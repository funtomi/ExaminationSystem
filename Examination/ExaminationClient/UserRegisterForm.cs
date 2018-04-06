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
    public partial class UserRegisterForm : Form {
        public UserRegisterForm() {
            InitializeComponent();
        } 

        /// <summary>
        /// 检查输入
        /// </summary>
        /// <returns></returns>
        private bool InputValidator() {
            if (string.IsNullOrEmpty(this.txtBoxUserName.Text)){
            MessageBox.Show("请输入用户名！");
                return false;
            }
            if(string.IsNullOrEmpty(this.txtBoxPassword1.Text)){
                MessageBox.Show("请输入密码！");
                return false;
            }
            if(string.IsNullOrEmpty(this.txtBoxPassword2.Text)) {
                MessageBox.Show("请再次输入密码！");
                return false;
            }
            if (this.txtBoxPassword1.Text != this.txtBoxPassword2.Text) {
                MessageBox.Show("输入密码不一致，请检查！");
                return false;
            }
            return true;
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
        private void btnRegister_Click(object sender, EventArgs e) {
            if (!InputValidator()) {
                return;
            }
            string errText;
            if (!ServiceWindow.Service.RegisterUser(this.txtBoxUserName.Text, this.txtBoxPassword1.Text,
                out errText)) {
                    MessageBox.Show("注册失败，错误原因："+errText);
                    return;
            }
            MessageBox.Show("注册成功！");
        }

        private void chkBoxPassword1_CheckedChanged(object sender, EventArgs e) {
            if (this.chkBoxPassword1.Checked) {
                this.txtBoxPassword1.PasswordChar = this.txtBoxPassword2.PasswordChar = new char();
                return;
            }
            this.txtBoxPassword1.PasswordChar = this.txtBoxPassword2.PasswordChar = '*';
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            LoginForm form = new LoginForm();
            form.Show();
            this.Dispose(false);
        }

        private void UserRegisterForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (ServiceWindow.Service.State != System.ServiceModel.CommunicationState.Closed) {
                ServiceWindow.Service.Close();
            }
        }

        private void txtBoxUserName_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                if (!InputValidator()) {
                    return;
                }
                string errText;
                if (!ServiceWindow.Service.RegisterUser(this.txtBoxUserName.Text, this.txtBoxPassword1.Text,
                    out errText)) {
                    MessageBox.Show("注册失败，错误原因：" + errText);
                    return;
                }
                MessageBox.Show("注册成功！");
            }
        }
        #endregion
         
    }
}
