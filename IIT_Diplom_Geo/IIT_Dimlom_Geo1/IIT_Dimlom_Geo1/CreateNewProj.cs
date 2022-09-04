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
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Form_Load();
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
                int num1 = 0;
                try
                {
                    // Кол-во проектов заранее не известно
                    while ((sTmp = fbb.ReadString()) != null) // Переписывает в sTemp в место int строку с названием файла
                    {
                        //sTemp - строковое выражение порядкового номера проекта и преобразование его в целое число nProject
                        Console.WriteLine($"CreateNewProj.CheckLoad-[DEBUG] Зполнение списка проектов... sTmp = {sTmp}");
                        //nProject = System.Convert.ToInt32(sTmp);
                        //nameProject = fbb.ReadString();
                        //nameDirectory = fbb.ReadString();
                        this.nProject = Convert.ToInt32(this.sTmp);
                        this.myProj.curProject = fbb.ReadString();
                        this.myProj.curDirect = fbb.ReadString();
                        this.listBox1.Items.Add((object)this.myProj.curProject);
                        ++num1;
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


        private void Form_Load()
        {
            this.myProj.FilePath();
            if (!File.Exists(this.myProj.tmpStr))
            {
                int num = (int)MessageBox.Show("Drive wasn't defined", "Project creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form.ActiveForm.Close();
            }
            int num1 = 0;
            if (File.Exists(this.myProj.fileAllProj))
            {
                FileStream input = new FileStream(this.myProj.fileAllProj, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    while ((this.sTmp = binaryReader.ReadString()) != null)
                    {
                        this.nProject = Convert.ToInt32(this.sTmp);
                        this.myProj.curProject = binaryReader.ReadString();
                        this.myProj.curDirect = binaryReader.ReadString();
                        this.listBox1.Items.Add((object)this.myProj.curProject);
                        ++num1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The Read operation failed as expected.");
                }
                finally
                {
                    input.Close();
                    binaryReader.Close();
                }
            }
            if (num1 != 0)
                return;
            this.listBox1.Items.Add((object)"         DIDN't  FIND");
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                int num1 = (int)MessageBox.Show("Project name wasn't defined", "New Project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(this.myProj.fileAllProj))
                {
                    FileStream input = new FileStream(this.myProj.fileAllProj, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    this.nMax = 0;
                    try
                    {
                        while ((this.sTmp = binaryReader.ReadString()) != null)
                        {
                            this.nProject = Convert.ToInt32(this.sTmp);
                            this.myProj.curProject = binaryReader.ReadString();
                            this.myProj.curDirect = binaryReader.ReadString();
                            if (this.nProject > this.nMax)
                                this.nMax = this.nProject;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The Read operation failed as expected.");
                    }
                    finally
                    {
                        input.Close();
                        binaryReader.Close();
                    }
                }
                FileStream output1 = new FileStream(this.myProj.fileAllProj, FileMode.Append, FileAccess.Write);
                BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                DateTime now1 = DateTime.Now;
                DateTime now2 = DateTime.Now;
                this.nProject = this.nMax + 1;
                this.sTmp = Convert.ToString(this.nProject);
                this.myProj.curProject = this.textBox1.Text + " " + (object)now2;
                this.myProj.curDirect = this.myProj.comPath + "brProj" + this.sTmp;
                try
                {
                    if (!Directory.Exists(this.myProj.curDirect))
                        Directory.CreateDirectory(this.myProj.curDirect);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The delete operation failed as expected.");
                }
                try
                {
                    this.myProj.curDirect = "brProj" + this.sTmp;
                    binaryWriter1.Write(this.sTmp);
                    binaryWriter1.Write(this.myProj.curProject);
                    binaryWriter1.Write(this.myProj.curDirect);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The Read operation failed as expected.");
                }
                output1.Close();
                binaryWriter1.Close();
                try
                {
                    if (File.Exists(this.myProj.fileProj))
                        File.Delete(this.myProj.fileProj);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The Delete operation failed as expected.");
                }
                FileStream output2 = new FileStream(this.myProj.fileProj, FileMode.CreateNew);
                BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                binaryWriter2.Write(this.sTmp);
                binaryWriter2.Write(this.myProj.curProject);
                binaryWriter2.Close();
                output2.Close();
                int num2 = 0;
                if (File.Exists(this.myProj.fileAdd))
                    File.Delete(this.myProj.fileAdd);
                FileStream output3 = new FileStream(this.myProj.fileAdd, FileMode.CreateNew);
                BinaryWriter binaryWriter3 = new BinaryWriter((Stream)output3);
                binaryWriter3.Write(num2);
                binaryWriter3.Close();
                output3.Close();
                Form.ActiveForm.Close();
            }
        }
        //private void Confirm_Click(object sender, EventArgs e)
        //{
        //    //Проверка окна TextBox
        //    if (textBoxNewProjName.Text == "")
        //    {
        //        MessageBox.Show("Имя проекта не определено...", "New Project", MessageBoxButtons.OK,
        //            MessageBoxIcon.Warning);
        //        return;
        //    }

        //    //Создание директории для проектов
        //    try
        //    {
        //        if (!Directory.Exists(myProj.comPath))
        //        {
        //            Directory.CreateDirectory(myProj.comPath);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Ошибка! Операция не удалась");
        //    }
        //    finally
        //    {

        //    }
        //    //Определение времени открытия проекта
        //    DateTime sDateTime = DateTime.Now;
        //    sDateTime = DateTime.Now;

        //    //Порядковый номер нового проекта и его строковое представление

        //    nProject = nMax + 1;
        //    sTmp = System.Convert.ToString(nProject);

        //    //Название проекта с учетом времени создания
        //    nameProject = textBoxNewProjName.Text + " " + sDateTime;

        //    //Имя директории нового проекта
        //    nameDirectory = myProj.comPath + "\\" + myProj.dirKey + sTmp;

        //    // Создание директории нового проекта

        //    try
        //    {
        //        if (!Directory.Exists(nameDirectory))
        //        {
        //            Directory.CreateDirectory(nameDirectory);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Ошибка операции (Создание директории нового проекта)");
        //    }
        //    finally { }

        //    // Создание файла для информации о проекте
        //    try
        //    {
        //        if (File.Exists(myProj.fileProj))
        //        {
        //            File.Delete(myProj.fileProj);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Операция удаления не удалась...");
        //    }
        //    finally { }

        //    //Запись информации в файл
        //    myProj.fileProj = "tempFileProj"; // убрать значение
        //    FileStream fc = new FileStream(myProj.fileProj, FileMode.CreateNew);
        //    BinaryWriter fcc = new BinaryWriter(fc);
        //    fcc.Write(sTmp);
        //    fcc.Write(nameProject);
        //    fcc.Write(nameDirectory);
        //    fcc.Close();
        //    fc.Close();
        //    File.Delete("tempFileProj"); // Временная строка

        //    //Создание файла с перечислением всех проектов, если он не был создан
        //    if (!File.Exists(myProj.fileAllProj))
        //    {
        //        myProj.fileAllProj = "tempAllProj"; // убрать значение
        //        FileStream fd = new FileStream(myProj.fileAllProj, FileMode.CreateNew);
        //        BinaryWriter fdd = new BinaryWriter(fd);
        //        Console.WriteLine($"Запись информации о проектах при создании - {myProj.fileAllProj}");
        //        fd.Close();
        //        fdd.Close();
        //        File.Delete("tempAllProj"); // Временная строка


        //    }

        //    // Добавление в файл информации о новом проекте
        //    if (File.Exists(myProj.fileAllProj))
        //    {
        //        FileStream fe = new FileStream(myProj.fileAllProj, FileMode.Append, FileAccess.Write);
        //        BinaryWriter fee = new BinaryWriter(fe);
        //        fee.Write(sTmp);
        //        fee.Write(nameProject);
        //        fee.Write(nameDirectory);
        //        Console.WriteLine($"Запись информации о проектах при создании - {myProj.fileAllProj}");
        //        fee.Close();
        //        fe.Close();
        //    }

        //CreateNewProj.ActiveForm.Hide();
        //}
        private void Quit_Click(object sender, EventArgs e)
        {
            CreateNewProj.ActiveForm.Hide();
        }
    }
}