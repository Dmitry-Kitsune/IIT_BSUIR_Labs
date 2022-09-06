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
    public partial class PolyTopo : Form
    {
        private string sTmp = "";
        private char[] sFormula = new char[50];
        private int iWidth;
        private int iHeight;
        private int kPntInput;
        private int kPntPlus;
        private int xBegWin;
        private int yBegWin;
        private int xEndWin;
        private int yEndWin;
        private int nControl;
        private int nProcess;
        private int kNode;
        private int kNew;
        private int iParam;
        private int kOut;
        private int kInter;
        private int x1Box;
        private int y1Box;
        private int x2Box;
        private int y2Box;
        private int iPointDraw = 1;
        private int iLineDraw;
        private int iLineTopo;
        private int iPolyDraw;
        private int iNodeDraw;
        private int kDangle;
        private int iDangleDraw;
        private int kRcPnt;
        private int kSel = -1;
        private int indLine;
        private int indPoly;
        private int kSymbPnt;
        private int kLineTopo;
        private int kPolySource;
        private int hSymbPoly = 30;
        private int kSymbPoly;
        private int kSymbLine;
        private int hSymbLine = 18;
        private int kLineInput;
        private int iHeightShow;
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
        private double tolerance = 0.003;
        private double xaCur;
        private double yaCur;
        private double xbCur;
        private double ybCur;
        private double xCur;
        private double yCur;
        private double sArea;
        private double arExter;
        private double toler;
        private string[] nameArc = new string[10];
        private double[] xArc = new double[10];
        private double[] yArc = new double[10];
        private double[] zArc = new double[10];
        private int iCond;
        private int iGraphic;
        private Rectangle[] RcPnt = new Rectangle[200];
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

        private MyGeodesy myPol = new MyGeodesy();

        public string fCurPnt { get; private set; }
        public string fCurHeig { get; private set; }
        public string fCurLine { get; private set; }

        public PolyTopo()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.pixWid = this.panel7.Bounds.Width;
            this.pixHei = this.panel7.Bounds.Height;
            if (this.pixWid <= this.pixHei)
                this.iWidth = this.iHeight = this.pixWid;
            if (this.pixWid > this.pixHei)
                this.iWidth = this.iHeight = this.pixHei;
            this.panel1.BorderStyle = StatusBarPanelBorderStyle.Raised;
            this.panel2.BorderStyle = StatusBarPanelBorderStyle.Raised;
            this.panel3.BorderStyle = StatusBarPanelBorderStyle.Raised;
            this.panel4.BorderStyle = StatusBarPanelBorderStyle.Raised;
            this.panel5.BorderStyle = StatusBarPanelBorderStyle.Raised;
            this.panel6.BorderStyle = StatusBarPanelBorderStyle.Raised;
            this.panel1.AutoSize = StatusBarPanelAutoSize.Spring;
            this.panel2.AutoSize = StatusBarPanelAutoSize.Contents;
            this.panel3.AutoSize = StatusBarPanelAutoSize.Contents;
            this.panel4.AutoSize = StatusBarPanelAutoSize.Contents;
            this.panel5.AutoSize = StatusBarPanelAutoSize.Contents;
            this.panel6.AutoSize = StatusBarPanelAutoSize.Contents;
            this.panel1.Text = "Готов...";
            this.panel3.Text = "**";
            this.panel5.Text = "**";
            this.panel6.Text = DateTime.Now.ToShortDateString();
            this.statusBar1.Enabled = true;
            this.statusBar1.Font = new Font(this.Font, FontStyle.Bold);
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Panels.Add(this.panel1);
            this.statusBar1.Panels.Add(this.panel2);
            this.statusBar1.Panels.Add(this.panel3);
            this.statusBar1.Panels.Add(this.panel4);
            this.statusBar1.Panels.Add(this.panel5);
            this.statusBar1.Panels.Add(this.panel6);
            this.Controls.Add((Control)this.statusBar1);
            this.button1.MouseHover += new EventHandler(this.button1_MouseHover);
            this.button1.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button3.MouseHover += new EventHandler(this.button3_MouseHover);
            this.button3.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button4.MouseHover += new EventHandler(this.button4_MouseHover);
            this.button4.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button5.MouseHover += new EventHandler(this.button5_MouseHover);
            this.button5.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button6.MouseHover += new EventHandler(this.button6_MouseHover);
            this.button6.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button7.MouseHover += new EventHandler(this.button7_MouseHover);
            this.button7.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button8.MouseHover += new EventHandler(this.button8_MouseHover);
            this.button8.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button14.MouseHover += new EventHandler(this.button14_MouseHover);
            this.button14.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button15.MouseHover += new EventHandler(this.button15_MouseHover);
            this.button15.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button18.MouseHover += new EventHandler(this.button18_MouseHover);
            this.button18.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button22.MouseHover += new EventHandler(this.button22_MouseHover);
            this.button22.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button23.MouseHover += new EventHandler(this.button23_MouseHover);
            this.button23.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.myPol.FilePath();
            this.FormLoad();
        }

        private void button1_MouseHover(object sender, EventArgs e) => this.label11.Text = "Close of Dialog";

        private void button1_MouseLeave(object sender, EventArgs e) => this.label11.Text = "";

        private void button2_MouseHover(object sender, EventArgs e) => this.label11.Text = "Click Button for automatic Linear and Polygonal Topologies construction";

        private void button3_MouseHover(object sender, EventArgs e) => this.label11.Text = "Нажмите кнопку. For update of Linear Topology select and remove line";

        private void button4_MouseHover(object sender, EventArgs e) => this.label11.Text = "Click button for Rebuilding of Polygonal Topology after corection of Linear Topology";

        private void button5_MouseHover(object sender, EventArgs e) => this.label11.Text = "Нажмите кнопку. Зажмите левую кнопкой мыши и переместите мышь. После выбора области отпустите кнопку. Нажмите правую кнопку мыши для исходного положения";

        private void button6_MouseHover(object sender, EventArgs e) => this.label11.Text = "После нажатия на эту кнопку и отпустив левую кнопку мыши возле выбранной точки. Нажмите правую кнопку для исходного положения";

        private void button7_MouseHover(object sender, EventArgs e) => this.label11.Text = "После нажатия на эту кнопку и отпустив левую кнопку мыши возле выбранной точки. Нажмите правую кнопку для исходного положения";

        private void button8_MouseHover(object sender, EventArgs e) => this.label11.Text = "После нажатия на эту кнопку левую кнопкой мыши ведите вдоль экрана. Нажмите правую кнопку для возврата исходное положение";

        private void button14_MouseHover(object sender, EventArgs e) => this.label11.Text = "Нажмите кнопку. By left button of mouse choose parcel";

        private void button15_MouseHover(object sender, EventArgs e) => this.label11.Text = "Click button if process of dividing and Legal Area is known";

        private void button18_MouseHover(object sender, EventArgs e) => this.label11.Text = "Нажмите кнопку. Dialog for input Legal areas is opened";

        private void button22_MouseHover(object sender, EventArgs e) => this.label11.Text = "Нажмите кнопку. Dialog is opened. Set up Formula for calculation tolerance of Calculated and Legal Areas";

        private void button23_MouseHover(object sender, EventArgs e) => this.label11.Text = "Click button for node and linear topologies building";


        private void FormLoad()
        {
            xmin = 9999999.9;
            this.ymin = 9999999.9;
            this.xmax = -9999999.9;
            this.ymax = -9999999.9;
            DllClass1.SetColour(this.myPol.brColor, this.myPol.pnColor);
            DllClass1.PointSymbLoad(this.myPol.fsymbPnt, out this.kSymbPnt, this.myPol.numRec, this.myPol.numbUser, this.myPol.heiSymb);
            this.myPol.kSymbPnt = this.kSymbPnt;
            DllClass1.LineSymbolLoad(this.myPol.fsymbLine, out this.kSymbLine, out this.hSymbLine, this.myPol.sSymbLine, this.myPol.x1Line, this.myPol.y1Line, this.myPol.x2Line, this.myPol.y2Line, this.myPol.xDescr, this.myPol.yDescr, this.myPol.x1Dens, this.myPol.y1Dens, this.myPol.x1Sign, this.myPol.y1Sign, this.myPol.x2Sign, this.myPol.y2Sign, this.myPol.n1Sign, this.myPol.n2Sign, this.myPol.iStyle1, this.myPol.iStyle2, this.myPol.iWidth1, this.myPol.iWidth2, this.myPol.nColLine, this.myPol.nItem, this.myPol.itemLoc, this.myPol.nBaseSymb, this.myPol.sInscr, this.myPol.hInscr, this.myPol.iColInscr, this.myPol.iDensity);
            this.myPol.PolySymbolLoad(this.myPol.fsymbPoly, out this.kSymbPoly, out this.hSymbPoly);
            this.iPointDraw = 1;
            this.kPntPlus = 0;
            this.myPol.PointLoad(fCurPnt, fCurHeig);
            this.kPntPlus = this.myPol.kPntPlus;
            this.kPntInput = this.myPol.kPntInput;
            if (this.kPntPlus > 0)
            {
                if (!File.Exists(this.myPol.fpointInscr))
                {
                    FileStream output = new FileStream(this.myPol.fpointInscr, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    binaryWriter.Write(this.kPntPlus);
                    for (int index = 0; index <= this.kPntPlus; ++index)
                    {
                        this.myPol.xPntInscr[index] = this.myPol.xPnt[index];
                        this.myPol.yPntInscr[index] = this.myPol.yPnt[index];
                        this.myPol.iHorVerPnt[index] = 0;
                        binaryWriter.Write(this.myPol.xPnt[index]);
                        binaryWriter.Write(this.myPol.yPnt[index]);
                        binaryWriter.Write(this.myPol.iHorVerPnt[index]);
                    }
                    binaryWriter.Close();
                    output.Close();
                }
                this.myPol.LoadKeepInscr(1);
            }
            this.iParam = 1;
            this.iLineDraw = 1;
            this.kLineInput = 0;
            this.myPol.LineLoad(fCurLine);
            this.kLineInput = this.myPol.kLineInput;
            this.xmin = this.myPol.xmin;
            this.ymin = this.myPol.ymin;
            this.xmax = this.myPol.xmax;
            this.ymax = this.myPol.ymax;
            this.myPol.kPoly = 0;
            this.kInter = 0;
            this.myPol.PolygonLoad(ref this.myPol.kPolyInside);
            this.myPol.LineTopoLoad();
            this.kLineTopo = this.myPol.kLineTopo;
            this.myPol.LoadNode();
            this.kNode = this.myPol.kNodeTopo;
            int nName = 0;
            DllClass1.NewPointName(this.kPntPlus, this.myPol.namePnt, out nName, out this.sTmp);
            DllClass1.NameNode(nName, this.kPntPlus, this.myPol.namePnt, this.myPol.xPnt, this.myPol.yPnt, ref this.kNode, ref this.myPol.nameNode, ref this.myPol.xNode, ref this.myPol.yNode);
            this.kDangle = 0;
            this.myPol.DangleLoad();
            this.kDangle = this.myPol.kDangle;
            if (this.kDangle == 0)
                this.button13.Visible = false;
            if (this.myPol.kPoly > 0)
            {
                this.iPointDraw = 1;
                this.iLineDraw = 1;
                this.iLineTopo = 1;
                this.iPolyDraw = 1;
                if (this.kDangle > 0)
                    this.iDangleDraw = 1;
            }
            if (this.myPol.kPoly == 0 && this.kLineTopo > 0)
            {
                this.iPointDraw = 1;
                this.iLineTopo = 1;
                this.iLineDraw = 0;
            }
            this.xminCur = this.xmin;
            this.yminCur = this.ymin;
            this.xmaxCur = this.xmax;
            this.ymaxCur = this.ymax;
            DllClass1.CoorWin(this.xmin, this.ymin, this.xmax, this.ymax, this.iWidth, this.iHeight, out this.scaleToWin, out this.scaleToGeo, out this.xBegX, out this.yBegY, out this.xEndX, out this.yEndY, out this.xBegWin, out this.yBegWin, out this.xEndWin, out this.yEndWin, out this.iCond);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (this.iGraphic > 0)
                return;
            if (this.nControl == 10)
                graphics.DrawRectangle(new Pen(Color.Green, 2f), this.RcDraw);
            if (this.kPntPlus > 0 && this.iPointDraw > 0)
                DllClass1.PointsDraw(e, this.myPol.fsymbPnt, this.iHeightShow, this.kPntPlus, this.myPol.namePnt, this.myPol.xPnt, this.myPol.yPnt, this.myPol.zPnt, this.myPol.xPntInscr, this.myPol.yPntInscr, this.myPol.iHorVerPnt, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myPol.nCode1, this.myPol.nCode2, this.kSymbPnt, this.myPol.numRec, this.myPol.numbUser, this.myPol.ixSqu, this.myPol.iySqu, this.myPol.nColor, this.myPol.brColor, this.myPol.pnColor);
            if (this.kLineInput > 0 && this.iLineDraw > 0)
            {
                this.iParam = 1;
                DllClass1.LineDraw(e, this.kLineInput, this.myPol.k1, this.myPol.k2, this.myPol.xLin, this.myPol.yLin, this.myPol.rRadLine, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myPol.pnColor, this.iParam);
            }
            if (this.kLineTopo > 0 && this.iLineTopo > 0)
            {
                this.iParam = 4;
                DllClass1.LineDraw(e, this.kLineTopo, this.myPol.kl1, this.myPol.kl2, this.myPol.zLin, this.myPol.zPik, this.myPol.radLine, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myPol.pnColor, this.iParam);
            }
            if (this.myPol.kPoly > 0 && this.iPolyDraw > 0)
                this.LabelDraw(e, this.myPol.kPoly, this.myPol.namePoly, this.myPol.xLab, this.myPol.yLab, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            if (this.kNode > 0 && this.iNodeDraw > 0)
                DllClass1.DrawNode(e, this.kNode, this.myPol.nameNode, this.myPol.xNode, this.myPol.yNode, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            if (this.kDangle > 0 && this.iDangleDraw > 0)
                this.DangleDraw(e);
            if (this.nProcess == 520 || this.nProcess == 540)
            {
                if (this.kRcPnt > 0)
                {
                    for (int index = 1; index <= this.kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.DarkBlue), this.RcPnt[index]);
                }
                this.DrawSelLine(e);
            }
            Cursor.Current = Cursors.Default;
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            this.x1Box = e.X;
            this.y1Box = e.Y;
            this.RcDraw.X = e.X;
            this.RcDraw.Y = e.Y;
            this.RcBox.X = e.X;
            this.RcBox.Y = e.Y;
            DllClass1.WINtoXY(this.x1Box, this.y1Box, this.scaleToGeo, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out this.xCur, out this.yCur);
            if (this.nControl == 10)
            {
                DllClass1.WINtoXY(e.X, e.Y, this.scaleToGeo, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out this.xCurMin, out this.yCurMin);
                if (e.Button == MouseButtons.Left)
                {
                    this.isDrag = true;
                    this.startPoint = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                }
            }
            if (this.nControl == 20)
            {
                double x1 = this.xCur - 0.4 * (this.xEndX - this.xBegX);
                double y1 = this.yCur - 0.4 * (this.yEndY - this.yBegY);
                double x2 = this.xCur + 0.4 * (this.xEndX - this.xBegX);
                double y2 = this.yCur + 0.4 * (this.yEndY - this.yBegY);
                this.xminCur = x1;
                this.yminCur = y1;
                this.xmaxCur = x2;
                this.ymaxCur = y2;
                DllClass1.CoorWin(x1, y1, x2, y2, this.iWidth, this.iHeight, out this.scaleToWin, out this.scaleToGeo, out this.xBegX, out this.yBegY, out this.xEndX, out this.yEndY, out this.xBegWin, out this.yBegWin, out this.xEndWin, out this.yEndWin, out this.iCond);
                if (this.iCond < 0)
                    this.iGraphic = 1;
                this.panel7.Invalidate();
            }
            if (this.nControl == 30)
            {
                double num1 = this.xCur - 0.5 * (this.xEndX - this.xBegX);
                double num2 = this.yCur - 0.5 * (this.yEndY - this.yBegY);
                double num3 = this.xCur + 0.5 * (this.xEndX - this.xBegX);
                double num4 = this.yCur + 0.5 * (this.yEndY - this.yBegY);
                double x1 = num1 - 0.2 * (this.xEndX - this.xBegX);
                double y1 = num2 - 0.2 * (this.yEndY - this.yBegY);
                double x2 = num3 + 0.2 * (this.xEndX - this.xBegX);
                double y2 = num4 + 0.2 * (this.yEndY - this.yBegY);
                this.xminCur = x1;
                this.yminCur = y1;
                this.xmaxCur = x2;
                this.ymaxCur = y2;
                DllClass1.CoorWin(x1, y1, x2, y2, this.iWidth, this.iHeight, out this.scaleToWin, out this.scaleToGeo, out this.xBegX, out this.yBegY, out this.xEndX, out this.yEndY, out this.xBegWin, out this.yBegWin, out this.xEndWin, out this.yEndWin, out this.iCond);
                if (this.iCond < 0)
                    this.iGraphic = 1;
                this.panel7.Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                this.xminCur = this.xmin;
                this.yminCur = this.ymin;
                this.xmaxCur = this.xmax;
                this.ymaxCur = this.ymax;
                this.dx = this.xmax - this.xmin;
                this.dy = this.ymax - this.ymin;
                if (this.dx < 0.05 || this.dy < 0.05)
                    return;
                DllClass1.CoorWin(this.xminCur, this.yminCur, this.xmaxCur, this.ymaxCur, this.iWidth, this.iHeight, out this.scaleToWin, out this.scaleToGeo, out this.xBegX, out this.yBegY, out this.xEndX, out this.yEndY, out this.xBegWin, out this.yBegWin, out this.xEndWin, out this.yEndWin, out this.iCond);
                if (this.iCond < 0)
                    this.iGraphic = 1;
                this.panel7.Invalidate();
            }
            if (e.Button != MouseButtons.Left || this.nProcess != 520 && this.nProcess != 540)
                return;
            DllClass1.WINtoXY(e.X, e.Y, this.scaleToGeo, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out this.xCur, out this.yCur);
            this.kSel = 0;
            this.xArc[0] = this.xCur;
            this.yArc[0] = this.yCur;
            ++this.kRcPnt;
            this.RcPnt[this.kRcPnt].X = e.X;
            this.RcPnt[this.kRcPnt].Y = e.Y;
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            DllClass1.WINtoXY(e.X, e.Y, this.scaleToGeo, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out this.xCur, out this.yCur);
            if (!File.Exists(this.myPol.filePoint))
            {
                this.panel2.Text = string.Format("{0}", (object)e.X);
                this.panel4.Text = string.Format("{0}", (object)e.Y);
            }
            if (File.Exists(this.myPol.filePoint))
            {
                this.panel2.Text = string.Format("{0:F3}", (object)this.xCur);
                this.panel4.Text = string.Format("{0:F3}", (object)this.yCur);
            }
            if (this.nControl == 10 && e.Button == MouseButtons.Left && this.isDrag)
            {
                ControlPaint.DrawReversibleFrame(this.theRectangle, this.BackColor, FrameStyle.Dashed);
                this.endPoint = this.PointToScreen(new Point(e.X, e.Y));
                if (e.X > 15 && e.X < this.pixWid + 10 && e.Y > 15 && e.Y < this.pixHei + 10)
                    this.theRectangle = new Rectangle(this.startPoint.X, this.startPoint.Y, this.endPoint.X - this.startPoint.X, this.endPoint.Y - this.startPoint.Y);
                ControlPaint.DrawReversibleFrame(this.theRectangle, this.BackColor, FrameStyle.Dashed);
            }
            if (this.nControl != 40 || e.Button != MouseButtons.Left)
                return;
            double xCur1 = 0.0;
            double yCur1 = 0.0;
            double xCur2 = 0.0;
            double yCur2 = 0.0;
            this.x2Box = e.X;
            this.y2Box = e.Y;
            DllClass1.WINtoXY(this.x1Box, this.y1Box, this.scaleToGeo, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xCur1, out yCur1);
            DllClass1.WINtoXY(this.x2Box, this.y2Box, this.scaleToGeo, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xCur2, out yCur2);
            double num1 = xCur2 - xCur1;
            double num2 = yCur2 - yCur1;
            this.xaCur = this.xminCur - num1;
            this.yaCur = this.yminCur - num2;
            this.xbCur = this.xmaxCur - num1;
            this.ybCur = this.ymaxCur - num2;
            DllClass1.CoorWin(this.xaCur, this.yaCur, this.xbCur, this.ybCur, this.iWidth, this.iHeight, out this.scaleToWin, out this.scaleToGeo, out this.xBegX, out this.yBegY, out this.xEndX, out this.yEndY, out this.xBegWin, out this.yBegWin, out this.xEndWin, out this.yEndWin, out this.iCond);
            if (this.iCond < 0)
                this.iGraphic = 1;
            this.panel7.Invalidate();
        }

        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.nControl == 10)
            {
                ControlPaint.DrawReversibleFrame(this.theRectangle, this.BackColor, FrameStyle.Dashed);
                if (this.xCurMin > this.xCur)
                {
                    this.xCurMax = this.xCurMin;
                    this.xCurMin = this.xCur;
                }
                else
                    this.xCurMax = this.xCur;
                if (this.yCurMin > this.yCur)
                {
                    this.yCurMax = this.yCurMin;
                    this.yCurMin = this.yCur;
                }
                else
                    this.yCurMax = this.yCur;
                if (this.isDrag)
                {
                    this.dx = this.xCurMax - this.xCurMin;
                    this.dy = this.yCurMax - this.yCurMin;
                    if (this.dx < 0.05 || this.dy < 0.05)
                        return;
                    this.xminCur = this.xCurMin;
                    this.yminCur = this.yCurMin;
                    this.xmaxCur = this.xCurMax;
                    this.ymaxCur = this.yCurMax;
                    DllClass1.CoorWin(this.xCurMin, this.yCurMin, this.xCurMax, this.yCurMax, this.iWidth, this.iHeight, out this.scaleToWin, out this.scaleToGeo, out this.xBegX, out this.yBegY, out this.xEndX, out this.yEndY, out this.xBegWin, out this.yBegWin, out this.xEndWin, out this.yEndWin, out this.iCond);
                    if (this.iCond < 0)
                    {
                        this.iGraphic = 1;
                        return;
                    }
                }
                this.theRectangle = new Rectangle(0, 0, 0, 0);
                this.isDrag = false;
                this.panel7.Invalidate();
            }
            if (this.nControl == 40)
            {
                this.xminCur = this.xaCur;
                this.yminCur = this.yaCur;
                this.xmaxCur = this.xbCur;
                this.ymaxCur = this.ybCur;
            }
            if (this.nProcess == 520 || this.nProcess == 540)
            {
                this.RcPnt[this.kRcPnt].Width = 4;
                this.RcPnt[this.kRcPnt].Height = 4;
                this.panel7.Invalidate(this.RcPnt[this.kRcPnt]);
            }
            if (this.nProcess == 520 && this.kSel == 0)
            {
                double az = 0.0;
                double num1;
                double yrd = num1 = 0.0;
                double xrd = num1;
                double rd = num1;
                DllClass1.FindLine(this.xArc[0], this.yArc[0], this.kLineTopo, ref this.myPol.kl1, ref this.myPol.kl2, ref this.myPol.radLine, ref this.myPol.xOut, ref this.myPol.yOut, ref this.myPol.zLin, ref this.myPol.zPik, out rd, out xrd, out yrd, out this.kSel, ref this.myPol.xWork, ref this.myPol.yWork, ref this.myPol.xDop, ref this.myPol.yDop, out this.xCur, out this.yCur, out az, out this.indLine);
                this.panel7.Invalidate();
                if (MessageBox.Show("Do you really want to Delete this line ?", "Linear Topology Correction", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    this.kSel = -1;
                    this.kRcPnt = 0;
                    this.nProcess = 0;
                    this.panel7.Invalidate();
                    return;
                }
                DllClass1.LineTopoDel(this.indLine, this.kLineTopo, ref this.myPol.radLine, ref this.myPol.kl1, ref this.myPol.kl2, ref this.myPol.zLin, ref this.myPol.zPik, out this.kNew, ref this.myPol.rWork, ref this.myPol.nWork1, ref this.myPol.nWork2, ref this.myPol.xAdd, ref this.myPol.yAdd, ref this.myPol.nWork);
                if (this.kNew == 0)
                    return;
                this.kLineTopo = this.kNew;
                for (int index1 = 1; index1 <= this.kLineTopo; ++index1)
                {
                    this.myPol.radLine[index1] = this.myPol.rWork[index1];
                    this.myPol.kl1[index1] = this.myPol.nWork1[index1];
                    this.myPol.kl2[index1] = this.myPol.nWork2[index1];
                    int num2 = this.myPol.kl1[index1];
                    int num3 = this.myPol.kl2[index1];
                    for (int index2 = num2; index2 <= num3; ++index2)
                    {
                        this.myPol.zLin[index2] = this.myPol.xAdd[index2];
                        this.myPol.zPik[index2] = this.myPol.yAdd[index2];
                    }
                }
                this.myPol.kLineTopo = this.kLineTopo;
                this.myPol.KeepLineTopo();
                this.kDangle = 0;
                int kLine2 = 0;
                DllClass1.DangleDelete(this.kLineTopo, ref this.myPol.radLine, ref this.myPol.kl1, ref this.myPol.kl2, ref this.myPol.zLin, ref this.myPol.zPik, out kLine2, ref this.myPol.pWork, ref this.myPol.kt1, ref this.myPol.kt2, ref this.myPol.xWork1, ref this.myPol.yWork1, this.tolerance, out this.kDangle, ref this.myPol.nWork, ref this.myPol.ktt);
                if (this.kDangle == 0)
                {
                    if (File.Exists(this.myPol.fileDangle))
                        File.Delete(this.myPol.fileDangle);
                    this.button13.Visible = false;
                }
                if (this.kDangle > 0)
                {
                    this.button13.Visible = true;
                    if (File.Exists(this.myPol.fileDangle))
                        File.Delete(this.myPol.fileDangle);
                    FileStream output = new FileStream(this.myPol.fileDangle, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    binaryWriter.Write(this.kDangle);
                    for (int index3 = 1; index3 <= this.kLineTopo; ++index3)
                    {
                        int num4 = 0;
                        for (int index4 = 1; index4 <= this.kDangle; ++index4)
                        {
                            if (this.myPol.nWork[index4] == index3)
                            {
                                ++num4;
                                break;
                            }
                        }
                        if (num4 > 0)
                        {
                            binaryWriter.Write(this.myPol.radLine[index3]);
                            binaryWriter.Write(this.myPol.kl1[index3]);
                            binaryWriter.Write(this.myPol.kl2[index3]);
                            int num5 = this.myPol.kl1[index3];
                            int num6 = this.myPol.kl2[index3];
                            for (int index5 = num5; index5 <= num6; ++index5)
                            {
                                binaryWriter.Write(this.myPol.zLin[index5]);
                                binaryWriter.Write(this.myPol.zPik[index5]);
                            }
                        }
                    }
                    binaryWriter.Close();
                    output.Close();
                }
                if (File.Exists(this.myPol.filePoly))
                    File.Delete(this.myPol.filePoly);
                this.myPol.kPoly = 0;
                if (File.Exists(this.myPol.fileExter))
                    File.Delete(this.myPol.fileExter);
                this.kOut = 0;
                this.groupBox5.Visible = false;
                this.iLineTopo = 1;
                this.kSel = -1;
                this.kRcPnt = 0;
                this.panel7.Invalidate();
            }
            if (this.nProcess != 540 || this.kSel != 0)
                return;
            string sName = "";
            double sCalc = 0.0;
            double sLeg = 0.0;
            this.indPoly = 0;
            DllClass1.ParcelSelect(this.xArc[0], this.yArc[0], this.myPol.kPoly, ref this.myPol.namePoly, ref this.myPol.xLab, ref this.myPol.yLab, ref this.myPol.areaPol, ref this.myPol.areaLeg, out sName, out sCalc, out sLeg, out this.indPoly);
            if (this.indPoly == 0)
                return;
            int num7 = this.myPol.kt1[this.indPoly];
            int num8 = this.myPol.kt2[this.indPoly];
            this.kSel = -1;
            for (int index = num7; index <= num8; ++index)
            {
                ++this.kSel;
                this.myPol.xWork[this.kSel] = this.myPol.xPol[index];
                this.myPol.yWork[this.kSel] = this.myPol.yPol[index];
            }
            double num9 = 0.0;
            double num10 = 0.0;
            for (int index = 1; index <= this.myPol.kPoly; ++index)
            {
                if (index != this.indPoly && DllClass1.in_out(this.kSel, ref this.myPol.xWork, ref this.myPol.yWork, this.myPol.xLab[index], this.myPol.yLab[index]) != 0)
                {
                    num9 += this.myPol.areaPol[index];
                    num10 += this.myPol.areaLeg[index];
                }
            }
            this.textBox1.Text = sName;
            this.sTmp = string.Format("{0:F4}", (object)sCalc);
            this.textBox2.Text = this.sTmp;
            this.sTmp = string.Format("{0:F4}", (object)sLeg);
            this.textBox3.Text = this.sTmp;
            if (num9 > 0.0)
            {
                this.label2.Visible = true;
                this.textBox8.Visible = true;
                this.textBox9.Visible = true;
                this.sTmp = string.Format("{0:F4}", (object)num9);
                this.textBox8.Text = this.sTmp;
                this.sTmp = string.Format("{0:F4}", (object)num10);
                this.textBox9.Text = this.sTmp;
            }
            if (num9 <= 0.0)
            {
                this.label2.Visible = false;
                this.textBox8.Visible = false;
                this.textBox9.Visible = false;
            }
            this.panel7.Invalidate();
        }

        private void DrawSelLine(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int yWin;
            int xWin = yWin = 0;
            if (this.kSel <= 0)
                return;
            Point[] points = new Point[this.kSel + 1];
            for (int index = 0; index <= this.kSel; ++index)
            {
                DllClass1.XYtoWIN(this.myPol.xWork[index], this.myPol.yWork[index], this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                {
                    points[index].X = xWin;
                    points[index].Y = yWin;
                }
            }
            graphics.DrawLines(new Pen(Color.LightCoral, 1f), points);
        }

        private void DrawCommon(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int num1;
            int num2 = num1 = 0;
            int yWin = num1;
            int xWin = num1;
            if (this.kOut <= 0)
                return;
            Point[] points = new Point[this.kOut];
            for (int index1 = 1; index1 <= this.kOut; ++index1)
            {
                DllClass1.XYtoWIN(this.myPol.xOut[index1], this.myPol.yOut[index1], this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                {
                    int index2 = index1 - 1;
                    points[index2].X = xWin;
                    points[index2].Y = yWin;
                }
            }
            graphics.DrawLines(new Pen(Color.Cyan, 1f), points);
        }

        private void DangleDraw(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int num1;
            int num2 = num1 = 0;
            int yWin1 = num1;
            int xWin1 = num1;
            int yWin2 = num1;
            int xWin2 = num1;
            if (!File.Exists(this.myPol.fileDangle))
                return;
            Pen pen = new Pen(Color.LightBlue, 1f);
            FileStream input = new FileStream(this.myPol.fileDangle, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader((Stream)input);
            try
            {
                this.kDangle = binaryReader.ReadInt32();
                for (int index1 = 1; index1 <= this.kDangle; ++index1)
                {
                    binaryReader.ReadDouble();
                    int num3 = binaryReader.ReadInt32();
                    int num4 = binaryReader.ReadInt32();
                    for (int index2 = num3; index2 <= num4; ++index2)
                    {
                        this.myPol.xAdd[index2] = binaryReader.ReadDouble();
                        this.myPol.yAdd[index2] = binaryReader.ReadDouble();
                    }
                    for (int index3 = num3 + 1; index3 <= num4; ++index3)
                    {
                        DllClass1.XYtoWIN(this.myPol.xAdd[index3 - 1], this.myPol.yAdd[index3 - 1], this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xWin2, out yWin2);
                        if (xWin2 != 0 || yWin2 != 0)
                        {
                            DllClass1.XYtoWIN(this.myPol.xAdd[index3], this.myPol.yAdd[index3], this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xWin1, out yWin1);
                            if (xWin1 != 0 || yWin1 != 0)
                            {
                                Point pt1 = new Point(xWin2, yWin2);
                                Point pt2 = new Point(xWin1, yWin1);
                                graphics.DrawLine(pen, pt1, pt2);
                            }
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
                binaryReader.Close();
                input.Close();
            }
        }

        private void LabelDraw(
          PaintEventArgs e,
          int kPol,
          string[] namePol,
          double[] xLab,
          double[] yLab,
          double scaleWin,
          double xBeg,
          double yBeg,
          int xWin,
          int yWin)
        {
            Graphics graphics = e.Graphics;
            int num = 4;
            int xWin1 = 0;
            int yWin1 = 0;
            for (int index = 1; index <= kPol; ++index)
            {
                DllClass1.XYtoWIN(xLab[index], yLab[index], this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xWin1, out yWin1);
                if (xWin1 != 0 || yWin1 != 0)
                {
                    graphics.DrawString(namePol[index], new Font("Bold", (float)(num + 3)), (Brush)new SolidBrush(Color.Red), (float)(xWin1 + num / 2), (float)(yWin1 - num + 1));
                    graphics.FillRectangle((Brush)new SolidBrush(Color.Magenta), xWin1 - num / 2, yWin1 - num / 2, num, num);
                }
            }
        }

        private void SelectBox_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nProcess = 0;
            this.nControl = 10;
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nProcess = 0;
            this.nControl = 20;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nProcess = 0;
            this.nControl = 30;
        }

        private void Move_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nProcess = 0;
            this.nControl = 40;
        }

        private void PointsOnOff_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nControl = 0;
            int num1 = 0;
            if (this.iPointDraw > 0)
            {
                int num2 = num1 + 1;
                this.iPointDraw = 0;
            }
            else
                this.iPointDraw = 1;
            this.panel7.Invalidate();
        }

        private void PolygonsOnOff_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nControl = 0;
            int num1 = 0;
            if (this.iPolyDraw > 0)
            {
                int num2 = num1 + 1;
                this.iPolyDraw = 0;
            }
            else
                this.iPolyDraw = 1;
            this.panel7.Invalidate();
        }

        private void NodesOnOff_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nControl = 0;
            int num1 = 0;
            if (this.iNodeDraw > 0)
            {
                int num2 = num1 + 1;
                this.iNodeDraw = 0;
            }
            else
                this.iNodeDraw = 1;
            this.panel7.Invalidate();
        }

        private void LinTopoOnOff_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nControl = 0;
            if (this.iLineDraw > 0)
            {
                this.iLineDraw = 0;
                this.iLineTopo = 1;
                this.iNodeDraw = 1;
            }
            else
            {
                this.iLineDraw = 1;
                this.iLineTopo = 0;
                this.iNodeDraw = 0;
            }
            this.panel7.Invalidate();
        }

        private void DanglesOnOff_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.myPol.fileDangle))
            {
                int num1 = (int)MessageBox.Show("Dangles are absent", "Polygonal Topology", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.groupBox5.Visible = false;
                this.groupBox6.Visible = false;
                this.kSel = -1;
                this.kRcPnt = 0;
                this.nControl = 0;
                int num2 = 0;
                if (this.iDangleDraw > 0)
                {
                    int num3 = num2 + 1;
                    this.iDangleDraw = 0;
                    this.iNodeDraw = 0;
                }
                else
                {
                    this.iDangleDraw = 1;
                    this.iNodeDraw = 1;
                }
                this.panel7.Invalidate();
            }
        }

        private void CorrectLinear_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.nProcess = 520;
            this.kLineTopo = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nControl = 0;
            this.myPol.LineTopoLoad();
            this.kLineTopo = this.myPol.kLineTopo;
            if (this.kLineTopo == 0)
            {
                int num = (int)MessageBox.Show("Linear Topology wasn't created", "Linear Topology Building", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nProcess = 0;
            }
            else
            {
                this.iPointDraw = 0;
                this.iPolyDraw = 0;
                this.iDangleDraw = 0;
                this.iNodeDraw = 1;
                this.panel7.Invalidate();
            }
        }

        private void PolygonTopo_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.nProcess = 530;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.kLineTopo = 0;
            this.nControl = 0;
            this.myPol.LineTopoLoad();
            this.kLineTopo = this.myPol.kLineTopo;
            if (this.kLineTopo > 0)
                DllClass1.CleanLineTopo(ref this.kLineTopo, ref this.myPol.kl1, ref this.myPol.kl2, ref this.myPol.radLine, ref this.myPol.zLin, ref this.myPol.zPik, ref this.myPol.nWork, ref this.myPol.xWork, ref this.myPol.yWork, this.tolerance);
            if (this.kLineTopo == 0)
            {
                int num = (int)MessageBox.Show("Linear Topology wasn't created", "Linear Topology Building", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nProcess = 0;
            }
            else
            {
                this.myPol.LoadNode();
                this.kNode = this.myPol.kNodeTopo;
                int kNew = 0;
                this.panel1.Text = "Please, wait....Check up Double Lines";
                DllClass1.RemoveDoubleLine(this.tolerance, ref this.kLineTopo, ref this.myPol.rWork, ref this.myPol.kl1, ref this.myPol.kl2, ref this.myPol.zLin, ref this.myPol.zPik, out kNew, ref this.myPol.pWork, ref this.myPol.nWork1, ref this.myPol.nWork2, ref this.myPol.xWork, ref this.myPol.yWork, ref this.myPol.xDop, ref this.myPol.yDop, ref this.myPol.nWork, ref this.myPol.nDop1, ref this.myPol.nDop2, this.panel1);
                this.panel1.Text = "Please, wait....Polygonal Topology Building";
                DllClass1.LinesToPoly(this.tolerance, this.kLineTopo, ref this.myPol.kl1, ref this.myPol.kl2, ref this.myPol.zLin, ref this.myPol.zPik, this.kNode, ref this.myPol.xNode, ref this.myPol.yNode, out this.myPol.kPoly, ref this.myPol.namePoly, ref this.myPol.xLab, ref this.myPol.yLab, ref this.myPol.areaPol, ref this.myPol.areaLeg, ref this.myPol.nSymbPoly, ref this.myPol.kt1, ref this.myPol.kt2, ref this.myPol.xPol, ref this.myPol.yPol, out this.kInter, ref this.myPol.indPol, ref this.myPol.kn1, ref this.myPol.kn2, ref this.myPol.nWork, ref this.myPol.indInter, ref this.myPol.xWork1, ref this.myPol.yWork1, ref this.myPol.nWork1, ref this.myPol.nWork2, ref this.myPol.xWork, ref this.myPol.yWork, ref this.myPol.zWork, ref this.myPol.xWork2, ref this.myPol.yWork2, ref this.myPol.pWork, ref this.myPol.rWork, ref this.myPol.zDop, this.panel1);
                if (this.myPol.kPoly == 0)
                    return;
                this.panel1.Text = "Number polygons = " + Convert.ToString(this.myPol.kPoly);
                this.sArea = 0.0;
                for (int index = 1; index <= this.myPol.kPoly; ++index)
                {
                    this.myPol.namePoly[index] = string.Format("{0}", (object)index);
                    this.sArea += this.myPol.areaPol[index];
                }
                this.arExter = this.sArea;
                this.myPol.sArea = this.sArea;
                this.myPol.arExter = this.arExter;
                this.myPol.KeepExter();
                this.panel1.Text = "Please, wait....Polygon Label Definition";
                DllClass1.KeepPolyLabel(this.myPol.kPoly, ref this.myPol.namePoly, ref this.myPol.xLab, ref this.myPol.yLab, ref this.myPol.kt1, ref this.myPol.kt2, ref this.myPol.xPol, ref this.myPol.yPol, ref this.myPol.xWork1, ref this.myPol.yWork1, ref this.myPol.xWork2, ref this.myPol.yWork2, ref this.myPol.xWork, ref this.myPol.yWork, ref this.myPol.zWork, ref this.myPol.xDop, ref this.myPol.yDop, ref this.myPol.zDop, ref this.myPol.nDop1, ref this.myPol.nDop2, ref this.myPol.nDop3, this.panel1);
                this.myPol.KeepPoly();
                this.kPolySource = this.myPol.kPoly;
                for (int index1 = 1; index1 <= this.myPol.kPoly; ++index1)
                {
                    this.myPol.nameSource[index1] = this.myPol.namePoly[index1];
                    this.myPol.xLabSource[index1] = this.myPol.xLab[index1];
                    this.myPol.yLabSource[index1] = this.myPol.yLab[index1];
                    this.myPol.arCalcSource[index1] = this.myPol.areaPol[index1];
                    this.myPol.arLegSource[index1] = this.myPol.areaLeg[index1];
                    this.myPol.k1Source[index1] = this.myPol.kt1[index1];
                    this.myPol.k2Source[index1] = this.myPol.kt2[index1];
                    int num1 = this.myPol.kt1[index1];
                    int num2 = this.myPol.kt2[index1];
                    for (int index2 = num1; index2 <= num2; ++index2)
                    {
                        this.myPol.xSource[index2] = this.myPol.xPol[index2];
                        this.myPol.ySource[index2] = this.myPol.yPol[index2];
                    }
                }
                this.myPol.kPolySource = this.kPolySource;
                this.myPol.LoadKeepSource(2);
                this.panel1.Text = "Готов...";
                this.iPolyDraw = 1;
                this.iLineTopo = 1;
                this.iLineDraw = 0;
                this.iPointDraw = 0;
                if (File.Exists(this.myPol.flineFinal))
                    File.Delete(this.myPol.flineFinal);
                if (File.Exists(this.myPol.fpolyFinal))
                    File.Delete(this.myPol.fpolyFinal);
                if (File.Exists(this.myPol.fileItems))
                    File.Delete(this.myPol.fileItems);
                this.myPol.AllActionRemove();
                this.myPol.nAction = 0;
                this.myPol.KeepLoadAction(2);
                if (File.Exists(this.myPol.flistAction))
                    File.Delete(this.myPol.flistAction);
                FileStream output = new FileStream(this.myPol.flistAction, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                this.sTmp = "0";
                binaryWriter.Write(this.sTmp);
                binaryWriter.Close();
                output.Close();
                this.panel7.Invalidate();
            }
        }

        private void ParcelInfo_Click(object sender, EventArgs e)
        {
            this.nProcess = 540;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.myPol.PolygonLoad(ref this.myPol.kPolyInside);
            if (this.myPol.kPoly == 0)
            {
                int num = (int)MessageBox.Show("Топология полигонов не была создана", "Polygonal Topology Building", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nProcess = 0;
            }
            else
            {
                this.groupBox5.Visible = true;
                this.groupBox6.Visible = false;
                this.label1.Visible = true;
                this.label3.Visible = true;
                this.label4.Visible = true;
                this.textBox1.Visible = true;
                this.textBox1.Text = "";
                this.textBox2.Visible = true;
                this.textBox2.Text = "";
                this.textBox3.Visible = true;
                this.textBox3.ReadOnly = true;
                this.textBox3.Text = "";
                this.label2.Visible = false;
                this.textBox8.Visible = false;
                this.textBox9.Visible = false;
                this.button16.Visible = false;
                this.button17.Visible = false;
                this.iPolyDraw = 1;
                this.iLineTopo = 1;
                this.iLineDraw = 0;
                this.iPointDraw = 0;
                this.panel7.Invalidate();
            }
        }

        private void SetToler_Click(object sender, EventArgs e)
        {
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nControl = 0;
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = true;
            this.label7.Visible = false;
            this.label8.Visible = false;
            this.label9.Visible = false;
            this.label10.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox7.Visible = false;
            if (!File.Exists(this.myPol.fileToler))
                return;
            FileStream input = new FileStream(this.myPol.fileToler, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader((Stream)input);
            try
            {
                this.sTmp = binaryReader.ReadString();
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
            this.textBox4.Text = this.sTmp;
        }

        private void CheckResult_Click(object sender, EventArgs e)
        {
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nControl = 0;
            this.label7.Visible = true;
            this.label8.Visible = true;
            this.label9.Visible = true;
            this.label10.Visible = true;
            this.textBox5.Visible = true;
            this.textBox6.Visible = true;
            this.textBox7.Visible = true;
            if (!(this.textBox4.Text != ""))
                return;
            this.sTmp = this.textBox4.Text;
            for (int index = 0; index <= 49; ++index)
                this.sFormula[index] = char.MinValue;
            for (int index = 0; index < this.sTmp.Length; ++index)
                this.sFormula[index] = this.sTmp[index];
            DllClass1.TolerFormula(ref this.sFormula, 10000.0, out this.toler);
            this.textBox5.Text = string.Format("{0:F2}", (object)this.toler);
            DllClass1.TolerFormula(ref this.sFormula, 1000.0, out this.toler);
            this.textBox6.Text = string.Format("{0:F2}", (object)this.toler);
            DllClass1.TolerFormula(ref this.sFormula, 100.0, out this.toler);
            this.textBox7.Text = string.Format("{0:F2}", (object)this.toler);
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.myPol.fileToler))
                File.Delete(this.myPol.fileToler);
            FileStream output = new FileStream(this.myPol.fileToler, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(this.textBox4.Text);
            binaryWriter.Close();
            output.Close();
            this.groupBox6.Visible = false;
        }

        private void Wrong_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.myPol.fileToler))
                File.Delete(this.myPol.fileToler);
            this.groupBox6.Visible = false;
        }

        private void LegalArea_Click(object sender, EventArgs e)
        {
            this.groupBox6.Visible = false;
            this.nProcess = 550;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nControl = 0;
            this.myPol.PolygonLoad(ref this.myPol.kPolyInside);
            if (this.myPol.kPoly == 0)
            {
                int num = (int)MessageBox.Show("Топология полигонов не была создана", "Polygonal Topology Building", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nProcess = 0;
            }
            else
            {
                this.myPol.ExterLoad();
                this.sArea = this.myPol.sArea;
                this.arExter = this.myPol.arExter;
                this.label2.Visible = false;
                this.textBox8.Visible = false;
                this.textBox9.Visible = false;
                this.groupBox5.Visible = true;
                this.button16.Visible = true;
                this.button17.Visible = true;
                this.label3.Visible = true;
                this.label4.Visible = true;
                this.textBox2.Visible = true;
                this.textBox3.Visible = true;
                this.textBox3.ReadOnly = false;
                this.label1.Visible = true;
                this.textBox1.Visible = true;
                this.textBox1.Text = "Common";
                this.textBox2.Text = string.Format("{0:F4}", (object)this.sArea);
                this.textBox3.Text = string.Format("{0:F4}", (object)this.arExter);
                this.iPolyDraw = 1;
                this.iLineTopo = 1;
                this.iLineDraw = 0;
                this.iPointDraw = 0;
                this.panel7.Invalidate();
            }
        }

        private void EveryParcel_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.nProcess = 560;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nControl = 0;
            this.myPol.PolygonLoad(ref this.myPol.kPolyInside);
            if (this.myPol.kPoly == 0)
            {
                int num = (int)MessageBox.Show("Топология полигонов не была создана", "Polygonal Topology Building", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nProcess = 0;
            }
            else
            {
                int num = (int)new LegalArea().ShowDialog((IWin32Window)this);
                this.myPol.PolygonLoad(ref this.myPol.kPolyInside);
                this.panel7.Invalidate();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            int num1 = 0;
            if (File.Exists(this.myPol.fileToler))
            {
                FileStream input = new FileStream(this.myPol.fileToler, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.sTmp = binaryReader.ReadString();
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
                num1 = 1;
                for (int index = 0; index < this.sTmp.Length; ++index)
                    this.sFormula[index] = this.sTmp[index];
            }
            if (num1 == 0)
            {
                int num2 = (int)MessageBox.Show("Tolerance for Difference Calculated and Legal areas isn't defined", "Polygonal Topology Building", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            DllClass1.CheckText(this.textBox2.Text, out this.sArea, out this.iCond);
            if (this.iCond < 0)
            {
                int num3 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (this.textBox3.Text != "")
                {
                    DllClass1.CheckText(this.textBox3.Text, out this.arExter, out this.iCond);
                    if (this.iCond < 0)
                    {
                        int num4 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (this.arExter <= 0.0)
                        this.arExter = this.sArea;
                }
                this.myPol.PolygonLoad(ref this.myPol.kPolyInside);
                DllClass1.CheckText(this.textBox3.Text, out this.arExter, out this.iCond);
                if (this.iCond < 0)
                {
                    int num5 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    double num6 = (this.arExter - this.sArea) / this.sArea;
                    double num7 = 0.0;
                    int num8 = 0;
                    this.sTmp = "Difference more than tolerance-Parcels :";
                    for (int index = 1; index <= this.myPol.kPoly; ++index)
                    {
                        double num9 = num6 * this.myPol.areaPol[index];
                        this.myPol.areaLeg[index] = this.myPol.areaPol[index] + num9;
                        num7 += this.myPol.areaLeg[index];
                        if (num1 > 0)
                        {
                            double num10 = Math.Abs(this.myPol.areaLeg[index] - this.myPol.areaPol[index]);
                            DllClass1.TolerFormula(ref this.sFormula, this.myPol.areaPol[index], out this.toler);
                            if (num10 > this.toler)
                            {
                                ++num8;
                                this.sTmp = this.sTmp + this.myPol.namePoly[index] + ";";
                            }
                        }
                    }
                    if (num8 > 0)
                    {
                        int num11 = (int)MessageBox.Show(this.sTmp);
                    }
                    this.myPol.areaPol[1] = this.myPol.areaPol[1] - (num7 - this.arExter);
                    this.myPol.KeepPoly();
                    this.myPol.sArea = this.sArea;
                    this.myPol.arExter = this.arExter;
                    this.myPol.KeepExter();
                    this.groupBox5.Visible = false;
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nProcess = 0;
            this.nControl = 0;
            this.groupBox5.Visible = false;
            this.panel7.Invalidate();
        }

        private void NodeList_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.myPol.flineTopo))
            {
                int num = (int)MessageBox.Show("LINEAR TOPOLOGY wasn't created.", "Lines Forming", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.kSel = -1;
                this.kRcPnt = 0;
                this.nProcess = 0;
                this.nControl = 0;
                this.panel7.Invalidate();
            }
            else
            {
                this.nProcess = 1001;
                if (File.Exists(this.myPol.fileProcess))
                    File.Delete(this.myPol.fileProcess);
                FileStream output = new FileStream(this.myPol.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(this.nProcess);
                binaryWriter.Close();
                output.Close();
                int num = (int)new NodeList().ShowDialog((IWin32Window)this);
            }
        }

        private void LinearTopo_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.nControl = 0;
            this.myPol.LineLoad(fCurLine);
            this.kLineInput = this.myPol.kLineInput;
            this.xmin = this.myPol.xmin;
            this.ymin = this.myPol.ymin;
            this.xmax = this.myPol.xmax;
            this.ymax = this.myPol.ymax;
            this.nControl = 0;
            int kLine2;
            int num1 = kLine2 = 0;
            if (File.Exists(this.myPol.fileDangle))
                File.Delete(this.myPol.fileDangle);
            if (File.Exists(this.myPol.fileNode))
                File.Delete(this.myPol.fileNode);
            if (File.Exists(this.myPol.flineTopo))
                File.Delete(this.myPol.flineTopo);
            if (File.Exists(this.myPol.filePoly))
                File.Delete(this.myPol.filePoly);
            this.iPolyDraw = 0;
            this.myPol.kPoly = 0;
            if (File.Exists(this.myPol.fileExter))
                File.Delete(this.myPol.fileExter);
            if (File.Exists(this.myPol.flineFinal))
                File.Delete(this.myPol.flineFinal);
            if (File.Exists(this.myPol.fpolyFinal))
                File.Delete(this.myPol.fpolyFinal);
            this.myPol.AllActionRemove();
            this.myPol.nAction = 0;
            this.myPol.KeepLoadAction(2);
            DllClass1.LineTopology(this.tolerance, ref this.kPntPlus, ref this.myPol.xPnt, ref this.myPol.yPnt, ref this.kLineInput, ref this.myPol.rRadLine, ref this.myPol.k1, ref this.myPol.k2, ref this.myPol.xLin, ref this.myPol.yLin, out this.kNode, ref this.myPol.xNode, ref this.myPol.yNode, out this.kLineTopo, ref this.myPol.radLine, ref this.myPol.kl1, ref this.myPol.kl2, ref this.myPol.zLin, ref this.myPol.zPik, ref this.myPol.kt1, ref this.myPol.kt2, ref this.myPol.nWork, ref this.myPol.nWork1, ref this.myPol.nWork2, ref this.myPol.xWork, ref this.myPol.yWork, ref this.myPol.zWork, ref this.myPol.pWork, ref this.myPol.rWork, ref this.myPol.xWork1, ref this.myPol.yWork1, ref this.myPol.xAdd, ref this.myPol.yAdd, ref this.myPol.nDop1, ref this.myPol.nDop2, ref this.myPol.xDop, ref this.myPol.yDop, ref this.myPol.xPik, ref this.myPol.yPik, this.panel1);
            int nName = 0;
            DllClass1.NewPointName(this.kPntPlus, this.myPol.namePnt, out nName, out this.sTmp);
            DllClass1.NameNode(nName, this.kPntPlus, this.myPol.namePnt, this.myPol.xPnt, this.myPol.yPnt, ref this.kNode, ref this.myPol.nameNode, ref this.myPol.xNode, ref this.myPol.yNode);
            this.myPol.kNodeTopo = this.kNode;
            this.myPol.KeepNode();
            this.myPol.kLineTopo = this.kLineTopo;
            this.myPol.KeepLineTopo();
            this.kDangle = 0;
            DllClass1.DangleDelete(this.kLineInput, ref this.myPol.rWork, ref this.myPol.k1, ref this.myPol.k2, ref this.myPol.xLin, ref this.myPol.yLin, out kLine2, ref this.myPol.pWork, ref this.myPol.kt1, ref this.myPol.kt2, ref this.myPol.xWork1, ref this.myPol.yWork1, this.tolerance, out this.kDangle, ref this.myPol.nWork, ref this.myPol.ktt);
            if (this.kDangle == 0)
                this.button13.Visible = false;
            if (this.kDangle > 0)
            {
                this.button13.Visible = true;
                if (File.Exists(this.myPol.fileDangle))
                    File.Delete(this.myPol.fileDangle);
                FileStream output = new FileStream(this.myPol.fileDangle, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(this.kDangle);
                for (int index1 = 1; index1 <= this.kLineInput; ++index1)
                {
                    int num2 = 0;
                    for (int index2 = 1; index2 <= this.kDangle; ++index2)
                    {
                        if (this.myPol.nWork[index2] == index1)
                        {
                            ++num2;
                            break;
                        }
                    }
                    if (num2 > 0)
                    {
                        binaryWriter.Write(this.myPol.rWork[index1]);
                        binaryWriter.Write(this.myPol.k1[index1]);
                        binaryWriter.Write(this.myPol.k2[index1]);
                        int num3 = this.myPol.k1[index1];
                        int num4 = this.myPol.k2[index1];
                        for (int index3 = num3; index3 <= num4; ++index3)
                        {
                            binaryWriter.Write(this.myPol.xLin[index3]);
                            binaryWriter.Write(this.myPol.yLin[index3]);
                        }
                    }
                }
                binaryWriter.Close();
                output.Close();
                this.kLineInput = kLine2;
                for (int index = 1; index <= this.kLineInput; ++index)
                {
                    this.myPol.rWork[index] = this.myPol.pWork[index];
                    this.myPol.k1[index] = this.myPol.kt1[index];
                    this.myPol.k2[index] = this.myPol.kt2[index];
                }
                kLine2 = this.myPol.kt2[this.kLineInput];
                for (int index = 1; index <= kLine2; ++index)
                {
                    this.myPol.xLin[index] = this.myPol.xWork1[index];
                    this.myPol.yLin[index] = this.myPol.yWork1[index];
                }
            }
            this.kLineTopo = this.kLineInput;
            for (int index = 1; index <= this.kLineTopo; ++index)
            {
                this.myPol.radLine[index] = this.myPol.pWork[index];
                this.myPol.kl1[index] = this.myPol.kt1[index];
                this.myPol.kl2[index] = this.myPol.kt2[index];
            }
            kLine2 = this.myPol.kl2[this.kLineTopo];
            for (int index = 1; index <= kLine2; ++index)
            {
                this.myPol.zLin[index] = this.myPol.xWork1[index];
                this.myPol.zPik[index] = this.myPol.yWork1[index];
            }
            this.myPol.kLineTopo = this.kLineTopo;
            this.myPol.KeepLineTopo();
            this.kDangle = 0;
            this.myPol.DangleLoad();
            this.kDangle = this.myPol.kDangle;
            if (this.kDangle > 0)
            {
                this.kLineTopo = 0;
                this.myPol.LineTopoLoad();
                this.kLineTopo = this.myPol.kLineTopo;
                kLine2 = this.myPol.kl2[this.kLineTopo];
                for (int index4 = 1; index4 <= this.kDangle; ++index4)
                {
                    int num5 = this.myPol.ki1[index4];
                    int num6 = this.myPol.ki2[index4];
                    int num7 = 0;
                    for (int index5 = num5; index5 <= num6; ++index5)
                    {
                        ++num7;
                        ++kLine2;
                        this.myPol.zLin[kLine2] = this.myPol.xInt[index5];
                        this.myPol.zPik[kLine2] = this.myPol.yInt[index5];
                    }
                    this.myPol.nWork[index4] = num7;
                }
                for (int index = 1; index <= this.kDangle; ++index)
                {
                    ++this.kLineTopo;
                    this.myPol.radLine[this.kLineTopo] = this.myPol.zParc[index];
                    this.myPol.kl1[this.kLineTopo] = this.myPol.kl2[this.kLineTopo - 1] + 1;
                    this.myPol.kl2[this.kLineTopo] = this.myPol.kl2[this.kLineTopo - 1] + this.myPol.nWork[index];
                }
                this.myPol.kLineTopo = this.kLineTopo;
                this.myPol.KeepLineTopo();
            }
            if (File.Exists(this.myPol.flistAction))
                File.Delete(this.myPol.flistAction);
            FileStream output1 = new FileStream(this.myPol.flistAction, FileMode.CreateNew);
            BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
            this.sTmp = "0";
            binaryWriter1.Write(this.sTmp);
            binaryWriter1.Close();
            output1.Close();
            this.iPolyDraw = 1;
            this.iLineTopo = 1;
            this.iPointDraw = 1;
            this.iNodeDraw = 1;
            this.iLineDraw = 0;
            this.panel1.Text = "Готов...";
            this.panel7.Invalidate();
        }

        private void Exit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

    }
}
