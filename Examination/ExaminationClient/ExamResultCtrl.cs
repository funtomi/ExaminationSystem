using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationClient {
    public partial class ExamResultCtrl : ExaminationClient.BaseCtrl {
        private ExamSubjectCtrl[] _ctrls;
        private string _subType;
        private int _examTime;
        private List<ExamSubjectCtrl> _errCtrls;
        public delegate void SubjectRedoEventDelegate(ExamSubjectCtrl[] examSubCtrls);
        public SubjectRedoEventDelegate SubjectRedoEvent;
        public delegate void SubjectResultEventDelegate(ExamSubjectCtrl[] examSubCtrls);
        public SubjectResultEventDelegate SubjectResultEvent;
        public ExamResultCtrl() {
            InitializeComponent();
        }

        public ExamResultCtrl(ExamSubjectCtrl[] ctrls,string subType,int examTime):this() {
            this._ctrls = ctrls;
            _subType = subType;
            _examTime = examTime;
        }

        public ExamResultCtrl(ExamSubjectCtrl[] ctrls) {
            this._ctrls = ctrls;
            _subType = "错题重做";
            this.label4.Visible = false;
            this.lblExamTime.Visible = false;
        }

        /// <summary>
        /// 设置考试信息
        /// </summary>
        private void SetScore(int score) {
            this.lblScore.Text = "";
            this.lblScoreColor.Width = 0;
            if (_ctrls == null || _ctrls.Length == 0) {
                return;
            }
            this.lblScore.Text = score.ToString();
            this.lblScore.Width = (score / 100) * this.lblSumScore.Width;
        }

        /// <summary>
        /// 设置成绩结果信息
        /// </summary>
        private void SetSubInfo() {
            this.lblExamTime.Text = this.lblSubNum.Text = this.lblExamTime.Text = "";
            if (string.IsNullOrEmpty(_subType)) {
                return;
            }
            this.lblSubType.Text = _subType;
            if (_ctrls == null || _ctrls.Length == 0) {
                return;
            }
            this.lblSubNum.Text = _ctrls.Length.ToString();
            this.lblExamTime.Text = _examTime.ToString();
            return;
        }

        /// <summary>
        /// 计算分数
        /// </summary>
        /// <returns></returns>
        private int CaculateScore() {
            if (_ctrls == null || _ctrls.Length == 0) {
                return 0;
            }
            int rightNum = 0;
            _errCtrls = new List<ExamSubjectCtrl>();
            for (int i = 0; i < _ctrls.Length; i++) {
                var ctrl = _ctrls[i];
                if (ctrl.Result == ctrl.SubjectInfo.Result) {
                    rightNum++;
                    continue;
                }
                _errCtrls.Add(ctrl);
            }
            return rightNum / _ctrls.Length;
        }
        #region 事件
        private void ExamResultCtrl_Load(object sender, EventArgs e) {
            SetSubInfo();
            var score = CaculateScore();
            SetScore(score);
            if (_subType=="错题重做") {
                return;
            }
            string errText;
            if (!ServiceWindow.Service.SaveScore(ServiceWindow.UserId, ServiceWindow.UserName, score, _ctrls.Length, _ctrls[0].SubjectInfo.SubLevel, out errText)) {
                MessageBox.Show("成绩保存失败！错误原因："+errText);
                return;
            }
        }

        private void btnRedo_Click(object sender, EventArgs e) {
            if (_errCtrls == null || _errCtrls.Count == 0) {
                MessageBox.Show("没有错题！");
                return;
            }
            if (SubjectRedoEvent != null) {
                SubjectRedoEvent(_errCtrls.ToArray());
            }
        }

        private void btnResult_Click(object sender, EventArgs e) {
            if (_ctrls == null || _ctrls.Length == 0) {
                MessageBox.Show("没有测试的题目！");
                return;
            }
            if (SubjectResultEvent != null) {
                SubjectResultEvent(_ctrls);
            }
        }
        #endregion
         
    }
}
