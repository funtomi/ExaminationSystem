using ExaminationEntity;
using ExaminationHelper;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms; 

namespace ExaminationServer {
    public partial class SubjectAddCtrl : ExaminationServer.BaseControl {
        public SubjectAddCtrl() {
            InitializeComponent();
        }
        public SubjectAddCtrl(Guid id)
            : this() {
            _isNew = false;
            _id = id;
           
        }


        private string _currentType = "填空题";
        private bool _isNew = true;
        private SubjectInfo _currentSubject = new SubjectInfo();
        private string _fileName;
        WaveOut _wavePlayer = new WaveOut();
        private byte[] _fileStream;
        private Guid _id;
        private bool _isDirty = false;

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
            _currentType = _currentSubject.SubType;

            this.cmboxSubType.SelectedIndex = this.cmboxSubType.Items.Contains(_currentType) ? this.cmboxSubType.Items.IndexOf(_currentType)
                : 0;
            this.cmboxSubLevel.SelectedIndex = this.cmboxSubLevel.Items.Contains(_currentType) ? this.cmboxSubLevel.Items.IndexOf(_currentType)
                : 0;
            ChangeSubTypeView();
            this.txtBoxAbstract.Text = _currentSubject.Abstract;
            switch (_currentType) {
                case "选择题":
                    this.txtBoxResultA.Text = _currentSubject.SelectItem1;
                    this.txtBoxResultB.Text = _currentSubject.SelectItem2;
                    this.txtBoxResultC.Text = _currentSubject.SelectItem3;
                    this.txtBoxResultD.Text = _currentSubject.SelectItem4;
                    this.cmboxResult.SelectedValue = _currentSubject.Result;
                    break;
                default:
                case "填空题":
                    this.txtBoxResult.Text = _currentSubject.Result;
                    break;
            }
            if (!string.IsNullOrEmpty(_currentSubject.SubAudioName)) {
                this.txtBoxFileName.Text = _currentSubject.SubAudioName;
            }
            if (_currentSubject.SubAudio!=null&&_currentSubject.SubAudio.Length>0) {
                _fileStream = _currentSubject.SubAudio;
                this.btnPlay.Enabled = true;
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
                    SqlCommand cmd = new SqlCommand("", con);
                    switch (_currentType) {
                        case "选择题":
                            sql = "insert into Subject (Id,Abstract,SubType,Result,SelectItem1,SelectItem2,SelectItem3,SelectItem4"
                                + ",SubLevel,SubAudio,SubAudioName)"
                                + "values(@Id,@Abstract,@SubType,@Result,@SelectItem1,@SelectItem2,@SelectItem3,@SelectItem4"
                                +",@SubLevel,@SubAudio,@SubAudioName)";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("Result", this.cmboxResult.Text);
                            cmd.Parameters.AddWithValue("SelectItem1", this.txtBoxResultA.Text);
                            cmd.Parameters.AddWithValue("SelectItem2", this.txtBoxResultB.Text);
                            cmd.Parameters.AddWithValue("SelectItem3", this.txtBoxResultC.Text);
                            cmd.Parameters.AddWithValue("SelectItem4", this.txtBoxResultD.Text);
                            break;
                        case "填空题":
                            sql = "insert into Subject (Id,Abstract,SubType,Result,SubLevel,SubAudio,SubAudioName)"
                                + "values(@Id,@Abstract,@SubType,@Result,@SubLevel,@SubAudio,@SubAudioName)";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("Result", this.txtBoxResult.Text);
                            break;
                    }
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.Parameters.AddWithValue("Abstract", this.txtBoxAbstract.Text);
                    cmd.Parameters.AddWithValue("SubType", _currentType);
                    cmd.Parameters.AddWithValue("@SubLevel", this.cmboxSubLevel.Text);
                    cmd.Parameters.AddWithValue("@SubAudio", _fileStream);
                    cmd.Parameters.AddWithValue("@SubAudioName", this.txtBoxFileName.Text);
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
            if (this.panelSelect.Visible && !SelectContentValidator()) {
                return false;
            }
            if (this.panelCompletion.Visible && !CompletionValidator()) {
                return false;
            }
            if (string.IsNullOrEmpty(_fileName)||_fileStream==null) {
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
                MessageBox.Show("请填写答案！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 选择内容检验
        /// </summary>
        /// <returns></returns>
        private bool SelectContentValidator() {
            if (string.IsNullOrEmpty(this.txtBoxResultA.Text) || string.IsNullOrEmpty(this.txtBoxResultB.Text) ||
                string.IsNullOrEmpty(this.txtBoxResultC.Text) || string.IsNullOrEmpty(this.txtBoxResultD.Text)) {
                MessageBox.Show("请填写选项内容！");
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
                case "选择题":
                    _currentType = text;
                    ClearViews();
                    this.panelSelect.Visible = true;
                    this.panelCompletion.Visible = false;
                    break;
                default:
                case "填空题":
                    _currentType = text;
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
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("", conn);
                    string sql;
                    switch (_currentType) {
                        case "选择题":
                            sql = "update Subject set Abstract=@Abstract,SubType=@SubType,Result=@Result,SelectItem1=@SelectItem1,"
                                + "SelectItem2=@SelectItem2,SelectItem3=@SelectItem3,SelectItem4=@SelectItem4,SubLevel=@SubLevel"
                                + ",SubAudio=@SubAudio,SubAudioName=@SubAudioName where Id = @Id";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@SelectItem1", this.txtBoxResultA.Text);
                            cmd.Parameters.AddWithValue("@SelectItem2", this.txtBoxResultD.Text);
                            cmd.Parameters.AddWithValue("@SelectItem3", this.txtBoxResultC.Text);
                            cmd.Parameters.AddWithValue("@SelectItem4", this.txtBoxResultB.Text);
                            cmd.Parameters.AddWithValue("@Result", this.cmboxResult.Text);
                            break;
                        default:
                        case "填空题":
                            sql = "update Subject set Abstract=@Abstract,SubType=@SubType,Result=@Result where Id = @Id";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@Result", this.txtBoxResult.Text);
                            break;
                    }
                    cmd.Parameters.AddWithValue("@Abstract", this.txtBoxAbstract.Text);
                    cmd.Parameters.AddWithValue("@SubType", _currentType);
                    cmd.Parameters.AddWithValue("@Id", _currentSubject.Id);
                    cmd.Parameters.AddWithValue("@SubLevel", this.cmboxSubLevel.Text);
                    cmd.Parameters.AddWithValue("@SubAudio", _fileStream);
                    cmd.Parameters.AddWithValue("@SubAudioName", this.txtBoxFileName.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("保存失败，错误原因：" + ex.Message);
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

                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    string sql = "delete Subject where Id = @Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }

            } catch (Exception ex) {
                MessageBox.Show("删除失败，错误原因：" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 设置题目类型
        /// </summary>
        private void SetSubjectTypes() {
            this.cmboxSubType.Items.Clear();
            List<string> types = GetSubTypes();
            if (types == null || types.Count == 0) {
                MessageBox.Show("没有找到题目类型！");
                return;
            }
            this.cmboxSubType.Items.AddRange(types.ToArray());
            this.cmboxSubType.SelectedIndex = 0;
        }

        /// <summary>
        /// 获取题目类型
        /// </summary>
        private void SetSubLevels() {
            this.cmboxSubLevel.Items.Clear();
            List<string> levels = GetSubLevels();
            if (levels == null || levels.Count == 0) {
                MessageBox.Show("没有找到题目等级！");
                return;
            }
            this.cmboxSubLevel.Items.AddRange(levels.ToArray());
            this.cmboxSubLevel.SelectedIndex = 0;
        }

        /// <summary>
        /// 加载文件
        /// </summary>
        private byte[] UploadFile() {
            using (OpenFileDialog dialog = new OpenFileDialog()) {
                dialog.Filter = "音频文件|*.wav;*.mp3";//文件扩展名
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;
                dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                dialog.ShowDialog();

                if (!string.IsNullOrEmpty(dialog.FileName)) {
                    this.btnPlay.Enabled = false;
                    try {
                        byte[] byteArray = FileBinaryConvertHelper.File2Bytes(dialog.FileName);//文件转成byte二进制数组
                        _fileName = dialog.FileName;
                        this.txtBoxFileName.Text = dialog.SafeFileName;
                        _isDirty = true;
                        return byteArray;
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                        return null;
                    }
                }
                this.txtBoxFileName.Text = "";
            }
            return null;
        }

        /// <summary>
        /// 初始化播放插件
        /// </summary>
        /// <param name="fileName"></param>
        private void InitPlayAudio(string fileName) {
            if (_wavePlayer == null) {
                _wavePlayer = new WaveOut();
            }
            var audioFileReader = new AudioFileReader(fileName);
            audioFileReader.Volume = 1f;
            _wavePlayer.Init(audioFileReader); 
            this.btnPlay.Enabled = true;
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
            var format = Path.GetExtension(this.txtBoxFileName.Text);
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
            this.btnPlay.Enabled = true;
        }

        #region 事件
        private void SubjectAddCtrl_Load(object sender, EventArgs e) {
            SetSubjectTypes();
            SetSubLevels();
            if (_isNew) {
                this.cmboxResult.SelectedIndex = 0;
                return;
            }
            SetContent(_id);
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

        private void btnOpenFile_Click(object sender, EventArgs e) { 
            _fileStream = UploadFile();
            if (_fileStream == null || _fileStream.Length == 0) {
                return;
            }
            this.btnPlay.Enabled = true; 
        }
         
        private void btnPlay_Click(object sender, EventArgs e) {
            try {
                
                if (_isNew||_isDirty) {
                    if (string.IsNullOrEmpty(_fileName)) {
                        MessageBox.Show("没有上传音频文件！");
                        return;
                    }
                    InitPlayAudio(_fileName);
                } else { 
                    if (string.IsNullOrEmpty(this.txtBoxFileName.Text)||this._fileStream == null||this._fileStream.Length==0) {
                        MessageBox.Show("音频文件为空！");
                        return;
                    }
                    InitPlayAudio(_fileStream);
                }
                _wavePlayer.Play();
                this.btnStop.Enabled = true;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e) {
            if (_wavePlayer.PlaybackState == PlaybackState.Playing) {
                _wavePlayer.Stop();
            }
        }
        #endregion
         
    }
}
