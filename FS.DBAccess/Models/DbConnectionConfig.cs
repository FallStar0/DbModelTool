//===================================================
//  Copyright @ fallstar0@qq.com 2016
//  作者：Fallstar
//  时间：2016-09-13 15:06:44
//  说明：数据库连接配置
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FS.DBAccess
{
    /// <summary>
    /// 数据库连接配置
    /// </summary>
    [Description("数据库连接配置")]
    public class DbConnectionConfig
    {
        private DBType dBType = DBType.Oracle;
        /// <summary>
        /// 数据库类型
        /// </summary>
        [Description("数据库类型"), DisplayName("数据库类型"), Category("基本")]
        public DBType DBType { get { return dBType; } set { dBType = value; } }

        private string host = "127.0.0.1";
        /// <summary>
        /// 主机名/IP地址
        /// </summary>
        [Description("主机名/IP地址"), DisplayName("主机名"), Category("基本")]
        public string Host { get { return host; } set { host = value; } }

        private ushort port = 1521;
        /// <summary>
        /// 端口
        /// </summary>
        [Description("端口"), DisplayName("端口"), Category("基本")]
        public ushort Port { get { return port; } set { port = value; } }

        /// <summary>
        /// 数据库名/实例名
        /// </summary>
        [Description("数据库名/实例名"), DisplayName("数据库名"), Category("基本")]
        public string DBName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Description("用户名"), DisplayName("用户名"), Category("基本")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Description("密码"), DisplayName("密码"), Category("基本")]
        public string Password { get; set; }

        /// <summary>
        /// 配置是否为空
        /// </summary>
        [Browsable(false)]
        public virtual bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(Host) || string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(DBName);
            }
        }
        /// <summary>
        /// 配置是否一致
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public bool IsEqual(DbConnectionConfig cfg)
        {
            if (cfg == null) return false;
            return cfg.DBName == DBName && cfg.DBType == this.DBType && cfg.Host == this.Host && cfg.Password == this.Password && cfg.Port == this.Port && cfg.UserName == this.UserName;
        }

        /// <summary>
        /// 转为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}@{1}:{2}/{3}", this.UserName, this.Host, this.Port, this.DBName);
        }
    }
}
