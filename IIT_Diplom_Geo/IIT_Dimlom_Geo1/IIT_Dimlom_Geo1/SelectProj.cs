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
using System.Security;
using DiplomGeoDLL;

namespace IIT_Diplom_Geo1
{
    public partial class SelectProj : Form
    {
        MyGeodesy mySel = new MyGeodesy(); //Создаем объект класса 

        string sTmp = ""; // Еще одна sTemp
        private string fileProj;
        private string nameProject = "";
        private string nameDirectory = "";
        private int nProcess = 0;

        
        private string curDir = "";
        private string[] nameFiles = new string[100];
        private string nameProj = "";
        private string curProj = "";
        private int nProject;
        
        private int k;

        //public SelectProj()
        //{
        //    InitializeComponent();
        //    CheckSelect();

        //}

        //// Должен быть в FormProj
        //private void CheckSelect()
        //{
        //    // Восстановление переменных
        //    mySel.FilePath();
        //    listBox1.Items.Clear();
        //    // Заполнение окна ListBox именами проектов
        //    if (File.Exists(mySel.fileAllProj))
        //    {
        //        FileStream fb = new FileStream(mySel.fileAllProj, FileMode.Open, FileAccess.Read);
        //        BinaryReader fbb = new BinaryReader(fb);
        //        try
        //        {
        //            while ((sTmp = fbb.ReadString()) != null)
        //            {
        //                nameProject = fbb.ReadString();
        //                nameDirectory = fbb.ReadString();
        //                listBox1.Items.Add(nameProject);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine($"SelectProj [DEBUG] Не удалось выполнить операцию чтения....sTmp= {sTmp}");
        //        }
        //        finally
        //        {
        //            fb.Close();
        //            fbb.Close();
        //            if (File.Exists(mySel.fileProcess))
        //            {
        //                FileStream fe = new FileStream(mySel.fileProcess, FileMode.Open, FileAccess.Read);
        //                BinaryReader fee = new BinaryReader(fe);
        //                try
        //                {
        //                    nProcess = fee.ReadInt32(); // Код процесса
        //                }
        //                catch (Exception)
        //                {
        //                    Console.WriteLine($"Не удалось выполнить операцию чтения....SelectProj = {mySel.fileProcess}");
        //                }
        //                finally
        //                {
        //                    fe.Close();
        //                    fee.Close();
        //                    //Проверка текущего проекта
        //                    //DllClass1.CheckOpenProj();
        //                    //mySel.CheckOpenProj();
        //                    DllClass1.CheckOpenProj(mySel.fileProj, out mySel.curProject, out mySel.curDirectory);
        //                    //кнопка Удалить не активна
        //                    if (nProcess == 1)
        //                        btDelete.Enabled = false;
        //                    // Кнопка подтвердить не Активна
        //                    if (nProcess == 2)
        //                        Confirm.Enabled = false;
        //                }

        //            }
        //        }
        //    }
        //}

