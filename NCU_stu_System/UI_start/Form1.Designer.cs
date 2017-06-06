namespace NCU_stu_System
{
    partial class UI_start
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_start));
            this.panel_Shift = new System.Windows.Forms.Timer(this.components);
            this.form_load_timer = new System.Windows.Forms.Timer(this.components);
            this.form_load_timer2 = new System.Windows.Forms.Timer(this.components);
            this.backgroudWork_login = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.login_2 = new System.Windows.Forms.PictureBox();
            this.exit_2 = new System.Windows.Forms.PictureBox();
            this.shift_ac_2 = new System.Windows.Forms.PictureBox();
            this.shift_ac = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_checkauto = new System.Windows.Forms.PictureBox();
            this.pictureBox_checkpwd = new System.Windows.Forms.PictureBox();
            this.checkBox_login_panel1 = new System.Windows.Forms.CheckBox();
            this.checkBox_pwd_panel1 = new System.Windows.Forms.CheckBox();
            this.textbox_pwd = new System.Windows.Forms.TextBox();
            this.textbox_userid = new System.Windows.Forms.TextBox();
            this.pictubox = new System.Windows.Forms.PictureBox();
            this.exit_1 = new System.Windows.Forms.PictureBox();
            this.login_1 = new System.Windows.Forms.PictureBox();
            this.shift_ac_1_1 = new System.Windows.Forms.PictureBox();
            this.shift_ac_1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker_reg = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shift_ac_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shift_ac)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_checkauto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_checkpwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictubox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shift_ac_1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shift_ac_1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Shift
            // 
            this.panel_Shift.Tick += new System.EventHandler(this.panel_Shift_Tick);
            // 
            // form_load_timer
            // 
            this.form_load_timer.Tick += new System.EventHandler(this.form_load_timer_Tick);
            // 
            // form_load_timer2
            // 
            this.form_load_timer2.Tick += new System.EventHandler(this.form_load_timer2_Tick);
            // 
            // backgroudWork_login
            // 
            this.backgroudWork_login.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroudWork_login_DoWork);
            this.backgroudWork_login.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroudWork_login_RunWorkerCompleted);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::NCU_stu_System.Properties.Resources.losefouc_id_Nstu_login_bkg;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.login_2);
            this.panel2.Controls.Add(this.exit_2);
            this.panel2.Controls.Add(this.shift_ac_2);
            this.panel2.Controls.Add(this.shift_ac);
            this.panel2.Location = new System.Drawing.Point(39, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(479, 218);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.Enter += new System.EventHandler(this.panel2_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F);
            this.label5.Location = new System.Drawing.Point(41, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "班级";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(39, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "姓名";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("幼圆", 14F);
            this.textBox5.Location = new System.Drawing.Point(103, 189);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(195, 21);
            this.textBox5.TabIndex = 12;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("幼圆", 14F);
            this.textBox4.Location = new System.Drawing.Point(103, 155);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(195, 21);
            this.textBox4.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("幼圆", 14F);
            this.textBox3.Location = new System.Drawing.Point(103, 117);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(195, 21);
            this.textBox3.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(16, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "再次输入";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(35, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(53, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("幼圆", 14F);
            this.textBox2.Location = new System.Drawing.Point(103, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(195, 21);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("幼圆", 14F);
            this.textBox1.Location = new System.Drawing.Point(103, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 21);
            this.textBox1.TabIndex = 5;
            // 
            // login_2
            // 
            this.login_2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.login_2.BackgroundImage = global::NCU_stu_System.Properties.Resources.reg;
            this.login_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.login_2.Location = new System.Drawing.Point(355, 123);
            this.login_2.Name = "login_2";
            this.login_2.Size = new System.Drawing.Size(98, 37);
            this.login_2.TabIndex = 4;
            this.login_2.TabStop = false;
            this.login_2.Click += new System.EventHandler(this.login_2_Click);
            // 
            // exit_2
            // 
            this.exit_2.Location = new System.Drawing.Point(355, 166);
            this.exit_2.Name = "exit_2";
            this.exit_2.Size = new System.Drawing.Size(98, 37);
            this.exit_2.TabIndex = 3;
            this.exit_2.TabStop = false;
            this.exit_2.Click += new System.EventHandler(this.exit_2_Click);
            // 
            // shift_ac_2
            // 
            this.shift_ac_2.Location = new System.Drawing.Point(452, 42);
            this.shift_ac_2.Name = "shift_ac_2";
            this.shift_ac_2.Size = new System.Drawing.Size(27, 176);
            this.shift_ac_2.TabIndex = 1;
            this.shift_ac_2.TabStop = false;
            this.shift_ac_2.MouseHover += new System.EventHandler(this.shift_ac_2_MouseHover);
            // 
            // shift_ac
            // 
            this.shift_ac.Location = new System.Drawing.Point(3, 4);
            this.shift_ac.Name = "shift_ac";
            this.shift_ac.Size = new System.Drawing.Size(473, 40);
            this.shift_ac.TabIndex = 0;
            this.shift_ac.TabStop = false;
            this.shift_ac.MouseHover += new System.EventHandler(this.shift_ac_MouseHover);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::NCU_stu_System.Properties.Resources.fouc_id_stu_login_bkg;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox_checkauto);
            this.panel1.Controls.Add(this.pictureBox_checkpwd);
            this.panel1.Controls.Add(this.checkBox_login_panel1);
            this.panel1.Controls.Add(this.checkBox_pwd_panel1);
            this.panel1.Controls.Add(this.textbox_pwd);
            this.panel1.Controls.Add(this.textbox_userid);
            this.panel1.Controls.Add(this.pictubox);
            this.panel1.Controls.Add(this.exit_1);
            this.panel1.Controls.Add(this.login_1);
            this.panel1.Controls.Add(this.shift_ac_1_1);
            this.panel1.Controls.Add(this.shift_ac_1);
            this.panel1.Location = new System.Drawing.Point(12, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 207);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Enter += new System.EventHandler(this.panel1_Enter);
            // 
            // pictureBox_checkauto
            // 
            this.pictureBox_checkauto.Location = new System.Drawing.Point(199, 153);
            this.pictureBox_checkauto.Name = "pictureBox_checkauto";
            this.pictureBox_checkauto.Size = new System.Drawing.Size(16, 18);
            this.pictureBox_checkauto.TabIndex = 10;
            this.pictureBox_checkauto.TabStop = false;
            // 
            // pictureBox_checkpwd
            // 
            this.pictureBox_checkpwd.Location = new System.Drawing.Point(90, 153);
            this.pictureBox_checkpwd.Name = "pictureBox_checkpwd";
            this.pictureBox_checkpwd.Size = new System.Drawing.Size(16, 18);
            this.pictureBox_checkpwd.TabIndex = 9;
            this.pictureBox_checkpwd.TabStop = false;
            // 
            // checkBox_login_panel1
            // 
            this.checkBox_login_panel1.AutoSize = true;
            this.checkBox_login_panel1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_login_panel1.Location = new System.Drawing.Point(199, 153);
            this.checkBox_login_panel1.Name = "checkBox_login_panel1";
            this.checkBox_login_panel1.Size = new System.Drawing.Size(86, 18);
            this.checkBox_login_panel1.TabIndex = 8;
            this.checkBox_login_panel1.Text = "自动登录";
            this.checkBox_login_panel1.UseVisualStyleBackColor = true;
            this.checkBox_login_panel1.Visible = false;
            this.checkBox_login_panel1.CheckedChanged += new System.EventHandler(this.checkBox_login_panel1_CheckedChanged);
            // 
            // checkBox_pwd_panel1
            // 
            this.checkBox_pwd_panel1.AutoSize = true;
            this.checkBox_pwd_panel1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_pwd_panel1.Location = new System.Drawing.Point(90, 153);
            this.checkBox_pwd_panel1.Name = "checkBox_pwd_panel1";
            this.checkBox_pwd_panel1.Size = new System.Drawing.Size(86, 18);
            this.checkBox_pwd_panel1.TabIndex = 7;
            this.checkBox_pwd_panel1.Text = "记住密码";
            this.checkBox_pwd_panel1.UseVisualStyleBackColor = true;
            this.checkBox_pwd_panel1.Visible = false;
            this.checkBox_pwd_panel1.CheckedChanged += new System.EventHandler(this.checkBox_pwd_panel1_CheckedChanged);
            // 
            // textbox_pwd
            // 
            this.textbox_pwd.BackColor = System.Drawing.SystemColors.GrayText;
            this.textbox_pwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_pwd.Font = new System.Drawing.Font("幼圆", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textbox_pwd.Location = new System.Drawing.Point(90, 105);
            this.textbox_pwd.Name = "textbox_pwd";
            this.textbox_pwd.Size = new System.Drawing.Size(195, 24);
            this.textbox_pwd.TabIndex = 6;
            this.textbox_pwd.Visible = false;
            this.textbox_pwd.WordWrap = false;
            this.textbox_pwd.Enter += new System.EventHandler(this.textbox_pwd_Enter);
            this.textbox_pwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_pwd_KeyDown);
            this.textbox_pwd.Leave += new System.EventHandler(this.textbox_pwd_Leave);
            // 
            // textbox_userid
            // 
            this.textbox_userid.BackColor = System.Drawing.SystemColors.GrayText;
            this.textbox_userid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_userid.Font = new System.Drawing.Font("幼圆", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textbox_userid.Location = new System.Drawing.Point(90, 54);
            this.textbox_userid.MaxLength = 10;
            this.textbox_userid.Name = "textbox_userid";
            this.textbox_userid.Size = new System.Drawing.Size(195, 24);
            this.textbox_userid.TabIndex = 5;
            this.textbox_userid.Visible = false;
            this.textbox_userid.WordWrap = false;
            this.textbox_userid.Enter += new System.EventHandler(this.textbox_userid_Enter);
            this.textbox_userid.Leave += new System.EventHandler(this.textbox_userid_Leave);
            // 
            // pictubox
            // 
            this.pictubox.Image = global::NCU_stu_System.Properties.Resources.ty2;
            this.pictubox.Location = new System.Drawing.Point(400, 0);
            this.pictubox.Name = "pictubox";
            this.pictubox.Size = new System.Drawing.Size(77, 76);
            this.pictubox.TabIndex = 4;
            this.pictubox.TabStop = false;
            this.pictubox.Visible = false;
            // 
            // exit_1
            // 
            this.exit_1.Location = new System.Drawing.Point(353, 159);
            this.exit_1.Name = "exit_1";
            this.exit_1.Size = new System.Drawing.Size(98, 37);
            this.exit_1.TabIndex = 3;
            this.exit_1.TabStop = false;
            this.exit_1.Click += new System.EventHandler(this.exit_1_Click);
            // 
            // login_1
            // 
            this.login_1.Location = new System.Drawing.Point(353, 116);
            this.login_1.Name = "login_1";
            this.login_1.Size = new System.Drawing.Size(98, 37);
            this.login_1.TabIndex = 2;
            this.login_1.TabStop = false;
            this.login_1.Click += new System.EventHandler(this.login_1_Click);
            // 
            // shift_ac_1_1
            // 
            this.shift_ac_1_1.Location = new System.Drawing.Point(0, 0);
            this.shift_ac_1_1.Name = "shift_ac_1_1";
            this.shift_ac_1_1.Size = new System.Drawing.Size(21, 179);
            this.shift_ac_1_1.TabIndex = 1;
            this.shift_ac_1_1.TabStop = false;
            this.shift_ac_1_1.MouseHover += new System.EventHandler(this.shift_ac_1_1_MouseHover);
            // 
            // shift_ac_1
            // 
            this.shift_ac_1.Location = new System.Drawing.Point(0, 177);
            this.shift_ac_1.Name = "shift_ac_1";
            this.shift_ac_1.Size = new System.Drawing.Size(477, 30);
            this.shift_ac_1.TabIndex = 0;
            this.shift_ac_1.TabStop = false;
            this.shift_ac_1.MouseHover += new System.EventHandler(this.shift_ac_1_MouseHover);
            // 
            // backgroundWorker_reg
            // 
            this.backgroundWorker_reg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_reg_DoWork);
            // 
            // UI_start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 270);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UI_start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UI_start_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shift_ac_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shift_ac)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_checkauto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_checkpwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictubox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shift_ac_1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shift_ac_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer panel_Shift;
        private System.Windows.Forms.PictureBox shift_ac;
        private System.Windows.Forms.PictureBox shift_ac_2;
        private System.Windows.Forms.PictureBox shift_ac_1;
        private System.Windows.Forms.PictureBox shift_ac_1_1;
        private System.Windows.Forms.PictureBox exit_1;
        private System.Windows.Forms.PictureBox login_1;
        private System.Windows.Forms.PictureBox login_2;
        private System.Windows.Forms.PictureBox exit_2;
        private System.Windows.Forms.PictureBox pictubox;
        private System.Windows.Forms.Timer form_load_timer;
        private System.Windows.Forms.Timer form_load_timer2;
        private System.Windows.Forms.TextBox textbox_pwd;
        private System.Windows.Forms.TextBox textbox_userid;
        private System.Windows.Forms.CheckBox checkBox_login_panel1;
        private System.Windows.Forms.CheckBox checkBox_pwd_panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox_checkauto;
        private System.Windows.Forms.PictureBox pictureBox_checkpwd;
        private System.ComponentModel.BackgroundWorker backgroudWork_login;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker_reg;
    }
}

