//===================================================
//  Copyright @ fallstar0@qq.com 2016
//  作者：Fallstar
//  时间：2016-07-28 18:14:48
//  说明：数据库提供者代理工厂
//===================================================
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using FS.I18N;

namespace FS.DBAccess
{
    /// <summary>
    /// 数据库提供者代理工厂
    /// </summary>
    public static class DbFactory
    {
        #region 变量
        /// <summary>
        /// 数据库提供者工厂
        /// </summary>
        private static Dictionary<string, DbProviderFactory> factories = new Dictionary<string, DbProviderFactory>();
        /// <summary>
        /// 提供者的映射关系
        /// </summary>
        private static readonly Dictionary<DBType, string> providers = new Dictionary<DBType, string>()
        {
            {DBType.MySQL, "MySql.Data.MySqlClient"},
            {DBType.Oracle, "Oracle.ManagedDataAccess.Client"},
            {DBType.SQLite, "System.Data.SQLite"},
            {DBType.SQLServer, "System.Data.SqlClient"}
        };
        //private static readonly string[] dialectByProviderName = new string[]
        //        {
        //        "System.Data.SqlClient",
        //         "FirebirdSql.Data.FirebirdClient", //FirebirdDialect.Instance },
        //         "Npgsql", //PostgresDialect.Instance },
        //         "MySql.Data.MySqlClient", //MySqlDialect.Instance },
        //        "System.Data.SQLite", //SqliteDialect.Instance },
        //        "System.Data.OracleClient", //OracleDialect.Instance },
        //         "Oracle.ManagedDataAccess.Client", //OracleDialect.Instance }
        //    };
        #endregion

        #region 对外
        /// <summary>
        /// 创建数据库连接提供者
        /// </summary>
        /// <param name="connectionName">在配置文件里面的 connectionStrings 的 name</param>
        /// <returns></returns>
        public static DbProvider Create(string connectionName)
        {
            if (string.IsNullOrEmpty(connectionName))
                throw new ArgumentNullException(nameof(connectionName));
            var cfg = ConfigurationManager.ConnectionStrings[connectionName];
            if (cfg == null)
                throw new ArgumentException(LangHelper.GetRes(1600, "Can not find connection string with name of {0} !", connectionName));

            return Create(cfg.ProviderName, cfg.ConnectionString);
        }
        /// <summary>
        /// 创建一个数据库提供者
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static DbProvider Create(DbConnectionConfig config)
        {
            if (config == null)
                throw new ArgumentNullException("config");
            try
            {
                var factory = GetFactory(config.DBType);
                if (factory == null)
                    throw new NotImplementedException(LangHelper.GetRes(1601));
                DbProvider provider = null;

                switch (config.DBType)
                {
                    case DBType.Oracle:
                        //provider = new OracleDBProvider(factory, config);
                        break;

                    default:
                        throw new NotImplementedException(LangHelper.GetRes(1601));
                }
                //provider.ProviderFactory = factory;
                return provider;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 以数据库提供者名称和连接字符串创建数据库帮助类。
        /// </summary>
        /// <param name="providerName">如 Oracle.ManagedDataAccess.Client 和 System.Data.SqlClient 之类的</param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DbProvider Create(string providerName, string connectionString)
        {
            if (string.IsNullOrEmpty(providerName))
                throw new ArgumentNullException("providerName");
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString");
            try
            {
                var factory = GetFactory(providerName);
                if (factory == null)
                    throw new NotImplementedException(LangHelper.GetRes(1601));
                var provider = new DbProviderImpl(factory, connectionString);
                return provider;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 创建一个数据库提供者
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="dbName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static DbProvider Create(DBType dbType, string host, ushort port, string dbName, string userName, string password)
        {
            var cfg = new DbConnectionConfig()
            {
                DBType = dbType,
                Host = host,
                Port = port,
                DBName = dbName,
                UserName = userName,
                Password = password,
            };
            if (cfg.IsEmpty)
                throw new ArgumentException(LangHelper.GetRes(101));
            return Create(cfg);
        }

        /// <summary>
        /// 检查数据库连接是否正常
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static bool TestDbConnection(DbConnectionConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            using (var db = Create(config))
            {
                return db.TestConnection();
            }
        }
        #endregion

        #region 对内
        /// <summary>
        /// 通过提供者的名称来获取提供者
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        internal static DbProviderFactory GetFactory(string providerName)
        {
            DbProviderFactory factory;
            if (!factories.TryGetValue(providerName, out factory))
            {
                var newFactories = new Dictionary<string, DbProviderFactory>(factories);
                factory = newFactories[providerName] = DbProviderFactories.GetFactory(providerName);
                factories = newFactories;
            }
            return factory;
        }

        /// <summary>
        /// 通过类型来获取提供者
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        internal static DbProviderFactory GetFactory(DBType dbType)
        {
            if (!providers.ContainsKey(dbType)) return null;
            return GetFactory(providers[dbType]);
        }
        #endregion
    }
}
