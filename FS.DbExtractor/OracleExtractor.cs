//===================================================
//  Copyright @  Thpower.com 2017
//  作者：Fallstar
//  时间：2017-02-28 16:51:33
//  说明：Oracle数据库信息抽取器
//===================================================
using FS.DBAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.DbExtractor
{
    /// <summary>
    /// Oracle数据库信息抽取器
    /// </summary>
    internal class OracleExtractor : DbExtractorAbstract, IDbExtractor
    {
        #region 初始化
        /// <summary>
        /// 实例化
        /// </summary>
        public OracleExtractor()
        {

        }
        #endregion

        #region 信息抽取
        /// <summary>
        /// 获取数据库的所有表的信息
        /// </summary>
        /// <returns></returns>
        public List<DbTableInfo> GetAllTables()
        {
            var sql = @"select a.TABLE_NAME,b.COMMENTS 
                from user_tables a,user_tab_comments b 
                WHERE a.TABLE_NAME=b.TABLE_NAME";
            return GetAllTablesInternal(sql);
        }
        /// <summary>
        /// 获取表的所有字段名及字段类型
        /// </summary>
        /// <param name="tableName">数据表的名称</param>
        /// <returns></returns>
        public List<DbFieldInfo> GetAllColumns(string tableName)
        {
            var list = new List<DbFieldInfo>();
            var sqlFields = string.Format(@"select a.*,b.COMMENTS
                from user_tab_columns a, user_col_comments b
                where a.TABLE_NAME=b.TABLE_NAME and a.COLUMN_NAME=b.COLUMN_NAME 
                and a.TABLE_NAME='{0}'
                order by column_id", tableName);
            var user = GetUserId(null);
            var sqlFK = string.Format(@"select * from user_cons_columns c,user_constraints d
                    where c.owner='{1}' and c.constraint_name=d.constraint_name
                    and c.TABLE_NAME='{0}' ", tableName, user);

            //CONSTRAINT_TYPE
            //C--check ,present in a static list of values permitted for the column. 
            //P--primary key ,unique and not null,可以是多个column的联合。composite pk只能被定义为table constraint
            //R--forgien key ,parent table 中的primary key中的values必须包含child table中所有的values. share column的parent-child 关系 
            //U--unique ,唯一

            //获取主键
            var listPK = new List<string>();
            var dtPK = Provider.QueryData(sqlFK);
            if (dtPK != null && dtPK.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPK.Rows)
                {
                    if (dr["CONSTRAINT_TYPE"].ToString() != "P") continue;
                    listPK.Add(dr["COLUMN_NAME"].ToString());
                }
            }

            var dtCols = Provider.QueryData(sqlFields);
            if (dtCols == null)
                return null;

            foreach (DataRow dr in dtCols.Rows)
            {
                var it = new DbFieldInfo()
                {
                    FieldName = dr["COLUMN_NAME"].ToString(),
                    IsNullable = dr["NULLABLE"].ToString().ToUpper() != "N",
                    Description = dr["COMMENTS"].ToString(),
                    FieldType = dr["DATA_TYPE"].ToString(),
                };
                list.Add(it);
                byte b;
                if (dr["DATA_SCALE"] != DBNull.Value && byte.TryParse(dr["DATA_SCALE"].ToString(), out b))
                {
                    it.FieldScale = b;
                }
                if (dr["DATA_PRECISION"] != DBNull.Value && byte.TryParse(dr["DATA_PRECISION"].ToString(), out b))
                {
                    it.FieldPrecision = b;
                }
                it.IsIdentity = listPK.Exists(x => x == it.FieldName);
                it.DataType = ConvertDataType(it);
            }
            return list;
        }
        #endregion

        #region 字段转换
        //所有类型转换 http://www.cnblogs.com/vjine/p/3462167.html
        /// <summary>
        /// 将字段信息的类型转换为C#信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public string ConvertDataType(DbFieldInfo info)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            if (string.IsNullOrEmpty(info.FieldType))
                throw new ArgumentException(nameof(info.FieldType));
            info.DataType = SqlType2CsharpTypeStr(info.FieldType, info.IsNullable, info.FieldPrecision, info.FieldScale);
            return info.DataType;
        }

        /// <summary>
        /// 将数据库类型转为系统类型。
        /// </summary>
        /// <param name="sqlType"></param>
        /// <param name="isNullable">字段是否可空</param>
        /// <returns></returns>
        public static string SqlType2CsharpTypeStr(string sqlType, bool isNullable = false, ushort length = 0, byte scale = 0)
        {
            if (string.IsNullOrEmpty(sqlType))
                throw new ArgumentNullException(nameof(sqlType));
            var val = string.Empty;
            var allowNull = false;
            switch (sqlType.ToUpper())
            {
                case "NUMBER":
                    if (scale == 0)
                    {
                        if (length == 0)
                        {
                            //throw new ArgumentException(nameof(precision) + "不能为0（NUMBER）！");
                            val = "decimal";
                            break;
                        }

                        //boolean没法判断
                        if (length == 1)
                            val = "bool";
                        else if (length < 3)
                            val = "sbyte";
                        else if (length < 5)
                            val = "short";
                        else if (length <= 9)
                            val = "int";
                        else if (length <= 19)
                            val = "long";
                        else
                            val = "decimal";
                    }
                    else
                    {
                        if (length <= 7 && scale <= 3)
                            val = "float";
                        else if (length <= 15 && scale <= 5)
                            val = "double";
                        else
                            val = "decimal";
                    }
                    break;
                case "LONG":
                    val = "long";
                    break;

                case "DOUBLE":
                case "BINARY_DOUBLE":
                    val = "double";
                    break;

                case "DATE":
                    val = "DateTime";
                    break;

                case "CHAR":
                case "VARCHAR2":
                case "NVARCHAR2":
                case "CLOB":
                case "NCLOB":
                    val = "string";
                    allowNull = true;
                    break;

                case "BLOB":
                case "RAW":
                    val = "byte[]";
                    break;

                default:
                    throw new Exception(I18N.LangHelper.GetByID(183, sqlType));
            }
            if (isNullable && !allowNull)
                return val + "?";
            return val;
        }
        #endregion
    }
}
