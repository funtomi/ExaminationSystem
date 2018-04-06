using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationClient {
    public partial class ExaminationCtrl : ExaminationClient.BaseCtrl {
        private string _subType;
        private string _subLevel;
        private int _subNum;

        public ExaminationCtrl() {
            InitializeComponent();
        }

        public ExaminationCtrl(string subType, string subLevel, int subNum) {
            // TODO: Complete member initialization
            this._subType = subType;
            this._subLevel = subLevel;
            this._subNum = subNum;
        }
    }
}
