using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationServer {
    public partial class SubjectAddCtrl : ExaminationServer.BaseControl {
        public SubjectAddCtrl() {
            InitializeComponent();
        }
        private SubjectType _currentType = SubjectType.select;
        #region 事件
        private void SubjectAddCtrl_Load(object sender, EventArgs e) {
            this.cmboxSubType.SelectedIndex = 0;
            this.cmboxResult.SelectedIndex = 0;
        }

        private void cmboxSubType_SelectedIndexChanged(object sender, EventArgs e) {
            ChangeSubTypeView();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!ContentValidator()) {
                return;
            }
            if (SaveSubject()) {
                MessageBox.Show("保存成功！");
                ClearPage();
                return;
            }
        }

        #endregion
        /// <summary>
        /// 清除页面内容
        /// </summary>
        private void ClearPage() {
            this.txtBoxAbstract.Text = "";
            ClearViews();
        }

        /// <summary>
        /// 保存题目
        /// </summary>
        /// <returns></returns>
        private bool SaveSubject() {
            try {
                using (SqlConnection con = new SqlConnection(SQL_CON)) {
                    string sql;
                    var id = Guid.NewGuid();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("",con);
                    switch (_currentType) {
                        case SubjectType.select:
                            sql = "insert into Subject (Id,Abstract,SubType,Result,SelectItem1,SelectItem2,SelectItem3,SelectItem4)"
                                + "values(@Id,@Abstract,@SubType,@Result,@SelectItem1,@SelectItem2,@SelectItem3,@SelectItem4)";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("Result", this.cmboxResult.Text);
                            cmd.Parameters.AddWithValue("SelectItem1", this.txtBoxResultA.Text);
                            cmd.Parameters.AddWithValue("SelectItem2", this.txtBoxResultB.Text);
                            cmd.Parameters.AddWithValue("SelectItem3", this.txtBoxResultC.Text);
                            cmd.Parameters.AddWithValue("SelectItem4", this.txtBoxResultD.Text);

                            break;
                        case SubjectType.completion:
                            sql = "insert into Subject (Id,Abstract,SubType,Result)"
                                + "values(@Id,@Abstract,@SubType,@Result)";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("Result", this.txtBoxResult.Text);
                            break;
                    }
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.Parameters.AddWithValue("Abstract", this.txtBoxAbstract.Text);
                    cmd.Parameters.AddWithValue("SubType", (int)_currentType);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("保存失败，错误原因：" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 内容校验
        /// </summary>
        /// <returns></returns>
        private bool ContentValidator() {
            if (!AbstractValidator()) {
                return false;
            }
            if (_currentType == SubjectType.select && !SelectContentValidator()) {
                return false;
            }
            if (_currentType == SubjectType.completion&&!CompletionValidator()) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 填空校验
        /// </summary>
        /// <returns></returns>
        private bool CompletionValidator() {
            if (string.IsNullOrEmpty(this.txtBoxResult.Text)) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 选择内容检验
        /// </summary>
        /// <returns></returns>
        private bool SelectContentValidator() {
            if (string.IsNullOrEmpty(this.txtBoxResultA.Text)||string.IsNullOrEmpty(this.txtBoxResultB.Text)||
                string.IsNullOrEmpty(this.txtBoxResultC.Text)||string.IsNullOrEmpty(this.txtBoxResultD.Text)) {
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 题目内容检验
        /// </summary>
        /// <returns></returns>
        private bool AbstractValidator() {
            var text = this.txtBoxAbstract.Text;
            if (string.IsNullOrEmpty(text)) {
                MessageBox.Show("请填写题目内容!");
                return false;
            }
            return true;
        }
       
        /// <summary>
        /// 改变题目类型
        /// </summary>
        private void ChangeSubTypeView() {
            var text = this.cmboxSubType.Text;
            if (string.IsNullOrEmpty(text)) {
                return;
            }

            switch (text) {
                default:
                case "选择题":
                    if (_currentType == SubjectType.select) {
                        return;
                    }
                    _currentType = SubjectType.select;
                    ClearViews();
                    this.panelSelect.Visible = true;
                    this.panelCompletion.Visible = false;
                    break;
                case "填空题":
                    if (_currentType == SubjectType.completion) {
                        return;
                    }
                    _currentType = SubjectType.completion;
                    ClearViews();
                    this.panelSelect.Visible = false;
                    this.panelCompletion.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// 清除内容
        /// </summary>
        private void ClearViews() {
            this.txtBoxResultA.Text = this.txtBoxResultB.Text = this.txtBoxResultC.Text = this.txtBoxResultD.Text = "";
            this.txtBoxResult.Text = "";
            this.cmboxResult.SelectedIndex = 0;
        }
        
    }
}
