//===================================================
//  Copyright @  Thpower.com 2017
//  作者：Fallstar
//  时间：2017-02-28 16:46:10
//  说明：数据库信息抽取器工厂
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.DBAccess;
using System.Configuration;
using FS.I18N;

namespace FS.DbExtractor
{
    /// <summary>
    /// 数据库信息抽取器工厂
    /// </summary>
    public static class ExtractorFactory
    {
        /// <summary>
        /// 创建抽取器
        /// </summary>
        /// <param name="dbConnectionName"></param>
        /// <returns></returns>
        public static IDbExtractor Create(string dbConnectionName)
        {
            var cfg = ConfigurationManager.ConnectionStrings[dbConnectionName];
            var proName = cfg.ProviderName;
            if (string.IsNullOrEmpty(proName))
            {
                throw new InvalidOperationException(LangHelper.GetByID(181, dbConnectionName));
            }
            DBType dbType = DBType.Oracle;
            if (proName.Contains("Oracle.ManagedDataAccess"))
                dbType = DBType.Oracle;
            if (proName.Contains("System.Data.SqlClient"))
                dbType = DBType.SQLServer;
            if (proName.Contains("SQLite"))
                dbType = DBType.SQLite;
            if (proName.Contains("MySql"))
                dbType = DBType.MySQL;

            var extratractor = Create(dbType) as DbExtractorAbstract;
            extratractor.Provider = DbFactory.Create(dbConnectionName);
            extratractor.ConnectionString = cfg.ConnectionString;
            return extratractor as IDbExtractor;
        }
        /// <summary>
        /// 创建一个数据库信息抽取器
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IDbExtractor Create(DBType type)
        {
            switch (type)
            {
                case DBType.MySQL:
                    return new MySqlExtractor();

                case DBType.Oracle:
                    return new OracleExtractor();

                case DBType.SQLite:
                    return new SQLiteExtractor();

                case DBType.SQLServer:
                    return new MssqlExtractor();

                default:
                    throw new ArgumentException(LangHelper.GetByID(182, type));
            }

        }
    }
}
