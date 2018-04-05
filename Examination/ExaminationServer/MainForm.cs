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
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲  
        }
         
        private ServiceContainer _service = new ServiceContainer();

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

        /// <summary>
        /// 选择某个题目
        /// </summary>
        private void SelectSubjectEventHandle() {
            if (this.panelChild.Controls == null||this.panelChild.Controls.Count == 0) {
                return;
            }
            var currentCtrl = this.panelChild.Controls[0] as SubjectQueryCtrl;
            if (currentCtrl == null) {
                return;
            } 
            if (string.IsNullOrEmpty(currentCtrl.CurrentId)) {
                return;
            }
            var id = Guid.Parse(currentCtrl.CurrentId);
            if (id == null) {
                return;
            }
            SubjectAddCtrl ctrl = new SubjectAddCtrl(id);
            ChangeFormTo(ctrl);
        }

        #region 事件
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
            SubjectQueryCtrl ctrl = new SubjectQueryCtrl();
            ctrl.SelectSubjectEvent += new SubjectQueryCtrl.SelectSubjectEventDelegate(SelectSubjectEventHandle);
            ChangeFormTo(ctrl);
        }

        private void menuItemAddSubject_Click(object sender, EventArgs e) {
            SubjectAddCtrl ctrl = new SubjectAddCtrl(); 
            ChangeFormTo(ctrl);
        }

        private void menuItemSubjectType_Click(object sender, EventArgs e) {
            BasicInfoManager ctrl = new BasicInfoManager(BasicType.SubType);
            ChangeFormTo(ctrl);
        }

        private void menuItemSubjectLevel_Click(object sender, EventArgs e) {
            BasicInfoManager ctrl = new BasicInfoManager(BasicType.SubLevel);
            ChangeFormTo(ctrl);
        }

        private void menuItemUserRegister_Click(object sender, EventArgs e) {
            UserManagerCtrl ctrl = new UserManagerCtrl();
            ChangeFormTo(ctrl);
        }

        private void menuItemUserScoreInput_Click(object sender, EventArgs e) {
            UserRecordCtrl ctrl = new UserRecordCtrl();
            ChangeFormTo(ctrl);
        }
        #endregion

       
         
    }
}
