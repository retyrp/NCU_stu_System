using NCU_stu_System.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NCU_stu_System.chat
{
    class chat_load
    {
        private string name;
        private string id;
        public chat_load(string id)
        {
            this.id = id;
        }
        public chat_load()
        {

        }

        #region 获取在线用户
        private List<string> list_name = new List<string>();
        public List<string> list_name_getset { get { return list_name; } set { list_name = value; } }
        private List<string> list_userkey = new List<string>();
        public List<string> list_userkey_getset { get { return list_userkey; } set { list_userkey = value; } }
        private List<string> list_state = new List<string>();
        public List<string> list_state_getset { get { return list_state; } set { list_state = value; } }
        Dictionary<string, string> name_id = new Dictionary<string, string>();
        public string[] GetUserOnline()
        {

            string sql = "select * from online_chat where _state = 'online'";
            DBHelper helper = new DBHelper("shop");
            if (!helper.Connection())
                Console.WriteLine("连接数据库失败");
            //DbDataReader reader = helper.DataRead(sql);
            DataTable table = helper.FillTable(sql);
            if (table != null && table.Rows.Count > 0)
            {
                for (int i = table.Rows.Count - 1; i >= 0; i--)
                {
                    list_name_getset.Add(table.Rows[i]["name"].ToString());
                    list_userkey_getset.Add(table.Rows[i]["key_user"].ToString());
                    name_id.Add(table.Rows[i]["name"].ToString(), table.Rows[i]["key_user"].ToString());
                    //list_state_getset.Add(table.Rows[i]["_state"].ToString());
                }
            }
            string[] content = list_name.ToArray();
            return content;
        }
        public void run_pre()
        {
            Logindb_getname(id);
            Logindb(id, name, "online");
        }
        private void GetUserOnline_void()
        {

            string sql = "select * from online_chat where _state = 'online'";
            DBHelper helper = new DBHelper("shop");
            if (!helper.Connection())
                Console.WriteLine("连接数据库失败");
            //DbDataReader reader = helper.DataRead(sql);
            DataTable table = helper.FillTable(sql);
            if (table != null && table.Rows.Count > 0)
            {
                for (int i = table.Rows.Count - 1; i >= 0; i--)
                {
                    list_name_getset.Add(table.Rows[i]["name"].ToString());
                    list_userkey_getset.Add(table.Rows[i]["key_user"].ToString());
                    name_id.Add(table.Rows[i]["name"].ToString(), table.Rows[i]["key_user"].ToString());
                    //list_state_getset.Add(table.Rows[i]["_state"].ToString());
                }
            }
        }
        #endregion

        #region 发送状态信息
        /// 获取网络地址
        /*public string GetClientInternetIP()
        {
            Regex regex = new Regex("[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}");
            string ipAddress = "";
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    ipAddress = webClient.DownloadString("http://1212.ip138.com/ic.asp");
                }
                catch
                {
                    ipAddress = webClient.DownloadString("http://ip.chinaz.com/getip.aspx");
                }
                ipAddress = regex.Match(ipAddress).Groups[0].Value;
            }
            return ipAddress;
        }*/
        // 上载登录状况
        public void Logindb(string id, string name, string status)
        {
            int count = 0;
            string sql = "insert into online_chat(name,_state,key_user) values(N'" + name.ToString() + "','" + status + "',N'" + id + "')";
            DBHelper helper = new DBHelper("shop");
            while (true)
            {
                if (count == 6)
                    System.Console.WriteLine("连接数据库失败");
                if (helper.Update(sql) > 0)
                    break;
                count++;
            }
            helper.DisConnection();
        }
        // 查询用户信息
        private void Logindb_getname(string id)
        {
            string sql = "select * from users where id='" + id + "'";
            DBHelper helper = new DBHelper("shop");
            int count = 0;
            while (count < 5)
            {
                if (helper.Connection())
                    break;
                count++;
            }
            if (count == 5)
                System.Console.WriteLine("连接数据库失败");
            DataTable table = helper.FillTable(sql);
            helper.DisConnection();
            if (table != null && table.Rows.Count > 0)
            {
                this.name = table.Rows[0]["NAME"].ToString();
            }
        }
        private string Logindb_getid_string(string name)
        {
            string sql = "select * from users where name=N'" + name + "'";
            DBHelper helper = new DBHelper("shop");
            int count = 0;
            while (count < 5)
            {
                if (helper.Connection())
                    break;
                count++;
            }
            if (count == 5)
                System.Console.WriteLine("连接数据库失败");
            DataTable table = helper.FillTable(sql);
            helper.DisConnection();
            if (table != null && table.Rows.Count > 0)
            {
                return table.Rows[0]["ID"].ToString();
            }
            return null; 
        }
        //注销服务器
        public void cancel(string id)
        {
            int count = 0;
            string sql = "delete from online_chat where key_user = '"+id+"'";
            DBHelper helper = new DBHelper("shop");
            while (true)
            {
                if (count == 6)
                    System.Console.WriteLine("连接数据库失败");
                if (helper.Update(sql) > 0)
                    break;
                count++;
            }
            helper.DisConnection();

            cancel_server();
        }
        
        #endregion

        Socket clientSocket = null;
        public Socket clientSocket_get_set{ get { return clientSocket; } set { clientSocket = value; } }
        public void Server_start()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(Settings.Default.IP_server);
            IPEndPoint endpoint = new IPEndPoint(ip, Convert.ToInt32(Settings.Default.PORT_server));
            clientSocket.Connect(endpoint);
            login_server();
            //登录成功
            Thread thread = new Thread(ReceMsg);
            thread.IsBackground = true;//设置后台线程
            thread.Start();
        }
        public void ReceMsg()
        {
            byte[] buffer = new byte[128];
            while (true)
            {
                clientSocket.Receive(buffer,0,64,SocketFlags.None);//接收服务端发送过来的数据
                string ReceiveMsg = System.Text.Encoding.UTF8.GetString(buffer);//把接收到的字节数组转成字符串显示在文本框中。

                if (ReceiveMsg.Contains(id))
                    MessageBox.Show("登录聊天服务成功");

                else if (ReceiveMsg.Contains("#open64#"))
                {
                    int i = ReceiveMsg.IndexOf("#open64#");
                    //string me = ReceiveMsg.Substring(0, i);
                    string other = ReceiveMsg.Substring(i + 8, ReceiveMsg.Length - 8);
                    chat_start(other);
                }
                else
                    continue;
            }
        }

        //请求连接服务器
        private void login_server()
        {
            byte[] arrClientMsg;
            byte[] arrClientSendMsg;
            byte symbol = 9;

            arrClientMsg = Encoding.UTF8.GetBytes(id);
            arrClientSendMsg = new byte[arrClientMsg.Length + 1];
            arrClientSendMsg[0] = symbol;
            Buffer.BlockCopy(arrClientMsg, 0, arrClientSendMsg, 1, arrClientMsg.Length);
            clientSocket.Send(arrClientSendMsg);
        }
        //请求关闭连接
        private void cancel_server()
        {
            byte[] arrClientMsg;
            byte[] arrClientSendMsg;
            byte symbol = 7;

            arrClientMsg = Encoding.UTF8.GetBytes(id);
            arrClientSendMsg = new byte[arrClientMsg.Length + 1];
            arrClientSendMsg[0] = symbol;
            Buffer.BlockCopy(arrClientMsg, 0, arrClientSendMsg, 1, arrClientMsg.Length);
            clientSocket.Send(arrClientSendMsg);
        }
        public void chat_start(string aim_name)
        {
            //chat_online newchat = new chat_online(id,Logindb_getid_string(aim_name));
            //newchat.Show();
        }
    }
}
