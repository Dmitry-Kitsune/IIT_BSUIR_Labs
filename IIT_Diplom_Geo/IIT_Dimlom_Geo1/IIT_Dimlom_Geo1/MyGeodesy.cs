using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IIT_Dimlom_Geo1
{
    //public class Form : System.Windows.Forms.ContainerControl
    //{

    //}
    public class MyGeodesy
    {
        public string dirKey = "Diplom_Geo";
        public string projectKey = "Diplom_Geos";
        public string pathKey = "";
        public string comPath = "";

        public string fileProj = "";
        public string fileAllProj = "";


        public string diriveKey;
        public string driveKey;
        public string[] nameDrive;
        public int kDisk;
       
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
        //void DriveList(out int kDrive, out string[] sDrive)
        public void DriveList(out int kDrive, out string[] sDrive)
        {
            // initialization of outgoing parameters
            kDrive = 0;
            sDrive = new string[] { "", "", "", "", "", "", "", "", "", "" };
            // Using stndsrt program System.IO library
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            //Organization of the loops by the number of all disks
            foreach (DriveInfo d in allDrives)
            {
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
                // Формирование выходных параметров

                kDrive++;
                sDrive[kDrive] = d.Name;
            }
        }
        internal void KeepPath(string strCom, string strKey, string strFile)
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
                //Console.WriteLine("The CreateDirectory operation failed as expected.");
                Console.WriteLine("Операция CreateDirectory завершилась неудачно, как и ожидалось...");
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
        public void FilePath()
        {
            string sTemp = "";
            //Проверка выбора диска на случай непредвиденного удаления директории, определяющей выбор диска
            CheckDrive(dirKey, out diriveKey);
            sTemp = driveKey + dirKey + "\\brdrive,dat";
            if (!File.Exists(sTemp))
            {
                DialogResult result;
                result = MessageBox.Show("Проблемы с выбранным Диском", 
                    "Projects",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            //Открытие и чтение файла brdrive.dat
            FileStream fa = new FileStream(sTemp, FileMode.Open, FileAccess.Read);
            BinaryReader faa = new BinaryReader(fa);
            try
            {
                comPath = faa.ReadString();
            }
            catch (Exception)

            {
                Console.WriteLine("Ошибка операции чтения");
            } 
            finally
            {
                fa.Close();
                faa.Close();
            }
                // Формирование пути для файлов brProj.dat b brAllProj.dat в зависимости от выбранного диска
                fileProj = comPath + "\\brProj.dat";
                fileAllProj = comPath + "\\brAllProj.dat";
        }
    }
}
            
    
