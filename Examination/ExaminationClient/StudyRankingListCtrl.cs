using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationClient {
    public partial class StudyRankingListCtrl : ExaminationClient.BaseCtrl {
        public StudyRankingListCtrl() {
            InitializeComponent();
        }
        #region 事件
        private void StudyRankingListCtrl_Load(object sender, EventArgs e) {
            var data = ServiceWindow.Service.GetStudyRankingList();
            if (data == null || data.Rows.Count == 0) {
                data = CreateDataTable();
            }
            this.dataGridView1.DataSource = data;
        }


        #endregion
        /// <summary>
        /// 创建空表
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDataTable() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ranking", typeof(int));
            dt.Columns.Add("UserName");
            dt.Columns.Add("HighestScore", typeof(int));
            dt.Columns.Add("TestTimes", typeof(int));
            dt.Columns.Add("LastTestTime", typeof(DateTime));
            dt.Columns.Add("UserId", typeof(Guid));
            return dt;
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            var dataSource = this.dataGridView1.DataSource as DataTable;
            if (dataSource == null || dataSource.Rows.Count == 0) {
                MessageBox.Show("可惜，您还未上榜！");
                return;
            }
            var table = CreateDataTable();
            foreach (DataRow row in dataSource.Rows) {
                if (row["UserId"].ToString() == ServiceWindow.UserId.ToString()) {
                    var newRow = table.NewRow();
                    newRow["Ranking"] = row["Ranking"];
                    newRow["UserName"] = row["UserName"];
                    newRow["HighestScore"] = row["HighestScore"];
                    newRow["TestTimes"] = row["TestTimes"];
                    newRow["LastTestTime"] = row["LastTestTime"];
                    newRow["UserId"] = row["UserId"];
                    table.Rows.Add(newRow);
                    break;
                }
            }
            if (table.Rows.Count == 0) {
                MessageBox.Show("对不起，您还未上榜！");
                return;
            }
            this.dataGridView1.DataSource = table;
        }

    }
}
