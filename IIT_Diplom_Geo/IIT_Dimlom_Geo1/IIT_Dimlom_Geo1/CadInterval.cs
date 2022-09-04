using IIT_Diplom_Geo1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    public partial class CadInterval : Form
    {

        private double hSect;
        private double zh;
        private double zk;
        private MyGeodesy myTop = new MyGeodesy();
   
        public CadInterval()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.radioButton1.Checked = true;
            this.LoadData();
        }

        private void LoadData()
        {
            this.myTop.FilePath();
            if (File.Exists(this.myTop.fileZminzmax))
            {
                FileStream input = new FileStream(this.myTop.fileZminzmax, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.zh = binaryReader.ReadDouble();
                    this.zk = binaryReader.ReadDouble();
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
            this.textBox1.Text = string.Format("{0:F2}", (object)this.zh);
            this.textBox2.Text = string.Format("{0:F2}", (object)this.zk);
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            this.hSect = 0.0;
            if (this.radioButton1.Checked)
                this.hSect = 0.5;
            if (this.radioButton2.Checked)
                this.hSect = 0.2;
            if (this.radioButton3.Checked)
                this.hSect = 0.1;
            if (this.radioButton4.Checked)
                this.hSect = 1.0;
            if (this.radioButton5.Checked)
                this.hSect = 2.0;
            if (this.radioButton6.Checked)
                this.hSect = 5.0;
            if (this.radioButton7.Checked)
                this.hSect = 10.0;
            if (this.radioButton8.Checked)
                this.hSect = 20.0;
            if (this.radioButton9.Checked)
                this.hSect = 25.0;
            if (File.Exists(this.myTop.fileInterval))
                File.Delete(this.myTop.fileInterval);
            FileStream output = new FileStream(this.myTop.fileInterval, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(this.hSect);
            binaryWriter.Close();
            output.Close();
            Form.ActiveForm.Close();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.hSect = 0.0;
            if (File.Exists(this.myTop.fileInterval))
                File.Delete(this.myTop.fileInterval);
            FileStream output = new FileStream(this.myTop.fileInterval, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(this.hSect);
            binaryWriter.Close();
            output.Close();
            Form.ActiveForm.Close();
        }
    }
}
