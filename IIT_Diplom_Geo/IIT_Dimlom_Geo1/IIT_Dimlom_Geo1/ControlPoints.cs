using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DiplomGeoDLL;
using IIT_Diplom_Geo1;

namespace IIT_Dimlom_Geo1
{
    public partial class ControlPoints : Form
    {

        private string sTmp = "";
        private int kTar;
        private int indx;
        private double xmin = 9999999.9;
        private double ymin = 9999999.9;
        private double xmax = -9999999.9;
        private double ymax = -9999999.9;
        private string[] sPart;
        private double scaleToWin;
        private double scaleToGeo;
        private double xBegX;
        private double yBegY;
        private double xEndX;
        private double yEndY;
        private int xBegWin;
        private int yBegWin;
        private int xEndWin;
        private int yEndWin;
        private double xminCur;
        private double yminCur;
        private double xmaxCur;
        private double ymaxCur;
        private double xaCur;
        private double yaCur;
        private double xbCur;
        private double ybCur;
        private double xCur;
        private double yCur;
        private int nControl;
        private string pName = "";
        private double xx;
        private double yy;
        private double zz;
        private double dx;
        private double dy;
        private double dz;
        private double dr;
        private double ds = 0.01;
        private int x1Box;
        private int y1Box;
        private int x2Box;
        private int y2Box;
        private int iWidth;
        private int iHeight;
        private int iww;
        private int ihh;
        private int kDat;
        private int[] xDat = new int[1000];
        private int[] yDat = new int[1000];
        private int iCond;
        private int iGraphic;
        private Rectangle RcDraw;
        private Rectangle RcBox;
        private Rectangle RcBox1;
        private Rectangle RcBox2;
        private Rectangle RcBox3;
        private Rectangle RcBox4;
        private MyGeodesy mySub = new MyGeodesy();
        
        public ControlPoints()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            iww = panel1.Bounds.Width;
            ihh = panel1.Bounds.Height;
            if (iww <= ihh)
                iWidth = iHeight = iww;
            if (iww > ihh)
                iWidth = iHeight = ihh;
            Form_Load();
        }

