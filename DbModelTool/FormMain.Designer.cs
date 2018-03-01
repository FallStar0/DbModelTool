namespace FS.DbModelTool
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
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.btnSettingNext = new System.Windows.Forms.Button();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.cbTemplateName = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtGenPath = new System.Windows.Forms.TextBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTemplateName = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblNameSpace = new System.Windows.Forms.Label();
            this.tpDbNames = new System.Windows.Forms.TabPage();
            this.btnDbNext = new System.Windows.Forms.Button();
            this.lblDbNameTip = new System.Windows.Forms.Label();
            this.lbConStringName = new System.Windows.Forms.ListBox();
            this.tpTables = new System.Windows.Forms.TabPage();
            this.cblbTables = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDbReload = new System.Windows.Forms.Button();
            this.btnTableNext = new System.Windows.Forms.Button();
            this.cbAllTables = new System.Windows.Forms.CheckBox();
            this.tpResult = new System.Windows.Forms.TabPage();
            this.txtResultLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenFiles = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tpDbNames.SuspendLayout();
            this.tpTables.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tpResult.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpSettings);
            this.tabControl1.Controls.Add(this.tpDbNames);
            this.tabControl1.Controls.Add(this.tpTables);
            this.tabControl1.Controls.Add(this.tpResult);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 447);
            this.tabControl1.TabIndex = 0;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.btnSettingNext);
            this.tpSettings.Controls.Add(this.cbLanguage);
            this.tpSettings.Controls.Add(this.cbTemplateName);
            this.tpSettings.Controls.Add(this.textBox2);
            this.tpSettings.Controls.Add(this.textBox1);
            this.tpSettings.Controls.Add(this.txtGenPath);
            this.tpSettings.Controls.Add(this.txtNameSpace);
            this.tpSettings.Controls.Add(this.label2);
            this.tpSettings.Controls.Add(this.label1);
            this.tpSettings.Controls.Add(this.lblTemplateName);
            this.tpSettings.Controls.Add(this.lblFilePath);
            this.tpSettings.Controls.Add(this.lblNameSpace);
            this.tpSettings.Location = new System.Drawing.Point(4, 29);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Size = new System.Drawing.Size(574, 414);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Tag = "ResKey:Option";
            this.tpSettings.Text = "选项";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // btnSettingNext
            // 
            this.btnSettingNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingNext.Location = new System.Drawing.Point(460, 362);
            this.btnSettingNext.Name = "btnSettingNext";
            this.btnSettingNext.Size = new System.Drawing.Size(100, 40);
            this.btnSettingNext.TabIndex = 7;
            this.btnSettingNext.Tag = "ResID:129";
            this.btnSettingNext.Text = "下一步";
            this.btnSettingNext.UseVisualStyleBackColor = true;
            // 
            // cbLanguage
            // 
            this.cbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(435, 13);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(121, 28);
            this.cbLanguage.TabIndex = 4;
            // 
            // cbTemplateName
            // 
            this.cbTemplateName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemplateName.FormattingEnabled = true;
            this.cbTemplateName.Location = new System.Drawing.Point(131, 107);
            this.cbTemplateName.Name = "cbTemplateName";
            this.cbTemplateName.Size = new System.Drawing.Size(280, 28);
            this.cbTemplateName.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FS.DbModelTool.Properties.Settings.Default, "Copyright", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(131, 206);
            this.textBox2.Margin = new System.Windows.Forms.Padding(1);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(280, 28);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = global::FS.DbModelTool.Properties.Settings.Default.Copyright;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FS.DbModelTool.Properties.Settings.Default, "Author", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(131, 161);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(280, 28);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = global::FS.DbModelTool.Properties.Settings.Default.Author;
            // 
            // txtGenPath
            // 
            this.txtGenPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FS.DbModelTool.Properties.Settings.Default, "ModelGeneratePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtGenPath.Location = new System.Drawing.Point(131, 55);
            this.txtGenPath.Margin = new System.Windows.Forms.Padding(1);
            this.txtGenPath.Name = "txtGenPath";
            this.txtGenPath.Size = new System.Drawing.Size(280, 28);
            this.txtGenPath.TabIndex = 4;
            this.txtGenPath.Text = global::FS.DbModelTool.Properties.Settings.Default.ModelGeneratePath;
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FS.DbModelTool.Properties.Settings.Default, "ModelNameSpace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNameSpace.Location = new System.Drawing.Point(131, 13);
            this.txtNameSpace.Margin = new System.Windows.Forms.Padding(1);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(280, 28);
            this.txtNameSpace.TabIndex = 5;
            this.txtNameSpace.Text = global::FS.DbModelTool.Properties.Settings.Default.ModelNameSpace;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 209);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 2;
            this.label2.Tag = "ResID:1513";
            this.label2.Text = "版权：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 2;
            this.label1.Tag = "ResID:1512";
            this.label1.Text = "作者：";
            // 
            // lblTemplateName
            // 
            this.lblTemplateName.AutoSize = true;
            this.lblTemplateName.Location = new System.Drawing.Point(9, 110);
            this.lblTemplateName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTemplateName.Name = "lblTemplateName";
            this.lblTemplateName.Size = new System.Drawing.Size(89, 20);
            this.lblTemplateName.TabIndex = 2;
            this.lblTemplateName.Tag = "ResID:1511";
            this.lblTemplateName.Text = "模板名称：";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(9, 58);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(89, 20);
            this.lblFilePath.TabIndex = 2;
            this.lblFilePath.Tag = "ResID:1509";
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
            this.lblNameSpace.Tag = "ResID:1510";
            this.lblNameSpace.Text = "命名空间：";
            // 
            // tpDbNames
            // 
            this.tpDbNames.Controls.Add(this.btnDbNext);
            this.tpDbNames.Controls.Add(this.label3);
            this.tpDbNames.Controls.Add(this.lblDbNameTip);
            this.tpDbNames.Controls.Add(this.lbConStringName);
            this.tpDbNames.Location = new System.Drawing.Point(4, 29);
            this.tpDbNames.Name = "tpDbNames";
            this.tpDbNames.Padding = new System.Windows.Forms.Padding(3);
            this.tpDbNames.Size = new System.Drawing.Size(574, 414);
            this.tpDbNames.TabIndex = 0;
            this.tpDbNames.Tag = "ResID:1506";
            this.tpDbNames.Text = "数据库";
            this.tpDbNames.UseVisualStyleBackColor = true;
            // 
            // btnDbNext
            // 
            this.btnDbNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDbNext.Location = new System.Drawing.Point(460, 362);
            this.btnDbNext.Name = "btnDbNext";
            this.btnDbNext.Size = new System.Drawing.Size(100, 40);
            this.btnDbNext.TabIndex = 8;
            this.btnDbNext.Tag = "ResID:129";
            this.btnDbNext.Text = "下一步";
            this.btnDbNext.UseVisualStyleBackColor = true;
            // 
            // lblDbNameTip
            // 
            this.lblDbNameTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDbNameTip.Location = new System.Drawing.Point(414, 15);
            this.lblDbNameTip.Name = "lblDbNameTip";
            this.lblDbNameTip.Size = new System.Drawing.Size(152, 102);
            this.lblDbNameTip.TabIndex = 5;
            this.lblDbNameTip.Tag = "ResID:1507";
            this.lblDbNameTip.Text = "双击选择数据库";
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
            this.lbConStringName.Size = new System.Drawing.Size(408, 408);
            this.lbConStringName.TabIndex = 3;
            // 
            // tpTables
            // 
            this.tpTables.Controls.Add(this.cblbTables);
            this.tpTables.Controls.Add(this.panel2);
            this.tpTables.Location = new System.Drawing.Point(4, 29);
            this.tpTables.Name = "tpTables";
            this.tpTables.Padding = new System.Windows.Forms.Padding(3);
            this.tpTables.Size = new System.Drawing.Size(574, 414);
            this.tpTables.TabIndex = 1;
            this.tpTables.Tag = "ResID:1508";
            this.tpTables.Text = "表";
            this.tpTables.UseVisualStyleBackColor = true;
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
            this.cblbTables.Size = new System.Drawing.Size(448, 408);
            this.cblbTables.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDbReload);
            this.panel2.Controls.Add(this.btnTableNext);
            this.panel2.Controls.Add(this.cbAllTables);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(451, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 408);
            this.panel2.TabIndex = 4;
            // 
            // btnDbReload
            // 
            this.btnDbReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDbReload.Location = new System.Drawing.Point(9, 64);
            this.btnDbReload.Name = "btnDbReload";
            this.btnDbReload.Size = new System.Drawing.Size(100, 40);
            this.btnDbReload.TabIndex = 9;
            this.btnDbReload.Tag = "ResID:134";
            this.btnDbReload.Text = "重新加载";
            this.btnDbReload.UseVisualStyleBackColor = true;
            // 
            // btnTableNext
            // 
            this.btnTableNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTableNext.Location = new System.Drawing.Point(9, 359);
            this.btnTableNext.Name = "btnTableNext";
            this.btnTableNext.Size = new System.Drawing.Size(100, 40);
            this.btnTableNext.TabIndex = 9;
            this.btnTableNext.Tag = "ResID:129";
            this.btnTableNext.Text = "下一步";
            this.btnTableNext.UseVisualStyleBackColor = true;
            // 
            // cbAllTables
            // 
            this.cbAllTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllTables.Location = new System.Drawing.Point(12, 13);
            this.cbAllTables.Margin = new System.Windows.Forms.Padding(1);
            this.cbAllTables.Name = "cbAllTables";
            this.cbAllTables.Size = new System.Drawing.Size(105, 28);
            this.cbAllTables.TabIndex = 3;
            this.cbAllTables.Tag = "ResID:126";
            this.cbAllTables.Text = "全选";
            this.cbAllTables.UseVisualStyleBackColor = true;
            // 
            // tpResult
            // 
            this.tpResult.Controls.Add(this.txtResultLog);
            this.tpResult.Controls.Add(this.panel1);
            this.tpResult.Location = new System.Drawing.Point(4, 29);
            this.tpResult.Name = "tpResult";
            this.tpResult.Size = new System.Drawing.Size(574, 414);
            this.tpResult.TabIndex = 3;
            this.tpResult.Tag = "ResID:124";
            this.tpResult.Text = "结果";
            this.tpResult.UseVisualStyleBackColor = true;
            // 
            // txtResultLog
            // 
            this.txtResultLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultLog.Location = new System.Drawing.Point(0, 0);
            this.txtResultLog.Margin = new System.Windows.Forms.Padding(0);
            this.txtResultLog.Multiline = true;
            this.txtResultLog.Name = "txtResultLog";
            this.txtResultLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultLog.Size = new System.Drawing.Size(454, 414);
            this.txtResultLog.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGenFiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(454, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 414);
            this.panel1.TabIndex = 4;
            // 
            // btnGenFiles
            // 
            this.btnGenFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenFiles.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.btnGenFiles.Location = new System.Drawing.Point(12, 355);
            this.btnGenFiles.Margin = new System.Windows.Forms.Padding(1);
            this.btnGenFiles.Name = "btnGenFiles";
            this.btnGenFiles.Size = new System.Drawing.Size(97, 50);
            this.btnGenFiles.TabIndex = 3;
            this.btnGenFiles.Tag = "ResID:127";
            this.btnGenFiles.Text = "生成";
            this.btnGenFiles.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(414, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 144);
            this.label3.TabIndex = 5;
            this.label3.Tag = "ResID:1515";
            this.label3.Text = "你可以在当前目录的Db.config文件更改数据库连接";
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
            this.Tag = "ResID:1505";
            this.Text = "模型构建工具";
            this.tabControl1.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.tpDbNames.ResumeLayout(false);
            this.tpTables.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblTemplateName;
        private System.Windows.Forms.ComboBox cbTemplateName;
        private System.Windows.Forms.Button btnSettingNext;
        private System.Windows.Forms.Button btnDbNext;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTableNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDbReload;
        private System.Windows.Forms.Label label3;
    }
}