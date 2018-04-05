namespace ExaminationServer {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.题库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAddSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuerySubject = new System.Windows.Forms.ToolStripMenuItem();
            this.基础信息维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSubjectType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSubjectLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUserRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUserScoreInput = new System.Windows.Forms.ToolStripMenuItem();
            this.panelChild = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1367, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(96, 20);
            this.toolStripStatusLabel1.Text = "正在初始化...";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.题库ToolStripMenuItem,
            this.基础信息维护ToolStripMenuItem,
            this.用户管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1367, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 题库ToolStripMenuItem
            // 
            this.题库ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAddSubject,
            this.menuItemQuerySubject});
            this.题库ToolStripMenuItem.Name = "题库ToolStripMenuItem";
            this.题库ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.题库ToolStripMenuItem.Text = "题库录入";
            // 
            // menuItemAddSubject
            // 
            this.menuItemAddSubject.Name = "menuItemAddSubject";
            this.menuItemAddSubject.Size = new System.Drawing.Size(114, 26);
            this.menuItemAddSubject.Text = "新增";
            this.menuItemAddSubject.Click += new System.EventHandler(this.menuItemAddSubject_Click);
            // 
            // menuItemQuerySubject
            // 
            this.menuItemQuerySubject.Name = "menuItemQuerySubject";
            this.menuItemQuerySubject.Size = new System.Drawing.Size(114, 26);
            this.menuItemQuerySubject.Text = "查询";
            this.menuItemQuerySubject.Click += new System.EventHandler(this.menuItemQuerySubject_Click);
            // 
            // 基础信息维护ToolStripMenuItem
            // 
            this.基础信息维护ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSubjectType,
            this.menuItemSubjectLevel});
            this.基础信息维护ToolStripMenuItem.Name = "基础信息维护ToolStripMenuItem";
            this.基础信息维护ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.基础信息维护ToolStripMenuItem.Text = "基础信息维护";
            // 
            // menuItemSubjectType
            // 
            this.menuItemSubjectType.Name = "menuItemSubjectType";
            this.menuItemSubjectType.Size = new System.Drawing.Size(144, 26);
            this.menuItemSubjectType.Text = "题目类型";
            this.menuItemSubjectType.Click += new System.EventHandler(this.menuItemSubjectType_Click);
            // 
            // menuItemSubjectLevel
            // 
            this.menuItemSubjectLevel.Name = "menuItemSubjectLevel";
            this.menuItemSubjectLevel.Size = new System.Drawing.Size(144, 26);
            this.menuItemSubjectLevel.Text = "题目等级";
            this.menuItemSubjectLevel.Click += new System.EventHandler(this.menuItemSubjectLevel_Click);
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUserRegister,
            this.menuItemUserScoreInput});
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            // 
            // menuItemUserRegister
            // 
            this.menuItemUserRegister.Name = "menuItemUserRegister";
            this.menuItemUserRegister.Size = new System.Drawing.Size(180, 26);
            this.menuItemUserRegister.Text = "用户注册";
            this.menuItemUserRegister.Click += new System.EventHandler(this.menuItemUserRegister_Click);
            // 
            // menuItemUserScoreInput
            // 
            this.menuItemUserScoreInput.Name = "menuItemUserScoreInput";
            this.menuItemUserScoreInput.Size = new System.Drawing.Size(180, 26);
            this.menuItemUserScoreInput.Text = "用户成绩记录";
            this.menuItemUserScoreInput.Click += new System.EventHandler(this.menuItemUserScoreInput_Click);
            // 
            // panelChild
            // 
            this.panelChild.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChild.AutoScroll = true;
            this.panelChild.Location = new System.Drawing.Point(12, 40);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(1343, 596);
            this.panelChild.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 675);
            this.Controls.Add(this.panelChild);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "考试管理系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseForm_FormClosed);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 题库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemAddSubject;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuerySubject;
        private System.Windows.Forms.ToolStripMenuItem 基础信息维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemSubjectType;
        private System.Windows.Forms.ToolStripMenuItem menuItemSubjectLevel;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemUserRegister;
        private System.Windows.Forms.ToolStripMenuItem menuItemUserScoreInput;
        private System.Windows.Forms.Panel panelChild;
    }
}