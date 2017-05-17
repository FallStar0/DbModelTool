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
            this.label1 = new System.Windows.Forms.Label();
            this.lbConStringName = new System.Windows.Forms.ListBox();
            this.wpTables = new AeroWizard.WizardPage();
            this.cbAllTables = new System.Windows.Forms.CheckBox();
            this.cblbTables = new System.Windows.Forms.CheckedListBox();
            this.wpSettings = new AeroWizard.WizardPage();
            this.txtGenPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.wpResult = new AeroWizard.WizardPage();
            this.btnGenFiles = new System.Windows.Forms.Button();
            this.txtResultLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wpDbNames.SuspendLayout();
            this.wpTables.SuspendLayout();
            this.wpSettings.SuspendLayout();
            this.wpResult.SuspendLayout();
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
            this.wpDbNames.Controls.Add(this.label1);
            this.wpDbNames.Controls.Add(this.lbConStringName);
            this.wpDbNames.Name = "wpDbNames";
            this.wpDbNames.NextPage = this.wpTables;
            this.wpDbNames.Size = new System.Drawing.Size(737, 406);
            this.wpDbNames.TabIndex = 0;
            this.wpDbNames.Text = "请选择数据库连接";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(495, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 55);
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
            this.lbConStringName.Size = new System.Drawing.Size(305, 406);
            this.lbConStringName.TabIndex = 1;
            // 
            // wpTables
            // 
            this.wpTables.Controls.Add(this.cbAllTables);
            this.wpTables.Controls.Add(this.cblbTables);
            this.wpTables.Name = "wpTables";
            this.wpTables.NextPage = this.wpSettings;
            this.wpTables.Size = new System.Drawing.Size(737, 406);
            this.wpTables.TabIndex = 1;
            this.wpTables.Text = "请选择要生成代码的表";
            // 
            // cbAllTables
            // 
            this.cbAllTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllTables.AutoSize = true;
            this.cbAllTables.Checked = true;
            this.cbAllTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllTables.Location = new System.Drawing.Point(674, 8);
            this.cbAllTables.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbAllTables.Name = "cbAllTables";
            this.cbAllTables.Size = new System.Drawing.Size(51, 21);
            this.cbAllTables.TabIndex = 1;
            this.cbAllTables.Text = "全选";
            this.cbAllTables.UseVisualStyleBackColor = true;
            // 
            // cblbTables
            // 
            this.cblbTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cblbTables.FormattingEnabled = true;
            this.cblbTables.HorizontalScrollbar = true;
            this.cblbTables.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cblbTables.Location = new System.Drawing.Point(0, 0);
            this.cblbTables.Margin = new System.Windows.Forms.Padding(0);
            this.cblbTables.Name = "cblbTables";
            this.cblbTables.Size = new System.Drawing.Size(657, 400);
            this.cblbTables.TabIndex = 0;
            // 
            // wpSettings
            // 
            this.wpSettings.Controls.Add(this.txtGenPath);
            this.wpSettings.Controls.Add(this.label3);
            this.wpSettings.Controls.Add(this.label2);
            this.wpSettings.Controls.Add(this.txtNameSpace);
            this.wpSettings.Name = "wpSettings";
            this.wpSettings.NextPage = this.wpResult;
            this.wpSettings.Size = new System.Drawing.Size(737, 406);
            this.wpSettings.TabIndex = 2;
            this.wpSettings.Text = "选项";
            // 
            // txtGenPath
            // 
            this.txtGenPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FS.CodeTool.Properties.Settings.Default, "ModelGeneratePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtGenPath.Location = new System.Drawing.Point(71, 34);
            this.txtGenPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGenPath.Name = "txtGenPath";
            this.txtGenPath.Size = new System.Drawing.Size(213, 23);
            this.txtGenPath.TabIndex = 1;
            this.txtGenPath.Text = global::FS.CodeTool.Properties.Settings.Default.ModelGeneratePath;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "生成路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "命名空间：";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FS.CodeTool.Properties.Settings.Default, "ModelNameSpace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNameSpace.Location = new System.Drawing.Point(71, 10);
            this.txtNameSpace.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(141, 23);
            this.txtNameSpace.TabIndex = 1;
            this.txtNameSpace.Text = global::FS.CodeTool.Properties.Settings.Default.ModelNameSpace;
            // 
            // wpResult
            // 
            this.wpResult.AllowCancel = false;
            this.wpResult.AllowNext = false;
            this.wpResult.Controls.Add(this.btnGenFiles);
            this.wpResult.Controls.Add(this.txtResultLog);
            this.wpResult.IsFinishPage = true;
            this.wpResult.Name = "wpResult";
            this.wpResult.ShowCancel = false;
            this.wpResult.ShowNext = false;
            this.wpResult.Size = new System.Drawing.Size(737, 406);
            this.wpResult.TabIndex = 3;
            this.wpResult.Text = "结果";
            // 
            // btnGenFiles
            // 
            this.btnGenFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenFiles.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.btnGenFiles.Location = new System.Drawing.Point(659, 8);
            this.btnGenFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenFiles.Name = "btnGenFiles";
            this.btnGenFiles.Size = new System.Drawing.Size(68, 37);
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
            this.txtResultLog.Size = new System.Drawing.Size(651, 404);
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
            this.wpTables.ResumeLayout(false);
            this.wpTables.PerformLayout();
            this.wpSettings.ResumeLayout(false);
            this.wpSettings.PerformLayout();
            this.wpResult.ResumeLayout(false);
            this.wpResult.PerformLayout();
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
    }
}