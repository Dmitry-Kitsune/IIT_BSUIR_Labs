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
    public partial class FinalResult : Form
    {

        private int[] nExist = new int[20];
        private int kExist;
        private int iWidth;
        private int iHeight;
        private int nAction;
        private int nProcess;
        private int nControl;
        private int kSymbPnt;
        private int kSymbLine;
        private int kSymbPoly;
        private int kPntPlus;
        private int kPntInput;
        private int xBegWin;
        private int yBegWin;
        private int xEndWin;
        private int yEndWin;
        private int iPointShow = 1;
        private int x1Box;
        private int y1Box;
        private int x2Box;
        private int y2Box;
        private int kLineTopo;
        private int kLineFinal;
        private int kPoly;
        private int kPolyFinal;
        private int kNodeAct;
        private int kLineAct;
        private int kPolyAct;
        private int kPolyCancel;
        private int kLineCancel;
        private int kLineNew;
        private int kSel = -1;
        private int kRcPnt;
        private int indLine;
        private int kItemCoord;
        private int iBordSymbol;
        private int iPolySymbol;
        private int iCancelPoly;
        private int hSymbPoly = 30;
        private int kAddInscript;
        private int iContours = 1;
        private int iHeightShow;
        private int kPolySource;
        private int kPntFin;
        private int iNodeShow;
        private int kNode;
        private int kSelItem;
        private int iParam;
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
        private double xCur;
        private double yCur;
        private double xaCur;
        private double yaCur;
        private double xbCur;
        private double ybCur;
        private double tolerance = 0.003;
        private int iCond;
        private int iGraphic;
        private int hSymbLine = 18;
        private int kLineInput;
        private int iCodePoint;
        private int iCodeLine;
        private int iCodePoly;
        private int kItemPoly;
        private int hItemMax;
        private int wItemMax;
        private int kInstall;
        private int numSel;
        private bool isDrag;
        private int pixWid;
        private int pixHei;
        private double xCurMin;
        private double yCurMin;
        private double xCurMax;
        private double yCurMax;
        private double dx;
        private double dy;

        private MyGeodesy myFin = new MyGeodesy();

        public string fCurPnt { get; private set; }
        public string fCurHeig { get; private set; }
        public string fCurLine { get; private set; }

        public FinalResult()
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
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button33.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.label6.Visible = false;
            this.textBox6.Visible = false;
            this.label7.Visible = false;
            this.textBox7.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button34.Visible = false;
            this.textBox8.Text = "";
            this.button1.MouseHover += new EventHandler(this.button1_MouseHover);
            this.button1.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button2.MouseHover += new EventHandler(this.button2_MouseHover);
            this.button2.MouseLeave += new EventHandler(this.button1_MouseLeave);
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
            this.button10.MouseHover += new EventHandler(this.button10_MouseHover);
            this.button10.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button11.MouseHover += new EventHandler(this.button11_MouseHover);
            this.button11.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button19.MouseHover += new EventHandler(this.button19_MouseHover);
            this.button19.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button20.MouseHover += new EventHandler(this.button20_MouseHover);
            this.button20.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button29.MouseHover += new EventHandler(this.button29_MouseHover);
            this.button29.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button30.MouseHover += new EventHandler(this.button30_MouseHover);
            this.button30.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button21.MouseHover += new EventHandler(this.button21_MouseHover);
            this.button21.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button22.MouseHover += new EventHandler(this.button22_MouseHover);
            this.button22.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button23.MouseHover += new EventHandler(this.button23_MouseHover);
            this.button23.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button17.MouseHover += new EventHandler(this.button17_MouseHover);
            this.button17.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button25.MouseHover += new EventHandler(this.button25_MouseHover);
            this.button25.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button15.MouseHover += new EventHandler(this.button15_MouseHover);
            this.button15.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.myFin.FilePath();
            this.FormLoad();
        }


        private void button1_MouseHover(object sender, EventArgs e) => this.label3.Text = "Закрыть окно";

        private void button1_MouseLeave(object sender, EventArgs e) => this.label3.Text = "";

        private void button2_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. Зажмите левую кнопкой мыши и переместите мышь. После выбора области отпустите кнопку. Нажмите правую кнопку мыши для исходного положения";

        private void button3_MouseHover(object sender, EventArgs e) => this.label3.Text = "После нажатия на эту кнопку и отпустив левую кнопку мыши возле выбранной точки. Нажмите правую кнопку для исходного положения";

        private void button4_MouseHover(object sender, EventArgs e) => this.label3.Text = "После нажатия на эту кнопку и отпустив левую кнопку мыши возле выбранной точки. Нажмите правую кнопку для исходного положения";

        private void button5_MouseHover(object sender, EventArgs e) => this.label3.Text = "После нажатия на эту кнопку левую кнопкой мыши ведите вдоль экрана. Нажмите правую кнопку для возврата исходное положение";

        private void button6_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. By left button of mouse select Line. By dialog set up value of the Items и нажмите 'Подтвердить' или 'Delay'";

        private void button7_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. By left button of mouse select Line.";

        private void button10_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. By dialog set up value of the Items";

        private void button11_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. By left button of mouse select Parcel(label). By dialog set up value of the Items";

        private void button19_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. By left button of mouse select Label and by mouse(click) show new spot";

        private void button20_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. By left button of mouse select Label for changing inscription(Horizontal/Vertical)";

        private void button29_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. By left button of mouse select Point for moving of its Name(not point). Show new spot";

        private void button30_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. By left button of mouse select Point(name) for changing inscription";

        private void button21_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. Type inscription, set up properties. By left button of mouse show spot for inscription";

        private void button22_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. Select additional inscription for moving to new spot. Show new spot by mouse";

        private void button23_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. By left button of mouse select additional inscription for removing";

        private void button27_MouseHover(object sender, EventArgs e) => this.label3.Text = "Click Button for openning of Dialog for Printing final Results";

        private void button17_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. By left button of mouse select point for removing";

        private void button25_MouseHover(object sender, EventArgs e) => this.label3.Text = "Click Button and select point. Use 'Help' and select point's code. Click 'Confirm changing'";

        private void button15_MouseHover(object sender, EventArgs e) => this.label3.Text = "Нажмите кнопку. Select symbol and istall it by mouse in appropriate spots. Possible more than one";


        private void FormLoad()
        {
            for (int index = 0; index < 20; ++index)
                this.nExist[index] = 0;
            this.xmin = 9999999.9;
            this.ymin = 9999999.9;
            this.zmin = 9999999.9;
            this.xmax = -9999999.9;
            this.ymax = -9999999.9;
            this.zmax = -9999999.9;
            DllClass1.SetColour(this.myFin.brColor, this.myFin.pnColor);
            DllClass1.PointSymbLoad(this.myFin.fsymbPnt, out this.kSymbPnt, this.myFin.numRec, this.myFin.numbUser, this.myFin.heiSymb);
            this.myFin.kSymbPnt = this.kSymbPnt;
            DllClass1.LineSymbolLoad(this.myFin.fsymbLine, out this.kSymbLine, out this.hSymbLine, this.myFin.sSymbLine, this.myFin.x1Line, this.myFin.y1Line, this.myFin.x2Line, this.myFin.y2Line, this.myFin.xDescr, this.myFin.yDescr, this.myFin.x1Dens, this.myFin.y1Dens, this.myFin.x1Sign, this.myFin.y1Sign, this.myFin.x2Sign, this.myFin.y2Sign, this.myFin.n1Sign, this.myFin.n2Sign, this.myFin.iStyle1, this.myFin.iStyle2, this.myFin.iWidth1, this.myFin.iWidth2, this.myFin.nColLine, this.myFin.nItem, this.myFin.itemLoc, this.myFin.nBaseSymb, this.myFin.sInscr, this.myFin.hInscr, this.myFin.iColInscr, this.myFin.iDensity);
            this.myFin.PolySymbolLoad(this.myFin.fsymbPoly, out this.kSymbPoly, out this.hSymbPoly);
            this.myFin.LoadKeepSource(1);
            this.kPolySource = this.myFin.kPolySource;
            this.myFin.PointLoad(fCurPnt,fCurHeig);
            this.kPntPlus = this.myFin.kPntPlus;
            this.kPntInput = this.myFin.kPntInput;
            this.xmin = this.myFin.xmin;
            this.ymin = this.myFin.ymin;
            this.xmax = this.myFin.xmax;
            this.ymax = this.myFin.ymax;
            this.zmin = this.myFin.zmin;
            this.zmax = this.myFin.zmax;
            this.kPntFin = 0;
            this.myFin.PointLoadFin();
            this.kPntFin = this.myFin.kPntFin;
            if (this.kPntPlus > 0 && this.kPntFin == 0)
            {
                ++this.kExist;
                this.nExist[7] = 1;
                this.kPntFin = this.kPntPlus;
                for (int index = 0; index <= this.kPntPlus; ++index)
                {
                    this.myFin.namePntFin[index] = this.myFin.namePnt[index];
                    this.myFin.xPntFin[index] = this.myFin.xPnt[index];
                    this.myFin.yPntFin[index] = this.myFin.yPnt[index];
                    this.myFin.zPntFin[index] = this.myFin.zPnt[index];
                    this.myFin.nCode1Fin[index] = this.myFin.nCode1[index];
                    this.myFin.nCode2Fin[index] = this.myFin.nCode2[index];
                }
                this.myFin.kPntFin = this.kPntFin;
                this.myFin.KeepPointFin();
            }
            if (this.kPntFin > 0)
            {
                if (!File.Exists(this.myFin.fInscrFin))
                {
                    FileStream output = new FileStream(this.myFin.fInscrFin, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    binaryWriter.Write(this.kPntFin);
                    for (int index = 0; index <= this.kPntFin; ++index)
                    {
                        this.myFin.xPntInscr[index] = this.myFin.xPntFin[index];
                        this.myFin.yPntInscr[index] = this.myFin.yPntFin[index];
                        this.myFin.iHorVerPnt[index] = 0;
                        binaryWriter.Write(this.myFin.xPntFin[index]);
                        binaryWriter.Write(this.myFin.yPntFin[index]);
                        binaryWriter.Write(this.myFin.iHorVerPnt[index]);
                    }
                    binaryWriter.Close();
                    output.Close();
                }
                this.myFin.InscriptionFin(1);
            }
            this.myFin.LineLoad(fCurLine);
            this.kLineInput = this.myFin.kLineInput;
            this.xmin = this.myFin.xmin;
            this.ymin = this.myFin.ymin;
            this.xmax = this.myFin.xmax;
            this.ymax = this.myFin.ymax;
            if (this.kLineInput > 0)
            {
                ++this.kExist;
                this.nExist[6] = 1;
            }
            this.myFin.PolyLoadFin();
            this.kPolyFinal = this.myFin.kPolyFinal;
            this.myFin.LineLoadFin();
            this.kLineFinal = this.myFin.kLineFinal;
            this.myFin.KeepLoadAction(1);
            this.nAction = this.myFin.nAction;
            if (this.nAction > 0)
            {
                this.myFin.NodeActLoad(this.nAction);
                this.kNodeAct = this.myFin.kNodeAct;
                if (this.kNodeAct > 0)
                    this.iNodeShow = 1;
                this.myFin.CancPolyFin(this.nAction);
                this.myFin.CancPolyFinLoad();
                this.kPolyCancel = this.myFin.kPolyCancel;
                if (this.kPolyCancel < 1)
                {
                    int num = (int)MessageBox.Show("Данные отсутствуют", "Cadastral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.myFin.CancLineFin(this.nAction);
                this.myFin.CancLineFinLoad();
                this.kLineCancel = this.myFin.kLineCancel;
            }
            if (this.kNodeAct == 0)
            {
                this.myFin.LoadNode();
                this.kNode = this.myFin.kNodeTopo;
                if (this.kNode > 0)
                    this.iNodeShow = 1;
            }
            if (this.nAction > 0 && this.kPolyFinal == 0)
            {
                this.myFin.NodeActLoad(this.nAction);
                this.kNodeAct = this.myFin.kNodeAct;
                this.myFin.TopoActLoad(this.nAction);
                this.kLineAct = this.myFin.kLineAct;
                this.myFin.PolyActLoad(this.nAction);
                this.kPolyAct = this.myFin.kPolyAct;
                this.myFin.PolyCancelLoad(this.nAction);
                this.kPolyCancel = this.myFin.kPolyCancel;
                this.myFin.LineCancelLoad(this.nAction);
                this.kLineCancel = this.myFin.kLineCancel;
                this.myFin.LineNewLoad(this.nAction);
                this.kLineNew = this.myFin.kLineNew;
                ++this.kExist;
                this.nExist[1] = 1;
                if (File.Exists(this.myFin.flineFinal))
                {
                    this.myFin.LineLoadFin();
                    this.kLineFinal = this.myFin.kLineFinal;
                }
                if (!File.Exists(this.myFin.flineFinal))
                {
                    DllClass1.LineFinal(this.kLineInput, this.myFin.nLineCode, this.myFin.nLongRad, this.myFin.sWidLine, this.myFin.dstLine, this.myFin.rRadLine, this.myFin.xRadLine, this.myFin.yRadLine, this.myFin.k1, this.myFin.k2, this.myFin.xLin, this.myFin.yLin, this.kLineAct, this.myFin.radAct, this.myFin.kActLine1, this.myFin.kActLine2, this.myFin.xLineAct, this.myFin.yLineAct, out this.kLineFinal, this.myFin.nCodeFin, this.myFin.nLongFin, this.myFin.sWidFin, this.myFin.distFin, this.myFin.rRadFin, this.myFin.xRadFin, this.myFin.yRadFin, this.myFin.k1Fin, this.myFin.k2Fin, this.myFin.xFin, this.myFin.yFin, this.myFin.nWork1, this.myFin.xWork1, this.myFin.yWork1, this.tolerance);
                    if (this.kLineFinal > 0)
                    {
                        this.myFin.kLineFinal = this.kLineFinal;
                        this.myFin.KeepLineFin();
                    }
                }
                if (File.Exists(this.myFin.fpolyFinal))
                {
                    this.myFin.PolyLoadFin();
                    this.kPolyFinal = this.myFin.kPolyFinal;
                }
                if (!File.Exists(this.myFin.fpolyFinal))
                {
                    DllClass1.PolyFinal(this.kPolyAct, this.myFin.nameAct, this.myFin.xAct, this.myFin.yAct, this.myFin.aActCalc, this.myFin.aActLeg, this.myFin.kActPoly1, this.myFin.kActPoly2, this.myFin.xPolyAct, this.myFin.yPolyAct, out this.kPolyFinal, this.myFin.namePolyFin, this.myFin.xLabFin, this.myFin.yLabFin, this.myFin.arCalcFin, this.myFin.arLegFin, this.myFin.nSymbFin, this.myFin.kt1Fin, this.myFin.kt2Fin, this.myFin.xPolFin, this.myFin.yPolFin);
                    if (this.kPolyFinal > 0)
                    {
                        for (int index = 1; index <= this.kPolyFinal; ++index)
                            this.myFin.iHorVer[index] = 0;
                        this.myFin.kPolyFinal = this.kPolyFinal;
                        this.myFin.KeepPolyFin();
                    }
                }
            }
            if (this.nExist[1] == 0)
            {
                if (File.Exists(this.myFin.filePoly))
                {
                    this.myFin.PolygonLoad(ref this.myFin.kPolyInside);
                    this.kPoly = this.myFin.kPoly;
                    if (this.kPoly > 0)
                    {
                        ++this.kExist;
                        this.nExist[3] = 1;
                    }
                    if (File.Exists(this.myFin.fpolyFinal))
                    {
                        this.myFin.PolyLoadFin();
                        this.kPolyFinal = this.myFin.kPolyFinal;
                    }
                    if (!File.Exists(this.myFin.fpolyFinal))
                    {
                        DllClass1.PolyFinal(this.kPoly, this.myFin.namePoly, this.myFin.xLab, this.myFin.yLab, this.myFin.areaPol, this.myFin.areaLeg, this.myFin.kt1, this.myFin.kt2, this.myFin.xPol, this.myFin.yPol, out this.kPolyFinal, this.myFin.namePolyFin, this.myFin.xLabFin, this.myFin.yLabFin, this.myFin.arCalcFin, this.myFin.arLegFin, this.myFin.nSymbFin, this.myFin.kt1Fin, this.myFin.kt2Fin, this.myFin.xPolFin, this.myFin.yPolFin);
                        if (this.kPolyFinal > 0)
                        {
                            this.myFin.kPolyFinal = this.kPolyFinal;
                            this.myFin.KeepPolyFin();
                        }
                    }
                    if (this.kPolyFinal > 0)
                    {
                        ++this.kExist;
                        this.nExist[2] = 1;
                    }
                }
                if (File.Exists(this.myFin.flineTopo))
                {
                    this.myFin.LineTopoLoad();
                    this.kLineTopo = this.myFin.kLineTopo;
                    if (this.kLineTopo > 0)
                    {
                        ++this.kExist;
                        this.nExist[5] = 1;
                    }
                    if (File.Exists(this.myFin.flineFinal))
                    {
                        this.myFin.LineLoadFin();
                        this.kLineFinal = this.myFin.kLineFinal;
                    }
                    if (!File.Exists(this.myFin.flineFinal))
                    {
                        DllClass1.LineFinal(this.kLineInput, this.myFin.nLineCode, this.myFin.nLongRad, this.myFin.sWidLine, this.myFin.dstLine, this.myFin.rRadLine, this.myFin.xRadLine, this.myFin.yRadLine, this.myFin.k1, this.myFin.k2, this.myFin.xLin, this.myFin.yLin, this.kLineTopo, this.myFin.radLine, this.myFin.kl1, this.myFin.kl2, this.myFin.zLin, this.myFin.zPik, out this.kLineFinal, this.myFin.nCodeFin, this.myFin.nLongFin, this.myFin.sWidFin, this.myFin.distFin, this.myFin.rRadFin, this.myFin.xRadFin, this.myFin.yRadFin, this.myFin.k1Fin, this.myFin.k2Fin, this.myFin.xFin, this.myFin.yFin, this.myFin.nWork, this.myFin.xWork, this.myFin.yWork, this.tolerance);
                        if (this.kLineFinal > 0)
                        {
                            this.myFin.kLineFinal = this.kLineFinal;
                            this.myFin.KeepLineFin();
                        }
                    }
                    if (this.kLineFinal > 0)
                    {
                        ++this.kExist;
                        this.nExist[4] = 1;
                    }
                }
            }
            if (this.kLineFinal == 0 && this.nExist[6] > 0)
            {
                this.kLineFinal = this.kLineInput;
                for (int index1 = 1; index1 <= this.kLineInput; ++index1)
                {
                    this.myFin.nCodeFin[index1] = this.myFin.nLineCode[index1];
                    this.myFin.nLongFin[index1] = this.myFin.nLongRad[index1];
                    this.myFin.sWidFin[index1] = this.myFin.sWidLine[index1];
                    this.myFin.distFin[index1] = this.myFin.dstLine[index1];
                    this.myFin.rRadFin[index1] = this.myFin.rRadLine[index1];
                    this.myFin.xRadFin[index1] = this.myFin.xRadLine[index1];
                    this.myFin.yRadFin[index1] = this.myFin.yRadLine[index1];
                    this.myFin.k1Fin[index1] = this.myFin.k1[index1];
                    this.myFin.k2Fin[index1] = this.myFin.k2[index1];
                    int num1 = this.myFin.k1[index1];
                    int num2 = this.myFin.k2[index1];
                    for (int index2 = num1; index2 <= num2; ++index2)
                    {
                        this.myFin.xFin[index2] = this.myFin.xLin[index2];
                        this.myFin.yFin[index2] = this.myFin.yLin[index2];
                    }
                }
                this.myFin.kLineFinal = this.kLineFinal;
                this.myFin.KeepLineFin();
            }
            this.myFin.ItemLoadKeep(1);
            this.kItemCoord = this.myFin.kItemCoord;
            if (File.Exists(this.myFin.flineFinal))
            {
                DllClass1.LineItemCoor(this.myFin.fitemLine, this.myFin.nColorItm, this.myFin.ixSqu, this.myFin.iySqu, this.kLineFinal, this.myFin.rRadFin, this.myFin.k1Fin, this.myFin.k2Fin, this.myFin.xFin, this.myFin.yFin, this.myFin.nCodeFin, this.kSymbLine, this.myFin.nItem, this.myFin.n1Sign, this.myFin.n2Sign, this.myFin.iDensity, out this.kItemCoord, this.myFin.numSign, this.myFin.numItem, this.myFin.xItem, this.myFin.yItem, this.myFin.azItem, this.myFin.xAdd, this.myFin.yAdd, this.myFin.xDop, this.myFin.yDop, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.scaleToGeo);
                if (this.kItemCoord > 0)
                {
                    this.myFin.kItemCoord = this.kItemCoord;
                    this.myFin.ItemLoadKeep(2);
                }
            }
            this.myFin.AddInscrLoad();
            this.kAddInscript = this.myFin.kAddInscript;
            this.xminCur = this.xmin;
            this.yminCur = this.ymin;
            this.xmaxCur = this.xmax;
            this.ymaxCur = this.ymax;
            DllClass1.CoorWin(this.xmin, this.ymin, this.xmax, this.ymax, this.iWidth, this.iHeight, out this.scaleToWin, out this.scaleToGeo, out this.xBegX, out this.yBegY, out this.xEndX, out this.yEndY, out this.xBegWin, out this.yBegWin, out this.xEndWin, out this.yEndWin, out this.iCond);
            if (File.Exists(this.myFin.flineFinal))
            {
                DllClass1.LineItemCoor(this.myFin.fitemLine, this.myFin.nColorItm, this.myFin.ixSqu, this.myFin.iySqu, this.kLineFinal, this.myFin.rRadFin, this.myFin.k1Fin, this.myFin.k2Fin, this.myFin.xFin, this.myFin.yFin, this.myFin.nCodeFin, this.kSymbLine, this.myFin.nItem, this.myFin.n1Sign, this.myFin.n2Sign, this.myFin.iDensity, out this.kItemCoord, this.myFin.numSign, this.myFin.numItem, this.myFin.xItem, this.myFin.yItem, this.myFin.azItem, this.myFin.xAdd, this.myFin.yAdd, this.myFin.xDop, this.myFin.yDop, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.scaleToGeo);
                DllClass1.InputLineItem(this.kPntPlus, this.myFin.xPnt, this.myFin.yPnt, this.kLineFinal, this.myFin.k1Fin, this.myFin.k2Fin, this.myFin.xFin, this.myFin.yFin, this.myFin.nCodeFin, this.myFin.rRadFin, ref this.kItemCoord, this.myFin.numSign, this.myFin.numItem, this.myFin.xItem, this.myFin.yItem, this.myFin.azItem, this.myFin.xAdd, this.myFin.yAdd, this.myFin.xDop, this.myFin.yDop, this.kSymbLine, this.myFin.nItem, this.myFin.n1Sign, this.myFin.n2Sign, this.myFin.iDensity, this.myFin.iStyle1, this.myFin.iStyle2, this.myFin.sInscr, this.myFin.hInscr, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.scaleToGeo);
                if (this.kItemCoord > 0)
                {
                    this.myFin.kItemCoord = this.kItemCoord;
                    this.myFin.ItemLoadKeep(2);
                }
                int kLinePart = 0;
                int kPntPart = 0;
                DllClass1.FormInputLine(this.kLineFinal, this.myFin.k1Fin, this.myFin.k2Fin, this.myFin.xFin, this.myFin.yFin, this.myFin.nCodeFin, this.myFin.distFin, this.myFin.rRadFin, this.myFin.xRadFin, this.myFin.yRadFin, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myFin.nColLine, this.myFin.iWidth1, this.myFin.iWidth2, this.myFin.iStyle1, this.myFin.iStyle2, this.myFin.nBaseSymb, this.myFin.xAdd, this.myFin.yAdd, this.myFin.xOut, this.myFin.yOut, this.myFin.xDop, this.myFin.yDop, this.kSymbLine, this.myFin.n1Sign, this.myFin.n2Sign, out kLinePart, this.myFin.xWork1, this.myFin.yWork1, this.myFin.xWork2, this.myFin.yWork2, this.myFin.nWork, this.myFin.nDop1, out kPntPart, this.myFin.xWork, this.myFin.yWork, this.myFin.nDop2, this.scaleToGeo);
                DllClass1.KeepLoadParts(1, this.myFin.fPntLine, ref kPntPart, this.myFin.xWork, this.myFin.yWork, this.myFin.nDop2, ref kLinePart, this.myFin.xWork1, this.myFin.yWork1, this.myFin.xWork2, this.myFin.yWork2, this.myFin.nWork, this.myFin.nDop1);
            }
            this.kInstall = 0;
            if (!File.Exists(this.myFin.fPolyItem))
                return;
            FileStream input = new FileStream(this.myFin.fPolyItem, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader((Stream)input);
            try
            {
                this.kInstall = binaryReader.ReadInt32();
                for (int index = 1; index <= this.kInstall; ++index)
                {
                    this.myFin.nCent[index] = binaryReader.ReadInt32();
                    this.myFin.xLinParc[index] = binaryReader.ReadDouble();
                    this.myFin.yLinParc[index] = binaryReader.ReadDouble();
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (this.iGraphic > 0)
                return;
            if (this.nControl == 10)
                graphics.DrawRectangle(new Pen(Color.Green, 2f), this.RcDraw);
            if (this.kPolyFinal > 0 && this.iPolySymbol > 0)
                DllClass1.DrawPoly(e, this.myFin.fitemPoly, this.kPolyFinal, this.myFin.namePolyFin, this.myFin.kt1Fin, this.myFin.kt2Fin, this.myFin.xLabFin, this.myFin.yLabFin, this.myFin.arCalcFin, this.myFin.nSymbFin, this.myFin.iHorVer, this.myFin.xPolFin, this.myFin.yPolFin, this.myFin.ki1, this.myFin.ki2, this.myFin.xAdd, this.myFin.yAdd, this.kSymbPoly, this.myFin.npSign1, this.myFin.npSign2, this.myFin.npItem, this.myFin.nBackCol, this.myFin.nOneSymb, this.myFin.ixSqu, this.myFin.iySqu, this.myFin.nColorItm, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myFin.xDop, this.myFin.yDop, this.myFin.xWork, this.myFin.yWork, this.myFin.xWork1, this.myFin.yWork1, this.myFin.brColor, this.myFin.pnColor);
            this.kInstall = 0;
            if (File.Exists(this.myFin.fPolyItem))
            {
                FileStream input = new FileStream(this.myFin.fPolyItem, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.kInstall = binaryReader.ReadInt32();
                    for (int index = 1; index <= this.kInstall; ++index)
                    {
                        this.myFin.nCent[index] = binaryReader.ReadInt32();
                        this.myFin.xLinParc[index] = binaryReader.ReadDouble();
                        this.myFin.yLinParc[index] = binaryReader.ReadDouble();
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
            if (this.kInstall > 0 && this.iPolySymbol > 0)
            {
                string sTxt = "";
                int yWin = 0;
                int xWin = this.iWidth - this.wItemMax;
                for (int index1 = 1; index1 <= this.kInstall; ++index1)
                {
                    int nSelect = this.myFin.nCent[index1];
                    DllClass1.XYtoWIN(this.myFin.xLinParc[index1], this.myFin.yLinParc[index1], this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xWin, out yWin);
                    int kPix;
                    int mClr;
                    DllClass1.SelItemPoly(this.myFin.fitemPoly, nSelect, out int _, out int _, out int _, out kPix, this.myFin.ixSqu, this.myFin.iySqu, this.myFin.nColorItm, out sTxt, out mClr);
                    for (int index2 = 1; index2 <= kPix; ++index2)
                    {
                        int x = xWin + this.myFin.ixSqu[index2];
                        int y = yWin + this.myFin.iySqu[index2];
                        mClr = this.myFin.nColorItm[index2];
                        SolidBrush solidBrush = this.myFin.brColor[mClr];
                        graphics.FillRectangle((Brush)solidBrush, x, y, 1, 1);
                    }
                }
            }
            if (this.kNodeAct > 0 && this.iNodeShow > 0)
                DllClass1.DrawNodeAct(e, this.kNodeAct, this.myFin.nameNodeAct, this.myFin.xNodeAct, this.myFin.yNodeAct, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            if (this.kNode > 0 && this.kNodeAct == 0 && this.iNodeShow > 0)
                DllClass1.DrawNode(e, this.kNode, this.myFin.nameNode, this.myFin.xNode, this.myFin.yNode, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            if (this.kPntFin > 0 && this.iPointShow > 0)
                DllClass1.PointsDraw(e, this.myFin.fsymbPnt, this.iHeightShow, this.kPntFin, this.myFin.namePntFin, this.myFin.xPntFin, this.myFin.yPntFin, this.myFin.zPntFin, this.myFin.xPntInscr, this.myFin.yPntInscr, this.myFin.iHorVerPnt, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myFin.nCode1Fin, this.myFin.nCode2Fin, this.kSymbPnt, this.myFin.numRec, this.myFin.numbUser, this.myFin.ixSqu, this.myFin.iySqu, this.myFin.nColor, this.myFin.brColor, this.myFin.pnColor);
            if (this.kAddInscript > 0)
                DllClass1.AddInscrDraw(e, this.kAddInscript, this.myFin.sAddInscr, this.myFin.xAddInscr, this.myFin.yAddInscr, this.myFin.nHorVer, this.myFin.nInsCol, this.myFin.brColor, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            if (this.kPolyFinal > 0 && this.iPolySymbol == 0)
            {
                this.iParam = 8;
                DllClass1.LabelDraw(e, this.kPolyFinal, this.myFin.namePolyFin, this.myFin.xLabFin, this.myFin.yLabFin, this.myFin.iHorVer, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myFin.brColor, this.iParam);
            }
            if (this.kLineFinal > 0 && this.iBordSymbol > 0)
            {
                DllClass1.DrawInputLine(e, this.kLineFinal, this.myFin.k1Fin, this.myFin.k2Fin, this.myFin.xFin, this.myFin.yFin, this.myFin.nCodeFin, this.myFin.sWidFin, this.myFin.rRadFin, this.myFin.xRadFin, this.myFin.yRadFin, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myFin.nColLine, this.myFin.iWidth1, this.myFin.iWidth2, this.myFin.iStyle1, this.myFin.iStyle2, this.myFin.nBaseSymb, this.myFin.xAdd, this.myFin.yAdd, this.myFin.xDop, this.myFin.yDop, this.myFin.xWork2, this.myFin.yWork2, this.kSymbLine, this.myFin.n1Sign, this.myFin.n2Sign, this.myFin.brColor, this.myFin.pnColor, 0);
                if (this.kItemCoord > 0)
                    DllClass1.InputItemDraw(e, this.myFin.fitemLine, this.kItemCoord, this.myFin.numSign, this.myFin.numItem, this.myFin.xItem, this.myFin.yItem, this.myFin.azItem, this.myFin.itemLoc, this.myFin.nBaseSymb, this.myFin.sInscr, this.myFin.hInscr, this.myFin.iColInscr, this.kSymbLine, this.myFin.ixSqu, this.myFin.iySqu, this.myFin.nColorItm, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myFin.nDop1, this.myFin.nDop2, this.myFin.brColor);
            }
            if (this.kPolyAct > 0)
            {
                this.iParam = 4;
                DllClass1.LabelDraw(e, this.kPolyAct, this.myFin.nameAct, this.myFin.xAct, this.myFin.yAct, this.myFin.iHorVer, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myFin.brColor, this.iParam);
            }
            if (this.kLineFinal > 0 && this.iBordSymbol == 0)
            {
                this.iParam = 1;
                DllClass1.LineDraw(e, this.kLineFinal, this.myFin.k1Fin, this.myFin.k2Fin, this.myFin.xFin, this.myFin.yFin, this.myFin.rRadFin, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myFin.pnColor, this.iParam);
            }
            if (this.kRcPnt > 0)
            {
                for (int index = 1; index <= this.kRcPnt; ++index)
                    graphics.FillRectangle((Brush)new SolidBrush(Color.Magenta), this.RcPnt[index]);
            }
            if (this.kPolyCancel > 0 && this.iCancelPoly > 0)
            {
                this.iParam = 3;
                DllClass1.LabelDraw(e, this.kPolyCancel, this.myFin.nameCanc, this.myFin.xLabCanc, this.myFin.yLabCanc, this.myFin.iHorVer, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myFin.brColor, this.iParam);
                if (this.kLineCancel > 0)
                {
                    this.iParam = 3;
                    DllClass1.LineDraw(e, this.kLineCancel, this.myFin.kLinCanc1, this.myFin.kLinCanc2, this.myFin.xLinCanc, this.myFin.yLinCanc, this.myFin.RadCanc, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myFin.pnColor, this.iParam);
                }
            }
            if (File.Exists(this.myFin.fileContour) && this.iContours > 0)
                DllClass1.ContourDraw(e, this.myFin.fileContour, this.myFin.xDop, this.myFin.yDop, this.myFin.xOut, this.myFin.yOut, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            if (this.nProcess == 910)
                DllClass1.DrawSelLine(e, this.kSel, ref this.myFin.xSel, ref this.myFin.ySel, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            if (this.nProcess == 410 || this.nProcess == 420)
            {
                string sTxt = "";
                int yWin = 0;
                int xWin = this.iWidth - this.wItemMax;
                this.kInstall = 0;
                if (File.Exists(this.myFin.fPolyItem))
                {
                    FileStream input = new FileStream(this.myFin.fPolyItem, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        this.kInstall = binaryReader.ReadInt32();
                        for (int index = 1; index <= this.kInstall; ++index)
                        {
                            this.myFin.nCent[index] = binaryReader.ReadInt32();
                            this.myFin.xLinParc[index] = binaryReader.ReadDouble();
                            this.myFin.yLinParc[index] = binaryReader.ReadDouble();
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
                if (this.kInstall > 0 && this.iPolySymbol > 0)
                {
                    for (int index3 = 1; index3 <= this.kInstall; ++index3)
                    {
                        int nSelect = this.myFin.nCent[index3];
                        DllClass1.XYtoWIN(this.myFin.xLinParc[index3], this.myFin.yLinParc[index3], this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xWin, out yWin);
                        int kPix;
                        int mClr;
                        DllClass1.SelItemPoly(this.myFin.fitemPoly, nSelect, out int _, out int _, out int _, out kPix, this.myFin.ixSqu, this.myFin.iySqu, this.myFin.nColorItm, out sTxt, out mClr);
                        for (int index4 = 1; index4 <= kPix; ++index4)
                        {
                            int x = xWin + this.myFin.ixSqu[index4];
                            int y = yWin + this.myFin.iySqu[index4];
                            mClr = this.myFin.nColorItm[index4];
                            SolidBrush solidBrush = this.myFin.brColor[mClr];
                            graphics.FillRectangle((Brush)solidBrush, x, y, 1, 1);
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void SelectBox_Click(object sender, EventArgs e)
        {
            this.nControl = 10;
            this.nProcess = 0;
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            this.nControl = 20;
            this.nProcess = 0;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            this.nControl = 30;
            this.nProcess = 0;
        }

        private void Move_Click(object sender, EventArgs e)
        {
            this.nControl = 40;
            this.nProcess = 0;
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            DllClass1.WINtoXY(e.X, e.Y, this.scaleToGeo, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out this.xCur, out this.yCur);
            if (!File.Exists(this.myFin.filePoint))
            {
                this.panel2.Text = string.Format("{0}", (object)e.X);
                this.panel4.Text = string.Format("{0}", (object)e.Y);
            }
            if (File.Exists(this.myFin.filePoint))
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

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            this.CreateGraphics();
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
            if (e.Button == MouseButtons.Left)
            {
                if (this.nProcess == 910 || this.nProcess == 920 || this.nProcess == 930 || this.nProcess == 940 || this.nProcess == 950 || this.nProcess == 960 || this.nProcess == 970 || this.nProcess == 980 || this.nProcess == 990)
                {
                    DllClass1.WINtoXY(e.X, e.Y, this.scaleToGeo, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out this.xCur, out this.yCur);
                    ++this.kSel;
                    ++this.kRcPnt;
                    this.RcPnt[this.kRcPnt].X = e.X;
                    this.RcPnt[this.kRcPnt].Y = e.Y;
                }
                if (this.nProcess == 810 || this.nProcess == 820 || this.nProcess == 830 || this.nProcess == 840)
                {
                    DllClass1.WINtoXY(e.X, e.Y, this.scaleToGeo, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out this.xCur, out this.yCur);
                    ++this.kSel;
                    ++this.kRcPnt;
                    this.RcPnt[this.kRcPnt].X = e.X;
                    this.RcPnt[this.kRcPnt].Y = e.Y;
                }
                if (this.nProcess == 410)
                {
                    this.numSel = 0;
                    if (File.Exists(this.myFin.fileAdd))
                    {
                        FileStream input = new FileStream(this.myFin.fileAdd, FileMode.Open, FileAccess.Read);
                        BinaryReader binaryReader = new BinaryReader((Stream)input);
                        try
                        {
                            this.numSel = binaryReader.ReadInt32();
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
                    ++this.kSelItem;
                    if (this.kSelItem > 0)
                    {
                        this.kInstall = 0;
                        if (File.Exists(this.myFin.fPolyItem))
                        {
                            FileStream input = new FileStream(this.myFin.fPolyItem, FileMode.Open, FileAccess.Read);
                            BinaryReader binaryReader = new BinaryReader((Stream)input);
                            try
                            {
                                this.kInstall = binaryReader.ReadInt32();
                                for (int index = 1; index <= this.kInstall; ++index)
                                {
                                    this.myFin.nCent[index] = binaryReader.ReadInt32();
                                    this.myFin.xLinParc[index] = binaryReader.ReadDouble();
                                    this.myFin.yLinParc[index] = binaryReader.ReadDouble();
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
                        if (this.numSel > 0)
                        {
                            ++this.kInstall;
                            this.myFin.nCent[this.kInstall] = this.numSel;
                            this.myFin.xLinParc[this.kInstall] = this.xCur;
                            this.myFin.yLinParc[this.kInstall] = this.yCur;
                            if (File.Exists(this.myFin.fPolyItem))
                                File.Delete(this.myFin.fPolyItem);
                            FileStream output = new FileStream(this.myFin.fPolyItem, FileMode.CreateNew);
                            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                            binaryWriter.Write(this.kInstall);
                            for (int index = 1; index <= this.kInstall; ++index)
                            {
                                binaryWriter.Write(this.myFin.nCent[index]);
                                binaryWriter.Write(this.myFin.xLinParc[index]);
                                binaryWriter.Write(this.myFin.yLinParc[index]);
                            }
                            binaryWriter.Close();
                            output.Close();
                        }
                    }
                    this.panel7.Invalidate();
                }
            }
            if (e.Button != MouseButtons.Right || this.nProcess != 0)
                return;
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
            if (this.nProcess == 910 || this.nProcess == 920 || this.nProcess == 930 || this.nProcess == 940 || this.nProcess == 950 || this.nProcess == 960 || this.nProcess == 970 || this.nProcess == 980 || this.nProcess == 990)
            {
                this.RcPnt[this.kRcPnt].Width = 4;
                this.RcPnt[this.kRcPnt].Height = 4;
                this.panel7.Invalidate(this.RcPnt[this.kRcPnt]);
            }
            if (this.nProcess == 810 || this.nProcess == 820 || this.nProcess == 830 || this.nProcess == 840)
            {
                this.RcPnt[this.kRcPnt].Width = 4;
                this.RcPnt[this.kRcPnt].Height = 4;
                this.panel7.Invalidate(this.RcPnt[this.kRcPnt]);
            }
            if (this.nProcess == 910 && this.kSel == 0)
            {
                double az = 0.0;
                double num;
                double yrd = num = 0.0;
                double xrd = num;
                double rd = num;
                DllClass1.FindLine(this.xCur, this.yCur, this.kLineFinal, ref this.myFin.k1Fin, ref this.myFin.k2Fin, ref this.myFin.rRadFin, ref this.myFin.xRadFin, ref this.myFin.yRadFin, ref this.myFin.xFin, ref this.myFin.yFin, out rd, out xrd, out yrd, out this.kSel, ref this.myFin.xSel, ref this.myFin.ySel, ref this.myFin.xDop, ref this.myFin.yDop, out double _, out double _, out az, out this.indLine);
                if (this.kSel < 1)
                    return;
                this.panel7.Invalidate();
                this.textBox1.Text = string.Format("{0}", (object)this.myFin.nCodeFin[this.indLine]);
                this.textBox2.Text = string.Format("{0:F2}", (object)this.myFin.distFin[this.indLine]);
                this.button8.Visible = true;
                this.button9.Visible = true;
                this.button33.Visible = true;
            }
            if (this.nProcess == 920)
            {
                this.indLine = 0;
                if (this.kSel == 0)
                {
                    double az = 0.0;
                    double num;
                    double yrd = num = 0.0;
                    double xrd = num;
                    double rd = num;
                    DllClass1.FindLine(this.xCur, this.yCur, this.kLineFinal, ref this.myFin.k1Fin, ref this.myFin.k2Fin, ref this.myFin.rRadFin, ref this.myFin.xRadFin, ref this.myFin.yRadFin, ref this.myFin.xFin, ref this.myFin.yFin, out rd, out xrd, out yrd, out this.kSel, ref this.myFin.xSel, ref this.myFin.ySel, ref this.myFin.xDop, ref this.myFin.yDop, out double _, out double _, out az, out this.indLine);
                    if (this.kSel < 1)
                        return;
                }
                if (this.indLine > 0)
                {
                    int index1 = this.kSel + 1;
                    for (int index2 = 0; index2 <= this.kSel; ++index2)
                    {
                        --index1;
                        this.myFin.xDop[index2] = this.myFin.xSel[index1];
                        this.myFin.yDop[index2] = this.myFin.ySel[index1];
                    }
                    int num1 = this.myFin.k1Fin[this.indLine];
                    int num2 = this.myFin.k2Fin[this.indLine];
                    int index3 = -1;
                    for (int index4 = num1; index4 <= num2; ++index4)
                    {
                        ++index3;
                        this.myFin.xFin[index4] = this.myFin.xDop[index3];
                        this.myFin.yFin[index4] = this.myFin.yDop[index3];
                    }
                    this.myFin.kLineFinal = this.kLineFinal;
                    this.myFin.KeepLineFin();
                    if (File.Exists(this.myFin.flineFinal))
                    {
                        DllClass1.LineItemCoor(this.myFin.fitemLine, this.myFin.nColorItm, this.myFin.ixSqu, this.myFin.iySqu, this.kLineFinal, this.myFin.rRadFin, this.myFin.k1Fin, this.myFin.k2Fin, this.myFin.xFin, this.myFin.yFin, this.myFin.nCodeFin, this.kSymbLine, this.myFin.nItem, this.myFin.n1Sign, this.myFin.n2Sign, this.myFin.iDensity, out this.kItemCoord, this.myFin.numSign, this.myFin.numItem, this.myFin.xItem, this.myFin.yItem, this.myFin.azItem, this.myFin.xAdd, this.myFin.yAdd, this.myFin.xDop, this.myFin.yDop, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.scaleToGeo);
                        if (this.kItemCoord > 0)
                        {
                            this.myFin.kItemCoord = this.kItemCoord;
                            this.myFin.ItemLoadKeep(2);
                        }
                    }
                    this.iBordSymbol = 1;
                    this.panel7.Invalidate();
                }
            }
            if (this.nProcess == 930 && this.kSel == 0)
            {
                double num3 = 9999999.9;
                this.indLine = 0;
                for (int index = 1; index <= this.kPolyFinal; ++index)
                {
                    double num4 = this.myFin.xLabFin[index] - this.xCur;
                    double num5 = this.myFin.yLabFin[index] - this.yCur;
                    double num6 = Math.Sqrt(num4 * num4 + num5 * num5);
                    if (num6 < num3)
                    {
                        num3 = num6;
                        this.indLine = index;
                    }
                }
                this.label5.Visible = true;
                this.textBox5.Visible = true;
                this.label6.Visible = true;
                this.textBox6.Visible = true;
                this.button12.Visible = true;
                this.button13.Visible = true;
                this.button34.Visible = true;
                this.textBox5.Text = this.myFin.namePolyFin[this.indLine];
                this.textBox6.Text = string.Format("{0}", (object)this.myFin.nSymbFin[this.indLine]);
                this.iPolySymbol = 1;
            }
            if (this.nProcess == 810 || this.nProcess == 820 || this.nProcess == 830 || this.nProcess == 840)
            {
                if (this.kSel == 0)
                {
                    double num7 = 9999999.9;
                    this.indLine = -1;
                    for (int index = 0; index <= this.kPntFin; ++index)
                    {
                        double num8 = this.myFin.xPntInscr[index] - this.xCur;
                        double num9 = this.myFin.yPntInscr[index] - this.yCur;
                        double num10 = Math.Sqrt(num8 * num8 + num9 * num9);
                        if (num10 < num7)
                        {
                            num7 = num10;
                            this.indLine = index;
                        }
                    }
                    if (this.nProcess == 820)
                    {
                        this.myFin.iHorVerPnt[this.indLine] = this.myFin.iHorVerPnt[this.indLine] <= 0 ? 1 : 0;
                        this.myFin.kPntFin = this.kPntFin;
                        this.myFin.InscriptionFin(2);
                        this.iPointShow = 1;
                        this.kSel = -1;
                        this.kRcPnt = 0;
                        this.panel7.Invalidate();
                    }
                }
                if (this.nProcess == 830 && this.kSel == 0)
                {
                    int index5 = -1;
                    for (int index6 = 0; index6 <= this.kPntFin; ++index6)
                    {
                        if (this.indLine != index6)
                        {
                            ++index5;
                            this.myFin.namePntFin[index5] = this.myFin.namePntFin[index6];
                            this.myFin.xPntFin[index5] = this.myFin.xPntFin[index6];
                            this.myFin.yPntFin[index5] = this.myFin.yPntFin[index6];
                            this.myFin.zPntFin[index5] = this.myFin.zPntFin[index6];
                            this.myFin.nCode1Fin[index5] = this.myFin.nCode1Fin[index6];
                            this.myFin.nCode2Fin[index5] = this.myFin.nCode2Fin[index6];
                            this.myFin.xPntInscr[index5] = this.myFin.xPntInscr[index6];
                            this.myFin.yPntInscr[index5] = this.myFin.yPntInscr[index6];
                            this.myFin.iHorVerPnt[index5] = this.myFin.iHorVerPnt[index6];
                        }
                    }
                    this.kPntFin = index5;
                    this.myFin.kPntFin = this.kPntFin;
                    this.myFin.InscriptionFin(2);
                    this.myFin.KeepPointFin();
                    this.iPointShow = 1;
                    this.kSel = -1;
                    this.kRcPnt = 0;
                    this.panel7.Invalidate();
                }
                if (this.nProcess == 840 && this.kSel == 0)
                {
                    for (int index = 0; index <= this.kPntFin; ++index)
                    {
                        if (this.indLine == index)
                        {
                            this.textBox8.Text = string.Format("{0}", (object)this.myFin.nCode1Fin[this.indLine]);
                            break;
                        }
                    }
                    this.button24.Visible = true;
                    this.button26.Visible = true;
                }
                if (this.nProcess == 810 && this.kSel == 1)
                {
                    this.myFin.xPntInscr[this.indLine] = this.xCur;
                    this.myFin.yPntInscr[this.indLine] = this.yCur;
                    this.myFin.kPntFin = this.kPntFin;
                    this.myFin.InscriptionFin(2);
                    this.iPointShow = 1;
                    this.kSel = -1;
                    this.kRcPnt = 0;
                    this.panel7.Invalidate();
                }
            }
            if (this.nProcess == 940 || this.nProcess == 950)
            {
                if (this.kSel == 0)
                {
                    double num11 = 9999999.9;
                    this.indLine = 0;
                    for (int index = 1; index <= this.kPolyFinal; ++index)
                    {
                        double num12 = this.myFin.xLabFin[index] - this.xCur;
                        double num13 = this.myFin.yLabFin[index] - this.yCur;
                        double num14 = Math.Sqrt(num12 * num12 + num13 * num13);
                        if (num14 < num11)
                        {
                            num11 = num14;
                            this.indLine = index;
                        }
                    }
                    if (this.nProcess == 950)
                    {
                        this.myFin.iHorVer[this.indLine] = this.myFin.iHorVer[this.indLine] <= 0 ? 1 : 0;
                        this.myFin.kPolyFinal = this.kPolyFinal;
                        this.myFin.KeepPolyFin();
                        this.iPolySymbol = 0;
                        this.kSel = -1;
                        this.kRcPnt = 0;
                    }
                }
                if (this.nProcess == 940 && this.kSel == 1)
                {
                    this.myFin.xLabFin[this.indLine] = this.xCur;
                    this.myFin.yLabFin[this.indLine] = this.yCur;
                    this.myFin.kPolyFinal = this.kPolyFinal;
                    this.myFin.KeepPolyFin();
                    this.iPolySymbol = 0;
                    this.kSel = -1;
                    this.kRcPnt = 0;
                }
                this.panel7.Invalidate();
            }
            if (this.nProcess == 960)
            {
                int num15 = 0;
                if (this.kSel == 0)
                {
                    if (this.textBox7.Text == "")
                    {
                        this.kSel = -1;
                        this.kRcPnt = 0;
                        int num16 = (int)MessageBox.Show("Type Inscription", "Additional Inscription");
                        return;
                    }
                    if (this.radioButton1.Checked)
                        num15 = 0;
                    if (this.radioButton2.Checked)
                        num15 = 1;
                    ++this.kAddInscript;
                    this.myFin.sAddInscr[this.kAddInscript] = this.textBox7.Text;
                    this.myFin.xAddInscr[this.kAddInscript] = this.xCur;
                    this.myFin.yAddInscr[this.kAddInscript] = this.yCur;
                    this.myFin.nHorVer[this.kAddInscript] = num15;
                    this.myFin.nInsCol[this.kAddInscript] = this.comboBox1.SelectedIndex + 1;
                    this.myFin.kAddInscript = this.kAddInscript;
                    this.myFin.KeepAddInscr();
                    this.kSel = -1;
                    this.kRcPnt = 0;
                    this.panel7.Invalidate();
                }
            }
            if (this.nProcess == 970)
            {
                if (this.kSel == 0)
                {
                    double num17 = 9999999.9;
                    this.indLine = 0;
                    for (int index = 1; index <= this.kAddInscript; ++index)
                    {
                        double num18 = this.myFin.xAddInscr[index] - this.xCur;
                        double num19 = this.myFin.yAddInscr[index] - this.yCur;
                        double num20 = Math.Sqrt(num18 * num18 + num19 * num19);
                        if (num20 < num17)
                        {
                            num17 = num20;
                            this.indLine = index;
                        }
                    }
                }
                if (this.kSel == 1)
                {
                    this.myFin.xAddInscr[this.indLine] = this.xCur;
                    this.myFin.yAddInscr[this.indLine] = this.yCur;
                    this.myFin.kAddInscript = this.kAddInscript;
                    this.myFin.KeepAddInscr();
                    this.iPolySymbol = 0;
                    this.kSel = -1;
                    this.kRcPnt = 0;
                }
                this.panel7.Invalidate();
            }
            if (this.nProcess == 980)
            {
                if (this.kSel == 0)
                {
                    double num21 = 9999999.9;
                    this.indLine = 0;
                    for (int index = 1; index <= this.kAddInscript; ++index)
                    {
                        double num22 = this.myFin.xAddInscr[index] - this.xCur;
                        double num23 = this.myFin.yAddInscr[index] - this.yCur;
                        double num24 = Math.Sqrt(num22 * num22 + num23 * num23);
                        if (num24 < num21)
                        {
                            num21 = num24;
                            this.indLine = index;
                        }
                    }
                }
                if (this.kAddInscript == 1)
                {
                    if (File.Exists(this.myFin.fAddInscr))
                        File.Delete(this.myFin.fAddInscr);
                    this.kAddInscript = 0;
                    this.myFin.kAddInscript = 0;
                    this.kSel = -1;
                    this.kRcPnt = 0;
                }
                if (this.kAddInscript > 1)
                {
                    int index7 = 0;
                    for (int index8 = 1; index8 <= this.kAddInscript; ++index8)
                    {
                        if (index8 != this.indLine)
                        {
                            ++index7;
                            this.myFin.sAddInscr[index7] = this.myFin.sAddInscr[index8];
                            this.myFin.xAddInscr[index7] = this.myFin.xAddInscr[index8];
                            this.myFin.yAddInscr[index7] = this.myFin.yAddInscr[index8];
                            this.myFin.nHorVer[index7] = this.myFin.nHorVer[index8];
                            this.myFin.nInsCol[index7] = this.myFin.nInsCol[index8];
                        }
                    }
                    this.kAddInscript = index7;
                    this.myFin.kAddInscript = this.kAddInscript;
                    this.myFin.KeepAddInscr();
                    this.iPolySymbol = 0;
                    this.kSel = -1;
                    this.kRcPnt = 0;
                }
                this.panel7.Invalidate();
            }
            if (this.nProcess != 990)
                return;
            if (this.kSel == 0)
            {
                double num25 = 9999999.9;
                this.indLine = 0;
                for (int index = 1; index <= this.kItemCoord; ++index)
                {
                    double num26 = this.myFin.xitLine[index] - this.xCur;
                    double num27 = this.myFin.yitLine[index] - this.yCur;
                    double num28 = Math.Sqrt(num26 * num26 + num27 * num27);
                    if (num28 < num25)
                    {
                        num25 = num28;
                        this.indLine = index;
                    }
                }
                int index9 = 0;
                for (int index10 = 1; index10 <= this.kItemCoord; ++index10)
                {
                    if (this.indLine != index10)
                    {
                        ++index9;
                        this.myFin.indexLine[index9] = this.myFin.indexLine[index10];
                        this.myFin.xitLine[index9] = this.myFin.xitLine[index10];
                        this.myFin.yitLine[index9] = this.myFin.yitLine[index10];
                        this.myFin.azitLine[index9] = this.myFin.azitLine[index10];
                    }
                }
                this.kItemCoord = index9;
                this.myFin.kItemCoord = this.kItemCoord;
                this.myFin.ItemLoadKeep(2);
            }
            this.kSel = -1;
            this.kRcPnt = 0;
            this.panel7.Invalidate();
        }

        private void LineSymbol_Click(object sender, EventArgs e)
        {
            this.nProcess = 910;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.indLine = 0;
            this.button24.Visible = false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button33.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.label6.Visible = false;
            this.textBox6.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button34.Visible = false;
            this.iBordSymbol = 0;
            this.iPolySymbol = 0;
            this.panel7.Invalidate();
        }

        private void LineDirection_Click(object sender, EventArgs e)
        {
            this.nProcess = 920;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.indLine = 0;
            this.button24.Visible = false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button33.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.label6.Visible = false;
            this.textBox6.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button34.Visible = false;
            this.iPolySymbol = 0;
            this.panel7.Invalidate();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (this.nProcess != 910 || this.indLine <= 0)
                return;
            if (this.textBox1.Text == "")
            {
                int num1 = (int)MessageBox.Show("Неправильный номер. Проверьте свои коды", "Lines' Symbols");
            }
            else
            {
                double tText = 0.0;
                DllClass1.CheckText(this.textBox1.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num2 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int int32 = Convert.ToInt32(this.textBox1.Text);
                    int num3 = 0;
                    for (int index = 0; index <= this.kSymbLine; ++index)
                    {
                        if (this.myFin.n2Sign[index] == int32)
                        {
                            ++num3;
                            break;
                        }
                    }
                    if (num3 == 0)
                    {
                        for (int index = 0; index <= this.kSymbLine; ++index)
                        {
                            if (this.myFin.n1Sign[index] == int32)
                            {
                                ++num3;
                                break;
                            }
                        }
                    }
                    if (num3 == 0)
                    {
                        int num4 = (int)MessageBox.Show("Неправильный номер. Проверьте свои коды", "Lines' Symbols");
                    }
                    else
                    {
                        DllClass1.CheckText(this.textBox1.Text, out tText, out this.iCond);
                        if (this.iCond < 0)
                        {
                            int num5 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            DllClass1.CheckText(this.textBox2.Text, out this.myFin.distFin[this.indLine], out this.iCond);
                            if (this.iCond < 0)
                            {
                                int num6 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                this.myFin.nCodeFin[this.indLine] = Convert.ToInt32(this.textBox1.Text);
                                this.myFin.kLineFinal = this.kLineFinal;
                                this.myFin.KeepLineFin();
                                if (File.Exists(this.myFin.flineFinal))
                                {
                                    DllClass1.LineItemCoor(this.myFin.fitemLine, this.myFin.nColorItm, this.myFin.ixSqu, this.myFin.iySqu, this.kLineFinal, this.myFin.rRadFin, this.myFin.k1Fin, this.myFin.k2Fin, this.myFin.xFin, this.myFin.yFin, this.myFin.nCodeFin, this.kSymbLine, this.myFin.nItem, this.myFin.n1Sign, this.myFin.n2Sign, this.myFin.iDensity, out this.kItemCoord, this.myFin.numSign, this.myFin.numItem, this.myFin.xItem, this.myFin.yItem, this.myFin.azItem, this.myFin.xAdd, this.myFin.yAdd, this.myFin.xDop, this.myFin.yDop, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.scaleToGeo);
                                    if (this.kItemCoord > 0)
                                    {
                                        this.myFin.kItemCoord = this.kItemCoord;
                                        this.myFin.ItemLoadKeep(2);
                                    }
                                    this.myFin.LineLoad(fCurLine);
                                    this.kLineInput = this.myFin.kLineInput;
                                    DllClass1.FinalInput(this.kLineInput, this.myFin.nLineCode, this.myFin.rRadLine, this.myFin.k1, this.myFin.k2, this.myFin.xLin, this.myFin.yLin, this.kLineFinal, this.myFin.nCodeFin, this.myFin.rRadFin, this.myFin.k1Fin, this.myFin.k2Fin, this.myFin.xFin, this.myFin.yFin, this.tolerance);
                                    this.myFin.KeepLine(fCurLine);
                                }
                                this.kSel = -1;
                                this.kRcPnt = 0;
                                this.indLine = 0;
                                this.iBordSymbol = 1;
                                this.textBox1.Text = "";
                                this.textBox2.Text = "";
                                this.button24.Visible = false;
                                this.button8.Visible = false;
                                this.button9.Visible = false;
                                this.button33.Visible = false;
                                this.label5.Visible = false;
                                this.textBox5.Visible = false;
                                this.label6.Visible = false;
                                this.textBox6.Visible = false;
                                this.button12.Visible = false;
                                this.button13.Visible = false;
                                this.button34.Visible = false;
                                this.FormLoad();
                                this.panel7.Invalidate();
                            }
                        }
                    }
                }
            }
        }

        private void Delay_Click(object sender, EventArgs e)
        {
            this.kSel = -1;
            this.kRcPnt = 0;
            this.indLine = 0;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.button24.Visible = false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button33.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.label6.Visible = false;
            this.textBox6.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button34.Visible = false;
            this.panel7.Invalidate();
        }

        private void NameSymbol_Click(object sender, EventArgs e)
        {
            this.myFin.PolyLoadFin();
            this.kPolyFinal = this.myFin.kPolyFinal;
            if (this.kPolyFinal == 0)
            {
                int num = (int)MessageBox.Show("Топология полигонов не была создана", "Polygonal Topology Building", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nProcess = 0;
            }
            else
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.button24.Visible = false;
                this.button8.Visible = false;
                this.button9.Visible = false;
                this.button33.Visible = false;
                this.label5.Visible = false;
                this.textBox5.Visible = false;
                this.label6.Visible = false;
                this.textBox6.Visible = false;
                this.button12.Visible = false;
                this.button13.Visible = false;
                this.button34.Visible = false;
                int num = (int)new FinalCorrect().ShowDialog((IWin32Window)this);
                this.myFin.PolyLoadFin();
                this.kPolyFinal = this.myFin.kPolyFinal;
                this.iPolySymbol = 1;
                this.panel7.Invalidate();
            }
        }

        private void NameSymbGraph_Click(object sender, EventArgs e)
        {
            this.myFin.PolyLoadFin();
            this.kPolyFinal = this.myFin.kPolyFinal;
            if (this.kPolyFinal == 0)
            {
                int num = (int)MessageBox.Show("Топология полигонов не была создана", "Polygonal Topology Building", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nProcess = 0;
            }
            else
            {
                this.nProcess = 930;
                this.nControl = 0;
                this.kSel = -1;
                this.kRcPnt = 0;
                this.indLine = 0;
                this.button24.Visible = false;
                this.button8.Visible = false;
                this.button9.Visible = false;
                this.button33.Visible = false;
                this.button12.Visible = false;
                this.button13.Visible = false;
                this.button34.Visible = false;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.iPolySymbol = 0;
                this.panel7.Invalidate();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (this.indLine > 0 && this.textBox5.Text != "" && this.textBox6.Text != "")
            {
                double tText = 0.0;
                DllClass1.CheckText(this.textBox6.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                int int32 = Convert.ToInt32(this.textBox6.Text);
                int num1 = 0;
                for (int index = 0; index <= this.kSymbPoly; ++index)
                {
                    if (this.myFin.np2Sign[index] == int32)
                    {
                        ++num1;
                        break;
                    }
                }
                if (num1 == 0)
                {
                    for (int index = 0; index <= this.kSymbPoly; ++index)
                    {
                        if (this.myFin.np1Sign[index] == int32)
                        {
                            int num2 = num1 + 1;
                            break;
                        }
                    }
                }
                this.myFin.namePolyFin[this.indLine] = this.textBox5.Text;
                DllClass1.CheckText(this.textBox6.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num3 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.myFin.nSymbFin[this.indLine] = Convert.ToInt32(this.textBox6.Text);
                this.myFin.kPolyFinal = this.kPolyFinal;
                this.myFin.KeepPolyFin();
            }
            this.kSel = -1;
            this.kRcPnt = 0;
            this.indLine = 0;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.button24.Visible = false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button33.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.label6.Visible = false;
            this.textBox6.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button34.Visible = false;
            this.panel7.Invalidate();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.kSel = -1;
            this.kRcPnt = 0;
            this.indLine = 0;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.button24.Visible = false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button33.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.label6.Visible = false;
            this.textBox6.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button34.Visible = false;
            this.panel7.Invalidate();
        }

        private void InscriptionMove_Click(object sender, EventArgs e)
        {
            this.myFin.PolyLoadFin();
            this.kPolyFinal = this.myFin.kPolyFinal;
            if (this.kPolyFinal == 0)
            {
                int num = (int)MessageBox.Show("Топология полигонов не была создана", "Polygonal Topology Building", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nProcess = 0;
            }
            else
            {
                this.nProcess = 940;
                this.nControl = 0;
                this.kSel = -1;
                this.kRcPnt = 0;
                this.indLine = 0;
                this.button24.Visible = false;
                this.button8.Visible = false;
                this.button9.Visible = false;
                this.button33.Visible = false;
                this.button12.Visible = false;
                this.button13.Visible = false;
                this.button34.Visible = false;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.iPolySymbol = 0;
                this.panel7.Invalidate();
            }
        }

        private void HorizontalVertical_Click(object sender, EventArgs e)
        {
            this.myFin.PolyLoadFin();
            this.kPolyFinal = this.myFin.kPolyFinal;
            if (this.kPolyFinal == 0)
            {
                int num = (int)MessageBox.Show("Топология полигонов не была создана", "Polygonal Topology Building", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nProcess = 0;
            }
            else
            {
                this.nProcess = 950;
                this.nControl = 0;
                this.kSel = -1;
                this.kRcPnt = 0;
                this.indLine = 0;
                this.button24.Visible = false;
                this.button8.Visible = false;
                this.button9.Visible = false;
                this.button33.Visible = false;
                this.button12.Visible = false;
                this.button13.Visible = false;
                this.button34.Visible = false;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.iPolySymbol = 0;
                this.panel7.Invalidate();
            }
        }

        private void MoveNamePnt_Click(object sender, EventArgs e)
        {
            this.nProcess = 810;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.indLine = 0;
            this.button24.Visible = false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button33.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button34.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.iPointShow = 1;
        }

        private void HorVerPnt_Click(object sender, EventArgs e)
        {
            this.nProcess = 820;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.indLine = 0;
            this.button24.Visible = false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button33.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button34.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.iPointShow = 1;
        }

        private void PointDelete_Click(object sender, EventArgs e)
        {
            this.nProcess = 830;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.indLine = 0;
            this.button24.Visible = false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button33.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button34.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.iPointShow = 1;
        }

        private void PointSelect_Click(object sender, EventArgs e)
        {
            this.nProcess = 840;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.indLine = -1;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button33.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button34.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox8.Text = "";
            this.iPointShow = 1;
        }

        private void PointConfirm_Click(object sender, EventArgs e)
        {
            if (this.textBox8.Text == "")
            {
                int num1 = (int)MessageBox.Show("Code of Symbol isn't right", "Point's Symbol");
            }
            else
            {
                int num2 = 0;
                for (int index = 0; index < this.textBox8.Text.Length; ++index)
                {
                    if (!char.IsDigit(this.textBox8.Text[index]))
                    {
                        ++num2;
                        break;
                    }
                }
                if (num2 > 0)
                {
                    int num3 = (int)MessageBox.Show("Code of Symbol isn't number", "Point's Symbol");
                }
                else
                {
                    if (this.indLine <= -1)
                        return;
                    double tText = 0.0;
                    DllClass1.CheckText(this.textBox8.Text, out tText, out this.iCond);
                    if (this.iCond < 0)
                    {
                        int num4 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        this.myFin.nCode1Fin[this.indLine] = Convert.ToInt32(this.textBox8.Text);
                        this.myFin.kPntFin = this.kPntFin;
                        this.myFin.KeepPointFin();
                        this.iPointShow = 1;
                        double num5 = this.myFin.xPntFin[this.indLine];
                        double num6 = this.myFin.yPntFin[this.indLine];
                        int index1 = -1;
                        double num7 = 9999999.0;
                        for (int index2 = 0; index2 <= this.kPntPlus; ++index2)
                        {
                            double num8 = this.myFin.xPnt[index2] - num5;
                            double num9 = this.myFin.yPnt[index2] - num6;
                            double num10 = Math.Sqrt(num8 * num8 + num9 * num9);
                            if (num7 > num10)
                            {
                                num7 = num10;
                                index1 = index2;
                            }
                        }
                        if (num7 < 0.003)
                        {
                            this.myFin.nCode1[index1] = this.myFin.nCode1Fin[this.indLine];
                            this.myFin.KeepPoint();
                        }
                        this.kSel = -1;
                        this.kRcPnt = 0;
                        this.panel7.Invalidate();
                    }
                }
            }
        }

        private void AddInscript_Click(object sender, EventArgs e)
        {
            this.nProcess = 960;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.indLine = 0;
            this.label7.Visible = true;
            this.textBox7.Visible = true;
            this.radioButton1.Checked = true;
            this.button24.Visible = false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button33.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button34.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.comboBox1.Items.Add((object)"Black");
            this.comboBox1.Items.Add((object)"Red");
            this.comboBox1.Items.Add((object)"Green");
            this.comboBox1.Items.Add((object)"Blue");
            this.comboBox1.Items.Add((object)"Magenta");
            this.comboBox1.Items.Add((object)"Cyan");
            this.comboBox1.Items.Add((object)"Yellow");
            this.comboBox1.Items.Add((object)"Brown");
            this.comboBox1.Items.Add((object)"Gray");
            this.comboBox1.Items.Add((object)"Orange");
            this.comboBox1.Items.Add((object)"Pink");
            this.comboBox1.Items.Add((object)"Sienna");
            this.comboBox1.Items.Add((object)"Violet");
            this.comboBox1.Items.Add((object)"Gold");
            this.comboBox1.SelectedIndex = 0;
            this.iPolySymbol = 0;
            this.panel7.Invalidate();
        }

        private void AddMoving_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.myFin.fAddInscr))
            {
                int num = (int)MessageBox.Show("Inscriptions weren't added", "Additional Inscription");
            }
            else
            {
                this.nProcess = 970;
                this.nControl = 0;
                this.kSel = -1;
                this.kRcPnt = 0;
                this.indLine = 0;
                this.button24.Visible = false;
                this.button8.Visible = false;
                this.button9.Visible = false;
                this.button33.Visible = false;
                this.button12.Visible = false;
                this.button13.Visible = false;
                this.button34.Visible = false;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.iPolySymbol = 0;
                this.panel7.Invalidate();
            }
        }

        private void AddRemove_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.myFin.fAddInscr))
            {
                int num = (int)MessageBox.Show("Inscriptions weren't added", "Additional Inscription");
            }
            else
            {
                this.nProcess = 980;
                this.nControl = 0;
                this.kSel = -1;
                this.kRcPnt = 0;
                this.indLine = 0;
                this.button24.Visible = false;
                this.button8.Visible = false;
                this.button9.Visible = false;
                this.button33.Visible = false;
                this.button12.Visible = false;
                this.button13.Visible = false;
                this.button34.Visible = false;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.iPolySymbol = 0;
                this.panel7.Invalidate();
            }
        }

        private void PointsOnOff_Click(object sender, EventArgs e)
        {
            this.iPointShow = this.iPointShow <= 0 ? 1 : 0;
            this.panel7.Invalidate();
        }

        private void PolySymbol_Click(object sender, EventArgs e)
        {
            this.iPolySymbol = this.iPolySymbol <= 0 ? 1 : 0;
            this.iBordSymbol = this.iBordSymbol <= 0 ? 1 : 0;
            this.iCancelPoly = this.iCancelPoly <= 0 ? 1 : 0;
            this.panel7.Invalidate();
        }

        private void HeightsOnOff_Click(object sender, EventArgs e)
        {
            this.iHeightShow = this.iHeightShow <= 0 ? 1 : 0;
            this.panel7.Invalidate();
        }

        private void ContoursOnOff_Click(object sender, EventArgs e)
        {
            this.iContours = this.iContours <= 0 ? 1 : 0;
            this.panel7.Invalidate();
        }

        private void Exit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        private void HelpPoints_Click(object sender, EventArgs e)
        {
            int num = (int)new ListPntSign().ShowDialog((IWin32Window)this);
            this.iCodePoint = 0;
            if (File.Exists(this.myFin.fileAdd))
            {
                FileStream input = new FileStream(this.myFin.fileAdd, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.iCodePoint = binaryReader.ReadInt32();
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
            if (this.iCodePoint == 0)
                return;
            this.textBox8.Text = string.Format("{0}", (object)this.myFin.numbUser[this.iCodePoint]);
        }

        private void HelpLines_Click(object sender, EventArgs e)
        {
            int num = (int)new ListLineSign().ShowDialog((IWin32Window)this);
            this.iCodeLine = 0;
            this.iCond = 0;
            if (File.Exists(this.myFin.fileAdd))
            {
                FileStream input = new FileStream(this.myFin.fileAdd, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.iCodeLine = binaryReader.ReadInt32();
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
            if (this.iCodeLine == 0)
                return;
            this.textBox1.Text = string.Format("{0}", (object)this.myFin.n2Sign[this.iCodeLine]);
            this.textBox2.Text = "0.0";
            if (this.iCond != 8)
                return;
            this.textBox2.Text = "2.0";
        }

        private void HelpPolygons_Click(object sender, EventArgs e)
        {
            int num = (int)new ListPolySign().ShowDialog((IWin32Window)this);
            this.iCodePoly = 0;
            if (File.Exists(this.myFin.fileAdd))
            {
                FileStream input = new FileStream(this.myFin.fileAdd, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.iCodePoly = binaryReader.ReadInt32();
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
            if (this.iCodePoly == 0)
                return;
            this.textBox6.Text = string.Format("{0}", (object)this.myFin.npSign2[this.iCodePoly]);
        }

        private void ListItems_Click(object sender, EventArgs e)
        {
            this.nProcess = 410;
            this.kItemPoly = 0;
            this.hItemMax = 0;
            this.wItemMax = 0;
            if (File.Exists(this.myFin.fitemPoly))
            {
                FileStream input = new FileStream(this.myFin.fitemPoly, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    while (binaryReader.ReadString() != null)
                    {
                        int num1 = binaryReader.ReadInt32();
                        if (num1 == 0)
                        {
                            binaryReader.ReadDouble();
                            binaryReader.ReadDouble();
                            int num2 = binaryReader.ReadInt32();
                            int num3 = binaryReader.ReadInt32();
                            int num4 = binaryReader.ReadInt32();
                            if (num4 > 0)
                            {
                                for (int index = 1; index <= num4; ++index)
                                {
                                    binaryReader.ReadInt32();
                                    binaryReader.ReadInt32();
                                    binaryReader.ReadInt32();
                                }
                            }
                            ++this.kItemPoly;
                            if (num2 > this.wItemMax)
                                this.wItemMax = num2;
                            if (num3 > this.hItemMax)
                                this.hItemMax = num3;
                        }
                        if (num1 > 0)
                        {
                            binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            binaryReader.ReadString();
                            binaryReader.ReadDouble();
                            binaryReader.ReadDouble();
                            int num5 = binaryReader.ReadInt32();
                            int num6 = binaryReader.ReadInt32();
                            ++this.kItemPoly;
                            if (num5 > this.wItemMax)
                                this.wItemMax = num5;
                            if (num6 > this.hItemMax)
                                this.hItemMax = num6;
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
            this.kSelItem = 0;
            this.kInstall = 0;
            if (File.Exists(this.myFin.fPolyItem))
            {
                FileStream input = new FileStream(this.myFin.fPolyItem, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.kInstall = binaryReader.ReadInt32();
                    for (int index = 1; index <= this.kInstall; ++index)
                    {
                        this.myFin.nCent[index] = binaryReader.ReadInt32();
                        this.myFin.xLinParc[index] = binaryReader.ReadDouble();
                        this.myFin.yLinParc[index] = binaryReader.ReadDouble();
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
            int num = (int)new ListPolyItems().ShowDialog((IWin32Window)this);
            this.iPolySymbol = 1;
            this.panel7.Invalidate();
        }

        private void LastItem_Click(object sender, EventArgs e)
        {
            this.nProcess = 420;
            this.kSelItem = 0;
            this.kInstall = 0;
            if (File.Exists(this.myFin.fPolyItem))
            {
                FileStream input = new FileStream(this.myFin.fPolyItem, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.kInstall = binaryReader.ReadInt32();
                    for (int index = 1; index <= this.kInstall; ++index)
                    {
                        this.myFin.nCent[index] = binaryReader.ReadInt32();
                        this.myFin.xLinParc[index] = binaryReader.ReadDouble();
                        this.myFin.yLinParc[index] = binaryReader.ReadDouble();
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
            if (this.kInstall > 0)
            {
                --this.kInstall;
                if (File.Exists(this.myFin.fPolyItem))
                    File.Delete(this.myFin.fPolyItem);
                if (this.kInstall > 0)
                {
                    FileStream output = new FileStream(this.myFin.fPolyItem, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    binaryWriter.Write(this.kInstall);
                    for (int index = 1; index <= this.kInstall; ++index)
                    {
                        binaryWriter.Write(this.myFin.nCent[index]);
                        binaryWriter.Write(this.myFin.xLinParc[index]);
                        binaryWriter.Write(this.myFin.yLinParc[index]);
                    }
                    binaryWriter.Close();
                    output.Close();
                }
            }
            this.panel7.Invalidate();
        }

        private void AllItemDel_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.myFin.fPolyItem) && MessageBox.Show("Do you really want to Remove all items?", "All items Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                return;
            if (File.Exists(this.myFin.fPolyItem))
                File.Delete(this.myFin.fPolyItem);
            this.kInstall = 0;
            this.panel7.Invalidate();
        }

    }
}
