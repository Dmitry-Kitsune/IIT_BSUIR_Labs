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

    public partial class LineSign : Form
    {
        private string sText = "";
        private int iWidth;
        private int iHeight;
        private int pixWid;
        private int pixHei;
        private int kSymbLine;
        private int hSymbLine = 18;
        private int nProcess;
        private int numLast;
        private int nControl;
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
        private int ixSymb = 470;
        private int iySymb = 625;
        private int mColor;
        private int kCell;
        private int kAction;
        private int ixLine;
        private int iyLine;
        private int jxLine;
        private int jyLine;
        private int kItemLine;
        private int kLong;
        private int wSymbol;
        private int hSymbol;
        private int nSelLine = -1;
        private int indBase;
        private int kNew;
        private int nSelItem;
        private int iLong;
        private int iHei;
        private int iWid;
        private int mLocation;
        private int ihItem = 20;
        private int iwItem = 20;
        private int nDens;
        private int nSt1;
        private int nSt2;
        private int nWid1;
        private int nWid2;
        private int kSpot;
        private int kRect;
        private int rWid;
        private int rHei;
        private int iListShow = 1;
        private int kRectItem;
        private int rWidItem;
        private int rHeiItem;
        private int iListItemShow = 1;
        private int nProblem;
        private double wSign;
        private double hSign;
        private double sPixel = 0.254;
        private double xDown;
        private double yDown;
        private double x1Line;
        private double y1Line;
        private double x2Line;
        private double y2Line;
        private int kDown;
        private double[] xiDown = new double[10];
        private double[] yiDown = new double[10];
        private bool isDrag;
        private Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        private Point startPoint;
        private Point endPoint;

        private MyGeodesy myLin = new MyGeodesy();
        public LineSign()
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
            groupBox7.Visible = false;
            button13.Visible = false;
            button32.Visible = false;
            button23.Visible = false;
            button25.Visible = false;
            button26.Visible = false;
            button27.Visible = false;
            button28.Visible = false;
            button29.Visible = false;
            button30.Visible = false;
            button31.Visible = false;
            button33.Visible = false;
            button34.Visible = false;
            FormLoad();
        }
        public void FormLoad()
        {
            numLast = 0;
            int xh = 20;
            int yh = 60;
            int xk = 100;
            int yk = 60;
            myLin.FilePath();
            DllClass1.SetColour(myLin.brColor, myLin.pnColor);
            kSymbLine = 0;
            if (!File.Exists(myLin.fsymbLine))
            {
                myLin.LineDescription(out kSymbLine, myLin.sSymbLine);
                if (kSymbLine == 0)
                    return;
                DllClass1.LineSymbCoord(xh, yh, xk, yk, kSymbLine, hSymbLine, ref myLin.x1Line, ref myLin.y1Line, ref myLin.x2Line, ref myLin.y2Line, ref myLin.xDescr, ref myLin.yDescr, ref myLin.x1Dens, ref myLin.y1Dens, ref myLin.x1Sign, ref myLin.y1Sign, ref myLin.x2Sign, ref myLin.y2Sign, ref myLin.n1Sign, ref myLin.n2Sign, ref myLin.iStyle1, ref myLin.iStyle2, ref myLin.iWidth1, ref myLin.iWidth2, ref myLin.nColLine, ref myLin.nItem, ref myLin.itemLoc, ref myLin.nBaseSymb, ref myLin.sInscr, ref myLin.hInscr, ref myLin.iColInscr, ref myLin.iDensity);
                myLin.kSymbLine = kSymbLine;
                DllClass1.LineSymbolKeep(myLin.fsymbLine, kSymbLine, hSymbLine, myLin.sSymbLine, myLin.x1Line, myLin.y1Line, myLin.x2Line, myLin.y2Line, myLin.xDescr, myLin.yDescr, myLin.x1Dens, myLin.y1Dens, myLin.x1Sign, myLin.y1Sign, myLin.x2Sign, myLin.y2Sign, myLin.n1Sign, myLin.n2Sign, myLin.iStyle1, myLin.iStyle2, myLin.iWidth1, myLin.iWidth2, myLin.nColLine, myLin.nItem, myLin.itemLoc, myLin.nBaseSymb, myLin.sInscr, myLin.hInscr, myLin.iColInscr, myLin.iDensity);
            }
            DllClass1.LineSymbolLoad(myLin.fsymbLine, out kSymbLine, out hSymbLine, myLin.sSymbLine, myLin.x1Line, myLin.y1Line, myLin.x2Line, myLin.y2Line, myLin.xDescr, myLin.yDescr, myLin.x1Dens, myLin.y1Dens, myLin.x1Sign, myLin.y1Sign, myLin.x2Sign, myLin.y2Sign, myLin.n1Sign, myLin.n2Sign, myLin.iStyle1, myLin.iStyle2, myLin.iWidth1, myLin.iWidth2, myLin.nColLine, myLin.nItem, myLin.itemLoc, myLin.nBaseSymb, myLin.sInscr, myLin.hInscr, myLin.iColInscr, myLin.iDensity);
            kItemLine = 0;
            if (File.Exists(myLin.fitemLine))
            {
                myLin.hItemLine[1] = 55;
                if (File.Exists(myLin.fLinePixel))
                    File.Delete(myLin.fLinePixel);
                FileStream output = new FileStream(myLin.fLinePixel, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                FileStream input = new FileStream(myLin.fitemLine, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    string str;
                    while ((str = binaryReader.ReadString()) != null)
                    {
                        int int32 = Convert.ToInt32(str);
                        if (int32 > numLast)
                            numLast = int32;
                        int num1 = binaryReader.ReadInt32();
                        binaryWriter.Write(str);
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
                                for (int index = 1; index <= num6; ++index)
                                {
                                    int num7 = binaryReader.ReadInt32();
                                    int num8 = binaryReader.ReadInt32();
                                    int num9 = binaryReader.ReadInt32();
                                    binaryWriter.Write(num7);
                                    binaryWriter.Write(num8);
                                    binaryWriter.Write(num9);
                                }
                            }
                            ++kItemLine;
                            myLin.numLong[kItemLine] = num1;
                            if (num5 > ihItem)
                                ihItem = num5;
                            if (num4 > iwItem)
                                iwItem = num4;
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
            if (kItemLine == 0)
                kRectItem = 0;
            RectLineSign(pixWid, pixHei, kSymbLine, hSymbLine, out kRect, myLin.nVert, myLin.xVert, myLin.yVert, out rWid, out rHei);
            RectItemLine(ihItem, iwItem, pixWid, pixHei, kItemLine, out kRectItem, myLin.nParc, myLin.xParc, myLin.yParc, out rWidItem, out rHeiItem);
            nProblem = 2;
            if (File.Exists(myLin.fProblem))
                File.Delete(myLin.fProblem);
            FileStream output1 = new FileStream(myLin.fProblem, FileMode.CreateNew);
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

        private void Close_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (kRect > 0 && iListShow > 0)
                SymbLineDraw(e, myLin.fitemLine, kRect, myLin.nVert, myLin.xVert, myLin.yVert, rWid, rHei, kSymbLine, myLin.n2Sign, myLin.nBaseSymb, myLin.nColLine, myLin.iWidth1, myLin.iWidth2, myLin.iStyle1, myLin.iStyle2, myLin.nItem, myLin.itemLoc, myLin.iDensity, myLin.nColorItm, myLin.nWork1, myLin.nWork2, myLin.brColor, myLin.pnColor);
            if (kRectItem > 0 && iListItemShow > 0)
                ItemListDraw(e, myLin.fitemLine, kRectItem, myLin.nParc, myLin.xParc, myLin.yParc, rWidItem, rHeiItem, myLin.nWork1, myLin.nWork2, myLin.nWork, myLin.brColor, myLin.pnColor);
            if (nProcess != 10)
                return;
            DllClass1.GridDraw(e, kx, myLin.ixPix, ky, myLin.iyPix);
            if (nControl == 101)
            {
                DllClass1.DrawGrid(e, kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, myLin.brColor);
                ixSymb = 650;
                iySymb = 205;
                DllClass1.SignDraw(e, ixSymb, iySymb, kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, myLin.brColor);
            }
            if (nControl == 102)
            {
                DllClass1.DrawGrid(e, kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, myLin.brColor);
                ixSymb = 650;
                iySymb = 205;
                DllClass1.SignDraw(e, ixSymb, iySymb, kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, myLin.brColor);
            }
            if (nControl == 103 || nControl == 104)
            {
                DllClass1.DrawGrid(e, kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, myLin.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, myLin.brColor);
            }
            if (nControl == 105 || nControl == 106 || nControl == 107)
            {
                DllClass1.DrawGrid(e, kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, myLin.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, myLin.brColor);
            }
            if (nControl == 108 || nControl == 109 || nControl == 111 || nControl == 112)
            {
                DllClass1.DrawGrid(e, kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, myLin.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, myLin.brColor);
            }
            if (nControl == 113 || nControl == 114 || nControl == 115 || nControl == 116 || nControl == 117 || nControl == 118 || nControl == 119 || nControl == 121)
            {
                DllClass1.DrawGrid(e, kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, myLin.brColor);
                DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, myLin.brColor);
            }
            if (nControl != 122 && nControl != 123 && nControl != 124)
                return;
            DllClass1.DrawGrid(e, kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, myLin.brColor);
            DllClass1.SignDraw(e, ixBeg, iyBeg, kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, myLin.brColor);
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
            if ((nProcess == 30 || nProcess == 50) && e.Button == MouseButtons.Left)
            {
                xDown = 1.0 * (double)e.X;
                yDown = 1.0 * (double)e.Y;
            }
            if (nProcess != 40 || e.Button != MouseButtons.Left)
                return;
            if (kDown < 5)
            {
                ++kDown;
                xiDown[kDown] = 1.0 * (double)e.X;
                yiDown[kDown] = 1.0 * (double)e.Y;
            }
            if (kDown != 1)
                return;
            label4.Text = "Select appropriate item";
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
                    DllClass1.GridChange(ref kSqu, ref myLin.xSqu, ref myLin.ySqu, ref myLin.numCol, xDown, yDown, myLin.nDat, out iCond);
                    if (iCond == 0)
                    {
                        RadioColor(ref mColor);
                        DllClass1.GridPoint(kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, xDown, yDown, out kCell, myLin.xCell, myLin.yCell);
                        if (kCell > 0)
                        {
                            for (int index = 1; index <= kCell; ++index)
                            {
                                ++kSqu;
                                myLin.xSqu[kSqu] = myLin.xCell[index];
                                myLin.ySqu[kSqu] = myLin.yCell[index];
                                myLin.numCol[kSqu] = mColor;
                            }
                        }
                    }
                    if (kSqu > 0)
                        DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                    panel1.Invalidate();
                }
                if (nControl == 102)
                {
                    x1Line = 1.0 * (double)(startPoint.X - 18);
                    y1Line = 1.0 * (double)(startPoint.Y - 45);
                    x2Line = 1.0 * (double)(endPoint.X - 18);
                    y2Line = 1.0 * (double)(endPoint.Y - 45);
                    RadioColor(ref mColor);
                    DllClass1.GridLine(kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, x1Line, y1Line, x2Line, y2Line, out kCell, myLin.xCell, myLin.yCell, out iCond);
                    if (iCond < 0)
                        return;
                    int kArray = 999999;
                    DllClass1.doubleArray(myLin.xSqu, ref kArray);
                    DllClass1.doubleArray(myLin.ySqu, ref kArray);
                    DllClass1.intArray(myLin.numCol, ref kArray);
                    int num1 = kArray - 10;
                    if (kCell > 0)
                    {
                        for (int index = 1; index <= kCell; ++index)
                        {
                            ++kSqu;
                            if (kSqu > num1)
                            {
                                int num2 = (int)MessageBox.Show("Index array GridLine");
                                return;
                            }
                            myLin.xSqu[kSqu] = myLin.xCell[index];
                            myLin.ySqu[kSqu] = myLin.yCell[index];
                            myLin.numCol[kSqu] = mColor;
                        }
                        ++kAction;
                        DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
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
            if (nProcess == 30)
            {
                DllClass1.RectSelect(xDown, yDown, kRect, myLin.nVert, myLin.xVert, myLin.yVert, rWid, rHei, out nSelLine);
                if (nSelLine == 0)
                    return;
                indBase = myLin.nBaseSymb[nSelLine];
                nSt1 = myLin.iStyle1[nSelLine];
                nWid1 = myLin.iWidth1[nSelLine];
                textBox6.Text = myLin.sSymbLine[nSelLine];
                textBox5.Text = string.Format("{0}", (object)myLin.n2Sign[nSelLine]);
                nSelItem = myLin.nItem[nSelLine];
                iLong = 0;
                if (nSelItem > 0)
                    iLong = myLin.numLong[nSelItem];
                groupBox5.Visible = true;
                radioButton1.Checked = false;
                radioButton10.Checked = true;
                button13.Visible = true;
                button32.Visible = true;
                button23.Visible = true;
                button25.Visible = true;
                button26.Visible = true;
                button27.Visible = true;
                button28.Visible = true;
                button29.Visible = true;
                button30.Visible = true;
                button31.Visible = true;
                button33.Visible = true;
                button34.Visible = true;
                nDens = myLin.iDensity[nSelLine];
                RadioDensity(2, ref nDens);
                nSt1 = myLin.iStyle1[nSelLine];
                RadioStyle1(2, ref nSt1);
                nWid1 = myLin.iWidth1[nSelLine];
                RadioWidth1(2, ref nWid1);
                indBase = myLin.nBaseSymb[nSelLine];
                if (indBase < 8)
                {
                    groupBox13.Visible = false;
                    groupBox14.Visible = false;
                }
                if (indBase == 8)
                {
                    groupBox13.Visible = true;
                    groupBox14.Visible = true;
                    nSt2 = myLin.iStyle2[nSelLine];
                    RadioStyle2(2, ref nSt2);
                    nWid2 = myLin.iWidth2[nSelLine];
                    RadioWidth2(2, ref nWid2);
                }
                label4.Text = "";
            }
            if (nProcess == 40)
            {
                if (kDown > 0)
                {
                    xDown = xiDown[1];
                    yDown = yiDown[1];
                    DllClass1.RectSelect(xDown, yDown, kRect, myLin.nVert, myLin.xVert, myLin.yVert, rWid, rHei, out nSelLine);
                    if (nSelLine == 0)
                        return;
                    if (nSelLine > 8)
                    {
                        int num = (int)MessageBox.Show("Use Basic Symbols(number 1-8)", "Line's Symbol creation");
                        return;
                    }
                    groupBox5.Visible = true;
                    radioButton1.Checked = false;
                    radioButton10.Checked = true;
                    groupBox10.Visible = true;
                    groupBox11.Visible = true;
                    groupBox12.Visible = true;
                    indBase = myLin.nBaseSymb[nSelLine];
                    nSt1 = myLin.iStyle1[nSelLine];
                    nWid1 = myLin.iWidth1[nSelLine];
                    textBox6.Text = myLin.sSymbLine[nSelLine];
                    textBox5.Text = string.Format("{0}", (object)(kSymbLine + 1));
                    if (indBase == 8)
                    {
                        groupBox13.Visible = true;
                        groupBox14.Visible = true;
                        nSt2 = myLin.iStyle2[nSelLine];
                        nWid2 = myLin.iWidth2[nSelLine];
                    }
                    nDens = myLin.iDensity[nSelLine];
                    RadioDensity(2, ref nDens);
                    nSt1 = myLin.iStyle1[nSelLine];
                    RadioStyle1(2, ref nSt1);
                    nWid1 = myLin.iWidth1[nSelLine];
                    RadioWidth1(2, ref nWid1);
                    indBase = myLin.nBaseSymb[nSelLine];
                    if (indBase < 8)
                    {
                        groupBox13.Visible = false;
                        groupBox14.Visible = false;
                    }
                    if (indBase == 8)
                    {
                        groupBox13.Visible = true;
                        groupBox14.Visible = true;
                        nSt2 = myLin.iStyle2[nSelLine];
                        RadioStyle2(2, ref nSt2);
                        nWid2 = myLin.iWidth2[nSelLine];
                        RadioWidth2(2, ref nWid2);
                    }
                    nDens = 3;
                    RadioDensity(2, ref nDens);
                    iListItemShow = 1;
                    iListShow = 0;
                }
                if (kDown > 1)
                {
                    xDown = xiDown[kDown];
                    yDown = yiDown[kDown];
                    DllClass1.RectSelect(xDown, yDown, kRectItem, myLin.nParc, myLin.xParc, myLin.yParc, rWidItem, rHeiItem, out nSelItem);
                    if (nSelItem == 0)
                        return;
                    DllClass1.SelItemLine(myLin.fitemLine, nSelItem, out iLong, out iWid, out iHei, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColorItm, out sText, out mColor);
                    groupBox7.Visible = true;
                    radioButton29.Checked = true;
                    textBox11.Text = string.Format("{0}", (object)nSelItem);
                    iLong = myLin.numLong[nSelItem];
                    button13.Visible = true;
                    button32.Visible = true;
                    button23.Visible = true;
                    button25.Visible = true;
                    button26.Visible = true;
                    button27.Visible = true;
                    button28.Visible = true;
                    button29.Visible = true;
                    button30.Visible = true;
                    button31.Visible = true;
                    button33.Visible = true;
                    button34.Visible = true;
                    label4.Text = "";
                }
                panel1.Invalidate();
            }
            if (nProcess != 50)
                return;
            DllClass1.RectSelect(xDown, yDown, kRect, myLin.nVert, myLin.xVert, myLin.yVert, rWid, rHei, out nSelLine);
            if (nSelLine == 0)
                return;
            if (nSelLine > 8)
            {
                int num3 = (int)MessageBox.Show("Use Basic Symbols(number 1-8)", "Line's Symbol creation");
            }
            else
            {
                groupBox5.Visible = true;
                radioButton1.Checked = false;
                radioButton10.Checked = true;
                indBase = myLin.nBaseSymb[nSelLine];
                textBox6.Text = myLin.sSymbLine[nSelLine];
                textBox5.Text = string.Format("{0}", (object)(kSymbLine + 1));
                nSt1 = myLin.iStyle1[nSelLine];
                RadioStyle1(2, ref nSt1);
                nWid1 = myLin.iWidth1[nSelLine];
                RadioWidth1(2, ref nWid1);
                indBase = myLin.nBaseSymb[nSelLine];
                if (indBase < 8)
                {
                    groupBox11.Visible = false;
                    groupBox13.Visible = false;
                    groupBox14.Visible = false;
                }
                if (indBase == 8)
                {
                    groupBox11.Visible = true;
                    nSt1 = myLin.iStyle1[nSelLine];
                    RadioStyle1(2, ref nSt1);
                    nSt2 = myLin.iStyle2[nSelLine];
                    RadioStyle2(2, ref nSt2);
                    nWid2 = myLin.iWidth2[nSelLine];
                    RadioWidth2(2, ref nWid2);
                }
                button13.Visible = true;
                label4.Text = "";
            }
        }
        private void ItemsCreation_Click(object sender, EventArgs e)
        {
            nProcess = 10;
            groupBox2.Visible = true;
            radioButton1.Checked = true;
            radioButton10.Checked = false;
            textBox1.Text = "6.0";
            textBox2.Text = "3.0";
            button4.Visible = false;
            button12.Visible = false;
            button7.Visible = false;
            button5.Visible = false;
            button15.Visible = false;
            button32.Visible = false;
            button23.Visible = false;
            button25.Visible = false;
            button26.Visible = false;
            button27.Visible = false;
            button28.Visible = false;
            button29.Visible = false;
            button30.Visible = false;
            button31.Visible = false;
            button33.Visible = false;
            button34.Visible = false;
            groupBox5.Visible = false;
            groupBox7.Visible = false;
            button13.Visible = false;
            iListShow = 0;
            iListItemShow = 1;
            panel1.Invalidate();
        }

        private void ConfirmItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                int num1 = (int)MessageBox.Show("Check 'Width' and 'Height'", "Grid creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DllClass1.CheckText(textBox1.Text, out wSign, out iCond);
                if (iCond < 0)
                {
                    int num2 = (int)MessageBox.Show("Проверьте данные", "Grid creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DllClass1.CheckText(textBox2.Text, out hSign, out iCond);
                    if (iCond < 0)
                    {
                        int num3 = (int)MessageBox.Show("Проверьте данные", "Grid creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (wSign < 0.5)
                    {
                        int num4 = (int)MessageBox.Show("Width < 0.5 mm", "Grid creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (wSign > 10.0)
                    {
                        int num5 = (int)MessageBox.Show("Width > 10 mm", "Grid creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (hSign < 0.5)
                    {
                        int num6 = (int)MessageBox.Show("Height < 0.5 mm", "Grid creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (hSign > 5.0)
                    {
                        int num7 = (int)MessageBox.Show("Height > 5 mm", "Grid creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        button4.Visible = true;
                        button12.Visible = true;
                        button7.Visible = true;
                        button8.Visible = true;
                        button5.Visible = true;
                        button15.Visible = true;
                        button32.Visible = true;
                        button23.Visible = true;
                        button25.Visible = true;
                        button26.Visible = true;
                        button27.Visible = true;
                        button28.Visible = true;
                        button29.Visible = true;
                        button30.Visible = true;
                        button31.Visible = true;
                        button33.Visible = true;
                        button34.Visible = true;
                        DllClass1.GridCreate(2, iWidth, iHeight, wSign, hSign, sPixel, out kx, myLin.ixPix, out ky, myLin.iyPix, out kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out ix1Grid, out iy1Grid, out ix2Grid, out iy2Grid, pixWid, pixHei);
                        kSqu = 0;
                        kPixel = 0;
                        int num8 = iy2Grid - iy2Grid;
                        for (int index = 1; index <= ky; ++index)
                            myLin.iyPix[index] = myLin.iyPix[index] + num8;
                        for (int index = 1; index <= kPxy; ++index)
                        {
                            myLin.y1Pix[index] = myLin.y1Pix[index] + (double)num8;
                            myLin.y2Pix[index] = myLin.y2Pix[index] + (double)num8;
                        }
                        iy1Grid += num8;
                        iy2Grid += num8;
                        ixBeg = ix2Grid - (myLin.ixPix[kx] - myLin.ixPix[1]) / 2;
                        iyBeg = iy2Grid + 5;
                        panel1.Invalidate();
                    }
                }
            }
        }

        private void Pixel_Click(object sender, EventArgs e) => nControl = 101;

        private void Line_Click(object sender, EventArgs e) => nControl = 102;

        private void KeepItem_Click(object sender, EventArgs e)
        {
            myLin.FilePath();
            kLong = 0;
            if (kLong == 0 && kPixel < 2)
            {
                int num = (int)MessageBox.Show("Нет данных", "Item creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ++numLast;
                wSymbol = Convert.ToInt32(wSign / sPixel);
                hSymbol = Convert.ToInt32(hSign / sPixel);
                string str = string.Format("{0}", (object)numLast);
                FileStream output = new FileStream(myLin.fitemLine, FileMode.Append, FileAccess.Write);
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
                                binaryWriter.Write(myLin.ixSqu[index]);
                                binaryWriter.Write(myLin.iySqu[index]);
                                binaryWriter.Write(myLin.nColor[index]);
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
                for (int index = 1; index <= kRectItem; ++index)
                {
                    iListItemShow = 1;
                    iListShow = 0;
                    DllClass1.UpSign(kRectItem, myLin.yParc, pixHei, out iCond);
                    if (iCond == 0)
                        break;
                }
                kSqu = 0;
                kPixel = 0;
                panel1.Invalidate();
            }
        }

        private void LastDelete_Click(object sender, EventArgs e)
        {
            FormLoad();
            if (kItemLine == 0)
            {
                int num = (int)MessageBox.Show("Нет данных", "Item creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (kRectItem > 0)
                {
                    for (int index = 1; index <= kRectItem; ++index)
                    {
                        iListItemShow = 1;
                        iListShow = 0;
                        DllClass1.UpSign(kRectItem, myLin.yParc, pixHei, out iCond);
                        if (iCond == 0)
                        {
                            panel1.Invalidate();
                            break;
                        }
                    }
                }
                if (MessageBox.Show("Do you really want to delete last item?", "Lines symbols creation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                DllClass1.LastLineItem(ref kItemLine, myLin.fitemLine, myLin.fLinePixel);
                if (kItemLine == 0)
                    kRectItem = 0;
                FormLoad();
                if (kRectItem > 0)
                {
                    for (int index = 1; index <= kRectItem; ++index)
                    {
                        iListItemShow = 1;
                        iListShow = 0;
                        DllClass1.UpSign(kRectItem, myLin.yParc, pixHei, out iCond);
                        if (iCond == 0)
                            break;
                    }
                }
                kSqu = 0;
                kPixel = 0;
                panel1.Invalidate();
            }
        }

        private void SymbolUpdate_Click(object sender, EventArgs e)
        {
            nProcess = 30;
            groupBox2.Visible = false;
            groupBox5.Visible = false;
            groupBox7.Visible = false;
            button13.Visible = false;
            nSelLine = 0;
            iListShow = 1;
            iListItemShow = 0;
            for (int index = 1; index <= kRect; ++index)
            {
                iListShow = 1;
                DllClass1.DownSign(kRect, myLin.yVert, out iCond);
                if (iCond == 0)
                    break;
            }
            label4.Text = "Select appropriate symbol";
            panel1.Invalidate();
        }

        private void CopyBasic_Click(object sender, EventArgs e)
        {
            nProcess = 50;
            groupBox2.Visible = false;
            groupBox5.Visible = false;
            groupBox7.Visible = false;
            groupBox10.Visible = false;
            button13.Visible = false;
            iListShow = 1;
            iListItemShow = 0;
            for (int index = 1; index <= kRect; ++index)
            {
                DllClass1.DownSign(kRect, myLin.yVert, out iCond);
                if (iCond == 0)
                    break;
            }
            label4.Text = "Select appropriate basic symbol";
            panel1.Invalidate();
        }

        private void NewSymbol_Click(object sender, EventArgs e)
        {
            nProcess = 40;
            groupBox2.Visible = false;
            groupBox5.Visible = false;
            groupBox7.Visible = false;
            button13.Visible = false;
            iListItemShow = 0;
            kDown = 0;
            for (int index = 1; index <= kRect; ++index)
            {
                iListShow = 1;
                DllClass1.DownSign(kRect, myLin.yVert, out iCond);
                if (iCond == 0)
                    break;
            }
            label4.Text = "Select appropriate basic symbol";
            panel1.Invalidate();
        }

        private void LastSymbDelete_Click(object sender, EventArgs e)
        {
            if (kSymbLine < 9)
            {
                int num = (int)MessageBox.Show("Removing is possible only of last new created symbol", "Line's Symbol creation");
            }
            else
            {
                iListItemShow = 0;
                for (int index = 1; index <= kRect; ++index)
                {
                    iListShow = 1;
                    DllClass1.UpSign(kRect, myLin.yVert, pixHei, out iCond);
                    if (iCond == 0)
                    {
                        panel1.Invalidate();
                        break;
                    }
                }
                if (MessageBox.Show("Do you really want to delete last symbol ?", "Lines symbols creation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                --kSymbLine;
                myLin.kSymbLine = kSymbLine;
                DllClass1.LineSymbolKeep(myLin.fsymbLine, kSymbLine, hSymbLine, myLin.sSymbLine, myLin.x1Line, myLin.y1Line, myLin.x2Line, myLin.y2Line, myLin.xDescr, myLin.yDescr, myLin.x1Dens, myLin.y1Dens, myLin.x1Sign, myLin.y1Sign, myLin.x2Sign, myLin.y2Sign, myLin.n1Sign, myLin.n2Sign, myLin.iStyle1, myLin.iStyle2, myLin.iWidth1, myLin.iWidth2, myLin.nColLine, myLin.nItem, myLin.itemLoc, myLin.nBaseSymb, myLin.sInscr, myLin.hInscr, myLin.iColInscr, myLin.iDensity);
                FormLoad();
                for (int index = 1; index <= kRect; ++index)
                {
                    iListShow = 1;
                    DllClass1.UpSign(kRect, myLin.yVert, pixHei, out iCond);
                    if (iCond == 0)
                        break;
                }
                panel1.Invalidate();
            }
        }

        private void ConfirmSymbParam_Click(object sender, EventArgs e)
        {
            double tText = 0.0;
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
            if (textBox5.Text == "")
            {
                int num1 = (int)MessageBox.Show("Check parameters", "Line's Symbol corection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DllClass1.CheckText(textBox5.Text, out tText, out iCond);
                if (iCond < 0)
                {
                    int num2 = (int)MessageBox.Show("Check parameters", "Line's Symbol corection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (nProcess == 30)
                    {
                        if (textBox6.Text == "")
                        {
                            int num3 = (int)MessageBox.Show("Description incorrect", "Line's Symbol corection");
                            kNew = 0;
                            return;
                        }
                        myLin.sSymbLine[nSelLine] = textBox6.Text;
                        int int32 = Convert.ToInt32(textBox5.Text);
                        for (int index = 0; index <= kSymbLine; ++index)
                        {
                            if (myLin.n2Sign[index] == 0)
                                myLin.n2Sign[index] = myLin.n1Sign[index];
                            else if (myLin.n2Sign[index] != myLin.n1Sign[index] && myLin.n2Sign[index] == int32 && index != nSelLine)
                            {
                                int num4 = (int)MessageBox.Show("Duplicate of Your Code", "Line's Symbol corection");
                                kNew = 0;
                                return;
                            }
                        }
                        myLin.n2Sign[nSelLine] = Convert.ToInt32(textBox5.Text);
                        if (myLin.n2Sign[nSelLine] == 0)
                        {
                            myLin.n2Sign[nSelLine] = myLin.n1Sign[nSelLine];
                            textBox5.Text = string.Format("{0}", (object)myLin.n2Sign[nSelLine]);
                        }
                        RadioDensity(1, ref nDens);
                        myLin.iDensity[nSelLine] = nDens;
                        RadioStyle1(1, ref nSt1);
                        myLin.iStyle1[nSelLine] = nSt1;
                        RadioWidth1(1, ref nWid1);
                        myLin.iWidth1[nSelLine] = nWid1;
                        myLin.nColLine[nSelLine] = mColor;
                        nSelItem = myLin.nItem[nSelLine];
                        iLong = 0;
                        if (nSelItem > 0)
                            iLong = myLin.numLong[nSelItem];
                        if (nSelLine < 9)
                            myLin.iDensity[nSelLine] = 0;
                        if (iLong > 0)
                            myLin.iDensity[nSelLine] = 0;
                        if (indBase == 8)
                        {
                            RadioStyle2(1, ref nSt2);
                            myLin.iStyle2[nSelLine] = nSt2;
                            RadioWidth2(1, ref nWid2);
                            myLin.iWidth2[nSelLine] = nWid2;
                        }
                        groupBox5.Visible = false;
                        button13.Visible = false;
                    }
                    if (nProcess == 40)
                    {
                        mLocation = 0;
                        if (radioButton28.Checked)
                            mLocation = 1;
                        if (radioButton29.Checked)
                            mLocation = 2;
                        if (radioButton30.Checked)
                            mLocation = 3;
                        if (textBox6.Text == "")
                        {
                            int num5 = (int)MessageBox.Show("Description Error", "Line's Symbol creation");
                            return;
                        }
                        kNew = kSymbLine + 1;
                        myLin.sSymbLine[kNew] = textBox6.Text;
                        myLin.n1Sign[kNew] = kNew;
                        myLin.n2Sign[kNew] = Convert.ToInt32(textBox5.Text);
                        for (int index = 0; index <= kSymbLine; ++index)
                        {
                            if (myLin.n2Sign[index] == 0)
                                myLin.n2Sign[index] = myLin.n1Sign[index];
                            else if (myLin.n2Sign[index] == myLin.n2Sign[kNew])
                            {
                                int num6 = (int)MessageBox.Show("Duplicate of Your Code", "Line's Symbol creation");
                                kNew = 0;
                                return;
                            }
                        }
                        RadioDensity(1, ref nDens);
                        myLin.iDensity[kNew] = nDens;
                        RadioStyle1(1, ref nSt1);
                        myLin.iStyle1[kNew] = nSt1;
                        RadioWidth1(1, ref nWid1);
                        myLin.iWidth1[kNew] = nWid1;
                        myLin.nColLine[kNew] = mColor;
                        myLin.nBaseSymb[kNew] = indBase;
                        if (indBase == 8)
                        {
                            RadioStyle2(1, ref nSt2);
                            myLin.iStyle2[kNew] = nSt2;
                            RadioWidth2(1, ref nWid2);
                            myLin.iWidth2[kNew] = nWid2;
                        }
                        if (textBox11.Text == "")
                        {
                            int num7 = (int)MessageBox.Show("Check parameters", "Line's Symbol corection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        DllClass1.CheckText(textBox11.Text, out tText, out iCond);
                        if (iCond < 0)
                        {
                            int num8 = (int)MessageBox.Show("Check parameters", "Line's Symbol corection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        myLin.nItem[kNew] = nSelItem;
                        myLin.itemLoc[kNew] = mLocation;
                        myLin.sInscr[kNew] = "abcd";
                        myLin.hInscr[kNew] = 2.0;
                        myLin.iColInscr[kNew] = 1;
                        iLong = myLin.numLong[nSelItem];
                        if (iLong > 0)
                            myLin.iDensity[kNew] = 0;
                        kSymbLine = kNew;
                        label4.Text = "";
                    }
                    if (nProcess == 50)
                    {
                        mLocation = 0;
                        int num9 = 0;
                        if (textBox6.Text == "")
                        {
                            int num10 = (int)MessageBox.Show("Description Error", "Line's Symbol creation");
                            return;
                        }
                        kNew = kSymbLine + 1;
                        myLin.sSymbLine[kNew] = textBox6.Text;
                        myLin.n1Sign[kNew] = kNew;
                        myLin.n2Sign[kNew] = Convert.ToInt32(textBox5.Text);
                        for (int index = 0; index <= kSymbLine; ++index)
                        {
                            if (myLin.n2Sign[index] == 0)
                                myLin.n2Sign[index] = myLin.n1Sign[index];
                            else if (myLin.n2Sign[index] == myLin.n2Sign[kNew])
                            {
                                int num11 = (int)MessageBox.Show("Duplicate of Your Code", "Line's Symbol creation");
                                kNew = 0;
                                groupBox5.Visible = false;
                                return;
                            }
                        }
                        myLin.iDensity[kNew] = 0;
                        myLin.iStyle1[kNew] = nSt1;
                        RadioWidth1(1, ref nWid1);
                        myLin.iWidth1[kNew] = nWid1;
                        myLin.nColLine[kNew] = mColor;
                        myLin.nBaseSymb[kNew] = indBase;
                        if (indBase == 8)
                        {
                            RadioStyle1(1, ref nSt1);
                            myLin.iStyle1[kNew] = nSt1;
                            RadioStyle2(1, ref nSt2);
                            myLin.iStyle2[kNew] = nSt2;
                            RadioWidth2(1, ref nWid2);
                            myLin.iWidth2[kNew] = nWid2;
                        }
                        myLin.nItem[kNew] = 0;
                        myLin.itemLoc[kNew] = mLocation;
                        myLin.sInscr[kNew] = "abcd";
                        myLin.hInscr[kNew] = 2.0;
                        myLin.iColInscr[kNew] = num9;
                        kSymbLine = kNew;
                    }
                    if (nProcess == 30 || nProcess == 40 || nProcess == 50)
                    {
                        myLin.kSymbLine = kSymbLine;
                        DllClass1.LineSymbolKeep(myLin.fsymbLine, kSymbLine, hSymbLine, myLin.sSymbLine, myLin.x1Line, myLin.y1Line, myLin.x2Line, myLin.y2Line, myLin.xDescr, myLin.yDescr, myLin.x1Dens, myLin.y1Dens, myLin.x1Sign, myLin.y1Sign, myLin.x2Sign, myLin.y2Sign, myLin.n1Sign, myLin.n2Sign, myLin.iStyle1, myLin.iStyle2, myLin.iWidth1, myLin.iWidth2, myLin.nColLine, myLin.nItem, myLin.itemLoc, myLin.nBaseSymb, myLin.sInscr, myLin.hInscr, myLin.iColInscr, myLin.iDensity);
                        textBox5.Text = string.Format("{0}", (object)(myLin.n1Sign[kNew] + 1));
                    }
                    groupBox5.Visible = false;
                    groupBox7.Visible = false;
                    button13.Visible = false;
                    FormLoad();
                    for (int index = 1; index <= kRect; ++index)
                    {
                        iListShow = 1;
                        DllClass1.UpSign(kRect, myLin.yVert, pixHei, out iCond);
                        if (iCond == 0)
                            break;
                    }
                    nProcess = 0;
                    panel1.Invalidate();
                }
            }
        }

        public void RadioDensity(int iParam, ref int nDensity)
        {
            if (iParam == 1)
            {
                nDensity = 0;
                if (radioButton60.Checked)
                    nDensity = 0;
                if (radioButton31.Checked)
                    nDensity = 1;
                if (radioButton32.Checked)
                    nDensity = 2;
                if (radioButton33.Checked)
                    nDensity = 3;
                if (radioButton34.Checked)
                    nDensity = 4;
                if (radioButton35.Checked)
                    nDensity = 5;
            }
            if (iParam != 2)
                return;
            if (nDensity == 0)
            {
                radioButton60.Checked = true;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
            }
            if (nDensity == 0)
                radioButton60.Checked = true;
            if (nDensity == 1)
                radioButton31.Checked = true;
            if (nDensity == 2)
                radioButton32.Checked = true;
            if (nDensity == 3)
                radioButton33.Checked = true;
            if (nDensity == 4)
                radioButton34.Checked = true;
            if (nDensity != 5)
                return;
            radioButton35.Checked = true;
        }

        public void RadioStyle1(int iParam, ref int nStyle1)
        {
            if (iParam == 1)
            {
                nStyle1 = 0;
                if (radioButton36.Checked)
                    nStyle1 = 1;
                if (radioButton37.Checked)
                    nStyle1 = 2;
                if (radioButton38.Checked)
                    nStyle1 = 3;
                if (radioButton39.Checked)
                    nStyle1 = 4;
                if (radioButton40.Checked)
                    nStyle1 = 5;
                if (radioButton41.Checked)
                    nStyle1 = 6;
                if (radioButton42.Checked)
                    nStyle1 = 7;
            }
            if (iParam != 2)
                return;
            if (nStyle1 == 1)
                radioButton36.Checked = true;
            if (nStyle1 == 2)
                radioButton37.Checked = true;
            if (nStyle1 == 3)
                radioButton38.Checked = true;
            if (nStyle1 == 4)
                radioButton39.Checked = true;
            if (nStyle1 == 5)
                radioButton40.Checked = true;
            if (nStyle1 == 6)
                radioButton41.Checked = true;
            if (nStyle1 != 7)
                return;
            radioButton42.Checked = true;
        }

        public void RadioWidth1(int iParam, ref int nWidth1)
        {
            if (iParam == 1)
            {
                nWidth1 = 0;
                if (radioButton43.Checked)
                    nWidth1 = 1;
                if (radioButton44.Checked)
                    nWidth1 = 2;
                if (radioButton45.Checked)
                    nWidth1 = 3;
                if (radioButton46.Checked)
                    nWidth1 = 4;
                if (radioButton47.Checked)
                    nWidth1 = 5;
            }
            if (iParam != 2)
                return;
            if (nWidth1 == 1)
                radioButton43.Checked = true;
            if (nWidth1 == 2)
                radioButton44.Checked = true;
            if (nWidth1 == 3)
                radioButton45.Checked = true;
            if (nWidth1 == 4)
                radioButton46.Checked = true;
            if (nWidth1 != 5)
                return;
            radioButton47.Checked = true;
        }

        public void RadioStyle2(int iParam, ref int nStyle2)
        {
            if (iParam == 1)
            {
                nStyle2 = 0;
                if (radioButton48.Checked)
                    nStyle2 = 1;
                if (radioButton49.Checked)
                    nStyle2 = 2;
                if (radioButton50.Checked)
                    nStyle2 = 3;
                if (radioButton51.Checked)
                    nStyle2 = 4;
                if (radioButton52.Checked)
                    nStyle2 = 5;
                if (radioButton53.Checked)
                    nStyle2 = 6;
                if (radioButton54.Checked)
                    nStyle2 = 7;
            }
            if (iParam != 2)
                return;
            if (nStyle2 == 1)
                radioButton48.Checked = true;
            if (nStyle2 == 2)
                radioButton49.Checked = true;
            if (nStyle2 == 3)
                radioButton50.Checked = true;
            if (nStyle2 == 4)
                radioButton51.Checked = true;
            if (nStyle2 == 5)
                radioButton52.Checked = true;
            if (nStyle2 == 6)
                radioButton53.Checked = true;
            if (nStyle2 != 7)
                return;
            radioButton54.Checked = true;
        }

        public void RadioWidth2(int iParam, ref int nWidth2)
        {
            if (iParam == 1)
            {
                nWidth2 = 0;
                if (radioButton55.Checked)
                    nWidth2 = 1;
                if (radioButton56.Checked)
                    nWidth2 = 2;
                if (radioButton57.Checked)
                    nWidth2 = 3;
                if (radioButton58.Checked)
                    nWidth2 = 4;
                if (radioButton59.Checked)
                    nWidth2 = 5;
            }
            if (iParam != 2)
                return;
            if (nWidth2 == 1)
                radioButton55.Checked = true;
            if (nWidth2 == 2)
                radioButton56.Checked = true;
            if (nWidth2 == 3)
                radioButton57.Checked = true;
            if (nWidth2 == 4)
                radioButton58.Checked = true;
            if (nWidth2 != 5)
                return;
            radioButton59.Checked = true;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            nControl = 103;
            RadioColor(ref mColor);
            DllClass1.GridRectangle(1, kx, myLin.ixPix, ky, myLin.iyPix, out kCell, myLin.xCell, myLin.yCell);
            int kArray = 999999;
            DllClass1.doubleArray(myLin.xSqu, ref kArray);
            DllClass1.doubleArray(myLin.ySqu, ref kArray);
            DllClass1.intArray(myLin.numCol, ref kArray);
            int num1 = kArray - 10;
            if (kCell > 0)
            {
                for (int index = 1; index <= kCell; ++index)
                {
                    ++kSqu;
                    if (kSqu > num1)
                    {
                        int num2 = (int)MessageBox.Show("Index array Rectangle");
                        return;
                    }
                    myLin.xSqu[kSqu] = myLin.xCell[index];
                    myLin.ySqu[kSqu] = myLin.yCell[index];
                    myLin.numCol[kSqu] = mColor;
                }
                ++kAction;
                DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
            }
            panel1.Invalidate();
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            nControl = 105;
            RadioColor(ref mColor);
            DllClass1.GridEllipse(1, kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myLin.xSqu, ref kArray);
                DllClass1.doubleArray(myLin.ySqu, ref kArray);
                DllClass1.intArray(myLin.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Index array Ellipse");
                            return;
                        }
                        myLin.xSqu[kSqu] = myLin.xCell[index];
                        myLin.ySqu[kSqu] = myLin.yCell[index];
                        myLin.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        public void RectLineSign(
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
            idx = 150;
            idy = 2 * hSymbLine;
            int num2 = 500 / idx;
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

        public void SymbLineDraw(
          PaintEventArgs e,
          string fitemLine,
          int kRect,
          int[] nRect,
          double[] xRect,
          double[] yRect,
          int idx,
          int idy,
          int kSymbLine,
          int[] n2Sign,
          int[] nBaseSymb,
          int[] nColLine,
          int[] iWidth1,
          int[] iWidth2,
          int[] iStyle1,
          int[] iStyle2,
          int[] nItem,
          int[] itemLoc,
          int[] iDensity,
          int[] nColorItm,
          int[] ixp,
          int[] iyp,
          SolidBrush[] brColor,
          Pen[] pnCol)
        {
            Graphics graphics = e.Graphics;
            string sTxt = "";
            int num1 = 1;
            double[] x = new double[5];
            double[] y = new double[5];
            double[] xAng = new double[5];
            double[] yAng = new double[5];
            double[] xit = new double[20];
            double[] yit = new double[20];
            int emSize = 8;
            Font font = new Font("Arial", (float)emSize);
            SolidBrush solidBrush1 = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Gray, 1f);
            for (int index1 = 1; index1 <= kRect; ++index1)
            {
                int index2 = nRect[index1];
                int num2 = n2Sign[index2];
                int int32_1 = Convert.ToInt32(xRect[index2]);
                int int32_2 = Convert.ToInt32(yRect[index2]);
                string s = string.Format("{0}", (object)index2) + "-" + string.Format("{0}", (object)num2);
                graphics.DrawString(s, font, (Brush)solidBrush1, (float)int32_1, (float)int32_2);
                int num3 = int32_1 + 35;
                x[0] = 1.0 * (double)num3;
                x[1] = 1.0 * (double)(num3 + 80);
                y[0] = 1.0 * (double)(int32_2 + idy / 2);
                y[1] = 1.0 * (double)(int32_2 + idy / 2);
                int nBase = nBaseSymb[index2];
                int index3 = nColLine[index2];
                int iWid1 = iWidth1[index2];
                int iWid2 = iWidth2[index2];
                int iStyle3 = iStyle1[index2];
                int iStyle4 = iStyle2[index2];
                int nSelect = nItem[index2];
                int num4 = itemLoc[index2];
                int nDensity = iDensity[index2];
                SolidBrush solidBrush2 = brColor[index3];
                Pen jColor = pnCol[index3];
                if (nSelect > 0)
                {
                    int iLong;
                    int iWid3;
                    int iHei;
                    int kPix;
                    DllClass1.SelItemLine(fitemLine, nSelect, out iLong, out iWid3, out iHei, out kPix, ixp, iyp, nColorItm, out sTxt, out int _);
                    int kit;
                    if (nDensity == 1)
                    {
                        for (int index4 = 0; index4 <= num1; ++index4)
                        {
                            xAng[index4] = x[index4];
                            yAng[index4] = y[index4];
                        }
                        DllClass1.CoordLineItem(nDensity, num1, xAng, yAng, nBase, out kit, xit, yit);
                        if (iLong == 0)
                        {
                            for (int index5 = 1; index5 <= kit; ++index5)
                            {
                                int int32_3 = Convert.ToInt32(xit[index5]);
                                int int32_4 = Convert.ToInt32(yit[index5]);
                                if (nBase < 8)
                                {
                                    int32_3 -= iWid3 / 2;
                                    int32_4 -= iHei / 2;
                                    if (num4 == 1)
                                        int32_4 -= iHei / 2;
                                    if (num4 == 3)
                                        int32_4 += iHei / 2;
                                }
                                if (nBase == 8)
                                {
                                    int32_3 -= iWid3 / 2;
                                    int32_4 -= iHei / 2;
                                    if (num4 == 1)
                                        int32_4 -= iHei;
                                    if (num4 == 3)
                                        int32_4 += iHei;
                                }
                                DllClass1.SignDraw(e, int32_3, int32_4, kPix, ixp, iyp, nColorItm, brColor);
                            }
                        }
                    }
                    if (nDensity > 1)
                    {
                        int num5 = 0;
                        if (iLong == 0)
                        {
                            int int32_5 = Convert.ToInt32(x[0]);
                            int int32_6 = Convert.ToInt32(x[1]);
                            int int32_7 = Convert.ToInt32(y[0]);
                            if (nDensity == 1)
                                num5 = 5 * iWid3;
                            if (nDensity == 2)
                                num5 = 4 * iWid3;
                            if (nDensity == 3)
                                num5 = 3 * iWid3;
                            if (nDensity == 4)
                                num5 = 2 * iWid3;
                            if (nDensity == 5)
                                num5 = iWid3;
                            if (num5 > 0)
                            {
                                kit = (int32_6 - int32_5) / num5 + 1;
                                int ixh = int32_5 - num5;
                                for (int index6 = 1; index6 <= kit; ++index6)
                                {
                                    ixh += num5;
                                    int iyh = int32_7;
                                    if (nBase < 8)
                                    {
                                        iyh -= iHei / 2;
                                        if (num4 == 1)
                                            iyh -= iHei / 2;
                                        if (num4 == 3)
                                            iyh += iHei / 2;
                                    }
                                    if (nBase == 8)
                                    {
                                        iyh -= iHei / 2;
                                        if (num4 == 1)
                                            iyh -= iHei;
                                        if (num4 == 3)
                                            iyh += iHei;
                                    }
                                    DllClass1.SignDraw(e, ixh, iyh, kPix, ixp, iyp, nColorItm, brColor);
                                }
                            }
                        }
                    }
                }
                if (nBase == 1 || nBase == 2)
                {
                    jColor.Width = (float)iWid1;
                    DllClass1.LineSymbolStyle(e, jColor, iStyle3, num1, x, y, iWid1);
                }
                if (nBase > 2 && nBase < 8)
                {
                    jColor.Width = (float)iWid1;
                    DllClass1.LineSymbolStyle(e, jColor, iStyle3, num1, x, y, iWid1);
                }
                if (nBase == 8)
                {
                    int num6 = int32_2 - 3 + idy / 2;
                    jColor.Width = (float)iWid1;
                    if (iStyle3 == 1 || iStyle3 == 2)
                    {
                        y[0] = (double)num6;
                        y[1] = (double)num6;
                        DllClass1.LineSymbolStyle(e, jColor, iStyle3, num1, x, y, iWid1);
                    }
                    if (iStyle3 > 2 && iStyle3 < 8)
                    {
                        y[0] = (double)num6;
                        y[1] = (double)num6;
                        DllClass1.LineSymbolStyle(e, jColor, iStyle3, num1, x, y, iWid1);
                    }
                    jColor.Width = (float)iWid2;
                    int num7 = int32_2 + 3 + idy / 2;
                    if (iStyle4 == 1 || iStyle4 == 2)
                    {
                        y[0] = (double)num7;
                        y[1] = (double)num7;
                        DllClass1.LineSymbolStyle(e, jColor, iStyle4, num1, x, y, iWid2);
                    }
                    if (iStyle4 > 2 && iStyle4 < 8)
                    {
                        y[0] = (double)num7;
                        y[1] = (double)num7;
                        DllClass1.LineSymbolStyle(e, jColor, iStyle4, num1, x, y, iWid2);
                    }
                }
                graphics.DrawRectangle(pen, int32_1 - 1, int32_2 - emSize / 2, idx, idy);
            }
        }

        private void UpOne_Click(object sender, EventArgs e)
        {
            DllClass1.UpSign(kRect, myLin.yVert, pixHei, out iCond);
            panel1.Invalidate();
        }

        private void DownOne_Click(object sender, EventArgs e)
        {
            DllClass1.DownSign(kRect, myLin.yVert, out iCond);
            panel1.Invalidate();
        }

        private void MoreDetail_Click(object sender, EventArgs e)
        {
            int num1 = 200;
            if (File.Exists(myLin.fileAdd))
                File.Delete(myLin.fileAdd);
            FileStream output = new FileStream(myLin.fileAdd, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(num1);
            binaryWriter.Close();
            output.Close();
            int num2 = (int)new ListLineSign().ShowDialog((IWin32Window)this);
        }

        private void SignOnOff_Click(object sender, EventArgs e)
        {
            iListShow = iListShow <= 0 ? 1 : 0;
            panel1.Invalidate();
        }

        public void RectItemLine(
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
            if (kItemLine == 0)
                return;
            int num1 = 505;
            int num2 = 265;
            idx = 2 * iwItem + iwItem / 4;
            idy = ihItem + ihItem / 2;
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
            graphics.DrawString("ITEMS", font2, (Brush)solidBrush, (float)int32_1, (float)y);
            for (int index = 1; index <= kRectItem; ++index)
            {
                int nSelect = nRectItem[index];
                int int32_2 = Convert.ToInt32(xRectItem[nSelect]);
                int int32_3 = Convert.ToInt32(yRectItem[nSelect]);
                string s = string.Format("{0}", (object)nSelect);
                graphics.DrawString(s, font1, (Brush)solidBrush, (float)int32_2, (float)int32_3);
                int ixh = int32_2 + idx / 3;
                int kPix;
                DllClass1.SelItemLine(fitemLine, nSelect, out int _, out int _, out int _, out kPix, ixp, iyp, nColorItm, out sTxt, out int _);
                DllClass1.SignDraw(e, ixh, int32_3 + emSize, kPix, ixp, iyp, nColorItm, brColor);
                graphics.DrawRectangle(pen, int32_2 - 1, int32_3 - emSize / 2, idx, idy);
            }
        }

        private void UpItem_Click(object sender, EventArgs e)
        {
            DllClass1.UpSign(kRectItem, myLin.yParc, pixHei, out iCond);
            panel1.Invalidate();
        }

        private void DownItem_Click(object sender, EventArgs e)
        {
            DllClass1.DownItem(kRectItem, myLin.yParc, out iCond);
            panel1.Invalidate();
        }

        private void ItemsList_Click(object sender, EventArgs e)
        {
            iListItemShow = iListItemShow <= 0 ? 1 : 0;
            panel1.Invalidate();
        }

        private void Hexagon_Click(object sender, EventArgs e)
        {
            nControl = 122;
            RadioColor(ref mColor);
            DllClass1.GridHexagon(1, kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myLin.xSqu, ref kArray);
                DllClass1.doubleArray(myLin.ySqu, ref kArray);
                DllClass1.intArray(myLin.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Index array FillHexagon");
                            return;
                        }
                        myLin.xSqu[kSqu] = myLin.xCell[index];
                        myLin.ySqu[kSqu] = myLin.yCell[index];
                        myLin.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void ArcLeft_Click(object sender, EventArgs e)
        {
            nControl = 108;
            RadioColor(ref mColor);
            DllClass1.GridArc(1, kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myLin.xSqu, ref kArray);
                DllClass1.doubleArray(myLin.ySqu, ref kArray);
                DllClass1.intArray(myLin.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Index array ArcLeft");
                            return;
                        }
                        myLin.xSqu[kSqu] = myLin.xCell[index];
                        myLin.ySqu[kSqu] = myLin.yCell[index];
                        myLin.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void ArcRight_Click(object sender, EventArgs e)
        {
            nControl = 109;
            RadioColor(ref mColor);
            DllClass1.GridArc(2, kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myLin.xSqu, ref kArray);
                DllClass1.doubleArray(myLin.ySqu, ref kArray);
                DllClass1.intArray(myLin.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Index array ArcRight");
                            return;
                        }
                        myLin.xSqu[kSqu] = myLin.xCell[index];
                        myLin.ySqu[kSqu] = myLin.yCell[index];
                        myLin.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void ArcTop_Click(object sender, EventArgs e)
        {
            nControl = 111;
            RadioColor(ref mColor);
            DllClass1.GridArc(3, kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myLin.xSqu, ref kArray);
                DllClass1.doubleArray(myLin.ySqu, ref kArray);
                DllClass1.intArray(myLin.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Index array ArcTop");
                            return;
                        }
                        myLin.xSqu[kSqu] = myLin.xCell[index];
                        myLin.ySqu[kSqu] = myLin.yCell[index];
                        myLin.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void ArcBottom_Click(object sender, EventArgs e)
        {
            nControl = 112;
            RadioColor(ref mColor);
            DllClass1.GridArc(4, kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myLin.xSqu, ref kArray);
                DllClass1.doubleArray(myLin.ySqu, ref kArray);
                DllClass1.intArray(myLin.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Index array ArcBottom");
                            return;
                        }
                        myLin.xSqu[kSqu] = myLin.xCell[index];
                        myLin.ySqu[kSqu] = myLin.yCell[index];
                        myLin.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleLeft_Click(object sender, EventArgs e)
        {
            nControl = 113;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(1, kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myLin.xSqu, ref kArray);
                DllClass1.doubleArray(myLin.ySqu, ref kArray);
                DllClass1.intArray(myLin.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Index array TriangleLeft");
                            return;
                        }
                        myLin.xSqu[kSqu] = myLin.xCell[index];
                        myLin.ySqu[kSqu] = myLin.yCell[index];
                        myLin.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleRight_Click(object sender, EventArgs e)
        {
            nControl = 115;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(3, kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myLin.xSqu, ref kArray);
                DllClass1.doubleArray(myLin.ySqu, ref kArray);
                DllClass1.intArray(myLin.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Index array TriangleRight");
                            return;
                        }
                        myLin.xSqu[kSqu] = myLin.xCell[index];
                        myLin.ySqu[kSqu] = myLin.yCell[index];
                        myLin.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleTop_Click(object sender, EventArgs e)
        {
            nControl = 117;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(5, kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myLin.xSqu, ref kArray);
                DllClass1.doubleArray(myLin.ySqu, ref kArray);
                DllClass1.intArray(myLin.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Index array TriangleTop");
                            return;
                        }
                        myLin.xSqu[kSqu] = myLin.xCell[index];
                        myLin.ySqu[kSqu] = myLin.yCell[index];
                        myLin.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void TriangleBottom_Click(object sender, EventArgs e)
        {
            nControl = 119;
            RadioColor(ref mColor);
            DllClass1.GridTriangle(7, kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myLin.xSqu, ref kArray);
                DllClass1.doubleArray(myLin.ySqu, ref kArray);
                DllClass1.intArray(myLin.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Index array TriangleBottom");
                            return;
                        }
                        myLin.xSqu[kSqu] = myLin.xCell[index];
                        myLin.ySqu[kSqu] = myLin.yCell[index];
                        myLin.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }

        private void CircleTriangle_Click(object sender, EventArgs e)
        {
            nControl = 124;
            RadioColor(ref mColor);
            DllClass1.TriangleCircle(kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, myLin.xDat, myLin.yDat, out iCond);
            if (iCond < 0)
            {
                nControl = 0;
                int num = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kArray = 999999;
                DllClass1.doubleArray(myLin.xSqu, ref kArray);
                DllClass1.doubleArray(myLin.ySqu, ref kArray);
                DllClass1.intArray(myLin.numCol, ref kArray);
                int num1 = kArray - 10;
                if (kCell > 0)
                {
                    for (int index = 1; index <= kCell; ++index)
                    {
                        ++kSqu;
                        if (kSqu > num1)
                        {
                            int num2 = (int)MessageBox.Show("Index array FillHexagon");
                            return;
                        }
                        myLin.xSqu[kSqu] = myLin.xCell[index];
                        myLin.ySqu[kSqu] = myLin.yCell[index];
                        myLin.numCol[kSqu] = mColor;
                    }
                    ++kAction;
                    DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                }
                panel1.Invalidate();
            }
        }
        private void Concentric_Click(object sender, EventArgs e)
        {
            nControl = 107;
            RadioColor(ref mColor);
            DllClass1.ConcentricCircle(kx, myLin.ixPix, ky, myLin.iyPix, kPxy, myLin.x1Pix, myLin.y1Pix, myLin.x2Pix, myLin.y2Pix, out kCell, myLin.xCell, myLin.yCell, out kSpot, myLin.xSpot, myLin.ySpot, myLin.xAngel, myLin.yAngel, myLin.xDat, myLin.yDat, out iCond);
            int kArray = 999999;
            DllClass1.doubleArray(myLin.xSqu, ref kArray);
            DllClass1.doubleArray(myLin.ySqu, ref kArray);
            DllClass1.intArray(myLin.numCol, ref kArray);
            int num1 = kArray - 10;
            if (kCell > 0)
            {
                for (int index = 1; index <= kCell; ++index)
                {
                    ++kSqu;
                    if (kSqu > num1)
                    {
                        int num2 = (int)MessageBox.Show("Index array Concentric");
                        return;
                    }
                    myLin.xSqu[kSqu] = myLin.xCell[index];
                    myLin.ySqu[kSqu] = myLin.yCell[index];
                    myLin.numCol[kSqu] = mColor;
                }
                ++kAction;
                DllClass1.GridPixel(kSqu, myLin.xSqu, myLin.ySqu, myLin.numCol, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColor, ix1Grid, iy1Grid);
                if (iCond < 0)
                {
                    int num3 = (int)MessageBox.Show("Use option 'Handwork'", "Symbol creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            panel1.Invalidate();
        }
    }
}
