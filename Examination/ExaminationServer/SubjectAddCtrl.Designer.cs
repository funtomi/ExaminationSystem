namespace ExaminationServer {
    partial class SubjectAddCtrl {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectAddCtrl));
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtBoxFileName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmboxSubType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBoxAbstract = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCompletion = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxResult = new System.Windows.Forms.TextBox();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.cmboxResult = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxResultD = new System.Windows.Forms.TextBox();
            this.txtBoxResultC = new System.Windows.Forms.TextBox();
            this.txtBoxResultB = new System.Windows.Forms.TextBox();
            this.txtBoxResultA = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cmboxSubLevel = new System.Windows.Forms.ComboBox();
            this.panelCompletion.SuspendLayout();
            this.panelSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.Enabled = false;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.Location = new System.Drawing.Point(552, 58);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(36, 34);
            this.btnPlay.TabIndex = 22;
            this.btnPlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Location = new System.Drawing.Point(485, 60);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(51, 30);
            this.btnOpenFile.TabIndex = 21;
            this.btnOpenFile.Text = "浏览";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtBoxFileName
            // 
            this.txtBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxFileName.Location = new System.Drawing.Point(136, 65);
            this.txtBoxFileName.Name = "txtBoxFileName";
            this.txtBoxFileName.Size = new System.Drawing.Size(334, 25);
            this.txtBoxFileName.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "听力文件选择：";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(121, 576);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmboxSubType
            // 
            this.cmboxSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxSubType.FormattingEnabled = true;
            this.cmboxSubType.Items.AddRange(new object[] {
            "选择题",
            "填空题"});
            this.cmboxSubType.Location = new System.Drawing.Point(145, 20);
            this.cmboxSubType.Name = "cmboxSubType";
            this.cmboxSubType.Size = new System.Drawing.Size(121, 23);
            this.cmboxSubType.TabIndex = 7;
            this.cmboxSubType.SelectedIndexChanged += new System.EventHandler(this.cmboxSubType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "题目类型：";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(24, 576);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBoxAbstract
            // 
            this.txtBoxAbstract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxAbstract.Location = new System.Drawing.Point(24, 133);
            this.txtBoxAbstract.Multiline = true;
            this.txtBoxAbstract.Name = "txtBoxAbstract";
            this.txtBoxAbstract.Size = new System.Drawing.Size(636, 88);
            this.txtBoxAbstract.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "题目内容：";
            // 
            // panelCompletion
            // 
            this.panelCompletion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCompletion.Controls.Add(this.label9);
            this.panelCompletion.Controls.Add(this.txtBoxResult);
            this.panelCompletion.Location = new System.Drawing.Point(24, 227);
            this.panelCompletion.Name = "panelCompletion";
            this.panelCompletion.Size = new System.Drawing.Size(636, 326);
            this.panelCompletion.TabIndex = 16;
            this.panelCompletion.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "答案：";
            // 
            // txtBoxResult
            // 
            this.txtBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxResult.Location = new System.Drawing.Point(17, 57);
            this.txtBoxResult.Multiline = true;
            this.txtBoxResult.Name = "txtBoxResult";
            this.txtBoxResult.Size = new System.Drawing.Size(602, 214);
            this.txtBoxResult.TabIndex = 15;
            // 
            // panelSelect
            // 
            this.panelSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSelect.Controls.Add(this.cmboxResult);
            this.panelSelect.Controls.Add(this.label4);
            this.panelSelect.Controls.Add(this.txtBoxResultD);
            this.panelSelect.Controls.Add(this.txtBoxResultC);
            this.panelSelect.Controls.Add(this.txtBoxResultB);
            this.panelSelect.Controls.Add(this.txtBoxResultA);
            this.panelSelect.Controls.Add(this.label7);
            this.panelSelect.Controls.Add(this.label6);
            this.panelSelect.Controls.Add(this.label5);
            this.panelSelect.Controls.Add(this.label3);
            this.panelSelect.Controls.Add(this.label1);
            this.panelSelect.Location = new System.Drawing.Point(24, 227);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(636, 326);
            this.panelSelect.TabIndex = 4;
            this.panelSelect.Visible = false;
            // 
            // cmboxResult
            // 
            this.cmboxResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxResult.FormattingEnabled = true;
            this.cmboxResult.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cmboxResult.Location = new System.Drawing.Point(27, 275);
            this.cmboxResult.Name = "cmboxResult";
            this.cmboxResult.Size = new System.Drawing.Size(121, 23);
            this.cmboxResult.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "答案：";
            // 
            // txtBoxResultD
            // 
            this.txtBoxResultD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxResultD.Location = new System.Drawing.Point(27, 228);
            this.txtBoxResultD.Name = "txtBoxResultD";
            this.txtBoxResultD.Size = new System.Drawing.Size(592, 25);
            this.txtBoxResultD.TabIndex = 13;
            // 
            // txtBoxResultC
            // 
            this.txtBoxResultC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxResultC.Location = new System.Drawing.Point(27, 178);
            this.txtBoxResultC.Name = "txtBoxResultC";
            this.txtBoxResultC.Size = new System.Drawing.Size(592, 25);
            this.txtBoxResultC.TabIndex = 12;
            // 
            // txtBoxResultB
            // 
            this.txtBoxResultB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxResultB.Location = new System.Drawing.Point(27, 120);
            this.txtBoxResultB.Name = "txtBoxResultB";
            this.txtBoxResultB.Size = new System.Drawing.Size(592, 25);
            this.txtBoxResultB.TabIndex = 11;
            // 
            // txtBoxResultA
            // 
            this.txtBoxResultA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxResultA.Location = new System.Drawing.Point(27, 64);
            this.txtBoxResultA.Name = "txtBoxResultA";
            this.txtBoxResultA.Size = new System.Drawing.Size(592, 25);
            this.txtBoxResultA.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "B:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "C:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "D:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "A:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "题目选项：";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(607, 58);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(36, 34);
            this.btnStop.TabIndex = 23;
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(312, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "题目等级选择：";
            // 
            // cmboxSubLevel
            // 
            this.cmboxSubLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxSubLevel.FormattingEnabled = true;
            this.cmboxSubLevel.Location = new System.Drawing.Point(430, 20);
            this.cmboxSubLevel.Name = "cmboxSubLevel";
            this.cmboxSubLevel.Size = new System.Drawing.Size(129, 23);
            this.cmboxSubLevel.TabIndex = 25;
            // 
            // SubjectAddCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScroll = true;
            this.Controls.Add(this.cmboxSubLevel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtBoxFileName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmboxSubType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBoxAbstract);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.panelCompletion);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(600, 597);
            this.Name = "SubjectAddCtrl";
            this.Size = new System.Drawing.Size(682, 615);
            this.Load += new System.EventHandler(this.SubjectAddCtrl_Load);
            this.panelCompletion.ResumeLayout(false);
            this.panelCompletion.PerformLayout();
            this.panelSelect.ResumeLayout(false);
            this.panelSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxAbstract;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.ComboBox cmboxResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxResultD;
        private System.Windows.Forms.TextBox txtBoxResultC;
        private System.Windows.Forms.TextBox txtBoxResultB;
        private System.Windows.Forms.TextBox txtBoxResultA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmboxSubType;
        private System.Windows.Forms.Panel panelCompletion;
        private System.Windows.Forms.TextBox txtBoxResult;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBoxFileName;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmboxSubLevel;
    }
}
