using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DiplomGeoDLL;
using IIT_Diplom_Geo1;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace IIT_Diplom_Geo1
{
    //public class Form : System.Windows.Forms.ContainerControl
    //{

    //}
    public class MyGeodesy
    {
        public readonly string dirKey = "Diplom_Geo";
        public string projectKey = "Diplom_Projs";
        public string pathKey = "";
        public string comPath = "";

        public string curProject = "";
        public string curDirectory = "";

        public string fileProj = "";
        public string fileAllProj = "";

        public string driveKey;
        public string[] nameDrive;
        public int kDisk;
        public string filePoint = ""; // Получение переменной для filePoint (путь к файлу) 
        
        public string fileProcess = "";
        public string fileAdd = "Temp"; // Директория для удаления

        // Переменные для метода отрисовки panel1_Paint в class GeoDemo : Form

        private int kPartMaX = 20; // максимальное возможное кол-во слов в водимой строке
        char[] seps = { ' ', ',', '\t' }; // массив символов - пробел, запятая, табуляция
    
        // Граница вводимых данных в виде минимальных и максимальных значений координат точек
        public double xmin, ymin, xmax, ymax, zmin, zmax;

        // Кол-во введенных точек
        public int kPoints = 0;
        // Массив имен, координат и высот точек
        public string[] namePnt = new string[1000];
        public double[] xPntGeo = new double[1000];
        public double[] yPntGeo = new double[1000];
        public double[] zPntGeo = new double[1000];

        // Получение значений переменных для отрисовки в графической области области 
        //public double xmin { get; internal set; }
        //public double ymin { get; internal set; }
        //public double zmin { get; private set; }
        //public double xmax { get; internal set; }
        //public double ymax { get; internal set; }
        //public double zmax { get; private set; }

        // Переменные для  PointsLoad
        public double[] xPnt;
        public double[] yPnt;
        public double[] zPnt;

        internal void FilePath()
        {
            string sTmp = "";
            //Проверка выбора диска на случай непредвиденного удаления директории, определяющей выбор диска
            DllClass1.CheckDrive(dirKey, out driveKey);
            sTmp = driveKey + dirKey + "\\brdrive.dat";
            Console.WriteLine($"[DEBUG] MyGeodesy.FilePath: '{sTmp}'");
            if (!File.Exists(sTmp))
            {
                DialogResult result;
                result = MessageBox.Show("Проблемы с выбранным Диском",
                    "Projects",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            //Открытие и чтение файла brdrive.dat
            FileStream fa = new FileStream(sTmp, FileMode.Open, FileAccess.Read);
            BinaryReader faa = new BinaryReader(fa);
            try
            {
                comPath = faa.ReadString();
            }
            catch (Exception)

            {
                Console.WriteLine("Ошибка операции чтения");
            }
            finally
            {
                fa.Close();
                faa.Close();
            }

            // Формирование пути для файлов brProj.dat b brAllProj.dat в зависимости от выбранного диска
            fileProj = comPath + "\\brProj.dat";
            fileAllProj = comPath + "\\brAllProj.dat";

            fileProcess = comPath + "\\brProc.dat";
            // Формирование пути для файла fpoint.pnt (p.54)
            DllClass1.CheckOpenProj(fileProj, out curProject, out curDirectory);
            filePoint = curDirectory + "\\fpoint.pnt";
        }

        //internal void CheckOpenProj()
        //{
        //    string sTmp = "";

        //    if (File.Exists(fileProj))
        //    {
        //        FileStream fb = new FileStream(fileProj, FileMode.Open, FileAccess.Read);
        //        BinaryReader fbb = new BinaryReader(fb);
        //        try
        //        {
        //            sTmp = fbb.ReadString();
        //            curProject = fbb.ReadString();
        //            curDirectory = fbb.ReadString();
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine($"Ошибка операции чтения CheckOpenProj {sTmp}");
        //        }
        //        finally
        //        {
        //            fb.Close();
        //            fbb.Close();
        //        }
        //    }

        //    if (!File.Exists(fileProj))
        //        curProject = "";
        //}

        internal void ProjectDelete(string delDir)
        {
            //dellDer - имя удаляемой директории 
            //Массив имен удаляемых файлов из одной директории
            string[] nameFiles = new string[100];
            string sTmp = "";
            string sTmp1 = "";
            string sTmp2 = "";
            int kRec = 0;
            if (Directory.Exists(delDir))
            {
                // Стандартная функция
                nameFiles = Directory.GetFiles(delDir);
                // Выход по ошибке
                if (nameFiles.Length < 0)
                    return;
                // Удаление файлов из директории проекта
                for (int i = 0; i < nameFiles.Length; i++)
                {
                    if (File.Exists(nameFiles[i]))
                        File.Delete(nameFiles[i]);
                }
            }

            // Проверка удалены ли все файлы
            nameFiles = Directory.GetFiles(delDir);

            // Если все файлы удалены
            if (nameFiles.Length == 0)
            {
                // Удаление директории проекта
                if (Directory.Exists(delDir))
                    Directory.Delete(delDir);

                // Удаление о проекте из файла
                FileStream fp = new FileStream(fileAllProj, FileMode.Open,
                    FileAccess.Read);
                BinaryReader fpp = new BinaryReader(fp);

                // Объявление временного файла для сохранения информации об оставшихся проектах

                if (File.Exists(fileAdd))
                {
                    File.Delete(fileAdd);
                }

                FileStream fu = new FileStream(fileAdd, FileMode.CreateNew);
                BinaryWriter fuu = new BinaryWriter(fu);
                try
                {
                    while ((sTmp = fpp.ReadString()) != null)
                    {
                        sTmp1 = fpp.ReadString();
                        sTmp2 = fpp.ReadString();

                        // пропуск удаляемого проекта
                        if (sTmp2 == delDir)
                            continue;
                        kRec++;
                        fuu.Write(sTmp);
                        fuu.Write(sTmp1);
                        fuu.Write(sTmp2);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Не удалось выполнить операцию чтения.");
                }
                finally
                {
                    fp.Close();
                    fpp.Close();
                }

                fuu.Close();
                fu.Close();
                // Если проектов не осталось, то удаление информации файлов и выход из подпрограммы

                if (kRec == 0)
                {
                    if (File.Exists(fileAllProj))
                        File.Delete(fileAllProj);
                    if (File.Exists(fileProj))
                        File.Delete(fileProj);
                    if (File.Exists(fileAdd))
                        File.Delete(fileAdd);
                    return;
                }

                // Восстановление файла fileAllProj без удаленной директории
                FileStream fa = new FileStream(fileAdd, FileMode.Open,
                    FileAccess.Read);
                BinaryReader faa = new BinaryReader(fa);
                if (File.Exists(fileAllProj))
                {
                    File.Delete(fileAllProj);
                }

                FileStream fb = new FileStream(fileAllProj,
                    FileMode.CreateNew);
                BinaryWriter fbb = new BinaryWriter(fb);
                try
                {
                    while ((sTmp = faa.ReadString()) != null)
                    {
                        sTmp1 = faa.ReadString();
                        sTmp2 = faa.ReadString();
                        fbb.Write(sTmp);
                        fbb.Write(sTmp1);
                        fbb.Write(sTmp2);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"ProjectDelete[DEBUG] Не удалось выполнить операцию чтения. {sTmp}");
                }

                finally
                {
                    fa.Close();
                    faa.Close();
                }

                fbb.Close();
                fb.Close();
            }
        }

        // Объявленние выходных перемынных из метода CoorWin
        private double scaleToWin;
        private double scaleToGeo;
        private double xBegGeo;
        private double yBegGeo;
        private double xEndGeo;
        private double yEndGeo;
        private int xBegWin;
        private int yBegWin;

        // Объявление выходных переменных метода GeotoWin
        private int xWin;
        private int yWin;

        // Объявление выходных переменных метода WintoGeo
        private double xCur;
        private double yCur;

        //Функция для вычисления параметров,
        //перевода данных из геодезической системы в экранную и обратно

        internal void CoorWin(double xGeoMin, double yGeoMin, double xGeoMax,
            double yGeoMax, int pixWidth, int pixHeight, out double scaleToWin,
            out double scaleToGeo, out double xBegGeo, out double yBegGeo,
            out double xEndGeo, out double yEndGeo, out int xBegWin,
            out int yBegWin)
        {
            int dxWin, dyWin;
            int x1Win, y1Win, x2Win, y2Win;

            double sx = 0.0;
            double sy = 0.0;

            scaleToWin = 0.0;
            scaleToGeo = 0.0;

            xBegGeo = xGeoMin;
            yBegGeo = yGeoMin;
            xEndGeo = xGeoMax;
            yEndGeo = yGeoMax;

            // Уменьшение размера рабочей области панели по оси X
            dxWin = System.Convert.ToInt32(0.8 * pixWidth);

            // Уменьшение размера рабочей области панели по оси Y
            dyWin = System.Convert.ToInt32(0.8 * pixHeight);

            // Расчет приближенных значений начала координат экранной системы

            x1Win = System.Convert.ToInt32(0.1 * dxWin);
            y1Win = System.Convert.ToInt32(0.1 * dyWin);

            // Расчет масштаба по осям для перехода от геодезических координат к экранным
            sx = dxWin / (xGeoMax - xGeoMin);
            sy = dyWin / (yGeoMax - yGeoMin);

            // Минимальное значение из вычесленных принимаем за окончательное значение масштаба
            if (sx >= sy)
                scaleToWin = sy;
            if (sy > sx)
                scaleToWin = sx;

            // Расчет приблеженных конечных значений координат экранной системы с учетом размера области данных
            x2Win = System.Convert.ToInt32(x1Win + scaleToWin *
                (xGeoMax - xGeoMin));
            y2Win = System.Convert.ToInt32(y1Win + scaleToWin *
                (yGeoMax - yGeoMin));

            // Расчет приблеженных конечных значений координат экранной системы с учетом размера области данных
            x2Win = System.Convert.ToInt32(x1Win + scaleToWin *
                (xGeoMax - xGeoMin));
            y2Win = System.Convert.ToInt32(y1Win + scaleToWin *
                (yGeoMax - yGeoMin));

            // Расчет масштаба по осям для перехода к геодезическим координатам от экранных
            sx = (xGeoMax - xGeoMin) / (x2Win - x1Win);
            sy = (yGeoMax - yGeoMin) / (y2Win - y1Win);

            // Минимальное из вычисленных значений принимаем за окончательное
            if (sx >= sy)
                scaleToGeo = sy;
            if (sy > sx)
                scaleToGeo = sx;

            // Расчет значений начала координат экранной сыстемы с учетом расположения данных посредине панели
            // и разной направленности осенй Y
            xBegWin = x1Win + System.Convert.ToInt32((dxWin - (
                xGeoMax - xGeoMin) * scaleToWin) / 2);
            yBegWin = y1Win + dyWin - System.Convert.ToInt32((dyWin - (
                yGeoMax - yGeoMin) * scaleToWin) / 2);
        }

        // Функция вычисления экранных координат точки по заданным значениям ее геодезических координат
        internal void GeotoWin(double xCur, double yCur, double scaleToWin,
            double xBegGeo, double yBegGeo, int xBegWin, int yBegWin,
            out int xWin, out int yWin)
        {
            xWin = System.Convert.ToInt32(xBegWin + (xCur - xBegGeo) *
                scaleToWin);
            yWin = System.Convert.ToInt32(yBegWin - (yCur - yBegGeo) *
                scaleToWin);
        }
        // Расчет геодезических координат точки по заданным значениям ее экранных координат
        internal void WintoGeo(int xWin, int yWin, double scaleToGeo, double xBegGeo,
            double yBegGeo, int xBegWin, int yBegWin, out double xCur,
            out double yCur)
        {
            xCur = xBegGeo + (xWin - xBegWin) * scaleToGeo;
            yCur = yBegGeo + (yBegWin - yWin) * scaleToGeo;
        }
        // Подпрограмма рисовки (p.54-55)
        internal void PointDraw(PaintEventArgs e, int iParam, int kPnt, string[] namePnt,
            double[] xPnt, double[] yPnt, double[] zPnt, double scaleWin, double xBeg,
            double yBeg, int xWin, int yWin)
        {
            // Объявление объекта
            Graphics g = e.Graphics;
            string sTmp = "";
            int ix = 0;
            int iy = 0;
            int ih = 6;
            if (kPnt <= 0)
                return;
            // Установка цвета
            SolidBrush iColor = new SolidBrush(Color.Black);
            // Цикл на кол-во точек
            for (int i = 0; i <= kPnt; i++)
            {
                // Перевод геодезических координат в экранные
                GeotoWin(xPnt[i], yPnt[i], scaleWin, xBeg, yBeg, xWin, yWin,
                    out ix, out iy);
                //Обозначение местоположения точки с помощью стандартной функции
                g.FillRectangle(iColor, ix - 1, iy - 1, 3, 3);
                if (iParam == 0)
                {
                    // Если параметр равен нулю, то отображаем имя точки
                    g.DrawString(namePnt[i], new Font("Bold", ih), iColor,
                        ix + ih, iy - ih + 2);
                    if (iParam > 0)
                    {
                        // Еслми параметр больше нуля, то отображаем отметку точки
                        sTmp = String.Format("{O:F2}", zPnt[i]);
                        g.DrawString(sTmp, new Font("Bold", ih), iColor,
                            ix + ih, iy - ih + 2);
                    }
                }
            }
        }

        public void PointsInput(out int iCond, out int kAdd

            //int kGeoFin,
            //string[] nameFin,
            //double[] xFin,
            //double[] yFin,
            //double[] zFin,
            //double zeroSpot,

            //string[] nameAdd,
            //double[] xAdd,
            //double[] yAdd,
            //double[] zAdd,
            //int[] nUniq
        )
        {
            kAdd = -1;
            iCond = 0;
            string sTmp = "";
            
            int k = 0;
            int kPart = 50;
            double num1 = 0.0;
            int index1 = 0;
            double num2 = 3.1415926;
            double num3;
            double num4 = num3 = 0.0;
            double num5 = num3;
            double num6 = num3;
            double num7;
            double num8 = num7 = 0.0;
            int num9 = 0;
            int num14 = 0;
            int num15 = 0;
            // statName = sPart[1];
            int sPart = 0; // template
            int statName = sPart;
            //for (int index2 = 0; index2 <= kGeoFin; ++index2)
            //{
            //    if (nameFin[index2] == "statName") // Template
            //    {
            //        ++num14;
            //        num6 = xFin[index2];
            //        num5 = yFin[index2];
            //        num4 = zFin[index2];
            //        break;
            //    }
            //}
            if (File.Exists(filePoint))
            {
                FileStream fp = new FileStream(filePoint, FileMode.Open, FileAccess.Read);
                BinaryReader fpp = new BinaryReader(fp);
                try
                {
                    filePoint = fpp.ReadString();
                    //namePnt = fpp.ReadDouble();
                    //xPntGeo = fpp.ReadDouble();
                    //yPntGeo = fpp.ReadDouble();
                    //yPntGeo = fpp.ReadDouble();
                    //zPntGeo = fpp.ReadDouble();
                }
                catch (Exception)
                {
                    Console.WriteLine($"Ошибка операции чтения PointsInput {sTmp}");
                }
                finally
                {
                    fp.Close();
                    fpp.Close();
                }
            }

            if (!File.Exists(filePoint))
                filePoint = "";
        }

        void ShareString(string sPoint, int kPartMax, char[] seps, out int kPart, out string[] sPart)
        {
            // Инициализация выходных параметров
            kPart = 0;
            sPart = new string[kPartMax];

            // Объявление дополнительных данных
            string[] parts = new string[kPartMax];

            // Удаление пробелов в начале передаваемой строки
            sPoint = sPoint.Trim();

            // Получение реального количества слов в строке
            parts = sPoint.Split(seps);
            foreach (string s in parts)
            {
                int j = s.Length;
                if (j == 0)
                    continue;
                if (s == "")
                    continue;
                // Формирование выходных параметров
                kPart++;
                sPart[kPart] = s;

            }
        }
        internal void PointsLoad()
        {
            kPoints = 0;
            if (File.Exists(filePoint))
            {
                FileStream fa = new FileStream(filePoint, FileMode.Open,
                    FileAccess.Read);
                BinaryReader faa = new BinaryReader(fa);
                try
                {
                    kPoints = faa.ReadInt32();
                    xmin = faa.ReadDouble();
                    xmin = faa.ReadDouble();
                    zmin = faa.ReadDouble();
                    xmax = faa.ReadDouble();
                    ymax = faa.ReadDouble();
                    zmax = faa.ReadDouble();
                    for (int i = 0; i <= kPoints; i++)
                    {
                        namePnt[i] = faa.ReadString();
                        xPnt[i] = faa.ReadDouble();
                        yPnt[i] = faa.ReadDouble();
                        zPnt[i] = faa.ReadDouble();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"PointsLoad[DEBUG] Не удалось выполнить операцию чтения....SelectProj = {namePnt}");
                    Console.WriteLine($"PointsLoad[DEBUG] Не удалось выполнить операцию чтения....SelectProj = {xPnt}");
                    Console.WriteLine($"PointsLoad[DEBUG] Не удалось выполнить операцию чтения....SelectProj = {yPnt}");
                    Console.WriteLine($"PointsLoad[DEBUG] Не удалось выполнить операцию чтения....SelectProj = {zPnt}");
                }
                finally
                {
                    faa.Close();
                    fa.Close();
                }
            }

        }
    }
}


