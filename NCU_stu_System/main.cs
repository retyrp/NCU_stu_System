using NCU_stu_System.chat;
using NCU_stu_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebLibraryService;

namespace NCU_stu_System
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        public string id;
        public main(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            backgroundWorker_weather.RunWorkerAsync();
            //backgroundWorker_stu.RunWorkerAsync();
            Thread th = new Thread(new ThreadStart(getstu_info));
            th.ApartmentState = ApartmentState.STA;   //属性设置成单线程
            th.IsBackground = true;
            th.Start();
        }

        #region 无边框Panel拖动  
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gPanelTitleBack_MouseDown);
        }

        #endregion

        #region 天气获取
        //委托事件
        private delegate void InvokeCallback(string msg);
        void MessageEvent(string msg)
        {
            if (label1.InvokeRequired)
            {
                InvokeCallback msgCallback = new InvokeCallback(MessageEvent);
                label1.Invoke(msgCallback, new object[] { msg });
            }
            else
            {
                label1.Text = msg;
            }
        }
        private void backgroundWorker_weather_DoWork(object sender, DoWorkEventArgs e)
        {
            weather w = new weather();
            MessageEvent(w.getWeather());
        }
        #endregion

        #region 菜单button
       
        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            if (notifyIcon.Visible)
                notifyIcon.Visible = false;
            System.Environment.Exit(0);
        }
        private void pictureBox_mini_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_mini.BackgroundImage = Image.FromFile(Application.StartupPath + "\\pic\\main\\btn_mini_enter.png");
        }
        private void pictureBox_mini_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_mini.BackgroundImage = Image.FromFile(Application.StartupPath + "\\pic\\main\\btn_mini_normal.png");
        }
        private void pictureBox_close_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_close.BackgroundImage = Image.FromFile(Application.StartupPath + "\\pic\\main\\close_hover.png");
        }
        private void pictureBox_close_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_close.BackgroundImage = Image.FromFile(Application.StartupPath + "\\pic\\main\\close_ufoucs.png");
        }
        private void pictureBox_mini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
                notifyIcon.Visible = false;
            }
        }
        private void main_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;
                notifyIcon.Visible = true;

            }
        }


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            alarm.alarm a = new alarm.alarm();
            this.Hide();
            a.Show();
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath+"\\pic\\main\\chat_focus.png");
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\pic\\main\\chat_default.png");
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            chat.chat form = new chat.chat(id);
            form.Show();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            /*;
            new Thread((ThreadStart)delegate
            {
                Application.Run(new zone(id));
            }).Start();*/
            
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\pic\\main\\chat_fouc2.png");
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\pic\\main\\chat_2.png");
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            zone form = new zone(id);
            form.Show();
        }


        #region 获取学生信息
        private void MessageEvent_label_name(string msg)
        {
            if (label_name.InvokeRequired)
            {
                InvokeCallback msgCallback = new InvokeCallback(MessageEvent_label_name);
                label_name.Invoke(msgCallback, new object[] { msg });
            }
            else
            {
                label_name.Text = msg;
            }
        }
        private void MessageEvent_label_(string msg)
        {
            if (label_.InvokeRequired)
            {
                InvokeCallback msgCallback = new InvokeCallback(MessageEvent_label_);
                label_.Invoke(msgCallback, new object[] { msg });
            }
            else
            {
                label_.Text = msg;
            }
        }
        private void MessageEvent_label_weidutongzhi(string msg)
        {
            if (label_weidutongzhi .InvokeRequired)
            {
                InvokeCallback msgCallback = new InvokeCallback(MessageEvent_label_weidutongzhi);
                label_weidutongzhi.Invoke(msgCallback, new object[] { msg });
            }
            else
            {
                label_weidutongzhi.Text = msg;
            }
        }
        private void backgroundWorker_stu_DoWork(object sender, DoWorkEventArgs e)
        {
            //Thread.CurrentThread.SetApartmentState(ApartmentState.MTA);
            Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
            if (Settings.Default.stu_id != "none")
            {
                Class1 newstu = new Class1(Settings.Default.stu_id, Settings.Default.stu_pwd);
                string temp = newstu.temp_sentback;
                string[] temp_ = temp.Split(',');
                MessageEvent_label_name(temp_[0]);
                MessageEvent_label_name(temp_[1]);
            }
            else
                MessageBox.Show("未设置学号信息");
        }
        private void getstu_info()
        {          
            this.stu_id = Settings.Default.stu_id;
            this.stu_pwd = Settings.Default.stu_pwd;
            if (Settings.Default.stu_id != "none")
            {
                webBrowser1.Navigate(new Uri("http://online.ncu.edu.cn/"));
                
            }
            else
                MessageBox.Show("未设置学号信息");
        }
        Boolean flag = true;
        public string temp_sentback { get; private set; }
        string stu_id;
        string stu_pwd;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if(flag)
            { 
            if (e.Url.ToString().Trim() == "http://online.ncu.edu.cn/eol/main.jsp"|| e.Url.ToString().Trim() == "http://online.ncu.edu.cn/eol/welcomepage/student/index.jsp")
            {
                    flag = false;
                    if (flag)
                {
                    webBrowser1.Navigate("http://online.ncu.edu.cn/eol/welcomepage/student/index.jsp");
                    flag = false;

                }
                HtmlDocument htmlDoc = webBrowser1.Document;
                htmlDoc = webBrowser1.Document.Window.Frames["main"].Document;
                string scan = webBrowser1.Document.Window.Frames["main"].Document.Body.InnerHtml.ToString();
                GetInfo(scan);      
            }
          }
            if(flag)login();
        }
        private void GetInfo(string str)
        {
            Boolean flag = false;
            string temp = "";

            foreach (char buffer in str)
            {
                if (buffer == '\r' || buffer == '\n')
                    flag = false;
                if (buffer == '<')
                    flag = false;
                if (flag)
                    temp += buffer;
                if (buffer == '>')
                    flag = true;
            }
            temp = temp.Substring(0, temp.IndexOf("日程安排"));
            string[] temp1 = temp.Split(' ');
            string name = temp1[0].Substring(temp1[0].IndexOf("姓名") + 3);
            string weidutongzi = "";
            for (int j = 8; j < temp1.Length; j++)
            {
                if (temp1[j].Contains("年上") || temp1[j].Contains("年下")) ;
                else
                    weidutongzi += temp1[j] + "\r\n";
            }
            MessageEvent_label_name(name);
            MessageEvent_label_("通知");
            MessageEvent_label_weidutongzhi(weidutongzi);
        }
        private void login()
        {
            webBrowser1.Document.GetElementById("userName").InnerText = Settings.Default.stu_id;
            webBrowser1.Document.GetElementById("passWord").InnerText = Settings.Default.stu_pwd;
            HtmlElement login = webBrowser1.Document.GetElementById("login");

            login.InvokeMember("submit");
        }
        #endregion

        private void toolStripMenuItem_help_Click(object sender, EventArgs e)
        {
            About A = new About();
            A.Show();
        }

        private void toolStripMenuItem_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting s = new Setting();
            s.Show();
        }
    }
}
