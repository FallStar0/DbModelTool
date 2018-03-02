//===================================================
//  Copyright @ fallstar@qq.com 2018
//  作者：Fallstar
//  时间：2018-03-02 14:26:43
//  说明：统一管理版本
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS
{
    /// <summary>
    /// 统一管理版本
    /// </summary>
    public static class VerConstants
    {
        /// <summary>
        /// 文件版本
        /// </summary>
        public const string FileVersion = AssemblyVersion;

        /// <summary>
        /// 程序集版本，.Net会检查该版本。
        /// </summary>
        public const string AssemblyVersion = "1.0.0.0";

        /// <summary>
        /// 版权
        /// </summary>
        public const string Copyright = "Copyright © fallstar 2018";

        /// <summary>
        /// 公司名称
        /// </summary>
        public const string CompanyName = "Fallstar";
        /// <summary>
        /// 商标
        /// </summary>
        public const string Trademark = "fallstar@qq.com";
    }
}
