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
    //public class MyGeodesy
    //{
    //    public string dirKey = "Diplom_Geo";
    //    public string projectKey = "Diplom_Geos";
    //    public string pathKey = "";
    //    public string comPath = "";

    //    MyGeodesy myGeo = new MyGeodesy();


    //    // Функция проверки дирректорий дисков

    //    public void CheckDrive(string dirName, out string strPath)
    //    {
    //        string sTmp = ""; // Инициализация выходного параметра
    //        strPath = ""; //Использование стандартных программ библиотеки System.IO 

    //        DriveInfo[] allDrives = DriveInfo.GetDrives(); //Организация цикла по кол-ву дисков
    //        foreach (DriveInfo d in allDrives)
    //        {
    //            //Create ListViewItem, give name etc.
    //            ListViewItem NewItem = new ListViewItem();
    //            NewItem.Text = d.Name;

    //            //Исключение дисков А и Б
    //            if ((d.Name[0] == 'A') || (d.Name[0] == 'a'))
    //                continue;
    //            if ((d.Name[0] == 'B') || (d.Name[0] == 'b'))
    //                continue;
    //            //Test of Disc Ready
    //            if (d.IsReady == false)
    //                continue;
    //            // Exclude CD drive
    //            if (d.DriveFormat == "CDUDF")
    //                continue;
    //            //Disc name and Directory
    //            sTmp = d.Name + dirName;
    //            //Test of Directory exist
    //            if (Directory.Exists(sTmp))
    //            {
    //                strPath = d.Name;
    //                break;
    //            }
    //        }
    //   }
    //}
}



