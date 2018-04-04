using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationServer {
    public partial class BaseForm : Form {
        public BaseForm() {
            InitializeComponent();
        }
         
        private ServiceContainer _service = new ServiceContainer();

        private void BaseForm_Load(object sender, EventArgs e) {
            skinEngine1.SkinFile = "MSN.ssk";
            try {
            _service.StartService();
            toolStripStatusLabel1.Text = "服务已开启。";
            } catch (Exception ex) {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e) { 
            _service.CloseService();
        }

        private void menuItemQuerySubject_Click(object sender, EventArgs e) {
            this.panelChild.Controls.Clear();
            SubjectQueryCtrl ctrl = new SubjectQueryCtrl ();
            ctrl.Service = _service;
            ctrl.Dock = DockStyle.Fill;
            this.panelChild.Controls.Add(ctrl);
        }
         
    }
}
