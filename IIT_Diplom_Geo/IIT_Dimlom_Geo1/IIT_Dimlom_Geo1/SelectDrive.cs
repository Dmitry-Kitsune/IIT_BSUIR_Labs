using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DiplomGeoDLL;
using System.ComponentModel;

namespace IIT_Diplom_Geo1
{
    partial class SelectDrive : Form
    {
        private string comPath = "";
        private string filePath = "";
        private string pathSymbol = "";
        private string fileSymbol = "";
        private string[] sDrive;
        private int i;
        private int kDrive;
        private string tmpStr = "";
        private string tmpSymb = "";
        private string comDirect = "Diplom_Geo\\";
        private string symbDirect = "Diplom_Geo\\BrSymbol\\";
        //string dirKey = "Diplom_Geo\\";
        private MyGeodesy gen = new MyGeodesy();


        public SelectDrive()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.FormLoad();
        }
        private void FormLoad()
        {
            this.gen.FilePath();
            DllClass1.DriveList(out this.kDrive, out this.sDrive);
            for (this.i = 1; this.i <= this.kDrive; ++this.i)
            {
                this.listBox1.Items.Add((object)this.sDrive[this.i]);
                this.tmpStr = this.sDrive[this.i] + this.comDirect + "brdrive.dat";
                if (File.Exists(this.tmpStr))
                {
                    if (File.Exists(this.tmpStr))
                    {
                        FileStream input = new FileStream(this.tmpStr, FileMode.Open, FileAccess.Read);
                        BinaryReader binaryReader = new BinaryReader((Stream)input);
                        try
                        {
                            this.comPath = binaryReader.ReadString();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Операция удаления завершилась неудачно, как и ожидалось.");
                        }
                        finally
                        {
                            binaryReader.Close();
                            input.Close();
                        }
                        this.label3.Text = this.comPath;
                    }
                    else
                        this.label3.Text = "Isn't defined";
                }
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0 && MessageBox.Show("Drive wasn't selected. Do You want to leave Dialog?", "Drive selection", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                Form.ActiveForm.Close();
            if (this.listBox1.SelectedIndex <= -1)
                return;
            this.pathSymbol = this.listBox1.SelectedItem.ToString() + this.symbDirect;
            try
            {
                if (!Directory.Exists(this.pathSymbol))
                    Directory.CreateDirectory(this.pathSymbol);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Операция удаления завершилась неудачно, как и ожидалось.");
            }
            for (int index = 1; index <= this.kDrive; ++index)
            {
                this.tmpSymb = this.sDrive[index] + this.symbDirect;
                this.fileSymbol = this.tmpSymb + "brdrive.drv";
                if (Directory.Exists(this.tmpSymb))
                {
                    try
                    {
                        if (File.Exists(this.fileSymbol))
                            File.Delete(this.fileSymbol);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Операция удаления завершилась неудачно, как и ожидалось.");
                    }
                    FileStream output = new FileStream(this.fileSymbol, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    binaryWriter.Write(this.pathSymbol);
                    binaryWriter.Close();
                    output.Close();
                }
            }
            this.comPath = this.listBox1.SelectedItem.ToString() + this.comDirect;
            try
            {
                if (!Directory.Exists(this.comPath))
                    Directory.CreateDirectory(this.comPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Операция удаления завершилась неудачно, как и ожидалось.");
            }
            for (int index = 1; index <= this.kDrive; ++index)
            {
                this.tmpStr = this.sDrive[index] + this.comDirect;
                this.filePath = this.tmpStr + "brdrive.dat";
                if (Directory.Exists(this.tmpStr))
                {
                    this.label3.Text = this.comPath;
                    try
                    {
                        if (File.Exists(this.filePath))
                            File.Delete(this.filePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Операция удаления завершилась неудачно, как и ожидалось.");
                    }
                    FileStream output = new FileStream(this.filePath, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    binaryWriter.Write(this.comPath);
                    binaryWriter.Close();
                    output.Close();
                }
            }
            SelectDrive.ActiveForm.Hide();

        }

        private void Cancel_Click(object sender, EventArgs e) => Form.ActiveForm.Close();
        //private void Cancel_Click(object sender, EventArgs e)
        //{
        //    if (File.Exists(this.gen.fileAdd))
        //        File.Delete(this.gen.fileAdd);
        //    Form.ActiveForm.Close();
        //}

    }
}
