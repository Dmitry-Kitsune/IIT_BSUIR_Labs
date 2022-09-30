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
    public partial class DoubtfulPnt : Form
    {
        private string sTmp = "";
        private string sTmp1 = "";
        private string sTmp2 = "";
        private string sTmp3 = "";
        private double xmin = 9999999.9;
        private double ymin = 9999999.9;
        private double xmax = -9999999.9;
        private double ymax = -9999999.9;
        private int kTar;
        private int kGeo;
        private int kContr;
        private int kCheck;
        private int kBlock;
        private int kChange;
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
        private int nProcess;
        private int nControl;
        private double dx;
        private double dy;
        private double xCur;
        private double yCur;
        private int x1Box;
        private int y1Box;
        private int x2Box;
        private int y2Box;
        private int iWidth;
        private int iHeight;
        private int kDat;
        private int[] xDat = new int[5];
        private int[] yDat = new int[5];
        private double dx1;
        private double dy1;
        private double dz1;
        private double dx2;
        private double dy2;
        private double dz2;
        private double rxy;
        private double rz;
        private int iCond;
        private int iww;
        private int ihh;
        private int iGraphic;

        private MyGeodesy mySub = new MyGeodesy();
        public DoubtfulPnt()
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
            kDat = 0;
            if (!File.Exists(mySub.tmpStr))
            {
                int num = (int)MessageBox.Show("Диск не определен", "Заполнить хранилище контрольных точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form.ActiveForm.Close();
            }
            else
            {
                if (!File.Exists(mySub.fileProj))
                    return;
                FileStream input = new FileStream(mySub.fileProj, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                sTmp = binaryReader.ReadString();
                mySub.curProject = binaryReader.ReadString();
                input.Close();
                binaryReader.Close();
                mySub.curDirect = "Proj" + sTmp;
                LoadData();
                DifControl();
            }
        }

        public void LoadData()
        {
            if (File.Exists(mySub.fileDoubt))
            {
                listBox1.Items.Clear();
                kChange = 0;
                FileStream input = new FileStream(mySub.fileDoubt, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kChange = binaryReader.ReadInt32();
                    for (int index = 1; index <= kChange; ++index)
                    {
                        mySub.nameChange[index] = binaryReader.ReadString();
                        mySub.xChange[index] = binaryReader.ReadDouble();
                        mySub.yChange[index] = binaryReader.ReadDouble();
                        mySub.zChange[index] = binaryReader.ReadDouble();
                        sTmp = mySub.nameChange[index];
                        sTmp1 = string.Format("{0:F3}", (object)mySub.xChange[index]);
                        sTmp2 = string.Format("{0:F3}", (object)mySub.yChange[index]);
                        sTmp3 = string.Format("{0:F3}", (object)mySub.zChange[index]);
                        sTmp = sTmp + "  " + sTmp1 + "  " + sTmp2 + "  " + sTmp3;
                        listBox1.Items.Add((object)sTmp);
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
                }
            }
            if (File.Exists(mySub.aeroBlock))
            {
                FileStream input = new FileStream(mySub.aeroBlock, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    kBlock = binaryReader.ReadInt32();
                    for (int index = 1; index <= kBlock; ++index)
                    {
                        mySub.blockName[index] = binaryReader.ReadString();
                        mySub.xBlock[index] = binaryReader.ReadDouble();
                        mySub.yBlock[index] = binaryReader.ReadDouble();
                        mySub.zBlock[index] = binaryReader.ReadDouble();
                        if (xmin > mySub.xBlock[index])
                            xmin = mySub.xBlock[index];
                        if (ymin > mySub.yBlock[index])
                            ymin = mySub.yBlock[index];
                        if (xmax < mySub.xBlock[index])
                            xmax = mySub.xBlock[index];
                        if (ymax < mySub.yBlock[index])
                            ymax = mySub.yBlock[index];
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
                }
            }
            if (File.Exists(mySub.fileGeo))
            {
                FileStream input = new FileStream(mySub.fileGeo, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kTar = binaryReader.ReadInt32();
                    for (int index = 1; index <= kTar; ++index)
                    {
                        mySub.tarName[index] = binaryReader.ReadString();
                        mySub.xTar[index] = binaryReader.ReadDouble();
                        mySub.yTar[index] = binaryReader.ReadDouble();
                        mySub.zTar[index] = binaryReader.ReadDouble();
                        if (xmin > mySub.xTar[index])
                            xmin = mySub.xTar[index];
                        if (ymin > mySub.yTar[index])
                            ymin = mySub.yTar[index];
                        if (xmax < mySub.xTar[index])
                            xmax = mySub.xTar[index];
                        if (ymax < mySub.yTar[index])
                            ymax = mySub.yTar[index];
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
            xminCur = xmin;
            yminCur = ymin;
            xmaxCur = xmax;
            ymaxCur = ymax;
            DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond >= 0)
                return;
            iGraphic = 1;
        }

        public void DifControl()
        {
            int kGeo = 0;
            int kFin = 0;
            if (File.Exists(mySub.aeroBlock))
            {
                FileStream input = new FileStream(mySub.aeroBlock, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    kFin = binaryReader.ReadInt32();
                    for (int index = 1; index <= kFin; ++index)
                    {
                        mySub.blockName[index] = binaryReader.ReadString();
                        mySub.xBlock[index] = binaryReader.ReadDouble();
                        mySub.yBlock[index] = binaryReader.ReadDouble();
                        mySub.zBlock[index] = binaryReader.ReadDouble();
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
            if (!File.Exists(mySub.curControl))
                return;
            FileStream input1 = new FileStream(mySub.curControl, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader1 = new BinaryReader((Stream)input1);
            try
            {
                kGeo = binaryReader1.ReadInt32();
                for (int index = 1; index <= kGeo; ++index)
                {
                    mySub.nameContr[index] = binaryReader1.ReadString();
                    mySub.xContr[index] = binaryReader1.ReadDouble();
                    mySub.yContr[index] = binaryReader1.ReadDouble();
                    mySub.zContr[index] = binaryReader1.ReadDouble();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
            }
            finally
            {
                input1.Close();
                binaryReader1.Close();
            }
            int kDif;
            DllClass1.DifCoord(kGeo, mySub.nameContr, mySub.xContr, mySub.yContr, mySub.zContr, kFin, mySub.blockName, mySub.xBlock, mySub.yBlock, mySub.zBlock, out kDif, ref mySub.nameCheck, ref mySub.xBase, ref mySub.yBase, ref mySub.zBase, ref mySub.zCheck);
            if (kDif == 0)
                return;
            if (File.Exists(mySub.difControl))
                File.Delete(mySub.difControl);
            FileStream output = new FileStream(mySub.difControl, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(kDif);
            for (int index = 1; index <= kDif; ++index)
            {
                binaryWriter.Write(mySub.nameCheck[index]);
                binaryWriter.Write(mySub.xBase[index]);
                binaryWriter.Write(mySub.yBase[index]);
                binaryWriter.Write(mySub.zBase[index]);
            }
            binaryWriter.Close();
            output.Close();
        }

        public void DrawInterior(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int yWin;
            int xWin = yWin = 0;
            int emSize = 7;
            int num1 = iHeight - 45;
            double num2 = 0.0;
            double num3 = 0.0;
            int index1 = 0;
            if (File.Exists(mySub.difMeasure))
            {
                FileStream input = new FileStream(mySub.difMeasure, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    int num4;
                    while ((num4 = binaryReader.ReadInt32()) != 0)
                    {
                        if (num4 > 0)
                        {
                            binaryReader.ReadInt64();
                            binaryReader.ReadInt64();
                            for (int index2 = 1; index2 <= num4; ++index2)
                            {
                                string str = binaryReader.ReadString();
                                double num5 = binaryReader.ReadDouble();
                                double num6 = binaryReader.ReadDouble();
                                ++index1;
                                mySub.tarName[index1] = str;
                                mySub.xTar[index1] = num5;
                                mySub.yTar[index1] = num6;
                                num2 += Math.Abs(mySub.xTar[index1]);
                                num3 += Math.Abs(mySub.yTar[index1]);
                            }
                        }
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
            if (index1 == 0)
            {
                int num7 = (int)MessageBox.Show("Данные отсутствуют", "Внутренняя ориентация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nProcess = 0;
            }
            else
            {
                double num8 = num2 / (double)index1;
                double num9 = num3 / (double)index1;
                double num10 = num8;
                if (num9 < num8)
                    num10 = num9;
                int num11 = 0;
                if (File.Exists(mySub.aeroBlock))
                {
                    FileStream input = new FileStream(mySub.aeroBlock, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        num11 = binaryReader.ReadInt32();
                        for (int index3 = 1; index3 <= num11; ++index3)
                        {
                            mySub.blockName[index3] = binaryReader.ReadString();
                            mySub.xBlock[index3] = binaryReader.ReadDouble();
                            mySub.yBlock[index3] = binaryReader.ReadDouble();
                            mySub.zBlock[index3] = binaryReader.ReadDouble();
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
                if (num11 <= 0)
                {
                    nProcess = 0;
                }
                else
                {
                    int num12 = 0;
                    for (int index4 = 1; index4 <= index1; ++index4)
                    {
                        for (int index5 = 1; index5 <= num11; ++index5)
                        {
                            if (mySub.tarName[index4] == mySub.blockName[index5])
                            {
                                DllClass1.XYtoWIN(mySub.xBlock[index5], mySub.yBlock[index5], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                                if (xWin != 0 || yWin != 0)
                                {
                                    graphics.FillRectangle((Brush)new SolidBrush(Color.Black), xWin, yWin, 2, 2);
                                    int x = xWin + 2;
                                    int y = yWin - emSize;
                                    graphics.DrawString(mySub.tarName[index4], new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Blue), (float)x, (float)y);
                                    int num13 = 0;
                                    if (Math.Abs(mySub.xTar[index4]) > 3.0 * num10)
                                    {
                                        ++num13;
                                        ++num12;
                                    }
                                    string s1 = string.Format("{0:F3}", (object)mySub.xTar[index4]);
                                    int num14 = y + emSize;
                                    if (num13 == 0)
                                        graphics.DrawString(s1, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Black), (float)x, (float)(num14 + 1));
                                    if (num13 > 0)
                                        graphics.DrawString(s1, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num14 + 1));
                                    int num15 = 0;
                                    if (Math.Abs(mySub.yTar[index4]) > 3.0 * num10)
                                    {
                                        ++num15;
                                        ++num12;
                                    }
                                    string s2 = string.Format("{0:F3}", (object)mySub.yTar[index4]);
                                    int num16 = num14 + emSize;
                                    if (num15 == 0)
                                        graphics.DrawString(s2, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Black), (float)x, (float)(num16 + 1));
                                    if (num15 > 0)
                                    {
                                        graphics.DrawString(s2, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num16 + 1));
                                        break;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    if (num12 <= 0)
                        return;
                    graphics.DrawString("Голубой цвет -- Значение погрешностей", new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Cyan), 450f, (float)(num1 - emSize / 2));
                }
            }
        }

        public void DrawRelative(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int yWin;
            int xWin = yWin = 0;
            int emSize = 7;
            int num1 = iHeight - 45;
            int index1 = 0;
            int num2 = 0;
            if (File.Exists(mySub.aeroBlock))
            {
                FileStream input = new FileStream(mySub.aeroBlock, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    num2 = binaryReader.ReadInt32();
                    for (int index2 = 1; index2 <= num2; ++index2)
                    {
                        mySub.blockName[index2] = binaryReader.ReadString();
                        mySub.xBlock[index2] = binaryReader.ReadDouble();
                        mySub.yBlock[index2] = binaryReader.ReadDouble();
                        mySub.zBlock[index2] = binaryReader.ReadDouble();
                        string str1 = mySub.blockName[index2];
                        if (str1.IndexOf('-') > -1)
                        {
                            string str2 = str1.Trim('-');
                            ++index1;
                            mySub.numPhoto[index1] = Convert.ToInt32(str2);
                            mySub.xsPhoto[index1] = mySub.xBlock[index2];
                            mySub.ysPhoto[index1] = mySub.yBlock[index2];
                        }
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
            if (num2 <= 0)
            {
                nProcess = 0;
            }
            else
            {
                int index3 = 0;
                if (File.Exists(mySub.frelOrient))
                {
                    FileStream input = new FileStream(mySub.frelOrient, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        while (binaryReader.ReadInt64() != 0L)
                        {
                            int num3 = binaryReader.ReadInt32();
                            int num4 = binaryReader.ReadInt32();
                            binaryReader.ReadDouble();
                            binaryReader.ReadDouble();
                            binaryReader.ReadDouble();
                            binaryReader.ReadDouble();
                            binaryReader.ReadDouble();
                            double num5 = binaryReader.ReadDouble();
                            double num6 = binaryReader.ReadDouble();
                            binaryReader.ReadDouble();
                            binaryReader.ReadDouble();
                            binaryReader.ReadDouble();
                            int num7 = binaryReader.ReadInt32();
                            for (int index4 = 1; index4 <= num7; ++index4)
                            {
                                mySub.pntName[index4] = binaryReader.ReadString();
                                mySub.xLeft[index4] = binaryReader.ReadDouble();
                                mySub.yLeft[index4] = binaryReader.ReadDouble();
                                mySub.xRight[index4] = binaryReader.ReadDouble();
                                mySub.yRight[index4] = binaryReader.ReadDouble();
                            }
                            ++index3;
                            mySub.modLeft[index3] = num3;
                            mySub.modRight[index3] = num4;
                            mySub.xBase[index3] = num5;
                            mySub.yBase[index3] = num6;
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
                for (int index5 = 2; index5 <= index1; ++index5)
                {
                    int num8 = mySub.numPhoto[index5 - 1];
                    int num9 = mySub.numPhoto[index5];
                    for (int index6 = 1; index6 <= index3; ++index6)
                    {
                        if (mySub.modLeft[index6] == num8 && mySub.modRight[index6] == num9)
                        {
                            DllClass1.XYtoWIN(0.5 * (mySub.xsPhoto[index5 - 1] + mySub.xsPhoto[index5]), 0.5 * (mySub.ysPhoto[index5 - 1] + mySub.ysPhoto[index5]), scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                            if (xWin != 0 || yWin != 0)
                            {
                                string s1 = string.Format("{0:F3}", (object)mySub.xBase[index6]);
                                graphics.DrawString(s1, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Red), (float)xWin, (float)(yWin + 1));
                                string s2 = string.Format("{0:F3}", (object)mySub.yBase[index6]);
                                graphics.DrawString(s2, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Blue), (float)xWin, (float)(yWin + emSize + emSize / 2));
                                break;
                            }
                        }
                    }
                }
                graphics.DrawString("Красный-RSME до, Синий - после коррекции Y - параллакса", new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Black), 10f, (float)(num1 - emSize / 2));
            }
        }

        public void DrawModelStrip(out int iCond, int iParam, PaintEventArgs e)
        {
            iCond = 0;
            int emSize1 = 7;
            Graphics graphics = e.Graphics;
            int index1 = 0;
            double num1 = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            if (iParam == 1 && File.Exists(mySub.difModel))
            {
                FileStream input = new FileStream(mySub.difModel, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    while (binaryReader.ReadInt64() != 0L)
                    {
                        binaryReader.ReadInt64();
                        int num4 = binaryReader.ReadInt32();
                        if (num4 > 0)
                        {
                            for (int index2 = 1; index2 <= num4; ++index2)
                            {
                                string str = binaryReader.ReadString();
                                double num5 = binaryReader.ReadDouble();
                                double num6 = binaryReader.ReadDouble();
                                double num7 = binaryReader.ReadDouble();
                                ++index1;
                                mySub.tarName[index1] = str;
                                mySub.xTar[index1] = num5;
                                mySub.yTar[index1] = num6;
                                mySub.zTar[index1] = num7;
                                num1 += Math.Abs(num5);
                                num2 += Math.Abs(num6);
                                num3 += Math.Abs(num7);
                            }
                        }
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
            if (iParam == 2 && File.Exists(mySub.difStrip))
            {
                FileStream input = new FileStream(mySub.difStrip, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    while (binaryReader.ReadString() != null)
                    {
                        binaryReader.ReadString();
                        int num8 = binaryReader.ReadInt32();
                        if (num8 > 0)
                        {
                            for (int index3 = 1; index3 <= num8; ++index3)
                            {
                                string str = binaryReader.ReadString();
                                double num9 = binaryReader.ReadDouble();
                                double num10 = binaryReader.ReadDouble();
                                double num11 = binaryReader.ReadDouble();
                                ++index1;
                                mySub.tarName[index1] = str;
                                mySub.xTar[index1] = num9;
                                mySub.yTar[index1] = num10;
                                mySub.zTar[index1] = num11;
                                num1 += Math.Abs(num9);
                                num2 += Math.Abs(num10);
                                num3 += Math.Abs(num11);
                            }
                        }
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
            if (index1 == 0)
            {
                if (iParam == 1)
                {
                    iCond = -1;
                    return;
                }
                if (iParam == 2)
                {
                    iCond = -1;
                    return;
                }
            }
            double num12 = num1 / (double)index1;
            double num13 = num2 / (double)index1;
            double num14 = num3 / (double)index1;
            double num15 = num12;
            if (num13 < num12)
                num15 = num13;
            int num16 = -1;
            if (File.Exists(mySub.aeroBlock))
            {
                FileStream input = new FileStream(mySub.aeroBlock, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    num16 = binaryReader.ReadInt32();
                    for (int index4 = 1; index4 <= num16; ++index4)
                    {
                        mySub.blockName[index4] = binaryReader.ReadString();
                        mySub.xBlock[index4] = binaryReader.ReadDouble();
                        mySub.yBlock[index4] = binaryReader.ReadDouble();
                        mySub.zBlock[index4] = binaryReader.ReadDouble();
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
            if (num16 <= 0)
            {
                iCond = -1;
            }
            else
            {
                int num17 = 0;
                for (int index5 = 1; index5 <= index1; ++index5)
                {
                    for (int index6 = 1; index6 <= num16; ++index6)
                    {
                        if (mySub.tarName[index5] == mySub.blockName[index6])
                        {
                            int xWin;
                            int yWin;
                            DllClass1.XYtoWIN(mySub.xBlock[index6], mySub.yBlock[index6], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                            if (xWin != 0 || yWin != 0)
                            {
                                graphics.FillRectangle((Brush)new SolidBrush(Color.Black), xWin, yWin, 2, 2);
                                int x = xWin + 2;
                                int y = yWin - emSize1;
                                graphics.DrawString(mySub.tarName[index5], new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Black), (float)x, (float)y);
                                int num18 = 0;
                                if (Math.Abs(mySub.xTar[index5]) > 0.005 && Math.Abs(mySub.xTar[index5]) > 3.0 * num15)
                                {
                                    ++num18;
                                    ++num17;
                                }
                                string s1 = string.Format("{0:F3}", (object)mySub.xTar[index5]);
                                int num19 = y + emSize1;
                                if (num18 == 0)
                                    graphics.DrawString(s1, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Blue), (float)x, (float)(num19 + 1));
                                if (num18 > 0)
                                    graphics.DrawString(s1, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Red), (float)x, (float)(num19 + 1));
                                int num20 = 0;
                                if (Math.Abs(mySub.yTar[index5]) > 0.005 && Math.Abs(mySub.yTar[index5]) > 3.0 * num15)
                                {
                                    ++num20;
                                    ++num17;
                                }
                                string s2 = string.Format("{0:F3}", (object)mySub.yTar[index5]);
                                int num21 = num19 + emSize1;
                                if (num20 == 0)
                                    graphics.DrawString(s2, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Blue), (float)x, (float)(num21 + 1));
                                if (num20 > 0)
                                    graphics.DrawString(s2, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Red), (float)x, (float)(num21 + 1));
                                int num22 = 0;
                                if (Math.Abs(mySub.zTar[index5]) > 0.005 && Math.Abs(mySub.zTar[index5]) > 3.0 * num15)
                                {
                                    ++num22;
                                    ++num17;
                                }
                                string s3 = string.Format("{0:F3}", (object)mySub.zTar[index5]);
                                int num23 = num21 + emSize1;
                                if (num22 == 0)
                                    graphics.DrawString(s3, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Blue), (float)x, (float)(num23 + 1));
                                if (num22 > 0)
                                {
                                    graphics.DrawString(s3, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Red), (float)x, (float)(num23 + 1));
                                    break;
                                }
                                break;
                            }
                        }
                    }
                }
                int num24 = ihh - 20;
                int emSize2 = 8;
                graphics.DrawString("Средний :  ", new Font("Bold", (float)emSize2), (Brush)new SolidBrush(Color.Black), 20f, (float)(num24 - emSize2 / 2));
                string s4 = "DX = " + string.Format("{0:F3}", (object)num12);
                graphics.DrawString(s4, new Font("Bold", (float)emSize2), (Brush)new SolidBrush(Color.Black), 90f, (float)(num24 - emSize2 / 2));
                string s5 = "DY = " + string.Format("{0:F3}", (object)num13);
                graphics.DrawString(s5, new Font("Bold", (float)emSize2), (Brush)new SolidBrush(Color.Black), 160f, (float)(num24 - emSize2 / 2));
                string s6 = "DZ = " + string.Format("{0:F3}", (object)num14);
                graphics.DrawString(s6, new Font("Bold", (float)emSize2), (Brush)new SolidBrush(Color.Black), 230f, (float)(num24 - emSize2 / 2));
                if (num17 <= 0)
                    return;
                graphics.DrawString("Красный цвет -- Значение погрешностей", new Font("Bold", (float)emSize2), (Brush)new SolidBrush(Color.Red), 450f, (float)(num24 - emSize2 / 2));
            }
        }

        public void LoadControl()
        {
            kContr = 0;
            dx1 = 0.0;
            dy1 = 0.0;
            dz1 = 0.0;
            rxy = 0.0;
            rz = 0.0;
            if (File.Exists(mySub.difTarget))
            {
                FileStream input = new FileStream(mySub.difTarget, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kContr = binaryReader.ReadInt32();
                    if (kContr > 0)
                    {
                        for (int index = 1; index <= kContr; ++index)
                        {
                            mySub.nameContr[index] = binaryReader.ReadString();
                            mySub.xContr[index] = binaryReader.ReadDouble();
                            mySub.yContr[index] = binaryReader.ReadDouble();
                            mySub.zContr[index] = binaryReader.ReadDouble();
                            if (mySub.xContr[index] != 0.0 && mySub.yContr[index] != 0.0 && mySub.zContr[index] != 0.0)
                            {
                                dx1 += Math.Abs(mySub.xContr[index]);
                                dy1 += Math.Abs(mySub.yContr[index]);
                                dz1 += Math.Abs(mySub.zContr[index]);
                                ++rxy;
                                ++rz;
                            }
                            if (mySub.xContr[index] != 0.0 && mySub.yContr[index] != 0.0 && mySub.zContr[index] == 0.0)
                            {
                                dx1 += Math.Abs(mySub.xContr[index]);
                                dy1 += Math.Abs(mySub.yContr[index]);
                                ++rxy;
                            }
                            if (mySub.xContr[index] == 0.0 && mySub.yContr[index] == 0.0 && mySub.zContr[index] != 0.0)
                            {
                                dz1 += Math.Abs(mySub.zContr[index]);
                                ++rz;
                            }
                        }
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
                dx1 /= rxy;
                dy1 /= rxy;
                dz1 /= rz;
            }
            kCheck = 0;
            dx2 = 0.0;
            dy2 = 0.0;
            dz2 = 0.0;
            rxy = 0.0;
            rz = 0.0;
            if (!File.Exists(mySub.difControl))
                return;
            FileStream input1 = new FileStream(mySub.difControl, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader1 = new BinaryReader((Stream)input1);
            try
            {
                kCheck = binaryReader1.ReadInt32();
                if (kCheck > 0)
                {
                    for (int index = 1; index <= kCheck; ++index)
                    {
                        mySub.nameCheck[index] = binaryReader1.ReadString();
                        mySub.xCheck[index] = binaryReader1.ReadDouble();
                        mySub.yCheck[index] = binaryReader1.ReadDouble();
                        mySub.zCheck[index] = binaryReader1.ReadDouble();
                        if (mySub.xCheck[index] != 0.0 && mySub.yCheck[index] != 0.0 && mySub.zCheck[index] != 0.0)
                        {
                            dx2 += Math.Abs(mySub.xCheck[index]);
                            dy2 += Math.Abs(mySub.yCheck[index]);
                            dz2 += Math.Abs(mySub.zCheck[index]);
                            ++rxy;
                            ++rz;
                        }
                        if (mySub.xCheck[index] != 0.0 && mySub.yCheck[index] != 0.0 && mySub.zCheck[index] == 0.0)
                        {
                            dx2 += Math.Abs(mySub.xCheck[index]);
                            dy2 += Math.Abs(mySub.yCheck[index]);
                            ++rxy;
                        }
                        if (mySub.xCheck[index] == 0.0 && mySub.yCheck[index] == 0.0 && mySub.zCheck[index] != 0.0)
                        {
                            dz2 += Math.Abs(mySub.zCheck[index]);
                            ++rz;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
            }
            finally
            {
                input1.Close();
                binaryReader1.Close();
            }
            dx2 /= rxy;
            dy2 /= rxy;
            dz2 /= rz;
        }

        public void DrawGeo(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int xWin = 0;
            int yWin = 0;
            int emSize = 7;
            int num1 = 6;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            for (int index1 = 1; index1 <= kTar; ++index1)
            {
                if (mySub.xTar[index1] != 0.0 && mySub.yTar[index1] != 0.0 && mySub.zTar[index1] != 0.0)
                {
                    DllClass1.XYtoWIN(mySub.xTar[index1], mySub.yTar[index1], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                    if (xWin != 0 || yWin != 0)
                    {
                        ++num2;
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Red), xWin - num1 / 2, yWin - num1 / 2, num1, num1);
                        graphics.DrawString(mySub.tarName[index1], new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Black), (float)(xWin + emSize / 2), (float)(yWin - emSize));
                    }
                }
                else if (mySub.zTar[index1] == 0.0)
                {
                    DllClass1.XYtoWIN(mySub.xTar[index1], mySub.yTar[index1], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                    if (xWin != 0 || yWin != 0)
                    {
                        ++num3;
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Blue), xWin - num1 / 2, yWin - num1 / 2, num1, num1);
                        graphics.DrawString(mySub.tarName[index1], new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Black), (float)(xWin + emSize / 2), (float)(yWin - emSize));
                    }
                }
                else if (mySub.xTar[index1] == 0.0 && mySub.yTar[index1] == 0.0 && mySub.zTar[index1] != 0.0 && kBlock > 0)
                {
                    for (int index2 = 1; index2 <= kBlock; ++index2)
                    {
                        if (mySub.blockName[index2] == mySub.tarName[index1])
                        {
                            DllClass1.XYtoWIN(mySub.xBlock[index2], mySub.yBlock[index2], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                            if (xWin != 0 || yWin != 0)
                            {
                                ++num4;
                                graphics.FillRectangle((Brush)new SolidBrush(Color.Green), xWin - num1 / 2, yWin - num1 / 2, num1, num1);
                                graphics.DrawString(mySub.tarName[index1], new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Black), (float)(xWin + emSize / 2), (float)(yWin - emSize));
                                break;
                            }
                        }
                    }
                }
            }
            int y = ihh - 20;
            if (num2 > 0)
            {
                graphics.FillRectangle((Brush)new SolidBrush(Color.Red), 10, y, num1, num1);
                graphics.DrawString(" - X Y Z", new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Red), 14f, (float)(y - emSize / 2));
            }
            if (num3 > 0)
            {
                graphics.FillRectangle((Brush)new SolidBrush(Color.Blue), 70, y, num1, num1);
                graphics.DrawString(" - X Y", new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Blue), 74f, (float)(y - emSize / 2));
            }
            if (num4 <= 0)
                return;
            graphics.FillRectangle((Brush)new SolidBrush(Color.Green), 130, y, num1, num1);
            graphics.DrawString(" - Z", new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Green), 134f, (float)(y - emSize / 2));
        }

        public void DrawContrCheck(int iParam, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int xWin = 0;
            int yWin = 0;
            int emSize = 7;
            int num1 = 6;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            if (iParam == 1)
            {
                kGeo = kContr;
                for (int index = 1; index <= kContr; ++index)
                {
                    mySub.geoName[index] = mySub.nameContr[index];
                    mySub.xGeo[index] = mySub.xContr[index];
                    mySub.yGeo[index] = mySub.yContr[index];
                    mySub.zGeo[index] = mySub.zContr[index];
                }
                num6 = dx1;
                num7 = dy1;
                num8 = dz1;
            }
            if (iParam == 2)
            {
                kGeo = kCheck;
                for (int index = 1; index <= kCheck; ++index)
                {
                    mySub.geoName[index] = mySub.nameCheck[index];
                    mySub.xGeo[index] = mySub.xCheck[index];
                    mySub.yGeo[index] = mySub.yCheck[index];
                    mySub.zGeo[index] = mySub.zCheck[index];
                }
                num6 = dx2;
                num7 = dy2;
                num8 = dz2;
            }
            for (int index1 = 1; index1 <= kGeo; ++index1)
            {
                for (int index2 = 1; index2 <= kBlock; ++index2)
                {
                    if (mySub.geoName[index1] == mySub.blockName[index2])
                    {
                        DllClass1.XYtoWIN(mySub.xBlock[index2], mySub.yBlock[index2], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                        if (xWin != 0 || yWin != 0)
                        {
                            if (mySub.xGeo[index1] != 0.0 && mySub.yGeo[index1] != 0.0 && mySub.zGeo[index1] != 0.0)
                            {
                                ++num2;
                                graphics.FillRectangle((Brush)new SolidBrush(Color.Red), xWin - num1 / 2, yWin - num1 / 2, num1, num1);
                                int x = xWin + emSize / 2;
                                int y = yWin - emSize;
                                graphics.DrawString(mySub.geoName[index1], new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Red), (float)x, (float)y);
                                int num9 = 0;
                                if (Math.Abs(mySub.xGeo[index1]) > 3.0 * num6)
                                {
                                    ++num9;
                                    ++num5;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.xGeo[index1]);
                                int num10 = y + emSize;
                                if (num9 == 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Red), (float)x, (float)(num10 + 1));
                                if (num9 > 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num10 + 1));
                                int num11 = 0;
                                if (Math.Abs(mySub.yGeo[index1]) > 3.0 * num7)
                                {
                                    ++num11;
                                    ++num5;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.yGeo[index1]);
                                int num12 = num10 + emSize;
                                if (num11 == 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Red), (float)x, (float)(num12 + 1));
                                if (num11 > 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num12 + 1));
                                int num13 = 0;
                                if (Math.Abs(mySub.zGeo[index1]) > 3.0 * num8)
                                {
                                    ++num13;
                                    ++num5;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.zGeo[index1]);
                                int num14 = num12 + emSize;
                                if (num13 == 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Red), (float)x, (float)(num14 + 1));
                                if (num13 > 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num14 + 1));
                            }
                            else if (mySub.zGeo[index1] == 0.0)
                            {
                                ++num3;
                                graphics.FillRectangle((Brush)new SolidBrush(Color.Blue), xWin - num1 / 2, yWin - num1 / 2, num1, num1);
                                int x = xWin + emSize / 2;
                                int y = yWin - emSize;
                                graphics.DrawString(mySub.geoName[index1], new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Blue), (float)x, (float)y);
                                int num15 = 0;
                                if (Math.Abs(mySub.xGeo[index1]) > 3.0 * num6)
                                {
                                    ++num15;
                                    ++num5;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.xGeo[index1]);
                                int num16 = y + emSize;
                                if (num15 == 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Blue), (float)x, (float)(num16 + 1));
                                if (num15 > 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num16 + 1));
                                int num17 = 0;
                                if (Math.Abs(mySub.yGeo[index1]) > 3.0 * num7)
                                {
                                    ++num17;
                                    ++num5;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.yGeo[index1]);
                                int num18 = num16 + emSize;
                                if (num17 == 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Blue), (float)x, (float)(num18 + 1));
                                if (num17 > 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num18 + 1));
                            }
                            else if (mySub.xGeo[index1] == 0.0 && mySub.yGeo[index1] == 0.0 && mySub.zGeo[index1] != 0.0)
                            {
                                ++num4;
                                graphics.FillRectangle((Brush)new SolidBrush(Color.Green), xWin - num1 / 2, yWin - num1 / 2, num1, num1);
                                int x = xWin + emSize / 2;
                                int y = yWin - emSize;
                                graphics.DrawString(mySub.geoName[index1], new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Green), (float)x, (float)y);
                                int num19 = 0;
                                if (Math.Abs(mySub.zGeo[index1]) > 3.0 * num8)
                                {
                                    ++num19;
                                    ++num5;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.zGeo[index1]);
                                int num20 = y + emSize;
                                if (num19 == 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Green), (float)x, (float)(num20 + 1));
                                if (num19 > 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num20 + 1));
                            }
                        }
                    }
                }
            }
            if (iParam == 1 && kContr == 0 || iParam == 2 && kCheck == 0)
                return;
            int num21 = ihh - 20;
            graphics.DrawString("Средний :  ", new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Black), 20f, (float)(num21 - emSize / 2));
            sTmp = string.Format("{0:F3}", (object)num6);
            sTmp = "DX = " + sTmp;
            graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Red), 90f, (float)(num21 - emSize / 2));
            sTmp = string.Format("{0:F3}", (object)num7);
            sTmp = "DY = " + sTmp;
            graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Blue), 160f, (float)(num21 - emSize / 2));
            sTmp = string.Format("{0:F3}", (object)num8);
            sTmp = "DZ = " + sTmp;
            graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Green), 230f, (float)(num21 - emSize / 2));
            if (num5 <= 0)
                return;
            graphics.DrawString("Голубой цвет -- Значение погрешностей", new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Cyan), 450f, (float)(num21 - emSize / 2));
        }

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

        private void WithPoints_Click(object sender, EventArgs e)
        {
            if (File.Exists(mySub.fileDoubt))
                File.Delete(mySub.fileDoubt);
            FileStream output = new FileStream(mySub.fileDoubt, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            nProcess = 500;
            binaryWriter.Write(nProcess);
            output.Close();
            binaryWriter.Close();
            Form.ActiveForm.Close();
        }

        private void WithoutPoints_Click(object sender, EventArgs e)
        {
            if (File.Exists(mySub.fileGeo))
            {
                FileStream input = new FileStream(mySub.fileGeo, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kGeo = binaryReader.ReadInt32();
                    for (int index = 1; index <= kGeo; ++index)
                    {
                        mySub.geoName[index] = binaryReader.ReadString();
                        mySub.xGeo[index] = binaryReader.ReadDouble();
                        mySub.yGeo[index] = binaryReader.ReadDouble();
                        mySub.zGeo[index] = binaryReader.ReadDouble();
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
                if (kChange > 0)
                {
                    int index1 = 0;
                    for (int index2 = 1; index2 <= kGeo; ++index2)
                    {
                        int num = 0;
                        for (int index3 = 1; index3 <= kChange; ++index3)
                        {
                            if (mySub.nameChange[index3] == mySub.geoName[index2])
                            {
                                ++num;
                                break;
                            }
                        }
                        if (num <= 0)
                        {
                            ++index1;
                            mySub.geoName[index1] = mySub.geoName[index2];
                            mySub.xGeo[index1] = mySub.xGeo[index2];
                            mySub.yGeo[index1] = mySub.yGeo[index2];
                            mySub.zGeo[index1] = mySub.zGeo[index2];
                        }
                    }
                    kGeo = index1;
                    if (File.Exists(mySub.fileGeo))
                        File.Delete(mySub.fileGeo);
                    FileStream output1 = new FileStream(mySub.fileGeo, FileMode.CreateNew);
                    BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                    binaryWriter1.Write(kGeo);
                    for (int index4 = 1; index4 <= kGeo; ++index4)
                    {
                        binaryWriter1.Write(mySub.geoName[index4]);
                        binaryWriter1.Write(mySub.xGeo[index4]);
                        binaryWriter1.Write(mySub.yGeo[index4]);
                        binaryWriter1.Write(mySub.zGeo[index4]);
                    }
                    binaryWriter1.Close();
                    output1.Close();
                    if (File.Exists(mySub.fallGeo))
                        File.Delete(mySub.fallGeo);
                    FileStream output2 = new FileStream(mySub.fallGeo, FileMode.CreateNew);
                    BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                    binaryWriter2.Write(kGeo);
                    for (int index5 = 1; index5 <= kGeo; ++index5)
                    {
                        binaryWriter2.Write(mySub.geoName[index5]);
                        binaryWriter2.Write(mySub.xGeo[index5]);
                        binaryWriter2.Write(mySub.yGeo[index5]);
                        binaryWriter2.Write(mySub.zGeo[index5]);
                    }
                    binaryWriter2.Close();
                    output2.Close();
                }
            }
            if (File.Exists(mySub.fileDoubt))
                File.Delete(mySub.fileDoubt);
            FileStream output = new FileStream(mySub.fileDoubt, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            nProcess = 600;
            binaryWriter.Write(nProcess);
            output.Close();
            binaryWriter.Close();
            Form.ActiveForm.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (iGraphic > 0)
                return;
            int xWin = 0;
            int yWin = 0;
            int emSize = 7;
            int y = ihh - 20;
            if (kBlock > 0)
            {
                for (int index = 1; index <= kBlock; ++index)
                {
                    DllClass1.XYtoWIN(mySub.xBlock[index], mySub.yBlock[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                    if ((xWin != 0 || yWin != 0) && mySub.blockName[index].IndexOf('-') > -1)
                    {
                        sTmp = mySub.blockName[index].Trim('-');
                        graphics.DrawRectangle(new Pen(Color.Brown), xWin - 3, yWin - 3, 6, 6);
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Brown), xWin, yWin, 2, 2);
                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Brown), (float)(xWin + 3), (float)(yWin - 4));
                    }
                }
                graphics.DrawRectangle(new Pen(Color.Brown), 300, y, 6, 6);
                graphics.FillRectangle((Brush)new SolidBrush(Color.Brown), 303, y + 3, 2, 2);
                graphics.DrawString(" - Центр аэрофотосъемки", new Font("Bold", (float)emSize), (Brush)new SolidBrush(Color.Brown), 304f, (float)(y - emSize / 2));
            }
            if (nProcess == 0 || nProcess == 220)
                DrawGeo(e);
            if (nProcess == 160)
                DrawInterior(e);
            if (nProcess == 170)
                DrawRelative(e);
            if (nProcess == 180)
            {
                DrawModelStrip(out iCond, 1, e);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Данные отсутствуют", "Соединение моделей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nProcess = 0;
                    LoadData();
                    return;
                }
            }
            if (nProcess == 190)
            {
                DrawModelStrip(out iCond, 2, e);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Данные отсутствуют", "Соединение полос(линий)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nProcess = 0;
                    LoadData();
                    return;
                }
            }
            if (nProcess == 200)
                DrawContrCheck(1, e);
            if (nProcess == 210)
                DrawContrCheck(2, e);
            if (nControl != 10)
                return;
            graphics.DrawRectangle(new Pen(Color.Green, 2f), RcDraw);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x1Box = e.X;
            y1Box = e.Y;
            RcDraw.X = e.X;
            RcDraw.Y = e.Y;
            RcBox.X = e.X;
            RcBox.Y = e.Y;
            DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
            if (nControl == 10)
            {
                ++kDat;
                xDat[kDat] = e.X;
                yDat[kDat] = e.Y;
            }
            if (nControl == 20)
            {
                kDat = 0;
                double x1 = xCur - 0.4 * (xEndX - xBegX);
                double y1 = yCur - 0.4 * (yEndY - yBegY);
                double x2 = xCur + 0.4 * (xEndX - xBegX);
                double y2 = yCur + 0.4 * (yEndY - yBegY);
                xminCur = x1;
                yminCur = y1;
                xmaxCur = x2;
                ymaxCur = y2;
                DllClass1.CoorWin(x1, y1, x2, y2, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                if (iCond < 0)
                    iGraphic = 1;
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
                DllClass1.CoorWin(x1, y1, x2, y2, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                if (iCond < 0)
                    iGraphic = 1;
                panel1.Invalidate();
            }
            if (e.Button != MouseButtons.Right)
                return;
            xminCur = xmin;
            yminCur = ymin;
            xmaxCur = xmax;
            ymaxCur = ymax;
            DllClass1.CoorWin(xminCur, yminCur, xmaxCur, ymaxCur, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond < 0)
                iGraphic = 1;
            kDat = 0;
            panel1.Invalidate();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
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
            DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur1, out yCur1);
            DllClass1.WINtoXY(x2Box, y2Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur2, out yCur2);
            dx = xCur2 - xCur1;
            dy = yCur2 - yCur1;
            xaCur = xminCur - dx;
            yaCur = yminCur - dy;
            xbCur = xmaxCur - dx;
            ybCur = ymaxCur - dy;
            DllClass1.CoorWin(xaCur, yaCur, xbCur, ybCur, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond < 0)
                iGraphic = 1;
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
                DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur1, out yCur1);
                DllClass1.WINtoXY(x2Box, y2Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur2, out yCur2);
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
                DllClass1.CoorWin(xCur1, yCur1, xCur2, yCur2, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
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
            kDat = 0;
            xminCur = xaCur;
            yminCur = yaCur;
            xmaxCur = xbCur;
            ymaxCur = ybCur;
        }

        private void Cancel_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        private void InteriorOrient_Click(object sender, EventArgs e)
        {
            nProcess = 160;
            panel1.Invalidate();
        }

        private void RelativeOrient_Click(object sender, EventArgs e)
        {
            nProcess = 170;
            panel1.Invalidate();
        }

        private void ModelsJoin_Click(object sender, EventArgs e)
        {
            nProcess = 180;
            if (iCond < 0)
            {
                int num = (int)MessageBox.Show("Данные отсутствуют", "Соединение моделей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nProcess = 0;
                LoadData();
            }
            else
                panel1.Invalidate();
        }

        private void StripsJoin_Click(object sender, EventArgs e)
        {
            nProcess = 190;
            if (iCond < 0)
            {
                int num = (int)MessageBox.Show("Данные отсутствуют", "Соединение полос(линий)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nProcess = 0;
                LoadData();
            }
            else
                panel1.Invalidate();
        }

        private void ControlPoints_Click(object sender, EventArgs e)
        {
            nProcess = 200;
            LoadControl();
            if (kContr == 0)
            {
                int num = (int)MessageBox.Show("Данные отсутствуют", "Контрольные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nProcess = 0;
                LoadData();
            }
            else
                panel1.Invalidate();
        }

        private void CheckPoints_Click(object sender, EventArgs e)
        {
            nProcess = 210;
            LoadControl();
            if (kCheck == 0)
            {
                int num = (int)MessageBox.Show("Данные отсутствуют", "Контрольные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nProcess = 0;
                LoadData();
            }
            else
                panel1.Invalidate();
        }

        private void Original_Click(object sender, EventArgs e)
        {
            nProcess = 220;
            LoadData();
            panel1.Invalidate();
        }

    }
}
