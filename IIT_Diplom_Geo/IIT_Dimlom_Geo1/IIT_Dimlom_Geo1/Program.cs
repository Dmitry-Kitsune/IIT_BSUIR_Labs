using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using Microsoft.Graph;

namespace IIT_Dimlom_Geo1
{
    static class Program
    {
        //public static string dirKey = "Diplom_Geo";
        //public static string projectKey = "Diplom_Geos";
        //public static string pathKey = "";
        //public static string comPath = "";

        //public static string curProject = "";
        //public static string curDirectory = "";

        //public static string fileProj = "";
        //public static string fileAllProj = "";


        //public static string diriveKey;
        //public static string driveKey;
        //public static string[] nameDrive;
        //public static int kDisk;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GeoDemo());
        }
    }

}



