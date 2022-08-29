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
using Microsoft.Win32;
using DiplomGeoDLL;

namespace IIT_Diplom_Geo1
{

    public partial class ProjectMenu : Form
    {
        MyGeodesy myGeo = new MyGeodesy(); //Создаем объект класса 
        MyGeodesy mySel = new MyGeodesy(); //Создаем объект класса 

        string sTmp1 = "";
        string sTmp2 = "";
        // public string this.Path[] = mySel.comPath;
        int kDisk;

        public ProjectMenu()
        {
            //this.Font = SystemFonts.IconTitleFont;
            //SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            //this.FormClosing += new FormClosingEventHandler(FormProj_FormClosing);

            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.ChangeDrive.MouseHover += new
                EventHandler(this.ChangeDrive_MouseHover);

            this.ChangeDrive.MouseLeave += new
                EventHandler(this.ChangeDrive_MouseLeave);
            this.StartPosition = FormStartPosition.Manual;

            this.Confirm.MouseHover += new
                EventHandler(this.Confirm_MouseHover);
            this.Confirm.MouseLeave += new
                EventHandler(this.Confirm_MouseLeave);

            this.Cancel.MouseHover += new
                EventHandler(this.Cancel_MouseHover);
            this.Cancel.MouseLeave += new
                EventHandler(this.Free_MouseLeave);

            FormLoad();
            CheckForm();
        }
        //void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        //{
        //    if (e.Category == UserPreferenceCategory.Window)
        //    {
        //        this.Font = SystemFonts.IconTitleFont;
        //    }
        //}
        //void FormProj_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    SystemEvents.UserPreferenceChanged -= new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
        //}
        private void ChangeDrive_MouseHover(object sender, System.EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Close all processes";
            toolStripStatusLabel1.Text = "Изменить диск";
        }
        private void ChangeDrive_MouseLeave(object sender, System.EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Ready...";
            toolStripStatusLabel1.Text = "Готов...";
        }
        private void Free_MouseLeave(object sender, System.EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Ready...";
            toolStripStatusLabel1.Text = "Готов...";
        }

        private void Confirm_MouseHover(object sender, System.EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Close all processes";
            toolStripStatusLabel1.Text = "Подтвердить";
        }
        private void Confirm_MouseLeave(object sender, System.EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Ready...";
            toolStripStatusLabel1.Text = "Готов...";
        }
        private void Cancel_MouseHover(object sender, System.EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Close all processes";
            toolStripStatusLabel1.Text = "Отмена";
        }
        //void DriveList(out int kDrive, out string[] sDrive)
        //{
        //    // initialization of outgoing parameters
        //    kDrive = 0;
        //    sDrive = new string[] { "", "", "", "", "", "", "", "", "", "" };
        //    // Using stndsrt program System.IO library
        //    DriveInfo[] allDrives = DriveInfo.GetDrives();

        //    //Organization of the loops by the number of all disks
        //    foreach (DriveInfo d in allDrives)
        //    {
        //        //Исключение дисков А и Б
        //        if ((d.Name[0] == 'A') || (d.Name[0] == 'a'))
        //            continue;
        //        if ((d.Name[0] == 'B') || (d.Name[0] == 'b'))
        //            continue;
        //        //Test of Disc Ready
        //        if (d.IsReady == false)
        //            continue;
        //        // Exclude CD drive
        //        if (d.DriveFormat == "CDUDF")
        //            continue;
        //        // Формирование выходных параметров

        //        kDrive++;
        //        sDrive[kDrive] = d.Name;
        //    }
        //}
        void FormLoad()
        {
            //string sTmp1 = "";
            //string sTmp2 = ""; 

            DllClass1.CheckDrive(myGeo.dirKey, out myGeo.driveKey);
            if (myGeo.driveKey == "")
            {

                //if Disc not selected
                DllClass1.DriveList(out kDisk, out myGeo.nameDrive);
                if (kDisk == 1)
                {
                    var drive = myGeo.nameDrive[0];
                    Console.WriteLine($"[DEBUG] FormProj.FormLoad drive: {drive}");

                    myGeo.comPath = drive + myGeo.projectKey;
                    sTmp1 = drive + myGeo.dirKey; //myGeo. ?? нет значения
                    sTmp2 = drive + myGeo.dirKey + "\\brdrive.dat";
                    //Автоматическое создание дирректории и файла
                    DllClass1.KeepPath(myGeo.comPath, sTmp1, sTmp2);
                }

                // Форма SelectDrive  активизируется при количестве дисков больше одного
                if (kDisk > 1)
                {
                    SelectDrive sdr = new SelectDrive();
                    sdr.ShowDialog(this);
                }
                //Вторичная проверка выбора диска
                DllClass1.CheckDrive(myGeo.dirKey, out myGeo.driveKey);
                if (myGeo.driveKey == "")
                {
                    //если диск не выбран
                    DllClass1.DriveList(out kDisk, out myGeo.nameDrive);
                    myGeo.comPath = myGeo.nameDrive[0] + myGeo.projectKey;
                    sTmp1 = myGeo.nameDrive[0] + myGeo.dirKey;
                    sTmp2 = myGeo.nameDrive[0] + myGeo.dirKey + "\\brdrive.dat";
                    //Автоматическое создание директории файла
                    DllClass1.KeepPath(myGeo.comPath, sTmp1, sTmp2);

                }
            }
        }

