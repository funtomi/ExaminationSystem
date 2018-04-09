namespace ExaminationClient {
    partial class StudyRankingListCtrl {
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
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RankingCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HighestScoreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestTimsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastTestTimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "学习排行榜";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RankingCol,
            this.NameCol,
            this.HighestScoreCol,
            this.TestTimsCol,
            this.LastTestTimeCol});
            this.dataGridView1.Location = new System.Drawing.Point(27, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(636, 360);
            this.dataGridView1.TabIndex = 4;
            // 
            // RankingCol
            // 
            this.RankingCol.HeaderText = "名次";
            this.RankingCol.Name = "RankingCol";
            this.RankingCol.ReadOnly = true;
            // 
            // NameCol
            // 
            this.NameCol.HeaderText = "姓名";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            // 
            // HighestScoreCol
            // 
            this.HighestScoreCol.HeaderText = "最高分";
            this.HighestScoreCol.Name = "HighestScoreCol";
            this.HighestScoreCol.ReadOnly = true;
            // 
            // TestTimsCol
            // 
            this.TestTimsCol.HeaderText = "考试次数";
            this.TestTimsCol.Name = "TestTimsCol";
            this.TestTimsCol.ReadOnly = true;
            // 
            // LastTestTimeCol
            // 
            this.LastTestTimeCol.HeaderText = "最近考试时间";
            this.LastTestTimeCol.Name = "LastTestTimeCol";
            this.LastTestTimeCol.ReadOnly = true;
            this.LastTestTimeCol.Width = 200;
            // 
            // StudyRankingListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Name = "StudyRankingListCtrl";
            this.Size = new System.Drawing.Size(682, 445);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RankingCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HighestScoreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestTimsCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastTestTimeCol;
    }
}
