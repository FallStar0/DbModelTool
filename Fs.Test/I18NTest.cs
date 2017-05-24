using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FS.I18N;
using System.IO;

namespace Fs.Test
{
    [TestClass]
    public class I18NTest
    {
        [TestMethod]
        public void LoadLang()
        {
            var m = LangHelper.LoadLanguage();
            Assert.IsNotNull(m);

            m = LangHelper.LoadLanguage("en-us");
            Assert.IsNotNull(m);
        }

        [TestMethod]
        public void SaveNewLang()
        {
            var m = LangHelper.LoadLanguage();
            Assert.IsNotNull(m);
            if (m.Strings == null)
                m.Strings = new System.Collections.Generic.List<LanguageStingModel>();
            m.Strings.Add(new LanguageStingModel()
            {
                Key = "xxxxxx",
                LocID = 100000,
                Value = "测试策划四三三四四"
            });
            m.Strings.Add(new LanguageStingModel()
            {
                Key = "yyyy",
                LocID = 100001,
                Value = "测试ing1"
            });
            var p = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Language", "test.xml");
            //LangHelper.SaveLanguage(m, p);
        }
    }
}
