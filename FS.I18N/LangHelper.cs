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
    public static class LangHelper
    {
        #region 字段与属性
        /// <summary>
        /// 当前语言集合
        /// </summary>
        public static LanguageModel CurrentLanguage { get; private set; }
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
            CurrentLanguage = m;
            return m;
        }

        /// <summary>
        /// 保存语言文件【测试用】
        /// </summary>
        /// <param name="m"></param>
        internal static void SaveLanguage(LanguageModel m, string filePath)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));
            StoreHelper.SaveToFile(m, filePath);
        }
        #endregion

        #region 获取
        /// <summary>
        /// 获取语言模型
        /// </summary>
        /// <returns></returns>
        private static LanguageModel CheckModel()
        {
            var m = CurrentLanguage;
            if (m == null)
                throw new Exception("Please set a language before you use it！");
            return m;
        }
        /// <summary>
        /// 通过ID获取字符串
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetByID(uint id)
        {
            var m = CheckModel();
            return m.GetByID(id);
        }
        /// <summary>
        /// 通过ID获取字符串，并进行字符串格式化
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pars">附带的参数</param>
        /// <returns></returns>
        public static string GetByID(uint id, params object[] pars)
        {
            var m = CheckModel();
            var msg = m.GetByID(id);
            if (pars == null || pars.Length == 0) return msg;
            return string.Format(msg, pars);
        }
        /// <summary>
        /// 通过ID获取字符串，并进行字符串格式化
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pars">附带的参数</param>
        /// <returns></returns>
        public static string GetByID(LangMsgKeys id, params object[] pars)
        {
            var m = CheckModel();
            var msg = m.GetByID((uint)id);
            if (pars == null || pars.Length == 0) return msg;
            return string.Format(msg, pars);
        }
        /// <summary>
        /// 通过Key获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetByKey(string key)
        {
            var m = CheckModel();
            return m.GetByKey(key);
        }
        /// <summary>
        /// 通过Key获取，并进行字符串格式化
        /// </summary>
        /// <param name="key"></param>
        /// <param name="pars">附带的参数</param>
        /// <returns></returns>
        public static string GetByKey(string key, params object[] pars)
        {
            var m = CheckModel();
            var msg = m.GetByKey(key);
            if (pars == null || pars.Length == 0) return msg;
            return string.Format(msg, pars);
        }

        /// <summary>
        /// 通过ID获取字符串，并进行字符串格式化，提供默认值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="pars">附带的参数</param>
        /// <returns></returns>
        public static string GetRes(uint id, string defaultValue = null, params object[] pars)
        {
            var m = CheckModel();
            if (m == null)
            {
                if (defaultValue == null)
                    return id.ToString();
                return defaultValue;
            }
            return m.GetRes(id, defaultValue, pars);
        }

        /// <summary>
        /// 通过ID获取字符串，并进行字符串格式化，提供默认值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="pars">附带的参数</param>
        /// <returns></returns>
        public static string GetRes(LangMsgKeys id, string defaultValue = null, params object[] pars)
        {
            var m = CheckModel();
            if (m == null) return defaultValue ?? id.ToString();
            return m.GetRes(id, defaultValue, pars);
        }

        /// <summary>
        /// 通过ID获取字符串，并进行字符串格式化，提供默认值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="pars">附带的参数</param>
        /// <returns></returns>
        public static string GetRes(string key, string defaultValue = null, params object[] pars)
        {
            var m = CheckModel();
            if (m == null) return defaultValue;
            return m.GetRes(key, defaultValue, pars);
        }
        #endregion

    }
}
