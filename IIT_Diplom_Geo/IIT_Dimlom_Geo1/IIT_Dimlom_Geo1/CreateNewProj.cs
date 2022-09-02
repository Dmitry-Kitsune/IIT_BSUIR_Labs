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
using System.Linq.Expressions;
using DiplomGeoDLL;

namespace IIT_Diplom_Geo1
{
    public partial class CreateNewProj : Form
    {

        //Private ???
        MyGeodesy myProj = new MyGeodesy();

        string sTmp = "";
        string nameProject = "";
        private string nameDirectory = "";
        private int nMax = 0; //0
        private int nProject = 0;//0
        
        public CreateNewProj()
        {
            InitializeComponent();
            CheckLoad();
        }

        private void CheckLoad()
        {
            //Формирование путей файлов
            myProj.FilePath();
            //Проверка наличия файла fileAllProj
            if (File.Exists(myProj.fileAllProj))
            {
                FileStream fb = new FileStream(myProj.fileAllProj, FileMode.Open, FileAccess.Read);
                BinaryReader fbb = new BinaryReader(fb);
                nMax = 0;
                try
                {
                    // Кол-во проектов заранее не известно
                    while ((sTmp = fbb.ReadString()) != null) // Переписывает в sTemp в место int строку с названием файла
                    {
                        //sTemp - строковое выражение порядкового номера проекта и преобразование его в целое число nProject
                        Console.WriteLine($"CreateNewProj.CheckLoad-[DEBUG] Зполнение списка проектов... sTmp = {sTmp}");
                        nProject = System.Convert.ToInt32(sTmp);
                        nameProject = fbb.ReadString();
                        nameDirectory = fbb.ReadString();
                        //Поиск максимального порядкового номера
                        if (nProject > nMax)
                            nMax = nProject;
                        //Заполнение окна ListBox
                        listBox1.Items.Add(nameProject);
                        Console.WriteLine($"CreateNewProj.CheckLoad-[DEBUG] Зполнение списка проектов... nameProject = {nameProject}");
                        Console.WriteLine($"CreateNewProj.CheckLoad-[DEBUG] Зполнение списка проектов... nProject = {listBox1.Items}");
                        //nProject++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка операции чтения... nProject = {nProject},CheckLoad-[DEBUG] {e}");
                }
                finally
                {
                    fb.Close();
                    fbb.Close();
                }
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            //Проверка окна TextBox
            if (textBoxNewProjName.Text == "")
            {
                MessageBox.Show("Имя проекта не определено...", "New Project", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            //Создание директории для проектов
            try
            {
                if (!Directory.Exists(myProj.comPath))
                {
                    Directory.CreateDirectory(myProj.comPath);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка! Операция не удалась");
            }
            finally
            {

            }
            //Определение времени открытия проекта
            DateTime sDateTime = DateTime.Now;
            sDateTime = DateTime.Now;

            //Порядковый номер нового проекта и его строковое представление

            nProject = nMax + 1;
            sTmp = System.Convert.ToString(nProject);

            //Название проекта с учетом времени создания
            nameProject = textBoxNewProjName.Text + " " + sDateTime;

            //Имя директории нового проекта
            nameDirectory = myProj.comPath + "\\" + myProj.dirKey + sTmp;

            // Создание директории нового проекта

            try
            {
                if (!Directory.Exists(nameDirectory))
                {
                    Directory.CreateDirectory(nameDirectory);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка операции (Создание директории нового проекта)");
            }
            finally { }

            // Создание файла для информации о проекте
            try
            {
                if (File.Exists(myProj.fileProj))
                {
                    File.Delete(myProj.fileProj);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Операция удаления не удалась...");
            }
            finally { }

            //Запись информации в файл
            myProj.fileProj = "tempFileProj"; // убрать значение
            FileStream fc = new FileStream(myProj.fileProj, FileMode.CreateNew);
            BinaryWriter fcc = new BinaryWriter(fc);
            fcc.Write(sTmp);
            fcc.Write(nameProject);
            fcc.Write(nameDirectory);
            fcc.Close();
            fc.Close();
            File.Delete("tempFileProj"); // Временная строка

            //Создание файла с перечислением всех проектов, если он не был создан
            if (!File.Exists(myProj.fileAllProj))
            {
                myProj.fileAllProj = "tempAllProj"; // убрать значение
                FileStream fd = new FileStream(myProj.fileAllProj, FileMode.CreateNew);
                BinaryWriter fdd = new BinaryWriter(fd);
                Console.WriteLine($"Запись информации о проектах при создании - {myProj.fileAllProj}");
                fd.Close();
                fdd.Close();
                File.Delete("tempAllProj"); // Временная строка


            }

            // Добавление в файл информации о новом проекте
            if (File.Exists(myProj.fileAllProj))
            {
                FileStream fe = new FileStream(myProj.fileAllProj, FileMode.Append, FileAccess.Write);
                BinaryWriter fee = new BinaryWriter(fe);
                fee.Write(sTmp);
                fee.Write(nameProject);
                fee.Write(nameDirectory);
                Console.WriteLine($"Запись информации о проектах при создании - {myProj.fileAllProj}");
                fee.Close();
                fe.Close();
            }

            CreateNewProj.ActiveForm.Hide();
        }
        private void Quit_Click(object sender, EventArgs e)
        {
            CreateNewProj.ActiveForm.Hide();
        }
    }
}