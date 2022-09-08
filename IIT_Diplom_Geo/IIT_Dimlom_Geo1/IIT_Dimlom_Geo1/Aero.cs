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
    public partial class Aero : Form
    {

        private string sTmp = "";
        private string sTemp = "(Sqrt(dx*dx+dy*dy+dz*dz))";
        private int iWidth;
        private int iHeight;
        private int pixWid;
        private int pixHei;
        private int kBlock;
        private int kTar;
        private int nProcess;
        private int iCond;
        private int iGraphic;
        private int iShowInter;
        private int kRcPnt;
        private int kFin;
        private int kInter;
        private int kPhoto;
        private int kRelate;
        private int kDiffer;
        private int kControl;
        private int nControl;
        private int kStrip;
        private int kMod;
        private int iKindMeasure;
        private int kDat;
        private int kGeo;
        private int kCheck;
        private int x1Box;
        private int y1Box;
        private int x2Box;
        private int y2Box;
        private double xmin;
        private double ymin;
        private double xmax;
        private double ymax;
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
        private double xminCur;
        private double yminCur;
        private double xmaxCur;
        private double ymaxCur;
        private double dxx;
        private double dyy;
        private double dzz;
        private double xCur;
        private double yCur;
        private double xMod1;
        private double yMod1;
        private double xMod2;
        private double yMod2;
        private double zMod1;
        private double zMod2;
        private double xaCur;
        private double yaCur;
        private double xbCur;
        private double ybCur;
        private int[] xDat = new int[5];
        private int[] yDat = new int[5];
        private int nProblem;
        private string[] finError = new string[10];
        private string[] sApprox = new string[10];

        private MyGeodesy mySub = new MyGeodesy();
        public Aero()
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
            panel3.Text = "***";
            panel5.Text = "***";
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
            button29.MouseHover += new EventHandler(button29_MouseHover);
            button29.MouseLeave += new EventHandler(button1_MouseLeave);
            button30.MouseHover += new EventHandler(button30_MouseHover);
            button30.MouseLeave += new EventHandler(button1_MouseLeave);
            button31.MouseHover += new EventHandler(button31_MouseHover);
            button31.MouseLeave += new EventHandler(button1_MouseLeave);
            button32.MouseHover += new EventHandler(button32_MouseHover);
            button32.MouseLeave += new EventHandler(button1_MouseLeave);
            button33.MouseHover += new EventHandler(button33_MouseHover);
            button33.MouseLeave += new EventHandler(button1_MouseLeave);
            button34.MouseHover += new EventHandler(button34_MouseHover);
            button34.MouseLeave += new EventHandler(button1_MouseLeave);
            mySub.FilePath();
            Form_Load();
        }

        private void button1_MouseHover(object sender, EventArgs e) => label3.Text = "Закрыть окно";

        private void button1_MouseLeave(object sender, EventArgs e) => label3.Text = "";

        private void button2_MouseHover(object sender, EventArgs e) => label3.Text = "Открыть новый проект";

        private void button3_MouseHover(object sender, EventArgs e) => label3.Text = "Выбрать и открыть ранее созданный проект";

        private void button4_MouseHover(object sender, EventArgs e) => label3.Text = "Выберите и удалите ранее созданный проект";

        private void button5_MouseHover(object sender, EventArgs e) => label3.Text = "Удаление ВСЕХ проектов с данного(текущего) диска";

        private void button6_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Изменить диск для выбора старого проекта или создания нового";

        private void button7_MouseHover(object sender, EventArgs e) 
            => label3.Text = "После нажатия этой кнопки появляется 'Окно' обслуживания(исправления) данных камер";

        private void button8_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Вы можете удалить существующий 'архив' камер, если вы действительно этого хотите";

        private void button9_MouseHover(object sender, EventArgs e) 
            => label3.Text = "После нажатия на эту кнопку появляется стандартный окно ввода файла контрольных точек";

        private void button10_MouseHover(object sender, EventArgs e) 
            => label3.Text = "После нажатия на эту кнопку появляется Окно для работы с контрольными точками";

        private void button11_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Вы можете удалить существующий архив контрольных точек, если вы действительно этого хотите.";

        private void button12_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Используйте эту кнопку для добавления координат из файла, если Система координат текущего проекта отличается от контрольных точек 'Архива'";

        private void button13_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Нажмите эту кнопку. Появится стандартное окно для ввода данных из файла. Выберите файл с измерениями StereoScopic";

        private void button14_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Результаты внутреннего ориентирования";

        private void button15_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Результаты относительной ориентации";

        private void button16_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Результат совмещения моделей";

        private void button17_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Результат совмещения линий";

        private void button18_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Остаточные ошибки контрольных точек";

        private void button19_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Проверка остаточных ошибок точек";

        private void button20_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Возвращения к оригиналу";

        private void button21_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Показать все точки аэротриангуляции";

        private void button22_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Нажмите эту кнопку и после этого выделите мышкой часть контрольных точек в качестве исходных и нажать правую кнопку";

        private void button23_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Нажмите эту кнопку и после этого выделите мышкой часть контрольных точек в качестве проверочных и нажать правую кнопку";

        private void button24_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Вернуться ко всем точкам как контрольным после выбора контрольных или проверочных точек";

        private void button25_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Нажмите эту кнопку. В появившемся списке вы можете увидеть координаты точек и центров аэрофотосъемки, остаточные ошибки";

        private void button26_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Открыть стандартное окно(меню) для входного файла стереомодели с точками ЦММ";

        private void button27_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Показать результат вставки стереомодели";

        private void button28_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Добавить текущую модель в архив";

        private void button29_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Показать архив ЦММ (ЦИфровой модели местности)";

        private void button30_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Вы можете удалить архив ЦММ, если вы действительно этого хотите.";

        private void button31_MouseHover(object sender, EventArgs e) 
            => label3.Text = "Нажмите кнопку. Зажмите левую кнопку мыши и ведите мышь. После выбора области - отпустите кнопку мыши. Щелкните правой кнопкой мыши для возвращения в исходное положение";

        private void button32_MouseHover(object sender, EventArgs e) 
            => label3.Text = "После нажатия на данную кнопку, зажмите и отпустите левую кнопку мыши рядом с выбранной точкой. Щелкните правой кнопкой мыши для возвращения в исходное положение";

        private void button33_MouseHover(object sender, EventArgs e) 
            => label3.Text = "После нажатия на данную кнопку, зажмите и отпустите левую кнопку мыши рядом с выбранной точкой.Щелкните правой кнопкой мыши для возвращения в исходное положение";

        private void button34_MouseHover(object sender, EventArgs e) 
            => label3.Text = "После нажатия на эту кнопку, Зажмите левую кнопку мыши и ведите мышь along the screen. Щелкните правой кнопкой мыши для возвращения в исходное положение";


        private void Form_Load()
        {
            mySub.FilePath();
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)new SelectDrive().ShowDialog((IWin32Window)this);
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
                int num2 = (int)MessageBox.Show("Используйте 'Новый проект'", "Новый проект", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                sTmp = mySub.comPath + mySub.curDirect;
                if (!Directory.Exists(sTmp))
                    Directory.CreateDirectory(sTmp);
                label2.Text = sPart[1] + "\\" + mySub.curProject;
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
            kBlock = 0;
            kTar = 0;
            if (nProcess != 300 && nProcess != 310 && nProcess != 320)
            {
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
            }
            nProblem = 21;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            xminCur = xmin;
            yminCur = ymin;
            xmaxCur = xmax;
            ymaxCur = ymax;
            DllClass1.CoorWin(xmin, ymin, xmax, ymax, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
            if (iCond >= 0)
                return;
            iGraphic = 1;
        }

        public void SecondGeo(out int iParam)
        {
            iParam = 0;
            panel1.Text = "Пожалуйста подождите. Коррекция искажений аэрофотоснимков";
            int iCond;
            mySub.StereoDeform(out iCond, mySub.fileAero);
            panel1.Text = "Готов...";
            if (iCond != 0)
            {
                iParam = iCond;
            }
            else
            {
                panel1.Text = "Пожалуйста подождите. Внутренняя ориентация";
                mySub.DifInterior(out iCond, out int _);
                panel1.Text = "Готов...";
                if (iCond != 0)
                {
                    iParam = iCond;
                }
                else
                {
                    panel1.Text = "Пожалуйста подождите. Формирование полос(Линий)";
                    BuildStrip(out iCond);
                    panel1.Text = "Готов...";
                    if (iCond != 0)
                    {
                        iParam = iCond;
                    }
                    else
                    {
                        panel1.Text = "Пожалуйста подождите. Соединение полос(линий)";
                        mySub.StripsJoin(out iCond);
                        panel1.Text = "Готов...";
                        if (iCond != 0)
                        {
                            iParam = iCond;
                        }
                        else
                        {
                            int nParam = 0;
                            if (File.Exists(mySub.fileDoubt))
                            {
                                FileStream input = new FileStream(mySub.fileDoubt, FileMode.Open, FileAccess.Read);
                                BinaryReader binaryReader = new BinaryReader((Stream)input);
                                try
                                {
                                    nParam = binaryReader.ReadInt32();
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
                            if (File.Exists(mySub.fileDoubt))
                                File.Delete(mySub.fileDoubt);
                            if (kStrip > 1)
                            {
                                panel1.Text = "Пожалуйста подождите. Внешняя ориентация";
                                mySub.BlockToGeo(out iCond, nParam);
                                panel1.Text = "Готов...";
                                if (iCond != 0)
                                {
                                    iParam = iCond;
                                    return;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.sumTol[1]);
                                finError[1] = "Свободный блок = " + sTmp + "(dx=" + string.Format("{0:F3}", (object)mySub.tolDx[1]) + "; dy=" + string.Format("{0:F3}", (object)mySub.tolDy[1]) + "; dz=" + string.Format("{0:F3}", (object)mySub.tolDz[1]) + ")";
                            }
                            panel1.Text = "Пожалуйста подождите. Внешняя ориентация";
                            mySub.StripToGeo(out iCond, nParam);
                            panel1.Text = "Готов...";
                            if (iCond != 0)
                            {
                                iParam = iCond;
                            }
                            else
                            {
                                if (kStrip > 1 && mySub.sumTol[2] != 0.0)
                                {
                                    sTmp = string.Format("{0:F3}", (object)mySub.sumTol[2]);
                                    finError[2] = "Не свободный блок = " + sTmp + sTemp;
                                    finError[2] = "Не свободный блок = " + sTmp + "(dx=" + string.Format("{0:F3}", (object)mySub.tolDx[2]) + "; dy=" + string.Format("{0:F3}", (object)mySub.tolDy[2]) + "; dz=" + string.Format("{0:F3}", (object)mySub.tolDz[2]) + ")";
                                }
                                panel1.Text = "Пожалуйста подождите. преобразовать стерео в моно";
                                mySub.StereoToMono(out iCond);
                                panel1.Text = "Готов...";
                                if (iCond != 0)
                                {
                                    iParam = iCond;
                                }
                                else
                                {
                                    panel1.Text = "Пожалуйста подождите. Одновременная корректировка пучка(набора)";
                                    mySub.BackDirect(out iCond, 1);
                                    panel1.Text = "Готов...";
                                    if (iCond != 0)
                                    {
                                        iParam = iCond;
                                    }
                                    else
                                    {
                                        if (sApprox[1] == "")
                                        {
                                            sTmp = string.Format("Число приближений = {0}", (object)mySub.numApprox);
                                            sApprox[1] = "Минимизация DX, DY, DZ - " + sTmp;
                                            sTmp = string.Format("{0:F3}", (object)mySub.sumTol[3]);
                                            finError[3] = sTmp + "(dx=" + string.Format("{0:F3}", (object)mySub.tolDx[3]) + "; dy=" + string.Format("{0:F3}", (object)mySub.tolDy[3]) + "; dz=" + string.Format("{0:F3}", (object)mySub.tolDz[3]) + ")";
                                        }
                                        panel1.Text = "Пожалуйста подождите. Одновременная корректировка пучка(набора)";
                                        mySub.BackDirect(out iCond, 2);
                                        panel1.Text = "Готов...";
                                        if (iCond != 0)
                                        {
                                            iParam = iCond;
                                        }
                                        else
                                        {
                                            if (sApprox[2] == "")
                                            {
                                                sTmp = string.Format("Число приближений = {0}", (object)mySub.numApprox);
                                                sApprox[2] = "Минимизация DX, DY - " + sTmp;
                                                sTmp = string.Format("{0:F3}", (object)mySub.sumTol[4]);
                                                finError[4] = sTmp + "(dx=" + string.Format("{0:F3}", (object)mySub.tolDx[4]) + "; dy=" + string.Format("{0:F3}", (object)mySub.tolDy[4]) + "; dz=" + string.Format("{0:F3}", (object)mySub.tolDz[4]) + ")";
                                            }
                                            panel1.Text = "Пожалуйста подождите. Одновременная корректировка пучка(набора)";
                                            mySub.BackDirect(out iCond, 3);
                                            panel1.Text = "Готов...";
                                            if (iCond != 0)
                                            {
                                                iParam = iCond;
                                            }
                                            else
                                            {
                                                if (sApprox[3] == "")
                                                {
                                                    sTmp = string.Format("Число приближений = {0}", (object)mySub.numApprox);
                                                    sApprox[3] = "Минимизация DZ - " + sTmp;
                                                    sTmp = string.Format("{0:F3}", (object)mySub.sumTol[5]);
                                                    finError[5] = sTmp + "(dx=" + string.Format("{0:F3}", (object)mySub.tolDx[5]) + "; dy=" + string.Format("{0:F3}", (object)mySub.tolDy[5]) + "; dz=" + string.Format("{0:F3}", (object)mySub.tolDz[5]) + ")";
                                                }
                                                panel1.Text = "Пожалуйста подождите. Сохранение данных";
                                                mySub.BaseOrient();
                                                panel1.Text = "Готов...";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void ThirdGeo(out int iParam)
        {
            iParam = 0;
            panel1.Text = "Пожалуйста подождите. Одновременная корректировка пучка(набора)";
            int iCond;
            mySub.BackDirect(out iCond, 1);
            panel1.Text = "Готов...";
            if (iCond != 0)
            {
                iParam = iCond;
            }
            else
            {
                if (sApprox[1] == "")
                {
                    sTmp = string.Format("Число приближений = {0}", (object)mySub.numApprox);
                    sApprox[1] = "Минимизация DX, DY, DZ - " + sTmp;
                }
                sTmp = string.Format("{0:F3}", (object)mySub.sumTol[3]);
                finError[3] = sTmp + "(dx=" + string.Format("{0:F3}", (object)mySub.tolDx[3]) + "; dy=" + string.Format("{0:F3}", (object)mySub.tolDy[3]) + "; dz=" + string.Format("{0:F3}", (object)mySub.tolDz[3]) + ")";
                panel1.Text = "Пожалуйста подождите. Одновременная корректировка пучка(набора)";
                mySub.BackDirect(out iCond, 2);
                panel1.Text = "Готов...";
                if (iCond != 0)
                {
                    iParam = iCond;
                }
                else
                {
                    if (sApprox[2] == "")
                    {
                        sTmp = string.Format("Число приближений = {0}", (object)mySub.numApprox);
                        sApprox[2] = "Минимизация DX, DY - " + sTmp;
                    }
                    sTmp = string.Format("{0:F3}", (object)mySub.sumTol[4]);
                    finError[4] = sTmp + "(dx=" + string.Format("{0:F3}", (object)mySub.tolDx[4]) + "; dy=" + string.Format("{0:F3}", (object)mySub.tolDy[4]) + "; dz=" + string.Format("{0:F3}", (object)mySub.tolDz[4]) + ")";
                    panel1.Text = "Пожалуйста подождите. Одновременная корректировка пучка(набора)";
                    mySub.BackDirect(out iCond, 3);
                    panel1.Text = "Готов...";
                    if (iCond != 0)
                    {
                        iParam = iCond;
                    }
                    else
                    {
                        if (sApprox[3] == "")
                        {
                            sTmp = string.Format("Число приближений = {0}", (object)mySub.numApprox);
                            sApprox[3] = "Минимизация DZ - " + sTmp;
                        }
                        sTmp = string.Format("{0:F3}", (object)mySub.sumTol[5]);
                        finError[5] = sTmp + "(dx=" + string.Format("{0:F3}", (object)mySub.tolDx[5]) + "; dy=" + string.Format("{0:F3}", (object)mySub.tolDy[5]) + "; dz=" + string.Format("{0:F3}", (object)mySub.tolDz[5]) + ")";
                        panel1.Text = "Пожалуйста подождите. Сохранение данных";
                        mySub.BaseOrient();
                        panel1.Text = "Готов...";
                    }
                }
            }
        }

        public void ModelGeo(out int iParam)
        {
            iParam = 0;
            int iCond;
            mySub.OneStereo(out iCond, mySub.aeroStrip, mySub.fileAero, mySub.aerialPhoto, mySub.frelOrient, mySub.fotoStrip);
            if (iCond != 0)
            {
                iParam = iCond;
            }
            else
            {
                mySub.StripToGeo(out iCond, 0);
                if (iCond != 0)
                {
                    iParam = iCond;
                }
                else
                {
                    if (File.Exists(mySub.fileDoubt))
                    {
                        int num = (int)new DoubtfulPnt().ShowDialog((IWin32Window)this);
                    }
                    mySub.BackDirect(out iCond, 1);
                    if (iCond != 0)
                    {
                        nProcess = 0;
                        iParam = iCond;
                    }
                    else
                    {
                        mySub.BackDirect(out iCond, 2);
                        if (iCond != 0)
                        {
                            nProcess = 0;
                            iParam = iCond;
                        }
                        else
                        {
                            mySub.BackDirect(out iCond, 3);
                            if (iCond != 0)
                            {
                                nProcess = 0;
                                iParam = iCond;
                            }
                            else
                            {
                                if (File.Exists(mySub.difModel))
                                    File.Delete(mySub.difModel);
                                if (!File.Exists(mySub.difStrip))
                                    return;
                                File.Delete(mySub.difStrip);
                            }
                        }
                    }
                }
            }
        }

        public void BuildStrip(out int iCond)
        {
            iCond = 0;
            int iCond1;
            mySub.RelOrient(out iCond1);
            if (iCond1 < 0)
            {
                iCond = -1;
            }
            else
            {
                mySub.ModelPhoto(out iCond1);
                if (iCond1 < 0)
                {
                    iCond = -1;
                }
                else
                {
                    mySub.ModelsJoin(out iCond1);
                    if (iCond1 >= 0)
                        return;
                    iCond = -1;
                }
            }
        }

        public void FirstGeo(out int iParam, out int kMod)
        {
            iParam = 0;
            kMod = 0;
            panel1.Text = "Пожалуйста подождите. Коррекция искажений аэрофотоснимков";
            int iCond;
            mySub.StereoDeform(out iCond, mySub.fileAero);
            panel1.Text = "Готов...";
            if (iCond != 0)
            {
                iParam = iCond;
            }
            else
            {
                panel1.Text = "Пожалуйста подождите. Внутренняя ориентация";
                int kMod1;
                mySub.DifInterior(out iCond, out kMod1);
                panel1.Text = "Готов...";
                if (iCond != 0)
                {
                    iParam = iCond;
                }
                else
                {
                    kMod = kMod1;
                    if (kMod1 == 1)
                        return;
                    panel1.Text = "Пожалуйста подождите. Формирование полос(Линий)";
                    BuildStrip(out iCond);
                    panel1.Text = "Готов...";
                    if (iCond != 0)
                    {
                        iParam = iCond;
                    }
                    else
                    {
                        panel1.Text = "Пожалуйста подождите. Соединение полос(линий)";
                        mySub.StripsJoin(out iCond);
                        panel1.Text = "Готов...";
                        if (iCond != 0)
                        {
                            iParam = iCond;
                        }
                        else
                        {
                            if (kStrip > 1)
                            {
                                panel1.Text = "Пожалуйста подождите. Внешняя ориентация";
                                mySub.BlockToGeo(out iCond, 0);
                                panel1.Text = "Готов...";
                                if (iCond != 0)
                                {
                                    iParam = iCond;
                                    return;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.sumTol[1]);
                                finError[1] = "Свободный блок = " + sTmp + "(dx=" + string.Format("{0:F3}", (object)mySub.tolDx[1]) + "; dy=" + string.Format("{0:F3}", (object)mySub.tolDy[1]) + "; dz=" + string.Format("{0:F3}", (object)mySub.tolDz[1]) + ")";
                            }
                            if (kStrip == 1)
                            {
                                panel1.Text = "Пожалуйста подождите. Внешняя ориентация";
                                mySub.StripToGeo(out iCond, 0);
                                panel1.Text = "Готов...";
                                if (iCond != 0)
                                {
                                    iParam = iCond;
                                    return;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.sumTol[2]);
                                finError[2] = "Полоса(направление) = " + sTmp + "(dx=" + string.Format("{0:F3}", (object)mySub.tolDx[2]) + "; dy=" + string.Format("{0:F3}", (object)mySub.tolDy[2]) + "; dz=" + string.Format("{0:F3}", (object)mySub.tolDz[2]) + ")";
                            }
                            if (!File.Exists(mySub.fileDoubt))
                                return;
                            int num = (int)new DoubtfulPnt().ShowDialog((IWin32Window)this);
                        }
                    }
                }
            }
        }

        public void LoadModel(out int iCond)
        {
            iCond = 0;
            kFin = 0;
            if (File.Exists(mySub.fileModel))
            {
                FileStream input = new FileStream(mySub.fileModel, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                xMod1 = 9999999.9;
                yMod1 = 9999999.9;
                xMod2 = -9999999.9;
                yMod2 = -9999999.9;
                zMod1 = 9999999.9;
                zMod2 = -9999999.9;
                try
                {
                    binaryReader.ReadInt32();
                    binaryReader.ReadInt32();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    kFin = binaryReader.ReadInt32();
                    for (int index = 1; index <= kFin; ++index)
                    {
                        mySub.nameFin[index] = binaryReader.ReadString();
                        mySub.xFin[index] = binaryReader.ReadDouble();
                        mySub.yFin[index] = binaryReader.ReadDouble();
                        mySub.zFin[index] = binaryReader.ReadDouble();
                        if (mySub.xFin[index] < xMod1)
                            xMod1 = mySub.xFin[index];
                        if (mySub.xFin[index] > xMod2)
                            xMod2 = mySub.xFin[index];
                        if (mySub.yFin[index] < yMod1)
                            yMod1 = mySub.yFin[index];
                        if (mySub.yFin[index] > yMod2)
                            yMod2 = mySub.yFin[index];
                        if (mySub.zFin[index] < zMod1)
                            zMod1 = mySub.zFin[index];
                        if (mySub.zFin[index] > xMod2)
                            zMod2 = mySub.zFin[index];
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
                xminCur = xMod1;
                yminCur = yMod1;
                xmaxCur = xMod2;
                ymaxCur = yMod2;
                DllClass1.CoorWin(xMod1, yMod1, xMod2, yMod2, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                if (iCond < 0)
                {
                    iGraphic = 1;
                    return;
                }
            }
            if (kFin > 0)
                return;
            iCond = -99;
            int num = (int)MessageBox.Show("Данные отсутствуют", "Проверьте архив ЦММ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void LoadStore(out int iCond)
        {
            iCond = 0;
            xMod1 = 9999999.9;
            yMod1 = 9999999.9;
            xMod2 = -9999999.9;
            yMod2 = -9999999.9;
            zMod1 = 9999999.9;
            zMod2 = -9999999.9;
            kFin = 0;
            if (File.Exists(mySub.fbaseDtm))
            {
                FileStream input = new FileStream(mySub.fbaseDtm, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    binaryReader.ReadDouble();
                    while (binaryReader.ReadInt32() != 0)
                    {
                        binaryReader.ReadInt32();
                        int num1 = binaryReader.ReadInt32();
                        for (int index = 1; index <= num1; ++index)
                        {
                            string str = binaryReader.ReadString();
                            double num2 = binaryReader.ReadDouble();
                            double num3 = binaryReader.ReadDouble();
                            double num4 = binaryReader.ReadDouble();
                            ++kFin;
                            mySub.nameFin[kFin] = str;
                            mySub.xFin[kFin] = num2;
                            mySub.yFin[kFin] = num3;
                            mySub.zFin[kFin] = num4;
                            if (num2 < xMod1)
                                xMod1 = num2;
                            if (num2 > xMod2)
                                xMod2 = num2;
                            if (num3 < yMod1)
                                yMod1 = num3;
                            if (num3 > yMod2)
                                yMod2 = num3;
                            if (num4 < zMod1)
                                zMod1 = num4;
                            if (num4 > xMod2)
                                zMod2 = num4;
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
                xminCur = xMod1;
                yminCur = yMod1;
                xmaxCur = xMod2;
                ymaxCur = yMod2;
                DllClass1.CoorWin(xMod1, yMod1, xMod2, yMod2, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                if (iCond < 0)
                {
                    iGraphic = 1;
                    return;
                }
            }
            if (kFin > 0)
                return;
            iCond = -99;
            int num = (int)MessageBox.Show("Данные отсутствуют", "Архив ЦММ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int xWin1 = 0;
            int yWin = 0;
            int emSize1 = 7;
            int y1 = iHeight - 30;
            if (pixHei > iHeight)
                y1 = pixHei - 30;
            if (iGraphic > 0 || iShowInter > 0)
                return;
            if ((nProcess == 230 || nProcess == 240) && kRcPnt > 0)
            {
                for (int index = 1; index <= kRcPnt; ++index)
                    graphics.FillRectangle((Brush)new SolidBrush(Color.Cyan), RcPnt[index]);
            }
            if (nProcess != 300 && nProcess != 310 && nProcess != 320 && nProcess != 330)
            {
                if (kBlock > 0)
                {
                    for (int index1 = 1; index1 <= kBlock; ++index1)
                    {
                        DllClass1.XYtoWIN(mySub.xBlock[index1], mySub.yBlock[index1], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin);
                        if (xWin1 != 0 || yWin != 0)
                        {
                            if (mySub.blockName[index1].IndexOf('-') > -1)
                            {
                                sTmp = mySub.blockName[index1].Trim('-');
                                graphics.DrawRectangle(new Pen(Color.Brown), xWin1 - 3, yWin - 3, 6, 6);
                                graphics.FillRectangle((Brush)new SolidBrush(Color.Brown), xWin1, yWin, 2, 2);
                                graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Brown), (float)(xWin1 + 3), (float)(yWin - 4));
                            }
                            else if (nProcess == 290)
                            {
                                sTmp = mySub.blockName[index1].Trim('-');
                                int num = 0;
                                for (int index2 = 1; index2 <= kTar; ++index2)
                                {
                                    if (mySub.tarName[index2] == sTmp)
                                    {
                                        ++num;
                                        break;
                                    }
                                }
                                if (num <= 0)
                                {
                                    graphics.DrawRectangle(new Pen(Color.Black), xWin1 - 1, yWin - 1, 2, 2);
                                    graphics.FillRectangle((Brush)new SolidBrush(Color.Black), xWin1, yWin, 2, 2);
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Black), (float)(xWin1 + 3), (float)(yWin - 4));
                                }
                            }
                        }
                    }
                    graphics.DrawRectangle(new Pen(Color.Brown), 130, y1, 6, 6);
                    graphics.FillRectangle((Brush)new SolidBrush(Color.Brown), 132, y1 + 3, 2, 2);
                    graphics.DrawString(" - Центр аэрофотосъемки", new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Brown), 133f, (float)(y1 - emSize1 / 2));
                }
                int num1 = 6;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                for (int index3 = 1; index3 <= kTar; ++index3)
                {
                    if (mySub.xTar[index3] != 0.0 && mySub.yTar[index3] != 0.0 && mySub.zTar[index3] != 0.0)
                    {
                        DllClass1.XYtoWIN(mySub.xTar[index3], mySub.yTar[index3], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin);
                        if (xWin1 != 0 || yWin != 0)
                        {
                            ++num2;
                            graphics.FillRectangle((Brush)new SolidBrush(Color.Red), xWin1 - num1 / 2, yWin - num1 / 2, num1, num1);
                            graphics.DrawString(mySub.tarName[index3], new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Black), (float)(xWin1 + emSize1 / 2), (float)(yWin - emSize1));
                        }
                    }
                    else if (mySub.zTar[index3] == 0.0)
                    {
                        DllClass1.XYtoWIN(mySub.xTar[index3], mySub.yTar[index3], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin);
                        if (xWin1 != 0 || yWin != 0)
                        {
                            ++num3;
                            graphics.FillRectangle((Brush)new SolidBrush(Color.Blue), xWin1 - num1 / 2, yWin - num1 / 2, num1, num1);
                            graphics.DrawString(mySub.tarName[index3], new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Black), (float)(xWin1 + emSize1 / 2), (float)(yWin - emSize1));
                        }
                    }
                    else if (mySub.xTar[index3] == 0.0 && mySub.yTar[index3] == 0.0 && mySub.zTar[index3] != 0.0 && kBlock > 0)
                    {
                        for (int index4 = 1; index4 <= kBlock; ++index4)
                        {
                            if (mySub.blockName[index4] == mySub.tarName[index3])
                            {
                                DllClass1.XYtoWIN(mySub.xBlock[index4], mySub.yBlock[index4], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin);
                                if (xWin1 != 0 || yWin != 0)
                                {
                                    ++num4;
                                    graphics.FillRectangle((Brush)new SolidBrush(Color.Green), xWin1 - num1 / 2, yWin - num1 / 2, num1, num1);
                                    graphics.DrawString(mySub.tarName[index3], new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Black), (float)(xWin1 + emSize1 / 2), (float)(yWin - emSize1));
                                    break;
                                }
                            }
                        }
                    }
                }
                if (num2 > 0)
                {
                    graphics.FillRectangle((Brush)new SolidBrush(Color.Red), 12, y1, num1, num1);
                    graphics.DrawString(" - X Y Z", new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Red), 14f, (float)(y1 - emSize1 / 2));
                }
                if (num3 > 0)
                {
                    graphics.FillRectangle((Brush)new SolidBrush(Color.Blue), 60, y1, num1, num1);
                    graphics.DrawString(" - X Y", new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Blue), 64f, (float)(y1 - emSize1 / 2));
                }
                if (num4 > 0)
                {
                    graphics.FillRectangle((Brush)new SolidBrush(Color.Green), 100, y1, num1, num1);
                    graphics.DrawString(" - Z", new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Green), 104f, (float)(y1 - emSize1 / 2));
                }
            }
            if (nProcess == 300 || nProcess == 310)
            {
                if (kFin <= 0)
                    return;
                for (int index = 1; index <= kFin; ++index)
                {
                    DllClass1.XYtoWIN(mySub.xFin[index], mySub.yFin[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin);
                    if (xWin1 != 0 || yWin != 0)
                    {
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Black), xWin1, yWin, 2, 2);
                        sTmp = string.Format("{0:F3}", (object)mySub.zFin[index]);
                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Black), (float)(xWin1 + 2), (float)(yWin - emSize1));
                    }
                }
            }
            if (nProcess == 320 || nProcess == 330)
            {
                if (kFin <= 0)
                    return;
                for (int index = 1; index <= kFin; ++index)
                {
                    DllClass1.XYtoWIN(mySub.xFin[index], mySub.yFin[index], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin);
                    if (xWin1 != 0 || yWin != 0)
                    {
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Black), xWin1, yWin, 2, 2);
                        sTmp = string.Format("{0:F3}", (object)mySub.zFin[index]);
                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Black), (float)(xWin1 + 2), (float)(yWin - emSize1));
                    }
                }
            }
            if (nProcess == 160)
            {
                if (kBlock <= 0 || kInter == 0)
                {
                    nProcess = 0;
                    int num = (int)MessageBox.Show("Данные отсутствуют", "Внутренняя ориентация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    panel7.Invalidate();
                    return;
                }
                double num5 = 0.0;
                double num6 = 0.0;
                int num7;
                int num8 = num7 = 0;
                for (int index = 1; index <= kInter; ++index)
                {
                    num5 += Math.Abs(mySub.xDif[index]);
                    num6 += Math.Abs(mySub.yDif[index]);
                }
                double num9 = num5 / (double)kInter;
                double num10 = num6 / (double)kInter;
                double num11 = num9;
                if (num10 < num9)
                    num11 = num10;
                int num12 = 0;
                for (int index5 = 1; index5 <= kInter; ++index5)
                {
                    for (int index6 = 1; index6 <= kBlock; ++index6)
                    {
                        if (mySub.tmpName[index5] == mySub.blockName[index6])
                        {
                            DllClass1.XYtoWIN(mySub.xBlock[index6], mySub.yBlock[index6], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin);
                            if (xWin1 != 0 || yWin != 0)
                            {
                                graphics.FillRectangle((Brush)new SolidBrush(Color.Black), xWin1, yWin, 2, 2);
                                int x = xWin1 + 2;
                                int y2 = yWin - emSize1;
                                graphics.DrawString(mySub.tmpName[index5], new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Blue), (float)x, (float)y2);
                                int num13 = 0;
                                if (Math.Abs(mySub.xDif[index5]) > 3.0 * num11)
                                {
                                    ++num13;
                                    ++num12;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.xDif[index5]);
                                int num14 = y2 + emSize1;
                                if (num13 == 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Black), (float)x, (float)(num14 + 1));
                                if (num13 > 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num14 + 1));
                                int num15 = 0;
                                if (Math.Abs(mySub.yDif[index5]) > 3.0 * num11)
                                {
                                    ++num15;
                                    ++num12;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.yDif[index5]);
                                int num16 = num14 + emSize1;
                                if (num15 == 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Black), (float)x, (float)(num16 + 1));
                                if (num15 > 0)
                                {
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num16 + 1));
                                    break;
                                }
                                break;
                            }
                        }
                    }
                }
                if (num12 > 0)
                    graphics.DrawString("Голубой цвет -- Значение погрешностей", new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Cyan), 450f, (float)(y1 - emSize1 / 2));
            }
            if (nProcess == 170)
            {
                if (kPhoto <= 0 || kRelate == 0)
                {
                    nProcess = 0;
                    int num = (int)MessageBox.Show("Данные отсутствуют", "Относительная ориентация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    panel7.Invalidate();
                    return;
                }
                for (int index7 = 2; index7 <= kPhoto; ++index7)
                {
                    int num17 = mySub.numPhoto[index7 - 1];
                    int num18 = mySub.numPhoto[index7];
                    for (int index8 = 1; index8 <= kRelate; ++index8)
                    {
                        if (mySub.modLeft[index8] == num17 && mySub.modRight[index8] == num18)
                        {
                            DllClass1.XYtoWIN(0.5 * (mySub.xsPhoto[index7 - 1] + mySub.xsPhoto[index7]), 0.5 * (mySub.ysPhoto[index7 - 1] + mySub.ysPhoto[index7]), scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin);
                            if (xWin1 != 0 || yWin != 0)
                            {
                                sTmp = string.Format("{0:F3}", (object)mySub.xBase[index8]);
                                graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Red), (float)xWin1, (float)(yWin + 1));
                                sTmp = string.Format("{0:F3}", (object)mySub.yBase[index8]);
                                graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Blue), (float)xWin1, (float)(yWin + emSize1 + emSize1 / 2));
                                break;
                            }
                        }
                    }
                }
                graphics.DrawString("Красный-RSME до, Синий - после коррекции Y - параллакса", new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Black), 300f, (float)(y1 - emSize1 / 2));
            }
            if (nProcess == 180 || nProcess == 190)
            {
                if (kDiffer <= 0 && nProcess == 180)
                {
                    nProcess = 0;
                    int num = (int)MessageBox.Show("Данные отсутствуют", "Соединение моделей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    panel7.Invalidate();
                    return;
                }
                if (kDiffer <= 0 && nProcess == 190)
                {
                    nProcess = 0;
                    int num = (int)MessageBox.Show("Данные отсутствуют", "Соединение полос(линий)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    panel7.Invalidate();
                    return;
                }
                double num19 = 0.0;
                double num20 = 0.0;
                double num21 = 0.0;
                for (int index = 1; index <= kDiffer; ++index)
                {
                    num19 += Math.Abs(mySub.xBase[index]);
                    num20 += Math.Abs(mySub.yBase[index]);
                    num21 += Math.Abs(mySub.zBase[index]);
                }
                double num22 = num19 / (double)kDiffer;
                double num23 = num20 / (double)kDiffer;
                double num24 = num21 / (double)kDiffer;
                double num25 = num22;
                if (num23 < num22)
                    num25 = num23;
                int num26 = 0;
                for (int index9 = 1; index9 <= kDiffer; ++index9)
                {
                    for (int index10 = 1; index10 <= kBlock; ++index10)
                    {
                        if (mySub.tmpName[index9] == mySub.blockName[index10])
                        {
                            DllClass1.XYtoWIN(mySub.xBlock[index10], mySub.yBlock[index10], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin1, out yWin);
                            if (xWin1 != 0 || yWin != 0)
                            {
                                graphics.FillRectangle((Brush)new SolidBrush(Color.Black), xWin1, yWin, 2, 2);
                                int x = xWin1 + 2;
                                int y3 = yWin - emSize1;
                                graphics.DrawString(mySub.tmpName[index9], new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Black), (float)x, (float)y3);
                                int num27 = 0;
                                if (Math.Abs(mySub.xBase[index9]) > 0.005 && Math.Abs(mySub.xBase[index9]) > 3.0 * num25)
                                {
                                    ++num27;
                                    ++num26;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.xBase[index9]);
                                int num28 = y3 + emSize1;
                                if (num27 == 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Blue), (float)x, (float)(num28 + 1));
                                if (num27 > 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Red), (float)x, (float)(num28 + 1));
                                int num29 = 0;
                                if (Math.Abs(mySub.yBase[index9]) > 0.005 && Math.Abs(mySub.yBase[index9]) > 3.0 * num25)
                                {
                                    ++num29;
                                    ++num26;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.yBase[index9]);
                                int num30 = num28 + emSize1;
                                if (num29 == 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Blue), (float)x, (float)(num30 + 1));
                                if (num29 > 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Red), (float)x, (float)(num30 + 1));
                                int num31 = 0;
                                if (Math.Abs(mySub.zBase[index9]) > 0.005 && Math.Abs(mySub.zBase[index9]) > 3.0 * num25)
                                {
                                    ++num31;
                                    ++num26;
                                }
                                sTmp = string.Format("{0:F3}", (object)mySub.zBase[index9]);
                                int num32 = num30 + emSize1;
                                if (num31 == 0)
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Blue), (float)x, (float)(num32 + 1));
                                if (num31 > 0)
                                {
                                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize1), (Brush)new SolidBrush(Color.Red), (float)x, (float)(num32 + 1));
                                    break;
                                }
                                break;
                            }
                        }
                    }
                }
                int emSize2 = 7;
                graphics.DrawString("Средний :", new Font("Bold", (float)emSize2), (Brush)new SolidBrush(Color.Black), 270f, (float)(y1 - emSize2 / 2));
                sTmp = string.Format("{0:F3}", (object)num22);
                sTmp = "DX = " + sTmp;
                graphics.DrawString(sTmp, new Font("Bold", (float)emSize2), (Brush)new SolidBrush(Color.Black), 320f, (float)(y1 - emSize2 / 2));
                sTmp = string.Format("{0:F3}", (object)num23);
                sTmp = "DY = " + sTmp;
                graphics.DrawString(sTmp, new Font("Bold", (float)emSize2), (Brush)new SolidBrush(Color.Black), 370f, (float)(y1 - emSize2 / 2));
                sTmp = string.Format("{0:F3}", (object)num24);
                sTmp = "DZ = " + sTmp;
                graphics.DrawString(sTmp, new Font("Bold", (float)emSize2), (Brush)new SolidBrush(Color.Black), 420f, (float)(y1 - emSize2 / 2));
                if (num26 > 0)
                    graphics.DrawString("Красный цвет -- Значение погрешностей", new Font("Bold", (float)emSize2), (Brush)new SolidBrush(Color.Red), 475f, (float)(y1 - emSize2 / 2));
            }
            if (nProcess == 200 || nProcess == 210 || nProcess == 130 || nProcess == 140 || nProcess == 220 || nProcess == 230 || nProcess == 240 || nProcess == 250 || nProcess == 290)
            {
                if (kControl <= 0 && nProcess == 200)
                {
                    nProcess = 0;
                    int num = (int)MessageBox.Show("Данные отсутствуют", "Внешняя ориентация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    panel7.Invalidate();
                    return;
                }
                if (kControl <= 0 && nProcess == 210)
                {
                    nProcess = 0;
                    int num = (int)MessageBox.Show("Данные отсутствуют", "Внешняя ориентация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    panel7.Invalidate();
                    return;
                }
                int xWin2 = 0;
                yWin = 0;
                int emSize3 = 7;
                int num33 = 6;
                int num34 = 0;
                int num35 = 0;
                int num36 = 0;
                int num37 = 0;
                for (int index11 = 1; index11 <= kControl; ++index11)
                {
                    for (int index12 = 1; index12 <= kBlock; ++index12)
                    {
                        if (mySub.tmpName[index11] == mySub.blockName[index12])
                        {
                            DllClass1.XYtoWIN(mySub.xBlock[index12], mySub.yBlock[index12], scaleToWin, xBegX, yBegY, xBegWin, yBegWin, out xWin2, out yWin);
                            if (xWin2 != 0 || yWin != 0)
                            {
                                if (mySub.xBase[index11] != 0.0 && mySub.yBase[index11] != 0.0 && mySub.zBase[index11] != 0.0)
                                {
                                    ++num34;
                                    graphics.FillRectangle((Brush)new SolidBrush(Color.Red), xWin2 - num33 / 2, yWin - num33 / 2, num33, num33);
                                    int x = xWin2 + emSize3 / 2;
                                    int num38 = yWin - emSize3;
                                    int num39 = 0;
                                    if (Math.Abs(mySub.xBase[index11]) > 3.0 * dxx && Math.Abs(mySub.xBase[index11]) > 0.001)
                                    {
                                        ++num39;
                                        ++num37;
                                    }
                                    sTmp = string.Format("{0:F3}", (object)mySub.xBase[index11]);
                                    int num40 = num38 + emSize3;
                                    if (num39 == 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Red), (float)x, (float)(num40 + 1));
                                    if (num39 > 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num40 + 1));
                                    int num41 = 0;
                                    if (Math.Abs(mySub.yBase[index11]) > 3.0 * dyy && Math.Abs(mySub.yBase[index11]) > 0.001)
                                    {
                                        ++num41;
                                        ++num37;
                                    }
                                    sTmp = string.Format("{0:F3}", (object)mySub.yBase[index11]);
                                    int num42 = num40 + emSize3;
                                    if (num41 == 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Blue), (float)x, (float)(num42 + 1));
                                    if (num41 > 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num42 + 1));
                                    int num43 = 0;
                                    if (Math.Abs(mySub.zBase[index11]) > 3.0 * dzz && Math.Abs(mySub.zBase[index11]) > 0.001)
                                    {
                                        ++num43;
                                        ++num37;
                                    }
                                    sTmp = string.Format("{0:F3}", (object)mySub.zBase[index11]);
                                    int num44 = num42 + emSize3;
                                    if (num43 == 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Green), (float)x, (float)(num44 + 1));
                                    if (num43 > 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num44 + 1));
                                }
                                else if (mySub.zBase[index11] == 0.0)
                                {
                                    ++num35;
                                    graphics.FillRectangle((Brush)new SolidBrush(Color.Blue), xWin2 - num33 / 2, yWin - num33 / 2, num33, num33);
                                    int x = xWin2 + emSize3 / 2;
                                    int y4 = yWin - emSize3;
                                    graphics.DrawString(mySub.tmpName[index11], new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Blue), (float)x, (float)y4);
                                    int num45 = 0;
                                    if (Math.Abs(mySub.xBase[index11]) > 3.0 * dxx && Math.Abs(mySub.xBase[index11]) > 0.001)
                                    {
                                        ++num45;
                                        ++num37;
                                    }
                                    sTmp = string.Format("{0:F3}", (object)mySub.xBase[index11]);
                                    int num46 = y4 + emSize3;
                                    if (num45 == 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Red), (float)x, (float)(num46 + 1));
                                    if (num45 > 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num46 + 1));
                                    int num47 = 0;
                                    if (Math.Abs(mySub.yBase[index11]) > 3.0 * dyy && Math.Abs(mySub.yBase[index11]) > 0.001)
                                    {
                                        ++num47;
                                        ++num37;
                                    }
                                    sTmp = string.Format("{0:F3}", (object)mySub.yBase[index11]);
                                    int num48 = num46 + emSize3;
                                    if (num47 == 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Blue), (float)x, (float)(num48 + 1));
                                    if (num47 > 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num48 + 1));
                                }
                                else if (mySub.xBase[index11] == 0.0 && mySub.yBase[index11] == 0.0 && mySub.zBase[index11] != 0.0)
                                {
                                    ++num36;
                                    graphics.FillRectangle((Brush)new SolidBrush(Color.Green), xWin2 - num33 / 2, yWin - num33 / 2, num33, num33);
                                    int x = xWin2 + emSize3 / 2;
                                    int num49 = yWin - emSize3;
                                    int num50 = 0;
                                    if (Math.Abs(mySub.zBase[index11]) > 3.0 * dzz && Math.Abs(mySub.zBase[index11]) > 0.001)
                                    {
                                        ++num50;
                                        ++num37;
                                    }
                                    sTmp = string.Format("{0:F3}", (object)mySub.zBase[index11]);
                                    int num51 = num49 + emSize3;
                                    if (num50 == 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Green), (float)x, (float)(num51 + 1));
                                    if (num50 > 0)
                                        graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Cyan), (float)x, (float)(num51 + 1));
                                }
                            }
                        }
                    }
                }
                if (kControl > 0)
                {
                    graphics.DrawString("Средний :  ", new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Black), 270f, (float)(y1 - emSize3 / 2));
                    sTmp = string.Format("{0:F3}", (object)dxx);
                    sTmp = "DX = " + sTmp;
                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Red), 320f, (float)(y1 - emSize3 / 2));
                    sTmp = string.Format("{0:F3}", (object)dyy);
                    sTmp = "DY = " + sTmp;
                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Blue), 370f, (float)(y1 - emSize3 / 2));
                    sTmp = string.Format("{0:F3}", (object)dzz);
                    sTmp = "DZ = " + sTmp;
                    graphics.DrawString(sTmp, new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Green), 420f, (float)(y1 - emSize3 / 2));
                }
                if (num37 > 0)
                    graphics.DrawString("Голубой цвет -- Значение погрешностей", new Font("Bold", (float)emSize3), (Brush)new SolidBrush(Color.Cyan), 475f, (float)(y1 - emSize3 / 2));
            }
            if (nControl != 10)
                return;
            graphics.DrawRectangle(new Pen(Color.Green, 2f), RcDraw);
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            iGraphic = 0;
            x1Box = e.X;
            y1Box = e.Y;
            RcDraw.X = e.X;
            RcDraw.Y = e.Y;
            RcBox.X = e.X;
            RcBox.Y = e.Y;
            DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
            if (nControl == 10)
            {
                ++kDat;
                xDat[kDat] = e.X;
                yDat[kDat] = e.Y;
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
                {
                    iGraphic = 1;
                    return;
                }
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
                {
                    iGraphic = 1;
                    return;
                }
                panel7.Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                xminCur = xmin;
                yminCur = ymin;
                xmaxCur = xmax;
                ymaxCur = ymax;
                if (nProcess == 310 || nProcess == 320 || nProcess == 330)
                {
                    xminCur = xMod1;
                    yminCur = yMod1;
                    xmaxCur = xMod2;
                    ymaxCur = yMod2;
                }
                DllClass1.CoorWin(xminCur, yminCur, xmaxCur, ymaxCur, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                kDat = 0;
                if (iCond < 0)
                {
                    iGraphic = 1;
                    return;
                }
                panel7.Invalidate();
            }
            if (nProcess != 230 && nProcess != 240)
                return;
            if (e.Button == MouseButtons.Left)
            {
                ++kRcPnt;
                RcPnt[kRcPnt].X = e.X;
                RcPnt[kRcPnt].Y = e.Y;
                double num5 = 9999999.9;
                int index1 = 0;
                for (int index2 = 1; index2 <= kTar; ++index2)
                {
                    double num6 = mySub.xTar[index2] - xCur;
                    double num7 = mySub.yTar[index2] - yCur;
                    double num8 = Math.Sqrt(num6 * num6 + num7 * num7);
                    if (num5 > num8)
                    {
                        num5 = num8;
                        index1 = index2;
                    }
                }
                int num9 = 0;
                if (kGeo > 0)
                {
                    for (int index3 = 1; index3 <= kGeo; ++index3)
                    {
                        if (mySub.nameGeo[index3] == mySub.tarName[index1])
                        {
                            ++num9;
                            break;
                        }
                    }
                }
                if (num9 > 0)
                    return;
                ++kGeo;
                mySub.nameGeo[kGeo] = mySub.tarName[index1];
                mySub.xGeo[kGeo] = mySub.xTar[index1];
                mySub.yGeo[kGeo] = mySub.yTar[index1];
                mySub.zGeo[kGeo] = mySub.zTar[index1];
            }
            if (e.Button != MouseButtons.Right)
                return;
            for (int index = 1; index <= 9; ++index)
            {
                sApprox[index] = "";
                finError[index] = "";
                mySub.sumTol[index] = 0.0;
            }
            kRcPnt = 0;
            if (nProcess == 230)
            {
                if (kGeo < 4)
                {
                    if (MessageBox.Show("Контрольные точки < 4. Продолжить выбор? ?", "Выбор контрольных точек", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                        return;
                    kGeo = 0;
                    nProcess = 0;
                    LoadData();
                    panel7.Invalidate();
                    return;
                }
                if (File.Exists(mySub.fileGeo))
                    File.Delete(mySub.fileGeo);
                FileStream output1 = new FileStream(mySub.fileGeo, FileMode.CreateNew);
                BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                binaryWriter1.Write(kGeo);
                for (int index = 1; index <= kGeo; ++index)
                {
                    binaryWriter1.Write(mySub.nameGeo[index]);
                    binaryWriter1.Write(mySub.xGeo[index]);
                    binaryWriter1.Write(mySub.yGeo[index]);
                    binaryWriter1.Write(mySub.zGeo[index]);
                }
                binaryWriter1.Close();
                output1.Close();
                kCheck = 0;
                for (int index4 = 1; index4 <= kTar; ++index4)
                {
                    int num = 0;
                    for (int index5 = 1; index5 <= kGeo; ++index5)
                    {
                        if (mySub.tarName[index4] == mySub.nameGeo[index5])
                        {
                            ++num;
                            break;
                        }
                    }
                    if (num <= 0)
                    {
                        ++kCheck;
                        mySub.nameCheck[kCheck] = mySub.tarName[index4];
                        mySub.xCheck[kCheck] = mySub.xTar[index4];
                        mySub.yCheck[kCheck] = mySub.yTar[index4];
                        mySub.zCheck[kCheck] = mySub.zTar[index4];
                    }
                }
                if (kCheck == 0)
                    return;
                if (File.Exists(mySub.curControl))
                    File.Delete(mySub.curControl);
                FileStream output2 = new FileStream(mySub.curControl, FileMode.CreateNew);
                BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                binaryWriter2.Write(kCheck);
                for (int index = 1; index <= kCheck; ++index)
                {
                    binaryWriter2.Write(mySub.nameCheck[index]);
                    binaryWriter2.Write(mySub.xCheck[index]);
                    binaryWriter2.Write(mySub.yCheck[index]);
                    binaryWriter2.Write(mySub.zCheck[index]);
                }
                binaryWriter2.Close();
                output2.Close();
            }
            if (nProcess == 240)
            {
                kCheck = 0;
                if (kGeo > 0)
                {
                    if (File.Exists(mySub.curControl))
                        File.Delete(mySub.curControl);
                    FileStream output = new FileStream(mySub.curControl, FileMode.CreateNew);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    binaryWriter.Write(kGeo);
                    for (int index = 1; index <= kGeo; ++index)
                    {
                        binaryWriter.Write(mySub.nameGeo[index]);
                        binaryWriter.Write(mySub.xGeo[index]);
                        binaryWriter.Write(mySub.yGeo[index]);
                        binaryWriter.Write(mySub.zGeo[index]);
                    }
                    binaryWriter.Close();
                    output.Close();
                    for (int index6 = 1; index6 <= kTar; ++index6)
                    {
                        int num = 0;
                        for (int index7 = 1; index7 <= kGeo; ++index7)
                        {
                            if (mySub.tarName[index6] == mySub.nameGeo[index7])
                            {
                                ++num;
                                break;
                            }
                        }
                        if (num <= 0)
                        {
                            ++kCheck;
                            mySub.nameCheck[kCheck] = mySub.tarName[index6];
                            mySub.xCheck[kCheck] = mySub.xTar[index6];
                            mySub.yCheck[kCheck] = mySub.yTar[index6];
                            mySub.zCheck[kCheck] = mySub.zTar[index6];
                        }
                    }
                }
                kGeo = kCheck;
                for (int index = 1; index <= kGeo; ++index)
                {
                    mySub.nameGeo[index] = mySub.nameCheck[index];
                    mySub.xGeo[index] = mySub.xCheck[index];
                    mySub.yGeo[index] = mySub.yCheck[index];
                    mySub.zGeo[index] = mySub.zCheck[index];
                }
                if (File.Exists(mySub.fileGeo))
                    File.Delete(mySub.fileGeo);
                FileStream output3 = new FileStream(mySub.fileGeo, FileMode.CreateNew);
                BinaryWriter binaryWriter3 = new BinaryWriter((Stream)output3);
                binaryWriter3.Write(kGeo);
                for (int index = 1; index <= kGeo; ++index)
                {
                    binaryWriter3.Write(mySub.nameGeo[index]);
                    binaryWriter3.Write(mySub.xGeo[index]);
                    binaryWriter3.Write(mySub.yGeo[index]);
                    binaryWriter3.Write(mySub.zGeo[index]);
                }
                binaryWriter3.Close();
                output3.Close();
            }
            if (File.Exists(mySub.difControl))
                File.Delete(mySub.difControl);
            mySub.FilePath();
            ThirdGeo(out iCond);
            if (iCond != 0)
            {
                iGraphic = 1;
            }
            else
            {
                ThirdGeo(out iCond);
                if (iCond != 0)
                {
                    iGraphic = 1;
                }
                else
                {
                    LoadData();
                    mySub.DifControl();
                    mySub.LoadControl(1, out kControl, mySub.tmpName, mySub.xBase, mySub.yBase, mySub.zBase, out dxx, out dyy, out dzz);
                    panel7.Invalidate();
                    sTmp = "";
                    sTmp += "\nАбсолютная ориентация:";
                    for (int index = 1; index <= 2; ++index)
                    {
                        if (!(finError[index] == ""))
                            sTmp = sTmp + "\n" + finError[index];
                    }
                    sTmp += "\nРегулировка комплекта(группы):";
                    if (sApprox[1] != "")
                    {
                        sTmp = sTmp + "\n" + sApprox[1];
                        sTmp = sTmp + "\n" + finError[3];
                    }
                    if (sApprox[2] != "")
                    {
                        sTmp = sTmp + "\n" + sApprox[2];
                        sTmp = sTmp + "\n" + finError[4];
                    }
                    if (sApprox[3] != "")
                    {
                        sTmp = sTmp + "\n" + sApprox[3];
                        sTmp = sTmp + "\n" + finError[5];
                    }
                    int num = (int)MessageBox.Show(sTmp);
                }
            }
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            iGraphic = 0;
            DllClass1.WINtoXY(e.X, e.Y, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur, out yCur);
            if (!File.Exists(mySub.aeroBlock))
            {
                panel2.Text = string.Format("{0}", (object)e.X);
                panel4.Text = string.Format("{0}", (object)e.Y);
            }
            if (File.Exists(mySub.aeroBlock))
            {
                panel2.Text = string.Format("{0:F3}", (object)xCur);
                panel4.Text = string.Format("{0:F3}", (object)yCur);
            }
            if (nControl == 10 && e.Button == MouseButtons.Left)
            {
                if (e.X < RcBox.X)
                {
                    RcDraw.Width = RcBox.X - e.X;
                    RcDraw.X = e.X;
                }
                else
                    RcDraw.Width = e.X - RcBox.X;
                if (e.Y < RcBox.Y)
                {
                    RcDraw.Height = RcBox.Y - e.Y;
                    RcDraw.Y = e.Y;
                }
                else
                    RcDraw.Height = e.Y - RcBox.Y;
                RcBox1.X = RcDraw.X - 100;
                RcBox1.Y = RcDraw.Y - 100;
                RcBox1.Width = 100;
                RcBox1.Height = RcDraw.Height + 200;
                RcBox2.X = RcDraw.X - 100;
                RcBox2.Y = RcDraw.Y - 100;
                RcBox2.Width = RcDraw.Width + 200;
                RcBox2.Height = 100;
                RcBox3.X = RcDraw.X - 100;
                RcBox3.Y = RcDraw.Y + RcDraw.Height;
                RcBox3.Width = RcDraw.Width + 100;
                RcBox3.Height = 100;
                RcBox4.X = RcDraw.X + RcDraw.Width;
                RcBox4.Y = RcDraw.Y - 100;
                RcBox4.Width = 100;
                RcBox4.Height = RcDraw.Height + 200;
                panel7.Invalidate(RcDraw);
                panel7.Invalidate(RcBox1);
                panel7.Invalidate(RcBox2);
                panel7.Invalidate(RcBox3);
                panel7.Invalidate(RcBox4);
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
            else
                panel7.Invalidate();
        }

        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
            double xCur1 = 0.0;
            double yCur1 = 0.0;
            double xCur2 = 0.0;
            double yCur2 = 0.0;
            if (nControl == 10 && kDat > 0)
            {
                x1Box = RcDraw.X;
                y1Box = RcDraw.Y;
                x2Box = RcDraw.X + RcDraw.Width;
                y2Box = RcDraw.Y + RcDraw.Height;
                if (x1Box == x2Box || y1Box == y2Box)
                    return;
                DllClass1.WINtoXY(x1Box, y1Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur1, out yCur1);
                DllClass1.WINtoXY(x2Box, y2Box, scaleToGeo, xBegX, yBegY, xBegWin, yBegWin, out xCur2, out yCur2);
                if (xCur1 > xCur2)
                {
                    double num = xCur1;
                    xCur1 = xCur2;
                    xCur2 = num;
                }
                if (yCur1 > yCur2)
                {
                    double num = yCur1;
                    yCur1 = yCur2;
                    yCur2 = num;
                }
                xminCur = xCur1;
                yminCur = yCur1;
                xmaxCur = xCur2;
                ymaxCur = yCur2;
                DllClass1.CoorWin(xCur1, yCur1, xCur2, yCur2, iWidth, iHeight, out scaleToWin, out scaleToGeo, out xBegX, out yBegY, out xEndX, out yEndY, out xBegWin, out yBegWin, out xEndWin, out yEndWin, out iCond);
                if (iCond < 0)
                {
                    iGraphic = 1;
                    return;
                }
                RcDraw.X = 0;
                RcDraw.Y = 0;
                RcDraw.Height = 0;
                RcDraw.Width = 0;
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
            if (nProcess != 230 && nProcess != 240)
                return;
            RcPnt[kRcPnt].Width = 8;
            RcPnt[kRcPnt].Height = 8;
            panel7.Invalidate(RcPnt[kRcPnt]);
            panel7.Invalidate();
        }

        private void Exit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        private void FillCamera_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            mySub.FilePath();
            CameraStore cameraStore = new CameraStore();
            mySub.FilePath();
            int num = (int)cameraStore.ShowDialog((IWin32Window)this);
            mySub.FilePath();
            LoadData();
            nProblem = 22;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            panel7.Invalidate();
        }

        private void CameraDelete_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            mySub.FilePath();
            if (!File.Exists(mySub.tmpStr))
            {
                int num1 = (int)MessageBox.Show("Диск не определен", "Пополнить Архив камер(снимков)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FileStream input = new FileStream(mySub.tmpStr, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                mySub.comPath = binaryReader.ReadString();
                binaryReader.Close();
                input.Close();
                if (File.Exists(mySub.fileAdd))
                    File.Delete(mySub.fileAdd);
                if (!File.Exists(mySub.fstoreCam))
                {
                    int num2 = (int)MessageBox.Show("Аеро-фото камеры' Архив не создан или удален", "Удаление 'Архива' аэрофотокамер(Снимков)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (File.Exists(mySub.fstoreCam) && MessageBox.Show("Вы действитедьно хотите удалить архив Аерофотокамер(Аерофотоснимков)?", "Удаление архива Аерофотокамер(Аерофотоснимков)", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    File.Delete(mySub.fstoreCam);
                nProblem = 22;
                if (File.Exists(mySub.fProblem))
                    File.Delete(mySub.fProblem);
                FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(nProblem);
                binaryWriter.Close();
                output.Close();
            }
        }

        private void FillControl_Click(object sender, EventArgs e)
        {
            this.mySub.FilePath();
            this.mySub.ControlInput(out this.iCond, this.mySub.fstoreGeo);
            if (this.iCond < 0)
                this.iGraphic = 1;
            else if (this.iCond < 0)
            {
                int num = (int)MessageBox.Show("Слишком много ошибок", "Пополнить архив контрольных точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.iGraphic = 1;
            }
            else
            {
                ControlPoints controlPoints = new ControlPoints();
                controlPoints.Location = new Point(0, 0);
                int num = (int)controlPoints.ShowDialog((IWin32Window)this);
                this.mySub.FilePath();
                this.LoadData();
                this.nProblem = 23;
                if (File.Exists(this.mySub.fProblem))
                    File.Delete(this.mySub.fProblem);
                FileStream output = new FileStream(this.mySub.fProblem, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(this.nProblem);
                binaryWriter.Close();
                output.Close();
                this.panel7.Invalidate();
            }
        }

        private void ControlInfo_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            mySub.FilePath();
            if (!File.Exists(mySub.fstoreGeo))
            {
                int num1 = (int)MessageBox.Show("Контрольнеы точки' Архив не создан или удален", "Заполнить архив контрольных точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ControlPoints controlPoints = new ControlPoints();
                controlPoints.Location = new Point(0, 0);
                int num2 = (int)controlPoints.ShowDialog((IWin32Window)this);
                mySub.FilePath();
                LoadData();
                nProblem = 23;
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

        private void ControlDelete_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            mySub.FilePath();
            if (!File.Exists(mySub.fstoreGeo))
            {
                int num = (int)MessageBox.Show(" Архив контрольных точек не создан или удален", "Заполнить архив контрольных точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(mySub.fstoreGeo) && MessageBox.Show("Вы действитедьно хотите удалить архив Аерофотокамер(Аерофотоснимков)?", "Удалить of Control Points Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    File.Delete(mySub.fstoreGeo);
                LoadData();
                nProblem = 23;
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

        private void ControlCurrent_Click(object sender, EventArgs e)
        {
            for (int index = 1; index <= 9; ++index)
            {
                sApprox[index] = "";
                finError[index] = "";
                mySub.sumTol[index] = 0.0;
            }
            iGraphic = 0;
            mySub.FilePath();
            nProcess = 130;
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран","Стереоскопический ввод файлов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(mySub.fstoreCam))
            {
                int num2 = (int)MessageBox.Show("Аеро-фото камеры' Архив не создан","Стереоскопический ввод файлов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mySub.ControlInput(out iCond, mySub.currentGeo);
                if (iCond < 0)
                {
                    int num3 = (int)MessageBox.Show("Слишком много ошибок", "Файл контрольных точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    iGraphic = 1;
                }
                else
                {
                    mySub.FilePath();
                    if (!File.Exists(mySub.aeroStrip))
                    {
                        int num4 = (int)MessageBox.Show("Для продолжения процесса нажмите 'Ввод данных из файла' или 'Ввод измерений MonoScopic'", "Файл контрольных точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LoadData();
                        panel7.Invalidate();
                    }
                    else
                    {
                        if (File.Exists(mySub.aeroStrip))
                        {
                            FileStream input = new FileStream(mySub.aeroStrip, FileMode.Open, FileAccess.Read);
                            BinaryReader binaryReader = new BinaryReader((Stream)input);
                            try
                            {
                                kStrip = binaryReader.ReadInt32();
                                for (int index = 1; index <= kStrip; ++index)
                                {
                                    kMod = binaryReader.ReadInt32();
                                    if (binaryReader.ReadInt64() == 0L)
                                    {
                                        int num5 = (int)MessageBox.Show("Номер камеры(снимка) не определен", "Направление камеры", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
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
                        mySub.GeoSelect(out iCond);
                        if (iCond < 0)
                        {
                            iGraphic = 1;
                        }
                        else
                        {
                            FirstGeo(out iCond, out kMod);
                            if (iCond < 0)
                            {
                                iGraphic = 1;
                            }
                            else
                            {
                                if (kMod == 1)
                                {
                                    ModelGeo(out iCond);
                                    if (iCond != 0)
                                    {
                                        iGraphic = 1;
                                        return;
                                    }
                                }
                                if (kMod > 1)
                                {
                                    SecondGeo(out iCond);
                                    if (iCond != 0)
                                    {
                                        iGraphic = 1;
                                        return;
                                    }
                                    ThirdGeo(out iCond);
                                    if (iCond != 0)
                                    {
                                        iGraphic = 1;
                                        return;
                                    }
                                }
                                mySub.FilePath();
                                LoadData();
                                mySub.LoadControl(1, out kControl, mySub.tmpName, mySub.xBase, mySub.yBase, mySub.zBase, out dxx, out dyy, out dzz);
                                panel7.Invalidate();
                                sTmp = "";
                                sTmp += "\nАбсолютная ориентация:";
                                for (int index = 1; index <= 2; ++index)
                                {
                                    if (!(finError[index] == ""))
                                        sTmp = sTmp + "\n" + finError[index];
                                }
                                sTmp += "\nРегулировка комплекта(группы):";
                                if (sApprox[1] != "")
                                {
                                    sTmp = sTmp + "\n" + sApprox[1];
                                    sTmp = sTmp + "\n" + finError[3];
                                }
                                if (sApprox[2] != "")
                                {
                                    sTmp = sTmp + "\n" + sApprox[2];
                                    sTmp = sTmp + "\n" + finError[4];
                                }
                                if (sApprox[3] != "")
                                {
                                    sTmp = sTmp + "\n" + sApprox[3];
                                    sTmp = sTmp + "\n" + finError[5];
                                }
                                int num6 = (int)MessageBox.Show(sTmp);
                            }
                        }
                    }
                }
            }
        }

        private void StereoInput_Click(object sender, EventArgs e)
        {
            for (int index = 1; index <= 9; ++index)
            {
                sApprox[index] = "";
                finError[index] = "";
                mySub.sumTol[index] = 0.0;
            }
            iShowInter = 0;
            mySub.FilePath();
            nProcess = 140;
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран","Стереоскопический ввод файлов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(mySub.fstoreCam))
            {
                int num2 = (int)MessageBox.Show("Аеро-фото камеры' Архив не создан", "Ввод стереоскопических данных из файла", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (radioButton1.Checked)
                {
                    if (MessageBox.Show("Ваш выбор: X_LEFT, Y_LEFT, X_RIGHT, Y_RIGHT ?", "Ввод стереоскопических данных из файла", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        return;
                    iKindMeasure = 1;
                }
                if (radioButton2.Checked)
                {
                    if (MessageBox.Show("Ваш выбор: X_LEFT, Y_LEFT, X_PARALLAX, Y_PARALLAX ?", "Ввод стереоскопических данных из файла", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        return;
                    iKindMeasure = 2;
                }
                if (radioButton3.Checked)
                {
                    if (MessageBox.Show("Ваш выбор: X_LEFT, Y_RIGHT, X_PARALLAX, Y_PARALLAX ?", "Ввод стереоскопических данных из файла", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        return;
                    iKindMeasure = 3;
                }
                nProcess = 140;
                if (File.Exists(mySub.fileProcess))
                    File.Delete(mySub.fileProcess);
                FileStream output1 = new FileStream(mySub.fileProcess, FileMode.CreateNew);
                BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                binaryWriter1.Write(nProcess);
                binaryWriter1.Close();
                output1.Close();
                mySub.StereoInput(out iCond, iKindMeasure, mySub.fileAero, mySub.aeroStrip);
                if (iCond < 0)
                {
                    iGraphic = 1;
                }
                else
                {
                    mySub.GeoSelect(out iCond);
                    if (iCond < 0)
                    {
                        iGraphic = 1;
                    }
                    else
                    {
                        int num3 = (int)new StripCamera().ShowDialog((IWin32Window)this);
                        if (File.Exists(mySub.aeroStrip))
                        {
                            FileStream input = new FileStream(mySub.aeroStrip, FileMode.Open, FileAccess.Read);
                            BinaryReader binaryReader = new BinaryReader((Stream)input);
                            try
                            {
                                kStrip = binaryReader.ReadInt32();
                                for (int index = 1; index <= kStrip; ++index)
                                {
                                    kMod = binaryReader.ReadInt32();
                                    if (binaryReader.ReadInt64() == 0L)
                                    {
                                        int num4 = (int)MessageBox.Show("Номер камеры(снимка) не определен", "Направление камеры", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
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
                        FirstGeo(out iCond, out kMod);
                        if (iCond < 0)
                        {
                            iGraphic = 1;
                        }
                        else
                        {
                            if (kMod == 1)
                            {
                                ModelGeo(out iCond);
                                if (iCond != 0)
                                {
                                    iGraphic = 1;
                                    return;
                                }
                            }
                            if (kMod > 1)
                            {
                                SecondGeo(out iCond);
                                if (iCond != 0)
                                {
                                    iGraphic = 1;
                                    return;
                                }
                                ThirdGeo(out iCond);
                                if (iCond != 0)
                                {
                                    iGraphic = 1;
                                    return;
                                }
                            }
                            mySub.FilePath();
                            panel1.Text = "Пожалуйста, подождите. Загрузка результатов";
                            LoadData();
                            mySub.LoadControl(1, out kControl, mySub.tmpName, mySub.xBase, mySub.yBase, mySub.zBase, out dxx, out dyy, out dzz);
                            panel1.Text = "Готов...";
                            panel7.Invalidate();
                            sTmp = "";
                            sTmp += "\nАбсолютная ориентация:";
                            for (int index = 1; index <= 2; ++index)
                            {
                                if (!(finError[index] == ""))
                                    sTmp = sTmp + "\n" + finError[index];
                            }
                            sTmp += "\nРегулировка комплекта(группы):";
                            if (sApprox[1] != "")
                            {
                                sTmp = sTmp + "\n" + sApprox[1];
                                sTmp = sTmp + "\n" + finError[3];
                            }
                            if (sApprox[2] != "")
                            {
                                sTmp = sTmp + "\n" + sApprox[2];
                                sTmp = sTmp + "\n" + finError[4];
                            }
                            if (sApprox[3] != "")
                            {
                                sTmp = sTmp + "\n" + sApprox[3];
                                sTmp = sTmp + "\n" + finError[5];
                            }
                            int num5 = (int)MessageBox.Show(sTmp);
                            nProblem = 25;
                            if (File.Exists(mySub.fProblem))
                                File.Delete(mySub.fProblem);
                            FileStream output2 = new FileStream(mySub.fProblem, FileMode.CreateNew);
                            BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                            binaryWriter2.Write(nProblem);
                            binaryWriter2.Close();
                            output2.Close();
                        }
                    }
                }
            }
        }

        private void InteriorOrient_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            nProcess = 160;
            LoadData();
            mySub.InteriorOrient(out kInter, mySub.tmpName, mySub.xDif, mySub.yDif);
            nProblem = 26;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            panel7.Invalidate();
        }

        private void RelativeOrient_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            nProcess = 170;
            LoadData();
            mySub.RelativeOrient(out kPhoto, mySub.numPhoto, mySub.xsPhoto, mySub.ysPhoto, out kRelate, mySub.modLeft, mySub.modRight, mySub.xBase, mySub.yBase);
            nProblem = 26;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            panel7.Invalidate();
        }

        private void ModelsJoin_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            nProcess = 180;
            LoadData();
            mySub.ModelStripJoin(1, out kDiffer, mySub.tmpName, mySub.xBase, mySub.yBase, mySub.zBase);
            nProblem = 26;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            panel7.Invalidate();
        }

        private void StripsJoin_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            nProcess = 190;
            LoadData();
            mySub.ModelStripJoin(2, out kDiffer, mySub.tmpName, mySub.xBase, mySub.yBase, mySub.zBase);
            nProblem = 26;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            panel7.Invalidate();
        }

        private void ControlPoints_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            nProcess = 200;
            LoadData();
            mySub.LoadControl(1, out kControl, mySub.tmpName, mySub.xBase, mySub.yBase, mySub.zBase, out dxx, out dyy, out dzz);
            nProblem = 26;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            panel7.Invalidate();
        }

        private void CheckPoints_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            nProcess = 210;
            LoadData();
            mySub.LoadControl(2, out kControl, mySub.tmpName, mySub.xBase, mySub.yBase, mySub.zBase, out dxx, out dyy, out dzz);
            nProblem = 26;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            panel7.Invalidate();
        }

        private void Original_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            nProcess = 220;
            LoadData();
            nProblem = 26;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            panel7.Invalidate();
        }

        private void AllPoints_Click(object sender, EventArgs e)
        {
            nProcess = 290;
            iGraphic = 0;
            LoadData();
            nProblem = 26;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            panel7.Invalidate();
        }

        private void ControlSelect_Click(object sender, EventArgs e)
        {
            mySub.FilePath();
            iGraphic = 0;
            nProcess = 230;
            kRcPnt = 0;
            nControl = 0;
            kDat = 0;
            kGeo = 0;
            kCheck = 0;
            LoadData();
            nProblem = 26;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            panel7.Invalidate();
        }

        private void CheckSelect_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            mySub.FilePath();
            nProcess = 240;
            kRcPnt = 0;
            nControl = 0;
            kDat = 0;
            kGeo = 0;
            kCheck = 0;
            LoadData();
            nProblem = 26;
            if (File.Exists(mySub.fProblem))
                File.Delete(mySub.fProblem);
            FileStream output = new FileStream(mySub.fProblem, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(nProblem);
            binaryWriter.Close();
            output.Close();
            panel7.Invalidate();
        }

        private void AllAsControl_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mySub.fallGeo))
            {
                int num1 = (int)MessageBox.Show("Нет данных", "Контрольные точки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                for (int index = 1; index <= 9; ++index)
                {
                    sApprox[index] = "";
                    finError[index] = "";
                    mySub.sumTol[index] = 0.0;
                }
                iGraphic = 0;
                mySub.FilePath();
                nProcess = 250;
                kGeo = 0;
                if (File.Exists(mySub.fallGeo))
                {
                    FileStream input = new FileStream(mySub.fallGeo, FileMode.Open, FileAccess.Read);
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
                if (File.Exists(mySub.fileGeo))
                    File.Delete(mySub.fileGeo);
                FileStream output1 = new FileStream(mySub.fileGeo, FileMode.CreateNew);
                BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                binaryWriter1.Write(kGeo);
                for (int index = 1; index <= kGeo; ++index)
                {
                    binaryWriter1.Write(mySub.nameGeo[index]);
                    binaryWriter1.Write(mySub.xGeo[index]);
                    binaryWriter1.Write(mySub.yGeo[index]);
                    binaryWriter1.Write(mySub.zGeo[index]);
                }
                binaryWriter1.Close();
                output1.Close();
                if (File.Exists(mySub.curControl))
                    File.Delete(mySub.curControl);
                if (File.Exists(mySub.difControl))
                    File.Delete(mySub.difControl);
                if (File.Exists(mySub.aeroStrip))
                {
                    FileStream input = new FileStream(mySub.aeroStrip, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        kStrip = binaryReader.ReadInt32();
                        for (int index = 1; index <= kStrip; ++index)
                        {
                            kMod = binaryReader.ReadInt32();
                            if (binaryReader.ReadInt64() == 0L)
                            {
                                int num2 = (int)MessageBox.Show("Номер камеры(снимка) не определен", "Направление камеры", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
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
                mySub.FilePath();
                FirstGeo(out iCond, out kMod);
                if (iCond < 0)
                {
                    iGraphic = 1;
                }
                else
                {
                    if (kMod == 1)
                    {
                        ModelGeo(out iCond);
                        if (iCond != 0)
                        {
                            iGraphic = 1;
                            return;
                        }
                    }
                    if (kMod > 1)
                    {
                        SecondGeo(out iCond);
                        if (iCond != 0)
                        {
                            iGraphic = 1;
                            return;
                        }
                        ThirdGeo(out iCond);
                        if (iCond != 0)
                        {
                            iGraphic = 1;
                            return;
                        }
                    }
                    mySub.FilePath();
                    LoadData();
                    mySub.LoadControl(1, out kControl, mySub.tmpName, mySub.xBase, mySub.yBase, mySub.zBase, out dxx, out dyy, out dzz);
                    panel7.Invalidate();
                    sTmp = "";
                    sTmp += "\nАбсолютная ориентация:";
                    for (int index = 1; index <= 2; ++index)
                    {
                        if (!(finError[index] == ""))
                            sTmp = sTmp + "\n" + finError[index];
                    }
                    sTmp += "\nРегулировка комплекта(группы):";
                    if (sApprox[1] != "")
                    {
                        sTmp = sTmp + "\n" + sApprox[1];
                        sTmp = sTmp + "\n" + finError[3];
                    }
                    if (sApprox[2] != "")
                    {
                        sTmp = sTmp + "\n" + sApprox[2];
                        sTmp = sTmp + "\n" + finError[4];
                    }
                    if (sApprox[3] != "")
                    {
                        sTmp = sTmp + "\n" + sApprox[3];
                        sTmp = sTmp + "\n" + finError[5];
                    }
                    int num3 = (int)MessageBox.Show(sTmp);
                    nProblem = 26;
                    if (File.Exists(mySub.fProblem))
                        File.Delete(mySub.fProblem);
                    FileStream output2 = new FileStream(mySub.fProblem, FileMode.CreateNew);
                    BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                    binaryWriter2.Write(nProblem);
                    binaryWriter2.Close();
                    output2.Close();
                }
            }
        }

        private void PointsList_Click(object sender, EventArgs e)
        {
            mySub.FilePath();
            if (!File.Exists(mySub.aeroBlock))
            {
                int num = (int)MessageBox.Show("Нет данных", "Список точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ListPoints listPoints = new ListPoints();
                listPoints.Location = new Point(0, 0);
                listPoints.Show((IWin32Window)this);
                mySub.FilePath();
            }
        }

        private void StereoDtm_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            mySub.FilePath();
            nProcess = 300;
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран","Стереоскопический ввод файлов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(mySub.fstoreCam))
            {
                int num2 = (int)MessageBox.Show("Аеро-фото камеры' Архив не создан","Стереоскопический ввод файлов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (radioButton1.Checked)
                {
                    if (MessageBox.Show("Ваш выбор: X_LEFT, Y_LEFT, X_RIGHT, Y_RIGHT ?", "Ввод стереоскопических данных из файла", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        return;
                    iKindMeasure = 1;
                }
                if (radioButton2.Checked)
                {
                    if (MessageBox.Show("Ваш выбор: X_LEFT, Y_LEFT, X_PARALLAX, Y_PARALLAX ?", "Ввод стереоскопических данных из файла", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        return;
                    iKindMeasure = 2;
                }
                if (radioButton3.Checked)
                {
                    if (MessageBox.Show("Ваш выбор: X_LEFT, Y_RIGHT, X_PARALLAX, Y_PARALLAX ?", "Ввод стереоскопических данных из файла", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        return;
                    iKindMeasure = 3;
                }
                mySub.StereoInput(out iCond, iKindMeasure, mySub.stereoModel, mySub.modelStrip);
                if (iCond < 0)
                {
                    iGraphic = 1;
                }
                else
                {
                    nProcess = 300;
                    if (File.Exists(mySub.fileProcess))
                        File.Delete(mySub.fileProcess);
                    FileStream output1 = new FileStream(mySub.fileProcess, FileMode.CreateNew);
                    BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                    binaryWriter1.Write(nProcess);
                    binaryWriter1.Close();
                    output1.Close();
                    StripCamera stripCamera = new StripCamera();
                    stripCamera.Location = new Point(0, 0);
                    int num3 = (int)stripCamera.ShowDialog((IWin32Window)this);
                    mySub.FilePath();
                    if (File.Exists(mySub.aeroStrip))
                    {
                        FileStream input = new FileStream(mySub.aeroStrip, FileMode.Open, FileAccess.Read);
                        BinaryReader binaryReader = new BinaryReader((Stream)input);
                        try
                        {
                            kStrip = binaryReader.ReadInt32();
                            for (int index = 1; index <= kStrip; ++index)
                            {
                                kMod = binaryReader.ReadInt32();
                                if (binaryReader.ReadInt64() == 0L)
                                {
                                    int num4 = (int)MessageBox.Show("Номер камеры(снимка) не определен", "Направление камеры", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
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
                    mySub.StereoDeform(out iCond, mySub.stereoModel);
                    if (iCond < 0)
                    {
                        iGraphic = 1;
                    }
                    else
                    {
                        mySub.OneStereo(out iCond, mySub.modelStrip, mySub.stereoModel, mySub.modelPhoto, mySub.modRelative, mySub.fotoModel);
                        if (iCond < 0)
                        {
                            iGraphic = 1;
                        }
                        else
                        {
                            mySub.ModelOrient(out iCond);
                            if (iCond < 0)
                            {
                                iGraphic = 1;
                            }
                            else
                            {
                                mySub.InsertModel(out iCond);
                                if (iCond != 0)
                                {
                                    iGraphic = 1;
                                    nProcess = 0;
                                    LoadData();
                                    panel7.Invalidate();
                                }
                                else
                                {
                                    LoadModel(out iCond);
                                    if (iCond != 0)
                                    {
                                        iGraphic = 1;
                                        nProcess = 0;
                                        LoadData();
                                        panel7.Invalidate();
                                    }
                                    else
                                    {
                                        panel7.Invalidate();
                                        if (MessageBox.Show("Хотите добавить модель в архив ЦММ?", "Вставка стереомодели", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                        {
                                            if (!File.Exists(mySub.fileModel))
                                                return;
                                            File.Delete(mySub.fileModel);
                                        }
                                        else
                                        {
                                            mySub.MergeDtm();
                                            nProblem = 24;
                                            if (File.Exists(mySub.fProblem))
                                                File.Delete(mySub.fProblem);
                                            FileStream output2 = new FileStream(mySub.fProblem, FileMode.CreateNew);
                                            BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                                            binaryWriter2.Write(nProblem);
                                            binaryWriter2.Close();
                                            output2.Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ModelShow_Click(object sender, EventArgs e)
        {
            mySub.FilePath();
            nProcess = 310;
            LoadModel(out iCond);
            if (iCond != 0)
            {
                iGraphic = 1;
                nProcess = 0;
                LoadData();
                panel7.Invalidate();
            }
            else
            {
                nProblem = 24;
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

        private void AddCurrModel_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            mySub.FilePath();
            nProcess = 330;
            if (!File.Exists(mySub.fileProj))
            {
                int num1 = (int)MessageBox.Show("Проект не выбран","Стереоскопический ввод файлов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!File.Exists(mySub.fileModel))
            {
                int num2 = (int)MessageBox.Show("Данные отсутствуют", "Архив ЦММ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Хотите добавить модель в архив ЦММ?", "Вставка стереомодели", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
                mySub.MergeDtm();
                LoadStore(out iCond);
                if (iCond != 0)
                {
                    iGraphic = 1;
                    nProcess = 0;
                    LoadData();
                    panel7.Invalidate();
                }
                else
                {
                    nProblem = 24;
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

        private void ArchiveDtmShow_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            mySub.FilePath();
            nProcess = 320;
            LoadStore(out iCond);
            if (iCond != 0)
            {
                iGraphic = 1;
                nProcess = 0;
                LoadData();
                panel7.Invalidate();
            }
            else
            {
                nProblem = 24;
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

        private void ArchiveDtmDelete_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            mySub.FilePath();
            if (!File.Exists(mySub.fbaseDtm))
            {
                int num = (int)MessageBox.Show("Данные отсутствуют", "Архив ЦММ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!File.Exists(mySub.fbaseDtm) || MessageBox.Show("Вы хотите удалить архив ЦММ?", "Архив ЦММ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;
                File.Delete(mySub.fbaseDtm);
                nProcess = 0;
                LoadData();
                panel7.Invalidate();
            }
        }

        private void SelectBox_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            nControl = 10;
            kDat = 0;
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            nControl = 20;
            kDat = 0;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            nControl = 30;
            kDat = 0;
        }

        private void Move_Click(object sender, EventArgs e)
        {
            iGraphic = 0;
            nControl = 40;
            kDat = 0;
        }
    }
}



