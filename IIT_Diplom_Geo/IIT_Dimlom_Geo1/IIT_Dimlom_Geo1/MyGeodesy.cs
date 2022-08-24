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
        public readonly string dirKey = "Diplom_Geo";
        public string projectKey = "Diplom_Geos";
        public string pathKey = "";
        public string comPath = "";

        public string curProject = "";
        public string curDirectory = "";

        public string fileProj = "";
        public string fileAllProj = "";

        public string driveKey;
        public string[] nameDrive;
        public int kDisk;

        public string fileProcess = "";
        public string fileAdd = "";


        // Функция проверки дирректорий дисков

        internal void CheckDrive(string dirName, out string strPath)
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
            Console.WriteLine($"[DEBUG] MyGeodesy.CheckDrive: '{strPath}'");
        }

        //void DriveList(out int kDrive, out string[] sDrive)
        internal void DriveList(out int kDrive, out string[] sDrive)
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

        internal void FilePath()
        {
            string sTmp = "";
            //Проверка выбора диска на случай непредвиденного удаления директории, определяющей выбор диска
            CheckDrive(dirKey, out driveKey);
            sTmp = driveKey + dirKey + "\\brdrive.dat";
            Console.WriteLine($"[DEBUG] MyGeodesy.FilePath: '{sTmp}'");
            if (!File.Exists(sTmp))
            {
                DialogResult result;
                result = MessageBox.Show("Проблемы с выбранным Диском",
                    "Projects",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            //Открытие и чтение файла brdrive.dat
            FileStream fa = new FileStream(sTmp, FileMode.Open, FileAccess.Read);
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

            fileProcess = comPath + "\\brProc.dat";
        }

        internal void CheckOpenProj()
        { 
            string sTmp = "";

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
                    Console.WriteLine($"Ошибка операции чтения CheckOpenProj {sTmp}");
                }
                finally
                {
                    fb.Close();
                    fbb.Close();
                }
            }

            if (!File.Exists(fileProj))
                curProject = "";
        }

        internal void ProjectDelete(string delDir)
        {
            //dellDer - имя удаляемой директории 
            //Массив имен удаляемых файлов из одной директории
            string[] nameFiles = new string[100];
            string sTmp = "";
            string sTmp1 = "";
            string sTmp2 = "";
            int kRec = 0;
            if (Directory.Exists(delDir))
            {
                // Стандартная функция
                nameFiles = Directory.GetFiles(delDir);
                // Выход по ошибке
                if (nameFiles.Length < 0)
                    return;
                // Удаление файлов из директории проекта
                for (int i = 0; i < nameFiles.Length; i++)
                {
                    if (File.Exists(nameFiles[i]))
                        File.Delete(nameFiles[i]);
                }
            }

            // Проверка удалены ли все файлы
            nameFiles = Directory.GetFiles(delDir);

            // Если все файлы удалены
            if (nameFiles.Length == 0)
            {
                // Удаление директории проекта
                if (Directory.Exists(delDir))
                    Directory.Delete(delDir);

                // Удаление о проекте из файла
                FileStream fp = new FileStream(fileAllProj, FileMode.Open,
                    FileAccess.Read);
                BinaryReader fpp = new BinaryReader(fp);

                // Объявление временного файла для сохранения информации об оставшихся проектах

                if (File.Exists(fileAdd))
                {
                    File.Delete(fileAdd);
                }

                FileStream fu = new FileStream(fileAdd, FileMode.CreateNew);
                BinaryWriter fuu = new BinaryWriter(fu);
                try
                {
                    while ((sTmp = fpp.ReadString()) != null)
                    {
                        sTmp1 = fpp.ReadString();
                        sTmp2 = fpp.ReadString();

                        // пропуск удаляемого проекта
                        if (sTmp2 == delDir)
                            continue;
                        kRec++;
                        fuu.Write(sTmp);
                        fuu.Write(sTmp1);
                        fuu.Write(sTmp2);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Не удалось выполнить операцию чтения.");
                }
                finally
                {
                    fp.Close();
                    fpp.Close();
                }

                fuu.Close();
                fu.Close();
                // Усли проектов не осталось, то удаление информации файлов и выход из подпрограммы

                if (kRec == 0)
                {
                    if (File.Exists(fileAllProj))
                        File.Delete(fileAllProj);
                    if (File.Exists(fileProj))
                        File.Delete(fileProj);
                    if (File.Exists(fileAdd))
                        File.Delete(fileAdd);
                    return;
                }

                // Восстановление файла fileAllProj без удаленной директории
                FileStream fa = new FileStream(fileAdd, FileMode.Open,
                    FileAccess.Read);
                BinaryReader faa = new BinaryReader(fa);
                if (File.Exists(fileAllProj))
                {
                    File.Delete(fileAllProj);
                }

                FileStream fb = new FileStream(fileAllProj,
                    FileMode.CreateNew);
                BinaryWriter fbb = new BinaryWriter(fb);
                try
                {
                    while ((sTmp = faa.ReadString()) != null)
                    {
                        sTmp1 = faa.ReadString();
                        sTmp2 = faa.ReadString();
                        fbb.Write(sTmp);
                        fbb.Write(sTmp1);
                        fbb.Write(sTmp2);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"ProjectDelete[DEBUG] Не удалось выполнить операцию чтения. {sTmp}");
                }

                finally
                {
                    fa.Close();
                    faa.Close();
                }

                fbb.Close();
                fb.Close();
            }
        }

    }

}


