using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExaminationClient {
    public partial class StudyCruveCtrl : ExaminationClient.BaseCtrl {
        public StudyCruveCtrl() {
            InitializeComponent();
        }

        /// <summary>
        /// 创建曲线
        /// </summary>
        private Series CreateSeries() {
            Series series = new Series("学习进步曲线", 100);
            series.ChartArea = "ChartArea1";
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.Font = new System.Drawing.Font("微软雅黑", 7.865546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series.Legend = "Legend1";
            series.LegendText = "得分";
            series.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            return series;
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            ClearView();
            if (DateValidator()) {
                var series = CreateSeries();
                string errText = "";
                var startDate = DateTime.Parse(this.dtPickerStart.Text);
                var endDate = DateTime.Parse(this.dtPickerEnd.Text);
                var data = ServiceWindow.Service.GetStudyData(ServiceWindow.UserId, ServiceWindow.UserName,startDate,endDate, out errText);
                if (data==null||data.Rows.Count==0) {
                    MessageBox.Show("没有查到数据，可能错误:"+errText);
                    return;
                }
                this.chart1.DataSource = data;
                series.XValueMember = "TestTime";
                series.YValueMembers = "Record";
                this.chart1.Series.Add(series);
            }
        }

        /// <summary>
        /// 日期校验
        /// </summary>
        /// <returns></returns>
        private bool DateValidator() {
            if (string.IsNullOrEmpty(this.dtPickerStart.Text) || string.IsNullOrEmpty(this.dtPickerEnd.Text)) {
                return false;
            }
            var startDate = DateTime.Parse(this.dtPickerStart.Text);
            var endDate = DateTime.Parse(this.dtPickerEnd.Text);
            if (startDate > endDate) {
                MessageBox.Show("开始时间不能早于结束时间！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 清空图表
        /// </summary>
        private void ClearView() {
            this.chart1.Series.Clear();
        }
    }
}