        /// ////////////////////////////////////////////////////////
        string sTemp1;
        string sTemp2;
        /// ///////////////////////////////////////////////////////

        private void CheckForm() ///////////////////////////////// не задействована
        {
            //  string sTemp1;
            //  string sTemp2;

            //mySel.DriveList(out kDisk, out mySel.nameDrive);
            DllClass1.DriveList(out kDisk, out mySel.nameDrive);
            //Заполнение ListBox именами дисков
            for (int i = 1; i <= kDisk; i++)
                //listBox1.Items.Add(mySel.nameDrive[i]);
                listBox1.Items.Add(mySel.nameDrive[i]);
            //Проверка выбора диска
            // mySel.CheckDrive(mySel.dirKey, out mySel.driveKey);
            DllClass1.CheckDrive(mySel.dirKey, out mySel.driveKey);
            //Формирование пути к файлу brdrv.dat
            //mySel.pathKey = mySel.driveKey + mySel.dirKey + "\\brdrive.dat";
            mySel.pathKey = mySel.driveKey + mySel.dirKey + "\\brdrive.dat";

            if (File.Exists(mySel.pathKey))
            {
                // Если файл существует, то читаем его содержимое
                FileStream fs = new FileStream(mySel.pathKey, FileMode.Open, FileAccess.Read);
                BinaryReader fr = new BinaryReader(fs);
                mySel.comPath = fr.ReadString();
                fr.Close();
                fs.Close();
                // Fill the empty window by current value
                label3.Text = mySel.comPath;
            }
            else
            {
                //if file not exsists (DISK NOT SELECTED)
                label3.Text = "Диск не определен";
            }
            // mySel.CheckDrive(mySel.dikey, out mySel.driveKey);
            DllClass1.CheckDrive(mySel.dirKey, out mySel.driveKey);
            if (mySel.driveKey == "")
            {

                //Disk is not selected earlier
                mySel.comPath = mySel.nameDrive[1] + mySel.projectKey;
                sTemp1 = mySel.nameDrive[1] + mySel.dirKey;
                sTemp2 = mySel.nameDrive[1] + mySel.dirKey + "\\brdrive.dat";
                DllClass1.KeepPath(mySel.comPath, sTemp1, sTemp2);
            }
            //SelectDrive.ActiveForm.Hide();
        }

        //Button
        private void ChangeDrive_Click(object sender, EventArgs e)
        {
            DllClass1.DriveList(out kDisk, out myGeo.nameDrive);
            // if the number of disk = 1, nothing will change
            if (kDisk == 1)
                return;
            if (kDisk > 1)
            {
                SelectDrive sdr = new SelectDrive();
                sdr.ShowDialog(this);
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                //Имя диска не выделено в окне ListBox
                MessageBox.Show("Диск не выбран", "Geodesy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBox1.SelectedIndex >= 0)
            {
                //Имя диска выделено в окне ListBoX
                mySel.comPath = listBox1.SelectedItem + mySel.projectKey;
                sTemp1 = listBox1.SelectedItem + mySel.dirKey;
                sTemp2 = listBox1.SelectedItem + mySel.dirKey + "\\brdrive.dat";

                //Создание дирректории и файла
                DllClass1.KeepPath(mySel.comPath, sTemp1, sTemp2);

                // Проверка наличия ключевой директории на других дисках и внесение изменений в file - brdrive.dat
                for (int i = 1; i <= kDisk; i++)
                {
                    sTemp1 = mySel.nameDrive[i] + mySel.dirKey;
                    sTemp2 = mySel.nameDrive[i] + mySel.dirKey + "\\brdrive.dat";
                    if (File.Exists(sTemp2))
                        DllClass1.KeepPath(mySel.comPath, sTemp1, sTemp2);
                }
                SelectDrive.ActiveForm.Hide();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
