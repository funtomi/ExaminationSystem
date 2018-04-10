using ExaminationEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExaminationClient {
    public partial class ExaminationCtrl : ExaminationClient.BaseCtrl {
        private string _subType; 
        private int _subNum=0;
        private int _examTime=0;
        private int _restTime;
        private ExamSubjectCtrl[] _examSubs;
        public delegate void SubmitEventDelegate(ExamSubjectCtrl[] ctrls, string subType, int examTime);
        public delegate void ResultEventDelegate(ExamSubjectCtrl[] ctrls);
        public SubmitEventDelegate SubmitEvent;
        public ResultEventDelegate ResultEvent;
        private bool _isRedo = false;
        private SubjectInfo[] _subjectInfos;

        public ExaminationCtrl() {
            InitializeComponent();
        }

        public ExaminationCtrl(string subType, SubjectInfo[] subjectInfos,int examTime)
            : this() {
            // TODO: Complete member initialization
            this._subType = subType;
            this._subjectInfos = subjectInfos;
            this._subNum = _subjectInfos == null || _subjectInfos.Length == 0 ? 0 : _subjectInfos.Length;
            _examTime = examTime;
        }

        public ExaminationCtrl(ExamSubjectCtrl[] examSubs):this() {
            _isRedo = true;
            _examSubs = examSubs;
            _subNum = examSubs == null || examSubs.Length == 0 ? 0 : examSubs.Length;
        }

        /// <summary>
        /// 设置试卷状态
        /// </summary>
        private void SetViewEnable() {
            this.btnNext.Enabled = false;
            this.btnPreview.Enabled = false;
            this.cmboxSubSeq.Enabled = false;
            this.panel1.Enabled = false;
        }

        /// <summary>
        /// 设置考试时间
        /// </summary>
        private void SetExamTime() {
            if (_isRedo) {
                this.lblTime.Visible = false;
                this.label4.Visible = false;
                this.label3.Visible = false;
                return;
            }
            _restTime = _examTime * 60;
            this.lblTime.Text = GetTimeString(_restTime);
            this.timer1.Tick += timer1_Tick;
            this.timer1.Start();
        }

        /// <summary>
        /// 获得显示时间
        /// </summary>
        /// <param name="_examTime"></param>
        /// <returns></returns>
        private string GetTimeString(int _examTime) {
            if (_examTime < 0) {
                return "0秒";
            }
            int min = _examTime / 60;
            int sec = _examTime % 60;
            return string.Format("{0}分{1}秒", min, sec);
        }

        /// <summary>
        /// 设置题目页数
        /// </summary>
        private void SetSubNum() {
            if (_isRedo) {
                this.btnSubmit.Visible = false;
                this.btnResult.Visible = true;
                _subNum = _examSubs == null || _examSubs.Length == 0 ? 0 : _examSubs.Length;
            }
            if (_subNum < 0) {
                this.lblSubNum.Text = "/0";
                this.cmboxSubSeq.Items.Clear();
                return;
            }
            this.lblSubNum.Text = "/" + _subNum.ToString();
            for (int i = 1; i < _subNum + 1; i++) {
                this.cmboxSubSeq.Items.Add(i);
            }
            ChangeFormTo(0);
        }

        /// <summary>
        /// 清除题目
        /// </summary>
        private void ClearSubs(ExamSubjectCtrl[] examSubs) {
            this.panel1.Controls.Clear();
            if (examSubs != null && examSubs.Length > 0) {
                for (int i = 0; i < examSubs.Length; i++) {
                    examSubs[i].Dispose();
                }
            }
            examSubs = null;
        }
        /// <summary>
        /// 切换题目
        /// </summary>
        /// <param name="ctrl"></param>
        private void ChangeFormTo(int i) {
            this.btnNext.Enabled = this.btnPreview.Enabled = false;
            if (i < 0 || i >= _examSubs.Length) {
                return;
            }
            var ctrl = _examSubs[i];
            if (ctrl == null) {
                return;
            }
            this.panel1.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(ctrl);
            this.cmboxSubSeq.SelectedIndex = i;
            if (i>0) {
                this.btnPreview.Enabled = true;
            }
            if (i<_subNum-1) {
                this.btnNext.Enabled = true;
            }
        }

        /// <summary>
        /// 设置题目
        /// </summary>
        private void SetSubjects() {
            if (_subNum < 0) {
                ClearSubs(_examSubs);
                _subNum = 0;
                return;
            }
            if (_isRedo) {
                _subjectInfos= CreateSubjectInfo(_examSubs);
            }
            _examSubs = CreateExamSubCtrls(_subNum, _subjectInfos, _examSubs);
            _subNum = _subjectInfos == null ? 0 : _subjectInfos.Length;
        }

        /// <summary>
        /// 创建题目数据
        /// </summary>
        private SubjectInfo[] CreateSubjectInfo(ExamSubjectCtrl[] examSubs) {
            if (examSubs == null || examSubs.Length == 0) {
                ClearSubs(examSubs);
                _subNum = 0;
                return null;
            }
            var subjectInfos = new SubjectInfo[examSubs.Length];
            for (int i = 0; i < examSubs.Length; i++) {
                subjectInfos[i] = examSubs[i].SubjectInfo;
            }
            return subjectInfos;
        }
         

        /// <summary>
        /// 创建题目
        /// </summary>
        private ExamSubjectCtrl[] CreateExamSubCtrls(int subNum, SubjectInfo[] subjectInfo,ExamSubjectCtrl[] examCtrl) {
            if (subNum < 0) { 
                return null;
            }
            if (subjectInfo == null || subjectInfo.Length == 0) {  
                return null;
            }
            var examSubs = new ExamSubjectCtrl[subjectInfo.Length];
            for (int i = 0; i < subjectInfo.Length; i++) {
                examSubs[i] = new ExamSubjectCtrl(subjectInfo[i]);
                if (examCtrl!=null&&examCtrl.Length>i) {
                    examSubs[i].Result = examCtrl[i].Result;
                }
            } 
            return examSubs;
        }

        #region 事件
        private void ExaminationCtrl_Load(object sender, EventArgs e) {
            SetExamTime();
            SetSubjects();
            SetSubNum();
        }

        void timer1_Tick(object sender, EventArgs e) {
            if (_restTime > 0) {
                _restTime--;
                this.lblTime.Text = GetTimeString(_restTime);
                return;
            }
            this.timer1.Stop();
            this.lblTime.Text = GetTimeString(0);
            MessageBox.Show("考试时间到了，请交卷！");
            SetViewEnable();
        }

        private void btnPreview_Click(object sender, EventArgs e) {
            var i = Convert.ToInt32(this.cmboxSubSeq.SelectedIndex);
            if (i <= 0) {
                return;
            }
            ChangeFormTo(--i);
        }

        private void btnNext_Click(object sender, EventArgs e) {
            var i = Convert.ToInt32(this.cmboxSubSeq.SelectedIndex);
            if (i >= _examSubs.Length-1) {
                return;
            }
            ChangeFormTo(++i);
        }

        private void cmboxSubSeq_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.cmboxSubSeq.SelectedIndex < 0) {
                return;
            }
            ChangeFormTo(this.cmboxSubSeq.SelectedIndex);
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            if (_examSubs.Length < 1) {
                MessageBox.Show("当前没有试题！");
                return;
            }
            if (SubmitEvent != null) {
                SubmitEvent(_examSubs,_subType,_examTime);
                return;
            }

        }

        private void btnResult_Click(object sender, EventArgs e) {
            if (_examSubs.Length < 1) {
                MessageBox.Show("当前没有试题！");
                return;
            }
            if (ResultEvent != null) {
                var subs = CreateSubjectInfo(_examSubs);
                var ctrls = CreateExamSubCtrls(_examSubs.Length, subs, _examSubs);
                ResultEvent(ctrls);
                return;
            }
        }
        #endregion
         
         
    }
}
