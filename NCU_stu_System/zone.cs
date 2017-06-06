using NCU_stu_System.chat;
using NCU_stu_System.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCU_stu_System
{
    public partial class zone : Form
    {
        private bool isExit = false;
        private TcpClient client;
        private BinaryReader Read;
        private BinaryWriter Write;
        BackgroundWorker connectWork = new BackgroundWorker();
        private string server_IP = Settings.Default.IP_server;
        private int server_port = int.Parse(Settings.Default.PORT_server);

        private string id;
        public zone()
        {
            InitializeComponent();
        }
        public zone(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void zone_Load(object sender, EventArgs e)
        {
            //this.online_stu.MouseDoubleClick += new MouseEventHandler(online_stu_MouseDoubleClick);
            backgroundWorker_load.RunWorkerAsync();
        }

        //委托事件

        private void backgroundWorker_load_DoWork(object sender, DoWorkEventArgs e)
        {
            GetUserOnline_void();
            Server_start();
        }

        private void button_talk_Click(object sender, EventArgs e)
        {
            if(online_stu.SelectedIndex != -1)
            {
                
                chat_online newchat = new chat_online(id,name_id[""+online_stu.SelectedItem+""],false,false);
                //newchat.Text = online_stu.SelectedItems+"";
                newchat.Show(); 
            }
            else
                MessageBox.Show("请先在[当前在线]中选择一个对话者");
        }

        
        //关闭事件
        private void zone_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client != null)
            {
                AsyncSendMessage("Logout," + id);
                isExit = true;
                Read.Close();
                Write.Close();
                client.Close();
            }
            //MessageBox.Show(this,"",);
        }


        //--------------------------------------------------------------------------------
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
                        AddOnline(splitString[1]);
                        break;
                    case "logout":  //格式： logout,用户名
                        if (!receiveString.Contains("_"))
                            RemoveUserName(splitString[1]);
                        break;
                    case "talk":    //格式： talk,自己ID,对方ID,对话信息
                        message_Notifition(receiveString);
                        break;
                    case "response"://格式: response,自己会话ID
                        //message_Notifition(receiveString);
                        /*string talkString_response = receiveString.Substring(splitString[0].Length + splitString[1].Length + 2);
                        new Thread((ThreadStart)delegate
                        {
                            Application.Run(new chat_online(id, talkString_response, true));
                        }).Start();*/
                        break;
                    
                }
            }
            Thread.CurrentThread.Abort();
            //Application.Exit();
        }
        //发送消息动作
        private void sent_message(string aim_name, string message)
        {
            AsyncSendMessage("Talk," + aim_name + "," + message + "\r\n");
            //清除发送框 rtf_SendMessage.Clear();
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

        //查询用户资料
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
                    name_id.Add(table.Rows[i]["name_other"].ToString(),table.Rows[i]["user_id"].ToString());
                }
            }
            helper.DisConnection();
        }


        private delegate void AddOnlineDelegate(string message);

        //添加在线用户
        private void AddOnline(string message)
        {

            if (online_stu.InvokeRequired)
            {
                AddOnlineDelegate d = new AddOnlineDelegate(AddOnline);
                online_stu.Invoke(d, new object[] { message });
            }
            else
            {
                online_stu.Items.Add(id_name[message]);
                online_stu.SelectedIndex = online_stu.Items.Count - 1;
                online_stu.ClearSelected();
            }
        }

        // 从 listBoxOnline 删除离线用户
        private delegate void RemoveUserNameDelegate(string userName);
        private void RemoveUserName(string userName)
        {
            if (online_stu.InvokeRequired)
            {
                RemoveUserNameDelegate d = new RemoveUserNameDelegate(RemoveUserName);
                online_stu.Invoke(d,new object[] { userName });
            }
            else
            {
                online_stu.Items.Remove(id_name[userName]);
                online_stu.SelectedIndex = online_stu.Items.Count - 1;
                online_stu.ClearSelected();
            }
        }


        #region 消息通知
        private delegate void listBoxNotifi(string msg);
        private void addMsg(string msg)
        {
            if (listBox_notifi.InvokeRequired)
            {
                listBoxNotifi d = new listBoxNotifi(addMsg);
                listBox_notifi.Invoke(d, new object[] { msg });
            }
            else
            {
                listBox_notifi.Items.Add(msg);
            }

        }
        private void message_Notifition(string receiveString)
        {
            string[] splitString = receiveString.Split(',');
            string[] sp2 = splitString[1].Split('_');
            if (!listBox_notifi.SelectedItems.Contains("消息:" + id_name[sp2[0]]))
            {
                addMsg("消息:" + id_name[sp2[0]]);
                Write_temp(sp2[0], splitString[1]);
            }
            Write_temp(sp2[0], DateTime.Now.ToString("G"));
            Write_temp(sp2[0], receiveString.Substring(receiveString.IndexOf(splitString[2])));
        }
        public void Write_temp(string id,string msg)
        {
            FileStream fs = new FileStream(Application.StartupPath + "\\temp_" + id + ".bin", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.WriteLine(msg);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
        public string Read_temp(string name)
        {
            name = name.Split(':')[1];
            StreamReader sr = new StreamReader(Application.StartupPath + "\\temp_" + name_id[name] + ".bin", Encoding.UTF8);
            String line;
            line = sr.ReadLine();
            sr.Dispose();
            sr.Close();
            return line;
        }
        #endregion
        #endregion

        private void online_stu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void online_stu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.online_stu.IndexFromPoint(e.Location);
            online_stu.SelectedIndex = index;
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                chat_online newchat = new chat_online(id, name_id["" + online_stu.SelectedItem + ""], false,false);
                newchat.Show();
            }
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = ((TabControl)sender).TabPages[e.Index].Text;
            SolidBrush brush = new SolidBrush(Color.Black);
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Font f = new Font(Font.FontFamily,16,FontStyle.Regular);
            e.Graphics.DrawString(text, f, brush, e.Bounds, sf);
        }

        private void listBox_notifi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox_notifi.IndexFromPoint(e.Location);
            listBox_notifi.SelectedIndex = index;
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                chat_online newchat = new chat_online(id, Read_temp(listBox_notifi.SelectedItem + ""), true,true);
                newchat.Show();
            }
        }
    }
}
