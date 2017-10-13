//===================================================
//  Copyright @  Thpower.com 2017
//  作者：Fallstar
//  时间：2017-02-28 16:57:07
//  说明：实现了基本方法的数据库抽取器基类
//===================================================
using FS.DBAccess;
using System;
using System.Collections.Generic;
using System.Data;
using FS.I18N;
namespace FS.DbExtractor
{
    /// <summary>
    /// 实现了基本方法的数据库抽取器基类
    /// </summary>
    internal abstract class DbExtractorAbstract
    {
        #region 初始化
        /// <summary>
        /// 内部提供者
        /// </summary>
        internal DbProvider Provider { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        internal string ConnectionString { get; set; }
        /// <summary>
        /// 实例化
        /// </summary>
        public DbExtractorAbstract()
        {

        }
        #endregion

        #region 信息抽取
        /// <summary>
        /// 获取数据库的所有表的信息，
        /// 请定义TABLE_NAME 和 COMMENTS 字段的脚本
        /// </summary>
        /// <param name="sql">具体的脚本</param>
        /// <returns></returns>
        protected List<DbTableInfo> GetAllTablesInternal(string sql)
        {
            var dt = Provider.QueryData(sql);
            var list = new List<DbTableInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                var info = new DbTableInfo()
                {
                    TableName = dr["TABLE_NAME"].ToString(),
                    Description = dr["COMMENTS"] == DBNull.Value ? null : dr["COMMENTS"].ToString()
                };
                if (info.Description != null)
                    info.Description = info.Description.Trim();

                list.Add(info);
            }

            return list;
        }
        /// <summary>
        /// 获取表的所有字段名及字段类型
        /// </summary>
        /// <param name="tableName">数据表的名称</param>
        /// <returns></returns>
        protected List<DbFieldInfo> GetAllColumnsInternal(string tableName, string sql, List<string> listPK = null)
        {
            var list = new List<DbFieldInfo>();

            var dtCols = Provider.QueryData(sql);
            if (dtCols == null)
                return null;

            foreach (DataRow dr in dtCols.Rows)
            {
                var it = new DbFieldInfo()
                {
                    FieldName = dr["COLUMN_NAME"].ToString(),
                    IsNullable = dr["ISNULLABLE"].ToString().ToLower() == "false",
                    Description = dr["COMMENTS"].ToString(),
                    FieldType = dr["COLUMN_TYPE"].ToString(),
                };
                list.Add(it);
                byte b;
                if (dr["SCALE"] != DBNull.Value && byte.TryParse(dr["SCALE"].ToString(), out b))
                {
                    it.FieldScale = b;
                }
                if (dr["PRECISION"] != DBNull.Value && byte.TryParse(dr["PRECISION"].ToString(), out b))
                {
                    it.FieldPrecision = b;
                }
                if (listPK != null)
                    it.IsIdentity = listPK.Exists(x => x == it.FieldName);
            }
            return list;
        }
        #endregion

        #region 字段转换

        #endregion

        #region 其它
        /// <summary>
        /// 从连接字符串里面获取用户名
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        protected string GetUserId(string connString)
        {
            if (string.IsNullOrEmpty(connString))
                connString = ConnectionString;
            if (!connString.Contains(";"))
                throw new ArgumentException(LangHelper.GetByID(180));
            var sp1 = connString.Split(';');
            foreach (var item in sp1)
            {
                if (!item.Contains("=")) continue;
                var kv = item.Trim();
                if (!kv.StartsWith("User Id", StringComparison.OrdinalIgnoreCase)) continue;
                var sp2 = kv.Split('=');
                return sp2[1];
            }
            return null;
        }
        #endregion
    }
}