        public SelectProj()
        {
            this.InitializeComponent();
            this.mySel.FilePath();
            if (!File.Exists(this.mySel.tmpStr))
            {
                int num = (int)MessageBox.Show("Drive and Projects weren't defined", "Project selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form.ActiveForm.Close();
            }
            else
            {
                if (File.Exists(this.mySel.fileProj))
                {
                    FileStream input = new FileStream(this.mySel.fileProj, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    this.sTmp = binaryReader.ReadString();
                    this.mySel.curProject = binaryReader.ReadString();
                    input.Close();
                    binaryReader.Close();
                    this.nameProj = this.sTmp;
                    this.mySel.curDirect = "BrProj" + this.sTmp;
                }
                this.k = 0;
                FileStream input1 = new FileStream(this.mySel.fileAllProj, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader1 = new BinaryReader((Stream)input1);
                try
                {
                    while ((this.sTmp = binaryReader1.ReadString()) != null)
                    {
                        ++this.k;
                        this.nProject = Convert.ToInt32(this.sTmp);
                        this.mySel.curProject = binaryReader1.ReadString();
                        this.mySel.curDirect = binaryReader1.ReadString();
                        this.listBox1.Items.Add((object)this.mySel.curProject);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The Read operation failed as expected.");
                }
                finally
                {
                    input1.Close();
                    binaryReader1.Close();
                }
                if (File.Exists(this.mySel.fileProcess))
                {
                    FileStream input2 = new FileStream(this.mySel.fileProcess, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader2 = new BinaryReader((Stream)input2);
                    try
                    {
                        this.nProcess = binaryReader2.ReadInt32();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The Read operation failed as expected.");
                    }
                    finally
                    {
                        input2.Close();
                        binaryReader2.Close();
                    }
                }
                if (this.nProcess == 20)
                {
                    this.btDelete.Enabled = false;
                    this.btDelete.Text = "";
                }
                if (this.nProcess != 30)
                    return;
                this.btDelete.Enabled = false;
                this.btDelete.Text = "";
            }
        }


        private void Confirm_Click(object sender, EventArgs e)
        {
            // Проект в списке не помечен
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Проект не выбран",
                    "Выберите существующий проект", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Открытие файла со списком всех проектов
            FileStream fa = new FileStream(mySel.fileAllProj, FileMode.Open,
                FileAccess.Read);
            BinaryReader faa = new BinaryReader(fa);
            if (listBox1.SelectedIndex > -1)
            {
                try
                {

                    //Цикл до появления помеченного проекта который становится текущим
                    for (int i = 0; i <= listBox1.SelectedIndex; i++)
                    {
                        sTmp = faa.ReadString();
                        nameProject = faa.ReadString();
                        nameDirectory = faa.ReadString();
                        
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Не удалось выполнить операцию чтения....listBox1 = {listBox1.SelectedIndex}");
                }
                finally
                {
                    faa.Close();
                    fa.Close();
                }

                try
                {
                    if (File.Exists(mySel.fileAllProj))
                    {
                        File.Delete(mySel.fileProj);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Операция удаления не удалась. {mySel.fileProj}");
                }
                finally
                {
                }

                // Сохранение данных о текущем проекте

                FileStream fc = new FileStream(mySel.fileProj,
                    FileMode.CreateNew);
                BinaryWriter fcc = new BinaryWriter(fc);
                fcc.Write(sTmp);
                fcc.Write(nameProject);
                fcc.Write(nameDirectory);
                fcc.Close();
                fc.Close();
                SelectProj.ActiveForm.Hide();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            SelectProj.ActiveForm.Hide();

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // Проект в списке не помечен
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Проект не выбран",
                    "Выберите существующий проект", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Открытие файла со списком всех проектов
            FileStream fa = new FileStream(mySel.fileAllProj, FileMode.Open,
                FileAccess.Read);
            BinaryReader faa = new BinaryReader(fa);
            if (listBox1.SelectedIndex > -1)
            {
                try
                {

                    //Цикл до появления помеченного проекта который становится текущим
                    for (int i = 0; i <= listBox1.SelectedIndex; i++)
                    {
                        sTmp = faa.ReadString();
                        nameProject = faa.ReadString();
                        nameDirectory = faa.ReadString();
                        
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Не удалось выполнить операцию чтения....listBox1 = {listBox1.SelectedIndex}");
                }
                finally
                {
                    faa.Close();
                    fa.Close();
                }

                try
                {
                    if (File.Exists(mySel.fileAllProj))
                    {
                        File.Delete(mySel.fileProj);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Операция удаления не удалась. {mySel.fileProj}");
                }
                finally
                {
                }
                //Кнопка делейт
                DialogResult result;

                //Контрольный запрос на удаление директории
                result = MessageBox.Show("Вы действительно хотите удалить данный проект?",
                    nameProject, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;

                //Удаление директории
                mySel.ProjectDelete(nameDirectory);   
                //Если директория была текущей, то удаляет так же файл fileProj
                if (mySel.curDirectory == nameDirectory)   //Выбрасывает исключение!
                {
                    if (File.Exists(mySel.fileProj))
                        File.Delete(mySel.fileProj);
                }
            }
            //CheckSelect();
            mySel.FilePath();
        }

    }
}
