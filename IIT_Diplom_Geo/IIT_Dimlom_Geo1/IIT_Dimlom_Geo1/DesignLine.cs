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
using IIT_Dimlom_Geo1.Properties;
using DiplomGeoDLL;


namespace IIT_Dimlom_Geo1
{
    public partial class DesignLine : Form
    {

        private string sTmp1 = "";
        private string sTmp2 = "";
        private string sForm = "";
        private string pForm = "";
        private int iImageShow;
        private int nFillet;
        private int iWidth;
        private int iHeight;
        private int kPntInput = -1;
        private int kPntPlus = -1;
        private int kPntProj = -1;
        private int kProjInput = -1;
        private int xBegWin;
        private int yBegWin;
        private int xEndWin;
        private int yEndWin;
        private int nControl;
        private int x1Box;
        private int y1Box;
        private int x2Box;
        private int y2Box;
        private int nProcess;
        private int kRcPnt;
        private int ip;
        private int ir;
        private int iLong;
        private int kLineProj;
        private int iRadio;
        private int indLine;
        private int indSide;
        private int kAdd;
        private int kTopoProj;
        private int kPolyProj;
        private int nAction;
        private int kLineTopo;
        private int kLineAct;
        private int kPoly;
        private int kPolyAct;
        private int kIntAct;
        private int kNode;
        private int kNodeAct;
        private int iNodeActDraw = 1;
        private int iPointDraw = 1;
        private int iProjDraw = 1;
        private int iProjTopo;
        private int iLineActDraw = 1;
        private int nVertex = 5000;
        private int hSymbLine = 18;
        private int kPolySymb;
        private int hSymbPoly;
        private int kSymbLine;
        private int kLineInput;
        private double pi = 3.1415926;
        private int kSel = -1;
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
        private double dx;
        private double dy;
        private double ss;
        private double rr;
        private double dField;
        private double dProj;
        private double rRad;
        private double pRad;
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double x3;
        private double y3;
        private double x4;
        private double y4;
        private double xRad;
        private double yRad;
        private double tolerance = 0.003;
        private string[] nameArc = new string[10];
        private double[] xArc = new double[10];
        private double[] yArc = new double[10];
        private double[] zArc = new double[10];
        private double[] xAll = new double[10];
        private double[] yAll = new double[10];
        private int kNodeProj;
        private int kSymbPnt;
        private int iGraphic;
        private int iCond;
        private int iHeightShow;
        private bool isDrag;
        private double xCurMin;
        private double yCurMin;
        private double xCurMax;
        private double yCurMax;
        private int pixWid;
        private int pixHei;


        private MyGeodesy myLin = new MyGeodesy();
        private Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        private Rectangle[] RcPnt = new Rectangle[200];

        public string fCurPnt { get; private set; }
        public string fCurHeig { get; private set; }
        public string fCurLine { get; private set; }

        public DesignLine()
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
            button16.MouseHover += new EventHandler(button16_MouseHover);
            button16.MouseLeave += new EventHandler(button1_MouseLeave);
            button17.MouseHover += new EventHandler(button17_MouseHover);
            button17.MouseLeave += new EventHandler(button1_MouseLeave);
            button18.MouseHover += new EventHandler(button18_MouseHover);
            button18.MouseLeave += new EventHandler(button1_MouseLeave);
            button19.MouseHover += new EventHandler(button19_MouseHover);
            button19.MouseLeave += new EventHandler(button1_MouseLeave);
            button20.MouseHover += new EventHandler(button20_MouseHover);
            button20.MouseLeave += new EventHandler(button1_MouseLeave);
            button21.MouseHover += new EventHandler(button21_MouseHover);
            button21.MouseLeave += new EventHandler(button1_MouseLeave);
            button22.MouseHover += new EventHandler(button22_MouseHover);
            button22.MouseLeave += new EventHandler(button1_MouseLeave);
            button23.MouseHover += new EventHandler(button23_MouseHover);
            button23.MouseLeave += new EventHandler(button1_MouseLeave);
            button24.MouseHover += new EventHandler(button24_MouseHover);
            button24.MouseLeave += new EventHandler(button1_MouseLeave);
            button25.MouseHover += new EventHandler(button25_MouseHover);
            button25.MouseLeave += new EventHandler(button1_MouseLeave);
            button26.MouseHover += new EventHandler(button26_MouseHover);
            button26.MouseLeave += new EventHandler(button1_MouseLeave);
            button27.MouseHover += new EventHandler(button27_MouseHover);
            button27.MouseLeave += new EventHandler(button1_MouseLeave);
            button28.MouseHover += new EventHandler(button28_MouseHover);
            button28.MouseLeave += new EventHandler(button1_MouseLeave);
            button32.MouseHover += new EventHandler(button32_MouseHover);
            button32.MouseLeave += new EventHandler(button1_MouseLeave);
            button33.MouseHover += new EventHandler(button33_MouseHover);
            button33.MouseLeave += new EventHandler(button1_MouseLeave);
            button34.MouseHover += new EventHandler(button34_MouseHover);
            button34.MouseLeave += new EventHandler(button1_MouseLeave);
            DrawPicture(nProcess);
            pictureBox20.Visible = false;
            myLin.FilePath();
            FormLoad();
        }

        private void button1_MouseHover(object sender, EventArgs e) => label2.Text = "Закрыть окно";

        private void button1_MouseLeave(object sender, EventArgs e) => label2.Text = "";

        private void button2_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Зажмите левую кнопкой мыши и переместите мышь. После выбора области отпустите кнопку. Нажмите правую кнопку мыши для исходного положения";

        private void button3_MouseHover(object sender, EventArgs e) 
            => label2.Text = "После нажатия на эту кнопку и отпустив левую кнопку мыши возле выбранной точки. Нажмите правую кнопку для исходного положения";

        private void button4_MouseHover(object sender, EventArgs e) 
            => label2.Text = "После нажатия на эту кнопку и отпустив левую кнопку мыши возле выбранной точки. Нажмите правую кнопку для исходного положения";

        private void button5_MouseHover(object sender, EventArgs e) 
            => label2.Text = "После нажатия на эту кнопку левую кнопкой мыши ведите вдоль экрана. Нажмите правую кнопку для возврата исходное положение";

        private void button6_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Выделите точки с помощью левой кнопки мыши для построения линии. Нажмите правую кнопку после завершения выбора";

        private void button9_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Выделите 2 точки с помощью левой кнопки мыши для подтверждения и введите радиус для построения короткой окружности.";

        private void button10_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Выделите 2 точки с помощью левой кнопки мыши для подтверждения и введите радиус для построения длинной окружности.";

        private void button11_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Выделите 3 точки с помощью левой кнопки мыши для построения окружности (дуги).";

        private void button12_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Выделите 3 точки с помощью левой кнопки мыши для построения круга.";

        private void button13_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Выделите одну точку с помощью левой кнопки мыши как центральную и введите радиус для построения круга.";

        private void button14_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Выделите больше 2х точек с помощью левой кнопки мыши для построения кривой. Нажмите правую кнопку после выбора";

        private void button15_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выбрать линию и установить расстояние между ней и параллелно ей";

        private void button16_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. С помощью левой кнопки мыши выберите линию и затем данную точку";

        private void button17_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите линию ближе к концу, которую необходимо удлинить";

        private void button18_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две окружности, или окружность и дугу, или две дуги";

        private void button19_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две окружности, или окружность и дугу, или две дуги";

        private void button20_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две линии ближе к концам, где будет создаваться тупик";

        private void button21_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две линии для построения прямой короткой дуги.";

        private void button22_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две линии для построения обратной короткой дуги.";

        private void button23_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две линии для построения прямой длинной дуги.";

        private void button24_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две линии для построения обратной длинной дуги.";

        private void button25_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите 2 линии и установите Радиус для построения Прямых окружностей, к которым эти линии касаются";

        private void button26_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите 2 линии и установите Радиус для построения Обратной Дуги, к которой линии касаются";

        private void button27_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите 2 линии и задайте длину биссектрисы для построения дуги, к которой касаются линии";

        private void button28_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Левой кнопкой мыши выберите линию";

        private void button32_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку для обновления линейной топологии путем удаления линии";

        private void button33_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку. Перестроить линейную топологию после удаления линии";

        private void button34_MouseHover(object sender, EventArgs e) 
            => label2.Text = "Нажмите кнопку для построения линейной топологии";

