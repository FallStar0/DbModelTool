//===================================================
//  Copyright @ fallstar0@qq.com 2016
//  作者：Fallstar
//  时间：2016-07-28 18:15:30
//  说明：数据库提供着基类，主要是封装了Dapper作为数据查询类
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using System.Data.Common;

namespace FS.DBAccess
{
    /// <summary>
    /// 数据库提供着基类，主要是封装了Dapper作为数据查询类
    /// </summary>
    public abstract class DbProvider : IDisposable
    {
        #region 字段与属性
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        protected IDbConnection DbConn { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        protected string ConString { get; set; }
        /// <summary>
        /// 提供者工厂，内部用
        /// </summary>
        internal DbProviderFactory ProviderFactory { get; set; }
        #endregion

        #region 初始化
        /// <summary>
        /// 以连接字符串方式来初始化
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="conString"></param>
        internal DbProvider(DbProviderFactory factory, string conString)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));
            if (string.IsNullOrEmpty(conString))
                throw new ArgumentNullException(nameof(conString));
            ProviderFactory = factory;
            ConString = conString;
            //创建连接对象
            DbConn = CreateConnection(ConString);
        }
        /// <summary>
        /// 创建一个数据库连接提供者
        /// </summary>
        /// <param name="config">数据库连接配置</param>
        internal DbProvider(DbProviderFactory factory, DbConnectionConfig config) : this(factory, config.Host, config.Port, config.DBName, config.UserName, config.Password)
        {
            if (config == null)
                throw new ArgumentNullException("config");
        }
        /// <summary>
        /// 创建一个数据库连接提供者
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="port">端口</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        internal DbProvider(DbProviderFactory factory, string address, ushort port, string dbName, string userName, string password)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException("address");
            if (string.IsNullOrEmpty(dbName))
                throw new ArgumentNullException("dbName");
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));
            ProviderFactory = factory;
            //创建连接字符串
            ConString = CreateConnectionString(address, port, dbName, userName, password);
            if (string.IsNullOrEmpty(ConString))
                throw new Exception("创建数据连接字符串失败");
            //创建连接对象
            DbConn = CreateConnection(ConString);
        }

        #endregion

        #region 抽象方法
        /// <summary>
        /// 创建数据库连接
        /// </summary>
        /// <param name="conString">如果不传入，则根据初始化时候传入的信息来实现</param>
        /// <returns></returns>
        protected virtual IDbConnection CreateConnection(string conString = null)
        {
            var con = ProviderFactory.CreateConnection();
            con.ConnectionString = conString;
            return con;
        }
        /// <summary>
        /// 创建数据库连接字符串
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="port">端口</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        protected abstract string CreateConnectionString(string address, ushort port, string dbName, string userName, string password);
        /// <summary>
        /// 获取一个数据匹配器
        /// </summary>
        /// <returns></returns>
        protected virtual DbDataAdapter CreateAdapter()
        {
            var ad = ProviderFactory.CreateDataAdapter();
            return ad;
        }
        /// <summary>
        /// 创建一个命令构建器
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        protected virtual DbCommandBuilder CreateCommandBulider(DbDataAdapter da)
        {
            var cb = ProviderFactory.CreateCommandBuilder();
            cb.DataAdapter = da;
            return cb;
        }
        #endregion

        #region 对外提供对象的功能
        /// <summary>
        /// 获取命令对象
        /// </summary>
        /// <returns></returns>
        public virtual DbCommand CreateCommand()
        {
            return ProviderFactory.CreateCommand();
        }
        /// <summary>
        /// 获取输入的格式化参数
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public virtual IDbDataParameter GetDataParameter(string paramName, object value, DbType dbType)
        {
            var par = GetDataParameter(paramName, value);
            par.DbType = dbType;
            return par;
        }
        /// <summary>
        /// 获取输入的格式化参数
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual IDbDataParameter GetDataParameter(string paramName, object value)
        {
            var par = ProviderFactory.CreateParameter();
            par.ParameterName = paramName;
            par.Value = value;
            return par;
        }
        /// <summary>
        /// 开始一个新的事务
        /// </summary>
        /// <returns></returns>
        public virtual IDbTransaction BeginTransaction()
        {
            DbConn.Open();
            return DbConn.BeginTransaction();
        }

        #endregion

        #region 查询方法-想要更多方法的话，请从 Dapper 复制过来。。。
        /// <summary>
        /// 执行SQL，并返回IDataReader对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dbParams"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string sql, IEnumerable<IDbDataParameter> dbParams = null, IDbTransaction dbTran = null, CommandType? cmdType = null)
        {
            var d = CreateParameter(dbParams);
            return DbConn.ExecuteReader(sql, d, dbTran, null, cmdType);
        }

        /// <summary>
        /// 执行SQL获取DataTable
        /// </summary>
        /// <param name="sql">查询SQL</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>返回的结果集，null为执行失败</returns>
        public virtual DataTable QueryData(string sql, IEnumerable<IDbDataParameter> parameters = null)
        {
            var d = CreateParameter(parameters);
            using (var dr = DbConn.ExecuteReader(sql, d))
            {
                var dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
        }
        /// <summary>
        /// 执行脚本，并返回模型列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="dbTran"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> Query<T>(string sql, IEnumerable<IDbDataParameter> parameters = null, IDbTransaction dbTran = null, CommandType? cmdType = null)
        {
            var d = CreateParameter(parameters);
            return DbConn.Query<T>(sql, d, dbTran, true, null, cmdType);
        }
        #endregion

        #region 批量方法
        /// <summary>
        /// 批量更新操作，包括 更新、插入、删除，
        /// 虽然方便，但是效率可能不高。
        /// 【这是通用的，可以不用继承实现的】
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="selectCmd">查询这部分数据的Sql语句，需要CommandText ，如果有参数化就需要填充 Parameters</param>
        public virtual bool BatchUpdate(DataTable dt, DbCommand selectCmd)
        {
            if (dt == null)
                throw new ArgumentNullException("dt");
            if (string.IsNullOrEmpty(dt.TableName))
                throw new ArgumentException("TableName 属性必须为要操作的数据表的名称！");
            try
            {
                var da = CreateAdapter();
                da.SelectCommand = selectCmd;
                da.UpdateBatchSize = 1000;

                var builder = CreateCommandBulider(da);
                da.Update(dt);
            }
            catch
            {
                throw;
            }
            return true;
        }
        /// <summary>
        /// 批量更新，需要自行实现。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public abstract bool BatchUpdate(DataTable dt);
        #endregion

        #region 执行方法
        /// <summary>
        /// 执行脚本，并返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="dbTran"></param>
        /// <param name="cmdType"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public virtual int Execute(string sql, IEnumerable<IDbDataParameter> parameters = null, IDbTransaction dbTran = null, CommandType? cmdType = null, int? timeOut = null)
        {
            var d = CreateParameter(parameters);
            return DbConn.Execute(sql, d, dbTran, timeOut, cmdType);
        }
        /// <summary>
        /// 执行SQL获取首行首列单元值
        /// </summary>
        /// <param name="sql">查询SQL</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="dbTran">事务</param>
        /// <param name="cmdType">命令类型</param>
        /// <returns>返回的首行结果，null为执行失败，DBNull为空值</returns>
        public virtual object ExecuteScalar(string sql, IEnumerable<IDbDataParameter> parameters = null, IDbTransaction dbTran = null, CommandType? cmdType = null)
        {
            var d = CreateParameter(parameters);
            return DbConn.ExecuteScalar(sql, d, dbTran, null, cmdType);
        }

        /// <summary>
        /// 执行SQL获取首行首列单元值
        /// </summary>
        /// <param name="sql">查询SQL</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="dbTran">事务</param>
        /// <param name="cmdType">命令类型</param>
        /// <returns>返回的首行结果，null为执行失败，DBNull为空值</returns>
        public virtual T ExecuteScalar<T>(string sql, IEnumerable<IDbDataParameter> parameters = null, IDbTransaction dbTran = null, CommandType? cmdType = null)
        {
            var d = CreateParameter(parameters);
            return DbConn.ExecuteScalar<T>(sql, d, dbTran, null, cmdType);
        }

        /// <summary>
        /// 执行SQL，返回影响的行数量
        /// </summary>
        /// <param name="sql">查询SQL</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="dbTran">事务</param>
        /// <param name="cmdType">命令类型</param>
        /// <returns>影响的行数量，-1为执行失败</returns>
        public virtual int ExecuteNonQuery(string sql, IEnumerable<IDbDataParameter> parameters = null, IDbTransaction dbTran = null, CommandType? cmdType = null)
        {
            var d = CreateParameter(parameters);
            return DbConn.Execute(sql, d, dbTran, null, cmdType);
        }

        /// <summary>
        /// 以事物方式批量执行脚本，执行失败会回滚。
        /// </summary>
        /// <param name="sqls"></param>
        /// <param name="parameters"></param>
        /// <returns>返回执行是否成功</returns>
        public virtual bool ExcuteBatchSql(IEnumerable<string> sqls, IEnumerable<IDbDataParameter> parameters = null)
        {
            using (var cmd = DbConn.CreateCommand())
            using (var tran = DbConn.BeginTransaction())
            {
                try
                {
                    cmd.Transaction = tran;
                    if (parameters != null && parameters.Count() > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    foreach (var item in sqls)
                    {
                        cmd.CommandText = item;
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            return true;
        }
        #endregion

        #region 其它方法
        /// <summary>
        /// 测试数据库连接是否成功
        /// </summary>
        /// <param name="catchExecption"></param>
        /// <returns></returns>
        public bool TestConnection(bool catchExecption = false)
        {
            try
            {
                DbConn.Open();
                return true;
            }
            catch
            {
                if (!catchExecption)
                    throw;
                else
                    return false;
            }
        }
        #endregion

        #region 内部方法
        /// <summary>
        /// 创建Dapper用的参数列表
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected static DynamicParameters CreateParameter(IEnumerable<IDbDataParameter> parameters)
        {
            if (parameters == null || parameters.Count() == 0) return null;
            var d = new DynamicParameters();
            foreach (var item in parameters)
            {
                d.Add(item.ParameterName, item.Value, item.DbType, item.Direction, item.Size);
            }
            return d;
        }

        /// <summary>
        /// 准备命令
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dbParams"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        protected IDbCommand PrepareCommand(string sql, IEnumerable<IDbDataParameter> dbParams = null, IDbTransaction dbTran = null, CommandType? cmdType = null)
        {
            var cmd = DbConn.CreateCommand();
            cmd.CommandText = sql;
            if (cmdType != null)
                cmd.CommandType = cmdType.Value;
            if (dbTran != null)
                cmd.Transaction = dbTran;
            if (dbParams != null && dbParams.Count() > 0)
            {
                cmd.Parameters.Clear();
                foreach (var item in dbParams)
                {
                    if (!cmd.Parameters.Contains(item))
                        cmd.Parameters.Add(item);
                }
            }
            return cmd;
        }

        /// <summary>
        /// 转换DataTable为列行数组[Col][Row]
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>
        /// <returns>列行数组</returns>
        protected static object[][] DataTableToArray(DataTable dt)
        {
            if (dt == null) return null;

            object[][] array = new object[dt.Columns.Count][];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                array[i] = new object[dt.Rows.Count];
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    if (dt.Rows[n][i] == null)
                    {
                        array[i][n] = DBNull.Value;
                    }
                    else
                    {
                        array[i][n] = dt.Rows[n][i];
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            if (DbConn != null)
            {
                DbConn.Close();
                DbConn.Dispose();
            }
        }
        #endregion
    }
}
