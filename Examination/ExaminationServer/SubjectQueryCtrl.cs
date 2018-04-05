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
using ExaminationHelper;

namespace ExaminationServer {
    public partial class SubjectQueryCtrl : ExaminationServer.BaseControl {
        public SubjectQueryCtrl() {
            InitializeComponent();
        }

        private DataTable _data = new DataTable();//最新的搜索结果

        public delegate void SelectSubjectEventDelegate();
        public SelectSubjectEventDelegate SelectSubjectEvent;

        /// <summary>
        /// 当前选择的题目ID
        /// </summary>
        public string CurrentId { get { return _currentId; }  }
        private string _currentId;

        /// <summary>
        /// 搜索
        /// </summary>
        private void SearchSubject() {
            var text = this.txtSearch.Text;
            if (string.IsNullOrEmpty(text)) {//如果没有输入搜索内容，则清空表格
                ClearDataGridView();
                return;
            }
            //获取题目类型
            var type = this.cmboxType.Text;
            var data = DoSearch(text, type);
            if (data == null || data.Rows.Count == 0) {
                _data.Rows.Clear();
                ClearDataGridView();
                MessageBox.Show("没有找到匹配的题目！");
                return;
            }
            _data = data;
            var filtData = GetDisplayData(data);
            if (filtData == null || filtData.Rows.Count == 0) {
                ClearDataGridView();
                return;
            }  
            this.dataGridView1.DataSource = filtData;
        }

        /// <summary>
        /// 清除表格内容
        /// </summary>
        private void ClearDataGridView() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Abstract");
            dt.Columns.Add("SubType");
            dt.Columns.Add("Id"); 
            this.dataGridView1.DataSource = dt;
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
        private DataTable DoSearch(string text, string type) {
            if (string.IsNullOrEmpty(text)) {
                return null;
            }
            try {
                using (SqlConnection con = new SqlConnection(SQL_CON)) {
                    DataTable dt = new DataTable();
                    string sql = "select * from Subject where SubType = @type and Abstract like  '%'+ @text + '%'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql,con);
                    cmd.Parameters.Add(new SqlParameter("@type", type));
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
        /// 设置题目类型
        /// </summary>
        private void SetSubjectTypes() {
            this.cmboxType.Items.Clear();
            List<string> types = GetSubTypes();
            if (types == null||types.Count == 0) {
                MessageBox.Show("没有找到题目类型！");
                return;
            }
            this.cmboxType.Items.AddRange(types.ToArray());
            this.cmboxType.SelectedIndex = 0;

        }
         

        #region 事件
        private void SubjectQueryCtrl_Load(object sender, EventArgs e) {
            SetSubjectTypes();
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex<0) {
                return;
            }
            _currentId = this.dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            if (SelectSubjectEvent!=null) {
                SelectSubjectEvent();
            }
        }
        #endregion
         
    }

}
