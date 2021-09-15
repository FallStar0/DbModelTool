using FS.DBAccess;
using FS.I18N;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FS.DbModelTool
{
    public partial class FormMain : Form
    {
        #region Vars
        private string currentDbName = null;
        #endregion

        #region Init
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormLoaded;
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            cbAllTables.CheckedChanged += CbAllTables_CheckedChanged;
            this.btnGenFiles.Click += async (s, o) => await BeginToGenFiles();


            //InitUIMessage();
            InitSettings();


            InitDbNames();
            lbConStringName.DoubleClick += (s, o) => SelectDbName();

            btnSettingNext.Click += (s, o) => tabControl1.SelectedIndex = 1;
            btnDbNext.Click += (s, o) => tabControl1.SelectedIndex = 2;
            btnTableNext.Click += (s, o) => tabControl1.SelectedIndex = 3;

            btnDbReload.Click += async (s, o) =>
             {
                 btnDbReload.Enabled = false;
                 await ReloadTables(currentDbName);
                 btnDbReload.Enabled = true;
             };
        }

        #endregion

        #region Page-Config
        private List<LanguageSimpleInfo> langs = null;
        private async void InitSettings()
        {
            langs = await Task.Run(() => LangHelper.GetAllSupportLanguages());
            cbLanguage.Items.Clear();
            cbLanguage.DataSource = langs;
            cbLanguage.DisplayMember = "Name";

            cbLanguage.SelectedIndexChanged += CbLanguage_SelectedIndexChanged;
            var clang = langs.FirstOrDefault(x => x.Code == LangHelper.CurrentLanguage.Code);
            if (clang != null)
            {
                cbLanguage.SelectedIndex = langs.IndexOf(clang);
            }
            else
            {
                if (langs.Exists(x => x.Name == "English"))
                {
                    cbLanguage.SelectedIndex = langs.IndexOf(langs.Find(x => x.Name == "English"));
                }
                else
                    cbLanguage.SelectedIndex = 0;
            }

            var selTemp = Properties.Settings.Default.ModelTemlpateName;
            cbTemplateName.Items.Clear();
            cbTemplateName.Items.Add("Default");
            var temps = MainManager.GetTemplates();
            foreach (var item in temps)
            {
                cbTemplateName.Items.Add(item);
            }

            cbTemplateName.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(selTemp) && selTemp.ToLower() != "default")
            {
                var it = temps.FirstOrDefault(x => x == selTemp);
                if (it != null)
                    cbTemplateName.SelectedIndex = temps.IndexOf(it) + 1;
            }
        }
        #endregion


        #region UI-Language
        private void CbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            var lang = cb.SelectedItem as LanguageSimpleInfo;
            if (lang == null) return;
            string langCode = lang.Code;
            LangHelper.LoadLanguage(langCode);
            LangHelper.SetUICulture(langCode);
            ChangeLanguage();
        }

        /// <summary>
        /// 切换语言
        /// </summary>
        private void ChangeLanguage()
        {
            var msg = string.Empty;
            foreach (Control ctrl in GetSelfAndChildrenRecursive(this))
            {
                if (ctrl.Tag == null) continue;
                msg = GetResByTag(ctrl.Tag);
                if (string.IsNullOrEmpty(msg)) continue;
                ctrl.Text = msg;
            }
            this.Text += " by Fallstar v" + this.ProductVersion;
        }
        /// <summary>
        /// 递归获得所有子控件
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        private IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
        {
            List<Control> controls = new List<Control>();
            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetSelfAndChildrenRecursive(child));
            }
            controls.Add(parent);
            return controls;
        }
        /// <summary>
        /// 通过分析Tag来判断获取资源
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private string GetResByTag(object tag)
        {
            var t = tag.ToString().Trim();
            if (string.IsNullOrEmpty(t)) return null;
            if (t.StartsWith("ResID:"))
            {
                t = t.Replace("ResID:", string.Empty);
                uint id = 0;
                if (uint.TryParse(t, out id))
                    return GetRes(id);
                return null;
            }
            if (t.StartsWith("ResKey:"))
            {
                t = t.Replace("ResKey:", string.Empty);
                return GetRes(t);
            }
            return null;
        }

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="defaultValue"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        private string GetRes(uint id, string defaultValue = null, params object[] pars)
        {
            return LangHelper.GetRes(id, defaultValue, pars);
        }

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="defaultValue"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        private string GetRes(LangMsgKeys id, string defaultValue = null, params object[] pars)
        {
            return LangHelper.GetRes(id, defaultValue, pars);
        }

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        private string GetRes(string key, string defaultValue = null, params object[] pars)
        {
            return LangHelper.GetRes(key, defaultValue, pars);
        }
        #endregion

        #region Page-DbNames
        private void InitDbNames()
        {
            var dbNames = MainManager.GetDbConnectionNames();
            lbConStringName.Items.Clear();
            foreach (var item in dbNames)
            {
                lbConStringName.Items.Add(item);
            }
            if (dbNames.Count > 0)
                lbConStringName.SelectedIndex = 0;
        }

        private async void SelectDbName()
        {
            if (lbConStringName.SelectedIndex == -1)
            {
                return;
            }
            var dbName = lbConStringName.SelectedItem.ToString();
            if (dbName == currentDbName) return;
            currentDbName = dbName;
            var ret = MainManager.Logic.SetDbConnection(dbName);
            if (!ret.IsSuccess)
            {
                MessageBox.Show(ret.ReplyMsg);
                return;
            }
            await ReloadTables(dbName);

            tabControl1.SelectedIndex = 2;
        }
        #endregion

        #region Page-Table
        private List<DbTableInfo> tableInfos = null;

        private void CbAllTables_CheckedChanged(object sender, EventArgs e)
        {
            var isCheck = cbAllTables.Checked;
            for (int i = 0; i < cblbTables.Items.Count; i++)
            {
                cblbTables.SetItemChecked(i, isCheck);
            }
        }

        /// <summary>
        /// 读取所有表的信息
        /// </summary>
        /// <param name="dbName"></param>
        private async Task ReloadTables(string dbName)
        {
            if (string.IsNullOrEmpty(dbName))
            {
                MessageBox.Show(GetRes(1514));
                return;
            }
            btnDbNext.Enabled = false;
            var result = await Task.Run(() => MainManager.GetTableNames(dbName));
            btnDbNext.Enabled = true;
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ReplyMsg);
                return;
            }
            if (result.Result == null || result.Result.Count == 0) return;
            tableInfos = result.Result;

            cblbTables.Items.Clear();

            foreach (var item in result.Result)
            {
                cblbTables.Items.Add(item.TableName);
            }
        }
        #endregion

        #region Page-Result

        private async Task BeginToGenFiles()
        {
            var nameSpace = txtNameSpace.Text.Trim();
            var fileDir = txtGenPath.Text.Trim();
            if (string.IsNullOrEmpty(nameSpace))
                nameSpace = "Model";
            if (string.IsNullOrEmpty(fileDir))
                fileDir = "Models\\";

            var temp = cbTemplateName.SelectedItem.ToString();


            Properties.Settings.Default.ModelNameSpace = nameSpace;
            Properties.Settings.Default.ModelGeneratePath = fileDir;
            Properties.Settings.Default.ModelTemlpateName = temp;
            Properties.Settings.Default.Save();

            txtResultLog.Clear();
            AddResultLog(LangHelper.GetRes(1502));
            if (tableInfos == null)
            {
                AddResultLog(LangHelper.GetRes(1503));
                return;
            }
            var selTables = new List<DbTableInfo>();
            foreach (var item in cblbTables.CheckedItems)
            {
                var t = item.ToString();
                var it = tableInfos.FirstOrDefault(x => x.TableName == t);
                if (it == null) continue;
                selTables.Add(it);
            }
            AddResultLog(LangHelper.GetRes(1504, "Tables need to proccess :") + selTables.Count);
            var mo = new GenFileModel()
            {
                FilePath = fileDir,
                NameSpace = nameSpace,
                Tables = selTables,
                TemplateName = temp,
            };
            btnGenFiles.Enabled = false;
            await Task.Run(() => MainManager.GenFiles(mo, AddResultLog));
            btnGenFiles.Enabled = true;
        }

        /// <summary>
        /// 输出结果日志
        /// </summary>
        /// <param name="msg"></param>
        private void AddResultLog(string msg)
        {
            Action act = () => txtResultLog.AppendText(msg + Environment.NewLine);
            if (txtResultLog.InvokeRequired)
                txtResultLog.Invoke(act);
            else
                act();
        }

        #endregion
    }
}
