using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationServer {
    public partial class BasicInfoManager : ExaminationServer.BaseControl {
        public BasicInfoManager() {
            InitializeComponent();
        }
        public BasicInfoManager(BasicType type)
            : this() {
            _type = type;
        }

        private BasicType _type;

        /// <summary>
        /// 创建空表格
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private object CreatDataTable() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(Guid));
            dt.Columns.Add("DisplayName");
            return dt;
        }

        /// <summary>
        ///  获取题目内容
        /// </summary>
        /// <returns></returns>
        private DataTable GetSubTypeStruct(string tableName) {
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = string.Format(" select * from {0}", tableName);
                    SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    return dt;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dt"></param>
        private void SaveContent(DataTable dt) {
            if (!AddIds()) {
                return;
            }
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();//打开链接   
                    var tableName = GetTypeTableName(_type);
                    var sql = string.Format("delete {0}", tableName);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    using (SqlBulkCopy copy = new SqlBulkCopy(SQL_CON, SqlBulkCopyOptions.Default)) {
                        copy.DestinationTableName = tableName;  //指定服务器上目标表的名称   
                        copy.WriteToServer(dt);//执行把DataTable中的数据写入DB

                    }
                    conn.Close();
                    MessageBox.Show("保存成功！");
                }
            } catch (Exception ex) {
                MessageBox.Show("保存失败！错误原因：" + ex.Message);
            }

        }

        /// <summary>
        /// 为新增行添加id
        /// </summary>
        private bool AddIds() {
            var dt = this.dataGridView1.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0) {
                return false;
            }

            foreach (DataRow item in dt.Rows) {
                if (item.RowState == DataRowState.Deleted) {
                    continue;
                }
                if (string.IsNullOrEmpty(item["DisplayName"].ToString())) {
                    MessageBox.Show("内容不能为空！");
                    return false;
                }
                item["Id"] = Guid.NewGuid();
            }
            return true;
        }

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetTypeTableName(BasicType type) {
            switch (type) {
                case BasicType.SubType:
                    return "SubjectType";
                case BasicType.SubLevel:
                    return "SubjectLevel";
            }
            return null;
        }

        #region 事件
        private void BasicInfoManager_Load(object sender, EventArgs e) {
            var dt = GetSubTypeStruct(GetTypeTableName(_type));
            if (dt == null || dt.Rows.Count == 0) {
                this.dataGridView1.DataSource = CreatDataTable();
                return;
            }
            this.dataGridView1.DataSource = dt;

        }

        private void btnSave_Click(object sender, EventArgs e) {
            var dt = this.dataGridView1.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0) {
                MessageBox.Show("没有数据！");
                return;
            }
            SaveContent(dt);
        }

        #endregion

    }

    public enum BasicType {
        SubType, SubLevel
    }
}
