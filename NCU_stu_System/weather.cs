using NCU_stu_System.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCU_stu_System
{
    class weather
    {
        public string getWeather()
        {
            cn.com.webxml.www.WeatherWebService w = new cn.com.webxml.www.WeatherWebService();
            string[] s = new string[23];
            try { s = w.getWeatherbyCityName(Settings.Default.Location); }
            catch { }

            string temp = "今天" + "\r\n" + s[1] + s[5] + "\r\n" + s[6];
            return temp;
        }
    }
}
