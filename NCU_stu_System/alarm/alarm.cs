using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCU_stu_System.alarm
{
    public partial class alarm : Form
    {
        public alarm()
        {
            InitializeComponent();
        }

        private void pictureBox_beiwanglu_MouseEnter(object sender, EventArgs e)
        {
            panel_beiwanglu.Visible = true;
        }

        private void pictureBox_beiwanglu_MouseLeave(object sender, EventArgs e)
        {
            panel_beiwanglu.Visible = false;
        }
    }
}