        private void Form_Load()
        {
            mySub.FilePath();
            if (!File.Exists(mySub.tmpStr))
            {
                int num = (int)MessageBox.Show("Drive wasn't defined", "Fill up Control Points Store", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form.ActiveForm.Close();
            }
            if (!File.Exists(mySub.fstoreGeo))
                return;
            int index1 = 0;
            FileStream input = new FileStream(mySub.fstoreGeo, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader((Stream)input);
            try
            {
                listBox1.Sorted = true;
                kTar = binaryReader.ReadInt32();
                for (int index2 = 1; index2 <= kTar; ++index2)
                {
                    mySub.tarName[index2] = binaryReader.ReadString();
                    mySub.xTar[index2] = binaryReader.ReadDouble();
                    mySub.yTar[index2] = binaryReader.ReadDouble();
                    mySub.zTar[index2] = binaryReader.ReadDouble();
                    if (xmin > mySub.xTar[index2])
                        xmin = mySub.xTar[index2];
                    if (ymin > mySub.yTar[index2])
                        ymin = mySub.yTar[index2];
                    if (xmax < mySub.xTar[index2])
                        xmax = mySub.xTar[index2];
                    if (ymax < mySub.yTar[index2])
                        ymax = mySub.yTar[index2];
                    sTmp = mySub.tarName[index2] + "  " + string.Format("{0:F2}", (object)mySub.xTar[index2]) + "  " + string.Format("{0:F2}", (object)(mySub.yTar[index2].ToString() + "  " + string.Format("{0:F2}", (object)mySub.zTar[index2])));
                    listBox1.Items.Add((object)sTmp);
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
            xminCur = xmin;
            yminCur = ymin;
            xmaxCur = xmax;
            ymaxCur = ymax;
            DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond < 0)
            {
                iGraphic = 1;
            }
            else
            {
                if (kTar > 1)
                {
                    for (int index3 = 1; index3 < kTar; ++index3)
                    {
                        for (int index4 = index3 + 1; index4 <= kTar; ++index4)
                        {
                            if (mySub.tarName[index3] == mySub.tarName[index4])
                            {
                                ++index1;
                                mySub.nameGeo[index1] = mySub.tarName[index4];
                            }
                        }
                    }
                }
                if (index1 <= 0)
                    return;
                sTmp = "";
                for (int index5 = 1; index5 <= index1; ++index5)
                {
                    sTmp += mySub.nameGeo[index5];
                    if (index5 < index1)
                        sTmp += ",";
                }
                int num = (int)MessageBox.Show(sTmp, "Duplicate Points", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int xWin = 0;
            int yWin = 0;
            int emSize = 7;
            int num1 = 6;
            int num2 = 0;
            int num3 = 0;
            if (iGraphic > 0)
                return;
            if (nControl == 10)
                graphics.DrawRectangle(new Pen(Color.Green, 2f), RcDraw);
            for (int index = 1; index <= kTar; ++index)
            {
                DllClass1.XYtoWIN(mySub.xTar[index], mySub.yTar[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                {
                    if (mySub.xTar[index] != 0.0 && mySub.yTar[index] != 0.0 && mySub.zTar[index] != 0.0)
                    {
                        ++num2;
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Red), xWin, yWin, num1, num1);
                        graphics.DrawString(mySub.tarName[index], new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Black), (float)(xWin + emSize), (float)(yWin - emSize / 2));
                    }
                    else if (mySub.zTar[index] == 0.0)
                    {
                        ++num3;
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Blue), xWin, yWin, num1, num1);
                        graphics.DrawString(mySub.tarName[index], new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Black), (float)(xWin + emSize), (float)(yWin - emSize / 2));
                    }
                }
            }
            int y = iHeight - 45;
            if (num2 > 0)
            {
                graphics.FillRectangle((Brush)new SolidBrush(Color.Red), 10, y, num1, num1);
                graphics.DrawString(" - X Y Z", new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Red), 14f, (float)(y - emSize / 2));
            }
            if (num3 <= 0)
                return;
            graphics.FillRectangle((Brush)new SolidBrush(Color.Blue), 70, y, num1, num1);
            graphics.DrawString(" - X Y", new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Blue), 74f, (float)(y - emSize / 2));
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x1Box = e.X;
            y1Box = e.Y;
            RcDraw.X = e.X;
            RcDraw.Y = e.Y;
            RcBox.X = e.X;
            RcBox.Y = e.Y;
            DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo,
                xBegX, yBegY, xBegWin, yBegWin,
                out xCur, out yCur);
            if (nControl == 10)
            {
                ++kDat;
                xDat[kDat] = e.X;
                yDat[kDat] = e.Y;
            }
            if (nControl == 20)
            {
                kDat = 0;
                double x1 = xCur - 0.2 * (xEndX - xBegX);
                double y1 = yCur - 0.2 * (yEndY - yBegY);
                double x2 = xCur + 0.2 * (xEndX - xBegX);
                double y2 = yCur + 0.2 * (yEndY - yBegY);
                xminCur = x1;
                yminCur = y1;
                xmaxCur = x2;
                ymaxCur = y2;
                DllClass1.CoorWin(x1, y1, x2, y2, iWidth, iHeight,
                    out scaleToWin, out scaleToGeo, out xBegX,
                    out yBegY, out xEndX, out yEndY, out xBegWin,
                    out yBegWin, out xEndWin, out yEndWin, out iCond);
                if (iCond < 0)
                {
                    iGraphic = 1;
                    return;
                }
                panel1.Invalidate();
            }
            if (nControl == 30)
            {
                kDat = 0;
                double num1 = xCur - 0.5 * (xEndX - xBegX);
                double num2 = yCur - 0.5 * (yEndY - yBegY);
                double num3 = xCur + 0.5 * (xEndX - xBegX);
                double num4 = yCur + 0.5 * (yEndY - yBegY);
                double x1 = num1 - 0.2 * (xEndX - xBegX);
                double y1 = num2 - 0.2 * (yEndY - yBegY);
                double x2 = num3 + 0.2 * (xEndX - xBegX);
                double y2 = num4 + 0.2 * (yEndY - yBegY);
                xminCur = x1;
                yminCur = y1;
                xmaxCur = x2;
                ymaxCur = y2;
                DllClass1.CoorWin(x1, y1, x2, y2, iWidth, iHeight, 
                    out scaleToWin, out scaleToGeo, out xBegX, 
                    out yBegY, out xEndX, out yEndY, out xBegWin,
                    out yBegWin, out xEndWin, out yEndWin, out iCond);
                if (iCond < 0)
                {
                    iGraphic = 1;
                    return;
                }
                panel1.Invalidate();
            }
            if (e.Button != MouseButtons.Right)
                return;
            xminCur = xmin;
            yminCur = ymin;
            xmaxCur = xmax;
            ymaxCur = ymax;
            DllClass1.CoorWin(xminCur, yminCur, xmaxCur, ymaxCur,
                iWidth, iHeight, out scaleToWin, out scaleToGeo,
                out xBegX, out yBegY, out xEndX, out yEndY,
                out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            kDat = 0;
            if (iCond < 0)
                iGraphic = 1;
            else
                panel1.Invalidate();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY,
                xBegWin, yBegWin, out xCur, out yCur);
            textBox1.Text = string.Format("{0:F3}", (object)xCur);
            textBox2.Text = string.Format("{0:F3}", (object)yCur);
            if (nControl == 10 && e.Button == MouseButtons.Left)
            {
                if (e.X < RcBox.X)
                {
                    RcDraw.Width = RcBox.X - e.X;
                    RcDraw.X = e.X;
                }
                else
                    RcDraw.Width = e.X - RcBox.X;
                if (e.Y < RcBox.Y)
                {
                    RcDraw.Height = RcBox.Y - e.Y;
                    RcDraw.Y = e.Y;
                }
                else
                    RcDraw.Height = e.Y - RcBox.Y;
                RcBox1.X = RcDraw.X - 100;
                RcBox1.Y = RcDraw.Y - 100;
                RcBox1.Width = 100;
                RcBox1.Height = RcDraw.Height + 200;
                RcBox2.X = RcDraw.X - 100;
                RcBox2.Y = RcDraw.Y - 100;
                RcBox2.Width = RcDraw.Width + 200;
                RcBox2.Height = 100;
                RcBox3.X = RcDraw.X - 100;
                RcBox3.Y = RcDraw.Y + RcDraw.Height;
                RcBox3.Width = RcDraw.Width + 100;
                RcBox3.Height = 100;
                RcBox4.X = RcDraw.X + RcDraw.Width;
                RcBox4.Y = RcDraw.Y - 100;
                RcBox4.Width = 100;
                RcBox4.Height = RcDraw.Height + 200;
                panel1.Invalidate(RcDraw);
                panel1.Invalidate(RcBox1);
                panel1.Invalidate(RcBox2);
                panel1.Invalidate(RcBox3);
                panel1.Invalidate(RcBox4);
            }
            if (nControl != 40)
                return;
            kDat = 0;
            if (e.Button != MouseButtons.Left)
                return;
            double xCur1 = 0.0;
            double yCur1 = 0.0;
            double xCur2 = 0.0;
            double yCur2 = 0.0;
            x2Box = e.X;
            y2Box = e.Y;
            DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, xBegX, 
                yBegY, xBegWin, yBegWin, out xCur1, out yCur1);
            DllClass1.WINtoXY(x2Box, y2Box, scaleToGeo, xBegX, 
                yBegY, xBegWin, yBegWin, out xCur2, out yCur2);
            dx = xCur2 - xCur1;
            dy = yCur2 - yCur1;
            xaCur = xminCur - dx;
            yaCur = yminCur - dy;
            xbCur = xmaxCur - dx;
            ybCur = ymaxCur - dy;
            DllClass1.CoorWin(xaCur, yaCur, xbCur, ybCur, iWidth, 
                iHeight, out scaleToWin, out scaleToGeo, out xBegX,
                out yBegY, out xEndX, out yEndY, out xBegWin, 
                out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond < 0)
                iGraphic = 1;
            else
                panel1.Invalidate();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            double xCur1 = 0.0;
            double yCur1 = 0.0;
            double xCur2 = 0.0;
            double yCur2 = 0.0;
            if (nControl == 10 && kDat > 0)
            {
                x1Box = RcDraw.X;
                y1Box = RcDraw.Y;
                x2Box = RcDraw.X + RcDraw.Width;
                y2Box = RcDraw.Y + RcDraw.Height;
                if (x1Box == x2Box || y1Box == y2Box)
                    return;
                DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, 
                    xBegX, yBegY, xBegWin, yBegWin, out xCur1, out yCur1);
                DllClass1.WINtoXY(x2Box, y2Box, scaleToGeo, 
                    xBegX, yBegY, xBegWin, yBegWin, out xCur2, out yCur2);
                if (xCur1 > xCur2)
                {
                    double num = xCur1;
                    xCur1 = xCur2;
                    xCur2 = num;
                }
                if (yCur1 > yCur2)
                {
                    double num = yCur1;
                    yCur1 = yCur2;
                    yCur2 = num;
                }
                xminCur = xCur1;
                yminCur = yCur1;
                xmaxCur = xCur2;
                ymaxCur = yCur2;
                DllClass1.CoorWin(xCur1, yCur1, xCur2, yCur2, 
                    iWidth, iHeight, out scaleToWin, 
                    out scaleToGeo, out xBegX, out yBegY, 
                    out xEndX, out yEndY, out xBegWin, 
                    out yBegWin, out xEndWin, out yEndWin, out iCond);
                if (iCond < 0)
                {
                    iGraphic = 1;
                    return;
                }
                RcDraw.X = 0;
                RcDraw.Y = 0;
                RcDraw.Height = 0;
                RcDraw.Width = 0;
                panel1.Invalidate();
                kDat = 0;
            }
            if (nControl != 40)
                return;
            xminCur = xaCur;
            yminCur = yaCur;
            xmaxCur = xbCur;
            ymaxCur = ybCur;
            kDat = 0;
        }

        private void Correct_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                int num = (int)MessageBox.Show("Point wasn't selected.", "Point's Correction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string sLine = listBox1.SelectedItem.ToString();
                int k = 0;
                int kPart = 50;
                char[] seps = new char[2] { ' ', ',' };
                DllClass1.ShareString(sLine, kPart, seps, out k, out sPart);
                if (k != 4)
                    return;
                textBox3.Text = sPart[1];
                textBox4.Text = sPart[2];
                textBox5.Text = sPart[3];
                textBox6.Text = sPart[4];
                pName = sPart[1];
                xx = Convert.ToDouble(sPart[2]);
                yy = Convert.ToDouble(sPart[3]);
                zz = Convert.ToDouble(sPart[4]);
            }
        }

        private void Input_Click(object sender, EventArgs e)
        {
            indx = listBox1.SelectedIndex + 1;
            if (indx <= 0 && textBox3.Text != "")
            {
                DllClass1.CheckText(textBox4.Text, out mySub.xTar[kTar], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "AeroTriangulation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox5.Text, out mySub.yTar[kTar], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "AeroTriangulation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox6.Text, out mySub.zTar[kTar], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "AeroTriangulation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ++kTar;
                mySub.tarName[kTar] = textBox3.Text;
            }
            if (indx > 0)
            {
                int index1 = 0;
                for (int index2 = 1; index2 <= kTar; ++index2)
                {
                    if (mySub.tarName[index2] == pName)
                    {
                        dx = mySub.xTar[index2] - xx;
                        dy = mySub.yTar[index2] - yy;
                        dz = mySub.zTar[index2] - zz;
                        dr = Math.Sqrt(dx * dx + dy * dy + dz * dz);
                        if (dr < ds)
                        {
                            index1 = index2;
                            break;
                        }
                    }
                }
                if (textBox3.Text != "")
                {
                    if (index1 > 0)
                    {
                        DllClass1.CheckText(textBox4.Text, out mySub.xTar[index1], out iCond);
                        if (iCond < 0)
                        {
                            int num = (int)MessageBox.Show("Check data", "AeroTriangulation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        DllClass1.CheckText(textBox5.Text, out mySub.yTar[index1], out iCond);
                        if (iCond < 0)
                        {
                            int num = (int)MessageBox.Show("Check data", "AeroTriangulation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        DllClass1.CheckText(textBox6.Text, out mySub.zTar[index1], out iCond);
                        if (iCond < 0)
                        {
                            int num = (int)MessageBox.Show("Check data", "AeroTriangulation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        mySub.tarName[index1] = textBox3.Text;
                    }
                }
            }
            try
            {
                if (File.Exists(mySub.fstoreGeo))
                    File.Delete(mySub.fstoreGeo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The Delete operation failed as expected.");
            }
            FileStream output = new FileStream(mySub.fstoreGeo, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            listBox1.Items.Clear();
            xmin = 9999999.9;
            ymin = 9999999.9;
            xmax = -9999999.9;
            ymax = -9999999.9;
            binaryWriter.Write(kTar);
            for (int index = 1; index <= kTar; ++index)
            {
                binaryWriter.Write(mySub.tarName[index]);
                binaryWriter.Write(mySub.xTar[index]);
                binaryWriter.Write(mySub.yTar[index]);
                binaryWriter.Write(mySub.zTar[index]);
                if (xmin > mySub.xTar[index])
                    xmin = mySub.xTar[index];
                if (ymin > mySub.yTar[index])
                    ymin = mySub.yTar[index];
                if (xmax < mySub.xTar[index])
                    xmax = mySub.xTar[index];
                if (ymax < mySub.yTar[index])
                    ymax = mySub.yTar[index];
                sTmp = mySub.tarName[index] + "  " + string.Format("{0:F2}", (object)mySub.xTar[index]) + "  " + string.Format("{0:F2}", (object)(mySub.yTar[index].ToString() + "  " + string.Format("{0:F2}", (object)mySub.zTar[index])));
                listBox1.Items.Add((object)sTmp);
            }
            output.Close();
            binaryWriter.Close();
            DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond < 0)
            {
                iGraphic = 1;
            }
            else
            {
                Invalidate();
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                int num1 = (int)MessageBox.Show("Point wasn't selected.", "Point's Correction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string sLine = listBox1.SelectedItem.ToString();
                int k = 0;
                int kPart = 50;
                char[] seps = new char[3] { ' ', ',', '\t' };
                DllClass1.ShareString(sLine, kPart, seps, out k, out sPart);
                if (k == 0)
                    return;
                pName = sPart[1];
                indx = listBox1.SelectedIndex + 1;
                if (indx <= 0)
                    return;
                int index1 = 0;
                int num2 = 0;
                for (int index2 = 1; index2 <= kTar; ++index2)
                {
                    if (mySub.tarName[index2] == pName)
                    {
                        num2 = index2;
                        break;
                    }
                }
                for (int index3 = 1; index3 <= kTar; ++index3)
                {
                    if (num2 != index3)
                    {
                        ++index1;
                        mySub.tarName[index1] = mySub.tarName[index3];
                        mySub.xTar[index1] = mySub.xTar[index3];
                        mySub.yTar[index1] = mySub.yTar[index3];
                        mySub.zTar[index1] = mySub.zTar[index3];
                    }
                }
                kTar = index1;
                try
                {
                    if (File.Exists(mySub.fstoreGeo))
                        File.Delete(mySub.fstoreGeo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The Delete operation failed as expected.");
                }
                FileStream output = new FileStream(mySub.fstoreGeo, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                listBox1.Items.Clear();
                xmin = 9999999.9;
                ymin = 9999999.9;
                xmax = -9999999.9;
                ymax = -9999999.9;
                binaryWriter.Write(kTar);
                for (int index4 = 1; index4 <= kTar; ++index4)
                {
                    binaryWriter.Write(mySub.tarName[index4]);
                    binaryWriter.Write(mySub.xTar[index4]);
                    binaryWriter.Write(mySub.yTar[index4]);
                    binaryWriter.Write(mySub.zTar[index4]);
                    if (xmin > mySub.xTar[index4])
                        xmin = mySub.xTar[index4];
                    if (ymin > mySub.yTar[index4])
                        ymin = mySub.yTar[index4];
                    if (xmax < mySub.xTar[index4])
                        xmax = mySub.xTar[index4];
                    if (ymax < mySub.yTar[index4])
                        ymax = mySub.yTar[index4];
                    sTmp = mySub.tarName[index4] + "  " + string.Format("{0:F2}", (object)mySub.xTar[index4]) + "  " + string.Format("{0:F2}", (object)(mySub.yTar[index4].ToString() + "  " + string.Format("{0:F2}", (object)mySub.zTar[index4])));
                    listBox1.Items.Add((object)sTmp);
                }
                output.Close();
                binaryWriter.Close();
                DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                if (iCond < 0)
                    iGraphic = 1;
                else
                    Invalidate();
            }
        }

        private void Quit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        private void SelectBox_Click(object sender, EventArgs e)
        {
            nControl = 10;
            kDat = 0;
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            nControl = 20;
            kDat = 0;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            nControl = 30;
            kDat = 0;
        }

        private void Move_Click(object sender, EventArgs e)
        {
            nControl = 40;
            kDat = 0;
        }

    }
}
