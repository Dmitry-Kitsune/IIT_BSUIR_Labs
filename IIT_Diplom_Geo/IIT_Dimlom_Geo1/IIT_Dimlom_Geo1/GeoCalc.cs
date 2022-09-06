using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using Microsoft.Win32;
using DiplomGeoDLL;
using IIT_Diplom_Geo1;
using System.Drawing.Printing;


namespace IIT_Dimlom_Geo1
{
    public partial class GeoCalc : Form
    {
        private string sTmp = "";
        private string sTmp1 = "";
        private string sTmp2 = "";
        private string sTmp3 = "";
        private string sTmp4 = "";
        private string sTmp5 = "";
        private int pixWid;
        private int pixHei;
        private int iWidth;
        private int iHeight;
        private int iGraphic;
        private int kSymbPnt;
        private int kSymbLine;
        private int hSymbLine = 20;
        private int kGeo;
        private int kGeoNode;
        private int kGeoLine;
        private int kDop;
        private int kPntInput;
        private int kLineInput;
        private int kLinePnt;
        private int kGeoFin;
        private int kTaheo;
        private int kDif;
        private int xBegWin;
        private int yBegWin;
        private int xEndWin;
        private int yEndWin;
        private int nProcess;
        private int kCheck;
        private int kLineDop;
        private int kAdd;
        private int x1Box;
        private int y1Box;
        private int x2Box;
        private int y2Box;
        private int nControl;
        private int kDat;
        private int[] xDat = new int[1000];
        private int[] yDat = new int[1000];
        private int[] nDat = new int[1000];
        private string[] sDat = new string[1000];
        private double[] eRel = new double[1000];
        private double[] aRel = new double[1000];
        private int iCond;
        private int kSel;
        private int indPnt;
        private int iToler;
        private int kStt;
        private int ikk;
        private int dxSheet = 216;
        private int dySheet = 279;
        private int dxPage = 16;
        private int dyPage = 22;
        private int xPageBeg;
        private int yPageBeg;
        private int ixPixel;
        private int iyPixel;
        private int iScaleMap;
        private int kPage;
        private int ka;
        private int nPage;
        private int iColorPrint;
        private int k;
        private int kLineGeo;
        private int kRcPnt;
        private int kGeoAll;
        private int numCode;
        private int indexGeo;
        private int indexDTM = -1;
        private double xmin;
        private double ymin;
        private double xmax;
        private double ymax;
        private double xminCur;
        private double yminCur;
        private double xmaxCur;
        private double ymaxCur;
        private double zeroSpot;
        private double scaleToWin;
        private double scaleToGeo;
        private double xBegX;
        private double yBegY;
        private double xEndX;
        private double yEndY;
        private double dx;
        private double dy;
        private double xCurMin;
        private double yCurMin;
        private double xCurMax;
        private double yCurMax;
        private double xCur;
        private double yCur;
        private double xaCur;
        private double yaCur;
        private double xbCur;
        private double ybCur;
        private double sPixInch = 0.254;
        private int nProblem;
        private double[] x1 = new double[200];
        private double[] y1 = new double[200];
        private double[] x2 = new double[200];
        private double[] y2 = new double[200];
        private double[] x3 = new double[200];
        private double[] y3 = new double[200];
        private double[] x4 = new double[200];
        private double[] y4 = new double[200];
        private double[] xa = new double[10];
        private double[] ya = new double[10];
        private int[] iPrintShow = new int[21];

        private PrintDocument docToPreview = new PrintDocument();
        MyGeodesy myGeoCalc = new MyGeodesy();
        public GeoCalc()
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
            button10.MouseHover += new EventHandler(button10_MouseHover);
            button10.MouseLeave += new EventHandler(button10_MouseLeave);
            button1.MouseHover += new EventHandler(button1_MouseHover);
            button1.MouseLeave += new EventHandler(button10_MouseLeave);
            button11.MouseHover += new EventHandler(button11_MouseHover);
            button11.MouseLeave += new EventHandler(button10_MouseLeave);
            button12.MouseHover += new EventHandler(button12_MouseHover);
            button12.MouseLeave += new EventHandler(button10_MouseLeave);
            button21.MouseHover += new EventHandler(button21_MouseHover);
            button21.MouseLeave += new EventHandler(button10_MouseLeave);
            button20.MouseHover += new EventHandler(button20_MouseHover);
            button20.MouseLeave += new EventHandler(button10_MouseLeave);
            button18.MouseHover += new EventHandler(button18_MouseHover);
            button18.MouseLeave += new EventHandler(button10_MouseLeave);
            button31.MouseHover += new EventHandler(button31_MouseHover);
            button31.MouseLeave += new EventHandler(button10_MouseLeave);
            button19.MouseHover += new EventHandler(button19_MouseHover);
            button19.MouseLeave += new EventHandler(button10_MouseLeave);
            button32.MouseHover += new EventHandler(button32_MouseHover);
            button32.MouseLeave += new EventHandler(button10_MouseLeave);
            button22.MouseHover += new EventHandler(button22_MouseHover);
            button22.MouseLeave += new EventHandler(button10_MouseLeave);
            button28.MouseHover += new EventHandler(button28_MouseHover);
            button28.MouseLeave += new EventHandler(button10_MouseLeave);
            FormLoad();
        }

        private void button10_MouseHover(object sender, EventArgs e) => label9.Text = "Close Dialogue";

        private void button10_MouseLeave(object sender, EventArgs e) => label9.Text = "";

        private void button1_MouseHover(object sender, EventArgs e) => label9.Text = "Open Standard Dialogue for Input data file of measurements of Geodetic foundation";

        private void button17_MouseHover(object sender, EventArgs e) => label9.Text = "Open Dialogue for creation and update points' symbology";

        private void button11_MouseHover(object sender, EventArgs e) => label9.Text = "Open Standard Dialogue for Input data file of measurements of DTM points";

        private void button12_MouseHover(object sender, EventArgs e) => label9.Text = "Open Dialogue for addition points, measured with other methods";

        private void button21_MouseHover(object sender, EventArgs e) => label9.Text = "Click button and select point. Change symbol or click button 'Help selection'. Click button 'Save symbol'";

        private void button20_MouseHover(object sender, EventArgs e) => label9.Text = "Click button and select point. Change symbol or click button 'Help selection'. Click button 'Save symbol'";

        private void button18_MouseHover(object sender, EventArgs e) => label9.Text = "Click button of mouse near description and after that on new spot for this description";

        private void button31_MouseHover(object sender, EventArgs e) => label9.Text = "Click button of mouse near description and after that on new spot for this description";

        private void button19_MouseHover(object sender, EventArgs e) => label9.Text = "Click button of mouse near description for changing it horizontal or vertical position";

        private void button32_MouseHover(object sender, EventArgs e) => label9.Text = "Click button of mouse near description for changing it horizontal or vertical position";

        private void button22_MouseHover(object sender, EventArgs e) => label9.Text = "Before clicking button select scale";

        private void button28_MouseHover(object sender, EventArgs e) => label9.Text = "Before clicking button select scale";



