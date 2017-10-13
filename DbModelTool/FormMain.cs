using FS.DBAccess;
using FS.I18N;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            this.btnGenFiles.Click += (s, o) => BeginToGenFiles();


            InitUIMessage();
            InitSettings();


            InitDbNames();
            lbConStringName.DoubleClick += (s, o) => SelectDbName();

            btnSettingNext.Click += (s, o) => tabControl1.SelectedIndex = 1;
            btnDbNext.Click += (s, o) => tabControl1.SelectedIndex = 2;
            btnTableNext.Click += (s, o) => tabControl1.SelectedIndex = 3;
        }
        #endregion

        #region Page-Config
        private void InitSettings()
        {
            cbLanguage.Items.Clear();
            cbLanguage.Items.Add("中文");
            cbLanguage.Items.Add("English");
            cbLanguage.SelectedIndex = 0;
            cbLanguage.SelectedIndexChanged += CbLanguage_SelectedIndexChanged;

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
        /// <summary>
        /// 初始化UI信息
        /// </summary>
        private void InitUIMessage()
        {
            this.Text = LangHelper.GetByID(205);
            tpDbNames.Text = LangHelper.GetByID(206);
            this.tpTables.Text = LangHelper.GetByID(208);
            this.tpSettings.Text = LangHelper.GetByID(LangMsgKeys.Option);
            this.tpResult.Text = LangHelper.GetByID(LangMsgKeys.Result);

            lblDbNameTip.Text = LangHelper.GetByID(207);

            this.cbAllTables.Text = LangHelper.GetByID(LangMsgKeys.SelectAll);

            this.lblFilePath.Text = LangHelper.GetByID(209);

            this.lblNameSpace.Text = LangHelper.GetByID(210);
            this.lblTemplateName.Text = LangHelper.GetByID(211);

            this.btnGenFiles.Text = LangHelper.GetByID(LangMsgKeys.Generate);
            btnSettingNext.Text = LangHelper.GetByID(LangMsgKeys.Next);
            btnDbNext.Text = LangHelper.GetByID(LangMsgKeys.Next);
            btnTableNext.Text = LangHelper.GetByID(LangMsgKeys.Next);
        }

        private void CbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            var lang = cb.SelectedItem.ToString();
            string langCode = "zh-CN";
            if (lang == "English")
                langCode = "en-us";
            LangHelper.LoadLanguage(langCode);

            InitUIMessage();
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

            var result = await Task.Run(() => MainManager.GetTableNames(dbName));
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
        #endregion

        #region Page-Result

        private void BeginToGenFiles()
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
            AddResultLog(LangHelper.GetByID(202));
            if (tableInfos == null)
            {
                AddResultLog(LangHelper.GetByID(203));
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
            AddResultLog(LangHelper.GetByID(204) + selTables.Count);
            var mo = new GenFileModel()
            {
                FilePath = fileDir,
                NameSpace = nameSpace,
                Tables = selTables,
                TemplateName = temp,
            };
            Task.Run(() => MainManager.GenFiles(mo, AddResultLog));
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
