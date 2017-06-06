using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCU_stu_System
{
    class reg
    {
        public void Reg(string id, string name, string password, string cls)
        {
            User user = new User(id,name,password,cls);
            user.reg(); 
        }
    }
}
