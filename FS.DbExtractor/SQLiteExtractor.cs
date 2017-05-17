//===================================================
//  Copyright @  Thpower.com 2017
//  作者：Fallstar
//  时间：2017-03-01 10:09:35
//  说明：SQLite数据库信息抽取器
//===================================================
using FS.DBAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace FS.DbExtractor
{
    /// <summary>
    /// SQLite数据库信息抽取器
    /// </summary>
    internal class SQLiteExtractor : DbExtractorAbstract, IDbExtractor
    {
        #region 初始化
        /// <summary>
        /// 实例化
        /// </summary>
        public SQLiteExtractor()
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
            var sql = @"select tbl_name as 'TABLE_NAME','' as 'COMMENTS' from sqlite_master where type='table'";
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
            var sqlFields = string.Format(@"PRAGMA table_info('{0}')", tableName);

            var dtCols = Provider.QueryData(sqlFields);
            if (dtCols == null)
                return null;

            foreach (DataRow dr in dtCols.Rows)
            {
                var it = new DbFieldInfo()
                {
                    FieldName = dr["name"].ToString(),
                    IsNullable = dr["notnull"].ToString().ToUpper() == "1",
                    Description = string.Empty,
                    FieldType = "string",
                };
                it.IsIdentity = dr["pk"].ToString() == "1";
                it.DataType = ConvertDataType(it);
            }
            return list;
        }
        #endregion

        #region 字段转换
        //所有类型转换 http://www.cnblogs.com/vjine/p/3462167.html
        //关于SQLite的数据类型 https://www.oschina.net/translate/data-types-in-sqlite-version-3
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
                throw new ArgumentException(nameof(info.FieldType) + "不可为空！");
            info.DataType = SqlType2CsharpTypeStr(info.FieldType, info.IsNullable);
            return info.DataType;
        }

        /// <summary>
        /// 将数据库类型转为系统类型。
        /// 这个方法还缺了类型转换，需要后续补充
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
            switch (sqlType.ToUpper())
            {
                case "NULL":
                    val = "string";
                    break;
                case "INTEGER":
                    val = "int";
                    break;

                case "REAL":
                    val = "double";
                    break;

                case "BLOB":
                    val = "byte[]";
                    allowNull = true;
                    break;

                case "TEXT":
                default:
                    //默认以字符串方式存储
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
