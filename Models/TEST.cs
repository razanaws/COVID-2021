using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    class TEST
    {
        public static string center = "no appointment";
        public static string date;

        public static void SetData(string c, string d)
        {
            center = c;
            date = d;
        }

        public static string GetCenter()
        {
            return center;
        }
        public static string GetDate()
        {
            return date;
        }
    }
}
