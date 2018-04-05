using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ExaminationServer {
    public partial class SubjectQueryCtrl : ExaminationServer.BaseControl {
        public SubjectQueryCtrl() {
            InitializeComponent();
        } 

        private DataTable _data;//最新的搜索结果

        /// <summary>
        /// 搜索
        /// </summary>
        private void SearchSubject() {
            var text = this.txtSearch.Text;
            if (string.IsNullOrEmpty(text)) {//如果没有输入搜索内容，则清空表格
                this.dataGridView1.Rows.Clear();
                return;
            }
            //获取题目类型
            var type = GetSubjectType(this.cmboxType.SelectedItem.ToString());
            var data = DoSearch(text, type);
            if (data == null || data.Rows.Count == 0) {
                _data.Rows.Clear();
                this.dataGridView1.Rows.Clear();
                MessageBox.Show("没有找到匹配的题目！");
                return;
            }
            _data = data;
            var filtData = GetDisplayData(data);
            if (filtData == null || filtData.Rows.Count == 0) {
                this.dataGridView1.Rows.Clear();
                return;
            }
            filtData.Columns.Add("SubDisType");
            foreach (DataRow row in filtData.Rows) {
                switch ((SubjectType)row["SubType"]) {
                    default:
                    case SubjectType.select:
                        row["SubDisType"] = "选择题";
                        break;
                    case SubjectType.completion:
                        row["SubDisType"] = "填空题";
                        break; 
                }
            }
            this.dataGridView1.DataSource = filtData;
        }

        /// <summary>
        /// 获取需要显示的列
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private DataTable GetDisplayData(DataTable data) {
            if (data == null||data.Rows.Count == 0) {
                return null;
            }
            return data.DefaultView.ToTable(false, new string[] {"Abstract","SubType","Id" });
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="text">搜索内容</param>
        /// <param name="type">题目类型</param>
        /// <returns></returns>
        private DataTable DoSearch(string text, SubjectType type) {
            if (string.IsNullOrEmpty(text)) {
                return null;
            }
            try {
                using (SqlConnection con = new SqlConnection(SQL_CON)) {
                    DataTable dt = new DataTable();
                    string sql = "select * from Subject where SubType = @type and Abstract like  '%'+ @text + '%'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql,con);
                    cmd.Parameters.Add(new SqlParameter("@type", (int)type));
                    cmd.Parameters.Add(new SqlParameter("@text", text));
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    ada.Fill(dt);
                    con.Close();
                    return dt;
                }
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// 获取题目类型
        /// </summary>
        /// <param name="p">选择的题目类型</param>
        /// <returns></returns>
        private SubjectType GetSubjectType(string p) {
            if (string.IsNullOrEmpty(p)) {
                return SubjectType.select;
            }
            switch (p) {
                default:
                case "选择题":
                    return SubjectType.select;
                case "填空题":
                    return SubjectType.completion;
            }
        }


        #region 事件
        private void SubjectQueryCtrl_Load(object sender, EventArgs e) {
            this.cmboxType.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e) {

            SearchSubject();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != 13) {
                return;
            }
            SearchSubject();
        }
        #endregion

      
    }

}
