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
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲  
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

        /// <summary>
        /// 更换视图
        /// </summary>
        /// <param name="ctrl"></param>
        private void ChangeFormTo(UserControl ctrl) {
            foreach (Control item in this.panelChild.Controls) {
                item.Dispose();
            }
            this.panelChild.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            this.panelChild.Controls.Add(ctrl);
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

        private void menuItemStartExam_Click(object sender, EventArgs e) {
            ExaminationSelectCtrl ctrl = new ExaminationSelectCtrl();
            ctrl.StartExamEventHandel += new ExaminationSelectCtrl.StartExamEventDelegate(ExaminationSelectCtrl_StartExamEvent);
            ChangeFormTo(ctrl);
        }

        private void ExaminationSelectCtrl_StartExamEvent(string subType, string subLevel, int subNum,int examTime) {
            if (string.IsNullOrEmpty(subType)||string.IsNullOrEmpty(subLevel)) {
                MessageBox.Show("题目选择不能为空！");
                return;
            }
            ExaminationCtrl ctrl = new ExaminationCtrl(subType, subLevel, subNum, examTime);
            ctrl.SubmitEvent += new ExaminationCtrl.SubmitEventDelegate(ExaminationCtrl_SubmitEvent);
            ChangeFormTo(ctrl);
        }

        private void ExaminationCtrl_SubmitEvent(ExamSubjectCtrl[] ctrls,string subType,int examTime) {
            ExamResultCtrl ctrl = new ExamResultCtrl(ctrls,subType,examTime);
            ChangeFormTo(ctrl);
        }
        #endregion

        
    }
}
