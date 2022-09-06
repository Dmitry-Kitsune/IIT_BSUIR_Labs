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
    public partial class CadContours : Form
    {
        private string fileTemp = "";
        private string fileTmps = "";
        private int iWidth;
        private int iHeight;
        private int kSymbPnt;
        private int kSymbLine;
        private int hSymbLine = 18;
        private int kHeight;
        private int kVert;
        private int xBegWin;
        private int yBegWin;
        private int xEndWin;
        private int yEndWin;
        private int iPointShow = 1;
        private int iHeigShow = 1;
        private int kTriang;
        private int kCenTri;
        private int kCavei;
        private int nProcess;
        private int nControl;
        private int iTriangShow;
        private int iContourShow = 1;
        private int x1Box;
        private int y1Box;
        private int x2Box;
        private int y2Box;
        private int kSelPol;
        private int kDat;
        private int[] xDat = new int[50];
        private int[] yDat = new int[50];
        private int kInter;
        private int kPoly;
        private int kSelLine;
        private int kPntPlus;
        private int kPntInput;
        private int kLineInput;
        private int iParam;
        private int iPolygonShow = 1;
        private int kPntSource;
        private int nVertex = 5000;
        private int kBorder;
        private int kSqu;
        private int iLong;
        private int kCycle;
        private int iLineShow = 1;
        private int kChange;
        private int kLineTopo;
        private double xmin;
        private double ymin;
        private double xmax;
        private double ymax;
        private double zmin;
        private double zmax;
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
        private double scaleToWin;
        private double scaleToGeo;
        private double xBegX;
        private double yBegY;
        private double xEndX;
        private double yEndY;
        private double sRel;
        private double xSelect;
        private double ySelect;
        private double[] xSelPnt = new double[10];
        private double[] ySelPnt = new double[10];
        private double xSplit;
        private double ySplit;
        private double xSplPnt;
        private double ySplPnt;
        private int iGraphic;
        private int iCond;
        private int newTriangle;
        private int kVertLine;
        private int pixWid;
        private int pixHei;
        private double xCurMin;
        private double yCurMin;
        private double xCurMax;
        private double yCurMax;
        private double dx;
        private double dy;
        private bool isDrag;

        private MyGeodesy myTop = new MyGeodesy();

        public string fCurPnt { get; private set; }
        public string fCurHeig { get; private set; }
        public string fCurLine { get; private set; }
        public string fCurContour { get; private set; }
        public string fCurBorder { get; private set; }

        //public double hSect { get; private set; }

        public CadContours()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            pixWid = panel7.Bounds.Width;
            pixHei = panel7.Bounds.Height;
            if (pixWid <= pixHei)
                iWidth = iHeight = pixWid;
            if (pixWid > pixHei)
                iWidth = iHeight = pixHei;
            panel1.BorderStyle = StatusBarPanelBorderStyle.Raised;
            panel2.BorderStyle = StatusBarPanelBorderStyle.Raised;
            panel3.BorderStyle = StatusBarPanelBorderStyle.Raised;
            panel4.BorderStyle = StatusBarPanelBorderStyle.Raised;
            panel5.BorderStyle = StatusBarPanelBorderStyle.Raised;
            panel6.BorderStyle = StatusBarPanelBorderStyle.Raised;
            panel1.AutoSize = StatusBarPanelAutoSize.Spring;
            panel2.AutoSize = StatusBarPanelAutoSize.Contents;
            panel3.AutoSize = StatusBarPanelAutoSize.Contents;
            panel4.AutoSize = StatusBarPanelAutoSize.Contents;
            panel5.AutoSize = StatusBarPanelAutoSize.Contents;
            panel6.AutoSize = StatusBarPanelAutoSize.Contents;
            panel1.Text = "Готов...";
            panel3.Text = "**";
            panel5.Text = "**";
            panel6.Text = DateTime.Now.ToShortDateString();
            statusBar1.Enabled = true;
            statusBar1.Font = new Font(Font, FontStyle.Bold);
            statusBar1.ShowPanels = true;
            statusBar1.Panels.Add(panel1);
            statusBar1.Panels.Add(panel2);
            statusBar1.Panels.Add(panel3);
            statusBar1.Panels.Add(panel4);
            statusBar1.Panels.Add(panel5);
            statusBar1.Panels.Add(panel6);
            Controls.Add((Control)statusBar1);
            button22.MouseHover += new EventHandler(button22_MouseHover);
            button22.MouseLeave += new EventHandler(button1_MouseLeave);
            button1.MouseHover += new EventHandler(button1_MouseHover);
            button1.MouseLeave += new EventHandler(button1_MouseLeave);
            button2.MouseHover += new EventHandler(button2_MouseHover);
            button2.MouseLeave += new EventHandler(button1_MouseLeave);
            button3.MouseHover += new EventHandler(button3_MouseHover);
            button3.MouseLeave += new EventHandler(button1_MouseLeave);
            button4.MouseHover += new EventHandler(button4_MouseHover);
            button4.MouseLeave += new EventHandler(button1_MouseLeave);
            button5.MouseHover += new EventHandler(button5_MouseHover);
            button5.MouseLeave += new EventHandler(button1_MouseLeave);
            button6.MouseHover += new EventHandler(button6_MouseHover);
            button6.MouseLeave += new EventHandler(button1_MouseLeave);
            button7.MouseHover += new EventHandler(button7_MouseHover);
            button7.MouseLeave += new EventHandler(button1_MouseLeave);
            button8.MouseHover += new EventHandler(button8_MouseHover);
            button8.MouseLeave += new EventHandler(button1_MouseLeave);
            button14.MouseHover += new EventHandler(button14_MouseHover);
            button14.MouseLeave += new EventHandler(button1_MouseLeave);
            button15.MouseHover += new EventHandler(button15_MouseHover);
            button15.MouseLeave += new EventHandler(button1_MouseLeave);
            button16.MouseHover += new EventHandler(button16_MouseHover);
            button16.MouseLeave += new EventHandler(button1_MouseLeave);
            button17.MouseHover += new EventHandler(button17_MouseHover);
            button17.MouseLeave += new EventHandler(button1_MouseLeave);
            button18.MouseHover += new EventHandler(button18_MouseHover);
            button18.MouseLeave += new EventHandler(button1_MouseLeave);
            button12.MouseHover += new EventHandler(button12_MouseHover);
            button12.MouseLeave += new EventHandler(button1_MouseLeave);
            button23.MouseHover += new EventHandler(button23_MouseHover);
            button23.MouseLeave += new EventHandler(button1_MouseLeave);
            button24.MouseHover += new EventHandler(button24_MouseHover);
            button24.MouseLeave += new EventHandler(button1_MouseLeave);
            button26.MouseHover += new EventHandler(button26_MouseHover);
            button26.MouseLeave += new EventHandler(button1_MouseLeave);
            button29.MouseHover += new EventHandler(button29_MouseHover);
            button29.MouseLeave += new EventHandler(button1_MouseLeave);
            button32.MouseHover += new EventHandler(button32_MouseHover);
            button32.MouseLeave += new EventHandler(button1_MouseLeave);
            button30.MouseHover += new EventHandler(button30_MouseHover);
            button30.MouseLeave += new EventHandler(button1_MouseLeave);
            button27.MouseHover += new EventHandler(button27_MouseHover);
            button27.MouseLeave += new EventHandler(button1_MouseLeave);
            button28.MouseHover += new EventHandler(button28_MouseHover);
            button28.MouseLeave += new EventHandler(button1_MouseLeave);
            myTop.FilePath();
            FormLoad();
        }
        private void button22_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Закрыть окно";

        private void button1_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите кнопку. Зажмите левую кнопкой мыши и переместите мышь. После выбора области отпустите кнопку. Нажмите правую кнопку мыши для исходного положения";

        private void button1_MouseLeave(object sender, EventArgs e) 
            => label1.Text = "";

        private void button2_MouseHover(object sender, EventArgs e)
            => label1.Text = "После нажатия на эту кнопку и отпустив левую кнопку мыши возле выбранной точки. Нажмите правую кнопку для исходного положения";

        private void button3_MouseHover(object sender, EventArgs e) 
            => label1.Text = "После нажатия на эту кнопку и отпустив левую кнопку мыши возле выбранной точки. Нажмите правую кнопку для исходного положения";

        private void button4_MouseHover(object sender, EventArgs e) 
            => label1.Text = "После нажатия на эту кнопку левую кнопкой мыши ведите вдоль экрана. Нажмите правую кнопку для возврата исходное положение";

        private void button5_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. В диалоговом окне выберите интервал(участок рельефа) и нажмите 'Подтвердить'";

        private void button6_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. Левой кнопкой мыши выделите общую сторону двух треугольников";

        private void button7_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. Левой кнопкой мыши выделить треугольник(Центр) for removing";

        private void button8_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. В диалоговом окне выберите интервал(участок рельефа) и нажмите 'Подтвердить'";

        private void button14_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку для изменения плавности при необходимости(линии пересечения)";

        private void button15_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку для изменения плавности горизонталей";

        private void button16_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. Левой кнопкой мыши выделите линию в точке для разделения линии";

        private void button17_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. Левой кнопкой мыши выделить часть линии для удаления";

        private void button18_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку для восстановления последней удаленной линии";

        private void button12_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. Левой кнопкой мыши выберите один или несколько полигонов(Знаков) и нажмите правую кнопку";

        private void button23_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. Левой кнопкой мыши выберите линию для изменения плавности";

        private void button24_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. Левой кнопкой мыши выберите линию для изменения плавности";

        private void button26_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. Левой кнопкой мыши выберите любые три точки";

        private void button29_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. Автоматическое добавление вершин для всех линий";

        private void button32_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. Выберите линии для добавления вершин. После выбора щелкните правой кнопкой мыши";

        private void button30_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку for removing all vertexes";

        private void button27_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку. Автоматическая модель коррекции рельефа путем обновления связи между треугольниками";

        private void button28_MouseHover(object sender, EventArgs e) 
            => label1.Text = "Нажмите эту кнопку для возвращаемого в состояние до коррекции модели";

        private void FormLoad()
        {
            xmin = 9999999.9;
            ymin = 9999999.9;
            zmin = 9999999.9;
            xmax = -9999999.9;
            ymax = -9999999.9;
            zmax = -9999999.9;
           DllClass1.SetColour(myTop.brColor, myTop.pnColor);
           DllClass1.SetColour(myTop.brColor, myTop.pnColor);
           DllClass1.PointSymbLoad(myTop.fsymbPnt, out kSymbPnt, myTop.numRec, myTop.numbUser, myTop.heiSymb);
           DllClass1.LineSymbolLoad(myTop.fsymbLine, out kSymbLine, out hSymbLine, myTop.sSymbLine, myTop.x1Line, myTop.y1Line, myTop.x2Line, myTop.y2Line, myTop.xDescr, myTop.yDescr, myTop.x1Dens, myTop.y1Dens, myTop.x1Sign, myTop.y1Sign, myTop.x2Sign, myTop.y2Sign, myTop.n1Sign, myTop.n2Sign, myTop.iStyle1, myTop.iStyle2, myTop.iWidth1, myTop.iWidth2, myTop.nColLine, myTop.nItem, myTop.itemLoc, myTop.nBaseSymb, myTop.sInscr, myTop.hInscr, myTop.iColInscr, myTop.iDensity);
            myTop.PointLoad(fCurPnt, fCurHeig);
            kPntPlus = myTop.kPntPlus;
            kPntInput = myTop.kPntInput;
            if (kPntPlus < 2)
                return;
            xmin = myTop.xmin;
            ymin = myTop.ymin;
            xmax = myTop.xmax;
            ymax = myTop.ymax;
            zmin = myTop.zmin;
            zmax = myTop.zmax;
            myTop.LoadPntSour();
            kPntSource = myTop.kPntSource;
            myTop.PointHeight(fCurHeig);
            kHeight = myTop.kHeight;
            xmin = myTop.xmin;
            ymin = myTop.ymin;
            xmax = myTop.xmax;
            ymax = myTop.ymax;
            zmin = myTop.zmin;
            zmax = myTop.zmax;
            myTop.LineTopoLoad();
            kLineTopo = myTop.kLineTopo;
            iParam = 1;
            kLineInput = 0;
            myTop.LineLoad(fCurLine);
            kLineInput = myTop.kLineInput;
            xmin = myTop.xmin;
            ymin = myTop.ymin;
            xmax = myTop.xmax;
            ymax = myTop.ymax;
            Cursor.Current = Cursors.WaitCursor;
            if (File.Exists(myTop.fpointInscr))
            {
                File.Delete(myTop.fpointInscr);
                FileStream output = new FileStream(myTop.fpointInscr, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(kPntSource);
                for (int index = 0; index <= kPntSource; ++index)
                {
                    myTop.xPntInscr[index] = myTop.xSour[index];
                    myTop.yPntInscr[index] = myTop.ySour[index];
                    myTop.iHorVerPnt[index] = 0;
                    binaryWriter.Write(myTop.xSour[index]);
                    binaryWriter.Write(myTop.ySour[index]);
                    binaryWriter.Write(myTop.iHorVerPnt[index]);
                }
                binaryWriter.Close();
                output.Close();
                myTop.kPntPlus = kPntSource;
                myTop.LoadKeepInscr(2);
            }
            Cursor.Current = Cursors.WaitCursor;
            myTop.TriangInput(myTop.fileTrian);
            kTriang = myTop.kTriang;
            if (kTriang > 3)
            {
                kCenTri = 0;
               DllClass1.CenterTre(kTriang, myTop.xTre, myTop.yTre, out kCenTri, myTop.xCent, myTop.yCent);
            }
            myTop.ContoursInput();
            this.kCavei = myTop.kCavei;
            this.sRel = this.myTop.hSect;
            if (kCavei == 0 && File.Exists(myTop.fileContour))
                File.Delete(myTop.fileContour);
            if (kHeight > 3)
            {
                if (File.Exists(myTop.fileZminzmax))
                    File.Delete(myTop.fileZminzmax);
                FileStream output = new FileStream(myTop.fileZminzmax, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(zmin);
                binaryWriter.Write(zmax);
                binaryWriter.Close();
                output.Close();
            }
            kInter = 0;
            myTop.PolygonLoad(ref myTop.kPolyInside);
            kPoly = myTop.kPoly;
            fileTemp = myTop.faddPoly;
            myTop.kPoly = kPoly;
            myTop.LoadKeepPoly(2, fileTemp);
            myTop.LoadKeepPoly(3, fileTemp);
            kPoly = myTop.kPoly;
            kInter = 0;
            myTop.LoadKeepInscr(1);
            myTop.KeepLoadBorder(2, fCurBorder);
            kBorder = myTop.kBorder;
            kVert = 0;
            myTop.VertexLoadKeep(1);
            kVert = myTop.kVert;
            xminCur = xmin;
            yminCur = ymin;
            xmaxCur = xmax;
            ymaxCur = ymax;
           DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond >= 0)
                return;
            iGraphic = 1;
        }

        private void SelectBox_Click(object sender, EventArgs e)
        {
            nProcess = 0;
            nControl = 10;
            kDat = 0;
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            nProcess = 0;
            nControl = 20;
            kDat = 0;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            nProcess = 0;
            nControl = 30;
            kDat = 0;
        }

        private void Move_Click(object sender, EventArgs e)
        {
            nProcess = 0;
            nControl = 40;
            kDat = 0;
        }

        public void DrawPoint(
          PaintEventArgs e,
          int kPnt,
          double[] xPnt,
          double[] yPnt,
          double scaleToWin,
          double xBegX,
          double yBegY,
          int xBegWin,
          int yBegWin)
        {
            Graphics graphics = e.Graphics;
            int xWin = 0;
            int yWin = 0;
            if (kPnt < 0)
                return;
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            for (int index = 0; index <= kPnt; ++index)
            {
               DllClass1.XYtoWIN(xPnt[index], yPnt[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                    graphics.FillRectangle((Brush)solidBrush, xWin - 2, yWin - 2, 3, 3);
            }
        }

        public void InputItemDraw(
          PaintEventArgs e,
          string fitemLine,
          int kItem,
          int[] numSign,
          int[] numItem,
          double[] xItem,
          double[] yItem,
          double[] az,
          double scaleWin,
          double xBeg,
          double yBeg,
          int xWin,
          int yWin)
        {
            double num1 = 3.1415926;
            double num2 = 0.254;
            for (int index1 = 1; index1 <= kItem; ++index1)
            {
                double num3 = az[index1];
                double num4 = num3 + 0.5 * num1;
                if (num4 > 2.0 * num1)
                    num4 -= 2.0 * num1;
                int index2 = numSign[index1];
                int nSelect = numItem[index1];
                int num5 = myTop.itemLoc[index2];
                int num6 = myTop.nBaseSymb[index2];
                int xWin1;
                int yWin1;
               DllClass1.XYtoWIN(xItem[index1], yItem[index1], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin1);
                if (nSelect > 0)
                {
                    int iWid;
                    int iHei;
                    int kPix;
                    string sTxt;
                    int mClr;
                   DllClass1.SelItemLine(fitemLine, nSelect, out iLong, out iWid, out iHei, out kPix, myTop.ixSqu, myTop.iySqu, myTop.nColorItm, out sTxt, out mClr);
                    if (iLong == 0)
                    {
                        int num7 = iWid / 2;
                        int num8 = iHei / 2;
                        int num9 = xWin1 - Convert.ToInt32((double)num8 * Math.Cos(num4));
                        int num10 = yWin1 - Convert.ToInt32((double)num8 * Math.Sin(num4));
                        xWin1 = num9 - Convert.ToInt32((double)num7 * Math.Cos(num3));
                        yWin1 = num10 - Convert.ToInt32((double)num7 * Math.Sin(num3));
                        if (num5 == 1)
                        {
                            if (num6 < 8)
                            {
                                xWin1 -= Convert.ToInt32((double)num8 * Math.Cos(num4));
                                yWin1 -= Convert.ToInt32((double)num8 * Math.Sin(num4));
                            }
                            if (num6 == 8)
                            {
                                xWin1 -= Convert.ToInt32((double)iHei * Math.Cos(num4));
                                yWin1 -= Convert.ToInt32((double)iHei * Math.Sin(num4));
                            }
                        }
                        if (num5 == 3)
                        {
                            if (num6 < 8)
                            {
                                xWin1 += Convert.ToInt32((double)num8 * Math.Cos(num4));
                                yWin1 += Convert.ToInt32((double)num8 * Math.Sin(num4));
                            }
                            if (num6 == 8)
                            {
                                xWin1 += Convert.ToInt32((double)iHei * Math.Cos(num4));
                                yWin1 += Convert.ToInt32((double)iHei * Math.Sin(num4));
                            }
                        }
                        for (int index3 = 1; index3 <= kPix; ++index3)
                        {
                            myTop.nDop1[index3] = Convert.ToInt32((double)myTop.ixSqu[index3] * Math.Cos(num3)) - Convert.ToInt32((double)myTop.iySqu[index3] * Math.Sin(num3));
                            myTop.nDop2[index3] = Convert.ToInt32((double)myTop.ixSqu[index3] * Math.Sin(num3)) + Convert.ToInt32((double)myTop.iySqu[index3] * Math.Cos(num3));
                        }
                       DllClass1.SignDraw(e, xWin1, yWin1, kPix, myTop.nDop1, myTop.nDop2, myTop.nColorItm, myTop.brColor);
                    }
                    if (iLong > 0)
                    {
                        sTxt = myTop.sInscr[index2];
                        double num11 = myTop.hInscr[index2];
                        mClr = myTop.iColInscr[index2];
                        int length = sTxt.Length;
                        SolidBrush iColor = myTop.brColor[mClr];
                        int int32 = Convert.ToInt32(num11 / num2);
                        int num12 = int32 / 2;
                        int angle =DllClass1.RadGrad(num3);
                        if (num5 == 1)
                        {
                            if (num6 < 8)
                            {
                                xWin1 -= Convert.ToInt32((double)num12 * Math.Cos(num4));
                                yWin1 -= Convert.ToInt32((double)num12 * Math.Sin(num4));
                            }
                            if (num6 == 8)
                            {
                                xWin1 -= Convert.ToInt32((double)int32 * Math.Cos(num4));
                                yWin1 -= Convert.ToInt32((double)int32 * Math.Sin(num4));
                            }
                        }
                        if (num5 == 3)
                        {
                            if (num6 < 8)
                            {
                                xWin1 += Convert.ToInt32((double)num12 * Math.Cos(num4));
                                yWin1 += Convert.ToInt32((double)num12 * Math.Sin(num4));
                            }
                            if (num6 == 8)
                            {
                                xWin1 += Convert.ToInt32((double)int32 * Math.Cos(num4));
                                yWin1 += Convert.ToInt32((double)int32 * Math.Sin(num4));
                            }
                        }
                       DllClass1.RotText(e, sTxt, xWin1, yWin1, int32, angle, iColor, 1);
                    }
                }
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (iGraphic > 0)
                return;
            if (nProcess == 410)
            {
                if (kPntSource > 0 && iPointShow > 0)
                   DllClass1.PointsDraw(e, myTop.fsymbPnt, iHeigShow, kPntPlus, myTop.namePnt, myTop.xPnt, myTop.yPnt, myTop.zPnt, myTop.xPntInscr, myTop.yPntInscr, myTop.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myTop.nCode1, myTop.nCode2, kSymbPnt, myTop.numRec, myTop.numbUser, myTop.ixSqu, myTop.iySqu, myTop.nColor, myTop.brColor, myTop.pnColor);
                int xWin;
                int yWin;
                if (kLineInput > 0 && iLineShow > 0)
                {
                    iParam = 1;
                   DllClass1.LineDraw(e, kLineInput, myTop.k1, myTop.k2, myTop.xLin, myTop.yLin, myTop.rRadLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myTop.pnColor, iParam);
                    if (kVert > 0)
                    {
                        SolidBrush solidBrush = new SolidBrush(Color.Red);
                        for (int index = 1; index <= kVert; ++index)
                        {
                           DllClass1.XYtoWIN(myTop.xVert[index], myTop.yVert[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                            graphics.FillRectangle((Brush)solidBrush, xWin - 2, yWin - 2, 4, 4);
                        }
                    }
                }
                if (kVertLine <= 0)
                    return;
                SolidBrush solidBrush1 = new SolidBrush(Color.Gray);
                for (int index = 1; index <= kVertLine; ++index)
                {
                   DllClass1.XYtoWIN(myTop.xSel[index], myTop.ySel[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                    graphics.FillRectangle((Brush)solidBrush1, xWin - 3, yWin - 3, 6, 6);
                }
            }
            else
            {
                if (kBorder > 2)
                   DllClass1.DrawSelLine(e, kBorder, ref myTop.xBorder, ref myTop.yBorder, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                if (kPntSource > 0 && iPointShow > 0)
                   DllClass1.PointsDraw(e, myTop.fsymbPnt, iHeigShow, kPntPlus, myTop.namePnt, myTop.xPnt, myTop.yPnt, myTop.zPnt, myTop.xPntInscr, myTop.yPntInscr, myTop.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myTop.nCode1, myTop.nCode2, kSymbPnt, myTop.numRec, myTop.numbUser, myTop.ixSqu, myTop.iySqu, myTop.nColor, myTop.brColor, myTop.pnColor);
                if (kTriang > 3 && iTriangShow > 0)
                {
                   DllClass1.DrawTre(e, kTriang, myTop.xTre, myTop.yTre, kCenTri, myTop.xCent, myTop.yCent, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                    SolidBrush solidBrush = new SolidBrush(Color.Blue);
                    graphics.FillRectangle((Brush)solidBrush, 228, iHeight - 14, 4, 4);
                    graphics.DrawString(" -- Centre of Triangle", new Font("Bold", 8f), (Brush)solidBrush, 222f, (float)(iHeight - 20));
                }
                if (kPntSource > 0 && iPointShow == 0)
                    DrawPoint(e, kPntSource, myTop.xSour, myTop.ySour, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                if (kCavei > 0 && iContourShow > 0)
                {
                   DllClass1.ContourDraw(e, myTop.fileContour, myTop.xDop, myTop.yDop, myTop.xOut, myTop.yOut, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                    if (nProcess == 280 || nProcess == 290)
                    {
                        if (kSelLine > 0)
                           DllClass1.DrawSelLine(e, kSelLine, ref myTop.xSel, ref myTop.ySel, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                        kSelLine = 0;
                    }
                }
                if (kPoly > 0 && iPolygonShow > 0)
                {
                    iParam = 8;
                   DllClass1.LabelDraw(e, kPoly, myTop.namePolyFin, myTop.xLabFin, myTop.yLabFin, myTop.iHorVer, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myTop.brColor, iParam);
                    SolidBrush solidBrush = new SolidBrush(Color.Brown);
                    graphics.FillRectangle((Brush)solidBrush, 108, iHeight - 14, 4, 4);
                    graphics.DrawString(" -- Label of Polygon", new Font("Bold", 8f), (Brush)solidBrush, 112f, (float)(iHeight - 20));
                }
                int xWin;
                int yWin;
                if (kLineInput > 0 && kLineTopo == 0 && iLineShow > 0)
                {
                    iParam = 1;
                   DllClass1.LineDraw(e, kLineInput, myTop.k1, myTop.k2, myTop.xLin, myTop.yLin, myTop.rRadLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myTop.pnColor, iParam);
                    if (kVert > 0)
                    {
                        SolidBrush solidBrush = new SolidBrush(Color.Black);
                        for (int index = 1; index <= kVert; ++index)
                        {
                           DllClass1.XYtoWIN(myTop.xVert[index], myTop.yVert[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                            graphics.FillRectangle((Brush)solidBrush, xWin - 2, yWin - 2, 4, 4);
                        }
                    }
                }
                if (kLineTopo > 0 && iLineShow > 0)
                {
                    iParam = 1;
                   DllClass1.LineDraw(e, kLineTopo, myTop.kl1, myTop.kl2, myTop.zLin, myTop.zPik, myTop.radLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myTop.pnColor, iParam);
                    if (kVert > 0)
                    {
                        SolidBrush solidBrush = new SolidBrush(Color.Red);
                        for (int index = 1; index <= kVert; ++index)
                        {
                           DllClass1.XYtoWIN(myTop.xVert[index], myTop.yVert[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                            graphics.FillRectangle((Brush)solidBrush, xWin - 2, yWin - 2, 4, 4);
                        }
                    }
                }
                if ((nProcess == 250 || nProcess == 260 || nProcess == 270) && myTop.kSplit > 0)
                {
                    SolidBrush solidBrush = new SolidBrush(Color.Cyan);
                    for (int index = 1; index <= myTop.kSplit; ++index)
                    {
                       DllClass1.XYtoWIN(myTop.xSpl[index], myTop.ySpl[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                        if (xWin != 0 || yWin != 0)
                        {
                            graphics.FillRectangle((Brush)solidBrush, xWin - 2, yWin - 2, 4, 4);
                            graphics.FillRectangle((Brush)solidBrush, 8, iHeight - 14, 4, 4);
                            graphics.DrawString(" -- Split points", new Font("Bold", 8f), (Brush)solidBrush, 12f, (float)(iHeight - 20));
                        }
                    }
                }
                label1.Text = "";
                Cursor.Current = Cursors.Default;
            }
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            x1Box = e.X;
            y1Box = e.Y;
            RcDraw.X = e.X;
            RcDraw.Y = e.Y;
            RcBox.X = e.X;
            RcBox.Y = e.Y;
           DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
            if (nProcess == 220 || nProcess == 230 || nProcess == 250 || nProcess == 260 || nProcess == 280 || nProcess == 290)
            {
                xSelect = xCur;
                ySelect = yCur;
            }
            if (nProcess == 310)
            {
                ++kSelPol;
                myTop.xSel[kSelPol] = xCur;
                myTop.ySel[kSelPol] = yCur;
            }
            if (nProcess == 320)
            {
                ++newTriangle;
                xSelPnt[newTriangle] = xCur;
                ySelPnt[newTriangle] = yCur;
            }
            if (nProcess == 410 && e.Button == MouseButtons.Left)
            {
                ++kVertLine;
                myTop.xSel[kVertLine] = xCur;
                myTop.ySel[kVertLine] = yCur;
                panel7.Invalidate();
            }
            if (nControl == 10)
            {
               DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCurMin, out yCurMin);
                ++kDat;
                xDat[kDat] = e.X;
                yDat[kDat] = e.Y;
                if (e.Button == MouseButtons.Left)
                {
                    this.isDrag = true;
                    startPoint = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                }
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
                panel7.Invalidate();
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
                panel7.Invalidate();
            }
            if (e.Button != MouseButtons.Right)
                return;
            Cursor.Current = Cursors.WaitCursor;
            if (nProcess == 410)
            {
                int index1 = 0;
                int kVertLine = 0;
                if (File.Exists(myTop.fVertLine))
                {
                    myTop.VertexLine(1, myTop.fVertLine, ref kVertLine, myTop.nWork1, myTop.nWork2, myTop.rWork, myTop.xWork, myTop.yWork);
                    index1 = myTop.nWork2[kVertLine];
                    for (int index2 = 1; index2 <= kVertLine; ++index2)
                        myTop.nWork[index2] = myTop.nWork2[index2] - myTop.nWork1[index2] + 1;
                }
                if (kVertLine > 0)
                {
                    for (int index3 = 1; index3 <= kVertLine; ++index3)
                    {
                        double num5 = 9999999.9;
                        int index4 = 0;
                        int ip;
                        for (int index5 = 1; index5 <= kLineInput; ++index5)
                        {
                            int num6 = myTop.k1[index5];
                            int num7 = myTop.k2[index5];
                            for (int index6 = num6 + 1; index6 <= num7; ++index6)
                            {
                                double dist;
                               DllClass1.DistPnt(myTop.xSel[index3], myTop.ySel[index3], myTop.xLin[index6 - 1], myTop.yLin[index6 - 1], myTop.xLin[index6], myTop.yLin[index6], out dist, out ip, out double _, out double _);
                                if (ip > 0 && num5 > dist)
                                {
                                    num5 = dist;
                                    index4 = index5;
                                }
                            }
                        }
                        if (index4 > 0)
                        {
                            int num8 = myTop.k1[index4];
                            int num9 = myTop.k2[index4];
                            ip = 0;
                            for (int index7 = num8; index7 <= num9; ++index7)
                            {
                                ++ip;
                                ++index1;
                                myTop.xWork[index1] = myTop.xLin[index7];
                                myTop.yWork[index1] = myTop.yLin[index7];
                            }
                            if (ip > 1)
                            {
                                ++kVertLine;
                                myTop.rWork[kVertLine] = myTop.rRadLine[index4];
                                myTop.nWork[kVertLine] = ip;
                            }
                        }
                    }
                    myTop.nWork1[1] = 1;
                    myTop.nWork2[1] = myTop.nWork[1];
                    if (kVertLine > 1)
                    {
                        for (int index8 = 2; index8 <= kVertLine; ++index8)
                        {
                            myTop.nWork1[index8] = myTop.nWork2[index8 - 1] + 1;
                            myTop.nWork2[index8] = myTop.nWork2[index8 - 1] + myTop.nWork[index8];
                        }
                    }
                    myTop.VertexLine(2, myTop.fVertLine, ref kVertLine, myTop.nWork1, myTop.nWork2, myTop.rWork, myTop.xWork, myTop.yWork);
                }
                if (kVertLine > 0)
                {
                   DllClass1.VertexAddition(kVertLine, myTop.nWork1, myTop.nWork2, myTop.rWork, myTop.xWork, myTop.yWork, kPntPlus, myTop.xPnt, myTop.yPnt, myTop.zPnt, out kVert, myTop.xVert, myTop.yVert, myTop.zVert, myTop.xAdd, myTop.yAdd, myTop.zAdd, myTop.nDop3, myTop.pWork, myTop.xDop, myTop.yDop, myTop.zDop, myTop.zCent, myTop.nWork, myTop.nDop1, myTop.nDop2);
                    if (kVert > 0)
                    {
                        int nName = 0;
                        string sName = "";
                       DllClass1.NewPointName(kPntPlus, myTop.namePnt, out nName, out sName);
                        for (int index9 = 1; index9 <= kVert; ++index9)
                        {
                            ++nName;
                            string str = string.Format("{0}", (object)nName);
                            myTop.nVert[index9] = nName;
                            myTop.nameVert[index9] = str;
                        }
                        myTop.kVert = kVert;
                        myTop.VertexLoadKeep(2);
                        if (File.Exists(myTop.fileTrian))
                            File.Delete(myTop.fileTrian);
                        if (File.Exists(myTop.fileContour))
                            File.Delete(myTop.fileContour);
                    }
                    kCycle = 0;
                }
                panel7.Invalidate();
            }
            else
            {
                if (nProcess != 310 && nProcess != 410)
                {
                    xminCur = xmin;
                    yminCur = ymin;
                    xmaxCur = xmax;
                    ymaxCur = ymax;
                    dx = xmax - xmin;
                    dy = ymax - ymin;
                    if (dx < 0.05 || dy < 0.05)
                        return;
                   DllClass1.CoorWin(xminCur, yminCur, xmaxCur, ymaxCur, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                    if (iCond < 0)
                        iGraphic = 1;
                    kDat = 0;
                    panel7.Invalidate();
                }
                if (nProcess == 310 && kSelPol > 0)
                {
                    fileTemp = myTop.faddPoly;
                    fileTmps = myTop.fblockPoly;
                    myTop.BlockSelect(kSelPol, myTop.xSel, myTop.ySel, fileTemp, fileTmps, myTop.xWork2, myTop.yWork2);
                    kInter = myTop.kInter;
                    if (kInter > 0)
                    {
                        fileTemp = myTop.fpolyInter;
                        myTop.LoadKeepPoly(3, fileTemp);
                        kPoly = myTop.kPoly;
                        fileTemp = myTop.fileSplit;
                        myTop.kPoly = kPoly;
                        myTop.LoadKeepPoly(1, fileTemp);
                        fileTemp = myTop.fileSplit;
                        fileTmps = myTop.ftmpPoly;
                        myTop.ClipContour(2, fileTemp, fileTmps, myTop.xDop, myTop.yDop, myTop.xPik, myTop.yPik, panel1);
                        if (File.Exists(myTop.fileSplit))
                            File.Delete(myTop.fileSplit);
                    }
                    fileTemp = myTop.fblockPoly;
                    fileTmps = myTop.fileContour;
                    myTop.ClipContour(1, fileTemp, fileTmps, myTop.xDop, myTop.yDop, myTop.xPik, myTop.yPik, panel1);
                    if (kInter > 0)
                    {
                        fileTemp = myTop.fileContour;
                        fileTmps = myTop.ftmpPoly;
                        myTop.ClipContour(3, fileTemp, fileTmps, myTop.xDop, myTop.yDop, myTop.xPik, myTop.yPik, panel1);
                    }
                    kCavei = myTop.kCavei;
                    iContourShow = 1;
                    fileTemp = myTop.faddPoly;
                    myTop.LoadKeepPoly(3, fileTemp);
                    kPoly = myTop.kPoly;
                }
                myTop.NewInscript(myTop.fileContour, myTop.xWork1, myTop.yWork1, myTop.xWork2, myTop.yWork2);
                label1.Text = "";
                panel1.Text = "Готов...";
                Cursor.Current = Cursors.Default;
                kDat = 0;
                panel7.Invalidate();
            }
        }

        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
            if (nControl == 10 && kDat > 0)
            {
                ControlPaint.DrawReversibleFrame(theRectangle, BackColor, FrameStyle.Dashed);
                if (xCurMin > xCur)
                {
                    xCurMax = xCurMin;
                    xCurMin = xCur;
                }
                else
                    xCurMax = xCur;
                if (yCurMin > yCur)
                {
                    yCurMax = yCurMin;
                    yCurMin = yCur;
                }
                else
                    yCurMax = yCur;
                if (this.isDrag)
                {
                    dx = xCurMax - xCurMin;
                    dy = yCurMax - yCurMin;
                    if (dx < 0.05 || dy < 0.05)
                        return;
                    xminCur = xCurMin;
                    yminCur = yCurMin;
                    xmaxCur = xCurMax;
                    ymaxCur = yCurMax;
                   DllClass1.CoorWin(xCurMin, yCurMin, xCurMax, yCurMax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                    if (iCond < 0)
                    {
                        iGraphic = 1;
                        return;
                    }
                }
                theRectangle = new Rectangle(0, 0, 0, 0);
                this.isDrag = false;
                panel7.Invalidate();
                kDat = 0;
            }
            if (nControl == 40)
            {
                kDat = 0;
                xminCur = xaCur;
                yminCur = yaCur;
                xmaxCur = xbCur;
                ymaxCur = ybCur;
            }
            if (nProcess == 220)
            {
                myTop.TriangInput(myTop.fileTrian);
                kTriang = myTop.kTriang;
                if (kTriang > 3)
                {
                    kCenTri = 0;
                   DllClass1.CenterTre(kTriang, myTop.xTre, myTop.yTre, out kCenTri, myTop.xCent, myTop.yCent);
                }
                label1.Text = "************Пожалуйста......Подождите****************";
               DllClass1.NewDiagonal(xSelect, ySelect, ref kTriang, myTop.nTre, myTop.xTre, myTop.yTre, myTop.zTre);
                label1.Text = "";
                kCavei = 0;
                label1.Text = "*****Пожалуйста......Подождите*****ФОРМИРОВАНИЕ ГОРИЗОНТАЛЕЙ";
               DllClass1.ContSquare(sRel, kTriang, myTop.xTre, myTop.yTre, myTop.zTre, myTop.nSpot, myTop.xOut, myTop.yOut, myTop.xSel, myTop.ySel, myTop.xSpot, myTop.ySpot, myTop.zAdd, myTop.xAdd, myTop.yAdd, myTop.zDop, out kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.nDop3, myTop.xCont, myTop.yCont, panel1);
                label1.Text = "";
                if (kCavei > 0)
                {
                    label1.Text = "*****Пожалуйста......Подождите*****СГЛАЖИВАНИЕ ГОРИЗОНТАЛЕЙ";
                   DllClass1.ContToDraw(myTop.fileAdd, myTop.fileContour, sRel, kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.xCont, myTop.yCont, myTop.nDop3, myTop.xDop, myTop.yDop, myTop.xWork1, myTop.yWork1, myTop.xAdd, myTop.yAdd, myTop.xSel, myTop.ySel, panel1, nVertex);
                    label1.Text = "";
                }
                kCenTri = 0;
               DllClass1.CenterTre(kTriang, myTop.xTre, myTop.yTre, out kCenTri, myTop.xCent, myTop.yCent);
               DllClass1.KeepTriang(myTop.fileTrian, xmin, ymin, xmax, ymax, kTriang, myTop.nTre, myTop.xTre, myTop.yTre, myTop.zTre);
                myTop.kSplit = 0;
                if (File.Exists(myTop.fileSplit))
                    File.Delete(myTop.fileSplit);
                if (File.Exists(myTop.ftmpPoly))
                    File.Delete(myTop.ftmpPoly);
                nProcess = 0;
                panel7.Invalidate();
            }
            if (nProcess == 230)
            {
                myTop.TriangInput(myTop.fileTrian);
                kTriang = myTop.kTriang;
                if (kTriang > 3)
                {
                    kCenTri = 0;
                   DllClass1.CenterTre(kTriang, myTop.xTre, myTop.yTre, out kCenTri, myTop.xCent, myTop.yCent);
                }
                label1.Text = "************Пожалуйста......Подождите****************";
               DllClass1.TreDelete(xSelect, ySelect, ref kTriang, ref myTop.nTre, ref myTop.xTre, ref myTop.yTre, ref myTop.zTre);
                label1.Text = "";
                kCavei = 0;
                label1.Text = "*****Пожалуйста......Подождите*****ФОРМИРОВАНИЕ ГОРИЗОНТАЛЕЙ";
               DllClass1.ContSquare(sRel, kTriang, myTop.xTre, myTop.yTre, myTop.zTre, myTop.nSpot, myTop.xOut, myTop.yOut, myTop.xSel, myTop.ySel, myTop.xSpot, myTop.ySpot, myTop.zSpot, myTop.xAdd, myTop.yAdd, myTop.zDop, out kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.nDop3, myTop.xCont, myTop.yCont, panel1);
                label1.Text = "";
                if (kCavei == 0)
                    return;
                if (kCavei > 0)
                {
                    label1.Text = "*****Пожалуйста......Подождите*****СГЛАЖИВАНИЕ ГОРИЗОНТАЛЕЙ";
                   DllClass1.ContToDraw(myTop.fileAdd, myTop.fileContour, sRel, kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.xCont, myTop.yCont, myTop.nDop3, myTop.xDop, myTop.yDop, myTop.xWork1, myTop.yWork1, myTop.xAdd, myTop.yAdd, myTop.xSel, myTop.ySel, panel1, nVertex);
                    label1.Text = "";
                }
                kCenTri = 0;
               DllClass1.CenterTre(kTriang, myTop.xTre, myTop.yTre, out kCenTri, myTop.xCent, myTop.yCent);
               DllClass1.KeepTriang(myTop.fileTrian, xmin, ymin, xmax, ymax, kTriang, myTop.nTre, myTop.xTre, myTop.yTre, myTop.zTre);
                myTop.kSplit = 0;
                if (File.Exists(myTop.fileSplit))
                    File.Delete(myTop.fileSplit);
                if (File.Exists(myTop.ftmpPoly))
                    File.Delete(myTop.ftmpPoly);
                nProcess = 0;
                iContourShow = 1;
                panel7.Invalidate();
            }
            if (nProcess == 250)
            {
                myTop.SplitContour(1, xSelect, ySelect, out xSplit, out ySplit, xSplPnt, ySplPnt, myTop.xAdd, myTop.yAdd, myTop.xDop, myTop.yDop, myTop.xOut, myTop.yOut, ref this.myTop.kSplit, ref myTop.xSpl, ref myTop.ySpl);
                myTop.SplitFile(1, xSplit, ySplit, ref this.myTop.kSplit, ref myTop.xSpl, ref myTop.ySpl);
                myTop.SplitFile(2, xSplit, ySplit, ref this.myTop.kSplit, ref myTop.xSpl, ref myTop.ySpl);
                xSplit = 0.0;
                ySplit = 0.0;
                panel7.Invalidate();
            }
            if (nProcess == 260)
            {
                myTop.SplitContour(2, xSelect, ySelect, out xSplit, out ySplit, xSplPnt, ySplPnt, myTop.xAdd, myTop.yAdd, myTop.xDop, myTop.yDop, myTop.xOut, myTop.yOut, ref myTop.kSplit, ref myTop.xSpl, ref myTop.ySpl);
                myTop.SplitFile(3, xSplit, ySplit, ref this.myTop.kSplit, ref myTop.xSpl, ref myTop.ySpl);
                xSplit = 0.0;
                ySplit = 0.0;
                panel7.Invalidate();
            }
            if (nProcess == 280)
            {
                myTop.SmoothSelect(1, xSelect, ySelect, myTop.xAdd, myTop.yAdd, myTop.xDop, myTop.yDop, myTop.xOut, myTop.yOut, out kSelLine, myTop.xSel, myTop.ySel, nVertex);
                xSplit = 0.0;
                ySplit = 0.0;
                kSelLine = 0;
                label1.Text = "";
                panel7.Invalidate();
            }
            if (nProcess == 290)
            {
                myTop.SmoothSelect(2, xSelect, ySelect, myTop.xAdd, myTop.yAdd, myTop.xDop, myTop.yDop, myTop.xOut, myTop.yOut, out kSelLine, myTop.xSel, myTop.ySel, nVertex);
                xSplit = 0.0;
                ySplit = 0.0;
                kSelLine = 0;
                label1.Text = "";
                panel7.Invalidate();
            }
            if (nProcess != 320 || newTriangle != 3)
                return;
            myTop.TriangInput(myTop.fileTrian);
            kTriang = myTop.kTriang;
            if (kTriang > 3)
            {
                kCenTri = 0;
               DllClass1.CenterTre(kTriang, myTop.xTre, myTop.yTre, out kCenTri, myTop.xCent, myTop.yCent);
            }
            label1.Text = "************Пожалуйста......Подождите****************";
           DllClass1.AddTriangle(ref newTriangle, ref xSelPnt, ref ySelPnt, kHeight, myTop.xHeig, myTop.yHeig, myTop.zHeig, ref kTriang, ref myTop.nTre, ref myTop.xTre, ref myTop.yTre, ref myTop.zTre);
            label1.Text = "";
            kCavei = 0;
            label1.Text = "*****Пожалуйста......Подождите*****ФОРМИРОВАНИЕ ГОРИЗОНТАЛЕЙ";
           DllClass1.ContSquare(sRel, kTriang, myTop.xTre, myTop.yTre, myTop.zTre, myTop.nSpot, myTop.xOut, myTop.yOut, myTop.xSel, myTop.ySel, myTop.xSpot, myTop.ySpot, myTop.zSpot, myTop.xAdd, myTop.yAdd, myTop.zDop, out kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.nDop3, myTop.xCont, myTop.yCont, panel1);
            label1.Text = "";
            if (kCavei == 0)
                return;
            if (kCavei > 0)
            {
                label1.Text = "*****Пожалуйста......Подождите*****СГЛАЖИВАНИЕ ГОРИЗОНТАЛЕЙ";
               DllClass1.ContToDraw(myTop.fileAdd, myTop.fileContour, sRel, kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.xCont, myTop.yCont, myTop.nDop3, myTop.xDop, myTop.yDop, myTop.xWork1, myTop.yWork1, myTop.xAdd, myTop.yAdd, myTop.xSel, myTop.ySel, panel1, nVertex);
                label1.Text = "";
            }
            kCenTri = 0;
           DllClass1.CenterTre(kTriang, myTop.xTre, myTop.yTre, out kCenTri, myTop.xCent, myTop.yCent);
           DllClass1.KeepTriang(myTop.fileTrian, xmin, ymin, xmax, ymax, kTriang, myTop.nTre, myTop.xTre, myTop.yTre, myTop.zTre);
            myTop.kSplit = 0;
            if (File.Exists(myTop.fileSplit))
                File.Delete(myTop.fileSplit);
            if (File.Exists(myTop.ftmpPoly))
                File.Delete(myTop.ftmpPoly);
            nProcess = 0;
            newTriangle = 0;
            panel7.Invalidate();
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
           DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
            if (kHeight < 2)
            {
                panel2.Text = string.Format("{0}", (object)e.X);
                panel4.Text = string.Format("{0}", (object)e.Y);
            }
            if (kHeight > 1)
            {
                panel2.Text = string.Format("{0:F3}", (object)xCur);
                panel4.Text = string.Format("{0:F3}", (object)yCur);
            }
            if (nControl == 10 && e.Button == MouseButtons.Left && isDrag)
            {
                ControlPaint.DrawReversibleFrame(theRectangle, BackColor, FrameStyle.Dashed);
                endPoint = PointToScreen(new Point(e.X, e.Y));
                if (e.X > 15 && e.X < pixWid + 10 && e.Y > 15 && e.Y < pixHei + 10)
                    theRectangle = new Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
                ControlPaint.DrawReversibleFrame(theRectangle, BackColor, FrameStyle.Dashed);
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
            double num1 = xCur2 - xCur1;
            double num2 = yCur2 - yCur1;
            xaCur = xminCur - num1;
            yaCur = yminCur - num2;
            xbCur = xmaxCur - num1;
            ybCur = ymaxCur - num2;
           DllClass1.CoorWin(xaCur, yaCur, xbCur, ybCur, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond < 0)
                iGraphic = 1;
            panel7.Invalidate();
        }

        private void ModelContour_Click(object sender, EventArgs e)
        {
            nProcess = 210;
            nControl = 0;
            double num1 = 0.0;
            myTop.FilePath();
            FormLoad();
            if (kTriang > 3 && MessageBox.Show("Модель рельефа существует. Используйте кнопку 'Изменить интервал'." +
                " Вы хотите создать новую модель ?", "Действия с участком", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                panel7.Invalidate();
            }
            else
            {
                int num2 = (int)new CadInterval().ShowDialog((IWin32Window)this);
                FileStream input = new FileStream(myTop.fileInterval, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    num1 = binaryReader.ReadDouble();
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
                if (num1 == 0.0)
                {
                    panel7.Invalidate();
                }
                else
                {
                    sRel = num1;
                    myTop.kSplit = 0;
                    if (File.Exists(myTop.fileSplit))
                        File.Delete(myTop.fileSplit);
                    if (File.Exists(myTop.ftmpPoly))
                        File.Delete(myTop.ftmpPoly);
                    if (File.Exists(myTop.fileBorder))
                        File.Delete(myTop.fileBorder);
                    kBorder = -1;
                   DllClass1.BorderBuilding(ref this.kHeight, ref myTop.xHeig, ref myTop.yHeig, out kBorder, myTop.xBorder, myTop.yBorder, myTop.nSpot, myTop.xSpot, myTop.ySpot, myTop.zSpot, myTop.nWork1, myTop.nWork2, panel1);
                    myTop.kBorder = kBorder;
                    myTop.KeepLoadBorder(1, fCurBorder);
                    int kHeight = this.kHeight;
                    if (kLineInput > 0 && kVert > 0)
                    {
                        for (int index1 = 1; index1 <= kVert; ++index1)
                        {
                            int num3 = 0;
                            for (int index2 = 0; index2 <= kHeight; ++index2)
                            {
                                dx = myTop.xHeig[index2] - myTop.xVert[index1];
                                dy = myTop.yHeig[index2] - myTop.yVert[index1];
                                if (Math.Sqrt(dx * dx + dy * dy) < 0.1)
                                {
                                    ++num3;
                                    break;
                                }
                            }
                            if (num3 <= 0)
                            {
                                ++kHeight;
                                myTop.nHeig[kHeight] = myTop.nVert[index1];
                                myTop.xHeig[kHeight] = myTop.xVert[index1];
                                myTop.yHeig[kHeight] = myTop.yVert[index1];
                                myTop.zHeig[kHeight] = myTop.zVert[index1];
                            }
                        }
                    }
                    kTriang = 0;
                    kCavei = 0;
                    kCycle = 0;
                   DllClass1.TinCreate(myTop.fileAdd, kBorder, myTop.xBorder, myTop.yBorder, kHeight, myTop.nHeig, myTop.xHeig, myTop.yHeig, myTop.zHeig, out kSqu, myTop.xWork1, myTop.yWork1, myTop.xWork2, myTop.yWork2, myTop.nDop1, myTop.nDop2, myTop.nDop3, myTop.nPik, myTop.xPik, myTop.yPik, myTop.zSel, out kTriang, myTop.nTre, myTop.xTre, myTop.yTre, myTop.zTre, myTop.nWork1, myTop.xAdd, myTop.yAdd, myTop.zAdd, myTop.nSour1, myTop.nSour2, myTop.nSpot, myTop.xSpot, myTop.ySpot, myTop.zSpot, myTop.xOut, myTop.yOut, myTop.nWork, myTop.nCode1Fin, myTop.nCode2Fin, myTop.xDop, myTop.yDop, myTop.zDop, myTop.nCent, myTop.xCent, myTop.yCent, myTop.zCent, myTop.xPol, myTop.yPol, myTop.nWork, myTop.xWork, myTop.yWork, myTop.zWork, myTop.nParc, myTop.xParc, myTop.yParc, myTop.zParc, myTop.pWork, myTop.rWork, myTop.xSel, myTop.ySel, myTop.kMaxTre, panel1);
                    label1.Text = "Подожди.....Архив треугольников";
                   DllClass1.KeepTriang(myTop.fileTrian, xmin, ymin, xmax, ymax, kTriang, myTop.nTre, myTop.xTre, myTop.yTre, myTop.zTre);
                    label1.Text = "*****Пожалуйста......Подождите*****ФОРМИРОВАНИЕ ГОРИЗОНТАЛЕЙ";
                   DllClass1.ContSquare(sRel, kTriang, myTop.xTre, myTop.yTre, myTop.zTre, myTop.nTre, myTop.xOut, myTop.yOut, myTop.xSel, myTop.ySel, myTop.xSpot, myTop.ySpot, myTop.zAdd, myTop.xAdd, myTop.yAdd, myTop.zDop, out kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.nDop3, myTop.xCont, myTop.yCont, panel1);
                    label1.Text = "";
                    panel1.Text = "Готов....";
                    if (kCavei == 0)
                        return;
                    if (kCavei > 0)
                    {
                        label1.Text = "*****Пожалуйста......Подождите*****СГЛАЖИВАНИЕ ГОРИЗОНТАЛЕЙ";
                       DllClass1.ContToDraw(myTop.fileAdd, myTop.fileContour, sRel, kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.xCont, myTop.yCont, myTop.nDop3, myTop.xDop, myTop.yDop, myTop.xWork1, myTop.yWork1, myTop.xAdd, myTop.yAdd, myTop.xSel, myTop.ySel, panel1, nVertex);
                        label1.Text = "";
                        panel1.Text = "Готов..";
                    }
                    kCenTri = 0;
                   DllClass1.CenterTre(kTriang, myTop.xTre, myTop.yTre, out kCenTri, myTop.xCent, myTop.yCent);
                    if (File.Exists(myTop.ftrianTemp))
                        File.Delete(myTop.ftrianTemp);
                    panel7.Invalidate();
                }
            }
        }

        private void Diagonal_Click(object sender, EventArgs e)
        {
            nProcess = 220;
            nControl = 0;
            iTriangShow = 1;
            iContourShow = 1;
            xSelect = 0.0;
            ySelect = 0.0;
            panel7.Invalidate();
        }

        private void TreRemove_Click(object sender, EventArgs e)
        {
            nProcess = 230;
            nControl = 0;
            iTriangShow = 1;
            iContourShow = 0;
            xSelect = 0.0;
            ySelect = 0.0;
            panel7.Invalidate();
        }

        private void NewTriangle_Click(object sender, EventArgs e)
        {
            nProcess = 320;
            nControl = 0;
            iTriangShow = 1;
            iContourShow = 0;
            iPointShow = 0;
            newTriangle = 0;
            panel7.Invalidate();
        }

        private void ChangeInterval_Click(object sender, EventArgs e)
        {
            nProcess = 240;
            nControl = 0;
            sRel = 0.0;
            if (kTriang < 4)
            {
                int num1 = (int)MessageBox.Show("Модель рельефа не создана", "Просмотр(показать)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new CadInterval().ShowDialog((IWin32Window)this);
                FileStream input = new FileStream(myTop.fileInterval, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    sRel = binaryReader.ReadDouble();
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
                if (sRel == 0.0)
                    return;
                myTop.kSplit = 0;
                if (File.Exists(myTop.fileSplit))
                    File.Delete(myTop.fileSplit);
                if (File.Exists(myTop.ftmpPoly))
                    File.Delete(myTop.ftmpPoly);
                kCavei = 0;
                label1.Text = "*****Пожалуйста......Подождите*****ФОРМИРОВАНИЕ ГОРИЗОНТАЛЕЙ";
               DllClass1.ContSquare(sRel, kTriang, myTop.xTre, myTop.yTre, myTop.zTre, myTop.nTre, myTop.xOut, myTop.yOut, myTop.xSel, myTop.ySel, myTop.xSpot, myTop.ySpot, myTop.zAdd, myTop.xAdd, myTop.yAdd, myTop.zDop, out kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.nDop3, myTop.xCont, myTop.yCont, panel1);
                label1.Text = "";
                if (kCavei == 0)
                    return;
                if (kCavei > 0)
                {
                    label1.Text = "*****Пожалуйста......Подождите*****СГЛАЖИВАНИЕ ГОРИЗОНТАЛЕЙ";
                   DllClass1.ContToDraw(myTop.fileAdd, myTop.fileContour, sRel, kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.xCont, myTop.yCont, myTop.nDop3, myTop.xDop, myTop.yDop, myTop.xWork1, myTop.yWork1, myTop.xAdd, myTop.yAdd, myTop.xSel, myTop.ySel, panel1, nVertex);
                    label1.Text = "";
                    panel1.Text = "Готов..";
                }
                iContourShow = 1;
                panel7.Invalidate();
            }
        }

        private void PointsOnOff_Click(object sender, EventArgs e)
        {
            if (iPointShow > 0)
            {
                iPointShow = 0;
                iHeigShow = 0;
            }
            else
            {
                iPointShow = 1;
                iHeigShow = 1;
            }
            panel7.Invalidate();
        }

        private void TrianglesOnOff_Click(object sender, EventArgs e)
        {
            if (kTriang < 5)
            {
                int num = (int)MessageBox.Show("Модель рельефа не создана", "Просмотр(показать)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                iTriangShow = iTriangShow <= 0 ? 1 : 0;
                panel7.Invalidate();
            }
        }

        private void ContoursOnOff_Click(object sender, EventArgs e)
        {
            if (kCavei == 0)
            {
                int num = (int)MessageBox.Show("Горизонтали не построены", "Просмотр(показать)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                iContourShow = iContourShow <= 0 ? 1 : 0;
                panel7.Invalidate();
            }
        }

        private void PolygonOnOff_Click(object sender, EventArgs e)
        {
            if (kPoly == 0)
            {
                int num = (int)MessageBox.Show("Полигональная топология не была создана", "Просмотр(показать)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                iPolygonShow = iPolygonShow <= 0 ? 1 : 0;
                panel7.Invalidate();
            }
        }

        private void BlockAll_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myTop.fileContour))
            {
                int num1 = (int)MessageBox.Show("Горизонтали не построены", "Блокировка полигонов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(myTop.filePoly))
            {
                int num2 = (int)MessageBox.Show("Топология полигонов не была создана", "Блокировка полигонов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                fileTemp = myTop.faddPoly;
                myTop.LoadKeepPoly(3, fileTemp);
                kPoly = myTop.kPoly;
                fileTemp = myTop.fblockPoly;
                myTop.kPoly = kPoly;
                myTop.LoadKeepPoly(1, fileTemp);
                myTop.PolyInter();
                kInter = myTop.kInter;
                fileTemp = myTop.fblockPoly;
                fileTmps = myTop.fileContour;
                myTop.ClipContour(1, fileTemp, fileTmps, myTop.xDop, myTop.yDop, myTop.xPik, myTop.yPik, panel1);
                fileTmps = myTop.fileContour;
                myTop.NewInscript(fileTmps, myTop.xWork1, myTop.yWork1, myTop.xWork2, myTop.yWork2);
                kCavei = myTop.kCavei;
                iContourShow = 1;
                panel1.Text = "Готов...";
                panel7.Invalidate();
            }
        }

        private void BlockInrinsic_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myTop.fileContour))
            {
                int num1 = (int)MessageBox.Show("Горизонтали не построены", "Блокировка полигонов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(myTop.filePoly))
            {
                int num2 = (int)MessageBox.Show("Топология полигонов не была создана", "Блокировка полигонов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                fileTemp = myTop.faddPoly;
                myTop.LoadKeepPoly(3, fileTemp);
                kPoly = myTop.kPoly;
                myTop.PolyInter();
                kInter = myTop.kInter;
                if (kInter > 0)
                {
                    fileTemp = myTop.fpolyInter;
                    myTop.LoadKeepPoly(3, fileTemp);
                    kPoly = myTop.kPoly;
                    fileTemp = myTop.fblockPoly;
                    myTop.kPoly = kPoly;
                    myTop.LoadKeepPoly(1, fileTemp);
                    fileTemp = myTop.fblockPoly;
                    fileTmps = myTop.fileContour;
                    myTop.ClipContour(1, fileTemp, fileTmps, myTop.xDop, myTop.yDop, myTop.xPik, myTop.yPik, panel1);
                    kCavei = myTop.kCavei;
                    iContourShow = 1;
                    fileTemp = myTop.faddPoly;
                    myTop.LoadKeepPoly(3, fileTemp);
                    kPoly = myTop.kPoly;
                }
                fileTmps = myTop.fileContour;
                myTop.NewInscript(fileTmps, myTop.xWork1, myTop.yWork1, myTop.xWork2, myTop.yWork2);
                panel1.Text = "Готов...";
                panel7.Invalidate();
            }
        }

        private void ExeptIntrinsic_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myTop.fileContour))
            {
                int num1 = (int)MessageBox.Show("Горизонтали не построены", "Блокировка полигонов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(myTop.filePoly))
            {
                int num2 = (int)MessageBox.Show("Топология полигонов не была создана", "Блокировка полигонов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                fileTemp = myTop.faddPoly;
                myTop.LoadKeepPoly(3, fileTemp);
                kPoly = myTop.kPoly;
                myTop.PolyInter();
                kInter = myTop.kInter;
                if (kInter == 0)
                    return;
                fileTemp = myTop.fpolyInter;
                myTop.LoadKeepPoly(3, fileTemp);
                kPoly = myTop.kPoly;
                fileTemp = myTop.fblockPoly;
                myTop.kPoly = kPoly;
                myTop.LoadKeepPoly(1, fileTemp);
                fileTemp = myTop.fblockPoly;
                fileTmps = myTop.ftmpPoly;
                myTop.ClipContour(2, fileTemp, fileTmps, myTop.xDop, myTop.yDop, myTop.xPik, myTop.yPik, panel1);
                fileTemp = myTop.faddPoly;
                myTop.LoadKeepPoly(3, fileTemp);
                kPoly = myTop.kPoly;
                fileTemp = myTop.fblockPoly;
                myTop.kPoly = kPoly;
                myTop.LoadKeepPoly(1, fileTemp);
                myTop.PolyInter();
                kInter = myTop.kInter;
                fileTemp = myTop.fblockPoly;
                fileTmps = myTop.fileContour;
                myTop.ClipContour(1, fileTemp, fileTmps, myTop.xDop, myTop.yDop, myTop.xPik, myTop.yPik, panel1);
                fileTemp = myTop.fileContour;
                fileTmps = myTop.ftmpPoly;
                myTop.ClipContour(3, fileTemp, fileTmps, myTop.xDop, myTop.yDop, myTop.xPik, myTop.yPik, panel1);
                fileTemp = myTop.fileContour;
                myTop.NewInscript(fileTemp, myTop.xWork1, myTop.yWork1, myTop.xWork2, myTop.yWork2);
                kCavei = myTop.kCavei;
                iContourShow = 1;
                panel1.Text = "Готов...";
                panel7.Invalidate();
            }
        }

        private void BlockSelect_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myTop.fileContour))
            {
                int num1 = (int)MessageBox.Show("Горизонтали не построены", "Блокировка полигонов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(myTop.filePoly))
            {
                int num2 = (int)MessageBox.Show("Топология полигонов не была создана", "Блокировка полигонов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 310;
                nControl = 0;
                kSelPol = 0;
            }
        }

        private void Abolish_Click(object sender, EventArgs e)
        {
            label1.Text = "*****Пожалуйста......Подождите*****ФОРМИРОВАНИЕ ГОРИЗОНТАЛЕЙ";
           DllClass1.ContSquare(sRel, kTriang, myTop.xTre, myTop.yTre, myTop.zTre, myTop.nTre, myTop.xOut, myTop.yOut, myTop.xSel, myTop.ySel, myTop.xSpot, myTop.ySpot, myTop.zAdd, myTop.xAdd, myTop.yAdd, myTop.zDop, out kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.nDop3, myTop.xCont, myTop.yCont, panel1);
            label1.Text = "";
            panel1.Text = "Готов.......";
            if (kCavei == 0)
                return;
            if (kCavei > 0)
            {
                label1.Text = "*****Пожалуйста......Подождите*****СГЛАЖИВАНИЕ ГОРИЗОНТАЛЕЙ";
               DllClass1.ContToDraw(myTop.fileAdd, myTop.fileContour, sRel, kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.xCont, myTop.yCont, myTop.nDop3, myTop.xDop, myTop.yDop, myTop.xWork1, myTop.yWork1, myTop.xAdd, myTop.yAdd, myTop.xSel, myTop.ySel, panel1, nVertex);
                panel1.Text = "Готов.......";
            }
            label1.Text = "";
            kCenTri = 0;
           DllClass1.CenterTre(kTriang, myTop.xTre, myTop.yTre, out kCenTri, myTop.xCent, myTop.yCent);
            if (File.Exists(myTop.fblockPoly))
                File.Delete(myTop.fblockPoly);
            if (File.Exists(myTop.fpolyInter))
                File.Delete(myTop.fpolyInter);
            panel7.Invalidate();
        }

        private void SmoothDown_Click(object sender, EventArgs e)
        {
            label1.Text = "************Пожалуйста......Подождите****************";
           DllClass1.SmoothChange(myTop.fileAdd, myTop.fileContour, 1, myTop.xAdd, myTop.yAdd, myTop.xDop, myTop.yDop, myTop.xWork, myTop.yWork, panel1, nVertex);
            label1.Text = "";
            panel1.Text = "Готов..";
            panel7.Invalidate();
        }

        private void SmoothUp_Click(object sender, EventArgs e)
        {
            label1.Text = "************Пожалуйста......Подождите****************";
           DllClass1.SmoothChange(myTop.fileAdd, myTop.fileContour, 2, myTop.xAdd, myTop.yAdd, myTop.xDop, myTop.yDop, myTop.xWork, myTop.yWork, panel1, nVertex);
            label1.Text = "";
            panel1.Text = "Готов..";
            panel7.Invalidate();
        }

        private void LessenOne_Click(object sender, EventArgs e)
        {
            nProcess = 280;
            nControl = 0;
            kSelLine = 0;
            panel7.Invalidate();
        }

        private void RaiseOne_Click(object sender, EventArgs e)
        {
            nProcess = 290;
            nControl = 0;
            kSelLine = 0;
            panel7.Invalidate();
        }

        private void ContSplit_Click(object sender, EventArgs e)
        {
            nProcess = 250;
            nControl = 0;
            if (File.Exists(myTop.ftmpPoly))
                File.Delete(myTop.ftmpPoly);
            myTop.kSplit = 0;
            if (File.Exists(myTop.fileSplit))
                File.Delete(myTop.fileSplit);
            panel7.Invalidate();
        }

        private void ContRemove_Click(object sender, EventArgs e)
        {
            nProcess = 260;
            nControl = 0;
            panel7.Invalidate();
        }

        private void ContRestore_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myTop.ftmpPoly))
                return;
            label1.Text = "************Пожалуйста......Подождите****************";
            nProcess = 270;
            nControl = 0;
            myTop.SplitContour(3, this.xSelect, this.ySelect, out xSplit, out ySplit, this.xSplPnt, this.ySplPnt,
                this.myTop.xAdd, this.myTop.yAdd, this.myTop.xDop, this.myTop.yDop,
                 this.myTop.xOut, this.myTop.yOut, ref myTop.kSplit, ref myTop.xSpl, ref myTop.ySpl);
            label1.Text = "";
            panel1.Text = "Готов........";
            panel7.Invalidate();
        }

        private void AutomatCorrect_Click(object sender, EventArgs e)
        {
            if (kTriang < 5)
            {
                int num = (int)MessageBox.Show("Модель рельефа не создана", "Исправление модели", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(myTop.ftrianTemp))
                    File.Delete(myTop.ftrianTemp);
               DllClass1.KeepTriang(myTop.ftrianTemp, xmin, ymin, xmax, ymax, kTriang, myTop.nTre, myTop.xTre, myTop.yTre, myTop.zTre);
                int iParam = 1;
                label1.Text = "Wait.....Исправление модели";
               DllClass1.TinCorrect(iParam, sRel, ref kTriang, myTop.nTre, myTop.xTre, myTop.yTre, myTop.zTre, myTop.xWork, myTop.yWork, myTop.zWork, myTop.pWork, out kChange);
                label1.Text = "Подожди.....Архив треугольников";
               DllClass1.KeepTriang(myTop.fileTrian, xmin, ymin, xmax, ymax, kTriang, myTop.nTre, myTop.xTre, myTop.yTre, myTop.zTre);
                label1.Text = "*****Пожалуйста......Подождите*****ФОРМИРОВАНИЕ ГОРИЗОНТАЛЕЙ";
               DllClass1.ContSquare(sRel, kTriang, myTop.xTre, myTop.yTre, myTop.zTre, myTop.nTre, myTop.xOut, myTop.yOut, myTop.xSel, myTop.ySel, myTop.xSpot, myTop.ySpot, myTop.zAdd, myTop.xAdd, myTop.yAdd, myTop.zDop, out kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.nDop3, myTop.xCont, myTop.yCont, panel1);
                label1.Text = "";
                panel1.Text = "Готов..";
                if (kCavei == 0)
                    return;
                if (kCavei > 0)
                {
                    label1.Text = "*****Пожалуйста......Подождите*****СГЛАЖИВАНИЕ ГОРИЗОНТАЛЕЙ";
                   DllClass1.ContToDraw(myTop.fileAdd, myTop.fileContour, sRel, kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.xCont, myTop.yCont, myTop.nDop3, myTop.xDop, myTop.yDop, myTop.xWork1, myTop.yWork1, myTop.xAdd, myTop.yAdd, myTop.xSel, myTop.ySel, panel1, nVertex);
                    label1.Text = "";
                    panel1.Text = "Готов..";
                }
                kCenTri = 0;
               DllClass1.CenterTre(kTriang, myTop.xTre, myTop.yTre, out kCenTri, myTop.xCent, myTop.yCent);
                panel7.Invalidate();
            }
        }

        private void LineOnOff_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myTop.fileLine))
            {
                int num = (int)MessageBox.Show("Нет линий", "Просмотр(показать)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                iLineShow = iLineShow <= 0 ? 1 : 0;
                panel7.Invalidate();
            }
        }

        private void VertexAdd_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myTop.fileLine))
            {
                int num1 = (int)MessageBox.Show("Нет линий", "Добавление вершин", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int kLineInput = this.kLineInput;
                int index1 = 0;
                for (int index2 = 1; index2 <= kLineInput; ++index2)
                {
                    myTop.nWork1[index2] = myTop.k1[index2];
                    myTop.nWork2[index2] = myTop.k2[index2];
                    myTop.rWork[index2] = myTop.rRadLine[index2];
                    int num2 = myTop.k1[index2];
                    int num3 = myTop.k2[index2];
                    for (int index3 = num2; index3 <= num3; ++index3)
                    {
                        ++index1;
                        myTop.xWork[index1] = myTop.xLin[index3];
                        myTop.yWork[index1] = myTop.yLin[index3];
                    }
                }
                ++kCycle;
                if (kCycle <= 0)
                    return;
               DllClass1.VertexAdd(kCycle, kLineInput, myTop.nWork1, myTop.nWork2, myTop.rWork, myTop.xWork, myTop.yWork, kPntPlus, myTop.xPnt, myTop.yPnt, myTop.zPnt, out kVert, myTop.xVert, myTop.yVert, myTop.zVert, myTop.xAdd, myTop.yAdd, myTop.zAdd, myTop.nDop3, myTop.pWork, myTop.xDop, myTop.yDop, myTop.nWork);
                if (kVert <= 0)
                    return;
                int nName = 0;
                string sName = "";
               DllClass1.NewPointName(kPntPlus, myTop.namePnt, out nName, out sName);
                for (int index4 = 1; index4 <= kVert; ++index4)
                {
                    ++nName;
                    sName = string.Format("{0}", (object)nName);
                    myTop.nVert[index4] = nName;
                    myTop.nameVert[index4] = sName;
                }
                myTop.kVert = kVert;
                myTop.VertexLoadKeep(2);
                if (File.Exists(myTop.fileTrian))
                    File.Delete(myTop.fileTrian);
                if (File.Exists(myTop.fileContour))
                    File.Delete(myTop.fileContour);
                panel7.Invalidate();
            }
        }

        private void SelectLines_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myTop.fileLine))
            {
                int num = (int)MessageBox.Show("Нет линий", "Добавление вершин", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 410;
                nControl = 0;
                kVertLine = 0;
                FormLoad();
                panel7.Invalidate();
            }
        }

        private void VertexRemove_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myTop.fVertex) && !File.Exists(myTop.fVertLine))
            {
                int num = (int)MessageBox.Show("Удаление вершин", "Добавление вершин", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(myTop.fVertex))
                    File.Delete(myTop.fVertex);
                if (File.Exists(myTop.fVertLine))
                    File.Delete(myTop.fVertLine);
                kVert = 0;
                kCycle = 0;
                kVertLine = 0;
                FormLoad();
                if (File.Exists(myTop.fileTrian))
                    File.Delete(myTop.fileTrian);
                if (File.Exists(myTop.fileContour))
                    File.Delete(myTop.fileContour);
                panel7.Invalidate();
            }
        }

        private void ModelReturn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myTop.ftrianTemp))
            {
                int num = (int)MessageBox.Show("Нет данных", "Исправление модели", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                myTop.TriangInput(myTop.ftrianTemp);
               DllClass1.KeepTriang(myTop.fileTrian, xmin, ymin, xmax, ymax, kTriang, myTop.nTre, myTop.xTre, myTop.yTre, myTop.zTre);
               DllClass1.ContSquare(sRel, kTriang, myTop.xTre, myTop.yTre, myTop.zTre, myTop.nTre, myTop.xOut, myTop.yOut, myTop.xSel, myTop.ySel, myTop.xSpot, myTop.ySpot, myTop.zAdd, myTop.xAdd, myTop.yAdd, myTop.zDop, out kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.nDop3, myTop.xCont, myTop.yCont, panel1);
                if (kCavei == 0)
                    return;
                panel1.Text = "Готов..";
                if (kCavei > 0)
                {
                    label1.Text = "*****Пожалуйста......Подождите*****СГЛАЖИВАНИЕ ГОРИЗОНТАЛЕЙ";
                   DllClass1.ContToDraw(myTop.fileAdd, myTop.fileContour, sRel, kCavei, myTop.zCont, myTop.nDop1, myTop.nDop2, myTop.xCont, myTop.yCont, myTop.nDop3, myTop.xDop, myTop.yDop, myTop.xWork1, myTop.yWork1, myTop.xAdd, myTop.yAdd, myTop.xSel, myTop.ySel, panel1, nVertex);
                    label1.Text = "";
                    panel1.Text = "Готов..";
                }
                kCenTri = 0;
               DllClass1.CenterTre(kTriang, myTop.xTre, myTop.yTre, out kCenTri, myTop.xCent, myTop.yCent);
                if (File.Exists(myTop.ftrianTemp))
                    File.Delete(myTop.ftrianTemp);
                panel7.Invalidate();
            }
        }

        private void Quit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

    }
}
