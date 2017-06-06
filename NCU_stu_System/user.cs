using NCU_stu_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCU_stu_System
{
    class User
    {
        private string id;
        public string name;
        private string cls;
        
        private string UserName
        {
            get { return name; }
            set { name = value; }
        }
        public string UserID
        { get { return id; } set { id = value; } }
        public string Cls
        { get { return cls; }set{ cls = value; } }
        public string Password { get; set; }
        //登录
        public User(string id,string pwd)
        {
            UserID = id;
            Password = pwd;
           
            
        }
        public bool login()
        {
            isLogin = true;
            Server_start();
            while (!isRec)
            {

            }
            return flag;
        }
        //注册
        public User(string id, string name, string password, string cls)
        {
            UserID = id;
            UserName = name;
            Password = password;
            Cls = cls;
            
        }
        public bool reg()
        {
            Server_start();
            while (!isRec)
            {

            }
            return flag;
            
        }

        #region 登录服务
        public string user_name { get; private set; }
        public string user_id { get; private set; }

        private bool isLogin = false;
        public bool isRec = false;
        public bool flag { get; private set; }
        private bool isExit = false;
        private TcpClient client;
        private BinaryReader Read;
        private BinaryWriter Write;
        BackgroundWorker connectWork = new BackgroundWorker();
        private string server_IP = Settings.Default.IP_server;
        private int server_port = int.Parse(Settings.Default.PORT_server);

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
                
                //AsyncSendMessage("Login," + txt_UserName.Text);
                Thread threadReceive = new Thread(new ThreadStart(ReceiveData));
                threadReceive.IsBackground = true;
                threadReceive.Start();
            }
            else
            {
                MessageBox.Show("连接登录服务器失败");
                //AddStatus("连接失败:" + e.Result);
                //btn_Login.Enabled = true;
            }
        }

        // 处理接收的服务器收据

        private void ReceiveData()
        {
            if(isLogin)
                AsyncSendMessage("Login_server," + UserID + "," + Password);
            else
                AsyncSendMessage("Regdit_server," + UserID + "," + UserName + "," + Password + "," + cls);
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
                isRec = true;
                switch (command)
                {
                    case "suc":   //格式： login,用户名
                        flag = true;
                        if (isLogin)
                            Settings.Default.NAME = splitString[2];
                        //MessageBox.Show(splitString[1]+splitString[2]);
                        else
                            MessageBox.Show(splitString[1]);
                        isExit = true;
                        break;
                    case "error":  //格式： logout,用户名
                        flag = false;
                        MessageBox.Show(splitString[1]+splitString[2]);
                        isExit = true;
                        break;
                }
            }
            Read.Close();
            Write.Close();
            client.Close();
            Thread.CurrentThread.Abort();
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





        
        #endregion
        //
    }
}
