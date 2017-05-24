//===================================================
//  作者：Fallstar
//  时间：2017-05-15 11:36:38
//  说明：国际化语言管理器
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.I18N
{
    /// <summary>
    /// 国际化语言管理器
    /// </summary>
    public static class I18NHelper
    {
        #region 字段与属性
        /// <summary>
        /// 当前语言集合
        /// </summary>
        public static LanguageModel CurrentLanguage { get; set; }
        #endregion

        #region 初始化
        /// <summary>
        /// 加载某种语言
        /// </summary>
        /// <param name="code">如果不设置就根据系统获取</param>
        /// <returns></returns>
        public static LanguageModel LoadLanguage(string code = null)
        {
            if (string.IsNullOrEmpty(code))
                code = System.Globalization.CultureInfo.InstalledUICulture.Name;
            code = code.ToLower();

            var m = StoreHelper.LoadByCode(code);
            return m;
        }
        #endregion

        #region 获取
        /// <summary>
        /// 通过ID获取字符串
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetByLocId(uint id)
        {
            return id.ToString();
        }
        /// <summary>
        /// 通过Key获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetByKey(string key)
        {
            return key;
        }
        #endregion

    }
}
