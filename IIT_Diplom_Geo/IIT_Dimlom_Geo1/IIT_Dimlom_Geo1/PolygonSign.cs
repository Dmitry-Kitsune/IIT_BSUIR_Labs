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

    public partial class PolygonSign : Form
    {
        private string sText = "";
        private int iWidth;
        private int iHeight;
        private int pixWid;
        private int pixHei;
        private int kPolySymb;
        private int kItemPoly;
        private int nProcess;
        private double wSign;
        private double hSign;
        private double sPixel = 0.254;
        private int iCond;
        private int kx;
        private int ky;
        private int kPxy;
        private int kSqu;
        private int kPixel;
        private int ix1Grid;
        private int iy1Grid;
        private int ix2Grid;
        private int iy2Grid;
        private int ixBeg;
        private int iyBeg;
        private int ixSymb = 310;
        private int iySymb = 410;
        private int nControl;
        private int hText;
        private int mColor;
        private double xDown;
        private double yDown;
        private int kCell;
        private double x1Line;
        private double y1Line;
        private double x2Line;
        private double y2Line;
        private int kAction;
        private int ixLine;
        private int iyLine;
        private int jxLine;
        private int jyLine;
        private int kLong;
        private int numLast;
        private int wSymbol;
        private int hSymbol;
        private int wItemMax;
        private int hItemMax;
        private int yBegin = 55;
        private int khItem;
        private int iLong;
        private int hSymbPoly;
        private int numSelect;
        private int nDensity;
        private int kSpot;
        private int kRectPoly;
        private int rWidPoly;
        private int rHeiPoly;
        private int kRectItem;
        private int rWidItem;
        private int rHeiItem;
        private int iListShow = 1;
        private int iListItemShow = 1;
        private int nProblem;
        private bool isDrag;
        private Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        private Point startPoint;
        private Point endPoint;

        private MyGeodesy mySig = new MyGeodesy();
        public PolygonSign()
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
            groupBox5.Visible = false;
            FormLoad();
        }
        private void FormLoad()
        {
            numLast = 0;
            mySig.FilePath();
            DllClass1.SetColour(mySig.brColor, mySig.pnColor);
            if (!File.Exists(mySig.fsymbPoly))
            {
                DllClass1.PolyDescription(out kPolySymb, mySig.sPolySymb, mySig.npSign1, mySig.npItem, mySig.npSign2, mySig.nBackCol, mySig.npTxtCol, mySig.hpFont, mySig.spInscr, mySig.nOneSymb);
                if (kPolySymb == 0)
                    return;
                DllClass1.PolySymbCoord(yBegin, hSymbPoly, kPolySymb, ref mySig.xpSign1, ref mySig.ypSign1, ref mySig.xpSymb, ref mySig.ypSymb, ref mySig.xpItem, ref mySig.ypItem, ref mySig.xpDescr, ref mySig.ypDescr, ref mySig.xpSign2, ref mySig.ypSign2);
                mySig.kPolySymb = kPolySymb;
                DllClass1.PolySymbolKeep(mySig.fsymbPoly, kPolySymb, hSymbPoly, mySig.sPolySymb, mySig.npSign1, mySig.xpSign1, mySig.ypSign1, mySig.xpSymb, mySig.ypSymb, mySig.npItem, mySig.xpItem, mySig.ypItem, mySig.xpDescr, mySig.ypDescr, mySig.npSign2, mySig.xpSign2, mySig.ypSign2, mySig.nBackCol, mySig.nOneSymb);
            }
            mySig.PolySymbolLoad(mySig.fsymbPoly, out kPolySymb, out hSymbPoly);
            kItemPoly = 0;
            if (File.Exists(mySig.fitemPoly))
            {
                int index1 = 1;
                int yBegin = this.yBegin;
                mySig.hItemPoly[1] = yBegin;
                if (File.Exists(mySig.fPolyPixel))
                    File.Delete(mySig.fPolyPixel);
                FileStream output = new FileStream(mySig.fPolyPixel, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                FileStream input = new FileStream(mySig.fitemPoly, FileMode.Open, FileAccess.Read);
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
                            ++kItemPoly;
                            mySig.numLong[kItemPoly] = num1;
                            ++index1;
                            if (num3 < 3.0)
                                yBegin += Convert.ToInt32(2.5 * (double)num5);
                            if (num3 >= 3.0 && num3 < 4.0)
                                yBegin += Convert.ToInt32(1.5 * (double)num5);
                            if (num3 >= 4.0)
                                yBegin += Convert.ToInt32(1.3 * (double)num5);
                            mySig.hItemPoly[index1] = yBegin;
                            if (num4 > wItemMax)
                                wItemMax = num4;
                            if (num5 > hItemMax)
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
                            ++kItemPoly;
                            mySig.numLong[kItemPoly] = num1;
                            ++index1;
                            yBegin += 3 * num15;
                            mySig.hItemPoly[index1] = yBegin;
                            if (num14 > wItemMax)
                                wItemMax = num14;
                            if (num15 > hItemMax)
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
            mySig.kItemPoly = kItemPoly;
            if (kItemPoly == 0)
                hItemMax = 10;
            khItem = kItemPoly + 1;
            mySig.hItemPoly[khItem] = mySig.hItemPoly[kItemPoly] + hItemMax + hItemMax / 3;
            hSymbPoly = hItemMax + 6;
            mySig.hSymbPoly = hSymbPoly;
            mySig.kPolySymb = kPolySymb;
            DllClass1.PolySymbolKeep(mySig.fsymbPoly, kPolySymb, hSymbPoly, mySig.sPolySymb, mySig.npSign1, mySig.xpSign1, mySig.ypSign1, mySig.xpSymb, mySig.ypSymb, mySig.npItem, mySig.xpItem, mySig.ypItem, mySig.xpDescr, mySig.ypDescr, mySig.npSign2, mySig.xpSign2, mySig.ypSign2, mySig.nBackCol, mySig.nOneSymb);
            RectPolySign(pixWid, pixHei, kPolySymb, hSymbPoly, out kRectPoly, mySig.nVert, mySig.xVert, mySig.yVert, out rWidPoly, out rHeiPoly);
            if (wItemMax < 20)
                wItemMax = 20;
            RectItemPoly(hItemMax, wItemMax, pixWid, pixHei, kItemPoly, out kRectItem, mySig.nParc, mySig.xParc, mySig.yParc, out rWidItem, out rHeiItem);
            nProblem = 3;
            if (File.Exists(mySig.fProblem))
                File.Delete(mySig.fProblem);
            FileStream output1 = new FileStream(mySig.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
            binaryWriter1.Write(nProblem);
            binaryWriter1.Close();
            output1.Close();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (kRectPoly > 0 && iListShow > 0)
                SymbPolyDraw(e, mySig.fitemPoly, kRectPoly, mySig.nVert, mySig.xVert, mySig.yVert, rWidPoly, rHeiPoly, kPolySymb, mySig.npSign2, mySig.nBackCol, mySig.npItem, mySig.nOneSymb, mySig.nWork1, mySig.nWork2, mySig.nColorItm, mySig.brColor, mySig.pnColor);
            if (kRectItem > 0 && iListItemShow > 0)
                ItemListDraw(e, mySig.fitemPoly, kRectItem, mySig.nParc, mySig.xParc, mySig.yParc, rWidItem, rHeiItem, mySig.nWork1, mySig.nWork2, mySig.nWork, mySig.brColor, mySig.pnColor);
            if (nProcess != 10)
                return;
            DllClass1.GridDraw(e, kx, mySig.ixPix, ky, mySig.iyPix);
            ixSymb = mySig.ixPix[1] - 2 * Convert.ToInt32(wSign / sPixel);
            if (hSign >= (double)hText)
                iySymb = mySig.iyPix[1];
            if (hSign < (double)hText)
                iySymb = mySig.iyPix[1] - Convert.ToInt32((double)hText / sPixel);
            if (nControl == 101)
            {
                DllClass1.DrawGrid(e, kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, mySig.brColor);
                ixSymb = 640;
                iySymb = 235;
                DllClass1.SignDraw(e, ixSymb, iySymb, kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, mySig.brColor);
            }
            if (nControl == 102)
            {
                DllClass1.DrawGrid(e, kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, mySig.brColor);
                ixSymb = 640;
                iySymb = 235;
                DllClass1.SignDraw(e, ixSymb, iySymb, kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, mySig.brColor);
            }
            if (nControl == 103 || nControl == 104)
            {
                DllClass1.DrawGrid(e, kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, mySig.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, mySig.brColor);
            }
            if (nControl == 105 || nControl == 106 || nControl == 107)
            {
                DllClass1.DrawGrid(e, kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, mySig.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, mySig.brColor);
            }
            if (nControl == 108 || nControl == 109 || nControl == 111 || nControl == 112)
            {
                DllClass1.DrawGrid(e, kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, mySig.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, mySig.brColor);
            }
            if (nControl == 113 || nControl == 114 || nControl == 115 || nControl == 116 || nControl == 117 || nControl == 118 || nControl == 119 || nControl == 121)
            {
                DllClass1.DrawGrid(e, kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, mySig.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, mySig.brColor);
            }
            if (nControl == 122 || nControl == 123 || nControl == 124)
            {
                DllClass1.DrawGrid(e, kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, mySig.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, mySig.brColor);
            }
            if (nControl != 125)
                return;
            DllClass1.DrawText(e, sText, hText, ixSymb, iySymb, mColor, mySig.brColor);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            CreateGraphics();
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
            if (nProcess != 20 && nProcess != 30)
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
                    DllClass1.GridChange(ref kSqu, ref mySig.xSqu, ref mySig.ySqu, ref mySig.numCol, xDown, yDown, mySig.nDat, out iCond);
                    if (iCond == 0)
                    {
                        RadioColor(ref mColor);
                        DllClass1.GridPoint(kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, xDown, yDown, out kCell, mySig.xCell, mySig.yCell);
                        if (kCell > 0)
                        {
                            for (int index = 1; index <= kCell; ++index)
                            {
                                ++kSqu;
                                mySig.xSqu[kSqu] = mySig.xCell[index];
                                mySig.ySqu[kSqu] = mySig.yCell[index];
                                mySig.numCol[kSqu] = mColor;
                            }
                        }
                    }
                    if (kSqu > 0)
                        DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                    panel1.Invalidate();
                }
                if (nControl == 102)
                {
                    x1Line = 1.0 * (double)(startPoint.X - 18);
                    y1Line = 1.0 * (double)(startPoint.Y - 45);
                    x2Line = 1.0 * (double)(endPoint.X - 18);
                    y2Line = 1.0 * (double)(endPoint.Y - 45);
                    RadioColor(ref mColor);
                    DllClass1.GridLine(kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, x1Line, y1Line, x2Line, y2Line, out kCell, mySig.xCell, mySig.yCell, out iCond);
                    if (iCond < 0)
                        return;
                    if (kCell > 0)
                    {
                        for (int index = 1; index <= kCell; ++index)
                        {
                            ++kSqu;
                            mySig.xSqu[kSqu] = mySig.xCell[index];
                            mySig.ySqu[kSqu] = mySig.yCell[index];
                            mySig.numCol[kSqu] = mColor;
                        }
                        ++kAction;
                        DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
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
            if (nProcess == 20)
            {
                int numRect = 0;
                int iWid = 0;
                int iHei = 0;
                int kPix = 0;
                iLong = 0;
                DllClass1.RectSelect(xDown, yDown, kRectItem, mySig.nParc, mySig.xParc, mySig.yParc, rWidItem, rHeiItem, out numRect);
                if (numRect == 0)
                    return;
                DllClass1.SelItemPoly(mySig.fitemPoly, numRect, out iLong, out iWid, out iHei, out kPix, mySig.ixSqu, mySig.iySqu, mySig.nColorItm, out sText, out mColor);
                groupBox5.Visible = true;
                radioButton19.Checked = true;
                textBox3.Text = string.Format("{0}", (object)(kPolySymb + 1));
                textBox4.Text = string.Format("{0}", (object)numRect);
                textBox5.Text = "Пользовательские описания";
            }
            if (nProcess != 30)
                return;
            int numRect1 = 0;
            numSelect = 0;
            iLong = 1;
            DllClass1.RectSelect(xDown, yDown, kRectPoly, mySig.nVert, mySig.xVert, mySig.yVert, rWidPoly, rHeiPoly, out numRect1);
            if (numRect1 == 0)
                return;
            numSelect = numRect1;
            groupBox5.Visible = true;
            radioButton19.Checked = true;
            nDensity = mySig.nOneSymb[numRect1];
            RadioDensity(2, ref nDensity);
            textBox3.Text = string.Format("{0}", (object)mySig.npSign2[numRect1]);
            textBox4.Text = string.Format("{0}", (object)mySig.npItem[numRect1]);
            textBox5.Text = mySig.sPolySymb[numRect1];
            if (mySig.spInscr[numRect1] == "abcd")
                iLong = 0;
            if (iLong <= 0)
                return;
            double num = mySig.hpFont[numRect1];
        }

        private void ItemCreation_Click(object sender, EventArgs e)
        {
            nProcess = 10;
            groupBox2.Visible = true;
            groupBox5.Visible = false;
            radioButton1.Checked = true;
            textBox1.Text = "4.0";
            textBox2.Text = "4.0";
            button4.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            button6.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            button26.Visible = false;
            button27.Visible = false;
        }

        private void ConfirmItem_Click(object sender, EventArgs e)
        {
            hText = 0;
            label1.Text = "";
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                int num1 = (int)MessageBox.Show("Проверьте 'Ширину' и 'Высоту''", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DllClass1.CheckText(textBox1.Text, out wSign, out iCond);
                if (iCond < 0)
                {
                    int num2 = (int)MessageBox.Show("Проверьте данные", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DllClass1.CheckText(textBox2.Text, out hSign, out iCond);
                    if (iCond < 0)
                    {
                        int num3 = (int)MessageBox.Show("Проверьте данные", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (wSign < 0.5)
                    {
                        int num4 = (int)MessageBox.Show("Ширина < 0.5 мм", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (wSign > 10.0)
                    {
                        int num5 = (int)MessageBox.Show("Ширина > 10 мм", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (hSign < 0.5)
                    {
                        int num6 = (int)MessageBox.Show("Высота < 0.5 мм", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (hSign > 5.0)
                    {
                        int num7 = (int)MessageBox.Show("Высота > 5 мм", "Создание сетки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        button4.Visible = true;
                        button5.Visible = true;
                        button7.Visible = true;
                        button8.Visible = true;
                        button6.Visible = true;
                        button14.Visible = true;
                        button15.Visible = true;
                        button16.Visible = true;
                        button17.Visible = true;
                        button18.Visible = true;
                        button19.Visible = true;
                        button20.Visible = true;
                        button21.Visible = true;
                        button22.Visible = true;
                        button23.Visible = true;
                        button24.Visible = true;
                        button25.Visible = true;
                        button26.Visible = true;
                        button27.Visible = true;
                        DllClass1.GridCreate(3, iWidth, iHeight, wSign, hSign, sPixel, out kx, mySig.ixPix, out ky, mySig.iyPix, out kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out ix1Grid, out iy1Grid, out ix2Grid, out iy2Grid, pixWid, pixHei);
                        kSqu = 0;
                        kPixel = 0;
                        int num8 = mySig.ixPix[kx] - mySig.ixPix[1];
                        int num9 = mySig.iyPix[ky];
                        int num10 = mySig.iyPix[1];
                        Convert.ToInt32(wSign / sPixel);
                        Convert.ToInt32(hSign / sPixel);
                        int num11 = iy2Grid - iy2Grid;
                        for (int index = 1; index <= ky; ++index)
                            mySig.iyPix[index] = mySig.iyPix[index] + num11;
                        for (int index = 1; index <= kPxy; ++index)
                        {
                            mySig.y1Pix[index] = mySig.y1Pix[index] + (double)num11;
                            mySig.y2Pix[index] = mySig.y2Pix[index] + (double)num11;
                        }
                        iy1Grid += num11;
                        iy2Grid += num11;
                        ixBeg = ix2Grid - num8;
                        iyBeg = iy2Grid + 2;
                        panel1.Invalidate();
                    }
                }
            }
        }

        private void Pixel_Click(object sender, EventArgs e) => nControl = 101;

        private void Line_Click(object sender, EventArgs e) => nControl = 102;

        private void KeepItem_Click(object sender, EventArgs e)
        {
            mySig.FilePath();
            kLong = 0;
            if (nControl == 125)
                kLong = sText.Length;
            if (kLong == 0 && kPixel < 2)
            {
                int num = (int)MessageBox.Show("Нет данных", "Создание элемента", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ++numLast;
                wSymbol = Convert.ToInt32(wSign / sPixel);
                hSymbol = Convert.ToInt32(hSign / sPixel);
                string str = string.Format("{0}", (object)numLast);
                FileStream output = new FileStream(mySig.fitemPoly, FileMode.Append, FileAccess.Write);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                try
                {
                    binaryWriter.Write(str);
                    binaryWriter.Write(kLong);
                    if (kLong == 0)
                    {
                        binaryWriter.Write(wSign);
                        binaryWriter.Write(hSign);
                        binaryWriter.Write(wSymbol);
                        binaryWriter.Write(hSymbol);
                        binaryWriter.Write(kPixel);
                        if (kPixel > 0)
                        {
                            for (int index = 1; index <= kPixel; ++index)
                            {
                                binaryWriter.Write(mySig.ixSqu[index]);
                                binaryWriter.Write(mySig.iySqu[index]);
                                binaryWriter.Write(mySig.nColor[index]);
                            }
                        }
                    }
                    if (kLong > 0)
                    {
                        binaryWriter.Write(hText);
                        binaryWriter.Write(mColor);
                        binaryWriter.Write(sText);
                        binaryWriter.Write(wSign);
                        binaryWriter.Write(hSign);
                        binaryWriter.Write(wSymbol);
                        binaryWriter.Write(hSymbol);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                }
                binaryWriter.Close();
                output.Close();
                FormLoad();
                for (int index = 1; index <= kRectItem; ++index)
                {
                    DllClass1.UpSign(kRectItem, mySig.yParc, pixHei, out iCond);
                    if (iCond == 0)
                    {
                        panel1.Invalidate();
                        break;
                    }
                }
                panel1.Invalidate();
            }
        }

        private void LastDelete_Click(object sender, EventArgs e)
        {
            iListItemShow = 1;
            iListShow = 0;
            if (kRectItem == 0)
                return;
            for (int index = 1; index <= kRectItem; ++index)
            {
                DllClass1.UpSign(kRectItem, mySig.yParc, pixHei, out iCond);
                if (iCond == 0)
                {
                    panel1.Invalidate();
                    break;
                }
            }
            if (MessageBox.Show("Вы действительно хотите удалить последний элемент?", "Создание символов полигонов", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                return;
            for (int index = 1; index <= kPolySymb; ++index)
            {
                if (mySig.npItem[index] == kItemPoly)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить этот элемент??", "СИМВОЛ С ДАННЫМ ЭЛЕМЕНТОМ СУЩЕСТВУЕТ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        return;
                    break;
                }
            }
            DllClass1.PolyLastItem(ref kItemPoly, mySig.fitemPoly, mySig.fPolyPixel);
            if (kItemPoly == 0)
                kRectItem = 0;
            FormLoad();
            if (kRectItem > 0)
            {
                for (int index = 1; index <= kRectItem; ++index)
                {
                    DllClass1.UpSign(kRectItem, mySig.yParc, pixHei, out iCond);
                    if (iCond == 0)
                        break;
                }
            }
            panel1.Invalidate();
        }

        private void NewSymbol_Click(object sender, EventArgs e)
        {
            nProcess = 20;
            groupBox2.Visible = false;
            groupBox5.Visible = false;
            button10.Visible = true;
            button13.Visible = false;
            iListShow = 1;
            iListItemShow = 1;
            if (kItemPoly == 0)
            {
                int num = (int)MessageBox.Show("Элементы-?","Новый символ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                label1.Text = "Выберите соответствующий элемент";
                panel1.Invalidate();
            }
        }

        private void AddSymbol_Click(object sender, EventArgs e)
        {
            double tText = 0.0;
            label1.Text = "";
            if (textBox3.Text == "")
            {
                int num1 = (int)MessageBox.Show("Проверьте код пользователя","Новый символ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DllClass1.CheckText(textBox3.Text, out tText, out iCond);
                if (iCond < 0)
                {
                    int num2 = (int)MessageBox.Show("Проверьте данные","Новый символ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (textBox5.Text == "")
                {
                    int num3 = (int)MessageBox.Show("Проверьте описание","Новый символ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    iListShow = 1;
                    mColor = 0;
                    if (radioButton10.Checked)
                        mColor = 1;
                    if (radioButton11.Checked)
                        mColor = 2;
                    if (radioButton12.Checked)
                        mColor = 3;
                    if (radioButton13.Checked)
                        mColor = 4;
                    if (radioButton14.Checked)
                        mColor = 5;
                    if (radioButton15.Checked)
                        mColor = 6;
                    if (radioButton16.Checked)
                        mColor = 7;
                    if (radioButton17.Checked)
                        mColor = 8;
                    if (radioButton18.Checked)
                        mColor = 9;
                    if (radioButton19.Checked)
                        mColor = 10;
                    if (mColor == 0)
                        mColor = 10;
                    int int32 = Convert.ToInt32(textBox3.Text);
                    int num4 = 0;
                    for (int index = 1; index <= kPolySymb; ++index)
                    {
                        if (mySig.npSign2[index] == int32)
                        {
                            ++num4;
                            break;
                        }
                    }
                    if (num4 > 0)
                    {
                        int num5 = (int)MessageBox.Show("Дубликат кода пользователя","Новый символ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int index1 = kPolySymb + 1;
                        mySig.sPolySymb[index1] = textBox5.Text;
                        mySig.npSign1[index1] = index1;
                        mySig.npItem[index1] = Convert.ToInt32(textBox4.Text);
                        mySig.npSign2[index1] = Convert.ToInt32(textBox3.Text);
                        mySig.nBackCol[index1] = mColor;
                        RadioDensity(1, ref nDensity);
                        mySig.nOneSymb[index1] = nDensity;
                        kPolySymb = index1;
                        mySig.kPolySymb = kPolySymb;
                        DllClass1.PolySymbolKeep(mySig.fsymbPoly, kPolySymb, hSymbPoly, mySig.sPolySymb, mySig.npSign1, mySig.xpSign1, mySig.ypSign1, mySig.xpSymb, mySig.ypSymb, mySig.npItem, mySig.xpItem, mySig.ypItem, mySig.xpDescr, mySig.ypDescr, mySig.npSign2, mySig.xpSign2, mySig.ypSign2, mySig.nBackCol, mySig.nOneSymb);
                        textBox3.Text = string.Format("{0}", (object)(index1 + 1));
                        numSelect = 0;
                        groupBox5.Visible = false;
                        nProcess = 0;
                        FormLoad();
                        for (int index2 = 1; index2 <= kRectPoly; ++index2)
                        {
                            DllClass1.UpSign(kRectPoly, mySig.yVert, pixHei, out iCond);
                            if (iCond == 0)
                                break;
                        }
                        panel1.Invalidate();
                    }
                }
            }
        }

        private void SymbolUpdate_Click(object sender, EventArgs e)
        {
            nProcess = 30;
            groupBox2.Visible = false;
            groupBox5.Visible = false;
            button10.Visible = false;
            button13.Visible = true;
            iListShow = 1;
            iListItemShow = 0;
            label1.Text = "Выберите соответствующий символ";
            panel1.Invalidate();
        }

        private void ConfirmChanges_Click(object sender, EventArgs e)
        {
            double tText = 0.0;
            if (textBox3.Text == "")
            {
                int num1 = (int)MessageBox.Show("Проверьте код пользователя", "Обновление символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DllClass1.CheckText(textBox3.Text, out tText, out iCond);
                if (iCond < 0)
                {
                    int num2 = (int)MessageBox.Show("1-Проверьте данные", "Обновление символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (textBox5.Text == "")
                {
                    int num3 = (int)MessageBox.Show("Проверьте описание", "Обновление символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int num4 = 0;
                    mColor = 0;
                    if (radioButton10.Checked)
                        mColor = 1;
                    if (radioButton11.Checked)
                        mColor = 2;
                    if (radioButton12.Checked)
                        mColor = 3;
                    if (radioButton13.Checked)
                        mColor = 4;
                    if (radioButton14.Checked)
                        mColor = 5;
                    if (radioButton15.Checked)
                        mColor = 6;
                    if (radioButton16.Checked)
                        mColor = 7;
                    if (radioButton17.Checked)
                        mColor = 8;
                    if (radioButton18.Checked)
                        mColor = 9;
                    if (radioButton19.Checked)
                        mColor = 10;
                    if (mColor == 0)
                        mColor = 10;
                    int int32 = Convert.ToInt32(textBox3.Text);
                    int num5 = 0;
                    for (int index = 1; index <= kPolySymb; ++index)
                    {
                        if (mySig.npSign2[index] == int32)
                        {
                            num5 = index;
                            break;
                        }
                    }
                    if (num5 > 0 && num5 != numSelect)
                    {
                        int num6 = (int)MessageBox.Show("Дубликат кода пользователя", "Обновление символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int numSelect = this.numSelect;
                        mySig.sPolySymb[numSelect] = textBox5.Text;
                        mySig.npSign1[numSelect] = numSelect;
                        mySig.npItem[numSelect] = Convert.ToInt32(textBox4.Text);
                        mySig.npSign2[numSelect] = Convert.ToInt32(textBox3.Text);
                        mySig.nBackCol[numSelect] = mColor;
                        mySig.npTxtCol[numSelect] = num4;
                        if (iLong == 0)
                        {
                            mySig.hpFont[numSelect] = 2.0;
                            mySig.spInscr[numSelect] = "abcd";
                        }
                        RadioDensity(1, ref nDensity);
                        mySig.nOneSymb[numSelect] = nDensity;
                        mySig.kPolySymb = kPolySymb;
                        mySig.hSymbPoly = hSymbPoly;
                        mySig.kPolySymb = kPolySymb;
                        DllClass1.PolySymbolKeep(mySig.fsymbPoly, kPolySymb, hSymbPoly, mySig.sPolySymb, mySig.npSign1, mySig.xpSign1, mySig.ypSign1, mySig.xpSymb, mySig.ypSymb, mySig.npItem, mySig.xpItem, mySig.ypItem, mySig.xpDescr, mySig.ypDescr, mySig.npSign2, mySig.xpSign2, mySig.ypSign2, mySig.nBackCol, mySig.nOneSymb);
                        numSelect = 0;
                        groupBox5.Visible = false;
                        nProcess = 0;
                        FormLoad();
                        panel1.Invalidate();
                    }
                }
            }
        }

        private void LastSymbDel_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            if (kPolySymb < 1)
                return;
            if (kPolySymb < 2)
            {
                if (File.Exists(mySig.fsymbPoly))
                    File.Delete(mySig.fsymbPoly);
                kPolySymb = 0;
                mySig.kPolySymb = 0;
                FormLoad();
                panel1.Invalidate();
            }
            else
            {
                iListShow = 1;
                iListItemShow = 0;
                for (int index = 1; index <= kRectPoly; ++index)
                {
                    DllClass1.UpSign(kRectPoly, mySig.yVert, pixHei, out iCond);
                    if (iCond == 0)
                    {
                        panel1.Invalidate();
                        break;
                    }
                }
                if (MessageBox.Show("Вы действительно хотите удалить последний символ?", "Создание символов полигонов", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                --kPolySymb;
                mySig.kPolySymb = kPolySymb;
                DllClass1.PolySymbolKeep(mySig.fsymbPoly, kPolySymb, hSymbPoly, mySig.sPolySymb, mySig.npSign1, mySig.xpSign1, mySig.ypSign1, mySig.xpSymb, mySig.ypSymb, mySig.npItem, mySig.xpItem, mySig.ypItem, mySig.xpDescr, mySig.ypDescr, mySig.npSign2, mySig.xpSign2, mySig.ypSign2, mySig.nBackCol, mySig.nOneSymb);
                FormLoad();
                for (int index = 1; index <= kRectPoly; ++index)
                {
                    DllClass1.UpSign(kRectPoly, mySig.yVert, pixHei, out iCond);
                    if (iCond == 0)
                        break;
                }
                panel1.Invalidate();
            }
        }

        public void RadioDensity(int iParam, ref int nDensity)
        {
            if (iParam == 1)
            {
                nDensity = 0;
                if (radioButton20.Checked)
                    nDensity = 0;
                if (radioButton21.Checked)
                    nDensity = 1;
                if (radioButton22.Checked)
                    nDensity = 2;
                if (radioButton23.Checked)
                    nDensity = 3;
                if (radioButton24.Checked)
                    nDensity = 4;
                if (radioButton25.Checked)
                    nDensity = 5;
            }
            if (iParam != 2)
                return;
            if (nDensity == 0)
            {
                radioButton20.Checked = true;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
            }
            if (nDensity == 0)
                radioButton20.Checked = true;
            if (nDensity == 1)
                radioButton21.Checked = true;
            if (nDensity == 2)
                radioButton22.Checked = true;
            if (nDensity == 3)
                radioButton23.Checked = true;
            if (nDensity == 4)
                radioButton24.Checked = true;
            if (nDensity != 5)
                return;
            radioButton25.Checked = true;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            nControl = 103;
            RadioColor(ref mColor);
            DllClass1.GridRectangle(1, kx, mySig.ixPix, ky, mySig.iyPix, out kCell, mySig.xCell, mySig.yCell);
            int kArray = 999999;
            DllClass1.doubleArray(mySig.xSqu, ref kArray);
            DllClass1.doubleArray(mySig.ySqu, ref kArray);
            DllClass1.intArray(mySig.numCol, ref kArray);
            int num1 = kArray - 10;
            if (kCell > 0)
            {
                for (int index = 1; index <= kCell; ++index)
                {
                    ++kSqu;
                    if (kSqu > num1)
                    {
                        int num2 = (int)MessageBox.Show("Индекс массива Rectangle");
                        return;
                    }
                    mySig.xSqu[kSqu] = mySig.xCell[index];
                    mySig.ySqu[kSqu] = mySig.yCell[index];
                    mySig.numCol[kSqu] = mColor;
                }
                ++kAction;
                DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
            }
            panel1.Invalidate();
        }

        private void FillRectangle_Click(object sender, EventArgs e)
        {
            nControl = 104;
            RadioColor(ref mColor);
            DllClass1.GridRectangle(2, kx, mySig.ixPix, ky, mySig.iyPix, out kCell, mySig.xCell, mySig.yCell);
            int kArray = 999999;
            DllClass1.doubleArray(mySig.xSqu, ref kArray);
            DllClass1.doubleArray(mySig.ySqu, ref kArray);
            DllClass1.intArray(mySig.numCol, ref kArray);
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
                    mySig.xSqu[kSqu] = mySig.xCell[index];
                    mySig.ySqu[kSqu] = mySig.yCell[index];
                    mySig.numCol[kSqu] = mColor;
                }
                ++kAction;
                DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
            }
            panel1.Invalidate();
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            nControl = 105;
            RadioColor(ref mColor);
            DllClass1.GridEllipse(1, kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void FillEllipse_Click(object sender, EventArgs e)
        {
            nControl = 106;
            RadioColor(ref mColor);
            DllClass1.GridEllipse(2, kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void CloseDialog_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        private void Hexagon_Click(object sender, EventArgs e)
        {
            nControl = 122;
            RadioColor(ref mColor);
            DllClass1.GridHexagon(1, kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void ArcLeft_Click(object sender, EventArgs e)
        {
            nControl = 108;
            RadioColor(ref mColor);
            DllClass1.GridArc(1, kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void ArcRight_Click(object sender, EventArgs e)
        {
            nControl = 109;
            RadioColor(ref mColor);
            DllClass1.GridArc(2, kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void ArcTop_Click(object sender, EventArgs e)
        {
            nControl = 111;
            RadioColor(ref mColor);
            DllClass1.GridArc(3, kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void ArcBottom_Click(object sender, EventArgs e)
        {
            nControl = 112;
            RadioColor(ref mColor);
            DllClass1.GridArc(4, kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleLeft_Click(object sender, EventArgs e)
        {
            nControl = 113;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(1, kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleRight_Click(object sender, EventArgs e)
        {
            nControl = 115;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(3, kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleTop_Click(object sender, EventArgs e)
        {
            nControl = 117;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(5, kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleBottom_Click(object sender, EventArgs e)
        {
            nControl = 119;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(7, kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void CircleTriangle_Click(object sender, EventArgs e)
        {
            nControl = 124;
            RadioColor(ref mColor);
            DllClass1.TriangleCircle(kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, mySig.xDat, mySig.yDat, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySig.xSqu, ref kArray);
                DllClass1.doubleArray(mySig.ySqu, ref kArray);
                DllClass1.intArray(mySig.numCol, ref kArray);
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
                        mySig.xSqu[kSqu] = mySig.xCell[index];
                        mySig.ySqu[kSqu] = mySig.yCell[index];
                        mySig.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void Concentric_Click(object sender, EventArgs e)
        {
            nControl = 107;
            RadioColor(ref mColor);
            DllClass1.ConcentricCircle(kx, mySig.ixPix, ky, mySig.iyPix, kPxy, mySig.x1Pix, mySig.y1Pix, mySig.x2Pix, mySig.y2Pix, out kCell, mySig.xCell, mySig.yCell, out kSpot, mySig.xSpot, mySig.ySpot, mySig.xAngel, mySig.yAngel, mySig.xDat, mySig.yDat, out iCond);
            int kArray = 999999;
            DllClass1.doubleArray(mySig.xSqu, ref kArray);
            DllClass1.doubleArray(mySig.ySqu, ref kArray);
            DllClass1.intArray(mySig.numCol, ref kArray);
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
                    mySig.xSqu[kSqu] = mySig.xCell[index];
                    mySig.ySqu[kSqu] = mySig.yCell[index];
                    mySig.numCol[kSqu] = mColor;
                }
                ++kAction;
                DllClass1.GridPixel(kSqu, mySig.xSqu, mySig.ySqu, mySig.numCol, out kPixel, mySig.ixSqu, mySig.iySqu, mySig.nColor, ix1Grid, iy1Grid);
                if (iCond < 0)
                {
                    int num3 = (int)MessageBox.Show("Воспользуйтесь опцией 'Ручное создание'", "Создание символа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            panel1.Invalidate();
        }

        public void RectPolySign(
          int pixWid,
          int pixHei,
          int kSymbLine,
          int hSymbLine,
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
            idx = 90;
            idy = 2 * hSymbLine;
            int num2 = 450 / idx;
            int num3 = 0;
            int num4 = -idy / 2;
            do
            {
                num4 += idy;
                int num5 = -idx + num1;
                for (int index = 1; index <= num2; ++index)
                {
                    ++num3;
                    num5 += idx;
                    ++kRect;
                    nRect[kRect] = num3;
                    xRect[kRect] = (double)num5;
                    yRect[kRect] = (double)num4;
                    if (num3 == kSymbLine)
                        break;
                }
            }
            while (num3 != kSymbLine && num3 < kSymbLine);
        }

        public void SymbPolyDraw(
          PaintEventArgs e,
          string fitemPoly,
          int kRect,
          int[] nRect,
          double[] xRect,
          double[] yRect,
          int idx,
          int idy,
          int kPolySymb,
          int[] npSign2,
          int[] nBackCol,
          int[] nItem,
          int[] nOneSymb,
          int[] ixp,
          int[] iyp,
          int[] nColItem,
          SolidBrush[] brColor,
          Pen[] pnCol)
        {
            Graphics graphics = e.Graphics;
            string sTxt = "";
            int hSymbPoly = this.hSymbPoly;
            int emSize = 8;
            int width = 25;
            Font font = new Font("Arial", (float)emSize);
            SolidBrush solidBrush1 = new SolidBrush(Color.Black);
            Pen pen1 = new Pen(Color.Gray, 1f);
            for (int index1 = 1; index1 <= kRect; ++index1)
            {
                int index2 = nRect[index1];
                int num1 = npSign2[index2];
                int nSelect = nItem[index2];
                int int32_1 = Convert.ToInt32(xRect[index2]);
                int int32_2 = Convert.ToInt32(yRect[index2]);
                string s = string.Format("{0}", (object)index2) + "-" + string.Format("{0}", (object)num1);
                graphics.DrawString(s, font, (Brush)solidBrush1, (float)int32_1, (float)int32_2);
                graphics.DrawRectangle(pen1, int32_1 - 1, int32_2 - emSize, idx, idy);
                int index3 = nBackCol[index2];
                int x = int32_1 + 40;
                if (index3 == 10)
                {
                    SolidBrush solidBrush2 = new SolidBrush(Color.White);
                    graphics.FillRectangle((Brush)solidBrush2, x, int32_2, width, hSymbPoly);
                }
                if (index3 < 10)
                {
                    SolidBrush solidBrush3 = brColor[index3];
                    graphics.FillRectangle((Brush)solidBrush3, x, int32_2, width, hSymbPoly);
                }
                Pen pen2 = new Pen(Color.Gray, 1f);
                if (nSelect != 0)
                {
                    int iLong;
                    int iWid;
                    int iHei;
                    int kPix;
                    int mClr;
                    DllClass1.SelItemPoly(fitemPoly, nSelect, out iLong, out iWid, out iHei, out kPix, ixp, iyp, nColItem, out sTxt, out mClr);
                    if (iLong == 0)
                    {
                        int num2 = 1;
                        int num3 = (width - num2 * iWid) / (num2 + 1);
                        int num4 = x;
                        for (int index4 = 1; index4 <= num2; ++index4)
                        {
                            int num5 = num4 + num3;
                            for (int index5 = 1; index5 <= kPix; ++index5)
                            {
                                int num6 = num5 + ixp[index5];
                                int num7 = int32_2 + iyp[index5];
                                mClr = nColItem[index5];
                                SolidBrush solidBrush4 = brColor[mClr];
                                int num8 = (width - iWid) / 2;
                                int num9 = (hSymbPoly - iHei) / 2;
                                int num10 = 0;
                                graphics.FillRectangle((Brush)solidBrush4, num6 + num10, num7 + num9, 1, 1);
                            }
                            num4 = num5 + iWid;
                        }
                    }
                }
            }
        }

        public void RectItemPoly(
          int ihItem,
          int iwItem,
          int pixWid,
          int pixHei,
          int kItemLine,
          out int kRectItem,
          int[] nRectItem,
          double[] xRectItem,
          double[] yRectItem,
          out int idx,
          out int idy)
        {
            kRectItem = 0;
            idx = idy = 0;
            if (kItemPoly == 0)
                return;
            int num1 = 505;
            int num2 = 265;
            idx = 2 * iwItem;
            idy = 2 * ihItem;
            int num3 = (pixWid - num1 - 5) / idx;
            int num4 = 0;
            int num5 = -idy + num2;
            do
            {
                num5 += idy;
                int num6 = -idx + num1;
                for (int index = 1; index <= num3; ++index)
                {
                    ++num4;
                    num6 += idx;
                    ++kRectItem;
                    nRectItem[kRectItem] = num4;
                    xRectItem[kRectItem] = (double)num6;
                    yRectItem[kRectItem] = (double)num5;
                    if (num4 == kItemLine)
                        break;
                }
            }
            while (num4 != kItemLine && num4 < kItemLine);
        }

        public void ItemListDraw(
          PaintEventArgs e,
          string fitemLine,
          int kRectItem,
          int[] nRectItem,
          double[] xRectItem,
          double[] yRectItem,
          int idx,
          int idy,
          int[] ixp,
          int[] iyp,
          int[] nColorItm,
          SolidBrush[] brColor,
          Pen[] pnCol)
        {
            Graphics graphics = e.Graphics;
            string sTxt = "";
            int emSize = 8;
            Font font1 = new Font("Arial", (float)emSize);
            Font font2 = new Font("Arial", (float)emSize, FontStyle.Bold);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Gray, 1f);
            int int32_1 = Convert.ToInt32(xRectItem[1]);
            int y = Convert.ToInt32(yRectItem[1]) - 2 * emSize;
            graphics.DrawString("Элементы", font2, (Brush)solidBrush, (float)int32_1, (float)y);
            for (int index = 1; index <= kRectItem; ++index)
            {
                int nSelect = nRectItem[index];
                int int32_2 = Convert.ToInt32(xRectItem[nSelect]);
                int int32_3 = Convert.ToInt32(yRectItem[nSelect]);
                string s = string.Format("{0}", (object)nSelect);
                graphics.DrawString(s, font1, (Brush)solidBrush, (float)int32_2, (float)int32_3);
                int ixh = int32_2 + 20;
                int kPix;
                DllClass1.SelItemLine(fitemLine, nSelect, out int _, out int _, out int _, out kPix, ixp, iyp, nColorItm, out sTxt, out int _);
                DllClass1.SignDraw(e, ixh, int32_3 + emSize / 2, kPix, ixp, iyp, nColorItm, brColor);
                graphics.DrawRectangle(pen, int32_2 - 1, int32_3 - emSize / 2, idx, idy);
            }
        }

        private void UpSymbol_Click(object sender, EventArgs e)
        {
            DllClass1.UpSign(kRectPoly, mySig.yVert, pixHei, out iCond);
            panel1.Invalidate();
        }

        private void DownSymbol_Click(object sender, EventArgs e)
        {
            DllClass1.DownSign(kRectPoly, mySig.yVert, out iCond);
            panel1.Invalidate();
        }

        private void MoreDetails_Click(object sender, EventArgs e)
        {
            int num1 = 1000;
            if (File.Exists(mySig.fileAdd))
                File.Delete(mySig.fileAdd);
            FileStream output = new FileStream(mySig.fileAdd, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(num1);
            binaryWriter.Close();
            output.Close();
            int num2 = (int)new ListPolySign().ShowDialog((IWin32Window)this);
        }

        private void SymbolsOnOff_Click(object sender, EventArgs e)
        {
            iListShow = iListShow <= 0 ? 1 : 0;
            panel1.Invalidate();
        }

        private void UpItem_Click(object sender, EventArgs e)
        {
            DllClass1.UpSign(kRectItem, mySig.yParc, pixHei, out iCond);
            label1.Text = "";
            panel1.Invalidate();
        }

        private void DownItem_Click(object sender, EventArgs e)
        {
            DllClass1.DownItem(kRectItem, mySig.yParc, out iCond);
            label1.Text = "";
            panel1.Invalidate();
        }

        private void ItemsOnOff_Click(object sender, EventArgs e)
        {
            iListItemShow = iListItemShow <= 0 ? 1 : 0;
            panel1.Invalidate();
        }

    }
}
