//===================================================
//  Copyright @ fallstar0@qq.com 2016
//  作者：Fallstar
//  时间：2016-09-13 15:07:07
//  说明：数据库类型
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FS.DBAccess
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DBType
    {
        /// <summary>
        /// Mssql Server
        /// </summary>
        SQLServer,
        /// <summary>
        /// MySQL
        /// </summary>
        MySQL,
        /// <summary>
        /// Oracle
        /// </summary>
        Oracle,
        /// <summary>
        /// SQLite
        /// </summary>
        SQLite,
    }
}
