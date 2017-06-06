using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCU_stu_System.chat
{
    public partial class chat : Form
    {
        public string id;
        public chat()
        {
            flashMes();
            InitializeComponent();
        }
        public chat(string id)
        {
            this.id = id;
            InitializeComponent();
            flashMes();
        }


        private void chat_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            toolStripStatusLabel1.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.timer1.Interval = 1000;
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void flashMes()
        {
            chat_n cat = new chat_n(id);
            textBox1.Text = cat.rec();
            label1.Text = cat.rec_person();
            this.Refresh();
            //用实时cache来实现数据通信交流
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
            {
                chat_n dog = new chat_n(id, textBox2.Text);
                dog.sent();
            }
        }

        private void button_fresh_Click(object sender, EventArgs e)
        {
            flashMes();
        }
    }
}
