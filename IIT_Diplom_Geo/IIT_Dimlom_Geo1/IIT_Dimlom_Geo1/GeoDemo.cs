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
using System.Windows.Media.Media3D;

namespace IIT_Dimlom_Geo1
{

    public partial class GeoDemo : Form
    {

        MyGeodesy myGeo = new MyGeodesy();

        private string sTmp1;
        private int nProcess;

        public GeoDemo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.btExit1.MouseHover += new
                EventHandler(this.btExit_MouseHover);
            this.btExit1.MouseLeave += new
                EventHandler(this.btExit_MouseLeave);
            //this.FileOptions.MouseHover += new 
            //    EventHandler(this.FileOptions_MouseLeave);
            //this.FileOptions.MouseLeave += new 
            //    EventHandler(this.FileOptions_MouseLeave);
            FormLoad();
        }

        private void FormLoad()
        {
            myGeo.CheckDrive(myGeo.dirKey, out myGeo.driveKey);
            label1.Text = myGeo.comPath;
            // Проверка открытия проекта
            myGeo.FilePath();
            myGeo.CheckOpenProj();
            if (myGeo.curProject == "")
                label1.Text = myGeo.comPath + "*** Проект не открыт...";
            else
                label1.Text = myGeo.curProject;
        }

        private void btExit_MouseHover(object sender, System.EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Close all processes";
            toolStripStatusLabel1.Text = "Закрыть все прооцессы";
        }

        private void btExit_MouseLeave(object sender, System.EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Ready...";
            toolStripStatusLabel1.Text = "Готов...";
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel3.Text = String.Format("{0}", e.X);
            toolStripStatusLabel5.Text = String.Format("{0}", e.Y);
        }

        private void ProjectMenuItem_Click(object sender, EventArgs e)
        {
            ProjectMenu frm = new ProjectMenu();
            frm.Show();
        }

