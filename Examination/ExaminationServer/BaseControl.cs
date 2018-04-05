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

namespace ExaminationServer {
    public partial class BaseControl : UserControl {
        public BaseControl() {
            InitializeComponent();
        }
        protected static string SQL_CON = ConfigurationManager.AppSettings["sqlCon"]; 

    }


    public enum SubjectType {
        select,//选择题
        completion//填空题
    }
}
