//===================================================
//  Copyright @  fallstar0@qq.com 2017
//  作者：Fallstar
//  时间：2017-02-28 17:54:05
//  说明：MySql数据库信息抽取器
//===================================================
using FS.DBAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace FS.DbExtractor
{
    /// <summary>
    /// MySql数据库信息抽取器
    /// </summary>
    internal class MySqlExtractor : DbExtractorAbstract, IDbExtractor
    {
        #region 初始化
        /// <summary>
        /// 实例化
        /// </summary>
        public MySqlExtractor()
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
            var user = GetUserId(null);
            var sql = string.Format(@"SELECT TABLE_NAME as TABLE_NAME,TABLE_COMMENT as COMMENTS 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = '{0}'", user);
            return GetAllTablesInternal(sql);
        }
        /// <summary>
        /// 获取表的所有字段名及字段类型
        /// </summary>
        /// <param name="tableName">数据表的名称</param>
        /// <returns></returns>
        public List<DbFieldInfo> GetAllColumns(string tableName)
        {
            var user = GetUserId(null);
            var list = new List<DbFieldInfo>();
            var sqlFields = string.Format(@" select * from INFORMATION_SCHEMA.Columns 
                where table_name='{0}' 
                and table_schema='{1}'", tableName, user);

            var dtCols = Provider.QueryData(sqlFields);
            if (dtCols == null)
                return null;

            foreach (DataRow dr in dtCols.Rows)
            {
                var it = new DbFieldInfo()
                {
                    FieldName = dr["COLUMN_NAME"].ToString(),
                    IsNullable = dr["IS_NULLABLE"].ToString().ToUpper() != "NO",
                    Description = dr["COLUMN_COMMENT"].ToString(),
                    FieldType = dr["COLUMN_TYPE"].ToString(),
                };
                if (it.FieldType.Contains("("))
                    it.FieldType = it.FieldType.Substring(0, it.FieldType.IndexOf("("));
                list.Add(it);
                byte b;
                if (dr["NUMERIC_SCALE"] != DBNull.Value && byte.TryParse(dr["NUMERIC_SCALE"].ToString(), out b))
                {
                    it.FieldScale = b;
                }
                ushort us;
                if (dr["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value && ushort.TryParse(dr["CHARACTER_MAXIMUM_LENGTH"].ToString(), out us))
                {
                    it.FieldPrecision = us;
                }
                it.IsIdentity = dr["COLUMN_KEY"].ToString() == "PRI";
                it.DataType = ConvertDataType(it);
            }
            return list;
        }
        #endregion

        #region 字段转换
        //关于MySql的类型介绍，请查看这个连接：http://www.cnblogs.com/kissdodog/p/4159176.html
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
        public static string SqlType2CsharpTypeStr(string sqlType, bool isNullable = false, ushort precision = 0, byte scale = 0)
        {
            if (string.IsNullOrEmpty(sqlType))
                throw new ArgumentNullException(nameof(sqlType));
            var val = string.Empty;
            var allowNull = false;
            switch (sqlType.ToUpper())
            {
                case "BOOL":
                    val = "bool";
                    break;

                case "TINYINT":
                    val = "sbyte";
                    break;
                case "SMALLINT":
                    val = "short";
                    break;
                case "INT":
                    val = "int";
                    break;
                case "BIGINT":
                    val = "long";
                    break;

                case "DATE":
                case "DATETIME":
                case "TIMESTAMP":
                    val = "DateTime";
                    break;

                case "FLOAT":
                    val = "float";
                    break;
                case "DOUBLE":
                    val = "double";
                    break;
                case "DECIMAL":
                    val = "decimal";
                    break;

                case "CHAR":
                case "VARCHAR":
                case "TINYTEXT":
                case "TEXT":
                case "MEDIUMTEXT":
                case "LONGTEXT":
                    val = "string";
                    allowNull = true;
                    break;

                case "BINARY":
                case "VARBINARY":
                case "BIT":
                case "TINYBLOB":
                case "BLOB":
                case "MEDIUMBLOB":
                case "LONGBLOB":
                    val = "byte[]";
                    allowNull = true;
                    break;

                default:
                    throw new Exception(I18N.LangHelper.GetRes(1623, "Database field type {0} is not support to convert to system type.", sqlType));
            }
            if (isNullable && !allowNull)
                return val + "?";
            return val;
        }
        #endregion
    }
}
