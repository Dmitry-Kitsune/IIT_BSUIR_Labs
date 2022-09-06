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
using System.Drawing.Printing;

namespace IIT_Dimlom_Geo1
{
    public partial class MapScale : Form
    {
        private string sTmp = "";
        private string sTmp1 = "";
        private string sTmp2 = "";
        private string sTmp3 = "";
        private string sTmp4 = "";
        private string sTmp5 = "";
        private int km;
        private string[] sMess = new string[2000];
        private string[] sNewMess = new string[2000];
        private int[] kpp = new int[500];
        private int[] kp1 = new int[500];
        private int[] kp2 = new int[500];
        private int[] nTab = new int[500];
        private int iSquare;
        private int iPrecision;
        private int newTable;
        private int nTable;
        private int newTabPrint;
        private int nTabPrint;
        private int hText = 10;
        private int xPageBeg;
        private int yPageBeg;
        private int ixPixel;
        private int iyPixel;
        private int kPage;
        private int nPage;
        private int numPage;
        private int dxPage = 17;
        private int dyPage = 22;
        private int dxSheet = 210;
        private int dySheet = 290;
        private int ka;
        private int kSel;
        private int ip;
        private int iScaleMap;
        private int kSymbPnt;
        private int kSymbLine;
        private int kSymbPoly;
        private int iParam;
        private int kPntPlus;
        private int kPolyFinal;
        private int kLineFinal;
        private int kItemCoord;
        private int hSymbPoly = 30;
        private int kAddInscript;
        private int nAction;
        private int kPolyCancel;
        private int kLineCancel;
        private int nProcess;
        private int kNewMess;
        private int kPntFin;
        private int kNodeAct;
        private int kNode;
        private double dx;
        private double dy;
        private double ss;
        private double sPixInch = 0.254;
        private double[] x1 = new double[500];
        private double[] y1 = new double[500];
        private double[] x2 = new double[500];
        private double[] y2 = new double[500];
        private double[] x3 = new double[500];
        private double[] y3 = new double[500];
        private double[] x4 = new double[500];
        private double[] y4 = new double[500];
        private double[] xa = new double[10];
        private double[] ya = new double[10];
        private int[] iPrintShow = new int[21];
        private double sArea;
        private double arExter;
        private int iToler;
        private char[] sFormula = new char[50];
        private int iWidth;
        private int iHeight;
        private int xBegWin;
        private int yBegWin;
        private int xEndWin;
        private int yEndWin;
        private double xBegX;
        private double yBegY;
        private int pixWid;
        private int pixHei;
        private double scaleToWin;
        private double xmin;
        private double ymin;
        private double xmax;
        private double ymax;
        private double scaleToGeo;
        private int iCond;
        private int iGraphic;
        private double xEndX;
        private double yEndY;
        private int k;
        private int kList;
        private int hSymbLine = 18;
        private int kPntPart;
        private int kLinePart;
        private int kInstall;
        internal PrintPreviewControl PrintPreviewControl1;
        private PrintDocument docToPreview = new PrintDocument();
        private PrintDocument docToPrint = new PrintDocument();
        private MyGeodesy myMap = new MyGeodesy();

        public string fCurPnt { get; private set; }
        public string fCurHeig { get; private set; }

        public MapScale()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            pixWid = panel1.Bounds.Width;
            pixHei = panel1.Bounds.Height;
            if (pixWid <= pixHei)
                iWidth = iHeight = pixWid;
            if (pixWid > pixHei)
                iWidth = iHeight = pixHei;
            radioButton3.Checked = true;
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
            checkBox7.Checked = true;
            checkBox8.Checked = true;
            checkBox9.Checked = true;
            checkBox10.Checked = false;
            comboBox1.Items.Add((object)"М. кв.");
            comboBox1.Items.Add((object)"Гектары");
            comboBox1.Items.Add((object)"Акры");
            comboBox1.Items.Add((object)"Дунам");
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add((object)"0.1");
            comboBox2.Items.Add((object)"0.01");
            comboBox2.Items.Add((object)"0.001");
            comboBox2.Items.Add((object)"0.0001");
            comboBox2.SelectedIndex = 1;
            FormLoad();
        }

