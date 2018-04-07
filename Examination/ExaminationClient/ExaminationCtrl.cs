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
        private string _subLevel;
        private int _subNum;
        private int _examTime;
        private int _restTime;
        private ExamSubjectCtrl[] _examSubs;
        public delegate void SubmitEventDelegate(ExamSubjectCtrl[] ctrls, string subType, int examTime);
        public delegate void ResultEventDelegate(ExamSubjectCtrl[] ctrls);
        public SubmitEventDelegate SubmitEvent;
        public ResultEventDelegate ResultEvent;
        private bool _isRedo = false;

        public ExaminationCtrl() {
            InitializeComponent();
        }

        public ExaminationCtrl(string subType, string subLevel, int subNum,int examTime):this(){
            // TODO: Complete member initialization
            this._subType = subType;
            this._subLevel = subLevel;
            this._subNum = subNum;
            _examTime = examTime;
        }

        public ExaminationCtrl(ExamSubjectCtrl[] examSubs):this() {
            _isRedo = true;
            _examSubs = examSubs;
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
            this.lblTime.Text = GetTimeString(_examTime);
            _restTime = _examTime * 60;
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
        }

        /// <summary>
        /// 清除题目
        /// </summary>
        private void ClearSubs() {
            this.panel1.Controls.Clear();
            if (_examSubs != null && _examSubs.Length > 0) {
                for (int i = 0; i < _examSubs.Length; i++) {
                    _examSubs[i].Dispose();
                }
            }
            _examSubs = null;
        }
        /// <summary>
        /// 切换题目
        /// </summary>
        /// <param name="ctrl"></param>
        private void ChangeFormTo(int i) {
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
        }

        /// <summary>
        /// 设置题目
        /// </summary>
        private void SetSubjects() {
            if (_subNum < 0) {
                ClearSubs();
                return;
            }
            if (_isRedo) {
                ChangeFormTo(0);
                return;
            }
            CreateExamSubCtrls();
        }

        /// <summary>
        /// 创建题目
        /// </summary>
        private void CreateExamSubCtrls() {
            if (_subNum < 0) {
                return;
            }
            string errText;
            var list = ServiceWindow.Service.GetSubjects(_subNum, _subLevel, _subType, out errText);
            if (list == null || list.Length == 0) {
                MessageBox.Show("没有找到匹配的题目，请重新选择！");
                ClearSubs();
                return;
            }
            _examSubs = new ExamSubjectCtrl[list.Length];
            for (int i = 0; i < list.Length; i++) {
                _examSubs[i] = new ExamSubjectCtrl(list[i]);
            }
            ChangeFormTo(0);
        }

        #region 事件
        private void ExaminationCtrl_Load(object sender, EventArgs e) {
                SetExamTime();
                SetSubNum();
                SetSubjects();  
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
            var i = Convert.ToInt32(this.cmboxSubSeq.Text);
            if (i <= 1) {
                return;
            }
            ChangeFormTo(i - 1);
        }

        private void btnNext_Click(object sender, EventArgs e) {
            var i = Convert.ToInt32(this.cmboxSubSeq.Text);
            if (i >= _examSubs.Length) {
                return;
            }
            ChangeFormTo(i + 1);
        }

        private void cmboxSubSeq_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.cmboxSubSeq.SelectedIndex < 0) {
                return;
            }
            ChangeFormTo(this.cmboxSubSeq.SelectedIndex + 1);
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
                ResultEvent(_examSubs);
                return;
            }
        }
        #endregion

        

         
    }
}
