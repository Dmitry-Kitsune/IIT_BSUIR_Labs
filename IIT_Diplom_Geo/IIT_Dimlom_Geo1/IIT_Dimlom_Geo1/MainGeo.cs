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
using System.Security;
using DiplomGeoDLL;
using IIT_Diplom_Geo1;


namespace IIT_Dimlom_Geo1
{
    public partial class MainGeo : Form
    {
        private int iWidth;
        private int iHeight;
        private int pixWid;
        private int pixHei;
        private int nProcess;
        private string sTmp = "";
        private int kSymbPnt;
        private int kSymbLine;
        private int kPolySymb;
        private int hSymbLine = 20;
        private int hSymbPoly;
        private int nProblem;
        private int kRect;
        private int rWid;
        private int rHei;
        private int kRectPoly;
        private int rWidPoly;
        private int rHeiPoly;
        private double xmin;
        private double xmax;
        private double ymin;
        private double ymax;
        private int kGeo;
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
        private int iCond;
        private int iGraphic;
        private int kGeoAll;
        private int kLineDop;
        private int kAdd;
        private int kTaheo;
        private int kBlock;
        private int kTar;
        private string[] sa = new string[10];
        private double[] xa = new double[10];
        private double[] ya = new double[10];
        private double[] za = new double[10];
        private int ix;
        private int iy;
        private int ih = 7;
        private int ik;
        private int kPntPlus;
        private int kPntInput;
        private int kLineInput;
        private int kLineTopo;
        private int kNode;
        private int kPntProj;
        private int kProjInput;
        private int kLineProj;
        private int nAction;
        private int kNodeAct;
        private int kLineAct;
        private int kPolyAct;
        private int kLineNew;
        private double xCur;
        private double yCur;


        private MyGeodesy mySub = new MyGeodesy();

        public string fCurPnt { get; private set; }
        public string fCurHeig { get; private set; }
        public string fCurLine { get; private set; }

        public MainGeo()
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
            panel1.Text = "Дипломный проект ПОИС.00332 Бурляев";
            panel3.Text = "**";
            panel5.Text = "**";
            panel6.Text = DateTime.Now.ToShortDateString();
            statusBar1.ShowPanels = true;
            statusBar1.Panels.Add(panel1);
            statusBar1.Panels.Add(panel2);
            statusBar1.Panels.Add(panel3);
            statusBar1.Panels.Add(panel4);
            statusBar1.Panels.Add(panel5);
            statusBar1.Panels.Add(panel6);
            Controls.Add((Control)statusBar1);
            ExitToolStripMenuItem.MouseHover += new EventHandler(ExitToolStripMenuItem_MouseHover);
            ExitToolStripMenuItem.MouseLeave += new EventHandler(ExitToolStripMenuItem_MouseLeave);
            button2.MouseHover += new EventHandler(button2_MouseHover);
            button2.MouseLeave += new EventHandler(ExitToolStripMenuItem_MouseLeave);
            button3.MouseHover += new EventHandler(button3_MouseHover);
            button3.MouseLeave += new EventHandler(ExitToolStripMenuItem_MouseLeave);
            button4.MouseHover += new EventHandler(button4_MouseHover);
            button4.MouseLeave += new EventHandler(ExitToolStripMenuItem_MouseLeave);
            button5.MouseHover += new EventHandler(button5_MouseHover);
            button5.MouseLeave += new EventHandler(ExitToolStripMenuItem_MouseLeave);
            button6.MouseHover += new EventHandler(button6_MouseHover);
            button6.MouseLeave += new EventHandler(ExitToolStripMenuItem_MouseLeave);
            button7.MouseHover += new EventHandler(button7_MouseHover);
            button7.MouseLeave += new EventHandler(ExitToolStripMenuItem_MouseLeave);
            button8.MouseHover += new EventHandler(button8_MouseHover);
            button8.MouseLeave += new EventHandler(ExitToolStripMenuItem_MouseLeave);
            button9.MouseHover += new EventHandler(button9_MouseHover);
            button9.MouseLeave += new EventHandler(ExitToolStripMenuItem_MouseLeave);
            mySub.FilePath();
            FormLoad();
        }

            private void ExitToolStripMenuItem_MouseHover(object sender, EventArgs e) => label3.Text = "Закрыть окно";

            private void ExitToolStripMenuItem_MouseLeave(object sender, EventArgs e) => label3.Text = "";

            private void button2_MouseHover(object sender, EventArgs e) => label3.Text = "Открыть новый проект";

            private void button3_MouseHover(object sender, EventArgs e) => label3.Text = "Выберите и откройте ранее созданный проект";

            private void button4_MouseHover(object sender, EventArgs e) => label3.Text = "Выберите и удалите ранее созданный проект";

            private void button5_MouseHover(object sender, EventArgs e) => label3.Text = "Все проекты удаляются с текущего диска";

            private void button6_MouseHover(object sender, EventArgs e) => label3.Text = "Сменить диск на новый или выбрать ранее созданный проект";

            private void button7_MouseHover(object sender, EventArgs e) => label3.Text = "Создание новых или обновление топографических символов точек";

