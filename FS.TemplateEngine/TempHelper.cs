//===================================================
//  Copyright @  Fallstar 2017
//  作者：Fallstar
//  时间：2017-05-25 16:27:52
//  说明：模板管理帮助类
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RazorEngine;
//using RazorEngine.Templating;
using RazorEngineCore;
using System.IO;
using FS.DBAccess;

namespace FS.TemplateEngine
{
    /// <summary>
    /// 模板管理帮助类
    /// </summary>
    public static class TempHelper
    {
        #region 静态
        /// <summary>
        /// 模板所在的目录
        /// </summary>
        public static readonly string TemplateFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");
        #endregion

        #region 读取模板
        /// <summary>
        /// 读取模板列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTemplateList()
        {
            if (!Directory.Exists(TemplateFolder))
                throw new DirectoryNotFoundException(TemplateFolder);
            var files = Directory.GetFiles(TemplateFolder, "*.cshtml");
            return files.ToList();
        }
        #endregion

        #region 生成
        /// <summary>
        /// 生成代码字符串
        /// </summary>
        /// <param name="tempFile"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Obsolete]
        public static string GenCode(string tempFile, object model)
        {
            if (string.IsNullOrEmpty(tempFile)) throw new ArgumentNullException(nameof(tempFile));
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (!tempFile.Contains("/"))
            {
                tempFile = Path.Combine(TemplateFolder, tempFile);
            }
            var n = Path.GetFileName(tempFile);
            var t = File.ReadAllText(tempFile);
            //var result = Engine.Razor.RunCompile(t, n, model.GetType(), model);
            //return result;
            return null;
        }

        /// <summary>
        /// 生成代码字符串
        /// </summary>
        /// <param name="tempFile"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string GenCode2(string tempFile, object model)
        {
            if (string.IsNullOrEmpty(tempFile)) throw new ArgumentNullException(nameof(tempFile));
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (!tempFile.Contains("/"))
            {
                tempFile = Path.Combine(TemplateFolder, tempFile);
            }
            var n = Path.GetFileName(tempFile);
            var t = File.ReadAllText(tempFile);

            var razorEngine = new RazorEngine();
            var template = razorEngine.Compile(t, builder =>
            {
                //builder.AddAssemblyReferenceByName("System.Security"); // by name
                builder.AddAssemblyReference(typeof(File)); // by type
                builder.AddAssemblyReference(typeof(DateTime));
                builder.AddAssemblyReference(typeof(DbTool).Assembly);
                builder.AddAssemblyReference(typeof(TempHelper).Assembly);
            });
            var result = template.Run(model);
            return result;
        }

        #endregion
    }
}
