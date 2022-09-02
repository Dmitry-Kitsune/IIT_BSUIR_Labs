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
using DiplomGeoDLL;

namespace IIT_Dimlom_Geo1
{
    public partial class AddPnt : Form
    {

        private string sDialog = "";
        private int iWidth;
        private int iHeight;
        private int xBegWin;
        private int yBegWin;
        private int xEndWin;
        private int yEndWin;
        private int nProcess;
        private int nControl;
        private int nCode;
        private int kDat;
        private int[] xDat = new int[50];
        private int[] yDat = new int[50];
        private int x1Box;
        private int y1Box;
        private int x2Box;
        private int y2Box;
        private int kRcPnt;
        private int iCode1;
        private int iParam;
        private int kMess;
        private int kSymbPnt;
        private int kTaheo;
        private double xaCur;
        private double yaCur;
        private double xbCur;
        private double ybCur;
        private double xCur;
        private double yCur;
        private double xmin;
        private double ymin;
        private double xmax;
        private double ymax;
        private double xminCur;
        private double yminCur;
        private double xmaxCur;
        private double ymaxCur;
        private double scaleToWin;
        private double scaleToGeo;
        private double xBegX;
        private double yBegY;
        private double xEndX;
        private double yEndY;
        private double[] xSel = new double[10];
        private double[] ySel = new double[10];
        private double[] aDir = new double[10];
        private string sNew = "";
        private double xNew;
        private double yNew;
        private double zNew;
        private int iCond;
        private int iGraphic;
        private StatusBar statusBar1 = new StatusBar();
        private StatusBarPanel panel1 = new StatusBarPanel();
        private StatusBarPanel panel2 = new StatusBarPanel();
        private StatusBarPanel panel3 = new StatusBarPanel();
        private StatusBarPanel panel4 = new StatusBarPanel();
        private StatusBarPanel panel5 = new StatusBarPanel();
        private StatusBarPanel panel6 = new StatusBarPanel();
        private Rectangle RcDraw;
        private Rectangle RcBox;
        private Rectangle[] RcPnt = new Rectangle[100];
        private bool isDrag;
        private Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        private Point startPoint;
        private Point endPoint;
        private int pixWid;
        private int pixHei;
        private double xCurMin;
        private double yCurMin;
        private double xCurMax;
        private double yCurMax;
        private double dx;
        private double dy;


        MyGeodesy myPnt = new MyGeodesy();

        public AddPnt()
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
            panel1.Text = "Ready...";
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
            button9.MouseHover += new EventHandler(button9_MouseHover);
            button9.MouseLeave += new EventHandler(button1_MouseLeave);
            button11.MouseHover += new EventHandler(button11_MouseHover);
            button11.MouseLeave += new EventHandler(button1_MouseLeave);
            button12.MouseHover += new EventHandler(button12_MouseHover);
            button12.MouseLeave += new EventHandler(button1_MouseLeave);
            button13.MouseHover += new EventHandler(button13_MouseHover);
            button13.MouseLeave += new EventHandler(button1_MouseLeave);
            button14.MouseHover += new EventHandler(button14_MouseHover);
            button14.MouseLeave += new EventHandler(button1_MouseLeave);
            button15.MouseHover += new EventHandler(button15_MouseHover);
            button15.MouseLeave += new EventHandler(button1_MouseLeave);
            myPnt.FilePath();
            FormLoad();
            radioButton1.Checked = true;
            groupBox4.Visible = false;
            panel7.Invalidate();
        }

        private void button1_MouseHover(object sender, EventArgs e) 
            => panel1.Text = "Вернуться в главное меню";

        private void button1_MouseLeave(object sender, EventArgs e)
            => panel1.Text = "Ready..";

        private void button2_MouseHover(object sender, EventArgs e) 
            => panel1.Text = "Нажать кнопку мыши. Зажмите лекую  кнопку мыши и ведите для выбора области, затем отпустите кнопку. Нажмите правую кнопку для исходного";

        private void button3_MouseHover(object sender, EventArgs e)
            => panel1.Text = "Нажать кнопку мыши. Зажмите и отпустите левуюю кнопку мыши рядом с выделеной точкой. Нажмите правую кнопку для исходного значения";

