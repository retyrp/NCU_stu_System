namespace NCU_stu_System
{
    partial class zone
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.online_stu = new System.Windows.Forms.ListBox();
            this.button_talk = new System.Windows.Forms.Button();
            this.backgroundWorker_load = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox_notifi = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // online_stu
            // 
            this.online_stu.BackColor = System.Drawing.SystemColors.HotTrack;
            this.online_stu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.online_stu.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.online_stu.FormattingEnabled = true;
            this.online_stu.ItemHeight = 19;
            this.online_stu.Location = new System.Drawing.Point(3, 0);
            this.online_stu.Name = "online_stu";
            this.online_stu.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.online_stu.Size = new System.Drawing.Size(169, 344);
            this.online_stu.TabIndex = 0;
            this.online_stu.SelectedIndexChanged += new System.EventHandler(this.online_stu_SelectedIndexChanged);
            this.online_stu.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.online_stu_MouseDoubleClick);
            // 
            // button_talk
            // 
            this.button_talk.Location = new System.Drawing.Point(3, 339);
            this.button_talk.Name = "button_talk";
            this.button_talk.Size = new System.Drawing.Size(165, 38);
            this.button_talk.TabIndex = 1;
            this.button_talk.Text = "发起会话";
            this.button_talk.UseVisualStyleBackColor = true;
            this.button_talk.Click += new System.EventHandler(this.button_talk_Click);
            // 
            // backgroundWorker_load
            // 
            this.backgroundWorker_load.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_load_DoWork);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(1, -1);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 385);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 3;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.online_stu);
            this.tabPage1.Controls.Add(this.button_talk);
            this.tabPage1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(28, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(168, 377);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "联系人";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox_notifi);
            this.tabPage2.Location = new System.Drawing.Point(28, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(168, 377);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "消息通知";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBox_notifi
            // 
            this.listBox_notifi.BackColor = System.Drawing.SystemColors.HotTrack;
            this.listBox_notifi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_notifi.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_notifi.FormattingEnabled = true;
            this.listBox_notifi.ItemHeight = 19;
            this.listBox_notifi.Location = new System.Drawing.Point(3, 5);
            this.listBox_notifi.Name = "listBox_notifi";
            this.listBox_notifi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_notifi.Size = new System.Drawing.Size(169, 363);
            this.listBox_notifi.TabIndex = 1;
            this.listBox_notifi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_notifi_MouseDoubleClick);
            // 
            // zone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(200, 377);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "zone";
            this.ShowIcon = false;
            this.Text = "zone";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.zone_FormClosed);
            this.Load += new System.EventHandler(this.zone_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_talk;
        private System.ComponentModel.BackgroundWorker backgroundWorker_load;
        public System.Windows.Forms.ListBox online_stu;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ListBox listBox_notifi;
    }
}