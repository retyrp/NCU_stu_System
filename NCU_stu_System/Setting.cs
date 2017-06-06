using NCU_stu_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCU_stu_System
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.stu_id = textBox1.Text;
            Settings.Default.stu_pwd = textBox2.Text;
            Settings.Default.IP_server = textBox3.Text;
            Settings.Default.PORT_server = textBox4.Text;
            Settings.Default.Location = textBox5.Text;
            Settings.Default.Save();
        }
    }
}
