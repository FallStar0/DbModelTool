using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FS.TemplateEngine;
using System.IO;
using System.Collections.Generic;

namespace FS.Test
{
    [TestClass]
    public class TemplateTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var t = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "DbTableModel.cshtml");
            var m = new ComDbInfos()
            {
                NameSpace = "Thp.Model.DbModel",
                Table = new DBAccess.DbTableInfo() { Description = "测试", TableName = "Table_Test" }
            };
            var list = new List<DBAccess.DbFieldInfo>();
            m.Table.Fileds = list;
            list.Add(new DBAccess.DbFieldInfo()
            {
                DataType = "string",
                FieldName = "Test1",
                Description = "Test1 desc",
            });
            list.Add(new DBAccess.DbFieldInfo()
            {
                DataType = "bool",
                FieldName = "Test2",
                Description = "Test2 desc",
                IsNullable = true,
            });
            list.Add(new DBAccess.DbFieldInfo()
            {
                DataType = "DateTime",
                FieldName = "Test3",
                Description = "Test3 desc",
                IsNullable = false,
            });
            var res = TempHelper.GenCode2(t, m);
            Assert.IsNotNull(res);
            Console.WriteLine(res);
        }
    }
}
