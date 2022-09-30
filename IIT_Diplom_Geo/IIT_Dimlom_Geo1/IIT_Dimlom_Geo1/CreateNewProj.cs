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
                        this.nProject = Convert.ToInt32(this.sTmp);
                        this.myProj.curDirect = fbb.ReadString();
                        this.myProj.curProject = fbb.ReadString();
                        this.listBox1.Items.Add((object)this.myProj.curProject + " " + myProj.curDirect);
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
                int num = (int)MessageBox.Show("Диск не определен", "Создание проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        //binaryReader.ReadString();//вставить переменную  дата
                        this.myProj.curDirect = binaryReader.ReadString();
                        this.myProj.curProject = binaryReader.ReadString();
                        this.listBox1.Items.Add((object)this.myProj.curProject + " " + myProj.curDirect);
                        ++num1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                }
                finally
                {
                    input.Close();
                    binaryReader.Close();
                }
            }
            if (num1 != 0)
                return;
            this.listBox1.Items.Add((object)"       Не найден");
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (this.textBoxNewProjName.Text == "")
               // if (this.textBox1.Text == "")
            {
                int num1 = (int)MessageBox.Show("Имя проекта не определено", "Новый проект", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            this.myProj.curDirect = binaryReader.ReadString();
                            this.myProj.curProject = binaryReader.ReadString();
                            if (this.nProject > this.nMax)
                                this.nMax = this.nProject;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
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
                this.myProj.curProject = this.textBoxNewProjName.Text + " " + (object)now2;
                //this.myProj.curDirect = this.myProj.comPath + "Proj" + this.sTmp;
                this.myProj.curDirect = this.myProj.comPath + this.textBoxNewProjName.Text; //+ this.sTmp;
                try
                {
                    if (!Directory.Exists(this.myProj.curDirect))
                    { Directory.CreateDirectory(this.myProj.curDirect);
                        Console.WriteLine($"[DEBUG]  Crreated new directory {this.myProj.curDirect}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция удаления завершилась неудачно, как и ожидалось.");
                }
                try
                {
                    //this.myProj.curDirect = "Proj" + this.sTmp;
                    binaryWriter1.Write(this.sTmp);
                    binaryWriter1.Write(this.myProj.curProject);
                    binaryWriter1.Write(this.myProj.curDirect);
                    //binaryWriter1.Write(this.nProject);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
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
                    Console.WriteLine("Операция удаления завершилась неудачно, как и ожидалось.");
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
        private void Quit_Click(object sender, EventArgs e)
        {
            CreateNewProj.ActiveForm.Hide();
        }

        private void textBoxNewProjName_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                this.textBoxNewProjName.Text = (sender as TextBox).Text;
            }
        }
    }
}