namespace NCU_stu_System.alarm
{
    partial class alarm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_func = new System.Windows.Forms.Panel();
            this.panel_menu = new System.Windows.Forms.Panel();
            this.button_beiwanglu = new System.Windows.Forms.Button();
            this.button_dingshirenwu = new System.Windows.Forms.Button();
            this.panel_beiwanglu = new System.Windows.Forms.Panel();
            this.panel_dingshirenwu = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel_func.SuspendLayout();
            this.panel_menu.SuspendLayout();
            this.panel_beiwanglu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel_func);
            this.panel1.Controls.Add(this.panel_menu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 460);
            this.panel1.TabIndex = 0;
            // 
            // panel_func
            // 
            this.panel_func.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_func.Controls.Add(this.panel_beiwanglu);
            this.panel_func.Location = new System.Drawing.Point(157, 12);
            this.panel_func.Name = "panel_func";
            this.panel_func.Size = new System.Drawing.Size(795, 445);
            this.panel_func.TabIndex = 1;
            // 
            // panel_menu
            // 
            this.panel_menu.BackColor = System.Drawing.Color.Transparent;
            this.panel_menu.Controls.Add(this.button_dingshirenwu);
            this.panel_menu.Controls.Add(this.button_beiwanglu);
            this.panel_menu.Location = new System.Drawing.Point(12, 12);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(138, 445);
            this.panel_menu.TabIndex = 0;
            // 
            // button_beiwanglu
            // 
            this.button_beiwanglu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_beiwanglu.Font = new System.Drawing.Font("宋体", 18F);
            this.button_beiwanglu.Location = new System.Drawing.Point(3, 3);
            this.button_beiwanglu.Name = "button_beiwanglu";
            this.button_beiwanglu.Size = new System.Drawing.Size(132, 207);
            this.button_beiwanglu.TabIndex = 0;
            this.button_beiwanglu.Text = "备忘录";
            this.button_beiwanglu.UseVisualStyleBackColor = true;
            // 
            // button_dingshirenwu
            // 
            this.button_dingshirenwu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_dingshirenwu.Font = new System.Drawing.Font("宋体", 18F);
            this.button_dingshirenwu.Location = new System.Drawing.Point(3, 216);
            this.button_dingshirenwu.Name = "button_dingshirenwu";
            this.button_dingshirenwu.Size = new System.Drawing.Size(132, 226);
            this.button_dingshirenwu.TabIndex = 1;
            this.button_dingshirenwu.Text = "定时任务";
            this.button_dingshirenwu.UseVisualStyleBackColor = true;
            // 
            // panel_beiwanglu
            // 
            this.panel_beiwanglu.Controls.Add(this.panel_dingshirenwu);
            this.panel_beiwanglu.Location = new System.Drawing.Point(3, 3);
            this.panel_beiwanglu.Name = "panel_beiwanglu";
            this.panel_beiwanglu.Size = new System.Drawing.Size(789, 421);
            this.panel_beiwanglu.TabIndex = 0;
            // 
            // panel_dingshirenwu
            // 
            this.panel_dingshirenwu.Location = new System.Drawing.Point(3, 22);
            this.panel_dingshirenwu.Name = "panel_dingshirenwu";
            this.panel_dingshirenwu.Size = new System.Drawing.Size(786, 417);
            this.panel_dingshirenwu.TabIndex = 0;
            this.panel_dingshirenwu.Visible = false;
            // 
            // alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 460);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "alarm";
            this.Text = "备忘提醒";
            this.panel1.ResumeLayout(false);
            this.panel_func.ResumeLayout(false);
            this.panel_menu.ResumeLayout(false);
            this.panel_beiwanglu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_func;
        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Panel panel_beiwanglu;
        private System.Windows.Forms.Panel panel_dingshirenwu;
        private System.Windows.Forms.Button button_dingshirenwu;
        private System.Windows.Forms.Button button_beiwanglu;
    }
}