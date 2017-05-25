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
using RazorEngine;
using RazorEngine.Templating;
using System.IO;

namespace FS.TemplateEngine
{
    /// <summary>
    /// 模板管理帮助类
    /// </summary>
    public static class TempHelper
    {
        #region 读取模板

        #endregion

        #region 生成文件
        public static void GenFile(string tempFile, object model)
        {
            var n = Path.GetFileName(tempFile);
            var t = File.ReadAllText(tempFile);
            var result = Engine.Razor.RunCompile(t, n, model.GetType(), model);
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Replace("&lt;", "<").Replace("&gt;", ">");
            }
            Console.Write(result);
            //string template = "Hello @Model.Name, welcome to RazorEngine!";
            //string templateFile = "C:/mytemplate.cshtml";
            //var result = Engine.IsolatedRazor.RunCompile(new LoadedTemplateSource(template, templateFile), "templateKey", null, new { Name = "World" });
        }
        #endregion
    }
}