        private void newProjToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Желательна проверка файла brdrive.dat
            myGeo.CheckDrive(myGeo.dirKey, out myGeo.driveKey);
            sTmp1 = myGeo.driveKey + myGeo.dirKey + "\\brdrive.dat";
            Console.WriteLine($"[DEBUG] GeoDemo.newProjToolStripMenuItem_Click: '{sTmp1}'");
            if (!File.Exists(sTmp1))
            {
                MessageBox.Show("Проблемы с выброром диска", "Открыть новый проект",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Загрузка формы CreateNewProj
            CreateNewProj pr = new CreateNewProj();
            pr.ShowDialog(this);
            //pr.Show(this);

            // Проверка открытия проекта
            myGeo.FilePath();
            myGeo.CheckOpenProj();
            if (myGeo.curProject == "")
                label1.Text = myGeo.comPath + "*** Проект не открыт...";
            else
                label1.Text = myGeo.curProject;
        }

        //Проверка функции Выбора проекта  (pj-36)
        private void SelectProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int kProj = 0;
            myGeo.FilePath();
            // Подсчет находящихся в работе проектов
            if (File.Exists(myGeo.fileAllProj))
            {
                FileStream fb = new FileStream(myGeo.fileAllProj,
                    FileMode.Open, FileAccess.Read);
                BinaryReader fbb = new BinaryReader(fb);
                try
                {
                    while ((sTmp1 = fbb.ReadString()) != null)
                    {

                        myGeo.curProject = fbb.ReadString();
                        myGeo.curDirectory = fbb.ReadString();
                        kProj++;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Не удалось выполнить операцию чтения...");
                }
                finally
                {
                    fb.Close();
                    fbb.Close();
                }
            }

            // Если кол-во проектов равно нулю
            if (kProj == 0)
            {
                MessageBox.Show("Проект не определен",
                    "Выбрать существующий проект", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Если кол-во проектов равно 1, то нет смысла открывать форму для выбора проекта
            if (kProj == 1)
            {
                MessageBox.Show("Только один проект",
                    "Выбрать существующий проект",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (File.Exists(myGeo.fileProj))
                {
                    File.Delete(myGeo.fileProj);
                }

                FileStream fc = new FileStream(myGeo.fileProj,
                    FileMode.CreateNew);
                BinaryWriter fcc = new BinaryWriter(fc);
                fcc.Write(sTmp1);
                fcc.Write(myGeo.curProject);
                fcc.Write(myGeo.curDirectory);
                fcc.Close();
                fc.Close();
            }

            // Создание файла с кодом процесса = 1 
            if (File.Exists(myGeo.fileProcess))
            {
                File.Delete(myGeo.fileProcess);
            }

            FileStream fe = new FileStream(myGeo.fileProcess,
                FileMode.CreateNew);
            BinaryWriter fee = new BinaryWriter(fe);
            nProcess = 1;
            fee.Write(nProcess);
            fee.Close();
            fe.Close();
            if (kProj > 1)
                // Открытие формы
            {
                SelectProj spr = new SelectProj();
                spr.ShowDialog(this);
            }

            // Обновление переменных в соответствии с новым текущим проектом
            myGeo.FilePath();
            myGeo.CheckOpenProj();
            label1.Text = myGeo.curProject;
        }

        private void DeleteProjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Контроль наличияфайла с перечнем проектов
            if (!File.Exists(myGeo.fileAllProj))
            {
                MessageBox.Show("Проект не выбран",
                    "Выберите существующий проект",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создание файла с кодом процесса = 2
            if (File.Exists(myGeo.fileProcess))
            {
                File.Delete(myGeo.fileProcess);
            }

            FileStream fe = new FileStream(myGeo.fileProcess,
                FileMode.CreateNew);
            BinaryWriter fee = new BinaryWriter(fe);
            nProcess = 2;
            fee.Write(nProcess);
            fee.Close();
            fe.Close();
            //3arpy3Ka <t>opMhi .LlJ1JI Bbi6opa rrpoeKTa
            SelectProj spr = new SelectProj();
            spr.ShowDialog(this);
            //06HOBJieHHe nepeMeHHbiX
            myGeo.FilePath();
            //IKoHrponh reeyll(ero npoei < Ta
            myGeo.CheckOpenProj();
            if (myGeo.curProject == "")
                label1.Text = myGeo.comPath + "***Проект не был открыт";
            else
                label1.Text = myGeo.curProject;
        }

        private void DelAllProjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            // Проверка наличия проектов
            if (!File.Exists(myGeo.fileAllProj))
            {
                MessageBox.Show("Проект не выбран", "Удалить все проекты",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Контрольный запрос на удаление
            result = MessageBox.Show("Вы действительно хотите удалить все проекты ?", "Удалить все проекты",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

            // Восстановление переменных
            myGeo.FilePath();

            //1 / U,HKJI Ha Ha.JIW[He He 6onee 500 rrpoeKToB
            for (int i = 1; i < 500; i++)
            {
                int k = 0;
                if (File.Exists(myGeo.fileAllProj))
                {
                    FileStream fb = new FileStream(myGeo.fileAllProj,
                        FileMode.Open, FileAccess.Read);
                    BinaryReader fbb = new BinaryReader(fb);
                    try
                    {
                        while ((sTmp = fbb.ReadString()) != null)
                        {
                            sTmp1 = fbb.ReadString();
                            sTmp2 = fbb.ReadString();

                            // Выход из цикла сразу после считывания первого проекта
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(
                            "DelAllProjToolStripMenuItem_Click[DEBUG] Не удалось выполнить операцию чтения.");
                    }
                    finally
                    {
                        fb.Close();
                        fbb.Close();
                    }

                    // Удаление очередного проекта и восстановление файла fileAllProj
                    k++;
                    myGeo.ProjectDelete(sTmp2);
                }

                //Выход из цикла сразу после удаления последнего проекта
                if (k == 0)
                    break;
            }
            // Попытка восстановить переменные после удаления последнего проекта

            myGeo.FilePath();
            // Проверка наличия текущего проекта
            myGeo.CheckOpenProj();
            if (myGeo.curProject == "")
                label1.Text = myGeo.comPath + "***Проект не открыт";
            else
                label1.Text = myGeo.curProject;
        }
    }
}

