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
    public partial class ParcelAction : Form
    {
        private bool isDrag;
        private string sTmp = "";
        private string sName = "";
        private string[] sMess = new string[1000];
        private int iWidth;
        private int iHeight;
        private int xBegWin;
        private int yBegWin;
        private int xEndWin;
        private int yEndWin;
        private int nProcess;
        private int kPolyProj;
        private int kLineTopo;
        private int nControl;
        private int x1Box;
        private int y1Box;
        private int x2Box;
        private int y2Box;
        private int kNode;
        private int kRcPnt;
        private int kSel = -1;
        private int indPoly;
        private int kAdd;
        private int kPntPlus;
        private int kPntInput;
        private int kNodeParc;
        private int kLineParc;
        private int kPolyParc;
        private int kInParc;
        private int nAction;
        private int kSymbPnt;
        private int kLineAct;
        private int kPolyAct;
        private int kIntAct;
        private int kPoly;
        private int kNodeAct;
        private int iNodeActDraw = 1;
        private int kInside;
        private int idPoly;
        private int kPntProj;
        private int kProjInput;
        private int kTopoProj;
        private int iProjDraw = 1;
        private int iPointDraw;
        private int kPolyPrev;
        private int kPolyCancel;
        private int kLineCancel;
        private int iPolCancDraw;
        private int kParcDop;
        private int kLineNew;
        private int kLineProj;
        private int kLineFinal;
        private int kPolyFinal;
        private int kSymbLine;
        private int kPolySource;
        private int maxParcel;
        private int indSource;
        private int hSymbLine = 18;
        private int kPolySymb;
        private int hSymbPoly;
        private int iHeightShow;
        private int kLineInput;
        private int iParam;
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
        private double xCur;
        private double yCur;
        private double xaCur;
        private double yaCur;
        private double xbCur;
        private double ybCur;
        private double[] xArc = new double[1000];
        private double[] yArc = new double[1000];
        private double tolerance = 0.003;
        private double areaSel;
        private double areaInput;
        private double sCalc;
        private double sLeg;
        private double xPoint;
        private double yPoint;
        private double selRad;
        private double xSelRad;
        private double ySelRad;
        private double[] difArea = new double[1000];
        private int iCond;
        private int iGraphic;
        private int minArray = 999999;
        private int pixWid;
        private int pixHei;
        private double xCurMin;
        private double yCurMin;
        private double xCurMax;
        private double yCurMax;
        private double dx;
        private double dy;

        private MyGeodesy myAct = new MyGeodesy();

        public string fCurPnt { get; private set; }
        public string fCurHeig { get; private set; }
        public string fCurLine { get; private set; }

        public ParcelAction()
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
            this.button21.Visible = false;
            this.button30.Visible = false;
            this.groupBox6.Visible = false;
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
            this.button8.MouseHover += new EventHandler(this.button8_MouseHover);
            this.button8.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button9.MouseHover += new EventHandler(this.button9_MouseHover);
            this.button9.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button10.MouseHover += new EventHandler(this.button10_MouseHover);
            this.button10.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button11.MouseHover += new EventHandler(this.button11_MouseHover);
            this.button11.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button13.MouseHover += new EventHandler(this.button13_MouseHover);
            this.button13.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button12.MouseHover += new EventHandler(this.button12_MouseHover);
            this.button12.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button20.MouseHover += new EventHandler(this.button20_MouseHover);
            this.button20.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button24.MouseHover += new EventHandler(this.button24_MouseHover);
            this.button24.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button26.MouseHover += new EventHandler(this.button26_MouseHover);
            this.button26.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button31.MouseHover += new EventHandler(this.button31_MouseHover);
            this.button31.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button14.MouseHover += new EventHandler(this.button14_MouseHover);
            this.button14.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button15.MouseHover += new EventHandler(this.button15_MouseHover);
            this.button15.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.button22.MouseHover += new EventHandler(this.button22_MouseHover);
            this.button22.MouseLeave += new EventHandler(this.button1_MouseLeave);
            this.myAct.FilePath();
            this.FormLoad();
        }

        private void button1_MouseHover(object sender, EventArgs e) => this.label6.Text = "Закрыть окно";

        private void button1_MouseLeave(object sender, EventArgs e) => this.label6.Text = "";

        private void button2_MouseHover(object sender, EventArgs e) => this.label6.Text = "Нажмите кнопку. Зажмите левую кнопкой мыши и переместите мышь. После выбора области отпустите кнопку. Нажмите правую кнопку мыши для исходного положения";

        private void button3_MouseHover(object sender, EventArgs e) => this.label6.Text = "После нажатия на эту кнопку и отпустив левую кнопку мыши возле выбранной точки. Нажмите правую кнопку для исходного положения";

        private void button4_MouseHover(object sender, EventArgs e) => this.label6.Text = "После нажатия на эту кнопку и отпустив левую кнопку мыши возле выбранной точки. Нажмите правую кнопку для исходного положения";

        private void button5_MouseHover(object sender, EventArgs e) => this.label6.Text = "После нажатия на эту кнопку левую кнопкой мыши ведите вдоль экрана. Нажмите правую кнопку для возврата исходное положение";

        private void button6_MouseHover(object sender, EventArgs e) => this.label6.Text ="Нажмите Кнопку. Левой кнопкой мыши выберите: 1-Участок (метка), 2 - Линия. В области в области устоновки окна и нажмите 'Подтвердить' или 'Отменить'";

        private void button7_MouseHover(object sender, EventArgs e) => this.label6.Text ="Нажмите Кнопку. Левой кнопкой мыши выберите: 1-Участок (метка), 2 - Линия. В области в области устоновки окна и нажмите 'Подтвердить' или 'Отменить'";

        private void button8_MouseHover(object sender, EventArgs e) => this.label6.Text ="Нажмите Кнопку. Левой кнопкой мыши выберите: 1-Участок (метка), 2 - Линия. В области в области устоновки окна и нажмите 'Подтвердить' или 'Отменить'";

        private void button9_MouseHover(object sender, EventArgs e) => this.label6.Text ="Нажмите Кнопку. Левой кнопкой мыши выберите: 1-Участок (метка), 2 - Линия. В области в области устоновки окна и нажмите 'Подтвердить' или 'Отменить'";

        private void button10_MouseHover(object sender, EventArgs e) => this.label6.Text ="Нажмите Кнопку. Левой кнопкой мыши выберите: 1-Участок (метка), 2 - Линия. В области в области устоновки окна и нажмите 'Подтвердить' или 'Отменить'";

        private void button11_MouseHover(object sender, EventArgs e) => this.label6.Text ="Нажмите Кнопку. Левой кнопкой мыши выберите: 1-Участок (метка), 2 - Линия. В области в области устоновки окна и нажмите 'Подтвердить' или 'Отменить'";

        private void button13_MouseHover(object sender, EventArgs e) => this.label6.Text = "Нажмите кнопку для разделения участков со всеми проектными линиями";

        private void button12_MouseHover(object sender, EventArgs e) => this.label6.Text = "Нажмите кнопку. Нажмите Левой кнопкой мыши выберите одну подходящую проектную линию. Нажмите 'Продолжить' или 'Отменить выбор'";

        private void button20_MouseHover(object sender, EventArgs e) => this.label6.Text = "Нажмите кнопку. Нажмите Левой кнопкой мыши и выберите одну подходящую закрытую проектную линию. Нажмите 'Продолжить' или 'Отменить выбор'";

        private void button24_MouseHover(object sender, EventArgs e)
            => this.label6.Text = "Нажмите кнопку. Левой кнопкой мыши выберите > один соседний участок. После этого щелкните правой кнопкой мыши";

        private void button26_MouseHover(object sender, EventArgs e) 
            => this.label6.Text = "Нажмите кнопку для объединения всех участков";

        private void button31_MouseHover(object sender, EventArgs e)
            => this.label6.Text = "Нажмите кнопку. Левой кнопкой мыши выберите один подходящий внутренний участок";

        private void button14_MouseHover(object sender, EventArgs e) 
            => this.label6.Text = "Нажмите кнопку. Левой кнопкой мыши выберите соответствующий участок";

        private void button15_MouseHover(object sender, EventArgs e)
            => this.label6.Text = "Нажмите кнопку для удаления последнего действия";

        private void button22_MouseHover(object sender, EventArgs e)
            => this.label6.Text = "Нажмите кнопку для удаления всех действий";

        private void FormLoad()
        {
            this.minArray = 999999;
            DllClass1.doubleArray(this.xArc, ref this.minArray);
            DllClass1.doubleArray(this.yArc, ref this.minArray);
            this.xmin = 9999999.9;
            this.ymin = 9999999.9;
            this.xmax = -9999999.9;
            this.ymax = -9999999.9;
            DllClass1.SetColour(this.myAct.brColor, this.myAct.pnColor);
            DllClass1.PointSymbLoad(this.myAct.fsymbPnt, out this.kSymbPnt, this.myAct.numRec, this.myAct.numbUser, this.myAct.heiSymb);
            this.myAct.kSymbPnt = this.kSymbPnt;
            DllClass1.LineSymbolLoad(this.myAct.fsymbLine, out this.kSymbLine, out this.hSymbLine, this.myAct.sSymbLine, this.myAct.x1Line, this.myAct.y1Line, this.myAct.x2Line, this.myAct.y2Line, this.myAct.xDescr, this.myAct.yDescr, this.myAct.x1Dens, this.myAct.y1Dens, this.myAct.x1Sign, this.myAct.y1Sign, this.myAct.x2Sign, this.myAct.y2Sign, this.myAct.n1Sign, this.myAct.n2Sign, this.myAct.iStyle1, this.myAct.iStyle2, this.myAct.iWidth1, this.myAct.iWidth2, this.myAct.nColLine, this.myAct.nItem, this.myAct.itemLoc, this.myAct.nBaseSymb, this.myAct.sInscr, this.myAct.hInscr, this.myAct.iColInscr, this.myAct.iDensity);
            this.myAct.PolySymbolLoad(this.myAct.fsymbPoly, out this.kPolySymb, out this.hSymbPoly);
            this.myAct.LoadKeepSource(1);
            this.kPolySource = this.myAct.kPolySource;
            this.myAct.PointLoad();
            //this.myAct.PointLoad(fCurPnt, fCurHeig);
            this.kPntPlus = this.myAct.kPntPlus;
            this.kPntInput = this.myAct.kPntInput;
            if (this.kPntPlus > 0)
            {
                if (!File.Exists(this.myAct.fpointInscr))
                {
                    FileStream output = new FileStream(this.myAct.fpointInscr, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    binaryWriter.Write(this.kPntPlus);
                    for (int index = 0; index <= this.kPntPlus; ++index)
                    {
                        this.myAct.xPntInscr[index] = this.myAct.xPnt[index];
                        this.myAct.yPntInscr[index] = this.myAct.yPnt[index];
                        this.myAct.iHorVerPnt[index] = 0;
                        binaryWriter.Write(this.myAct.xPnt[index]);
                        binaryWriter.Write(this.myAct.yPnt[index]);
                        binaryWriter.Write(this.myAct.iHorVerPnt[index]);
                    }
                    binaryWriter.Close();
                    output.Close();
                }
                this.xmin = this.myAct.xmin;
                this.ymin = this.myAct.ymin;
                this.xmax = this.myAct.xmax;
                this.ymax = this.myAct.ymax;
                this.myAct.LoadKeepInscr(1);
            }
            this.myAct.LineLoad();
            //this.myAct.LineLoad(fCurLine);
            this.kLineInput = this.myAct.kLineInput;
            this.xmin = this.myAct.xmin;
            this.ymin = this.myAct.ymin;
            this.xmax = this.myAct.xmax;
            this.ymax = this.myAct.ymax;
            this.myAct.PolygonLoad(ref this.myAct.kPolyInside);
            this.kPoly = this.myAct.kPoly;
            this.myAct.LineTopoLoad();
            this.kLineTopo = this.myAct.kLineTopo;
            if (this.kLineTopo > 0)
            {
                int num = this.myAct.kl2[this.kLineTopo];
                for (int index = 1; index <= num; ++index)
                {
                    if (this.myAct.zLin[index] < this.xmin)
                        this.xmin = this.myAct.zLin[index];
                    if (this.myAct.zLin[index] > this.xmax)
                        this.xmax = this.myAct.zLin[index];
                    if (this.myAct.zPik[index] < this.ymin)
                        this.ymin = this.myAct.zPik[index];
                    if (this.myAct.zPik[index] > this.ymax)
                        this.ymax = this.myAct.zPik[index];
                }
            }
            this.myAct.PointProjLoad();
            this.kPntProj = this.myAct.kPntProj;
            this.kProjInput = this.myAct.kProjInput;
            this.myAct.PolyProjLoad();
            this.kPolyProj = this.myAct.kPolyProj;
            this.myAct.LineProjLoad();
            this.kLineProj = this.myAct.kLineProj;
            this.myAct.TopoProjLoad();
            this.kTopoProj = this.myAct.kTopoProj;
            this.myAct.LoadNode();
            this.kNode = this.myAct.kNodeTopo;
            this.myAct.KeepLoadAction(1);
            this.nAction = this.myAct.nAction;
            if (this.nAction > 0)
            {
                this.myAct.NodeActLoad(this.nAction);
                this.kNodeAct = this.myAct.kNodeAct;
                this.myAct.TopoActLoad(this.nAction);
                this.kLineAct = this.myAct.kLineAct;
                this.myAct.PolyActLoad(this.nAction);
                this.kPolyAct = this.myAct.kPolyAct;
                this.myAct.PolyCancelLoad(this.nAction);
                this.kPolyCancel = this.myAct.kPolyCancel;
                this.myAct.LineCancelLoad(this.nAction);
                this.kLineCancel = this.myAct.kLineCancel;
                this.myAct.LineNewLoad(this.nAction);
                this.kLineNew = this.myAct.kLineNew;
            }
            if (this.nAction == 0)
            {
                this.myAct.nAction = this.nAction;
                this.myAct.kLineTopo = this.kLineTopo;
                this.myAct.kPoly = this.kPoly;
                this.myAct.kNode = this.kNode;
                this.myAct.KeepActionZero();
                this.kLineAct = this.myAct.kLineAct;
                this.kPolyAct = this.myAct.kPolyAct;
                this.kIntAct = this.myAct.kIntAct;
                this.kNodeAct = this.myAct.kNodeAct;
            }
            if (this.kPolyAct > 0)
            {
                int kPnt = -1;
                for (int index = 1; index <= this.kPolyAct; ++index)
                {
                    ++kPnt;
                    this.myAct.nameDop[kPnt] = this.myAct.nameAct[index];
                }
                DllClass1.NewPointName(kPnt, this.myAct.nameDop, out this.maxParcel, out this.sTmp);
                --this.maxParcel;
            }
            if (this.maxParcel < 0)
                this.maxParcel = 0;
            if (this.nAction > 0)
            {
                string sMessOut = "";
                int k = 0;
                int num1 = 0;
                if (File.Exists(this.myAct.flistAction))
                {
                    FileStream input = new FileStream(this.myAct.flistAction, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        while ((this.sTmp = binaryReader.ReadString()) != null)
                        {
                            ++num1;
                            if (num1 != 1)
                            {
                                ++k;
                                this.sMess[k] = this.sTmp;
                                sMessOut = sMessOut + "\n" + this.sTmp;
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
                if (k > 3)
                {
                    DllClass1.ActionMessage(k, this.sMess, out sMessOut);
                    int num2 = (int)MessageBox.Show(sMessOut);
                }
            }
            this.xminCur = this.xmin;
            this.yminCur = this.ymin;
            this.xmaxCur = this.xmax;
            this.ymaxCur = this.ymax;
            DllClass1.CoorWin(this.xmin, this.ymin, this.xmax, this.ymax, this.iWidth, this.iHeight, out this.scaleToWin, out this.scaleToGeo, out this.xBegX, out this.yBegY, out this.xEndX, out this.yEndY, out this.xBegWin, out this.yBegWin, out this.xEndWin, out this.yEndWin, out this.iCond);
            if (this.iCond >= 0)
                return;
            this.iGraphic = 1;
        }

        public void ChangeAction()
        {
            DllClass1.NameActNode(this.kPntInput, this.myAct.namePnt, this.myAct.xPnt, this.myAct.yPnt, ref this.kNodeAct, ref this.myAct.nameNodeAct, ref this.myAct.xNodeAct, ref this.myAct.yNodeAct);
            ++this.nAction;
            this.myAct.nAction = this.nAction;
            this.myAct.KeepLoadAction(2);
            this.myAct.kNodeAct = this.kNodeAct;
            this.myAct.KeepNodeAct(this.nAction);
            this.myAct.kLineAct = this.kLineAct;
            this.myAct.KeepTopoAct(this.nAction);
            this.myAct.kPolyAct = this.kPolyAct;
            this.myAct.kIntAct = this.kIntAct;
            this.myAct.KeepPolyAct(this.nAction);
            this.myAct.kLineCancel = this.kLineCancel;
            this.myAct.KeepLineCancel(this.nAction);
            this.myAct.kPolyCancel = this.kPolyCancel;
            this.myAct.KeepPolyCancel(this.nAction);
            this.myAct.kLineNew = this.kLineNew;
            this.myAct.KeepLineNew(this.nAction);
        }

        public void ActionDelete()
        {
            string path1 = this.myAct.factNode + "." + string.Format("{0}", (object)this.nAction);
            if (File.Exists(path1))
                File.Delete(path1);
            string path2 = this.myAct.factLine + "." + string.Format("{0}", (object)this.nAction);
            if (File.Exists(path2))
                File.Delete(path2);
            string path3 = this.myAct.factPoly + "." + string.Format("{0}", (object)this.nAction);
            if (File.Exists(path3))
                File.Delete(path3);
            string path4 = this.myAct.flineCancel + "." + string.Format("{0}", (object)this.nAction);
            if (File.Exists(path4))
                File.Delete(path4);
            string path5 = this.myAct.fpolyCancel + "." + string.Format("{0}", (object)this.nAction);
            if (File.Exists(path5))
                File.Delete(path5);
            string path6 = this.myAct.flineNew + "." + string.Format("{0}", (object)this.nAction);
            if (File.Exists(path6))
                File.Delete(path6);
            string path7 = this.myAct.fpolyNew + "." + string.Format("{0}", (object)this.nAction);
            if (File.Exists(path7))
                File.Delete(path7);
            --this.nAction;
            this.myAct.nAction = this.nAction;
            this.myAct.KeepLoadAction(2);
            this.panel1.Text = "Готов ...";
        }

        public void PolyOrder()
        {
            if (this.kPolyAct < 2)
                return;
            for (int index1 = 1; index1 < this.kPolyAct; ++index1)
            {
                for (int index2 = index1 + 1; index2 <= this.kPolyAct; ++index2)
                {
                    if (this.myAct.aActCalc[index1] < this.myAct.aActCalc[index2])
                    {
                        string str = this.myAct.nameAct[index1];
                        double num1 = this.myAct.xAct[index1];
                        double num2 = this.myAct.yAct[index1];
                        double num3 = this.myAct.aActCalc[index1];
                        double num4 = this.myAct.aActLeg[index1];
                        int num5 = this.myAct.kActPoly1[index1];
                        int num6 = this.myAct.kActPoly2[index1];
                        int num7 = this.myAct.kPolyActInt[index1];
                        this.myAct.nameAct[index1] = this.myAct.nameAct[index2];
                        this.myAct.xAct[index1] = this.myAct.xAct[index2];
                        this.myAct.yAct[index1] = this.myAct.yAct[index2];
                        this.myAct.aActCalc[index1] = this.myAct.aActCalc[index2];
                        this.myAct.aActLeg[index1] = this.myAct.aActLeg[index2];
                        this.myAct.kActPoly1[index1] = this.myAct.kActPoly1[index2];
                        this.myAct.kActPoly2[index1] = this.myAct.kActPoly2[index2];
                        this.myAct.kPolyActInt[index1] = this.myAct.kPolyActInt[index2];
                        this.myAct.nameAct[index2] = str;
                        this.myAct.xAct[index2] = num1;
                        this.myAct.yAct[index2] = num2;
                        this.myAct.aActCalc[index2] = num3;
                        this.myAct.aActLeg[index2] = num4;
                        this.myAct.kActPoly1[index2] = num5;
                        this.myAct.kActPoly2[index2] = num6;
                        this.myAct.kPolyActInt[index2] = num7;
                    }
                }
            }
            int index3 = 0;
            for (int index4 = 1; index4 <= this.kPolyAct; ++index4)
            {
                int num8 = this.myAct.kActPoly1[index4];
                int num9 = this.myAct.kActPoly2[index4];
                this.myAct.nWork[index4] = num9 - num8 + 1;
                for (int index5 = num8; index5 <= num9; ++index5)
                {
                    ++index3;
                    this.myAct.xWork[index3] = this.myAct.xPolyAct[index5];
                    this.myAct.yWork[index3] = this.myAct.yPolyAct[index5];
                }
            }
            for (int index6 = 1; index6 <= index3; ++index6)
            {
                this.myAct.xPolyAct[index6] = this.myAct.xWork[index6];
                this.myAct.yPolyAct[index6] = this.myAct.yWork[index6];
            }
            this.myAct.kActPoly1[1] = 1;
            this.myAct.kActPoly2[1] = this.myAct.nWork[1];
            for (int index7 = 2; index7 <= this.kPolyAct; ++index7)
            {
                this.myAct.kActPoly1[index7] = this.myAct.kActPoly2[index7 - 1] + 1;
                this.myAct.kActPoly2[index7] = this.myAct.kActPoly2[index7 - 1] + this.myAct.nWork[index7];
            }
            this.kIntAct = 0;
            for (int index8 = 1; index8 <= this.kPolyAct; ++index8)
            {
                string str = Convert.ToString(index8);
                this.myAct.nameAct[index8] = str;
                int k = -1;
                int num10 = this.myAct.kActPoly1[index8];
                int num11 = this.myAct.kActPoly2[index8];
                for (int index9 = num10; index9 <= num11; ++index9)
                {
                    ++k;
                    this.myAct.xOut[k] = this.myAct.xPolyAct[index9];
                    this.myAct.yOut[k] = this.myAct.yPolyAct[index9];
                }
                if (DllClass1.in_out(k, ref this.myAct.xOut, ref this.myAct.yOut, this.xPoint, this.yPoint) > 0)
                    this.myAct.aActCalc[index8] = this.areaSel;
                this.myAct.kPolyActInt[index8] = 0;
                for (int index10 = index8 + 1; index10 <= this.kPolyAct; ++index10)
                {
                    if (DllClass1.in_out(k, ref this.myAct.xOut, ref this.myAct.yOut, this.myAct.xAct[index10], this.myAct.yAct[index10]) > 0)
                    {
                        this.myAct.kPolyActInt[index8] = this.myAct.kPolyActInt[index8] + 1;
                        ++this.kIntAct;
                        this.myAct.kIndexAct1[this.kIntAct] = index8;
                        this.myAct.kIndexAct2[this.kIntAct] = index10;
                    }
                }
            }
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
                DllClass1.XYtoWIN(this.myAct.xSel[index], this.myAct.ySel[index], this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                {
                    points[index].X = xWin;
                    points[index].Y = yWin;
                }
            }
            graphics.DrawLines(new Pen(Color.Sienna, 2f), points);
        }

        private void DrawPntProj(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int xWin = 0;
            int yWin = 0;
            int emSize = 6;
            if (this.kPntProj < 1)
                return;
            SolidBrush solidBrush = new SolidBrush(Color.Red);
            for (int index = 0; index <= this.kPntProj; ++index)
            {
                DllClass1.XYtoWIN(this.myAct.xProj[index], this.myAct.yProj[index], this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                {
                    graphics.FillRectangle((Brush)solidBrush, xWin - 2, yWin - 2, 4, 4);
                    graphics.DrawString(this.myAct.nameProj[index], new Font("Bold", (float)emSize), (Brush)solidBrush, (float)(xWin + emSize / 2), (float)(yWin - emSize));
                }
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (this.iGraphic > 0)
                return;
            if (this.nControl == 10)
                graphics.DrawRectangle(new Pen(Color.Green, 2f), this.RcDraw);
            if (this.kPntPlus > 0 && this.iPointDraw > 0)
                DllClass1.PointsDraw(e, this.myAct.fsymbPnt, this.iHeightShow, this.kPntPlus, this.myAct.namePnt, this.myAct.xPnt, this.myAct.yPnt, this.myAct.zPnt, this.myAct.xPntInscr, this.myAct.yPntInscr, this.myAct.iHorVerPnt, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myAct.nCode1, this.myAct.nCode2, this.kSymbPnt, this.myAct.numRec, this.myAct.numbUser, this.myAct.ixSqu, this.myAct.iySqu, this.myAct.nColor, this.myAct.brColor, this.myAct.pnColor);
            if (this.kPoly == 0 && this.kLineInput > 0)
            {
                this.iParam = 1;
                DllClass1.LineDraw(e, this.kLineInput, this.myAct.k1, this.myAct.k2, this.myAct.xLin, this.myAct.yLin, this.myAct.rRadLine, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myAct.pnColor, this.iParam);
            }
            if (this.kLineAct > 0)
            {
                this.iParam = 1;
                DllClass1.LineDraw(e, this.kLineAct, this.myAct.kActLine1, this.myAct.kActLine2, this.myAct.xLineAct, this.myAct.yLineAct, this.myAct.radAct, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myAct.pnColor, this.iParam);
            }
            if (this.kPolyAct > 0)
            {
                this.iParam = 8;
                DllClass1.LabelDraw(e, this.kPolyAct, this.myAct.nameAct, this.myAct.xAct, this.myAct.yAct, this.myAct.iHorVer, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myAct.brColor, this.iParam);
            }
            if (this.kNodeAct > 0 && this.iNodeActDraw > 0)
                DllClass1.DrawNodeAct(e, this.kNodeAct, this.myAct.nameNodeAct, this.myAct.xNodeAct, this.myAct.yNodeAct, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            if (this.kLineNew > 0 && this.iPolCancDraw > 0)
            {
                this.iParam = 2;
                DllClass1.LineDraw(e, this.kLineNew, this.myAct.kLinNew1, this.myAct.kLinNew2, this.myAct.xLinNew, this.myAct.yLinNew, this.myAct.RadNew, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myAct.pnColor, this.iParam);
            }
            if (this.kLineFinal > 0)
            {
                this.iParam = 1;
                DllClass1.LineDraw(e, this.kLineFinal, this.myAct.k1Fin, this.myAct.k2Fin, this.myAct.xFin, this.myAct.yFin, this.myAct.rRadFin, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myAct.pnColor, this.iParam);
            }
            if (this.kPolyFinal > 0)
            {
                this.iParam = 8;
                DllClass1.LabelDraw(e, this.kPolyFinal, this.myAct.namePolyFin, this.myAct.xLabFin, this.myAct.yLabFin, this.myAct.iHorVer, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myAct.brColor, this.iParam);
            }
            if (this.kPntProj > 0 && this.iPointDraw > 0)
                this.DrawPntProj(e);
            if (this.kPolyProj > 0 && this.iProjDraw > 0)
            {
                this.iParam = 4;
                DllClass1.LineDraw(e, this.kPolyProj, this.myAct.kPol1, this.myAct.kPol2, this.myAct.xPolProj, this.myAct.yPolProj, this.myAct.RadProj, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myAct.pnColor, this.iParam);
            }
            if (this.kTopoProj > 0 && this.kPolyProj == 0)
            {
                this.iParam = 4;
                DllClass1.LineDraw(e, this.kTopoProj, this.myAct.kPrt1, this.myAct.kPrt2, this.myAct.xLinTopo, this.myAct.yLinTopo, this.myAct.RadTopo, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myAct.pnColor, this.iParam);
            }
            if (this.iPolCancDraw > 0)
            {
                if (this.kPolyCancel > 0)
                {
                    int iParam = 3;
                    DllClass1.LabelDraw(e, this.kPolyCancel, this.myAct.nameCanc, this.myAct.xLabCanc, this.myAct.yLabCanc, this.myAct.iHorVer, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myAct.brColor, iParam);
                }
                if (this.kLineCancel > 0)
                {
                    this.iParam = 3;
                    DllClass1.LineDraw(e, this.kLineCancel, this.myAct.kLinCanc1, this.myAct.kLinCanc2, this.myAct.xLinCanc, this.myAct.yLinCanc, this.myAct.RadCanc, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.myAct.pnColor, this.iParam);
                }
            }
            this.DrawSelLine(e);
            if (this.nProcess == 210 || this.nProcess == 220 || this.nProcess == 230 || this.nProcess == 240 || this.nProcess == 250 || this.nProcess == 260 || this.nProcess == 280 || this.nProcess == 290)
            {
                if (this.kRcPnt > 0)
                {
                    for (int index = 1; index <= this.kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), this.RcPnt[index]);
                }
                this.DrawSelLine(e);
                DllClass1.DrawNode(e, this.kNode, this.myAct.nameNode, this.myAct.xNode, this.myAct.yNode, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            }
            if (this.nProcess == 300)
            {
                if (this.kRcPnt > 0)
                {
                    for (int index = 1; index <= this.kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), this.RcPnt[index]);
                }
                this.DrawSelLine(e);
            }
            if (this.nProcess == 310 || this.nProcess == 320 || this.nProcess == 410)
            {
                if (this.kRcPnt > 0)
                {
                    for (int index = 1; index <= this.kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), this.RcPnt[index]);
                }
                this.DrawSelLine(e);
            }
            Cursor.Current = Cursors.Default;
        }

        private void SelectBox_Click(object sender, EventArgs e)
        {
            this.nProcess = 0;
            this.nControl = 10;
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            this.nProcess = 0;
            this.nControl = 20;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            this.nProcess = 0;
            this.nControl = 30;
        }

        private void Move_Click(object sender, EventArgs e)
        {
            this.nProcess = 0;
            this.nControl = 40;
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
            if (e.Button == MouseButtons.Right)
            {
                if (this.nProcess == 0)
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
                if (this.nProcess == 310)
                {
                    if (this.kSel > 0)
                    {
                        this.sName = "";
                        this.sCalc = 0.0;
                        this.sLeg = 0.0;
                        double num5 = 0.0;
                        double num6 = 0.0;
                        int num7;
                        int num8 = num7 = 0;
                        int num9;
                        int num10 = num9 = 0;
                        double num11;
                        double num12 = num11 = 0.0;
                        int num13;
                        int num14 = num13 = 0;
                        if (this.kNodeAct > 0)
                        {
                            for (int index1 = 1; index1 <= this.kNodeAct; ++index1)
                            {
                                int num15 = 0;
                                for (int index2 = 0; index2 <= this.kPntPlus; ++index2)
                                {
                                    double num16 = this.myAct.xNodeAct[index1] - this.myAct.xPnt[index2];
                                    double num17 = this.myAct.yNodeAct[index1] - this.myAct.yPnt[index2];
                                    if (Math.Sqrt(num16 * num16 + num17 * num17) < this.tolerance)
                                    {
                                        ++num15;
                                        break;
                                    }
                                }
                                if (num15 <= 0)
                                {
                                    ++this.kPntPlus;
                                    this.myAct.namePnt[this.kPntPlus] = this.myAct.nameNodeAct[index1];
                                    this.myAct.xPnt[this.kPntPlus] = this.myAct.xNodeAct[index1];
                                    this.myAct.yPnt[this.kPntPlus] = this.myAct.yNodeAct[index1];
                                }
                            }
                        }
                        for (int index = 0; index <= this.kSel; ++index)
                        {
                            DllClass1.ParcelSelect(this.xArc[index], this.yArc[index], this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, out this.sName, out this.sCalc, out this.sLeg, out this.indPoly);
                            if (this.indPoly != 0)
                            {
                                this.xArc[index] = this.myAct.xAct[this.indPoly];
                                this.yArc[index] = this.myAct.yAct[this.indPoly];
                            }
                        }
                        for (int index3 = 0; index3 < this.kSel; ++index3)
                        {
                            for (int index4 = index3 + 1; index4 <= this.kSel; ++index4)
                            {
                                double num18 = this.xArc[index3] - this.xArc[index4];
                                double num19 = this.yArc[index3] - this.yArc[index4];
                                if (Math.Sqrt(num18 * num18 + num19 * num19) < this.tolerance)
                                {
                                    this.xArc[index4] = 0.0;
                                    this.yArc[index4] = 0.0;
                                }
                            }
                        }
                        int index5 = -1;
                        for (int index6 = 0; index6 <= this.kSel; ++index6)
                        {
                            if (this.xArc[index6] != 0.0 || this.yArc[index6] != 0.0)
                            {
                                ++index5;
                                this.xArc[index5] = this.xArc[index6];
                                this.yArc[index5] = this.yArc[index6];
                            }
                        }
                        this.kSel = index5;
                        if (this.kSel < 1)
                        {
                            int num20 = (int)MessageBox.Show("Number selected neighbour parcels < 2", "Parcels' Division and Unification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.kSel = -1;
                            this.kRcPnt = 0;
                            this.panel7.Invalidate();
                            return;
                        }
                        int index7 = 0;
                        num10 = 0;
                        for (int index8 = 0; index8 <= this.kSel; ++index8)
                        {
                            DllClass1.ParcelSelect(this.xArc[index8], this.yArc[index8], this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, out this.sName, out this.sCalc, out this.sLeg, out this.indPoly);
                            if (this.indPoly != 0)
                            {
                                int num21 = this.myAct.kActPoly1[this.indPoly];
                                int num22 = this.myAct.kActPoly2[this.indPoly];
                                int num23 = 0;
                                for (int index9 = num21; index9 <= num22; ++index9)
                                {
                                    ++num23;
                                    ++index7;
                                    this.myAct.xAdd[index7] = this.myAct.xPolyAct[index9];
                                    this.myAct.yAdd[index7] = this.myAct.yPolyAct[index9];
                                }
                                this.myAct.nameWork[index8] = this.sName;
                                this.myAct.nDop3[index8] = num23;
                            }
                        }
                        this.myAct.nDop1[0] = 1;
                        this.myAct.nDop2[0] = this.myAct.nDop3[0];
                        for (int index10 = 1; index10 <= this.kSel; ++index10)
                        {
                            this.myAct.nDop1[index10] = this.myAct.nDop2[index10 - 1] + 1;
                            this.myAct.nDop2[index10] = this.myAct.nDop2[index10 - 1] + this.myAct.nDop3[index10];
                        }
                        for (int index11 = 0; index11 <= this.kSel; ++index11)
                        {
                            int num24 = this.myAct.nDop1[index11];
                            int num25 = this.myAct.nDop2[index11];
                            int num26 = 0;
                            for (int index12 = num24; index12 < num25; ++index12)
                            {
                                for (int index13 = 0; index13 <= this.kSel; ++index13)
                                {
                                    if (index13 != index11)
                                    {
                                        int num27 = this.myAct.nDop1[index13];
                                        int num28 = this.myAct.nDop2[index13];
                                        for (int index14 = num27; index14 < num28; ++index14)
                                        {
                                            double num29 = this.myAct.xAdd[index12] - this.myAct.xAdd[index14];
                                            double num30 = this.myAct.yAdd[index12] - this.myAct.yAdd[index14];
                                            if (Math.Sqrt(num29 * num29 + num30 * num30) < this.tolerance)
                                                ++num26;
                                        }
                                    }
                                }
                            }
                            if (num26 < 2)
                            {
                                this.xArc[index11] = 0.0;
                                this.yArc[index11] = 0.0;
                            }
                        }
                        int index15 = -1;
                        for (int index16 = 0; index16 <= this.kSel; ++index16)
                        {
                            if (this.xArc[index16] != 0.0 || this.yArc[index16] != 0.0)
                            {
                                ++index15;
                                this.xArc[index15] = this.xArc[index16];
                                this.yArc[index15] = this.yArc[index16];
                            }
                        }
                        this.kSel = index15;
                        if (this.kSel < 1)
                        {
                            int num31 = (int)MessageBox.Show("Number selected neighbour parcels < 2", "Parcels' Division and Unification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.kSel = -1;
                            this.kRcPnt = 0;
                            this.panel7.Invalidate();
                            return;
                        }
                        num7 = 0;
                        int index17 = 0;
                        int kLine = 0;
                        int index18 = 0;
                        for (int index19 = 0; index19 <= this.kSel; ++index19)
                        {
                            DllClass1.ParcelSelect(this.xArc[index19], this.yArc[index19], this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, out this.sName, out this.sCalc, out this.sLeg, out this.indPoly);
                            if (this.indPoly != 0)
                            {
                                num5 += this.sLeg;
                                num6 += this.sCalc;
                                int num32 = this.myAct.kActPoly1[this.indPoly];
                                int num33 = this.myAct.kActPoly2[this.indPoly];
                                this.kAdd = -1;
                                for (int index20 = num32; index20 <= num33; ++index20)
                                {
                                    ++this.kAdd;
                                    this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index20];
                                    this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index20];
                                }
                                ++index18;
                                this.myAct.nameParc[index18] = this.sName;
                                this.myAct.xParc[index18] = this.myAct.xAct[this.indPoly];
                                this.myAct.yParc[index18] = this.myAct.yAct[this.indPoly];
                                this.myAct.aParcCalc[index18] = this.sCalc;
                                this.myAct.aParcLeg[index18] = this.sLeg;
                                int kin = 0;
                                int kLin = 0;
                                DllClass1.ParcelLine(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, kin, ref this.myAct.kin1, ref this.myAct.kin2, ref this.myAct.xActInt, ref this.myAct.yActInt, this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, out kLin, ref this.myAct.rWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.nWork, this.tolerance);
                                if (kLin > 0)
                                {
                                    num8 = 0;
                                    for (int index21 = 1; index21 <= kLin; ++index21)
                                    {
                                        int num34 = 0;
                                        int num35 = this.myAct.nWork1[index21];
                                        int num36 = this.myAct.nWork2[index21];
                                        for (int index22 = num35; index22 <= num36; ++index22)
                                        {
                                            ++num34;
                                            ++index17;
                                            this.myAct.xDop[index17] = this.myAct.xWork[index22];
                                            this.myAct.yDop[index17] = this.myAct.yWork[index22];
                                        }
                                        ++kLine;
                                        this.myAct.nDop3[kLine] = num34;
                                        this.myAct.zDop[kLine] = this.myAct.rWork[index21];
                                    }
                                }
                            }
                        }
                        if (index18 > 0)
                        {
                            this.kPolyCancel = index18;
                            for (int index23 = 1; index23 <= this.kPolyCancel; ++index23)
                            {
                                this.myAct.nameCanc[index23] = this.myAct.nameParc[index23];
                                this.myAct.xLabCanc[index23] = this.myAct.xParc[index23];
                                this.myAct.yLabCanc[index23] = this.myAct.yParc[index23];
                                this.myAct.aCalcCanc[index23] = this.myAct.aParcCalc[index23];
                                this.myAct.aLegCanc[index23] = this.myAct.aParcLeg[index23];
                            }
                        }
                        this.myAct.nDop1[1] = 1;
                        this.myAct.nDop2[1] = this.myAct.nDop3[1];
                        for (int index24 = 2; index24 <= kLine; ++index24)
                        {
                            this.myAct.nDop1[index24] = this.myAct.nDop2[index24 - 1] + 1;
                            this.myAct.nDop2[index24] = this.myAct.nDop2[index24 - 1] + this.myAct.nDop3[index24];
                        }
                        DllClass1.CommonLine(kLine, ref this.myAct.zDop, ref this.myAct.nDop1, ref this.myAct.nDop2, ref this.myAct.xDop, ref this.myAct.yDop, out this.kLineCancel, ref this.myAct.RadCanc, ref this.myAct.kLinCanc1, ref this.myAct.kLinCanc2, ref this.myAct.xLinCanc, ref this.myAct.yLinCanc, ref this.myAct.nWork, this.tolerance);
                        if (this.kLineCancel > 0)
                            DllClass1.CommonDelete(ref this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, this.kLineCancel, ref this.myAct.RadCanc, ref this.myAct.kLinCanc1, ref this.myAct.kLinCanc2, ref this.myAct.xLinCanc, ref this.myAct.yLinCanc, ref this.myAct.nWork, this.tolerance);
                        this.kPolyAct = 0;
                        this.kIntAct = 0;
                        this.panel1.Text = "Пожалуйста подождите....Построение полигональных топографических знаков";
                        DllClass1.LinesToPoly(this.tolerance, this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, this.kNodeAct, ref this.myAct.xNodeAct, ref this.myAct.yNodeAct, out this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.nSymbPoly, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out this.kIntAct, ref this.myAct.kIndexAct, ref this.myAct.kIndexAct1, ref this.myAct.kIndexAct2, ref this.myAct.nWork, ref this.myAct.indInter, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.pWork, ref this.myAct.rWork, ref this.myAct.zDop, this.panel1);
                        if (this.kPolyAct == 0)
                            return;
                        this.myAct.PolyActPrev(ref this.myAct.kPolyInside, this.nAction);
                        this.kPolyPrev = this.myAct.kPolyPrev;
                        DllClass1.ActionCompare(this.kPolyPrev, ref this.myAct.xLab, ref this.myAct.yLab, ref this.myAct.areaPol, ref this.myAct.areaLeg, ref this.myAct.kt1, ref this.myAct.kt2, ref this.myAct.xPol, ref this.myAct.yPol, this.kPolyAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, ref this.myAct.xWork, ref this.myAct.yWork);
                        this.PolyOrder();
                        this.panel1.Text = "Пожалуйста подождите....Определение подписи(метки) полигона";
                        DllClass1.KeepPolyLabel(this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xDop, ref this.myAct.yDop, ref this.myAct.zDop, ref this.myAct.nDop1, ref this.myAct.nDop2, ref this.myAct.nDop3, this.panel1);
                        int index25 = 0;
                        for (int index26 = 1; index26 <= this.kPolyAct; ++index26)
                        {
                            if (Math.Abs(this.myAct.aActCalc[index26] - num6) <= 0.1)
                            {
                                int num37 = this.myAct.kActPoly1[index26];
                                int num38 = this.myAct.kActPoly2[index26];
                                this.kAdd = -1;
                                for (int index27 = num37; index27 <= num38; ++index27)
                                {
                                    ++this.kAdd;
                                    this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index27];
                                    this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index27];
                                }
                                int num39 = 0;
                                if (index18 > 0)
                                {
                                    for (int index28 = 1; index28 <= index18; ++index28)
                                    {
                                        if (DllClass1.in_out(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.myAct.xParc[index28], this.myAct.yParc[index28]) > 0)
                                            ++num39;
                                    }
                                }
                                if (num39 > 0 && num39 == index18)
                                {
                                    index25 = index26;
                                    break;
                                }
                            }
                        }
                        if (index25 > 0)
                        {
                            this.myAct.aActLeg[index25] = num5;
                            int num40 = this.myAct.kActPoly1[index25];
                            int num41 = this.myAct.kActPoly2[index25];
                            this.kAdd = -1;
                            for (int index29 = num40; index29 <= num41; ++index29)
                            {
                                ++this.kAdd;
                                this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index29];
                                this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index29];
                            }
                            for (int index30 = 1; index30 <= this.kNodeAct; ++index30)
                            {
                                if (DllClass1.in_out(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.myAct.xNodeAct[index30], this.myAct.yNodeAct[index30]) > 0)
                                {
                                    int num42 = 0;
                                    for (int index31 = 1; index31 <= this.kLineAct; ++index31)
                                    {
                                        int index32 = this.myAct.kActLine1[index31];
                                        int index33 = this.myAct.kActLine2[index31];
                                        double num43 = this.myAct.xLineAct[index32] - this.myAct.xNodeAct[index30];
                                        double num44 = this.myAct.yLineAct[index32] - this.myAct.yNodeAct[index30];
                                        if (Math.Sqrt(num43 * num43 + num44 * num44) < this.tolerance)
                                        {
                                            ++num42;
                                            break;
                                        }
                                        double num45 = this.myAct.xLineAct[index33] - this.myAct.xNodeAct[index30];
                                        double num46 = this.myAct.yLineAct[index33] - this.myAct.yNodeAct[index30];
                                        if (Math.Sqrt(num45 * num45 + num46 * num46) < this.tolerance)
                                        {
                                            ++num42;
                                            break;
                                        }
                                    }
                                    if (num42 <= 0)
                                    {
                                        int num47 = 0;
                                        for (int index34 = 0; index34 <= this.kAdd; ++index34)
                                        {
                                            double num48 = this.myAct.xAdd[index34] - this.myAct.xNodeAct[index30];
                                            double num49 = this.myAct.yAdd[index34] - this.myAct.yNodeAct[index30];
                                            if (Math.Sqrt(num48 * num48 + num49 * num49) < this.tolerance)
                                            {
                                                ++num47;
                                                break;
                                            }
                                        }
                                        if (num47 <= 0)
                                        {
                                            this.myAct.xNodeAct[index30] = 0.0;
                                            this.myAct.yNodeAct[index30] = 0.0;
                                        }
                                    }
                                }
                            }
                            int index35 = 0;
                            for (int index36 = 1; index36 <= this.kNodeAct; ++index36)
                            {
                                if (this.myAct.xNodeAct[index36] != 0.0 || this.myAct.yNodeAct[index36] != 0.0)
                                {
                                    ++index35;
                                    this.myAct.nameNodeAct[index35] = this.myAct.nameNodeAct[index36];
                                    this.myAct.xNodeAct[index35] = this.myAct.xNodeAct[index36];
                                    this.myAct.yNodeAct[index35] = this.myAct.yNodeAct[index36];
                                }
                            }
                            this.kNodeAct = index35;
                        }
                        if (this.maxParcel < 0)
                            this.maxParcel = 0;
                        int kNew = 0;
                        DllClass1.ParcNewName(this.maxParcel, this.kPolySource, this.myAct.nameSource, this.myAct.xLabSource, this.myAct.yLabSource, this.myAct.arCalcSource, this.myAct.arLegSource, this.myAct.k1Source, this.myAct.k2Source, this.myAct.xSource, this.myAct.ySource, this.kPolyAct, this.myAct.nameAct, this.myAct.xAct, this.myAct.yAct, this.myAct.aActCalc, this.myAct.aActLeg, out kNew, this.myAct.nameDop, this.myAct.xDop, this.myAct.yDop, this.myAct.xWork, this.myAct.yWork, this.myAct.xSpot, this.myAct.ySpot);
                        if (this.maxParcel < 0)
                            this.maxParcel = 0;
                        if (kNew > 0)
                        {
                            if (!File.Exists(this.myAct.flistAction))
                            {
                                int num50 = (int)MessageBox.Show("Вернуться к Построение полигональных топографических знаков", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            FileStream output = new FileStream(this.myAct.flistAction, FileMode.Append);
                            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                            this.sTmp = string.Format("{0}", (object)this.nProcess) + "   0";
                            binaryWriter.Write(this.sTmp);
                            this.sTmp = this.myAct.nameDop[1] + "  " + string.Format("{0:F4}", (object)this.myAct.xWork[1]) + "  " + string.Format("{0:F4}", (object)this.myAct.yWork[1]);
                            binaryWriter.Write(this.sTmp);
                            for (int index37 = 1; index37 <= this.kPolyCancel; ++index37)
                            {
                                this.sTmp = this.myAct.nameCanc[index37] + "  " + string.Format("{0:F4}", (object)this.myAct.aCalcCanc[index37]) + "  " + string.Format("{0:F4}", (object)this.myAct.aLegCanc[index37]);
                                binaryWriter.Write(this.sTmp);
                            }
                            this.sTmp = "0";
                            binaryWriter.Write(this.sTmp);
                            binaryWriter.Close();
                            output.Close();
                            DllClass1.ParcelSelect(this.myAct.xDop[1], this.myAct.yDop[1], this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, out this.sName, out this.sCalc, out this.sLeg, out this.indPoly);
                            if (this.indPoly == 0)
                                return;
                            int num51 = this.myAct.kActPoly1[this.indPoly];
                            int num52 = this.myAct.kActPoly2[this.indPoly];
                            this.kAdd = -1;
                            for (int index38 = num51; index38 <= num52; ++index38)
                            {
                                ++this.kAdd;
                                this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index38];
                                this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index38];
                            }
                            int index39 = this.myAct.k2Source[this.kPolySource];
                            int num53 = 0;
                            for (int index40 = 0; index40 <= this.kAdd; ++index40)
                            {
                                ++num53;
                                ++index39;
                                this.myAct.xSource[index39] = this.myAct.xAdd[index40];
                                this.myAct.ySource[index39] = this.myAct.yAdd[index40];
                            }
                            ++this.kPolySource;
                            this.myAct.nameSource[this.kPolySource] = this.myAct.nameDop[1];
                            this.myAct.xLabSource[this.kPolySource] = this.myAct.xDop[1];
                            this.myAct.yLabSource[this.kPolySource] = this.myAct.yDop[1];
                            this.myAct.arCalcSource[this.kPolySource] = this.myAct.xWork[1];
                            this.myAct.arLegSource[this.kPolySource] = this.myAct.yWork[1];
                            this.myAct.k1Source[this.kPolySource] = this.myAct.k2Source[this.kPolySource - 1] + 1;
                            this.myAct.k2Source[this.kPolySource] = this.myAct.k2Source[this.kPolySource - 1] + num53;
                            this.myAct.kPolySource = this.kPolySource;
                            this.myAct.LoadKeepSource(2);
                            int kPnt = -1;
                            for (int index41 = 1; index41 <= this.kPolyAct; ++index41)
                            {
                                ++kPnt;
                                this.myAct.nameAdd[kPnt] = this.myAct.nameAct[index41];
                            }
                            DllClass1.NewPointName(kPnt, this.myAct.nameAdd, out this.maxParcel, out this.sTmp);
                            --this.maxParcel;
                        }
                        this.ChangeAction();
                        this.panel1.Text = "Готов...";
                        this.kSel = -1;
                        this.kRcPnt = 0;
                        this.nProcess = 0;
                        this.nControl = 0;
                        this.panel7.Invalidate();
                    }
                    if (File.Exists(this.myAct.flineFinal))
                        File.Delete(this.myAct.flineFinal);
                    this.kLineFinal = 0;
                    if (File.Exists(this.myAct.fpolyFinal))
                        File.Delete(this.myAct.fpolyFinal);
                    this.kPolyFinal = 0;
                }
            }
            if (e.Button != MouseButtons.Left || this.nProcess != 210 && this.nProcess != 220 && this.nProcess != 230 && this.nProcess != 300 && this.nProcess != 240 && this.nProcess != 250 && this.nProcess != 260 && this.nProcess != 280 && this.nProcess != 290 && this.nProcess != 310 && this.nProcess != 410)
                return;
            DllClass1.WINtoXY(e.X, e.Y, this.scaleToGeo, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out this.xCur, out this.yCur);
            ++this.kSel;
            if (this.kSel > this.minArray)
            {
                int num = (int)MessageBox.Show("Too much selection");
            }
            else
            {
                this.xArc[this.kSel] = this.xCur;
                this.yArc[this.kSel] = this.yCur;
                ++this.kRcPnt;
                this.RcPnt[this.kRcPnt].X = e.X;
                this.RcPnt[this.kRcPnt].Y = e.Y;
            }
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
            if (this.nProcess == 210 || this.nProcess == 220 || this.nProcess == 230 || this.nProcess == 300 || this.nProcess == 240 || this.nProcess == 250 || this.nProcess == 260 || this.nProcess == 280 || this.nProcess == 290)
            {
                this.RcPnt[this.kRcPnt].Width = 4;
                this.RcPnt[this.kRcPnt].Height = 4;
                this.panel7.Invalidate(this.RcPnt[this.kRcPnt]);
            }
            if (this.nProcess == 310 || this.nProcess == 410)
            {
                this.RcPnt[this.kRcPnt].Width = 5;
                this.RcPnt[this.kRcPnt].Height = 5;
                this.panel7.Invalidate(this.RcPnt[this.kRcPnt]);
            }
            if ((this.nProcess == 210 || this.nProcess == 220 || this.nProcess == 230 || this.nProcess == 240 || this.nProcess == 250 || this.nProcess == 260) && this.kSel == 1)
            {
                this.sName = "";
                this.sCalc = 0.0;
                this.sLeg = 0.0;
                DllClass1.ParcelSelect(this.xArc[0], this.yArc[0], this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, out this.sName, out this.sCalc, out this.sLeg, out this.indPoly);
                if (this.indPoly == 0)
                    return;
                DllClass1.SelectSource(this.kPolySource, this.myAct.xLabSource, this.myAct.yLabSource, this.myAct.arCalcSource, this.myAct.arLegSource, this.myAct.xAct[this.indPoly], this.myAct.yAct[this.indPoly], this.myAct.aActCalc[this.indPoly], this.myAct.aActLeg[this.indPoly], out this.indSource);
                int num1 = this.myAct.kActPoly1[this.indPoly];
                int num2 = this.myAct.kActPoly2[this.indPoly];
                this.kAdd = -1;
                for (int index = num1; index <= num2; ++index)
                {
                    ++this.kAdd;
                    this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index];
                    this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index];
                }
                double num3 = 0.0;
                double num4 = 0.0;
                int kin = 0;
                int kLin = 0;
                if (this.myAct.kPolyActInt[this.indPoly] > 0)
                {
                    for (int index1 = 1; index1 <= this.kPolyAct; ++index1)
                    {
                        if (index1 != this.indPoly && DllClass1.in_out(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.myAct.xAct[index1], this.myAct.yAct[index1]) != 0 && this.myAct.aActCalc[index1] < this.myAct.aActCalc[this.indPoly])
                        {
                            num3 += this.myAct.aActCalc[index1];
                            num4 += this.myAct.aActLeg[index1];
                            int num5 = this.myAct.kActPoly1[index1];
                            int num6 = this.myAct.kActPoly2[index1];
                            int num7 = 0;
                            for (int index2 = num5; index2 <= num6; ++index2)
                            {
                                ++kLin;
                                ++num7;
                                this.myAct.xActInt[kLin] = this.myAct.xPolyAct[index2];
                                this.myAct.yActInt[kLin] = this.myAct.yPolyAct[index2];
                            }
                            ++kin;
                            this.myAct.kParc[kin] = num7;
                        }
                    }
                }
                if (kin > 0)
                {
                    this.myAct.kin1[1] = 1;
                    this.myAct.kin2[1] = this.myAct.kParc[1];
                    if (kin > 1)
                    {
                        for (int index = 2; index <= kin; ++index)
                        {
                            this.myAct.kin1[index] = this.myAct.kin2[index - 1] + 1;
                            this.myAct.kin2[index] = this.myAct.kin2[index - 1] + this.myAct.kParc[index];
                        }
                    }
                }
                DllClass1.ParcelLine(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, kin, ref this.myAct.kin1, ref this.myAct.kin2, ref this.myAct.xActInt, ref this.myAct.yActInt, this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, out kLin, ref this.myAct.rWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.nWork, this.tolerance);
                DllClass1.SelectLine(this.xArc[1], this.yArc[1], this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, kLin, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.rWork, ref this.myAct.xWork, ref this.myAct.yWork, out this.selRad, out this.xSelRad, out this.ySelRad, out this.kSel, ref this.myAct.xSel, ref this.myAct.ySel, this.tolerance, ref this.myAct.xDop, ref this.myAct.yDop, ref this.myAct.zDop);
                this.button19.Visible = true;
                this.button29.Visible = true;
                this.textBox4.Visible = true;
                this.label4.Visible = true;
                this.label4.Text = "Area, sq.m";
                if (this.nProcess == 220)
                    this.label4.Text = "Distance,м";
                if (this.nProcess == 230 || this.nProcess == 260)
                    this.label4.Text = "Процент,%";
                if (this.nProcess == 250)
                {
                    this.label4.Visible = false;
                    this.textBox4.Visible = false;
                }
                this.textBox1.Text = this.sName;
                this.sTmp = string.Format("{0:F4}", (object)this.sCalc);
                this.textBox2.Text = this.sTmp;
                this.sTmp = string.Format("{0:F4}", (object)this.sLeg);
                this.textBox3.Text = this.sTmp;
                this.label5.Visible = false;
                this.textBox5.Visible = false;
                this.textBox6.Visible = false;
                if (num3 > 0.0)
                {
                    this.label5.Visible = true;
                    this.textBox5.Visible = true;
                    this.textBox6.Visible = true;
                    this.sTmp = string.Format("{0:F4}", (object)num3);
                    this.textBox5.Text = this.sTmp;
                    this.sTmp = string.Format("{0:F4}", (object)num4);
                    this.textBox6.Text = this.sTmp;
                }
                this.panel7.Invalidate();
            }
            if ((this.nProcess == 280 || this.nProcess == 290) && this.kSel == 0)
            {
                double dist;
                if (this.kTopoProj > 0)
                {
                    double num8 = 9999999.9;
                    int index3 = 0;
                    int ip;
                    for (int index4 = 1; index4 <= this.kTopoProj; ++index4)
                    {
                        int num9 = this.myAct.kPrt1[index4];
                        int num10 = this.myAct.kPrt2[index4];
                        for (int index5 = num9 + 1; index5 <= num10; ++index5)
                        {
                            DllClass1.DistPnt(this.xArc[0], this.yArc[0], this.myAct.xLinTopo[index5 - 1], this.myAct.yLinTopo[index5 - 1], this.myAct.xLinTopo[index5], this.myAct.yLinTopo[index5], out dist, out ip, out double _, out double _);
                            if (ip > 0 && num8 > dist)
                            {
                                num8 = dist;
                                index3 = 1;
                                this.myAct.nDat[index3] = index4;
                                this.kSel = -1;
                                for (int index6 = num9; index6 <= num10; ++index6)
                                {
                                    ++this.kSel;
                                    this.myAct.xSel[this.kSel] = this.myAct.xLinTopo[index6];
                                    this.myAct.ySel[this.kSel] = this.myAct.yLinTopo[index6];
                                }
                            }
                        }
                    }
                    for (int index7 = 1; index7 <= this.kTopoProj; ++index7)
                    {
                        int num11 = 0;
                        for (int index8 = 1; index8 <= this.kTopoProj; ++index8)
                        {
                            ip = 0;
                            for (int index9 = 1; index9 <= index3; ++index9)
                            {
                                if (this.myAct.nDat[index9] == index8)
                                {
                                    ++ip;
                                    break;
                                }
                            }
                            if (ip <= 0)
                            {
                                int index10 = this.myAct.kPrt1[index8];
                                int index11 = this.myAct.kPrt2[index8];
                                double num12 = this.myAct.xSel[this.kSel] - this.myAct.xLinTopo[index10];
                                double num13 = this.myAct.ySel[this.kSel] - this.myAct.yLinTopo[index10];
                                double num14 = Math.Sqrt(num12 * num12 + num13 * num13);
                                double num15 = this.myAct.xSel[this.kSel] - this.myAct.xLinTopo[index11];
                                double num16 = this.myAct.ySel[this.kSel] - this.myAct.yLinTopo[index11];
                                double num17 = Math.Sqrt(num15 * num15 + num16 * num16);
                                if (num14 < this.tolerance)
                                {
                                    for (int index12 = index10 + 1; index12 <= index11; ++index12)
                                    {
                                        ++this.kSel;
                                        this.myAct.xSel[this.kSel] = this.myAct.xLinTopo[index12];
                                        this.myAct.ySel[this.kSel] = this.myAct.yLinTopo[index12];
                                    }
                                    ++index3;
                                    this.myAct.nDat[index3] = index8;
                                    double num18 = this.myAct.xSel[0] - this.myAct.xSel[this.kSel];
                                    double num19 = this.myAct.ySel[0] - this.myAct.ySel[this.kSel];
                                    dist = Math.Sqrt(num18 * num18 + num19 * num19);
                                    if (dist < this.tolerance)
                                    {
                                        ++num11;
                                        break;
                                    }
                                }
                                if (num17 < this.tolerance)
                                {
                                    int index13 = index11;
                                    for (int index14 = index10 + 1; index14 <= index11; ++index14)
                                    {
                                        --index13;
                                        ++this.kSel;
                                        this.myAct.xSel[this.kSel] = this.myAct.xLinTopo[index13];
                                        this.myAct.ySel[this.kSel] = this.myAct.yLinTopo[index13];
                                    }
                                    ++index3;
                                    this.myAct.nDat[index3] = index8;
                                    double num20 = this.myAct.xSel[0] - this.myAct.xSel[this.kSel];
                                    double num21 = this.myAct.ySel[0] - this.myAct.ySel[this.kSel];
                                    dist = Math.Sqrt(num20 * num20 + num21 * num21);
                                    if (dist < this.tolerance)
                                    {
                                        ++num11;
                                        break;
                                    }
                                }
                            }
                        }
                        if (num11 <= 0)
                        {
                            for (int index15 = 1; index15 <= this.kTopoProj; ++index15)
                            {
                                ip = 0;
                                for (int index16 = 1; index16 <= index3; ++index16)
                                {
                                    if (this.myAct.nDat[index16] == index15)
                                    {
                                        ++ip;
                                        break;
                                    }
                                }
                                if (ip <= 0)
                                {
                                    int index17 = this.myAct.kPrt1[index15];
                                    int index18 = this.myAct.kPrt2[index15];
                                    double num22 = this.myAct.xSel[0] - this.myAct.xLinTopo[index17];
                                    double num23 = this.myAct.ySel[0] - this.myAct.yLinTopo[index17];
                                    double num24 = Math.Sqrt(num22 * num22 + num23 * num23);
                                    double num25 = this.myAct.xSel[0] - this.myAct.xLinTopo[index18];
                                    double num26 = this.myAct.ySel[0] - this.myAct.yLinTopo[index18];
                                    double num27 = Math.Sqrt(num25 * num25 + num26 * num26);
                                    if (num24 < this.tolerance)
                                    {
                                        int index19 = -1;
                                        int index20 = index18 + 1;
                                        for (int index21 = index17; index21 <= index18; ++index21)
                                        {
                                            --index20;
                                            ++index19;
                                            this.myAct.xDop[index19] = this.myAct.xLinTopo[index20];
                                            this.myAct.yDop[index19] = this.myAct.yLinTopo[index20];
                                        }
                                        for (int index22 = 1; index22 <= this.kSel; ++index22)
                                        {
                                            ++index19;
                                            this.myAct.xDop[index19] = this.myAct.xSel[index22];
                                            this.myAct.yDop[index19] = this.myAct.ySel[index22];
                                        }
                                        this.kSel = index19;
                                        for (int index23 = 0; index23 <= this.kSel; ++index23)
                                        {
                                            this.myAct.xSel[index23] = this.myAct.xDop[index23];
                                            this.myAct.ySel[index23] = this.myAct.yDop[index23];
                                        }
                                        ++index3;
                                        this.myAct.nDat[index3] = index15;
                                        double num28 = this.myAct.xSel[0] - this.myAct.xSel[this.kSel];
                                        double num29 = this.myAct.ySel[0] - this.myAct.ySel[this.kSel];
                                        if (Math.Sqrt(num28 * num28 + num29 * num29) < this.tolerance)
                                        {
                                            ++num11;
                                            break;
                                        }
                                    }
                                    if (num27 < this.tolerance)
                                    {
                                        int index24 = -1;
                                        for (int index25 = index17; index25 <= index18; ++index25)
                                        {
                                            ++index24;
                                            this.myAct.xDop[index24] = this.myAct.xLinTopo[index25];
                                            this.myAct.yDop[index24] = this.myAct.yLinTopo[index25];
                                        }
                                        for (int index26 = 1; index26 <= this.kSel; ++index26)
                                        {
                                            ++index24;
                                            this.myAct.xDop[index24] = this.myAct.xSel[index26];
                                            this.myAct.yDop[index24] = this.myAct.ySel[index26];
                                        }
                                        this.kSel = index24;
                                        for (int index27 = 0; index27 <= this.kSel; ++index27)
                                        {
                                            this.myAct.xSel[index27] = this.myAct.xDop[index27];
                                            this.myAct.ySel[index27] = this.myAct.yDop[index27];
                                        }
                                        ++index3;
                                        this.myAct.nDat[index3] = index15;
                                        double num30 = this.myAct.xSel[0] - this.myAct.xSel[this.kSel];
                                        double num31 = this.myAct.ySel[0] - this.myAct.ySel[this.kSel];
                                        if (Math.Sqrt(num30 * num30 + num31 * num31) < this.tolerance)
                                        {
                                            ++num11;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (num11 > 0)
                                break;
                        }
                        else
                            break;
                    }
                }
                if (this.nProcess == 290)
                {
                    double num32 = this.myAct.xSel[0] - this.myAct.xSel[this.kSel];
                    double num33 = this.myAct.ySel[0] - this.myAct.ySel[this.kSel];
                    dist = Math.Sqrt(num32 * num32 + num33 * num33);
                    if (dist > this.tolerance)
                    {
                        int num34 = (int)MessageBox.Show("Line isn't Closed", "Parcels' Division and Unification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                this.button21.Visible = true;
                this.button30.Visible = true;
                this.panel7.Invalidate();
            }
            if (this.nProcess == 300 && this.kSel == 0)
            {
                this.sName = "";
                this.sCalc = 0.0;
                this.sLeg = 0.0;
                DllClass1.ParcelSelect(this.xArc[0], this.yArc[0], this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, out this.sName, out this.sCalc, out this.sLeg, out this.indPoly);
                if (this.indPoly == 0)
                    return;
                int num35 = this.myAct.kActPoly1[this.indPoly];
                int num36 = this.myAct.kActPoly2[this.indPoly];
                this.kSel = -1;
                for (int index = num35; index <= num36; ++index)
                {
                    ++this.kSel;
                    this.myAct.xSel[this.kSel] = this.myAct.xPolyAct[index];
                    this.myAct.ySel[this.kSel] = this.myAct.yPolyAct[index];
                }
                double num37 = 0.0;
                double num38 = 0.0;
                for (int index28 = 1; index28 <= this.kPolyAct; ++index28)
                {
                    if (index28 != this.indPoly && DllClass1.in_out(this.kSel, ref this.myAct.xSel, ref this.myAct.ySel, this.myAct.xAct[index28], this.myAct.yAct[index28]) != 0)
                    {
                        int num39 = this.myAct.kActPoly1[index28];
                        int num40 = this.myAct.kActPoly2[index28];
                        int num41 = 0;
                        for (int index29 = num39; index29 <= num40; ++index29)
                        {
                            for (int index30 = 0; index30 <= this.kSel; ++index30)
                            {
                                double num42 = this.myAct.xSel[index30] - this.myAct.xPolyAct[index29];
                                double num43 = this.myAct.ySel[index30] - this.myAct.yPolyAct[index29];
                                if (Math.Sqrt(num42 * num42 + num43 * num43) < this.tolerance)
                                {
                                    ++num41;
                                    break;
                                }
                            }
                            if (num41 > 0)
                                break;
                        }
                        if (num41 <= 0)
                        {
                            num37 += this.myAct.aActCalc[index28];
                            num38 += this.myAct.aActLeg[index28];
                        }
                    }
                }
                this.textBox1.Text = this.sName;
                this.sTmp = string.Format("{0:F4}", (object)this.sCalc);
                this.textBox2.Text = this.sTmp;
                this.sTmp = string.Format("{0:F4}", (object)this.sLeg);
                this.textBox3.Text = this.sTmp;
                if (num37 > 0.0)
                {
                    this.label5.Visible = true;
                    this.textBox5.Visible = true;
                    this.textBox6.Visible = true;
                    this.sTmp = string.Format("{0:F4}", (object)num37);
                    this.textBox5.Text = this.sTmp;
                    this.sTmp = string.Format("{0:F4}", (object)num38);
                    this.textBox6.Text = this.sTmp;
                }
                this.panel7.Invalidate();
            }
            if (this.nProcess != 410 || this.kSel != 0)
                return;
            this.sName = "";
            this.sCalc = 0.0;
            this.sLeg = 0.0;
            int num44;
            int num45 = num44 = 0;
            int num46;
            int num47 = num46 = 0;
            int num48 = 0;
            int kLine = 0;
            int index31 = 0;
            double num49;
            double num50 = num49 = 0.0;
            DllClass1.ParcelSelect(this.xArc[0], this.yArc[0], this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, out this.sName, out this.sCalc, out this.sLeg, out this.indPoly);
            if (this.indPoly == 0)
                return;
            int num51 = this.myAct.kActPoly1[this.indPoly];
            int num52 = this.myAct.kActPoly2[this.indPoly];
            this.kAdd = -1;
            for (int index32 = num51; index32 <= num52; ++index32)
            {
                ++this.kAdd;
                this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index32];
                this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index32];
            }
            string str1 = this.myAct.nameAct[this.indPoly];
            double num53 = this.myAct.aActCalc[this.indPoly];
            double num54 = this.myAct.aActLeg[this.indPoly];
            int kin1 = 0;
            int kLin1 = 0;
            DllClass1.ParcelLine(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, kin1, ref this.myAct.kin1, ref this.myAct.kin2, ref this.myAct.xActInt, ref this.myAct.yActInt, this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, out kLin1, ref this.myAct.rWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.nWork, this.tolerance);
            if (kLin1 == 0)
                return;
            int num55 = 0;
            for (int index33 = 1; index33 <= this.kPolyAct; ++index33)
            {
                if (this.indPoly != index33)
                {
                    int num56 = this.myAct.kActPoly1[index33];
                    int num57 = this.myAct.kActPoly2[index33];
                    this.kAdd = -1;
                    for (int index34 = num56; index34 <= num57; ++index34)
                    {
                        ++this.kAdd;
                        this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index34];
                        this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index34];
                    }
                    num55 = DllClass1.in_out(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.myAct.xAct[this.indPoly], this.myAct.yAct[this.indPoly]);
                    if (num55 > 0)
                    {
                        index31 = index33;
                        break;
                    }
                }
            }
            string str2 = this.myAct.nameAct[index31];
            double num58 = this.myAct.aActCalc[index31];
            double num59 = this.myAct.aActLeg[index31];
            if (num55 == 0)
            {
                int num60 = (int)MessageBox.Show("Parcel isn't Interior", "Inner Parcel delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int index35 = num48 + 1;
                this.myAct.nameParc[index35] = this.sName;
                this.myAct.xParc[index35] = this.myAct.xAct[this.indPoly];
                this.myAct.yParc[index35] = this.myAct.yAct[this.indPoly];
                this.myAct.aParcCalc[index35] = this.sCalc;
                this.myAct.aParcLeg[index35] = this.sLeg;
                this.myAct.nExter[index35] = this.indPoly;
                for (int index36 = 1; index36 <= this.kPolyAct; ++index36)
                {
                    if (this.indPoly != index36 && index36 != index31 && DllClass1.in_out(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.myAct.xAct[index36], this.myAct.yAct[index36]) > 0)
                    {
                        ++index35;
                        this.myAct.nameParc[index35] = this.myAct.nameAct[index36];
                        this.myAct.xParc[index35] = this.myAct.xAct[index36];
                        this.myAct.yParc[index35] = this.myAct.yAct[index36];
                        this.myAct.aParcCalc[index35] = this.myAct.aActCalc[index36];
                        this.myAct.aParcLeg[index35] = this.myAct.aActLeg[index36];
                        this.myAct.nExter[index35] = index36;
                    }
                }
                int kBnd = 0;
                int index37 = 0;
                for (int index38 = 1; index38 <= index35; ++index38)
                {
                    this.indPoly = 0;
                    for (int index39 = 1; index39 <= this.kPolyAct; ++index39)
                    {
                        if (this.myAct.nExter[index38] == index39)
                        {
                            this.indPoly = index39;
                            break;
                        }
                    }
                    if (this.indPoly != 0)
                    {
                        int num61 = this.myAct.kActPoly1[this.indPoly];
                        int num62 = this.myAct.kActPoly2[this.indPoly];
                        this.kAdd = -1;
                        for (int index40 = num61; index40 <= num62; ++index40)
                        {
                            ++this.kAdd;
                            this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index40];
                            this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index40];
                        }
                        int kin2 = 0;
                        kBnd = 0;
                        DllClass1.ParcelLine(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, kin2, ref this.myAct.kin1, ref this.myAct.kin2, ref this.myAct.xActInt, ref this.myAct.yActInt, this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, out kBnd, ref this.myAct.rWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.nWork, this.tolerance);
                        if (kBnd > 0)
                        {
                            num45 = 0;
                            for (int index41 = 1; index41 <= kBnd; ++index41)
                            {
                                int num63 = 0;
                                int num64 = this.myAct.nWork1[index41];
                                int num65 = this.myAct.nWork2[index41];
                                for (int index42 = num64; index42 <= num65; ++index42)
                                {
                                    ++num63;
                                    ++index37;
                                    this.myAct.xDop[index37] = this.myAct.xWork[index42];
                                    this.myAct.yDop[index37] = this.myAct.yWork[index42];
                                }
                                ++kLine;
                                this.myAct.nDop3[kLine] = num63;
                                this.myAct.zDop[kLine] = this.myAct.rWork[index41];
                            }
                        }
                    }
                }
                this.myAct.nDop1[1] = 1;
                this.myAct.nDop2[1] = this.myAct.nDop3[1];
                if (kLine > 1)
                {
                    for (int index43 = 2; index43 <= kLine; ++index43)
                    {
                        this.myAct.nDop1[index43] = this.myAct.nDop2[index43 - 1] + 1;
                        this.myAct.nDop2[index43] = this.myAct.nDop2[index43 - 1] + this.myAct.nDop3[index43];
                    }
                }
                DllClass1.BoundLine(kLin1, kLine, ref this.myAct.zDop, ref this.myAct.nDop1, ref this.myAct.nDop2, ref this.myAct.xDop, ref this.myAct.yDop, out kBnd, ref this.myAct.zWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.nWork, this.tolerance);
                if (kBnd > 0)
                    DllClass1.BoundDelete(ref this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, kBnd, ref this.myAct.zWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.nWork, this.tolerance);
                this.kPolyAct = 0;
                this.kIntAct = 0;
                this.panel1.Text = "Пожалуйста подождите....Построение полигональных топографических знаков";
                DllClass1.LinesToPoly(this.tolerance, this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, this.kNodeAct, ref this.myAct.xNodeAct, ref this.myAct.yNodeAct, out this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.nSymbPoly, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out this.kIntAct, ref this.myAct.kIndexAct, ref this.myAct.kIndexAct1, ref this.myAct.kIndexAct2, ref this.myAct.nWork, ref this.myAct.indInter, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.pWork, ref this.myAct.rWork, ref this.myAct.zDop, this.panel1);
                if (this.kPolyAct == 0)
                    return;
                this.myAct.PolyActPrev(ref this.myAct.kPolyInside, this.nAction);
                this.kPolyPrev = this.myAct.kPolyPrev;
                DllClass1.ActionCompare(this.kPolyPrev, ref this.myAct.xLab, ref this.myAct.yLab, ref this.myAct.areaPol, ref this.myAct.areaLeg, ref this.myAct.kt1, ref this.myAct.kt2, ref this.myAct.xPol, ref this.myAct.yPol, this.kPolyAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, ref this.myAct.xWork, ref this.myAct.yWork);
                this.PolyOrder();
                this.panel1.Text = "Пожалуйста подождите....Определение подписи(метки) полигона";
                DllClass1.KeepPolyLabel(this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xDop, ref this.myAct.yDop, ref this.myAct.zDop, ref this.myAct.nDop1, ref this.myAct.nDop2, ref this.myAct.nDop3, this.panel1);
                int num66 = this.myAct.kActPoly1[index31];
                int num67 = this.myAct.kActPoly2[index31];
                this.kAdd = -1;
                for (int index44 = num66; index44 <= num67; ++index44)
                {
                    ++this.kAdd;
                    this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index44];
                    this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index44];
                }
                for (int index45 = 1; index45 <= this.kNodeAct; ++index45)
                {
                    if (DllClass1.in_out(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.myAct.xNodeAct[index45], this.myAct.yNodeAct[index45]) > 0)
                    {
                        int num68 = 0;
                        for (int index46 = 1; index46 <= this.kLineAct; ++index46)
                        {
                            int index47 = this.myAct.kActLine1[index46];
                            int index48 = this.myAct.kActLine2[index46];
                            double num69 = this.myAct.xLineAct[index47] - this.myAct.xNodeAct[index45];
                            double num70 = this.myAct.yLineAct[index47] - this.myAct.yNodeAct[index45];
                            if (Math.Sqrt(num69 * num69 + num70 * num70) < this.tolerance)
                            {
                                ++num68;
                                break;
                            }
                            double num71 = this.myAct.xLineAct[index48] - this.myAct.xNodeAct[index45];
                            double num72 = this.myAct.yLineAct[index48] - this.myAct.yNodeAct[index45];
                            if (Math.Sqrt(num71 * num71 + num72 * num72) < this.tolerance)
                            {
                                ++num68;
                                break;
                            }
                        }
                        if (num68 <= 0)
                        {
                            int num73 = 0;
                            for (int index49 = 0; index49 <= this.kAdd; ++index49)
                            {
                                double num74 = this.myAct.xAdd[index49] - this.myAct.xNodeAct[index45];
                                double num75 = this.myAct.yAdd[index49] - this.myAct.yNodeAct[index45];
                                if (Math.Sqrt(num74 * num74 + num75 * num75) < this.tolerance)
                                {
                                    ++num73;
                                    break;
                                }
                            }
                            if (num73 <= 0)
                            {
                                this.myAct.xNodeAct[index45] = 0.0;
                                this.myAct.yNodeAct[index45] = 0.0;
                            }
                        }
                    }
                }
                int index50 = 0;
                for (int index51 = 1; index51 <= this.kNodeAct; ++index51)
                {
                    if (this.myAct.xNodeAct[index51] != 0.0 || this.myAct.yNodeAct[index51] != 0.0)
                    {
                        ++index50;
                        this.myAct.nameNodeAct[index50] = this.myAct.nameNodeAct[index51];
                        this.myAct.xNodeAct[index50] = this.myAct.xNodeAct[index51];
                        this.myAct.yNodeAct[index50] = this.myAct.yNodeAct[index51];
                    }
                }
                this.kNodeAct = index50;
                if (this.maxParcel < 0)
                    this.maxParcel = 0;
                int kNew = 0;
                DllClass1.ParcNewName(this.maxParcel, this.kPolySource, this.myAct.nameSource, this.myAct.xLabSource, this.myAct.yLabSource, this.myAct.arCalcSource, this.myAct.arLegSource, this.myAct.k1Source, this.myAct.k2Source, this.myAct.xSource, this.myAct.ySource, this.kPolyAct, this.myAct.nameAct, this.myAct.xAct, this.myAct.yAct, this.myAct.aActCalc, this.myAct.aActLeg, out kNew, this.myAct.nameDop, this.myAct.xDop, this.myAct.yDop, this.myAct.xWork, this.myAct.yWork, this.myAct.xSpot, this.myAct.ySpot);
                if (this.maxParcel < 0)
                    this.maxParcel = 0;
                if (kNew > 0)
                {
                    if (!File.Exists(this.myAct.flistAction))
                    {
                        int num76 = (int)MessageBox.Show("Вернуться к Построение полигональных топографических знаков", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    FileStream output = new FileStream(this.myAct.flistAction, FileMode.Append);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    this.sTmp = string.Format("{0}", (object)this.nProcess) + "   0";
                    binaryWriter.Write(this.sTmp);
                    this.sTmp = this.myAct.nameDop[1] + "  " + string.Format("{0:F4}", (object)this.myAct.xWork[1]) + "  " + string.Format("{0:F4}", (object)this.myAct.yWork[1]);
                    binaryWriter.Write(this.sTmp);
                    this.sTmp = str1 + "  " + string.Format("{0:F4}", (object)num53) + "  " + string.Format("{0:F4}", (object)num54);
                    binaryWriter.Write(this.sTmp);
                    this.sTmp = str2 + "  " + string.Format("{0:F4}", (object)num58) + "  " + string.Format("{0:F4}", (object)num59);
                    binaryWriter.Write(this.sTmp);
                    this.sTmp = "0";
                    binaryWriter.Write(this.sTmp);
                    binaryWriter.Close();
                    output.Close();
                    this.kPolySource = this.myAct.kPolyAct;
                    for (int index52 = 1; index52 <= this.myAct.kPolyAct; ++index52)
                    {
                        this.myAct.nameSource[index52] = this.myAct.nameAct[index52];
                        this.myAct.xLabSource[index52] = this.myAct.xAct[index52];
                        this.myAct.yLabSource[index52] = this.myAct.yAct[index52];
                        this.myAct.arCalcSource[index52] = this.myAct.aActCalc[index52];
                        this.myAct.arLegSource[index52] = this.myAct.aActLeg[index52];
                        this.myAct.k1Source[index52] = this.myAct.kActPoly1[index52];
                        this.myAct.k2Source[index52] = this.myAct.kActPoly2[index52];
                        int num77 = this.myAct.k1Source[index52];
                        int num78 = this.myAct.k2Source[index52];
                        for (int index53 = num77; index53 <= num78; ++index53)
                        {
                            this.myAct.xSource[index53] = this.myAct.xPolyAct[index53];
                            this.myAct.ySource[index53] = this.myAct.yPolyAct[index53];
                        }
                    }
                    this.myAct.kPolySource = this.kPolySource;
                    this.myAct.LoadKeepSource(2);
                    int kPnt = -1;
                    for (int index54 = 1; index54 <= this.kPolyAct; ++index54)
                    {
                        ++kPnt;
                        this.myAct.nameAdd[kPnt] = this.myAct.nameAct[index54];
                    }
                    DllClass1.NewPointName(kPnt, this.myAct.nameAdd, out this.maxParcel, out this.sTmp);
                    --this.maxParcel;
                }
                this.ChangeAction();
                this.panel1.Text = "Готов...";
                this.kSel = -1;
                this.kRcPnt = 0;
                this.nProcess = 0;
                this.nControl = 0;
                this.panel7.Invalidate();
            }
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            DllClass1.WINtoXY(e.X, e.Y, this.scaleToGeo, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out this.xCur, out this.yCur);
            if (!File.Exists(this.myAct.flineTopo))
            {
                this.panel2.Text = string.Format("{0}", (object)e.X);
                this.panel4.Text = string.Format("{0}", (object)e.Y);
            }
            if (File.Exists(this.myAct.flineTopo))
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

        private void ParallelMetre_Click(object sender, EventArgs e)
        {
            this.nProcess = 210;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.groupBox6.Visible = true;
            this.button19.Visible = false;
            this.button29.Visible = false;
            this.label4.Visible = false;
            this.label4.Text = "";
            this.textBox4.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.iProjDraw = 0;
            this.myAct.TopoActLoad(this.nAction);
            this.panel7.Invalidate();
        }

        private void ParallelDistance_Click(object sender, EventArgs e)
        {
            this.nProcess = 220;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.groupBox6.Visible = true;
            this.button19.Visible = false;
            this.button29.Visible = false;
            this.label4.Visible = false;
            this.label4.Text = "";
            this.textBox4.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.iProjDraw = 0;
            this.panel7.Invalidate();
        }

        private void ParallelPercent_Click(object sender, EventArgs e)
        {
            this.nProcess = 230;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.groupBox6.Visible = true;
            this.button19.Visible = false;
            this.button29.Visible = false;
            this.label4.Visible = false;
            this.label4.Text = "";
            this.textBox4.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.iProjDraw = 0;
            this.panel7.Invalidate();
        }

        private void PerpendicularMetre_Click(object sender, EventArgs e)
        {
            this.nProcess = 240;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.groupBox6.Visible = true;
            this.button19.Visible = false;
            this.button29.Visible = false;
            this.label4.Visible = false;
            this.label4.Text = "";
            this.textBox4.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.iProjDraw = 0;
            this.panel7.Invalidate();
        }

        private void PerpendicularLine_Click(object sender, EventArgs e)
        {
            this.nProcess = 250;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.groupBox6.Visible = true;
            this.button19.Visible = false;
            this.button29.Visible = false;
            this.label4.Visible = false;
            this.label4.Text = "";
            this.textBox4.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.iProjDraw = 0;
            this.panel7.Invalidate();
        }

        private void PerpendicularPercent_Click(object sender, EventArgs e)
        {
            this.nProcess = 260;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.groupBox6.Visible = true;
            this.button19.Visible = false;
            this.button29.Visible = false;
            this.label4.Visible = false;
            this.label4.Text = "";
            this.textBox4.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.iProjDraw = 0;
            this.panel7.Invalidate();
        }

        private void DesignAllLines_Click(object sender, EventArgs e)
        {
            int num1;
            int kPol1 = num1 = 0;
            double num2;
            double num3 = num2 = 0.0;
            if (this.kPolyProj == 0 && this.kTopoProj == 0)
            {
                int num4 = (int)MessageBox.Show("Процесс проектирования не был завершен", "Разделение участков со всеми проектными(графическими) линиями", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.kSel = -1;
                this.kRcPnt = 0;
                this.nProcess = 0;
            }
            else
            {
                this.nProcess = 270;
                this.nControl = 0;
                this.kSel = -1;
                this.kRcPnt = 0;
                this.iProjDraw = 1;
                this.kLineCancel = 0;
                this.kLineNew = 0;
                this.kPolyCancel = 0;
                this.groupBox6.Visible = false;
                this.myAct.TopoActLoad(this.nAction);
                this.kLineAct = this.myAct.kLineAct;
                if (this.kPntProj > -1)
                {
                    for (int index1 = 0; index1 <= this.kPntProj; ++index1)
                    {
                        int num5 = 0;
                        for (int index2 = 0; index2 <= this.kPntPlus; ++index2)
                        {
                            double num6 = this.myAct.xProj[index1] - this.myAct.xPnt[index2];
                            double num7 = this.myAct.yProj[index1] - this.myAct.yPnt[index2];
                            if (Math.Sqrt(num6 * num6 + num7 * num7) < this.tolerance)
                            {
                                ++num5;
                                break;
                            }
                        }
                        if (num5 <= 0)
                        {
                            ++this.kPntPlus;
                            this.myAct.xPnt[this.kPntPlus] = this.myAct.xProj[index1];
                            this.myAct.yPnt[this.kPntPlus] = this.myAct.yProj[index1];
                        }
                    }
                }
                if (this.kNodeAct > 0)
                {
                    for (int index3 = 1; index3 <= this.kNodeAct; ++index3)
                    {
                        int num8 = 0;
                        for (int index4 = 0; index4 <= this.kPntPlus; ++index4)
                        {
                            double num9 = this.myAct.xNodeAct[index3] - this.myAct.xPnt[index4];
                            double num10 = this.myAct.yNodeAct[index3] - this.myAct.yPnt[index4];
                            if (Math.Sqrt(num9 * num9 + num10 * num10) < this.tolerance)
                            {
                                ++num8;
                                break;
                            }
                        }
                        if (num8 <= 0)
                        {
                            ++this.kPntPlus;
                            this.myAct.namePnt[this.kPntPlus] = this.myAct.nameNodeAct[index3];
                            this.myAct.xPnt[this.kPntPlus] = this.myAct.xNodeAct[index3];
                            this.myAct.yPnt[this.kPntPlus] = this.myAct.yNodeAct[index3];
                        }
                    }
                }
                int index5 = this.myAct.kActLine2[this.kLineAct];
                for (int index6 = 1; index6 <= this.kTopoProj; ++index6)
                {
                    int num11 = this.myAct.kPrt1[index6];
                    int num12 = this.myAct.kPrt2[index6];
                    int num13 = 0;
                    for (int index7 = num11; index7 <= num12; ++index7)
                    {
                        ++num13;
                        ++index5;
                        this.myAct.xLineAct[index5] = this.myAct.xLinTopo[index7];
                        this.myAct.yLineAct[index5] = this.myAct.yLinTopo[index7];
                    }
                    ++this.kLineAct;
                    this.myAct.radAct[this.kLineAct] = this.myAct.RadTopo[index6];
                    this.myAct.kActLine1[this.kLineAct] = this.myAct.kActLine2[this.kLineAct - 1] + 1;
                    this.myAct.kActLine2[this.kLineAct] = this.myAct.kActLine2[this.kLineAct - 1] + num13;
                }
                int kLine2 = 0;
                DllClass1.LineTopoline(this.tolerance, this.kPntPlus, ref this.myAct.xPnt, ref this.myAct.yPnt, ref this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, out kLine2, ref this.myAct.pWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.nWork, ref this.myAct.nDop3, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, this.panel1);
                if (kLine2 == 0)
                    return;
                this.kLineAct = kLine2;
                for (int index8 = 1; index8 <= kLine2; ++index8)
                {
                    this.myAct.radAct[index8] = this.myAct.pWork[index8];
                    this.myAct.kActLine1[index8] = this.myAct.nWork1[index8];
                    this.myAct.kActLine2[index8] = this.myAct.nWork2[index8];
                }
                int kNew1 = this.myAct.nWork2[kLine2];
                for (int index9 = 1; index9 <= kNew1; ++index9)
                {
                    this.myAct.xLineAct[index9] = this.myAct.xWork1[index9];
                    this.myAct.yLineAct[index9] = this.myAct.yWork1[index9];
                }
                this.panel1.Text = "Пожалуйста подождите....Построение топологии узла";
                int knd = 0;
                DllClass1.NodeTopology(this.tolerance, this.kPntPlus, ref this.myAct.xPnt, ref this.myAct.yPnt, this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, out this.kNodeAct, ref this.myAct.xNodeAct, ref this.myAct.yNodeAct, ref this.myAct.nWork, ref this.myAct.xDop, ref this.myAct.yDop, out knd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.panel1);
                DllClass1.NameActNode(this.kPntInput, this.myAct.namePnt, this.myAct.xPnt, this.myAct.yPnt, ref this.kNodeAct, ref this.myAct.nameNodeAct, ref this.myAct.xNodeAct, ref this.myAct.yNodeAct);
                this.panel1.Text = "Пожалуйста подождите....Построение линейной топологии";
                DllClass1.LineDivide(this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, knd, ref this.myAct.xAdd, ref this.myAct.yAdd, out kNew1, ref this.myAct.pWork, ref this.myAct.nDop1, ref this.myAct.nDop2, ref this.myAct.nDop3, ref this.myAct.xDop, ref this.myAct.yDop, this.tolerance, this.panel1);
                if (kNew1 == 0)
                    return;
                this.kLineAct = kNew1;
                for (int index10 = 1; index10 <= this.kLineAct; ++index10)
                {
                    if (this.myAct.nDop2[index10] - this.myAct.nDop1[index10] == 1)
                        this.myAct.pWork[index10] = 0.0;
                    this.myAct.radAct[index10] = this.myAct.pWork[index10];
                    this.myAct.kActLine1[index10] = this.myAct.nDop1[index10];
                    this.myAct.kActLine2[index10] = this.myAct.nDop2[index10];
                }
                int kNew2 = this.myAct.kActLine2[this.kLineAct];
                for (int index11 = 1; index11 <= kNew2; ++index11)
                {
                    this.myAct.xLineAct[index11] = this.myAct.xDop[index11];
                    this.myAct.yLineAct[index11] = this.myAct.yDop[index11];
                }
                this.panel1.Text = "Пожалуйста подождите....Проверка двойных линий";
                DllClass1.RemoveDoubleLine(this.tolerance, ref this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, out kNew2, ref this.myAct.pWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.xDop, ref this.myAct.yDop, ref this.myAct.nWork, ref this.myAct.nDop1, ref this.myAct.nDop2, this.panel1);
                double sArea = 0.0;
                int kOut = 0;
                DllClass1.ExteriorBox(this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, ref this.myAct.nExter, out kOut, ref this.myAct.xOut, ref this.myAct.yOut, out sArea, ref this.myAct.nWork);
                if (this.kLineAct > 0)
                    DllClass1.CleanLineTopo(ref this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.radAct, ref this.myAct.xLineAct, ref this.myAct.yLineAct, ref this.myAct.nWork, ref this.myAct.xWork, ref this.myAct.yWork, this.tolerance);
                this.panel1.Text = "Пожалуйста подождите....Построение полигональных топографических знаков";
                DllClass1.PolyTopology(this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, this.kNodeAct, ref this.myAct.xNodeAct, ref this.myAct.yNodeAct, out this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.nSymbPoly, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.nWork, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, this.tolerance, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.kn1, ref this.myAct.kn2, ref this.myAct.nExter, ref this.myAct.indInter, ref this.myAct.indPol, this.panel1);
                if (this.kPolyAct == 0)
                    return;
                if (this.kPolyAct > 1)
                {
                    int kPol2 = 0;
                    DllClass1.PolyDelete(this.kPolyAct, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out kPol2, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.nSymbPoly, ref this.myAct.kn1, ref this.myAct.kn2, ref this.myAct.xWork1, ref this.myAct.yWork1, this.tolerance, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.nWork);
                    if (kPol2 == 0)
                        return;
                    this.kPolyAct = kPol2;
                    for (int index12 = 1; index12 <= kPol2; ++index12)
                    {
                        this.myAct.kActPoly1[index12] = this.myAct.kn1[index12];
                        this.myAct.kActPoly2[index12] = this.myAct.kn2[index12];
                    }
                    int num14 = this.myAct.kActPoly2[kPol2];
                    for (int index13 = 1; index13 <= num14; ++index13)
                    {
                        this.myAct.xPolyAct[index13] = this.myAct.xWork1[index13];
                        this.myAct.yPolyAct[index13] = this.myAct.yWork1[index13];
                    }
                    for (int index14 = 1; index14 <= this.kPolyAct; ++index14)
                        this.myAct.nameAct[index14] = string.Format("{0}", (object)index14);
                    int kin = 0;
                    DllClass1.PolyInterior(this.kPolyAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg,
                        ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out kin, ref this.myAct.indPol, 
                        ref this.myAct.kn1, ref this.myAct.kn2, ref this.myAct.nWork, ref this.myAct.indInter, ref this.myAct.xWork1, ref this.myAct.yWork1,
                        ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.rWork, 
                        ref this.myAct.pWork, ref this.myAct.zDop);
                    this.kIntAct = kin;
                }
                this.myAct.PolyActPrev(ref this.myAct.kPolyInside, this.nAction);
                this.kPolyPrev = this.myAct.kPolyPrev;
                DllClass1.FindPolyCancel(this.kPolyPrev, ref this.myAct.namePoly, ref this.myAct.xLab, ref this.myAct.yLab, 
                    ref this.myAct.areaPol, ref this.myAct.areaLeg, ref this.myAct.kt1, ref this.myAct.kt2, ref this.myAct.xPol, 
                    ref this.myAct.yPol, this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, 
                    ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, 
                    ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out this.kPolyCancel, ref this.myAct.nameCanc, 
                    ref this.myAct.xLabCanc, ref this.myAct.yLabCanc, ref this.myAct.aCalcCanc, ref this.myAct.aLegCanc, ref this.myAct.xWork, ref this.myAct.yWork);
                DllClass1.ActionCompare(this.kPolyPrev, ref this.myAct.xLab, ref this.myAct.yLab, ref this.myAct.areaPol, 
                    ref this.myAct.areaLeg, ref this.myAct.kt1, ref this.myAct.kt2, ref this.myAct.xPol, ref this.myAct.yPol, 
                    this.kPolyAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, 
                    ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, ref this.myAct.xWork, ref this.myAct.yWork);
                this.panel1.Text = "Число полигонов = " + Convert.ToString(this.kPolyAct);
                this.PolyOrder();
                this.panel1.Text = "Пожалуйста подождите....Определение подписи(метки) полигона";
                DllClass1.KeepPolyLabel(this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.kActPoly1, 
                    ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, ref this.myAct.xWork1, ref this.myAct.yWork1, 
                    ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xDop, 
                    ref this.myAct.yDop, ref this.myAct.zDop, ref this.myAct.nDop1, ref this.myAct.nDop2, ref this.myAct.nDop3, this.panel1);
                if (this.maxParcel < 0)
                    this.maxParcel = 0;
                int kNew3 = 0;
                DllClass1.ParcNewName(this.maxParcel, this.kPolySource, this.myAct.nameSource, this.myAct.xLabSource, this.myAct.yLabSource, 
                    this.myAct.arCalcSource, this.myAct.arLegSource, this.myAct.k1Source, this.myAct.k2Source, this.myAct.xSource, this.myAct.ySource,
                    this.kPolyAct, this.myAct.nameAct, this.myAct.xAct, this.myAct.yAct, this.myAct.aActCalc, this.myAct.aActLeg, out kNew3, this.myAct.nameDop, 
                    this.myAct.xDop, this.myAct.yDop, this.myAct.xWork, this.myAct.yWork, this.myAct.xSpot, this.myAct.ySpot);
                if (this.maxParcel < 0)
                    this.maxParcel = 0;
                if (kNew3 > 1)
                {
                    if (!File.Exists(this.myAct.flistAction))
                    {
                        int num15 = (int)MessageBox.Show("Вернуться к Построение полигональных топографических знаков", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    FileStream output = new FileStream(this.myAct.flistAction, FileMode.Append);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    this.sTmp = string.Format("{0}", (object)this.nProcess) + "   0";
                    binaryWriter.Write(this.sTmp);
                    for (int index15 = 1; index15 <= this.kPolySource; ++index15)
                    {
                        int num16 = this.myAct.k1Source[index15];
                        int num17 = this.myAct.k2Source[index15];
                        int k = -1;
                        for (int index16 = num16; index16 <= num17; ++index16)
                        {
                            ++k;
                            this.myAct.xWork1[k] = this.myAct.xSource[index16];
                            this.myAct.yWork1[k] = this.myAct.ySource[index16];
                        }
                        DllClass1.NewInPrev(this.myAct.arCalcSource[index15], k, this.myAct.xWork1, this.myAct.yWork1, kNew3, this.myAct.nameDop, this.myAct.xDop, this.myAct.yDop, this.myAct.xWork, this.myAct.yWork, out kPol1, this.myAct.nameWork, this.myAct.xOut, this.myAct.yOut, this.myAct.xWork2, this.myAct.yWork2);
                        if (kPol1 >= 1)
                        {
                            this.sTmp = this.myAct.nameSource[index15] + "   " + string.Format("{0:F4}", (object)this.myAct.arCalcSource[index15]) + "   " + string.Format("{0:F4}", (object)this.myAct.arLegSource[index15]);
                            binaryWriter.Write(this.sTmp);
                            for (int index17 = 1; index17 <= kPol1; ++index17)
                            {
                                this.sTmp = this.myAct.nameWork[index17] + "   " + string.Format("{0:F4}", (object)this.myAct.xWork2[index17]) + "   " + string.Format("{0:F4}", (object)this.myAct.yWork2[index17]);
                                binaryWriter.Write(this.sTmp);
                            }
                            this.sTmp = "0";
                            binaryWriter.Write(this.sTmp);
                        }
                    }
                    binaryWriter.Close();
                    output.Close();
                    int kPnt = -1;
                    this.kPolySource = this.kPolyAct;
                    for (int index18 = 1; index18 <= this.kPolyAct; ++index18)
                    {
                        ++kPnt;
                        this.myAct.nameAdd[kPnt] = this.myAct.nameAct[index18];
                        this.myAct.nameSource[index18] = this.myAct.nameAct[index18];
                        this.myAct.xLabSource[index18] = this.myAct.xAct[index18];
                        this.myAct.yLabSource[index18] = this.myAct.yAct[index18];
                        this.myAct.arCalcSource[index18] = this.myAct.aActCalc[index18];
                        this.myAct.arLegSource[index18] = this.myAct.aActLeg[index18];
                        this.myAct.k1Source[index18] = this.myAct.kActPoly1[index18];
                        this.myAct.k2Source[index18] = this.myAct.kActPoly2[index18];
                        int num18 = this.myAct.k1Source[index18];
                        int num19 = this.myAct.k2Source[index18];
                        for (int index19 = num18; index19 <= num19; ++index19)
                        {
                            this.myAct.xSource[index19] = this.myAct.xPolyAct[index19];
                            this.myAct.ySource[index19] = this.myAct.yPolyAct[index19];
                        }
                    }
                    DllClass1.NewPointName(kPnt, this.myAct.nameAdd, out this.maxParcel, out this.sTmp);
                    --this.maxParcel;
                    this.myAct.kPolySource = this.kPolySource;
                    this.myAct.LoadKeepSource(2);
                }
                this.ChangeAction();
                this.myAct.PolygonLoad(ref this.myAct.kPolyInside);
                this.kPoly = this.myAct.kPoly;
                this.button21.Visible = false;
                this.button30.Visible = false;
                this.groupBox6.Visible = false;
                this.nProcess = 0;
                this.nControl = 0;
                this.kSel = -1;
                this.kRcPnt = 0;
                if (File.Exists(this.myAct.flineFinal))
                    File.Delete(this.myAct.flineFinal);
                this.kLineFinal = 0;
                if (File.Exists(this.myAct.fpolyFinal))
                    File.Delete(this.myAct.fpolyFinal);
                this.kPolyFinal = 0;
                this.panel1.Text = "Готов ...";
                this.panel7.Invalidate();
            }
        }

        private void DesignLine_Click(object sender, EventArgs e)
        {
            if (this.kPolyProj == 0 && this.kTopoProj == 0)
            {
                int num = (int)MessageBox.Show("Процесс проектирования не был завершен", "Разделение участков со всеми проектными(графическими) линиями", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.kSel = -1;
                this.kRcPnt = 0;
                this.nProcess = 0;
            }
            else
            {
                this.nProcess = 280;
                this.nControl = 0;
                this.kSel = -1;
                this.kRcPnt = 0;
                this.iProjDraw = 1;
                this.groupBox6.Visible = false;
                this.panel7.Invalidate();
            }
        }

        private void DevideUnify_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.myAct.fpolyProj))
            {
                int num = (int)MessageBox.Show("Процесс проектирования не был завершен", "Разделение участков со всеми проектными(графическими) линиями", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.kSel = -1;
                this.kRcPnt = 0;
                this.nProcess = 0;
            }
            else
            {
                this.nProcess = 290;
                this.nControl = 0;
                this.kSel = -1;
                this.kRcPnt = 0;
                this.iProjDraw = 1;
                this.groupBox6.Visible = false;
                this.panel7.Invalidate();
            }
        }

        private void UnificationParcels_Click(object sender, EventArgs e)
        {
            this.nProcess = 310;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.iProjDraw = 0;
            this.groupBox6.Visible = false;
            if (this.kPolyAct == 0)
            {
                int num = (int)MessageBox.Show("Данные отсутствуют", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                this.panel7.Invalidate();
        }

        private void UnifyAllParcels_Click(object sender, EventArgs e)
        {
            double num1 = 0.0;
            int kLine = 0;
            int num2;
            int num3 = num2 = 0;
            int num4 = num2;
            int kCom = num2;
            int index1;
            int kin = index1 = 0;
            double num5;
            double num6 = num5 = 0.0;
            this.nProcess = 320;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.iProjDraw = 0;
            this.groupBox6.Visible = false;
            if (this.kPolyAct == 0)
            {
                int num7 = (int)MessageBox.Show("Данные отсутствуют", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (this.kPolyProj > 0 || this.kTopoProj > 0)
            {
                int num8 = (int)MessageBox.Show("Have to remove of all design data", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.kSel = this.kPolyAct;
                for (int index2 = 1; index2 <= this.kPolyAct; ++index2)
                {
                    num1 += this.myAct.aActLeg[index2];
                    int num9 = this.myAct.kActPoly1[index2];
                    int num10 = this.myAct.kActPoly2[index2];
                    this.kAdd = -1;
                    for (int index3 = num9; index3 <= num10; ++index3)
                    {
                        ++this.kAdd;
                        this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index3];
                        this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index3];
                    }
                    this.myAct.nameParc[index2] = this.myAct.nameAct[index2];
                    this.myAct.xParc[index2] = this.myAct.xAct[index2];
                    this.myAct.yParc[index2] = this.myAct.yAct[index2];
                    this.myAct.aParcCalc[index2] = this.myAct.aActCalc[index2];
                    this.myAct.aParcLeg[index2] = this.myAct.aActLeg[index2];
                    kCom = 0;
                    DllClass1.ParcelLine(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, kin, ref this.myAct.kin1, ref this.myAct.kin2, ref this.myAct.xActInt, ref this.myAct.yActInt, this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, out kCom, ref this.myAct.rWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.nWork, this.tolerance);
                    if (kCom > 0)
                    {
                        num4 = 0;
                        for (int index4 = 1; index4 <= kCom; ++index4)
                        {
                            int num11 = 0;
                            int num12 = this.myAct.nWork1[index4];
                            int num13 = this.myAct.nWork2[index4];
                            for (int index5 = num12; index5 <= num13; ++index5)
                            {
                                ++num11;
                                ++index1;
                                this.myAct.xDop[index1] = this.myAct.xWork[index5];
                                this.myAct.yDop[index1] = this.myAct.yWork[index5];
                            }
                            ++kLine;
                            this.myAct.nDop3[kLine] = num11;
                            this.myAct.zDop[kLine] = this.myAct.rWork[index4];
                        }
                    }
                }
                this.myAct.nDop1[1] = 1;
                this.myAct.nDop2[1] = this.myAct.nDop3[1];
                for (int index6 = 2; index6 <= kLine; ++index6)
                {
                    this.myAct.nDop1[index6] = this.myAct.nDop2[index6 - 1] + 1;
                    this.myAct.nDop2[index6] = this.myAct.nDop2[index6 - 1] + this.myAct.nDop3[index6];
                }
                DllClass1.CommonLine(kLine, ref this.myAct.zDop, ref this.myAct.nDop1, ref this.myAct.nDop2, ref this.myAct.xDop, ref this.myAct.yDop, out kCom, ref this.myAct.zWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.nWork, this.tolerance);
                if (kCom > 0)
                    DllClass1.CommonDelete(ref this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, kCom, ref this.myAct.zWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.nWork, this.tolerance);
                this.kPolyAct = 0;
                this.kIntAct = 0;
                this.panel1.Text = "Пожалуйста подождите....Построение полигональных топографических знаков";
                DllClass1.LinesToPoly(this.tolerance, this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, this.kNodeAct, ref this.myAct.xNodeAct, ref this.myAct.yNodeAct, out this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.nSymbPoly, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out this.kIntAct, ref this.myAct.kIndexAct, ref this.myAct.kIndexAct1, ref this.myAct.kIndexAct2, ref this.myAct.nWork, ref this.myAct.indInter, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.pWork, ref this.myAct.rWork, ref this.myAct.zDop, this.panel1);
                if (this.kPolyAct == 0)
                    return;
                int num14 = this.myAct.kActPoly1[1];
                int num15 = this.myAct.kActPoly2[1];
                this.kAdd = -1;
                for (int index7 = num14; index7 <= num15; ++index7)
                {
                    ++this.kAdd;
                    this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index7];
                    this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index7];
                }
                int index8 = 0;
                for (int index9 = 1; index9 <= this.kNodeAct; ++index9)
                {
                    if (DllClass1.in_out(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.myAct.xNodeAct[index9], this.myAct.yNodeAct[index9]) > 0)
                    {
                        int num16 = 0;
                        for (int index10 = 0; index10 <= this.kAdd; ++index10)
                        {
                            double num17 = this.myAct.xAdd[index10] - this.myAct.xNodeAct[index9];
                            double num18 = this.myAct.yAdd[index10] - this.myAct.yNodeAct[index9];
                            if (Math.Sqrt(num17 * num17 + num18 * num18) < this.tolerance)
                            {
                                ++num16;
                                break;
                            }
                        }
                        if (num16 <= 0)
                        {
                            this.myAct.xNodeAct[index9] = 0.0;
                            this.myAct.yNodeAct[index9] = 0.0;
                        }
                    }
                }
                for (int index11 = 1; index11 <= this.kNodeAct; ++index11)
                {
                    if (this.myAct.xNodeAct[index11] != 0.0 || this.myAct.yNodeAct[index11] != 0.0)
                    {
                        ++index8;
                        this.myAct.nameNodeAct[index8] = this.myAct.nameNodeAct[index11];
                        this.myAct.xNodeAct[index8] = this.myAct.xNodeAct[index11];
                        this.myAct.yNodeAct[index8] = this.myAct.yNodeAct[index11];
                    }
                }
                this.kNodeAct = index8;
                int kLinInt = 0;
                DllClass1.LineInside(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, ref this.selRad, ref this.xSelRad, ref this.ySelRad, ref this.kLineAct, ref this.myAct.rWork, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, out kLinInt, ref this.myAct.pWork, ref this.myAct.nDop1, ref this.myAct.nDop2, ref this.myAct.xDop, ref this.myAct.yDop, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.nWork, ref this.myAct.nDop3, ref this.myAct.xWork2, ref this.myAct.yWork2);
                if (kLinInt > 0)
                {
                    this.kPolyAct = 0;
                    this.kIntAct = 0;
                    this.panel1.Text = "Пожалуйста подождите....Построение полигональных топографических знаков";
                    DllClass1.LinesToPoly(this.tolerance, this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, this.kNodeAct, ref this.myAct.xNodeAct, ref this.myAct.yNodeAct, out this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.nSymbPoly, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out this.kIntAct, ref this.myAct.kIndexAct, ref this.myAct.kIndexAct1, ref this.myAct.kIndexAct2, ref this.myAct.nWork, ref this.myAct.indInter, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.pWork, ref this.myAct.rWork, ref this.myAct.zDop, this.panel1);
                }
                if (this.maxParcel < 0)
                    this.maxParcel = 0;
                int kNew = 0;
                DllClass1.ParcNewName(this.maxParcel, this.kPolySource, this.myAct.nameSource, this.myAct.xLabSource, this.myAct.yLabSource, this.myAct.arCalcSource, this.myAct.arLegSource, this.myAct.k1Source, this.myAct.k2Source, this.myAct.xSource, this.myAct.ySource, this.kPolyAct, this.myAct.nameAct, this.myAct.xAct, this.myAct.yAct, this.myAct.aActCalc, this.myAct.aActLeg, out kNew, this.myAct.nameDop, this.myAct.xDop, this.myAct.yDop, this.myAct.xWork, this.myAct.yWork, this.myAct.xSpot, this.myAct.ySpot);
                if (this.maxParcel < 0)
                    this.maxParcel = 0;
                if (kNew > 0)
                {
                    if (!File.Exists(this.myAct.flistAction))
                    {
                        int num19 = (int)MessageBox.Show("Вернуться к Построение полигональных топографических знаков", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    FileStream output = new FileStream(this.myAct.flistAction, FileMode.Append);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    this.sTmp = string.Format("{0}", (object)this.nProcess) + "   0";
                    binaryWriter.Write(this.sTmp);
                    this.sTmp = this.myAct.nameDop[1] + "  " + string.Format("{0:F4}", (object)this.myAct.xWork[1]) + "  " + string.Format("{0:F4}", (object)this.myAct.yWork[1]);
                    binaryWriter.Write(this.sTmp);
                    for (int index12 = 1; index12 <= this.kSel; ++index12)
                    {
                        this.sTmp = this.myAct.nameParc[index12] + "  " + string.Format("{0:F4}", (object)this.myAct.aParcCalc[index12]) + "  " + string.Format("{0:F4}", (object)this.myAct.aParcLeg[index12]);
                        binaryWriter.Write(this.sTmp);
                    }
                    this.sTmp = "0";
                    binaryWriter.Write(this.sTmp);
                    binaryWriter.Close();
                    output.Close();
                    this.myAct.kPolySource = this.kPolySource;
                    this.myAct.LoadKeepSource(2);
                    int kPnt = -1;
                    for (int index13 = 1; index13 <= this.kPolyAct; ++index13)
                    {
                        ++kPnt;
                        this.myAct.nameAdd[kPnt] = this.myAct.nameAct[index13];
                    }
                    DllClass1.NewPointName(kPnt, this.myAct.nameAdd, out this.maxParcel, out this.sTmp);
                    --this.maxParcel;
                }
                this.myAct.aActLeg[1] = num1;
                this.ChangeAction();
                this.panel1.Text = "Готов...";
                if (File.Exists(this.myAct.flineFinal))
                    File.Delete(this.myAct.flineFinal);
                this.kLineFinal = 0;
                if (File.Exists(this.myAct.fpolyFinal))
                    File.Delete(this.myAct.fpolyFinal);
                this.kPolyFinal = 0;
                this.kRcPnt = 0;
                this.groupBox6.Visible = false;
                this.panel7.Invalidate();
            }
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            int ip;
            int kLin = ip = 0;
            double num1;
            double num2 = num1 = 0.0;
            if (this.kPolyProj == 0 && this.kTopoProj == 0)
            {
                int num3 = (int)MessageBox.Show("Процесс проектирования не был завершен", "Разделение участков со всеми проектными(графическими) линиями", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.kSel = -1;
                this.kRcPnt = 0;
                this.nProcess = 0;
            }
            else
            {
                this.myAct.TopoActLoad(this.nAction);
                this.kLineAct = this.myAct.kLineAct;
                if (this.kPntProj > 0)
                {
                    for (int index1 = 0; index1 <= this.kPntProj; ++index1)
                    {
                        ip = 0;
                        for (int index2 = 0; index2 <= this.kPntPlus; ++index2)
                        {
                            double num4 = this.myAct.xProj[index1] - this.myAct.xPnt[index2];
                            double num5 = this.myAct.yProj[index1] - this.myAct.yPnt[index2];
                            if (Math.Sqrt(num4 * num4 + num5 * num5) < this.tolerance)
                            {
                                ++ip;
                                break;
                            }
                        }
                        if (ip <= 0)
                        {
                            ++this.kPntPlus;
                            this.myAct.xPnt[this.kPntPlus] = this.myAct.xProj[index1];
                            this.myAct.yPnt[this.kPntPlus] = this.myAct.yProj[index1];
                        }
                    }
                }
                if (this.kNodeAct > 0)
                {
                    for (int index3 = 1; index3 <= this.kNodeAct; ++index3)
                    {
                        ip = 0;
                        for (int index4 = 0; index4 <= this.kPntPlus; ++index4)
                        {
                            double num6 = this.myAct.xNodeAct[index3] - this.myAct.xPnt[index4];
                            double num7 = this.myAct.yNodeAct[index3] - this.myAct.yPnt[index4];
                            if (Math.Sqrt(num6 * num6 + num7 * num7) < this.tolerance)
                            {
                                ++ip;
                                break;
                            }
                        }
                        if (ip <= 0)
                        {
                            ++this.kPntPlus;
                            this.myAct.namePnt[this.kPntPlus] = this.myAct.nameNodeAct[index3];
                            this.myAct.xPnt[this.kPntPlus] = this.myAct.xNodeAct[index3];
                            this.myAct.yPnt[this.kPntPlus] = this.myAct.yNodeAct[index3];
                        }
                    }
                }
                int kPol1 = -1;
                for (int index = 0; index <= this.kSel; ++index)
                {
                    ++kPol1;
                    this.myAct.xDop[kPol1] = this.myAct.xSel[index];
                    this.myAct.yDop[kPol1] = this.myAct.ySel[index];
                }
                int kin1 = 0;
                DllClass1.ParcelLine(kPol1, ref this.myAct.xDop, ref this.myAct.yDop, kin1, ref this.myAct.kin1, ref this.myAct.kin2, ref this.myAct.xActInt, ref this.myAct.yActInt, this.kTopoProj, ref this.myAct.RadTopo, ref this.myAct.kPrt1, ref this.myAct.kPrt2, ref this.myAct.xLinTopo, ref this.myAct.yLinTopo, out kLin, ref this.myAct.rWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.nWork, this.tolerance);
                if (kLin == 0)
                    return;
                int kNew1 = this.myAct.kActLine2[this.kLineAct];
                for (int index5 = 1; index5 <= kLin; ++index5)
                {
                    int num8 = this.myAct.nWork1[index5];
                    int num9 = this.myAct.nWork2[index5];
                    ip = 0;
                    for (int index6 = num8; index6 <= num9; ++index6)
                    {
                        ++ip;
                        ++kNew1;
                        this.myAct.xLineAct[kNew1] = this.myAct.xWork[index6];
                        this.myAct.yLineAct[kNew1] = this.myAct.yWork[index6];
                    }
                    ++this.kLineAct;
                    this.myAct.radAct[this.kLineAct] = this.myAct.rWork[index5];
                    this.myAct.kActLine1[this.kLineAct] = this.myAct.kActLine2[this.kLineAct - 1] + 1;
                    this.myAct.kActLine2[this.kLineAct] = this.myAct.kActLine2[this.kLineAct - 1] + ip;
                }
                this.panel1.Text = "Пожалуйста подождите....Построение топологии узла";
                int knd = 0;
                DllClass1.NodeTopology(this.tolerance, this.kPntPlus, ref this.myAct.xPnt, ref this.myAct.yPnt, this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, out this.kNodeAct, ref this.myAct.xNodeAct, ref this.myAct.yNodeAct, ref this.myAct.nWork, ref this.myAct.xDop, ref this.myAct.yDop, out knd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.panel1);
                this.panel1.Text = "Пожалуйста подождите....Построение линейной топологии";
                DllClass1.LineDivide(this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, knd, ref this.myAct.xAdd, ref this.myAct.yAdd, out kNew1, ref this.myAct.pWork, ref this.myAct.nDop1, ref this.myAct.nDop2, ref this.myAct.nDop3, ref this.myAct.xDop, ref this.myAct.yDop, this.tolerance, this.panel1);
                if (kNew1 == 0)
                    return;
                this.kLineAct = kNew1;
                for (int index = 1; index <= this.kLineAct; ++index)
                {
                    ip = this.myAct.nDop2[index] - this.myAct.nDop1[index];
                    if (ip == 1)
                        this.myAct.pWork[index] = 0.0;
                    this.myAct.radAct[index] = this.myAct.pWork[index];
                    this.myAct.kActLine1[index] = this.myAct.nDop1[index];
                    this.myAct.kActLine2[index] = this.myAct.nDop2[index];
                }
                kNew1 = this.myAct.kActLine2[this.kLineAct];
                for (int index = 1; index <= kNew1; ++index)
                {
                    this.myAct.xLineAct[index] = this.myAct.xDop[index];
                    this.myAct.yLineAct[index] = this.myAct.yDop[index];
                }
                double sArea = 0.0;
                int kOut = 0;
                DllClass1.ExteriorBox(this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, ref this.myAct.nExter, out kOut, ref this.myAct.xOut, ref this.myAct.yOut, out sArea, ref this.myAct.nWork);
                this.panel1.Text = "Пожалуйста подождите....Проверка двойных линий";
                DllClass1.RemoveDoubleLine(this.tolerance, ref this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, out kNew1, ref this.myAct.pWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.xDop, ref this.myAct.yDop, ref this.myAct.nWork, ref this.myAct.nDop1, ref this.myAct.nDop2, this.panel1);
                if (this.kLineAct > 0)
                    DllClass1.CleanLineTopo(ref this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.radAct, ref this.myAct.xLineAct, ref this.myAct.yLineAct, ref this.myAct.nWork, ref this.myAct.xWork, ref this.myAct.yWork, this.tolerance);
                this.panel1.Text = "Пожалуйста подождите....Построение полигональных топографических знаков";
                DllClass1.PolyTopology(this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, this.kNodeAct, ref this.myAct.xNodeAct, ref this.myAct.yNodeAct, out this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.nSymbPoly, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.nWork, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, this.tolerance, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.kn1, ref this.myAct.kn2, ref this.myAct.nExter, ref this.myAct.indInter, ref this.myAct.indPol, this.panel1);
                if (this.kPolyAct == 0)
                    return;
                if (this.kPolyAct > 1)
                {
                    int kPol2 = 0;
                    DllClass1.PolyDelete(this.kPolyAct, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out kPol2, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.nSymbPoly, ref this.myAct.kn1, ref this.myAct.kn2, ref this.myAct.xWork1, ref this.myAct.yWork1, this.tolerance, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.nWork);
                    if (kPol2 == 0)
                        return;
                    this.kPolyAct = kPol2;
                    for (int index = 1; index <= this.kPolyAct; ++index)
                        this.myAct.nameAct[index] = string.Format("{0}", (object)index);
                    for (int index = 1; index <= kPol2; ++index)
                    {
                        this.myAct.kActPoly1[index] = this.myAct.kn1[index];
                        this.myAct.kActPoly2[index] = this.myAct.kn2[index];
                    }
                    ip = this.myAct.kActPoly2[kPol2];
                    for (int index = 1; index <= ip; ++index)
                    {
                        this.myAct.xPolyAct[index] = this.myAct.xWork1[index];
                        this.myAct.yPolyAct[index] = this.myAct.yWork1[index];
                    }
                    int kin2 = 0;
                    DllClass1.PolyInterior(kPol2, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out kin2, ref this.myAct.indPol, ref this.myAct.kn1, ref this.myAct.kn2, ref this.myAct.nWork, ref this.myAct.indInter, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.rWork, ref this.myAct.pWork, ref this.myAct.zDop);
                    this.kIntAct = kin2;
                }
                this.myAct.PolyActPrev(ref this.myAct.kPolyInside, this.nAction);
                this.kPolyPrev = this.myAct.kPolyPrev;
                if (this.nProcess == 280)
                {
                    this.kPolyCancel = 0;
                    DllClass1.FindPolyCancel(this.kPolyPrev, ref this.myAct.namePoly, ref this.myAct.xLab, ref this.myAct.yLab, ref this.myAct.areaPol, ref this.myAct.areaLeg, ref this.myAct.kt1, ref this.myAct.kt2, ref this.myAct.xPol, ref this.myAct.yPol, this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out this.kPolyCancel, ref this.myAct.nameCanc, ref this.myAct.xLabCanc, ref this.myAct.yLabCanc, ref this.myAct.aCalcCanc, ref this.myAct.aLegCanc, ref this.myAct.xWork, ref this.myAct.yWork);
                }
                DllClass1.ActionCompare(this.kPolyPrev, ref this.myAct.xLab, ref this.myAct.yLab, ref this.myAct.areaPol, ref this.myAct.areaLeg, ref this.myAct.kt1, ref this.myAct.kt2, ref this.myAct.xPol, ref this.myAct.yPol, this.kPolyAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, ref this.myAct.xWork, ref this.myAct.yWork);
                this.PolyOrder();
                this.panel1.Text = "Пожалуйста подождите....Определение подписи(метки) полигона";
                DllClass1.KeepPolyLabel(this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xDop, ref this.myAct.yDop, ref this.myAct.zDop, ref this.myAct.nDop1, ref this.myAct.nDop2, ref this.myAct.nDop3, this.panel1);
                int kPnt1 = -1;
                for (int index = 1; index <= this.kPolySource; ++index)
                {
                    ++kPnt1;
                    this.myAct.nameDop[kPnt1] = this.myAct.nameSource[index];
                }
                DllClass1.NewPointName(kPnt1, this.myAct.nameDop, out this.maxParcel, out this.sTmp);
                --this.maxParcel;
                if (this.maxParcel < 0)
                    this.maxParcel = 0;
                int kNew2 = 0;
                DllClass1.ParcNewName(this.maxParcel, this.kPolySource, this.myAct.nameSource, this.myAct.xLabSource, this.myAct.yLabSource, this.myAct.arCalcSource, this.myAct.arLegSource, this.myAct.k1Source, this.myAct.k2Source, this.myAct.xSource, this.myAct.ySource, this.kPolyAct, this.myAct.nameAct, this.myAct.xAct, this.myAct.yAct, this.myAct.aActCalc, this.myAct.aActLeg, out kNew2, this.myAct.nameDop, this.myAct.xDop, this.myAct.yDop, this.myAct.xWork, this.myAct.yWork, this.myAct.xSpot, this.myAct.ySpot);
                if (this.maxParcel < 0)
                    this.maxParcel = 0;
                if (kNew2 > 1)
                {
                    if (!File.Exists(this.myAct.flistAction))
                    {
                        int num10 = (int)MessageBox.Show("Вернуться к Построение полигональных топографических знаков", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    FileStream output1 = new FileStream(this.myAct.flistAction, FileMode.Append);
                    BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                    this.sTmp = string.Format("{0}", (object)this.nProcess) + "   0";
                    binaryWriter1.Write(this.sTmp);
                    for (int index7 = 1; index7 <= this.kPolySource; ++index7)
                    {
                        int num11 = this.myAct.k1Source[index7];
                        int num12 = this.myAct.k2Source[index7];
                        kNew1 = -1;
                        for (int index8 = num11; index8 <= num12; ++index8)
                        {
                            ++kNew1;
                            this.myAct.xWork1[kNew1] = this.myAct.xSource[index8];
                            this.myAct.yWork1[kNew1] = this.myAct.ySource[index8];
                        }
                        DllClass1.NewInPrev(this.myAct.arCalcSource[index7], kNew1, this.myAct.xWork1, this.myAct.yWork1, kNew2, this.myAct.nameDop, this.myAct.xDop, this.myAct.yDop, this.myAct.xWork, this.myAct.yWork, out kPol1, this.myAct.nameWork, this.myAct.xOut, this.myAct.yOut, this.myAct.xWork2, this.myAct.yWork2);
                        if (kPol1 >= 2)
                        {
                            this.sTmp = this.myAct.nameSource[index7] + "   " + string.Format("{0:F4}", (object)this.myAct.arCalcSource[index7]) + "   " + string.Format("{0:F4}", (object)this.myAct.arLegSource[index7]);
                            binaryWriter1.Write(this.sTmp);
                            for (int index9 = 1; index9 <= kPol1; ++index9)
                            {
                                this.sTmp = this.myAct.nameWork[index9] + "   " + string.Format("{0:F4}", (object)this.myAct.xWork2[index9]) + "   " + string.Format("{0:F4}", (object)this.myAct.yWork2[index9]);
                                binaryWriter1.Write(this.sTmp);
                            }
                            this.sTmp = "0";
                            binaryWriter1.Write(this.sTmp);
                        }
                    }
                    binaryWriter1.Close();
                    output1.Close();
                    int kPnt2 = -1;
                    this.kPolySource = this.kPolyAct;
                    for (int index10 = 1; index10 <= this.kPolyAct; ++index10)
                    {
                        ++kPnt2;
                        this.myAct.nameAdd[kPnt2] = this.myAct.nameAct[index10];
                        this.myAct.nameSource[index10] = this.myAct.nameAct[index10];
                        this.myAct.xLabSource[index10] = this.myAct.xAct[index10];
                        this.myAct.yLabSource[index10] = this.myAct.yAct[index10];
                        this.myAct.arCalcSource[index10] = this.myAct.aActCalc[index10];
                        this.myAct.arLegSource[index10] = this.myAct.aActLeg[index10];
                        this.myAct.k1Source[index10] = this.myAct.kActPoly1[index10];
                        this.myAct.k2Source[index10] = this.myAct.kActPoly2[index10];
                        int num13 = this.myAct.k1Source[index10];
                        int num14 = this.myAct.k2Source[index10];
                        for (int index11 = num13; index11 <= num14; ++index11)
                        {
                            this.myAct.xSource[index11] = this.myAct.xPolyAct[index11];
                            this.myAct.ySource[index11] = this.myAct.yPolyAct[index11];
                        }
                    }
                    DllClass1.NewPointName(kPnt2, this.myAct.nameAdd, out this.maxParcel, out this.sTmp);
                    --this.maxParcel;
                    this.myAct.kPolySource = this.kPolySource;
                    this.myAct.LoadKeepSource(2);
                    if (this.nProcess == 290)
                    {
                        if (this.kNodeAct > 0)
                        {
                            int index12 = 0;
                            this.myAct.xDop[index12] = this.myAct.xSel[0];
                            this.myAct.yDop[index12] = this.myAct.ySel[0];
                            for (int index13 = 1; index13 <= this.kSel; ++index13)
                            {
                                kNew1 = 0;
                                for (int index14 = 1; index14 <= this.kNodeAct; ++index14)
                                {
                                    double num15 = this.myAct.xSel[index13 - 1] - this.myAct.xNodeAct[index14];
                                    double num16 = this.myAct.ySel[index13 - 1] - this.myAct.yNodeAct[index14];
                                    if (Math.Sqrt(num15 * num15 + num16 * num16) >= this.tolerance)
                                    {
                                        double xp = this.myAct.xSel[index13] - this.myAct.xNodeAct[index14];
                                        double yp = this.myAct.ySel[index13] - this.myAct.yNodeAct[index14];
                                        double dist = Math.Sqrt(xp * xp + yp * yp);
                                        if (dist >= this.tolerance)
                                        {
                                            DllClass1.DistPnt(this.myAct.xNodeAct[index14], this.myAct.yNodeAct[index14], this.myAct.xSel[index13 - 1], this.myAct.ySel[index13 - 1], this.myAct.xSel[index13], this.myAct.ySel[index13], out dist, out ip, out xp, out yp);
                                            if (ip > 0 && dist < this.tolerance)
                                            {
                                                ++kNew1;
                                                this.myAct.xWork[kNew1] = xp;
                                                this.myAct.yWork[kNew1] = yp;
                                            }
                                        }
                                    }
                                }
                                if (kNew1 == 1)
                                {
                                    ++index12;
                                    this.myAct.xDop[index12] = this.myAct.xWork[1];
                                    this.myAct.yDop[index12] = this.myAct.yWork[1];
                                }
                                if (kNew1 > 1)
                                {
                                    for (int index15 = 1; index15 <= kNew1; ++index15)
                                    {
                                        double num17 = this.myAct.xWork[index15] - this.myAct.xSel[index13 - 1];
                                        double num18 = this.myAct.yWork[index15] - this.myAct.ySel[index13 - 1];
                                        this.myAct.rWork[index15] = Math.Sqrt(num17 * num17 + num18 * num18);
                                    }
                                    for (int index16 = 1; index16 < kNew1; ++index16)
                                    {
                                        ip = index16 + 1;
                                        for (int index17 = ip; index17 <= kNew1; ++index17)
                                        {
                                            if (this.myAct.rWork[index16] > this.myAct.rWork[index17])
                                            {
                                                double num19 = this.myAct.xWork[index16];
                                                double num20 = this.myAct.yWork[index16];
                                                double num21 = this.myAct.rWork[index16];
                                                this.myAct.xWork[index16] = this.myAct.xWork[index17];
                                                this.myAct.yWork[index16] = this.myAct.yWork[index17];
                                                this.myAct.rWork[index16] = this.myAct.rWork[index17];
                                                this.myAct.xWork[index17] = num19;
                                                this.myAct.yWork[index17] = num20;
                                                this.myAct.rWork[index17] = num21;
                                            }
                                        }
                                    }
                                    for (int index18 = 1; index18 <= kNew1; ++index18)
                                    {
                                        ++index12;
                                        this.myAct.xDop[index12] = this.myAct.xWork[index18];
                                        this.myAct.yDop[index12] = this.myAct.yWork[index18];
                                    }
                                }
                                ++index12;
                                this.myAct.xDop[index12] = this.myAct.xSel[index13];
                                this.myAct.yDop[index12] = this.myAct.ySel[index13];
                            }
                            this.kSel = index12;
                            for (int index19 = 1; index19 <= this.kSel; ++index19)
                            {
                                this.myAct.xSel[index19] = this.myAct.xDop[index19];
                                this.myAct.ySel[index19] = this.myAct.yDop[index19];
                            }
                        }
                        this.kPolyCancel = 0;
                        DllClass1.PolyInside(this.kSel, ref this.myAct.xSel, ref this.myAct.ySel, ref this.kPolyAct, ref this.myAct.nameAct, 
                            ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.kActPoly1, 
                            ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out this.kPolyCancel, ref this.myAct.nameCanc,
                            ref this.myAct.xLabCanc, ref this.myAct.yLabCanc, ref this.myAct.aCalcCanc, ref this.myAct.aLegCanc, ref this.myAct.nWork1, 
                            ref this.myAct.nWork2, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.nWork, ref this.myAct.nDop3);
                        this.kLineCancel = 0;
                        double sMove = 0.1;
                        int kBord = 0;
                        DllClass1.ParallelBorder(sMove, this.kSel, ref this.myAct.xSel, ref this.myAct.ySel, this.selRad, this.xSelRad, this.ySelRad, 
                            ref this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, 
                            ref this.myAct.yLineAct, out this.kLineCancel, ref this.myAct.RadCanc, ref this.myAct.kLinCanc1, ref this.myAct.kLinCanc2,
                            ref this.myAct.xLinCanc, ref this.myAct.yLinCanc, out kBord, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.nWork, 
                            ref this.myAct.nDop3, ref this.myAct.xWork2, ref this.myAct.yWork2);
                        int index20 = 0;
                        for (int index21 = 1; index21 <= this.kNodeAct; ++index21)
                        {
                            ip = DllClass1.in_out(kBord, ref this.myAct.xWork1, ref this.myAct.yWork1, this.myAct.xNodeAct[index21], this.myAct.yNodeAct[index21]);
                            if (ip > 0)
                            {
                                int num22 = 0;
                                for (int index22 = 0; index22 <= this.kSel; ++index22)
                                {
                                    double num23 = this.myAct.xSel[index22] - this.myAct.xNodeAct[index21];
                                    double num24 = this.myAct.ySel[index22] - this.myAct.yNodeAct[index21];
                                    if (Math.Sqrt(num23 * num23 + num24 * num24) < this.tolerance)
                                    {
                                        ++num22;
                                        break;
                                    }
                                }
                                if (num22 <= 0)
                                {
                                    this.myAct.xNodeAct[index21] = 0.0;
                                    this.myAct.yNodeAct[index21] = 0.0;
                                }
                            }
                        }
                        for (int index23 = 1; index23 <= this.kNodeAct; ++index23)
                        {
                            if (this.myAct.xNodeAct[index23] != 0.0 || this.myAct.yNodeAct[index23] != 0.0)
                            {
                                ++index20;
                                this.myAct.nameNodeAct[index20] = this.myAct.nameNodeAct[index23];
                                this.myAct.xNodeAct[index20] = this.myAct.xNodeAct[index23];
                                this.myAct.yNodeAct[index20] = this.myAct.yNodeAct[index23];
                            }
                        }
                        this.kNodeAct = index20;
                        if (this.maxParcel < 0)
                            this.maxParcel = 0;
                        DllClass1.ParcNewName(this.maxParcel, this.kPolySource, this.myAct.nameSource, this.myAct.xLabSource, this.myAct.yLabSource, 
                            this.myAct.arCalcSource, this.myAct.arLegSource, this.myAct.k1Source, this.myAct.k2Source, this.myAct.xSource, this.myAct.ySource,
                            this.kPolyAct, this.myAct.nameAct, this.myAct.xAct, this.myAct.yAct, this.myAct.aActCalc, this.myAct.aActLeg, out kNew2, this.myAct.nameDop,
                            this.myAct.xDop, this.myAct.yDop, this.myAct.xWork, this.myAct.yWork, this.myAct.xSpot, this.myAct.ySpot);
                        if (this.maxParcel <= 0)
                            this.maxParcel = 0;
                        if (kNew2 > 0)
                        {
                            if (!File.Exists(this.myAct.flistAction))
                            {
                                int num25 = (int)MessageBox.Show("Вернуться к Построение полигональных топографических знаков", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            FileStream output2 = new FileStream(this.myAct.flistAction, FileMode.Append);
                            BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                            this.sTmp = "10   0";
                            binaryWriter2.Write(this.sTmp);
                            this.sTmp = this.myAct.nameDop[1] + "  " + string.Format("{0:F4}", (object)this.myAct.xWork[1]) + "  " + string.Format("{0:F4}", (object)this.myAct.yWork[1]);
                            binaryWriter2.Write(this.sTmp);
                            for (int index24 = 1; index24 <= this.kPolyCancel; ++index24)
                            {
                                this.sTmp = this.myAct.nameCanc[index24] + "  " + string.Format("{0:F4}", (object)this.myAct.aCalcCanc[index24]) + "  " + string.Format("{0:F4}", (object)this.myAct.aLegCanc[index24]);
                                binaryWriter2.Write(this.sTmp);
                            }
                            this.sTmp = "0";
                            binaryWriter2.Write(this.sTmp);
                            binaryWriter2.Close();
                            output2.Close();
                            kNew1 = this.myAct.k2Source[this.kPolySource];
                            ip = 0;
                            for (int index25 = 0; index25 <= this.kSel; ++index25)
                            {
                                ++ip;
                                ++kNew1;
                                this.myAct.xSource[kNew1] = this.myAct.xSel[index25];
                                this.myAct.ySource[kNew1] = this.myAct.ySel[index25];
                            }
                            ++this.kPolySource;
                            this.myAct.nameSource[this.kPolySource] = this.myAct.nameDop[1];
                            this.myAct.xLabSource[this.kPolySource] = this.myAct.xDop[1];
                            this.myAct.yLabSource[this.kPolySource] = this.myAct.yDop[1];
                            this.myAct.arCalcSource[this.kPolySource] = this.myAct.xWork[1];
                            this.myAct.arLegSource[this.kPolySource] = this.myAct.yWork[1];
                            this.myAct.k1Source[this.kPolySource] = this.myAct.k2Source[this.kPolySource - 1] + 1;
                            this.myAct.k2Source[this.kPolySource] = this.myAct.k2Source[this.kPolySource - 1] + ip;
                            this.myAct.kPolySource = this.kPolySource;
                            this.myAct.LoadKeepSource(2);
                            for (int index26 = 1; index26 <= this.kPolyAct; ++index26)
                            {
                                ++kPnt2;
                                this.myAct.nameAdd[kPnt2] = this.myAct.nameAct[index26];
                            }
                            DllClass1.NewPointName(kPnt2, this.myAct.nameAdd, out this.maxParcel, out this.sTmp);
                            --this.maxParcel;
                        }
                    }
                }
                this.ChangeAction();
                this.myAct.PolygonLoad(ref this.myAct.kPolyInside);
                this.kPoly = this.myAct.kPoly;
                this.panel1.Text = "Готов";
                this.button21.Visible = false;
                this.button30.Visible = false;
                this.groupBox6.Visible = false;
                this.nProcess = 0;
                this.nControl = 0;
                this.kSel = -1;
                this.kRcPnt = 0;
                if (File.Exists(this.myAct.flineFinal))
                    File.Delete(this.myAct.flineFinal);
                this.kLineFinal = 0;
                if (File.Exists(this.myAct.fpolyFinal))
                    File.Delete(this.myAct.fpolyFinal);
                this.kPolyFinal = 0;
                this.panel7.Invalidate();
            }
        }

        private void Unselect_Click(object sender, EventArgs e)
        {
            this.button21.Visible = false;
            this.button30.Visible = false;
            this.groupBox6.Visible = false;
            this.nProcess = 0;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.panel7.Invalidate();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (this.nProcess != 250)
            {
                if (this.textBox4.Text == "")
                {
                    int num = (int)MessageBox.Show("Введите данные в поле слева от кнопки 'Подтвердить'", "Разделение участков с помощью параллельной линии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DllClass1.CheckText(this.textBox4.Text, out this.areaInput, out this.iCond);
                if (this.iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.areaInput <= 0.0)
                {
                    int num = (int)MessageBox.Show("Введите данные в поле слева от кнопки 'Подтвердить'", "Разделение участков с помощью параллельной линии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.nProcess == 230 || this.nProcess == 260)
                {
                    if (this.areaInput >= 100.0)
                    {
                        int num = (int)MessageBox.Show("Процент > 100", "Разделение участков с помощью параллельной линии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    this.areaInput = 0.01 * this.areaInput * this.sCalc;
                }
                if ((this.nProcess == 210 || this.nProcess == 240) && this.areaInput >= this.sCalc)
                {
                    int num = (int)MessageBox.Show("Проверить вводимые данные", "Разделение участков с помощью параллельной линии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            int num1 = 0;
            this.xPoint = 0.0;
            this.yPoint = 0.0;
            double num2;
            double num3 = num2 = 0.0;
            double num4 = 0.0;
            int num5 = 0;
            double azHor = 0.0;
            double azVer = 0.0;
            int iPlusMin = 1;
            double fCoeff = 1.0;
            this.kPolyCancel = 0;
            this.kLineNew = 0;
            if (this.kNodeAct > 0)
            {
                for (int index1 = 1; index1 <= this.kNodeAct; ++index1)
                {
                    int num6 = 0;
                    for (int index2 = 0; index2 <= this.kPntPlus; ++index2)
                    {
                        double num7 = this.myAct.xNodeAct[index1] - this.myAct.xPnt[index2];
                        double num8 = this.myAct.yNodeAct[index1] - this.myAct.yPnt[index2];
                        if (Math.Sqrt(num7 * num7 + num8 * num8) < this.tolerance)
                        {
                            ++num6;
                            break;
                        }
                    }
                    if (num6 <= 0)
                    {
                        ++this.kPntPlus;
                        this.myAct.namePnt[this.kPntPlus] = this.myAct.nameNodeAct[index1];
                        this.myAct.xPnt[this.kPntPlus] = this.myAct.xNodeAct[index1];
                        this.myAct.yPnt[this.kPntPlus] = this.myAct.yNodeAct[index1];
                    }
                }
            }
            int num9 = this.myAct.kActPoly1[this.indPoly];
            int num10 = this.myAct.kActPoly2[this.indPoly];
            double xMove = this.myAct.xAct[this.indPoly];
            double yMove = this.myAct.yAct[this.indPoly];
            this.kPolyCancel = 1;
            this.myAct.nameCanc[1] = this.myAct.nameAct[this.indPoly];
            this.myAct.xLabCanc[1] = this.myAct.xAct[this.indPoly];
            this.myAct.yLabCanc[1] = this.myAct.yAct[this.indPoly];
            this.myAct.aCalcCanc[1] = this.myAct.aActCalc[this.indPoly];
            this.myAct.aLegCanc[1] = this.myAct.aActLeg[this.indPoly];
            this.kAdd = -1;
            for (int index = num9; index <= num10; ++index)
            {
                ++this.kAdd;
                this.myAct.xAdd[this.kAdd] = this.myAct.xPolyAct[index];
                this.myAct.yAdd[this.kAdd] = this.myAct.yPolyAct[index];
            }
            int index3 = 0;
            this.kInside = 0;
            for (int index4 = 1; index4 <= this.kPolyAct; ++index4)
            {
                if (index4 != this.indPoly && DllClass1.in_out(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.myAct.xAct[index4], 
                    this.myAct.yAct[index4]) != 0 && this.myAct.aActCalc[index4] < this.myAct.aActCalc[this.indPoly])
                {
                    int num11 = this.myAct.kActPoly1[index4];
                    int num12 = this.myAct.kActPoly2[index4];
                    int num13 = 0;
                    for (int index5 = num11; index5 <= num12; ++index5)
                    {
                        ++index3;
                        ++num13;
                        this.myAct.xPolProj[index3] = this.myAct.xPolyAct[index5];
                        this.myAct.yPolProj[index3] = this.myAct.yPolyAct[index5];
                    }
                    ++this.kInside;
                    this.myAct.kParc[this.kInside] = num13;
                }
            }
            if (this.kInside > 0)
            {
                this.myAct.kPol1[1] = 1;
                this.myAct.kPol2[1] = this.myAct.kParc[1];
                if (this.kInside > 1)
                {
                    for (int index6 = 2; index6 <= this.kInside; ++index6)
                    {
                        this.myAct.kPol1[index6] = this.myAct.kPol2[index6 - 1] + 1;
                        this.myAct.kPol2[index6] = this.myAct.kPol2[index6 - 1] + this.myAct.kParc[index6];
                    }
                }
            }
            int kLin1 = 0;
            DllClass1.ParcelLine(this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.kInside, ref this.myAct.kPol1, ref this.myAct.kPol2,
                ref this.myAct.xPolProj, ref this.myAct.yPolProj, this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2,
                ref this.myAct.xLineAct, ref this.myAct.yLineAct, out kLin1, ref this.myAct.radParc, ref this.myAct.nProj1, ref this.myAct.nProj2,
                ref this.myAct.xLinProj, ref this.myAct.yLinProj, ref this.myAct.nWork, this.tolerance);
            this.xPoint = 0.0;
            this.yPoint = 0.0;
            num1 = kLin1;
            num4 = 0.0;
            int numVar = 0;
            num5 = 0;
            if (this.nProcess == 210 || this.nProcess == 220 || this.nProcess == 230)
            {
                int iParam = 1;
                if (this.nProcess == 220)
                    iParam = 2;
                if (this.nProcess == 230)
                    iParam = 3;
                DllClass1.FirstParallel(iParam, this.areaInput, this.sCalc, this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, ref this.kSel, ref this.myAct.xSel, 
                    ref this.myAct.ySel, this.selRad, this.xSelRad, this.ySelRad, out xMove, out yMove, out this.xPoint, out this.yPoint, out azHor, out azVer, 
                    ref this.myAct.xDop, ref this.myAct.yDop, ref this.myAct.zDop);
                do
                {
                    ++numVar;
                    this.panel1.Text = "Пожалуйста подождите....Вычисление чисел = " + Convert.ToString(numVar);
                    DllClass1.ParallelParcel(xMove, yMove, azHor, this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.kInside, ref this.myAct.kPol1, ref this.myAct.kPol2, 
                        ref this.myAct.xPolProj, ref this.myAct.yPolProj, this.selRad, this.xSelRad, this.ySelRad, out this.kParcDop, ref this.myAct.radDop, ref this.myAct.kParcDop1,
                        ref this.myAct.kParcDop2, ref this.myAct.xParcDop, ref this.myAct.yParcDop, ref this.myAct.xOut, ref this.myAct.yOut, ref this.myAct.zWork, ref this.myAct.xDop, ref this.myAct.yDop);
                    if (this.kParcDop == 0)
                    {
                        int num14 = (int)MessageBox.Show("Проверьте вводимые данные", "Разделение участков с помощью параллельной линии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    int kLin2 = kLin1;
                    int index7 = this.myAct.nProj2[kLin2];
                    this.kNodeParc = 0;
                    for (int index8 = 1; index8 <= this.kParcDop; ++index8)
                    {
                        int index9 = this.myAct.kParcDop1[index8];
                        int index10 = this.myAct.kParcDop2[index8];
                        ++this.kNodeParc;
                        this.myAct.xNodeParc[this.kNodeParc] = this.myAct.xParcDop[index9];
                        this.myAct.yNodeParc[this.kNodeParc] = this.myAct.yParcDop[index9];
                        ++this.kNodeParc;
                        this.myAct.xNodeParc[this.kNodeParc] = this.myAct.xParcDop[index10];
                        this.myAct.yNodeParc[this.kNodeParc] = this.myAct.yParcDop[index10];
                        int num15 = 0;
                        for (int index11 = index9; index11 <= index10; ++index11)
                        {
                            ++num15;
                            ++index7;
                            this.myAct.xLinProj[index7] = this.myAct.xParcDop[index11];
                            this.myAct.yLinProj[index7] = this.myAct.yParcDop[index11];
                        }
                        this.myAct.nWork[index8] = num15;
                    }
                    for (int index12 = 1; index12 <= this.kParcDop; ++index12)
                    {
                        ++kLin2;
                        this.myAct.radParc[kLin2] = this.myAct.radDop[index12];
                        this.myAct.nProj1[kLin2] = this.myAct.nProj2[kLin2 - 1] + 1;
                        this.myAct.nProj2[kLin2] = this.myAct.nProj2[kLin2 - 1] + this.myAct.nWork[index12];
                    }
                    this.panel1.Text = "Пожалуйста подождите....Построение линейной топологии";
                    this.kLineParc = 0;
                    DllClass1.LineDivide(kLin2, ref this.myAct.radParc, ref this.myAct.nProj1, ref this.myAct.nProj2, ref this.myAct.xLinProj, ref this.myAct.yLinProj, this.kNodeParc, ref this.myAct.xNodeParc, ref this.myAct.yNodeParc, out this.kLineParc, ref this.myAct.rWork, ref this.myAct.kParc1, ref this.myAct.kParc2, ref this.myAct.kParc, ref this.myAct.xLinParc, ref this.myAct.yLinParc, this.tolerance, this.panel1);
                    if (this.kLineParc == 0)
                        return;
                    this.panel1.Text = "Пожалуйста подождите....Построение полигональных топографических знаков";
                    this.kPolyParc = 0;
                    this.kInParc = 0;
                    DllClass1.LinesToPoly(this.tolerance, this.kLineParc, ref this.myAct.kParc1, ref this.myAct.kParc2, ref this.myAct.xLinParc, ref this.myAct.yLinParc, this.kNodeParc, ref this.myAct.xNodeParc, ref this.myAct.yNodeParc, out this.kPolyParc, ref this.myAct.nameParc, ref this.myAct.xParc, ref this.myAct.yParc, ref this.myAct.aParcCalc, ref this.myAct.aParcLeg, ref this.myAct.nSymbPoly, ref this.myAct.kPolPar1, ref this.myAct.kPolPar2, ref this.myAct.xPolParc, ref this.myAct.yPolParc, out this.kInParc, ref this.myAct.indPol, ref this.myAct.kin1, ref this.myAct.kin2, ref this.myAct.nWork, ref this.myAct.indInter, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.pWork, ref this.myAct.rWork, ref this.myAct.zDop, this.panel1);
                    if (this.kPolyParc == 0)
                        return;
                    this.idPoly = 0;
                    for (int index13 = 1; index13 <= this.kPolyParc; ++index13)
                    {
                        int num16 = this.myAct.kPolPar1[index13];
                        int num17 = this.myAct.kPolPar2[index13];
                        int k = -1;
                        for (int index14 = num16; index14 <= num17; ++index14)
                        {
                            ++k;
                            this.myAct.xOut[k] = this.myAct.xPolParc[index14];
                            this.myAct.yOut[k] = this.myAct.yPolParc[index14];
                        }
                        if (DllClass1.in_out(k, ref this.myAct.xOut, ref this.myAct.yOut, this.xPoint, this.yPoint) > 0)
                        {
                            this.areaSel = this.myAct.aParcCalc[index13];
                            this.idPoly = index13;
                            break;
                        }
                    }
                    if (iParam != 2)
                    {
                        double num18 = this.areaInput - this.areaSel;
                        if (Math.Abs(num18) < 0.001)
                        {
                            this.myAct.aParcCalc[this.idPoly] = this.areaInput;
                            break;
                        }
                        if (this.selRad <= 0.0)
                        {
                            double num19 = num18 / this.areaInput;
                            double num20 = xMove - this.xPoint;
                            double num21 = yMove - this.yPoint;
                            double num22 = Math.Sqrt(num20 * num20 + num21 * num21);
                            double num23 = num19 * num22;
                            xMove += num23 * Math.Cos(azVer);
                            yMove += num23 * Math.Sin(azVer);
                        }
                        if (this.selRad > 0.0)
                        {
                            double num24 = num18 / this.areaInput;
                            double x = xMove - this.xPoint;
                            double y = yMove - this.yPoint;
                            double num25 = Math.Sqrt(x * x + y * y);
                            azVer = Math.Atan2(y, x);
                            if (azVer < 0.0)
                                azVer += 6.2831852;
                            double num26 = num24 * num25;
                            xMove += num26 * Math.Cos(azVer);
                            yMove += num26 * Math.Sin(azVer);
                        }
                    }
                    else
                        break;
                }
                while (numVar < 150);
                if (numVar > 140)
                {
                    int num27 = (int)MessageBox.Show("Проверьте данные", "Разделение участков с помощью параллельной линии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (this.nProcess == 240 || this.nProcess == 250 || this.nProcess == 260)
            {
                int iParam = 1;
                if (this.nProcess == 250)
                    iParam = 2;
                if (this.nProcess == 260)
                    iParam = 3;
                DllClass1.FirstPerpendicular(iParam, this.areaInput, this.sCalc, this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, ref this.kSel, ref this.myAct.xSel, ref this.myAct.ySel, this.selRad, this.xSelRad, this.ySelRad, out xMove, out yMove, out this.xPoint, out this.yPoint, out azHor, out azVer, ref this.myAct.xDop, ref this.myAct.yDop, ref this.myAct.zDop);
                do
                {
                    ++numVar;
                    this.panel1.Text = "Вычисление чисел = " + Convert.ToString(numVar);
                    DllClass1.PerpendicularParcel(xMove, yMove, azVer, this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, this.kInside, ref this.myAct.kPol1, ref this.myAct.kPol2, ref this.myAct.xPolProj, ref this.myAct.yPolProj, this.selRad, this.xSelRad, this.ySelRad, out this.kParcDop, ref this.myAct.radDop, ref this.myAct.kParcDop1, ref this.myAct.kParcDop2, ref this.myAct.xParcDop, ref this.myAct.yParcDop, ref this.myAct.xOut, ref this.myAct.yOut, ref this.myAct.zWork, ref this.myAct.xInter, ref this.myAct.yInter, ref this.myAct.nWork, this.tolerance);
                    if (this.kParcDop == 0)
                    {
                        int num28 = (int)MessageBox.Show("Проверьте вводимые данные", "Разделение участков перпендикулярной линией", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    int kLin3 = kLin1;
                    int index15 = this.myAct.nProj2[kLin3];
                    this.kNodeParc = 0;
                    for (int index16 = 1; index16 <= this.kParcDop; ++index16)
                    {
                        int index17 = this.myAct.kParcDop1[index16];
                        int index18 = this.myAct.kParcDop2[index16];
                        ++this.kNodeParc;
                        this.myAct.xNodeParc[this.kNodeParc] = this.myAct.xParcDop[index17];
                        this.myAct.yNodeParc[this.kNodeParc] = this.myAct.yParcDop[index17];
                        ++this.kNodeParc;
                        this.myAct.xNodeParc[this.kNodeParc] = this.myAct.xParcDop[index18];
                        this.myAct.yNodeParc[this.kNodeParc] = this.myAct.yParcDop[index18];
                        int num29 = 0;
                        for (int index19 = index17; index19 <= index18; ++index19)
                        {
                            ++num29;
                            ++index15;
                            this.myAct.xLinProj[index15] = this.myAct.xParcDop[index19];
                            this.myAct.yLinProj[index15] = this.myAct.yParcDop[index19];
                        }
                        this.myAct.nWork[index16] = num29;
                    }
                    for (int index20 = 1; index20 <= this.kParcDop; ++index20)
                    {
                        ++kLin3;
                        this.myAct.radParc[kLin3] = this.myAct.radDop[index20];
                        this.myAct.nProj1[kLin3] = this.myAct.nProj2[kLin3 - 1] + 1;
                        this.myAct.nProj2[kLin3] = this.myAct.nProj2[kLin3 - 1] + this.myAct.nWork[index20];
                    }
                    this.panel1.Text = "Пожалуйста подождите....Построение линейной топологии";
                    this.kLineParc = 0;
                    DllClass1.LineDivide(kLin3, ref this.myAct.radParc, ref this.myAct.nProj1, ref this.myAct.nProj2, ref this.myAct.xLinProj, ref this.myAct.yLinProj, this.kNodeParc, ref this.myAct.xNodeParc, ref this.myAct.yNodeParc, out this.kLineParc, ref this.myAct.rWork, ref this.myAct.kParc1, ref this.myAct.kParc2, ref this.myAct.kParc, ref this.myAct.xLinParc, ref this.myAct.yLinParc, this.tolerance, this.panel1);
                    if (this.kLineParc == 0)
                        return;
                    this.panel1.Text = "Пожалуйста подождите....Построение полигональных топографических знаков";
                    this.kPolyParc = 0;
                    this.kInParc = 0;
                    DllClass1.LinesToPoly(this.tolerance, this.kLineParc, ref this.myAct.kParc1, ref this.myAct.kParc2, ref this.myAct.xLinParc, ref this.myAct.yLinParc, this.kNodeParc, ref this.myAct.xNodeParc, ref this.myAct.yNodeParc, out this.kPolyParc, ref this.myAct.nameParc, ref this.myAct.xParc, ref this.myAct.yParc, ref this.myAct.aParcCalc, ref this.myAct.aParcLeg, ref this.myAct.nSymbPoly, ref this.myAct.kPolPar1, ref this.myAct.kPolPar2, ref this.myAct.xPolParc, ref this.myAct.yPolParc, out this.kInParc, ref this.myAct.indPol, ref this.myAct.kin1, ref this.myAct.kin2, ref this.myAct.nWork, ref this.myAct.indInter, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.pWork, ref this.myAct.rWork, ref this.myAct.zDop, this.panel1);
                    if (this.kPolyParc == 0)
                        return;
                    this.idPoly = 0;
                    for (int index21 = 1; index21 <= this.kPolyParc; ++index21)
                    {
                        int num30 = this.myAct.kPolPar1[index21];
                        int num31 = this.myAct.kPolPar2[index21];
                        int k = -1;
                        for (int index22 = num30; index22 <= num31; ++index22)
                        {
                            ++k;
                            this.myAct.xOut[k] = this.myAct.xPolParc[index22];
                            this.myAct.yOut[k] = this.myAct.yPolParc[index22];
                        }
                        if (DllClass1.in_out(k, ref this.myAct.xOut, ref this.myAct.yOut, this.xPoint, this.yPoint) > 0)
                        {
                            this.areaSel = this.myAct.aParcCalc[index21];
                            this.idPoly = index21;
                            break;
                        }
                    }
                    if (iParam != 2)
                    {
                        double num32 = this.areaInput - this.areaSel;
                        if (numVar > 1 && Math.Abs(num32) < 0.001)
                        {
                            this.myAct.aParcCalc[this.idPoly] = this.areaInput;
                            break;
                        }
                        if (this.selRad <= 0.0)
                        {
                            double num33 = num32 / this.areaInput;
                            double num34 = xMove - this.xPoint;
                            double num35 = yMove - this.yPoint;
                            double num36 = Math.Sqrt(num34 * num34 + num35 * num35);
                            double num37 = num33 * num36;
                            xMove += num37 * Math.Cos(azHor);
                            yMove += num37 * Math.Sin(azHor);
                        }
                        if (this.selRad > 0.0)
                        {
                            this.difArea[numVar] = num32;
                            int iCond = 0;
                            DllClass1.PerpendicularMove(ref xMove, ref yMove, ref azVer, this.areaInput, this.areaSel, this.sCalc, this.kAdd, ref this.myAct.xAdd, ref this.myAct.yAdd, ref this.kSel, ref this.myAct.xSel, ref this.myAct.ySel, this.selRad, this.xSelRad, this.ySelRad, out iCond, ref this.myAct.xDop, ref this.myAct.yDop, ref this.myAct.zDop, numVar, this.difArea, ref iPlusMin, ref fCoeff);
                            if (Math.Abs(this.difArea[numVar]) < 0.001)
                            {
                                this.myAct.aParcCalc[this.idPoly] = this.areaInput;
                                break;
                            }
                            if (iCond <= 0)
                            {
                                if (iCond < 0)
                                {
                                    int num38 = (int)MessageBox.Show("Ищите другое решение", "Разделение участков перпендикулярной линией", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }
                            else
                                break;
                        }
                    }
                    else
                        break;
                }
                while (numVar < 150);
                if (numVar > 145)
                {
                    int num39 = (int)MessageBox.Show("Ищите другое решение", "Разделение участков перпендикулярной линией", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            this.panel1.Text = "New area,sq.m = " + string.Format("{0:F4}", (object)this.areaSel);
            if (this.kNodeParc > 0)
            {
                for (int index23 = 1; index23 <= this.kNodeParc; ++index23)
                {
                    int num40 = 0;
                    for (int index24 = 1; index24 <= this.kNodeAct; ++index24)
                    {
                        double num41 = this.myAct.xNodeParc[index23] - this.myAct.xNodeAct[index24];
                        double num42 = this.myAct.yNodeParc[index23] - this.myAct.yNodeAct[index24];
                        if (Math.Sqrt(num41 * num41 + num42 * num42) < this.tolerance)
                        {
                            ++num40;
                            break;
                        }
                    }
                    if (num40 <= 0)
                    {
                        ++this.kNodeAct;
                        this.myAct.nameNodeAct[this.kNodeAct] = "n999";
                        this.myAct.xNodeAct[this.kNodeAct] = this.myAct.xNodeParc[index23];
                        this.myAct.yNodeAct[this.kNodeAct] = this.myAct.yNodeParc[index23];
                    }
                }
            }
            int index25 = this.myAct.kActLine2[this.kLineAct];
            int index26 = 0;
            for (int index27 = 1; index27 <= this.kParcDop; ++index27)
            {
                int num43 = this.myAct.kParcDop1[index27];
                int num44 = this.myAct.kParcDop2[index27];
                int num45 = 0;
                for (int index28 = num43; index28 <= num44; ++index28)
                {
                    ++num45;
                    ++index25;
                    this.myAct.xLineAct[index25] = this.myAct.xParcDop[index28];
                    this.myAct.yLineAct[index25] = this.myAct.yParcDop[index28];
                    ++index26;
                    this.myAct.xLinNew[index26] = this.myAct.xParcDop[index28];
                    this.myAct.yLinNew[index26] = this.myAct.yParcDop[index28];
                }
                this.myAct.nWork[index27] = num45;
            }
            for (int index29 = 1; index29 <= this.kParcDop; ++index29)
            {
                ++this.kLineAct;
                this.myAct.radAct[this.kLineAct] = this.myAct.radDop[index29];
                this.myAct.kActLine1[this.kLineAct] = this.myAct.kActLine2[this.kLineAct - 1] + 1;
                this.myAct.kActLine2[this.kLineAct] = this.myAct.kActLine2[this.kLineAct - 1] + this.myAct.nWork[index29];
            }
            this.kLineNew = this.kParcDop;
            this.myAct.kLinNew1[1] = 1;
            this.myAct.kLinNew2[1] = this.myAct.nWork[1];
            if (this.kLineNew > 1)
            {
                for (int index30 = 2; index30 <= this.kLineNew; ++index30)
                {
                    this.myAct.kLinNew1[index30] = this.myAct.kLinNew2[index30 - 1] + 1;
                    this.myAct.kLinNew2[index30] = this.myAct.kLinNew2[index30 - 1] + this.myAct.nWork[index30];
                }
            }
            this.myAct.KeepLineNew(this.nAction);
            this.kLineParc = 0;
            DllClass1.LineDivide(this.kLineAct, ref this.myAct.radAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, this.kNodeParc, ref this.myAct.xNodeParc, ref this.myAct.yNodeParc, out this.kLineParc, ref this.myAct.rWork, ref this.myAct.kParc1, ref this.myAct.kParc2, ref this.myAct.kParc, ref this.myAct.xLinParc, ref this.myAct.yLinParc, this.tolerance, this.panel1);
            if (this.kLineParc == 0)
                return;
            int index31 = 0;
            this.kLineAct = this.kLineParc;
            for (int index32 = 1; index32 <= this.kLineParc; ++index32)
            {
                this.myAct.radAct[index32] = this.myAct.rWork[index32];
                this.myAct.kActLine1[index32] = this.myAct.kParc1[index32];
                this.myAct.kActLine2[index32] = this.myAct.kParc2[index32];
                int num46 = this.myAct.kParc1[index32];
                int num47 = this.myAct.kParc2[index32];
                for (int index33 = num46; index33 <= num47; ++index33)
                {
                    ++index31;
                    this.myAct.xLineAct[index31] = this.myAct.xLinParc[index33];
                    this.myAct.yLineAct[index31] = this.myAct.yLinParc[index33];
                }
            }
            this.kPolyAct = 0;
            this.kIntAct = 0;
            this.panel1.Text = "Пожалуйста подождите....Построение полигональных топографических знаков";
            DllClass1.LinesToPoly(this.tolerance, this.kLineAct, ref this.myAct.kActLine1, ref this.myAct.kActLine2, ref this.myAct.xLineAct, ref this.myAct.yLineAct, this.kNodeAct, ref this.myAct.xNodeAct, ref this.myAct.yNodeAct, out this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.nSymbPoly, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, out this.kIntAct, ref this.myAct.kIndexAct, ref this.myAct.kIndexAct1, ref this.myAct.kIndexAct2, ref this.myAct.nWork, ref this.myAct.indInter, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.nWork1, ref this.myAct.nWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.pWork, ref this.myAct.rWork, ref this.myAct.zDop, this.panel1);
            if (this.kPolyAct == 0)
                return;
            this.myAct.PolyActPrev(ref this.myAct.kPolyInside, this.nAction);
            this.kPolyPrev = this.myAct.kPolyPrev;
            DllClass1.ActionCompare(this.kPolyPrev, ref this.myAct.xLab, ref this.myAct.yLab, ref this.myAct.areaPol, ref this.myAct.areaLeg, ref this.myAct.kt1, ref this.myAct.kt2, ref this.myAct.xPol, ref this.myAct.yPol, this.kPolyAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.aActCalc, ref this.myAct.aActLeg, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, ref this.myAct.xWork, ref this.myAct.yWork);
            this.PolyOrder();
            this.panel1.Text = "Пожалуйста подождите....Определение подписи(метки) полигона";
            DllClass1.KeepPolyLabel(this.kPolyAct, ref this.myAct.nameAct, ref this.myAct.xAct, ref this.myAct.yAct, ref this.myAct.kActPoly1, ref this.myAct.kActPoly2, ref this.myAct.xPolyAct, ref this.myAct.yPolyAct, ref this.myAct.xWork1, ref this.myAct.yWork1, ref this.myAct.xWork2, ref this.myAct.yWork2, ref this.myAct.xWork, ref this.myAct.yWork, ref this.myAct.zWork, ref this.myAct.xDop, ref this.myAct.yDop, ref this.myAct.zDop, ref this.myAct.nDop1, ref this.myAct.nDop2, ref this.myAct.nDop3, this.panel1);
            if (this.maxParcel < 0)
                this.maxParcel = 0;
            int kNew = 0;
            DllClass1.ParcNewName(this.maxParcel, this.kPolySource, this.myAct.nameSource, this.myAct.xLabSource, this.myAct.yLabSource, this.myAct.arCalcSource, this.myAct.arLegSource, this.myAct.k1Source, this.myAct.k2Source, this.myAct.xSource, this.myAct.ySource, this.kPolyAct, this.myAct.nameAct, this.myAct.xAct, this.myAct.yAct, this.myAct.aActCalc, this.myAct.aActLeg, out kNew, this.myAct.nameDop, this.myAct.xDop, this.myAct.yDop, this.myAct.xWork, this.myAct.yWork, this.myAct.xSpot, this.myAct.ySpot);
            if (this.maxParcel < 0)
                this.maxParcel = 0;
            if (kNew > 1)
            {
                if (!File.Exists(this.myAct.flistAction))
                {
                    int num48 = (int)MessageBox.Show("Вернуться к Построение полигональных топографических знаков", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                FileStream output = new FileStream(this.myAct.flistAction, FileMode.Append);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                this.sTmp = string.Format("{0}", (object)this.nProcess) + "   " + string.Format("{0:F4}", (object)this.areaInput);
                binaryWriter.Write(this.sTmp);
                this.sTmp = this.myAct.nameCanc[1] + "   " + string.Format("{0:F4}", (object)this.myAct.aCalcCanc[1]) + "   " + string.Format("{0:F4}", (object)this.myAct.aLegCanc[1]);
                binaryWriter.Write(this.sTmp);
                for (int index34 = 1; index34 <= kNew; ++index34)
                {
                    double num49 = 9999999.9;
                    int index35 = 0;
                    for (int index36 = 1; index36 <= this.kPolySource; ++index36)
                    {
                        double num50 = this.myAct.xLabSource[index36] - this.myAct.xDop[index34];
                        double num51 = this.myAct.yLabSource[index36] - this.myAct.yDop[index34];
                        double num52 = Math.Sqrt(num50 * num50 + num51 * num51);
                        if (num52 < num49)
                        {
                            num49 = num52;
                            index35 = index36;
                        }
                    }
                    double num53 = Math.Abs(this.myAct.xWork[index34] - this.myAct.arCalcSource[index35]);
                    if (num49 < 0.1 && num53 < 0.1)
                    {
                        this.myAct.nameSource[index35] = this.myAct.nameDop[index34];
                    }
                    else
                    {
                        this.sTmp = this.myAct.nameDop[index34] + "   " + string.Format("{0:F4}", (object)this.myAct.xWork[index34]) + "   " + string.Format("{0:F4}", (object)this.myAct.yWork[index34]);
                        binaryWriter.Write(this.sTmp);
                    }
                }
                this.sTmp = "0";
                binaryWriter.Write(this.sTmp);
                binaryWriter.Close();
                output.Close();
                int kPnt = -1;
                this.kPolySource = this.kPolyAct;
                for (int index37 = 1; index37 <= this.kPolyAct; ++index37)
                {
                    ++kPnt;
                    this.myAct.nameDop[kPnt] = this.myAct.nameAct[index37];
                    this.myAct.nameSource[index37] = this.myAct.nameAct[index37];
                    this.myAct.xLabSource[index37] = this.myAct.xAct[index37];
                    this.myAct.yLabSource[index37] = this.myAct.yAct[index37];
                    this.myAct.arCalcSource[index37] = this.myAct.aActCalc[index37];
                    this.myAct.arLegSource[index37] = this.myAct.aActLeg[index37];
                    this.myAct.k1Source[index37] = this.myAct.kActPoly1[index37];
                    this.myAct.k2Source[index37] = this.myAct.kActPoly2[index37];
                    int num54 = this.myAct.k1Source[index37];
                    int num55 = this.myAct.k2Source[index37];
                    for (int index38 = num54; index38 <= num55; ++index38)
                    {
                        this.myAct.xSource[index38] = this.myAct.xPolyAct[index38];
                        this.myAct.ySource[index38] = this.myAct.yPolyAct[index38];
                    }
                }
                DllClass1.NewPointName(kPnt, this.myAct.nameDop, out this.maxParcel, out this.sTmp);
                --this.maxParcel;
                this.myAct.kPolySource = this.kPolySource;
                this.myAct.LoadKeepSource(2);
            }
            this.ChangeAction();
            this.panel1.Text = "Готов...";
            this.kSel = -1;
            this.kRcPnt = 0;
            this.areaInput = 0.0;
            this.nProcess = 0;
            this.nControl = 0;
            this.button19.Visible = false;
            this.button29.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.label4.Visible = false;
            this.textBox4.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.groupBox6.Visible = false;
            if (File.Exists(this.myAct.flineFinal))
                File.Delete(this.myAct.flineFinal);
            this.kLineFinal = 0;
            if (File.Exists(this.myAct.fpolyFinal))
                File.Delete(this.myAct.fpolyFinal);
            this.kPolyFinal = 0;
            this.panel7.Invalidate();
        }

        private void Abolish_Click(object sender, EventArgs e)
        {
            this.kSel = -1;
            this.kRcPnt = 0;
            this.areaInput = 0.0;
            this.nProcess = 0;
            this.nControl = 0;
            this.button19.Visible = false;
            this.button29.Visible = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.label4.Visible = false;
            this.textBox4.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.groupBox6.Visible = false;
            this.panel7.Invalidate();
        }

        private void GetInfo_Click(object sender, EventArgs e)
        {
            this.nProcess = 300;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            if (this.kPolyAct == 0)
            {
                int num = (int)MessageBox.Show("Данные отсутствуют", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.groupBox5.Visible = true;
                this.groupBox6.Visible = true;
                this.button19.Visible = false;
                this.button29.Visible = false;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.label4.Visible = false;
                this.label5.Visible = false;
                this.textBox4.Visible = false;
                this.textBox5.Visible = false;
                this.textBox6.Visible = false;
                this.panel7.Invalidate();
            }
        }

        private void LastRemove_Click(object sender, EventArgs e)
        {
            if (this.nAction == 0)
            {
                int num1 = (int)MessageBox.Show("Все изменения удалены", "Действия с участкомs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nProcess = 400;
                this.nControl = 0;
                if (MessageBox.Show("Do you really want to Remove Last Action ?", "Действия с участком", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                this.ActionDelete();
                this.myAct.KeepLoadAction(1);
                this.nAction = this.myAct.nAction;
                if (this.nAction > 0)
                {
                    this.myAct.NodeActLoad(this.nAction);
                    this.kNodeAct = this.myAct.kNodeAct;
                    this.myAct.TopoActLoad(this.nAction);
                    this.kLineAct = this.myAct.kLineAct;
                    this.myAct.PolyActLoad(this.nAction);
                    this.kPolyAct = this.myAct.kPolyAct;
                    this.myAct.KeepListing(this.myAct.nameDop, this.myAct.nDop3);
                }
                if (this.nAction == 0)
                {
                    this.myAct.nAction = this.nAction;
                    this.myAct.kPoly = this.kPoly;
                    this.myAct.kNode = this.kNode;
                    this.myAct.KeepActionZero();
                    this.kLineAct = this.myAct.kLineAct;
                    this.kPolyAct = this.myAct.kPolyAct;
                    this.kIntAct = this.myAct.kIntAct;
                    this.kNodeAct = this.myAct.kNodeAct;
                    if (File.Exists(this.myAct.flistAction))
                        File.Delete(this.myAct.flistAction);
                    FileStream output = new FileStream(this.myAct.flistAction, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    this.sTmp = "0";
                    binaryWriter.Write(this.sTmp);
                    binaryWriter.Close();
                    output.Close();
                }
                this.kPolySource = this.kPolyAct;
                if (this.kPolyAct == 0 && File.Exists(this.myAct.fsourcePoly))
                    File.Delete(this.myAct.fsourcePoly);
                if (this.kPolyAct > 0)
                {
                    int kPnt = -1;
                    for (int index1 = 1; index1 <= this.kPolyAct; ++index1)
                    {
                        ++kPnt;
                        this.myAct.nameDop[kPnt] = this.myAct.nameAct[index1];
                        this.myAct.nameSource[index1] = this.myAct.nameAct[index1];
                        this.myAct.xLabSource[index1] = this.myAct.xAct[index1];
                        this.myAct.yLabSource[index1] = this.myAct.yAct[index1];
                        this.myAct.arCalcSource[index1] = this.myAct.aActCalc[index1];
                        this.myAct.arLegSource[index1] = this.myAct.aActLeg[index1];
                        this.myAct.k1Source[index1] = this.myAct.kActPoly1[index1];
                        this.myAct.k2Source[index1] = this.myAct.kActPoly2[index1];
                        int num2 = this.myAct.k1Source[index1];
                        int num3 = this.myAct.k2Source[index1];
                        for (int index2 = num2; index2 <= num3; ++index2)
                        {
                            this.myAct.xSource[index2] = this.myAct.xPolyAct[index2];
                            this.myAct.ySource[index2] = this.myAct.yPolyAct[index2];
                        }
                    }
                    DllClass1.NewPointName(kPnt, this.myAct.nameDop, out this.maxParcel, out this.sTmp);
                    --this.maxParcel;
                    this.myAct.kPolySource = this.kPolySource;
                    this.myAct.LoadKeepSource(2);
                }
                this.kSel = -1;
                this.kRcPnt = 0;
                this.nProcess = 0;
                this.nControl = 0;
                this.kLineCancel = 0;
                this.kLineNew = 0;
                this.kPolyCancel = 0;
                this.groupBox6.Visible = false;
                if (File.Exists(this.myAct.flineFinal))
                    File.Delete(this.myAct.flineFinal);
                this.kLineFinal = 0;
                if (File.Exists(this.myAct.fpolyFinal))
                    File.Delete(this.myAct.fpolyFinal);
                this.kPolyFinal = 0;
                if (File.Exists(this.myAct.fCancLine))
                    File.Delete(this.myAct.fCancLine);
                if (File.Exists(this.myAct.fCancPoly))
                    File.Delete(this.myAct.fCancPoly);
                if (File.Exists(this.myAct.fInscrFin))
                    File.Delete(this.myAct.fInscrFin);
                this.iPolCancDraw = 0;
                this.panel7.Invalidate();
            }
        }

        private void ParcelDelete_Click(object sender, EventArgs e)
        {
            this.nProcess = 410;
            this.nControl = 0;
            this.kSel = -1;
            this.kRcPnt = 0;
            this.iProjDraw = 0;
            this.groupBox6.Visible = false;
            if (this.kPolyAct == 0)
            {
                int num = (int)MessageBox.Show("Данные отсутствуют", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                this.panel7.Invalidate();
        }

        private void AllActionsRemove_Click(object sender, EventArgs e)
        {
            if (this.nAction == 0)
            {
                int num1 = (int)MessageBox.Show("Все изменения удалены", "Действия с участкомs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Вы действительно хотите удалить все изменения ?", "Действия с участком", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                this.myAct.AllActionRemove();
                this.nAction = 0;
                this.myAct.nAction = this.nAction;
                this.myAct.KeepLoadAction(2);
                this.myAct.nAction = this.nAction;
                this.myAct.kPoly = this.kPoly;
                this.myAct.kNode = this.kNode;
                this.myAct.KeepActionZero();
                this.kLineAct = this.myAct.kLineAct;
                this.kPolyAct = this.myAct.kPolyAct;
                this.kIntAct = this.myAct.kIntAct;
                this.kNodeAct = this.myAct.kNodeAct;
                this.kSel = -1;
                this.kRcPnt = 0;
                this.nProcess = 0;
                this.nControl = 0;
                this.kLineCancel = 0;
                this.kLineNew = 0;
                this.kPolyCancel = 0;
                this.groupBox6.Visible = false;
                if (File.Exists(this.myAct.flineFinal))
                    File.Delete(this.myAct.flineFinal);
                this.kLineFinal = 0;
                if (File.Exists(this.myAct.fpolyFinal))
                    File.Delete(this.myAct.fpolyFinal);
                this.kPolyFinal = 0;
                if (File.Exists(this.myAct.flistAction))
                    File.Delete(this.myAct.flistAction);
                if (File.Exists(this.myAct.fCancLine))
                    File.Delete(this.myAct.fCancLine);
                if (File.Exists(this.myAct.fCancPoly))
                    File.Delete(this.myAct.fCancPoly);
                if (File.Exists(this.myAct.fInscrFin))
                    File.Delete(this.myAct.fInscrFin);
                this.iPolCancDraw = 0;
                this.panel1.Text = "Готов ...";
                if (File.Exists(this.myAct.flistAction))
                    File.Delete(this.myAct.flistAction);
                FileStream output = new FileStream(this.myAct.flistAction, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                this.sTmp = "0";
                binaryWriter.Write(this.sTmp);
                binaryWriter.Close();
                output.Close();
                this.myAct.PolygonLoad(ref this.myAct.kPolyInside);
                if (this.myAct.kPoly == 0 && File.Exists(this.myAct.fsourcePoly))
                    File.Delete(this.myAct.fsourcePoly);
                this.kPolySource = this.myAct.kPoly;
                if (this.myAct.kPoly > 0)
                {
                    for (int index1 = 1; index1 <= this.myAct.kPoly; ++index1)
                    {
                        this.myAct.nameSource[index1] = this.myAct.namePoly[index1];
                        this.myAct.xLabSource[index1] = this.myAct.xLab[index1];
                        this.myAct.yLabSource[index1] = this.myAct.yLab[index1];
                        this.myAct.arCalcSource[index1] = this.myAct.areaPol[index1];
                        this.myAct.arLegSource[index1] = this.myAct.areaLeg[index1];
                        this.myAct.k1Source[index1] = this.myAct.kt1[index1];
                        this.myAct.k2Source[index1] = this.myAct.kt2[index1];
                        int num2 = this.myAct.k1Source[index1];
                        int num3 = this.myAct.k2Source[index1];
                        for (int index2 = num2; index2 <= num3; ++index2)
                        {
                            this.myAct.xSource[index2] = this.myAct.xPol[index2];
                            this.myAct.ySource[index2] = this.myAct.yPol[index2];
                        }
                    }
                    this.myAct.kPolySource = this.kPolySource;
                    this.myAct.LoadKeepSource(2);
                    this.maxParcel = 0;
                }
                if (this.kPolySource == 0)
                {
                    this.kPolyAct = 0;
                    this.maxParcel = 0;
                }
                if (this.kPolyAct > 0)
                {
                    int kPnt = -1;
                    for (int index = 1; index <= this.kPolyAct; ++index)
                    {
                        ++kPnt;
                        this.myAct.nameDop[kPnt] = this.myAct.nameAct[index];
                    }
                    DllClass1.NewPointName(kPnt, this.myAct.nameDop, out this.maxParcel, out this.sTmp);
                    --this.maxParcel;
                }
                this.iProjDraw = 1;
                this.panel7.Invalidate();
            }
        }

        private void PointOnOff_Click(object sender, EventArgs e)
        {
            this.kSel = -1;
            this.kRcPnt = 0;
            this.groupBox6.Visible = false;
            this.iPointDraw = this.iPointDraw <= 0 ? 1 : 0;
            this.panel7.Invalidate();
        }

        private void DesignLineOnOff_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.myAct.fpolyProj) && !File.Exists(this.myAct.ftopoProj))
            {
                int num = (int)MessageBox.Show("Линейные топографические знаки не были созданы", "Графическое построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.kSel = -1;
                this.kRcPnt = 0;
            }
            else
            {
                this.kSel = -1;
                this.kRcPnt = 0;
                this.groupBox6.Visible = false;
                this.iProjDraw = this.iProjDraw <= 0 ? 1 : 0;
                this.panel7.Invalidate();
            }
        }

        private void CancelParcelOnOff_Click(object sender, EventArgs e)
        {
            this.myAct.KeepLoadAction(1);
            this.nAction = this.myAct.nAction;
            this.myAct.CancPolyFin(this.nAction);
            this.myAct.CancPolyFinLoad();
            this.kPolyCancel = this.myAct.kPolyCancel;
            this.myAct.CancLineFin(this.nAction);
            this.myAct.CancLineFinLoad();
            this.kLineCancel = this.myAct.kLineCancel;
            if (this.kPolyCancel < 1 && this.kLineCancel < 1)
            {
                int num = (int)MessageBox.Show("Данные отсутствуют", "Кадастр и топография", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.kSel = -1;
                this.kRcPnt = 0;
                this.groupBox6.Visible = false;
                this.iPolCancDraw = this.iPolCancDraw <= 0 ? 1 : 0;
                this.panel7.Invalidate();
            }
        }

        private void NodeList_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.myAct.factLine + "." + string.Format("{0}", (object)this.nAction)))
            {
                int num = (int)MessageBox.Show("LINEAR TOPOLOGY of Actions wasn't created.", "Parcels' Actions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.kSel = -1;
                this.kRcPnt = 0;
                this.nProcess = 0;
                this.panel7.Invalidate();
            }
            else
            {
                this.nProcess = 1002;
                if (File.Exists(this.myAct.fileProcess))
                    File.Delete(this.myAct.fileProcess);
                FileStream output = new FileStream(this.myAct.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(this.nProcess);
                binaryWriter.Close();
                output.Close();
                int num = (int)new NodeList().ShowDialog((IWin32Window)this);
            }
        }

        private void Exit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();
    }

}

