﻿namespace PackageTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.OriginalBaseVerLabel = new System.Windows.Forms.Label();
            this.BaseVerTxt = new System.Windows.Forms.TextBox();
            this.CurVerTxt = new System.Windows.Forms.TextBox();
            this.CurVerLabel = new System.Windows.Forms.Label();
            this.ResListLabel = new System.Windows.Forms.Label();
            this.ResList = new System.Windows.Forms.ListBox();
            this.BasePathLabel = new System.Windows.Forms.Label();
            this.BasePathFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.BasePathTxt = new System.Windows.Forms.Label();
            this.BasePathBrowserBtn = new System.Windows.Forms.Button();
            this.NewVerBtn = new System.Windows.Forms.Button();
            this.GoGoGo = new System.Windows.Forms.Button();
            this.compareBtn = new System.Windows.Forms.Button();
            this.testSynBtn = new System.Windows.Forms.Button();
            this.autoCompareCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.scriptCheckBox = new System.Windows.Forms.CheckBox();
            this.fileCheckerBtn = new System.Windows.Forms.Button();
            this.switchModeBtn = new System.Windows.Forms.Button();
            this.checkSvnUpdate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OriginalBaseVerLabel
            // 
            this.OriginalBaseVerLabel.AutoSize = true;
            this.OriginalBaseVerLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OriginalBaseVerLabel.Location = new System.Drawing.Point(74, 53);
            this.OriginalBaseVerLabel.Name = "OriginalBaseVerLabel";
            this.OriginalBaseVerLabel.Size = new System.Drawing.Size(83, 12);
            this.OriginalBaseVerLabel.TabIndex = 1;
            this.OriginalBaseVerLabel.Text = "Base Version:";
            // 
            // BaseVerTxt
            // 
            this.BaseVerTxt.Location = new System.Drawing.Point(233, 51);
            this.BaseVerTxt.Name = "BaseVerTxt";
            this.BaseVerTxt.ReadOnly = true;
            this.BaseVerTxt.Size = new System.Drawing.Size(144, 21);
            this.BaseVerTxt.TabIndex = 2;
            // 
            // CurVerTxt
            // 
            this.CurVerTxt.Location = new System.Drawing.Point(233, 96);
            this.CurVerTxt.Name = "CurVerTxt";
            this.CurVerTxt.ReadOnly = true;
            this.CurVerTxt.Size = new System.Drawing.Size(144, 21);
            this.CurVerTxt.TabIndex = 4;
            // 
            // CurVerLabel
            // 
            this.CurVerLabel.AutoSize = true;
            this.CurVerLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurVerLabel.Location = new System.Drawing.Point(62, 98);
            this.CurVerLabel.Name = "CurVerLabel";
            this.CurVerLabel.Size = new System.Drawing.Size(101, 12);
            this.CurVerLabel.TabIndex = 3;
            this.CurVerLabel.Text = "Current Version:";
            // 
            // ResListLabel
            // 
            this.ResListLabel.AutoSize = true;
            this.ResListLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResListLabel.Location = new System.Drawing.Point(70, 150);
            this.ResListLabel.Name = "ResListLabel";
            this.ResListLabel.Size = new System.Drawing.Size(89, 12);
            this.ResListLabel.TabIndex = 5;
            this.ResListLabel.Text = "Resource list:";
            // 
            // ResList
            // 
            this.ResList.FormattingEnabled = true;
            this.ResList.ItemHeight = 12;
            this.ResList.Location = new System.Drawing.Point(233, 150);
            this.ResList.Name = "ResList";
            this.ResList.Size = new System.Drawing.Size(144, 148);
            this.ResList.TabIndex = 6;
            // 
            // BasePathLabel
            // 
            this.BasePathLabel.AutoSize = true;
            this.BasePathLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BasePathLabel.Location = new System.Drawing.Point(419, 50);
            this.BasePathLabel.Name = "BasePathLabel";
            this.BasePathLabel.Size = new System.Drawing.Size(65, 12);
            this.BasePathLabel.TabIndex = 7;
            this.BasePathLabel.Text = "Base Path:";
            this.BasePathLabel.Visible = false;
            // 
            // BasePathTxt
            // 
            this.BasePathTxt.AutoSize = true;
            this.BasePathTxt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BasePathTxt.Location = new System.Drawing.Point(513, 50);
            this.BasePathTxt.Name = "BasePathTxt";
            this.BasePathTxt.Size = new System.Drawing.Size(89, 12);
            this.BasePathTxt.TabIndex = 8;
            this.BasePathTxt.Text = "这里是路径地址";
            this.BasePathTxt.Visible = false;
            // 
            // BasePathBrowserBtn
            // 
            this.BasePathBrowserBtn.Location = new System.Drawing.Point(891, 45);
            this.BasePathBrowserBtn.Name = "BasePathBrowserBtn";
            this.BasePathBrowserBtn.Size = new System.Drawing.Size(75, 23);
            this.BasePathBrowserBtn.TabIndex = 9;
            this.BasePathBrowserBtn.Text = "浏览...";
            this.BasePathBrowserBtn.UseVisualStyleBackColor = true;
            this.BasePathBrowserBtn.Visible = false;
            // 
            // NewVerBtn
            // 
            this.NewVerBtn.Location = new System.Drawing.Point(456, 150);
            this.NewVerBtn.Name = "NewVerBtn";
            this.NewVerBtn.Size = new System.Drawing.Size(75, 23);
            this.NewVerBtn.TabIndex = 10;
            this.NewVerBtn.Text = "添加新版本";
            this.NewVerBtn.UseVisualStyleBackColor = true;
            this.NewVerBtn.Click += new System.EventHandler(this.NewVerBtn_Click);
            // 
            // GoGoGo
            // 
            this.GoGoGo.Location = new System.Drawing.Point(456, 198);
            this.GoGoGo.Name = "GoGoGo";
            this.GoGoGo.Size = new System.Drawing.Size(75, 23);
            this.GoGoGo.TabIndex = 11;
            this.GoGoGo.Text = "go!";
            this.GoGoGo.UseVisualStyleBackColor = true;
            this.GoGoGo.Click += new System.EventHandler(this.GoGoGo_Click);
            // 
            // compareBtn
            // 
            this.compareBtn.Location = new System.Drawing.Point(456, 246);
            this.compareBtn.Name = "compareBtn";
            this.compareBtn.Size = new System.Drawing.Size(75, 23);
            this.compareBtn.TabIndex = 12;
            this.compareBtn.Text = "对比";
            this.compareBtn.UseVisualStyleBackColor = true;
            this.compareBtn.Click += new System.EventHandler(this.compareBtn_Click);
            // 
            // testSynBtn
            // 
            this.testSynBtn.Location = new System.Drawing.Point(456, 291);
            this.testSynBtn.Name = "testSynBtn";
            this.testSynBtn.Size = new System.Drawing.Size(75, 23);
            this.testSynBtn.TabIndex = 13;
            this.testSynBtn.Text = "同步版本";
            this.testSynBtn.UseVisualStyleBackColor = true;
            this.testSynBtn.Visible = false;
            this.testSynBtn.Click += new System.EventHandler(this.testSynBtn_Click);
            // 
            // autoCompareCheckBox
            // 
            this.autoCompareCheckBox.AutoSize = true;
            this.autoCompareCheckBox.Checked = true;
            this.autoCompareCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoCompareCheckBox.Location = new System.Drawing.Point(421, 96);
            this.autoCompareCheckBox.Name = "autoCompareCheckBox";
            this.autoCompareCheckBox.Size = new System.Drawing.Size(96, 16);
            this.autoCompareCheckBox.TabIndex = 14;
            this.autoCompareCheckBox.Text = "是否自动对比";
            this.autoCompareCheckBox.UseVisualStyleBackColor = true;
            this.autoCompareCheckBox.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "打大包";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(456, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "重打大包";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // scriptCheckBox
            // 
            this.scriptCheckBox.AutoSize = true;
            this.scriptCheckBox.Checked = true;
            this.scriptCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scriptCheckBox.Location = new System.Drawing.Point(67, 215);
            this.scriptCheckBox.Name = "scriptCheckBox";
            this.scriptCheckBox.Size = new System.Drawing.Size(108, 16);
            this.scriptCheckBox.TabIndex = 17;
            this.scriptCheckBox.Text = "是否拷贝Script";
            this.scriptCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileCheckerBtn
            // 
            this.fileCheckerBtn.Location = new System.Drawing.Point(64, 274);
            this.fileCheckerBtn.Name = "fileCheckerBtn";
            this.fileCheckerBtn.Size = new System.Drawing.Size(75, 23);
            this.fileCheckerBtn.TabIndex = 18;
            this.fileCheckerBtn.Text = "文件查重";
            this.fileCheckerBtn.UseVisualStyleBackColor = true;
            this.fileCheckerBtn.Click += new System.EventHandler(this.fileCheckerBtn_Click);
            // 
            // switchModeBtn
            // 
            this.switchModeBtn.Location = new System.Drawing.Point(233, 328);
            this.switchModeBtn.Name = "switchModeBtn";
            this.switchModeBtn.Size = new System.Drawing.Size(75, 23);
            this.switchModeBtn.TabIndex = 19;
            this.switchModeBtn.Text = "切换模式";
            this.switchModeBtn.UseVisualStyleBackColor = true;
            this.switchModeBtn.Click += new System.EventHandler(this.switchModeBtn_Click);
            // 
            // checkSvnUpdate
            // 
            this.checkSvnUpdate.AutoSize = true;
            this.checkSvnUpdate.Location = new System.Drawing.Point(67, 176);
            this.checkSvnUpdate.Name = "checkSvnUpdate";
            this.checkSvnUpdate.Size = new System.Drawing.Size(90, 16);
            this.checkSvnUpdate.TabIndex = 20;
            this.checkSvnUpdate.Text = "是否更新SVN";
            this.checkSvnUpdate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 391);
            this.Controls.Add(this.checkSvnUpdate);
            this.Controls.Add(this.switchModeBtn);
            this.Controls.Add(this.fileCheckerBtn);
            this.Controls.Add(this.scriptCheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.autoCompareCheckBox);
            this.Controls.Add(this.testSynBtn);
            this.Controls.Add(this.compareBtn);
            this.Controls.Add(this.GoGoGo);
            this.Controls.Add(this.NewVerBtn);
            this.Controls.Add(this.BasePathBrowserBtn);
            this.Controls.Add(this.BasePathTxt);
            this.Controls.Add(this.BasePathLabel);
            this.Controls.Add(this.ResList);
            this.Controls.Add(this.ResListLabel);
            this.Controls.Add(this.CurVerTxt);
            this.Controls.Add(this.CurVerLabel);
            this.Controls.Add(this.BaseVerTxt);
            this.Controls.Add(this.OriginalBaseVerLabel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PackageTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OriginalBaseVerLabel;
        private System.Windows.Forms.TextBox BaseVerTxt;
        private System.Windows.Forms.TextBox CurVerTxt;
        private System.Windows.Forms.Label CurVerLabel;
        private System.Windows.Forms.Label ResListLabel;
        private System.Windows.Forms.ListBox ResList;
        private System.Windows.Forms.Label BasePathLabel;
        private System.Windows.Forms.FolderBrowserDialog BasePathFolderBrowser;
        private System.Windows.Forms.Label BasePathTxt;
        private System.Windows.Forms.Button BasePathBrowserBtn;
        //md5文件目录
        private string resmd5txtFolder;
        private System.Windows.Forms.Button NewVerBtn;
        private System.Windows.Forms.Button GoGoGo;
        //程序当前路劲
        private string curPath;
        //当前打包版本
        private string curVer;
        //已打版本个数
        private int verCount;
        //change.xml 路径
        private string changePath;
        //online folder
        private string onlineFolder;
        //change os
        private string changeOs;
        //localization media path
        private string locPath;
        //res media path
        private string resPath;
        //res script path
        private string scriptPath;
        private System.Windows.Forms.Button compareBtn;
        //svn path
        private string svnpath;
        //ini文件名
        private string iniFileName;
        private System.Windows.Forms.Button testSynBtn;
        private int verLen;
        private System.Windows.Forms.CheckBox autoCompareCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox scriptCheckBox;
        private System.Windows.Forms.Button fileCheckerBtn;
        private System.Windows.Forms.Button switchModeBtn;
        private int packMode;
        private System.Windows.Forms.CheckBox checkSvnUpdate;
    }
}

