using NCU_stu_System.login;
using NCU_stu_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCU_stu_System
{
    public partial class UI_start : Form
    {
        private Boolean bIsFade = false;
        private Boolean bIsFade_into = true;
        private Boolean bIsFade_exit = false;

        public UI_start()
        {
            InitializeComponent();
        }


        private void UI_start_Load(object sender, EventArgs e)
        {
            form_load();
            UI_ctrl();
        }



        #region 移动窗体
        /// <summary>
        /// 重写WndProc方法,实现窗体移动和禁止双击最大化
        /// </summary>
        /// <param name="m">Windows 消息</param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x4e:
                case 0xd:
                case 0xe:
                case 0x14:
                    base.WndProc(ref m);
                    break;
                case 0x84://鼠标点任意位置后可以拖动窗体
                    this.DefWndProc(ref m);
                    if (m.Result.ToInt32() == 0x01)
                    {
                        m.Result = new IntPtr(0x02);
                    }
                    break;
                case 0xA3://禁止双击最大化
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion

        #region 定义无边框Panel  
        [DllImport("user32.dll")]//*********************拖动无窗体的控件  
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void gPanelTitleBack_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数  
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gPanelTitleBack_MouseDown);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gPanelTitleBack_MouseDown);
        }
        #endregion

        #region 窗体切换效果
        private void UI_ctrl()
        {
            panel1.Focus();
            //窗体透明化
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            //定时器设定
            this.panel_Shift.Interval = 15;
            this.panel_Shift.Enabled = true;
        }


        //层叠切换
        private void shift_ac_MouseHover(object sender, EventArgs e)
        {
            panel2.Focus();
            panel_Shift.Start();
        }

        private void shift_ac_2_MouseHover(object sender, EventArgs e)
        {
            panel2.Focus();
            panel_Shift.Start();
        }

        private void shift_ac_1_MouseHover(object sender, EventArgs e)
        {
            panel1.Focus();
            panel_Shift.Start();
        }

        private void shift_ac_1_1_MouseHover(object sender, EventArgs e)
        {
            panel1.Focus();
            panel_Shift.Start();
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            shift_ac_1.Visible = false;
            shift_ac_1_1.Visible = false;
            shift_ac.Visible = true;
            shift_ac_2.Visible = true;
        }

        private void panel2_Enter(object sender, EventArgs e)
        {
            shift_ac.Visible = false;
            shift_ac_2.Visible = false;
            shift_ac_1.Visible = true;
            shift_ac_1_1.Visible = true;
        }

        //timer控件
        private void panel_Shift_Tick(object sender, EventArgs e)
        {
            if (panel1.Focused&&!panel2.Focused)
            {
                this.Opacity -= 0.07;
                if (this.Opacity <= 0)
                {
                    login_1.Visible = true;
                    exit_1.Visible = true;
                    login_2.Visible = false;
                    exit_2.Visible = false;

                    panel1.BringToFront();
                    panel2.SendToBack();

                    panel1.BackgroundImage = Image.FromFile(Application.StartupPath+"\\pic\\start\\fouc_id_stu_login_bkg.png");
                    panel2.BackgroundImage = Image.FromFile(Application.StartupPath+"\\pic\\start\\losefouc_id_Nstu_login_bkg.png");

                    while (this.Opacity <1)
                        this.Opacity += 0.02;

                    panel_Shift.Stop();
                }
            }
            if (panel2.Focused&&!panel1.Focused)
            {
                this.Opacity -= 0.07;
                if (this.Opacity <= 0)
                {
                    login_1.Visible = false;
                    exit_1.Visible = false;
                    login_2.Visible = true;
                    exit_2.Visible = true;
                    textbox_userid.Visible = false;
                    textbox_pwd.Visible = false;
                    checkBox_login_panel1.Visible = false;
                    checkBox_pwd_panel1.Visible = false;


                    panel1.SendToBack();
                    panel2.BringToFront();
                    panel2.BackgroundImage = Image.FromFile(Application.StartupPath+"\\pic\\start\\fouc_id_Nstu_login_bkg.png");
                    panel1.BackgroundImage = Image.FromFile(Application.StartupPath+"\\pic\\start\\losefouc_id_stu_login_bkg.png");

                    while (this.Opacity < 1)
                        this.Opacity += 0.09;
                    panel_Shift.Stop();
                }
            } 
        }



        #endregion

        #region 窗口启动
        private void form_load()
        {
            this.Opacity = 0;
            this.form_load_timer.Interval = 50;
            this.form_load_timer.Enabled = true;
            this.form_load_timer.Start();
        }
        private void form_load_timer_Tick(object sender, EventArgs e)
        {
            if (bIsFade_into)
            {
                this.Opacity += 0.04;
                if (this.Opacity >= 1)
                {
                    bIsFade_into = false;
                }
            }
            if (bIsFade_exit)
            {
                this.Opacity -= 0.05;
                if (this.Opacity <= 0)
                {
                    this.form_load_timer.Stop();
                    System.Environment.Exit(0);
                }
            }
        }
        private void form_load_timer2_Tick(object sender, EventArgs e)
        {
            if (bIsFade)
            {
                this.Opacity += 0.05;
                if (this.Opacity >= 1)
                    this.form_load_timer2.Stop();
            }
            else
            {
                this.Opacity -= 0.1;
                if (this.Opacity <= 0)
                {
                    bIsFade = true;
                    Thread thread = new Thread(new ThreadStart(deal_login));
                    thread.Start();
                }
            }
        }
        private void viewshow_1()
        {
            textbox_userid.Visible = true;
            textbox_pwd.Visible = true;
            checkBox_login_panel1.Visible = true;
            checkBox_pwd_panel1.Visible = true;

            login_1.Visible = false;
            exit_1.Visible = false;

            this.panel1.BackgroundImage = Image.FromFile(Application.StartupPath+"\\pic\\login\\enter_login.png");
        }
        private void viewshow_2()
        {
            login_2.Visible = false;
            exit_2.Visible = false;
        }
        #endregion

        #region 登录

        public static string userID_deafult = "学号/用户名";
        public static string userPWD_deafult = "密码";

        private void login_1_Click(object sender, EventArgs e)
        {
            bIsFade = false;
            this.form_load_timer2.Interval = 10;
            this.form_load_timer2.Enabled = true;
            this.form_load_timer2.Start();
        }

        private void login_2_Click(object sender, EventArgs e)
        {
            reg();
        }

        private void exit_1_Click(object sender, EventArgs e)
        {
            bIsFade_exit = true;
            if (bIsFade)
            {
                this.form_load_timer.Enabled = true;
                this.form_load_timer.Start();
            }
        }

        private void exit_2_Click(object sender, EventArgs e)
        {
            bIsFade_exit = true;
            if (bIsFade)
            {
                this.form_load_timer.Enabled = true;
                this.form_load_timer.Start();
            }
        }

        private void checkBox_pwd_panel1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_pwd_panel1.Checked)
                pictureBox_checkpwd.BackgroundImage = Image.FromFile(Application.StartupPath+"\\pic\\login\\menu_check_checked.png");
            else
                pictureBox_checkpwd.BackgroundImage = Image.FromFile(Application.StartupPath+"\\pic\\login\\menu_check.png");
        }

        private void checkBox_login_panel1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_login_panel1.Checked)
            {
                pictureBox_checkauto.BackgroundImage = Image.FromFile(Application.StartupPath+"\\pic\\login\\menu_check_checked.png");
                checkBox_pwd_panel1.Checked = true;
            }
            else
                pictureBox_checkauto.BackgroundImage = Image.FromFile(Application.StartupPath+"\\pic\\login\\menu_check.png");
        }

        private void textbox_userid_Enter(object sender, EventArgs e)
        {
            Font font = new Font(FontFamily.Families[0], 18, FontStyle.Bold);
            textbox_userid.Text = userID_deafult;
            textbox_userid.Font = font;
            textbox_userid.ForeColor = Color.Black;
            if (textbox_userid.Text.Equals("学号/用户名"))
                textbox_userid.Text = "";
        }

        private void textbox_userid_Leave(object sender, EventArgs e)
        {
            if (textbox_userid.Text.Equals(""))
            {
                Font font_b = new Font(FontFamily.Families[0], 14, FontStyle.Regular);
                textbox_userid.Font = font_b;
                textbox_userid.ForeColor = Color.White;
                textbox_userid.Text = userID_deafult;
            }
        }

        private void textbox_pwd_Enter(object sender, EventArgs e)
        {
            textbox_pwd.ForeColor = Color.Black;
            if (textbox_pwd.Text.Equals("密码"))
                textbox_pwd.Text = "";
            if (textbox_pwd.PasswordChar != '*')
            {
                textbox_pwd.PasswordChar = '·';
            }
        }

        private void textbox_pwd_Leave(object sender, EventArgs e)
        {
            if (textbox_pwd.Text == "")
                textbox_pwd.Text = userPWD_deafult;
            if (textbox_pwd.Text.Equals("密码"))
                textbox_pwd.PasswordChar = textbox_userid.PasswordChar;
        }

        private void textbox_pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                backgroudWork_login.RunWorkerAsync();
        }

        //登录前预设的准备
        private delegate void MyInvoke();
        private void deal_login()
        {
            MyInvoke im = new MyInvoke(Button_login);
            this.BeginInvoke(im);
        }
        private void Button_login()
        {
            viewshow_1();
            login_pre();
        }
        private void login_pre()
        {
            checkBox_pwd_panel1.Checked = Settings.Default.CHECKBOX_PWD;
            checkBox_login_panel1.Checked = Settings.Default.CHECKBOX_AOTU;
            if (checkBox_pwd_panel1.Checked)
            {
                //*这里等待使用加密程序处理
                userID_deafult = Settings.Default.ID;
                userPWD_deafult = Settings.Default.PWD;
                textbox_pwd.PasswordChar = '·';
            }
            textbox_userid.Text = userID_deafult;
            textbox_pwd.Text = userPWD_deafult;
            
            this.Refresh();

            if (checkBox_login_panel1.Checked)
                backgroudWork_login.RunWorkerAsync();
        }

        //登录操作
        private void login_do()
        {
            
            Console.WriteLine("开始登录准备");
            if (check_input())
            {
                login.login log = new login.login();
                check();
                if (log.Login(textbox_userid.Text, textbox_pwd.Text))
                {
                    this.Hide();
                    main mi = new main();
                    mi.Show();
                }
                System.Console.WriteLine("初步检验成功");
            }
            else
                System.Console.WriteLine("格式错误");
            
        }
        private void check()
        {
            if (checkBox_pwd_panel1.Checked)
            {
                //checkbox_login_MessageEvent(true);//checkBox_login_panel1.Checked = true;
                checkbox_pwd_MessageEvent(true);//checkBox_pwd_panel1.Checked = true;
                //
                Settings.Default.CHECKBOX_PWD = true;
                Settings.Default.ID = this.textbox_userid.Text;
                Settings.Default.PWD = this.textbox_pwd.Text;
            }
            else
            {
                checkbox_pwd_MessageEvent(false);//checkBox_pwd_panel1.Checked = false;
                Settings.Default.CHECKBOX_AOTU = false;
            }

            if (checkBox_login_panel1.Checked)
            {
                checkbox_pwd_MessageEvent(true);
                Settings.Default.CHECKBOX_AOTU = true;
                Settings.Default.CHECKBOX_PWD = true;
                Settings.Default.ID = this.textbox_userid.Text;
                Settings.Default.PWD = this.textbox_pwd.Text;
            }
            else
            {
                Settings.Default.CHECKBOX_AOTU = false;
                Settings.Default.ID = null;
                Settings.Default.PWD = null;
            }
            Settings.Default.Save();
        }
        private Boolean check_input()
        {
            if (textbox_userid.Text != "" && textbox_pwd.Text != "" && Regex.IsMatch(textbox_userid.Text, @"^\d{10}$"))
                return true;
            else
                return false;
        }

        private delegate void InvokeCallback(bool flag);
        private void picture_MessageEvent(bool flag)
        {
            if (pictubox.InvokeRequired)
            {
                InvokeCallback msgCallback = new InvokeCallback(picture_MessageEvent);
                pictubox.Invoke(msgCallback, new object[] { flag });
            }
            else
                pictubox.Visible = true;
        }
        private void checkbox_pwd_MessageEvent(bool flag)
        {
            if (checkBox_pwd_panel1.InvokeRequired)
            {
                InvokeCallback msgCallback = new InvokeCallback(checkbox_pwd_MessageEvent);
                checkBox_pwd_panel1.Invoke(msgCallback, new object[] { flag });
            }
            else
                checkBox_pwd_panel1.Visible = true;
        }
        private void checkbox_login_MessageEvent(bool flag)
        {
            if (checkBox_login_panel1.InvokeRequired)
            {
                InvokeCallback msgCallback = new InvokeCallback(checkbox_login_MessageEvent);
                checkBox_login_panel1.Invoke(msgCallback, new object[] { flag });
            }
            else
                checkBox_login_panel1.Visible = true;
        }

        private bool login_suc_flag = false;
        private void backgroudWork_login_DoWork(object sender, DoWorkEventArgs e)
        {
            picture_MessageEvent(true);
            login_suc_flag = back_login();
        }
        private bool back_login()
        {
            if (check_input())
            {
                login.login log = new login.login();
                check();
                if (log.Login(textbox_userid.Text, textbox_pwd.Text))
                {
                    return true;
                }
            }
            return false;
        }
        private void login_suc()
        {
            MessageBox.Show("欢迎您," + Settings.Default.NAME);
            this.Hide();
            main mi = new main(textbox_userid.Text);
            mi.Show();
        }
        private void backgroudWork_login_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (login_suc_flag)
                login_suc();
            else
                ;//MessageBox.Show("Error!");
        }



        #endregion

        #region 注册
        private void reg()
        {
            if (textBox1.Text.Trim().Length > 10)
            {
                MessageBox.Show("用户名长度不能超过10");
            }
            else if (textBox2.Text.Equals(textBox3.Text))
            {
                backgroundWorker_reg.RunWorkerAsync();//
            }
            else { MessageBox.Show("两次输入密码不一致"); }
        }
        
        private void reg_bk()
        {
            reg regedit = new reg();
            regedit.Reg(textBox1.Text,textBox4.Text,textBox2.Text,textBox5.Text); 
        }
        

        private void backgroundWorker_reg_DoWork(object sender, DoWorkEventArgs e)
        {
            reg_bk();
        }
        #endregion
    }
}
