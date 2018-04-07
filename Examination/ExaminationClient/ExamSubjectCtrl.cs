using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ExaminationClient {
    public partial class ExamSubjectCtrl : ExaminationClient.BaseCtrl {
        private ExaminationEntity.SubjectInfo _subjectInfo;

        public ExaminationEntity.SubjectInfo SubjectInfo {
            get { return _subjectInfo; }
            set { _subjectInfo = value; }
        }
        WaveOut _wavePlayer;
        public string Result {
            get {
                if (_subjectInfo==null||string.IsNullOrEmpty(_subjectInfo.SubType)) {
                    return "";
                }
                switch (_subjectInfo.SubType) {
                    case "选择题":
                        return _result;
                    case "填空题":
                        return this.txtboxResult.Text;
                }
                return "";
            }
        }
        private string _result;
        public ExamSubjectCtrl() {
            InitializeComponent();
        }

        public ExamSubjectCtrl(ExaminationEntity.SubjectInfo subjectInfo):this() {
            // TODO: Complete member initialization
            this._subjectInfo = subjectInfo;
        }
        /// <summary>
        /// 设置标题
        /// </summary>
        private void SetAnswerPanel() {
            if (_subjectInfo == null || string.IsNullOrEmpty(_subjectInfo.SubType)) {
                this.lblTitle.Text = "";
                return;
            }
            this.lblTitle.Text = _subjectInfo.SubType;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        private void SetAbstract() {
            if (_subjectInfo==null||string.IsNullOrEmpty(_subjectInfo.Abstract)) {
                this.lblAbstract.Text = "";
                return;
            }
            this.lblAbstract.Text = _subjectInfo.Abstract;
        }

        /// <summary>
        /// 设置选项
        /// </summary>
        private void SetLabel() {
            if (_subjectInfo==null||string.IsNullOrEmpty(_subjectInfo.SubType)) {
                this.panelSelect.Visible = this.panelCompletion.Enabled = false;
                return;
            }
            switch (_subjectInfo.SubType) {
                case "选择题":
                    this.panelSelect.Visible = true;
                    this.panelCompletion.Visible = false;
                    this.rdBtnA.Text = "A."+_subjectInfo.SelectItem1;
                    this.rdBtnB.Text = "B."+_subjectInfo.SelectItem2;
                    this.rdBtnC.Text = "C."+_subjectInfo.SelectItem3;
                    this.rdBtnD.Text = "D."+_subjectInfo.SelectItem4;
                    break;
                case "填空题":
                    this.panelCompletion.Visible = true;
                    this.panelSelect.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// 初始化播放插件
        /// </summary>
        /// <param name="fileName"></param>
        private void InitPlayAudio(byte[] file) {
            if (file == null) {
                return;
            }
            if (_wavePlayer == null) {
                _wavePlayer = new WaveOut();
            }
            
            var format = Path.GetExtension(_subjectInfo.SubAudioName);
            if (string.IsNullOrEmpty(format)) {
                MessageBox.Show("没有听力文件!");
                return;
            }
            switch (format) {
                default:
                case "mp3":
                    WaveStream wavStream = new WaveFileReader(new MemoryStream(file));
                    _wavePlayer.Init(wavStream);
                    break;
                case "wav":
                    WaveStream stream = new Mp3FileReader(new MemoryStream(file));
                    _wavePlayer.Init(stream);
                    break;
            }
            _wavePlayer.Play();
        }

        #region 事件
        private void ExamSubjectCtrl_Load(object sender, EventArgs e) {
            if (_subjectInfo == null) {
                return;
            }
            SetLabel();
            SetAbstract();
            SetAnswerPanel();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            if (_subjectInfo == null || _subjectInfo.SubAudio == null || _subjectInfo.SubAudio.Length == 0) {
                return;
            }
            InitPlayAudio(_subjectInfo.SubAudio);
        }

        private void btnStop_Click(object sender, EventArgs e) {
            if (_wavePlayer == null || _wavePlayer.PlaybackState != PlaybackState.Playing) {
                return;
            }
            _wavePlayer.Stop();
        }

        private void rdBtnA_CheckedChanged(object sender, EventArgs e) {
            var ctrl = sender as RadioButton;
            if (ctrl == null) {
                return;
            }
            var text = ctrl.Text;
            if (string.IsNullOrEmpty(text)) {
                _result = "";
                return;
            }
            _result = text.Substring(0, 1);
        }
        #endregion
         
        
    }
}
