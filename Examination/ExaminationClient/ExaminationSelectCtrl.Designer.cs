namespace ExaminationClient {
    partial class ExaminationSelectCtrl {
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmboxSubType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmboxSubLevel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxSubNumber = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择题目类型：";
            // 
            // cmboxSubType
            // 
            this.cmboxSubType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboxSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxSubType.FormattingEnabled = true;
            this.cmboxSubType.Location = new System.Drawing.Point(147, 24);
            this.cmboxSubType.Name = "cmboxSubType";
            this.cmboxSubType.Size = new System.Drawing.Size(260, 23);
            this.cmboxSubType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "选择题目等级：";
            // 
            // cmboxSubLevel
            // 
            this.cmboxSubLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboxSubLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxSubLevel.FormattingEnabled = true;
            this.cmboxSubLevel.Location = new System.Drawing.Point(147, 78);
            this.cmboxSubLevel.Name = "cmboxSubLevel";
            this.cmboxSubLevel.Size = new System.Drawing.Size(260, 23);
            this.cmboxSubLevel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "选择题目数量：";
            // 
            // txtBoxSubNumber
            // 
            this.txtBoxSubNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxSubNumber.Location = new System.Drawing.Point(147, 141);
            this.txtBoxSubNumber.Name = "txtBoxSubNumber";
            this.txtBoxSubNumber.Size = new System.Drawing.Size(260, 25);
            this.txtBoxSubNumber.TabIndex = 5;
            this.txtBoxSubNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxSubNumber_KeyPress);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(235, 203);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 36);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "开始考试";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // ExaminationCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtBoxSubNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmboxSubLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmboxSubType);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "ExaminationCtrl";
            this.Size = new System.Drawing.Size(454, 271);
            this.Load += new System.EventHandler(this.ExaminationCtrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboxSubType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmboxSubLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxSubNumber;
        private System.Windows.Forms.Button btnStart;
    }
}
