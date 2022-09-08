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
    partial class AddPoints : Form
    {
        private IContainer components;

        private string sDialog = "";
        private int iWidth;
        private int iHeight;
        private int kPntInput;
        private int kPntPlus;
        private int xBegWin;
        private int yBegWin;
        private int xEndWin;
        private int yEndWin;
        private int nProcess;
        private int nControl;
        private int kDat;
        private int[] xDat = new int[10];
        private int[] yDat = new int[10];
        private int x1Box;
        private int y1Box;
        private int x2Box;
        private int y2Box;
        private int kRcPnt;
        private int iCode1;
        private int iCode2;
        private int iParam;
        private int kSymbPnt;
        private int nProcInput = -1;
        private int kLineInput;
        private int kHeight;
        private int kPntSource;
        private int kLineAct;
        private int kPolyAct;
        private int kPntProj = -1;
        private int kLineProj;
        private int nCode;
        private int kMess;
        private int kProjInput;
        private int kTopoProj;
        private int kPolyProj;
        private int nAction;
        private int kNodeAct;
        private int kIntAct;
        private double xaCur;
        private double yaCur;
        private double xbCur;
        private double ybCur;
        private double xCur;
        private double yCur;
        private double xmin;
        private double ymin;
        private double zmin;
        private double xmax;
        private double ymax;
        private double zmax;
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
        private int kPoly;
        private int kLineTopo;
        private int kNode;
        private int kPntFin;
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

        MyGeodesy myPoint = new MyGeodesy();

        public string fCurPnt { get; private set; }
        public string fCurHeig { get; private set; }
        public string fCurLine { get; private set; }
        public StatusBarPanel panel { get; private set; }
       
        public AddPoints()
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
            button10.MouseHover += new EventHandler(button10_MouseHover);
            button10.MouseLeave += new EventHandler(button1_MouseLeave);
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
            button20.MouseHover += new EventHandler(button20_MouseHover);
            button20.MouseLeave += new EventHandler(button1_MouseLeave);
            myPoint.FilePath();
            FormLoad();
            radioButton1.Checked = true;
            groupBox4.Visible = false;
            panel7.Invalidate();
        }
        private void button1_MouseHover(object sender, EventArgs e) => label12.Text = "Вернуться к Главному меню";

        private void button1_MouseLeave(object sender, EventArgs e) => label12.Text = "";

        private void button2_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите кнопку. Зажмите левую кнопку мыши и переместите ее для выбора области, затем отпустите кнопку. Щелкните правой кнопкой мыши для возвращения в исходное положение";

        private void button3_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите кнопку. Нажмите и отпустите левую кнопку мыши рядом с точкой выделения. Щелкните правой кнопкой мыши для возвращения в исходное положение";

        private void button4_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите кнопку. Нажмите и отпустите левую кнопку мыши рядом с точкой выделения. Щелкните правой кнопкой мыши для возвращения в исходное положение";

        private void button5_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите кнопку. Зажмите левую кнопку мыши и ведите вдоль экрана. Щелкните правой кнопкой мыши для возвращения в исходное положение";

        private void button6_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите кнопку. Выберите мышью 2 точки как базисные для добавления точки методом перпендикуляров";

        private void button7_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите кнопку. Выберите мышью 2 точки как базисные для добавления точки методом угловой засечки";

        private void button8_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите кнопку.  Выберите мышью 2 точки как базисные для добавления точки методом  линейной засечки";

        private void button9_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите кнопку.  Выберите мышью 3 точки как базисные для добавления точки методом обратной линейной засечки";

        private void button10_MouseHover(object sender, EventArgs e) => label12.Text = "Добавление точки путем ввода данных точки с помощью диалогового окна";

        private void button11_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите кнопку. Выберите точку мышью для проверки и исправления данных";

        private void button12_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите кнопку. Выделите точку мышью и нажмите кнопку 'Удалить'.";

        private void button13_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите эту кнопку после выбора метода и базисных точек";

        private void button14_MouseHover(object sender, EventArgs e) => label12.Text = "Сохранить результаты";

        private void button15_MouseHover(object sender, EventArgs e) => label12.Text = "Эта кнопка имеет 2 назначения в зависимости от процесса(действия)";

        private void button20_MouseHover(object sender, EventArgs e) => label12.Text = "Нажмите кнопку. Используя данные координат statusBar1, переместите курсор мыши на заданные координаты и нажмите левую кнопку мыши.";

        private void FormLoad()
        {
            this.xmin = 9999999.9;
            this.ymin = 9999999.9;
            this.zmin = 9999999.9;
            this.xmax = -9999999.9;
            this.ymax = -9999999.9;
            this.zmax = -9999999.9;
            if (File.Exists(this.myPoint.fileProcess))
            {
                FileStream input = new FileStream(this.myPoint.fileProcess, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.nProcInput = binaryReader.ReadInt32();
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
            if (this.nProcInput == 970)
            {
                this.groupBox3.Visible = false;
                this.label11.Visible = false;
                this.textBox11.Visible = false;
                this.button21.Visible = false;
            }
            if (this.nProcInput == 920)
                this.groupBox7.Visible = false;
            DllClass1.SetColour(this.myPoint.brColor, this.myPoint.pnColor);
            DllClass1.PointSymbLoad(this.myPoint.fsymbPnt, out this.kSymbPnt, this.myPoint.numRec, this.myPoint.numbUser, this.myPoint.heiSymb);
            this.myPoint.kSymbPnt = this.kSymbPnt;
            this.myPoint.PolygonLoad(ref this.myPoint.kPolyInside);
            this.kPoly = this.myPoint.kPoly;
            this.myPoint.LineTopoLoad();
            this.kLineTopo = this.myPoint.kLineTopo;
            this.myPoint.LineLoad();
            this.kLineInput = this.myPoint.kLineInput;
            this.xmin = this.myPoint.xmin;
            this.ymin = this.myPoint.ymin;
            this.xmax = this.myPoint.xmax;
            this.ymax = this.myPoint.ymax;
            this.myPoint.PointLoad();
            this.kPntPlus = this.myPoint.kPntPlus;
            this.kPntInput = this.myPoint.kPntInput;
            this.xmin = this.myPoint.xmin;
            this.ymin = this.myPoint.ymin;
            this.xmax = this.myPoint.xmax;
            this.ymax = this.myPoint.ymax;
            this.zmin = this.myPoint.zmin;
            this.zmax = this.myPoint.zmax;
            this.kPntFin = 0;
            this.myPoint.PointLoadFin();
            this.kPntFin = this.myPoint.kPntFin;
            if (this.kPntPlus > 0 && !File.Exists(this.myPoint.fpointInscr))
            {
                FileStream output = new FileStream(this.myPoint.fpointInscr, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(this.kPntPlus);
                for (int index = 0; index <= this.kPntPlus; ++index)
                {
                    this.myPoint.xPntInscr[index] = this.myPoint.xPnt[index];
                    this.myPoint.yPntInscr[index] = this.myPoint.yPnt[index];
                    this.myPoint.iHorVerPnt[index] = 0;
                    binaryWriter.Write(this.myPoint.xPnt[index]);
                    binaryWriter.Write(this.myPoint.yPnt[index]);
                    binaryWriter.Write(this.myPoint.iHorVerPnt[index]);
                }
                binaryWriter.Close();
                output.Close();
            }
            this.myPoint.LoadKeepInscr(1);
            if (this.kPntFin > 0)
                this.myPoint.InscriptionFin(1);
            this.myPoint.PointProjLoad();
            this.kPntProj = this.myPoint.kPntProj;
            this.kProjInput = this.myPoint.kProjInput;
            this.myPoint.LineProjLoad();
            this.kLineProj = this.myPoint.kLineProj;
            this.myPoint.TopoProjLoad();
            this.kTopoProj = this.myPoint.kTopoProj;
            this.myPoint.PolyProjLoad();
            this.kPolyProj = this.myPoint.kPolyProj;
            this.myPoint.LoadNode();
            this.kNode = this.myPoint.kNodeTopo;
            this.myPoint.KeepLoadAction(1);
            this.nAction = this.myPoint.nAction;
            if (this.nAction > 0)
            {
                this.myPoint.NodeActLoad(this.nAction);
                this.kNodeAct = this.myPoint.kNodeAct;
                this.myPoint.TopoActLoad(this.nAction);
                this.kLineAct = this.myPoint.kLineAct;
                this.myPoint.PolyActLoad(this.nAction);
                this.kPolyAct = this.myPoint.kPolyAct;
            }
            if (this.nAction == 0)
                this.KeepActionZero();
            this.xminCur = this.xmin;
            this.yminCur = this.ymin;
            this.xmaxCur = this.xmax;
            this.ymaxCur = this.ymax;
            DllClass1.CoorWin(this.xmin, this.ymin, this.xmax, this.ymax, this.iWidth, this.iHeight, out this.scaleToWin, out this.scaleToGeo, out this.xBegX, out this.yBegY, out this.xEndX, out this.yEndY, out this.xBegWin, out this.yBegWin, out this.xEndWin, out this.yEndWin, out this.iCond);
            if (this.iCond >= 0)
                return;
            this.iGraphic = 1;
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
            DllClass1.XYtoWIN(xNew, yNew, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
            if (xWin == 0 && yWin == 0)
                return;
            graphics.FillRectangle((Brush)solidBrush1, xWin - 1, yWin - 1, 3, 3);
            graphics.DrawString(sNew, new Font("Bold", (float)emSize), (Brush)solidBrush1, (float)(xWin + emSize / 2), (float)(yWin - emSize + 2));
        }

        public void KeepActionZero()
        {
            int num1;
            int index1 = num1 = 0;
            if (kLineTopo == 0)
                return;
            kLineAct = kLineTopo;
            for (int index2 = 1; index2 <= kLineTopo; ++index2)
            {
                myPoint.kActLine1[index2] = myPoint.kl1[index2];
                myPoint.kActLine2[index2] = myPoint.kl2[index2];
                int num2 = myPoint.kl1[index2];
                int num3 = myPoint.kl2[index2];
                for (int index3 = num2; index3 <= num3; ++index3)
                {
                    ++index1;
                    myPoint.xLineAct[index1] = myPoint.zLin[index3];
                    myPoint.yLineAct[index1] = myPoint.zPik[index3];
                }
            }
            myPoint.kLineAct = kLineAct;
            myPoint.KeepTopoAct(nAction);
            if (myPoint.kPoly == 0)
                return;
            kPoly = myPoint.kPoly;
            kPolyAct = kPoly;
            for (int index4 = 1; index4 <= kPolyAct; ++index4)
            {
                myPoint.nameAct[index4] = myPoint.namePoly[index4];
                myPoint.xAct[index4] = myPoint.xLab[index4];
                myPoint.yAct[index4] = myPoint.yLab[index4];
                myPoint.aActCalc[index4] = myPoint.areaPol[index4];
                myPoint.aActLeg[index4] = myPoint.areaLeg[index4];
                myPoint.kActPoly1[index4] = myPoint.kt1[index4];
                myPoint.kActPoly2[index4] = myPoint.kt2[index4];
                int num4 = myPoint.kt1[index4];
                int num5 = myPoint.kt2[index4];
                for (int index5 = num4; index5 <= num5; ++index5)
                {
                    myPoint.xPolyAct[index5] = myPoint.xPol[index5];
                    myPoint.yPolyAct[index5] = myPoint.yPol[index5];
                }
            }
            kIntAct = 0;
            for (int index6 = 1; index6 <= kPolyAct; ++index6)
            {
                int k = -1;
                int num6 = myPoint.kActPoly1[index6];
                int num7 = myPoint.kActPoly2[index6];
                for (int index7 = num6; index7 <= num7; ++index7)
                {
                    ++k;
                    myPoint.xOut[k] = myPoint.xPolyAct[index7];
                    myPoint.yOut[k] = myPoint.yPolyAct[index7];
                }
                myPoint.kPolyActInt[index6] = 0;
                for (int index8 = 1; index8 <= kPolyAct; ++index8)
                {
                    if (index6 != index8 && myPoint.aActCalc[index8] < myPoint.aActCalc[index6] && DllClass1.in_out(k, ref myPoint.xOut, ref myPoint.yOut, myPoint.xAct[index8], myPoint.yAct[index8]) > 0)
                    {
                        myPoint.kPolyActInt[index6] = myPoint.kPolyActInt[index6] + 1;
                        ++kIntAct;
                        myPoint.kIndexAct1[kIntAct] = index6;
                        myPoint.kIndexAct2[kIntAct] = index8;
                    }
                }
            }
            myPoint.kPolyAct = kPolyAct;
            myPoint.kIntAct = kIntAct;
            myPoint.KeepPolyAct(nAction);
            kNodeAct = kNode;
            for (int index9 = 1; index9 <= kNodeAct; ++index9)
            {
                myPoint.nameNodeAct[index9] = myPoint.nameNode[index9];
                myPoint.xNodeAct[index9] = myPoint.xNode[index9];
                myPoint.yNodeAct[index9] = myPoint.yNode[index9];
            }
            myPoint.kNodeAct = kNodeAct;
            myPoint.KeepNodeAct(nAction);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (iGraphic > 0)
                return;
            if (nControl == 10)
                graphics.DrawRectangle(new Pen(Color.Green, 2f), RcDraw);
            if (kLineAct > 0)
            {
                int iPar = 1;
                DllClass1.LineDraw(e, kLineAct, myPoint.kActLine1, myPoint.kActLine2, myPoint.xLineAct,
                    myPoint.yLineAct, myPoint.radAct, scaleToWin, xBegX, yBegY, xBegWin, yBegWin,
                    myPoint.pnColor, iPar);
            }
            if (kPolyAct > 0)
            {
                int iParam = 8;
                DllClass1.LabelDraw(e, kPolyAct, myPoint.nameAct, myPoint.xAct, myPoint.yAct,
                    myPoint.iHorVer, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myPoint.brColor, iParam);
            }
            if (kPntPlus > 0 && kPntFin == 0)
                DllClass1.PointsDraw(e, myPoint.fsymbPnt, 0, kPntPlus, myPoint.namePnt,
                    myPoint.xPnt, myPoint.yPnt, myPoint.zPnt, myPoint.xPntInscr, myPoint.yPntInscr,
                    myPoint.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myPoint.nCode1,
                    myPoint.nCode2, kSymbPnt, myPoint.numRec, myPoint.numbUser, myPoint.ixSqu, 
                    myPoint.iySqu, myPoint.nColor, myPoint.brColor, myPoint.pnColor);
            if (kPntFin > 0)
                DllClass1.PointsDraw(e, myPoint.fsymbPnt, 0, kPntFin, myPoint.namePntFin,
                    myPoint.xPntFin, myPoint.yPntFin, myPoint.zPntFin, myPoint.xPntInscr, 
                    myPoint.yPntInscr, myPoint.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin,
                    yBegWin, myPoint.nCode1Fin, myPoint.nCode2Fin, kSymbPnt, myPoint.numRec, 
                    myPoint.numbUser, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, myPoint.brColor,
                    myPoint.pnColor);
            if (nProcInput == 970 && kPntProj > -1)
                DrawPntProj(e);
            if (kLineProj > 0)
            {
                int iPar = 2;
                DllClass1.LineDraw(e, kLineProj, myPoint.kPr1, myPoint.kPr2, myPoint.xLinProj,
                    myPoint.yLinProj, myPoint.RadProj, scaleToWin, xBegX, yBegY, xBegWin, yBegWin,
                    myPoint.pnColor, iPar);
            }
            if (kLineTopo > 0)
            {
                iParam = 1;
                DllClass1.LineDraw(e, kLineTopo, myPoint.kl1, myPoint.kl2, myPoint.zLin, myPoint.zPik, myPoint.radLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myPoint.pnColor, iParam);
            }
            if (nProcess == 510 || nProcess == 520 || nProcess == 530 || nProcess == 540 || nProcess == 560 || nProcess == 570)
            {
                if (kRcPnt > 0)
                {
                    for (int index = 1; index <= kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), RcPnt[index]);
                    if (kRcPnt == 2 && nProcess != 540)
                    {
                        Point[] pointArray = new Point[3];
                        pointArray[0].X = RcPnt[1].X;
                        pointArray[0].Y = RcPnt[1].Y;
                        pointArray[1].X = RcPnt[2].X;
                        pointArray[1].Y = RcPnt[2].Y;
                        graphics.DrawLine(new Pen(Color.Gold), pointArray[0], pointArray[1]);
                    }
                }
                if (xNew != 0.0 && yNew != 0.0)
                    NewPointDraw(e, sNew, xNew, yNew);
            }
            if (nProcess == 550 && xNew != 0.0 && yNew != 0.0)
                NewPointDraw(e, sNew, xNew, yNew);
            if ((nProcess == 580 || nProcess == 600 || nProcess == 610) && kRcPnt > 0)
            {
                for (int index = 1; index <= kRcPnt; ++index)
                    graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), RcPnt[index]);
            }
            Cursor.Current = Cursors.Default;
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
            if (!File.Exists(myPoint.filePoint))
            {
                panel2.Text = string.Format("{0}", (object)e.X);
                panel4.Text = string.Format("{0}", (object)e.Y);
            }
            if (File.Exists(myPoint.filePoint))
            {
                panel2.Text = string.Format("{0:F3}", (object)xCur);
                panel4.Text = string.Format("{0:F3}", (object)yCur);
            }
            if (nControl == 10 && e.Button == MouseButtons.Left && isDrag)
            {
                ControlPaint.DrawReversibleFrame(theRectangle, BackColor, FrameStyle.Dashed);
                endPoint = PointToScreen(new Point(e.X, e.Y));
                if (e.X > 15 && e.X < pixWid + 10 && e.Y > 15 && e.Y < pixHei + 10)
                    theRectangle = new Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X,
                        endPoint.Y - startPoint.Y);
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
            DllClass1.CoorWin(xaCur, yaCur, xbCur, ybCur, iWidth, iHeight, out scaleToWin, out scaleToGeo, 
                out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
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
            DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
            if (nControl == 10)
            {
                DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCurMin, out yCurMin);
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
                DllClass1.CoorWin(x1, y1, x2, y2, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, 
                    out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
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
                DllClass1.CoorWin(x1, y1, x2, y2, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, 
                    out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
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
                DllClass1.CoorWin(xminCur, yminCur, xmaxCur, ymaxCur, iWidth, iHeight, out scaleToWin, out scaleToGeo, 
                    out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                if (iCond < 0)
                    iGraphic = 1;
                kDat = 0;
                panel7.Invalidate();
            }
            if (e.Button != MouseButtons.Left || nProcess != 510 && nProcess != 520 && nProcess != 530 && nProcess != 540 && nProcess 
                != 560 && nProcess != 570 && nProcess != 580 && nProcess != 600 && nProcess != 610)
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
                    DllClass1.CoorWin(xCurMin, yCurMin, xCurMax, yCurMax, iWidth, iHeight, out scaleToWin,
                        out scaleToGeo, 
                        out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin,
                        out yEndWin, out iCond);
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
                if (kDat == 2)
                {
                    for (int index = 1; index <= kDat; ++index)
                    {
                        DllClass1.WINtoXY(xDat[index], yDat[index], scaleToGeo, xBegX, yBegY, xBegWin,
                            yBegWin, out xCur, out yCur);
                        int indx = -1;
                        DllClass1.SelPoint(kPntPlus, myPoint.xPnt, myPoint.yPnt, xCur, yCur, out indx);
                        if (indx >= 1)
                        {
                            if (index == 1)
                            {
                                textBox1.Text = myPoint.namePnt[indx];
                                xSel[0] = myPoint.xPnt[indx];
                                ySel[0] = myPoint.yPnt[indx];
                            }
                            if (index == 2)
                            {
                                textBox2.Text = myPoint.namePnt[indx];
                                xSel[1] = myPoint.xPnt[indx];
                                ySel[1] = myPoint.yPnt[indx];
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
                if (kDat == 3)
                {
                    for (int index = 1; index <= kDat; ++index)
                    {
                        DllClass1.WINtoXY(xDat[index], yDat[index], scaleToGeo, xBegX, yBegY, xBegWin,
                            yBegWin, out xCur, out yCur);
                        int indx = -1;
                        DllClass1.SelPoint(kPntPlus, myPoint.xPnt, myPoint.yPnt, xCur, yCur, out indx);
                        if (indx >= 1)
                        {
                            if (index == 1)
                            {
                                textBox1.Text = myPoint.namePnt[indx];
                                xSel[0] = myPoint.xPnt[indx];
                                ySel[0] = myPoint.yPnt[indx];
                            }
                            if (index == 2)
                            {
                                textBox2.Text = myPoint.namePnt[indx];
                                xSel[1] = myPoint.xPnt[indx];
                                ySel[1] = myPoint.yPnt[indx];
                            }
                            if (index == 3)
                            {
                                textBox3.Text = myPoint.namePnt[indx];
                                xSel[2] = myPoint.xPnt[indx];
                                ySel[2] = myPoint.yPnt[indx];
                            }
                        }
                    }
                }
            }
            if (nProcess == 560 || nProcess == 570)
            {
                RcPnt[kRcPnt].Width = 6;
                RcPnt[kRcPnt].Height = 6;
                panel7.Invalidate(RcPnt[kRcPnt]);
                if (kDat == 1)
                {
                    for (int index = 1; index <= kDat; ++index)
                    {
                        DllClass1.WINtoXY(xDat[index], yDat[index], scaleToGeo, xBegX, yBegY, xBegWin,
                            yBegWin, out xCur, out yCur);
                        int indx = -1;
                        DllClass1.SelPoint(kPntPlus, myPoint.xPnt, myPoint.yPnt, xCur, yCur, out indx);
                        if (indx >= 0 && index == 1)
                        {
                            textBox7.Text = myPoint.namePnt[indx];
                            textBox8.Text = string.Format("{0:F3}", (object)myPoint.xPnt[indx]);
                            textBox9.Text = string.Format("{0:F3}", (object)myPoint.yPnt[indx]);
                            textBox10.Text = string.Format("{0:F3}", (object)myPoint.zPnt[indx]);
                            textBox11.Text = string.Format("{0}", (object)myPoint.nCode1[indx]);
                        }
                    }
                }
                kDat = 0;
            }
            if (nProcess == 580 || nProcess == 610)
            {
                RcPnt[kRcPnt].Width = 6;
                RcPnt[kRcPnt].Height = 6;
                panel7.Invalidate(RcPnt[kRcPnt]);
                panel7.Invalidate();
                if (kDat == 1)
                {
                    DllClass1.WINtoXY(xDat[1], yDat[1], scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                    textBox8.Text = string.Format("{0:F3}", (object)xCur);
                    textBox9.Text = string.Format("{0:F3}", (object)yCur);
                    textBox10.Text = "0";
                    textBox11.Text = "0";
                }
                kDat = 0;
            }
            if (nProcess != 600)
                return;
            RcPnt[kRcPnt].Width = 6;
            RcPnt[kRcPnt].Height = 6;
            panel7.Invalidate(RcPnt[kRcPnt]);
            if (kDat == 1)
            {
                DllClass1.WINtoXY(xDat[1], yDat[1], scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                int index1 = -1;
                double num1;
                double num2 = num1 = 0.0;
                double num3 = 9999999.9;
                for (int index2 = 0; index2 <= kPntProj; ++index2)
                {
                    double num4 = myPoint.xProj[index2] - xCur;
                    double num5 = myPoint.yProj[index2] - yCur;
                    double num6 = Math.Sqrt(num4 * num4 + num5 * num5);
                    if (num6 < num3)
                    {
                        index1 = index2;
                        num3 = num6;
                    }
                }
                if (MessageBox.Show("Вы действительно хотите удалить эту точку?", "Номер точки " + myPoint.nameProj[index1],
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    kDat = 0;
                    kRcPnt = 0;
                    nProcess = 0;
                    panel7.Invalidate();
                    return;
                }
                if (kPntProj > 0)
                {
                    int index3 = -1;
                    for (int index4 = 0; index4 <= kPntProj; ++index4)
                    {
                        if (!(myPoint.nameProj[index4] == myPoint.nameProj[index1]))
                        {
                            ++index3;
                            myPoint.nameProj[index3] = myPoint.nameProj[index4];
                            myPoint.xProj[index3] = myPoint.xProj[index4];
                            myPoint.yProj[index3] = myPoint.yProj[index4];
                            myPoint.zProj[index3] = myPoint.zProj[index4];
                            myPoint.nProj1[index3] = myPoint.nProj1[index4];
                            myPoint.nProj2[index3] = myPoint.nProj2[index4];
                        }
                    }
                    if (index3 < 0)
                        index3 = 0;
                    kPntProj = index3;
                    myPoint.kPntProj = kPntProj;
                    myPoint.kProjInput = kProjInput;
                    myPoint.KeepPointProj();
                }
                if (kPntProj == 0)
                {
                    kPntProj = -1;
                    if (File.Exists(myPoint.fpointProj))
                        File.Delete(myPoint.fpointProj);
                }
                panel7.Invalidate();
            }
            kDat = 0;
            kRcPnt = 0;
            nProcess = 0;
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
            iCode2 = 0;
            groupBox7.Visible = false;
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
            label2.Text = "Расстояние от 1,м";
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
            iCode2 = 0;
            groupBox7.Visible = false;
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
            label2.Text = "Угол от 1,г°мм'сс";
            label3.Visible = true;
            label4.Visible = true;
            label6.Visible = true;
            label6.Text = "Угол от 2,г°мм'сс";
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
            iCode2 = 0;
            groupBox7.Visible = false;
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
            label2.Text = "Расстояние от 1,м";
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = true;
            label6.Text = "Расстояние от 2,м";
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
            iCode2 = 0;
            groupBox7.Visible = false;
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
            label2.Text = "Направления,г°мм'сс";
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

        private void InputData_Click(object sender, EventArgs e)
        {
            this.nProcess = 550;
            this.nControl = 0;
            this.kDat = 0;
            this.kRcPnt = 0;
            this.sNew = "";
            this.xNew = 0.0;
            this.yNew = 0.0;
            this.zNew = 0.0;
            this.iCode1 = 0;
            this.iCode2 = 0;
            this.groupBox7.Visible = false;
            this.groupBox4.Visible = true;
            this.groupBox6.Visible = false;
            this.textBox1.Visible = false;
            this.textBox2.Visible = false;
            this.textBox3.Visible = false;
            this.textBox4.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox8.ReadOnly = false;
            this.textBox9.ReadOnly = false;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.label5.Visible = false;
            this.label6.Visible = false;
            this.button13.Visible = false;
            int nName = 0;
            DllClass1.NewPointName(this.kPntPlus, this.myPoint.namePnt, out nName, out this.sNew);
            if (nName < 0)
                return;
            this.textBox7.Text = this.sNew;
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "0";
            this.textBox11.Text = "0";
            this.panel7.Invalidate();
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
            iCode2 = 0;
            groupBox7.Visible = false;
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
            iCode2 = 0;
            groupBox7.Visible = false;
            groupBox4.Visible = true;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
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
            button15.Text = "Удалить";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            panel7.Invalidate();
        }

        private void DrawPntProj(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int xWin = 0;
            int yWin = 0;
            int emSize = 6;
            if (kPntProj < 0)
                return;
            SolidBrush solidBrush1 = new SolidBrush(Color.Red);
            Pen pen1 = new Pen(Color.Red);
            SolidBrush solidBrush2 = new SolidBrush(Color.Red);
            Pen pen2 = new Pen(Color.Red);
            for (int index = 0; index <= kPntProj; ++index)
            {
                DllClass1.XYtoWIN(myPoint.xProj[index], myPoint.yProj[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                {
                    graphics.FillRectangle((Brush)solidBrush1, xWin - 2, yWin - 2, 4, 4);
                    graphics.DrawString(myPoint.nameProj[index], new Font("Bold", (float)emSize), (Brush)solidBrush1, (float)(xWin + emSize / 2), (float)(yWin - emSize));
                }
            }
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            int nName = 0;
            DllClass1.NewPointName(kPntPlus, myPoint.namePnt, out nName, out sNew);
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
                    int num = (int)MessageBox.Show("Ошибка расстояний - пробелы(пустоты)", "Перпендикуляр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox4.Text, out tText1, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Перпендикуляр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox5.Text, out tText2, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Перпендикуляр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    int num = (int)MessageBox.Show("Угловая ошибка - разрывы(пустоты)", "Засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                double tText3;
                DllClass1.CheckText(textBox4.Text, out tText3, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                double tText4;
                DllClass1.CheckText(textBox5.Text, out tText4, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    int num = (int)MessageBox.Show("Ошибка расстояний - пробелы(пустоты)", "Засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox4.Text, out tText1, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox5.Text, out tText2, out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                xNew = 0.0;
                yNew = 0.0;
                DllClass1.LinearResect(iParam, xSel[0], ySel[0], xSel[1], ySel[1], tText1, tText2, out xNew, out yNew);
                if (xNew == 0.0 && yNew == 0.0)
                {
                    int num = (int)MessageBox.Show("Ошибка расстояний - короткая", "Обратная засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (nProcess == 540)
            {
                if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    int num = (int)MessageBox.Show("Направления ошибка - пустоты(разрывы)", "Обратная засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox4.Text, out aDir[0], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Обратная засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox5.Text, out aDir[1], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Обратная засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(textBox6.Text, out aDir[2], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Обратная засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                xNew = 0.0;
                yNew = 0.0;
                DllClass1.Inverse(xSel, ySel, aDir, out xNew, out yNew);
                double num1 = 9999999.9;
                double num2 = 9999999.9;
                double num3 = -9999999.9;
                double num4 = -9999999.9;
                for (int index = 0; index <= 2; ++index)
                {
                    if (xSel[index] < num1)
                        num1 = xSel[index];
                    if (xSel[index] > num3)
                        num3 = xSel[index];
                    if (ySel[index] < num2)
                        num2 = ySel[index];
                    if (ySel[index] > num4)
                        num4 = ySel[index];
                }
                double num5 = num3 - num1;
                double num6 = num4 - num2;
                double num7 = Math.Sqrt(num5 * num5 + num6 * num6);
                for (int index = 0; index <= 2; ++index)
                {
                    double num8 = xSel[index] - xNew;
                    double num9 = ySel[index] - yNew;
                    if (Math.Sqrt(num8 * num8 + num9 * num9) > 2.0 * num7)
                    {
                        xNew = yNew = 0.0;
                        int num10 = (int)MessageBox.Show("Проверьте данные", "Обратная засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
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
            iCode2 = 0;
            zNew = 0.0;
            if (nProcess == 580 || nProcess == 590)
            {
                if (textBox7.Text == "")
                {
                    int num1 = (int)MessageBox.Show("Название точки - пусто", "Проектные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (textBox8.Text == "" || textBox9.Text == "")
                {
                    int num2 = (int)MessageBox.Show("Ошибка в координатах точки - пустоты(разрывы)", "Засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ++kPntProj;
                    myPoint.nameProj[kPntProj] = textBox7.Text;
                    DllClass1.CheckText(textBox8.Text, out myPoint.xProj[kPntProj], out iCond);
                    if (iCond < 0)
                    {
                        int num3 = (int)MessageBox.Show("Проверьте данные", "Засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        DllClass1.CheckText(textBox9.Text, out myPoint.yProj[kPntProj], out iCond);
                        if (iCond < 0)
                        {
                            int num4 = (int)MessageBox.Show("Проверьте данные", "Засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (textBox10.Text != "")
                            {
                                DllClass1.CheckText(textBox10.Text, out myPoint.zProj[kPntProj], out iCond);
                                if (iCond < 0)
                                {
                                    int num5 = (int)MessageBox.Show("Проверьте данные", "Засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }
                            double tText = 0.0;
                            if (textBox11.Text != "")
                            {
                                DllClass1.CheckText(textBox11.Text, out tText, out iCond);
                                if (iCond < 0)
                                {
                                    int num6 = (int)MessageBox.Show("Проверьте данные", "Обратная засечка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                                myPoint.nProj1[kPntProj] = Convert.ToInt32(textBox11.Text);
                            }
                            myPoint.kPntProj = kPntProj;
                            myPoint.kProjInput = kProjInput;
                            myPoint.KeepPointProj();
                            textBox7.Text = "";
                            textBox8.Text = "";
                            textBox9.Text = "";
                            textBox10.Text = "";
                            textBox11.Text = "";
                            kDat = 0;
                            kRcPnt = 0;
                            FormLoad();
                            panel7.Invalidate();
                        }
                    }
                }
            }
            else if (nProcess == 570)
            {
                int num7 = (int)MessageBox.Show("Использовать кнопку 'Удалить'", "Данные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (nProcess != 560 && textBox7.Text == "")
            {
                int num8 = (int)MessageBox.Show("Название точки - пусто", "Данные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                sNew = textBox7.Text;
                if (nProcess == 550 || nProcess == 560 || nProcess == 610)
                {
                    if (textBox8.Text == "" || textBox9.Text == "")
                    {
                        int num9 = (int)MessageBox.Show("Ошибка в координатах точки - пустоты(разрывы)", "Данные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    DllClass1.CheckText(textBox8.Text, out xNew, out iCond);
                    if (iCond < 0)
                    {
                        int num10 = (int)MessageBox.Show("Проверьте данные", "Данные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    DllClass1.CheckText(textBox9.Text, out yNew, out iCond);
                    if (iCond < 0)
                    {
                        int num11 = (int)MessageBox.Show("Проверьте данные", "Данные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                if (textBox10.Text != "")
                {
                    DllClass1.CheckText(textBox10.Text, out zNew, out iCond);
                    if (iCond < 0)
                    {
                        int num12 = (int)MessageBox.Show("Проверьте данные", "Данные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                double tText = 0.0;
                if (textBox11.Text != "")
                {
                    DllClass1.CheckText(textBox11.Text, out tText, out iCond);
                    if (iCond < 0)
                    {
                        int num13 = (int)MessageBox.Show("Проверьте данные", "Данные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    int int32 = Convert.ToInt32(textBox11.Text);
                    if (int32 > 0)
                    {
                        int num14 = 0;
                        for (int index = 1; index <= kSymbPnt; ++index)
                        {
                            if (myPoint.numbUser[index] == int32)
                            {
                                ++num14;
                                break;
                            }
                        }
                        if (num14 == 0)
                        {
                            int num15 = (int)MessageBox.Show("Проверьте код", "Данные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox7.Text = "";
                            textBox8.Text = "";
                            textBox9.Text = "";
                            textBox10.Text = "0";
                            textBox11.Text = "0";
                            return;
                        }
                    }
                    iCode1 = Convert.ToInt32(textBox11.Text);
                }
                iCode2 = 0;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    if (nProcess != 560)
                    {
                        if (myPoint.namePnt[index] == sNew)
                        {
                            int num16 = (int)MessageBox.Show("Дубликат имени точки (потор)", "Данные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        double num17 = myPoint.xPnt[index] - xNew;
                        double num18 = myPoint.yPnt[index] - yNew;
                        if (Math.Sqrt(num17 * num17 + num18 * num18) < 0.003)
                        {
                            int num19 = (int)MessageBox.Show("Повтор координат точки(дубликат)", "Данные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
                if (nProcess == 560)
                {
                    for (int index = 0; index <= kPntPlus; ++index)
                    {
                        if (myPoint.namePnt[index] == sNew)
                        {
                            myPoint.xPnt[index] = xNew;
                            myPoint.yPnt[index] = yNew;
                            myPoint.zPnt[index] = zNew;
                            myPoint.nCode1[index] = iCode1;
                            myPoint.nCode2[index] = iCode2;
                            break;
                        }
                    }
                }
                DllClass1.SelPntCode(iCode1, myPoint.kSymbPnt, myPoint.numRec, myPoint.numbUser, out nCode);
                if (nCode < 0)
                    return;
                kMess = 0;
                sDialog = "Ошибка кода точки: ";
                if (nCode < 0)
                {
                    ++kMess;
                    sDialog = sDialog + sNew + ",";
                }
                if (kMess > 0)
                {
                    int num20 = (int)MessageBox.Show(sDialog, "Символы точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    FormLoad();
                    panel7.Invalidate();
                }
                else
                {
                    if (nProcess != 560)
                    {
                        ++kPntPlus;
                        myPoint.namePnt[kPntPlus] = sNew;
                        myPoint.xPnt[kPntPlus] = xNew;
                        myPoint.yPnt[kPntPlus] = yNew;
                        myPoint.zPnt[kPntPlus] = zNew;
                        myPoint.nCode1[kPntPlus] = iCode1;
                        myPoint.nCode2[kPntPlus] = iCode2;
                        myPoint.xPntInscr[kPntPlus] = xNew;
                        myPoint.yPntInscr[kPntPlus] = yNew;
                        myPoint.iHorVerPnt[kPntPlus] = 0;
                    }
                    myPoint.kPntPlus = kPntPlus;
                    myPoint.kPntInput = kPntInput;
                    myPoint.KeepPoint();
                    xmin = myPoint.xmin;
                    ymin = myPoint.ymin;
                    xmax = myPoint.xmax;
                    ymax = myPoint.ymax;
                    myPoint.LoadKeepInscr(2);
                    kPntFin = 0;
                    if (File.Exists(myPoint.fpointFinal))
                        File.Delete(myPoint.fpointFinal);
                    if (File.Exists(myPoint.fInscrFin))
                        File.Delete(myPoint.fInscrFin);
                    if (File.Exists(myPoint.fpointInscr))
                    {
                        File.Delete(myPoint.fpointInscr);
                        FileStream output = new FileStream(myPoint.fpointInscr, FileMode.CreateNew);
                        BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                        binaryWriter.Write(kPntPlus);
                        for (int index = 0; index <= kPntPlus; ++index)
                        {
                            myPoint.xPntInscr[index] = myPoint.xPnt[index];
                            myPoint.yPntInscr[index] = myPoint.yPnt[index];
                            myPoint.iHorVerPnt[index] = 0;
                            binaryWriter.Write(myPoint.xPnt[index]);
                            binaryWriter.Write(myPoint.yPnt[index]);
                            binaryWriter.Write(myPoint.iHorVerPnt[index]);
                        }
                        binaryWriter.Close();
                        output.Close();
                    }
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
                for (int index2 = 0; index2 <= kPntPlus; ++index2)
                {
                    if (!(myPoint.namePnt[index2] == textBox7.Text))
                    {
                        ++index1;
                        myPoint.namePnt[index1] = myPoint.namePnt[index2];
                        myPoint.xPnt[index1] = myPoint.xPnt[index2];
                        myPoint.yPnt[index1] = myPoint.yPnt[index2];
                        myPoint.zPnt[index1] = myPoint.zPnt[index2];
                        myPoint.nCode1[index1] = myPoint.nCode1[index2];
                        myPoint.nCode2[index1] = myPoint.nCode2[index2];
                    }
                }
                kPntPlus = index1;
                myPoint.kPntPlus = kPntPlus;
                myPoint.kPntInput = kPntPlus;
                myPoint.KeepPoint();
                if (kPntPlus > 0)
                {
                    if (File.Exists(myPoint.fpointInscr))
                    {
                        File.Delete(myPoint.fpointInscr);
                        FileStream output = new FileStream(myPoint.fpointInscr, FileMode.CreateNew);
                        BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                        binaryWriter.Write(kPntPlus);
                        for (int index3 = 0; index3 <= kPntPlus; ++index3)
                        {
                            myPoint.xPntInscr[index3] = myPoint.xPnt[index3];
                            myPoint.yPntInscr[index3] = myPoint.yPnt[index3];
                            myPoint.iHorVerPnt[index3] = 0;
                            binaryWriter.Write(myPoint.xPnt[index3]);
                            binaryWriter.Write(myPoint.yPnt[index3]);
                            binaryWriter.Write(myPoint.iHorVerPnt[index3]);
                        }
                        binaryWriter.Close();
                        output.Close();
                    }
                    myPoint.LoadKeepInscr(1);
                }
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

        private void PointGraphicly_Click(object sender, EventArgs e)
        {
            nProcess = 610;
            nControl = 0;
            kDat = 0;
            kRcPnt = 0;
            sNew = "";
            xNew = 0.0;
            yNew = 0.0;
            zNew = 0.0;
            iCode1 = 0;
            iCode2 = 0;
            groupBox7.Visible = false;
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
            int nName = 0;
            DllClass1.NewPointName(kPntPlus, myPoint.namePnt, out nName, out sNew);
            if (nName < 0)
                return;
            textBox7.Text = sNew;
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "0";
            textBox11.Text = "0";
            panel7.Invalidate();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            DllClass1.KeepPntHeig(myPoint.filePoint, myPoint.fileHeight, ref myPoint.xmin, ref myPoint.ymin, ref myPoint.xmax, ref myPoint.ymax, ref myPoint.zmin, ref myPoint.zmax, myPoint.kPntPlus, myPoint.kPntInput, myPoint.namePnt, myPoint.xPnt, myPoint.yPnt, myPoint.zPnt, myPoint.nCode1, myPoint.nCode2, ref myPoint.kHeight, myPoint.nameHeig, myPoint.xHeig, myPoint.yHeig, myPoint.zHeig);
            kHeight = myPoint.kHeight;
            if (iCond < 0)
            {
                iGraphic = 1;
            }
            else
            {
                kPntPlus = myPoint.kPntPlus;
                myPoint.FilePath();
                panel1.Text = "******Пожалуйста.......ПОДОЖДИТЕ******СОРТИРОВКА ТОЧЕК*******";
                myPoint.HeightSorting(fCurHeig, panel);
                kHeight = myPoint.kHeight;
                kPntSource = kPntPlus;
                for (int index = 0; index <= kPntSource; ++index)
                {
                    myPoint.nameSour[index] = myPoint.namePnt[index];
                    myPoint.xSour[index] = myPoint.xPnt[index];
                    myPoint.ySour[index] = myPoint.yPnt[index];
                    myPoint.zSour[index] = myPoint.zPnt[index];
                    myPoint.nSour1[index] = myPoint.nCode1[index];
                    myPoint.nSour2[index] = myPoint.nCode2[index];
                }
                myPoint.kPntSource = kPntSource;
                myPoint.KeepPntSour();
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {
            int num = (int)new ListPntSign().ShowDialog((IWin32Window)this);
            int index = 0;
            if (File.Exists(myPoint.fileAdd))
            {
                FileStream input = new FileStream(myPoint.fileAdd, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    index = binaryReader.ReadInt32();
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
            if (index == 0)
                return;
            textBox11.Text = string.Format("{0}", (object)myPoint.numbUser[index]);
        }

        private void DesitgnGraphicly_Click(object sender, EventArgs e)
        {
            nProcess = 580;
            nControl = 0;
            kDat = 0;
            kRcPnt = 0;
            sNew = "";
            xNew = 0.0;
            yNew = 0.0;
            zNew = 0.0;
            iCode1 = 0;
            iCode2 = 0;
            groupBox3.Visible = false;
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
            int nName1 = 0;
            int nName2 = 0;
            string sName = "";
            DllClass1.NewPointName(kPntPlus, myPoint.namePnt, out nName1, out sNew);
            if (nName1 < 0)
                return;
            textBox7.Text = sNew;
            if (kPntProj > -1)
            {
                DllClass1.NewPointName(kPntProj, myPoint.nameProj, out nName2, out sName);
                if (nName2 < 0)
                    return;
                if (nName2 > nName1)
                    textBox7.Text = sName;
            }
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "0";
            textBox11.Text = "0";
            panel7.Invalidate();
        }

        private void DesignPointDelete_Click(object sender, EventArgs e)
        {
            if (kPntProj < 0)
            {
                int num = (int)MessageBox.Show("Нет проектных точек", "Удаление точек проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 600;
                nControl = 0;
                kDat = 0;
                kRcPnt = 0;
                groupBox4.Visible = false;
            }
        }

        private void DesignTyping_Click(object sender, EventArgs e)
        {
            nProcess = 590;
            nControl = 0;
            kDat = 0;
            kRcPnt = 0;
            sNew = "";
            xNew = 0.0;
            yNew = 0.0;
            zNew = 0.0;
            iCode1 = 0;
            iCode2 = 0;
            groupBox3.Visible = false;
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
            int nName1 = 0;
            int nName2 = 0;
            string sName = "";
            DllClass1.NewPointName(kPntPlus, myPoint.namePnt, out nName1, out sNew);
            if (nName1 < 0)
                return;
            textBox7.Text = sNew;
            if (kPntProj > -1)
            {
                DllClass1.NewPointName(kPntProj, myPoint.nameProj, out nName2, out sName);
                if (nName2 < 0)
                    return;
                if (nName2 > nName1)
                    textBox7.Text = sName;
            }
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "0";
            textBox11.Text = "0";
            panel7.Invalidate();
        }

        private void AllPointsDelete_Click(object sender, EventArgs e)
        {
            if (kPntProj < 0)
            {
                int num = (int)MessageBox.Show("Все точки проекта были удалены", "Построение проектных линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                kRcPnt = 0;
                nProcess = 0;
                nControl = 0;
                panel7.Invalidate();
            }
            else
            {
                if (File.Exists(myPoint.fpointProj) && MessageBox.Show("Вы действительно хотите Удалить все точки Проекта ?", "Построение проектных линий", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                if (File.Exists(myPoint.fpointProj))
                    File.Delete(myPoint.fpointProj);
                kPntProj = -1;
                kProjInput = -1;
                kRcPnt = 0;
                nProcess = 0;
                nControl = 0;
                panel7.Invalidate();
            }
        }

    }
}
