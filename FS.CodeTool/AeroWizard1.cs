using FS.DBAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace FS.CodeTool
{
    public partial class AeroWizard1 : Form
    {
        #region Vars
        private string currentDbName = null;
        #endregion

        #region Init
        public AeroWizard1()
        {
            InitializeComponent();
            this.Load += AeroWizard1_Load;
            this.wpDbNames.Initialize += WpDbNames_Initialize;
            this.wpDbNames.Commit += WpDbNames_Commit;

            this.wpTables.Initialize += WpTables_Initialize;
            this.wpTables.Commit += WpTables_Commit;
            cblbTables.ItemCheck += CblbTables_ItemCheck;
            cbAllTables.CheckedChanged += CbAllTables_CheckedChanged;

            this.wpResult.Initialize += WpResult_Initialize;
            this.btnGenFiles.Click += (s, e) => BeginToGenFiles();
        }

        private void AeroWizard1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Page-DbNames
        private void WpDbNames_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            InitDbNames();
        }

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

            wpDbNames.AllowNext = dbNames.Count > 0;
        }

        private void WpDbNames_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {

        }
        #endregion

        #region Page-Table
        private List<DbTableInfo> tableInfos = null;
        private async void WpTables_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            e.Page.AllowNext = false;
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
            e.Page.AllowNext = true;
        }

        private void WpTables_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {

        }

        private void CblbTables_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var cblb = sender as CheckedListBox;
            wpTables.AllowNext = cblb.CheckedItems.Count > 0;
        }

        private void CbAllTables_CheckedChanged(object sender, EventArgs e)
        {
            var isCheck = cbAllTables.Checked;
            for (int i = 0; i < cblbTables.Items.Count; i++)
            {
                cblbTables.SetItemChecked(i, isCheck);
            }
        }
        #endregion

        #region Page-Config

        #endregion

        #region Page-Result
        private bool hasGen = false;
        private void WpResult_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            if (hasGen) return;
            hasGen = true;
            BeginToGenFiles();
        }

        private void BeginToGenFiles()
        {
            var nameSpace = txtNameSpace.Text.Trim();
            var fileDir = txtGenPath.Text.Trim();
            if (string.IsNullOrEmpty(nameSpace))
                nameSpace = "Model";
            if (string.IsNullOrEmpty(fileDir))
                fileDir = "Models\\";
            txtResultLog.Clear();
            AddResultLog("开始生成模型文件~");
            if (tableInfos == null)
            {
                AddResultLog("没有对应的表信息，中断！");
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
            AddResultLog("需要处理的表数量：" + selTables.Count);
            var mo = new GenFileModel()
            {
                FilePath = fileDir,
                NameSpace = nameSpace,
                Tables = selTables
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
