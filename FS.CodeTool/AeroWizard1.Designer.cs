namespace FS.CodeTool
{
    partial class AeroWizard1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AeroWizard1));
            this.wizardControl1 = new AeroWizard.WizardControl();
            this.wpDbNames = new AeroWizard.WizardPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbConStringName = new System.Windows.Forms.ListBox();
            this.wpTables = new AeroWizard.WizardPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbAllTables = new System.Windows.Forms.CheckBox();
            this.cblbTables = new System.Windows.Forms.CheckedListBox();
            this.wpSettings = new AeroWizard.WizardPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtGenPath = new System.Windows.Forms.TextBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wpResult = new AeroWizard.WizardPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnGenFiles = new System.Windows.Forms.Button();
            this.txtResultLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wpDbNames.SuspendLayout();
            this.panel1.SuspendLayout();
            this.wpTables.SuspendLayout();
            this.panel2.SuspendLayout();
            this.wpSettings.SuspendLayout();
            this.panel3.SuspendLayout();
            this.wpResult.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.BackColor = System.Drawing.Color.White;
            this.wizardControl1.CancelButtonText = "取消";
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.FinishButtonText = "完成";
            this.wizardControl1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextButtonText = "下一步(&N)";
            this.wizardControl1.Pages.Add(this.wpDbNames);
            this.wizardControl1.Pages.Add(this.wpTables);
            this.wizardControl1.Pages.Add(this.wpSettings);
            this.wizardControl1.Pages.Add(this.wpResult);
            this.wizardControl1.Size = new System.Drawing.Size(784, 562);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "模型构建工具";
            this.wizardControl1.TitleIcon = ((System.Drawing.Icon)(resources.GetObject("wizardControl1.TitleIcon")));
            // 
            // wpDbNames
            // 
            this.wpDbNames.Controls.Add(this.panel1);
            this.wpDbNames.Name = "wpDbNames";
            this.wpDbNames.NextPage = this.wpTables;
            this.wpDbNames.Size = new System.Drawing.Size(737, 406);
            this.wpDbNames.TabIndex = 0;
            this.wpDbNames.Text = "请选择数据库连接";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbConStringName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 406);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(615, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 59);
            this.label1.TabIndex = 2;
            this.label1.Text = "数据库连接需要在对应的 .config 里面定义好";
            // 
            // lbConStringName
            // 
            this.lbConStringName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbConStringName.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.lbConStringName.FormattingEnabled = true;
            this.lbConStringName.ItemHeight = 27;
            this.lbConStringName.Items.AddRange(new object[] {
            "Oracle",
            "SQLServer",
            "MySql"});
            this.lbConStringName.Location = new System.Drawing.Point(0, 0);
            this.lbConStringName.Margin = new System.Windows.Forms.Padding(0);
            this.lbConStringName.Name = "lbConStringName";
            this.lbConStringName.Size = new System.Drawing.Size(201, 406);
            this.lbConStringName.TabIndex = 1;
            // 
            // wpTables
            // 
            this.wpTables.Controls.Add(this.panel2);
            this.wpTables.Name = "wpTables";
            this.wpTables.NextPage = this.wpSettings;
            this.wpTables.Size = new System.Drawing.Size(491, 244);
            this.wpTables.TabIndex = 1;
            this.wpTables.Text = "请选择要生成代码的表";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbAllTables);
            this.panel2.Controls.Add(this.cblbTables);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 244);
            this.panel2.TabIndex = 2;
            // 
            // cbAllTables
            // 
            this.cbAllTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllTables.AutoSize = true;
            this.cbAllTables.Checked = true;
            this.cbAllTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllTables.Location = new System.Drawing.Point(436, 5);
            this.cbAllTables.Margin = new System.Windows.Forms.Padding(1);
            this.cbAllTables.Name = "cbAllTables";
            this.cbAllTables.Size = new System.Drawing.Size(51, 21);
            this.cbAllTables.TabIndex = 1;
            this.cbAllTables.Text = "全选";
            this.cbAllTables.UseVisualStyleBackColor = true;
            // 
            // cblbTables
            // 
            this.cblbTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cblbTables.FormattingEnabled = true;
            this.cblbTables.HorizontalScrollbar = true;
            this.cblbTables.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cblbTables.Location = new System.Drawing.Point(0, 0);
            this.cblbTables.Margin = new System.Windows.Forms.Padding(0);
            this.cblbTables.Name = "cblbTables";
            this.cblbTables.Size = new System.Drawing.Size(491, 244);
            this.cblbTables.TabIndex = 0;
            // 
            // wpSettings
            // 
            this.wpSettings.Controls.Add(this.panel3);
            this.wpSettings.Name = "wpSettings";
            this.wpSettings.NextPage = this.wpResult;
            this.wpSettings.Size = new System.Drawing.Size(491, 244);
            this.wpSettings.TabIndex = 2;
            this.wpSettings.Text = "选项";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtGenPath);
            this.panel3.Controls.Add(this.txtNameSpace);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 244);
            this.panel3.TabIndex = 2;
            // 
            // txtGenPath
            // 
            this.txtGenPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FS.CodeTool.Properties.Settings.Default, "ModelGeneratePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtGenPath.Location = new System.Drawing.Point(62, 30);
            this.txtGenPath.Margin = new System.Windows.Forms.Padding(1);
            this.txtGenPath.Name = "txtGenPath";
            this.txtGenPath.Size = new System.Drawing.Size(140, 26);
            this.txtGenPath.TabIndex = 1;
            this.txtGenPath.Text = global::FS.CodeTool.Properties.Settings.Default.ModelGeneratePath;
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FS.CodeTool.Properties.Settings.Default, "ModelNameSpace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNameSpace.Location = new System.Drawing.Point(62, 5);
            this.txtNameSpace.Margin = new System.Windows.Forms.Padding(1);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(139, 26);
            this.txtNameSpace.TabIndex = 1;
            this.txtNameSpace.Text = global::FS.CodeTool.Properties.Settings.Default.ModelNameSpace;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "生成路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "命名空间：";
            // 
            // wpResult
            // 
            this.wpResult.AllowCancel = false;
            this.wpResult.AllowNext = false;
            this.wpResult.Controls.Add(this.panel4);
            this.wpResult.IsFinishPage = true;
            this.wpResult.Name = "wpResult";
            this.wpResult.ShowCancel = false;
            this.wpResult.ShowNext = false;
            this.wpResult.Size = new System.Drawing.Size(491, 244);
            this.wpResult.TabIndex = 3;
            this.wpResult.Text = "结果";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnGenFiles);
            this.panel4.Controls.Add(this.txtResultLog);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(491, 244);
            this.panel4.TabIndex = 2;
            // 
            // btnGenFiles
            // 
            this.btnGenFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenFiles.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.btnGenFiles.Location = new System.Drawing.Point(442, 1);
            this.btnGenFiles.Margin = new System.Windows.Forms.Padding(1);
            this.btnGenFiles.Name = "btnGenFiles";
            this.btnGenFiles.Size = new System.Drawing.Size(49, 25);
            this.btnGenFiles.TabIndex = 1;
            this.btnGenFiles.Text = "生成";
            this.btnGenFiles.UseVisualStyleBackColor = true;
            // 
            // txtResultLog
            // 
            this.txtResultLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultLog.Location = new System.Drawing.Point(0, 0);
            this.txtResultLog.Margin = new System.Windows.Forms.Padding(0);
            this.txtResultLog.Multiline = true;
            this.txtResultLog.Name = "txtResultLog";
            this.txtResultLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultLog.Size = new System.Drawing.Size(432, 246);
            this.txtResultLog.TabIndex = 0;
            // 
            // AeroWizard1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.wizardControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AeroWizard1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wpDbNames.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.wpTables.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.wpSettings.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.wpResult.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AeroWizard.WizardControl wizardControl1;
        private AeroWizard.WizardPage wpDbNames;
        private AeroWizard.WizardPage wpTables;
        private System.Windows.Forms.ListBox lbConStringName;
        private System.Windows.Forms.Label label1;
        private AeroWizard.WizardPage wpSettings;
        private AeroWizard.WizardPage wpResult;
        private System.Windows.Forms.CheckedListBox cblbTables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGenPath;
        private System.Windows.Forms.TextBox txtResultLog;
        private System.Windows.Forms.Button btnGenFiles;
        private System.Windows.Forms.CheckBox cbAllTables;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}