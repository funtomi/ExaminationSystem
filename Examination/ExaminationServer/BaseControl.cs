using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using ExaminationHelper;

namespace ExaminationServer {
    public partial class BaseControl : UserControl {
        public BaseControl() {
            InitializeComponent();
        }
        protected static string SQL_CON = ConfigurationManager.AppSettings["sqlCon"];

        /// <summary>
        /// 获取题目类型
        /// </summary>
        /// <returns></returns>
        protected List<string> GetSubTypes() {
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select DisplayName from SubjectType";
                    SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    if (dt == null || dt.Rows.Count == 0) {
                        return null;
                    }
                    var list = dt.AsEnumerable().Select(c => c.Field<string>("DisplayName")).ToList<string>();
                    return list;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
     
}
