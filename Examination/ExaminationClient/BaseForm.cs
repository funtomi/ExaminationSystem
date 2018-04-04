using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationClient {
    public partial class BaseForm : Form {
        public BaseForm() {
            InitializeComponent();
        }

        /// <summary>
        /// 服务
        /// </summary>
        public ServiceReference1.Service1Client Service {
            get { return _service; }
            set { _service = value; }
        }
        private ServiceReference1.Service1Client _service = new ServiceReference1.Service1Client();
         
        private void BaseForm_Load(object sender, EventArgs e) {
            try {
                _service.Open();
                MessageBox.Show(_service.GetUsers().Name);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message); 
            }
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (_service.State != System.ServiceModel.CommunicationState.Closed) {
                _service.Close();
            }
        }
    }
}
