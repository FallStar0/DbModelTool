//===================================================
//  Copyright @ fallstar0@qq.com 2016
//  作者：Fallstar
//  时间：2016-10-12 17:48:21
//  说明：一个用于提供基本功能的实现类
//===================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace FS.DBAccess
{
    /// <summary>
    /// 一个用于提供基本功能的实现类
    /// </summary>
    class DbProviderImpl : DbProvider
    {
        /// <summary>
        /// 以连接字符串方式来初始化
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="conString"></param>
        internal DbProviderImpl(DbProviderFactory factory, string conString) : base(factory, conString)
        {

        }
        public override bool BatchUpdate(DataTable dt)
        {
            throw new NotImplementedException();
        }

        protected override string CreateConnectionString(string address, ushort port, string dbName, string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
