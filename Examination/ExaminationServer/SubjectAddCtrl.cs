using ExaminationEntity;
using ExaminationHelper;
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
        public SubjectAddCtrl(Guid id):this() {
            _isNew = false;
            SetContent(id);
        }

        
        private SubjectType _currentType = SubjectType.select;
        private bool _isNew = true;
        private SubjectInfo _currentSubject = new SubjectInfo();

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="id"></param>
        private void SetContent(Guid id) {
            if (id == null) {
                return;
            }
            _currentSubject = GetSubject(id);
            if (_currentSubject == null) {
                return;
            }
           this.cmboxSubType.SelectedIndex = _currentSubject.SubType;
            _currentType = (SubjectType)_currentSubject.SubType;
            this.cmboxSubType.SelectedIndex = (int)_currentType;
            ChangeSubTypeView();
            this.txtBoxAbstract.Text = _currentSubject.Abstract;
            switch (_currentType) {
                case SubjectType.select:
                    this.txtBoxResultA.Text = _currentSubject.SelectItem1;
                    this.txtBoxResultB.Text = _currentSubject.SelectItem2;
                    this.txtBoxResultC.Text = _currentSubject.SelectItem3;
                    this.txtBoxResultD.Text = _currentSubject.SelectItem4;
                    this.cmboxResult.SelectedValue = _currentSubject.Result;
                    break;
                case SubjectType.completion:
                    this.txtBoxResult.Text = _currentSubject.Result;
                    break; 
            }
            this.btnDelete.Visible = true;
        }

        /// <summary>
        /// 获取某一项题目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SubjectInfo GetSubject(Guid id) {
            if (id == null) {
                return null;
            }
            try {
                using (SqlConnection con = new SqlConnection(SQL_CON)) {
                    string sql = "select * from Subject where Id = @Id";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("Id", id);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    var list = DataTableHelper.DataTableToList<SubjectInfo>(dt);
                    if (list == null || list.Count == 0) {
                        return null;
                    }
                    return list[0];
                }
            } catch (Exception ex) {
                MessageBox.Show("没有找到匹配项，错误原因为：" + ex.Message);
                return null;
            }
        }

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
        
        /// <summary>
        /// 保存修改的题目
        /// </summary>
        /// <returns></returns>
        private bool ModifySubject() {
            var id = _currentSubject.Id;
            if (id == null) {
                return false;
            }
            try {
                using (SqlConnection conn = new SqlConnection (SQL_CON)) {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("", conn);
                    string sql;
                    switch (_currentType) {
                        case SubjectType.select:
                            sql = "update Subject set Abstract=@Abstract,SubType=@SubType,Result=@Result,SelectItem1=@SelectItem1,"
                                + "SelectItem2=@SelectItem2,SelectItem3=@SelectItem3,SelectItem4=@SelectItem4 where Id = @Id";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@SelectItem1", this.txtBoxResultA.Text);
                            cmd.Parameters.AddWithValue("@SelectItem2", this.txtBoxResultD.Text);
                            cmd.Parameters.AddWithValue("@SelectItem3", this.txtBoxResultC.Text);
                            cmd.Parameters.AddWithValue("@SelectItem4", this.txtBoxResultB.Text);
                            cmd.Parameters.AddWithValue("@Result", this.cmboxResult.Text);
                            break;
                        case SubjectType.completion:
                            sql = "update Subject set Abstract=@Abstract,SubType=@SubType,Result=@Result where Id = @Id";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@Result", this.txtBoxResult.Text);
                            break; 
                    }
                    cmd.Parameters.AddWithValue("@Abstract",this.txtBoxAbstract.Text);
                    cmd.Parameters.AddWithValue("@SubType",(int)_currentType);
                    cmd.Parameters.AddWithValue("@Id",_currentSubject.Id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("保存失败，错误原因："+ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除题目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DeleteSubject(Guid id) {
            if (id == null) {
                MessageBox.Show("没有找到匹配项！");
                return false;
            }
            try {

            using (SqlConnection conn = new SqlConnection (SQL_CON)) {
                conn.Open();
                string sql = "delete Subject where Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }

            } catch (Exception ex) {
                MessageBox.Show("删除失败，错误原因："+ex.Message);
                return false;
            }
        }

        #region 事件
        private void SubjectAddCtrl_Load(object sender, EventArgs e) {
            if (_isNew) {
                this.cmboxSubType.SelectedIndex = 0;
                this.cmboxResult.SelectedIndex = 0;
            }
        }

        private void cmboxSubType_SelectedIndexChanged(object sender, EventArgs e) {
            ChangeSubTypeView();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!ContentValidator()) {
                return;
            }
            if (_isNew) {
                if (SaveSubject()) {
                    MessageBox.Show("保存成功！");
                    ClearPage();
                    return;
                }
            }
            if (ModifySubject()) {
                MessageBox.Show("保存成功！");
                ClearPage();
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (this._currentSubject.Id == null) {
                return;
            }
            if (DeleteSubject(_currentSubject.Id)) {
                MessageBox.Show("删除成功！");
                ClearPage();
                return;
            }
        }
         
        #endregion

       
        
    }
}
