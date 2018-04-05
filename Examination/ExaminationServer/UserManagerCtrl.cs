using ExaminationEntity;
using ExaminationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationServer {
    public partial class UserManagerCtrl : ExaminationServer.BaseControl {
        public UserManagerCtrl() {
            InitializeComponent();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        private DataTable GetUserInfos(string text) {
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from UserInfo";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (!string.IsNullOrEmpty(text)) {
                        cmd.CommandText += " where Name like '%'+ @text + '%'";
                        cmd.Parameters.AddWithValue("@text",text);
                    }
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    return dt;
                }
            } catch (Exception ex) {
                MessageBox.Show("获取用户信息失败，错误原因：" + ex.Message);
                return CreatEmptyTable();
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        private DataTable GetUserInfos() {
            return GetUserInfos("");
        }

        /// <summary>
        /// 创建空表格
        /// </summary>
        /// <returns></returns>
        private DataTable CreatEmptyTable() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(Guid));
            dt.Columns.Add("Name");
            dt.Columns.Add("Password");
            return dt;
        }

        /// <summary>
        /// 搜索用户
        /// </summary>
        private void SearchUser() {
            if (string.IsNullOrEmpty(this.txtBoxUserInfo.Text)) {
                MessageBox.Show("请输入查询内容！");
                this.dataGridView1.DataSource = CreatEmptyTable();
                return;
            }
            var dt = GetUserInfos(this.txtBoxUserInfo.Text);
            if (dt == null||dt.Rows.Count == 0) {
                this.dataGridView1.DataSource = CreatEmptyTable();
                MessageBox.Show("没有找到匹配的内容！");
                return;
            }
            this.dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void SaveTable() {
            var dt = this.dataGridView1.DataSource as DataTable;
            if (dt==null||dt.Rows.Count == 0) {
                MessageBox.Show("没有需要保存的内容！");
                return;
            }
            string errText = "";
            int errCount = 0;
            foreach (DataRow row in dt.Rows) {
                row.ClearErrors();

                if (row.RowState == DataRowState.Detached||row.RowState == DataRowState.Unchanged) {
                    continue;
                }
                if (row.RowState == DataRowState.Deleted) {
                    continue;
                }
                if (row.RowState == DataRowState.Added) {
                    var data = new UserInfo() {
                        Name = row["Name"].ToString(),
                        Password = row["Password"].ToString(),
                        Id = Guid.NewGuid()
                    };
                
                    if (AddCurrentRow(data, out errText)) {
                        row["Id"] = data.Id;
                        continue;
                    }
                    errCount++;
                    row.RowError = errText; 
                }
                if (row.RowState == DataRowState.Modified) {
                    var data = new UserInfo() {
                        Name = row["Name"].ToString(),
                        Password = row["Password"].ToString(),
                        Id =  (Guid)row["Id"]
                    };
                    if (ModifyCurrentRow(data, out errText)) {
                        continue; 
                    }
                    errCount++;
                    row.RowError = errText; 
                }
            }
            if (errCount == 0) {
                MessageBox.Show("保存成功！");
                return;
            }
            MessageBox.Show(string.Format("有{0}条保存失败，请检查！", errCount));
        }

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        private bool ModifyCurrentRow(UserInfo data, out string errText) {
            errText = "";
            if (data==null) {
                return false;
            }
            try {
                using (SqlConnection conn  = new SqlConnection (SQL_CON)) {
                    conn.Open();
                    var sql = "updata UserInfo set Name = @Name,Password =@Password where Id=@Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", data.Id);
                    cmd.Parameters.AddWithValue("@Name", data.Name);
                    cmd.Parameters.AddWithValue("@Password", data.Password);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            } catch (Exception ex) {
                errText = "修改失败，错误原因：" + ex.Message;
                return false;
                
                throw;
            }
        }

        /// <summary>
        /// 添加新行
        /// </summary>
        /// <param name="data"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        private bool AddCurrentRow(UserInfo data,out string errText) {
            errText = "";
            if (data ==null) {
                return false;
            }
            try {
                using (SqlConnection conn = new SqlConnection (SQL_CON)) {
                    conn.Open();
                    var sql = "insert into UserInfo(Name,Id,Password)Values(@Name,@Id,@Password)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Name",data.Name);
                    cmd.Parameters.AddWithValue("@Id",data.Id);
                    cmd.Parameters.AddWithValue("@Password", data.Password);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            } catch (Exception ex) {
                errText = "新增失败，错误原因：" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 删除一条用户记录
        /// </summary>
        /// <param name="data"></param>
        private bool DeleteCurrentRow(Guid id,out string errText) {
            errText = "";
            if (id == null) {
                return false;
            }
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "delete UserInfo where Id = @Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            } catch (Exception ex) {
                errText = "删除失败，错误原因：" + ex.Message;
                return false;
            }
        }

        #region 事件
        private void UserManagerCtrl_Load(object sender, EventArgs e) {
            this.dataGridView1.DataSource =  GetUserInfos();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            SearchUser();
        }

        private void txtBoxUserInfo_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                SearchUser();
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            SaveTable();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            var id = (Guid)e.Row.Cells["Id"].Value;
            string errText = "";
            if (!DeleteCurrentRow(id, out errText)) {
                MessageBox.Show("删除失败，错误原因：" + errText);
                e.Cancel = true;
            }
        }
        #endregion
         
        
         
    }
}