        private void FormLoad()
        {
            xmin = 9999999.9;
            ymin = 9999999.9;
            zmin = 9999999.9;
            xmax = -9999999.9;
            ymax = -9999999.9;
            zmax = -9999999.9;
            DllClass1.SetColour(myLin.brColor, myLin.pnColor);
            DllClass1.PointSymbLoad(myLin.fsymbPnt, out kSymbPnt, myLin.numRec, myLin.numbUser, myLin.heiSymb);
            myLin.kSymbPnt = kSymbPnt;
            DllClass1.LineSymbolLoad(myLin.fsymbLine, out kSymbLine, out hSymbLine, myLin.sSymbLine, myLin.x1Line, myLin.y1Line, myLin.x2Line, myLin.y2Line, myLin.xDescr, myLin.yDescr, myLin.x1Dens, myLin.y1Dens, myLin.x1Sign, myLin.y1Sign, myLin.x2Sign, myLin.y2Sign, myLin.n1Sign, myLin.n2Sign, myLin.iStyle1, myLin.iStyle2, myLin.iWidth1, myLin.iWidth2, myLin.nColLine, myLin.nItem, myLin.itemLoc, myLin.nBaseSymb, myLin.sInscr, myLin.hInscr, myLin.iColInscr, myLin.iDensity);
            myLin.PolySymbolLoad(myLin.fsymbPoly, out kPolySymb, out hSymbPoly);
            myLin.PolygonLoad(ref myLin.kPolyInside);
            kPoly = myLin.kPoly;
            myLin.LineTopoLoad();
            kLineTopo = myLin.kLineTopo;
            myLin.PointLoad();
            //  myLin.PointLoad(fCurPnt, fCurHeig);
            kPntPlus = myLin.kPntPlus;
            kPntInput = myLin.kPntInput;
            xmin = myLin.xmin;
            ymin = myLin.ymin;
            xmax = myLin.xmax;
            ymax = myLin.ymax;
            zmin = myLin.zmin;
            zmax = myLin.zmax;
            if (kPntPlus > 0)
            {
                if (!File.Exists(myLin.fpointInscr))
                {
                    FileStream output = new FileStream(myLin.fpointInscr, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    binaryWriter.Write(kPntPlus);
                    for (int index = 0; index <= kPntPlus; ++index)
                    {
                        myLin.xPntInscr[index] = myLin.xPnt[index];
                        myLin.yPntInscr[index] = myLin.yPnt[index];
                        myLin.iHorVerPnt[index] = 0;
                        binaryWriter.Write(myLin.xPnt[index]);
                        binaryWriter.Write(myLin.yPnt[index]);
                        binaryWriter.Write(myLin.iHorVerPnt[index]);
                    }
                    binaryWriter.Close();
                    output.Close();
                }
                myLin.LoadKeepInscr(1);
            }
            myLin.LineLoad();
            kLineInput = myLin.kLineInput;
            xmin = myLin.xmin;
            ymin = myLin.ymin;
            xmax = myLin.xmax;
            ymax = myLin.ymax;
            myLin.PointProjLoad();
            kPntProj = myLin.kPntProj;
            kProjInput = myLin.kProjInput;
            myLin.LineProjLoad();
            kLineProj = myLin.kLineProj;
            myLin.TopoProjLoad();
            kTopoProj = myLin.kTopoProj;
            myLin.NodeProjLoad();
            kNodeProj = myLin.kNodeProj;
            myLin.PolyProjLoad();
            kPolyProj = myLin.kPolyProj;
            myLin.LoadNode();
            kNode = myLin.kNodeTopo;
            myLin.KeepLoadAction(1);
            nAction = myLin.nAction;
            if (nAction > 0)
            {
                myLin.NodeActLoad(nAction);
                kNodeAct = myLin.kNodeAct;
                myLin.TopoActLoad(nAction);
                kLineAct = myLin.kLineAct;
                myLin.PolyActLoad(nAction);
                kPolyAct = myLin.kPolyAct;
            }
            if (nAction == 0)
                KeepActionZero();
            xminCur = xmin;
            yminCur = ymin;
            xmaxCur = xmax;
            ymaxCur = ymax;
            DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond >= 0)
                return;
            iGraphic = 1;
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
                myLin.kActLine1[index2] = myLin.kl1[index2];
                myLin.kActLine2[index2] = myLin.kl2[index2];
                int num2 = myLin.kl1[index2];
                int num3 = myLin.kl2[index2];
                for (int index3 = num2; index3 <= num3; ++index3)
                {
                    ++index1;
                    myLin.xLineAct[index1] = myLin.zLin[index3];
                    myLin.yLineAct[index1] = myLin.zPik[index3];
                }
            }
            myLin.kLineAct = kLineAct;
            myLin.KeepTopoAct(nAction);
            if (myLin.kPoly == 0)
                return;
            kPoly = myLin.kPoly;
            kPolyAct = kPoly;
            for (int index4 = 1; index4 <= kPolyAct; ++index4)
            {
                myLin.nameAct[index4] = myLin.namePoly[index4];
                myLin.xAct[index4] = myLin.xLab[index4];
                myLin.yAct[index4] = myLin.yLab[index4];
                myLin.aActCalc[index4] = myLin.areaPol[index4];
                myLin.aActLeg[index4] = myLin.areaLeg[index4];
                myLin.kActPoly1[index4] = myLin.kt1[index4];
                myLin.kActPoly2[index4] = myLin.kt2[index4];
                int num4 = myLin.kt1[index4];
                int num5 = myLin.kt2[index4];
                for (int index5 = num4; index5 <= num5; ++index5)
                {
                    myLin.xPolyAct[index5] = myLin.xPol[index5];
                    myLin.yPolyAct[index5] = myLin.yPol[index5];
                }
            }
            kIntAct = 0;
            for (int index6 = 1; index6 <= kPolyAct; ++index6)
            {
                int k = -1;
                int num6 = myLin.kActPoly1[index6];
                int num7 = myLin.kActPoly2[index6];
                for (int index7 = num6; index7 <= num7; ++index7)
                {
                    ++k;
                    myLin.xOut[k] = myLin.xPolyAct[index7];
                    myLin.yOut[k] = myLin.yPolyAct[index7];
                }
                myLin.kPolyActInt[index6] = 0;
                for (int index8 = 1; index8 <= kPolyAct; ++index8)
                {
                    if (index6 != index8 && myLin.aActCalc[index8] < myLin.aActCalc[index6] && DllClass1.in_out(k, ref myLin.xOut, ref myLin.yOut, myLin.xAct[index8], myLin.yAct[index8]) > 0)
                    {
                        myLin.kPolyActInt[index6] = myLin.kPolyActInt[index6] + 1;
                        ++kIntAct;
                        myLin.kIndexAct1[kIntAct] = index6;
                        myLin.kIndexAct2[kIntAct] = index8;
                    }
                }
            }
            myLin.kPolyAct = kPolyAct;
            myLin.kIntAct = kIntAct;
            myLin.KeepPolyAct(nAction);
            kNodeAct = kNode;
            for (int index9 = 1; index9 <= kNodeAct; ++index9)
            {
                myLin.nameNodeAct[index9] = myLin.nameNode[index9];
                myLin.xNodeAct[index9] = myLin.xNode[index9];
                myLin.yNodeAct[index9] = myLin.yNode[index9];
            }
            myLin.kNodeAct = kNodeAct;
            myLin.KeepNodeAct(nAction);
        }

        public void KeepLoadAction(int iParam)
        {
            if (iParam == 1 && File.Exists(myLin.fileAction))
            {
                FileStream input = new FileStream(myLin.fileAction, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    nAction = binaryReader.ReadInt32();
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
            if (iParam != 2)
                return;
            if (File.Exists(myLin.fileAction))
                File.Delete(myLin.fileAction);
            FileStream output = new FileStream(myLin.fileAction, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nAction);
            binaryWriter.Close();
            output.Close();
        }

        private void DrawPntProj(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int xWin = 0;
            int yWin = 0;
            int emSize = 6;
            if (kPntProj < 0)
                return;
            SolidBrush solidBrush = new SolidBrush(Color.Red);
            for (int index = 0; index <= kPntProj; ++index)
            {
                DllClass1.XYtoWIN(myLin.xProj[index], myLin.yProj[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                {
                    graphics.FillRectangle((Brush)solidBrush, xWin - 2, yWin - 2, 4, 4);
                    graphics.DrawString(myLin.nameProj[index], new Font("Bold", (float)emSize), (Brush)solidBrush, (float)(xWin + emSize / 2), (float)(yWin - emSize));
                }
            }
        }

        private void DrawNodeProj(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int xWin = 0;
            int yWin = 0;
            if (kNodeProj < 1)
                return;
            SolidBrush solidBrush = new SolidBrush(Color.Sienna);
            for (int index = 1; index <= kNodeProj; ++index)
            {
                DllClass1.XYtoWIN(myLin.xNodeProj[index], myLin.yNodeProj[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                    graphics.FillRectangle((Brush)solidBrush, xWin - 2, yWin - 2, 4, 4);
            }
        }

        private void DrawSelLine(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int yWin;
            int xWin = yWin = 0;
            if (kSel <= 0)
                return;
            Point[] points = new Point[kSel + 1];
            for (int index = 0; index <= kSel; ++index)
            {
                DllClass1.XYtoWIN(myLin.xWork[index], myLin.yWork[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                {
                    points[index].X = xWin;
                    points[index].Y = yWin;
                }
            }
            graphics.DrawLines(new Pen(Color.DarkCyan, 1f), points);
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
                    graphics.FillRectangle((Brush)solidBrush, xWin - 1, yWin - 1, 2, 2);
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (iGraphic > 0)
                return;
            if (nControl == 10)
                graphics.DrawRectangle(new Pen(Color.Green, 2f), RcDraw);
            if (kPoly == 0 && kLineInput > 0)
            {
                int iPar = 1;
                DllClass1.LineDraw(e, kLineInput, myLin.k1, myLin.k2, myLin.xLin, myLin.yLin, myLin.rRadLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myLin.pnColor, iPar);
            }
            if (kLineAct > 0 && iLineActDraw > 0)
            {
                int iPar = 1;
                DllClass1.LineDraw(e, kLineAct, myLin.kActLine1, myLin.kActLine2, myLin.xLineAct, myLin.yLineAct, myLin.radAct, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myLin.pnColor, iPar);
            }
            if (kPolyAct > 0 && iLineActDraw > 0)
            {
                int iParam = 8;
                DllClass1.LabelDraw(e, kPolyAct, myLin.nameAct, myLin.xAct, myLin.yAct, myLin.iHorVer, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myLin.brColor, iParam);
            }
            if (kNodeAct > 0 && iNodeActDraw > 0)
                DllClass1.DrawNodeAct(e, kNodeAct, myLin.nameNodeAct, myLin.xNodeAct, myLin.yNodeAct, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            if (kPntPlus > 0 && iPointDraw > 0)
                DllClass1.PointsDraw(e, myLin.fsymbPnt, iHeightShow, kPntPlus, myLin.namePnt, myLin.xPnt, myLin.yPnt, myLin.zPnt, myLin.xPntInscr, myLin.yPntInscr, myLin.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myLin.nCode1, myLin.nCode2, kSymbPnt, myLin.numRec, myLin.numbUser, myLin.ixSqu, myLin.iySqu, myLin.nColor, myLin.brColor, myLin.pnColor);
            if (kPntPlus > 0 && iPointDraw == 0)
                DrawPoint(e, kPntPlus, myLin.xPnt, myLin.yPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            if (kPntProj > -1 && iProjDraw > 0)
                DrawPntProj(e);
            if (kLineProj > 0 && iProjDraw > 0)
            {
                int iPar = 2;
                DllClass1.LineDraw(e, kLineProj, myLin.kPr1, myLin.kPr2, myLin.xLinProj, myLin.yLinProj, myLin.RadProj, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myLin.pnColor, iPar);
            }
            if (kTopoProj > 0 && iProjTopo > 0)
            {
                int iPar = 4;
                DllClass1.LineDraw(e, kTopoProj, myLin.kPrt1, myLin.kPrt2, myLin.xLinTopo, myLin.yLinTopo, myLin.RadTopo, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myLin.pnColor, iPar);
                DrawNodeProj(e);
            }
            if (nProcess != 510)
            {
                if (kRcPnt > 0)
                {
                    for (int index = 1; index <= kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), RcPnt[index]);
                }
                DllClass1.DrawSelLine(e, kSel, ref myLin.xWork, ref myLin.yWork, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                DrawPicture(nProcess);
            }
            if (nProcess == 510)
            {
                if (kRcPnt > 0)
                {
                    for (int index = 1; index <= kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), RcPnt[index]);
                }
                DrawSelLine(e);
                if (iImageShow > 0)
                    DrawPicture(nProcess);
            }
            Cursor.Current = Cursors.Default;
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
                if (e.Button == MouseButtons.Left)
                {
                    isDrag = true;
                    startPoint = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                }
            }
            if (nControl == 20)
            {
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
                if (nProcess == 0)
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
                    panel7.Invalidate();
                }
                if (nProcess > 0)
                {
                    if (kSel > -1)
                    {
                        double tText = 0.0;
                        if (textBox4.Text != "")
                        {
                            DllClass1.CheckText(textBox4.Text, out tText, out iCond);
                            if (iCond < 0)
                            {
                                int num = (int)MessageBox.Show("Проверьте данные", "Аэротриангуляция", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        if (tText <= 0.0)
                            textBox4.Text = "0";
                    }
                    if (nProcess == 570 && kSel > 1)
                    {
                        int kSel = this.kSel;
                        for (int index = 0; index <= kSel; ++index)
                        {
                            myLin.namePik[index] = myLin.nameWork[index];
                            myLin.xPik[index] = myLin.xWork[index];
                            myLin.yPik[index] = myLin.yWork[index];
                            myLin.zDop[index] = myLin.zWork[index];
                        }
                        int k = 0;
                        DllClass1.Line_Spl(kSel, ref myLin.xPik, ref myLin.yPik, out k, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop, nVertex);
                        if (k < 1)
                            return;
                        kSel = k;
                        for (int index = 0; index <= kSel; ++index)
                        {
                            myLin.nameWork[index] = "rad";
                            myLin.zWork[index] = 0.0;
                        }
                        for (int index1 = 0; index1 <= kSel; ++index1)
                        {
                            rr = 9999999.9;
                            ip = -1;
                            for (int index2 = 0; index2 <= kSel; ++index2)
                            {
                                dx = myLin.xWork[index1] - myLin.xPik[index2];
                                dy = myLin.yWork[index1] - myLin.yPik[index2];
                                ss = Math.Sqrt(dx * dx + dy * dy);
                                if (ss < rr)
                                {
                                    ip = index2;
                                    rr = ss;
                                }
                            }
                            myLin.nameWork[index1] = myLin.namePik[ip];
                            myLin.zWork[index1] = myLin.zDop[ip];
                        }
                        textBox4.Text = "1";
                        panel7.Invalidate();
                    }
                }
            }
            if (e.Button != MouseButtons.Left)
                return;
            if (nProcess == 510 || nProcess == 520 || nProcess == 530 || nProcess == 540 || nProcess == 550 || nProcess == 560 || nProcess == 570)
            {
                DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                dField = 9999999.9;
                ip = -1;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - xCur;
                    dy = myLin.yPnt[index] - yCur;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dField)
                    {
                        ip = index;
                        dField = ss;
                    }
                }
                dProj = 9999999.9;
                ir = -1;
                if (kPntProj > -1)
                {
                    for (int index = 0; index <= kPntProj; ++index)
                    {
                        dx = myLin.xProj[index] - xCur;
                        dy = myLin.yProj[index] - yCur;
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < dProj)
                        {
                            ir = index;
                            dProj = ss;
                        }
                    }
                }
                if (dProj > dField && ip > -1)
                {
                    ++kSel;
                    myLin.nameWork[kSel] = myLin.namePnt[ip];
                    myLin.xWork[kSel] = myLin.xPnt[ip];
                    myLin.yWork[kSel] = myLin.yPnt[ip];
                    myLin.zWork[kSel] = myLin.zPnt[ip];
                    listBox1.Items.Add((object)myLin.namePnt[ip]);
                }
                if (dProj < dField && ir > -1)
                {
                    ++kSel;
                    myLin.nameWork[kSel] = myLin.nameProj[ir];
                    myLin.xWork[kSel] = myLin.xProj[ir];
                    myLin.yWork[kSel] = myLin.yProj[ir];
                    myLin.zWork[kSel] = myLin.zProj[ir];
                    listBox1.Items.Add((object)myLin.nameProj[ir]);
                }
                ++kRcPnt;
                RcPnt[kRcPnt].X = e.X;
                RcPnt[kRcPnt].Y = e.Y;
            }
            if ((nProcess == 520 || nProcess == 530) && kSel == 1)
            {
                dx = myLin.xWork[1] - myLin.xWork[0];
                dy = myLin.yWork[1] - myLin.yWork[0];
                ss = Math.Sqrt(dx * dx + dy * dy);
                sTmp1 = string.Format("{0:F1}", (object)ss);
                DllClass1.FormCreate(0, out iRadio, out rRad, out pRad, out sForm, out pForm, sTmp1, sTmp2);
                rr = 2.0 * rRad - ss;
                if (rr < 0.1)
                {
                    int num = (int)MessageBox.Show("Увеличить радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    listBox1.Items.Clear();
                    return;
                }
                textBox4.Text = sForm;
                sTmp1 = myLin.nameWork[0];
                x1 = myLin.xWork[0];
                y1 = myLin.yWork[0];
                dx = myLin.zWork[0];
                sTmp2 = myLin.nameWork[1];
                x2 = myLin.xWork[1];
                y2 = myLin.yWork[1];
                dy = myLin.zWork[1];
                iLong = 0;
                if (nProcess == 530)
                    iLong = 1;
                DllClass1.Arc_2Pnt(x1, y1, x2, y2, rRad, ref xRad, ref yRad, out kSel, ref myLin.xWork, ref myLin.yWork, ref iLong, ref myLin.xDop, ref myLin.yDop);
                if (kSel < 2)
                    return;
                for (int index = 1; index < kSel; ++index)
                {
                    myLin.nameWork[index] = "rad";
                    myLin.zWork[index] = 0.0;
                }
                myLin.nameWork[0] = sTmp1;
                myLin.zWork[0] = dx;
                myLin.nameWork[kSel] = sTmp2;
                myLin.zWork[kSel] = dy;
                panel7.Invalidate();
            }
            if ((nProcess == 540 || nProcess == 550) && kSel == 2)
            {
                nameArc[0] = myLin.nameWork[0];
                xArc[0] = myLin.xWork[0];
                yArc[0] = myLin.yWork[0];
                zArc[0] = myLin.zWork[0];
                nameArc[1] = myLin.nameWork[1];
                xArc[1] = myLin.xWork[1];
                yArc[1] = myLin.yWork[1];
                zArc[1] = myLin.zWork[1];
                nameArc[2] = myLin.nameWork[2];
                xArc[2] = myLin.xWork[2];
                yArc[2] = myLin.yWork[2];
                zArc[2] = myLin.zWork[2];
                if (nProcess == 540)
                {
                    iLong = 0;
                    DllClass1.Arc_3Pnt(xArc, yArc, out rRad, out xRad, out yRad, out kSel, ref myLin.xWork, ref myLin.yWork, ref iLong);
                    if (kSel < 2)
                        return;
                }
                if (nProcess == 550)
                {
                    DllClass1.Circle_3Pnt(xArc, yArc, out rRad, out xRad, out yRad, out kSel, ref myLin.xWork, ref myLin.yWork);
                    if (kSel < 2)
                        return;
                }
                rr = 9999999.9;
                ip = -1;
                for (int index = 1; index < kSel; ++index)
                {
                    myLin.nameWork[index] = "rad";
                    myLin.zWork[index] = 0.0;
                    dx = myLin.xWork[index] - xArc[1];
                    dy = myLin.yWork[index] - yArc[1];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        ip = index;
                        rr = ss;
                    }
                }
                myLin.nameWork[0] = nameArc[0];
                myLin.zWork[0] = zArc[0];
                myLin.nameWork[ip] = nameArc[1];
                myLin.zWork[ip] = zArc[1];
                myLin.nameWork[kSel] = nameArc[2];
                myLin.zWork[kSel] = zArc[2];
                sTmp1 = string.Format("{0:F3}", (object)rRad);
                textBox4.Text = sTmp1;
                panel7.Invalidate();
            }
            if (nProcess == 560 && kSel == 0)
            {
                nameArc[0] = myLin.nameWork[0];
                xArc[0] = myLin.xWork[0];
                yArc[0] = myLin.yWork[0];
                zArc[0] = myLin.zWork[0];
                sTmp1 = "";
                sTmp2 = "";
                DllClass1.FormCreate(1, out iRadio, out rRad, out pRad, out sForm, out pForm, sTmp1, sTmp2);
                if (rRad <= 0.0)
                {
                    int num = (int)MessageBox.Show("Увеличить радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    listBox1.Items.Clear();
                    nProcess = 0;
                    return;
                }
                xRad = xArc[0];
                yRad = yArc[0];
                DllClass1.Circle_Rad(rRad, xArc[0], yArc[0], out kSel, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop);
                if (kSel < 2)
                    return;
                for (int index = 0; index <= kSel; ++index)
                {
                    myLin.nameWork[index] = "rad";
                    myLin.zWork[index] = 0.0;
                }
                textBox4.Text = sForm;
                panel7.Invalidate();
            }
            if (nProcess == 580)
            {
                DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                kSel = 0;
                xArc[0] = xCur;
                yArc[0] = yCur;
                ++kRcPnt;
                RcPnt[kRcPnt].X = e.X;
                RcPnt[kRcPnt].Y = e.Y;
                textBox4.Text = "0";
            }
            if (nProcess == 590 || nProcess == 620 || nProcess == 630 || nProcess == 640 || nProcess == 54 || nProcess == 55 || nProcess == 56 || nProcess == 57 || nProcess == 58 || nProcess == 59 || nProcess == 62)
            {
                ++kSel;
                if (kSel == 0)
                {
                    DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                    xArc[0] = xCur;
                    yArc[0] = yCur;
                }
                if (kSel == 1)
                {
                    DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                    xArc[1] = xCur;
                    yArc[1] = yCur;
                }
                ++kRcPnt;
                RcPnt[kRcPnt].X = e.X;
                RcPnt[kRcPnt].Y = e.Y;
                textBox4.Text = "0";
            }
            if (nProcess == 600 || nProcess == 610)
            {
                DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                kSel = 0;
                xArc[0] = xCur;
                yArc[0] = yCur;
                ++kRcPnt;
                RcPnt[kRcPnt].X = e.X;
                RcPnt[kRcPnt].Y = e.Y;
                textBox4.Text = "0";
                if (nProcess == 600)
                    textBox4.ReadOnly = true;
            }
            if (nProcess == 130)
            {
                DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                kSel = 0;
                xArc[0] = xCur;
                yArc[0] = yCur;
                ++kRcPnt;
                RcPnt[kRcPnt].X = e.X;
                RcPnt[kRcPnt].Y = e.Y;
            }
            if (kSel <= 0 || nProcess != 510)
                return;
            panel7.Invalidate();
        }

        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
            double xh = 0.0;
            double yh = 0.0;
            double xk = 0.0;
            double yk = 0.0;
            double xx = 0.0;
            double yy = 0.0;
            if (nControl == 10)
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
            }
            if (nControl == 40)
            {
                xminCur = xaCur;
                yminCur = yaCur;
                xmaxCur = xbCur;
                ymaxCur = ybCur;
            }
            if (nProcess == 130)
            {
                RcPnt[kRcPnt].Width = 4;
                RcPnt[kRcPnt].Height = 4;
                panel7.Invalidate(RcPnt[kRcPnt]);
            }
            if (nProcess == 570 || nProcess == 580 || nProcess == 590 || nProcess == 600 || nProcess == 610 || nProcess == 620 || nProcess == 630 || nProcess == 640 || nProcess == 54 || nProcess == 55 || nProcess == 56 || nProcess == 57 || nProcess == 58 || nProcess == 59 || nProcess == 62 || nProcess == 510)
            {
                RcPnt[kRcPnt].Width = 4;
                RcPnt[kRcPnt].Height = 4;
                panel7.Invalidate(RcPnt[kRcPnt]);
            }
            if (nProcess == 580 && kSel == 0)
            {
                double az = 0.0;
                int kp = 0;
                int index1 = 0;
                double num1;
                double yrd = num1 = 0.0;
                double xrd = num1;
                double rd = num1;
                DllClass1.FindLine(xArc[0], yArc[0], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.RadProj, ref myLin.xRadProj, ref myLin.yRadProj, ref myLin.xLinProj, ref myLin.yLinProj, out rd, out xrd, out yrd, out kp, ref myLin.xPik, ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                for (int index2 = 0; index2 <= kp; ++index2)
                {
                    dField = 9999999.9;
                    ip = -1;
                    for (int index3 = 0; index3 <= kPntPlus; ++index3)
                    {
                        dx = myLin.xPnt[index3] - myLin.xPik[index2];
                        dy = myLin.yPnt[index3] - myLin.yPik[index2];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss <= 0.1 && ss < dField)
                        {
                            dField = ss;
                            ip = index3;
                        }
                    }
                    dProj = 9999999.9;
                    ir = -1;
                    if (kPntProj > -1)
                    {
                        for (int index4 = 0; index4 <= kPntProj; ++index4)
                        {
                            dx = myLin.xProj[index4] - myLin.xPik[index2];
                            dy = myLin.yProj[index4] - myLin.yPik[index2];
                            ss = Math.Sqrt(dx * dx + dy * dy);
                            if (ss <= 0.1 && ss < dProj)
                            {
                                dProj = ss;
                                ir = index4;
                            }
                        }
                    }
                    if (dProj > dField && ip > -1)
                    {
                        ++index1;
                        myLin.nameDop[index1] = myLin.namePnt[ip];
                        myLin.xDop[index1] = myLin.xPnt[ip];
                        myLin.yDop[index1] = myLin.yPnt[ip];
                        myLin.zDop[index1] = myLin.zPnt[ip];
                    }
                    if (dProj < dField && ir > -1)
                    {
                        ++index1;
                        myLin.nameDop[index1] = myLin.nameProj[ir];
                        myLin.xDop[index1] = myLin.xProj[ir];
                        myLin.yDop[index1] = myLin.yProj[ir];
                        myLin.zDop[index1] = myLin.zProj[ir];
                    }
                }
                sTmp1 = "";
                sTmp2 = "";
                DllClass1.FormCreate(2, out iRadio, out this.rRad, out pRad, out sForm, out pForm, sTmp1, sTmp2);
                double rRad = this.rRad;
                if (rRad <= 0.0)
                {
                    int num2 = (int)MessageBox.Show("Увеличить расстояние", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    kAdd = 0;
                    listBox1.Items.Clear();
                    nProcess = 0;
                    return;
                }
                if (kp == 1)
                    rd = 0.0;
                if (rd <= 1.0)
                {
                    rRad = 0.0;
                    xRad = 0.0;
                    yRad = 0.0;
                    if (iRadio == 1)
                    {
                        double num3 = az + 0.5 * pi;
                        if (num3 >= 2.0 * pi)
                            num3 -= 2.0 * pi;
                        xh = xArc[0] + rRad * Math.Cos(num3);
                        yh = yArc[0] + Math.Sin(num3);
                    }
                    if (iRadio == 2)
                    {
                        double num4 = az - 0.5 * pi;
                        if (num4 < 0.0)
                            num4 += 2.0 * pi;
                        xh = xArc[0] + rRad * Math.Cos(num4);
                        yh = yArc[0] + rRad * Math.Sin(num4);
                    }
                    DllClass1.ParallelLine(xh, yh, rRad, kp, ref myLin.xPik, ref myLin.yPik, out kSel, ref myLin.xWork, ref myLin.yWork);
                    if (kSel < 1)
                        return;
                    for (int index5 = 0; index5 <= kSel; ++index5)
                    {
                        myLin.nameWork[index5] = "lin";
                        myLin.zWork[index5] = 0.0;
                    }
                    int nName1 = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName1, out sTmp1);
                    if (nName1 < 0)
                        return;
                    int nName2 = 0;
                    if (kPntProj > -1)
                    {
                        DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName2, out sTmp2);
                        if (nName2 < 0)
                            return;
                        if (nName2 > nName1)
                        {
                            nName1 = nName2;
                            sTmp1 = sTmp2;
                        }
                    }
                    --nName1;
                    for (int index6 = 1; index6 <= index1; ++index6)
                    {
                        rr = 9999999.9;
                        ip = -1;
                        for (int index7 = 0; index7 <= kSel; ++index7)
                        {
                            dx = myLin.xDop[index6] - myLin.xWork[index7];
                            dy = myLin.yDop[index6] - myLin.yWork[index7];
                            ss = Math.Sqrt(dx * dx + dy * dy);
                            if (ss < rr)
                            {
                                rr = ss;
                                ip = index7;
                            }
                        }
                        ++nName1;
                        sTmp1 = string.Format("{0}", (object)nName1);
                        myLin.nameWork[ip] = sTmp1;
                        ++kAdd;
                        myLin.nameAdd[kAdd] = sTmp1;
                        myLin.xAdd[kAdd] = myLin.xWork[ip];
                        myLin.yAdd[kAdd] = myLin.yWork[ip];
                        myLin.zAdd[kAdd] = 0.0;
                        ++kPntProj;
                        myLin.nameProj[kPntProj] = sTmp1;
                        myLin.xProj[kPntProj] = myLin.xWork[ip];
                        myLin.yProj[kPntProj] = myLin.yWork[ip];
                        myLin.zProj[kPntProj] = 0.0;
                    }
                    rRad = rd;
                }
                if (rd > 1.0)
                {
                    if (iRadio == 1)
                        rd += rRad;
                    if (iRadio == 2)
                        rd -= rRad;
                    DllClass1.ParallelArcCircle(kp, ref myLin.xPik, ref myLin.yPik, ref rd, ref xrd, ref yrd, out kSel, ref myLin.xWork, ref myLin.yWork, out rRad, out xRad, out yRad, ref myLin.xDop, ref myLin.yDop);
                    if (kSel < 2)
                        return;
                    for (int index8 = 0; index8 <= kSel; ++index8)
                    {
                        myLin.nameWork[index8] = "rad";
                        myLin.zWork[index8] = 0.0;
                    }
                    int nName3 = 0;
                    int nName4 = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName3, out sTmp1);
                    if (nName3 < 0)
                        return;
                    if (kPntProj > -1)
                    {
                        DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName4, out sTmp2);
                        if (nName4 < 0)
                            return;
                        if (nName4 > nName3)
                            sTmp1 = sTmp2;
                    }
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[0];
                    myLin.yAdd[kAdd] = myLin.yWork[0];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntProj;
                    myLin.nameProj[kPntProj] = sTmp1;
                    myLin.xProj[kPntProj] = myLin.xWork[0];
                    myLin.yProj[kPntProj] = myLin.yWork[0];
                    myLin.zProj[kPntProj] = 0.0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName3, out sTmp1);
                    if (nName3 < 0)
                        return;
                    if (kPntProj > -1)
                    {
                        DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName4, out sTmp2);
                        if (nName4 < 0)
                            return;
                        if (nName4 > nName3)
                            sTmp1 = sTmp2;
                    }
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[kSel];
                    myLin.yAdd[kAdd] = myLin.yWork[kSel];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntProj;
                    myLin.nameProj[kPntProj] = sTmp1;
                    myLin.xProj[kPntProj] = myLin.xWork[kSel];
                    myLin.yProj[kPntProj] = myLin.yWork[kSel];
                    myLin.zProj[kPntProj] = 0.0;
                }
                textBox4.Text = "0";
                if (rRad > 0.0)
                {
                    sTmp1 = string.Format("{0:F3}", (object)rRad);
                    textBox4.Text = sTmp1;
                }
                panel7.Invalidate();
            }
            if (nProcess == 590 && kSel == 1)
            {
                double az = 0.0;
                int kp = 0;
                double num;
                double yrd = num = 0.0;
                double xrd = num;
                double rd = num;
                DllClass1.FindLine(xArc[0], yArc[0], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.RadProj,
                    ref myLin.xRadProj, ref myLin.yRadProj, ref myLin.xLinProj, ref myLin.yLinProj, out rd, out xrd,
                    out yrd, out kp, ref myLin.xPik, ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                dField = 9999999.9;
                ip = -1;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - xArc[1];
                    dy = myLin.yPnt[index] - yArc[1];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dField)
                    {
                        dField = ss;
                        ip = index;
                    }
                }
                dProj = 9999999.9;
                ir = -1;
                for (int index = 0; index <= kPntProj; ++index)
                {
                    dx = myLin.xProj[index] - xArc[1];
                    dy = myLin.yProj[index] - yArc[1];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dProj)
                    {
                        dProj = ss;
                        ir = index;
                    }
                }
                if (dProj > dField)
                {
                    xx = myLin.xPnt[ip];
                    yy = myLin.yPnt[ip];
                }
                if (dProj < dField)
                {
                    xx = myLin.xProj[ir];
                    yy = myLin.yProj[ir];
                }
                DllClass1.PerpToLine(xx, yy, kp, ref myLin.xPik, ref myLin.yPik, out xCur, out yCur, out az, out indSide);
                if (indSide == 0)
                    return;
                if (dProj > dField)
                {
                    kSel = 1;
                    myLin.nameWork[0] = myLin.namePnt[ip];
                    myLin.xWork[0] = myLin.xPnt[ip];
                    myLin.yWork[0] = myLin.yPnt[ip];
                    myLin.zWork[0] = myLin.zPnt[ip];
                }
                if (dProj < dField)
                {
                    kSel = 1;
                    myLin.nameWork[0] = myLin.nameProj[ir];
                    myLin.xWork[0] = myLin.xProj[ir];
                    myLin.yWork[0] = myLin.yProj[ir];
                    myLin.zWork[0] = myLin.zProj[ir];
                }
                dField = 9999999.9;
                ip = -1;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - xCur;
                    dy = myLin.yPnt[index] - yCur;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dField)
                    {
                        dField = ss;
                        ip = index;
                    }
                }
                dProj = 9999999.9;
                ir = -1;
                for (int index = 0; index <= kPntProj; ++index)
                {
                    dx = myLin.xProj[index] - xCur;
                    dy = myLin.yProj[index] - yCur;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dProj)
                    {
                        dProj = ss;
                        ir = index;
                    }
                }
                if (dProj > dField && dField < 0.005)
                {
                    myLin.nameWork[1] = myLin.namePnt[ip];
                    myLin.xWork[1] = myLin.xPnt[ip];
                    myLin.yWork[1] = myLin.yPnt[ip];
                    myLin.zWork[1] = myLin.zPnt[ip];
                }
                if (dProj < dField && dProj < 0.005)
                {
                    myLin.nameWork[1] = myLin.nameProj[ir];
                    myLin.xWork[1] = myLin.xProj[ir];
                    myLin.yWork[1] = myLin.yProj[ir];
                    myLin.zWork[1] = myLin.zProj[ir];
                }
                if (dField > 0.005 && dProj > 0.005)
                {
                    int nName5 = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName5, out sTmp1);
                    if (nName5 < 0)
                        return;
                    int nName6 = 0;
                    if (kPntProj > -1)
                    {
                        DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName6, out sTmp2);
                        if (nName6 < 0)
                            return;
                        if (nName6 > nName5)
                            sTmp1 = sTmp2;
                    }
                    myLin.nameWork[1] = sTmp1;
                    myLin.xWork[1] = xCur;
                    myLin.yWork[1] = yCur;
                    myLin.zWork[1] = 0.0;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = xCur;
                    myLin.yAdd[kAdd] = yCur;
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntProj;
                    myLin.nameProj[kPntProj] = sTmp1;
                    myLin.xProj[kPntProj] = xCur;
                    myLin.yProj[kPntProj] = yCur;
                    myLin.zProj[kPntProj] = 0.0;
                }
                textBox4.Text = "0";
                panel7.Invalidate();
            }
            if (nProcess == 130 && kSel == 0)
            {
                double az = 0.0;
                double num5;
                double yrd = num5 = 0.0;
                double xrd = num5;
                double rd = num5;
                DllClass1.FindLine(xArc[0], yArc[0], kTopoProj, ref myLin.kPrt1, ref myLin.kPrt2, ref myLin.RadTopo, ref myLin.xOut, ref myLin.yOut, ref myLin.xLinTopo, ref myLin.yLinTopo, out rd, out xrd, out yrd, out kSel, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kSel < 1)
                    return;
                panel7.Invalidate();
                if (MessageBox.Show("Вы действительно хотите удалить эту строку ?", "Построение линий", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    kSel = -1;
                    kAdd = 0;
                    kRcPnt = 0;
                    nProcess = 0;
                    panel7.Invalidate();
                    return;
                }
                int kNew = 0;
                DllClass1.LineTopoDel(indLine, kTopoProj, ref myLin.RadTopo, ref myLin.kPrt1, ref myLin.kPrt2, ref myLin.xLinTopo, ref myLin.yLinTopo, out kNew, ref myLin.rWork, ref myLin.nWork1, ref myLin.nWork2, ref myLin.xAdd, ref myLin.yAdd, ref myLin.nWork);
                if (kNew < 1)
                    return;
                kTopoProj = kNew;
                for (int index9 = 1; index9 <= kTopoProj; ++index9)
                {
                    myLin.RadTopo[index9] = myLin.rWork[index9];
                    myLin.kPrt1[index9] = myLin.nWork1[index9];
                    myLin.kPrt2[index9] = myLin.nWork2[index9];
                    int num6 = myLin.kPrt1[index9];
                    int num7 = myLin.kPrt2[index9];
                    for (int index10 = num6; index10 <= num7; ++index10)
                    {
                        myLin.xLinTopo[index10] = myLin.xAdd[index10];
                        myLin.yLinTopo[index10] = myLin.yAdd[index10];
                    }
                }
                myLin.kTopoProj = kTopoProj;
                myLin.KeepTopoProj();
                if (File.Exists(myLin.fpolyProj))
                {
                    File.Delete(myLin.fpolyProj);
                    kPolyProj = 0;
                }
                iProjTopo = 1;
                kSel = -1;
                kRcPnt = 0;
                panel7.Invalidate();
            }
            if (nProcess == 600 && kSel == 0)
            {
                double az = 0.0;
                double num8;
                double yrd = num8 = 0.0;
                double xrd = num8;
                double rd = num8;
                DllClass1.FindLine(xArc[0], yArc[0], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.RadProj, ref myLin.xRadProj, ref myLin.yRadProj, ref myLin.xLinProj, ref myLin.yLinProj, out rd, out xrd, out yrd, out kSel, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kSel < 1)
                    return;
                panel7.Invalidate();
                if (nProcess == 600 && MessageBox.Show("Вы действительно хотите удалить эту строку ?", "Построение линий", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    kSel = -1;
                    kAdd = 0;
                    kRcPnt = 0;
                    nProcess = 0;
                    panel7.Invalidate();
                    return;
                }
                if (kLineProj == 1)
                {
                    if (File.Exists(myLin.flineProj))
                        File.Delete(myLin.flineProj);
                    kSel = -1;
                    kAdd = 0;
                    kRcPnt = 0;
                    kLineProj = 0;
                    panel7.Invalidate();
                    return;
                }
                if (kPntPlus > kPntInput)
                {
                    int index11 = 0;
                    for (int index12 = 0; index12 <= kSel; ++index12)
                    {
                        rr = 9999999.9;
                        ip = -1;
                        for (int index13 = kPntInput + 1; index13 <= kPntPlus; ++index13)
                        {
                            dx = myLin.xPnt[index13] - myLin.xWork[index12];
                            dy = myLin.yPnt[index13] - myLin.yWork[index12];
                            ss = Math.Sqrt(dx * dx + dy * dy);
                            if (ss <= 0.1 && ss < rr)
                            {
                                rr = ss;
                                ip = index13;
                            }
                        }
                        if (ip >= 0)
                        {
                            ++index11;
                            myLin.nameDop[index11] = myLin.namePnt[ip];
                        }
                    }
                    if (index11 > 0)
                    {
                        for (int index14 = 1; index14 <= index11; ++index14)
                        {
                            int num9 = -1;
                            for (int index15 = 0; index15 <= kPntPlus; ++index15)
                            {
                                if (myLin.nameDop[index14] == myLin.namePnt[index15])
                                {
                                    num9 = index15;
                                    break;
                                }
                            }
                            if (num9 >= 0)
                            {
                                ip = -1;
                                for (int index16 = 0; index16 <= kPntPlus; ++index16)
                                {
                                    if (index16 != num9)
                                    {
                                        ++ip;
                                        myLin.namePnt[ip] = myLin.namePnt[index16];
                                        myLin.xPnt[ip] = myLin.xPnt[index16];
                                        myLin.yPnt[ip] = myLin.yPnt[index16];
                                        myLin.zPnt[ip] = myLin.zPnt[index16];
                                        myLin.nCode1[ip] = myLin.nCode1[index16];
                                        myLin.nCode2[ip] = myLin.nCode2[index16];
                                    }
                                }
                                kPntPlus = ip;
                                myLin.kPntPlus = kPntPlus;
                                myLin.kPntInput = kPntInput;
                                myLin.KeepPoint();
                            }
                        }
                    }
                }
                int kLin = 0;
                DllClass1.LineDelete(indLine, ref kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.kPr, ref myLin.iProj1, 
                    ref myLin.iLongProj, ref myLin.sWidProj, ref myLin.RadProj, ref myLin.xRadProj, ref myLin.yRadProj, 
                    ref myLin.xLinProj, ref myLin.yLinProj, ref myLin.zLinProj, out kLin, ref myLin.xPik, ref myLin.yPik, ref myLin.zDop);
                myLin.kLineProj = kLineProj;
                myLin.KeepProjLine();
                if (File.Exists(myLin.fnodeProj))
                {
                    File.Delete(myLin.fnodeProj);
                    kNodeProj = 0;
                }
                if (File.Exists(myLin.ftopoProj))
                {
                    File.Delete(myLin.ftopoProj);
                    kTopoProj = 0;
                }
                if (File.Exists(myLin.fpolyProj))
                {
                    File.Delete(myLin.fpolyProj);
                    kPolyProj = 0;
                }
                myLin.AllActionRemove();
                nAction = 0;
                myLin.nAction = nAction;
                myLin.KeepLoadAction(2);
                if (File.Exists(myLin.flineFinal))
                    File.Delete(myLin.flineFinal);
                if (File.Exists(myLin.fpolyFinal))
                    File.Delete(myLin.fpolyFinal);
                if (File.Exists(myLin.fileItems))
                    File.Delete(myLin.fileItems);
                if (File.Exists(myLin.flistAction))
                    File.Delete(myLin.flistAction);
                FileStream output = new FileStream(myLin.flistAction, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                string str = "0";
                binaryWriter.Write(str);
                binaryWriter.Close();
                output.Close();
                kSel = -1;
                kAdd = 0;
                kRcPnt = 0;
                panel7.Invalidate();
            }
            if (nProcess == 610 && kSel == 0)
            {
                double num10;
                double yrd = num10 = 0.0;
                double xrd = num10;
                double rd = num10;
                DllClass1.LengthenLine(xArc[0], yArc[0], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.RadProj, ref myLin.xRadProj, ref myLin.yRadProj, ref myLin.xLinProj, ref myLin.yLinProj, out rd, out xrd, out yrd, out kSel, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur);
                if (kSel < 1)
                {
                    int num11 = (int)MessageBox.Show("Повторить процесс", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    kAdd = 0;
                    kRcPnt = 0;
                    nProcess = 0;
                    listBox1.Items.Clear();
                    panel7.Invalidate();
                    return;
                }
                rr = 9999999.9;
                int index17 = -1;
                for (int index18 = 0; index18 <= kSel; ++index18)
                {
                    dx = myLin.xWork[index18] - xCur;
                    dy = myLin.yWork[index18] - yCur;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        index17 = index18;
                    }
                }
                dField = 9999999.9;
                ip = -1;
                for (int index19 = 0; index19 <= kPntPlus; ++index19)
                {
                    dx = myLin.xPnt[index19] - xCur;
                    dy = myLin.yPnt[index19] - yCur;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dField)
                    {
                        dField = ss;
                        ip = index19;
                    }
                }
                dProj = 9999999.9;
                ir = -1;
                for (int index20 = 0; index20 <= kPntProj; ++index20)
                {
                    dx = myLin.xProj[index20] - xCur;
                    dy = myLin.yProj[index20] - yCur;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dProj)
                    {
                        dProj = ss;
                        ir = index20;
                    }
                }
                if (dProj > dField && dField < 0.005)
                {
                    myLin.nameWork[index17] = myLin.namePnt[ip];
                    myLin.xWork[index17] = myLin.xPnt[ip];
                    myLin.yWork[index17] = myLin.yPnt[ip];
                    myLin.zWork[index17] = myLin.zPnt[ip];
                }
                if (dProj < dField && dProj < 0.005)
                {
                    myLin.nameWork[index17] = myLin.nameProj[ir];
                    myLin.xWork[index17] = myLin.xProj[ir];
                    myLin.yWork[index17] = myLin.yProj[ir];
                    myLin.zWork[index17] = myLin.zProj[ir];
                }
                if (dProj > 0.005 && dField > 0.005)
                {
                    int nName7 = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName7, out sTmp1);
                    if (nName7 < 0)
                        return;
                    int nName8 = 0;
                    if (kPntProj > -1)
                    {
                        DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName8, out sTmp2);
                        if (nName8 < 0)
                            return;
                        if (nName8 > nName7)
                            sTmp1 = sTmp2;
                    }
                    myLin.nameWork[index17] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[index17];
                    myLin.yAdd[kAdd] = myLin.yWork[index17];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntProj;
                    myLin.nameProj[kPntProj] = sTmp1;
                    myLin.xProj[kPntProj] = myLin.xWork[index17];
                    myLin.yProj[kPntProj] = myLin.yWork[index17];
                    myLin.zProj[kPntProj] = 0.0;
                }
                if (kSel > 1)
                {
                    for (int index21 = 1; index21 < kSel; ++index21)
                    {
                        myLin.nameWork[index21] = "rad";
                        myLin.zWork[index21] = 0.0;
                    }
                }
                panel7.Invalidate();
            }
            if (nProcess == 620 && kSel == 1)
            {
                double az = 0.0;
                int kp = 0;
                double num12;
                double yrd1 = num12 = 0.0;
                double xrd1 = num12;
                double rd1 = num12;
                double num13;
                double yrd2 = num13 = 0.0;
                double xrd2 = num13;
                double rd2 = num13;
                DllClass1.FindLine(xArc[0], yArc[0], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.RadProj, ref myLin.xRadProj,
                    ref myLin.yRadProj, ref myLin.xLinProj, ref myLin.yLinProj, out rd1, out xrd1, out yrd1, out kp, ref myLin.xPik, 
                    ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                DllClass1.FindLine(xArc[1], yArc[1], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.RadProj, ref myLin.xRadProj,
                    ref myLin.yRadProj, ref myLin.xLinProj, ref myLin.yLinProj, out rd2, out xrd2, out yrd2, out kp, ref myLin.xPik,
                    ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                sTmp1 = "";
                sTmp2 = "";
                DllClass1.FormCreate(1, out iRadio, out rRad, out pRad, out sForm, out pForm, sTmp1, sTmp2);
                if (rRad == 0.0)
                {
                    int num14 = (int)MessageBox.Show("Неверный радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    kRcPnt = 0;
                    listBox1.Items.Clear();
                    panel7.Invalidate();
                    return;
                }
                DllClass1.ArcTangent(1, rRad, rd1, xrd1, yrd1, rd2, xrd2, yrd2, out xRad, out yRad, out xh, out yh, out xk, out yk);
                if (xh == 0.0 || yh == 0.0)
                {
                    int num15 = (int)MessageBox.Show("Увеличить радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    kRcPnt = 0;
                    listBox1.Items.Clear();
                    panel7.Invalidate();
                    return;
                }
                iLong = 0;
                DllClass1.Arc_2Pnt(xh, yh, xk, yk, rRad, ref xRad, ref yRad, out kSel, ref myLin.xWork, ref myLin.yWork, ref iLong, ref myLin.xDop, ref myLin.yDop);
                if (kSel < 2)
                    return;
                for (int index = 0; index <= kSel; ++index)
                {
                    myLin.nameWork[index] = "rad";
                    myLin.zWork[index] = 0.0;
                }
                ip = -1;
                dField = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - myLin.xWork[0];
                    dy = myLin.yPnt[index] - myLin.yWork[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dField)
                    {
                        dField = ss;
                        ip = index;
                    }
                }
                ir = -1;
                dProj = 9999999.9;
                for (int index = 0; index <= kPntProj; ++index)
                {
                    dx = myLin.xProj[index] - myLin.xWork[0];
                    dy = myLin.yProj[index] - myLin.yWork[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dProj)
                    {
                        dProj = ss;
                        ir = index;
                    }
                }
                if (dProj > dField && dField < 0.003)
                {
                    myLin.nameWork[0] = myLin.namePnt[ip];
                    myLin.xWork[0] = myLin.xPnt[ip];
                    myLin.yWork[0] = myLin.yPnt[ip];
                    myLin.zWork[0] = myLin.zPnt[ip];
                }
                if (dProj < dField && dProj < 0.003)
                {
                    myLin.nameWork[0] = myLin.nameProj[ir];
                    myLin.xWork[0] = myLin.xProj[ir];
                    myLin.yWork[0] = myLin.yProj[ir];
                    myLin.zWork[0] = myLin.zProj[ir];
                }
                if (dField >= 0.003 && dProj > 0.003)
                {
                    int nName9 = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName9, out sTmp1);
                    if (nName9 < 0)
                        return;
                    int nName10 = 0;
                    if (kPntProj > -1)
                    {
                        DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName10, out sTmp2);
                        if (nName10 < 0)
                            return;
                        if (nName10 > nName9)
                            sTmp1 = sTmp2;
                    }
                    myLin.nameWork[0] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[0];
                    myLin.yAdd[kAdd] = myLin.yWork[0];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntProj;
                    myLin.nameProj[kPntProj] = sTmp1;
                    myLin.xProj[kPntProj] = myLin.xWork[0];
                    myLin.yProj[kPntProj] = myLin.yWork[0];
                    myLin.zProj[kPntProj] = 0.0;
                }
                ip = -1;
                dField = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - myLin.xWork[kSel];
                    dy = myLin.yPnt[index] - myLin.yWork[kSel];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dField)
                    {
                        dField = ss;
                        ip = index;
                    }
                }
                ir = -1;
                dProj = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - myLin.xWork[kSel];
                    dy = myLin.yPnt[index] - myLin.yWork[kSel];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dProj)
                    {
                        dProj = ss;
                        ir = index;
                    }
                }
                if (dProj > dField && dField < 0.003)
                {
                    myLin.nameWork[kSel] = myLin.namePnt[ip];
                    myLin.xWork[kSel] = myLin.xPnt[ip];
                    myLin.yWork[kSel] = myLin.yPnt[ip];
                    myLin.zWork[kSel] = myLin.zPnt[ip];
                }
                if (dProj < dField && dProj < 0.003)
                {
                    myLin.nameWork[kSel] = myLin.nameProj[ir];
                    myLin.xWork[kSel] = myLin.xProj[ir];
                    myLin.yWork[kSel] = myLin.yProj[ir];
                    myLin.zWork[kSel] = myLin.zProj[ir];
                }
                if (dProj >= 0.003 && dField > 0.003)
                {
                    int nName11 = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName11, out sTmp1);
                    if (nName11 < 0)
                        return;
                    int nName12 = 0;
                    if (kPntProj > -1)
                    {
                        DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName12, out sTmp2);
                        if (nName12 < 0)
                            return;
                        if (nName12 > nName11)
                            sTmp1 = sTmp2;
                    }
                    myLin.nameWork[kSel] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[kSel];
                    myLin.yAdd[kAdd] = myLin.yWork[kSel];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntProj;
                    myLin.nameProj[kPntProj] = sTmp1;
                    myLin.xProj[kPntProj] = myLin.xWork[kSel];
                    myLin.yProj[kPntProj] = myLin.yWork[kSel];
                    myLin.zProj[kPntProj] = 0.0;
                }
                textBox4.Text = sForm;
                panel7.Invalidate();
            }
            if (nProcess == 630 && kSel == 1)
            {
                double az = 0.0;
                int kp = 0;
                double num16;
                double yrd3 = num16 = 0.0;
                double xrd3 = num16;
                double rd3 = num16;
                double num17;
                double yrd4 = num17 = 0.0;
                double xrd4 = num17;
                double rd4 = num17;
                DllClass1.FindLine(xArc[0], yArc[0], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.RadProj, ref myLin.xRadProj, ref myLin.yRadProj, ref myLin.xLinProj, ref myLin.yLinProj, out rd3, out xrd3, out yrd3, out kp, ref myLin.xPik, ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                DllClass1.FindLine(xArc[1], yArc[1], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.RadProj, ref myLin.xRadProj, ref myLin.yRadProj, ref myLin.xLinProj, ref myLin.yLinProj, out rd4, out xrd4, out yrd4, out kp, ref myLin.xPik, ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                sTmp1 = "";
                sTmp2 = "";
                DllClass1.FormCreate(1, out iRadio, out rRad, out pRad, out sForm, out pForm, sTmp1, sTmp2);
                if (rRad == 0.0)
                {
                    int num18 = (int)MessageBox.Show("Неверный радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    kRcPnt = 0;
                    listBox1.Items.Clear();
                    panel7.Invalidate();
                    return;
                }
                DllClass1.ArcTangent(2, rRad, rd3, xrd3, yrd3, rd4, xrd4, yrd4, out xRad, out yRad, out xh, out yh, out xk, out yk);
                if (xh == 0.0 || yh == 0.0)
                {
                    int num19 = (int)MessageBox.Show("Увеличить радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    kRcPnt = 0;
                    listBox1.Items.Clear();
                    panel7.Invalidate();
                    return;
                }
                iLong = 0;
                DllClass1.Arc_2Pnt(xh, yh, xk, yk, rRad, ref xRad, ref yRad, out kSel, ref myLin.xWork, ref myLin.yWork, ref iLong, ref myLin.xDop, ref myLin.yDop);
                if (kSel < 2)
                    return;
                for (int index = 0; index <= kSel; ++index)
                {
                    myLin.nameWork[index] = "rad";
                    myLin.zWork[index] = 0.0;
                }
                ip = -1;
                dField = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - myLin.xWork[0];
                    dy = myLin.yPnt[index] - myLin.yWork[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dField)
                    {
                        dField = ss;
                        ip = index;
                    }
                }
                ir = -1;
                dProj = 9999999.9;
                for (int index = 0; index <= kPntProj; ++index)
                {
                    dx = myLin.xProj[index] - myLin.xWork[0];
                    dy = myLin.yProj[index] - myLin.yWork[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dProj)
                    {
                        dProj = ss;
                        ir = index;
                    }
                }
                if (dProj > dField && dField < 0.003)
                {
                    myLin.nameWork[0] = myLin.namePnt[ip];
                    myLin.xWork[0] = myLin.xPnt[ip];
                    myLin.yWork[0] = myLin.yPnt[ip];
                    myLin.zWork[0] = myLin.zPnt[ip];
                }
                if (dProj < dField && dProj < 0.003)
                {
                    myLin.nameWork[0] = myLin.nameProj[ir];
                    myLin.xWork[0] = myLin.xProj[ir];
                    myLin.yWork[0] = myLin.yProj[ir];
                    myLin.zWork[0] = myLin.zProj[ir];
                }
                if (dField >= 0.003 && dProj > 0.003)
                {
                    int nName13 = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName13, out sTmp1);
                    if (nName13 < 0)
                        return;
                    int nName14 = 0;
                    if (kPntProj > -1)
                    {
                        DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName14, out sTmp2);
                        if (nName14 < 0)
                            return;
                        if (nName14 > nName13)
                            sTmp1 = sTmp2;
                    }
                    myLin.nameWork[0] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[0];
                    myLin.yAdd[kAdd] = myLin.yWork[0];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntProj;
                    myLin.nameProj[kPntProj] = sTmp1;
                    myLin.xProj[kPntProj] = myLin.xWork[0];
                    myLin.yProj[kPntProj] = myLin.yWork[0];
                    myLin.zProj[kPntProj] = 0.0;
                }
                ip = -1;
                dField = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - myLin.xWork[kSel];
                    dy = myLin.yPnt[index] - myLin.yWork[kSel];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dField)
                    {
                        dField = ss;
                        ip = index;
                    }
                }
                ir = -1;
                dProj = 9999999.9;
                for (int index = 0; index <= kPntProj; ++index)
                {
                    dx = myLin.xProj[index] - myLin.xWork[kSel];
                    dy = myLin.yProj[index] - myLin.yWork[kSel];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dProj)
                    {
                        dProj = ss;
                        ir = index;
                    }
                }
                if (dProj > dField && dField < 0.003)
                {
                    myLin.nameWork[kSel] = myLin.namePnt[ip];
                    myLin.xWork[kSel] = myLin.xPnt[ip];
                    myLin.yWork[kSel] = myLin.yPnt[ip];
                    myLin.zWork[kSel] = myLin.zPnt[ip];
                }
                if (dProj < dField && dProj < 0.003)
                {
                    myLin.nameWork[kSel] = myLin.nameProj[ir];
                    myLin.xWork[kSel] = myLin.xProj[ir];
                    myLin.yWork[kSel] = myLin.yProj[ir];
                    myLin.zWork[kSel] = myLin.zProj[ir];
                }
                if (dField >= 0.003 && dProj > 0.003)
                {
                    int nName15 = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName15, out sTmp1);
                    if (nName15 < 0)
                        return;
                    int nName16 = 0;
                    if (kPntProj > -1)
                    {
                        DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName16, out sTmp2);
                        if (nName16 < 0)
                            return;
                        if (nName16 > nName15)
                            sTmp1 = sTmp2;
                    }
                    myLin.nameWork[kSel] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[kSel];
                    myLin.yAdd[kAdd] = myLin.yWork[kSel];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntProj;
                    myLin.nameProj[kPntProj] = sTmp1;
                    myLin.xProj[kPntProj] = myLin.xWork[kSel];
                    myLin.yProj[kPntProj] = myLin.yWork[kSel];
                    myLin.zProj[kPntProj] = 0.0;
                }
                textBox4.Text = sForm;
                panel7.Invalidate();
            }
            if (nProcess == 640)
            {
                double num20;
                double num21 = num20 = 0.0;
                double num22 = num20;
                double num23 = num20;
                double num24 = num20;
                if (kSel == 1)
                {
                    int index22 = -1;
                    int kp = 0;
                    DllClass1.FindEndLine(xArc[0], yArc[0], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.xLinProj, ref myLin.yLinProj, out kp, ref myLin.xPik, ref myLin.yPik, out indLine, out ip);
                    if (ip > 0 && ip < kp)
                    {
                        int num25 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
                        kSel = -1;
                        kRcPnt = 0;
                        kAdd = 0;
                        nProcess = 0;
                        panel7.Invalidate();
                        return;
                    }
                    if (ip == 0)
                    {
                        xh = myLin.xPik[0];
                        yh = myLin.yPik[0];
                        xk = myLin.xPik[1];
                        yk = myLin.yPik[1];
                        num24 = myLin.xPik[0];
                        num23 = myLin.yPik[0];
                    }
                    if (ip == kp)
                    {
                        xh = myLin.xPik[kp];
                        yh = myLin.yPik[kp];
                        xk = myLin.xPik[kp - 1];
                        yk = myLin.yPik[kp - 1];
                        num24 = myLin.xPik[kp];
                        num23 = myLin.yPik[kp];
                    }
                    DllClass1.FindEndLine(xArc[1], yArc[1], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.xLinProj, ref myLin.yLinProj, out kp, ref myLin.xPik, ref myLin.yPik, out indLine, out ip);
                    if (ip > 0 && ip < kp)
                    {
                        int num26 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
                        kSel = -1;
                        kRcPnt = 0;
                        kAdd = 0;
                        nProcess = 0;
                        panel7.Invalidate();
                        return;
                    }
                    if (ip == 0)
                    {
                        x3 = myLin.xPik[0];
                        y3 = myLin.yPik[0];
                        x4 = myLin.xPik[1];
                        y4 = myLin.yPik[1];
                        num22 = myLin.xPik[0];
                        num21 = myLin.yPik[0];
                    }
                    if (ip == kp)
                    {
                        x3 = myLin.xPik[kp];
                        y3 = myLin.yPik[kp];
                        x4 = myLin.xPik[kp - 1];
                        y4 = myLin.yPik[kp - 1];
                        num22 = myLin.xPik[kp];
                        num21 = myLin.yPik[kp];
                    }
                    dx = num22 - num24;
                    dy = num21 - num23;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    sTmp1 = string.Format("{0:F1}", (object)ss);
                    if (ss < 0.001)
                    {
                        int num27 = (int)MessageBox.Show("Неправильный выбор линий", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        kSel = -1;
                        listBox1.Items.Clear();
                        nProcess = 0;
                        panel7.Invalidate();
                        return;
                    }
                    sTmp2 = "";
                    DllClass1.FormCreate(3, out iRadio, out rRad, out pRad, out sForm, out pForm, sTmp1, sTmp2);
                    if (rRad <= 0.0 || pRad <= 0.0)
                    {
                        int num28 = (int)MessageBox.Show("One Radius = 0", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        kSel = -1;
                        listBox1.Items.Clear();
                        nProcess = 0;
                        panel7.Invalidate();
                        return;
                    }
                    int kt = 0;
                    DllClass1.BlindAlley(xArc[0], yArc[0], xh, yh, xk, yk, x3, y3, x4, y4, rRad, pRad, out kt, ref xAll, ref yAll);
                    if (kt != 9)
                    {
                        int num29 = (int)MessageBox.Show("Неправильный выбор линий", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        kSel = -1;
                        listBox1.Items.Clear();
                        nProcess = 0;
                        panel7.Invalidate();
                        return;
                    }
                    xArc[0] = xAll[3];
                    yArc[0] = yAll[3];
                    xArc[1] = xAll[4];
                    yArc[1] = yAll[4];
                    xArc[2] = xAll[5];
                    yArc[2] = yAll[5];
                    DllClass1.Arc_3Pnt(xArc, yArc, out ss, out dx, out dy, out kSel, ref myLin.xDop, ref myLin.yDop, ref iLong);
                    if (kSel < 2)
                        return;
                    for (int index23 = 0; index23 <= kSel; ++index23)
                    {
                        ++index22;
                        myLin.xWork[index22] = myLin.xDop[index23];
                        myLin.yWork[index22] = myLin.yDop[index23];
                    }
                    xArc[0] = xAll[5];
                    yArc[0] = yAll[5];
                    xArc[1] = xAll[9];
                    yArc[1] = yAll[9];
                    xArc[2] = xAll[8];
                    yArc[2] = yAll[8];
                    DllClass1.Arc_3Pnt(xArc, yArc, out ss, out dx, out dy, out kSel, ref myLin.xDop, ref myLin.yDop, ref iLong);
                    if (kSel < 2)
                        return;
                    dx = myLin.xWork[index22] - myLin.xDop[0];
                    dy = myLin.yWork[index22] - myLin.yDop[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < 0.1)
                    {
                        for (int index24 = 1; index24 <= kSel; ++index24)
                        {
                            ++index22;
                            myLin.xWork[index22] = myLin.xDop[index24];
                            myLin.yWork[index22] = myLin.yDop[index24];
                        }
                    }
                    if (ss > 0.1)
                    {
                        xArc[0] = xAll[8];
                        yArc[0] = yAll[8];
                        xArc[1] = xAll[9];
                        yArc[1] = yAll[9];
                        xArc[2] = xAll[5];
                        yArc[2] = yAll[5];
                        DllClass1.Arc_3Pnt(xArc, yArc, out ss, out dx, out dy, out kSel, ref myLin.xDop, ref myLin.yDop, ref iLong);
                        if (kSel < 2)
                            return;
                        for (int index25 = 1; index25 <= kSel; ++index25)
                        {
                            ++index22;
                            myLin.xWork[index22] = myLin.xDop[index25];
                            myLin.yWork[index22] = myLin.yDop[index25];
                        }
                    }
                    xArc[0] = xAll[8];
                    yArc[0] = yAll[8];
                    xArc[1] = xAll[7];
                    yArc[1] = yAll[7];
                    xArc[2] = xAll[6];
                    yArc[2] = yAll[6];
                    DllClass1.Arc_3Pnt(xArc, yArc, out ss, out dx, out dy, out kSel, ref myLin.xDop, ref myLin.yDop, ref iLong);
                    if (kSel < 2)
                        return;
                    dx = myLin.xWork[index22] - myLin.xDop[0];
                    dy = myLin.yWork[index22] - myLin.yDop[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < 0.1)
                    {
                        for (int index26 = 1; index26 <= kSel; ++index26)
                        {
                            ++index22;
                            myLin.xWork[index22] = myLin.xDop[index26];
                            myLin.yWork[index22] = myLin.yDop[index26];
                        }
                    }
                    kSel = index22;
                    for (int index27 = 0; index27 <= kSel; ++index27)
                    {
                        myLin.nameWork[index27] = "rad";
                        myLin.zWork[index27] = 0.0;
                    }
                    ip = -1;
                    dField = 9999999.9;
                    for (int index28 = 0; index28 <= kPntPlus; ++index28)
                    {
                        dx = myLin.xPnt[index28] - myLin.xWork[0];
                        dy = myLin.yPnt[index28] - myLin.yWork[0];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < dField)
                        {
                            dField = ss;
                            ip = index28;
                        }
                    }
                    ir = -1;
                    dProj = 9999999.9;
                    for (int index29 = 0; index29 <= kPntProj; ++index29)
                    {
                        dx = myLin.xProj[index29] - myLin.xWork[0];
                        dy = myLin.yProj[index29] - myLin.yWork[0];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < dProj)
                        {
                            dProj = ss;
                            ir = index29;
                        }
                    }
                    if (dProj > dField && dField < 0.003)
                    {
                        myLin.nameWork[0] = myLin.namePnt[ip];
                        myLin.xWork[0] = myLin.xPnt[ip];
                        myLin.yWork[0] = myLin.yPnt[ip];
                        myLin.zWork[0] = myLin.zPnt[ip];
                    }
                    if (dProj < dField && dProj < 0.003)
                    {
                        myLin.nameWork[0] = myLin.nameProj[ir];
                        myLin.xWork[0] = myLin.xProj[ir];
                        myLin.yWork[0] = myLin.yProj[ir];
                        myLin.zWork[0] = myLin.zProj[ir];
                    }
                    if (dField >= 0.003 && dProj > 0.003)
                    {
                        int nName17 = 0;
                        DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName17, out sTmp1);
                        if (nName17 < 0)
                            return;
                        int nName18 = 0;
                        if (kPntProj > -1)
                        {
                            DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName18, out sTmp2);
                            if (nName18 < 0)
                                return;
                            if (nName18 > nName17)
                                sTmp1 = sTmp2;
                        }
                        myLin.nameWork[0] = sTmp1;
                        ++kAdd;
                        myLin.nameAdd[kAdd] = sTmp1;
                        myLin.xAdd[kAdd] = myLin.xWork[0];
                        myLin.yAdd[kAdd] = myLin.yWork[0];
                        myLin.zAdd[kAdd] = 0.0;
                        ++kPntProj;
                        myLin.nameProj[kPntProj] = sTmp1;
                        myLin.xProj[kPntProj] = myLin.xWork[0];
                        myLin.yProj[kPntProj] = myLin.yWork[0];
                        myLin.zProj[kPntProj] = 0.0;
                    }
                    ip = -1;
                    dField = 9999999.9;
                    for (int index30 = 0; index30 <= kPntPlus; ++index30)
                    {
                        dx = myLin.xPnt[index30] - myLin.xWork[kSel];
                        dy = myLin.yPnt[index30] - myLin.yWork[kSel];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < dField)
                        {
                            dField = ss;
                            ip = index30;
                        }
                    }
                    ir = -1;
                    dProj = 9999999.9;
                    for (int index31 = 0; index31 <= kPntProj; ++index31)
                    {
                        dx = myLin.xProj[index31] - myLin.xWork[kSel];
                        dy = myLin.yProj[index31] - myLin.yWork[kSel];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < dProj)
                        {
                            dProj = ss;
                            ir = index31;
                        }
                    }
                    if (dProj > dField && dField < 0.003)
                    {
                        myLin.nameWork[kSel] = myLin.namePnt[ip];
                        myLin.xWork[kSel] = myLin.xPnt[ip];
                        myLin.yWork[kSel] = myLin.yPnt[ip];
                        myLin.zWork[kSel] = myLin.zPnt[ip];
                    }
                    if (dProj < dField && dProj < 0.003)
                    {
                        myLin.nameWork[kSel] = myLin.nameProj[ir];
                        myLin.xWork[kSel] = myLin.xProj[ir];
                        myLin.yWork[kSel] = myLin.yProj[ir];
                        myLin.zWork[kSel] = myLin.zProj[ir];
                    }
                    if (dProj >= 0.003 && dField > 0.003)
                    {
                        int nName19 = 0;
                        DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName19, out sTmp1);
                        if (nName19 < 0)
                            return;
                        int nName20 = 0;
                        if (kPntProj > -1)
                        {
                            DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName20, out sTmp2);
                            if (nName20 < 0)
                                return;
                            if (nName20 > nName19)
                                sTmp1 = sTmp2;
                        }
                        myLin.nameWork[kSel] = sTmp1;
                        ++kAdd;
                        myLin.nameAdd[kAdd] = sTmp1;
                        myLin.xAdd[kAdd] = myLin.xWork[kSel];
                        myLin.yAdd[kAdd] = myLin.yWork[kSel];
                        myLin.zAdd[kAdd] = 0.0;
                        ++kPntProj;
                        myLin.nameProj[kPntProj] = sTmp1;
                        myLin.xProj[kPntProj] = myLin.xWork[kSel];
                        myLin.yProj[kPntProj] = myLin.yWork[kSel];
                        myLin.zProj[kPntProj] = 0.0;
                    }
                    textBox4.Text = "1";
                    panel7.Invalidate();
                }
            }
            if (nProcess != 54 && nProcess != 55 && nProcess != 56 && nProcess != 57 && nProcess != 58 && nProcess != 59 && nProcess != 62 || kSel != 1)
                return;
            double az1 = 0.0;
            int kp1 = 0;
            int kp2 = 0;
            double num30;
            double yrd5 = num30 = 0.0;
            double xrd5 = num30;
            double rd5 = num30;
            double num31;
            double yrd6 = num31 = 0.0;
            double xrd6 = num31;
            double rd6 = num31;
            DllClass1.FindLine(xArc[0], yArc[0], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.RadProj, ref myLin.xRadProj, 
                ref myLin.yRadProj, ref myLin.xLinProj, ref myLin.yLinProj, out rd5, out xrd5, out yrd5, out kp1, ref myLin.xPik, 
                ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az1, out indLine);
            if (kp1 < 1)
                return;
            DllClass1.FindLine(xArc[1], yArc[1], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.RadProj, ref myLin.xRadProj,
                ref myLin.yRadProj, ref myLin.xLinProj, ref myLin.yLinProj, out rd6, out xrd6, out yrd6, out kp2, ref myLin.xPol, 
                ref myLin.yPol, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az1, out indSide);
            if (kp2 < 1)
                return;
            if (indLine == indSide)
            {
                rr = 9999999.9;
                ip = -1;
                for (int index = 0; index <= kp1; ++index)
                {
                    dx = myLin.xPik[index] - xArc[0];
                    dy = myLin.yPik[index] - yArc[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        ip = index;
                    }
                }
                if (ip == 0 || ip == kp1)
                {
                    xh = myLin.xPik[0];
                    yh = myLin.yPik[0];
                    xk = myLin.xPik[1];
                    yk = myLin.yPik[1];
                    x3 = myLin.xPik[kp1];
                    y3 = myLin.yPik[kp1];
                    x4 = myLin.xPik[kp1 - 1];
                    y4 = myLin.yPik[kp1 - 1];
                }
                if (ip > 0 && ip < kp1)
                {
                    xh = myLin.xPik[ip];
                    yh = myLin.yPik[ip];
                    xk = myLin.xPik[ip - 1];
                    yk = myLin.yPik[ip - 1];
                    x3 = myLin.xPik[ip];
                    y3 = myLin.yPik[ip];
                    x4 = myLin.xPik[ip + 1];
                    y4 = myLin.yPik[ip + 1];
                }
            }
            if (indLine != indSide)
            {
                if (nProcess == 54 || nProcess == 55 || nProcess == 58 || nProcess == 59)
                    DllClass1.FindEndLine(xArc[0], yArc[0], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.xLinProj, ref myLin.yLinProj, out kp1, ref myLin.xPik, ref myLin.yPik, out indLine, out ip);
                if (nProcess == 56 || nProcess == 57 || nProcess == 62)
                {
                    rr = 9999999.9;
                    ip = -1;
                    for (int index = 0; index <= kp1; ++index)
                    {
                        dx = myLin.xPik[index] - xArc[0];
                        dy = myLin.yPik[index] - yArc[0];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < rr)
                        {
                            rr = ss;
                            ip = index;
                        }
                    }
                }
                if (ip > 0 && ip < kp1)
                {
                    int num32 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
                    kSel = -1;
                    kRcPnt = 0;
                    kAdd = 0;
                    nProcess = 0;
                    panel7.Invalidate();
                    return;
                }
                if (ip == 0)
                {
                    xh = myLin.xPik[0];
                    yh = myLin.yPik[0];
                    xk = myLin.xPik[1];
                    yk = myLin.yPik[1];
                }
                if (ip == kp1)
                {
                    xh = myLin.xPik[kp1];
                    yh = myLin.yPik[kp1];
                    xk = myLin.xPik[kp1 - 1];
                    yk = myLin.yPik[kp1 - 1];
                }
                if (nProcess == 54 || nProcess == 55 || nProcess == 58 || nProcess == 59)
                    DllClass1.FindEndLine(xArc[1], yArc[1], kLineProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.xLinProj, ref myLin.yLinProj, out kp2, ref myLin.xPol, ref myLin.yPol, out indSide, out ip);
                if (nProcess == 56 || nProcess == 57 || nProcess == 62)
                {
                    rr = 9999999.9;
                    ip = -1;
                    if (kp2 > -1)
                    {
                        for (int index = 0; index <= kp2; ++index)
                        {
                            dx = myLin.xPol[index] - xArc[1];
                            dy = myLin.yPol[index] - yArc[1];
                            ss = Math.Sqrt(dx * dx + dy * dy);
                            if (ss < rr)
                            {
                                rr = ss;
                                ip = index;
                            }
                        }
                    }
                }
                if (ip > 0 && ip < kp2)
                {
                    int num33 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
                    kSel = -1;
                    kRcPnt = 0;
                    kAdd = 0;
                    nProcess = 0;
                    panel7.Invalidate();
                    return;
                }
                if (ip == 0)
                {
                    x3 = myLin.xPol[0];
                    y3 = myLin.yPol[0];
                    x4 = myLin.xPol[1];
                    y4 = myLin.yPol[1];
                }
                if (ip == kp2)
                {
                    x3 = myLin.xPol[kp2];
                    y3 = myLin.yPol[kp2];
                    x4 = myLin.xPol[kp2 - 1];
                    y4 = myLin.yPol[kp2 - 1];
                }
            }
            if (nProcess == 56 || nProcess == 57)
            {
                sTmp1 = "";
                sTmp2 = "";
                DllClass1.FormCreate(1, out iRadio, out rRad, out pRad, out sForm, out pForm, sTmp1, sTmp2);
                if (rRad == 0.0)
                {
                    int num34 = (int)MessageBox.Show("Неверный радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    kRcPnt = 0;
                    listBox1.Items.Clear();
                    panel7.Invalidate();
                    return;
                }
                rd5 = rRad;
                if (nProcess == 57)
                    iLong = 1;
            }
            if (nProcess == 62)
            {
                sTmp1 = "";
                sTmp2 = "";
                DllClass1.FormCreate(4, out iRadio, out rRad, out pRad, out sForm, out pForm, sTmp1, sTmp2);
                if (rRad == 0.0)
                {
                    int num35 = (int)MessageBox.Show("Неверное расстояние", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    kRcPnt = 0;
                    kAdd = 0;
                    nProcess = 0;
                    listBox1.Items.Clear();
                    panel7.Invalidate();
                    return;
                }
                rd6 = rRad;
            }
            if (nProcess == 55 || nProcess == 59)
                iLong = 1;
            if (nProcess != 62)
            {
                DllClass1.Fillet(nFillet, xh, yh, xk, yk, x3, y3, x4, y4, iLong, rd5, out rRad, out xRad, out yRad, out kSel, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop);
                int num36 = (int)MessageBox.Show(string.Format("nFillet = {0}", (object)nFillet) + "   " + string.Format("kSel = {0}", (object)kSel));
                if (kSel < 3)
                {
                    int num37 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
                    kSel = -1;
                    kRcPnt = 0;
                    kAdd = 0;
                    nProcess = 0;
                    panel7.Invalidate();
                    return;
                }
            }
            if (nProcess == 62)
            {
                DllClass1.FilletBisect(xh, yh, xk, yk, x3, y3, x4, y4, rd6, out rRad, out xRad, out yRad, out kSel, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop);
                if (kSel < 3)
                {
                    int num38 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
                    kSel = -1;
                    kRcPnt = 0;
                    kAdd = 0;
                    nProcess = 0;
                    panel7.Invalidate();
                    return;
                }
            }
            for (int index = 0; index <= kSel; ++index)
            {
                myLin.nameWork[index] = "rad";
                myLin.zWork[index] = 0.0;
            }
            ip = -1;
            dField = 9999999.9;
            for (int index = 0; index <= kPntPlus; ++index)
            {
                dx = myLin.xPnt[index] - myLin.xWork[0];
                dy = myLin.yPnt[index] - myLin.yWork[0];
                ss = Math.Sqrt(dx * dx + dy * dy);
                if (ss < dField)
                {
                    dField = ss;
                    ip = index;
                }
            }
            ir = -1;
            dProj = 9999999.9;
            if (kPntProj > -1)
            {
                for (int index = 0; index <= kPntProj; ++index)
                {
                    dx = myLin.xProj[index] - myLin.xWork[0];
                    dy = myLin.yProj[index] - myLin.yWork[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dProj)
                    {
                        dProj = ss;
                        ir = index;
                    }
                }
            }
            if (dProj > dField && dField < 0.003)
            {
                myLin.nameWork[0] = myLin.namePnt[ip];
                myLin.xWork[0] = myLin.xPnt[ip];
                myLin.yWork[0] = myLin.yPnt[ip];
                myLin.zWork[0] = myLin.zPnt[ip];
            }
            if (dProj < dField && dProj < 0.003)
            {
                myLin.nameWork[0] = myLin.nameProj[ir];
                myLin.xWork[0] = myLin.xProj[ir];
                myLin.yWork[0] = myLin.yProj[ir];
                myLin.zWork[0] = myLin.zProj[ir];
            }
            if (dField >= 0.003 && dProj > 0.003)
            {
                int nName21 = 0;
                DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName21, out sTmp1);
                if (nName21 < 0)
                    return;
                int nName22 = 0;
                if (kPntProj > -1)
                {
                    DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName22, out sTmp2);
                    if (nName22 < 0)
                        return;
                    if (nName22 > nName21)
                        sTmp1 = sTmp2;
                }
                myLin.nameWork[0] = sTmp1;
                ++kAdd;
                myLin.nameAdd[kAdd] = sTmp1;
                myLin.xAdd[kAdd] = myLin.xWork[0];
                myLin.yAdd[kAdd] = myLin.yWork[0];
                myLin.zAdd[kAdd] = 0.0;
                ++kPntProj;
                myLin.nameProj[kPntProj] = sTmp1;
                myLin.xProj[kPntProj] = myLin.xWork[0];
                myLin.yProj[kPntProj] = myLin.yWork[0];
                myLin.zProj[kPntProj] = 0.0;
            }
            ip = -1;
            dField = 9999999.9;
            for (int index = 0; index <= kPntPlus; ++index)
            {
                dx = myLin.xPnt[index] - myLin.xWork[kSel];
                dy = myLin.yPnt[index] - myLin.yWork[kSel];
                ss = Math.Sqrt(dx * dx + dy * dy);
                if (ss < dField)
                {
                    dField = ss;
                    ip = index;
                }
            }
            ir = -1;
            dProj = 9999999.9;
            if (kPntProj > -1)
            {
                for (int index = 0; index <= kPntProj; ++index)
                {
                    dx = myLin.xProj[index] - myLin.xWork[kSel];
                    dy = myLin.yProj[index] - myLin.yWork[kSel];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < dProj)
                    {
                        dProj = ss;
                        ir = index;
                    }
                }
            }
            if (dProj > dField && dField < 0.003)
            {
                myLin.nameWork[kSel] = myLin.namePnt[ip];
                myLin.xWork[kSel] = myLin.xPnt[ip];
                myLin.yWork[kSel] = myLin.yPnt[ip];
                myLin.zWork[kSel] = myLin.zPnt[ip];
            }
            if (dProj < dField && dProj < 0.003)
            {
                myLin.nameWork[kSel] = myLin.nameProj[ir];
                myLin.xWork[kSel] = myLin.xProj[ir];
                myLin.yWork[kSel] = myLin.yProj[ir];
                myLin.zWork[kSel] = myLin.zProj[ir];
            }
            if (dField >= 0.003 && dProj > 0.003)
            {
                int nName23 = 0;
                DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName23, out sTmp1);
                if (nName23 < 0)
                    return;
                int nName24 = 0;
                if (kPntProj > -1)
                {
                    DllClass1.NewPointName(kPntProj, myLin.nameProj, out nName24, out sTmp2);
                    if (nName24 < 0)
                        return;
                    if (nName24 > nName23)
                        sTmp1 = sTmp2;
                }
                myLin.nameWork[kSel] = sTmp1;
                ++kAdd;
                myLin.nameAdd[kAdd] = sTmp1;
                myLin.xAdd[kAdd] = myLin.xWork[kSel];
                myLin.yAdd[kAdd] = myLin.yWork[kSel];
                myLin.zAdd[kAdd] = 0.0;
                ++kPntProj;
                myLin.nameProj[kPntProj] = sTmp1;
                myLin.xProj[kPntProj] = myLin.xWork[kSel];
                myLin.yProj[kPntProj] = myLin.yWork[kSel];
                myLin.zProj[kPntProj] = 0.0;
            }
            sTmp1 = string.Format("{0:F3}", (object)rRad);
            textBox4.Text = sTmp1;
            panel7.Invalidate();
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
            if (!File.Exists(myLin.filePoint))
            {
                panel2.Text = string.Format("{0}", (object)e.X);
                panel4.Text = string.Format("{0}", (object)e.Y);
            }
            if (File.Exists(myLin.filePoint))
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
            if (nControl != 40 || e.Button != MouseButtons.Left)
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

        private void SelectBox_Click(object sender, EventArgs e)
        {
            nProcess = 0;
            nControl = 10;
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            nProcess = 0;
            nControl = 20;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            nProcess = 0;
            nControl = 30;
        }

        private void Move_Click(object sender, EventArgs e)
        {
            nProcess = 0;
            nControl = 40;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            nProcess = 510;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = false;
            textBox4.Visible = false;
            panel7.Invalidate();
        }

        private void ArcShort_Click(object sender, EventArgs e)
        {
            nProcess = 520;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            textBox4.Text = "";
            panel7.Invalidate();
        }

        private void ArcLong_Click(object sender, EventArgs e)
        {
            nProcess = 530;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            textBox4.Text = "";
            panel7.Invalidate();
        }

        private void Arc3Pnt_Click(object sender, EventArgs e)
        {
            nProcess = 540;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            textBox4.Text = "";
            panel7.Invalidate();
        }

        private void Circle3Pnt_Click(object sender, EventArgs e)
        {
            nProcess = 550;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            textBox4.Text = "";
            panel7.Invalidate();
        }

        private void CircleCentre_Click(object sender, EventArgs e)
        {
            nProcess = 560;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            textBox4.Text = "";
            panel7.Invalidate();
        }

        private void Curve_Click(object sender, EventArgs e)
        {
            nProcess = 570;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            panel7.Invalidate();
        }

        private void Parallel_Click(object sender, EventArgs e)
        {
            nProcess = 580;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            panel7.Invalidate();
        }

        private void PointLine_Click(object sender, EventArgs e)
        {
            nProcess = 590;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            panel7.Invalidate();
        }

        private void Lengthen_Click(object sender, EventArgs e)
        {
            nProcess = 610;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            panel7.Invalidate();
        }

        private void TangentDirect_Click(object sender, EventArgs e)
        {
            nProcess = 620;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            panel7.Invalidate();
        }

        private void TangentInverse_Click(object sender, EventArgs e)
        {
            nProcess = 630;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            panel7.Invalidate();
        }

        private void BlindAlley_Click(object sender, EventArgs e)
        {
            if (kLineProj < 2)
            {
                int num = (int)MessageBox.Show("Линии < 2", "Замкнутая линия", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 640;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                listBox1.Items.Clear();
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                panel7.Invalidate();
            }
        }

        private void FilletShortDirect_Click(object sender, EventArgs e)
        {
            if (kLineProj < 1)
            {
                int num = (int)MessageBox.Show("Линии < 2", "Замкнутая линия", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 54;
                iImageShow = 1;
                nFillet = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                listBox1.Items.Clear();
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                panel7.Invalidate();
            }
        }

        private void FilletLongDirect_Click(object sender, EventArgs e)
        {
            if (kLineProj < 1)
            {
                int num = (int)MessageBox.Show("Линии < 2", "Замкнутая линия", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 55;
                iImageShow = 1;
                nFillet = 3;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                listBox1.Items.Clear();
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                panel7.Invalidate();
            }
        }

        private void FilletDirectR_Click(object sender, EventArgs e)
        {
            if (kLineProj < 1)
            {
                int num = (int)MessageBox.Show("Линии < 2", "Замкнутая линия", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 56;
                iImageShow = 1;
                nFillet = 5;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                listBox1.Items.Clear();
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                panel7.Invalidate();
            }
        }

        private void FilletInverseR_Click(object sender, EventArgs e)
        {
            if (kLineProj < 1)
            {
                int num = (int)MessageBox.Show("Линии < 2", "Замкнутая линия", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 57;
                iImageShow = 1;
                nFillet = 6;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                listBox1.Items.Clear();
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                panel7.Invalidate();
            }
        }

        private void FilletShortInverse_Click(object sender, EventArgs e)
        {
            if (kLineProj < 1)
            {
                int num = (int)MessageBox.Show("Линии < 2", "Замкнутая линия", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 58;
                iImageShow = 1;
                nFillet = 2;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                listBox1.Items.Clear();
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                panel7.Invalidate();
            }
        }

        private void FilletLongInverse_Click(object sender, EventArgs e)
        {
            if (kLineProj < 1)
            {
                int num = (int)MessageBox.Show("Линии < 2", "Замкнутая линия", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 59;
                iImageShow = 1;
                nFillet = 4;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                listBox1.Items.Clear();
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                panel7.Invalidate();
            }
        }

        private void FilletBisect_Click(object sender, EventArgs e)
        {
            if (kLineProj < 1)
            {
                int num = (int)MessageBox.Show("Линии < 2", "Замкнутая линия", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 62;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                listBox1.Items.Clear();
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                panel7.Invalidate();
            }
        }

        private void AllPointsDelete_Click(object sender, EventArgs e)
        {
            if (kPntProj < 0)
            {
                int num = (int)MessageBox.Show("Все точки проекта были удалены", "Построение проектных линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                kSel = -1;
                kAdd = 0;
                kRcPnt = 0;
                nProcess = 0;
                nControl = 0;
                panel7.Invalidate();
            }
            else
            {
                if (File.Exists(myLin.fpointProj) && MessageBox.Show("Вы действительно хотите Удалить все точки Проекта ?", "Построение проектных линий", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                if (File.Exists(myLin.fpointProj))
                    File.Delete(myLin.fpointProj);
                kPntProj = -1;
                kProjInput = -1;
                kSel = -1;
                kAdd = 0;
                kRcPnt = 0;
                nProcess = 0;
                nControl = 0;
                panel7.Invalidate();
            }
        }

        private void LineDelete_Click(object sender, EventArgs e)
        {
            nProcess = 600;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            if (kLineProj != 0)
                return;
            int num = (int)MessageBox.Show("Все строки были удалены", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            nProcess = 0;
        }

        private void AllDelete_Click(object sender, EventArgs e)
        {
            if (kLineProj == 0)
            {
                int num = (int)MessageBox.Show("Все строки были удалены", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                kSel = -1;
                kAdd = 0;
                kRcPnt = 0;
                nProcess = 0;
                listBox1.Items.Clear();
                panel7.Invalidate();
            }
            else
            {
                if (File.Exists(myLin.flineProj) && MessageBox.Show("Вы действительно хотите удалить все строки ?", "Построение линий", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                myLin.kPntProj = kPntProj;
                myLin.kProjInput = kProjInput;
                myLin.KeepPointProj();
                if (File.Exists(myLin.flineProj))
                {
                    File.Delete(myLin.flineProj);
                    kLineProj = 0;
                    kSel = -1;
                    kAdd = 0;
                    nProcess = 0;
                    nControl = 0;
                    kRcPnt = 0;
                    rRad = 0.0;
                    xRad = 0.0;
                    yRad = 0.0;
                    iLong = 0;
                    listBox1.Items.Clear();
                    textBox4.Text = "";
                }
                if (File.Exists(myLin.fnodeProj))
                {
                    File.Delete(myLin.fnodeProj);
                    kNodeProj = 0;
                }
                if (File.Exists(myLin.ftopoProj))
                {
                    File.Delete(myLin.ftopoProj);
                    kTopoProj = 0;
                    myLin.kTopoProj = 0;
                }
                if (File.Exists(myLin.fpolyProj))
                {
                    File.Delete(myLin.fpolyProj);
                    kPolyProj = 0;
                    myLin.kPolyProj = 0;
                }
                myLin.AllActionRemove();
                nAction = 0;
                myLin.nAction = nAction;
                myLin.KeepLoadAction(2);
                if (File.Exists(myLin.flineFinal))
                    File.Delete(myLin.flineFinal);
                if (File.Exists(myLin.fpolyFinal))
                    File.Delete(myLin.fpolyFinal);
                kPolyAct = 0;
                if (File.Exists(myLin.fileItems))
                    File.Delete(myLin.fileItems);
                if (File.Exists(myLin.flistAction))
                    File.Delete(myLin.flistAction);
                FileStream output = new FileStream(myLin.flistAction, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                string str = "0";
                binaryWriter.Write(str);
                binaryWriter.Close();
                output.Close();
                iProjDraw = 0;
                panel7.Invalidate();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            kSel = -1;
            nProcess = 0;
            nControl = 0;
            kAdd = 0;
            kRcPnt = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            textBox4.Text = "";
            myLin.PointProjLoad();
            kPntProj = myLin.kPntProj;
            kProjInput = myLin.kProjInput;
            myLin.PointLoad();
            panel7.Invalidate();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (kSel <= 0)
                return;
            if (textBox4.Text == "")
            {
                int num1 = (int)MessageBox.Show("Может быть, вы забыли нажать правую кнопку мыши", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                rRad = 0.0;
                if (kSel > 0)
                {
                    DllClass1.CheckText(textBox4.Text, out rRad, out iCond);
                    if (iCond < 0)
                    {
                        int num2 = (int)MessageBox.Show("Проверьте данные", "Аеротриангуляция", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                if (kAdd > 0)
                {
                    myLin.kPntProj = kPntProj;
                    myLin.kProjInput = kProjInput;
                    myLin.KeepPointProj();
                }
                int index1 = 0;
                if (kLineProj > 0)
                    index1 = myLin.kPr2[kLineProj];
                for (int index2 = 0; index2 <= kSel; ++index2)
                {
                    ++index1;
                    myLin.xLinProj[index1] = myLin.xWork[index2];
                    myLin.yLinProj[index1] = myLin.yWork[index2];
                }
                ++kLineProj;
                myLin.iLongProj[kLineProj] = iLong;
                myLin.RadProj[kLineProj] = rRad;
                myLin.xRadProj[kLineProj] = xRad;
                myLin.yRadProj[kLineProj] = yRad;
                myLin.kPr[kLineProj] = kSel + 1;
                if (kLineProj == 1)
                {
                    myLin.kPr1[kLineProj] = 1;
                    myLin.kPr2[kLineProj] = myLin.kPr[kLineProj];
                }
                if (kLineProj > 1)
                {
                    myLin.kPr1[kLineProj] = myLin.kPr2[kLineProj - 1] + 1;
                    myLin.kPr2[kLineProj] = myLin.kPr2[kLineProj - 1] + myLin.kPr[kLineProj];
                }
                myLin.kLineProj = kLineProj;
                myLin.KeepProjLine();
                iProjDraw = 1;
                kSel = -1;
                kRcPnt = 0;
                nProcess = 0;
                kAdd = 0;
                listBox1.Items.Clear();
                textBox4.Text = "";
                if (File.Exists(myLin.ftopoProj))
                    File.Delete(myLin.ftopoProj);
                kTopoProj = 0;
                if (File.Exists(myLin.fpolyProj))
                    File.Delete(myLin.fpolyProj);
                kPolyProj = 0;
                if (File.Exists(myLin.fnodeProj))
                    File.Delete(myLin.fnodeProj);
                kNodeProj = 0;
                panel7.Invalidate();
            }
        }

        private void LinearTopology_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myLin.flineProj))
            {
                int num = (int)MessageBox.Show("Проектные линии не были построены ", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                kSel = -1;
            }
            else
            {
                myLin.LineProjLoad();
                kLineProj = myLin.kLineProj;
                nProcess = 140;
                nControl = 0;
                kSel = -1;
                kRcPnt = 0;
                kAdd = -1;
                if (kPntProj > -1)
                {
                    for (int index = 0; index <= kPntProj; ++index)
                    {
                        ++kAdd;
                        myLin.xAdd[kAdd] = myLin.xProj[index];
                        myLin.yAdd[kAdd] = myLin.yProj[index];
                    }
                }
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    ++kAdd;
                    myLin.xAdd[kAdd] = myLin.xPnt[index];
                    myLin.yAdd[kAdd] = myLin.yPnt[index];
                }
                int kLine2 = 0;
                DllClass1.LineTopoline(tolerance, kAdd, ref myLin.xAdd, ref myLin.yAdd, ref kLineProj, ref myLin.RadProj, ref myLin.kPr1, ref myLin.kPr2, ref myLin.xLinProj, ref myLin.yLinProj, out kLine2, ref myLin.pWork, ref myLin.nWork1, ref myLin.nWork2, ref myLin.xWork1, ref myLin.yWork1, ref myLin.nWork, ref myLin.nDop3, ref myLin.xWork, ref myLin.yWork, ref myLin.zWork, panel1);
                if (kLine2 < 1)
                    return;
                int knd = 0;
                panel1.Text = "Пожалуйста подождите....Построение узловой топологии";
                DllClass1.NodeTopology(tolerance, kAdd, ref myLin.xAdd, ref myLin.yAdd, kLine2, ref myLin.nWork1, ref myLin.nWork2, ref myLin.xWork1, ref myLin.yWork1, out kNodeProj, ref myLin.xNodeProj, ref myLin.yNodeProj, ref myLin.nWork, ref myLin.xDop, ref myLin.yDop, out knd, ref myLin.xPik, ref myLin.yPik, panel1);
                if (File.Exists(myLin.fnodeProj))
                    File.Delete(myLin.fnodeProj);
                FileStream output = new FileStream(myLin.fnodeProj, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(kNodeProj);
                if (kNodeProj > 0)
                {
                    for (int index = 1; index <= kNodeProj; ++index)
                    {
                        binaryWriter.Write(myLin.xNodeProj[index]);
                        binaryWriter.Write(myLin.yNodeProj[index]);
                    }
                }
                binaryWriter.Close();
                output.Close();
                int kNew1 = 0;
                panel1.Text = "Пожалуйста подождите....Построение линейной топологии ";
                DllClass1.LineDivide(kLine2, ref myLin.pWork, ref myLin.nWork1, ref myLin.nWork2, ref myLin.xWork1, ref myLin.yWork1, knd, ref myLin.xPik, ref myLin.yPik, out kNew1, ref myLin.RadTopo, ref myLin.kPrt1, ref myLin.kPrt2, ref myLin.kPrt, ref myLin.xLinTopo, ref myLin.yLinTopo, tolerance, panel1);
                if (kNew1 < 1)
                    return;
                int kNew2 = 0;
                panel1.Text = "Пожалуйста подождите....Проверка двойных линий";
                DllClass1.RemoveDoubleLine(tolerance, ref kNew1, ref myLin.RadTopo, ref myLin.kPrt1, ref myLin.kPrt2, ref myLin.xLinTopo, ref myLin.yLinTopo, out kNew2, ref myLin.pWork, ref myLin.nWork1, ref myLin.nWork2, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop, ref myLin.nWork, ref myLin.nDop1, ref myLin.nDop2, panel1);
                kTopoProj = kNew1;
                myLin.kTopoProj = kTopoProj;
                myLin.KeepTopoProj();
                int kInter = 0;
                panel1.Text = "Пожалуйста подождите....Построение полигональной топологии";
                DllClass1.LinesToPoly(tolerance, kTopoProj, ref myLin.kPrt1, ref myLin.kPrt2, ref myLin.xLinTopo, ref myLin.yLinTopo, kNodeProj, ref myLin.xNodeProj, ref myLin.yNodeProj, out kPolyProj, ref myLin.namePoly, ref myLin.xLab, ref myLin.yLab, ref myLin.areaPol, ref myLin.areaLeg, ref myLin.nSymbPoly, ref myLin.kPol1, ref myLin.kPol2, ref myLin.xPolProj, ref myLin.yPolProj, out kInter, ref myLin.indPol, ref myLin.kn1, ref myLin.kn2, ref myLin.nWork, ref myLin.indInter, ref myLin.xWork1, ref myLin.yWork1, ref myLin.nWork1, ref myLin.nWork2, ref myLin.xWork, ref myLin.yWork, ref myLin.zWork, ref myLin.xWork2, ref myLin.yWork2, ref myLin.pWork, ref myLin.rWork, ref myLin.zDop, panel1);
                if (kPolyProj < 1)
                    return;
                myLin.kPolyProj = kPolyProj;
                myLin.KeepPolyProj();
                int kLin2 = 0;
                DllClass1.LineOpenMerge(tolerance, kTopoProj, ref myLin.kPrt1, ref myLin.kPrt2, ref myLin.xLinTopo, ref myLin.yLinTopo, out kLin2, ref myLin.nDop1, ref myLin.nDop2, ref myLin.nDop3, ref myLin.xAdd, ref myLin.yAdd, ref myLin.nWork1, ref myLin.xWork2, ref myLin.yWork2);
                if (kLin2 > 0)
                {
                    int index1 = 0;
                    if (kPolyProj == 0)
                        index1 = 0;
                    if (kPolyProj > 0)
                    {
                        index1 = myLin.kPol2[kPolyProj];
                        for (int index2 = 1; index2 <= kPolyProj; ++index2)
                        {
                            ip = myLin.kPol2[index2] - myLin.kPol1[index2] + 1;
                            myLin.nDop3[index2] = ip;
                        }
                    }
                    for (int index3 = 1; index3 <= kLin2; ++index3)
                    {
                        int num1 = myLin.nDop1[index3];
                        int num2 = myLin.nDop2[index3];
                        ip = 0;
                        for (int index4 = num1; index4 <= num2; ++index4)
                        {
                            ++ip;
                            ++index1;
                            myLin.xPolProj[index1] = myLin.xAdd[index4];
                            myLin.yPolProj[index1] = myLin.yAdd[index4];
                        }
                        ++kPolyProj;
                        myLin.nDop3[kPolyProj] = ip;
                    }
                    myLin.kPol1[1] = 1;
                    myLin.kPol2[1] = myLin.nDop3[1];
                    if (kPolyProj > 1)
                    {
                        for (int index5 = 2; index5 <= kPolyProj; ++index5)
                        {
                            myLin.kPol1[index5] = myLin.kPol2[index5 - 1] + 1;
                            myLin.kPol2[index5] = myLin.kPol2[index5 - 1] + myLin.nDop3[index5];
                        }
                    }
                    myLin.kPolyProj = kPolyProj;
                    myLin.KeepPolyProj();
                }
                myLin.PolygonLoad(ref myLin.kPolyInside);
                if (File.Exists(myLin.flineFinal))
                    File.Delete(myLin.flineFinal);
                if (File.Exists(myLin.fpolyFinal))
                    File.Delete(myLin.fpolyFinal);
                if (File.Exists(myLin.fileItems))
                    File.Delete(myLin.fileItems);
                panel1.Text = "Готов...";
                panel7.Invalidate();
            }
        }

        private void SelectRemove_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myLin.ftopoProj))
            {
                int num = (int)MessageBox.Show("Проверьте графическую модель построения линии", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                kSel = -1;
                nProcess = 130;
                nControl = 0;
                kSel = -1;
                kRcPnt = 0;
                myLin.TopoProjLoad();
                kTopoProj = myLin.kTopoProj;
                panel7.Invalidate();
            }
        }

        private void RebuildTopology_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myLin.flineProj))
            {
                int num = (int)MessageBox.Show("Графическая(проектная) линия не построена", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                kSel = -1;
            }
            else
            {
                kSel = -1;
                nProcess = 150;
                nControl = 0;
                kSel = -1;
                kRcPnt = 0;
                kTopoProj = 0;
                myLin.TopoProjLoad();
                kTopoProj = myLin.kTopoProj;
                if (kTopoProj == 0)
                {
                    int num = (int)MessageBox.Show("Линейные топографические знаки не были созданы", "Построение линейной топологии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nProcess = 0;
                }
                else
                {
                    kNodeProj = 0;
                    myLin.NodeProjLoad();
                    kNodeProj = myLin.kNodeProj;
                    int kNew = 0;
                    panel1.Text = "Пожалуйста подождите....Проверка двойных линий";
                    DllClass1.RemoveDoubleLine(tolerance, ref kTopoProj, ref myLin.rWork, ref myLin.kPrt1, ref myLin.kPrt2, ref myLin.xLinTopo, ref myLin.yLinTopo, out kNew, ref myLin.pWork, ref myLin.nWork1, ref myLin.nWork2, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop, ref myLin.nWork, ref myLin.nDop1, ref myLin.nDop2, panel1);
                    int kInter = 0;
                    panel1.Text = "Пожалуйста подождите....Построение полигональных топографических знаков";
                    DllClass1.LinesToPoly(tolerance, kTopoProj, ref myLin.kPrt1, ref myLin.kPrt2, ref myLin.xLinTopo, ref myLin.yLinTopo, kNodeProj, ref myLin.xNodeProj, ref myLin.yNodeProj, out kPolyProj, ref myLin.namePoly, ref myLin.xLab, ref myLin.yLab, ref myLin.areaPol, ref myLin.areaLeg, ref myLin.nSymbPoly, ref myLin.kPol1, ref myLin.kPol2, ref myLin.xPolProj, ref myLin.yPolProj, out kInter, ref myLin.indPol, ref myLin.kn1, ref myLin.kn2, ref myLin.nWork, ref myLin.indInter, ref myLin.xWork1, ref myLin.yWork1, ref myLin.nWork1, ref myLin.nWork2, ref myLin.xWork, ref myLin.yWork, ref myLin.zWork, ref myLin.xWork2, ref myLin.yWork2, ref myLin.pWork, ref myLin.rWork, ref myLin.zDop, panel1);
                    if (kPolyProj < 1)
                        return;
                    myLin.kPolyProj = kPolyProj;
                    myLin.KeepPolyProj();
                    int kLin2 = 0;
                    DllClass1.LineOpenMerge(tolerance, kTopoProj, ref myLin.kPrt1, ref myLin.kPrt2, ref myLin.xLinTopo, ref myLin.yLinTopo, out kLin2, ref myLin.nDop1, ref myLin.nDop2, ref myLin.nDop3, ref myLin.xAdd, ref myLin.yAdd, ref myLin.nWork1, ref myLin.xWork2, ref myLin.yWork2);
                    if (kLin2 > 0)
                    {
                        int index1 = 0;
                        if (kPolyProj == 0)
                            index1 = 0;
                        if (kPolyProj > 0)
                        {
                            index1 = myLin.kPol2[kPolyProj];
                            for (int index2 = 1; index2 <= kPolyProj; ++index2)
                            {
                                ip = myLin.kPol2[index2] - myLin.kPol1[index2] + 1;
                                myLin.nDop3[index2] = ip;
                            }
                        }
                        for (int index3 = 1; index3 <= kLin2; ++index3)
                        {
                            int num1 = myLin.nDop1[index3];
                            int num2 = myLin.nDop2[index3];
                            ip = 0;
                            for (int index4 = num1; index4 <= num2; ++index4)
                            {
                                ++ip;
                                ++index1;
                                myLin.xPolProj[index1] = myLin.xAdd[index4];
                                myLin.yPolProj[index1] = myLin.yAdd[index4];
                            }
                            ++kPolyProj;
                            myLin.nDop3[kPolyProj] = ip;
                        }
                        myLin.kPol1[1] = 1;
                        myLin.kPol2[1] = myLin.nDop3[1];
                        if (kPolyProj > 1)
                        {
                            for (int index5 = 2; index5 <= kPolyProj; ++index5)
                            {
                                myLin.kPol1[index5] = myLin.kPol2[index5 - 1] + 1;
                                myLin.kPol2[index5] = myLin.kPol2[index5 - 1] + myLin.nDop3[index5];
                            }
                        }
                        myLin.kPolyProj = kPolyProj;
                        myLin.KeepPolyProj();
                    }
                    myLin.PolygonLoad(ref myLin.kPolyInside);
                    if (File.Exists(myLin.flineFinal))
                        File.Delete(myLin.flineFinal);
                    if (File.Exists(myLin.fpolyFinal))
                        File.Delete(myLin.fpolyFinal);
                    if (File.Exists(myLin.fileItems))
                        File.Delete(myLin.fileItems);
                    panel1.Text = "Готов...";
                    panel7.Invalidate();
                }
            }
        }

        private void PointsOnnOff_Click(object sender, EventArgs e)
        {
            iPointDraw = iPointDraw <= 0 ? 1 : 0;
            panel7.Invalidate();
        }

        private void ProjectOnOff_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myLin.flineProj))
            {
                int num = (int)MessageBox.Show("Проектируемые линии не построены", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                kSel = -1;
            }
            else
            {
                iProjDraw = iProjDraw <= 0 ? 1 : 0;
                panel7.Invalidate();
            }
        }

        private void TopologyOnOff_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myLin.ftopoProj))
            {
                int num = (int)MessageBox.Show("Проектируемые линии не построены", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                kSel = -1;
            }
            else
            {
                iProjTopo = iProjTopo <= 0 ? 1 : 0;
                panel7.Invalidate();
            }
        }

        private void SourceLinesOnOff_Click(object sender, EventArgs e)
        {
            iLineActDraw = iLineActDraw <= 0 ? 1 : 0;
            panel7.Invalidate();
        }

        private void SourceNodeOnOff_Click(object sender, EventArgs e)
        {
            iNodeActDraw = iNodeActDraw <= 0 ? 1 : 0;
            panel7.Invalidate();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (File.Exists(myLin.flineProj) && !File.Exists(myLin.ftopoProj) && 
                MessageBox.Show("Линейные топографические знаки не были созданы. Вы действительно хотите выйти из программы ?", "Построение линий", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                kSel = -1;
            else
                Form.ActiveForm.Close();
        }

        private void DrawPicture(int nProcess)
        {
            int pixHei = this.pixHei;
            if (nProcess == 510)
                pictureBox1.Visible = true;
            else
                pictureBox1.Visible = false;
            if (nProcess == 520)
                pictureBox2.Visible = true;
            else
                pictureBox2.Visible = false;
            if (nProcess == 530)
                pictureBox3.Visible = true;
            else
                pictureBox3.Visible = false;
            if (nProcess == 540)
                pictureBox4.Visible = true;
            else
                pictureBox4.Visible = false;
            if (nProcess == 550)
                pictureBox5.Visible = true;
            else
                pictureBox5.Visible = false;
            if (nProcess == 560)
                pictureBox6.Visible = true;
            else
                pictureBox6.Visible = false;
            if (nProcess == 570)
                pictureBox7.Visible = true;
            else
                pictureBox7.Visible = false;
            if (nProcess == 590)
                pictureBox8.Visible = true;
            else
                pictureBox8.Visible = false;
            if (nProcess == 610)
                pictureBox9.Visible = true;
            else
                pictureBox9.Visible = false;
            if (nProcess == 620)
                pictureBox10.Visible = true;
            else
                pictureBox10.Visible = false;
            if (nProcess == 630)
                pictureBox11.Visible = true;
            else
                pictureBox11.Visible = false;
            if (nProcess == 640)
                pictureBox12.Visible = true;
            else
                pictureBox12.Visible = false;
            if (nProcess == 54)
                pictureBox13.Visible = true;
            else
                pictureBox13.Visible = false;
            if (nProcess == 58)
                pictureBox14.Visible = true;
            else
                pictureBox14.Visible = false;
            if (nProcess == 55)
                pictureBox15.Visible = true;
            else
                pictureBox15.Visible = false;
            if (nProcess == 59)
                pictureBox16.Visible = true;
            else
                pictureBox16.Visible = false;
            if (nProcess == 56)
                pictureBox17.Visible = true;
            else
                pictureBox17.Visible = false;
            if (nProcess == 57)
                pictureBox18.Visible = true;
            else
                pictureBox18.Visible = false;
            if (nProcess == 62)
                pictureBox19.Visible = true;
            else
                pictureBox19.Visible = false;
            if (nProcess == 700 && iImageShow > 0)
                pictureBox20.Visible = true;
            if (nProcess == 700 && iImageShow == 0)
                pictureBox20.Visible = false;
            if (iImageShow == 0)
                return;
            if (nProcess == 510 && iImageShow > 0)
                pictureBox1.Location = new Point(0, pixHei - pictureBox1.Height);
            if (nProcess == 520 && iImageShow > 0)
                pictureBox2.Location = new Point(0, pixHei - pictureBox2.Height);
            if (nProcess == 530 && iImageShow > 0)
                pictureBox3.Location = new Point(0, pixHei - pictureBox3.Height);
            if (nProcess == 540 && iImageShow > 0)
                pictureBox4.Location = new Point(0, pixHei - pictureBox4.Height);
            if (nProcess == 550 && iImageShow > 0)
                pictureBox5.Location = new Point(0, pixHei - pictureBox5.Height);
            if (nProcess == 560 && iImageShow > 0)
                pictureBox6.Location = new Point(0, pixHei - pictureBox6.Height);
            if (nProcess == 570 && iImageShow > 0)
                pictureBox7.Location = new Point(0, pixHei - pictureBox7.Height);
            if (nProcess == 590 && iImageShow > 0)
                pictureBox8.Location = new Point(0, pixHei - pictureBox8.Height);
            if (nProcess == 610 && iImageShow > 0)
                pictureBox9.Location = new Point(0, pixHei - pictureBox9.Height);
            if (nProcess == 620 && iImageShow > 0)
                pictureBox10.Location = new Point(0, pixHei - pictureBox10.Height);
            if (nProcess == 630 && iImageShow > 0)
                pictureBox11.Location = new Point(0, pixHei - pictureBox11.Height);
            if (nProcess == 640 && iImageShow > 0)
                pictureBox12.Location = new Point(0, pixHei - pictureBox12.Height);
            if (nProcess == 54 && iImageShow > 0)
                pictureBox13.Location = new Point(0, pixHei - pictureBox13.Height);
            if (nProcess == 58 && iImageShow > 0)
                pictureBox14.Location = new Point(0, pixHei - pictureBox14.Height);
            if (nProcess == 55 && iImageShow > 0)
                pictureBox15.Location = new Point(0, pixHei - pictureBox15.Height);
            if (nProcess == 59 && iImageShow > 0)
                pictureBox16.Location = new Point(0, pixHei - pictureBox16.Height);
            if (nProcess == 56 && iImageShow > 0)
                pictureBox17.Location = new Point(0, pixHei - pictureBox17.Height);
            if (nProcess == 57 && iImageShow > 0)
                pictureBox18.Location = new Point(0, pixHei - pictureBox18.Height);
            if (nProcess == 62 && iImageShow > 0)
                pictureBox19.Location = new Point(0, pixHei - pictureBox19.Height);
            if (nProcess != 700 || iImageShow <= 0)
                return;
            pictureBox20.Location = new Point(0, 0);
        }

        private void AllTypeLines_Click(object sender, EventArgs e)
        {
            nProcess = 700;
            iImageShow = iImageShow != 1 ? 1 : 0;
            nControl = 0;
            if (nProcess == 700 && iImageShow > 0)
                pictureBox20.Location = new Point(0, 0);
            panel7.Invalidate();
        }




    }
}
