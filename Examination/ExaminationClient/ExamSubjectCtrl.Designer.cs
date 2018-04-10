namespace ExaminationClient {
    partial class ExamSubjectCtrl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamSubjectCtrl));
            this.lblAbstract = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBtnD = new System.Windows.Forms.RadioButton();
            this.rdBtnC = new System.Windows.Forms.RadioButton();
            this.rdBtnB = new System.Windows.Forms.RadioButton();
            this.rdBtnA = new System.Windows.Forms.RadioButton();
            this.panelCompletion = new System.Windows.Forms.Panel();
            this.txtboxResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelSelect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelCompletion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAbstract
            // 
            this.lblAbstract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAbstract.AutoEllipsis = true;
            this.lblAbstract.Location = new System.Drawing.Point(45, 105);
            this.lblAbstract.Name = "lblAbstract";
            this.lblAbstract.Size = new System.Drawing.Size(532, 52);
            this.lblAbstract.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "题目内容：";
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(188, 22);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(36, 34);
            this.btnStop.TabIndex = 3;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Location = new System.Drawing.Point(128, 22);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(36, 34);
            this.btnStart.TabIndex = 2;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(26, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(92, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "选择题：";
            // 
            // panelSelect
            // 
            this.panelSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSelect.AutoScroll = true;
            this.panelSelect.Controls.Add(this.groupBox1);
            this.panelSelect.Location = new System.Drawing.Point(31, 160);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(555, 340);
            this.panelSelect.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdBtnD);
            this.groupBox1.Controls.Add(this.rdBtnC);
            this.groupBox1.Controls.Add(this.rdBtnB);
            this.groupBox1.Controls.Add(this.rdBtnA);
            this.groupBox1.Location = new System.Drawing.Point(19, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 309);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选项：";
            // 
            // rdBtnD
            // 
            this.rdBtnD.AutoSize = true;
            this.rdBtnD.Location = new System.Drawing.Point(255, 118);
            this.rdBtnD.Name = "rdBtnD";
            this.rdBtnD.Size = new System.Drawing.Size(14, 13);
            this.rdBtnD.TabIndex = 3;
            this.rdBtnD.TabStop = true;
            this.rdBtnD.UseVisualStyleBackColor = true;
            this.rdBtnD.CheckedChanged += new System.EventHandler(this.rdBtnA_CheckedChanged);
            // 
            // rdBtnC
            // 
            this.rdBtnC.AutoSize = true;
            this.rdBtnC.Location = new System.Drawing.Point(29, 111);
            this.rdBtnC.Name = "rdBtnC";
            this.rdBtnC.Size = new System.Drawing.Size(14, 13);
            this.rdBtnC.TabIndex = 2;
            this.rdBtnC.TabStop = true;
            this.rdBtnC.UseVisualStyleBackColor = true;
            this.rdBtnC.CheckedChanged += new System.EventHandler(this.rdBtnA_CheckedChanged);
            // 
            // rdBtnB
            // 
            this.rdBtnB.AutoSize = true;
            this.rdBtnB.Location = new System.Drawing.Point(255, 41);
            this.rdBtnB.Name = "rdBtnB";
            this.rdBtnB.Size = new System.Drawing.Size(14, 13);
            this.rdBtnB.TabIndex = 1;
            this.rdBtnB.TabStop = true;
            this.rdBtnB.UseVisualStyleBackColor = true;
            this.rdBtnB.CheckedChanged += new System.EventHandler(this.rdBtnA_CheckedChanged);
            // 
            // rdBtnA
            // 
            this.rdBtnA.AutoSize = true;
            this.rdBtnA.Location = new System.Drawing.Point(29, 41);
            this.rdBtnA.Name = "rdBtnA";
            this.rdBtnA.Size = new System.Drawing.Size(14, 13);
            this.rdBtnA.TabIndex = 0;
            this.rdBtnA.TabStop = true;
            this.rdBtnA.UseVisualStyleBackColor = true;
            this.rdBtnA.CheckedChanged += new System.EventHandler(this.rdBtnA_CheckedChanged);
            // 
            // panelCompletion
            // 
            this.panelCompletion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCompletion.Controls.Add(this.txtboxResult);
            this.panelCompletion.Controls.Add(this.label3);
            this.panelCompletion.Location = new System.Drawing.Point(28, 157);
            this.panelCompletion.Name = "panelCompletion";
            this.panelCompletion.Size = new System.Drawing.Size(555, 360);
            this.panelCompletion.TabIndex = 2;
            // 
            // txtboxResult
            // 
            this.txtboxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxResult.Location = new System.Drawing.Point(33, 51);
            this.txtboxResult.Multiline = true;
            this.txtboxResult.Name = "txtboxResult";
            this.txtboxResult.Size = new System.Drawing.Size(497, 292);
            this.txtboxResult.TabIndex = 1;
            this.txtboxResult.TextChanged += new System.EventHandler(this.txtboxResult_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "答案：";
            // 
            // ExamSubjectCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.Controls.Add(this.lblAbstract);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.panelCompletion);
            this.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ExamSubjectCtrl";
            this.Size = new System.Drawing.Size(617, 548);
            this.Load += new System.EventHandler(this.ExamSubjectCtrl_Load);
            this.panelSelect.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelCompletion.ResumeLayout(false);
            this.panelCompletion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAbstract;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdBtnD;
        private System.Windows.Forms.RadioButton rdBtnC;
        private System.Windows.Forms.RadioButton rdBtnB;
        private System.Windows.Forms.RadioButton rdBtnA;
        private System.Windows.Forms.Panel panelCompletion;
        private System.Windows.Forms.TextBox txtboxResult;
        private System.Windows.Forms.Label label3;
    }
}