        private void button4_MouseHover(object sender, EventArgs e)
            => panel1.Text = "Нажать кнопку мыши. Нажмите и отпустите левую кнопу мыши рядом с выбранной точкой. Щелкните правой кнопкой мыши для исходного";

        private void button5_MouseHover(object sender, EventArgs e) 
            => panel1.Text = "Нажать кнопку мыши. Зажмите левую кнопку мыши и двигайте мышью вдоль экрана. Щелкните правой кнопкой мыши для исходного";

        private void button6_MouseHover(object sender, EventArgs e)
            => panel1.Text = "Нажать кнопку мыши. Выберите 2 точки как базисные для добавления точки методом перпендикуляров";

        private void button7_MouseHover(object sender, EventArgs e) 
            => panel1.Text = "Нажать кнопку мыши. Выберите 2 точки как базисные (исходные) для добавления точки методом угловой(полярной) засечки";

        private void button8_MouseHover(object sender, EventArgs e)
            => panel1.Text = "Нажать кнопку мыши. Выберите мышью 2 точки как базисные для добавления точки с помощью обратной линейной засечки";

        private void button9_MouseHover(object sender, EventArgs e)
            => panel1.Text = "Нажать кнопку мыши. Выберите 3 точки как базовые (базис) для добавления точки с помощью метода обратной угловой засечки";

        private void button10_MouseHover(object sender, EventArgs e) 
            => panel1.Text = "Добавление точки путем ввода данных точки с помощью диалогового окна";

        private void button11_MouseHover(object sender, EventArgs e) 
            => panel1.Text = "Нажать кнопку мыши. Выберите точку мышью для проверки и исправления данных";

        private void button12_MouseHover(object sender, EventArgs e) 
            => panel1.Text = "Щелкнуть кнопкой мыши. Выберите точку мышью и нажмите кнопку 'Удалить'";

        private void button13_MouseHover(object sender, EventArgs e) 
            => panel1.Text = "Нажмите эту кнопку после выбора метода и базисных точек";

        private void button14_MouseHover(object sender, EventArgs e) 
            => panel1.Text = "Сохранить результат";

        private void button15_MouseHover(object sender, EventArgs e) 
            => panel1.Text = "Эта кнопка имеет 2 назначения в зависимости от процесса";

