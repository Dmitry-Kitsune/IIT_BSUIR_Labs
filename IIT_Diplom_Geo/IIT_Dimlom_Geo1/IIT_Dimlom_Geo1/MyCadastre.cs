﻿using DiplomGeoDLL;
using IIT_Diplom_Geo1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Доработать класс Aero

// Обратить внимание на строку 166+
// Возможно потребуются изменения в ссылке на форму выбора пути к проекту (смена класса)

namespace IIT_Dimlom_Geo1
{
    public partial class MyCadastre : Form
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

        public MyCadastre()
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
            panel1.Text = "Дипломный проект гр00332 Бурляев Д.А.";
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
            button7.MouseHover += new EventHandler(button7_MouseHover);
            button7.MouseLeave += new EventHandler(button1_MouseLeave);
            button8.MouseHover += new EventHandler(button8_MouseHover);
            button8.MouseLeave += new EventHandler(button1_MouseLeave);
            button9.MouseHover += new EventHandler(button9_MouseHover);
            button9.MouseLeave += new EventHandler(button1_MouseLeave);
            mySub.FilePath();
            FormLoad();
        }

        private void button1_MouseHover(object sender, EventArgs e) => label3.Text = "Закрыть окно";

        private void button1_MouseLeave(object sender, EventArgs e) => label3.Text = "";

        private void button2_MouseHover(object sender, EventArgs e) => label3.Text = "Открыть новый проект";

        private void button3_MouseHover(object sender, EventArgs e) => label3.Text = "Выбрать и открыть ранее созданный проект";

        private void button4_MouseHover(object sender, EventArgs e) => label3.Text = "Выберите и удалите ранее созданный проект";

        private void button5_MouseHover(object sender, EventArgs e) => label3.Text = "Удаление ВСЕХ проектов с данного(текущего) диска";

        private void button6_MouseHover(object sender, EventArgs e) => label3.Text = "Изменить диск для выбора старого проекта или создания нового";

        private void button7_MouseHover(object sender, EventArgs e) => label3.Text = "Создание новых или обновление топографических символов точек";

        private void button8_MouseHover(object sender, EventArgs e) => label3.Text = "Создание новых или обновление топографических символов линий";

        private void button9_MouseHover(object sender, EventArgs e) => label3.Text = "Создание новых или обновление топографических символов полигонов.";

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
                            mySub.curDirect = binaryReader.ReadString();
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
                    int num2 = (int)MessageBox.Show("Открыть новый проект", "Кадастр и топография", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (num1 > 0)
                {
                    int num3 = (int)MessageBox.Show("Используйте выбор проекта или создать новый проект", "Кадастр и топография", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                //label2.Text = sPart[1] + "\\+" + mySub.curProject;
                label2.Text = mySub.comPath + "\\" + mySub.curProject;
                if (!File.Exists(mySub.tmpStr) && nProcess == 910)
                {
                    int num = (int)MessageBox.Show("Диск не был определен. Используйте 'Cменить диск'", "Кадастр и топография", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                LoadData();
                panel7.Invalidate();
            }
        }

        public void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            DllClass1.SetColour(this.mySub.brColor, this.mySub.pnColor);
            DllClass1.PointSymbLoad(this.mySub.fsymbPnt, out this.kSymbPnt, this.mySub.numRec, this.mySub.numbUser, this.mySub.heiSymb);
            this.mySub.kSymbPnt = this.kSymbPnt;
            DllClass1.LineSymbolLoad(this.mySub.fsymbLine, out this.kSymbLine, out this.hSymbLine, this.mySub.sSymbLine, this.mySub.x1Line, this.mySub.y1Line, this.mySub.x2Line, this.mySub.y2Line, this.mySub.xDescr, this.mySub.yDescr, this.mySub.x1Dens, this.mySub.y1Dens, this.mySub.x1Sign, this.mySub.y1Sign, this.mySub.x2Sign, this.mySub.y2Sign, this.mySub.n1Sign, this.mySub.n2Sign, this.mySub.iStyle1, this.mySub.iStyle2, this.mySub.iWidth1, this.mySub.iWidth2, this.mySub.nColLine, this.mySub.nItem, this.mySub.itemLoc, this.mySub.nBaseSymb, this.mySub.sInscr, this.mySub.hInscr, this.mySub.iColInscr, this.mySub.iDensity);
            this.mySub.PolySymbolLoad(this.mySub.fsymbPoly, out this.kPolySymb, out this.hSymbPoly);
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
            if (this.nProblem == 0)
                return;
            if (this.nProblem == 1)
            {
                label4.Text = "Последний процесс: Библиотека символов построения линий";
                if (this.kSymbPnt > 0)
                    this.mySub.RectCoord(this.pixWid, this.pixHei, this.kSymbPnt, this.mySub.heiSymb, out this.kRect, this.mySub.nVert, this.mySub.xVert, this.mySub.yVert, out this.rWid, out this.rHei);
            }
            if (nProblem == 2)
            {
                label4.Text = "Последний процесс: Библиотека символов построения линий";
                if (kSymbLine > 0)
                    mySub.RectLineSign(pixWid, pixHei, kSymbLine, hSymbLine, out kRect, mySub.nVert, mySub.xVert, mySub.yVert, out rWid, out rHei);
            }
            if (nProblem == 3)
            {
                label4.Text = "Последний процесс: Библиотека символов построения полигонов";
                if (kPolySymb > 0)
                    mySub.RectPolySign(pixWid, pixHei, kPolySymb, hSymbPoly, out kRectPoly, mySub.nVert, mySub.xVert, mySub.yVert, out rWidPoly, out rHeiPoly);
            }
            if (nProblem == 10)
                label4.Text = "Проверка процесса 'Геодезия'";
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
                        this.kGeo = binaryReader.ReadInt32();
                        for (int index = 1; index <= kGeo; ++index)
                        {
                            this.mySub.nameGeo[index] = binaryReader.ReadString();
                            this.mySub.xGeo[index] = binaryReader.ReadDouble();
                            this.mySub.yGeo[index] = binaryReader.ReadDouble();
                            this.mySub.zGeo[index] = binaryReader.ReadDouble();
                            this.mySub.nGeoCode[index] = binaryReader.ReadInt32();
                            if (this.xmin > this.mySub.xGeo[index])
                                this.xmin = this.mySub.xGeo[index];
                            if (this.ymin > this.mySub.yGeo[index])
                                this.ymin = this.mySub.yGeo[index];
                            if (this.xmax < this.mySub.xGeo[index])
                                this.xmax = this.mySub.xGeo[index];
                            if (this.ymax < this.mySub.yGeo[index])
                                this.ymax = this.mySub.yGeo[index];
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
                        DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
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
                        this.kLineDop = binaryReader.ReadInt32();
                        for (int index1 = 1; index1 <= this.kLineDop; ++index1)
                        {
                            this.kAdd = binaryReader.ReadInt32();
                            for (int index2 = 1; index2 <= 2; ++index2)
                            {
                                this.sa[index2] = binaryReader.ReadString();
                                this.xa[index2] = binaryReader.ReadDouble();
                                this.ya[index2] = binaryReader.ReadDouble();
                                this.za[index2] = binaryReader.ReadDouble();
                            }
                            this.mySub.sGeoDop1[index1] = this.sa[1];
                            this.mySub.xGeoDop1[index1] = this.xa[1];
                            this.mySub.yGeoDop1[index1] = this.ya[1];
                            this.mySub.zGeoDop1[index1] = this.za[1];
                            this.mySub.sGeoDop2[index1] = this.sa[2];
                            this.mySub.xGeoDop2[index1] = this.xa[2];
                            this.mySub.yGeoDop2[index1] = this.ya[2];
                            this.mySub.zGeoDop2[index1] = this.za[2];
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
                this.mySub.KeepLoadGeoAll(2, ref this.kGeoAll);
            }
            if (this.nProblem == 12)
            {
                this.mySub.KeepLoadGeoAll(2, ref this.kGeoAll);
                this.mySub.LoadKeepTaheo(1);
                this.kTaheo = this.mySub.kTaheo;
                this.xmin = 9999999.9;
                this.ymin = 9999999.9;
                this.xmax = -9999999.9;
                this.ymax = -9999999.9;
                if (this.kTaheo > 3)
                {
                    for (int index = 0; index <= this.kTaheo; ++index)
                    {
                        if (this.xmin > this.mySub.xTah[index])
                            this.xmin = this.mySub.xTah[index];
                        if (this.ymin > this.mySub.yTah[index])
                            this.ymin = this.mySub.yTah[index];
                        if (this.xmax < this.mySub.xTah[index])
                            this.xmax = this.mySub.xTah[index];
                        if (this.ymax < this.mySub.yTah[index])
                            this.ymax = this.mySub.yTah[index];
                    }
                    DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
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
                    FileStream input = new FileStream(this.mySub.fileGeo, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        this.kTar = binaryReader.ReadInt32();
                        for (int index = 1; index <= this.kTar; ++index)
                        {
                            this.mySub.tarName[index] = binaryReader.ReadString();
                            this.mySub.xTar[index] = binaryReader.ReadDouble();
                            this.mySub.yTar[index] = binaryReader.ReadDouble();
                            this.mySub.zTar[index] = binaryReader.ReadDouble();
                            if (this.xmin > this.mySub.xTar[index])
                                this.xmin = this.mySub.xTar[index];
                            if (this.ymin > this.mySub.yTar[index])
                                this.ymin = this.mySub.yTar[index];
                            if (this.xmax < this.mySub.xTar[index])
                                this.xmax = this.mySub.xTar[index];
                            if (this.ymax < this.mySub.yTar[index])
                                this.ymax = this.mySub.yTar[index];
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
                    FileStream input = new FileStream(this.mySub.currentGeo, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        this.kTar = binaryReader.ReadInt32();
                        for (int index = 1; index <= this.kTar; ++index)
                        {
                            this.mySub.tarName[index] = binaryReader.ReadString();
                            this.mySub.xTar[index] = binaryReader.ReadDouble();
                            this.mySub.yTar[index] = binaryReader.ReadDouble();
                            this.mySub.zTar[index] = binaryReader.ReadDouble();
                            if (this.xmin > this.mySub.xTar[index])
                                this.xmin = this.mySub.xTar[index];
                            if (this.ymin > this.mySub.yTar[index])
                                this.ymin = this.mySub.yTar[index];
                            if (this.xmax < this.mySub.xTar[index])
                                this.xmax = this.mySub.xTar[index];
                            if (this.ymax < this.mySub.yTar[index])
                                this.ymax = this.mySub.yTar[index];
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
                if (File.Exists(this.mySub.aeroBlock))
                {
                    FileStream input = new FileStream(this.mySub.aeroBlock, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        binaryReader.ReadDouble();
                        this.kBlock = binaryReader.ReadInt32();
                        for (int index = 1; index <= this.kBlock; ++index)
                        {
                            this.mySub.blockName[index] = binaryReader.ReadString();
                            this.mySub.xBlock[index] = binaryReader.ReadDouble();
                            this.mySub.yBlock[index] = binaryReader.ReadDouble();
                            this.mySub.zBlock[index] = binaryReader.ReadDouble();
                            if (this.xmin > this.mySub.xBlock[index])
                                this.xmin = this.mySub.xBlock[index];
                            if (this.ymin > this.mySub.yBlock[index])
                                this.ymin = this.mySub.yBlock[index];
                            if (this.xmax < this.mySub.xBlock[index])
                                this.xmax = this.mySub.xBlock[index];
                            if (this.ymax < this.mySub.yBlock[index])
                                this.ymax = this.mySub.yBlock[index];
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
                    DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                    if (iCond < 0)
                        iGraphic = 1;
                }
            }
            if (nProblem == 31 || nProblem == 32 || nProblem == 33 || nProblem == 34 || nProblem == 41 || nProblem == 42 || nProblem == 51 || nProblem == 61 || nProblem == 62 || nProblem == 63)
            {
                this.mySub.PointLoad();
                this.kPntPlus = this.mySub.kPntPlus;
                this.kPntInput = this.mySub.kPntInput;
                if (this.kPntPlus < 2)
                {
                    this.panel7.Invalidate();
                    return;
                }
                for (int index = 0; index <= this.kPntPlus; ++index)
                {
                    this.mySub.xPntInscr[index] = this.mySub.xPnt[index];
                    this.mySub.yPntInscr[index] = this.mySub.yPnt[index];
                    this.mySub.iHorVerPnt[index] = 0;
                }
                this.xmin = 9999999.9;
                this.ymin = 9999999.9;
                this.xmax = -9999999.9;
                this.ymax = -9999999.9;
                if (this.kPntPlus > 3)
                {
                    for (int index = 0; index <= this.kPntPlus; ++index)
                    {
                        if (this.xmin > this.mySub.xPnt[index])
                            this.xmin = this.mySub.xPnt[index];
                        if (this.ymin > this.mySub.yPnt[index])
                            this.ymin = this.mySub.yPnt[index];
                        if (this.xmax < this.mySub.xPnt[index])
                            this.xmax = this.mySub.xPnt[index];
                        if (this.ymax < this.mySub.yPnt[index])
                            this.ymax = this.mySub.yPnt[index];
                    }
                    DllClass1.CoorWin(this.xmin, this.ymin, this.xmax, this.ymax, this.iWidth, this.iHeight, out this.scaleToWin, out this.scaleToGeo, out this.xBegX, out this.yBegY, out this.xEndX, out this.yEndY, out this.xBegWin, out this.yBegWin, out this.xEndWin, out this.yEndWin, out this.iCond);
                    if (this.iCond < 0)
                        this.iGraphic = 1;
                }
            }
            if (nProblem == 41)
            {
                label4.Text = "Последний процесс: Кадастр - От точек к линиям";
                kLineInput = 0;
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
                int num1 = (int)MessageBox.Show("Диск не выбран. Используйте 'Изменить диск'", "Открыыть проект", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int num2 = (int)new CreateNewProj().ShowDialog((IWin32Window)this);
                if (!File.Exists(mySub.fileAdd))
                {
                    int num3 = (int)MessageBox.Show("Новый проект не определен.", "Новый проект", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        label2.Text = sPart[1] + "\\--Проект не определен";
                        int num4 = (int)MessageBox.Show("Проекты не определены.", "Новый проект", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        label2.Text = sPart[1] + "\\+" + mySub.curProject;
                        mySub.FilesRemove();
                        FormLoad();
                        int num5 = (int)MessageBox.Show("Используйте 'Добавление точек из файла'", "Кадастр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Проект не выбран. Используйте 'Новый проект'", "Выбрать проект", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    int num3 = (int)MessageBox.Show("Проекты не выбраны.", "Новый проект", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Проект не выбран. Используйте 'Новый проект'", "Выбрать проект", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (mySub.nameDir.Length < 0 || mySub.nameDir.Length > -1 && MessageBox.Show("Вы действительно хотите удалить все проекты ?", "Удаление всех проектов", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                return;
            for (int i = 0; i < mySub.nameDir.Length; ++i)
                mySub.DeleteProject(mySub.nameDir[i]);
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
            int num1 = (int)new ProjectMenu().ShowDialog((IWin32Window)this);
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
                int num2 = (int)MessageBox.Show("Проекты не выбраны. Используйте 'Новый проект'", "Новый проект", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Диск не определен", "Создание проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Диск не определен", "Создание проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Диск не определен", "Создание проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Диск не определен", "Создание проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Диск не определен", "Создание проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                int num1 = (int)MessageBox.Show("Диск не определен", "Создание проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            for (int i = 1; i <= kPol; ++i)
            {
                DllClass1.XYtoWIN(xLab[i], yLab[i], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin1);
                if (xWin1 != 0 || yWin1 != 0)
                {
                    graphics.DrawString(namePol[i], new Font("Bold", (float)(num + 3)), (Brush)new SolidBrush(Color.Red), (float)(xWin1 + num / 2), (float)(yWin1 - num + 1));
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
            for (int i = 0; i <= kPntProj; ++i)
            {
                if (double.IsNaN(mySub.xProj[i]) || double.IsNaN(mySub.yProj[i]))
                {
                    int num = (int)MessageBox.Show("Проверьте данные");
                    iGraphic = 1;
                    break;
                }
                DllClass1.XYtoWIN(mySub.xProj[i], mySub.yProj[i], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin, out yWin);
                if (xWin != 0 || yWin != 0)
                {
                    graphics.FillRectangle((Brush)solidBrush, xWin - 2, yWin - 2, 4, 4);
                    graphics.DrawString(mySub.nameProj[i], new Font("Bold", (float)emSize), (Brush)solidBrush, (float)(xWin + emSize / 2), (float)(yWin - emSize));
                }
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (iGraphic > 0)
                return;
            if (nProblem == 1 && kSymbPnt > 0)
                mySub.SymbPntDraw(e, mySub.fsymbPnt, kRect, mySub.nVert, mySub.xVert, mySub.yVert, rWid, rHei, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.nWork1, mySub.nWork2, mySub.nWork, mySub.brColor);
            if (nProblem == 2 && kSymbLine > 0)
                mySub.SymbLineDraw(e, mySub.fitemLine, kRect, mySub.nVert, mySub.xVert, mySub.yVert, rWid, rHei, kSymbLine, mySub.n2Sign, mySub.nBaseSymb, mySub.nColLine, mySub.iWidth1, mySub.iWidth2,
                    mySub.iStyle1, mySub.iStyle2, mySub.nItem, mySub.itemLoc, mySub.iDensity, mySub.nColorItm, mySub.nWork1, mySub.nWork2, mySub.brColor, mySub.pnColor);
            if (nProblem == 3 && kRectPoly > 0)
                mySub.SymbPolyDraw(e, mySub.fitemPoly, kRectPoly, mySub.nVert, mySub.xVert, mySub.yVert, rWidPoly, rHeiPoly, kPolySymb, mySub.npSign2, mySub.nBackCol, mySub.npItem, mySub.nOneSymb,
                    mySub.nWork1, mySub.nWork2, mySub.nColorItm, mySub.brColor, mySub.pnColor);
            if (nProblem == 11)
            {
                label4.Text = "Последний процесс: Результаты Загрузки измерений из файла (контрольные точки)";
                if (kGeo > 0 && kLineDop > 0)
                {
                    mySub.GeoLineDraw(e, kLineDop, mySub.sGeoDop1, mySub.xGeoDop1, mySub.yGeoDop1, mySub.sGeoDop2, mySub.xGeoDop2, mySub.yGeoDop2, kGeo, mySub.nameGeo, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 0, kGeoAll, mySub.nameGeo, mySub.xGeo, mySub.yGeo, mySub.zGeo, mySub.xGeoInscr, mySub.yGeoInscr, mySub.iHorVerGeo, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nGeoCode, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.numCol, mySub.brColor, mySub.pnColor);
                }
            }
            if (nProblem == 12)
            {
                label4.Text = "Последний процесс: Результат загрузки данных файла измерения точек DTM'";
                if (kTaheo > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 0, kTaheo, mySub.nameTah, mySub.xTah, mySub.yTah, mySub.zTah, mySub.xTahInscr, mySub.yTahInscr, mySub.iHorVerTah, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nTah1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.numCol, mySub.brColor, mySub.pnColor);
            }
            if (nProblem == 21 || nProblem == 25)
            {
                label4.Text = "Проверка процессов аэротриангуляции.";
                ik = iHeight - 30;
                if (kBlock > 0)
                {
                    for (int i = 1; i <= kBlock; ++i)
                    {
                        DllClass1.XYtoWIN(mySub.xBlock[i], mySub.yBlock[i], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out ix, out iy);
                        if ((ix != 0 || iy != 0) && mySub.blockName[i].IndexOf('-') > -1)
                        {
                            sTmp = mySub.blockName[i].Trim('-');
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
                    for (int i = 1; i <= kTar; ++i)
                    {
                        if (mySub.xTar[i] != 0.0 && mySub.yTar[i] != 0.0 && mySub.zTar[i] != 0.0)
                        {
                            DllClass1.XYtoWIN(mySub.xTar[i], mySub.yTar[i], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out ix, out iy);
                            if (ix != 0 || iy != 0)
                            {
                                graphics.FillRectangle((Brush)new SolidBrush(Color.Red), ix - num / 2, iy - num / 2, num, num);
                                graphics.DrawString(mySub.tarName[i], new Font("Bold", (float)ih), (Brush)new SolidBrush(Color.Black), (float)(ix + ih / 2), (float)(iy - ih));
                            }
                        }
                    }
                }
            }
            if (nProblem == 22)
            {
                sTmp = "Аэротриангуляция-Последний процесс:";
                DllClass1.DrawText(e, sTmp, 20, 60, pixHei / 2 - 20, 4, mySub.brColor);
                sTmp = "Проверка архива камер";
                DllClass1.DrawText(e, sTmp, 20, 50, pixHei / 2 + 10, 4, mySub.brColor);
            }
            if (nProblem == 23)
            {
                sTmp = "Аэротриангуляция-Последний процесс:";
                DllClass1.DrawText(e, sTmp, 20, 80, pixHei / 2 - 20, 4, mySub.brColor);
                sTmp = "Проверка архива контрольных точек";
                DllClass1.DrawText(e, sTmp, 20, 50, pixHei / 2 + 10, 4, mySub.brColor);
            }
            if (nProblem == 24)
            {
                sTmp = "Аэротриангуляция-Последний процесс:";
                DllClass1.DrawText(e, sTmp, 20, 80, pixHei / 2 - 20, 4, mySub.brColor);
                sTmp = "Проверка архива точек DTM";
                DllClass1.DrawText(e, sTmp, 20, 50, pixHei / 2 + 10, 4, mySub.brColor);
            }
            if (nProblem == 25)
                label4.Text = "Ввод стерео измерений и расчеты аэротриангуляции";
            if (nProblem == 26)
            {
                label4.Text = "Control of Aerotriangulation's processes";
                sTmp = "Аэротриангуляция-Последний процесс:";
                DllClass1.DrawText(e, sTmp, 20, 80, pixHei / 2 - 20, 4, mySub.brColor);
                sTmp = "Control of Aerotriangulation's processes";
                DllClass1.DrawText(e, sTmp, 20, 50, pixHei / 2 + 10, 4, mySub.brColor);
            }
            if (nProblem == 31 || nProblem == 32)
            {
                label4.Text = "Кадастр и топография-Последний процесс: File points input";
                if (nProblem == 32)
                    label4.Text = "Кадастр и топография-Последний процесс: Additional points";
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
            }
            if (nProblem == 33 || nProblem == 34)
            {
                label4.Text = "Кадастр и топография-Последний процесс: Geodey calculation data";
                if (nProblem == 34)
                    label4.Text = "Кадастр и топография-Последний процесс: Aerotriangulation data";
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
            }
            if (nProblem == 40)
            {
                label4.Text = "Control of Cadstral processes";
                sTmp = "Кадастр и топография-Последний процесс:";
                DllClass1.DrawText(e, sTmp, 20, 80, pixHei / 2 - 20, 4, mySub.brColor);
                sTmp = "Verification of cadastral processes";
                DllClass1.DrawText(e, sTmp, 20, 50, pixHei / 2 + 10, 4, mySub.brColor);
            }
            if (nProblem == 41)
            {
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
                if (kLineInput > 0)
                {
                    int iPar = 1;
                    DllClass1.LineDraw(e, kLineInput, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, mySub.rRadLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
            }
            if (nProblem == 42)
            {
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
                if (kLineTopo > 0)
                {
                    int iPar = 4;
                    DllClass1.LineDraw(e, kLineTopo, mySub.kl1, mySub.kl2, mySub.zLin, mySub.zPik, mySub.radLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
                if (kNode > 0)
                    DllClass1.DrawNode(e, kNode, mySub.nameNode, mySub.xNode, mySub.yNode, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
                if (mySub.kPoly > 0)
                    LabelDraw(e, mySub.kPoly, mySub.namePoly, mySub.xLab, mySub.yLab, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            }
            if (nProblem == 51)
            {
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
                if (kLineInput > 0)
                {
                    int iPar = 1;
                    DllClass1.LineDraw(e, kLineInput, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, mySub.rRadLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
                if (File.Exists(mySub.fileContour))
                    DllClass1.ContourDraw(e, mySub.fileContour, mySub.xDop, mySub.yDop, mySub.xOut, mySub.yOut, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            }
            if (nProblem == 61 || nProblem == 62 || nProblem == 63)
            {
                label4.Text = "Кадастр и топография-Последний процесс: Design's points file input";
                if (nProblem == 62)
                    label4.Text = "Кадастр и топография-Последний процесс: Design's additional points";
                if (kPntPlus > 0)
                    DllClass1.PointsDraw(e, mySub.fsymbPnt, 1, kPntPlus, mySub.namePnt, mySub.xPnt, mySub.yPnt, mySub.zPnt, mySub.xPntInscr, mySub.yPntInscr, mySub.iHorVerPnt, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.nCode1, mySub.nCode2, kSymbPnt, mySub.numRec, mySub.numbUser, mySub.ixSqu, mySub.iySqu, mySub.nColor, mySub.brColor, mySub.pnColor);
                if (kPntProj > -1)
                    DrawPntProj(e);
                if (kLineInput > 0)
                {
                    int iPar = 1;
                    DllClass1.LineDraw(e, kLineInput, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, mySub.rRadLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
            }
            if (nProblem == 63)
            {
                label4.Text = "Кадастр и топография-Последний процесс: Design's lines forming";
                if (kLineProj > 0)
                {
                    int iPar = 2;
                    DllClass1.LineDraw(e, kLineProj, mySub.kPr1, mySub.kPr2, mySub.xLinProj, mySub.yLinProj, mySub.RadProj, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
                if (kLineInput > 0)
                {
                    int iPar = 1;
                    DllClass1.LineDraw(e, kLineInput, mySub.k1, mySub.k2, mySub.xLin, mySub.yLin, mySub.rRadLine, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
                }
            }
            if (nProblem != 71)
                return;
            label4.Text = "Кадастр и топография-Последний процесс: Действия с участками";
            if (kLineAct > 0)
            {
                int iPar = 1;
                DllClass1.LineDraw(e, kLineAct, mySub.kActLine1, mySub.kActLine2, mySub.xLineAct, mySub.yLineAct, mySub.radAct, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar);
            }
            if (kPolyAct > 0)
            {
                int iParam = 8;
                DllClass1.LabelDraw(e, kPolyAct, mySub.nameAct, mySub.xAct, mySub.yAct, mySub.iHorVer, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.brColor, iParam);
            }
            if (kNodeAct > 0)
                DllClass1.DrawNodeAct(e, kNodeAct, mySub.nameNodeAct, mySub.xNodeAct, mySub.yNodeAct, scaleToWin, xBegX, yBegY, xBegWin, yBegWin);
            if (kLineNew <= 0)
                return;
            int iPar1 = 2;
            DllClass1.LineDraw(e, kLineNew, mySub.kLinNew1, mySub.kLinNew2, mySub.xLinNew, mySub.yLinNew, mySub.RadNew, scaleToWin, xBegX, yBegY, xBegWin, yBegWin, mySub.pnColor, iPar1);
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
