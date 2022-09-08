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
    public partial class Cadasral : Form
    {
        private string sTmp = "";
        private int iWidth;
        private int iHeight;
        private int pixWid;
        private int pixHei;
        private int nProcess;
        private int kSymbPnt;
        private int kSymbLine;
        private int kPntPlus;
        private int kPntInput;
        private int kNode;
        private int hSymbLine = 20;
        private int kPolySymb;
        private int kPntSource;
        private int kPntFin;
        private int hSymbPoly;
        private int kPntProj = -1;
        private int kProjInput;
        private int kLineProj;
        private int kItemCoord;
        private int kPolyFinal;
        private int iPolyFinal;
        private int kLineFinal;
        private int iLineFinal;
        private int kLineInput;
        private int nAction;
        private int kNodeAct;
        private int kLineAct;
        private int kPolyAct;
        private int kPolyCancel;
        private int kLineCancel;
        private int kLineNew;
        private int kLineTopo;
        private int kPoly;
        private int kAddInscript;
        private int iCond;
        private int iGraphic;
        private int kBorder;
        private int iPointOnOff = 1;
        private int iHeightShow;
        private int iProjData;
        private int iCancelPoly;
        private int iContourShow = 1;
        private int kHeight;
        private int kIntAct;
        private int kPolySource;
        private int maxParcel;
        private int kInstall;
        private int iSymbols;
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
        private double xCur;
        private double yCur;
        private double scaleToWin;
        private double scaleToGeo;
        private double xBegX;
        private double yBegY;
        private double xEndX;
        private double yEndY;
        private int xBegWin;
        private int yBegWin;
        private int xEndWin;
        private int yEndWin;
        private double tolerance = 0.003;
        private string[] sDrive;
        private int kDrive;
        public string[] nameFiles = new string[100];
        public string[] nameDir = new string[100];
        private int kModStore;
        private string[] sModStore = new string[35];
        private int kSelModel;
        private string[] sSelModel = new string[35];
        private int iParam;
        private string sNameModel = "";
        private int ip;
        private int nProblem;

        private MyGeodesy mySub = new MyGeodesy();

        public string fCurPnt { get; private set; }
        public string fCurHeig { get; private set; }
        public string fCurLine { get; private set; }

        public Cadasral()
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
            panel1.Text = "Diplom ПОИС.00332 Бурляев";
            panel3.Text = "**";
            panel5.Text = "**";
            panel6.Text = DateTime.Now.ToShortDateString();
            statusBar1.Enabled = true;
            statusBar1.Font = new Font(Font, FontStyle.Bold);
            groupBox10.Visible = false;
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
            button19.MouseHover += new EventHandler(button19_MouseHover);
            button19.MouseLeave += new EventHandler(button1_MouseLeave);
            button20.MouseHover += new EventHandler(button20_MouseHover);
            button20.MouseLeave += new EventHandler(button1_MouseLeave);
            button24.MouseHover += new EventHandler(button24_MouseHover);
            button24.MouseLeave += new EventHandler(button1_MouseLeave);
            button25.MouseHover += new EventHandler(button25_MouseHover);
            button25.MouseLeave += new EventHandler(button1_MouseLeave);
            button21.MouseHover += new EventHandler(button21_MouseHover);
            button21.MouseLeave += new EventHandler(button1_MouseLeave);
            button22.MouseHover += new EventHandler(button22_MouseHover);
            button22.MouseLeave += new EventHandler(button1_MouseLeave);
            button23.MouseHover += new EventHandler(button23_MouseHover);
            button23.MouseLeave += new EventHandler(button1_MouseLeave);
            button30.MouseHover += new EventHandler(button30_MouseHover);
            button30.MouseLeave += new EventHandler(button1_MouseLeave);
            button26.MouseHover += new EventHandler(button26_MouseHover);
            button26.MouseLeave += new EventHandler(button1_MouseLeave);
            button29.MouseHover += new EventHandler(button29_MouseHover);
            button29.MouseLeave += new EventHandler(button1_MouseLeave);
            button27.MouseHover += new EventHandler(button27_MouseHover);
            button27.MouseLeave += new EventHandler(button1_MouseLeave);
            button28.MouseHover += new EventHandler(button28_MouseHover);
            button28.MouseLeave += new EventHandler(button1_MouseLeave);
            mySub.FilePath();
            FormLoad();
        }
        private void button1_MouseHover(object sender, EventArgs e) => label3.Text = "Закрыть окно";

        private void button1_MouseLeave(object sender, EventArgs e) => label3.Text = "";

        private void button7_MouseHover(object sender, EventArgs e) => label3.Text = "Создание новых или обновление точек еопографических знаков/символов";

        private void button8_MouseHover(object sender, EventArgs e) => label3.Text = "Создание новых или обновление линейных топографических обозначений/знаков";

        private void button9_MouseHover(object sender, EventArgs e) => label3.Text = "Создание новых или обновление полигональных топографических знаков";

        private void button10_MouseHover(object sender, EventArgs e) => label3.Text = "Ввод точек из файла - исходные данные";

        private void button11_MouseHover(object sender, EventArgs e) => label3.Text = "Ввод дополнительныех точек, определяется другими способами";

        private void button19_MouseHover(object sender, EventArgs e) => label3.Text = "Формирование линейных структур";

        private void button20_MouseHover(object sender, EventArgs e)
            => label3.Text = "Создание линейных и полигональных топологий";

        private void button24_MouseHover(object sender, EventArgs e) => label3.Text = "Модель формирования и коррекции рельефа и горизонталей";

        private void button25_MouseHover(object sender, EventArgs e) => label3.Text = "Удаление контурных линий";

        private void button21_MouseHover(object sender, EventArgs e) => label3.Text = "Ввод точек из файла - данные для создания/моделирования участков ";

        private void button22_MouseHover(object sender, EventArgs e) => label3.Text = "Определяет ввод дополнительных точек, заданных другими способами";

        private void button23_MouseHover(object sender, EventArgs e) => label3.Text = "Формирование линейных структур(объектов) дизайна";

        private void button30_MouseHover(object sender, EventArgs e) => label3.Text = "Удаление всех данных проектирования/моделирования";

        private void button26_MouseHover(object sender, EventArgs e) => label3.Text = "Разделение и объединение площадей с использованием проектных данных и без них";

        private void button29_MouseHover(object sender, EventArgs e) => label3.Text = "Удаление всех действий";

        private void button27_MouseHover(object sender, EventArgs e) => label3.Text = "Окончательные правильные топографические символы точек, линий, полигонов";

        private void button28_MouseHover(object sender, EventArgs e) => label3.Text = "Печать карты и таблиц в формате листа A4";

        private void FormLoad()
        {
            if (!File.Exists(mySub.tmpStr))
            {
                int num = (int)new SelectDrive().ShowDialog((IWin32Window)this);
                //int num = (int)new ChangeDrive().ShowDialog((IWin32Window)this);
                nProcess = 910;
                mySub.FilePath();
            }
            if (!File.Exists(mySub.fileProj))
            {
                if (!File.Exists(mySub.tmpStr))
                    return;
                if (File.Exists(mySub.tmpStr))
                {
                    FileStream input = new FileStream(mySub.tmpStr, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        mySub.comPath = binaryReader.ReadString();
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
                int num1 = 0;
                if (File.Exists(mySub.fileAllProj))
                {
                    FileStream input = new FileStream(mySub.fileAllProj, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        while ((sTmp = binaryReader.ReadString()) != null)
                        {
                            ++num1;
                            sTmp = binaryReader.ReadString();
                            mySub.curProject = binaryReader.ReadString();
                            //mySub.curDirect = binaryReader.ReadString();
                            mySub.curDirect = mySub.comPath;
                        }
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
                }
                if (num1 == 0)
                {
                    int num2 = (int)MessageBox.Show("Открыть новый проект", "Кадастр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (num1 > 0)
                {
                    int num3 = (int)MessageBox.Show("Используйте 'Выбрать проект' или 'Открыть новый проект'", "Кадастр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            mySub.FilePath();
            int kPart = 50;
            char[] seps = new char[1] { '\\' };
            string[] sPart = new string[50];
            int k = 0;
            DllClass1.ShareString(mySub.comPath, kPart, seps, out k, out sPart);
            if (!File.Exists(mySub.fileProj))
            {
                label2.Text = sPart[1] + "\\--Проект не выбран";
            }
            else
            {
                sTmp = mySub.comPath + mySub.curDirect;
                if (!Directory.Exists(sTmp))
                    Directory.CreateDirectory(sTmp);
                label2.Text = mySub.comPath + "\\" + mySub.curProject;
                //label2.Text = sPart[1] + "\\" + mySub.curProject;
                if (!File.Exists(mySub.tmpStr) && nProcess == 910)
                {
                    int num = (int)MessageBox.Show("Диск не выбран. Используйте 'Сменить диск'", "Кадастр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                LoadData();
                panel7.Invalidate();
            }
        }

        public void LoadData()
        {
            this.xmin = 9999999.9;
            this.ymin = 9999999.9;
            this.xmax = -9999999.9;
            this.ymax = -9999999.9;
            Cursor.Current = Cursors.WaitCursor;
            DllClass1.SetColour(this.mySub.brColor, this.mySub.pnColor);
            DllClass1.PointSymbLoad(this.mySub.fsymbPnt, out this.kSymbPnt, this.mySub.numRec, this.mySub.numbUser, this.mySub.heiSymb);
            this.mySub.kSymbPnt = this.kSymbPnt;
            DllClass1.LineSymbolLoad(this.mySub.fsymbLine, out this.kSymbLine, out this.hSymbLine, this.mySub.sSymbLine, this.mySub.x1Line, this.mySub.y1Line, this.mySub.x2Line, this.mySub.y2Line, this.mySub.xDescr, this.mySub.yDescr, this.mySub.x1Dens, this.mySub.y1Dens, this.mySub.x1Sign, this.mySub.y1Sign, this.mySub.x2Sign, this.mySub.y2Sign, this.mySub.n1Sign, this.mySub.n2Sign, this.mySub.iStyle1, this.mySub.iStyle2, this.mySub.iWidth1, this.mySub.iWidth2, this.mySub.nColLine, this.mySub.nItem, this.mySub.itemLoc, this.mySub.nBaseSymb, this.mySub.sInscr, this.mySub.hInscr, this.mySub.iColInscr, this.mySub.iDensity);
            this.mySub.PolySymbolLoad(this.mySub.fsymbPoly, out this.kPolySymb, out this.hSymbPoly);
            Cursor.Current = Cursors.WaitCursor;
            this.kInstall = 0;
            if (File.Exists(this.mySub.fPolyItem))
            {
                FileStream input = new FileStream(this.mySub.fPolyItem, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.kInstall = binaryReader.ReadInt32();
                    for (int index = 1; index <= this.kInstall; ++index)
                    {
                        this.mySub.nCent[index] = binaryReader.ReadInt32();
                        this.mySub.xLinParc[index] = binaryReader.ReadDouble();
                        this.mySub.yLinParc[index] = binaryReader.ReadDouble();
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
            this.mySub.PointLoad();
            this.kPntPlus = this.mySub.kPntPlus;
            this.kPntInput = this.mySub.kPntInput;
            this.mySub.LoadNode();
            this.kNode = this.mySub.kNodeTopo;
            if (this.kPntPlus < 2)
                return;
            this.xmin = this.mySub.xmin;
            this.ymin = this.mySub.ymin;
            this.xmax = this.mySub.xmax;
            this.ymax = this.mySub.ymax;
            this.zmin = this.mySub.zmin;
            this.zmax = this.mySub.zmax;
            this.mySub.LoadPntSour();
            this.kPntSource = this.mySub.kPntSource;
            this.kPntFin = 0;
            this.mySub.PointLoadFin();
            this.kPntFin = this.mySub.kPntFin;
            Cursor.Current = Cursors.WaitCursor;
            if (File.Exists(this.mySub.fpointInscr))
                File.Delete(this.mySub.fpointInscr);
            FileStream output1 = new FileStream(this.mySub.fpointInscr, FileMode.CreateNew);
            BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
            binaryWriter1.Write(this.kPntPlus);
            for (int index = 0; index <= this.kPntPlus; ++index)
            {
                this.mySub.xPntInscr[index] = this.mySub.xPnt[index];
                this.mySub.yPntInscr[index] = this.mySub.yPnt[index];
                this.mySub.iHorVerPnt[index] = 0;
                binaryWriter1.Write(this.mySub.xPnt[index]);
                binaryWriter1.Write(this.mySub.yPnt[index]);
                binaryWriter1.Write(this.mySub.iHorVerPnt[index]);
            }
            binaryWriter1.Close();
            output1.Close();
            this.mySub.LoadKeepInscr(2);
            Cursor.Current = Cursors.WaitCursor;
            if (this.kPntFin > 0)
                this.mySub.InscriptionFin(1);
            this.kPntProj = -1;
            this.mySub.PointProjLoad();
            this.kPntProj = this.mySub.kPntProj;
            this.kProjInput = this.mySub.kProjInput;
            this.kLineProj = 0;
            this.mySub.LineProjLoad();
            this.kLineProj = this.mySub.kLineProj;
            Cursor.Current = Cursors.WaitCursor;
            this.kItemCoord = 0;
            this.mySub.ItemLoadKeep(1);
            this.kItemCoord = this.mySub.kItemCoord;
            Cursor.Current = Cursors.WaitCursor;
            this.kPolyFinal = 0;
            this.mySub.PolyLoadFin();
            this.kPolyFinal = this.mySub.kPolyFinal;
            this.iPolyFinal = this.kPolyFinal;
            Cursor.Current = Cursors.WaitCursor;
            this.kLineFinal = 0;
            this.mySub.LineLoadFin();
            this.kLineFinal = this.mySub.kLineFinal;
            this.iLineFinal = this.kLineFinal;
            Cursor.Current = Cursors.WaitCursor;
            this.kLineInput = 0;
            this.mySub.LineLoad();
            this.kLineInput = this.mySub.kLineInput;
            if (this.kLineInput == 0)
            {
                this.kLineTopo = 0;
                if (File.Exists(this.mySub.flineTopo))
                    File.Delete(this.mySub.flineTopo);
                this.kLineFinal = 0;
                this.iLineFinal = 0;
                if (File.Exists(this.mySub.flineFinal))
                    File.Delete(this.mySub.flineFinal);
            }
            Cursor.Current = Cursors.WaitCursor;
            this.mySub.KeepLoadAction(1);
            this.nAction = this.mySub.nAction;
            if (this.nAction == 0)
            {
                this.mySub.kNodeTopo = this.kNode;
                this.mySub.KeepActionZero();
            }
            if (this.kLineInput > 0)
            {
                int kArray = 999999;
                DllClass1.doubleArray(this.mySub.xLin, ref kArray);
                DllClass1.doubleArray(this.mySub.yLin, ref kArray);
                int num = this.mySub.k2[this.kLineInput];
                if (num < 2 || num > kArray)
                {
                    this.kLineInput = 0;
                    if (File.Exists(this.mySub.fileLine))
                        File.Delete(this.mySub.fileLine);
                }
            }
            if (this.nAction > 0 && this.kPolyFinal == 0)
            {
                this.mySub.NodeActLoad(this.nAction);
                this.kNodeAct = this.mySub.kNodeAct;
                this.mySub.TopoActLoad(this.nAction);
                this.kLineAct = this.mySub.kLineAct;
                this.mySub.PolyActLoad(this.nAction);
                this.kPolyAct = this.mySub.kPolyAct;
                this.mySub.PolyCancelLoad(this.nAction);
                this.kPolyCancel = this.mySub.kPolyCancel;
                this.mySub.LineCancelLoad(this.nAction);
                this.kLineCancel = this.mySub.kLineCancel;
                this.mySub.LineNewLoad(this.nAction);
                this.kLineNew = this.mySub.kLineNew;
                DllClass1.LineFinal(this.kLineInput, this.mySub.nLineCode, this.mySub.nLongRad, this.mySub.sWidLine, this.mySub.dstLine, this.mySub.rRadLine, this.mySub.xRadLine, this.mySub.yRadLine, this.mySub.k1, this.mySub.k2, this.mySub.xLin, this.mySub.yLin, this.kLineAct, this.mySub.radAct, this.mySub.kActLine1, this.mySub.kActLine2, this.mySub.xLineAct, this.mySub.yLineAct, out this.kLineFinal, this.mySub.nCodeFin, this.mySub.nLongFin, this.mySub.sWidFin, this.mySub.distFin, this.mySub.rRadFin, this.mySub.xRadFin, this.mySub.yRadFin, this.mySub.k1Fin, this.mySub.k2Fin, this.mySub.xFin, this.mySub.yFin, this.mySub.nWork1, this.mySub.xWork1, this.mySub.yWork1, this.tolerance);
                DllClass1.PolyFinal(this.kPolyAct, this.mySub.nameAct, this.mySub.xAct, this.mySub.yAct, this.mySub.aActCalc, this.mySub.aActLeg, this.mySub.kActPoly1, this.mySub.kActPoly2, this.mySub.xPolyAct, this.mySub.yPolyAct, out this.kPolyFinal, this.mySub.namePolyFin, this.mySub.xLabFin, this.mySub.yLabFin, this.mySub.arCalcFin, this.mySub.arLegFin, this.mySub.nSymbFin, this.mySub.kt1Fin, this.mySub.kt2Fin, this.mySub.xPolFin, this.mySub.yPolFin);
            }
            this.kLineTopo = 0;
            this.mySub.LineTopoLoad();
            this.kLineTopo = this.mySub.kLineTopo;
            DllClass1.SymbolTrans(this.kLineInput, this.mySub.nLineCode, this.mySub.rRadLine, this.mySub.k1, this.mySub.k2, this.mySub.xLin, this.mySub.yLin, this.kLineTopo, this.mySub.nTopoCode, this.mySub.radLine, this.mySub.kl1, this.mySub.kl2, this.mySub.zLin, this.mySub.zPik, this.tolerance);
            this.kPoly = 0;
            this.mySub.PolygonLoad(ref this.mySub.kPolyInside);
            this.kPoly = this.mySub.kPoly;
            if (this.kPolyFinal == 0 && this.kPoly > 0)
            {
                this.kPolyFinal = this.kPoly;
                for (int index = 1; index <= this.kPoly; ++index)
                {
                    this.mySub.namePolyFin[index] = this.mySub.namePoly[index];
                    this.mySub.xLabFin[index] = this.mySub.xLab[index];
                    this.mySub.yLabFin[index] = this.mySub.yLab[index];
                    this.mySub.nSymbFin[index] = this.mySub.nSymbPoly[index];
                }
                DllClass1.LineFinal(this.kLineInput, this.mySub.nLineCode, this.mySub.nLongRad, this.mySub.sWidLine, this.mySub.dstLine, this.mySub.rRadLine, this.mySub.xRadLine, this.mySub.yRadLine, this.mySub.k1, this.mySub.k2, this.mySub.xLin, this.mySub.yLin, this.kLineTopo, this.mySub.radLine, this.mySub.kl1, this.mySub.kl2, this.mySub.zLin, this.mySub.zPik, out this.kLineFinal, this.mySub.nCodeFin, this.mySub.nLongFin, this.mySub.sWidFin, this.mySub.distFin, this.mySub.rRadFin, this.mySub.xRadFin, this.mySub.yRadFin, this.mySub.k1Fin, this.mySub.k2Fin, this.mySub.xFin, this.mySub.yFin, this.mySub.nWork, this.mySub.xWork, this.mySub.yWork, this.tolerance);
            }
            if (this.kLineFinal == 0 && this.kLineTopo > 0)
                DllClass1.LineFinal(this.kLineInput, this.mySub.nLineCode, this.mySub.nLongRad, this.mySub.sWidLine, this.mySub.dstLine, this.mySub.rRadLine, this.mySub.xRadLine, this.mySub.yRadLine, this.mySub.k1, this.mySub.k2, this.mySub.xLin, this.mySub.yLin, this.kLineTopo, this.mySub.radLine, this.mySub.kl1, this.mySub.kl2, this.mySub.zLin, this.mySub.zPik, out this.kLineFinal, this.mySub.nCodeFin, this.mySub.nLongFin, this.mySub.sWidFin, this.mySub.distFin, this.mySub.rRadFin, this.mySub.xRadFin, this.mySub.yRadFin, this.mySub.k1Fin, this.mySub.k2Fin, this.mySub.xFin, this.mySub.yFin, this.mySub.nWork, this.mySub.xWork, this.mySub.yWork, this.tolerance);
            if (this.kLineFinal == 0 && this.kLineTopo == 0)
            {
                this.kLineFinal = this.kLineInput;
                for (int index1 = 1; index1 <= this.kLineInput; ++index1)
                {
                    this.mySub.nCodeFin[index1] = this.mySub.nLineCode[index1];
                    this.mySub.nLongFin[index1] = this.mySub.nLongRad[index1];
                    this.mySub.sWidFin[index1] = this.mySub.sWidLine[index1];
                    this.mySub.distFin[index1] = this.mySub.dstLine[index1];
                    this.mySub.rRadFin[index1] = this.mySub.rRadLine[index1];
                    this.mySub.xRadFin[index1] = this.mySub.xRadLine[index1];
                    this.mySub.yRadFin[index1] = this.mySub.yRadLine[index1];
                    this.mySub.k1Fin[index1] = this.mySub.k1[index1];
                    this.mySub.k2Fin[index1] = this.mySub.k2[index1];
                    int num1 = this.mySub.k1[index1];
                    int num2 = this.mySub.k2[index1];
                    for (int index2 = num1; index2 <= num2; ++index2)
                    {
                        this.mySub.xFin[index2] = this.mySub.xLin[index2];
                        this.mySub.yFin[index2] = this.mySub.yLin[index2];
                    }
                }
                this.mySub.ItemLoadKeep(1);
                this.kItemCoord = this.mySub.kItemCoord;
            }
            this.mySub.AddInscrLoad();
            this.kAddInscript = this.mySub.kAddInscript;
            this.xminCur = this.xmin;
            this.yminCur = this.ymin;
            this.xmaxCur = this.xmax;
            this.ymaxCur = this.ymax;
            DllClass1.CoorWin(this.xmin, this.ymin, this.xmax, this.ymax, this.iWidth, this.iHeight, out this.scaleToWin, out this.scaleToGeo, out this.xBegX, out this.yBegY, out this.xEndX, out this.yEndY, out this.xBegWin, out this.yBegWin, out this.xEndWin, out this.yEndWin, out this.iCond);
            if (this.iCond < 0)
                this.iGraphic = 1;
            if (this.kSymbLine > 0)
            {
                DllClass1.LineItemCoor(this.mySub.fitemLine, this.mySub.nColorItm, this.mySub.ixSqu, this.mySub.iySqu, this.kLineFinal, this.mySub.rRadFin, this.mySub.k1Fin, this.mySub.k2Fin, this.mySub.xFin, this.mySub.yFin, this.mySub.nCodeFin, this.kSymbLine, this.mySub.nItem, this.mySub.n1Sign, this.mySub.n2Sign, this.mySub.iDensity, out this.kItemCoord, this.mySub.numSign, this.mySub.numItem, this.mySub.xItem, this.mySub.yItem, this.mySub.azItem, this.mySub.xAdd, this.mySub.yAdd, this.mySub.xDop, this.mySub.yDop, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.scaleToGeo);
                if (this.kItemCoord > 0)
                {
                    this.mySub.kItemCoord = this.kItemCoord;
                    this.mySub.ItemLoadKeep(2);
                }
            }
            this.nProblem = 0;
            if (File.Exists(this.mySub.fProblem) && File.Exists(this.mySub.fProblem))
            {
                FileStream input = new FileStream(this.mySub.fProblem, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.nProblem = binaryReader.ReadInt32();
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
            if (this.nProblem >= 30)
                return;
            this.nProblem = 40;
            if (File.Exists(this.mySub.fProblem))
                File.Delete(this.mySub.fProblem);
            FileStream output2 = new FileStream(this.mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
            binaryWriter2.Write(this.nProblem);
            binaryWriter2.Close();
            output2.Close();
        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine($"panel7_Paint[DEBUG]: sender = {sender} PaintEventArgs = {e}");
            Graphics graphics = e.Graphics;
            if (this.iGraphic > 0)
                return;
            Cursor.Current = Cursors.WaitCursor;
            if (this.kBorder > 2)
                DllClass1.DrawSelLine(e, this.kBorder, ref this.mySub.xBorder,
                    ref this.mySub.yBorder, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            if (this.kPntPlus > 0 && this.kPntFin == 0 && this.iPointOnOff > 0)
                DllClass1.PointsDraw(e, this.mySub.fsymbPnt, this.iHeightShow,
                    this.kPntPlus, this.mySub.namePnt, this.mySub.xPnt, this.mySub.yPnt, this.mySub.zPnt, 
                    this.mySub.xPntInscr, this.mySub.yPntInscr, this.mySub.iHorVerPnt, this.scaleToWin,
                    this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.mySub.nCode1, this.mySub.nCode2, 
                    this.kSymbPnt, this.mySub.numRec, this.mySub.numbUser, this.mySub.ixSqu, this.mySub.iySqu,
                    this.mySub.nColor, this.mySub.brColor, this.mySub.pnColor);
            if (this.kPntFin > 0 && this.iPointOnOff > 0)
                DllClass1.PointsDraw(e, this.mySub.fsymbPnt, this.iHeightShow,
                    this.kPntFin, this.mySub.namePntFin, this.mySub.xPntFin,
                    this.mySub.yPntFin, this.mySub.zPntFin, this.mySub.xPntInscr,
                    this.mySub.yPntInscr, this.mySub.iHorVerPnt, this.scaleToWin,
                    this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.mySub.nCode1Fin,
                    this.mySub.nCode2Fin, this.kSymbPnt, this.mySub.numRec, this.mySub.numbUser, 
                    this.mySub.ixSqu, this.mySub.iySqu, this.mySub.nColor, this.mySub.brColor, 
                    this.mySub.pnColor);
            if (this.kPolyFinal > 0 && this.iSymbols > 0)
                DllClass1.DrawPoly(e, this.mySub.fitemPoly, this.kPolyFinal,
                    this.mySub.namePolyFin, this.mySub.kt1Fin, this.mySub.kt2Fin,
                    this.mySub.xLabFin, this.mySub.yLabFin, this.mySub.arCalcFin, 
                    this.mySub.nSymbFin, this.mySub.iHorVer, this.mySub.xPolFin, 
                    this.mySub.yPolFin, this.mySub.ki1, this.mySub.ki2, this.mySub.xAdd,
                    this.mySub.yAdd, this.kPolySymb, this.mySub.npSign1, this.mySub.npSign2,
                    this.mySub.npItem, this.mySub.nBackCol, this.mySub.nOneSymb, this.mySub.ixSqu,
                    this.mySub.iySqu, this.mySub.nColorItm, this.scaleToWin, this.xBegX, this.yBegY, 
                    this.xBegWin, this.yBegWin, this.mySub.xDop, this.mySub.yDop, this.mySub.xWork, 
                    this.mySub.yWork, this.mySub.xWork1, this.mySub.yWork1, this.mySub.brColor, 
                    this.mySub.pnColor);
            if (this.kAddInscript > 0 && this.iSymbols > 0)
                DllClass1.AddInscrDraw(e, this.kAddInscript, this.mySub.sAddInscr, this.mySub.xAddInscr, this.mySub.yAddInscr, this.mySub.nHorVer, this.mySub.nInsCol, this.mySub.brColor, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            if (this.kLineFinal > 0 && this.iSymbols > 0)
            {
                DllClass1.DrawInputLine(e, this.kLineFinal, this.mySub.k1Fin, this.mySub.k2Fin, this.mySub.xFin, this.mySub.yFin, this.mySub.nCodeFin, this.mySub.sWidFin, this.mySub.rRadFin, this.mySub.xRadFin, this.mySub.yRadFin, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.mySub.nColLine, this.mySub.iWidth1, this.mySub.iWidth2, this.mySub.iStyle1, this.mySub.iStyle2, this.mySub.nBaseSymb, this.mySub.xAdd, this.mySub.yAdd, this.mySub.xDop, this.mySub.yDop, this.mySub.xWork2, this.mySub.yWork2, this.kSymbLine, this.mySub.n1Sign, this.mySub.n2Sign, this.mySub.brColor, this.mySub.pnColor, 0);
                if (this.kItemCoord > 0)
                    DllClass1.InputItemDraw(e, this.mySub.fitemLine, this.kItemCoord, this.mySub.numSign, this.mySub.numItem, this.mySub.xItem, this.mySub.yItem, this.mySub.azItem, this.mySub.itemLoc, this.mySub.nBaseSymb, this.mySub.sInscr, this.mySub.hInscr, this.mySub.iColInscr, this.kSymbLine, this.mySub.ixSqu, this.mySub.iySqu, this.mySub.nColorItm, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.mySub.nDop1, this.mySub.nDop2, this.mySub.brColor);
            }
            if (this.kLineFinal > 0 && this.iSymbols == 0)
            {
                int iPar = 1;
                DllClass1.LineDraw(e, this.kLineFinal, this.mySub.k1Fin, this.mySub.k2Fin, this.mySub.xFin, this.mySub.yFin, this.mySub.rRadFin, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.mySub.pnColor, iPar);
            }
            if (this.kPolyFinal > 0 && this.iSymbols == 0)
            {
                int iParam = 8;
                DllClass1.LabelDraw(e, this.kPolyFinal, this.mySub.namePolyFin, this.mySub.xLabFin, this.mySub.yLabFin, this.mySub.iHorVer, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.mySub.brColor, iParam);
            }
            if (this.kPntProj > -1 && this.iProjData > 0)
                this.DrawPntProj(e);
            if (this.kLineProj > 0 && this.iProjData > 0)
            {
                int iPar = 2;
                DllClass1.LineDraw(e, this.kLineProj, this.mySub.kPr1, this.mySub.kPr2, this.mySub.xLinProj, this.mySub.yLinProj, this.mySub.RadProj, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.mySub.pnColor, iPar);
            }
            if (this.kPolyCancel > 0 && this.iCancelPoly > 0)
            {
                int iParam = 3;
                DllClass1.LabelDraw(e, this.kPolyCancel, this.mySub.nameCanc, this.mySub.xLabCanc, this.mySub.yLabCanc, this.mySub.iHorVer, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.mySub.brColor, iParam);
                if (this.kLineCancel > 0)
                {
                    int iPar = 3;
                    DllClass1.LineDraw(e, this.kLineCancel, this.mySub.kLinCanc1, this.mySub.kLinCanc2, this.mySub.xLinCanc, this.mySub.yLinCanc, this.mySub.RadCanc, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, this.mySub.pnColor, iPar);
                }
            }
            if (File.Exists(this.mySub.fileContour) && this.iContourShow > 0)
                DllClass1.ContourDraw(e, this.mySub.fileContour, this.mySub.xDop, this.mySub.yDop, this.mySub.xOut, this.mySub.yOut, this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin);
            if (this.kInstall > 0 && this.iSymbols > 0)
            {
                string sTxt = "";
                for (int index1 = 1; index1 <= this.kInstall; ++index1)
                {
                    int nSelect = this.mySub.nCent[index1];
                    int xWin;
                    int yWin;
                    DllClass1.XYtoWIN(this.mySub.xLinParc[index1], this.mySub.yLinParc[index1], this.scaleToWin, this.xBegX, this.yBegY, this.xBegWin, this.yBegWin, out xWin, out yWin);
                    int kPix;
                    int mClr;
                    DllClass1.SelItemPoly(this.mySub.fitemPoly, nSelect, out int _, out int _, out int _, out kPix, this.mySub.ixSqu, this.mySub.iySqu, this.mySub.nColorItm, out sTxt, out mClr);
                    for (int index2 = 1; index2 <= kPix; ++index2)
                    {
                        int x = xWin + this.mySub.ixSqu[index2];
                        int y = yWin + this.mySub.iySqu[index2];
                        mClr = this.mySub.nColorItm[index2];
                        SolidBrush solidBrush = this.mySub.brColor[mClr];
                        graphics.FillRectangle((Brush)solidBrush, x, y, 1, 1);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
            if (!File.Exists(mySub.filePoint))
            {
                panel2.Text = string.Format("{0}", (object)e.X);
                panel4.Text = string.Format("{0}", (object)e.Y);
            }
            if (!File.Exists(mySub.filePoint))
                return;
            panel2.Text = string.Format("{0:F3}", (object)xCur);
            panel4.Text = string.Format("{0:F3}", (object)yCur);
        }

        private void DrawPntProj(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int xWin = 0;
            int yWin = 0;
            int emSize = 6;
            SolidBrush solidBrush = new SolidBrush(Color.Red);
            for (int index = 0; index <= kPntProj; ++index)
            {
                if (double.IsNaN(mySub.xProj[index]) || double.IsNaN(mySub.yProj[index]))
                {
                    int num = (int)MessageBox.Show("Проверить данные");
                    iGraphic = 1;
                    break;
                }
                DllClass1.XYtoWIN(mySub.xProj[index], mySub.yProj[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                {
                    graphics.FillRectangle((Brush)solidBrush, xWin - 2, yWin - 2, 4, 4);
                    graphics.DrawString(mySub.nameProj[index], new Font("Bold", (float)emSize), (Brush)solidBrush, (float)(xWin + emSize / 2), (float)(yWin - emSize));
                }
            }
        }

        private void Points_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)MessageBox.Show("Диск не выбран", "Создание проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new PointSign().ShowDialog((IWin32Window)this);
                LoadData();
                panel7.Invalidate();
            }
        }

        private void Lines_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)MessageBox.Show("Диск не выбран", "Создание проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new LineSign().ShowDialog((IWin32Window)this);
                LoadData();
                panel7.Invalidate();
            }
        }

        private void Polygons_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)MessageBox.Show("Диск не выбран", "Создание проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new PolygonSign().ShowDialog((IWin32Window)this);
                LoadData();
                panel7.Invalidate();
            }
        }

        //private void FilePoints_Click(object sender, EventArgs e)
        //{
        //    string text = "Точки: ";
        //    mySub.FilePath();
        //    nProcess = 910;
        //    if (File.Exists(mySub.fileProcess))
        //        File.Delete(mySub.fileProcess);
        //    FileStream output1 = new FileStream(mySub.fileProcess, FileMode.CreateNew);
        //    BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
        //    binaryWriter1.Write(nProcess);
        //    binaryWriter1.Close();
        //    output1.Close();
        //    if (!File.Exists(mySub.fileProj))
        //    {
        //        int num1 = (int)MessageBox.Show("Проект не выбран", "Загрузка данных из файла", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    else
        //    {
        //        DllClass1.PointsInput(out mySub.kPntPlus, out mySub.kPntInput, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt, mySub.nCode1, mySub.nCode2,
        //            out mySub.kHeight, mySub.nameHeig, mySub.xHeig, mySub.yHeig, mySub.zHeig, out mySub.xmin, out mySub.ymin, out mySub.xmax, out mySub.ymax,
        //            out mySub.zmin, out mySub.zmax, out iCond);
        //        if (iCond < 0)
        //            return;
        //        kPntPlus = mySub.kPntPlus;
        //        kPntInput = mySub.kPntInput;
        //        kHeight = mySub.kHeight;
        //        xmin = mySub.xmin;
        //        ymin = mySub.ymin;
        //        xmax = mySub.xmax;
        //        ymax = mySub.ymax;
        //        zmin = mySub.zmin;
        //        zmax = mySub.zmax;
        //        int num2 = 0;
        //        for (int index = 1; index <= kPntPlus; ++index)
        //        {
        //            if (mySub.nCode1[index] > 0)
        //            {
        //                int kPix;
        //                DllClass1.SelSymbPnt(mySub.fsymbPnt, mySub.nCode1[index], kSymbPnt, mySub.numRec, mySub.numbUser,
        //                    out int _, out int _, out int _, out string _, out kPix, mySub.ixSqu, mySub.iySqu, mySub.nColor, out string _, out int _);
        //                if (kPix == 0)
        //                {
        //                    ++num2;
        //                    text = text + mySub.namePnt[index] + ", ";
        //                }
        //            }
        //        }
        //        if (num2 > 0)
        //        {
        //            int num3 = (int)MessageBox.Show(text, "Ошибка кода символов точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //        mySub.FilesRemove();
        //        mySub.AllActionRemove();
        //        DllClass1.KeepPntHeig(mySub.filePoint, mySub.fileHeight, ref mySub.xmin, ref mySub.ymin, ref mySub.xmax,
        //            ref mySub.ymax, ref mySub.zmin, ref mySub.zmax, mySub.kPntPlus, mySub.kPntInput, mySub.namePnt, mySub.xPnt,
        //            mySub.yPnt, mySub.zPnt, mySub.nCode1, mySub.nCode2, ref mySub.kHeight, mySub.nameHeig, mySub.xHeig, mySub.yHeig, mySub.zHeig);
        //        kHeight = mySub.kHeight;
        //        if (iCond < 0)
        //        {
        //            iGraphic = 1;
        //        }
        //        else
        //        {
        //            kPntPlus = mySub.kPntPlus;
        //            mySub.FilePath();
        //            panel1.Text = "******СОРТИРОВКА ТОЧЕК*******";
        //            mySub.HeightSorting();
        //            kHeight = mySub.kHeight;
        //            panel1.Text = "Готово......";
        //            kPntSource = kPntPlus;
        //            for (int index = 0; index <= kPntSource; ++index)
        //            {
        //                mySub.nameSour[index] = mySub.namePnt[index];
        //                mySub.xSour[index] = mySub.xPnt[index];
        //                mySub.ySour[index] = mySub.yPnt[index];
        //                mySub.zSour[index] = mySub.zPnt[index];
        //                mySub.nSour1[index] = mySub.nCode1[index];
        //                mySub.nSour2[index] = mySub.nCode2[index];
        //            }
        //            mySub.kPntSource = kPntSource;
        //            mySub.KeepPntSour();
        //            LoadData();
        //            iPointOnOff = 1;
        //            nProblem = 31;
        //            if (File.Exists(mySub.fProblem))
        //                File.Delete(mySub.fProblem);
        //            FileStream output2 = new FileStream(mySub.fProblem, FileMode.CreateNew);
        //            BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
        //            binaryWriter2.Write(nProblem);
        //            binaryWriter2.Close();
        //            output2.Close();
        //            panel7.Invalidate();
        //        }
        //    }
        //}
        private void FilePoints_Click(object sender, EventArgs e)
        {
            string text = "Points: ";
            this.mySub.FilePath();
            this.nProcess = 910;
            if (File.Exists(this.mySub.fileProcess))
                File.Delete(this.mySub.fileProcess);
            FileStream output1 = new FileStream(this.mySub.fileProcess, FileMode.CreateNew);
            BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
            binaryWriter1.Write(this.nProcess);
            binaryWriter1.Close();
            output1.Close();
            if (!File.Exists(this.mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Project wasn't defined", "Data File Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DllClass1.PointsInput(out this.mySub.kPntPlus, out this.mySub.kPntInput, this.mySub.namePnt, this.mySub.xPnt, this.mySub.yPnt, this.mySub.zPnt, this.mySub.nCode1, this.mySub.nCode2, out this.mySub.kHeight, this.mySub.nameHeig, this.mySub.xHeig, this.mySub.yHeig, this.mySub.zHeig, out this.mySub.xmin, out this.mySub.ymin, out this.mySub.xmax, out this.mySub.ymax, out this.mySub.zmin, out this.mySub.zmax, out this.iCond);
                if (this.iCond < 0)
                    return;
                this.kPntPlus = this.mySub.kPntPlus;
                this.kPntInput = this.mySub.kPntInput;
                this.kHeight = this.mySub.kHeight;
                this.xmin = this.mySub.xmin;
                this.ymin = this.mySub.ymin;
                this.xmax = this.mySub.xmax;
                this.ymax = this.mySub.ymax;
                this.zmin = this.mySub.zmin;
                this.zmax = this.mySub.zmax;
                int num2 = 0;
                for (int index = 1; index <= this.kPntPlus; ++index)
                {
                    if (this.mySub.nCode1[index] > 0)
                    {
                        int kPix;
                        DllClass1.SelSymbPnt(this.mySub.fsymbPnt, this.mySub.nCode1[index], this.kSymbPnt, this.mySub.numRec, this.mySub.numbUser, out int _, out int _, out int _, out string _, out kPix, this.mySub.ixSqu, this.mySub.iySqu, this.mySub.nColor, out string _, out int _);
                        if (kPix == 0)
                        {
                            ++num2;
                            text = text + this.mySub.namePnt[index] + ", ";
                        }
                    }
                }
                if (num2 > 0)
                {
                    int num3 = (int)MessageBox.Show(text, "Code's error of points' symbols", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.mySub.FilesRemove();
                this.mySub.AllActionRemove();
                DllClass1.KeepPntHeig(this.mySub.filePnt, this.mySub.fileHeight, ref this.mySub.xmin, ref this.mySub.ymin, ref this.mySub.xmax, ref this.mySub.ymax, ref this.mySub.zmin, ref this.mySub.zmax, this.mySub.kPntPlus, this.mySub.kPntInput, this.mySub.namePnt, this.mySub.xPnt, this.mySub.yPnt, this.mySub.zPnt, this.mySub.nCode1, this.mySub.nCode2, ref this.mySub.kHeight, this.mySub.nameHeig, this.mySub.xHeig, this.mySub.yHeig, this.mySub.zHeig);
                this.kHeight = this.mySub.kHeight;
                if (this.iCond < 0)
                {
                    this.iGraphic = 1;
                }
                else
                {
                    this.kPntPlus = this.mySub.kPntPlus;
                    this.mySub.FilePath();
                    this.panel1.Text = "******POINTS SORTING*******";
                    this.mySub.HeightSorting();
                    this.kHeight = this.mySub.kHeight;
                    this.panel1.Text = "Готов......";
                    this.kPntSource = this.kPntPlus;
                    for (int index = 0; index <= this.kPntSource; ++index)
                    {
                        this.mySub.nameSour[index] = this.mySub.namePnt[index];
                        this.mySub.xSour[index] = this.mySub.xPnt[index];
                        this.mySub.ySour[index] = this.mySub.yPnt[index];
                        this.mySub.zSour[index] = this.mySub.zPnt[index];
                        this.mySub.nSour1[index] = this.mySub.nCode1[index];
                        this.mySub.nSour2[index] = this.mySub.nCode2[index];
                    }
                    this.mySub.kPntSource = this.kPntSource;
                    this.mySub.KeepPntSour();
                    this.LoadData();
                    this.iPointOnOff = 1;
                    this.nProblem = 31;
                    if (File.Exists(this.mySub.fProblem))
                        File.Delete(this.mySub.fProblem);
                    FileStream output2 = new FileStream(this.mySub.fProblem, FileMode.CreateNew);
                    BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                    binaryWriter2.Write(this.nProblem);
                    binaryWriter2.Close();
                    output2.Close();
                    this.panel7.Invalidate();
                }
            }
        }

        private void AddPoints_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "Добавление точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Добавление точек из файла", "Добавление точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mySub.FilePath();
                nProcess = 920;
                if (File.Exists(mySub.fileProcess))
                    File.Delete(mySub.fileProcess);
                FileStream output1 = new FileStream(mySub.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                binaryWriter1.Write(nProcess);
                binaryWriter1.Close();
                output1.Close();
                int num3 = (int)new AddPoints().ShowDialog((IWin32Window)this);
                LoadData();
                nProblem = 32;
                if (File.Exists(mySub.fProblem))
                    File.Delete(mySub.fProblem);
                FileStream output2 = new FileStream(mySub.fProblem, FileMode.CreateNew);
                BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                binaryWriter2.Write(nProblem);
                binaryWriter2.Close();
                output2.Close();
                panel7.Invalidate();
            }
        }

        private void ViewPoints_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Загрузка точек из файла", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                iPointOnOff = iPointOnOff <= 0 ? 1 : 0;
                panel7.Invalidate();
            }
        }

        private void ViewHeights_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Добавление точек из файла", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                iHeightShow = iHeightShow <= 0 ? 1 : 0;
                panel7.Invalidate();
            }
        }

        private void ViewContours_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Добавление точек из файла", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(mySub.fileContour))
            {
                int num3 = (int)MessageBox.Show("Нет данных", "Кадастр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                iContourShow = iContourShow <= 0 ? 1 : 0;
                panel7.Invalidate();
            }
        }

        private void ViewLines_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kLineInput < 1)
            {
                int num2 = (int)MessageBox.Show("Нет данных", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                iSymbols = iSymbols <= 0 ? 1 : 0;
                panel7.Invalidate();
            }
        }

        private void ViewDesigns_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Ввод исходных данных", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntProj < 0 && kLineProj < 1)
            {
                int num3 = (int)MessageBox.Show("Нет данных", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                iProjData = iProjData <= 0 ? 1 : 0;
                panel7.Invalidate();
            }
        }

        private void ViewCancelled_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "Просомтр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Ввод исходных данных", "Просмотр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mySub.KeepLoadAction(1);
                nAction = mySub.nAction;
                mySub.CancPolyFin(nAction);
                mySub.CancPolyFinLoad();
                kPolyCancel = mySub.kPolyCancel;
                if (kPolyCancel < 1)
                {
                    int num3 = (int)MessageBox.Show("Нет данных", "Кадастр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    mySub.CancLineFin(nAction);
                    mySub.CancLineFinLoad();
                    kLineCancel = mySub.kLineCancel;
                    iCancelPoly = iCancelPoly <= 0 ? 1 : 0;
                    panel7.Invalidate();
                }
            }
        }

        private void PointsLines_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "От точек к линиям", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Добавление точек из файла", "От точек к линиям", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mySub.FilePath();
                nProcess = 940;
                if (File.Exists(mySub.fileProcess))
                    File.Delete(mySub.fileProcess);
                FileStream output1 = new FileStream(mySub.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                binaryWriter1.Write(nProcess);
                binaryWriter1.Close();
                output1.Close();
                int num3 = (int)new LinesForm().ShowDialog((IWin32Window)this);
                nProblem = 41;
                if (File.Exists(mySub.fProblem))
                    File.Delete(mySub.fProblem);
                FileStream output2 = new FileStream(mySub.fProblem, FileMode.CreateNew);
                BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                binaryWriter2.Write(nProblem);
                binaryWriter2.Close();
                output2.Close();
                LoadData();
                panel7.Invalidate();
            }
        }

        private void PolyTopology_Click(object sender, EventArgs e)
        {
            mySub.FilePath();
            if (!File.Exists(mySub.fileLine))
            {
                int num1 = (int)MessageBox.Show("Вернуться к 'От точек к линиям'", "Построение топологий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 950;
                if (File.Exists(mySub.fileProcess))
                    File.Delete(mySub.fileProcess);
                FileStream output1 = new FileStream(mySub.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                binaryWriter1.Write(nProcess);
                binaryWriter1.Close();
                output1.Close();
                int num2 = (int)new PolyTopo().ShowDialog((IWin32Window)this);
                nProblem = 42;
                if (File.Exists(mySub.fProblem))
                    File.Delete(mySub.fProblem);
                FileStream output2 = new FileStream(mySub.fProblem, FileMode.CreateNew);
                BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                binaryWriter2.Write(nProblem);
                binaryWriter2.Close();
                output2.Close();
                LoadData();
                panel7.Invalidate();
            }
        }

        private void ProjPointsInput_Click(object sender, EventArgs e)
        {
            if (kPntPlus < 1)
            {
                int num1 = (int)MessageBox.Show("Добавление точек из файла", "Точки проектирования", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mySub.FilePath();
                nProcess = 960;
                if (File.Exists(mySub.fileProcess))
                    File.Delete(mySub.fileProcess);
                FileStream output1 = new FileStream(mySub.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                binaryWriter1.Write(nProcess);
                binaryWriter1.Close();
                output1.Close();
                if (!File.Exists(mySub.fileProj))
                {
                    int num2 = (int)MessageBox.Show("Проект не выбранd", "Ввод файла проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    mySub.PointsDesign(out iCond);
                    if (iCond < 0)
                        return;
                    nProblem = 61;
                    if (File.Exists(mySub.fProblem))
                        File.Delete(mySub.fProblem);
                    FileStream output2 = new FileStream(mySub.fProblem, FileMode.CreateNew);
                    BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                    binaryWriter2.Write(nProblem);
                    binaryWriter2.Close();
                    output2.Close();
                    mySub.FilePath();
                    LoadData();
                    panel7.Invalidate();
                }
            }
        }

        private void ProjAddPoints_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "Дополнительные точки дизайна/проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Загрузка точек из файла", "Точки проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mySub.FilePath();
                nProcess = 970;
                if (File.Exists(mySub.fileProcess))
                    File.Delete(mySub.fileProcess);
                FileStream output1 = new FileStream(mySub.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                binaryWriter1.Write(nProcess);
                binaryWriter1.Close();
                output1.Close();
                int num3 = (int)new AddPoints().ShowDialog((IWin32Window)this);
                nProblem = 62;
                if (File.Exists(mySub.fProblem))
                    File.Delete(mySub.fProblem);
                FileStream output2 = new FileStream(mySub.fProblem, FileMode.CreateNew);
                BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                binaryWriter2.Write(nProblem);
                binaryWriter2.Close();
                output2.Close();
                LoadData();
                panel7.Invalidate();
            }
        }

        private void ProjLinesForm_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "От точек к линиям", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Загрузка точек из файла", "Тотчки проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPoly == 0)
            {
                int num3 = (int)MessageBox.Show("Полигональная топология не создана", "Линии проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mySub.FilePath();
                nProcess = 980;
                int num4 = (int)new DesignLine().ShowDialog((IWin32Window)this);
                nProblem = 63;
                if (File.Exists(mySub.fProblem))
                    File.Delete(mySub.fProblem);
                FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(nProblem);
                binaryWriter.Close();
                output.Close();
                LoadData();
                panel7.Invalidate();
            }
        }

        private void ActionParcel_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "От точек к линиям", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Загрузка точек из файла", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPoly == 0)
            {
                int num3 = (int)MessageBox.Show("Полигональная топология не создана", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mySub.FilePath();
                nProcess = 110;
                if (File.Exists(mySub.fileProcess))
                    File.Delete(mySub.fileProcess);
                FileStream output1 = new FileStream(mySub.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                binaryWriter1.Write(nProcess);
                binaryWriter1.Close();
                output1.Close();
                sTmp = mySub.factPol;
                sTmp = sTmp + "." + string.Format("{0}", (object)1);
                if (File.Exists(sTmp) && MessageBox.Show("Окончательные результаты были созданы.Хотите продолжить процесс действий с участками? ?", "Действия с участками", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    panel7.Invalidate();
                }
                else
                {
                    int num4 = (int)new ParcelAction().ShowDialog((IWin32Window)this);
                    nProblem = 71;
                    if (File.Exists(mySub.fProblem))
                        File.Delete(mySub.fProblem);
                    FileStream output2 = new FileStream(mySub.fProblem, FileMode.CreateNew);
                    BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                    binaryWriter2.Write(nProblem);
                    binaryWriter2.Close();
                    output2.Close();
                    LoadData();
                    panel7.Invalidate();
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        private void ModelRelief_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не определен", "От точек к линиям", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(mySub.fileHeight))
            {
                int num2 = (int)MessageBox.Show("Точек высоты недостаточно:", "Добавить контурные линии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                panel1.Text = "**********************Пожалуйста.... Подождите*************************";
                mySub.HeightSorting();
                kHeight = mySub.kHeight;
                if (kHeight < 4)
                {
                    int num3 = (int)MessageBox.Show("Точек высоты не достаточно", "Добавьте контурные линии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int num4 = (int)new CadContours().ShowDialog((IWin32Window)this);
                    if (File.Exists(mySub.fileContour))
                    {
                        nProblem = 51;
                        if (File.Exists(mySub.fProblem))
                            File.Delete(mySub.fProblem);
                        FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
                        BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                        binaryWriter.Write(nProblem);
                        binaryWriter.Close();
                        output.Close();
                    }
                    LoadData();
                    iContourShow = 1;
                    panel1.Text = "Готов";
                    panel7.Invalidate();
                }
            }
        }

        private void ContourRemove_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                MessageBox.Show("Проект не выбран", "От точек к линиям", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(mySub.fileContour) && MessageBox.Show("Вы действительно хотите удалить контурные линии?", "Удаление контурных линий", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                if (File.Exists(mySub.fileContour))
                    File.Delete(mySub.fileContour);
                iContourShow = 0;
                panel7.Invalidate();
            }
        }

        private void FinalResult_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "От точек к линиям", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Загрузка точек из файла", "Исправление и печать", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mySub.FilePath();
                nProcess = 130;
                if (File.Exists(mySub.fileProcess))
                    File.Delete(mySub.fileProcess);
                FileStream output = new FileStream(mySub.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(nProcess);
                binaryWriter.Close();
                output.Close();
                int num3 = (int)new FinalResult().ShowDialog((IWin32Window)this);
                LoadData();
                panel7.Invalidate();
            }
        }

        private void PrintMap_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.flineFinal))
            {
                int num1 = (int)MessageBox.Show("Проверить конечный результат", "Щелкните 'Окончательный результат коррекции'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new MapScale().ShowDialog((IWin32Window)this);
            }
        }

        private void AllActDelete_Click(object sender, EventArgs e)
        {
            if (nAction == 0)
            {
                int num1 = (int)MessageBox.Show("Все изменения удалены", "Действия с участками", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Вы действительно хотите удалить все изменения ?", "Действия с участками", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                mySub.AllActionRemove();
                nAction = 0;
                mySub.nAction = nAction;
                mySub.KeepLoadAction(2);
                mySub.nAction = nAction;
                mySub.kPoly = kPoly;
                mySub.kNode = kNode;
                mySub.KeepActionZero();
                kLineAct = mySub.kLineAct;
                kPolyAct = mySub.kPolyAct;
                kIntAct = mySub.kIntAct;
                kNodeAct = mySub.kNodeAct;
                nProcess = 0;
                kLineCancel = 0;
                kLineNew = 0;
                kPolyCancel = 0;
                if (File.Exists(mySub.flineFinal))
                    File.Delete(mySub.flineFinal);
                kLineFinal = 0;
                if (File.Exists(mySub.fpolyFinal))
                    File.Delete(mySub.fpolyFinal);
                kPolyFinal = 0;
                if (File.Exists(mySub.flistAction))
                    File.Delete(mySub.flistAction);
                if (File.Exists(mySub.fCancLine))
                    File.Delete(mySub.fCancLine);
                if (File.Exists(mySub.fCancPoly))
                    File.Delete(mySub.fCancPoly);
                if (File.Exists(mySub.fInscrFin))
                    File.Delete(mySub.fInscrFin);
                panel1.Text = "Готов ...";
                if (File.Exists(mySub.flistAction))
                    File.Delete(mySub.flistAction);
                FileStream output = new FileStream(mySub.flistAction, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                sTmp = "0";
                binaryWriter.Write(sTmp);
                binaryWriter.Close();
                output.Close();
                mySub.PolygonLoad(ref mySub.kPolyInside);
                if (mySub.kPoly == 0 && File.Exists(mySub.fsourcePoly))
                    File.Delete(mySub.fsourcePoly);
                kPolySource = mySub.kPoly;
                if (mySub.kPoly > 0)
                {
                    for (int index1 = 1; index1 <= mySub.kPoly; ++index1)
                    {
                        mySub.nameSource[index1] = mySub.namePoly[index1];
                        mySub.xLabSource[index1] = mySub.xLab[index1];
                        mySub.yLabSource[index1] = mySub.yLab[index1];
                        mySub.arCalcSource[index1] = mySub.areaPol[index1];
                        mySub.arLegSource[index1] = mySub.areaLeg[index1];
                        mySub.k1Source[index1] = mySub.kt1[index1];
                        mySub.k2Source[index1] = mySub.kt2[index1];
                        int num2 = mySub.k1Source[index1];
                        int num3 = mySub.k2Source[index1];
                        for (int index2 = num2; index2 <= num3; ++index2)
                        {
                            mySub.xSource[index2] = mySub.xPol[index2];
                            mySub.ySource[index2] = mySub.yPol[index2];
                        }
                    }
                    mySub.kPolySource = kPolySource;
                    mySub.LoadKeepSource(2);
                    maxParcel = 0;
                }
                if (kPolySource == 0)
                {
                    kPolyAct = 0;
                    maxParcel = 0;
                }
                if (kPolyAct > 0)
                {
                    int kPnt = -1;
                    for (int index = 1; index <= kPolyAct; ++index)
                    {
                        ++kPnt;
                        mySub.nameDop[kPnt] = mySub.nameAct[index];
                    }
                    DllClass1.NewPointName(kPnt, mySub.nameDop, out maxParcel, out sTmp);
                    --maxParcel;
                }
                LoadData();
                panel7.Invalidate();
            }
        }

        private void AllDesignDel_Click(object sender, EventArgs e)
        {
            if (kPntProj < 0 && kLineProj == 0)
            {
                int num = (int)MessageBox.Show("Все данные проектирования были удалены", "Формирование проектных данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nProcess = 0;
                panel7.Invalidate();
            }
            else
            {
                if ((File.Exists(mySub.fpointProj) || File.Exists(mySub.flineProj)) && MessageBox.Show("Вы действительно хотите удалить все данные проектирования?", "Формирование проектных линий", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                if (File.Exists(mySub.fpointProj))
                    File.Delete(mySub.fpointProj);
                kPntProj = -1;
                kProjInput = -1;
                if (File.Exists(mySub.flineProj))
                {
                    File.Delete(mySub.flineProj);
                    kLineProj = 0;
                }
                if (File.Exists(mySub.fnodeProj))
                    File.Delete(mySub.fnodeProj);
                if (File.Exists(mySub.ftopoProj))
                {
                    File.Delete(mySub.ftopoProj);
                    mySub.kTopoProj = 0;
                }
                if (File.Exists(mySub.fpolyProj))
                {
                    File.Delete(mySub.fpolyProj);
                    mySub.kPolyProj = 0;
                }
                nProcess = 0;
                LoadData();
                panel7.Invalidate();
            }
        }

        private void GeoData_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран", "Передача файла", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mySub.FilePath();
                DllClass1.DriveList(out kDrive, out sDrive);
                sTmp = "";
                for (int index = 1; index <= kDrive; ++index)
                {
                    sTmp = sDrive[index] + "Diplom_Geo\\brdrive.dat";
                    //sTmp = sDrive[index] + "Diplom_Geo\\brdriv.dat";
                    if (File.Exists(sTmp))
                        break;
                }
                if (!File.Exists(sTmp))
                {
                    int num2 = (int)MessageBox.Show("Поля проектов не созданы", "Передача Данных полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    iGraphic = 0;
                    int num3 = 0;
                    FileStream input = new FileStream(sTmp, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    string path1 = binaryReader.ReadString();
                    binaryReader.Close();
                    input.Close();
                    nameDir = Directory.GetDirectories(path1);
                    if (nameDir.Length < 0)
                        return;
                    for (int index = 0; index < nameDir.Length; ++index)
                    {
                        string path2 = nameDir[index];
                        if (Directory.Exists(path2))
                        {
                            string path3 = path2 + "\\ftah.pnt";
                            if (File.Exists(path3))
                            {
                                nameFiles = File.ReadAllLines(path3);
                                int num4 = 0;
                                foreach (string nameFile in nameFiles)
                                    ++num4;
                                if (num4 > 0)
                                    ++num3;
                            }
                        }
                    }
                    if (num3 == 0)
                    {
                        int num5 = (int)MessageBox.Show("Нет геодезических проектов", "Передача данных полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int num6 = (int)new FieldProject().ShowDialog((IWin32Window)this);
                        mySub.FilePath();
                        mySub.PointLoad();
                        kPntPlus = mySub.kPntPlus;
                        kPntSource = kPntPlus;
                        for (int index = 0; index <= kPntSource; ++index)
                        {
                            mySub.nameSour[index] = mySub.namePnt[index];
                            mySub.xSour[index] = mySub.xPnt[index];
                            mySub.ySour[index] = mySub.yPnt[index];
                            mySub.zSour[index] = mySub.zPnt[index];
                            mySub.nSour1[index] = mySub.nCode1[index];
                            mySub.nSour2[index] = mySub.nCode2[index];
                        }
                        mySub.kPntSource = kPntSource;
                        mySub.KeepPntSour();
                        LoadData();
                        kPntFin = 0;
                        if (File.Exists(mySub.fileContour))
                            File.Delete(mySub.fileContour);
                        if (File.Exists(mySub.fpointFinal))
                            File.Delete(mySub.fpointFinal);
                        if (File.Exists(mySub.fInscrFin))
                            File.Delete(mySub.fInscrFin);
                        iPointOnOff = 1;
                        nProblem = 33;
                        if (File.Exists(mySub.fProblem))
                            File.Delete(mySub.fProblem);
                        FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
                        BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                        binaryWriter.Write(nProblem);
                        binaryWriter.Close();
                        output.Close();
                        panel7.Invalidate();
                    }
                }
            }
        }

        private void AeroData_Click(object sender, EventArgs e)
        {
            nProcess = 0;
            mySub.FilePath();
            if (!File.Exists(mySub.fbaseDtm))
            {
                int num = (int)MessageBox.Show("Данные аэротриангуляции отсутствуют", "Архив DTM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                groupBox10.Visible = true;
                iParam = 1;
                ListStore(iParam, out kModStore, sModStore, kSelModel, sSelModel);
                if (kModStore == 0)
                {
                    iGraphic = 1;
                }
                else
                {
                    for (int index = 1; index <= kModStore; ++index)
                    {
                        if (index == 1)
                        {
                            checkBox1.Text = sModStore[index];
                            checkBox1.Checked = true;
                        }
                        if (index == 2)
                        {
                            checkBox2.Text = sModStore[index];
                            checkBox2.Checked = true;
                        }
                        if (index == 3)
                        {
                            checkBox3.Text = sModStore[index];
                            checkBox3.Checked = true;
                        }
                        if (index == 4)
                        {
                            checkBox4.Text = sModStore[index];
                            checkBox4.Checked = true;
                        }
                        if (index == 5)
                        {
                            checkBox5.Text = sModStore[index];
                            checkBox5.Checked = true;
                        }
                        if (index == 6)
                        {
                            checkBox6.Text = sModStore[index];
                            checkBox6.Checked = true;
                        }
                        if (index == 7)
                        {
                            checkBox7.Text = sModStore[index];
                            checkBox7.Checked = true;
                        }
                        if (index == 8)
                        {
                            checkBox8.Text = sModStore[index];
                            checkBox8.Checked = true;
                        }
                        if (index == 9)
                        {
                            checkBox9.Text = sModStore[index];
                            checkBox9.Checked = true;
                        }
                        if (index == 10)
                        {
                            checkBox10.Text = sModStore[index];
                            checkBox10.Checked = true;
                        }
                        if (index == 11)
                        {
                            checkBox11.Text = sModStore[index];
                            checkBox11.Checked = true;
                        }
                        if (index == 12)
                        {
                            checkBox12.Text = sModStore[index];
                            checkBox12.Checked = true;
                        }
                        if (index == 13)
                        {
                            checkBox13.Text = sModStore[index];
                            checkBox13.Checked = true;
                        }
                        if (index == 14)
                        {
                            checkBox14.Text = sModStore[index];
                            checkBox14.Checked = true;
                        }
                        if (index == 15)
                        {
                            checkBox15.Text = sModStore[index];
                            checkBox15.Checked = true;
                        }
                        if (index == 16)
                        {
                            checkBox16.Text = sModStore[index];
                            checkBox16.Checked = true;
                        }
                        if (index == 17)
                        {
                            checkBox17.Text = sModStore[index];
                            checkBox17.Checked = true;
                        }
                        if (index == 18)
                        {
                            checkBox18.Text = sModStore[index];
                            checkBox18.Checked = true;
                        }
                        if (index == 19)
                        {
                            checkBox19.Text = sModStore[index];
                            checkBox19.Checked = true;
                        }
                        if (index == 20)
                        {
                            checkBox20.Text = sModStore[index];
                            checkBox20.Checked = true;
                        }
                        if (index == 21)
                        {
                            checkBox21.Text = sModStore[index];
                            checkBox21.Checked = true;
                        }
                        if (index == 22)
                        {
                            checkBox22.Text = sModStore[index];
                            checkBox22.Checked = true;
                        }
                        if (index == 23)
                        {
                            checkBox23.Text = sModStore[index];
                            checkBox23.Checked = true;
                        }
                        if (index == 24)
                        {
                            checkBox24.Text = sModStore[index];
                            checkBox24.Checked = true;
                        }
                        if (index == 25)
                        {
                            checkBox25.Text = sModStore[index];
                            checkBox25.Checked = true;
                        }
                        if (index == 26)
                        {
                            checkBox26.Text = sModStore[index];
                            checkBox26.Checked = true;
                        }
                        if (index == 27)
                        {
                            checkBox27.Text = sModStore[index];
                            checkBox27.Checked = true;
                        }
                        if (index == 28)
                        {
                            checkBox28.Text = sModStore[index];
                            checkBox28.Checked = true;
                        }
                        if (index == 29)
                        {
                            checkBox29.Text = sModStore[index];
                            checkBox29.Checked = true;
                        }
                        if (index == 30)
                        {
                            checkBox30.Text = sModStore[index];
                            checkBox30.Checked = true;
                        }
                    }
                }
            }
        }

        public void ListStore(
          int iParam,
          out int kModStore,
          string[] sModStore,
          int kSelModel,
          string[] sSelModel)
        {
            int num1;
            int num2 = num1 = 0;
            string str1 = "";
            kPntPlus = -1;
            kModStore = 0;
            if (iParam == 1 && File.Exists(mySub.fbaseDtm))
            {
                FileStream input = new FileStream(mySub.fbaseDtm, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    xmin = binaryReader.ReadDouble();
                    ymin = binaryReader.ReadDouble();
                    xmax = binaryReader.ReadDouble();
                    ymax = binaryReader.ReadDouble();
                    zmin = binaryReader.ReadDouble();
                    zmax = binaryReader.ReadDouble();
                    int num3;
                    while ((num3 = binaryReader.ReadInt32()) != 0)
                    {
                        int num4 = binaryReader.ReadInt32();
                        string str2 = string.Format("{0}", (object)num3);
                        string str3 = string.Format("{0}", (object)num4);
                        ++kModStore;
                        sModStore[kModStore] = str2 + "-" + str3;
                        int num5 = binaryReader.ReadInt32();
                        for (int index = 1; index <= num5; ++index)
                        {
                            str1 = binaryReader.ReadString();
                            binaryReader.ReadDouble();
                            binaryReader.ReadDouble();
                            binaryReader.ReadDouble();
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
            if (iParam != 2 || !File.Exists(mySub.fbaseDtm))
                return;
            FileStream input1 = new FileStream(mySub.fbaseDtm, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader1 = new BinaryReader((Stream)input1);
            try
            {
                xmin = binaryReader1.ReadDouble();
                ymin = binaryReader1.ReadDouble();
                xmax = binaryReader1.ReadDouble();
                ymax = binaryReader1.ReadDouble();
                zmin = binaryReader1.ReadDouble();
                zmax = binaryReader1.ReadDouble();
                int num6;
                while ((num6 = binaryReader1.ReadInt32()) != 0)
                {
                    int num7 = binaryReader1.ReadInt32();
                    sNameModel = string.Format("{0}", (object)num6) + "-" + string.Format("{0}", (object)num7);
                    ip = 0;
                    for (int index = 1; index <= kSelModel; ++index)
                    {
                        if (sSelModel[index] == sNameModel)
                        {
                            ++ip;
                            break;
                        }
                    }
                    int num8 = binaryReader1.ReadInt32();
                    for (int index = 1; index <= num8; ++index)
                    {
                        string str4 = binaryReader1.ReadString();
                        double num9 = binaryReader1.ReadDouble();
                        double num10 = binaryReader1.ReadDouble();
                        double num11 = binaryReader1.ReadDouble();
                        if (ip > 0)
                        {
                            ++kPntPlus;
                            mySub.namePnt[kPntPlus] = str4;
                            mySub.xPnt[kPntPlus] = num9;
                            mySub.yPnt[kPntPlus] = num10;
                            mySub.zPnt[kPntPlus] = num11;
                            mySub.nCode1[kPntPlus] = 0;
                            mySub.nCode2[kPntPlus] = 0;
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
                binaryReader1.Close();
                input1.Close();
            }
        }

        private void ModelSelect_Click(object sender, EventArgs e)
        {
            kSelModel = 0;
            if (checkBox1.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox1.Text;
            }
            if (checkBox2.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox2.Text;
            }
            if (checkBox3.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox3.Text;
            }
            if (checkBox4.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox4.Text;
            }
            if (checkBox5.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox5.Text;
            }
            if (checkBox6.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox6.Text;
            }
            if (checkBox7.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox7.Text;
            }
            if (checkBox8.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox8.Text;
            }
            if (checkBox9.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox9.Text;
            }
            if (checkBox10.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox10.Text;
            }
            if (checkBox11.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox11.Text;
            }
            if (checkBox12.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox12.Text;
            }
            if (checkBox13.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox13.Text;
            }
            if (checkBox14.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox14.Text;
            }
            if (checkBox15.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox15.Text;
            }
            if (checkBox16.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox16.Text;
            }
            if (checkBox17.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox17.Text;
            }
            if (checkBox18.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox18.Text;
            }
            if (checkBox19.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox19.Text;
            }
            if (checkBox20.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox20.Text;
            }
            if (checkBox21.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox21.Text;
            }
            if (checkBox22.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox22.Text;
            }
            if (checkBox23.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox23.Text;
            }
            if (checkBox24.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox24.Text;
            }
            if (checkBox25.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox25.Text;
            }
            if (checkBox26.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox26.Text;
            }
            if (checkBox27.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox27.Text;
            }
            if (checkBox28.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox28.Text;
            }
            if (checkBox29.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox29.Text;
            }
            if (checkBox30.Checked)
            {
                ++kSelModel;
                sSelModel[kSelModel] = checkBox30.Text;
            }
            groupBox10.Visible = false;
            if (kSelModel == 0)
                return;
            nProblem = 34;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            iParam = 2;
            ListStore(iParam, out kModStore, sModStore, kSelModel, sSelModel);
            kPntInput = kPntPlus;
            kHeight = 0;
            mySub.kPntPlus = kPntPlus;
            mySub.kPntInput = kPntInput;
            DllClass1.KeepPntHeig(mySub.filePoint, mySub.fileHeight, ref mySub.xmin, ref mySub.ymin, ref mySub.xmax, ref mySub.ymax, ref mySub.zmin, ref mySub.zmax, mySub.kPntPlus, mySub.kPntInput, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt, mySub.nCode1, mySub.nCode2, ref mySub.kHeight, mySub.nameHeig, mySub.xHeig, mySub.yHeig, mySub.zHeig);
            mySub.HeightSorting();
            kHeight = mySub.kHeight;
            for (int index = 0; index <= kPntPlus; ++index)
            {
                mySub.xPntInscr[index] = mySub.xPnt[index];
                mySub.yPntInscr[index] = mySub.yPnt[index];
                mySub.iHorVerPnt[index] = 0;
            }
            mySub.LoadKeepInscr(2);
            LoadData();
            panel7.Invalidate();
        }



    }

}
