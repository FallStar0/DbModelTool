namespace FS.CodeTool
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDbNames = new System.Windows.Forms.TabPage();
            this.lblDbNameTip = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.lbConStringName = new System.Windows.Forms.ListBox();
            this.tpTables = new System.Windows.Forms.TabPage();
            this.cbAllTables = new System.Windows.Forms.CheckBox();
            this.cblbTables = new System.Windows.Forms.CheckedListBox();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.txtGenPath = new System.Windows.Forms.TextBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblNameSpace = new System.Windows.Forms.Label();
            this.tpResult = new System.Windows.Forms.TabPage();
            this.btnGenFiles = new System.Windows.Forms.Button();
            this.txtResultLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tpDbNames.SuspendLayout();
            this.tpTables.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tpResult.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpDbNames);
            this.tabControl1.Controls.Add(this.tpTables);
            this.tabControl1.Controls.Add(this.tpSettings);
            this.tabControl1.Controls.Add(this.tpResult);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 447);
            this.tabControl1.TabIndex = 0;
            // 
            // tpDbNames
            // 
            this.tpDbNames.Controls.Add(this.lblDbNameTip);
            this.tpDbNames.Controls.Add(this.cbLanguage);
            this.tpDbNames.Controls.Add(this.lbConStringName);
            this.tpDbNames.Location = new System.Drawing.Point(4, 29);
            this.tpDbNames.Name = "tpDbNames";
            this.tpDbNames.Padding = new System.Windows.Forms.Padding(3);
            this.tpDbNames.Size = new System.Drawing.Size(574, 414);
            this.tpDbNames.TabIndex = 0;
            this.tpDbNames.Text = "数据库";
            this.tpDbNames.UseVisualStyleBackColor = true;
            // 
            // lblDbNameTip
            // 
            this.lblDbNameTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDbNameTip.AutoSize = true;
            this.lblDbNameTip.Location = new System.Drawing.Point(327, 379);
            this.lblDbNameTip.Name = "lblDbNameTip";
            this.lblDbNameTip.Size = new System.Drawing.Size(121, 20);
            this.lblDbNameTip.TabIndex = 5;
            this.lblDbNameTip.Text = "双击选择数据库";
            // 
            // cbLanguage
            // 
            this.cbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(445, 8);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(121, 28);
            this.cbLanguage.TabIndex = 4;
            // 
            // lbConStringName
            // 
            this.lbConStringName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbConStringName.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.lbConStringName.FormattingEnabled = true;
            this.lbConStringName.ItemHeight = 25;
            this.lbConStringName.Items.AddRange(new object[] {
            "Oracle",
            "SQLServer",
            "MySql"});
            this.lbConStringName.Location = new System.Drawing.Point(3, 3);
            this.lbConStringName.Margin = new System.Windows.Forms.Padding(0);
            this.lbConStringName.Name = "lbConStringName";
            this.lbConStringName.Size = new System.Drawing.Size(308, 408);
            this.lbConStringName.TabIndex = 3;
            // 
            // tpTables
            // 
            this.tpTables.Controls.Add(this.cbAllTables);
            this.tpTables.Controls.Add(this.cblbTables);
            this.tpTables.Location = new System.Drawing.Point(4, 29);
            this.tpTables.Name = "tpTables";
            this.tpTables.Padding = new System.Windows.Forms.Padding(3);
            this.tpTables.Size = new System.Drawing.Size(574, 414);
            this.tpTables.TabIndex = 1;
            this.tpTables.Text = "表";
            this.tpTables.UseVisualStyleBackColor = true;
            // 
            // cbAllTables
            // 
            this.cbAllTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllTables.AutoSize = true;
            this.cbAllTables.Checked = true;
            this.cbAllTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllTables.Location = new System.Drawing.Point(475, 21);
            this.cbAllTables.Margin = new System.Windows.Forms.Padding(1);
            this.cbAllTables.Name = "cbAllTables";
            this.cbAllTables.Size = new System.Drawing.Size(60, 24);
            this.cbAllTables.TabIndex = 3;
            this.cbAllTables.Text = "全选";
            this.cbAllTables.UseVisualStyleBackColor = true;
            // 
            // cblbTables
            // 
            this.cblbTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cblbTables.FormattingEnabled = true;
            this.cblbTables.HorizontalScrollbar = true;
            this.cblbTables.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cblbTables.Location = new System.Drawing.Point(3, 3);
            this.cblbTables.Margin = new System.Windows.Forms.Padding(0);
            this.cblbTables.Name = "cblbTables";
            this.cblbTables.Size = new System.Drawing.Size(568, 408);
            this.cblbTables.TabIndex = 2;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.txtGenPath);
            this.tpSettings.Controls.Add(this.txtNameSpace);
            this.tpSettings.Controls.Add(this.lblFilePath);
            this.tpSettings.Controls.Add(this.lblNameSpace);
            this.tpSettings.Location = new System.Drawing.Point(4, 29);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Size = new System.Drawing.Size(574, 414);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "选项";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // txtGenPath
            // 
            this.txtGenPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FS.CodeTool.Properties.Settings.Default, "ModelGeneratePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtGenPath.Location = new System.Drawing.Point(131, 55);
            this.txtGenPath.Margin = new System.Windows.Forms.Padding(1);
            this.txtGenPath.Name = "txtGenPath";
            this.txtGenPath.Size = new System.Drawing.Size(280, 28);
            this.txtGenPath.TabIndex = 4;
            this.txtGenPath.Text = global::FS.CodeTool.Properties.Settings.Default.ModelGeneratePath;
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FS.CodeTool.Properties.Settings.Default, "ModelNameSpace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNameSpace.Location = new System.Drawing.Point(131, 13);
            this.txtNameSpace.Margin = new System.Windows.Forms.Padding(1);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(280, 28);
            this.txtNameSpace.TabIndex = 5;
            this.txtNameSpace.Text = global::FS.CodeTool.Properties.Settings.Default.ModelNameSpace;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(9, 58);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(89, 20);
            this.lblFilePath.TabIndex = 2;
            this.lblFilePath.Text = "生成路径：";
            // 
            // lblNameSpace
            // 
            this.lblNameSpace.AutoSize = true;
            this.lblNameSpace.Location = new System.Drawing.Point(9, 16);
            this.lblNameSpace.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNameSpace.Name = "lblNameSpace";
            this.lblNameSpace.Size = new System.Drawing.Size(89, 20);
            this.lblNameSpace.TabIndex = 3;
            this.lblNameSpace.Text = "命名空间：";
            // 
            // tpResult
            // 
            this.tpResult.Controls.Add(this.txtResultLog);
            this.tpResult.Controls.Add(this.panel1);
            this.tpResult.Location = new System.Drawing.Point(4, 29);
            this.tpResult.Name = "tpResult";
            this.tpResult.Size = new System.Drawing.Size(574, 414);
            this.tpResult.TabIndex = 3;
            this.tpResult.Text = "结果";
            this.tpResult.UseVisualStyleBackColor = true;
            // 
            // btnGenFiles
            // 
            this.btnGenFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenFiles.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.btnGenFiles.Location = new System.Drawing.Point(7, 1);
            this.btnGenFiles.Margin = new System.Windows.Forms.Padding(1);
            this.btnGenFiles.Name = "btnGenFiles";
            this.btnGenFiles.Size = new System.Drawing.Size(82, 50);
            this.btnGenFiles.TabIndex = 3;
            this.btnGenFiles.Text = "生成";
            this.btnGenFiles.UseVisualStyleBackColor = true;
            // 
            // txtResultLog
            // 
            this.txtResultLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultLog.Location = new System.Drawing.Point(0, 0);
            this.txtResultLog.Margin = new System.Windows.Forms.Padding(0);
            this.txtResultLog.Multiline = true;
            this.txtResultLog.Name = "txtResultLog";
            this.txtResultLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultLog.Size = new System.Drawing.Size(479, 414);
            this.txtResultLog.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGenFiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(479, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 414);
            this.panel1.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(582, 447);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "模型构建工具";
            this.tabControl1.ResumeLayout(false);
            this.tpDbNames.ResumeLayout(false);
            this.tpDbNames.PerformLayout();
            this.tpTables.ResumeLayout(false);
            this.tpTables.PerformLayout();
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.tpResult.ResumeLayout(false);
            this.tpResult.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpDbNames;
        private System.Windows.Forms.TabPage tpTables;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.ListBox lbConStringName;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.TabPage tpResult;
        private System.Windows.Forms.CheckBox cbAllTables;
        private System.Windows.Forms.CheckedListBox cblbTables;
        private System.Windows.Forms.TextBox txtGenPath;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblNameSpace;
        private System.Windows.Forms.Button btnGenFiles;
        private System.Windows.Forms.TextBox txtResultLog;
        private System.Windows.Forms.Label lblDbNameTip;
        private System.Windows.Forms.Panel panel1;
    }
}