using FS.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.CodeTool
{
    /// <summary>
    /// 生成文件模型
    /// </summary>
    public class GenFileModel
    {
        /// <summary>
        /// 要生成的表信息
        /// </summary>
        public List<DbTableInfo> Tables { get; set; }
        /// <summary>
        /// 文件生成目录
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 模型命名空间
        /// </summary>
        public string NameSpace { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string TemplateName { get; set; }
    }
}
