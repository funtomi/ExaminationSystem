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
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        protected override void WndProc(ref Message msg) {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE)) {
                // 点击winform右上关闭按钮 
                System.Environment.Exit(0);
                return;
            }
            base.WndProc(ref msg);
        }

        #region 事件
        private void BaseForm_Load(object sender, EventArgs e) {
            this.skinEngine1.SkinFile = "MSN.ssk";
           
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (ServiceWindow.Service.State != System.ServiceModel.CommunicationState.Closed) {
                ServiceWindow.Service.Close();
            }
        }
        #endregion
        
    }
}
