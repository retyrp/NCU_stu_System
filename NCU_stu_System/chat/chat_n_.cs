using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCU_stu_System.chat
{
    class chat_n
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private string ID;
        public string UserID { get { return ID; } set { ID = value; } }
        private string content;
        public string Content { get { return content; } set { content = value; } }
        private string cls;
        public string Cls { get { return cls; } set { cls = value; } }

        public chat_n(string id, string cls, string con, string name)
        {
            UserID = id;
            Cls = cls;
            Content = con;
            Name = name;
            inti(UserID);
        }

        public chat_n(string id, string content)
        { UserID = id; Content = content; inti(UserID); }

        public chat_n(string id)
        { UserID = id; inti(UserID); }

        //发送消息
        public void sent()
        {
            chat_sent sent = new chat_sent(Content, UserID, Cls, Name);
            sent.sent();
        }

        //接受，刷新留言数据

        public string rec()
        {
            chat_sent rec = new chat_sent(Cls,UserID);
            return rec.reciver();
        }

        //返回登录消息
        public string rec_person()
        {
            return "欢迎你来到" + Cls + "的讨论空间";
        }

        //查询用户资料
        private void inti(string id)
        {
            string sql = "select * from users where id='" + id + "'";
            DBHelper helper = new DBHelper("shop");
            if (!helper.Connection())
                System.Console.WriteLine("连接数据库失败");
            DataTable table = helper.FillTable(sql);
            helper.DisConnection();
            if (table != null && table.Rows.Count > 0)
            {
                this.Name = table.Rows[0]["name"].ToString();
                this.Cls = table.Rows[0]["class"].ToString();
            }
        }
    }
}
