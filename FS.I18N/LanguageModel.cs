//===================================================
//  作者：Fallstar
//  时间：2017-05-15 11:39:16
//  说明：语言模型
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FS.I18N
{
    /// <summary>
    /// 语言模型
    /// </summary>
    [XmlRoot("Language")]
    public class LanguageModel
    {
        #region Attr
        /// <summary>
        /// 语言代码
        /// </summary>
        [XmlAttribute]
        public string Code { get; set; }
        /// <summary>
        /// 语言显示名称
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }
        #endregion

        #region Prop
        /// <summary>
        /// 字符串集合
        /// </summary>
        [XmlElement("String")]
        public List<LanguageStingModel> Strings { get; set; }

        /// <summary>
        /// 以ID作为索引的字典
        /// </summary>
        private Dictionary<uint, string> dicID = null;
        /// <summary>
        /// 以Key作为索引的字典
        /// </summary>
        private Dictionary<string, string> dicKey = null;
        #endregion

        #region Func
        /// <summary>
        /// 初始化字典
        /// </summary>
        public void Init()
        {
            dicID = new Dictionary<uint, string>();
            dicKey = new Dictionary<string, string>();
            if (Strings == null || Strings.Count == 0) return;

            var dic1 = new Dictionary<uint, string>();
            var dic2 = new Dictionary<string, string>();

            foreach (var item in Strings)
            {
                if (dic1.ContainsKey(item.LocID))
                    dic1[item.LocID] = item.Value;
                else
                    dic1.Add(item.LocID, item.Value);

                if (string.IsNullOrEmpty(item.Key)) continue;
                if (dic2.ContainsKey(item.Key))
                    dic2[item.Key] = item.Value;
                else
                    dic2.Add(item.Key, item.Value);
            }
            dicID = dic1;
            dicKey = dic2;
        }
        /// <summary>
        /// 通过LocID来获取字符串，如果获取不到就返回null
        /// </summary>
        /// <param name="locID"></param>
        /// <returns></returns>
        internal string GetByID(uint locID)
        {
            if (dicID == null) Init();
            if (dicID.ContainsKey(locID)) return dicID[locID];
            return null;
        }
        /// <summary>
        /// 通过字符串Key来获取字符串，如果获取不到就返回null
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal string GetByKey(string key)
        {
            if (dicKey == null) Init();
            if (dicKey.ContainsKey(key)) return dicKey[key];
            return null;
        }

        /// <summary>
        /// 通过ID获取字符串，并进行字符串格式化，提供默认值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="pars">附带的参数</param>
        /// <returns></returns>
        public string GetRes(uint id, string defaultValue = null, params object[] pars)
        {
            var msg = GetByID(id);
            if (msg == null)
            {
                if (defaultValue == null)
                    return id.ToString();
                msg = defaultValue;
            }
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
        public string GetRes(LangMsgKeys id, string defaultValue = null, params object[] pars)
        {
            var msg = GetByID((uint)id);
            if (msg == null)
            {
                if (defaultValue == null)
                    return id.ToString();
                msg = defaultValue;
            }
            if (pars == null || pars.Length == 0) return msg;
            return string.Format(msg, pars);
        }

        /// <summary>
        /// 通过ID获取字符串，并进行字符串格式化，提供默认值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="pars">附带的参数</param>
        /// <returns></returns>
        public string GetRes(string key, string defaultValue = null, params object[] pars)
        {
            var msg = GetByKey(key);
            if (msg == null)
            {
                if (defaultValue == null)
                    return key;
                msg = defaultValue;
            }
            if (pars == null || pars.Length == 0) return msg;
            return string.Format(msg, pars);
        }

        #endregion
    }

    /// <summary>
    /// 语言字符串模型
    /// </summary>
    [XmlRoot("String")]
    public class LanguageStingModel
    {
        /// <summary>
        /// 唯一ID
        /// </summary>
        [XmlAttribute("LocID")]
        public uint LocID { get; set; }
        /// <summary>
        /// 用于字符串索引的Key，不是必须的
        /// </summary>
        [XmlAttribute("Key")]
        public string Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }

    /// <summary>
    /// Simply language info
    /// </summary>
    public class LanguageSimpleInfo
    {
        /// <summary>
        /// language name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// filename
        /// </summary>
        public string FileName { get; set; }
    }
}
