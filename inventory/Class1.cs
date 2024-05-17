using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory
{
    internal class Class1
    {

        static string Uname;
        static string fname;

        public static string uname
        {

            get {
                return Uname;
            }
            set {
                Uname = value;
            }
            
        }
        public static string Fname
        {

            get
            {
                return fname;
            }
            set
            {
                fname = value;
            }

        }
        




    }
}