        private void FormLoad()
        {
            iGraphic = 0;
            myGeoCalc.FilePath();
            if (!File.Exists(myGeoCalc.tmpStr))
            {
                int num1 = (int)new SelectDrive().ShowDialog((IWin32Window)this);
                //int num1 = (int)new ProjectMenu().ShowDialog((IWin32Window)this);
                //int num1 = (int)new ChangeDrive().ShowDialog((IWin32Window)this);
            }
            myGeoCalc.FilePath();
            int kPart = 50;
            char[] seps = new char[1] { '\\' };
            string[] sPart = new string[50];
            int k = 0;
            DllClass1.ShareString(myGeoCalc.comPath, kPart, seps, out k, out sPart);
            myGeoCalc.pathSymbol = sPart[1] + "\\BrSymbol\\";
            myGeoCalc.fsymbPnt = myGeoCalc.pathSymbol + "brsymb.pnt";
            if (!File.Exists(myGeoCalc.fileProj))
            {
                label2.Text = sPart[1] + "\\--Проект не выбран";
                if (File.Exists(myGeoCalc.fileAllProj))
                    return;
                int num2 = (int)MessageBox.Show("Click 'New project' for opening project");
            }
            else
            {
                sTmp = myGeoCalc.comPath + myGeoCalc.curDirect;
                if (!Directory.Exists(sTmp))
                    Directory.CreateDirectory(sTmp);
                label2.Text = sPart[1] + "\\+" + myGeoCalc.curProject;
                LoadData();
                if (kGeo == 0)
                {
                    int num3 = (int)MessageBox.Show("Use 'Measurements data file input'", "GeoCalc", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                panel7.Invalidate();
            }
        }

        public void LoadData()
        {
            int num1 = 0;
            nProblem = 10;
            if (File.Exists(myGeoCalc.fProblem))
                File.Delete(myGeoCalc.fProblem);
            FileStream output1 = new FileStream(myGeoCalc.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
            binaryWriter1.Write(nProblem);
            binaryWriter1.Close();
            output1.Close();
            xmin = 9999999.9;
            ymin = 9999999.9;
            xmax = -9999999.9;
            ymax = -9999999.9;
            DllClass1.SetColour(myGeoCalc.brColor, myGeoCalc.pnColor);
            DllClass1.PointSymbLoad(myGeoCalc.fsymbPnt, out kSymbPnt, myGeoCalc.numRec, myGeoCalc.numbUser, myGeoCalc.heiSymb);
            myGeoCalc.kSymbPnt = kSymbPnt;
            DllClass1.LineSymbolLoad(myGeoCalc.fsymbLine, out kSymbLine, out hSymbLine, myGeoCalc.sSymbLine, myGeoCalc.x1Line, myGeoCalc.y1Line, myGeoCalc.x2Line, myGeoCalc.y2Line, myGeoCalc.xDescr, myGeoCalc.yDescr, myGeoCalc.x1Dens, myGeoCalc.y1Dens, myGeoCalc.x1Sign, myGeoCalc.y1Sign, myGeoCalc.x2Sign, myGeoCalc.y2Sign, myGeoCalc.n1Sign, myGeoCalc.n2Sign, myGeoCalc.iStyle1, myGeoCalc.iStyle2, myGeoCalc.iWidth1, myGeoCalc.iWidth2, myGeoCalc.nColLine, myGeoCalc.nItem, myGeoCalc.itemLoc, myGeoCalc.nBaseSymb, myGeoCalc.sInscr, myGeoCalc.hInscr, myGeoCalc.iColInscr, myGeoCalc.iDensity);
            kGeo = 0;
            if (File.Exists(myGeoCalc.fgeoGeo))
            {
                FileStream input = new FileStream(myGeoCalc.fgeoGeo, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kGeo = binaryReader.ReadInt32();
                    for (int index = 1; index <= kGeo; ++index)
                    {
                        myGeoCalc.nameGeo[index] = binaryReader.ReadString();
                        myGeoCalc.xGeo[index] = binaryReader.ReadDouble();
                        myGeoCalc.yGeo[index] = binaryReader.ReadDouble();
                        myGeoCalc.zGeo[index] = binaryReader.ReadDouble();
                        myGeoCalc.nGeoCode[index] = binaryReader.ReadInt32();
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
                if (!File.Exists(myGeoCalc.fGeoInscr))
                {
                    FileStream output2 = new FileStream(myGeoCalc.fGeoInscr, FileMode.CreateNew);
                    BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                    binaryWriter2.Write(kGeo);
                    for (int index = 1; index <= kGeo; ++index)
                    {
                        myGeoCalc.xGeoInscr[index] = myGeoCalc.xGeo[index];
                        myGeoCalc.yGeoInscr[index] = myGeoCalc.yGeo[index];
                        myGeoCalc.iHorVerGeo[index] = 0;
                        binaryWriter2.Write(myGeoCalc.xGeoInscr[index]);
                        binaryWriter2.Write(myGeoCalc.yGeoInscr[index]);
                        binaryWriter2.Write(myGeoCalc.iHorVerGeo[index]);
                    }
                    binaryWriter2.Close();
                    output2.Close();
                }
                myGeoCalc.InscrLoadKeep(1);
            }
            myGeoCalc.KeepLoadGeoAll(2, ref kGeoAll);
            kGeoNode = 0;
            if (File.Exists(myGeoCalc.fgeoNode))
            {
                FileStream input = new FileStream(myGeoCalc.fgeoNode, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kGeoNode = binaryReader.ReadInt32();
                    if (kGeoNode > 0)
                    {
                        for (int index = 1; index <= kGeoNode; ++index)
                        {
                            myGeoCalc.nameNode[index] = binaryReader.ReadString();
                            myGeoCalc.xNode[index] = binaryReader.ReadDouble();
                            myGeoCalc.yNode[index] = binaryReader.ReadDouble();
                            myGeoCalc.zNode[index] = binaryReader.ReadDouble();
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
            kGeoLine = 0;
            kDop = 0;
            kLineGeo = 0;
            int index1 = 0;
            if (File.Exists(myGeoCalc.fgeoLine))
            {
                FileStream input = new FileStream(myGeoCalc.fgeoLine, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kGeoLine = binaryReader.ReadInt32();
                    for (int index2 = 1; index2 <= kGeoLine; ++index2)
                    {
                        myGeoCalc.namePnt1[index2] = binaryReader.ReadString();
                        myGeoCalc.xPnt1[index2] = binaryReader.ReadDouble();
                        myGeoCalc.yPnt1[index2] = binaryReader.ReadDouble();
                        myGeoCalc.zPnt1[index2] = binaryReader.ReadDouble();
                        myGeoCalc.namePnt2[index2] = binaryReader.ReadString();
                        myGeoCalc.xPnt2[index2] = binaryReader.ReadDouble();
                        myGeoCalc.yPnt2[index2] = binaryReader.ReadDouble();
                        myGeoCalc.zPnt2[index2] = binaryReader.ReadDouble();
                        myGeoCalc.distAver[index2] = binaryReader.ReadDouble();
                        myGeoCalc.horAver[index2] = binaryReader.ReadDouble();
                        myGeoCalc.verAver[index2] = binaryReader.ReadDouble();
                        int index3 = index1 + 1;
                        myGeoCalc.xLineGeo[index3] = myGeoCalc.xPnt1[index2];
                        myGeoCalc.yLineGeo[index3] = myGeoCalc.yPnt1[index2];
                        index1 = index3 + 1;
                        myGeoCalc.xLineGeo[index1] = myGeoCalc.xPnt2[index2];
                        myGeoCalc.yLineGeo[index1] = myGeoCalc.yPnt2[index2];
                        ++kLineGeo;
                        myGeoCalc.kGin[kLineGeo] = 2;
                        myGeoCalc.rRadGeo[kLineGeo] = 0.0;
                        myGeoCalc.xRadGeo[kLineGeo] = 0.0;
                        myGeoCalc.yRadGeo[kLineGeo] = 0.0;
                        if (myGeoCalc.xPnt1[index2] != 0.0 && myGeoCalc.yPnt1[index2] != 0.0 && myGeoCalc.xPnt2[index2] != 0.0 && myGeoCalc.yPnt2[index2] != 0.0)
                        {
                            int num2 = 0;
                            int num3 = 0;
                            for (int index4 = 1; index4 <= kGeo; ++index4)
                            {
                                if (myGeoCalc.namePnt1[index2] == myGeoCalc.nameGeo[index4])
                                    ++num2;
                                if (myGeoCalc.namePnt2[index2] == myGeoCalc.nameGeo[index4])
                                    ++num3;
                            }
                            if (num2 == 0)
                            {
                                ++kDop;
                                myGeoCalc.nameDop[kDop] = myGeoCalc.namePnt1[index2];
                                myGeoCalc.xDop[kDop] = myGeoCalc.xPnt1[index2];
                                myGeoCalc.yDop[kDop] = myGeoCalc.yPnt1[index2];
                                myGeoCalc.zDop[kDop] = myGeoCalc.zPnt1[index2];
                            }
                            if (num3 == 0)
                            {
                                ++kDop;
                                myGeoCalc.nameDop[kDop] = myGeoCalc.namePnt2[index2];
                                myGeoCalc.xDop[kDop] = myGeoCalc.xPnt2[index2];
                                myGeoCalc.yDop[kDop] = myGeoCalc.yPnt2[index2];
                                myGeoCalc.zDop[kDop] = myGeoCalc.zPnt2[index2];
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
            if (kLineGeo > 0)
            {
                myGeoCalc.kGeo1[1] = 1;
                myGeoCalc.kGeo2[1] = myGeoCalc.kGin[1];
                if (kLineGeo > 0)
                {
                    for (int index5 = 2; index5 <= kLineGeo; ++index5)
                    {
                        myGeoCalc.kGeo1[index5] = myGeoCalc.kGeo2[index5 - 1] + 1;
                        myGeoCalc.kGeo2[index5] = myGeoCalc.kGeo2[index5 - 1] + myGeoCalc.kGin[index5];
                    }
                }
            }
            if (kDop > 1)
            {
                num1 = 0;
                for (int index6 = 1; index6 <= kDop; ++index6)
                {
                    if (myGeoCalc.xDop[index6] != 0.0 || myGeoCalc.yDop[index6] != 0.0)
                    {
                        for (int index7 = index6 + 1; index7 < kDop; ++index7)
                        {
                            if ((myGeoCalc.xDop[index7] != 0.0 || myGeoCalc.yDop[index7] != 0.0) && myGeoCalc.nameDop[index6] == myGeoCalc.nameDop[index7])
                            {
                                myGeoCalc.xDop[index7] = 0.0;
                                myGeoCalc.yDop[index7] = 0.0;
                            }
                        }
                    }
                }
                int index8 = 0;
                for (int index9 = 1; index9 <= kDop; ++index9)
                {
                    if (myGeoCalc.xDop[index9] != 0.0 || myGeoCalc.yDop[index9] != 0.0)
                    {
                        ++index8;
                        myGeoCalc.nameDop[index8] = myGeoCalc.nameDop[index9];
                        myGeoCalc.xDop[index8] = myGeoCalc.xDop[index9];
                        myGeoCalc.yDop[index8] = myGeoCalc.yDop[index9];
                        myGeoCalc.zDop[index8] = myGeoCalc.zDop[index9];
                    }
                }
                kDop = index8;
                if (kDop > 0)
                {
                    for (int index10 = 1; index10 <= kDop; ++index10)
                        myGeoCalc.iCode1[index10] = 0;
                    for (int index11 = 1; index11 <= kGeo; ++index11)
                    {
                        int num4 = 0;
                        for (int index12 = 1; index12 <= kDop; ++index12)
                        {
                            double num5 = myGeoCalc.xGeo[index11] - myGeoCalc.xDop[index12];
                            double num6 = myGeoCalc.yGeo[index11] - myGeoCalc.yDop[index12];
                            if (Math.Sqrt(num5 * num5 + num6 * num6) < 0.005)
                            {
                                ++num4;
                                myGeoCalc.nameDop[index12] = myGeoCalc.nameGeo[index11];
                                myGeoCalc.xDop[index12] = myGeoCalc.xGeo[index11];
                                myGeoCalc.yDop[index12] = myGeoCalc.yGeo[index11];
                                myGeoCalc.zDop[index12] = myGeoCalc.zGeo[index11];
                                myGeoCalc.iCode1[index12] = myGeoCalc.nGeoCode[index11];
                                break;
                            }
                        }
                        if (num4 <= 0)
                        {
                            ++kDop;
                            myGeoCalc.nameDop[kDop] = myGeoCalc.nameGeo[index11];
                            myGeoCalc.xDop[kDop] = myGeoCalc.xGeo[index11];
                            myGeoCalc.yDop[kDop] = myGeoCalc.yGeo[index11];
                            myGeoCalc.zDop[kDop] = myGeoCalc.zGeo[index11];
                            myGeoCalc.iCode1[kDop] = myGeoCalc.nGeoCode[index11];
                        }
                    }
                }
            }
            kPntInput = 0;
            if (File.Exists(myGeoCalc.filePoints))
            {
                FileStream input = new FileStream(myGeoCalc.filePoints, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kPntInput = binaryReader.ReadInt32();
                    for (int index13 = 1; index13 <= kPntInput; ++index13)
                    {
                        myGeoCalc.nameGeo[index13] = binaryReader.ReadString();
                        myGeoCalc.xGeo[index13] = binaryReader.ReadDouble();
                        myGeoCalc.yGeo[index13] = binaryReader.ReadDouble();
                        myGeoCalc.zGeo[index13] = binaryReader.ReadDouble();
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
            kLineInput = 0;
            if (File.Exists(myGeoCalc.flineLine))
            {
                FileStream input = new FileStream(myGeoCalc.flineLine, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kLineInput = binaryReader.ReadInt32();
                    for (int index14 = 1; index14 <= kLineInput; ++index14)
                    {
                        kLinePnt = binaryReader.ReadInt32();
                        for (int index15 = 1; index15 <= kLinePnt; ++index15)
                        {
                            myGeoCalc.nameAdd[index15] = binaryReader.ReadString();
                            myGeoCalc.xAdd[index15] = binaryReader.ReadDouble();
                            myGeoCalc.yAdd[index15] = binaryReader.ReadDouble();
                        }
                        if (kPntInput > 0)
                        {
                            for (int index16 = 1; index16 <= kPntInput; ++index16)
                            {
                                for (int index17 = 1; index17 <= kLinePnt; ++index17)
                                {
                                    if (myGeoCalc.nameGeo[index16] == myGeoCalc.nameAdd[index17])
                                    {
                                        myGeoCalc.xGeo[index16] = myGeoCalc.xAdd[index17];
                                        myGeoCalc.yGeo[index16] = myGeoCalc.yAdd[index17];
                                        break;
                                    }
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
            int iCond = 0;
            myGeoCalc.PointCollect(0, kGeo, myGeoCalc.nameGeo, out iCond);
            if (iCond < 0)
            {
                int num7 = (int)MessageBox.Show("Check and Correct Data");
                iGraphic = 1;
            }
            else
            {
                kGeoFin = myGeoCalc.kGeoFin;
                if (kGeoFin < 1)
                    return;
                if (kGeoFin > 0)
                {
                    if (File.Exists(myGeoCalc.fcalcPoint))
                        File.Delete(myGeoCalc.fcalcPoint);
                    FileStream output3 = new FileStream(myGeoCalc.fcalcPoint, FileMode.CreateNew);
                    BinaryWriter binaryWriter3 = new BinaryWriter((Stream)output3);
                    binaryWriter3.Write(kGeoFin);
                    for (int index18 = 0; index18 <= kGeoFin; ++index18)
                    {
                        binaryWriter3.Write(myGeoCalc.nameFin[index18]);
                        binaryWriter3.Write(myGeoCalc.xFin[index18]);
                        binaryWriter3.Write(myGeoCalc.yFin[index18]);
                        binaryWriter3.Write(myGeoCalc.zFin[index18]);
                        myGeoCalc.iCode1[index18] = 0;
                        binaryWriter3.Write(myGeoCalc.iCode1[index18]);
                    }
                    binaryWriter3.Close();
                    output3.Close();
                    if (!File.Exists(myGeoCalc.fileInscr))
                    {
                        FileStream output4 = new FileStream(myGeoCalc.fileInscr, FileMode.CreateNew);
                        BinaryWriter binaryWriter4 = new BinaryWriter((Stream)output4);
                        binaryWriter4.Write(kGeoFin);
                        for (int index19 = 0; index19 <= kGeoFin; ++index19)
                        {
                            myGeoCalc.xPntInscr[index19] = myGeoCalc.xFin[index19];
                            myGeoCalc.yPntInscr[index19] = myGeoCalc.yFin[index19];
                            myGeoCalc.iHorVerPnt[index19] = 0;
                            binaryWriter4.Write(myGeoCalc.xFin[index19]);
                            binaryWriter4.Write(myGeoCalc.yFin[index19]);
                            binaryWriter4.Write(myGeoCalc.iHorVerPnt[index19]);
                        }
                        binaryWriter4.Close();
                        output4.Close();
                    }
                    myGeoCalc.LoadInscrKeep(1);
                    if (kGeoAll == 0)
                    {
                        kGeoAll = kGeo;
                        for (int index20 = 0; index20 <= kGeoFin; ++index20)
                        {
                            int num8 = 0;
                            for (int index21 = 1; index21 <= kGeo; ++index21)
                            {
                                if (myGeoCalc.nameFin[index20] == myGeoCalc.nameGeo[index21])
                                {
                                    ++num8;
                                    break;
                                }
                            }
                            if (num8 <= 0)
                            {
                                ++kGeoAll;
                                myGeoCalc.nameGeo[kGeoAll] = myGeoCalc.nameFin[index20];
                                myGeoCalc.xGeo[kGeoAll] = myGeoCalc.xFin[index20];
                                myGeoCalc.yGeo[kGeoAll] = myGeoCalc.yFin[index20];
                                myGeoCalc.zGeo[kGeoAll] = myGeoCalc.zFin[index20];
                                myGeoCalc.nGeoCode[kGeoAll] = myGeoCalc.iCode1[index20];
                                myGeoCalc.xGeoInscr[kGeoAll] = myGeoCalc.xPntInscr[index20];
                                myGeoCalc.yGeoInscr[kGeoAll] = myGeoCalc.yPntInscr[index20];
                                myGeoCalc.iHorVerGeo[kGeoAll] = myGeoCalc.iHorVerPnt[index20];
                            }
                        }
                        if (kGeoAll > 0)
                            myGeoCalc.KeepLoadGeoAll(1, ref kGeoAll);
                    }
                }
                kTaheo = 0;
                if (File.Exists(myGeoCalc.ftahPoint))
                {
                    FileStream input = new FileStream(myGeoCalc.ftahPoint, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        kTaheo = binaryReader.ReadInt32();
                        for (int index22 = 0; index22 <= kTaheo; ++index22)
                        {
                            myGeoCalc.nameTah[index22] = binaryReader.ReadString();
                            myGeoCalc.xTah[index22] = binaryReader.ReadDouble();
                            myGeoCalc.yTah[index22] = binaryReader.ReadDouble();
                            myGeoCalc.zTah[index22] = binaryReader.ReadDouble();
                            myGeoCalc.nTah1[index22] = binaryReader.ReadInt32();
                            myGeoCalc.xTahInscr[index22] = binaryReader.ReadDouble();
                            myGeoCalc.yTahInscr[index22] = binaryReader.ReadDouble();
                            myGeoCalc.iHorVerTah[index22] = binaryReader.ReadInt32();
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
                    for (int index23 = 0; index23 <= kTaheo; ++index23)
                    {
                        num1 = 0;
                        for (int index24 = 1; index24 <= kGeoAll; ++index24)
                        {
                            dx = myGeoCalc.xTah[index23] - myGeoCalc.xGeo[index24];
                            dy = myGeoCalc.yTah[index23] - myGeoCalc.yGeo[index24];
                            if (Math.Sqrt(dx * dx + dy * dy) < 0.1)
                                myGeoCalc.nTah1[index23] = myGeoCalc.nGeoCode[index24];
                        }
                    }
                    myGeoCalc.kTaheo = kTaheo;
                    myGeoCalc.LoadKeepTaheo(2);
                    myGeoCalc.LoadKeepTaheo(1);
                }
                zeroSpot = 0.0;
                kDif = 0;
                if (File.Exists(myGeoCalc.fileDifer))
                {
                    FileStream input = new FileStream(myGeoCalc.fileDifer, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    kDif = binaryReader.ReadInt32();
                    for (int index25 = 1; index25 <= kDif; ++index25)
                    {
                        myGeoCalc.n1Pnt[index25] = binaryReader.ReadString();
                        myGeoCalc.n2Pnt[index25] = binaryReader.ReadString();
                        myGeoCalc.distDif[index25] = binaryReader.ReadDouble();
                        myGeoCalc.horDif[index25] = binaryReader.ReadDouble();
                        myGeoCalc.verDif[index25] = binaryReader.ReadDouble();
                        myGeoCalc.dhDif[index25] = binaryReader.ReadDouble();
                        myGeoCalc.verZero[index25] = binaryReader.ReadDouble();
                        zeroSpot += myGeoCalc.verZero[index25];
                    }
                    binaryReader.Close();
                    input.Close();
                    if (kDif > 0)
                        zeroSpot /= (double)kDif;
                }
                if (kDif == 0)
                {
                    int num9 = (int)MessageBox.Show("Zenith angle isn't define");
                }
                kCheck = 0;
                if (File.Exists(myGeoCalc.fileCheck))
                {
                    FileStream input = new FileStream(myGeoCalc.fileCheck, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        kStt = binaryReader.ReadInt32();
                        for (int index26 = 1; index26 <= kStt; ++index26)
                        {
                            sTmp = binaryReader.ReadString();
                            int num10 = binaryReader.ReadInt32();
                            for (int index27 = 1; index27 <= num10; ++index27)
                            {
                                binaryReader.ReadString();
                                double num11 = binaryReader.ReadDouble();
                                ++kCheck;
                                myGeoCalc.n1Check[kCheck] = sTmp;
                                myGeoCalc.distCheck[kCheck] = num11;
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
                kLineDop = 0;
                if (File.Exists(myGeoCalc.fgeoPoly))
                {
                    string[] strArray = new string[10];
                    double[] numArray1 = new double[10];
                    double[] numArray2 = new double[10];
                    double[] numArray3 = new double[10];
                    FileStream input = new FileStream(myGeoCalc.fgeoPoly, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        kLineDop = binaryReader.ReadInt32();
                        for (int index28 = 1; index28 <= kLineDop; ++index28)
                        {
                            kAdd = binaryReader.ReadInt32();
                            for (int index29 = 1; index29 <= 2; ++index29)
                            {
                                strArray[index29] = binaryReader.ReadString();
                                numArray1[index29] = binaryReader.ReadDouble();
                                numArray2[index29] = binaryReader.ReadDouble();
                                numArray3[index29] = binaryReader.ReadDouble();
                            }
                            myGeoCalc.sGeoDop1[index28] = strArray[1];
                            myGeoCalc.xGeoDop1[index28] = numArray1[1];
                            myGeoCalc.yGeoDop1[index28] = numArray2[1];
                            myGeoCalc.zGeoDop1[index28] = numArray3[1];
                            myGeoCalc.sGeoDop2[index28] = strArray[2];
                            myGeoCalc.xGeoDop2[index28] = numArray1[2];
                            myGeoCalc.yGeoDop2[index28] = numArray2[2];
                            myGeoCalc.zGeoDop2[index28] = numArray3[2];
                            double num12 = numArray1[2] - numArray1[1];
                            double num13 = numArray2[2] - numArray2[1];
                            double num14 = Math.Sqrt(num12 * num12 + num13 * num13);
                            ikk = 0;
                            if (kCheck > 0)
                            {
                                for (int index30 = 1; index30 < kCheck; ++index30)
                                {
                                    if (myGeoCalc.n1Check[index30] == strArray[1] && Math.Abs(myGeoCalc.distCheck[index30] - num14) > 0.5 * myGeoCalc.distCheck[index30])
                                    {
                                        ++ikk;
                                        break;
                                    }
                                    if (myGeoCalc.n1Check[index30] == strArray[2] && Math.Abs(myGeoCalc.distCheck[index30] - num14) > 0.5 * myGeoCalc.distCheck[index30])
                                    {
                                        ++ikk;
                                        break;
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
                xmin = 9999999.9;
                ymin = 9999999.9;
                xmax = -9999999.9;
                ymax = -9999999.9;
                if (kGeo > 1)
                {
                    for (int index31 = 1; index31 <= kGeo; ++index31)
                    {
                        if (xmin > myGeoCalc.xGeo[index31])
                            xmin = myGeoCalc.xGeo[index31];
                        if (ymin > myGeoCalc.yGeo[index31])
                            ymin = myGeoCalc.yGeo[index31];
                        if (xmax < myGeoCalc.xGeo[index31])
                            xmax = myGeoCalc.xGeo[index31];
                        if (ymax < myGeoCalc.yGeo[index31])
                            ymax = myGeoCalc.yGeo[index31];
                    }
                    nProblem = 11;
                    if (File.Exists(myGeoCalc.fProblem))
                        File.Delete(myGeoCalc.fProblem);
                    FileStream output5 = new FileStream(myGeoCalc.fProblem, FileMode.CreateNew);
                    BinaryWriter binaryWriter5 = new BinaryWriter((Stream)output5);
                    binaryWriter5.Write(nProblem);
                    binaryWriter5.Close();
                    output5.Close();
                }
                if (kTaheo > 0)
                {
                    for (int index32 = 0; index32 <= kTaheo; ++index32)
                    {
                        if (xmin > myGeoCalc.xTah[index32])
                            xmin = myGeoCalc.xTah[index32];
                        if (ymin > myGeoCalc.yTah[index32])
                            ymin = myGeoCalc.yTah[index32];
                        if (xmax < myGeoCalc.xTah[index32])
                            xmax = myGeoCalc.xTah[index32];
                        if (ymax < myGeoCalc.yTah[index32])
                            ymax = myGeoCalc.yTah[index32];
                    }
                    nProblem = 12;
                    if (File.Exists(myGeoCalc.fProblem))
                        File.Delete(myGeoCalc.fProblem);
                    FileStream output6 = new FileStream(myGeoCalc.fProblem, FileMode.CreateNew);
                    BinaryWriter binaryWriter6 = new BinaryWriter((Stream)output6);
                    binaryWriter6.Write(nProblem);
                    binaryWriter6.Close();
                    output6.Close();
                }
                xminCur = xmin;
                yminCur = ymin;
                xmaxCur = xmax;
                ymaxCur = ymax;
                DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                if (iCond < 0)
                    iGraphic = 1;
                panel7.Invalidate();
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (iGraphic > 0)
                return;
            if (nProcess == 0)
            {
                if (kGeo > 0 && kLineDop > 0 && kTaheo == 0)
                {
                    myGeoCalc.GeoLineDraw(e, kLineDop, myGeoCalc.sGeoDop1, myGeoCalc.xGeoDop1, 
                        myGeoCalc.yGeoDop1, myGeoCalc.sGeoDop2, myGeoCalc.xGeoDop2, myGeoCalc.yGeoDop2,
                        kGeo, myGeoCalc.nameGeo, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                    DllClass1.PointsDraw(e, myGeoCalc.fsymbPnt, 0, kGeoAll, myGeoCalc.nameGeo, myGeoCalc.xGeo,
                        myGeoCalc.yGeo, myGeoCalc.zGeo, myGeoCalc.xGeoInscr, myGeoCalc.yGeoInscr, 
                        myGeoCalc.iHorVerGeo, scaleToWin, xBegX, yBegY, xBegWin, yBegWin,
                        myGeoCalc.nGeoCode, myGeoCalc.nCode2, kSymbPnt, myGeoCalc.numRec, myGeoCalc.numbUser,
                        myGeoCalc.ixSqu, myGeoCalc.iySqu, myGeoCalc.numCol, myGeoCalc.brColor, 
                        myGeoCalc.pnColor);
                }
                if (kTaheo > 0)
                    DllClass1.PointsDraw(e, myGeoCalc.fsymbPnt, 0, kTaheo, myGeoCalc.nameTah, 
                        myGeoCalc.xTah, myGeoCalc.yTah, myGeoCalc.zTah, myGeoCalc.xTahInscr, 
                        myGeoCalc.yTahInscr, myGeoCalc.iHorVerTah, scaleToWin, xBegX, yBegY,
                        xBegWin, yBegWin, myGeoCalc.nTah1, myGeoCalc.nCode2, kSymbPnt,
                        myGeoCalc.numRec, myGeoCalc.numbUser, myGeoCalc.ixSqu, myGeoCalc.iySqu, 
                        myGeoCalc.numCol, myGeoCalc.brColor, myGeoCalc.pnColor);
                if (kRcPnt > 0)
                {
                    for (int index = 1; index <= kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), RcPnt[index]);
                }
            }
            if (nProcess == 910)
            {
                if (kGeo > 0 && kLineDop > 0)
                {
                    myGeoCalc.GeoLineDraw(e, kLineDop, myGeoCalc.sGeoDop1, myGeoCalc.xGeoDop1,
                        myGeoCalc.yGeoDop1, myGeoCalc.sGeoDop2, myGeoCalc.xGeoDop2, myGeoCalc.yGeoDop2,
                        kGeo, myGeoCalc.nameGeo, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                    DllClass1.PointsDraw(e, myGeoCalc.fsymbPnt, 0, kGeoAll, myGeoCalc.nameGeo, myGeoCalc.xGeo,
                        myGeoCalc.yGeo, myGeoCalc.zGeo, myGeoCalc.xGeoInscr, myGeoCalc.yGeoInscr,
                        myGeoCalc.iHorVerGeo, scaleToWin, xBegX, yBegY, xBegWin, yBegWin,
                        myGeoCalc.nGeoCode, myGeoCalc.nCode2, kSymbPnt, myGeoCalc.numRec, myGeoCalc.numbUser,
                        myGeoCalc.ixSqu, myGeoCalc.iySqu, myGeoCalc.numCol, myGeoCalc.brColor,
                        myGeoCalc.pnColor);
                }
                if (kRcPnt > 0)
                {
                    for (int index = 1; index <= kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), RcPnt[index]);
                }
            }
            if (nProcess == 920)
            {
                if (kTaheo > 0)
                    DllClass1.PointsDraw(e, myGeoCalc.fsymbPnt, 0, kTaheo, myGeoCalc.nameTah, 
                        myGeoCalc.xTah, myGeoCalc.yTah, myGeoCalc.zTah, myGeoCalc.xTahInscr,
                        myGeoCalc.yTahInscr, myGeoCalc.iHorVerTah, scaleToWin, xBegX, yBegY,
                        xBegWin, yBegWin, myGeoCalc.nTah1, myGeoCalc.nCode2, kSymbPnt,
                        myGeoCalc.numRec, myGeoCalc.numbUser, myGeoCalc.ixSqu, myGeoCalc.iySqu,
                        myGeoCalc.numCol, myGeoCalc.brColor, myGeoCalc.pnColor);
                if (kRcPnt > 0)
                {
                    for (int index = 1; index <= kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), RcPnt[index]);
                }
            }
            if (nProcess == 210 || nProcess == 810 || nProcess == 820)
            {
                if (kGeo > 0 && kLineDop > 0)
                {
                    myGeoCalc.GeoLineDraw(e, kLineDop, myGeoCalc.sGeoDop1, myGeoCalc.xGeoDop1, 
                        myGeoCalc.yGeoDop1, myGeoCalc.sGeoDop2, myGeoCalc.xGeoDop2, myGeoCalc.yGeoDop2,
                        kGeo, myGeoCalc.nameGeo, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                    DllClass1.PointsDraw(e, myGeoCalc.fsymbPnt, 0, kGeoAll, myGeoCalc.nameGeo, myGeoCalc.xGeo,
                        myGeoCalc.yGeo, myGeoCalc.zGeo, myGeoCalc.xGeoInscr, myGeoCalc.yGeoInscr, 
                        myGeoCalc.iHorVerGeo, scaleToWin, xBegX, yBegY, xBegWin, yBegWin,
                        myGeoCalc.nGeoCode, myGeoCalc.nCode2, kSymbPnt, myGeoCalc.numRec, 
                        myGeoCalc.numbUser, myGeoCalc.ixSqu, myGeoCalc.iySqu, myGeoCalc.numCol,
                        myGeoCalc.brColor, myGeoCalc.pnColor);
                }
                if (kRcPnt > 0)
                {
                    for (int index = 1; index <= kRcPnt; ++index)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), RcPnt[index]);
                }
            }
            if (nProcess != 830 && nProcess != 840 && nProcess != 850 && nProcess != 220)
                return;
            if (kTaheo > 0)
                DllClass1.PointsDraw(e, myGeoCalc.fsymbPnt, 0, kTaheo, myGeoCalc.nameTah, myGeoCalc.xTah, myGeoCalc.yTah, myGeoCalc.zTah, myGeoCalc.xTahInscr, myGeoCalc.yTahInscr, myGeoCalc.iHorVerTah, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, myGeoCalc.nTah1, myGeoCalc.nCode2, kSymbPnt, myGeoCalc.numRec, myGeoCalc.numbUser, myGeoCalc.ixSqu, myGeoCalc.iySqu, myGeoCalc.numCol, myGeoCalc.brColor, myGeoCalc.pnColor);
            if (kRcPnt <= 0)
                return;
            for (int index = 1; index <= kRcPnt; ++index)
                graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), RcPnt[index]);
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            x1Box = e.X;
            y1Box = e.Y;
            double xCur = 0.0;
            double yCur = 0.0;
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
            if (e.Button == MouseButtons.Left)
            {
                if (nProcess == 210 && kDat == 0)
                {
                    ++kDat;
                    xDat[kDat] = e.X;
                    yDat[kDat] = e.Y;
                    kRcPnt = 1;
                    RcPnt[kRcPnt].X = e.X;
                    RcPnt[kRcPnt].Y = e.Y;
                }
                if (nProcess == 850 && kDat == 0)
                {
                    ++kDat;
                    xDat[kDat] = e.X;
                    yDat[kDat] = e.Y;
                    kRcPnt = 1;
                    RcPnt[kRcPnt].X = e.X;
                    RcPnt[kRcPnt].Y = e.Y;
                }
            }
            if (nProcess == 810 || nProcess == 820 || nProcess == 830 || nProcess == 840)
                ++kSel;
            if (e.Button != MouseButtons.Right)
                return;
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
                        iGraphic = 1;
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
            if (nProcess == 210 && kDat > 0)
            {
                RcPnt[kRcPnt].Width = 6;
                RcPnt[kRcPnt].Height = 6;
                panel7.Invalidate(RcPnt[kRcPnt]);
                DllClass1.WINtoXY(xDat[1], yDat[1], scaleToGeo, xBegX, yBegY, 
                    xBegWin, yBegWin, out xCur, out yCur);
                numCode = 0;
                indexGeo = 0;
                DllClass1.SelPoint(kGeoAll, myGeoCalc.xGeo, myGeoCalc.yGeo, xCur,
                    yCur, out indexGeo);
                if (indexGeo > 0)
                    textBox3.Text = string.Format("{0}", (object)myGeoCalc.nGeoCode[indexGeo]);
                kDat = 0;
                panel7.Invalidate();
            }
            if (nProcess == 850 && kDat > 0)
            {
                RcPnt[kRcPnt].Width = 6;
                RcPnt[kRcPnt].Height = 6;
                panel7.Invalidate(RcPnt[kRcPnt]);
                DllClass1.WINtoXY(xDat[1], yDat[1], scaleToGeo, xBegX, yBegY, 
                    xBegWin, yBegWin, out xCur, out yCur);
                numCode = 0;
                indexDTM = -1;
                DllClass1.SelPoint(kTaheo, myGeoCalc.xTah, myGeoCalc.yTah, xCur,
                    yCur, out indexDTM);
                if (indexDTM > -1)
                    textBox4.Text = string.Format("{0}", (object)myGeoCalc.nTah1[indexDTM]);
                kDat = 0;
                panel7.Invalidate();
            }
            if (nProcess == 810 || nProcess == 820)
            {
                if (kSel == 0)
                {
                    double num1 = 9999999.9;
                    indPnt = 0;
                    if (kGeoAll > 0)
                    {
                        for (int index = 0; index <= kGeoAll; ++index)
                        {
                            double num2 = myGeoCalc.xGeoInscr[index] - xCur;
                            double num3 = myGeoCalc.yGeoInscr[index] - yCur;
                            double num4 = Math.Sqrt(num2 * num2 + num3 * num3);
                            if (num4 < num1)
                            {
                                num1 = num4;
                                indPnt = index;
                            }
                        }
                        if (nProcess == 820)
                        {
                            myGeoCalc.iHorVerGeo[indPnt] = myGeoCalc.iHorVerGeo[indPnt] <= 0 ? 1 : 0;
                            myGeoCalc.KeepLoadGeoAll(1, ref kGeoAll);
                            kSel = -1;
                            panel7.Invalidate();
                        }
                    }
                }
                if (nProcess == 810 && kSel == 1)
                {
                    if (kGeoAll > 0)
                    {
                        myGeoCalc.xGeoInscr[indPnt] = xCur;
                        myGeoCalc.yGeoInscr[indPnt] = yCur;
                        myGeoCalc.KeepLoadGeoAll(1, ref kGeoAll);
                    }
                    kSel = -1;
                    panel7.Invalidate();
                }
            }
            if (nProcess != 830 && nProcess != 840)
                return;
            if (kSel == 0)
            {
                double num5 = 9999999.9;
                indPnt = 0;
                if (kTaheo > 0)
                {
                    for (int index = 0; index <= kTaheo; ++index)
                    {
                        double num6 = myGeoCalc.xTahInscr[index] - xCur;
                        double num7 = myGeoCalc.yTahInscr[index] - yCur;
                        double num8 = Math.Sqrt(num6 * num6 + num7 * num7);
                        if (num8 < num5)
                        {
                            num5 = num8;
                            indPnt = index;
                        }
                    }
                    if (nProcess == 840)
                    {
                        myGeoCalc.iHorVerTah[indPnt] = myGeoCalc.iHorVerTah[indPnt] <= 0 ? 1 : 0;
                        myGeoCalc.kTaheo = kTaheo;
                        myGeoCalc.LoadKeepTaheo(2);
                        kSel = -1;
                        panel7.Invalidate();
                    }
                }
            }
            if (nProcess != 830 || kSel != 1)
                return;
            if (kTaheo > 0)
            {
                myGeoCalc.xTahInscr[indPnt] = xCur;
                myGeoCalc.yTahInscr[indPnt] = yCur;
                myGeoCalc.kTaheo = kTaheo;
                myGeoCalc.LoadKeepTaheo(2);
            }
            kSel = -1;
            panel7.Invalidate();
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, 
                yBegWin, out xCur, out yCur);
            if (!File.Exists(myGeoCalc.fgeoGeo))
            {
                panel2.Text = string.Format("{0}", (object)e.X);
                panel4.Text = string.Format("{0}", (object)e.Y);
            }
            if (File.Exists(myGeoCalc.fgeoGeo))
            {
                panel2.Text = string.Format("{0:F3}", (object)xCur);
                panel4.Text = string.Format("{0:F3}", (object)yCur);
            }
            if (File.Exists(myGeoCalc.filePoints))
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
            DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin,
                out xCur1, out yCur1);
            DllClass1.WINtoXY(x2Box, y2Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin,
                out xCur2, out yCur2);
            dx = xCur2 - xCur1;
            dy = yCur2 - yCur1;
            xaCur = xminCur - dx;
            yaCur = yminCur - dy;
            xbCur = xmaxCur - dx;
            ybCur = ymaxCur - dy;
            DllClass1.CoorWin(xaCur, yaCur, xbCur, ybCur, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond < 0)
                iGraphic = 1;
            panel7.Invalidate();
        }

        private void GeoInput_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            iGraphic = 0;
            myGeoCalc.FilePath();
            int iCond = 0;
            if (!File.Exists(myGeoCalc.fileProj))
            {
                int num = (int)MessageBox.Show("Project wasn't opened");
            }
            else
            {
                myGeoCalc.MeasurementInput(out iCond);
                if (iCond < 0)
                    return;
                myGeoCalc.FormLine(out iCond);
                if (iCond < 0)
                    return;
                myGeoCalc.LineTopology();
                nProblem = 11;
                if (File.Exists(myGeoCalc.fProblem))
                    File.Delete(myGeoCalc.fProblem);
                FileStream output = new FileStream(myGeoCalc.fProblem, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(nProblem);
                binaryWriter.Close();
                output.Close();
                LoadData();
                nProcess = 0;
                textBox1.Text = "";
                textBox2.Text = "";
                panel7.Invalidate();
            }
        }

        private void Exit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        private void Doubtful_Click(object sender, EventArgs e)
        {
            string str1 = "";
            double num1 = 0.0;
            int num2 = 0;
            kDat = 0;
            kGeoLine = 0;
            nControl = 0;
            iGraphic = 0;
            int iCond = 0;
            myGeoCalc.PointCollect(0, kGeo, myGeoCalc.nameGeo, out iCond);
            if (iCond < 0)
            {
                int num3 = (int)MessageBox.Show("Check and Correct Data");
                iGraphic = 1;
            }
            else
            {
                kGeoFin = myGeoCalc.kGeoFin;
                if (!File.Exists(myGeoCalc.flineFile))
                {
                    int num4 = (int)MessageBox.Show("Данные отсутствуют", "Doubtful data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    iToler = 0;
                    if (radioButton2.Checked)
                        iToler = 500;
                    if (radioButton3.Checked)
                        iToler = 1000;
                    if (radioButton4.Checked)
                        iToler = 2000;
                    if (radioButton5.Checked)
                        iToler = 3000;
                    if (radioButton6.Checked)
                        iToler = 5000;
                    if (File.Exists(myGeoCalc.fDoubtful))
                        File.Delete(myGeoCalc.fDoubtful);
                    double num5;
                    double num6 = num5 = 0.0;
                    double num7;
                    double num8 = num7 = 0.0;
                    if (!File.Exists(myGeoCalc.ferrorNode))
                        return;
                    FileStream input1 = new FileStream(myGeoCalc.ferrorNode, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader1 = new BinaryReader((Stream)input1);
                    try
                    {
                        int num9 = binaryReader1.ReadInt32();
                        for (int index1 = 1; index1 <= num9; ++index1)
                        {
                            kAdd = binaryReader1.ReadInt32();
                            for (int index2 = 1; index2 <= kAdd; ++index2)
                            {
                                myGeoCalc.indLine[index2] = binaryReader1.ReadInt32();
                                myGeoCalc.nameAdd[index2] = binaryReader1.ReadString();
                                myGeoCalc.xAdd[index2] = binaryReader1.ReadDouble();
                                myGeoCalc.yAdd[index2] = binaryReader1.ReadDouble();
                                myGeoCalc.zAdd[index2] = binaryReader1.ReadDouble();
                                if (!File.Exists(myGeoCalc.flineFile))
                                    return;
                                FileStream input2 = new FileStream(myGeoCalc.flineFile, FileMode.Open, FileAccess.Read);
                                BinaryReader binaryReader2 = new BinaryReader((Stream)input2);
                                try
                                {
                                    int num10 = binaryReader2.ReadInt32();
                                    num1 = 0.0;
                                    str1 = "";
                                    for (int index3 = 1; index3 <= num10; ++index3)
                                    {
                                        int num11 = binaryReader2.ReadInt32();
                                        kDop = binaryReader2.ReadInt32();
                                        for (int index4 = 1; index4 <= kDop; ++index4)
                                        {
                                            myGeoCalc.nameDop[index4] = binaryReader2.ReadString();
                                            myGeoCalc.xDop[index4] = binaryReader2.ReadDouble();
                                            myGeoCalc.yDop[index4] = binaryReader2.ReadDouble();
                                            myGeoCalc.zDop[index4] = binaryReader2.ReadDouble();
                                        }
                                        if (myGeoCalc.indLine[index2] == num11 && myGeoCalc.nameAdd[index2] == myGeoCalc.nameDop[kDop])
                                        {
                                            string str2 = myGeoCalc.nameDop[1];
                                            for (int index5 = 2; index5 <= kDop; ++index5)
                                            {
                                                str2 = str2 + "+" + myGeoCalc.nameDop[index5];
                                                double num12 = myGeoCalc.xDop[index5] - myGeoCalc.xDop[index5 - 1];
                                                double num13 = myGeoCalc.yDop[index5] - myGeoCalc.yDop[index5 - 1];
                                                num1 += Math.Sqrt(num12 * num12 + num13 * num13);
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
                                    binaryReader2.Close();
                                    input2.Close();
                                }
                                if (num1 != 0.0)
                                {
                                    double num14 = Math.Sqrt(myGeoCalc.xAdd[index2] * myGeoCalc.xAdd[index2] + myGeoCalc.yAdd[index2] * myGeoCalc.yAdd[index2]) / num1;
                                    ++kGeoLine;
                                    myGeoCalc.nameStat[kGeoLine] = myGeoCalc.nameAdd[index2];
                                    myGeoCalc.numStat[kGeoLine] = myGeoCalc.indLine[index2];
                                    myGeoCalc.hStat[kGeoLine] = num14;
                                    int int32 = Convert.ToInt32(100000.0 * num14);
                                    int num15 = 10000;
                                    if (int32 > 5)
                                        num15 = Convert.ToInt32(100000 / int32);
                                    if (num15 > 10000)
                                        num2 = 10000;
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
                    if (kGeoLine > 1)
                    {
                        for (int index6 = 1; index6 < kGeoLine; ++index6)
                        {
                            for (int index7 = index6 + 1; index7 <= kGeoLine; ++index7)
                            {
                                if (myGeoCalc.hStat[index6] < myGeoCalc.hStat[index7])
                                {
                                    string str3 = myGeoCalc.nameStat[index6];
                                    int num16 = myGeoCalc.numStat[index6];
                                    double num17 = myGeoCalc.hStat[index6];
                                    myGeoCalc.nameStat[index6] = myGeoCalc.nameStat[index7];
                                    myGeoCalc.numStat[index6] = myGeoCalc.numStat[index7];
                                    myGeoCalc.hStat[index6] = myGeoCalc.hStat[index7];
                                    myGeoCalc.nameStat[index7] = str3;
                                    myGeoCalc.numStat[index7] = num16;
                                    myGeoCalc.hStat[index7] = num17;
                                }
                            }
                        }
                    }
                    int int32_1 = Convert.ToInt32(100000.0 * myGeoCalc.hStat[1]);
                    int num18 = 10000;
                    if (int32_1 > 10)
                        num18 = Convert.ToInt32(100000 / int32_1);
                    textBox2.Text = "1:" + string.Format("{0}", (object)num18);
                    double num19 = 0.0;
                    for (int index = 1; index <= kGeoLine; ++index)
                        num19 += myGeoCalc.hStat[index];
                    int int32_2 = Convert.ToInt32(100000.0 * (num19 / (double)kGeoLine));
                    int num20 = 10000;
                    if (int32_2 > 10)
                        num20 = Convert.ToInt32(100000 / int32_2);
                    textBox1.Text = "1:" + string.Format("{0}", (object)num20);
                    kDat = 0;
                    int index8 = 0;
                    int num21 = 0;
                    do
                    {
                        ++index8;
                        double num22 = 0.0;
                        double num23 = 0.0;
                        for (int index9 = index8; index9 <= kGeoLine; ++index9)
                        {
                            ++num23;
                            num22 += myGeoCalc.hStat[index9];
                        }
                        double num24 = num22 / num23;
                        if (iToler == 0)
                        {
                            if (myGeoCalc.hStat[index8] > 3.0 * num24)
                            {
                                ++kDat;
                                nDat[kDat] = myGeoCalc.numStat[index8];
                                sDat[kDat] = myGeoCalc.nameStat[index8];
                                eRel[kDat] = myGeoCalc.hStat[index8];
                                aRel[kDat] = num24;
                            }
                            else
                                ++num21;
                        }
                        if (iToler > 0)
                        {
                            double num25 = 1.0 / (double)iToler;
                            if (myGeoCalc.hStat[index8] > num25)
                            {
                                ++kDat;
                                nDat[kDat] = myGeoCalc.numStat[index8];
                                sDat[kDat] = myGeoCalc.nameStat[index8];
                                eRel[kDat] = myGeoCalc.hStat[index8];
                                aRel[kDat] = num24;
                            }
                            else
                                ++num21;
                        }
                    }
                    while (num21 == 0);
                    if (kDat < 1)
                    {
                        int num26 = (int)MessageBox.Show("No doubtful data", "Doubtful data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (kDat > 0)
                    {
                        int int32_3 = Convert.ToInt32(100000.0 * aRel[1]);
                        int num27 = 10000;
                        if (int32_3 > 5)
                            num27 = Convert.ToInt32(100000 / int32_3);
                        sTmp = string.Format("{0}", (object)num27);
                        textBox1.Text = "1 : " + sTmp;
                        int int32_4 = Convert.ToInt32(100000.0 * eRel[1]);
                        int num28 = 10000;
                        if (int32_4 > 5)
                            num28 = Convert.ToInt32(100000 / int32_4);
                        sTmp = string.Format("{0}", (object)num28);
                        textBox2.Text = "1 : " + sTmp;
                        FileStream output = new FileStream(myGeoCalc.fDoubtful, FileMode.CreateNew);
                        BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                        try
                        {
                            binaryWriter.Write(kDat);
                            for (int index10 = 1; index10 <= kDat; ++index10)
                            {
                                if (!File.Exists(myGeoCalc.flineFile))
                                    return;
                                FileStream input3 = new FileStream(myGeoCalc.flineFile, FileMode.Open, FileAccess.Read);
                                BinaryReader binaryReader3 = new BinaryReader((Stream)input3);
                                try
                                {
                                    int num29 = binaryReader3.ReadInt32();
                                    for (int index11 = 1; index11 <= num29; ++index11)
                                    {
                                        int num30 = binaryReader3.ReadInt32();
                                        kDop = binaryReader3.ReadInt32();
                                        for (int index12 = 1; index12 <= kDop; ++index12)
                                        {
                                            myGeoCalc.nameDop[index12] = binaryReader3.ReadString();
                                            myGeoCalc.xDop[index12] = binaryReader3.ReadDouble();
                                            myGeoCalc.yDop[index12] = binaryReader3.ReadDouble();
                                            myGeoCalc.zDop[index12] = binaryReader3.ReadDouble();
                                        }
                                        if (nDat[index10] == num30)
                                        {
                                            binaryWriter.Write(kDop);
                                            binaryWriter.Write(eRel[index10]);
                                            binaryWriter.Write(aRel[index10]);
                                            for (int index13 = 1; index13 <= kDop; ++index13)
                                            {
                                                binaryWriter.Write(myGeoCalc.nameDop[index13]);
                                                binaryWriter.Write(myGeoCalc.xDop[index13]);
                                                binaryWriter.Write(myGeoCalc.yDop[index13]);
                                            }
                                            break;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                                }
                                finally
                                {
                                    binaryReader3.Close();
                                    input3.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                        }
                        finally
                        {
                            binaryWriter.Close();
                            output.Close();
                        }
                        myGeoCalc.FilePath();
                        Doubtful doubtful = new Doubtful();
                        doubtful.Location = new Point(0, 0);
                        int num31 = (int)doubtful.ShowDialog((IWin32Window)this);
                        myGeoCalc.FilePath();
                    }
                    LoadData();
                    panel7.Invalidate();
                }
            }
        }

        private void ListLines_Click(object sender, EventArgs e)
        {
            nControl = 0;
            if (!File.Exists(myGeoCalc.fDoubtful))
            {
                int num1 = (int)MessageBox.Show("Данные отсутствуют", "Doubtful data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                myGeoCalc.FilePath();
                Doubtful doubtful = new Doubtful();
                doubtful.Location = new Point(0, 0);
                int num2 = (int)doubtful.ShowDialog((IWin32Window)this);
                myGeoCalc.FilePath();
            }
        }

        private void PointsList_Click(object sender, EventArgs e)
        {
            nControl = 0;
            myGeoCalc.FilePath();
            new PointsList().Show((IWin32Window)this);
            myGeoCalc.FilePath();
        }

        private void InputAllPoints_Click(object sender, EventArgs e)
        {
            int iCond = 0;
            myGeoCalc.PointCollect(0, kGeo, myGeoCalc.nameGeo, out iCond);
            if (iCond < 0)
            {
                int num = (int)MessageBox.Show("Basic Points are absent", "Characteristic Points of District", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                iGraphic = 1;
            }
            else
            {
                nProcess = 220;
                kGeoFin = myGeoCalc.kGeoFin;
                if (kGeoFin < 1)
                {
                    int num1 = (int)MessageBox.Show("Basic Points are absent", "Characteristic Points of District", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    myGeoCalc.AllPointsInput(out iCond, kGeoFin, myGeoCalc.nameFin, myGeoCalc.xFin, myGeoCalc.yFin, myGeoCalc.zFin, zeroSpot, out kAdd, myGeoCalc.nameAdd, myGeoCalc.xAdd, myGeoCalc.yAdd, myGeoCalc.zAdd, myGeoCalc.nUniq);
                    for (int index1 = 0; index1 <= kAdd; ++index1)
                    {
                        sTmp = myGeoCalc.nameAdd[index1];
                        double num2 = 0.0;
                        double num3 = 0.0;
                        double num4 = 0.0;
                        kDop = 0;
                        for (int index2 = 0; index2 <= kAdd; ++index2)
                        {
                            if (myGeoCalc.nameAdd[index2] == sTmp)
                            {
                                ++kDop;
                                num2 += myGeoCalc.xAdd[index2];
                                num3 += myGeoCalc.yAdd[index2];
                                num4 += myGeoCalc.zAdd[index2];
                            }
                        }
                        double num5 = num2 / (double)kDop;
                        double num6 = num3 / (double)kDop;
                        double num7 = num4 / (double)kDop;
                        for (int index3 = 0; index3 <= kAdd; ++index3)
                        {
                            if (myGeoCalc.nameAdd[index3] == sTmp)
                            {
                                myGeoCalc.xAdd[index3] = num5;
                                myGeoCalc.yAdd[index3] = num6;
                                myGeoCalc.zAdd[index3] = num7;
                            }
                        }
                    }
                    int num8 = 0;
                    for (int index4 = 0; index4 < kAdd; ++index4)
                    {
                        for (int index5 = index4 + 1; index5 <= kAdd; ++index5)
                        {
                            if (myGeoCalc.nameAdd[index4] == myGeoCalc.nameAdd[index5])
                            {
                                myGeoCalc.xAdd[index5] = 0.0;
                                myGeoCalc.yAdd[index5] = 0.0;
                                myGeoCalc.zAdd[index5] = 0.0;
                            }
                        }
                    }
                    int index6 = -1;
                    for (int index7 = 0; index7 <= kAdd; ++index7)
                    {
                        if (myGeoCalc.xAdd[index7] != 0.0 || myGeoCalc.yAdd[index7] != 0.0 || myGeoCalc.zAdd[index7] != 0.0)
                        {
                            ++index6;
                            myGeoCalc.nameTah[index6] = myGeoCalc.nameAdd[index7];
                            myGeoCalc.xTah[index6] = myGeoCalc.xAdd[index7];
                            myGeoCalc.yTah[index6] = myGeoCalc.yAdd[index7];
                            myGeoCalc.zTah[index6] = myGeoCalc.zAdd[index7];
                            myGeoCalc.nTah1[index6] = myGeoCalc.nUniq[index7];
                            myGeoCalc.xTahInscr[index6] = myGeoCalc.xTah[index6];
                            myGeoCalc.yTahInscr[index6] = myGeoCalc.yTah[index6];
                            myGeoCalc.iHorVerTah[index6] = 0;
                            for (int index8 = 0; index8 <= kGeoFin; ++index8)
                            {
                                double num9 = myGeoCalc.xTah[index6] - myGeoCalc.xFin[index8];
                                double num10 = myGeoCalc.yTah[index6] - myGeoCalc.yFin[index8];
                                if (Math.Sqrt(num9 * num9 + num10 * num10) < 0.003)
                                {
                                    myGeoCalc.nameTah[index6] = myGeoCalc.nameFin[index8];
                                    myGeoCalc.xTah[index6] = myGeoCalc.xFin[index8];
                                    myGeoCalc.yTah[index6] = myGeoCalc.yFin[index8];
                                    myGeoCalc.zTah[index6] = myGeoCalc.zFin[index7];
                                    myGeoCalc.nTah1[index6] = 0;
                                    myGeoCalc.xTahInscr[index6] = myGeoCalc.xTah[index6];
                                    myGeoCalc.yTahInscr[index6] = myGeoCalc.yTah[index6];
                                    myGeoCalc.iHorVerTah[index6] = 0;
                                    break;
                                }
                            }
                        }
                    }
                    kTaheo = index6;
                    if (kTaheo <= 0)
                        return;
                    for (int index9 = 0; index9 <= kGeoFin; ++index9)
                    {
                        int num11 = 0;
                        for (int index10 = 0; index10 <= kTaheo; ++index10)
                        {
                            double num12 = myGeoCalc.xTah[index10] - myGeoCalc.xFin[index9];
                            double num13 = myGeoCalc.yTah[index10] - myGeoCalc.yFin[index9];
                            if (Math.Sqrt(num12 * num12 + num13 * num13) < 0.003)
                            {
                                ++num11;
                                break;
                            }
                        }
                        if (num11 == 0)
                        {
                            ++kTaheo;
                            myGeoCalc.nameTah[kTaheo] = myGeoCalc.nameFin[index9];
                            myGeoCalc.xTah[kTaheo] = myGeoCalc.xFin[index9];
                            myGeoCalc.yTah[kTaheo] = myGeoCalc.yFin[index9];
                            myGeoCalc.zTah[kTaheo] = myGeoCalc.zFin[index9];
                            myGeoCalc.nTah1[kTaheo] = 0;
                            myGeoCalc.xTahInscr[kTaheo] = myGeoCalc.xTah[kTaheo];
                            myGeoCalc.yTahInscr[kTaheo] = myGeoCalc.yTah[kTaheo];
                            myGeoCalc.iHorVerTah[index6] = 0;
                        }
                    }
                    for (int index11 = 0; index11 <= kTaheo; ++index11)
                    {
                        num8 = 0;
                        for (int index12 = 1; index12 <= kGeoAll; ++index12)
                        {
                            double num14 = myGeoCalc.xTah[index11] - myGeoCalc.xGeo[index12];
                            double num15 = myGeoCalc.yTah[index11] - myGeoCalc.yGeo[index12];
                            if (Math.Sqrt(num14 * num14 + num15 * num15) < 0.1)
                            {
                                myGeoCalc.nTah1[index11] = myGeoCalc.nGeoCode[index12];
                                myGeoCalc.iHorVerTah[index11] = myGeoCalc.iHorVerGeo[index12];
                            }
                        }
                    }
                    myGeoCalc.kTaheo = kTaheo;
                    myGeoCalc.LoadKeepTaheo(2);
                    myGeoCalc.LoadKeepTaheo(1);
                    nProblem = 12;
                    if (File.Exists(myGeoCalc.fProblem))
                        File.Delete(myGeoCalc.fProblem);
                    FileStream output = new FileStream(myGeoCalc.fProblem, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    binaryWriter.Write(nProblem);
                    binaryWriter.Close();
                    output.Close();
                    panel7.Invalidate();
                }
            }
        }

        private void AddPoints_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myGeoCalc.ftahPoint))
            {
                int num1 = (int)MessageBox.Show("Distinctive Points of District are absent", "Distinctive Points of District", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new AddPnt().ShowDialog((IWin32Window)this);
                FormLoad();
                panel7.Invalidate();
            }
        }

        private void SelectBox_Click(object sender, EventArgs e)
        {
            nControl = 10;
            kDat = 0;
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            nControl = 20;
            kDat = 0;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            nControl = 30;
            kDat = 0;
        }

        private void Move_Click(object sender, EventArgs e)
        {
            nControl = 40;
            kDat = 0;
        }

        private void InscriptionMove_Click(object sender, EventArgs e)
        {
            nProcess = 810;
            nControl = 0;
            kSel = -1;
            indPnt = 0;
            panel7.Invalidate();
        }

        private void InscrHorVert_Click(object sender, EventArgs e)
        {
            nProcess = 820;
            nControl = 0;
            kSel = -1;
            indPnt = 0;
            panel7.Invalidate();
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

        private void Init_Preview()
        {
            PrintPreviewControl1 = new PrintPreviewControl();
            PrintPreviewControl1.ClientSize = new Size(580, 680);
            PrintPreviewControl1.Location = new Point(40, 0);
            PrintPreviewControl1.Document = docToPreview;
            Controls.Add((Control)PrintPreviewControl1);
            docToPreview.PrintPage += new PrintPageEventHandler(docToPreview_PrintPage);
        }

        private void Init_Print()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);
            printDocument.Print();
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
            iColorPrint = 0;
            if (nProcess == 230)
            {
                myGeoCalc.PrevPrint_Lines(e, sPixInch, iScaleMap, xa, ya, 
                    kLineGeo, myGeoCalc.rRadGeo, myGeoCalc.xRadGeo, myGeoCalc.yRadGeo, 
                    myGeoCalc.kGeo1, myGeoCalc.kGeo2, myGeoCalc.xLineGeo, myGeoCalc.yLineGeo, 
                    myGeoCalc.xAdd, myGeoCalc.yAdd, xPageBeg, yPageBeg, ixPixel, iyPixel, 0);
                int iParam = 0;
                DllClass1.Print_Points(e, myGeoCalc.fsymbPnt, sPixInch, iScaleMap, 
                    xa, ya, kGeoAll, myGeoCalc.nameGeo, myGeoCalc.xGeo, 
                    myGeoCalc.yGeo, myGeoCalc.zGeo, iParam, myGeoCalc.xGeoInscr, myGeoCalc.yGeoInscr, myGeoCalc.iHorVerGeo, myGeoCalc.nGeoCode, myGeoCalc.nCode2, myGeoCalc.kSymbPnt, myGeoCalc.numRec, myGeoCalc.numbUser, myGeoCalc.ixSqu, myGeoCalc.iySqu, myGeoCalc.numCol, xPageBeg, yPageBeg, myGeoCalc.brColor, myGeoCalc.pnColor, iColorPrint);
            }
            if (nProcess == 240)
            {
                int iParam = 0;
                if (kTaheo > 0)
                    DllClass1.Print_Points(e, myGeoCalc.fsymbPnt, sPixInch, iScaleMap, xa, ya, kGeoFin, myGeoCalc.nameFin, myGeoCalc.xFin, myGeoCalc.yFin, myGeoCalc.zFin, iParam, myGeoCalc.xPntInscr, myGeoCalc.yPntInscr, myGeoCalc.iHorVerPnt, myGeoCalc.nCode1, myGeoCalc.nCode2, myGeoCalc.kSymbPnt, myGeoCalc.numRec, myGeoCalc.numbUser, myGeoCalc.ixSqu, myGeoCalc.iySqu, myGeoCalc.numCol, xPageBeg, yPageBeg, myGeoCalc.brColor, myGeoCalc.pnColor, iColorPrint);
            }
            DllClass1.Page_PrevPrint(e, sPixInch, iScaleMap, xa, ya, xPageBeg, yPageBeg, ixPixel, iyPixel, nPage);
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
            iColorPrint = 0;
            if (nProcess == 230)
            {
                myGeoCalc.PrevPrint_Lines(e, sPixInch, iScaleMap, xa, ya, kLineGeo, 
                    myGeoCalc.rRadGeo, myGeoCalc.xRadGeo, myGeoCalc.yRadGeo, myGeoCalc.kGeo1, 
                    myGeoCalc.kGeo2, myGeoCalc.xLineGeo, myGeoCalc.yLineGeo, myGeoCalc.xAdd, 
                    myGeoCalc.yAdd, xPageBeg, yPageBeg, ixPixel, iyPixel, 0);
                int iParam = 0;
                DllClass1.Print_Points(e, myGeoCalc.fsymbPnt, sPixInch, iScaleMap, xa, ya, 
                    kGeoAll, myGeoCalc.nameGeo, myGeoCalc.xGeo, myGeoCalc.yGeo, myGeoCalc.zGeo, iParam, 
                    myGeoCalc.xGeoInscr, myGeoCalc.yGeoInscr, myGeoCalc.iHorVerGeo, myGeoCalc.nGeoCode, 
                    myGeoCalc.nCode2, myGeoCalc.kSymbPnt, myGeoCalc.numRec, myGeoCalc.numbUser, 
                    myGeoCalc.ixSqu, myGeoCalc.iySqu, myGeoCalc.numCol, xPageBeg, yPageBeg, 
                    myGeoCalc.brColor, myGeoCalc.pnColor, iColorPrint);
            }
            if (nProcess == 240)
            {
                int iParam = 0;
                if (kTaheo > 0)
                    DllClass1.Print_Points(e, myGeoCalc.fsymbPnt, sPixInch, iScaleMap, xa, ya, 
                        kGeoFin, myGeoCalc.nameFin, myGeoCalc.xFin, myGeoCalc.yFin, myGeoCalc.zFin, 
                        iParam, myGeoCalc.xPntInscr, myGeoCalc.yPntInscr, myGeoCalc.iHorVerPnt, myGeoCalc.nCode1,
                        myGeoCalc.nCode2, myGeoCalc.kSymbPnt, myGeoCalc.numRec, myGeoCalc.numbUser, 
                        myGeoCalc.ixSqu, myGeoCalc.iySqu, myGeoCalc.numCol, xPageBeg, yPageBeg, 
                        myGeoCalc.brColor, myGeoCalc.pnColor, iColorPrint);
            }
            DllClass1.Page_PrevPrint(e, sPixInch, iScaleMap, xa, ya, xPageBeg, yPageBeg, 
                ixPixel, iyPixel, nPage);
        }

        private void GeoFoundationPrint_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myGeoCalc.fGeoAll))
            {
                int num1 = (int)MessageBox.Show("Данные отсутствуют", "Geo foundation print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 230;
                kGeoFin = -1;
                for (int index = 1; index <= kGeoAll; ++index)
                {
                    ++kGeoFin;
                    myGeoCalc.nameFin[kGeoFin] = myGeoCalc.nameGeo[index];
                    myGeoCalc.xFin[kGeoFin] = myGeoCalc.xGeo[index];
                    myGeoCalc.yFin[kGeoFin] = myGeoCalc.yGeo[index];
                    myGeoCalc.zFin[kGeoFin] = myGeoCalc.zGeo[index];
                    myGeoCalc.nCode1[kGeoFin] = myGeoCalc.nGeoCode[index];
                    myGeoCalc.xPntInscr[kGeoFin] = myGeoCalc.xGeoInscr[index];
                    myGeoCalc.yPntInscr[kGeoFin] = myGeoCalc.yGeoInscr[index];
                    myGeoCalc.iHorVerPnt[kGeoFin] = myGeoCalc.iHorVerGeo[index];
                }
                int kLineGeo1 = 0;
                myGeoCalc.GeoLineSelect(kLineDop, myGeoCalc.sGeoDop1, myGeoCalc.xGeoDop1, myGeoCalc.yGeoDop1, myGeoCalc.sGeoDop2, myGeoCalc.xGeoDop2, myGeoCalc.yGeoDop2, kGeo, myGeoCalc.nameGeo, out kLineGeo1, myGeoCalc.xDat, myGeoCalc.yDat);
                if (kLineGeo1 > 0)
                {
                    k = myGeoCalc.kGeo2[kLineGeo];
                    int num2 = 2 * kLineGeo1;
                    for (int index = 1; index <= num2; ++index)
                    {
                        ++k;
                        myGeoCalc.xLineGeo[k] = myGeoCalc.xDat[index];
                        myGeoCalc.yLineGeo[k] = myGeoCalc.yDat[index];
                    }
                    int kLineGeo2 = kLineGeo;
                    kLineGeo += kLineGeo1;
                    for (int index = 1; index <= kLineGeo; ++index)
                        myGeoCalc.nCodeLine[index] = 2;
                    for (int index = 1; index <= kLineGeo2; ++index)
                        myGeoCalc.nCodeLine[index] = 1;
                    for (int index = 1; index <= kLineGeo; ++index)
                    {
                        myGeoCalc.nDat[index] = 2;
                        myGeoCalc.rRadGeo[index] = 0.0;
                        myGeoCalc.xRadGeo[index] = 0.0;
                        myGeoCalc.yRadGeo[index] = 0.0;
                    }
                    myGeoCalc.kGeo1[1] = 1;
                    myGeoCalc.kGeo2[1] = myGeoCalc.nDat[1];
                    if (kLineGeo > 1)
                    {
                        for (int index = 2; index <= kLineGeo; ++index)
                        {
                            myGeoCalc.kGeo1[index] = myGeoCalc.kGeo2[index - 1] + 1;
                            myGeoCalc.kGeo2[index] = myGeoCalc.kGeo2[index - 1] + myGeoCalc.nDat[index];
                        }
                    }
                }
                myGeoCalc.kGeoFin = kGeoFin;
                panel7.Visible = false;
                Size_PrevPrint(sPixInch, dxSheet, dySheet, dxPage, dyPage, out xPageBeg, out yPageBeg, out ixPixel, out iyPixel);
                iScaleMap = 0;
                if (radioButton9.Checked)
                    iScaleMap = 200;
                if (radioButton10.Checked)
                    iScaleMap = 500;
                if (radioButton11.Checked)
                    iScaleMap = 1000;
                if (radioButton12.Checked)
                    iScaleMap = 2000;
                if (radioButton13.Checked)
                    iScaleMap = 5000;
                if (radioButton1.Checked)
                    iScaleMap = 250;
                if (radioButton7.Checked)
                    iScaleMap = 625;
                if (radioButton8.Checked)
                    iScaleMap = 1250;
                if (radioButton14.Checked)
                    iScaleMap = 2500;
                if (radioButton15.Checked)
                    iScaleMap = 6250;
                DllClass1.BoundPage(iScaleMap, myGeoCalc.kGeoFin, myGeoCalc.xFin, 
                    myGeoCalc.yFin, dxPage, dyPage, out kPage, x1, y1,
                    x2, y2, x3, y3, x4, y4);
                if (kPage < 1)
                {
                    int num3 = (int)MessageBox.Show("Change Map Scale", "Printing Scheme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
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
                        for (int index2 = 0; index2 <= kGeoFin; ++index2)
                        {
                            if (DllClass1.in_out(ka, ref xa, ref ya, myGeoCalc.xFin[index2], 
                                myGeoCalc.yFin[index2]) > 0)
                                ++kSel;
                        }
                        if (kSel != 0)
                        {
                            sTmp5 = string.Format("{0}", (object)kSel);
                            sTmp = "   " + sTmp1 + "        " + sTmp2 + "        " + sTmp3 + "        " + sTmp4 + "       " + sTmp5;
                            sTmp = " " + string.Format("{0}", (object)index1) + "    " + sTmp;
                            listBox1.Items.Add((object)sTmp);
                        }
                    }
                }
            }
        }

        private void PrintDTM_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myGeoCalc.fGeoAll))
            {
                int num1 = (int)MessageBox.Show("Данные отсутствуют", "DTM points print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 240;
                kGeoFin = -1;
                kTaheo = myGeoCalc.kTaheo;
                myGeoCalc.LoadKeepTaheo(1);
                if (kTaheo > 0)
                {
                    for (int index = 0; index <= kTaheo; ++index)
                    {
                        ++kGeoFin;
                        myGeoCalc.nameFin[kGeoFin] = myGeoCalc.nameTah[index];
                        myGeoCalc.xFin[kGeoFin] = myGeoCalc.xTah[index];
                        myGeoCalc.yFin[kGeoFin] = myGeoCalc.yTah[index];
                        myGeoCalc.zFin[kGeoFin] = myGeoCalc.zTah[index];
                        myGeoCalc.nCode1[kGeoFin] = myGeoCalc.nTah1[index];
                        myGeoCalc.xPntInscr[kGeoFin] = myGeoCalc.xTahInscr[index];
                        myGeoCalc.yPntInscr[kGeoFin] = myGeoCalc.yTahInscr[index];
                        myGeoCalc.iHorVerPnt[kGeoFin] = myGeoCalc.iHorVerTah[index];
                    }
                }
                myGeoCalc.kGeoFin = kGeoFin;
                panel7.Visible = false;
                Size_PrevPrint(sPixInch, dxSheet, dySheet, dxPage, dyPage, out xPageBeg, out yPageBeg, out ixPixel, out iyPixel);
                iScaleMap = 0;
                if (radioButton9.Checked)
                    iScaleMap = 200;
                if (radioButton10.Checked)
                    iScaleMap = 500;
                if (radioButton11.Checked)
                    iScaleMap = 1000;
                if (radioButton12.Checked)
                    iScaleMap = 2000;
                if (radioButton13.Checked)
                    iScaleMap = 5000;
                if (radioButton1.Checked)
                    iScaleMap = 250;
                if (radioButton7.Checked)
                    iScaleMap = 625;
                if (radioButton8.Checked)
                    iScaleMap = 1250;
                if (radioButton14.Checked)
                    iScaleMap = 2500;
                if (radioButton15.Checked)
                    iScaleMap = 6250;
                DllClass1.BoundPage(iScaleMap, myGeoCalc.kGeoFin, myGeoCalc.xFin, myGeoCalc.yFin, dxPage, dyPage, out kPage, x1, y1, x2, y2, x3, y3, x4, y4);
                if (kPage < 1)
                {
                    int num2 = (int)MessageBox.Show("Change Map Scale", "Printing Scheme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
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
                        for (int index2 = 0; index2 <= kGeoFin; ++index2)
                        {
                            if (DllClass1.in_out(ka, ref xa, ref ya, myGeoCalc.xFin[index2], myGeoCalc.yFin[index2]) > 0)
                                ++kSel;
                        }
                        if (kSel != 0)
                        {
                            sTmp5 = string.Format("{0}", (object)kSel);
                            sTmp = "   " + sTmp1 + "        " + sTmp2 + "        " + sTmp3 + "        " + sTmp4 + "       " + sTmp5;
                            sTmp = " " + string.Format("{0}", (object)index1) + "    " + sTmp;
                            listBox1.Items.Add((object)sTmp);
                        }
                    }
                }
            }
        }

        private void PreviewSelection_Click(object sender, EventArgs e)
        {
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

        private void PreviewIn_Click(object sender, EventArgs e)
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

        private void PreviewOut_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                int num = (int)MessageBox.Show("Страница не выбрана.", "Печать страницы", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                PrintPreviewControl1.Zoom = 0.55;
                PrintPreviewControl1.Invalidate();
            }
        }

        private void PrintSelection_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                int num = (int)MessageBox.Show("Страница не выбрана.", "Печать страницы", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Init_Print();
                myGeoCalc.FilePath();
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
                    for (int index2 = 0; index2 <= kGeoFin; ++index2)
                    {
                        if (DllClass1.in_out(ka, ref xa, ref ya, myGeoCalc.xFin[index2], myGeoCalc.yFin[index2]) > 0)
                            ++kSel;
                    }
                    sTmp5 = string.Format("{0}", (object)kSel);
                    sTmp = sTmp1 + " " + sTmp2 + " " + sTmp3 + " " + sTmp4 + "     " + sTmp5;
                    sTmp = " " + string.Format("{0}", (object)index1) + "      " + sTmp;
                    listBox1.Items.Add((object)sTmp);
                }
            }
        }

        private void MainPanel_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Controls.Remove((Control)PrintPreviewControl1);
            LoadData();
            panel7.Visible = true;
            nProcess = 0;
            panel7.Invalidate();
        }

        private void ChangeSymbol_Click(object sender, EventArgs e)
        {
            nProcess = 210;
            numCode = 0;
            kDat = 0;
            kRcPnt = 0;
            if (!File.Exists(myGeoCalc.fgeoGeo))
            {
                int num = (int)MessageBox.Show("Нет данных", "Change symbol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                panel7.Invalidate();
        }

        private void SymbolSave_Click(object sender, EventArgs e)
        {
            if (indexGeo == 0)
            {
                int num1 = (int)MessageBox.Show("Точка не выбрана", "Change symbol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (textBox3.Text != "")
                {
                    double tText = 0.0;
                    DllClass1.CheckText(textBox3.Text, out tText, out iCond);
                    if (iCond < 0)
                    {
                        int num2 = (int)MessageBox.Show("Проверьте данные", "Change symbol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    myGeoCalc.nGeoCode[indexGeo] = Convert.ToInt32(textBox3.Text);
                }
                myGeoCalc.KeepLoadGeoAll(1, ref kGeoAll);
                nProcess = 0;
                kRcPnt = 0;
                kDat = 0;
                panel7.Invalidate();
            }
        }

        private void HelpSelection_Click(object sender, EventArgs e)
        {
            int num = (int)new ListPntSign().ShowDialog((IWin32Window)this);
            if (File.Exists(myGeoCalc.fileAdd))
            {
                FileStream input = new FileStream(myGeoCalc.fileAdd, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    numCode = binaryReader.ReadInt32();
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
            if (numCode == 0)
                return;
            textBox3.Text = string.Format("{0}", (object)myGeoCalc.numbUser[numCode]);
        }

        private void DTMmove_Click(object sender, EventArgs e)
        {
            nProcess = 830;
            nControl = 0;
            kSel = -1;
            indPnt = 0;
            if (!File.Exists(myGeoCalc.ftahPoint))
            {
                int num = (int)MessageBox.Show("Нет данных", "Change symbol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                kTaheo = myGeoCalc.kTaheo;
                myGeoCalc.LoadKeepTaheo(1);
                panel7.Invalidate();
            }
        }

        private void DTMinscription_Click(object sender, EventArgs e)
        {
            nProcess = 840;
            nControl = 0;
            kSel = -1;
            indPnt = 0;
            if (!File.Exists(myGeoCalc.ftahPoint))
            {
                int num = (int)MessageBox.Show("Нет данных", "Change symbol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                kTaheo = myGeoCalc.kTaheo;
                myGeoCalc.LoadKeepTaheo(1);
                panel7.Invalidate();
            }
        }

        private void DTMsymbol_Click(object sender, EventArgs e)
        {
            nProcess = 850;
            numCode = 0;
            kDat = 0;
            kRcPnt = 0;
            if (!File.Exists(myGeoCalc.ftahPoint))
            {
                int num = (int)MessageBox.Show("Нет данных", "Change symbol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                kTaheo = myGeoCalc.kTaheo;
                myGeoCalc.LoadKeepTaheo(1);
                textBox4.Text = "";
                panel7.Invalidate();
            }
        }

        private void DTMsymbolSave_Click(object sender, EventArgs e)
        {
            if (indexDTM < 0)
            {
                int num1 = (int)MessageBox.Show("Точка не выбрана", "Change symbol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (textBox4.Text != "")
                {
                    double tText = 0.0;
                    DllClass1.CheckText(textBox4.Text, out tText, out iCond);
                    if (iCond < 0)
                    {
                        int num2 = (int)MessageBox.Show("Проверьте данные", "Change symbol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    myGeoCalc.nTah1[indexDTM] = Convert.ToInt32(textBox4.Text);
                }
                myGeoCalc.kTaheo = kTaheo;
                myGeoCalc.LoadKeepTaheo(2);
                nProcess = 850;
                kRcPnt = 0;
                kDat = 0;
                panel7.Invalidate();
            }
        }

        private void DTMhelp_Click(object sender, EventArgs e)
        {
            int num = (int)new ListPntSign().ShowDialog((IWin32Window)this);
            if (File.Exists(myGeoCalc.fileAdd))
            {
                FileStream input = new FileStream(myGeoCalc.fileAdd, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    numCode = binaryReader.ReadInt32();
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
            if (numCode == 0)
                return;
            textBox4.Text = string.Format("{0}", (object)myGeoCalc.numbUser[numCode]);
        }

        private void BasicPoints_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myGeoCalc.fgeoGeo))
            {
                int num1 = (int)MessageBox.Show("Данные отсутствуют", "Geo foundation print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (kGeo < 1)
            {
                int num2 = (int)MessageBox.Show("Данные отсутствуют", "Geo foundation print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 910;
                nProblem = 11;
                if (File.Exists(myGeoCalc.fProblem))
                    File.Delete(myGeoCalc.fProblem);
                FileStream output = new FileStream(myGeoCalc.fProblem, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(nProblem);
                binaryWriter.Close();
                output.Close();
                panel7.Invalidate();
            }
        }

        private void DTMPoints_Click(object sender, EventArgs e)
        {
            if (!File.Exists(myGeoCalc.fGeoAll))
            {
                int num1 = (int)MessageBox.Show("Данные отсутствуют", "DTM points print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 920;
                myGeoCalc.LoadKeepTaheo(1);
                kTaheo = myGeoCalc.kTaheo;
                if (kTaheo < 1)
                {
                    int num2 = (int)MessageBox.Show("Данные отсутствуют", "DTM points print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (kTaheo > 0)
                    {
                        for (int index = 0; index <= kTaheo; ++index)
                        {
                            ++kGeoFin;
                            myGeoCalc.nameFin[kGeoFin] = myGeoCalc.nameTah[index];
                            myGeoCalc.xFin[kGeoFin] = myGeoCalc.xTah[index];
                            myGeoCalc.yFin[kGeoFin] = myGeoCalc.yTah[index];
                            myGeoCalc.zFin[kGeoFin] = myGeoCalc.zTah[index];
                            myGeoCalc.nCode1[kGeoFin] = myGeoCalc.nTah1[index];
                            myGeoCalc.xPntInscr[kGeoFin] = myGeoCalc.xTahInscr[index];
                            myGeoCalc.yPntInscr[kGeoFin] = myGeoCalc.yTahInscr[index];
                            myGeoCalc.iHorVerPnt[kGeoFin] = myGeoCalc.iHorVerTah[index];
                        }
                    }
                    myGeoCalc.kGeoFin = kGeoFin;
                    nProblem = 12;
                    if (File.Exists(myGeoCalc.fProblem))
                        File.Delete(myGeoCalc.fProblem);
                    FileStream output = new FileStream(myGeoCalc.fProblem, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    binaryWriter.Write(nProblem);
                    binaryWriter.Close();
                    output.Close();
                    panel7.Invalidate();
                }
            }
        }

    }
}
