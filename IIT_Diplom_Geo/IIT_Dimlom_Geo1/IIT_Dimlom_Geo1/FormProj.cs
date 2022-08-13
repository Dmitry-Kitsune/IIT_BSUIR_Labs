using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace IIT_Dimlom_Geo1
{

    public partial class ProjectMenu : Form 
    {
        MyGeodesy myGeo = new MyGeodesy();
        public ProjectMenu()
        {
            InitializeComponent();

            //this.FileOptions.MouseHover += new
            //    EventHandler(this.FileOptions_MouseLeave);
            //this.FileOptions.MouseLeave += new
            //    EventHandler(this.FileOptions_MouseLeave);
           FormLoad();
        }
        private void FormLoad()
        {
            string sTmp1 = "";
            string sTmp2 = "";

            myGeo.CheckDrive(myGeo.dirKey, out myGeo.driveKey);
            if(myGeo.driveKey == "")
            {
                //if Disc not selected
                myGeo.DriveList(out kDisk, out myGeo.nameDrive);
                if (kDisk == 1)
                {
                    myGeo.comPath = myGeo.nameDrive[1] + myGeo.projectKey;
                    sTmp1 = myGeo.nameDrive[1] + myGeo.dirKey;
                    sTmp2 = myGeo.nameDrive[1] + myGeo.dirKey + "\\brdrv.dat";
                    //Автоматическое создание дирректории и файла
                    myGeo.KeepPath(myGeo.comPath, sTmp1, sTmp2);
                }

                // Форма SelectDrive  активизируется при количестве дисков больше одного
                if (kDisk>1)
                {
                    SelectDrive sdr = new SlectDrive();
                    sdr.ShowDialof(this);
                }
                //Вторичная проверка выбора диска
                myGeo.CheckDrive(myGeo.dirKey, out myGeo.driveKey);
                if(myGeo.driveKey == "")
                {
                    //If disc not selected
                    myGeo.DriveList(out kDisk, out myGeo.nameDrive);
                    myGeo.comPath = myGeo.nameDrive[1] + myGeo.projectKey;
                    sTmp1 = myGeo.nameDrive[1] + myGeo.dirKey;
                    sTmp2 = myGeo.nameDrive[1] + myGeo.dirKey + "\\brdrv.dat";
                    //Автоматическое создание директории файла
                    myGeo.KeepPath(myGeo.comPath, sTmp1, sTmp2);
                }

            }
           
        }


        void DriveList(out int kDrive, out string[] sDrive)
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

    }
}
