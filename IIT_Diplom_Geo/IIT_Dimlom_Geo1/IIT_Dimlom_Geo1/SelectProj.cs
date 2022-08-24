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

namespace IIT_Dimlom_Geo1
{
    public partial class SelectProj : Form
    {
        MyGeodesy mySel = new MyGeodesy(); //Создаем объект класса 

        string sTmp = ""; // Еще одна sTemp
        private string nameProject = "";
        private string nameDirectory = "";
        private int nProcess = 0;


        public SelectProj()
        {
            InitializeComponent();
            CheckSelect();
        }

        // Должен быть в FormProj
        private void CheckSelect()
        {
            // Восстановление переменных
            mySel.FilePath();

            // Заполнение окна ListBox именами проектов
            if (File.Exists(mySel.fileAllProj))
            {
                FileStream fb = new FileStream(mySel.fileAllProj, FileMode.Open, FileAccess.Read);
                BinaryReader fbb = new BinaryReader(fb);
                try
                {
                    while ((sTmp = fbb.ReadString()) != null)
                    {
                        nameProject = fbb.ReadString();
                        nameDirectory = fbb.ReadString();
                        listBox1.Items.Add(nameProject);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"SelectProj [DEBUG] Не удалось выполнить операцию чтения....sTmp= {sTmp}");
                }
                finally
                {
                    fb.Close();
                    fbb.Close();
                    if (File.Exists(mySel.fileProcess))
                    {
                        FileStream fe = new FileStream(mySel.fileProcess, FileMode.Open, FileAccess.Read);
                        BinaryReader fee = new BinaryReader(fe);
                        try
                        {
                            nProcess = fee.ReadInt32(); // Код процесса
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Не удалось выполнить операцию чтения....SelectProj = {mySel.fileProcess}");
                        }
                        finally
                        {
                            fe.Close();
                            fee.Close();
                            //Проверка текущего проекта
                            mySel.CheckOpenProj();
                            //кнопка Удалить не активна
                            if (nProcess == 1)
                                btDelete.Enabled = false;
                            // Кнопка подтвердить не Активна
                            if (nProcess == 2)
                                Confirm.Enabled = false;
                        }

                    }
                }
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
        }
    }
}
