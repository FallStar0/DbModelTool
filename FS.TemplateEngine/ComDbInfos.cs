//===================================================
//  Copyright @  2017
//  作者：Fallstar
//  时间：2017-05-25 16:48:48
//  说明：一般数据库信息，用于构造模板
//===================================================
using System;
using System.Collections.Generic;
using FS.DBAccess;

namespace FS.TemplateEngine
{
    /// <summary>
    /// 一般数据库信息，用于构造模板
    /// </summary>
    public class ComDbInfos
    {
        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }
        /// <summary>
        /// 表信息
        /// </summary>
        public DbTableInfo Table { get; set; }
    }
}
