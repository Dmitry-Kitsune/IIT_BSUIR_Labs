using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IIT_Dimlom_Geo1
{
    public class MyGeodesy : Form
    {
        public string dirKey = "Diplom_Geo";
        public string projectKey = "Diplom_Geos";
        public string pathKey = "";
        public string comPath = "";

        MyGeodesy myGeo = new MyGeodesy();


        // Функция проверки дирректорий дисков

        public void CheckDrive(string dirName, out string strPath)
        {
            string sTmp = ""; // Инициализация выходного параметра
            strPath = ""; //Использование стандартных программ библиотеки System.IO 

            DriveInfo[] allDrives = DriveInfo.GetDrives(); //Организация цикла по кол-ву дисков
            foreach (DriveInfo d in allDrives)
            {
                //Create ListViewItem, give name etc.
                ListViewItem NewItem = new ListViewItem();
                NewItem.Text = d.Name;

                //Исключение дисков А и Б
                if ((d.Name[0] == 'A') || (d.Name[0] == 'a'))
                    continue;
                if ((d.Name[0] == 'B') || (d.Name[0] == 'b'))
                    continue;
                //Test of Disc Ready
                if (d.IsReady == false)
                    continue;
                // Exclude CD drive
                if (d.DriveFormat == "CDUDF")
                    continue;
                //Disc name and Directory
                sTmp = d.Name + dirName;
                //Test of Directory exist
                if (Directory.Exists(sTmp))
                {
                    strPath = d.Name;
                    break;
                }
            }

        }
        protected void KeepPath(string strCom, string strKey, string strFile)
        {
            //Создание директории "Diplom_Geo" на выбранном диске
            try
            {
                if (!Directory.Exists(strKey))
                {
                    Directory.CreateDirectory(strKey);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The CreateDirectory operation failed as expected.");
            }
            finally { }
            // запись в файл brdrv.dat путь к директории с проектами
            if (File.Exists(strFile))
            {
                File.Delete(strFile);
            }
            FileStream f1 = new FileStream(strFile, FileMode.CreateNew);
            BinaryWriter f2 = new BinaryWriter(f1);
            f2.Write(strCom);
            f2.Close();
            f1.Close();
        } 
    }
}
            
    
