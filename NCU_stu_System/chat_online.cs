using NCU_stu_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCU_stu_System
{
    public partial class chat_online : Form
    {
        private bool isCat = false;
        private bool isRece = false;
        private bool isExit = false;
        private TcpClient client;
        private BinaryReader Read;
        private BinaryWriter Write;
        BackgroundWorker connectWork = new BackgroundWorker();
        private string server_IP = Settings.Default.IP_server;
        private int server_port = int.Parse(Settings.Default.PORT_server);

        string[] splitString;
        //自己id
        public string id { get; private set; }
        //对方id
        private string aim_id;
        //用于发起消息时保存原有的id
        private string aim_id_temp;

        public chat_online(string id,string aim_id,bool flag,bool temp)
        {
            InitializeComponent();
            Random r = new Random((int)DateTime.Now.Ticks);
            this.id = id+"_"+r.Next(100, 999); this.aim_id = aim_id; aim_id_temp=aim_id;
            isRece = flag;
            isCat = temp;
            GetUserOnline_void();

            if (aim_id.Contains("_"))
            {
                splitString = aim_id.Split('_');
                this.Text = id_name[splitString[0]];
            }
            else
                this.Text = id_name[aim_id];
        }



        private void chat_online_Load(object sender, EventArgs e)
        {
            Read_temp(aim_id);
            Server_start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTalkMessage("\r\n\r\n\t\t\t\t\t"+"我:"+textBox2.Text+"\r\n\r\n");
            //AsyncSendMessage("Talk," + aim_id + "," + textBox2.Text + "\r\n");
            sent_message(aim_id,textBox2.Text);
            textBox2.Clear();
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AsyncSendMessage("Talk," + aim_id + "," + textBox2.Text + "\r\n");
                textBox2.Clear();
                textBox2.Clear();
            }
        }

        private void chat_online_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client != null)
            {
                AsyncSendMessage("Logout," + id);
                isExit = true;
                Read.Close();
                Write.Close();
                client.Close();
            }
        }

        #region 耦合部分
        public void Server_start()
        {
            connectWork.DoWork += new DoWorkEventHandler(connectWork_DoWork);
            connectWork.RunWorkerCompleted += new RunWorkerCompletedEventHandler(connectWork_RunWorkerCompleted);
            connectWork.RunWorkerAsync();
        }

        // 异步方式与服务器进行连接
        private void connectWork_DoWork(object sender, DoWorkEventArgs e)
        {
            client = new TcpClient();
            IAsyncResult result = client.BeginConnect(server_IP, server_port, null, null);
            while (!result.IsCompleted)
            {
                Thread.Sleep(100);
                //AddStatus(".");
            }
            try
            {
                client.EndConnect(result);
                e.Result = "success";
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
                return;
            }
        }
        // 异步方式与服务器完成连接操作后的处理
        void connectWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() == "success")
            {
                //AddStatus("连接成功");
                //获取网络流
                NetworkStream networkStream = client.GetStream();
                //将网络流作为二进制读写对象
                Read = new BinaryReader(networkStream);
                Write = new BinaryWriter(networkStream);
                AsyncSendMessage("Login," + id);
                //心跳检测
                AsyncSendMessage("?,"+aim_id+","+id);
                if (isRece)
                    AsyncSendMessage("_response," +aim_id+","+ id);
                else
                    AsyncSendMessage("response," + aim_id+","+id);
                Thread threadReceive = new Thread(new ThreadStart(ReceiveData));
                threadReceive.IsBackground = true;
                threadReceive.Start();
            }
            else
            {
                //AddStatus("连接失败:" + e.Result);
                //btn_Login.Enabled = true;
            }
        }

        // 处理接收的服务器收据

        private void ReceiveData()
        {
            string receiveString = null;
            while (!isExit)
            {
                ReceiveMessageDelegate d = new ReceiveMessageDelegate(receiveMessage);
                IAsyncResult result = d.BeginInvoke(out receiveString, null, null);
                //使用轮询方式来盘点异步操作是否完成
                while (!result.IsCompleted)
                {
                    if (isExit)
                        break;
                    Thread.Sleep(250);
                }
                //获取Begin方法的返回值所有输入/输出参数
                d.EndInvoke(out receiveString, result);
                if (receiveString == null)
                {
                    if (!isExit)
                        MessageBox.Show("与服务器失去联系");
                    break;
                }
                string[] splitString = receiveString.Split(',');
                string command = splitString[0].ToLower();
                switch (command)
                {
                    case "login":   //格式： login,用户名
                        break;
                    case "logout":  //格式： logout,用户名
                        if (splitString[1].Equals(aim_id_temp) || splitString[1].Equals(aim_id))
                            isExit = true;//做一个委托;
                        break;
                    case "talk":    //格式： talk,用户名,对话信息
                        AddTalkMessage(id_name[splitString[1].Split('_')[0]] + "：\r\n");
                        AddTalkMessage(receiveString.Substring(splitString[0].Length + splitString[1].Length + 2));
                        break;
                    /*case "response"://格式: response,自己会话ID
                        AsyncSendMessage("_response," + id);
                        break;*/
                    case "_response": // _response,对方会话ID
                        isCat = true;
                        string talkString_response_ = receiveString.Substring(splitString[0].Length + splitString[1].Length + 2);
                        SetTextInputEnable(true);
                        aim_id = talkString_response_;
                        break;
                    case "NoFound":
                        isCat = false;
                        aim_id = aim_id.Split('_')[0];
                        break;
                    case "?":
                        AsyncSendMessage("!," + aim_id + "," + id);
                        break;
                    case "!":
                        isCat = true;
                        isRece = false;
                        break;
                }
            }
            Thread.CurrentThread.Abort();
            File.Delete(Application.StartupPath + "\\temp_" + aim_id + ".bin");
        }
        //发送消息动作
        private void sent_message(string aim_id, string message)
        {
            if (!isCat)
                AsyncSendMessage("Talk," + aim_id + "," + id +"," + message + "\r\n");
            else
                AsyncSendMessage("Talk," + aim_id + "," + message + "\r\n");
            textBox2.Clear();
        }
        private struct SendMessageStates
        {
            public SendMessageDelegate d;
            public IAsyncResult result;
        }
        //异步发送数据
        private void AsyncSendMessage(string message)
        {
            SendMessageDelegate d = new SendMessageDelegate(SendMessage);
            IAsyncResult result = d.BeginInvoke(message, null, null);
            while (!result.IsCompleted)
            {
                if (isExit)
                    return;
                Thread.Sleep(50);
            }
            SendMessageStates states = new SendMessageStates();
            states.d = d;
            states.result = result;
            Thread t = new Thread(FinishAsyncSendMessage);
            t.IsBackground = true;
            t.Start(states);
        }
        private void SendMessage(string message)
        {
            try
            {
                Write.Write(message);
                Write.Flush();
            }
            catch
            {
                //AddStatus("发送失败");
            }
        }
        //发送成功后
        private void FinishAsyncSendMessage(object obj)
        {
            SendMessageStates states = (SendMessageStates)obj;
            states.d.EndInvoke(states.result);
        }
        private delegate void SendMessageDelegate(string message);

        // 连接服务器
        private delegate void ConnectServerDelegate();
        private void ConnectServer()
        {
            client = new TcpClient(server_IP, server_port);
        }

        // 读取服务器发过来的信息
        private delegate void ReceiveMessageDelegate(out string receiveMessage);
        private void receiveMessage(out string receiveMessage)
        {
            receiveMessage = null;
            try
            {
                receiveMessage = Read.ReadString();
            }
            catch (Exception ex)
            {
                //AddStatus(ex.Message);
            }
        }

        //显示消息
        private delegate void AddTalkMessageDelegate(string message);
        private void AddTalkMessage(string message)
        {
            if (textBox1.InvokeRequired)
            {
                AddTalkMessageDelegate d = new AddTalkMessageDelegate(AddTalkMessage);
                textBox1.Invoke(d, new object[] { message });
            }
            else
            {
                textBox1.AppendText(message);
                textBox1.ScrollToCaret();
            }
        }

        //控制消息输入框
        private delegate void textBox_2Enable(bool flag);
        private void SetTextInputEnable(bool flag)
        {
            if (textBox2.InvokeRequired)
            {
                textBox_2Enable d = new textBox_2Enable(SetTextInputEnable);
                textBox2.Invoke(d, new object[] { flag });
            }
            else
            {
                textBox2.Enabled = flag;
                button1.Enabled = flag;
            }
        }

        private delegate void AddOnlineDelegate(string message);


        //查询用户资料

        public void Read_temp(string aim_id)
        {
            if (File.Exists(Application.StartupPath + "\\temp_" + aim_id.Split('_')[0] + ".bin"))
            {
                StreamReader sr = new StreamReader(Application.StartupPath + "\\temp_" + aim_id.Split('_')[0] + ".bin", Encoding.UTF8);
                String line;
                line = sr.ReadLine();
                aim_id = line;
                while ((line = sr.ReadLine()) != null)
                {
                    AddTalkMessage(line);
                }
                sr.Dispose();
                sr.Close(); 
            }          
        }

        Dictionary<string, string> name_id = new Dictionary<string, string>();
        Dictionary<string, string> id_name = new Dictionary<string, string>();
        private void GetUserOnline_void()
        {

            string sql = "select * from user_info ";
            DBHelper helper = new DBHelper("shop");
            if (!helper.Connection())
                Console.WriteLine("连接数据库失败");
            //DbDataReader reader = helper.DataRead(sql);
            DataTable table = helper.FillTable(sql);
            if (table != null && table.Rows.Count > 0)
            {
                for (int i = table.Rows.Count - 1; i >= 0; i--)
                {
                    id_name.Add(table.Rows[i]["user_id"].ToString(), table.Rows[i]["name_other"].ToString());
                    name_id.Add(table.Rows[i]["name_other"].ToString(), table.Rows[i]["user_id"].ToString());
                }
            }
            helper.DisConnection();

        }
        #endregion





    }
}
