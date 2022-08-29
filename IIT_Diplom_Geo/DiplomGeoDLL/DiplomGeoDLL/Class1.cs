using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomGeoDLL
{
    public class DllClass1
    {
        public readonly string dirKey = "Diplom_Geo";
        public string projectKey = "Diplom_Projs";
        public string pathKey = "";
        public string comPath = "";

        public string curProject = "";
        public string curDirectory = "";

        public string fileProj = "";
        public string fileAllProj = "";

        public string driveKey;
        public string[] nameDrive;

        public static void CheckDrive(string dirName, out string strPath)
        {
            string sTmp = "";
            strPath = "";
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if ((d.Name[0] == 'A') || (d.Name[0] == 'a'))
                    continue;
                if ((d.Name[0] == 'B') || (d.Name[0] == 'b'))
                    continue;
                if (d.IsReady == false)
                    continue;
                if (d.DriveFormat == "CDUDF")
                    continue;
                sTmp = d.Name + dirName;
                if (Directory.Exists(sTmp))
                {
                    strPath = d.Name;
                    break;
                }
            }
        }
        public static void DriveList(out int kDrive, out string[] sDrive)
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

        public static void KeepPath(string strCom, string strKey, string strFile)
        {
            Console.WriteLine($"[DEBUG] MyGeodesy.KeepPath mySel.comPath: '{strCom}'");
            Console.WriteLine($"[DEBUG] MyGeodesy.KeepPath sTemp1: '{strKey}'");
            Console.WriteLine($"[DEBUG] MyGeodesy.KeepPath sTemp2: '{strFile}'");

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
            finally
            {
            }

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
        //public string fileProj { get; set; }
        //void CheckOpenProj() : base ()
        //{
        //}
        public static void CheckOpenProj(string fileProj, out string curProject, out string curDirectory)
        //public static void CheckOpenProj() : base ()
        {
           // fileProj = ""; // перенесено из MyGeodesy.cs
            string sTmp = "";// перенесено из MyGeodesy.cs

            // инициализация выходных параметров

            curProject = "";      // перенесено из MyGeodesy.cs
            curDirectory = "";    // перенесено из MyGeodesy.cs

            if (File.Exists(fileProj))
            {
                FileStream fb = new FileStream(fileProj, FileMode.Open, FileAccess.Read);
                BinaryReader fbb = new BinaryReader(fb);
                try
                {
                    sTmp = fbb.ReadString();
                    curProject = fbb.ReadString();
                    curDirectory = fbb.ReadString();
                }
                catch (Exception)
                {
                    Console.WriteLine($"Ошибка операции чтения CheckOpenProj. sTmp = {sTmp}");
                    Console.WriteLine($"Ошибка операции чтения CheckOpenProj. fileProj = {fileProj}");
                }
                finally
                {
                    fb.Close();
                    fbb.Close();
                }
            }
        }
    }

}