        private void FormLoad()
        {
            xmin = 9999999.9;
            ymin = 9999999.9;
            xmax = -9999999.9;
            ymax = -9999999.9;
            int kPart = 50;
            char[] seps = new char[1] { '\\' };
            string[] sPart = new string[50];
            int k = 0;
            DllClass1.ShareString(myPnt.comPath, kPart, seps, out k, out sPart);
            DllClass1.SetColour(myPnt.brColor, myPnt.pnColor);
            myPnt.pathSymbol = sPart[1] + "\\BrSymbol\\";
            myPnt.fsymbPnt = myPnt.pathSymbol + "brsymb.pnt";
            DllClass1.PointSymbLoad(myPnt.fsymbPnt, out kSymbPnt, 
                myPnt.numRec, myPnt.numbUser, myPnt.heiSymb);
            myPnt.kSymbPnt = kSymbPnt;
            kTaheo = 0;
            if (File.Exists(myPnt.ftahPoint))
            {
                FileStream input = new FileStream(myPnt.ftahPoint, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kTaheo = binaryReader.ReadInt32();
                    for (int index = 0; index <= kTaheo; ++index)
                    {
                        myPnt.nameTah[index] = binaryReader.ReadString();
                        myPnt.xTah[index] = binaryReader.ReadDouble();
                        myPnt.yTah[index] = binaryReader.ReadDouble();
                        myPnt.zTah[index] = binaryReader.ReadDouble();
                        myPnt.nTah1[index] = binaryReader.ReadInt32();
                        myPnt.xTahInscr[index] = binaryReader.ReadDouble();
                        myPnt.yTahInscr[index] = binaryReader.ReadDouble();
                        myPnt.iHorVerTah[index] = binaryReader.ReadInt32();
                        if (xmin > myPnt.xTah[index])
                            xmin = myPnt.xTah[index];
                        if (ymin > myPnt.yTah[index])
                            ymin = myPnt.yTah[index];
                        if (xmax < myPnt.xTah[index])
                            xmax = myPnt.xTah[index];
                        if (ymax < myPnt.yTah[index])
                            ymax = myPnt.yTah[index];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The Read operation failed as expected.");
                }
                finally
                {
                    binaryReader.Close();
                    input.Close();
                }
                if (kTaheo > 0)
                    myPnt.LoadKeepTaheo(1);
            }
            xminCur = xmin;
            yminCur = ymin;
            xmaxCur = xmax;
            ymaxCur = ymax;
            DllClass1.CoorWin(xmin, ymin, xmax, ymax, 
                iWidth, iHeight, out scaleToWin, out scaleToGeo, 
                out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, 
                out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond >= 0)
                return;
            iGraphic = 1;
        }

        private void NewPointDraw(PaintEventArgs e, string sNew, double xNew, double yNew)
        {
            Graphics graphics = e.Graphics;
            int xWin = 0;
            int yWin = 0;
            int emSize = 6;
            SolidBrush solidBrush1 = new SolidBrush(Color.Black);
            Pen pen1 = new Pen(Color.Black);
            SolidBrush solidBrush2 = new SolidBrush(Color.Black);
            Pen pen2 = new Pen(Color.Black);
            DllClass1.XYtoWIN(xNew, yNew, scaleToWin, xBegX, yBegY, 
                xBegWin, yBegWin, out xWin, out yWin);
            if (xWin == 0 && yWin == 0)
                return;
            graphics.FillRectangle((Brush)solidBrush1, xWin - 1, yWin - 1, 3, 3);
            graphics.DrawString(sNew, new Font("Bold", (float)emSize), (Brush)solidBrush1, (float)(xWin + emSize / 2), (float)(yWin - emSize + 2));
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (iGraphic > 0)
                return;
            if (nControl == 10)
                graphics.DrawRectangle(new Pen(Color.Green, 2f), RcDraw);
            if (kTaheo > 0)
                DllClass1.PointsDraw(e, myPnt.fsymbPnt, 0, kTaheo, myPnt.nameTah, myPnt.xTah, myPnt.yTah, myPnt.zTah, myPnt.xTahInscr, myPnt.yTahInscr, myPnt.iHorVerTah, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myPnt.nTah1, myPnt.nCode2, kSymbPnt, myPnt.numRec, myPnt.numbUser, myPnt.ixSqu, myPnt.iySqu, myPnt.numCol, myPnt.brColor, myPnt.pnColor);
            if (nProcess != 510 && nProcess != 520 && nProcess != 530 && nProcess != 540 && nProcess != 560 && nProcess != 570)
                return;
            if (kRcPnt > 0)
            {
                for (int index = 1; index <= kRcPnt; ++index)
                    graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), RcPnt[index]);
                if (kRcPnt == 2 && nProcess != 540 && nProcess != 560 && nProcess != 570)
                {
                    Point[] pointArray = new Point[3];
                    pointArray[0].X = RcPnt[1].X;
                    pointArray[0].Y = RcPnt[1].Y;
                    pointArray[1].X = RcPnt[2].X;
                    pointArray[1].Y = RcPnt[2].Y;
                    graphics.DrawLine(new Pen(Color.Gold), pointArray[0], pointArray[1]);
                }
            }
            if (xNew == 0.0 || yNew == 0.0)
                return;
            kMess = 0;
            sDialog = "Points' Codes Errors: ";
            NewPointDraw(e, sNew, xNew, yNew);
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
            if (!File.Exists(myPnt.fgeoGeo))
            {
                panel2.Text = string.Format("{0}", (object)e.X);
                panel4.Text = string.Format("{0}", (object)e.Y);
            }
            if (File.Exists(myPnt.fgeoGeo))
            {
                panel2.Text = string.Format("{0:F3}", (object)xCur);
                panel4.Text = string.Format("{0:F3}", (object)yCur);
            }
            if (File.Exists(myPnt.filePoints))
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

            DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, xBegX, yBegY,
                xBegWin, yBegWin, out xCur1, out yCur1);
            DllClass1.WINtoXY(x2Box, y2Box, scaleToGeo, xBegX, yBegY,
                xBegWin, yBegWin, out xCur2, out yCur2);
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

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            CreateGraphics();
            x1Box = e.X;
            y1Box = e.Y;
            RcDraw.X = e.X;
            RcDraw.Y = e.Y;
            RcBox.X = e.X;
            RcBox.Y = e.Y;
            DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, xBegX, 
                yBegY, xBegWin, yBegWin, out xCur, out yCur);
            if (nControl == 10)
            {
                DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY,
                    xBegWin, yBegWin, out xCurMin, out yCurMin);
                ++kDat;
                xDat[kDat] = e.X;
                yDat[kDat] = e.Y;
                yDat[kDat] = e.Y;
                if (e.Button == MouseButtons.Left)
                {
                    isDrag = true;
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
            if (e.Button == MouseButtons.Right)
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
            if (e.Button != MouseButtons.Left || nProcess != 510 && nProcess != 520 && nProcess != 530 && nProcess != 540 && nProcess != 560 && nProcess != 570)
                return;
            ++kDat;
            xDat[kDat] = e.X;
            yDat[kDat] = e.Y;
            ++kRcPnt;
            RcPnt[kRcPnt].X = e.X;
            RcPnt[kRcPnt].Y = e.Y;
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
                if (isDrag)
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
                isDrag = false;
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
            if (nProcess == 510 || nProcess == 520 || nProcess == 530)
            {
                RcPnt[kRcPnt].Width = 6;
                RcPnt[kRcPnt].Height = 6;
                panel7.Invalidate(RcPnt[kRcPnt]);
                panel7.Invalidate();
                if (kDat > 0)
                {
                    for (int index = 1; index <= kDat; ++index)
                    {
                        DllClass1.WINtoXY(xDat[index], yDat[index], scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                        int indx = -1;
                        DllClass1.SelPoint(kTaheo, myPnt.xTah, myPnt.yTah, xCur, yCur, out indx);
                        if (indx >= 0)
                        {
                            if (index == 1)
                            {
                                textBox1.Text = myPnt.nameTah[indx];
                                xSel[0] = myPnt.xTah[indx];
                                ySel[0] = myPnt.yTah[indx];
                            }
                            if (index == 2)
                            {
                                textBox2.Text = myPnt.nameTah[indx];
                                xSel[1] = myPnt.xTah[indx];
                                ySel[1] = myPnt.yTah[indx];
                            }
                        }
                    }
                }
            }
            if (nProcess == 540)
            {
                RcPnt[kRcPnt].Width = 6;
                RcPnt[kRcPnt].Height = 6;
                panel7.Invalidate(RcPnt[kRcPnt]);
                panel7.Invalidate();
                if (kDat > 0)
                {
                    for (int index = 1; index <= kDat; ++index)
                    {
                        DllClass1.WINtoXY(xDat[index], yDat[index], scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                        int indx = -1;
                        DllClass1.SelPoint(kTaheo, myPnt.xTah, myPnt.yTah, xCur, yCur, out indx);
                        if (indx >= 0)
                        {
                            if (index == 1)
                            {
                                textBox1.Text = myPnt.nameTah[indx];
                                xSel[0] = myPnt.xTah[indx];
                                ySel[0] = myPnt.yTah[indx];
                            }
                            if (index == 2)
                            {
                                textBox2.Text = myPnt.nameTah[indx];
                                xSel[1] = myPnt.xTah[indx];
                                ySel[1] = myPnt.yTah[indx];
                            }
                            if (index == 3)
                            {
                                textBox3.Text = myPnt.nameTah[indx];
                                xSel[2] = myPnt.xTah[indx];
                                ySel[2] = myPnt.yTah[indx];
                            }
                        }
                    }
                }
            }
            if (nProcess != 560 && nProcess != 570)
                return;
            RcPnt[kRcPnt].Width = 6;
            RcPnt[kRcPnt].Height = 6;
            panel7.Invalidate(RcPnt[kRcPnt]);
            if (kDat == 1)
            {
                for (int index = 1; index <= kDat; ++index)
                {
                    DllClass1.WINtoXY(xDat[index], yDat[index],
                        scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                    int indx = -1;
                    DllClass1.SelPoint(kTaheo, myPnt.xTah,
                        myPnt.yTah, xCur, yCur, out indx);
                    if (indx >= 0 && index == 1)
                    {
                        textBox7.Text = myPnt.nameTah[indx];
                        textBox8.Text = string.Format("{0:F3}", (object)myPnt.xTah[indx]);
                        textBox9.Text = string.Format("{0:F3}", (object)myPnt.yTah[indx]);
                        textBox10.Text = string.Format("{0:F3}", (object)myPnt.zTah[indx]);
                        textBox11.Text = string.Format("{0}", (object)myPnt.nTah1[indx]);
                    }
                }
            }
            kDat = 0;
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

        private void Perpendicular_Click(object sender, EventArgs e)
        {
            nProcess = 510;
            nControl = 0;
            kDat = 0;
            kRcPnt = 0;
            sNew = "";
            xNew = 0.0;
            yNew = 0.0;
            zNew = 0.0;
            iCode1 = 0;
            groupBox4.Visible = true;
            groupBox6.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Visible = false;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label2.Text = "Distance from 1,m";
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = true;
            button13.Visible = true;
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            panel7.Invalidate();
        }

        private void AngleResect_Click(object sender, EventArgs e)
        {
            nProcess = 520;
            nControl = 0;
            kDat = 0;
            kRcPnt = 0;
            sNew = "";
            xNew = 0.0;
            yNew = 0.0;
            zNew = 0.0;
            iCode1 = 0;
            groupBox4.Visible = true;
            groupBox6.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Visible = false;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label2.Text = "Angle from 1,dmmss";
            label3.Visible = true;
            label4.Visible = true;
            label6.Visible = true;
            label6.Text = "Angle from 2,dmmss";
            label5.Visible = false;
            button13.Visible = true;
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            panel7.Invalidate();
        }

        private void LinearResect_Click(object sender, EventArgs e)
        {
            nProcess = 530;
            nControl = 0;
            kDat = 0;
            kRcPnt = 0;
            sNew = "";
            xNew = 0.0;
            yNew = 0.0;
            zNew = 0.0;
            iCode1 = 0;
            groupBox4.Visible = true;
            groupBox6.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Visible = false;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label2.Text = "Distance from 1,m";
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = true;
            label6.Text = "Distance from 2,m";
            button13.Visible = true;
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            panel7.Invalidate();
        }

        private void InverseResection_Click(object sender, EventArgs e)
        {
            nProcess = 540;
            nControl = 0;
            kDat = 0;
            kRcPnt = 0;
            sNew = "";
            xNew = 0.0;
            yNew = 0.0;
            zNew = 0.0;
            iCode1 = 0;
            groupBox4.Visible = true;
            groupBox6.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Visible = true;
            textBox3.Text = "";
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Visible = true;
            textBox6.Text = "";
            label1.Visible = true;
            label2.Visible = true;
            label2.Text = "Directions,dmmss";
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = false;
            button13.Visible = true;
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            panel7.Invalidate();
        }

        private void PointInfo_Click(object sender, EventArgs e)
        {
            nProcess = 560;
            nControl = 0;
            kDat = 0;
            kRcPnt = 0;
            sNew = "";
            xNew = 0.0;
            yNew = 0.0;
            zNew = 0.0;
            iCode1 = 0;
            groupBox4.Visible = true;
            groupBox6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button13.Visible = false;
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            panel7.Invalidate();
        }

        private void PointDelete_Click(object sender, EventArgs e)
        {
            nProcess = 570;
            nControl = 0;
            kDat = 0;
            kRcPnt = 0;
            sNew = "";
            xNew = 0.0;
            yNew = 0.0;
            zNew = 0.0;
            iCode1 = 0;
            groupBox4.Visible = true;
            groupBox6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button13.Visible = false;
            button15.Text = "Delete";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            panel7.Invalidate();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            int nName = 0;
            DllClass1.NewPointName(kTaheo, myPnt.nameTah, out nName, out sNew);
            if (nName < 0)
                return;
            double tText1;
            double tText2;
            if (nProcess == 510)
            {
                iParam = 0;
                if (radioButton1.Checked)
                    iParam = 1;
                if (radioButton2.Checked)
                    iParam = 2;
                if (textBox4.Text == "" || textBox5.Text == "")
                {
                    int num = (int)MessageBox.Show("Distances error-blanks", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox4.Text, out tText1, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox5.Text, out tText2, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                xNew = 0.0;
                yNew = 0.0;
                DllClass1.Perpendicular(iParam, xSel[0], ySel[0], xSel[1], ySel[1], tText1, tText2, out xNew, out yNew);
                if (xNew == 0.0 && yNew == 0.0)
                    return;
            }
            if (nProcess == 520)
            {
                iParam = 0;
                if (radioButton1.Checked)
                    iParam = 1;
                if (radioButton2.Checked)
                    iParam = 2;
                if (textBox4.Text == "" || textBox5.Text == "")
                {
                    int num = (int)MessageBox.Show("Anges error-blanks", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                double tText3;
                DllClass1.CheckText(textBox4.Text, out tText3, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                double tText4;
                DllClass1.CheckText(textBox5.Text, out tText4, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                xNew = 0.0;
                yNew = 0.0;
                DllClass1.AngularResect(iParam, xSel[0], ySel[0], xSel[1], ySel[1], tText3, tText4, out xNew, out yNew);
                if (xNew == 0.0 && yNew == 0.0)
                    return;
            }
            if (nProcess == 530)
            {
                iParam = 0;
                if (radioButton1.Checked)
                    iParam = 1;
                if (radioButton2.Checked)
                    iParam = 2;
                if (textBox4.Text == "" || textBox5.Text == "")
                {
                    int num = (int)MessageBox.Show("Distances error-blanks", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox4.Text, out tText1, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox5.Text, out tText2, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                xNew = 0.0;
                yNew = 0.0;
                DllClass1.LinearResect(iParam, xSel[0], ySel[0], xSel[1], ySel[1], tText1, tText2, out xNew, out yNew);
                if (xNew == 0.0 && yNew == 0.0)
                {
                    int num = (int)MessageBox.Show("Distances error-short", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (nProcess == 540)
            {
                if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    int num = (int)MessageBox.Show("Directions error-blank", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox4.Text, out aDir[0], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox5.Text, out aDir[1], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox6.Text, out aDir[2], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Check data", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                dx = Math.Abs(aDir[1] - aDir[0]);
                dy = Math.Abs(aDir[2] - aDir[1]);
                double num1 = Math.Abs(aDir[2] - aDir[0]);
                if (dx < 0.001 || dy < 0.001 || num1 < 0.001)
                {
                    int num2 = (int)MessageBox.Show("Directions error", "Inverse Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                xNew = 0.0;
                yNew = 0.0;
                DllClass1.Inverse(xSel, ySel, aDir, out xNew, out yNew);
                if (xNew == 0.0 && yNew == 0.0)
                    return;
            }
            textBox7.Text = sNew;
            textBox8.Text = string.Format("{0:F3}", (object)xNew);
            textBox9.Text = string.Format("{0:F3}", (object)yNew);
            textBox10.Text = "0";
            textBox11.Text = "0";
            kDat = 0;
            panel7.Invalidate();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            kRcPnt = 0;
            iCode1 = 0;
            zNew = 0.0;
            if (nProcess == 570)
            {
                int num1 = (int)MessageBox.Show("Use button 'Delete'", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (nProcess != 560 && textBox7.Text == "")
            {
                int num2 = (int)MessageBox.Show("Point's name-blank", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                sNew = textBox7.Text;
                if (nProcess == 560)
                {
                    if (textBox8.Text == "" || textBox9.Text == "")
                    {
                        int num3 = (int)MessageBox.Show("Point's coordinate error-blank", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    DllClass1.CheckText(textBox8.Text, out xNew, out iCond);
                    if (iCond < 0)
                    {
                        int num4 = (int)MessageBox.Show("Check data", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    DllClass1.CheckText(textBox9.Text, out yNew, out iCond);
                    if (iCond < 0)
                    {
                        int num5 = (int)MessageBox.Show("Check data", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                if (textBox10.Text != "")
                {
                    DllClass1.CheckText(textBox10.Text, out zNew, out iCond);
                    if (iCond < 0)
                    {
                        int num6 = (int)MessageBox.Show("Check data", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                if (textBox11.Text != "")
                {
                    double tText = 0.0;
                    DllClass1.CheckText(textBox11.Text, out tText, out iCond);
                    if (iCond < 0)
                    {
                        int num7 = (int)MessageBox.Show("Check data", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    iCode1 = Convert.ToInt32(textBox11.Text);
                }
                for (int index = 0; index <= kTaheo; ++index)
                {
                    if (nProcess != 560)
                    {
                        if (myPnt.nameTah[index] == sNew)
                        {
                            int num8 = (int)MessageBox.Show("Points' names-duplicate", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        double num9 = myPnt.xTah[index] - xNew;
                        double num10 = myPnt.yTah[index] - yNew;
                        if (Math.Sqrt(num9 * num9 + num10 * num10) < 0.003)
                        {
                            int num11 = (int)MessageBox.Show("Points' coordinates-duplicate", "Resection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
                if (nProcess == 560)
                {
                    for (int index = 0; index <= kTaheo; ++index)
                    {
                        if (myPnt.nameTah[index] == sNew)
                        {
                            myPnt.xTah[index] = xNew;
                            myPnt.yTah[index] = yNew;
                            myPnt.zTah[index] = zNew;
                            myPnt.nTah1[index] = iCode1;
                            break;
                        }
                    }
                }
                if (nCode < 0)
                    return;
                kMess = 0;
                sDialog = "Points' Codes Errors: ";
                if (nCode < 0)
                {
                    ++kMess;
                    sDialog = sDialog + sNew + ",";
                }
                if (nCode < 0)
                {
                    ++kMess;
                    sDialog = sDialog + sNew + ",";
                }
                if (kMess > 0)
                {
                    int num12 = (int)MessageBox.Show(sDialog, "Points' Symbols", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    FormLoad();
                    panel7.Invalidate();
                }
                else
                {
                    if (nProcess != 560)
                    {
                        ++kTaheo;
                        myPnt.nameTah[kTaheo] = sNew;
                        myPnt.xTah[kTaheo] = xNew;
                        myPnt.yTah[kTaheo] = yNew;
                        myPnt.zTah[kTaheo] = zNew;
                        myPnt.nTah1[kTaheo] = iCode1;
                        myPnt.xTahInscr[kTaheo] = xNew;
                        myPnt.yTahInscr[kTaheo] = yNew;
                        myPnt.iHorVerTah[kTaheo] = 0;
                    }
                    myPnt.kTaheo = kTaheo;
                    myPnt.LoadKeepTaheo(2);
                    FormLoad();
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    kDat = 0;
                    kRcPnt = 0;
                    panel7.Invalidate();
                }
            }
        }

        private void CancelSave_Click(object sender, EventArgs e)
        {
            if (nProcess == 570)
            {
                int index1 = -1;
                for (int index2 = 0; index2 <= kTaheo; ++index2)
                {
                    if (!(myPnt.nameTah[index2] == textBox7.Text))
                    {
                        ++index1;
                        myPnt.nameTah[index1] = myPnt.nameTah[index2];
                        myPnt.xTah[index1] = myPnt.xTah[index2];
                        myPnt.yTah[index1] = myPnt.yTah[index2];
                        myPnt.zTah[index1] = myPnt.zTah[index2];
                        myPnt.nTah1[index1] = myPnt.nTah1[index2];
                        myPnt.xTahInscr[index1] = myPnt.xTahInscr[index2];
                        myPnt.yTahInscr[index1] = myPnt.yTahInscr[index2];
                        myPnt.iHorVerTah[index1] = myPnt.iHorVerTah[index2];
                    }
                }
                kTaheo = index1;
                myPnt.kTaheo = kTaheo;
                myPnt.LoadKeepTaheo(2);
            }
            nProcess = 0;
            kRcPnt = 0;
            kDat = 0;
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            xNew = 0.0;
            yNew = 0.0;
            panel7.Invalidate();
        }

        private void Cancel_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        private void HelpSymb_Click(object sender, EventArgs e)
        {
            int num = (int)new ListPntSign().ShowDialog((IWin32Window)this);
            int index = 0;
            if (File.Exists(myPnt.fileAdd))
            {
                FileStream input = new FileStream(myPnt.fileAdd, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    index = binaryReader.ReadInt32();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось..");
                }
                finally
                {
                    binaryReader.Close();
                    input.Close();
                }
            }
            if (index == 0)
                return;
            textBox11.Text = string.Format("{0}", (object)myPnt.numbUser[index]);
        }

    }
}
