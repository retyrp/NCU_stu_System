using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NCU_stu_System.login
{
    class login
    {
        public bool Login(string id, string pwd)
        {
            User user = new User(id,pwd);
            return user.login();
        }
    }
}
