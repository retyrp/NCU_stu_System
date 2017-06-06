using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebLibraryService
{
    public class Class1
    {
        string strURL = "http://online.ncu.edu.cn/eol/homepage/common/";
        Boolean flag = true;
        public string temp_sentback { get; private set; }
        string stu_id;
        string stu_pwd;
        WebBrowser webBrowser1 = new WebBrowser();

        public Class1(string stu_id,string stu_pwd)
        {
            webBrowser1.Navigate(new Uri("http://online.ncu.edu.cn/"));
            this.stu_id = stu_id;
            this.stu_pwd = stu_pwd;
            
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
            MessageBox.Show(name);
            string weidutongzi = "";
            for (int j = 8; j < temp1.Length; j++)
            {
                if (temp1[j].Contains("年上") || temp1[j].Contains("年下")) ;
                else
                    weidutongzi += temp1[j] + "\r\n";


            }
            temp_sentback = name + "," + weidutongzi;
        }
        public string ret()
        {
            while (temp_sentback == null)
            { }
            return temp_sentback;
        }
        private void login()
        {
            webBrowser1.Document.GetElementById("userName").InnerText = stu_id;
            webBrowser1.Document.GetElementById("passWord").InnerText = stu_pwd;
            HtmlElement login = webBrowser1.Document.GetElementById("login");

            login.InvokeMember("submit");
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            if (e.Url.ToString().Trim() == "http://online.ncu.edu.cn/eol/main.jsp")
            {
                if (flag)
                {
                    webBrowser1.Navigate("http://online.ncu.edu.cn/eol/welcomepage/student/index.jsp");
                    flag = false;

                }

                HtmlDocument htmlDoc = webBrowser1.Document;
                htmlDoc = webBrowser1.Document.Window.Frames["main"].Document;
                string scan = webBrowser1.Document.Window.Frames["main"].Document.Body.InnerHtml.ToString();
                GetInfo(scan);
                login();
            }
        }
    }
}
