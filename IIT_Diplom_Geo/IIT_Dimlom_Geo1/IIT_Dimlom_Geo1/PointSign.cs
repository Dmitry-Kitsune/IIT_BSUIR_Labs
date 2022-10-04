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
    public partial class PointSign : Form
    {
        private string sText = "";
        private string sDescr = "";
        private int iWidth;
        private int iHeight;
        private int pixWid;
        private int pixHei;
        private int kx;
        private int ky;
        private int kPxy;
        private int kSqu;
        private int kCell;
        private int nProcess;
        private int nControl;
        private int ixLine;
        private int iyLine;
        private int jxLine;
        private int jyLine;
        private int kPixel;
        private int ix1Grid;
        private int iy1Grid;
        private int ix2Grid;
        private int iy2Grid;
        private int ixBeg;
        private int iyBeg;
        private int mColor;
        private int iCond;
        private int kSpot;
        private int kAction;
        private int numLast;
        private int numUser;
        private int kMax;
        private int kLong;
        private int kSymbPnt;
        private int wSymbol;
        private int hSymbol;
        private int nSel;
        private int iLong;
        private double wSign;
        private double hSign;
        private double tText;
        private double sPixel = 0.254;
        private double x1Line;
        private double y1Line;
        private double x2Line;
        private double y2Line;
        private double xDown;
        private double yDown;
        private int kRect;
        private int rWid;
        private int rHei;
        private int iListShow = 1;
        private int nProblem;
        private bool isDrag;
        private Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        private Point startPoint;
        private Point endPoint;

        private char[] seps = new char[1] { '\\' };
        private string[] sPart = new string[50];
        private MyGeodesy myPoint = new MyGeodesy();
        public PointSign()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            pixWid = panel1.Bounds.Width;
            pixHei = panel1.Bounds.Height;
            if (pixWid <= pixHei)
                iWidth = iHeight = pixWid;
            if (pixWid > pixHei)
                iWidth = iHeight = pixHei;
            panel2.BorderStyle = StatusBarPanelBorderStyle.Raised;
            panel3.BorderStyle = StatusBarPanelBorderStyle.Raised;
            panel4.BorderStyle = StatusBarPanelBorderStyle.Raised;
            panel5.BorderStyle = StatusBarPanelBorderStyle.Raised;
            panel2.AutoSize = StatusBarPanelAutoSize.Contents;
            panel3.AutoSize = StatusBarPanelAutoSize.Contents;
            panel4.AutoSize = StatusBarPanelAutoSize.Contents;
            panel5.AutoSize = StatusBarPanelAutoSize.Contents;
            panel3.Text = "**";
            panel5.Text = "**";
            statusBar1.ShowPanels = true;
            statusBar1.Panels.Add(panel2);
            statusBar1.Panels.Add(panel3);
            statusBar1.Panels.Add(panel4);
            statusBar1.Panels.Add(panel5);
            Controls.Add((Control)statusBar1);
            groupBox2.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button9.Visible = false;
            radioButton1.Checked = true;
            label6.Visible = false;
            label7.Visible = false;
            label10.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox9.Visible = false;
            FormLoad();
        }
        public void FormLoad()
        {
            numLast = 0;
            myPoint.FilePath();
            DllClass1.SetColour(myPoint.brColor, myPoint.pnColor);
            kSymbPnt = 0;
            if (File.Exists(myPoint.fsymbPnt))
            {
                if (File.Exists(myPoint.fPointPixel))
                    File.Delete(myPoint.fPointPixel);
                FileStream output = new FileStream(myPoint.fPointPixel, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                FileStream input = new FileStream(myPoint.fsymbPnt, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    string str1;
                    while ((str1 = binaryReader.ReadString()) != null)
                    {
                        int int32 = Convert.ToInt32(str1);
                        if (int32 > numLast)
                            numLast = int32;
                        int num1 = binaryReader.ReadInt32();
                        binaryWriter.Write(str1);
                        binaryWriter.Write(num1);
                        if (num1 == 0)
                        {
                            int num2 = binaryReader.ReadInt32();
                            string str2 = binaryReader.ReadString();
                            double num3 = binaryReader.ReadDouble();
                            double num4 = binaryReader.ReadDouble();
                            int num5 = binaryReader.ReadInt32();
                            int num6 = binaryReader.ReadInt32();
                            int num7 = binaryReader.ReadInt32();
                            binaryWriter.Write(num2);
                            binaryWriter.Write(str2);
                            binaryWriter.Write(num3);
                            binaryWriter.Write(num4);
                            binaryWriter.Write(num5);
                            binaryWriter.Write(num6);
                            binaryWriter.Write(num7);
                            if (num7 > 0)
                            {
                                for (int index = 1; index <= num7; ++index)
                                {
                                    double num8 = binaryReader.ReadDouble();
                                    double num9 = binaryReader.ReadDouble();
                                    int num10 = binaryReader.ReadInt32();
                                    binaryWriter.Write(num8);
                                    binaryWriter.Write(num9);
                                    binaryWriter.Write(num10);
                                }
                            }
                            int num11 = binaryReader.ReadInt32();
                            binaryWriter.Write(num11);
                            if (num11 > 0)
                            {
                                for (int index = 1; index <= num11; ++index)
                                {
                                    int num12 = binaryReader.ReadInt32();
                                    int num13 = binaryReader.ReadInt32();
                                    int num14 = binaryReader.ReadInt32();
                                    binaryWriter.Write(num12);
                                    binaryWriter.Write(num13);
                                    binaryWriter.Write(num14);
                                }
                            }
                            ++kSymbPnt;
                            myPoint.heiSymb[kSymbPnt] = num6;
                            myPoint.numbUser[kSymbPnt] = num2;
                            myPoint.numLong[kSymbPnt] = num1;
                        }
                        if (num1 > 0)
                        {
                            int num15 = binaryReader.ReadInt32();
                            int num16 = binaryReader.ReadInt32();
                            string str3 = binaryReader.ReadString();
                            int num17 = binaryReader.ReadInt32();
                            string str4 = binaryReader.ReadString();
                            double num18 = binaryReader.ReadDouble();
                            double num19 = binaryReader.ReadDouble();
                            int num20 = binaryReader.ReadInt32();
                            int num21 = binaryReader.ReadInt32();
                            binaryWriter.Write(num15);
                            binaryWriter.Write(num16);
                            binaryWriter.Write(str3);
                            binaryWriter.Write(num17);
                            binaryWriter.Write(str4);
                            binaryWriter.Write(num18);
                            binaryWriter.Write(num19);
                            binaryWriter.Write(num20);
                            binaryWriter.Write(num21);
                            ++kSymbPnt;
                            myPoint.heiSymb[kSymbPnt] = num15;
                            myPoint.numbUser[kSymbPnt] = num17;
                            myPoint.numLong[kSymbPnt] = num1;
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
            if (kSymbPnt > 0)
                RectCoord(pixWid, pixHei, kSymbPnt, myPoint.heiSymb, out kRect, myPoint.nVert, myPoint.xVert, myPoint.yVert, out rWid, out rHei);
            nProblem = 1;
            if (File.Exists(myPoint.fProblem))
                File.Delete(myPoint.fProblem);
            FileStream output1 = new FileStream(myPoint.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
            binaryWriter1.Write(nProblem);
            binaryWriter1.Close();
            output1.Close();
            panel1.Invalidate();
        }

        public void RadioColor(ref int mColor)
        {
            mColor = 0;
            if (radioButton1.Checked)
                mColor = 1;
            if (radioButton2.Checked)
                mColor = 2;
            if (radioButton3.Checked)
                mColor = 3;
            if (radioButton4.Checked)
                mColor = 4;
            if (radioButton5.Checked)
                mColor = 5;
            if (radioButton6.Checked)
                mColor = 6;
            if (radioButton7.Checked)
                mColor = 7;
            if (radioButton8.Checked)
                mColor = 8;
            if (!radioButton9.Checked)
                return;
            mColor = 9;
        }
        private void SignCreation_Click(object sender, EventArgs e)
        {
            if (kMax == 2)
            {
                int num = (int)MessageBox.Show("Готово", "Создание символов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FormLoad();
                nProcess = 10;
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox1.Text = "3.0";
                textBox2.Text = "3.0";
                button9.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label10.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox9.Visible = true;
                textBox5.Text = string.Format("{0}", (object)(numLast + 1));
                textBox6.Text = "Не определено";
                textBox9.Text = string.Format("{0}", (object)(numLast + 1));
                label1.Text = "";
            }
        }

        private void ConfirmSymbol_Click(object sender, EventArgs e)
        {
            if (nProcess == 10)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    int num = (int)MessageBox.Show("Проверьте 'Ширину' и 'Высоту''", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox1.Text, out wSign, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox2.Text, out hSign, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (wSign < 0.5)
                {
                    int num = (int)MessageBox.Show("Ширина < 0.5 мм", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (wSign > 10.0)
                {
                    int num = (int)MessageBox.Show("Ширина > 10 мм", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (hSign < 0.5)
                {
                    int num = (int)MessageBox.Show("Высота < 0.5 мм", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (hSign > 10.0)
                {
                    int num = (int)MessageBox.Show("Высота > 10 мм", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (textBox5.Text == "")
                    textBox5.Text = "0";
                if (textBox6.Text == "")
                    textBox6.Text = "Не определено";
                DllClass1.CheckText(textBox5.Text, out tText, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                numUser = Convert.ToInt32(tText);
                sDescr = textBox6.Text;
                DllClass1.GridCreate(1, iWidth, iHeight, wSign, hSign, sPixel, out kx, myPoint.ixPix, out ky, myPoint.iyPix, out kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out ix1Grid, out iy1Grid, out ix2Grid, out iy2Grid, pixWid, pixHei);
                kSqu = 0;
                kPixel = 0;
                kAction = 0;
                int num1 = myPoint.ixPix[kx] - myPoint.ixPix[1];
                Convert.ToInt32(wSign / sPixel);
                int int32 = Convert.ToInt32(hSign / sPixel);
                ixBeg = ix2Grid - num1 / 2;
                iyBeg = iy2Grid + int32;
                groupBox2.Visible = true;
                nControl = 0;
            }
            if (nProcess == 20)
            {
                if (textBox9.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Обновление символов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox5.Text, out tText, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Обновление символов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string text = textBox9.Text;
                numUser = Convert.ToInt32(tText);
                sDescr = textBox6.Text;
                int num2 = 0;
                if (kSymbPnt > 0)
                {
                    for (int index = 1; index <= kSymbPnt; ++index)
                    {
                        if (myPoint.numbUser[index] > 0 && myPoint.numbUser[index] == numUser)
                        {
                            ++num2;
                            break;
                        }
                    }
                }
                if (num2 > 0 && MessageBox.Show("Дубликат кода пользователя. Вы хотите сохранить код пользователя ?", "Обновление символов", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    --numLast;
                    return;
                }
                DllClass1.SymbolUpdate(myPoint.fsymbPnt, myPoint.fPointPixel, kSymbPnt, nSel, text, iLong, numUser, sDescr);
                FormLoad();
                label2.Visible = false;
                label3.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button9.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label10.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox9.Visible = false;
                groupBox2.Visible = false;
                nProcess = 0;
                kSqu = kx = ky = 0;
                sText = "";
                label1.Text = "";
            }
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black, 1f);
            if ((nProcess == 0 || nProcess == 10 || nProcess == 20) && iListShow > 0)
                SymbPntDraw(e, myPoint.fsymbPnt, kRect, myPoint.nVert, myPoint.xVert, myPoint.yVert, rWid, rHei, kSymbPnt, myPoint.numRec, myPoint.numbUser, myPoint.nWork1, myPoint.nWork2, myPoint.nWork, myPoint.brColor);
            if (nProcess != 10)
                return;
            DllClass1.GridDraw(e, kx, myPoint.ixPix, ky, myPoint.iyPix);
            if (nControl == 101 || nControl == 103 || nControl == 104)
            {
                DllClass1.DrawGrid(e, kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, myPoint.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, myPoint.brColor);
            }
            if (nControl == 102)
            {
                DllClass1.DrawGrid(e, kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, myPoint.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, myPoint.brColor);
            }
            if (nControl == 105 || nControl == 106 || nControl == 107)
            {
                DllClass1.DrawGrid(e, kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, myPoint.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, myPoint.brColor);
            }
            if (nControl == 108 || nControl == 109 || nControl == 111 || nControl == 112)
            {
                DllClass1.DrawGrid(e, kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, myPoint.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, myPoint.brColor);
            }
            if (nControl == 113 || nControl == 114 || nControl == 115 || nControl == 116 || nControl == 117 || nControl == 118 || nControl == 119 || nControl == 121)
            {
                DllClass1.DrawGrid(e, kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, myPoint.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, myPoint.brColor);
            }
            if (nControl != 122 && nControl != 123 && nControl != 124)
                return;
            DllClass1.DrawGrid(e, kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, myPoint.brColor);
            DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, myPoint.brColor);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (nProcess == 10)
            {
                if (nControl == 101 && e.Button == MouseButtons.Left)
                {
                    xDown = 1.0 * (double)e.X;
                    yDown = 1.0 * (double)e.Y;
                }
                if (nControl == 102 && e.Button == MouseButtons.Left)
                {
                    isDrag = true;
                    Control control = (Control)sender;
                    startPoint = control.PointToScreen(new Point(e.X, e.Y));
                    endPoint = control.PointToScreen(new Point(e.X, e.Y));
                }
            }
            if (nProcess != 20)
                return;
            if (e.Button == MouseButtons.Left)
            {
                xDown = 1.0 * (double)e.X;
                yDown = 1.0 * (double)e.Y;
            }
            label1.Text = "";
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            panel2.Text = string.Format("{0}", (object)e.X);
            panel4.Text = string.Format("{0}", (object)e.Y);
            if (nControl != 102 || e.Button != MouseButtons.Left || !isDrag)
                return;
            ControlPaint.DrawReversibleLine(startPoint, endPoint, BackColor);
            endPoint = PointToScreen(new Point(e.X, e.Y));
            ControlPaint.DrawReversibleLine(startPoint, endPoint, BackColor);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (nProcess == 10)
            {
                if (nControl == 101)
                {
                    DllClass1.GridChange(ref kSqu, ref myPoint.xSqu, ref myPoint.ySqu, ref myPoint.numCol, xDown, yDown, myPoint.nDat, out iCond);
                    if (iCond == 0)
                    {
                        RadioColor(ref mColor);
                        DllClass1.GridPoint(kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, xDown, yDown, out kCell, myPoint.xCell, myPoint.yCell);
                        if (kCell > 0)
                        {
                            for (int index = 1; index <= kCell; ++index)
                            {
                                ++kSqu;
                                myPoint.xSqu[kSqu] = myPoint.xCell[index];
                                myPoint.ySqu[kSqu] = myPoint.yCell[index];
                                myPoint.numCol[kSqu] = mColor;
                            }
                        }
                    }
                    if (kSqu > 0)
                    {
                        if (File.Exists(myPoint.fPointPixel))
                            File.Delete(myPoint.fPointPixel);
                        FileStream output = new FileStream(myPoint.fPointPixel, FileMode.CreateNew);
                        BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                        binaryWriter.Write(kSqu);
                        binaryWriter.Write(nControl);
                        for (int index = 1; index <= kSqu; ++index)
                        {
                            binaryWriter.Write(myPoint.xSqu[index]);
                            binaryWriter.Write(myPoint.ySqu[index]);
                            binaryWriter.Write(myPoint.numCol[index]);
                        }
                        binaryWriter.Close();
                        output.Close();
                        DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                    }
                    panel1.Invalidate();
                }
                if (nControl == 102)
                {
                    x1Line = 1.0 * (double)(startPoint.X - 18);
                    y1Line = 1.0 * (double)(startPoint.Y - 45);
                    x2Line = 1.0 * (double)(endPoint.X - 18);
                    y2Line = 1.0 * (double)(endPoint.Y - 45);
                    RadioColor(ref mColor);
                    DllClass1.GridLine(kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, x1Line, y1Line, x2Line, y2Line, out kCell, myPoint.xCell, myPoint.yCell, out iCond);
                    if (iCond < 0)
                        return;
                    if (kCell > 0)
                    {
                        for (int index = 1; index <= kCell; ++index)
                        {
                            ++kSqu;
                            myPoint.xSqu[kSqu] = myPoint.xCell[index];
                            myPoint.ySqu[kSqu] = myPoint.yCell[index];
                            myPoint.numCol[kSqu] = mColor;
                        }
                        ++kAction;
                        DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                    }
                    ixLine = startPoint.X - 18;
                    iyLine = startPoint.Y - 45;
                    jxLine = endPoint.X - 18;
                    jyLine = endPoint.Y - 45;
                    isDrag = false;
                    startPoint.X = 0;
                    startPoint.Y = 0;
                    endPoint.X = 0;
                    endPoint.Y = 0;
                    panel1.Invalidate();
                }
            }
            if (nProcess != 20)
                return;
            DllClass1.RectSelect(xDown, yDown, kRect, myPoint.nVert, myPoint.xVert, myPoint.yVert, rWid, rHei, out nSel);
            if (nSel == 0)
                return;
            string sOrder;
            string sUser;
            string sDescript;
            DllClass1.SymbolSelect(myPoint.fsymbPnt, nSel, out sOrder, out sUser, out sDescript, out iLong);
            if (sOrder == "")
            {
                nSel = kSymbPnt;
                if (nSel > 0)
                    DllClass1.SymbolSelect(myPoint.fsymbPnt, nSel, out sOrder, out sUser, out sDescript, out iLong);
            }
            label6.Visible = true;
            label7.Visible = true;
            label10.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox9.Visible = true;
            if (nProcess == 20)
                button9.Visible = true;
            textBox9.Text = sOrder;
            textBox5.Text = sUser;
            textBox6.Text = sDescript;
        }

        private void Handwork_Click(object sender, EventArgs e) => nControl = 101;

        private void Line_Click(object sender, EventArgs e) => nControl = 102;

        private void Rectangle_Click(object sender, EventArgs e)
        {
            nControl = 103;
            RadioColor(ref mColor);
            DllClass1.GridRectangle(1, kx, myPoint.ixPix, ky, myPoint.iyPix, out kCell, myPoint.xCell, myPoint.yCell);
            int kArray = 999999;
            DllClass1.doubleArray(myPoint.xSqu, ref kArray);
            DllClass1.doubleArray(myPoint.ySqu, ref kArray);
            DllClass1.intArray(myPoint.numCol, ref kArray);
            int num1 = kArray - 10;
            if (kCell > 0)
            {
                for (int index = 1; index <= kCell; ++index)
                {
                    ++kSqu;
                    if (kSqu > num1)
                    {
                        int num2 = (int)MessageBox.Show("Индекс массива FillRectangle");
                        return;
                    }
                    myPoint.xSqu[kSqu] = myPoint.xCell[index];
                    myPoint.ySqu[kSqu] = myPoint.yCell[index];
                    myPoint.numCol[kSqu] = mColor;
                }
                ++kAction;
                DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
            }
            panel1.Invalidate();
        }

        private void FillRectangle_Click(object sender, EventArgs e)
        {
            nControl = 104;
            RadioColor(ref mColor);
            DllClass1.GridRectangle(2, kx, myPoint.ixPix, ky, myPoint.iyPix, out kCell, myPoint.xCell, myPoint.yCell);
            int kArray = 999999;
            DllClass1.doubleArray(myPoint.xSqu, ref kArray);
            DllClass1.doubleArray(myPoint.ySqu, ref kArray);
            DllClass1.intArray(myPoint.numCol, ref kArray);
            int num1 = kArray - 10;
            if (kCell > 0)
            {
                for (int index = 1; index <= kCell; ++index)
                {
                    ++kSqu;
                    if (kSqu > num1)
                    {
                        int num2 = (int)MessageBox.Show("Индекс массива FillRectangle");
                        return;
                    }
                    myPoint.xSqu[kSqu] = myPoint.xCell[index];
                    myPoint.ySqu[kSqu] = myPoint.yCell[index];
                    myPoint.numCol[kSqu] = mColor;
                }
                ++kAction;
                DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
            }
            panel1.Invalidate();
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            nControl = 105;
            RadioColor(ref mColor);
            DllClass1.GridEllipse(1, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива Ellipse");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void FillEllipse_Click(object sender, EventArgs e)
        {
            nControl = 106;
            RadioColor(ref mColor);
            DllClass1.GridEllipse(2, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива FillEllipse");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void Concentric_Click(object sender, EventArgs e)
        {
            nControl = 107;
            RadioColor(ref mColor);
            DllClass1.ConcentricCircle(kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, myPoint.xDat, myPoint.yDat, out iCond);
            int kArray = 999999;
            DllClass1.doubleArray(myPoint.xSqu, ref kArray);
            DllClass1.doubleArray(myPoint.ySqu, ref kArray);
            DllClass1.intArray(myPoint.numCol, ref kArray);
            int num1 = kArray - 10;
            if (kCell > 0)
            {
                for (int index = 1; index <= kCell; ++index)
                {
                    ++kSqu;
                    if (kSqu > num1)
                    {
                        int num2 = (int)MessageBox.Show("Индекс массива Concentric");
                        return;
                    }
                    myPoint.xSqu[kSqu] = myPoint.xCell[index];
                    myPoint.ySqu[kSqu] = myPoint.yCell[index];
                    myPoint.numCol[kSqu] = mColor;
                }
                ++kAction;
                DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                if (iCond < 0)
                {
                    int num3 = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            panel1.Invalidate();
        }

        private void ArcLeft_Click(object sender, EventArgs e)
        {
            nControl = 108;
            RadioColor(ref mColor);
            DllClass1.GridArc(1, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива ArcLeft");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void ArcRight_Click(object sender, EventArgs e)
        {
            nControl = 109;
            RadioColor(ref mColor);
            DllClass1.GridArc(2, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива ArcRight");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void ArcTop_Click(object sender, EventArgs e)
        {
            nControl = 111;
            RadioColor(ref mColor);
            DllClass1.GridArc(3, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива ArcTop");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void ArcBottom_Click(object sender, EventArgs e)
        {
            nControl = 112;
            RadioColor(ref mColor);
            DllClass1.GridArc(4, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива ArcBottom");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleLeft_Click(object sender, EventArgs e)
        {
            nControl = 113;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(1, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива TriangleLeft");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void FillTriangleLeft_Click(object sender, EventArgs e)
        {
            nControl = 114;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(2, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива FillTriangleLeft");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleRight_Click(object sender, EventArgs e)
        {
            nControl = 115;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(3, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива TriangleRight");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void FillTriangleRight_Click(object sender, EventArgs e)
        {
            nControl = 116;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(4, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива FillTriangleRight");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleTop_Click(object sender, EventArgs e)
        {
            nControl = 117;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(5, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива TriangleTop");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void FillTriangleTop_Click(object sender, EventArgs e)
        {
            nControl = 118;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(6, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива FillTriangleTop");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleBottom_Click(object sender, EventArgs e)
        {
            nControl = 119;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(7, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива TriangleBottom");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void FillTriangleBottom_Click(object sender, EventArgs e)
        {
            nControl = 121;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(8, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива FillTriangleBottom");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void Hexagon_Click(object sender, EventArgs e)
        {
            nControl = 122;
            RadioColor(ref mColor);
            DllClass1.GridHexagon(1, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива FillHexagon");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void FillHexagon_Click(object sender, EventArgs e)
        {
            nControl = 123;
            RadioColor(ref mColor);
            DllClass1.GridHexagon(2, kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива FillHexagon");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void CircleTriangle_Click(object sender, EventArgs e)
        {
            nControl = 124;
            RadioColor(ref mColor);
            DllClass1.TriangleCircle(kx, myPoint.ixPix, ky, myPoint.iyPix, kPxy, myPoint.x1Pix, myPoint.y1Pix, myPoint.x2Pix, myPoint.y2Pix, out kCell, myPoint.xCell, myPoint.yCell, out kSpot, myPoint.xSpot, myPoint.ySpot, myPoint.xAngel, myPoint.yAngel, myPoint.xDat, myPoint.yDat, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myPoint.xSqu, ref kArray);
                DllClass1.doubleArray(myPoint.ySqu, ref kArray);
                DllClass1.intArray(myPoint.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Индекс массива FillHexagon");
                            return;
                        }
                        myPoint.xSqu[kSqu] = myPoint.xCell[index];
                        myPoint.ySqu[kSqu] = myPoint.yCell[index];
                        myPoint.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myPoint.xSqu, myPoint.ySqu, myPoint.numCol, out kPixel, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void KeepSymbol_Click(object sender, EventArgs e)
        {
            myPoint.FilePath();
            kLong = 0;
            ++numLast;
            wSymbol = Convert.ToInt32(wSign / sPixel);
            hSymbol = Convert.ToInt32(hSign / sPixel);
            string str = string.Format("{0}", (object)numLast);
            if (kLong == 0)
                numUser = Convert.ToInt32(textBox5.Text);
            int num = 0;
            if (kSymbPnt > 0)
            {
                for (int index = 1; index <= kSymbPnt; ++index)
                {
                    if (myPoint.numbUser[index] > 0 && myPoint.numbUser[index] == numUser)
                    {
                        ++num;
                        break;
                    }
                }
            }
            if (num > 0 && MessageBox.Show("Дубликат кода пользователя. Вы хотите сохранить код пользователя ?", "Обновление символов", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                --numLast;
            }
            else
            {
                FileStream output = new FileStream(myPoint.fsymbPnt, FileMode.Append, FileAccess.Write);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                try
                {
                    binaryWriter.Write(str);
                    binaryWriter.Write(kLong);
                    if (kLong == 0)
                    {
                        numUser = Convert.ToInt32(textBox5.Text);
                        sDescr = textBox6.Text;
                        binaryWriter.Write(numUser);
                        binaryWriter.Write(sDescr);
                        binaryWriter.Write(wSign);
                        binaryWriter.Write(hSign);
                        binaryWriter.Write(wSymbol);
                        binaryWriter.Write(hSymbol);
                        binaryWriter.Write(kSqu);
                        if (kSqu > 0)
                        {
                            for (int index = 1; index <= kSqu; ++index)
                            {
                                binaryWriter.Write(myPoint.xSqu[index]);
                                binaryWriter.Write(myPoint.ySqu[index]);
                                binaryWriter.Write(myPoint.numCol[index]);
                            }
                        }
                        binaryWriter.Write(kPixel);
                        if (kPixel > 0)
                        {
                            for (int index = 1; index <= kPixel; ++index)
                            {
                                binaryWriter.Write(myPoint.ixSqu[index]);
                                binaryWriter.Write(myPoint.iySqu[index]);
                                binaryWriter.Write(myPoint.nColor[index]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                }
                binaryWriter.Close();
                output.Close();
                FormLoad();
                label2.Visible = false;
                label3.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button9.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label10.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox9.Visible = false;
                groupBox2.Visible = false;
                for (int index = 1; index <= kRect; ++index)
                {
                    DllClass1.UpSign(kRect, myPoint.yVert, pixHei, out iCond);
                    if (iCond == 0)
                    {
                        iListShow = 1;
                        break;
                    }
                }
                nProcess = 0;
                kSqu = kx = ky = 0;
                sText = "";
                kPixel = 0;
                panel1.Invalidate();
            }
        }

        private void SymbolUpdate_Click(object sender, EventArgs e)
        {
            nProcess = 20;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label10.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox9.Visible = false;
            button9.Visible = false;
            groupBox2.Visible = false;
            nSel = 0;
            label1.Text = "Выделить символ с помощью мыши";
            panel1.Invalidate();
        }

        private void SymbolDelete_Click(object sender, EventArgs e)
        {
            for (int index = 1; index <= kRect; ++index)
            {
                DllClass1.UpSign(kRect, myPoint.yVert, pixHei, out iCond);
                if (iCond == 0)
                {
                    panel1.Invalidate();
                    break;
                }
            }
            if (MessageBox.Show("Вы действительно хотите удалить последний символ ?", "Создание символов точек", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                return;
            DllClass1.LastDelete(myPoint.fsymbPnt, myPoint.fPointPixel, ref kSymbPnt);
            FormLoad();
            if (kSymbPnt == 0)
                kRect = 0;
            if (kSymbPnt > 0)
            {
                for (int index = 1; index <= kRect; ++index)
                {
                    DllClass1.UpSign(kRect, myPoint.yVert, pixHei, out iCond);
                    if (iCond == 0)
                        break;
                }
            }
            nProcess = 0;
            kSqu = kx = ky = 0;
            sText = "";
            label6.Visible = false;
            label7.Visible = false;
            label10.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox9.Visible = false;
            button9.Visible = false;
            panel1.Invalidate();
        }

        public void RectCoord(
          int pixWid,
          int pixHei,
          int kSymbPnt,
          int[] hSymb,
          out int kRect,
          int[] nRect,
          double[] xRect,
          double[] yRect,
          out int idx,
          out int idy)
        {
            kRect = 0;
            idx = idy = 0;
            int num1 = 5;
            idx = 120;
            int num2 = 0;
            for (int index = 1; index <= kSymbPnt; ++index)
            {
                if (hSymb[index] > num2)
                    num2 = hSymb[index];
            }
            idy = num2 + num2 / 5;
            if (idy < 30)
                idy = 30;
            int num3 = 525 / idx;
            int num4 = 0;
            int num5 = -idy / 2;
            do
            {
                num5 += idy;
                int num6 = -idx + num1;
                for (int index = 1; index <= num3; ++index)
                {
                    ++num4;
                    num6 += idx;
                    ++kRect;
                    nRect[kRect] = num4;
                    xRect[kRect] = (double)num6;
                    yRect[kRect] = (double)num5;
                    if (num4 == kSymbPnt)
                        break;
                }
            }
            while (num4 != kSymbPnt && num4 < kSymbPnt);
        }

        public void SymbPntDraw(
          PaintEventArgs e,
          string fsymbPnt,
          int kRect,
          int[] nRect,
          double[] xRect,
          double[] yRect,
          int idx,
          int idy,
          int kSymbPnt,
          int[] nRec,
          int[] nUser,
          int[] ixp,
          int[] iyp,
          int[] nClr,
          SolidBrush[] brColor)
        {
            Graphics graphics = e.Graphics;
            string sDscr = "";
            int emSize = 8;
            Font font = new Font("Arial", (float)emSize);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Gray, 1f);
            for (int index1 = 1; index1 <= kRect; ++index1)
            {
                int index2 = nRect[index1];
                int nCodePnt = nUser[index2];
                int int32_1 = Convert.ToInt32(xRect[index2]);
                int int32_2 = Convert.ToInt32(yRect[index2]);
                string s = string.Format("{0}", (object)index2) + "-" + string.Format("{0}", (object)nCodePnt);
                graphics.DrawString(s, font, (Brush)solidBrush, (float)int32_1, (float)int32_2);
                int iLong;
                int iHei;
                int kPix;
                DllClass1.SelSymbPnt(fsymbPnt, nCodePnt, kSymbPnt, nRec, nUser, out iLong, out int _, out iHei, out sDscr, out kPix, ixp, iyp, nClr, out sText, out mColor);
                int ixh = int32_1 + idx / 2;
                int iyh = int32_2 + (idy - iHei) / 2 - 3;
                if (iLong == 0)
                    DllClass1.SignDraw(e, ixh, iyh, kPix, ixp, iyp, nClr, brColor);
                if (iLong > 0)
                    DllClass1.DrawText(e, sText, iHei, ixh, int32_2, mColor, brColor);
                graphics.DrawRectangle(pen, int32_1 - 1, int32_2 - emSize / 2, idx, idy);
            }
        }

        private void Close_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        private void Up_Click(object sender, EventArgs e)
        {
            DllClass1.UpSign(kRect, myPoint.yVert, pixHei, out iCond);
            panel1.Invalidate();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            DllClass1.DownSign(kRect, myPoint.yVert, out iCond);
            panel1.Invalidate();
        }

        private void MoreDetail_Click(object sender, EventArgs e)
        {
            int num1 = 200;
            if (File.Exists(myPoint.fileAdd))
                File.Delete(myPoint.fileAdd);
            FileStream output = new FileStream(myPoint.fileAdd, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(num1);
            binaryWriter.Close();
            output.Close();
            label1.Text = "";
            int num2 = (int)new ListPntSign().ShowDialog((IWin32Window)this);
        }

        private void ListOnOff_Click(object sender, EventArgs e)
        {
            iListShow = iListShow <= 0 ? 1 : 0;
            label1.Text = "";
            panel1.Invalidate();
        }
    }
}
