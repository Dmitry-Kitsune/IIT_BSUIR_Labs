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
        MyGeodesy myGeo = new MyGeodesy(); //Создаем объект класса 
        MyGeodesy mySel = new MyGeodesy(); //Создаем объект класса 
        public ProjectMenu()
        {
            InitializeComponent();

            //this.FileOptions.MouseHover += new
            //    EventHandler(this.FileOptions_MouseLeave);
            //this.FileOptions.MouseLeave += new
            //    EventHandler(this.FileOptions_MouseLeave);
           FormLoad();
        }
        protected void FormLoad()
        {
            string sTmp1 = "";
            string sTmp2 = "";
            int kDisk;
         
            myGeo.CheckDrive(myGeo.dirKey, out myGeo.driveKey);
            if (myGeo.driveKey == "")
            {

                //if Disc not selected
                myGeo.DriveList(out kDisk, out myGeo.nameDrive);
                if (kDisk == 1)
                {
                    myGeo.comPath = myGeo.nameDrive[1] + myGeo.projectKey;
                    sTmp1 = myGeo.nameDrive[1] + myGeo.dirKey; //myGeo. ?? нет значения
                    sTmp2 = myGeo.nameDrive[1] + myGeo.dirKey + "\\brdrive.dat";
                    //Автоматическое создание дирректории и файла
                    myGeo.KeepPath(myGeo.comPath, sTmp1, sTmp2);
                }

                // Форма SelectDrive  активизируется при количестве дисков больше одного
                if (kDisk > 1)
                {
                    SelectDrive sdr = new SelectDrive();
                    sdr.ShowDialog(this);
                }
                //Вторичная проверка выбора диска
                myGeo.CheckDrive(myGeo.dirKey, out myGeo.driveKey);
                if(myGeo.driveKey == "")
                {
                    //If disc not selected
                    myGeo.DriveList(out kDisk, out myGeo.nameDrive);
                    myGeo.comPath = myGeo.nameDrive[1] + myGeo.projectKey;
                    sTmp1 = myGeo.nameDrive[1] + myGeo.dirKey;
                    sTmp2 = myGeo.nameDrive[1] + myGeo.dirKey + "\\brdrive.dat";
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
        private void CheckForm(out int kDisk) /////////////////////////////////
        {
            //mySel.DriveList(out kDisk, out mySel.nameDrive);
            mySel.DriveList(out kDisk, out mySel.nameDrive);
            //Заполнение ListBox именами дисков
            for (int i = 1; i <= kDisk; i++)
                //listBox1.Items.Add(mySel.nameDrive[i]);
                listBox1.Items.Add(mySel.nameDrive[i]);
            //Проверка выбора диска
            // mySel.CheckDrive(mySel.dirKey, out mySel.driveKey);
            mySel.CheckDrive(mySel.dirKey, out mySel.driveKey);
            //Формирование пути к файлу brdrv.dat
            //mySel.pathKey = mySel.driveKey + mySel.dirKey + "\\brdrive.dat";
            mySel.pathKey = mySel.driveKey + mySel.dirKey + "\\brdrive.dat";

            if (File.Exists(mySel.pathKey))
            {
                // Если файл существует, то читаем его содержимое
                FileStream fs = new FileStream(myGeo.pathKey, FileMode.Open, FileAccess.Read);
                BinaryReader fr = new BinaryReader(fs);
                myGeo.comPath = fr.ReadString();
                fr.Close();
                fs.Close();
                // Fill the empty window by current value
                label3.Text = myGeo.comPath;
            }
            else
            {
                //if file not exsists (DISK NOT SELECTED)
                label3.Text = "Isn't defined";
            }
           // mySel.CheckDrive(mySel.dikey, out mySel.driveKey);
            mySel.CheckDrive(mySel.dirKey, out mySel.driveKey);
            if(mySel.driveKey == "")
            {
                //Disk is not selected earlier
                mySel.comPath = mySel.nameDrive[1] + mySel.projectKey;
                sTemp1 = mySel.nameDrive[1] + mySel.dirKey;
                sTemp2 = mySel.nameDrive[1] + mySel.dirKey + "\\brdrive.dat";
                mySel.KeepPath(mySel.comPath, sTemp1, sTemp2);
            }
            SelectDrive.ActiveForm.Hide();
        }
        //Button
        private void ChangeDrive_Click(object sender,EventArgs e)
        {
           // mySel,DriveList(out kDisk, out myGeo.nameDrive);
            mySel.DriveList(out kDisk, out mySel.nameDrive); // change to kDrive ??? 
            // if the number of disk = 1, nothing will change
            if (kDisk == 1)
                return;
            if (kDisk > 1)
            {
                SelectDrive sdr = new SelectDrive();
                sdr.ShowDialog(this);
            }
        }
    }
}
