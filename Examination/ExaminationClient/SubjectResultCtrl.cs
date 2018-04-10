using ExaminationEntity;
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
    public partial class SubjectResultCtrl : ExaminationClient.BaseCtrl {
        private ExamSubjectCtrl[] _examSubCtrls;
        private WaveOut _wavePlayer;
        private SubjectInfo _currentSub;

        public SubjectResultCtrl() {
            InitializeComponent();
        }

        public SubjectResultCtrl(ExamSubjectCtrl[] examSubCtrls) :this(){
            // TODO: Complete member initialization
            this._examSubCtrls = examSubCtrls;
            
        }

        #region 事件

        private void SubjectResultCtrl_Load(object sender, EventArgs e) {
            if (_examSubCtrls == null || _examSubCtrls.Length == 0) {
                return;
            }
            if (_examSubCtrls == null || _examSubCtrls.Length == 0) {
                this.lblSubNum.Text = "0";
                return;
            }
            this.lblSubNum.Text = _examSubCtrls.Length.ToString();
            for (int i = 1; i < _examSubCtrls.Length + 1; i++) {
                this.cmboxSubSeq.Items.Add(i);
            }
            this.cmboxSubSeq.SelectedIndex = 0;
            SetCurrentSubject(0);
        }

        private void btnPreview_Click(object sender, EventArgs e) {
            var i = this.cmboxSubSeq.SelectedIndex;
            if (i<=0) { 
                return;
            } 
            SetCurrentSubject(--i);
        }

        private void btnNext_Click(object sender, EventArgs e) {
            var i = this.cmboxSubSeq.SelectedIndex;
            if (i>=_examSubCtrls.Length-1) { 
                return;
            } 
            SetCurrentSubject(++i);
        }

        private void btnPlay_Click(object sender, EventArgs e) {
            if (_currentSub==null||_currentSub.SubAudio==null||_currentSub.SubAudio.Length==0) {
                return;
            }
            InitPlayAudio(_currentSub.SubAudio,_currentSub.SubAudioName);
        }

        private void btnStop_Click(object sender, EventArgs e) {
            if (_wavePlayer == null || _wavePlayer.PlaybackState != PlaybackState.Playing) {
                return;
            }
            _wavePlayer.Stop();
        }

        private void cmboxSubSeq_SelectedIndexChanged(object sender, EventArgs e) {
            var i = this.cmboxSubSeq.SelectedIndex;
            SetCurrentSubject(i);
        }
        #endregion

        /// <summary>
        /// 设置当前题目信息
        /// </summary>
        /// <param name="i"></param>
        private void SetCurrentSubject(int i) {
            this.btnNext.Enabled = this.btnPreview.Enabled = false;

            ClearCurrentSubject();
            if (i<0||_examSubCtrls == null || _examSubCtrls.Length == 0 || i >= _examSubCtrls.Length || _examSubCtrls[i] == null) {
                return;
            } 
            var currentSub = _examSubCtrls[i].SubjectInfo;
            if (currentSub==null) {
                return;
            }
            this.lblSubType.Text = currentSub.SubType;
            this.lblAbstract.Text = currentSub.Abstract;
            this.lblResult.Text = currentSub.Result;
            _currentSub = currentSub;
            this.btnNext.Enabled = i < _examSubCtrls.Length - 1;
            this.btnPreview.Enabled = i > 0;
            this.cmboxSubSeq.SelectedIndex = i;
        }

        /// <summary>
        /// 初始化播放插件
        /// </summary>
        /// <param name="fileName"></param>
        private void InitPlayAudio(byte[] file,string subAudioName) {
            if (file == null) {
                return;
            }
            if (_wavePlayer == null) {
                _wavePlayer = new WaveOut();
            }

            var format = Path.GetExtension(subAudioName);
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

        /// <summary>
        /// 清除界面内容
        /// </summary>
        private void ClearCurrentSubject() {
            this.lblSubType.Text = ""; 
            this.lblAbstract.Text = this.lblResult.Text = ""; 
        }

   
    }
}
