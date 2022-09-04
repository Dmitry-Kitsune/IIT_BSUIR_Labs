using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IIT_Dimlom_Geo1;
//using Microsoft.Graph;

namespace IIT_Diplom_Geo1
{
    static class Program
    {

        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGeo());
            //Application.Run(new GeoDemo());
        }
    }

}



