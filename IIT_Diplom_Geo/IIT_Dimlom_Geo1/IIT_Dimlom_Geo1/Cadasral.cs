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
        private void button1_MouseHover(object sender, EventArgs e) => label3.Text = "Close Dialog";

        private void button1_MouseLeave(object sender, EventArgs e) => label3.Text = "";

        private void button7_MouseHover(object sender, EventArgs e) => label3.Text = "Create new or update points' topographic symbologies";

        private void button8_MouseHover(object sender, EventArgs e) => label3.Text = "Create new or update lines' topographic symbologies";

        private void button9_MouseHover(object sender, EventArgs e) => label3.Text = "Create new or update polygons' topographic symbologies";

        private void button10_MouseHover(object sender, EventArgs e) => label3.Text = "File points input-initial data";

        private void button11_MouseHover(object sender, EventArgs e) => label3.Text = "Additional points input, defind in others ways";

        private void button19_MouseHover(object sender, EventArgs e) => label3.Text = "Forming linear structures";

        private void button20_MouseHover(object sender, EventArgs e) => label3.Text = "Linear and polygonal topologies creation";

        private void button24_MouseHover(object sender, EventArgs e) => label3.Text = "Model of relief and contour lines forming and correction";

        private void button25_MouseHover(object sender, EventArgs e) => label3.Text = "Contour lines removing";

        private void button21_MouseHover(object sender, EventArgs e) => label3.Text = "File points input-data for design of actions with parcels";

        private void button22_MouseHover(object sender, EventArgs e) => label3.Text = "Design's additional points input, defind in others ways";

        private void button23_MouseHover(object sender, EventArgs e) => label3.Text = "Forming design's linear structures";

        private void button30_MouseHover(object sender, EventArgs e) => label3.Text = "All design's data removing";

        private void button26_MouseHover(object sender, EventArgs e) => label3.Text = "Areas division and unification, using design's data and without this data";

        private void button29_MouseHover(object sender, EventArgs e) => label3.Text = "All actions removing";

        private void button27_MouseHover(object sender, EventArgs e) => label3.Text = "Final correct topographic symbologies of points, lines, polygons";

        private void button28_MouseHover(object sender, EventArgs e) => label3.Text = "Printing map and tables using format A4";

        private void FormLoad()
        {
            if (!File.Exists(mySub.tmpStr))
            {
                int num = (int)new ProjectMenu().ShowDialog((IWin32Window)this);
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
                        Console.WriteLine("The Read operation failed as expected.");
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
                            mySub.curDirect = binaryReader.ReadString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The Read operation failed as expected.");
                    }
                    finally
                    {
                        input.Close();
                        binaryReader.Close();
                    }
                }
                if (num1 == 0)
                {
                    int num2 = (int)MessageBox.Show("Open New Project", "Cadastral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (num1 > 0)
                {
                    int num3 = (int)MessageBox.Show("Use Project Selet or Open New Project", "Cadastral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                label2.Text = sPart[1] + "\\--Project isn't defined";
            }
            else
            {
                sTmp = mySub.comPath + mySub.curDirect;
                if (!Directory.Exists(sTmp))
                    Directory.CreateDirectory(sTmp);
                label2.Text = sPart[1] + "\\+" + mySub.curProject;
                if (!File.Exists(mySub.tmpStr) && nProcess == 910)
                {
                    int num = (int)MessageBox.Show("Drive wasn't defined. Use 'Drive Change'", "Cadastral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                LoadData();
                panel7.Invalidate();
            }
        }

        public void LoadData()
        {
            xmin = 9999999.9;
            ymin = 9999999.9;
            xmax = -9999999.9;
            ymax = -9999999.9;
            Cursor.Current = Cursors.WaitCursor;
            DllClass1.SetColour(mySub.brColor, mySub.pnColor);
            DllClass1.PointSymbLoad(mySub.fsymbPnt, out kSymbPnt, mySub.numRec, mySub.numbUser, mySub.heiSymb);
            mySub.kSymbPnt = kSymbPnt;
            DllClass1.LineSymbolLoad(mySub.fsymbLine, out kSymbLine, out hSymbLine, mySub.sSymbLine, mySub.x1Line, mySub.y1Line, mySub.x2Line, mySub.y2Line, mySub.xDescr, mySub.yDescr, mySub.x1Dens, mySub.y1Dens, mySub.x1Sign, mySub.y1Sign, mySub.x2Sign, mySub.y2Sign, mySub.n1Sign, mySub.n2Sign, mySub.iStyle1, mySub.iStyle2, mySub.iWidth1, mySub.iWidth2, mySub.nColLine, mySub.nItem, mySub.itemLoc, mySub.nBaseSymb, mySub.sInscr, mySub.hInscr, mySub.iColInscr, mySub.iDensity);
            mySub.PolySymbolLoad(mySub.fsymbPoly, out kPolySymb, out hSymbPoly);
            Cursor.Current = Cursors.WaitCursor;
            kInstall = 0;
            if (File.Exists(mySub.fPolyItem))
            {
                FileStream input = new FileStream(mySub.fPolyItem, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kInstall = binaryReader.ReadInt32();
                    for (int index = 1; index <= kInstall; ++index)
                    {
                        mySub.nCent[index] = binaryReader.ReadInt32();
                        mySub.xLinParc[index] = binaryReader.ReadDouble();
                        mySub.yLinParc[index] = binaryReader.ReadDouble();
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
            }
            mySub.PointLoad(fCurPnt, fCurHeig);
            kPntPlus = mySub.kPntPlus;
            kPntInput = mySub.kPntInput;
            mySub.LoadNode();
            kNode = mySub.kNodeTopo;
            if (kPntPlus < 2)
                return;
            xmin = mySub.xmin;
            ymin = mySub.ymin;
            xmax = mySub.xmax;
            ymax = mySub.ymax;
            zmin = mySub.zmin;
            zmax = mySub.zmax;
            mySub.LoadPntSour();
            kPntSource = mySub.kPntSource;
            kPntFin = 0;
            mySub.PointLoadFin();
            kPntFin = mySub.kPntFin;
            Cursor.Current = Cursors.WaitCursor;
            if (File.Exists(mySub.fpointInscr))
                File.Delete(mySub.fpointInscr);
            FileStream output1 = new FileStream(mySub.fpointInscr, FileMode.CreateNew);
            BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
            binaryWriter1.Write(kPntPlus);
            for (int index = 0; index <= kPntPlus; ++index)
            {
                mySub.xPntInscr[index] = mySub.xPnt[index];
                mySub.yPntInscr[index] = mySub.yPnt[index];
                mySub.iHorVerPnt[index] = 0;
                binaryWriter1.Write(mySub.xPnt[index]);
                binaryWriter1.Write(mySub.yPnt[index]);
                binaryWriter1.Write(mySub.iHorVerPnt[index]);
            }
            binaryWriter1.Close();
            output1.Close();
            mySub.LoadKeepInscr(2);
            Cursor.Current = Cursors.WaitCursor;
            if (kPntFin > 0)
                mySub.InscriptionFin(1);
            kPntProj = -1;
            mySub.PointProjLoad();
            kPntProj = mySub.kPntProj;
            kProjInput = mySub.kProjInput;
            kLineProj = 0;
            mySub.LineProjLoad();
            kLineProj = mySub.kLineProj;
            Cursor.Current = Cursors.WaitCursor;
            kItemCoord = 0;
            mySub.ItemLoadKeep(1);
            kItemCoord = mySub.kItemCoord;
            Cursor.Current = Cursors.WaitCursor;
            kPolyFinal = 0;
            mySub.PolyLoadFin();
            kPolyFinal = mySub.kPolyFinal;
            iPolyFinal = kPolyFinal;
            Cursor.Current = Cursors.WaitCursor;
            kLineFinal = 0;
            mySub.LineLoadFin();
            kLineFinal = mySub.kLineFinal;
            iLineFinal = kLineFinal;
            Cursor.Current = Cursors.WaitCursor;
            kLineInput = 0;
            mySub.LineLoad(fCurLine);
            kLineInput = mySub.kLineInput;
            if (kLineInput == 0)
            {
                kLineTopo = 0;
                if (File.Exists(mySub.flineTopo))
                    File.Delete(mySub.flineTopo);
                kLineFinal = 0;
                iLineFinal = 0;
                if (File.Exists(mySub.flineFinal))
                    File.Delete(mySub.flineFinal);
            }
            Cursor.Current = Cursors.WaitCursor;
            mySub.KeepLoadAction(1);
            nAction = mySub.nAction;
            if (nAction == 0)
            {
                mySub.kNodeTopo = kNode;
                mySub.KeepActionZero();
            }
            if (kLineInput > 0)
            {
                int kArray = 999999;
                DllClass1.doubleArray(mySub.xLin, ref kArray);
                DllClass1.doubleArray(mySub.yLin, ref kArray);
                int num = mySub.k2[kLineInput];
                if (num < 2 || num > kArray)
                {
                    kLineInput = 0;
                    if (File.Exists(mySub.fileLine))
                        File.Delete(mySub.fileLine);
                }
            }
            if (nAction > 0 && kPolyFinal == 0)
            {
                mySub.NodeActLoad(nAction);
                kNodeAct = mySub.kNodeAct;
                mySub.TopoActLoad(nAction);
                kLineAct = mySub.kLineAct;
                mySub.PolyActLoad(nAction);
                kPolyAct = mySub.kPolyAct;
                mySub.PolyCancelLoad(nAction);
                kPolyCancel = mySub.kPolyCancel;
                mySub.LineCancelLoad(nAction);
                kLineCancel = mySub.kLineCancel;
                mySub.LineNewLoad(nAction);
                kLineNew = mySub.kLineNew;
                DllClass1.LineFinal(kLineInput, mySub.nLineCode, mySub.nLongRad, mySub.sWidLine, mySub.dstLine, mySub.rRadLine, mySub.xRadLine, mySub.yRadLine, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, kLineAct, mySub.radAct, mySub.kActLine1, mySub.kActLine2, mySub.xLineAct, mySub.yLineAct, out kLineFinal, mySub.nCodeFin, mySub.nLongFin, mySub.sWidFin, mySub.distFin, mySub.rRadFin, mySub.xRadFin, mySub.yRadFin, mySub.k1Fin, mySub.k2Fin, mySub.xFin, mySub.yFin, mySub.nWork1, mySub.xWork1, mySub.yWork1, tolerance);
                DllClass1.PolyFinal(kPolyAct, mySub.nameAct, mySub.xAct, mySub.yAct, mySub.aActCalc, mySub.aActLeg, mySub.kActPoly1, mySub.kActPoly2, mySub.xPolyAct, mySub.yPolyAct, out kPolyFinal, mySub.namePolyFin, mySub.xLabFin, mySub.yLabFin, mySub.arCalcFin, mySub.arLegFin, mySub.nSymbFin, mySub.kt1Fin, mySub.kt2Fin, mySub.xPolFin, mySub.yPolFin);
            }
            kLineTopo = 0;
            mySub.LineTopoLoad();
            kLineTopo = mySub.kLineTopo;
            DllClass1.SymbolTrans(kLineInput, mySub.nLineCode, mySub.rRadLine, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, kLineTopo, mySub.nTopoCode, mySub.radLine, mySub.kl1, mySub.kl2, mySub.zLin, mySub.zPik, tolerance);
            kPoly = 0;
            mySub.PolygonLoad(ref mySub.kPolyInside);
            kPoly = mySub.kPoly;
            if (kPolyFinal == 0 && kPoly > 0)
            {
                kPolyFinal = kPoly;
                for (int index = 1; index <= kPoly; ++index)
                {
                    mySub.namePolyFin[index] = mySub.namePoly[index];
                    mySub.xLabFin[index] = mySub.xLab[index];
                    mySub.yLabFin[index] = mySub.yLab[index];
                    mySub.nSymbFin[index] = mySub.nSymbPoly[index];
                }
                DllClass1.LineFinal(kLineInput, mySub.nLineCode, mySub.nLongRad, mySub.sWidLine, mySub.dstLine, mySub.rRadLine, mySub.xRadLine, mySub.yRadLine, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, kLineTopo, mySub.radLine, mySub.kl1, mySub.kl2, mySub.zLin, mySub.zPik, out kLineFinal, mySub.nCodeFin, mySub.nLongFin, mySub.sWidFin, mySub.distFin, mySub.rRadFin, mySub.xRadFin, mySub.yRadFin, mySub.k1Fin, mySub.k2Fin, mySub.xFin, mySub.yFin, mySub.nWork, mySub.xWork, mySub.yWork, tolerance);
            }
            if (kLineFinal == 0 && kLineTopo > 0)
                DllClass1.LineFinal(kLineInput, mySub.nLineCode, mySub.nLongRad, mySub.sWidLine, mySub.dstLine, mySub.rRadLine, mySub.xRadLine, mySub.yRadLine, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, kLineTopo, mySub.radLine, mySub.kl1, mySub.kl2, mySub.zLin, mySub.zPik, out kLineFinal, mySub.nCodeFin, mySub.nLongFin, mySub.sWidFin, mySub.distFin, mySub.rRadFin, mySub.xRadFin, mySub.yRadFin, mySub.k1Fin, mySub.k2Fin, mySub.xFin, mySub.yFin, mySub.nWork, mySub.xWork, mySub.yWork, tolerance);
            if (kLineFinal == 0 && kLineTopo == 0)
            {
                kLineFinal = kLineInput;
                for (int index1 = 1; index1 <= kLineInput; ++index1)
                {
                    mySub.nCodeFin[index1] = mySub.nLineCode[index1];
                    mySub.nLongFin[index1] = mySub.nLongRad[index1];
                    mySub.sWidFin[index1] = mySub.sWidLine[index1];
                    mySub.distFin[index1] = mySub.dstLine[index1];
                    mySub.rRadFin[index1] = mySub.rRadLine[index1];
                    mySub.xRadFin[index1] = mySub.xRadLine[index1];
                    mySub.yRadFin[index1] = mySub.yRadLine[index1];
                    mySub.k1Fin[index1] = mySub.k1[index1];
                    mySub.k2Fin[index1] = mySub.k2[index1];
                    int num1 = mySub.k1[index1];
                    int num2 = mySub.k2[index1];
                    for (int index2 = num1; index2 <= num2; ++index2)
                    {
                        mySub.xFin[index2] = mySub.xLin[index2];
                        mySub.yFin[index2] = mySub.yLin[index2];
                    }
                }
                mySub.ItemLoadKeep(1);
                kItemCoord = mySub.kItemCoord;
            }
            mySub.AddInscrLoad();
            kAddInscript = mySub.kAddInscript;
            xminCur = xmin;
            yminCur = ymin;
            xmaxCur = xmax;
            ymaxCur = ymax;
            DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond < 0)
                iGraphic = 1;
            if (kSymbLine > 0)
            {
                DllClass1.LineItemCoor(mySub.fitemLine, mySub.nColorItm, mySub.ixSqu, mySub.iySqu, kLineFinal, mySub.rRadFin, mySub.k1Fin, mySub.k2Fin, mySub.xFin, mySub.yFin, mySub.nCodeFin, kSymbLine, mySub.nItem, mySub.n1Sign, mySub.n2Sign, mySub.iDensity, out kItemCoord, mySub.numSign, mySub.numItem, mySub.xItem, mySub.yItem, mySub.azItem, mySub.xAdd, mySub.yAdd, mySub.xDop, mySub.yDop, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, scaleToGeo);
                if (kItemCoord > 0)
                {
                    mySub.kItemCoord = kItemCoord;
                    mySub.ItemLoadKeep(2);
                }
            }
            nProblem = 0;
            if (File.Exists(mySub.fProblem) && File.Exists(mySub.fProblem))
            {
                FileStream input = new FileStream(mySub.fProblem, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    nProblem = binaryReader.ReadInt32();
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
            }
            if (nProblem >= 30)
                return;
            nProblem = 40;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output2 = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
            binaryWriter2.Write(nProblem);
            binaryWriter2.Close();
            output2.Close();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (iGraphic > 0)
                return;
            Cursor.Current = Cursors.WaitCursor;
            if (kBorder > 2)
                DllClass1.DrawSelLine(e, kBorder, ref mySub.xBorder, ref mySub.yBorder, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            if (kPntPlus > 0 && kPntFin == 0 && iPointOnOff > 0)
                DllClass1.PointsDraw(e, mySub.fsymbPnt, iHeightShow, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
            if (kPntFin > 0 && iPointOnOff > 0)
                DllClass1.PointsDraw(e, mySub.fsymbPnt, iHeightShow, kPntFin, mySub.namePntFin, mySub.xPntFin, mySub.yPntFin, mySub.zPntFin, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nCode1Fin, mySub.nCode2Fin, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
            if (kPolyFinal > 0 && iSymbols > 0)
                DllClass1.DrawPoly(e, mySub.fitemPoly, kPolyFinal, mySub.namePolyFin, mySub.kt1Fin, mySub.kt2Fin, mySub.xLabFin, mySub.yLabFin, mySub.arCalcFin, mySub.nSymbFin, mySub.iHorVer, mySub.xPolFin, mySub.yPolFin, mySub.ki1, mySub.ki2, mySub.xAdd, mySub.yAdd, kPolySymb, mySub.npSign1, mySub.npSign2, mySub.npItem, mySub.nBackCol, mySub.nOneSymb, mySub.ixSqu, mySub.iySqu, mySub.nColorItm, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.xDop, mySub.yDop, mySub.xWork, mySub.yWork, mySub.xWork1, mySub.yWork1, mySub.brColor, mySub.pnColor);
            if (kAddInscript > 0 && iSymbols > 0)
                DllClass1.AddInscrDraw(e, kAddInscript, mySub.sAddInscr, mySub.xAddInscr, mySub.yAddInscr, mySub.nHorVer, mySub.nInsCol, mySub.brColor, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            if (kLineFinal > 0 && iSymbols > 0)
            {
                DllClass1.DrawInputLine(e, kLineFinal, mySub.k1Fin, mySub.k2Fin, mySub.xFin, mySub.yFin, mySub.nCodeFin, mySub.sWidFin, mySub.rRadFin, mySub.xRadFin, mySub.yRadFin, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nColLine, mySub.iWidth1, mySub.iWidth2, mySub.iStyle1, mySub.iStyle2, mySub.nBaseSymb, mySub.xAdd, mySub.yAdd, mySub.xDop, mySub.yDop, mySub.xWork2, mySub.yWork2, kSymbLine, mySub.n1Sign, mySub.n2Sign, mySub.brColor, mySub.pnColor, 0);
                if (kItemCoord > 0)
                    DllClass1.InputItemDraw(e, mySub.fitemLine, kItemCoord, mySub.numSign, mySub.numItem, mySub.xItem, mySub.yItem, mySub.azItem, mySub.itemLoc, mySub.nBaseSymb, mySub.sInscr, mySub.hInscr, mySub.iColInscr, kSymbLine, mySub.ixSqu, mySub.iySqu, mySub.nColorItm, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nDop1, mySub.nDop2, mySub.brColor);
            }
            if (kLineFinal > 0 && iSymbols == 0)
            {
                int iPar = 1;
                DllClass1.LineDraw(e, kLineFinal, mySub.k1Fin, mySub.k2Fin, mySub.xFin, mySub.yFin, mySub.rRadFin, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
            }
            if (kPolyFinal > 0 && iSymbols == 0)
            {
                int iParam = 8;
                DllClass1.LabelDraw(e, kPolyFinal, mySub.namePolyFin, mySub.xLabFin, mySub.yLabFin, mySub.iHorVer, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.brColor, iParam);
            }
            if (kPntProj > -1 && iProjData > 0)
                DrawPntProj(e);
            if (kLineProj > 0 && iProjData > 0)
            {
                int iPar = 2;
                DllClass1.LineDraw(e, kLineProj, mySub.kPr1, mySub.kPr2, mySub.xLinProj, mySub.yLinProj, mySub.RadProj, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
            }
            if (kPolyCancel > 0 && iCancelPoly > 0)
            {
                int iParam = 3;
                DllClass1.LabelDraw(e, kPolyCancel, mySub.nameCanc, mySub.xLabCanc, mySub.yLabCanc, mySub.iHorVer, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.brColor, iParam);
                if (kLineCancel > 0)
                {
                    int iPar = 3;
                    DllClass1.LineDraw(e, kLineCancel, mySub.kLinCanc1, mySub.kLinCanc2, mySub.xLinCanc, mySub.yLinCanc, mySub.RadCanc, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
            }
            if (File.Exists(mySub.fileContour) && iContourShow > 0)
                DllClass1.ContourDraw(e, mySub.fileContour, mySub.xDop, mySub.yDop, mySub.xOut, mySub.yOut, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            if (kInstall > 0 && iSymbols > 0)
            {
                string sTxt = "";
                for (int index1 = 1; index1 <= kInstall; ++index1)
                {
                    int nSelect = mySub.nCent[index1];
                    int xWin;
                    int yWin;
                    DllClass1.XYtoWIN(mySub.xLinParc[index1], mySub.yLinParc[index1], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                    int kPix;
                    int mClr;
                    DllClass1.SelItemPoly(mySub.fitemPoly, nSelect, out int _, out int _, out int _, out kPix, mySub.ixSqu, mySub.iySqu, mySub.nColorItm, out sTxt, out mClr);
                    for (int index2 = 1; index2 <= kPix; ++index2)
                    {
                        int x = xWin + mySub.ixSqu[index2];
                        int y = yWin + mySub.iySqu[index2];
                        mClr = mySub.nColorItm[index2];
                        SolidBrush solidBrush = mySub.brColor[mClr];
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
                    int num = (int)MessageBox.Show("Check Data");
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
                int num1 = (int)MessageBox.Show("Drive wasn't defined", "Project creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Drive wasn't defined", "Project creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Drive wasn't defined", "Project creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new PolygonSign().ShowDialog((IWin32Window)this);
                LoadData();
                panel7.Invalidate();
            }
        }

        private void FilePoints_Click(object sender, EventArgs e)
        {
            string text = "Points: ";
            mySub.FilePath();
            nProcess = 910;
            if (File.Exists(mySub.fileProcess))
                File.Delete(mySub.fileProcess);
            FileStream output1 = new FileStream(mySub.fileProcess, FileMode.CreateNew);
            BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
            binaryWriter1.Write(nProcess);
            binaryWriter1.Close();
            output1.Close();
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Project wasn't defined", "Data File Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DllClass1.PointsInput(out mySub.kPntPlus, out mySub.kPntInput, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt, mySub.nCode1, mySub.nCode2, out mySub.kHeight, mySub.nameHeig, mySub.xHeig, mySub.yHeig, mySub.zHeig, out mySub.xmin, out mySub.ymin, out mySub.xmax, out mySub.ymax, out mySub.zmin, out mySub.zmax, out iCond);
                if (iCond < 0)
                    return;
                kPntPlus = mySub.kPntPlus;
                kPntInput = mySub.kPntInput;
                kHeight = mySub.kHeight;
                xmin = mySub.xmin;
                ymin = mySub.ymin;
                xmax = mySub.xmax;
                ymax = mySub.ymax;
                zmin = mySub.zmin;
                zmax = mySub.zmax;
                int num2 = 0;
                for (int index = 1; index <= kPntPlus; ++index)
                {
                    if (mySub.nCode1[index] > 0)
                    {
                        int kPix;
                        DllClass1.SelSymbPnt(mySub.fsymbPnt, mySub.nCode1[index], kSymbPnt, mySub.numRec, mySub.numbUser, out int _, out int _, out int _, out string _, out kPix, mySub.ixSqu, mySub.iySqu, mySub.nColor, out string _, out int _);
                        if (kPix == 0)
                        {
                            ++num2;
                            text = text + mySub.namePnt[index] + ", ";
                        }
                    }
                }
                if (num2 > 0)
                {
                    int num3 = (int)MessageBox.Show(text, "Code's error of points' symbols", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                mySub.FilesRemove();
                mySub.AllActionRemove();
                DllClass1.KeepPntHeig(mySub.filePoint, mySub.fileHeight, ref mySub.xmin, ref mySub.ymin, ref mySub.xmax, ref mySub.ymax, ref mySub.zmin, ref mySub.zmax, mySub.kPntPlus, mySub.kPntInput, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt, mySub.nCode1, mySub.nCode2, ref mySub.kHeight, mySub.nameHeig, mySub.xHeig, mySub.yHeig, mySub.zHeig);
                kHeight = mySub.kHeight;
                if (iCond < 0)
                {
                    iGraphic = 1;
                }
                else
                {
                    kPntPlus = mySub.kPntPlus;
                    mySub.FilePath();
                    panel1.Text = "******POINTS SORTING*******";
                    mySub.HeightSorting();
                    kHeight = mySub.kHeight;
                    panel1.Text = "Ready......";
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
                    iPointOnOff = 1;
                    nProblem = 31;
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
        }

        private void AddPoints_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Project wasn't defined", "Points Addition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Points' File Input", "Points Addition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Points' File Input", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Points' File Input", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Points' File Input", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(mySub.fileContour))
            {
                int num3 = (int)MessageBox.Show("No data", "Cadastral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kLineInput < 1)
            {
                int num2 = (int)MessageBox.Show("No data", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Input Initial data", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntProj < 0 && kLineProj < 1)
            {
                int num3 = (int)MessageBox.Show("No data", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Input Initial data", "Show", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    int num3 = (int)MessageBox.Show("No data", "Cadastral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "From Points to Lines", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Points' File Input", "From Points to Lines", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Return to 'From Points to Lines'", "Topologies Building", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Points' File Input", "Design's Points", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    int num2 = (int)MessageBox.Show("Project wasn't defined", "Design's File Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "Design's Additional Points", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Points' File Input", "Design's Points", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "From Points to Lines", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Points' File Input", "Design's Points", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPoly == 0)
            {
                int num3 = (int)MessageBox.Show("Polygonal topology wasn't created", "Design Lines", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "From Points to Lines", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Points' File Input", "Actions with Parcels", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPoly == 0)
            {
                int num3 = (int)MessageBox.Show("Polygonal topology wasn't created", "Parcels' action", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (File.Exists(sTmp) && MessageBox.Show("Final Results were created. Do you want to Continue Process of Actions with Parcels ?", "Parcel's Action", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "From Points to Lines", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(mySub.fileHeight))
            {
                int num2 = (int)MessageBox.Show("Altitude Points isn't enough", "Add Contour Lines", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                panel1.Text = "**********************PLEASE.......WAIT*************************";
                mySub.HeightSorting();
                kHeight = mySub.kHeight;
                if (kHeight < 4)
                {
                    int num3 = (int)MessageBox.Show("Altitude Points isn't enough", "Add Contour Lines", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    panel1.Text = "Ready";
                    panel7.Invalidate();
                }
            }
        }

        private void ContourRemove_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fileProj))
            {
                MessageBox.Show("Project wasn't defined", "From Points to Lines", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(mySub.fileContour) && MessageBox.Show("Do you really want to Remove Contour Lines ?", "Contour Lines Removing", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "From Points to Lines", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kPntPlus < 1)
            {
                int num2 = (int)MessageBox.Show("Points' File Input", "Correct and Print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Check final result", "Click 'Correction final result'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("All changes were removed", "Parcel's Actions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Do you really want to Remove All changes ?", "Parcel's Action", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
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
                panel1.Text = "Ready ...";
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
                int num = (int)MessageBox.Show("All Design's data were removed", "Design's data Forming", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nProcess = 0;
                panel7.Invalidate();
            }
            else
            {
                if ((File.Exists(mySub.fpointProj) || File.Exists(mySub.flineProj)) && MessageBox.Show("Do you really want to Delete all Design's data?", "Design's Lines Forming", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
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
                int num1 = (int)MessageBox.Show("Project wasn't defined", "Transfer File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mySub.FilePath();
                DllClass1.DriveList(out kDrive, out sDrive);
                sTmp = "";
                for (int index = 1; index <= kDrive; ++index)
                {
                    sTmp = sDrive[index] + "BrGeodesy\\brdrv.dat";
                    if (File.Exists(sTmp))
                        break;
                }
                if (!File.Exists(sTmp))
                {
                    int num2 = (int)MessageBox.Show("Field Projects aren't created", "Transfer Field Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        int num5 = (int)MessageBox.Show("No Geodesy Projects", "Transfer Field Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int num6 = (int)new FieldProject().ShowDialog((IWin32Window)this);
                        mySub.FilePath();
                        mySub.PointLoad(fCurPnt, fCurHeig);
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
                int num = (int)MessageBox.Show("Data of Aerotriangulation is absent", "DTM Archive", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    Console.WriteLine("The Read operation failed as expected.");
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
                Console.WriteLine("The Read operation failed as expected.");
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
