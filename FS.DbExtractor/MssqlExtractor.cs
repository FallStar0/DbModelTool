//===================================================
//  Copyright @  fallstar0@qq.com 2017
//  作者：Fallstar
//  时间：2017-02-28 11:46:33
//  说明：MSSQL Server 的信息访问类。
//===================================================
using FS.DBAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FS.DbExtractor
{
    /// <summary>
    /// MSSQL Server 的信息访问类。
    /// </summary>
    internal class MssqlExtractor : DbExtractorAbstract, IDbExtractor
    {
        #region 初始化
        /// <summary>
        /// 实例化
        /// </summary>
        public MssqlExtractor()
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
            var sql = string.Format(@"SELECT tbs.name as TABLE_NAME,ds.value as COMMENTS FROM sys.tables tbs
left join sys.extended_properties ds on ds.major_id=tbs.object_id and ds.minor_id=0
order by TABLE_NAME asc");
            return GetAllTablesInternal(sql);
        }
        /// <summary>
        /// 获取表的所有字段名及字段类型
        /// </summary>
        /// <param name="tableName">数据表的名称</param>
        /// <returns></returns>
        public List<DbFieldInfo> GetAllColumns(string tableName)
        {
            if (tableName == null)
                throw new ArgumentNullException(nameof(tableName));
            var list = new List<DbFieldInfo>();
            var sqlFields = string.Format(@"
                select c.name,c.is_nullable,ds.value,ts.name as column_type,c.max_length,c.precision,c.scale
                from sys.columns c
                left join sys.extended_properties ds on ds.major_id=c.object_id and ds.minor_id=c.column_id
                left join sys.types ts on c.system_type_id=ts.system_type_id and ts.user_type_id=c.user_type_id
                left join sys.tables tbs on tbs.object_id=c.object_id
                where tbs.name='{0}' 
                order by c.column_id", tableName);
            var sqlFK = string.Format(@"
                select b.column_name 
                from  information_schema.table_constraints a
                inner join information_schema.constraint_column_usage b
                on a.constraint_name = b.constraint_name
                where a.constraint_type = 'PRIMARY KEY' 
                and a.table_name = '{0}'", tableName);

            //获取主键
            var listPK = new List<string>();
            var dtPK = Provider.QueryData(sqlFK);
            if (dtPK != null && dtPK.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPK.Rows)
                {
                    listPK.Add(dr["column_name"].ToString());
                }
            }

            var dtCols = Provider.QueryData(sqlFields);
            if (dtCols == null)
                return null;

            foreach (DataRow dr in dtCols.Rows)
            {
                var it = new DbFieldInfo()
                {
                    FieldName = dr["name"].ToString(),
                    IsNullable = dr["is_nullable"].ToString().ToLower() == "false",
                    Description = dr["value"].ToString(),
                    FieldType = dr["column_type"].ToString(),
                };
                list.Add(it);
                byte b;
                if (dr["scale"] != DBNull.Value && byte.TryParse(dr["scale"].ToString(), out b))
                {
                    it.FieldScale = b;
                }
                if (dr["precision"] != DBNull.Value && byte.TryParse(dr["precision"].ToString(), out b))
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
                throw new ArgumentNullException(nameof(info.FieldType));
            info.DataType = SqlType2CsharpTypeStr(info.FieldType, info.IsNullable);
            return info.DataType;
        }

        /// <summary>
        /// 将数据库类型转为系统类型。
        /// </summary>
        /// <param name="sqlType"></param>
        /// <param name="isNullable">字段是否可空</param>
        /// <returns></returns>
        public static string SqlType2CsharpTypeStr(string sqlType, bool isNullable = false)
        {
            if (string.IsNullOrEmpty(sqlType))
                throw new ArgumentNullException(nameof(sqlType));
            var val = string.Empty;
            var allowNull = false;
            switch (sqlType.ToLower())
            {
                case "bit":
                    val = "bool";
                    break;
                case "int":
                    val = "int";
                    break;
                case "smallint":
                    val = "short";
                    break;
                case "bigint":
                    val = "long";
                    break;
                case "tinyint":
                    val = "byte";
                    break;

                case "binary":
                case "image":
                case "varbinary":
                    val = "byte[]";
                    allowNull = true;
                    break;

                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                    val = "decimal";
                    break;

                case "float":
                    val = "float";
                    break;
                case "real":
                    val = "Single";
                    break;

                case "datetime":
                case "smalldatetime":
                case "timestamp":
                    val = "DateTime";
                    break;

                case "uniqueidentifier":
                    val = "Guid";
                    break;
                case "Variant":
                    val = "object";
                    allowNull = true;
                    break;

                case "text":
                case "ntext":
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                default:
                    val = "string";
                    allowNull = true;
                    break;
            }
            if (isNullable && !allowNull)
                return val + "?";
            return val;
        }
        #endregion
    }
}
