using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationServer {
    public partial class UserRecordCtrl : ExaminationServer.BaseControl {
        public UserRecordCtrl() {
            InitializeComponent();
        }
        
        /// <summary>
        /// 设置用户成绩
        /// </summary>
        private void SetUserRecord() {
            var data = GetUserRecord();
            if (data == null||data.Rows.Count == 0) {
                this.dataGridView1.DataSource = CreateEmptyTable();
                return;
            }
            this.dataGridView1.DataSource = data;
        }

        /// <summary>
        /// 创建空表格
        /// </summary>
        /// <returns></returns>
        private DataTable CreateEmptyTable() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(Guid));
            dt.Columns.Add("Name");
            dt.Columns.Add("Record");
            dt.Columns.Add("TestTime",typeof(DateTime));
            dt.Columns.Add("TestTimes",typeof(int));
            dt.Columns.Add("HighestScore",typeof(int));
            return dt;
        }

        /// <summary>
        /// 获取用户成绩
        /// </summary>
        /// <returns></returns>
        private DataTable GetUserRecord() {
            try {
                using (SqlConnection conn = new SqlConnection (SQL_CON)) {
                    conn.Open();
                    var sql = "select * from UserRecord order by TestTime desc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    return dt;
                }
            } catch (Exception ex) {
                MessageBox.Show("获取成绩记录失败，错误原因："+ex.Message);
                return null;
            }
        }
        
        /// <summary>
        /// 搜索用户成绩记录
        /// </summary>
        /// <param name="text"></param>
        private void SearchUserRecord(string text) {
            if (string.IsNullOrEmpty(text)) {
                MessageBox.Show("请输入查询用户名！");
                return;
            }
            var data = DoSearch(text);
            if (data==null||data.Rows.Count==0) {
                this.dataGridView1.DataSource = CreateEmptyTable();
                return;
            }
            this.dataGridView1.DataSource = data;
        }

        /// <summary>
        /// 查找匹配项
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private DataTable DoSearch(string text) {
            if (string.IsNullOrEmpty(text)) {
                return null;
            }
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from UserRecord where Name like '%'+@text+'%'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    return dt;
                }
            } catch (Exception ex) {
                MessageBox.Show("查询失败，错误原因："+ex.Message);
                return null;
            }
        }
        #region 事件
        private void UserRecordCtrl_Load(object sender, EventArgs e) {
            SetUserRecord();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            SearchUserRecord(this.txtUserInfo.Text);
        }

        private void txtUserInfo_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                SearchUserRecord(this.txtUserInfo.Text);
            }
        }
        
        #endregion
    }
}
