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
            this.btnSearch = new System.Windows.Forms.Button();
            this.RankingCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HighestScoreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestTimsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastTestTimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RankingCol,
            this.NameCol,
            this.HighestScoreCol,
            this.TestTimsCol,
            this.LastTestTimeCol,
            this.IdCol});
            this.dataGridView1.Location = new System.Drawing.Point(27, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(636, 316);
            this.dataGridView1.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(574, 63);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 30);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查找自己";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // RankingCol
            // 
            this.RankingCol.DataPropertyName = "Ranking";
            this.RankingCol.HeaderText = "名次";
            this.RankingCol.Name = "RankingCol";
            this.RankingCol.ReadOnly = true;
            // 
            // NameCol
            // 
            this.NameCol.DataPropertyName = "UserName";
            this.NameCol.HeaderText = "姓名";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            // 
            // HighestScoreCol
            // 
            this.HighestScoreCol.DataPropertyName = "HighestScore";
            this.HighestScoreCol.HeaderText = "最高分";
            this.HighestScoreCol.Name = "HighestScoreCol";
            this.HighestScoreCol.ReadOnly = true;
            // 
            // TestTimsCol
            // 
            this.TestTimsCol.DataPropertyName = "TestTimes";
            this.TestTimsCol.HeaderText = "考试次数";
            this.TestTimsCol.Name = "TestTimsCol";
            this.TestTimsCol.ReadOnly = true;
            // 
            // LastTestTimeCol
            // 
            this.LastTestTimeCol.DataPropertyName = "LastTestTime";
            this.LastTestTimeCol.HeaderText = "最近考试时间";
            this.LastTestTimeCol.Name = "LastTestTimeCol";
            this.LastTestTimeCol.ReadOnly = true;
            this.LastTestTimeCol.Width = 200;
            // 
            // IdCol
            // 
            this.IdCol.DataPropertyName = "UserId";
            this.IdCol.HeaderText = "Id";
            this.IdCol.Name = "IdCol";
            this.IdCol.ReadOnly = true;
            this.IdCol.Visible = false;
            // 
            // StudyRankingListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Name = "StudyRankingListCtrl";
            this.Size = new System.Drawing.Size(682, 479);
            this.Load += new System.EventHandler(this.StudyRankingListCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn RankingCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HighestScoreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestTimsCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastTestTimeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCol;
    }
}