        private void FormLoad()
        {
            myMap.FilePath();
            DllClass1.SetColour(myMap.brColor, myMap.pnColor);
            DllClass1.PointSymbLoad(myMap.fsymbPnt, out kSymbPnt,
                myMap.numRec, myMap.numbUser, myMap.heiSymb);
            myMap.kSymbPnt = kSymbPnt;
            DllClass1.LineSymbolLoad(myMap.fsymbLine, out kSymbLine, 
                out hSymbLine, myMap.sSymbLine, myMap.x1Line, 
                myMap.y1Line, myMap.x2Line, myMap.y2Line, 
                myMap.xDescr, myMap.yDescr, myMap.x1Dens, 
                myMap.y1Dens, myMap.x1Sign, myMap.y1Sign, 
                myMap.x2Sign, myMap.y2Sign, myMap.n1Sign, 
                myMap.n2Sign, myMap.iStyle1, myMap.iStyle2, 
                myMap.iWidth1, myMap.iWidth2, myMap.nColLine, 
                myMap.nItem, myMap.itemLoc, myMap.nBaseSymb, 
                myMap.sInscr, myMap.hInscr, myMap.iColInscr, 
                myMap.iDensity);
            myMap.PolySymbolLoad(myMap.fsymbPoly, out kSymbPoly, out hSymbPoly);
            //myMap.PointLoad(fCurPnt, fCurHeig);
            myMap.PointLoad();
            kPntPlus = myMap.kPntPlus;
            myMap.PointLoadFin();
            kPntFin = myMap.kPntFin;
            xmin = myMap.xmin;
            ymin = myMap.ymin;
            xmax = myMap.xmax;
            ymax = myMap.ymax;
            if (!File.Exists(myMap.fInscrFin))
            {
                FileStream output = new FileStream(myMap.fInscrFin, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(kPntFin);
                for (int index = 0; index <= kPntFin; ++index)
                {
                    myMap.xPntInscr[index] = myMap.xPntFin[index];
                    myMap.yPntInscr[index] = myMap.yPntFin[index];
                    myMap.iHorVerPnt[index] = 0;
                    binaryWriter.Write(myMap.xPntFin[index]);
                    binaryWriter.Write(myMap.yPntFin[index]);
                    binaryWriter.Write(myMap.iHorVerPnt[index]);
                }
                binaryWriter.Close();
                output.Close();
                myMap.InscriptionFin(2);
            }
            myMap.InscriptionFin(1);
            myMap.PolyLoadFin();
            kPolyFinal = myMap.kPolyFinal;
            myMap.LineLoadFin();
            kLineFinal = myMap.kLineFinal;
            myMap.ItemLoadKeep(1);
            kItemCoord = myMap.kItemCoord;
            myMap.AddInscrLoad();
            kAddInscript = myMap.kAddInscript;
            myMap.KeepLoadAction(1);
            nAction = myMap.nAction;
            if (nAction > 0)
            {
                myMap.CancPolyFin(nAction);
                myMap.CancPolyFinLoad();
                kPolyCancel = myMap.kPolyCancel;
                myMap.CancLineFin(nAction);
                myMap.CancLineFinLoad();
                kLineCancel = myMap.kLineCancel;
                myMap.NodeActLoad(nAction);
                kNodeAct = myMap.kNodeAct;
                if (kNodeAct > 0)
                {
                    int index1 = 0;
                    for (int index2 = 1; index2 <= kNodeAct; ++index2)
                    {
                        ip = 0;
                        for (int index3 = 0; index3 <= kPntPlus; ++index3)
                        {
                            dx = myMap.xNodeAct[index2] - myMap.xPnt[index3];
                            dy = myMap.yNodeAct[index2] - myMap.yPnt[index3];
                            ss = Math.Sqrt(dx * dx + dy * dy);
                            if (ss < 0.003)
                            {
                                ++ip;
                                break;
                            }
                        }
                        if (ip <= 0)
                        {
                            ++index1;
                            myMap.nameNodeAct[index1] = myMap.nameNodeAct[index2];
                            myMap.xNodeAct[index1] = myMap.xNodeAct[index2];
                            myMap.yNodeAct[index1] = myMap.yNodeAct[index2];
                        }
                    }
                    kNodeAct = index1;
                }
            }
            if (kNodeAct == 0)
            {
                myMap.LoadNode();
                kNode = myMap.kNodeTopo;
                if (kNode > 0)
                {
                    int index4 = 0;
                    for (int index5 = 1; index5 <= kNode; ++index5)
                    {
                        ip = 0;
                        for (int index6 = 0; index6 <= kPntPlus; ++index6)
                        {
                            dx = myMap.xNode[index5] - myMap.xPnt[index6];
                            dy = myMap.yNode[index5] - myMap.yPnt[index6];
                            ss = Math.Sqrt(dx * dx + dy * dy);
                            if (ss < 0.003)
                            {
                                ++ip;
                                break;
                            }
                        }
                        if (ip <= 0)
                        {
                            ++index4;
                            myMap.nameNode[index4] = myMap.nameNode[index5];
                            myMap.xNode[index4] = myMap.xNode[index5];
                            myMap.yNode[index4] = myMap.yNode[index5];
                        }
                    }
                    kNode = index4;
                }
            }
            Size_PrevPrint(sPixInch, dxSheet, dySheet, dxPage,
                dyPage, out xPageBeg, out yPageBeg, out ixPixel,
                out iyPixel);
            int num = 0;
            string str = "";
            if (File.Exists(myMap.flistAction))
            {
                FileStream input = new FileStream(myMap.flistAction, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    while ((str = binaryReader.ReadString()) != null)
                    {
                        ++num;
                        if (num != 1)
                        {
                            ++km;
                            sMess[km] = str;
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
            myMap.ExterLoad();
            sArea = myMap.sArea;
            arExter = myMap.arExter;
            iToler = 0;
            if (File.Exists(myMap.fileToler))
            {
                FileStream input = new FileStream(myMap.fileToler, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    str = binaryReader.ReadString();
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
                iToler = 1;
                for (int index = 0; index < str.Length; ++index)
                    sFormula[index] = str[index];
            }
            DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight,
                out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX,
                out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin,
                out iCond);
            if (iCond < 0)
                iGraphic = 1;
            kInstall = 0;
            if (!File.Exists(myMap.fPolyItem))
                return;
            FileStream input1 = new FileStream(myMap.fPolyItem, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader1 = new BinaryReader((Stream)input1);
            try
            {
                kInstall = binaryReader1.ReadInt32();
                for (int index = 1; index <= kInstall; ++index)
                {
                    myMap.nCent[index] = binaryReader1.ReadInt32();
                    myMap.xLinParc[index] = binaryReader1.ReadDouble();
                    myMap.yLinParc[index] = binaryReader1.ReadDouble();
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

        public void Size_PrevPrint(
     double sPixInch,
     int dxSheet,
     int dySheet,
     int dxPage,
     int dyPage,
     out int ix,
     out int iy,
     out int ixPixel,
     out int iyPixel)
        {
            ixPixel = Convert.ToInt32((double)(10 * dxPage) / sPixInch);
            iyPixel = Convert.ToInt32((double)(10 * dyPage) / sPixInch);
            ix = Convert.ToInt32(0.5 * (double)(dxSheet - 10 * dxPage) / sPixInch);
            iy = Convert.ToInt32(0.5 * (double)(dySheet - 10 * dyPage) / sPixInch);
            iy -= iy / 3;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            iScaleMap = 0;
            if (radioButton1.Checked)
                iScaleMap = 100;
            if (radioButton2.Checked)
                iScaleMap = 200;
            if (radioButton3.Checked)
                iScaleMap = 500;
            if (radioButton4.Checked)
                iScaleMap = 1000;
            if (radioButton5.Checked)
                iScaleMap = 2000;
            if (radioButton6.Checked)
                iScaleMap = 5000;
            if (radioButton7.Checked)
                iScaleMap = 10000;
            //if (radioButton8.Checked)
            //    iScaleMap = 125;
            //if (radioButton9.Checked)
            //    iScaleMap = 250;
            //if (radioButton10.Checked)
            //    iScaleMap = 625;
            //if (radioButton11.Checked)
            //    iScaleMap = 1250;
            if (radioButton12.Checked)
                iScaleMap = 2500;
            //if (radioButton13.Checked)
            //    iScaleMap = 6250;
            //if (radioButton14.Checked)
            //    iScaleMap = 12500;
            for (int index = 0; index <= 20; ++index)
                iPrintShow[index] = 0;
            if (checkBox1.Checked)
                iPrintShow[1] = 1;
            if (checkBox2.Checked)
                iPrintShow[2] = 1;
            if (checkBox3.Checked)
                iPrintShow[3] = 1;
            if (checkBox4.Checked)
                iPrintShow[4] = 1;
            if (checkBox5.Checked)
                iPrintShow[5] = 1;
            if (checkBox6.Checked)
                iPrintShow[6] = 1;
            if (checkBox7.Checked)
                iPrintShow[7] = 1;
            if (checkBox8.Checked)
                iPrintShow[8] = 1;
            if (checkBox9.Checked)
                iPrintShow[9] = 1;
            if (checkBox10.Checked)
                iPrintShow[10] = 1;
            DllClass1.BoundPage(iScaleMap, myMap.kPntPlus, myMap.xPnt, myMap.yPnt, 
                dxPage, dyPage, out kPage, x1, y1, x2, y2, x3, 
                y3, x4, y4);
            if (kPage < 1)
                return;
            listBox1.Items.Clear();
            k = 0;
            kList = 0;
            for (int index1 = 1; index1 <= kPage; ++index1)
            {
                sTmp1 = string.Format("{0}", (object)x1[index1]);
                sTmp2 = string.Format("{0}", (object)y1[index1]);
                sTmp3 = string.Format("{0}", (object)x3[index1]);
                sTmp4 = string.Format("{0}", (object)y3[index1]);
                xa[0] = x1[index1];
                ya[0] = y1[index1];
                xa[1] = x2[index1];
                ya[1] = y2[index1];
                xa[2] = x3[index1];
                ya[2] = y3[index1];
                xa[3] = x4[index1];
                ya[3] = y4[index1];
                xa[4] = x1[index1];
                ya[4] = y1[index1];
                ka = 4;
                kSel = 0;
                for (int index2 = 0; index2 <= ka; ++index2)
                {
                    ++k;
                    ++kSel;
                    myMap.xCont[k] = xa[index2];
                    if (xa[index2] > xmax)
                        myMap.xCont[k] = xmax + 1.0;
                    myMap.yCont[k] = ya[index2];
                    if (ya[index2] > ymax)
                        myMap.yCont[k] = ymax + 1.0;
                }
                ++kList;
                myMap.nExter[kList] = kSel;
                kSel = 0;
                for (int index3 = 0; index3 <= myMap.kPntPlus; ++index3)
                {
                    ip = DllClass1.in_out(ka, ref xa, ref ya, myMap.xPnt[index3], 
                        myMap.yPnt[index3]);
                    if (ip > 0)
                        ++kSel;
                }
                sTmp5 = string.Format("{0}", (object)kSel);
                sTmp = sTmp1 + "   " + sTmp2 + "   " + sTmp3 + "   " + sTmp4 + "    " 
                    + sTmp5;
                sTmp = " " + string.Format("{0}", (object)index1) + "      " + sTmp;
                listBox1.Items.Add((object)sTmp);
            }
            myMap.kn1[1] = 1;
            myMap.kn2[1] = myMap.nExter[1];
            if (kList > 0)
            {
                for (int index = 2; index <= kList; ++index)
                {
                    myMap.kn1[index] = myMap.kn2[index - 1] + 1;
                    myMap.kn2[index] = myMap.kn2[index - 1] + myMap.nExter[index];
                }
            }
            panel1.Invalidate();
        }

        private void SelectPage_Click(object sender, EventArgs e)
        {
            nProcess = 10;
            for (int index = 0; index <= 20; ++index)
                iPrintShow[index] = 0;
            if (checkBox1.Checked)
                iPrintShow[1] = 1;
            if (checkBox2.Checked)
                iPrintShow[2] = 1;
            if (checkBox3.Checked)
                iPrintShow[3] = 1;
            if (checkBox4.Checked)
                iPrintShow[4] = 1;
            if (checkBox5.Checked)
                iPrintShow[5] = 1;
            if (checkBox6.Checked)
                iPrintShow[6] = 1;
            if (checkBox7.Checked)
                iPrintShow[7] = 1;
            if (checkBox8.Checked)
                iPrintShow[8] = 1;
            if (checkBox9.Checked)
                iPrintShow[9] = 1;
            if (checkBox10.Checked)
                iPrintShow[10] = 1;
            if (listBox1.SelectedIndex < 0)
            {
                int num = (int)MessageBox.Show("Страница не выбрана.", "Печать страницы", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nPage = listBox1.SelectedIndex + 1;
                Controls.Remove((Control)PrintPreviewControl1);
                Init_Preview();
            }
        }

        private void PrintSelected_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                int num = (int)MessageBox.Show("Страница не выбрана.", "Печать страницы", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                for (int index = 0; index <= 20; ++index)
                    iPrintShow[index] = 0;
                if (checkBox1.Checked)
                    iPrintShow[1] = 1;
                if (checkBox2.Checked)
                    iPrintShow[2] = 1;
                if (checkBox3.Checked)
                    iPrintShow[3] = 1;
                if (checkBox4.Checked)
                    iPrintShow[4] = 1;
                if (checkBox5.Checked)
                    iPrintShow[5] = 1;
                if (checkBox6.Checked)
                    iPrintShow[6] = 1;
                if (checkBox7.Checked)
                    iPrintShow[7] = 1;
                if (checkBox8.Checked)
                    iPrintShow[8] = 1;
                if (checkBox9.Checked)
                    iPrintShow[9] = 1;
                if (checkBox10.Checked)
                    iPrintShow[10] = 1;
                Init_Print();
                myMap.FilePath();
                listBox1.Items.Clear();
                for (int index1 = 1; index1 <= kPage; ++index1)
                {
                    sTmp1 = string.Format("{0}", (object)x1[index1]);
                    sTmp2 = string.Format("{0}", (object)y1[index1]);
                    sTmp3 = string.Format("{0}", (object)x3[index1]);
                    sTmp4 = string.Format("{0}", (object)y3[index1]);
                    xa[0] = x1[index1];
                    ya[0] = y1[index1];
                    xa[1] = x2[index1];
                    ya[1] = y2[index1];
                    xa[2] = x3[index1];
                    ya[2] = y3[index1];
                    xa[3] = x4[index1];
                    ya[3] = y4[index1];
                    xa[4] = x1[index1];
                    ya[4] = y1[index1];
                    ka = 4;
                    kSel = 0;
                    for (int index2 = 0; index2 <= myMap.kPntPlus; ++index2)
                    {
                        ip = DllClass1.in_out(ka, ref xa, ref ya, 
                            myMap.xPnt[index2], myMap.yPnt[index2]);
                        if (ip > 0)
                            ++kSel;
                    }
                    sTmp5 = string.Format("{0}", (object)kSel);
                    sTmp = sTmp1 + " " + sTmp2 + " " + sTmp3 + " " + sTmp4 + "     " 
                        + sTmp5;
                    sTmp = " " + string.Format("{0}", (object)index1) + "      " + sTmp;
                    listBox1.Items.Add((object)sTmp);
                }
            }
        }

        private void Init_Preview()
        {
            PrintPreviewControl1 = new PrintPreviewControl();
            PrintPreviewControl1.ClientSize = new Size(580, 690);
            PrintPreviewControl1.Location = new Point(160, 0);
            PrintPreviewControl1.Document = docToPreview;
            Controls.Add((Control)PrintPreviewControl1);
            docToPreview.PrintPage += new PrintPageEventHandler(docToPreview_PrintPage);
        }

        private void docToPreview_PrintPage(object sender, PrintPageEventArgs e)
        {
            xa[1] = x1[nPage];
            ya[1] = y1[nPage];
            xa[2] = x2[nPage];
            ya[2] = y2[nPage];
            xa[3] = x3[nPage];
            ya[3] = y3[nPage];
            xa[4] = x4[nPage];
            ya[4] = y4[nPage];
            xa[5] = x1[nPage];
            ya[5] = y1[nPage];
            if (nProcess == 10)
            {
                if (kPolyFinal > 0 && iPrintShow[3] > 0)
                    DllClass1.Print_Polygons(e, myMap.fitemPoly, kPolyFinal,
                        myMap.namePolyFin, myMap.kt1Fin, myMap.kt2Fin,
                        myMap.xLabFin, myMap.yLabFin, myMap.arCalcFin, 
                        myMap.arLegFin, myMap.nSymbFin, myMap.iHorVer, 
                        myMap.xPolFin, myMap.yPolFin, myMap.nDop1,
                        myMap.nDop2, myMap.xDop, myMap.yDop, kSymbPoly, 
                        myMap.npSign1, myMap.npSign2, myMap.npItem,
                        myMap.nBackCol, myMap.npTxtCol, myMap.hpFont,
                        myMap.spInscr, myMap.nOneSymb, myMap.ixSqu,
                        myMap.iySqu, myMap.nColorItm, myMap.brColor, 
                        myMap.pnColor, sPixInch, iScaleMap, xa, 
                        ya, xPageBeg, yPageBeg, iPrintShow[10], 
                        myMap.xAdd, myMap.yAdd, myMap.xWork, myMap.yWork,
                        myMap.nDop3, myMap.xLinProj, myMap.yLinProj);
                if (iPrintShow[6] > 0)
                    myMap.Contours_PrevPrint(e, sPixInch, iScaleMap,
                        xa, ya, myMap.xPik, myMap.yPik, myMap.xPol,
                        myMap.yPol, iPrintShow[10], xPageBeg, yPageBeg,
                        ixPixel, iyPixel);
                if (kLineFinal > 0)
                {
                    if (iPrintShow[4] == 0)
                        myMap.PrevPrint_Lines(e, sPixInch, iScaleMap, xa,
                            ya, kLineFinal, myMap.rRadFin, myMap.xRadFin,
                            myMap.yRadFin, myMap.k1Fin, myMap.k2Fin, myMap.xFin,
                            myMap.yFin, myMap.xPik, myMap.yPik, xPageBeg, yPageBeg, 
                            ixPixel, iyPixel, iPrintShow[5]);
                    if (iPrintShow[4] > 0)
                    {
                        if (kItemCoord > 0)
                        DllClass1.Print_ItemLine(e, myMap.fitemLine, sPixInch, 
                            iScaleMap, xa, ya, kItemCoord, myMap.numSign, 
                            myMap.numItem, myMap.xItem, myMap.yItem, myMap.azItem, 
                            myMap.itemLoc, myMap.nBaseSymb, myMap.sInscr, myMap.hInscr,
                            myMap.iColInscr, myMap.ixSqu, myMap.iySqu, myMap.nColorItm,
                            myMap.nDop1, myMap.nDop2, myMap.brColor, myMap.pnColor,
                            iPrintShow[10], xPageBeg, yPageBeg);
                        DllClass1.KeepLoadParts(2, myMap.fPntLine, ref kPntPart, myMap.xWork,
                            myMap.yWork, myMap.nDop2, ref kLinePart, myMap.xWork1,
                            myMap.yWork1, myMap.xWork2, myMap.yWork2, myMap.nWork,
                            myMap.nDop1);
                        DllClass1.Print_PartLines(e, sPixInch, iScaleMap, xa, ya,
                            kPntPart, myMap.xWork, myMap.yWork, myMap.nDop2,
                            kLinePart, myMap.xWork1, myMap.yWork1, myMap.xWork2,
                            myMap.yWork2, myMap.nWork, myMap.nDop1, myMap.xAdd,
                            myMap.yAdd, myMap.xDop, myMap.yDop, myMap.xPik,
                            myMap.yPik, myMap.nPik, myMap.nSour1, myMap.nSour2,
                            myMap.brColor, myMap.pnColor, xPageBeg, yPageBeg, iPrintShow[10]);
                    }
                }
                if (kPolyFinal > 0 && iPrintShow[3] == 0)
                {
                    iParam = 5;
                    DllClass1.Labels_PrevPrint(e, sPixInch, iScaleMap, xa,
                        ya, kPolyFinal, myMap.namePolyFin, myMap.xLabFin,
                        myMap.yLabFin, myMap.iHorVer, iParam, iPrintShow[10],
                        xPageBeg, yPageBeg);
                }
                if (kNodeAct > 0)
                {
                    iParam = 4;
                    DllClass1.Nodes_PrevPrint(e, sPixInch, iScaleMap, xa,
                        ya, kNodeAct, myMap.nameNodeAct, myMap.xNodeAct, 
                        myMap.yNodeAct, myMap.iHorVer, iParam, iPrintShow[10],
                        xPageBeg, yPageBeg);
                }
                if (kNode > 0 && kNodeAct == 0)
                {
                    iParam = 4;
                    DllClass1.Nodes_PrevPrint(e, sPixInch, iScaleMap, xa, 
                        ya, kNode, myMap.nameNode, myMap.xNode, 
                        myMap.yNode, myMap.iHorVer, iParam, iPrintShow[10],
                        xPageBeg, yPageBeg);
                }
                if (kAddInscript > 0 && iPrintShow[9] > 0)
                    DllClass1.Print_AddInscr(e, kAddInscript, myMap.sAddInscr,
                        myMap.xAddInscr, myMap.yAddInscr, myMap.nHorVer, 
                        myMap.nInsCol, myMap.brColor, sPixInch, iScaleMap,
                        xa, ya, xPageBeg, yPageBeg);
                if (iPrintShow[1] > 0 || iPrintShow[2] > 0)
                {
                    iParam = 0;
                    if (iPrintShow[2] > 0)
                        iParam = 1;
                    DllClass1.Print_Points(e, myMap.fsymbPnt, sPixInch, iScaleMap, 
                        xa, ya, kPntFin, myMap.namePntFin, myMap.xPntFin,
                        myMap.yPntFin, myMap.zPntFin, iParam, myMap.xPntInscr,
                        myMap.yPntInscr, myMap.iHorVerPnt, myMap.nCode1Fin, myMap.nCode2Fin,
                        myMap.kSymbPnt, myMap.numRec, myMap.numbUser, myMap.ixSqu,
                        myMap.iySqu, myMap.nColor, xPageBeg, yPageBeg, myMap.brColor,
                        myMap.pnColor, iPrintShow[10]);
                }
                if (kInstall > 0)
                {
                    double num1 = 0.01 * (double)iScaleMap;
                    string sTxt = "";
                    double[] x = new double[6];
                    double[] y = new double[6];
                    Graphics graphics = e.Graphics;
                    int k = -1;
                    for (int index = 1; index <= 5; ++index)
                    {
                        ++k;
                        x[k] = xa[index];
                        y[k] = ya[index];
                    }
                    for (int index1 = 1; index1 <= kInstall; ++index1)
                    {
                        ip = DllClass1.in_out(k, ref x, ref y, myMap.xLinParc[index1], myMap.yLinParc[index1]);
                        if (ip != 0)
                        {
                            dx = myMap.xLinParc[index1] - xa[2];
                            dy = myMap.yLinParc[index1] - ya[2];
                            int int32_1 = Convert.ToInt32(10.0 * dx / num1 / sPixInch);
                            int int32_2 = Convert.ToInt32(10.0 * dy / num1 / sPixInch);
                            int num2 = xPageBeg + int32_1;
                            int num3 = yPageBeg - int32_2;
                            int iWid;
                            int iHei;
                            int kPix;
                            int mClr;
                            DllClass1.SelItemPoly(myMap.fitemPoly, myMap.nCent[index1], out int _, out iWid, out iHei, out kPix, myMap.ixSqu, myMap.iySqu, myMap.nColorItm, out sTxt, out mClr);
                            if (iPrintShow[10] == 0)
                            {
                                for (int index2 = 1; index2 <= kPix; ++index2)
                                {
                                    int num4 = num2 + myMap.ixSqu[index2];
                                    int num5 = num3 + myMap.iySqu[index2];
                                    mClr = myMap.nColorItm[index2];
                                    SolidBrush solidBrush = myMap.brColor[1];
                                    graphics.FillRectangle((Brush)solidBrush, num4 - iWid / 2, num5 - iHei / 2, 1, 1);
                                }
                            }
                            if (iPrintShow[10] > 0)
                            {
                                for (int index3 = 1; index3 <= kPix; ++index3)
                                {
                                    int num6 = num2 + myMap.ixSqu[index3];
                                    int num7 = num3 + myMap.iySqu[index3];
                                    mClr = myMap.nColorItm[index3];
                                    SolidBrush solidBrush = myMap.brColor[mClr];
                                    graphics.FillRectangle((Brush)solidBrush, num6 - iWid / 2, num7 - iHei / 2, 1, 1);
                                }
                            }
                        }
                    }
                }
                if (kLineCancel > 0 && iPrintShow[7] > 0)
                    DllClass1.Print_CancelLine(e, sPixInch, iScaleMap, xa, ya, kLineCancel, myMap.kLinCanc1, myMap.kLinCanc2, myMap.xLinCanc, myMap.yLinCanc, myMap.RadCanc, myMap.nWork, myMap.nWork1, myMap.nWork2, myMap.xWork1, myMap.yWork1, myMap.xWork2, myMap.yWork2, myMap.xWork, myMap.yWork, myMap.xAdd, myMap.yAdd, myMap.xDop, myMap.yDop, iPrintShow[10], xPageBeg, yPageBeg);
                if (kPolyCancel > 0 && iPrintShow[8] > 0)
                {
                    iParam = 3;
                    DllClass1.Labels_PrevPrint(e, sPixInch, iScaleMap, xa, ya, kPolyCancel, myMap.nameCanc, myMap.xLabCanc, myMap.yLabCanc, myMap.iHorVer, iParam, iPrintShow[10], xPageBeg, yPageBeg);
                }
                DllClass1.Page_PrevPrint(e, sPixInch, iScaleMap, xa, ya, xPageBeg, yPageBeg, ixPixel, iyPixel, nPage);
            }
            if (nProcess == 20 && numPage > 0)
                DllClass1.Print_Report(e, sPixInch, dxSheet, dySheet, hText, km, sMess, kPage, kp1, kp2, numPage, newTable, out nTable, iSquare, iPrecision, myMap.nameDop);
            if (nProcess != 30 || numPage <= 0)
                return;
            DllClass1.Print_Area(e, sPixInch, dxSheet, dySheet, hText, kNewMess, sNewMess, kPage, kp1, kp2, numPage, iSquare, iPrecision, iToler, sFormula);
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                int num = (int)MessageBox.Show("Страница не выбрана.", "Печать страницы", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                PrintPreviewControl1.Zoom = 1.25;
                PrintPreviewControl1.Invalidate();
            }
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                int num = (int)MessageBox.Show("Страница не выбрана.", "Печать страницы", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                PrintPreviewControl1.Zoom = 0.59;
                PrintPreviewControl1.Invalidate();
            }
        }

        private void Init_Print()
        {
            docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);
            docToPrint.Print();
        }

        private void docToPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            xa[1] = x1[nPage];
            ya[1] = y1[nPage];
            xa[2] = x2[nPage];
            ya[2] = y2[nPage];
            xa[3] = x3[nPage];
            ya[3] = y3[nPage];
            xa[4] = x4[nPage];
            ya[4] = y4[nPage];
            xa[5] = x1[nPage];
            ya[5] = y1[nPage];
            if (nProcess == 10)
            {
                if (kPolyFinal > 0 && iPrintShow[3] > 0)
                    DllClass1.Print_Polygons(e, myMap.fitemPoly, kPolyFinal, myMap.namePolyFin, myMap.kt1Fin, myMap.kt2Fin, myMap.xLabFin, myMap.yLabFin, myMap.arCalcFin, myMap.arLegFin, myMap.nSymbFin, myMap.iHorVer, myMap.xPolFin, myMap.yPolFin, myMap.nDop1, myMap.nDop2, myMap.xDop, myMap.yDop, kSymbPoly, myMap.npSign1, myMap.npSign2, myMap.npItem, myMap.nBackCol, myMap.npTxtCol, myMap.hpFont, myMap.spInscr, myMap.nOneSymb, myMap.ixSqu, myMap.iySqu, myMap.nColorItm, myMap.brColor, myMap.pnColor, sPixInch, iScaleMap, xa, ya, xPageBeg, yPageBeg, iPrintShow[10], myMap.xAdd, myMap.yAdd, myMap.xWork, myMap.yWork, myMap.nDop3, myMap.xLinProj, myMap.yLinProj);
                if (iPrintShow[6] > 0)
                    myMap.Contours_PrevPrint(e, sPixInch, iScaleMap, xa, ya,
                        myMap.xPik, myMap.yPik, myMap.xPol, myMap.yPol,
                        iPrintShow[10], xPageBeg, yPageBeg, ixPixel, 
                        iyPixel);
                if (iPrintShow[1] > 0 || iPrintShow[2] > 0)
                {
                    iParam = 0;
                    if (iPrintShow[2] > 0)
                        iParam = 1;
                    DllClass1.Print_Points(e, myMap.fsymbPnt, sPixInch, iScaleMap, xa, ya, myMap.kPntFin, myMap.namePntFin, myMap.xPntFin, myMap.yPntFin, myMap.zPntFin, iParam, myMap.xPntInscr, myMap.yPntInscr, myMap.iHorVerPnt, myMap.nCode1Fin, myMap.nCode2Fin, myMap.kSymbPnt, myMap.numRec, myMap.numbUser, myMap.ixSqu, myMap.iySqu, myMap.nColor, xPageBeg, yPageBeg, myMap.brColor, myMap.pnColor, iPrintShow[10]);
                }
                if (kLineFinal > 0)
                {
                    if (iPrintShow[4] == 0)
                        myMap.PrevPrint_Lines(e, sPixInch, iScaleMap, xa, ya, kLineFinal, myMap.rRadFin, myMap.xRadFin, myMap.yRadFin, myMap.k1Fin, myMap.k2Fin, myMap.xFin, myMap.yFin, myMap.xPik, myMap.yPik, xPageBeg, yPageBeg, ixPixel, iyPixel, iPrintShow[5]);
                    if (iPrintShow[4] > 0)
                    {
                        if (kItemCoord > 0)
                            DllClass1.Print_ItemLine(e, myMap.fitemLine, sPixInch, iScaleMap, xa, ya, kItemCoord, myMap.numSign, myMap.numItem, myMap.xItem, myMap.yItem, myMap.azItem, myMap.itemLoc, myMap.nBaseSymb, myMap.sInscr, myMap.hInscr, myMap.iColInscr, myMap.ixSqu, myMap.iySqu, myMap.nColorItm, myMap.nDop1, myMap.nDop2, myMap.brColor, myMap.pnColor, iPrintShow[10], xPageBeg, yPageBeg);
                        DllClass1.KeepLoadParts(2, myMap.fPntLine, ref kPntPart, myMap.xWork, myMap.yWork, myMap.nDop2, ref kLinePart, myMap.xWork1, myMap.yWork1, myMap.xWork2, myMap.yWork2, myMap.nWork, myMap.nDop1);
                        DllClass1.Print_PartLines(e, sPixInch, iScaleMap, xa, ya, kPntPart, myMap.xWork, myMap.yWork, myMap.nDop2, kLinePart, myMap.xWork1, myMap.yWork1, myMap.xWork2, myMap.yWork2, myMap.nWork, myMap.nDop1, myMap.xAdd, myMap.yAdd, myMap.xDop, myMap.yDop, myMap.xPik, myMap.yPik, myMap.nPik, myMap.nSour1, myMap.nSour2, myMap.brColor, myMap.pnColor, xPageBeg, yPageBeg, iPrintShow[10]);
                    }
                }
                if (kPolyFinal > 0 && iPrintShow[3] == 0)
                {
                    iParam = 5;
                    DllClass1.Labels_PrevPrint(e, sPixInch, iScaleMap, xa, ya, kPolyFinal, myMap.namePolyFin, myMap.xLabFin, myMap.yLabFin, myMap.iHorVer, iParam, iPrintShow[10], xPageBeg, yPageBeg);
                }
                if (kNodeAct > 0)
                {
                    iParam = 4;
                    DllClass1.Nodes_PrevPrint(e, sPixInch, iScaleMap, xa, ya, kNodeAct, myMap.nameNodeAct, myMap.xNodeAct, myMap.yNodeAct, myMap.iHorVer, iParam, iPrintShow[10], xPageBeg, yPageBeg);
                }
                if (kNode > 0 && kNodeAct == 0)
                {
                    iParam = 4;
                    DllClass1.Nodes_PrevPrint(e, sPixInch, iScaleMap, xa, ya, kNode, myMap.nameNode, myMap.xNode, myMap.yNode, myMap.iHorVer, iParam, iPrintShow[10], xPageBeg, yPageBeg);
                }
                if (kAddInscript > 0 && iPrintShow[9] > 0)
                    DllClass1.Print_AddInscr(e, kAddInscript, myMap.sAddInscr, myMap.xAddInscr, myMap.yAddInscr, myMap.nHorVer, myMap.nInsCol, myMap.brColor, sPixInch, iScaleMap, xa, ya, xPageBeg, yPageBeg);
                if (kLineCancel > 0 && iPrintShow[7] > 0)
                    DllClass1.Print_CancelLine(e, sPixInch, iScaleMap, xa, ya, kLineCancel, myMap.kLinCanc1, myMap.kLinCanc2, myMap.xLinCanc, myMap.yLinCanc, myMap.RadCanc, myMap.nWork, myMap.nWork1, myMap.nWork2, myMap.xWork1, myMap.yWork1, myMap.xWork2, myMap.yWork2, myMap.xWork, myMap.yWork, myMap.xAdd, myMap.yAdd, myMap.xDop, myMap.yDop, iPrintShow[10], xPageBeg, yPageBeg);
                if (kPolyCancel > 0 && iPrintShow[8] > 0)
                {
                    iParam = 3;
                    DllClass1.Labels_PrevPrint(e, sPixInch, iScaleMap, xa, ya, kPolyCancel, myMap.nameCanc, myMap.xLabCanc, myMap.yLabCanc, myMap.iHorVer, iParam, iPrintShow[10], xPageBeg, yPageBeg);
                }
                if (kInstall > 0)
                {
                    double num1 = 0.01 * (double)iScaleMap;
                    string sTxt = "";
                    double[] x = new double[6];
                    double[] y = new double[6];
                    Graphics graphics = e.Graphics;
                    int k = -1;
                    for (int index = 1; index <= 5; ++index)
                    {
                        ++k;
                        x[k] = xa[index];
                        y[k] = ya[index];
                    }
                    for (int index1 = 1; index1 <= kInstall; ++index1)
                    {
                        ip = DllClass1.in_out(k, ref x, ref y, myMap.xLinParc[index1], myMap.yLinParc[index1]);
                        if (ip != 0)
                        {
                            dx = myMap.xLinParc[index1] - xa[2];
                            dy = myMap.yLinParc[index1] - ya[2];
                            int int32_1 = Convert.ToInt32(10.0 * dx / num1 / sPixInch);
                            int int32_2 = Convert.ToInt32(10.0 * dy / num1 / sPixInch);
                            int num2 = xPageBeg + int32_1;
                            int num3 = yPageBeg - int32_2;
                            int iWid;
                            int iHei;
                            int kPix;
                            int mClr;
                            DllClass1.SelItemPoly(myMap.fitemPoly, myMap.nCent[index1], out int _, out iWid, out iHei, out kPix, myMap.ixSqu, myMap.iySqu, myMap.nColorItm, out sTxt, out mClr);
                            if (iPrintShow[10] == 0)
                            {
                                for (int index2 = 1; index2 <= kPix; ++index2)
                                {
                                    int num4 = num2 + myMap.ixSqu[index2];
                                    int num5 = num3 + myMap.iySqu[index2];
                                    mClr = myMap.nColorItm[index2];
                                    SolidBrush solidBrush = myMap.brColor[1];
                                    graphics.FillRectangle((Brush)solidBrush, num4 - iWid / 2, num5 - iHei / 2, 1, 1);
                                }
                            }
                            if (iPrintShow[10] > 0)
                            {
                                for (int index3 = 1; index3 <= kPix; ++index3)
                                {
                                    int num6 = num2 + myMap.ixSqu[index3];
                                    int num7 = num3 + myMap.iySqu[index3];
                                    mClr = myMap.nColorItm[index3];
                                    SolidBrush solidBrush = myMap.brColor[mClr];
                                    graphics.FillRectangle((Brush)solidBrush, num6 - iWid / 2, num7 - iHei / 2, 1, 1);
                                }
                            }
                        }
                    }
                }
                DllClass1.Page_PrevPrint(e, sPixInch, iScaleMap, xa, ya, xPageBeg, yPageBeg, ixPixel, iyPixel, nPage);
            }
            if (nProcess == 20 && numPage > 0)
                DllClass1.Print_Report(e, sPixInch, dxSheet, dySheet, hText, km, sMess, kPage, kp1, kp2, numPage, newTabPrint, out nTabPrint, iSquare, iPrecision, myMap.nameDop);
            if (nProcess != 30 || numPage <= 0)
                return;
            DllClass1.Print_Area(e, sPixInch, dxSheet, dySheet, hText, kNewMess, sNewMess, kPage, kp1, kp2, numPage, iSquare, iPrecision, iToler, sFormula);
        }

        private void TableAction_Click(object sender, EventArgs e)
        {
            int k = 0;
            int num1 = 0;
            if (File.Exists(myMap.flistAction))
            {
                FileStream input = new FileStream(myMap.flistAction, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    while ((sTmp = binaryReader.ReadString()) != null)
                    {
                        ++num1;
                        if (num1 != 1)
                            ++k;
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
            if (k < 2)
            {
                int num2 = (int)MessageBox.Show("Нет действий", "Печать таблиц", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 20;
                DllClass1.PageCount(sPixInch, dxSheet, dySheet, hText, k, sMess, out kPage, kp1, kp2, kpp, nTab);
                if (kPage > 0)
                {
                    listBox2.Items.Clear();
                    for (int index = 1; index <= kPage; ++index)
                    {
                        sTmp = string.Format("{0}", (object)index) + ".  " + string.Format("{0}", (object)kp1[index]) + "-" + string.Format("{0}", (object)kp2[index]);
                        listBox2.Items.Add((object)sTmp);
                    }
                }
                iSquare = comboBox1.SelectedIndex + 1;
                iPrecision = comboBox2.SelectedIndex + 1;
                DllClass1.Equal_Area(iSquare, iPrecision, sArea, arExter, kPolyFinal, myMap.arCalcFin, myMap.arLegFin, myMap.xOut, myMap.yOut);
                int kMess = 0;
                iSquare = comboBox1.SelectedIndex + 1;
                iPrecision = comboBox2.SelectedIndex + 1;
                DllClass1.TablePrepare(k, sMess, iSquare, iPrecision, out kMess, myMap.nameWork, myMap.nameDop, myMap.xDop, myMap.yDop, sArea, arExter, kPolyFinal, myMap.namePolyFin, myMap.arCalcFin, myMap.arLegFin, myMap.xOut, myMap.yOut);
                myMap.kPolyFinal = kPolyFinal;
                myMap.KeepPolyFin();
                for (int index = 1; index <= k; ++index)
                    sMess[index] = myMap.nameWork[index];
                comboBox1.Visible = false;
                comboBox2.Visible = false;
            }
        }

        private void TableAreas_Click(object sender, EventArgs e)
        {
            if (kPolyFinal == 0)
            {
                int num = (int)MessageBox.Show("Нет данных", "Печать таблиц", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 30;
                iSquare = comboBox1.SelectedIndex + 1;
                iPrecision = comboBox2.SelectedIndex + 1;
                DllClass1.Equal_Area(iSquare, iPrecision, sArea, arExter, kPolyFinal, myMap.arCalcFin, myMap.arLegFin, myMap.xOut, myMap.yOut);
                int kMess = 0;
                iSquare = comboBox1.SelectedIndex + 1;
                iPrecision = comboBox2.SelectedIndex + 1;
                DllClass1.TablePrepare(km, sMess, iSquare, iPrecision, out kMess, myMap.nameWork, myMap.nameDop, myMap.xDop, myMap.yDop, sArea, arExter, kPolyFinal, myMap.namePolyFin, myMap.arCalcFin, myMap.arLegFin, myMap.xOut, myMap.yOut);
                myMap.kPolyFinal = kPolyFinal;
                myMap.KeepPolyFin();
                for (int index = 1; index <= km; ++index)
                    sMess[index] = myMap.nameWork[index];
                DllClass1.Page_Area(sPixInch, dxSheet, dySheet, hText, km, sMess, kPolyFinal, myMap.namePolyFin, myMap.arCalcFin, myMap.arLegFin, out kNewMess, sNewMess, iSquare, iPrecision, out kPage, kp1, kp2, kpp, sArea, arExter, myMap.xOut, myMap.yOut);
                if (kPage > 0)
                {
                    listBox2.Items.Clear();
                    for (int index = 1; index <= kPage; ++index)
                    {
                        sTmp = string.Format("{0}", (object)index) + ".  " + string.Format("{0}", (object)kp1[index]) + "-" + string.Format("{0}", (object)kp2[index]);
                        listBox2.Items.Add((object)sTmp);
                    }
                }
                comboBox1.Visible = false;
                comboBox2.Visible = false;
            }
        }

        private void PageAction_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex < 0)
            {
                int num1 = (int)MessageBox.Show("Страница не выбрана.", "Печать страницы", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                numPage = listBox2.SelectedIndex + 1;
                Controls.Remove((Control)PrintPreviewControl1);
                newTable = 0;
                if (numPage > 1)
                {
                    int num2 = numPage - 1;
                    for (int index = 1; index <= num2; ++index)
                        newTable += nTab[index];
                }
                Init_Preview();
            }
        }

        private void PrintAction_Click(object sender, EventArgs e)
        {
            if (numPage <= 0)
            {
                int num1 = (int)MessageBox.Show("Страница не выбрана.", "Печать страницы", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                newTabPrint = 0;
                if (numPage > 1)
                {
                    int num2 = numPage - 1;
                    for (int index = 1; index <= num2; ++index)
                        newTabPrint += nTab[index];
                }
                Init_Print();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (iGraphic > 0)
                return;
            if (kPolyFinal > 0)
            {
                int iParam = 8;
                DllClass1.LabelDraw(e, kPolyFinal, myMap.namePolyFin, myMap.xLabFin, myMap.yLabFin, myMap.iHorVer, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myMap.brColor, iParam);
            }
            if (kLineFinal > 0)
            {
                int iPar = 1;
                DllClass1.LineDraw(e, kLineFinal, myMap.k1Fin, myMap.k2Fin, myMap.xFin, myMap.yFin, myMap.rRadFin, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myMap.pnColor, iPar);
            }
            if (kList > 0)
            {
                int iPar = 2;
                for (int index = 1; index <= kList; ++index)
                    myMap.zCont[index] = 0.0;
                DllClass1.LineDraw(e, kList, myMap.kn1, myMap.kn2, myMap.xCont, myMap.yCont, myMap.zCont, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myMap.pnColor, iPar);
            }
            if (File.Exists(myMap.fileContour))
                DllClass1.ContourDraw(e, myMap.fileContour, myMap.xDop, myMap.yDop, myMap.xOut, myMap.yOut, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            if (kPntFin <= 0)
                return;
            DllClass1.PointsDraw(e, myMap.fsymbPnt, -1, kPntFin, myMap.namePntFin, myMap.xPntFin, myMap.yPntFin, myMap.zPntFin, myMap.xPntInscr, myMap.yPntInscr, myMap.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myMap.nCode1Fin, myMap.nCode2Fin, kSymbPnt, myMap.numRec, myMap.numbUser, myMap.ixSqu, myMap.iySqu, myMap.nColor, myMap.brColor, myMap.pnColor);
        }

        private void Quit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

    }
}
