using DiplomGeoDLL;
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
    public partial class ListPolyItems : Form
    {
        private int iWidth;
        private int iHeight;
        private int pixWid;
        private int pixHei;
        private int yTolMin;
        private int yTolMax;
        private int kItemPoly;
        private int numLast;
        private int nProcess;
        private int yBegin = 10;
        private int wItemMax;
        private int hItemMax;
        private int khItem;
        private MyGeodesy myPol = new MyGeodesy();
        public ListPolyItems()
        {
           InitializeComponent();
           StartPosition = FormStartPosition.Manual;
           pixWid =panel1.Bounds.Width;
           pixHei =panel1.Bounds.Height;
            if (this.pixWid <=pixHei)
               iWidth =iHeight =pixWid;
            if (this.pixWid >pixHei)
               iWidth =iHeight =pixHei;
           myPol.FilePath();
           FormLoad();
        }
        private void FormLoad()
        {
           numLast = 0;
           myPol.FilePath();
            DllClass1.SetColour(this.myPol.brColor,myPol.pnColor);
           kItemPoly = 0;
            if (File.Exists(this.myPol.fitemPoly))
            {
                int index1 = 1;
                int yBegin =this.yBegin;
               myPol.hItemPoly[1] =yBegin;
                if (File.Exists(this.myPol.fPolyPixel))
                    File.Delete(this.myPol.fPolyPixel);
                FileStream output = new FileStream(this.myPol.fPolyPixel, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                FileStream input = new FileStream(this.myPol.fitemPoly, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    string str1;
                    while ((str1 = binaryReader.ReadString()) != null)
                    {
                        int int32 = Convert.ToInt32(str1);
                        if (int32 >numLast)
                           numLast = int32;
                        int num1 = binaryReader.ReadInt32();
                        binaryWriter.Write(str1);
                        binaryWriter.Write(num1);
                        if (num1 == 0)
                        {
                            double num2 = binaryReader.ReadDouble();
                            double num3 = binaryReader.ReadDouble();
                            int num4 = binaryReader.ReadInt32();
                            int num5 = binaryReader.ReadInt32();
                            binaryWriter.Write(num2);
                            binaryWriter.Write(num3);
                            binaryWriter.Write(num4);
                            binaryWriter.Write(num5);
                            int num6 = binaryReader.ReadInt32();
                            binaryWriter.Write(num6);
                            if (num6 > 0)
                            {
                                for (int index2 = 1; index2 <= num6; ++index2)
                                {
                                    int num7 = binaryReader.ReadInt32();
                                    int num8 = binaryReader.ReadInt32();
                                    int num9 = binaryReader.ReadInt32();
                                    binaryWriter.Write(num7);
                                    binaryWriter.Write(num8);
                                    binaryWriter.Write(num9);
                                }
                            }
                            ++this.kItemPoly;
                           myPol.numLong[this.kItemPoly] = num1;
                            ++index1;
                            if (num3 < 3.0)
                                yBegin += Convert.ToInt32(2.5 * (double)num5);
                            if (num3 >= 3.0 && num3 < 4.0)
                                yBegin += Convert.ToInt32(1.5 * (double)num5);
                            if (num3 >= 4.0)
                                yBegin += Convert.ToInt32(1.3 * (double)num5);
                           myPol.hItemPoly[index1] = yBegin;
                            if (num4 >wItemMax)
                               wItemMax = num4;
                            if (num5 >hItemMax)
                               hItemMax = num5;
                        }
                        if (num1 > 0)
                        {
                            int num10 = binaryReader.ReadInt32();
                            int num11 = binaryReader.ReadInt32();
                            string str2 = binaryReader.ReadString();
                            double num12 = binaryReader.ReadDouble();
                            double num13 = binaryReader.ReadDouble();
                            int num14 = binaryReader.ReadInt32();
                            int num15 = binaryReader.ReadInt32();
                            binaryWriter.Write(num10);
                            binaryWriter.Write(num11);
                            binaryWriter.Write(str2);
                            binaryWriter.Write(num12);
                            binaryWriter.Write(num13);
                            binaryWriter.Write(num14);
                            binaryWriter.Write(num15);
                            ++this.kItemPoly;
                           myPol.numLong[this.kItemPoly] = num1;
                            ++index1;
                            yBegin += 3 * num15;
                           myPol.hItemPoly[index1] = yBegin;
                            if (num14 >wItemMax)
                               wItemMax = num14;
                            if (num15 >hItemMax)
                               hItemMax = num15;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                }
                finally
                {
                    binaryReader.Close();
                    input.Close();
                    binaryWriter.Close();
                    output.Close();
                }
            }
           myPol.kItemPoly =kItemPoly;
            if (this.kItemPoly == 0)
               hItemMax = 10;
            if (this.kItemPoly > 0)
            {
               yTolMin =myPol.hItemPoly[1];
               yTolMax =myPol.hItemPoly[this.kItemPoly];
            }
           khItem =kItemPoly + 1;
           myPol.hItemPoly[this.khItem] =myPol.hItemPoly[this.kItemPoly] +hItemMax;
            if (File.Exists(this.myPol.fileAdd))
            {
                FileStream input = new FileStream(this.myPol.fileAdd, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
               nProcess = binaryReader.ReadInt32();
                binaryReader.Close();
                input.Close();
            }
            if (this.nProcess == 0 ||nProcess == 10 ||nProcess == 1000)
               label1.Text = "";
            if (this.nProcess != 1000)
                return;
            for (int index3 = 1; index3 <=kItemPoly; ++index3)
            {
               yTolMax =myPol.hItemPoly[this.kItemPoly] +hItemMax;
                if (this.yTolMax <pixHei)
                    break;
                for (int index4 = 1; index4 <=kItemPoly; ++index4)
                   myPol.hItemPoly[index4] =myPol.hItemPoly[index4] -hItemMax;
               panel1.Invalidate();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            DllClass1.PolyItemDraw(e,myPol.fitemPoly,hItemMax,kItemPoly,myPol.hItemPoly,myPol.brColor);
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int num1 = 0;
            for (int index = 2; index <=khItem; ++index)
            {
                if (this.myPol.hItemPoly[index - 1] < e.Y &&myPol.hItemPoly[index] >= e.Y)
                {
                    num1 = index - 1;
                    break;
                }
            }
            if (num1 == 0)
            {
                int num2 = (int)MessageBox.Show("Повторить выбор элемента","Новый символ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(this.myPol.fileAdd))
                    File.Delete(this.myPol.fileAdd);
                FileStream output = new FileStream(this.myPol.fileAdd, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(num1);
                binaryWriter.Close();
                output.Close();
                Form.ActiveForm.Close();
            }
        }

        private void Up_Click(object sender, EventArgs e)
        {
           yTolMax =myPol.hItemPoly[this.kItemPoly] +hItemMax;
            if (this.yTolMax <pixHei)
                return;
            for (int index = 1; index <=kItemPoly; ++index)
               myPol.hItemPoly[index] =myPol.hItemPoly[index] -hItemMax;
           panel1.Invalidate();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            if (this.myPol.hItemPoly[1] >yTolMin)
                return;
            for (int index = 1; index <=kItemPoly; ++index)
               myPol.hItemPoly[index] =myPol.hItemPoly[index] +hItemMax;
           panel1.Invalidate();
        }

        private void Quit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();
    }
}