            private void button8_MouseHover(object sender, EventArgs e) => label3.Text = "Создание новых или обновление топографических символов линий";

            private void button9_MouseHover(object sender, EventArgs e) => label3.Text = "Создание новых или обновление топографических символов полигонов.";
        

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
                            binaryReader.ReadString();
                            mySub.curProject = binaryReader.ReadString();
                            string Drive1;
                            
                            mySub.curDirect = mySub.driveKey + "\\" + mySub.dirKey;
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
                    int num2 = (int)MessageBox.Show("Открыть новый проект", "Кадастровый", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                if (num1 > 0)
                {
                    int num3 = (int)MessageBox.Show("Используйте Выбор 'проекта' или 'Открыть новый проект'", "Геодезия или кадастр", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            mySub.FilePath();
           // mySub.curDirect = mySub.comPath;
           int kPart = 50;
            char[] seps = new char[1] { '\\' };
            string[] sPart = new string[50];
            int k = 0;
            DllClass1.ShareString(mySub.comPath, kPart, seps, out k, out sPart);
            if (!File.Exists(mySub.fileProj))
            {
                label2.Text = sPart[1] + "\\--Проект не определен";
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
                    int num = (int)MessageBox.Show("Диск не был определен. Используйте 'Сменить диск'", "Геодезия или Кадастр", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                LoadData();
                panel7.Invalidate();
            }

        }

        public void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            DllClass1.SetColour(mySub.brColor, mySub.pnColor);
            DllClass1.PointSymbLoad(mySub.fsymbPnt, out kSymbPnt, 
                mySub.numRec, mySub.numbUser, mySub.heiSymb);
            mySub.kSymbPnt = kSymbPnt;
            DllClass1.LineSymbolLoad(mySub.fsymbLine, out kSymbLine, 
                out hSymbLine, mySub.sSymbLine, mySub.x1Line, mySub.y1Line, 
                mySub.x2Line, mySub.y2Line, mySub.xDescr, mySub.yDescr,
                mySub.x1Dens, mySub.y1Dens, mySub.x1Sign, mySub.y1Sign, 
                mySub.x2Sign, mySub.y2Sign, mySub.n1Sign, mySub.n2Sign, 
                mySub.iStyle1, mySub.iStyle2, mySub.iWidth1, mySub.iWidth2,
                mySub.nColLine, mySub.nItem, mySub.itemLoc, mySub.nBaseSymb,
                mySub.sInscr, mySub.hInscr, mySub.iColInscr, mySub.iDensity);
            mySub.PolySymbolLoad(mySub.fsymbPoly, out kPolySymb, out hSymbPoly);
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
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                }
                finally
                {
                    binaryReader.Close();
                    input.Close();
                }
            }
            if (nProblem == 0)
                return;
            if (nProblem == 1)
            {
                label4.Text = "Последний процесс: Forming Points' библиотека символов";
                if (kSymbPnt > 0)
                    mySub.RectCoord(pixWid, pixHei, kSymbPnt, mySub.heiSymb, out kRect, mySub.nVert,
                        mySub.xVert, mySub.yVert, out rWid, out rHei);
            }
            if (nProblem == 2)
            {
                label4.Text = "Последний процесс: Forming Lines' библиотека символов";
                if (kSymbLine > 0)
                    mySub.RectLineSign(pixWid, pixHei, kSymbLine, hSymbLine, out kRect, mySub.nVert,
                        mySub.xVert, mySub.yVert, out rWid, out rHei);
            }
            if (nProblem == 3)
            {
                label4.Text = "Последний процесс: Forming Lines' библиотека символов";
                if (kPolySymb > 0)
                    mySub.RectPolySign(pixWid, pixHei, kPolySymb, hSymbPoly, out kRectPoly, mySub.nVert,
                        mySub.xVert, mySub.yVert, out rWidPoly, out rHeiPoly);
            }
            if (nProblem == 10)
                label4.Text = "Проверка процесса геодезии";
            if (nProblem == 11)
            {
                xmin = 9999999.9;
                ymin = 9999999.9;
                xmax = -9999999.9;
                ymax = -9999999.9;
                kGeo = 0;
                if (File.Exists(mySub.fgeoGeo))
                {
                    FileStream input = new FileStream(mySub.fgeoGeo, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        kGeo = binaryReader.ReadInt32();
                        for (int index = 1; index <= kGeo; ++index)
                        {
                            mySub.nameGeo[index] = binaryReader.ReadString();
                            mySub.xGeo[index] = binaryReader.ReadDouble();
                            mySub.yGeo[index] = binaryReader.ReadDouble();
                            mySub.zGeo[index] = binaryReader.ReadDouble();
                            mySub.nGeoCode[index] = binaryReader.ReadInt32();
                            if (xmin > mySub.xGeo[index])
                                xmin = mySub.xGeo[index];
                            if (ymin > mySub.yGeo[index])
                                ymin = mySub.yGeo[index];
                            if (xmax < mySub.xGeo[index])
                                xmax = mySub.xGeo[index];
                            if (ymax < mySub.yGeo[index])
                                ymax = mySub.yGeo[index];
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
                    if (kGeo > 3)
                    {
                        DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo,
                            out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                        if (iCond < 0)
                            iGraphic = 1;
                    }
                }
                kLineDop = 0;
                if (File.Exists(mySub.fgeoPoly))
                {
                    FileStream input = new FileStream(mySub.fgeoPoly, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        kLineDop = binaryReader.ReadInt32();
                        for (int index1 = 1; index1 <= kLineDop; ++index1)
                        {
                            kAdd = binaryReader.ReadInt32();
                            for (int index2 = 1; index2 <= 2; ++index2)
                            {
                                sa[index2] = binaryReader.ReadString();
                                xa[index2] = binaryReader.ReadDouble();
                                ya[index2] = binaryReader.ReadDouble();
                                za[index2] = binaryReader.ReadDouble();
                            }
                            mySub.sGeoDop1[index1] = sa[1];
                            mySub.xGeoDop1[index1] = xa[1];
                            mySub.yGeoDop1[index1] = ya[1];
                            mySub.zGeoDop1[index1] = za[1];
                            mySub.sGeoDop2[index1] = sa[2];
                            mySub.xGeoDop2[index1] = xa[2];
                            mySub.yGeoDop2[index1] = ya[2];
                            mySub.zGeoDop2[index1] = za[2];
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
                mySub.KeepLoadGeoAll(2, ref kGeoAll);
            }
            if (nProblem == 12)
            {
                mySub.KeepLoadGeoAll(2, ref kGeoAll);
                mySub.LoadKeepTaheo(1);
                kTaheo = mySub.kTaheo;
                xmin = 9999999.9;
                ymin = 9999999.9;
                xmax = -9999999.9;
                ymax = -9999999.9;
                if (kTaheo > 3)
                {
                    for (int index = 0; index <= kTaheo; ++index)
                    {
                        if (xmin > mySub.xTah[index])
                            xmin = mySub.xTah[index];
                        if (ymin > mySub.yTah[index])
                            ymin = mySub.yTah[index];
                        if (xmax < mySub.xTah[index])
                            xmax = mySub.xTah[index];
                        if (ymax < mySub.yTah[index])
                            ymax = mySub.yTah[index];
                    }
                    DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo,
                        out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                    if (iCond < 0)
                        iGraphic = 1;
                }
            }
            if (nProblem == 21)
            {
                xmin = 9999999.9;
                ymin = 9999999.9;
                xmax = -9999999.9;
                ymax = -9999999.9;
                if (File.Exists(mySub.fileGeo))
                {
                    FileStream input = new FileStream(mySub.fileGeo, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        kTar = binaryReader.ReadInt32();
                        for (int index = 1; index <= kTar; ++index)
                        {
                            mySub.tarName[index] = binaryReader.ReadString();
                            mySub.xTar[index] = binaryReader.ReadDouble();
                            mySub.yTar[index] = binaryReader.ReadDouble();
                            mySub.zTar[index] = binaryReader.ReadDouble();
                            if (xmin > mySub.xTar[index])
                                xmin = mySub.xTar[index];
                            if (ymin > mySub.yTar[index])
                                ymin = mySub.yTar[index];
                            if (xmax < mySub.xTar[index])
                                xmax = mySub.xTar[index];
                            if (ymax < mySub.yTar[index])
                                ymax = mySub.yTar[index];
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
                else if (File.Exists(mySub.currentGeo))
                {
                    FileStream input = new FileStream(mySub.currentGeo, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        kTar = binaryReader.ReadInt32();
                        for (int index = 1; index <= kTar; ++index)
                        {
                            mySub.tarName[index] = binaryReader.ReadString();
                            mySub.xTar[index] = binaryReader.ReadDouble();
                            mySub.yTar[index] = binaryReader.ReadDouble();
                            mySub.zTar[index] = binaryReader.ReadDouble();
                            if (xmin > mySub.xTar[index])
                                xmin = mySub.xTar[index];
                            if (ymin > mySub.yTar[index])
                                ymin = mySub.yTar[index];
                            if (xmax < mySub.xTar[index])
                                xmax = mySub.xTar[index];
                            if (ymax < mySub.yTar[index])
                                ymax = mySub.yTar[index];
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
                if (File.Exists(mySub.aeroBlock))
                {
                    FileStream input = new FileStream(mySub.aeroBlock, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        kBlock = binaryReader.ReadInt32();
                        for (int index = 1; index <= kBlock; ++index)
                        {
                            mySub.blockName[index] = binaryReader.ReadString();
                            mySub.xBlock[index] = binaryReader.ReadDouble();
                            mySub.yBlock[index] = binaryReader.ReadDouble();
                            mySub.zBlock[index] = binaryReader.ReadDouble();
                            if (xmin > mySub.xBlock[index])
                                xmin = mySub.xBlock[index];
                            if (ymin > mySub.yBlock[index])
                                ymin = mySub.yBlock[index];
                            if (xmax < mySub.xBlock[index])
                                xmax = mySub.xBlock[index];
                            if (ymax < mySub.yBlock[index])
                                ymax = mySub.yBlock[index];
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
                if (kBlock > 2)
                {
                    DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, 
                        out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                    if (iCond < 0)
                        iGraphic = 1;
                }
            }
            if (nProblem == 31 || nProblem == 32 || nProblem == 33 || nProblem == 34 || nProblem == 41 || nProblem == 42 || nProblem == 51 || nProblem == 61 || nProblem == 62 || nProblem == 63)
            {
               // mySub.PointLoad(fCurPnt, fCurHeig);
                mySub.PointLoad();
                kPntPlus = mySub.kPntPlus;
                kPntInput = mySub.kPntInput;
                if (kPntPlus < 2)
                {
                    panel7.Invalidate();
                    return;
                }
                for (int index = 0; index <= kPntPlus; ++index)
                {
                    mySub.xPntInscr[index] = mySub.xPnt[index];
                    mySub.yPntInscr[index] = mySub.yPnt[index];
                    mySub.iHorVerPnt[index] = 0;
                }
                xmin = 9999999.9;
                ymin = 9999999.9;
                xmax = -9999999.9;
                ymax = -9999999.9;
                if (kPntPlus > 3)
                {
                    for (int index = 0; index <= kPntPlus; ++index)
                    {
                        if (xmin > mySub.xPnt[index])
                            xmin = mySub.xPnt[index];
                        if (ymin > mySub.yPnt[index])
                            ymin = mySub.yPnt[index];
                        if (xmax < mySub.xPnt[index])
                            xmax = mySub.xPnt[index];
                        if (ymax < mySub.yPnt[index])
                            ymax = mySub.yPnt[index];
                    }
                    DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo,
                        out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                    if (iCond < 0)
                        iGraphic = 1;
                }
            }
            if (nProblem == 41)
            {
                label4.Text = "Последний процесс: Кадастр - От точек к линиям";
                kLineInput = 0;
               // mySub.LineLoad(fCurLine);
                mySub.LineLoad();
                kLineInput = mySub.kLineInput;
            }
            if (nProblem == 42)
            {
                label4.Text = "Последний процесс: Кадастр - построение полигональной топологии";
                kLineTopo = 0;
                mySub.LineTopoLoad();
                kLineTopo = mySub.kLineTopo;
                mySub.LoadNode();
                kNode = mySub.kNodeTopo;
            }
            mySub.kPoly = 0;
            mySub.kInter = 0;
            mySub.PolygonLoad(ref mySub.kPolyInside);
            if (nProblem == 51)
            {
                label4.Text = "Последний процесс: Кадастр - Модель рельефа и формирование горизонталей";
                kLineInput = 0;
                mySub.LineLoad();
                //mySub.LineLoad(fCurLine);
                kLineInput = mySub.kLineInput;
            }
            if (nProblem == 61 || nProblem == 62)
            {
                kPntProj = -1;
                mySub.PointProjLoad();
                kPntProj = mySub.kPntProj;
                kProjInput = mySub.kProjInput;
                kLineInput = 0;
                mySub.LineLoad();
                kLineInput = mySub.kLineInput;
            }
            if (nProblem == 63)
            {
                kPntProj = -1;
                mySub.PointProjLoad();
                kPntProj = mySub.kPntProj;
                kProjInput = mySub.kProjInput;
                kLineProj = 0;
                mySub.LineProjLoad();
                kLineProj = mySub.kLineProj;
                kLineInput = 0;
                mySub.LineLoad();
                kLineInput = mySub.kLineInput;
            }
            if (nProblem != 71)
                return;
            mySub.KeepLoadAction(1);
            nAction = mySub.nAction;
            if (nAction <= 0)
                return;
            mySub.NodeActLoad(nAction);
            kNodeAct = mySub.kNodeAct;
            mySub.TopoActLoad(nAction);
            kLineAct = mySub.kLineAct;
            mySub.PolyActLoad(nAction);
            kPolyAct = mySub.kPolyAct;
            mySub.LineNewLoad(nAction);
            kLineNew = mySub.kLineNew;
        }
        private void Exit_Click(object sender, EventArgs e) => Application.Exit();

        private void ProjectOpen_Click(object sender, EventArgs e)
        {
            mySub.FilePath();
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)MessageBox.Show("Диск не был определен. Используйте 'Изменить диск'", "Откритие проекта", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //int num2 = (int)new NewProject().ShowDialog((IWin32Window)this);
                int num2 = (int)new CreateNewProj().ShowDialog((IWin32Window)this);
                if (!File.Exists(mySub.fileAdd))
                {
                    int num3 = (int)MessageBox.Show("Новый проект не был определен..", "Новый проект", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int kPart = 50;
                    char[] seps = new char[1] { '\\' };
                    string[] sPart = new string[50];
                    int k = 0;
                    DllClass1.ShareString(mySub.comPath, kPart, seps, out k, out sPart);
                    if (k == 0)
                        return;
                    if (!File.Exists(mySub.fileProj))
                    {
                        label2.Text = sPart[1] + "\\--Проект не выбран";
                        int num4 = (int)MessageBox.Show("Проект не выбран.", "Новый проект", 
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        FileStream input = new FileStream(mySub.fileProj, FileMode.Open, FileAccess.Read);
                        BinaryReader binaryReader = new BinaryReader((Stream)input);
                        sTmp = binaryReader.ReadString();
                        mySub.curProject = binaryReader.ReadString();
                        binaryReader.Close();
                        input.Close();
                        mySub.FilePath();
                        label2.Text = sPart[1] + "\\" + this.mySub.curProject;
                        mySub.FilesRemove();
                        FormLoad();
                        int num5 = (int)MessageBox.Show("Используйте 'Файловы ввод точек'", "Геодезия", 
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        panel7.Invalidate();
                    }
                }
            }
        }

        private void ProjectSelect_Click(object sender, EventArgs e)
        {
            mySub.FilePath();
            if (!File.Exists(mySub.fileAllProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран. Используйте новый проект", "Выбор проекта", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 20;
                if (File.Exists(mySub.fileProcess))
                    File.Delete(mySub.fileProcess);
                FileStream output = new FileStream(mySub.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(nProcess);
                binaryWriter.Close();
                output.Close();
                int num2 = (int)new SelectProj().ShowDialog((IWin32Window)this);
                mySub.FilePath();
                int kPart = 50;
                char[] seps = new char[1] { '\\' };
                string[] sPart = new string[50];
                int k = 0;
                DllClass1.ShareString(mySub.comPath, kPart, seps, out k, out sPart);
                if (k == 0)
                    return;
                if (!File.Exists(mySub.fileProj))
                {
                    label2.Text = sPart[1] + "\\--Проект не выбран";
                    int num3 = (int)MessageBox.Show("Проект не выбран.", "Новаый проект", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    FileStream input = new FileStream(mySub.fileProj, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    sTmp = binaryReader.ReadString();
                    mySub.curProject = binaryReader.ReadString();
                    input.Close();
                    binaryReader.Close();
                    label2.Text = sPart[1] + "\\+" + mySub.curProject;
                    FormLoad();
                    panel7.Invalidate();
                }
            }
        }
        private void ProjectDelete_Click(object sender, EventArgs e)
        {
            mySub.FilePath();
            if (!File.Exists(mySub.fileAllProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран. Используйте новый проект", "Выбрать проект",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nProcess = 30;
                if (File.Exists(mySub.fileProcess))
                    File.Delete(mySub.fileProcess);
                FileStream output = new FileStream(mySub.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(nProcess);
                binaryWriter.Close();
                output.Close();
                int num2 = (int)new SelectProj().ShowDialog((IWin32Window)this);
                //int num2 = (int)new SelectProject().ShowDialog((IWin32Window)this);
                if (!File.Exists(mySub.fileAdd))
                    return;
                mySub.FilePath();
                FormLoad();
                panel7.Invalidate();
            }
        }

        private void ProjectsDelete_Click(object sender, EventArgs e)
        {
            mySub.FilePath();
            mySub.nameDir = Directory.GetDirectories(mySub.comPath);
            if (mySub.nameDir.Length < 0 || mySub.nameDir.Length > -1 && MessageBox.Show("Вы действительно хотите удалить все проекты?",
                "Удаление ВСЕХ проектов", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                return;
            for (int index = 0; index < mySub.nameDir.Length; ++index)
                mySub.DeleteProject(mySub.nameDir[index]);
            if (File.Exists(mySub.fileAllProj))
                File.Delete(mySub.fileAllProj);
            if (File.Exists(mySub.fileProj))
                File.Delete(mySub.fileProj);
            mySub.FilePath();
            label2.Text = "";
            panel7.Invalidate();
        }

        private void DiskChange_Click(object sender, EventArgs e)
        {
            string fsymbPnt1 = mySub.fsymbPnt;
            string fsymbLine1 = mySub.fsymbLine;
            string fitemLine1 = mySub.fitemLine;
            string fsymbPoly1 = mySub.fsymbPoly;
            string fitemPoly1 = mySub.fitemPoly;
            string fstoreCam1 = mySub.fstoreCam;
            int num1 = (int)new SelectDrive().ShowDialog((IWin32Window)this);
            mySub.FilePath();
            string fsymbPnt2 = mySub.fsymbPnt;
            string fsymbLine2 = mySub.fsymbLine;
            string fitemLine2 = mySub.fitemLine;
            string fsymbPoly2 = mySub.fsymbPoly;
            string fitemPoly2 = mySub.fitemPoly;
            string fstoreCam2 = mySub.fstoreCam;
            if (fsymbPnt1 == fsymbPnt2)
                return;
            if (File.Exists(fsymbPnt1))
                DllClass1.PointSymbolCopy(fsymbPnt1, fsymbPnt2);
            if (File.Exists(fsymbLine1))
                mySub.LineSymbolCopy(fsymbLine1, fsymbLine2);
            if (File.Exists(fitemLine1))
                DllClass1.LineItemCopy(fitemLine1, fitemLine2);
            if (File.Exists(fsymbPoly1))
                mySub.PolySymbolCopy(fsymbPoly1, fsymbPoly2);
            if (File.Exists(fitemPoly1))
                DllClass1.PolyItemCopy(fitemPoly1, fitemPoly2);
            if (File.Exists(fstoreCam1))
                DllClass1.CameraStoreCopy(fstoreCam1, fstoreCam2);
            int kPart = 50;
            char[] seps = new char[1] { '\\' };
            string[] sPart = new string[50];
            int k = 0;
            DllClass1.ShareString(mySub.comPath, kPart, seps, out k, out sPart);
            if (k == 0)
                return;
            if (!File.Exists(mySub.fileProj))
            {
                label2.Text = sPart[1] + "\\--Проект не выбран";
                int num2 = (int)MessageBox.Show("Проект не выбран. Воспользуйтесь 'Новый проект'", "Новый проект",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FormLoad();
                panel7.Invalidate();
            }
            else
            {
                FileStream input = new FileStream(mySub.fileProj, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                sTmp = binaryReader.ReadString();
                mySub.curProject = binaryReader.ReadString();
                input.Close();
                binaryReader.Close();
                FormLoad();
                panel7.Invalidate();
            }
        }

        private void PointsSymb_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)MessageBox.Show("Диск не выбран", "Создание проекта", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new PointSign().ShowDialog((IWin32Window)this);
                LoadData();
                panel7.Invalidate();
            }
        }

        private void LinesSymb_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)MessageBox.Show("Диск не выбран", "Создание проекта", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new LineSign().ShowDialog((IWin32Window)this);
                LoadData();
                panel7.Invalidate();
            }
        }

        private void PolygonsSymb_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)MessageBox.Show("Диск не выбран", "Создание проекта", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new PolygonSign().ShowDialog((IWin32Window)this);
                LoadData();
                panel7.Invalidate();
            }
        }

        private void Geodesy_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)MessageBox.Show("Диск не выбран", "Создание проекта", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new GeoCalc().ShowDialog((IWin32Window)this);
                LoadData();
                panel7.Invalidate();
            }
        }

        private void Aero_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)MessageBox.Show("Диск не выбран", "Создание проекта", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new Aero().ShowDialog((IWin32Window)this);
                LoadData();
                panel7.Invalidate();
            }
        }

        private void Cadastre_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)MessageBox.Show("Диск не выбран", "Создание проекта", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new Cadasral().ShowDialog((IWin32Window)this);
                LoadData();
                panel7.Invalidate();
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
                DllClass1.XYtoWIN(xLab[index], yLab[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin1);
                if (xWin1 != 0 || yWin1 != 0)
                {
                    graphics.DrawString(namePol[index], new Font("Bold", (float)(num + 3)), 
                        (Brush)new SolidBrush(Color.Red), (float)(xWin1 + num / 2), (float)(yWin1 - num + 1));
                    graphics.FillRectangle((Brush)new SolidBrush(Color.Magenta), xWin1 - num / 2, yWin1 - num / 2, num, num);
                }
            }
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
                    int num = (int)MessageBox.Show("Проверьте данные");
                    iGraphic = 1;
                    break;
                }
                DllClass1.XYtoWIN(mySub.xProj[index], mySub.yProj[index], scaleToWin, xBegX, yBegY, 
                    xBegWin, yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                {
                    graphics.FillRectangle((Brush)solidBrush, xWin - 2, yWin - 2, 4, 4);
                    graphics.DrawString(mySub.nameProj[index], new Font("Bold", (float)emSize), (Brush)solidBrush, (float)(xWin + emSize / 2), (float)(yWin - emSize));
                }
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (iGraphic > 0)
                return;
            if (nProblem == 1 && kSymbPnt > 0)
                mySub.SymbPntDraw(e, mySub.fsymbPnt, kRect, mySub.nVert, mySub.xVert, mySub.yVert, 
                    rWid, rHei, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.nWork1, mySub.nWork2,
                    mySub.nWork, mySub.brColor);
            if (nProblem == 2 && kSymbLine > 0)
                mySub.SymbLineDraw(e, mySub.fitemLine, kRect, mySub.nVert, mySub.xVert, mySub.yVert,
                    rWid, rHei, kSymbLine, mySub.n2Sign, mySub.nBaseSymb, mySub.nColLine, mySub.iWidth1,
                    mySub.iWidth2, mySub.iStyle1, mySub.iStyle2, mySub.nItem, mySub.itemLoc, mySub.iDensity, 
                    mySub.nColorItm, mySub.nWork1, mySub.nWork2, mySub.brColor, mySub.pnColor);
            if (nProblem == 3 && kRectPoly > 0)
                mySub.SymbPolyDraw(e, mySub.fitemPoly, kRectPoly, mySub.nVert, mySub.xVert, mySub.yVert, 
                    rWidPoly, rHeiPoly, kPolySymb, mySub.npSign2, mySub.nBackCol, mySub.npItem,
                    mySub.nOneSymb, mySub.nWork1, mySub.nWork2, mySub.nColorItm, mySub.brColor, mySub.pnColor);
            if (nProblem == 11)
            {
                label4.Text = "Последний процесс: Результат  'Загрузка данных измерений из файла' (Контрольные точки)'";
                if (kGeo > 0 && kLineDop > 0)
                {
                    mySub.GeoLineDraw(e, kLineDop, mySub.sGeoDop1, mySub.xGeoDop1, mySub.yGeoDop1, mySub.sGeoDop2, mySub.xGeoDop2, mySub.yGeoDop2, kGeo, mySub.nameGeo, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 0, kGeoAll, mySub.nameGeo, mySub.xGeo, mySub.yGeo, mySub.zGeo, mySub.xGeoInscr, mySub.yGeoInscr, mySub.iHorVerGeo, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nGeoCode, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.numCol, mySub.brColor, mySub.pnColor);
                }
            }
            if (nProblem == 12)
            {
                label4.Text = "Последний процесс: Результат 'Ввод данных измерений DTM из файла'";
                if (kTaheo > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 0, kTaheo, mySub.nameTah, mySub.xTah, mySub.yTah, mySub.zTah, mySub.xTahInscr, mySub.yTahInscr, mySub.iHorVerTah, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nTah1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.numCol, mySub.brColor, mySub.pnColor);
            }
            if (nProblem == 21 || nProblem == 25)
            {
                label4.Text = "Верификация процессов аэротриангуляции";
                ik = iHeight - 30;
                if (kBlock > 0)
                {
                    for (int index = 1; index <= kBlock; ++index)
                    {
                        DllClass1.XYtoWIN(mySub.xBlock[index], mySub.yBlock[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out ix, out iy);
                        if ((ix != 0 || iy != 0) && mySub.blockName[index].IndexOf('-') > -1)
                        {
                            sTmp = mySub.blockName[index].Trim('-');
                            graphics.DrawRectangle(new Pen(Color.Brown), ix - 3, iy - 3, 6, 6);
                            graphics.FillRectangle((Brush)new SolidBrush(Color.Brown), ix, iy, 2, 2);
                            graphics.DrawString(sTmp, new Font("Bold", (float)ih), (Brush)new SolidBrush(Color.Brown), (float)(ix + 3), (float)(iy - 4));
                        }
                    }
                    graphics.DrawRectangle(new Pen(Color.Brown), 130, ik, 6, 6);
                    graphics.FillRectangle((Brush)new SolidBrush(Color.Brown), 132, ik + 3, 2, 2);
                    graphics.DrawString(" - Центр аэрофотосъемки", new Font("Bold", (float)ih), (Brush)new SolidBrush(Color.Brown), 133f, (float)(ik - ih / 2));
                }
                if (kTar > 0)
                {
                    int num = 6;
                    for (int index = 1; index <= kTar; ++index)
                    {
                        if (mySub.xTar[index] != 0.0 && mySub.yTar[index] != 0.0 && mySub.zTar[index] != 0.0)
                        {
                            DllClass1.XYtoWIN(mySub.xTar[index], mySub.yTar[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out ix, out iy);
                            if (ix != 0 || iy != 0)
                            {
                                graphics.FillRectangle((Brush)new SolidBrush(Color.Red), ix - num / 2, iy - num / 2, num, num);
                                graphics.DrawString(mySub.tarName[index], new Font("Bold", (float)ih), (Brush)new SolidBrush(Color.Black), (float)(ix + ih / 2), (float)(iy - ih));
                            }
                        }
                    }
                }
            }
            if (nProblem == 22)
            {
                sTmp = "Аэротриангуляция-последний процесс:";
                DllClass1.DrawText(e, sTmp, 20, 60, pixHei / 2 - 20, 4, mySub.brColor);
                sTmp = "Проверка архива камер";
                DllClass1.DrawText(e, sTmp, 20, 50, pixHei / 2 + 10, 4, mySub.brColor);
            }
            if (nProblem == 23)
            {
                sTmp = "Аэротриангуляция-последний процесс:";
                DllClass1.DrawText(e, sTmp, 20, 80, pixHei / 2 - 20, 4, mySub.brColor);
                sTmp = "Проверка архива контрольных точек";
                DllClass1.DrawText(e, sTmp, 20, 50, pixHei / 2 + 10, 4, mySub.brColor);
            }
            if (nProblem == 24)
            {
                sTmp = "Аэротриангуляция-последний процесс:";
                DllClass1.DrawText(e, sTmp, 20, 80, pixHei / 2 - 20, 4, mySub.brColor);
                sTmp = "Проверка архива точек DTM";
                DllClass1.DrawText(e, sTmp, 20, 50, pixHei / 2 + 10, 4, mySub.brColor);
            }
            if (nProblem == 25)
                label4.Text = "Входные стерео измерения и расчеты аэротриангуляции";
            if (nProblem == 26)
            {
                label4.Text = "Управление процессами аэротриангуляции";
                sTmp = "Аэротриангуляция-последний процесс:";
                DllClass1.DrawText(e, sTmp, 20, 80, pixHei / 2 - 20, 4, mySub.brColor);
                sTmp = "Управление процессами аэротриангуляции";
                DllClass1.DrawText(e, sTmp, 20, 50, pixHei / 2 + 10, 4, mySub.brColor);
            }
            if (nProblem == 31 || nProblem == 32)
            {
                label4.Text = "Кадастровый-последний процесс: ввод файловых точек";
                if (nProblem == 32)
                    label4.Text = "Кадастровый-последний процесс: дополнительные баллы";
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, 
                        mySub.yPnt, mySub.zPnt, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt,
                        scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt,
                        mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor,
                        mySub.pnColor);
            }
            if (nProblem == 33 || nProblem == 34)
            {
                label4.Text = "Кадастровый-последний процесс: данные геодезического расчета";
                if (nProblem == 34)
                    label4.Text = "Кадастровый-последний процесс: данные аэротриангуляции";
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt,
                        mySub.zPnt, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY,
                        xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser,
                        mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
            }
            if (nProblem == 40)
            {
                label4.Text = "Контроль Кастровых процессов";
                sTmp = "Кадастровый-последний процесс:";
                DllClass1.DrawText(e, sTmp, 20, 80, pixHei / 2 - 20, 4, mySub.brColor);
                sTmp = "Проверка кадастровых процессов";
                DllClass1.DrawText(e, sTmp, 20, 50, pixHei / 2 + 10, 4, mySub.brColor);
            }
            if (nProblem == 41)
            {
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt,
                        mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin,
                        mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu,
                        mySub.nColor, mySub.brColor, mySub.pnColor);
                if (kLineInput > 0)
                {
                    int iPar = 1;
                   DllClass1.LineDraw(e, kLineInput, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, mySub.rRadLine, scaleToWin,
                       xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
            }
            if (nProblem == 42)
            {
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt,
                        mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
                if (kLineTopo > 0)
                {
                    int iPar = 4;
                    DllClass1.LineDraw(e, kLineTopo, mySub.kl1, mySub.kl2, mySub.zLin, mySub.zPik, mySub.radLine, scaleToWin,
                        xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
                if (kNode > 0)
                    DllClass1.DrawNode(e, kNode, mySub.nameNode, mySub.xNode, mySub.yNode, scaleToWin, xBegX,
                        yBegY, xBegWin, yBegWin);
                if (mySub.kPoly > 0)
                    LabelDraw(e, mySub.kPoly, mySub.namePoly, mySub.xLab, mySub.yLab, scaleToWin, xBegX,
                        yBegY, xBegWin, yBegWin);
            }
            if (nProblem == 51)
            {
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt,
                        mySub.zPnt, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, 
                        xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu,
                        mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
                if (kLineInput > 0)
                {
                    int iPar = 1;
                    DllClass1.LineDraw(e, kLineInput, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, mySub.rRadLine, 
                        scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
                if (File.Exists(mySub.fileContour))
                    DllClass1.ContourDraw(e, mySub.fileContour, mySub.xDop, mySub.yDop, mySub.xOut, mySub.yOut,
                        scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            }
            if (nProblem == 61 || nProblem == 62 || nProblem == 63)
            {
                label4.Text = "Кадастровый - Последний процесс: ввод проектных точек в файл";
                if (nProblem == 62)
                    label4.Text = "Кадастр - Последний процесс: Дополнительные баллы проекта";
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt, 
                        mySub.zPnt, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, 
                        xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, 
                        mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
                if (kPntProj > -1)
                    DrawPntProj(e);
                if (kLineInput > 0)
                {
                    int iPar = 1;
                    DllClass1.LineDraw(e, kLineInput, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, mySub.rRadLine,
                        scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
            }
            if (nProblem == 63)
            {
                label4.Text = "Кадастровый - последний процесс: формирование проектных линий";
                if (kLineProj > 0)
                {
                    int iPar = 2;
                    DllClass1.LineDraw(e, kLineProj, mySub.kPr1, mySub.kPr2, mySub.xLinProj, mySub.yLinProj, mySub.RadProj, 
                        scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
                if (kLineInput > 0)
                {
                    int iPar = 1;
                    DllClass1.LineDraw(e, kLineInput, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, mySub.rRadLine, scaleToWin, 
                        xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
            }
            if (nProblem != 71)
                return;
            label4.Text = "Кадастр - Последний процесс: Действия с посылками";
            if (kLineAct > 0)
            {
                int iPar = 1;
                DllClass1.LineDraw(e, kLineAct, mySub.kActLine1, mySub.kActLine2, mySub.xLineAct, mySub.yLineAct, mySub.radAct,
                    scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
            }
            if (kPolyAct > 0)
            {
                int iParam = 8;
                DllClass1.LabelDraw(e, kPolyAct, mySub.nameAct, mySub.xAct, mySub.yAct, mySub.iHorVer, scaleToWin, xBegX, yBegY,
                    xBegWin, yBegWin, mySub.brColor, iParam);
            }
            if (kNodeAct > 0)
                DllClass1.DrawNodeAct(e, kNodeAct, mySub.nameNodeAct, mySub.xNodeAct, mySub.yNodeAct, scaleToWin, xBegX, yBegY, 
                    xBegWin, yBegWin);
            if (kLineNew <= 0)
                return;
            int iPar1 = 2;
            DllClass1.LineDraw(e, kLineNew, mySub.kLinNew1, mySub.kLinNew2, mySub.xLinNew, mySub.yLinNew, mySub.RadNew, 
                scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar1);
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

    }
}
