//===================================================
//  作者：Fallstar
//  时间：2017-05-15 11:52:15
//  说明：存储帮助类
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FS.I18N
{
    /// <summary>
    /// 存储帮助类
    /// </summary>
    internal static class StoreHelper
    {
        #region Load
        /// <summary>
        /// 根据语言代码（文件名，无后缀）来获取
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static LanguageModel LoadByCode(string code)
        {
            var p = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, code + ".xml");
            return LoadByFile(p);
        }

        /// <summary>
        /// 从文件加载语言
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static LanguageModel LoadByFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new ArgumentException("FilePath not exist:" + filePath);

            var m = XmlSerializeHelper.Load<LanguageModel>(filePath);
            return m;
        }
        #endregion

        #region Save
        /// <summary>
        /// 保存到文件
        /// </summary>
        /// <param name="model"></param>
        /// <param name="filePath"></param>
        public static void SaveToFile(LanguageModel model, string filePath)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new ArgumentException("FilePath not exist:" + filePath);

            XmlSerializeHelper.Save(model, filePath);
        }
        #endregion
    }
}
