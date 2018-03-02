using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FS.DbModelTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            CheckDbConfigFile();
            FS.I18N.LangHelper.LoadLanguage();
            Application.Run(new FormMain());
        }

        /// <summary>
        /// 检查一下配置文件在不在
        /// </summary>
        public static void CheckDbConfigFile()
        {
            var file1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Db.config");
            if (File.Exists(file1)) return;
            var file2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Db.default.config");
            if (!File.Exists(file2))
            {
                MessageBox.Show("Db.default.config is missing!");
                Environment.Exit(1);
            }

            try
            {
                File.Copy(file2, file1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy file error : " + file2 + Environment.NewLine + ex.Message);
            }
        }
    }
}
