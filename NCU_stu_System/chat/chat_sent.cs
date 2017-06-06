using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCU_stu_System.chat
{
    class chat_sent
    {
        private string id;
        private string cls;
        private string time;
        private string text;
        private string name;

        public string Name { get { return name; } set { name = value; } }
        public string getTime { get { return time; } }

        public string setTime { set { time = value; } }

        public string text_content { get { return text; } set { text = value; } }

        public string UserID { get { return id; } set { id = value; } }

        public string Cls { get { return cls; } set { cls = value; } }

        public chat_sent()
        { }

        public chat_sent(string cls)
        { Cls = cls; }

        public chat_sent(string cls,string id)
        { Cls = cls; UserID = id; }

        public chat_sent(string temp, string id, string cls, string name)
        {
            UserID = id;
            text_content = temp;
            Cls = cls;
            Name = name;
        }
        public void sent()
        {
            setTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "insert into chat(txt,id,content,class,name) values('" + time + "','" + UserID + "',N'" + text_content + "',N'" + cls + "',N'" + Name + "')";
            DBHelper helper = new DBHelper("shop");
            if (!helper.Connection())
                System.Console.WriteLine("连接数据库失败");
            if (helper.Update(sql) > 0)
                MessageBox.Show("发送成功");
            helper.DisConnection();
        }

        //按班级查询消息
        public string reciver()
        {
            string content = "";
            string sql = "select * from chat where class = '" + cls + "'";
            DBHelper helper = new DBHelper("shop");
            if (!helper.Connection())
                Console.WriteLine("连接数据库失败");
            //DbDataReader reader = helper.DataRead(sql);
            DataTable table = helper.FillTable(sql);
            if (table != null && table.Rows.Count > 0)
            {
                for (int i = table.Rows.Count-1; i >= 0 ; i--)
                {
                    if (table.Rows[i]["id"].ToString().Equals(UserID))
                        content += "\t\t  "+table.Rows[i]["name"].ToString() + "   " + table.Rows[i]["txt"].ToString() + "\r\n" + "\t\t  " + table.Rows[i]["content"].ToString() + "\r\n\r\n";
                    else
                        content += table.Rows[i]["name"].ToString() + "   " + table.Rows[i]["txt"].ToString() + "\r\n"+ table.Rows[i]["content"].ToString() + "\r\n\r\n";
                }
            }
            return content;
        }
    }
}
