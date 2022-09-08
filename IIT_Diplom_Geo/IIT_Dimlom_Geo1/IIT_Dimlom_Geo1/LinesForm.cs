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
    public partial class LinesForm : Form
    {
        private string sTmp1 = "";
        private string sTmp2 = "";
        private string sForm = "";
        private string pForm = "";
        private int iWidth;
        private int iHeight;
        private int kPntInput;
        private int kPntPlus;
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
        private int iCodeLine;
        private int iLong;
        private int iRadio;
        private int indLine;
        private int indSide;
        private int kAdd;
        private int kSymbPnt;
        private int kSymbLine;
        private int iPointShow = 1;
        private int iLineShow = 1;
        private int iSymbolShow;
        private int kItemCoord;
        private int iImageShow;
        private int nFillet;
        private int iPointSymbol;
        private int iContShow;
        private int kPntSource;
        private int nVertex = 5000;
        private int hSymbLine = 18;
        private int kPolySymb;
        private int hSymbPoly;
        private int kLineInput;
        private int iHeightShow;
        private double tolerance = 0.003;
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
        private double rRad;
        private double pRad;
        private double sWidth;
        private double sMillim;
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
        private string[] nameArc = new string[10];
        private double[] xArc = new double[10];
        private double[] yArc = new double[10];
        private double[] zArc = new double[10];
        private double[] xAll = new double[10];
        private double[] yAll = new double[10];
        private int kPntFin;
        private int iCond;
        private int iGraphic;
        private Rectangle RcDraw;
        private Rectangle RcBox;
        private Rectangle[] RcPnt = new Rectangle[200];
        private MyGeodesy myLin = new MyGeodesy();
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

        public string fCurPnt { get; private set; }
        public string fCurHeig { get; private set; }
        public string fCurLine { get; private set; }

        public LinesForm()
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
            button29.MouseHover += new EventHandler(button29_MouseHover);
            button29.MouseLeave += new EventHandler(button1_MouseLeave);
            button30.MouseHover += new EventHandler(button30_MouseHover);
            button30.MouseLeave += new EventHandler(button1_MouseLeave);
            button31.MouseHover += new EventHandler(button31_MouseHover);
            button31.MouseLeave += new EventHandler(button1_MouseLeave);
            button34.MouseHover += new EventHandler(button34_MouseHover);
            button34.MouseLeave += new EventHandler(button1_MouseLeave);
            DrawPicture(nProcess);
            pictureBox20.Visible = false;
            myLin.FilePath();
            FormLoad();
        }

        private void button1_MouseHover(object sender, EventArgs e) => label5.Text = "Закрыть окно";

        private void button1_MouseLeave(object sender, EventArgs e) => label5.Text = "";

        private void button2_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Зажмите левую кнопкой мыши и переместите мышь. После выбора области отпустите кнопку. Нажмите правую кнопку мыши для исходного положения";

        private void button3_MouseHover(object sender, EventArgs e) => label5.Text = "После нажатия этой кнопки кликните левой кнопкой возле точки, которую хотите приблизить. Кликните правой кнопкой мыши для исходного положения ";

        private void button4_MouseHover(object sender, EventArgs e) => label5.Text = "После нажатия этой кнопки кликните по области которую хотите отдалить. Нажмите правую кнопку для исходного положения";

        private void button5_MouseHover(object sender, EventArgs e) => label5.Text = "После нажатия на эту кнопку, кликните правой кнопкой мыши по области экрана с графикой и передвигайте для смещения экрана. Нажмите правую кнопку для возврата исходное положение";

        private void button6_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Выдилите левой кнопкой точку для построения линии. Нажмите правую кнопку после завершения выбора";

        private void button9_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Выделите правой кнопкой мыши 2 точки следуя против часовй стрелки и задайте радиус для построения короткой окружности (дуги)";

        private void button10_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Выдилите правой кнопкой мыши 2 точки следуя против часовй стрелки и задайте радиус для построения длинной окружности.";

        private void button11_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. С помощб. левой кнопки мыши выделите 3 точки для построения окружности.";

        private void button12_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. С помощью правой кнопки мыши выделите 3 точки для построения круга .";

        private void button13_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. С помощью правой кнопки мыши выдиллите 1 точку как центр и введите радиус для построения круга.";

        private void button14_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. с помощью првавой кнопки мыши выделить 2 точки для построения кривой. Нажмите правую кнопку после выбора";

        private void button15_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите линию и установите расстояние между ними и парралельно линии ";

        private void button16_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите линию";

        private void button18_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите линию и после нее точку";

        private void button19_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите линию ближе к концу, которую необходимо удлинить";

        private void button20_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две окружности, или окружность и дугу, или две дуги";

        private void button21_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две окружности, или окружность и дугу, или две дуги";

        private void button22_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две линии ближе к концам, где будет создаваться тупик (замкнытая линия)";

        private void button23_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две линии для построения прямой короткой дуги.";

        private void button24_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две линии для построения обратной короткой дуги.";

        private void button25_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две линии для построения прямой длинной дуги.";

        private void button26_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите две линии для построения обратной длинной дуги.";

        private void button27_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите 2 линии и установите Радиус для построения Прямых окружностей, к которым эти линии касаются";

        private void button28_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите 2 линии и установите Радиус для построения Обратной Дуги, к которой линии касаются";

        private void button29_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите 2 линии и задайте длину биссектрисы для построения дуги, к которой касаются линии";

        private void button30_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите линию";

        private void button31_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. Левой кнопкой мыши выберите линию";

        private void button34_MouseHover(object sender, EventArgs e) => label5.Text = "Нажмите кнопку. В списке символов выберите подходящий и нажмите 'Сохранить'.";

        private void FormLoad()
        {
            xmin = 9999999.9;
            ymin = 9999999.9;
            zmin = 9999999.9;
            xmax = -9999999.9;
            ymax = -9999999.9;
            zmax = -9999999.9;
            DllClass1.SetColour(myLin.brColor, myLin.pnColor);
            DllClass1.PointSymbLoad(myLin.fsymbPnt, out kSymbPnt, 
                myLin.numRec, myLin.numbUser, myLin.heiSymb);
            myLin.kSymbPnt = kSymbPnt;
            DllClass1.LineSymbolLoad(myLin.fsymbLine, out kSymbLine, 
                out hSymbLine, myLin.sSymbLine, myLin.x1Line, 
                myLin.y1Line, myLin.x2Line, myLin.y2Line, myLin.xDescr, 
                myLin.yDescr, myLin.x1Dens, myLin.y1Dens, myLin.x1Sign, 
                myLin.y1Sign, myLin.x2Sign, myLin.y2Sign, myLin.n1Sign, 
                myLin.n2Sign, myLin.iStyle1, myLin.iStyle2, myLin.iWidth1, 
                myLin.iWidth2, myLin.nColLine, myLin.nItem, myLin.itemLoc, 
                myLin.nBaseSymb, myLin.sInscr, myLin.hInscr, myLin.iColInscr, myLin.iDensity);
            myLin.PolySymbolLoad(myLin.fsymbPoly, out kPolySymb, out hSymbPoly);
            //myLin.PointLoad(fCurPnt, fCurHeig);
            myLin.PointLoad();
            kPntPlus = myLin.kPntPlus;
            kPntInput = myLin.kPntInput;
            xmin = myLin.xmin;
            ymin = myLin.ymin;
            xmax = myLin.xmax;
            ymax = myLin.ymax;
            zmin = myLin.zmin;
            zmax = myLin.zmax;
            kPntFin = 0;
            myLin.PointLoadFin();
            kPntFin = myLin.kPntFin;
            if (kPntPlus > 0)
            {
                if (File.Exists(myLin.fpointInscr))
                    File.Delete(myLin.fpointInscr);
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
                myLin.LoadKeepInscr(2);
            }
            myLin.LoadPntSour();
            kPntSource = myLin.kPntSource;
            if (kPntFin > 0)
                myLin.InscriptionFin(1);
            kLineInput = 0;
            myLin.LineLoad();
            kLineInput = myLin.kLineInput;
            xmin = myLin.xmin;
            ymin = myLin.ymin;
            xmax = myLin.xmax;
            ymax = myLin.ymax;
            xminCur = xmin;
            yminCur = ymin;
            xmaxCur = xmax;
            ymaxCur = ymax;
            DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, 
                out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, 
                out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (kSymbLine <= 0)
                return;
            DllClass1.LineItemCoor(myLin.fitemLine, myLin.nColorItm, myLin.ixSqu, 
                myLin.iySqu, kLineInput, myLin.rRadLine, myLin.k1, myLin.k2,
                myLin.xLin, myLin.yLin, myLin.nLineCode, kSymbLine, myLin.nItem,
                myLin.n1Sign, myLin.n2Sign, myLin.iDensity, out kItemCoord, myLin.numSign, 
                myLin.numItem, myLin.xItem, myLin.yItem, myLin.azItem, myLin.xAdd, myLin.yAdd,
                myLin.xDop, myLin.yDop, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, scaleToGeo);
            if (kItemCoord <= 0)
                return;
            myLin.kItemCoord = kItemCoord;
            myLin.ItemLoadKeep(2);
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
            if (kPntPlus > 0 && kPntFin == 0 && iPointShow > 0)
                DllClass1.PointsDraw(e, myLin.fsymbPnt, iHeightShow, kPntPlus, myLin.namePnt, myLin.xPnt, myLin.yPnt, myLin.zPnt, myLin.xPntInscr,
                    myLin.yPntInscr, myLin.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myLin.nCode1, myLin.nCode2, kSymbPnt, myLin.numRec,
                    myLin.numbUser, myLin.ixSqu, myLin.iySqu, myLin.nColor, myLin.brColor, myLin.pnColor);
            if (kPntPlus > 0 && kPntFin == 0 && iPointShow == 0)
                DrawPoint(e, kPntPlus, myLin.xPnt, myLin.yPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            if (kPntFin > 0 && iPointShow > 0)
                DllClass1.PointsDraw(e, myLin.fpointFinal, iHeightShow, kPntFin, myLin.namePntFin, myLin.xPntFin, myLin.yPntFin, myLin.zPntFin, 
                    myLin.xPntInscr, myLin.yPntInscr, myLin.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myLin.nCode1Fin, myLin.nCode2Fin, 
                    kSymbPnt, myLin.numRec, myLin.numbUser, myLin.ixSqu, myLin.iySqu, myLin.nColor, myLin.brColor, myLin.pnColor);
            if (kPntFin > 0 && iPointShow == 0)
                DrawPoint(e, kPntFin, myLin.xPntFin, myLin.yPntFin, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            if (kLineInput > 0 && iSymbolShow > 0)
            {
                DllClass1.DrawInputLine(e, kLineInput, myLin.k1, myLin.k2, myLin.xLin, myLin.yLin, myLin.nLineCode, myLin.dstLine, myLin.rRadLine,
                    myLin.xRadLine, myLin.yRadLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myLin.nColLine, myLin.iWidth1, myLin.iWidth2, myLin.iStyle1,
                    myLin.iStyle2, myLin.nBaseSymb, myLin.xAdd, myLin.yAdd, myLin.xDop, myLin.yDop, myLin.xWork, myLin.yWork, kSymbLine, myLin.n1Sign, myLin.n2Sign,
                    myLin.brColor, myLin.pnColor, 0);
                if (kItemCoord > 0)
                    DllClass1.InputItemDraw(e, myLin.fitemLine, kItemCoord, myLin.numSign, myLin.numItem, myLin.xItem, myLin.yItem, myLin.azItem, myLin.itemLoc,
                        myLin.nBaseSymb, myLin.sInscr, myLin.hInscr, myLin.iColInscr, kSymbLine, myLin.ixSqu, myLin.iySqu, myLin.nColorItm, scaleToWin, xBegX, yBegY,
                        xBegWin, yBegWin, myLin.nDop1, myLin.nDop2, myLin.brColor);
            }
            if (kLineInput > 0 && iLineShow > 0)
            {
                int iPar = 1;
                DllClass1.LineDraw(e, kLineInput, myLin.k1, myLin.k2, myLin.xLin, myLin.yLin, myLin.rRadLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myLin.pnColor, iPar);
            }
            if (File.Exists(myLin.fileContour) && iContShow > 0)
                DllClass1.ContourDraw(e, myLin.fileContour, myLin.xDop, myLin.yDop, myLin.xOut, myLin.yOut, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            if (nProcess != 510)
            {
                if (kRcPnt > 0)
                {
                    for (int index = 1; index <= kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Magenta), RcPnt[index]);
                }
                DllClass1.DrawSelLine(e, kSel, ref myLin.xWork, ref myLin.yWork, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                DrawPicture(nProcess);
            }
            if (nProcess == 510)
            {
                if (kRcPnt > 0)
                {
                    for (int index = 1; index <= kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Magenta), RcPnt[index]);
                }
                DllClass1.DrawSelLine(e, kSel, ref myLin.xWork, ref myLin.yWork, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                if (iImageShow > 0)
                    DrawPicture(nProcess);
            }
            Cursor.Current = Cursors.Default;
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
                                int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        textBox1.Text = "1";
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
                            myLin.zPik[index] = myLin.zWork[index];
                        }
                        int k = 0;
                        DllClass1.Line_Spl(kSel, ref myLin.xPik, ref myLin.yPik, out k, 
                            ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop, nVertex);
                        if (k < 2)
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
                            myLin.zWork[index1] = myLin.zPik[ip];
                        }
                        textBox1.Text = "1";
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
                rr = 9999999.9;
                ip = -1;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - xCur;
                    dy = myLin.yPnt[index] - yCur;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        ip = index;
                        rr = ss;
                    }
                }
                if (ip > -1)
                {
                    ++kSel;
                    myLin.nameWork[kSel] = myLin.namePnt[ip];
                    myLin.xWork[kSel] = myLin.xPnt[ip];
                    myLin.yWork[kSel] = myLin.yPnt[ip];
                    myLin.zWork[kSel] = myLin.zPnt[ip];
                    listBox1.Items.Add((object)myLin.namePnt[ip]);
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
                sTmp2 = "";
                DllClass1.FormCreate(0, out iRadio, out rRad, out pRad, out sForm, out pForm, sTmp1, sTmp2);
                rr = 2.0 * rRad - ss;
                if (rr < 0.1)
                {
                    int num = (int)MessageBox.Show("Увеличить радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    listBox1.Items.Clear();
                    return;
                }
                textBox1.Text = "1";
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
                textBox1.Text = "1";
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
                textBox1.Text = "1";
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
                textBox1.Text = "1";
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
                textBox1.Text = "1";
                textBox4.Text = "0";
            }
            if (nProcess == 600 || nProcess == 610 || nProcess == 650 || nProcess == 660)
            {
                DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
                kSel = 0;
                xArc[0] = xCur;
                yArc[0] = yCur;
                ++kRcPnt;
                RcPnt[kRcPnt].X = e.X;
                RcPnt[kRcPnt].Y = e.Y;
                textBox1.Text = "1";
                textBox4.Text = "0";
                if (nProcess == 600)
                    textBox4.ReadOnly = true;
            }
            if (kSel <= 0 || nProcess != 510)
                return;
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

        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
            double xh = 0.0;
            double yh = 0.0;
            double xk = 0.0;
            double yk = 0.0;
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
                    DllClass1.CoorWin(xCurMin, yCurMin, xCurMax, 
                        yCurMax, iWidth, iHeight, out scaleToWin, 
                        out scaleToGeo, out xBegX, out yBegY, out xEndX, 
                        out yEndY, out xBegWin, out yBegWin, out xEndWin, 
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
            }
            if (nControl == 40)
            {
                xminCur = xaCur;
                yminCur = yaCur;
                xmaxCur = xbCur;
                ymaxCur = ybCur;
            }
            if (nProcess == 570 || nProcess == 580 || nProcess == 590 || 
                nProcess == 600 || nProcess == 610 || nProcess == 620 || 
                nProcess == 630 || nProcess == 640 || nProcess == 54 || 
                nProcess == 55 || nProcess == 56 || nProcess == 57 || 
                nProcess == 58 || nProcess == 59 || nProcess == 62 || 
                nProcess == 650 || nProcess == 660 || nProcess == 510)
            {
                RcPnt[kRcPnt].Width = 3;
                RcPnt[kRcPnt].Height = 3;
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
                DllClass1.FindLine(xArc[0], yArc[0], kLineInput, ref myLin.k1,
                    ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine,
                    ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin,
                    out rd, out xrd, out yrd, out kp, ref myLin.xPik, ref myLin.yPik,
                    ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                for (int index2 = 0; index2 <= kp; ++index2)
                {
                    ip = -1;
                    rr = 9999999.9;
                    for (int index3 = 0; index3 <= kPntPlus; ++index3)
                    {
                        dx = myLin.xPnt[index3] - myLin.xPik[index2];
                        dy = myLin.yPnt[index3] - myLin.yPik[index2];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < rr)
                        {
                            rr = ss;
                            ip = index3;
                        }
                    }
                    if (ip > -1)
                    {
                        ++index1;
                        myLin.nameDop[index1] = myLin.namePnt[ip];
                        myLin.xDop[index1] = myLin.xPnt[ip];
                        myLin.yDop[index1] = myLin.yPnt[ip];
                        myLin.zDop[index1] = myLin.zPnt[ip];
                    }
                }
                sTmp1 = "";
                sTmp2 = "";
                DllClass1.FormCreate(2, out iRadio, out this.rRad, 
                    out pRad, out sForm, out pForm, sTmp1, sTmp2);
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
                    for (int index4 = 0; index4 <= kSel; ++index4)
                    {
                        myLin.nameWork[index4] = "lin";
                        myLin.zWork[index4] = 0.0;
                    }
                    for (int index5 = 1; index5 <= index1; ++index5)
                    {
                        rr = 9999999.9;
                        ip = -1;
                        for (int index6 = 0; index6 <= kSel; ++index6)
                        {
                            dx = myLin.xDop[index5] - myLin.xWork[index6];
                            dy = myLin.yDop[index5] - myLin.yWork[index6];
                            ss = Math.Sqrt(dx * dx + dy * dy);
                            if (ss < rr)
                            {
                                rr = ss;
                                ip = index6;
                            }
                        }
                        int nName = 0;
                        DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                        myLin.nameWork[ip] = sTmp1;
                        ++kAdd;
                        myLin.nameAdd[kAdd] = sTmp1;
                        myLin.xAdd[kAdd] = myLin.xWork[ip];
                        myLin.yAdd[kAdd] = myLin.yWork[ip];
                        myLin.zAdd[kAdd] = 0.0;
                        ++kPntPlus;
                        myLin.namePnt[kPntPlus] = sTmp1;
                        myLin.xPnt[kPntPlus] = myLin.xWork[ip];
                        myLin.yPnt[kPntPlus] = myLin.yWork[ip];
                        myLin.zPnt[kPntPlus] = 0.0;
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
                    for (int index7 = 0; index7 <= kSel; ++index7)
                    {
                        myLin.nameWork[index7] = "rad";
                        myLin.zWork[index7] = 0.0;
                    }
                    int nName = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                    myLin.nameWork[ip] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[0];
                    myLin.yAdd[kAdd] = myLin.yWork[0];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntPlus;
                    myLin.namePnt[kPntPlus] = sTmp1;
                    myLin.xPnt[kPntPlus] = myLin.xWork[0];
                    myLin.yPnt[kPntPlus] = myLin.yWork[0];
                    myLin.zPnt[kPntPlus] = 0.0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp2);
                    myLin.nameWork[ip] = sTmp2;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp2;
                    myLin.xAdd[kAdd] = myLin.xWork[kSel];
                    myLin.yAdd[kAdd] = myLin.yWork[kSel];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntPlus;
                    myLin.namePnt[kPntPlus] = sTmp2;
                    myLin.xPnt[kPntPlus] = myLin.xWork[kSel];
                    myLin.yPnt[kPntPlus] = myLin.yWork[kSel];
                    myLin.zPnt[kPntPlus] = 0.0;
                }
                textBox1.Text = "1";
                textBox4.Text = "0";
                if (rRad > 0.0)
                {
                    sTmp1 = string.Format("{0:F2}", (object)rRad);
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
                DllClass1.FindLine(xArc[0], yArc[0], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, out rd, out xrd, out yrd, out kp, ref myLin.xPik, ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                rr = 9999999.9;
                ip = -1;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - xArc[1];
                    dy = myLin.yPnt[index] - yArc[1];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        ip = index;
                    }
                }
                DllClass1.PerpToLine(myLin.xPnt[ip], myLin.yPnt[ip], kp, ref myLin.xPik, ref myLin.yPik, out xCur, out yCur, out az, out indSide);
                if (indSide < 1)
                    return;
                kSel = 1;
                myLin.nameWork[0] = myLin.namePnt[ip];
                myLin.xWork[0] = myLin.xPnt[ip];
                myLin.yWork[0] = myLin.yPnt[ip];
                myLin.zWork[0] = myLin.zPnt[ip];
                int nName = 0;
                DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                myLin.nameWork[1] = sTmp1;
                myLin.xWork[1] = xCur;
                myLin.yWork[1] = yCur;
                myLin.zWork[1] = 0.0;
                ip = -1;
                rr = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - xCur;
                    dy = myLin.yPnt[index] - yCur;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        ip = index;
                    }
                }
                if (rr < tolerance)
                {
                    myLin.nameWork[1] = myLin.namePnt[ip];
                    myLin.xWork[1] = myLin.xPnt[ip];
                    myLin.yWork[1] = myLin.yPnt[ip];
                    myLin.zWork[1] = myLin.zPnt[ip];
                }
                if (rr >= tolerance)
                {
                    ++kPntPlus;
                    myLin.namePnt[kPntPlus] = sTmp1;
                    myLin.xPnt[kPntPlus] = xCur;
                    myLin.yPnt[kPntPlus] = yCur;
                    myLin.zPnt[kPntPlus] = 0.0;
                }
                textBox1.Text = "1";
                textBox4.Text = "0";
                panel7.Invalidate();
            }
            if (nProcess == 600 && kSel == 0)
            {
                double az = 0.0;
                double num5;
                double yrd = num5 = 0.0;
                double xrd = num5;
                double rd = num5;
                DllClass1.FindLine(xArc[0], yArc[0], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, out rd, out xrd, out yrd, out kSel, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
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
                if (kLineInput == 1)
                {
                    if (File.Exists(myLin.fileLine))
                        File.Delete(myLin.fileLine);
                    kSel = -1;
                    kAdd = 0;
                    kRcPnt = 0;
                    kLineInput = 0;
                    panel7.Invalidate();
                    return;
                }
                if (kPntPlus > kPntInput)
                {
                    int index8 = 0;
                    for (int index9 = 0; index9 <= kSel; ++index9)
                    {
                        rr = 9999999.9;
                        ip = -1;
                        for (int index10 = kPntInput + 1; index10 <= kPntPlus; ++index10)
                        {
                            dx = myLin.xPnt[index10] - myLin.xWork[index9];
                            dy = myLin.yPnt[index10] - myLin.yWork[index9];
                            ss = Math.Sqrt(dx * dx + dy * dy);
                            if (ss <= 0.1 && ss < rr)
                            {
                                rr = ss;
                                ip = index10;
                            }
                        }
                        if (ip >= 0)
                        {
                            ++index8;
                            myLin.nameDop[index8] = myLin.namePnt[ip];
                        }
                    }
                    if (index8 > 0)
                    {
                        for (int index11 = 1; index11 <= index8; ++index11)
                        {
                            int num6 = -1;
                            for (int index12 = 0; index12 <= kPntPlus; ++index12)
                            {
                                if (myLin.nameDop[index11] == myLin.namePnt[index12])
                                {
                                    num6 = index12;
                                    break;
                                }
                            }
                            if (num6 >= 0)
                            {
                                ip = -1;
                                for (int index13 = 0; index13 <= kPntPlus; ++index13)
                                {
                                    if (index13 != num6)
                                    {
                                        ++ip;
                                        myLin.namePnt[ip] = myLin.namePnt[index13];
                                        myLin.xPnt[ip] = myLin.xPnt[index13];
                                        myLin.yPnt[ip] = myLin.yPnt[index13];
                                        myLin.zPnt[ip] = myLin.zPnt[index13];
                                        myLin.nCode1[ip] = myLin.nCode1[index13];
                                        myLin.nCode2[ip] = myLin.nCode2[index13];
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
                DllClass1.LineDelete(indLine, ref kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.kt, ref myLin.nLineCode, ref myLin.nLongRad, ref myLin.sWidLine, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, ref myLin.zLin, out kLin, ref myLin.xPik, ref myLin.yPik, ref myLin.zPik);
                myLin.kLineInput = kLineInput;
                myLin.KeepLine();
                if (File.Exists(myLin.fileDangle))
                    File.Delete(myLin.fileDangle);
                if (File.Exists(myLin.fileNode))
                    File.Delete(myLin.fileNode);
                if (File.Exists(myLin.flineTopo))
                    File.Delete(myLin.flineTopo);
                if (File.Exists(myLin.filePoly))
                    File.Delete(myLin.filePoly);
                if (File.Exists(myLin.fileNode))
                    File.Delete(myLin.fileNode);
                DllClass1.LineItemCoor(myLin.fitemLine, myLin.nColorItm, myLin.ixSqu, myLin.iySqu, kLineInput, myLin.rRadLine, myLin.k1, myLin.k2, myLin.xLin, myLin.yLin, myLin.nLineCode, kSymbLine, myLin.nItem, myLin.n1Sign, myLin.n2Sign, myLin.iDensity, out kItemCoord, myLin.numSign, myLin.numItem, myLin.xItem, myLin.yItem, myLin.azItem, myLin.xAdd, myLin.yAdd, myLin.xDop, myLin.yDop, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, scaleToGeo);
                if (kItemCoord > 0)
                {
                    myLin.kItemCoord = kItemCoord;
                    myLin.ItemLoadKeep(2);
                }
                kSel = -1;
                kAdd = 0;
                kRcPnt = 0;
                panel7.Invalidate();
            }
            if (nProcess == 610 && kSel == 0)
            {
                double num7;
                double yrd = num7 = 0.0;
                double xrd = num7;
                double rd = num7;
                DllClass1.LengthenLine(xArc[0], yArc[0], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, out rd, out xrd, out yrd, out kSel, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur);
                textBox4.Text = string.Format("{0:F3}", (object)rd);
                if (kSel < 1)
                {
                    int num8 = (int)MessageBox.Show("Problem", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    kAdd = 0;
                    kRcPnt = 0;
                    nProcess = 0;
                    listBox1.Items.Clear();
                    panel7.Invalidate();
                    return;
                }
                rr = 9999999.9;
                int index14 = -1;
                for (int index15 = 0; index15 <= kSel; ++index15)
                {
                    dx = myLin.xWork[index15] - xCur;
                    dy = myLin.yWork[index15] - yCur;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        index14 = index15;
                    }
                }
                ip = -1;
                rr = 9999999.9;
                for (int index16 = 0; index16 <= kPntPlus; ++index16)
                {
                    dx = myLin.xPnt[index16] - xCur;
                    dy = myLin.yPnt[index16] - yCur;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        ip = index16;
                    }
                }
                if (rr < tolerance)
                {
                    myLin.nameWork[index14] = myLin.namePnt[ip];
                    myLin.xWork[index14] = myLin.xPnt[ip];
                    myLin.yWork[index14] = myLin.yPnt[ip];
                    myLin.zWork[index14] = myLin.zPnt[ip];
                }
                if (rr >= tolerance)
                {
                    int nName = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                    myLin.nameWork[index14] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[index14];
                    myLin.yAdd[kAdd] = myLin.yWork[index14];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntPlus;
                    myLin.namePnt[kPntPlus] = sTmp1;
                    myLin.xPnt[kPntPlus] = myLin.xWork[index14];
                    myLin.yPnt[kPntPlus] = myLin.yWork[index14];
                    myLin.zPnt[kPntPlus] = 0.0;
                }
                if (kSel > 1)
                {
                    for (int index17 = 1; index17 < kSel; ++index17)
                    {
                        myLin.nameWork[index17] = "rad";
                        myLin.zWork[index17] = 0.0;
                    }
                }
                panel7.Invalidate();
            }
            if (nProcess == 620 && kSel == 1)
            {
                double az = 0.0;
                int kp = 0;
                double num9;
                double yrd1 = num9 = 0.0;
                double xrd1 = num9;
                double rd1 = num9;
                double num10;
                double yrd2 = num10 = 0.0;
                double xrd2 = num10;
                double rd2 = num10;
                DllClass1.FindLine(xArc[0], yArc[0], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, out rd1, out xrd1, out yrd1, out kp, ref myLin.xPik, ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                DllClass1.FindLine(xArc[1], yArc[1], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, out rd2, out xrd2, out yrd2, out kp, ref myLin.xPik, ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                sTmp1 = "";
                sTmp2 = "";
                DllClass1.FormCreate(1, out iRadio, out rRad, out pRad, out sForm, out pForm, sTmp1, sTmp2);
                if (rRad == 0.0)
                {
                    int num11 = (int)MessageBox.Show("Неверный радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    kRcPnt = 0;
                    listBox1.Items.Clear();
                    panel7.Invalidate();
                    return;
                }
                DllClass1.ArcTangent(1, rRad, rd1, xrd1, yrd1, rd2, xrd2, yrd2, out xRad, out yRad, out xh, out yh, out xk, out yk);
                if (xh == 0.0 || yh == 0.0)
                {
                    int num12 = (int)MessageBox.Show("Увеличить радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                rr = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - myLin.xWork[0];
                    dy = myLin.yPnt[index] - myLin.yWork[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        ip = index;
                    }
                }
                if (rr < tolerance)
                {
                    myLin.nameWork[0] = myLin.namePnt[ip];
                    myLin.xWork[0] = myLin.xPnt[ip];
                    myLin.yWork[0] = myLin.yPnt[ip];
                    myLin.zWork[0] = myLin.zPnt[ip];
                }
                if (rr >= tolerance)
                {
                    int nName = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                    myLin.nameWork[0] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[0];
                    myLin.yAdd[kAdd] = myLin.yWork[0];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntPlus;
                    myLin.namePnt[kPntPlus] = sTmp1;
                    myLin.xPnt[kPntPlus] = myLin.xWork[0];
                    myLin.yPnt[kPntPlus] = myLin.yWork[0];
                    myLin.zPnt[kPntPlus] = 0.0;
                }
                ip = -1;
                rr = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - myLin.xWork[kSel];
                    dy = myLin.yPnt[index] - myLin.yWork[kSel];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        ip = index;
                    }
                }
                if (rr < tolerance)
                {
                    myLin.nameWork[kSel] = myLin.namePnt[ip];
                    myLin.xWork[kSel] = myLin.xPnt[ip];
                    myLin.yWork[kSel] = myLin.yPnt[ip];
                    myLin.zWork[kSel] = myLin.zPnt[ip];
                }
                if (rr >= tolerance)
                {
                    int nName = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                    myLin.nameWork[kSel] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[kSel];
                    myLin.yAdd[kAdd] = myLin.yWork[kSel];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntPlus;
                    myLin.namePnt[kPntPlus] = sTmp1;
                    myLin.xPnt[kPntPlus] = myLin.xWork[kSel];
                    myLin.yPnt[kPntPlus] = myLin.yWork[kSel];
                    myLin.zPnt[kPntPlus] = 0.0;
                }
                textBox1.Text = "1";
                textBox4.Text = sForm;
                panel7.Invalidate();
            }
            if (nProcess == 630 && kSel == 1)
            {
                double az = 0.0;
                int kp = 0;
                double num13;
                double yrd3 = num13 = 0.0;
                double xrd3 = num13;
                double rd3 = num13;
                double num14;
                double yrd4 = num14 = 0.0;
                double xrd4 = num14;
                double rd4 = num14;
                DllClass1.FindLine(xArc[0], yArc[0], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, out rd3, out xrd3, out yrd3, out kp, ref myLin.xPik, ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                DllClass1.FindLine(xArc[1], yArc[1], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, out rd4, out xrd4, out yrd4, out kp, ref myLin.xPik, ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp < 1)
                    return;
                sTmp1 = "";
                sTmp2 = "";
                DllClass1.FormCreate(1, out iRadio, out rRad, out pRad, out sForm, out pForm, sTmp1, sTmp2);
                if (rRad == 0.0)
                {
                    int num15 = (int)MessageBox.Show("Неверный радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kSel = -1;
                    kRcPnt = 0;
                    listBox1.Items.Clear();
                    panel7.Invalidate();
                    return;
                }
                DllClass1.ArcTangent(2, rRad, rd3, xrd3, yrd3, rd4, xrd4, yrd4, out xRad, out yRad, out xh, out yh, out xk, out yk);
                if (xh == 0.0 || yh == 0.0)
                {
                    int num16 = (int)MessageBox.Show("Увеличить радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                rr = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - myLin.xWork[0];
                    dy = myLin.yPnt[index] - myLin.yWork[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        ip = index;
                    }
                }
                if (rr < tolerance)
                {
                    myLin.nameWork[0] = myLin.namePnt[ip];
                    myLin.xWork[0] = myLin.xPnt[ip];
                    myLin.yWork[0] = myLin.yPnt[ip];
                    myLin.zWork[0] = myLin.zPnt[ip];
                }
                if (rr >= tolerance)
                {
                    int nName = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                    myLin.nameWork[0] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[0];
                    myLin.yAdd[kAdd] = myLin.yWork[0];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntPlus;
                    myLin.namePnt[kPntPlus] = sTmp1;
                    myLin.xPnt[kPntPlus] = myLin.xWork[0];
                    myLin.yPnt[kPntPlus] = myLin.yWork[0];
                    myLin.zPnt[kPntPlus] = 0.0;
                }
                ip = -1;
                rr = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - myLin.xWork[kSel];
                    dy = myLin.yPnt[index] - myLin.yWork[kSel];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        ip = index;
                    }
                }
                if (rr < tolerance)
                {
                    myLin.nameWork[kSel] = myLin.namePnt[ip];
                    myLin.xWork[kSel] = myLin.xPnt[ip];
                    myLin.yWork[kSel] = myLin.yPnt[ip];
                    myLin.zWork[kSel] = myLin.zPnt[ip];
                }
                if (rr >= tolerance)
                {
                    int nName = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                    myLin.nameWork[kSel] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[kSel];
                    myLin.yAdd[kAdd] = myLin.yWork[kSel];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntPlus;
                    myLin.namePnt[kPntPlus] = sTmp1;
                    myLin.xPnt[kPntPlus] = myLin.xWork[kSel];
                    myLin.yPnt[kPntPlus] = myLin.yWork[kSel];
                    myLin.zPnt[kPntPlus] = 0.0;
                }
                textBox1.Text = "1";
                textBox4.Text = sForm;
                panel7.Invalidate();
            }
            if (nProcess == 640)
            {
                double num17;
                double num18 = num17 = 0.0;
                double num19 = num17;
                double num20 = num17;
                double num21 = num17;
                if (kSel == 1)
                {
                    int index18 = -1;
                    int kp = 0;
                    DllClass1.FindEndLine(xArc[0], yArc[0], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.xLin, ref myLin.yLin, out kp, ref myLin.xPik, ref myLin.yPik, out indLine, out ip);
                    if (ip > 0 && ip < kp)
                    {
                        int num22 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
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
                        num21 = myLin.xPik[0];
                        num20 = myLin.yPik[0];
                    }
                    if (ip == kp)
                    {
                        xh = myLin.xPik[kp];
                        yh = myLin.yPik[kp];
                        xk = myLin.xPik[kp - 1];
                        yk = myLin.yPik[kp - 1];
                        num21 = myLin.xPik[kp];
                        num20 = myLin.yPik[kp];
                    }
                    DllClass1.FindEndLine(xArc[1], yArc[1], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.xLin, ref myLin.yLin, out kp, ref myLin.xPik, ref myLin.yPik, out indLine, out ip);
                    if (ip > 0 && ip < kp)
                    {
                        int num23 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
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
                        num19 = myLin.xPik[0];
                        num18 = myLin.yPik[0];
                    }
                    if (ip == kp)
                    {
                        x3 = myLin.xPik[kp];
                        y3 = myLin.yPik[kp];
                        x4 = myLin.xPik[kp - 1];
                        y4 = myLin.yPik[kp - 1];
                        num19 = myLin.xPik[kp];
                        num18 = myLin.yPik[kp];
                    }
                    dx = num19 - num21;
                    dy = num18 - num20;
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    sTmp1 = string.Format("{0:F1}", (object)ss);
                    if (ss < 0.001)
                    {
                        int num24 = (int)MessageBox.Show("Неправильный выбор линий", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        int num25 = (int)MessageBox.Show("One Radius = 0", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        int num26 = (int)MessageBox.Show("Неправильный выбор линий", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    for (int index19 = 0; index19 <= kSel; ++index19)
                    {
                        ++index18;
                        myLin.xWork[index18] = myLin.xDop[index19];
                        myLin.yWork[index18] = myLin.yDop[index19];
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
                    dx = myLin.xWork[index18] - myLin.xDop[0];
                    dy = myLin.yWork[index18] - myLin.yDop[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < 0.1)
                    {
                        for (int index20 = 1; index20 <= kSel; ++index20)
                        {
                            ++index18;
                            myLin.xWork[index18] = myLin.xDop[index20];
                            myLin.yWork[index18] = myLin.yDop[index20];
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
                        for (int index21 = 1; index21 <= kSel; ++index21)
                        {
                            ++index18;
                            myLin.xWork[index18] = myLin.xDop[index21];
                            myLin.yWork[index18] = myLin.yDop[index21];
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
                    dx = myLin.xWork[index18] - myLin.xDop[0];
                    dy = myLin.yWork[index18] - myLin.yDop[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < 0.1)
                    {
                        for (int index22 = 1; index22 <= kSel; ++index22)
                        {
                            ++index18;
                            myLin.xWork[index18] = myLin.xDop[index22];
                            myLin.yWork[index18] = myLin.yDop[index22];
                        }
                    }
                    kSel = index18;
                    for (int index23 = 0; index23 <= kSel; ++index23)
                    {
                        myLin.nameWork[index23] = "rad";
                        myLin.zWork[index23] = 0.0;
                    }
                    ip = -1;
                    rr = 9999999.9;
                    for (int index24 = 0; index24 <= kPntPlus; ++index24)
                    {
                        dx = myLin.xPnt[index24] - myLin.xWork[0];
                        dy = myLin.yPnt[index24] - myLin.yWork[0];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < rr)
                        {
                            rr = ss;
                            ip = index24;
                        }
                    }
                    if (rr < tolerance)
                    {
                        myLin.nameWork[0] = myLin.namePnt[ip];
                        myLin.xWork[0] = myLin.xPnt[ip];
                        myLin.yWork[0] = myLin.yPnt[ip];
                        myLin.zWork[0] = myLin.zPnt[ip];
                    }
                    if (rr >= tolerance)
                    {
                        int nName = 0;
                        DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                        myLin.nameWork[0] = sTmp1;
                        ++kAdd;
                        myLin.nameAdd[kAdd] = sTmp1;
                        myLin.xAdd[kAdd] = myLin.xWork[0];
                        myLin.yAdd[kAdd] = myLin.yWork[0];
                        myLin.zAdd[kAdd] = 0.0;
                        ++kPntPlus;
                        myLin.namePnt[kPntPlus] = sTmp1;
                        myLin.xPnt[kPntPlus] = myLin.xWork[0];
                        myLin.yPnt[kPntPlus] = myLin.yWork[0];
                        myLin.zPnt[kPntPlus] = 0.0;
                    }
                    ip = -1;
                    rr = 9999999.9;
                    for (int index25 = 0; index25 <= kPntPlus; ++index25)
                    {
                        dx = myLin.xPnt[index25] - myLin.xWork[kSel];
                        dy = myLin.yPnt[index25] - myLin.yWork[kSel];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < rr)
                        {
                            rr = ss;
                            ip = index25;
                        }
                    }
                    if (rr < tolerance)
                    {
                        myLin.nameWork[kSel] = myLin.namePnt[ip];
                        myLin.xWork[kSel] = myLin.xPnt[ip];
                        myLin.yWork[kSel] = myLin.yPnt[ip];
                        myLin.zWork[kSel] = myLin.zPnt[ip];
                    }
                    if (rr >= tolerance)
                    {
                        int nName = 0;
                        DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                        myLin.nameWork[kSel] = sTmp1;
                        ++kAdd;
                        myLin.nameAdd[kAdd] = sTmp1;
                        myLin.xAdd[kAdd] = myLin.xWork[kSel];
                        myLin.yAdd[kAdd] = myLin.yWork[kSel];
                        myLin.zAdd[kAdd] = 0.0;
                        ++kPntPlus;
                        myLin.namePnt[kPntPlus] = sTmp1;
                        myLin.xPnt[kPntPlus] = myLin.xWork[kSel];
                        myLin.yPnt[kPntPlus] = myLin.yWork[kSel];
                        myLin.zPnt[kPntPlus] = 0.0;
                    }
                    textBox1.Text = "1";
                    textBox4.Text = "1";
                    panel7.Invalidate();
                }
            }
            if ((nProcess == 54 || nProcess == 55 || nProcess == 56 || nProcess == 57 || nProcess == 58 || nProcess == 59 || nProcess == 62) && kSel == 1)
            {
                double az = 0.0;
                int kp1 = 0;
                int kp2 = 0;
                double num27;
                double yrd5 = num27 = 0.0;
                double xrd5 = num27;
                double rd5 = num27;
                double num28;
                double yrd6 = num28 = 0.0;
                double xrd6 = num28;
                double rd6 = num28;
                DllClass1.FindLine(xArc[0], yArc[0], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, out rd5, out xrd5, out yrd5, out kp1, ref myLin.xPik, ref myLin.yPik, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kp1 < 1)
                    return;
                DllClass1.FindLine(xArc[1], yArc[1], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, out rd6, out xrd6, out yrd6, out kp2, ref myLin.xPol, ref myLin.yPol, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indSide);
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
                        DllClass1.FindEndLine(xArc[0], yArc[0], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.xLin, ref myLin.yLin, out kp1, ref myLin.xPik, ref myLin.yPik, out indLine, out ip);
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
                        int num29 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
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
                        DllClass1.FindEndLine(xArc[1], yArc[1], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.xLin, ref myLin.yLin, out kp2, ref myLin.xPol, ref myLin.yPol, out indSide, out ip);
                    if (nProcess == 56 || nProcess == 57 || nProcess == 62)
                    {
                        rr = 9999999.9;
                        ip = -1;
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
                    if (ip > 0 && ip < kp2)
                    {
                        int num30 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
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
                        int num31 = (int)MessageBox.Show("Неверный радиус", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        int num32 = (int)MessageBox.Show("Неверное расстояние", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    if (kSel < 3)
                    {
                        int num33 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
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
                        int num34 = (int)MessageBox.Show("Повторить выбор линий", "Построение линий");
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
                rr = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - myLin.xWork[0];
                    dy = myLin.yPnt[index] - myLin.yWork[0];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        ip = index;
                    }
                }
                if (rr < tolerance)
                {
                    myLin.nameWork[0] = myLin.namePnt[ip];
                    myLin.xWork[0] = myLin.xPnt[ip];
                    myLin.yWork[0] = myLin.yPnt[ip];
                    myLin.zWork[0] = myLin.zPnt[ip];
                }
                if (rr >= tolerance)
                {
                    int nName = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                    myLin.nameWork[0] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[0];
                    myLin.yAdd[kAdd] = myLin.yWork[0];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntPlus;
                    myLin.namePnt[kPntPlus] = sTmp1;
                    myLin.xPnt[kPntPlus] = myLin.xWork[0];
                    myLin.yPnt[kPntPlus] = myLin.yWork[0];
                    myLin.zPnt[kPntPlus] = 0.0;
                }
                ip = -1;
                rr = 9999999.9;
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    dx = myLin.xPnt[index] - myLin.xWork[kSel];
                    dy = myLin.yPnt[index] - myLin.yWork[kSel];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < rr)
                    {
                        rr = ss;
                        ip = index;
                    }
                }
                if (rr < tolerance)
                {
                    myLin.nameWork[kSel] = myLin.namePnt[ip];
                    myLin.xWork[kSel] = myLin.xPnt[ip];
                    myLin.yWork[kSel] = myLin.yPnt[ip];
                    myLin.zWork[kSel] = myLin.zPnt[ip];
                }
                if (rr >= tolerance)
                {
                    int nName = 0;
                    DllClass1.NewPointName(kPntPlus, myLin.namePnt, out nName, out sTmp1);
                    myLin.nameWork[kSel] = sTmp1;
                    ++kAdd;
                    myLin.nameAdd[kAdd] = sTmp1;
                    myLin.xAdd[kAdd] = myLin.xWork[kSel];
                    myLin.yAdd[kAdd] = myLin.yWork[kSel];
                    myLin.zAdd[kAdd] = 0.0;
                    ++kPntPlus;
                    myLin.namePnt[kPntPlus] = sTmp1;
                    myLin.xPnt[kPntPlus] = myLin.xWork[kSel];
                    myLin.yPnt[kPntPlus] = myLin.yWork[kSel];
                    myLin.zPnt[kPntPlus] = 0.0;
                }
                textBox1.Text = "1";
                sTmp1 = string.Format("{0:F3}", (object)rRad);
                textBox4.Text = sTmp1;
                panel7.Invalidate();
            }
            if (nProcess == 650 && kSel == 0)
            {
                double az = 0.0;
                double num;
                double yrd = num = 0.0;
                double xrd = num;
                double rd = num;
                DllClass1.FindLine(xArc[0], yArc[0], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, out rd, out xrd, out yrd, out kSel, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az, out indLine);
                if (kSel < 1)
                    return;
                textBox1.Text = string.Format("{0}", (object)myLin.nLineCode[indLine]);
                textBox4.Text = string.Format("{0:F2}", (object)myLin.rRadLine[indLine]);
                panel7.Invalidate();
            }
            if (nProcess != 660 || kSel != 0)
                return;
            double az1 = 0.0;
            double num35;
            double yrd7 = num35 = 0.0;
            double xrd7 = num35;
            double rd7 = num35;
            DllClass1.FindLine(xArc[0], yArc[0], kLineInput, ref myLin.k1, ref myLin.k2, ref myLin.rRadLine, ref myLin.xRadLine, ref myLin.yRadLine, ref myLin.xLin, ref myLin.yLin, out rd7, out xrd7, out yrd7, out kSel, ref myLin.xWork, ref myLin.yWork, ref myLin.xDop, ref myLin.yDop, out xCur, out yCur, out az1, out indLine);
            if (kSel < 1)
                return;
            int index26 = kSel + 1;
            for (int index27 = 0; index27 <= kSel; ++index27)
            {
                --index26;
                myLin.xDop[index27] = myLin.xWork[index26];
                myLin.yDop[index27] = myLin.yWork[index26];
            }
            int num36 = myLin.k1[indLine];
            int num37 = myLin.k2[indLine];
            int index28 = -1;
            for (int index29 = num36; index29 <= num37; ++index29)
            {
                ++index28;
                myLin.xLin[index29] = myLin.xDop[index28];
                myLin.yLin[index29] = myLin.yDop[index28];
            }
            myLin.KeepLine();
            DllClass1.LineItemCoor(myLin.fitemLine, myLin.nColorItm, myLin.ixSqu, myLin.iySqu, kLineInput, myLin.rRadLine, myLin.k1, myLin.k2, myLin.xLin, myLin.yLin, myLin.nLineCode, kSymbLine, myLin.nItem, myLin.n1Sign, myLin.n2Sign, myLin.iDensity, out kItemCoord, myLin.numSign, myLin.numItem, myLin.xItem, myLin.yItem, myLin.azItem, myLin.xAdd, myLin.yAdd, myLin.xDop, myLin.yDop, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, scaleToGeo);
            if (kItemCoord > 0)
            {
                myLin.kItemCoord = kItemCoord;
                myLin.ItemLoadKeep(2);
            }
            kSel = -1;
            iLineShow = 0;
            iSymbolShow = 1;
            panel7.Invalidate();
        }

        private void SelectBox_Click(object sender, EventArgs e) => nControl = 10;

        private void ZoomIn_Click(object sender, EventArgs e) => nControl = 20;

        private void ZoomOut_Click(object sender, EventArgs e) => nControl = 30;

        private void Move_Click(object sender, EventArgs e) => nControl = 40;

        private void ArcShort_Click(object sender, EventArgs e)
        {
            nProcess = 520;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            iCodeLine = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            groupBox4.Visible = true;
            listBox1.Items.Clear();
            textBox1.Text = "";
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            textBox4.Text = "";
            iSymbolShow = 0;
            iLineShow = 1;
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
            iCodeLine = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            groupBox4.Visible = true;
            listBox1.Items.Clear();
            textBox1.Text = "";
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            textBox4.Text = "";
            iSymbolShow = 0;
            iLineShow = 1;
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
            iCodeLine = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            groupBox4.Visible = true;
            listBox1.Items.Clear();
            textBox1.Text = "";
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            textBox4.Text = "";
            iSymbolShow = 0;
            iLineShow = 1;
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
            iCodeLine = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            groupBox4.Visible = true;
            listBox1.Items.Clear();
            textBox1.Text = "";
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            textBox4.Text = "";
            iSymbolShow = 0;
            iLineShow = 1;
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
            iCodeLine = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            groupBox4.Visible = true;
            listBox1.Items.Clear();
            textBox1.Text = "";
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            textBox4.Text = "";
            iSymbolShow = 0;
            iLineShow = 1;
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
            iCodeLine = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            groupBox4.Visible = true;
            listBox1.Items.Clear();
            textBox1.Text = "";
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            iSymbolShow = 0;
            iLineShow = 1;
            panel7.Invalidate();
        }

        private void Parallel_Click(object sender, EventArgs e)
        {
            if (iGraphic > 0)
                return;
            if (kLineInput < 1)
            {
                int num = (int)MessageBox.Show("Нет линий", "Parallel Line", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 580;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void PointLine_Click(object sender, EventArgs e)
        {
            if (kLineInput < 1)
            {
                int num = (int)MessageBox.Show("Нет линий", "Point Line", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 590;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void Lengthen_Click(object sender, EventArgs e)
        {
            if (kLineInput < 1)
            {
                int num = (int)MessageBox.Show("Нет линий", "Lengthen Line", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 610;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void TangentDirect_Click(object sender, EventArgs e)
        {
            if (kLineInput < 2)
            {
                int num = (int)MessageBox.Show("Линии < 2", "Tangent Direct", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 620;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void TangentInverse_Click(object sender, EventArgs e)
        {
            if (kLineInput < 2)
            {
                int num = (int)MessageBox.Show("Линии < 2", "Tangent Inverse", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 630;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void BlindAlley_Click(object sender, EventArgs e)
        {
            if (kLineInput < 2)
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
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void ChangeCode_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myLin.fileLine))
            {
                int num = (int)MessageBox.Show("Нет линий", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 650;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                iLineShow = 1;
                iSymbolShow = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                panel7.Invalidate();
            }
        }

        private void ChangeDirection_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myLin.fileLine))
            {
                int num = (int)MessageBox.Show("Нет линий", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 660;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = false;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void FilletShortDirect_Click(object sender, EventArgs e)
        {
            if (kLineInput < 1)
            {
                int num = (int)MessageBox.Show("Нет линий", "Fillet Short Direct", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 54;
                nFillet = 1;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void FilletLongDirect_Click(object sender, EventArgs e)
        {
            if (kLineInput < 1)
            {
                int num = (int)MessageBox.Show("Нет линий", "Fillet Long Direct", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 55;
                nFillet = 3;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void FilletDirectR_Click(object sender, EventArgs e)
        {
            if (kLineInput < 1)
            {
                int num = (int)MessageBox.Show("Нет линий", "Fillet Direct R > 0", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 56;
                nFillet = 5;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void FilletInverseR_Click(object sender, EventArgs e)
        {
            if (kLineInput < 1)
            {
                int num = (int)MessageBox.Show("Нет линий", "Fillet Inverse R > 0", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 57;
                nFillet = 6;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void FilletShortInverse_Click(object sender, EventArgs e)
        {
            if (kLineInput < 1)
            {
                int num = (int)MessageBox.Show("Нет линий", "Fillet Short Inverse", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 58;
                nFillet = 2;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void FilletLongInverse_Click(object sender, EventArgs e)
        {
            if (kLineInput < 1)
            {
                int num = (int)MessageBox.Show("Линии < 2", "Замкнутая линия", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 59;
                nFillet = 4;
                iImageShow = 1;
                nControl = 0;
                kAdd = 0;
                kSel = -1;
                kRcPnt = 0;
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void FilletBisect_Click(object sender, EventArgs e)
        {
            if (kLineInput < 1)
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
                iCodeLine = 0;
                rRad = 0.0;
                xRad = 0.0;
                yRad = 0.0;
                iLong = 0;
                groupBox4.Visible = true;
                listBox1.Items.Clear();
                textBox1.Text = "";
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                iSymbolShow = 0;
                iLineShow = 1;
                panel7.Invalidate();
            }
        }

        private void LineDelete_Click(object sender, EventArgs e)
        {
            nProcess = 600;
            iImageShow = 0;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            iCodeLine = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            groupBox4.Visible = true;
            listBox1.Items.Clear();
            textBox1.Text = "";
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.ReadOnly = true;
            iSymbolShow = 0;
            iLineShow = 1;
            if (File.Exists(myLin.fileDangle))
                File.Delete(myLin.fileDangle);
            if (File.Exists(myLin.fileNode))
                File.Delete(myLin.fileNode);
            if (File.Exists(myLin.flineFinal))
                File.Delete(myLin.flineFinal);
            if (File.Exists(myLin.fpolyFinal))
                File.Delete(myLin.fpolyFinal);
            if (File.Exists(myLin.fCancLine))
                File.Delete(myLin.fCancLine);
            if (File.Exists(myLin.fCancPoly))
                File.Delete(myLin.fCancPoly);
            if (File.Exists(myLin.flineTopo))
                File.Delete(myLin.flineTopo);
            if (File.Exists(myLin.filePoly))
                File.Delete(myLin.filePoly);
            if (File.Exists(myLin.factLine))
                File.Delete(myLin.factLine);
            if (File.Exists(myLin.factNode))
                File.Delete(myLin.factNode);
            if (File.Exists(myLin.factPoly))
                File.Delete(myLin.factPoly);
            if (File.Exists(myLin.fileAction))
                File.Delete(myLin.fileAction);
            if (File.Exists(myLin.fileExter))
                File.Delete(myLin.fileExter);
            if (File.Exists(myLin.fileProcess))
                File.Delete(myLin.fileProcess);
            if (File.Exists(myLin.fileToler))
                File.Delete(myLin.fileToler);
            if (File.Exists(myLin.fblockPoly))
                File.Delete(myLin.fblockPoly);
            if (File.Exists(myLin.fpolyInter))
                File.Delete(myLin.fpolyInter);
            if (File.Exists(myLin.fileInterval))
                File.Delete(myLin.fileInterval);
            if (File.Exists(myLin.faddPoly))
                File.Delete(myLin.faddPoly);
            if (File.Exists(myLin.fileContour))
                File.Delete(myLin.fileContour);
            if (File.Exists(myLin.fileZminzmax))
                File.Delete(myLin.fileZminzmax);
            if (File.Exists(myLin.fileSplit))
                File.Delete(myLin.fileSplit);
            if (File.Exists(myLin.flistAction))
                File.Delete(myLin.flistAction);
            if (File.Exists(myLin.flineFinal))
                File.Delete(myLin.flineFinal);
            if (File.Exists(myLin.fsourcePoly))
                File.Delete(myLin.fsourcePoly);
            kItemCoord = 0;
            myLin.AllActionRemove();
            if (kLineInput == 0)
            {
                int num = (int)MessageBox.Show("All lines were removed", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nProcess = 0;
            }
            else
                panel7.Invalidate();
        }

        private void AllDelete_Click(object sender, EventArgs e)
        {
            if (kLineInput == 0)
            {
                int num = (int)MessageBox.Show("All lines were removed", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                kSel = -1;
                kAdd = 0;
                kRcPnt = 0;
                nProcess = 0;
                listBox1.Items.Clear();
                iSymbolShow = 0;
                panel7.Invalidate();
            }
            else
            {
                if (File.Exists(myLin.fileLine) && MessageBox.Show("Вы действительно хотите удалить все строки ?", "Построение линий", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                kPntPlus = kPntInput;
                myLin.kPntPlus = kPntPlus;
                myLin.kPntInput = kPntInput;
                myLin.KeepPoint();
                if (File.Exists(myLin.fileLine))
                {
                    File.Delete(myLin.fileLine);
                    kLineInput = 0;
                    kSel = -1;
                    kAdd = 0;
                    nProcess = 0;
                    nControl = 0;
                    kRcPnt = 0;
                    iCodeLine = 0;
                    rRad = 0.0;
                    xRad = 0.0;
                    yRad = 0.0;
                    iLong = 0;
                    listBox1.Items.Clear();
                    textBox1.Text = "";
                    textBox4.Text = "";
                    iSymbolShow = 0;
                }
                kItemCoord = 0;
                myLin.FilesRemove();
                myLin.AllActionRemove();
                panel7.Invalidate();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (kSel < 1)
                return;
            if (textBox1.Text == "" || textBox4.Text == "")
            {
                int num1 = (int)MessageBox.Show("May be you forgot down right button of the mouse", "Построение линий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(myLin.flineTopo))
                {
                    myLin.LineLoad();
                    kLineInput = myLin.kLineInput;
                }
                if (kSel > 0)
                {
                    double tText = 0.0;
                    DllClass1.CheckText(textBox1.Text, out tText, out iCond);
                    if (iCond < 0)
                    {
                        int num2 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    iCodeLine = Convert.ToInt32(textBox1.Text);
                    if (iCodeLine == 0)
                        iCodeLine = 1;
                    sWidth = 0.0;
                    sMillim = 0.0;
                    DllClass1.CheckText(textBox4.Text, out rRad, out iCond);
                    if (iCond < 0)
                    {
                        int num3 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                if (nProcess == 650 && kSel > 0 && indLine > 0)
                {
                    int num4 = 0;
                    double tText = 0.0;
                    if (textBox1.Text != "" && textBox1.Text != "0")
                    {
                        DllClass1.CheckText(textBox1.Text, out tText, out iCond);
                        if (iCond < 0)
                        {
                            int num5 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        num4 = Convert.ToInt32(textBox1.Text);
                        int num6 = 0;
                        for (int index = 0; index <= kSymbLine; ++index)
                        {
                            if (myLin.n2Sign[index] > 0 && myLin.n2Sign[index] == num4)
                            {
                                ++num6;
                                break;
                            }
                        }
                        if (num6 == 0)
                        {
                            for (int index = 0; index <= kSymbLine; ++index)
                            {
                                if (myLin.n1Sign[index] > 0 && myLin.n1Sign[index] == num4)
                                {
                                    ++num6;
                                    break;
                                }
                            }
                        }
                        if (num6 == 0)
                        {
                            int num7 = (int)MessageBox.Show("Неправильный номер. Проверьте свои коды.", "Символы линий");
                            return;
                        }
                    }
                    if (num4 == 0)
                        num4 = 1;
                    myLin.nLineCode[indLine] = num4;
                    myLin.sWidLine[indLine] = 0.0;
                    myLin.dstLine[indLine] = 0.0;
                    DllClass1.CheckText(textBox4.Text, out myLin.rRadLine[indLine], out iCond);
                    if (iCond < 0)
                    {
                        int num8 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        myLin.kLineInput = kLineInput;
                        myLin.KeepLine();
                        if (kSymbLine > 0)
                        {
                            DllClass1.LineItemCoor(myLin.fitemLine, myLin.nColorItm, myLin.ixSqu, myLin.iySqu, kLineInput, myLin.rRadLine, myLin.k1, myLin.k2, myLin.xLin, myLin.yLin, myLin.nLineCode, kSymbLine, myLin.nItem, myLin.n1Sign, myLin.n2Sign, myLin.iDensity, out kItemCoord, myLin.numSign, myLin.numItem, myLin.xItem, myLin.yItem, myLin.azItem, myLin.xAdd, myLin.yAdd, myLin.xDop, myLin.yDop, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, scaleToGeo);
                            if (kItemCoord > 0)
                            {
                                myLin.kItemCoord = kItemCoord;
                                myLin.ItemLoadKeep(2);
                            }
                            iSymbolShow = 1;
                        }
                        iLineShow = 0;
                        if (kSymbLine == 0)
                            iLineShow = 1;
                        kSel = -1;
                        kRcPnt = 0;
                        nProcess = 0;
                        kAdd = 0;
                        rRad = 0.0;
                        xRad = 0.0;
                        yRad = 0.0;
                        iLong = 0;
                        iSymbolShow = 1;
                        iLineShow = 0;
                        listBox1.Items.Clear();
                        textBox1.Text = "";
                        textBox4.Text = "";
                        if (File.Exists(myLin.fileDangle))
                            File.Delete(myLin.fileDangle);
                        if (File.Exists(myLin.fileNode))
                            File.Delete(myLin.fileNode);
                        if (File.Exists(myLin.flineFinal))
                            File.Delete(myLin.flineFinal);
                        if (File.Exists(myLin.fpolyFinal))
                            File.Delete(myLin.fpolyFinal);
                        if (File.Exists(myLin.fCancLine))
                            File.Delete(myLin.fCancLine);
                        if (File.Exists(myLin.fCancPoly))
                            File.Delete(myLin.fCancPoly);
                        if (File.Exists(myLin.flineTopo))
                            File.Delete(myLin.flineTopo);
                        if (File.Exists(myLin.filePoly))
                            File.Delete(myLin.filePoly);
                        if (File.Exists(myLin.factLine))
                            File.Delete(myLin.factLine);
                        if (File.Exists(myLin.factNode))
                            File.Delete(myLin.factNode);
                        if (File.Exists(myLin.factPoly))
                            File.Delete(myLin.factPoly);
                        if (File.Exists(myLin.fileAction))
                            File.Delete(myLin.fileAction);
                        if (File.Exists(myLin.fileExter))
                            File.Delete(myLin.fileExter);
                        if (File.Exists(myLin.fileProcess))
                            File.Delete(myLin.fileProcess);
                        if (File.Exists(myLin.fileToler))
                            File.Delete(myLin.fileToler);
                        if (File.Exists(myLin.fblockPoly))
                            File.Delete(myLin.fblockPoly);
                        if (File.Exists(myLin.fpolyInter))
                            File.Delete(myLin.fpolyInter);
                        if (File.Exists(myLin.fileInterval))
                            File.Delete(myLin.fileInterval);
                        if (File.Exists(myLin.faddPoly))
                            File.Delete(myLin.faddPoly);
                        if (File.Exists(myLin.fileContour))
                            File.Delete(myLin.fileContour);
                        if (File.Exists(myLin.fileZminzmax))
                            File.Delete(myLin.fileZminzmax);
                        if (File.Exists(myLin.fileSplit))
                            File.Delete(myLin.fileSplit);
                        if (File.Exists(myLin.flistAction))
                            File.Delete(myLin.flistAction);
                        if (File.Exists(myLin.flineFinal))
                            File.Delete(myLin.flineFinal);
                        if (File.Exists(myLin.fsourcePoly))
                            File.Delete(myLin.fsourcePoly);
                        myLin.AllActionRemove();
                        panel7.Invalidate();
                    }
                }
                else
                {
                    if (kAdd > 0)
                    {
                        myLin.kPntPlus = kPntPlus;
                        myLin.kPntInput = kPntInput;
                        myLin.KeepPoint();
                    }
                    int index1 = 0;
                    if (kLineInput > 0)
                        index1 = myLin.k2[kLineInput];
                    for (int index2 = 0; index2 <= kSel; ++index2)
                    {
                        ++index1;
                        myLin.xLin[index1] = myLin.xWork[index2];
                        myLin.yLin[index1] = myLin.yWork[index2];
                    }
                    ++kLineInput;
                    myLin.nLineCode[kLineInput] = iCodeLine;
                    myLin.nLongRad[kLineInput] = iLong;
                    myLin.sWidLine[kLineInput] = sWidth;
                    myLin.dstLine[kLineInput] = sMillim;
                    myLin.rRadLine[kLineInput] = rRad;
                    myLin.xRadLine[kLineInput] = xRad;
                    myLin.yRadLine[kLineInput] = yRad;
                    myLin.kt[kLineInput] = kSel + 1;
                    if (kLineInput == 1)
                    {
                        myLin.k1[kLineInput] = 1;
                        myLin.k2[kLineInput] = myLin.kt[kLineInput];
                    }
                    if (kLineInput > 1)
                    {
                        myLin.k1[kLineInput] = myLin.k2[kLineInput - 1] + 1;
                        myLin.k2[kLineInput] = myLin.k2[kLineInput - 1] + myLin.kt[kLineInput];
                    }
                    myLin.kLineInput = kLineInput;
                    myLin.KeepLine();
                    kSel = -1;
                    kRcPnt = 0;
                    nProcess = 0;
                    kAdd = 0;
                    listBox1.Items.Clear();
                    textBox1.Text = "";
                    textBox4.Text = "";
                    if (File.Exists(myLin.fileDangle))
                        File.Delete(myLin.fileDangle);
                    if (File.Exists(myLin.fileNode))
                        File.Delete(myLin.fileNode);
                    if (File.Exists(myLin.flineFinal))
                        File.Delete(myLin.flineFinal);
                    if (File.Exists(myLin.fpolyFinal))
                        File.Delete(myLin.fpolyFinal);
                    if (File.Exists(myLin.fCancLine))
                        File.Delete(myLin.fCancLine);
                    if (File.Exists(myLin.fCancPoly))
                        File.Delete(myLin.fCancPoly);
                    if (File.Exists(myLin.flineTopo))
                        File.Delete(myLin.flineTopo);
                    if (File.Exists(myLin.filePoly))
                        File.Delete(myLin.filePoly);
                    if (File.Exists(myLin.factLine))
                        File.Delete(myLin.factLine);
                    if (File.Exists(myLin.factNode))
                        File.Delete(myLin.factNode);
                    if (File.Exists(myLin.factPoly))
                        File.Delete(myLin.factPoly);
                    if (File.Exists(myLin.fileAction))
                        File.Delete(myLin.fileAction);
                    if (File.Exists(myLin.fileExter))
                        File.Delete(myLin.fileExter);
                    if (File.Exists(myLin.fileProcess))
                        File.Delete(myLin.fileProcess);
                    if (File.Exists(myLin.fileToler))
                        File.Delete(myLin.fileToler);
                    if (File.Exists(myLin.fblockPoly))
                        File.Delete(myLin.fblockPoly);
                    if (File.Exists(myLin.fpolyInter))
                        File.Delete(myLin.fpolyInter);
                    if (File.Exists(myLin.fileInterval))
                        File.Delete(myLin.fileInterval);
                    if (File.Exists(myLin.faddPoly))
                        File.Delete(myLin.faddPoly);
                    if (File.Exists(myLin.fileContour))
                        File.Delete(myLin.fileContour);
                    if (File.Exists(myLin.fileZminzmax))
                        File.Delete(myLin.fileZminzmax);
                    if (File.Exists(myLin.fileSplit))
                        File.Delete(myLin.fileSplit);
                    if (File.Exists(myLin.flistAction))
                        File.Delete(myLin.flistAction);
                    if (File.Exists(myLin.flineFinal))
                        File.Delete(myLin.flineFinal);
                    if (File.Exists(myLin.fsourcePoly))
                        File.Delete(myLin.fsourcePoly);
                    myLin.AllActionRemove();
                    iLineShow = 1;
                    iSymbolShow = 0;
                    if (iCodeLine > 0)
                    {
                        if (kSymbLine > 0)
                        {
                            DllClass1.LineItemCoor(myLin.fitemLine, myLin.nColorItm, myLin.ixSqu, myLin.iySqu, kLineInput, myLin.rRadLine, myLin.k1, myLin.k2, myLin.xLin, myLin.yLin, myLin.nLineCode, kSymbLine, myLin.nItem, myLin.n1Sign, myLin.n2Sign, myLin.iDensity, out kItemCoord, myLin.numSign, myLin.numItem, myLin.xItem, myLin.yItem, myLin.azItem, myLin.xAdd, myLin.yAdd, myLin.xDop, myLin.yDop, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, scaleToGeo);
                            if (kItemCoord > 0)
                            {
                                myLin.kItemCoord = kItemCoord;
                                myLin.ItemLoadKeep(2);
                            }
                            iSymbolShow = 1;
                        }
                        iLineShow = 0;
                        if (kSymbLine == 0)
                            iLineShow = 1;
                    }
                    myLin.AllActionRemove();
                    panel7.Invalidate();
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            kSel = -1;
            nProcess = 0;
            nControl = 0;
            kAdd = 0;
            kRcPnt = 0;
            iCodeLine = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            textBox1.Text = "";
            textBox4.Text = "";
            myLin.PointLoad();
            kPntPlus = myLin.kPntPlus;
            kPntInput = myLin.kPntInput;
            panel7.Invalidate();
        }

        private void PointsOnOff_Click(object sender, EventArgs e)
        {
            iPointShow = iPointShow <= 0 ? 1 : 0;
            panel7.Invalidate();
        }

        private void SymbolsOnOff_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myLin.fileLine))
            {
                int num = (int)MessageBox.Show("Нет линий", "Просмотр(показать)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (iSymbolShow > 0)
                {
                    iLineShow = 1;
                    iSymbolShow = 0;
                }
                else
                {
                    iLineShow = 0;
                    iSymbolShow = 1;
                }
                kSel = -1;
                panel7.Invalidate();
            }
        }

        private void AllType_Click(object sender, EventArgs e)
        {
            nProcess = 700;
            iImageShow = iImageShow != 1 ? 1 : 0;
            nControl = 0;
            kSel = -1;
            kAdd = 0;
            kRcPnt = 0;
            iCodeLine = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            listBox1.Items.Clear();
            textBox1.Text = "";
            textBox4.Text = "";
            panel7.Invalidate();
        }

        private void PointSymbol_Click(object sender, EventArgs e)
        {
            iPointSymbol = iPointSymbol >= 0 ? -1 : 0;
            if (iPointSymbol == 0)
                iPointShow = 1;
            panel7.Invalidate();
        }

        private void Exit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        private void Line_Click(object sender, EventArgs e)
        {
            nProcess = 510;
            iImageShow = 1;
            nControl = 0;
            kAdd = 0;
            kSel = -1;
            kRcPnt = 0;
            iCodeLine = 0;
            rRad = 0.0;
            xRad = 0.0;
            yRad = 0.0;
            iLong = 0;
            groupBox4.Visible = true;
            listBox1.Items.Clear();
            textBox1.Text = "";
            label4.Visible = false;
            textBox4.Visible = false;
            iSymbolShow = 0;
            iLineShow = 1;
            panel7.Invalidate();
        }

        private void HelpSymbol_Click(object sender, EventArgs e)
        {
            int num1 = 300;
            if (File.Exists(myLin.fileAdd))
                File.Delete(myLin.fileAdd);
            FileStream output = new FileStream(myLin.fileAdd, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(num1);
            binaryWriter.Close();
            output.Close();
            int num2 = (int)new ListLineSign().ShowDialog((IWin32Window)this);
            int index = 0;
            iCodeLine = 0;
            iCond = 0;
            if (File.Exists(myLin.fileAdd))
            {
                FileStream input = new FileStream(myLin.fileAdd, FileMode.Open, FileAccess.Read);
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
            iCodeLine = myLin.n2Sign[index];
            if (iCodeLine == 0)
                iCodeLine = 1;
            textBox1.Text = string.Format("{0}", (object)iCodeLine);
            iCond = myLin.nBaseSymb[index];
            textBox2.Text = "0.0";
            if (iCond != 8)
                return;
            textBox2.Text = "2.0";
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }
    }
}
