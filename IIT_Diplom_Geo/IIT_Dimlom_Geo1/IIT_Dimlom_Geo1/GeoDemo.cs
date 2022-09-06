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
using System.Windows.Media.Media3D;
using DiplomGeoDLL;


namespace IIT_Diplom_Geo1
{

    public partial class GeoDemo : Form
    {
        public string fileProj { get; set; }

        MyGeodesy myGeo = new MyGeodesy();

        private string sTmp1; // так же используется для удаления всех проектов
        private string sTmp2; // для удаления всех проектов
        private int nProcess;
        private string sTmp; // для удаления всех проектов
        private int nControl = 0; // Для выбора области приблежения

        // переменные для определения размеров графической панели
        int pixWidth = 0;
        int pixHeight = 0;

        // Переменные для отрисовки
        double xminCur, yminCur, xmaxCur, ymaxCur;

        public GeoDemo()
        {
            InitializeComponent();

            // Данные для определения масштаба
            pixWidth = panel1.Bounds.Width;
            pixHeight = panel1.Bounds.Height;

            StartPosition = FormStartPosition.Manual;
            btExit1.MouseHover += new
                EventHandler(btExit_MouseHover);
            btExit1.MouseLeave += new
                EventHandler(btExit_MouseLeave);
            //FileOptions.MouseHover += new 
            //    EventHandler(FileOptions_MouseLeave);
            //FileOptions.MouseLeave += new 
            //    EventHandler(FileOptions_MouseLeave);
            FormLoad();
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
        // Переменные для активации функции масштабирования изображения
        bool isDrag = false;
        Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        Point startPoint;
        Point endPoint;
        double xCur, yCur;
        double xCurMin, yCurMin, xCurMax, yCurMax;
        double dx, dy, x1, y1, x2, y2;
        double xaCur, yaCur, xbCur, ybCur;
        // Перемещение изображения в окне
        private int x1Box, y1Box, x2Box, y2Box;
        // метод FormLoad
        private DllClass1 DllClass1 { get; }
        //public string fileProj { get; set; }

        private void FormLoad()
        {
            DllClass1.CheckDrive(myGeo.dirKey, out myGeo.driveKey);
            label1.Text = myGeo.comPath;
            // Проверка открытия проекта
            myGeo.FilePath();
            //myGeo.CheckOpenProj();
            DllClass1.CheckOpenProj(fileProj, out string curProject, out string curDirectory);
            if (myGeo.curProject == "")
                label1.Text = myGeo.comPath + "*** Проект не открыт...";
            else
                label1.Text = myGeo.curProject;
            LoadData();
        }

        private void btExit_MouseHover(object sender, System.EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Close all processes";
            toolStripStatusLabel1.Text = "Закрыть все прооцессы";
        }

        private void btExit_MouseLeave(object sender, System.EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Готов...";
            toolStripStatusLabel1.Text = "Готов...";
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            double xCur = 0.0;
            double yCur = 0.0;

            // Переход от экранных координат к геодезическим
            myGeo.WintoGeo(e.X, e.Y, scaleToGeo, xBegGeo, yBegGeo,
                xBegWin, yBegWin, out xCur, out yCur);
            //При отсутствии данных в строке состояния отображаются экранные координаты
            if (myGeo.kPoints < 1)
            {
                toolStripStatusLabel3.Text = String.Format("{0}", e.X);
                toolStripStatusLabel5.Text = String.Format("{0}", e.Y);
            }

            //При наличии данных в строке состояния отображаются геодезические координаты
            if (myGeo.kPoints > 0)
            {
                toolStripStatusLabel3.Text = String.Format("{0:F2}", xCur);
                toolStripStatusLabel5.Text = String.Format("{0:F2}", yCur);
            }
            //Вычерчивание прямоугольника для определения области увеличения
            if ((nControl == 10) && (isDrag))
            {
                // Стандартные функции

                ControlPaint.DrawReversibleFrame(theRectangle,
                    BackColor, FrameStyle.Dashed);
                endPoint = PointToScreen(new Point(e.X, e.Y));

                // Ограничение вычерчиваемого прямоугольника только в пределах панели
                if ((e.X > 15) && (e.X < pixWidth + 10) && (e.Y > 15) &&
                    (e.Y < pixHeight + 10))
                {
                    int width = endPoint.X - startPoint.X;
                    int height = endPoint.Y - startPoint.Y;
                    theRectangle = new Rectangle(startPoint.X,
                        startPoint.Y, width, height);
                    ControlPaint.DrawReversibleFrame(theRectangle,
                        BackColor, FrameStyle.Dashed);

                }

                ControlPaint.DrawReversibleFrame(theRectangle,
                    BackColor, FrameStyle.Dashed);
            }
            // Перемещение области (окна) данных вдоль панели не меняя масшатаба изображения
            if (nControl == 40)
            {
                if (e.Button == MouseButtons.Left)
                {

                    // Экранные координаты конечной точки перемещения
                    x2Box = e.X;
                    y2Box = e.Y;
                    // Вычисление геодезических координат начальной и конечной точек перемещения
                    myGeo.WintoGeo(x1Box, y1Box, scaleToGeo, xBegGeo,
                        yBegGeo, xBegWin, yBegWin, out x1, out y1);
                    myGeo.WintoGeo(x2Box, y2Box, scaleToGeo, xBegGeo,
                        yBegGeo, xBegWin, yBegWin, out x2, out y2);
                    // Вычисление разности координат
                    dx = x2 - x1;
                    dy = y2 - y1;
                    // Вычисление новых границ области данных с сохранением ее площади
                    xaCur = xminCur - dx;
                    yaCur = yminCur - dy;
                    xbCur = xmaxCur - dx;
                    ybCur = ymaxCur - dy;
                    // Вычисление новых параметров преобразования координат
                    myGeo.CoorWin(xaCur, yaCur, xbCur, ybCur, pixWidth, pixHeight,
                        out scaleToWin, out scaleToGeo, out xBegGeo, out yBegGeo,
                        out xEndGeo, out yEndGeo, out xBegWin, out yBegWin);
                    // перерисовка панели
                    panel1.Invalidate();
                }
            }
        }

        // Кнопка выбора области приблежения
        private void SelectBox_Click(object sender, EventArgs e)
        {
            myGeo.FilePath();
            // Проверка открытия проекта
            DllClass1.CheckOpenProj(myGeo.fileProj, out myGeo.curProject,
                out myGeo.curDirectory);
            if (myGeo.curProject == "")
            {
                MessageBox.Show("Проект не выбран", "Выберите поле данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine($"GeoDemo.SelectBox_Click[DEBUG] - {sender}, {e}");
                return;
            }

            // Идентификация оператора
            nControl = 10;
        }

        // Активация функции мыши для оператора Select Box
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x1Box = e.X;
            y1Box = e.Y;
            // Вычисление геодезических координат в момент нажатия кнопки
            myGeo.WintoGeo(e.X, e.Y, scaleToGeo, xBegGeo, yBegGeo, xBegWin,
                yBegWin, out xCurMin, out yCurMin);
            if (e.Button == MouseButtons.Left)
            {
                if (nControl == 10)
                {
                    isDrag = true;
                    Control control = (Control)sender;
                    // Определение стартовой точки прямоугольника с использованием стандартной функции
                    startPoint = control.PointToScreen(new Point(e.X, e.Y));
                }
                if (nControl == 20)
                {
                    double eff = 0.3;
                    // Определение границ выделяемой области
                    x1 = xCurMin - eff * (xEndGeo - xBegGeo);
                    y1 = yCurMin - eff * (yEndGeo - yBegGeo);
                    x2 = xCurMin + eff * (xEndGeo - xBegGeo);
                    y2 = yCurMin + eff * (yEndGeo - yBegGeo);
                    // Сохранение текущих координат
                    xminCur = x1;
                    yminCur = y1;
                    xmaxCur = x2;
                    ymaxCur = y2;
                    // Вычисление параметров преобразования координат
                    myGeo.CoorWin(x1, y1, x2, y2, pixWidth, pixHeight, out scaleToWin,
                        out scaleToGeo, out xBegGeo, out yBegGeo, out xEndGeo,
                        out yEndGeo, out xBegWin, out yBegWin);
                }
                if (nControl == 30)
                {
                    double ef1 = 0.5;
                    double ef2 = 0.1;
                    // Охват максимально возможной области
                    x1 = xCurMin - ef1 * (xEndGeo - xBegGeo);
                    y1 = yCurMin - ef1 * (yEndGeo - yBegGeo);
                    x2 = xCurMin + ef1 * (xEndGeo - xBegGeo);
                    y2 = yCurMin + ef1 * (yEndGeo - yBegGeo);
                    // Уменьшение выделяемой области данных
                    x1 = x1 - ef2 * (xEndGeo - xBegGeo);
                    y1 = y1 - ef2 * (yEndGeo - yBegGeo);
                    x2 = x2 + ef2 * (xEndGeo - xBegGeo);
                    y2 = y2 + ef2 * (yEndGeo - yBegGeo);
                    // Сохранение текущих координат границ области данных
                    xminCur = x1;
                    yminCur = y1;
                    xmaxCur = x2;
                    ymaxCur = y2;
                    // Вычисление параметров преобразования координат
                    myGeo.CoorWin(x1, y1, x2, y2, pixWidth, pixHeight, out scaleToWin,
                        out scaleToGeo, out xBegGeo, out yBegGeo, out xEndGeo,
                        out yEndGeo, out xBegWin, out yBegWin);
                }
            }
            // Возвращение изображения в окне области данных в исходное положение
            if (e.Button == MouseButtons.Right)
            {
                // Сохранение текущих координат границы области данных
                xminCur = myGeo.xmin;
                yminCur = myGeo.ymin;
                xmaxCur = myGeo.xmax;
                ymaxCur = myGeo.ymax;
                myGeo.CoorWin(myGeo.xmin, myGeo.ymin, myGeo.xmax,
                    myGeo.ymax, pixWidth, pixHeight, out scaleToWin,
                    out scaleToGeo, out xBegGeo, out yBegGeo,
                    out xEndGeo, out yEndGeo, out xBegWin, out yBegWin);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if ((nControl == 10) && (isDrag))
            {
                ControlPaint.DrawReversibleFrame(theRectangle,
                    BackColor, FrameStyle.Dashed);
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
                    // Площадь прямоугольника не может быть нулевой
                    dx = xCurMax - xCurMin;
                    dy = yCurMax - yCurMin;
                    // Для исключения случайных нажатий и отпусканий кнопки мыши
                    // без перемещения установим минимальный размер сторон области выделения
                    if ((dx < 0.05) || (dy < 0.05))
                        return;
                    //Сохранение текущих координат границы области данных
                    xminCur = xCurMin;
                    yminCur = yCurMin;
                    xmaxCur = xCurMax;
                    ymaxCur = yCurMax;
                    //Вычисление параметров преобразования координат
                    myGeo.CoorWin(xCurMin, yCurMin, xCurMax, yCurMax,
                        pixWidth, pixHeight, out scaleToWin, out scaleToGeo,
                        out xBegGeo, out yBegGeo, out xEndGeo, out yEndGeo,
                        out xBegWin, out yBegWin);
                }
                // Сохранение границ текущей области данных
                if ((nControl == 40) && (isDrag))
                {
                    xminCur = xaCur;
                    yminCur = yaCur;
                    xmaxCur = xbCur;
                    ymaxCur = ybCur;
                }

                //Новая инициализация объектов
                theRectangle = new Rectangle(0, 0, 0, 0);
                isDrag = false;
            }

            //Перерисовка панели
            panel1.Invalidate();
        }

        private void ProjectMenuItem_Click(object sender, EventArgs e)
        {
            ProjectMenu frm = new ProjectMenu();
            frm.Show();
        }

        private void newProjToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Желательна проверка файла brdrive.dat
            //myGeo.CheckDrive(myGeo.dirKey, out myGeo.driveKey);
            DllClass1.CheckDrive(myGeo.dirKey, out myGeo.driveKey);
            sTmp1 = myGeo.driveKey + myGeo.dirKey + "\\brdrive.dat";
            Console.WriteLine($"[DEBUG] GeoDemo.newProjToolStripMenuItem_Click: '{sTmp1}'");
            if (!File.Exists(sTmp1))
            {
                MessageBox.Show("Проблемы с выброром диска", "Открыть новый проект",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Загрузка формы CreateNewProj
            CreateNewProj pr = new CreateNewProj();
            pr.ShowDialog(this);
            //pr.Show(this);

            // Проверка открытия проекта
            myGeo.FilePath();
            //myGeo.CheckOpenProj();
            DllClass1.CheckOpenProj(fileProj, out string curProject, out string curDirectory);
            if (myGeo.curProject == "")
                label1.Text = myGeo.comPath + "*** Проект не открыт...";
            else
                label1.Text = myGeo.curProject;
        }

        //Проверка функции Выбора проекта  (p.36)
        private void SelectProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int kProj = 0;
            myGeo.FilePath();
            // Подсчет находящихся в работе проектов
            if (File.Exists(myGeo.fileAllProj))
            {
                FileStream fb = new FileStream(myGeo.fileAllProj,
                    FileMode.Open, FileAccess.Read);
                BinaryReader fbb = new BinaryReader(fb);
                try
                {
                    while ((sTmp1 = fbb.ReadString()) != null)
                    {

                        myGeo.curProject = fbb.ReadString();
                        myGeo.curDirectory = fbb.ReadString();
                        kProj++;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Не удалось выполнить операцию чтения...");
                }
                finally
                {
                    fb.Close();
                    fbb.Close();
                }
            }

            // Если кол-во проектов равно нулю
            if (kProj == 0)
            {
                MessageBox.Show("Проект не определен",
                    "Выбрать существующий проект", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Если кол-во проектов равно 1, то нет смысла открывать форму для выбора проекта
            if (kProj == 1)
            {
                MessageBox.Show("Только один проект",
                    "Выбрать существующий проект",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (File.Exists(myGeo.fileProj))
                {
                    File.Delete(myGeo.fileProj);
                }

                FileStream fc = new FileStream(myGeo.fileProj,
                    FileMode.CreateNew);
                BinaryWriter fcc = new BinaryWriter(fc);
                fcc.Write(sTmp1);
                fcc.Write(myGeo.curProject);
                fcc.Write(myGeo.curDirectory);
                fcc.Close();
                fc.Close();
            }

            // Создание файла с кодом процесса = 1 
            if (File.Exists(myGeo.fileProcess))
            {
                File.Delete(myGeo.fileProcess);
            }

            FileStream fe = new FileStream(myGeo.fileProcess,
                FileMode.CreateNew);
            BinaryWriter fee = new BinaryWriter(fe);
            nProcess = 1;
            fee.Write(nProcess);
            fee.Close();
            fe.Close();
            if (kProj > 1)
            // Открытие формы
            {
                SelectProj spr = new SelectProj();
                spr.ShowDialog(this);
            }

            // Обновление переменных в соответствии с новым текущим проектом
            myGeo.FilePath();
            //myGeo.CheckOpenProj();
            DllClass1.CheckOpenProj(fileProj, out string curProject, out string curDirectory);
            label1.Text = myGeo.curProject;
        }

        private void DeleteProjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Контроль наличияфайла с перечнем проектов
            if (!File.Exists(myGeo.fileAllProj))
            {
                MessageBox.Show("Проект не выбран",
                    "Выберите существующий проект",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создание файла с кодом процесса = 2
            if (File.Exists(myGeo.fileProcess))
            {
                File.Delete(myGeo.fileProcess);
            }

            FileStream fe = new FileStream(myGeo.fileProcess,
                FileMode.CreateNew);
            BinaryWriter fee = new BinaryWriter(fe);
            nProcess = 2;
            fee.Write(nProcess);
            fee.Close();
            fe.Close();
            //3arpy3Ka <t>opMhi .LlJ1JI Bbi6opa rrpoeKTa
            SelectProj spr = new SelectProj();
            spr.ShowDialog(this);
            //06HOBJieHHe nepeMeHHbiX
            myGeo.FilePath();
            //IKoHrponh reeyll(ero npoei < Ta
            // myGeo.CheckOpenProj();
            DllClass1.CheckOpenProj(fileProj, out string curProject, out string curDirectory);
            if (myGeo.curProject == "")
                label1.Text = myGeo.comPath + "***Проект не был открыт";
            else
                label1.Text = myGeo.curProject;
        }

        private void DelAllProjToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult result;

            // Проверка наличия проектов
            if (!File.Exists(myGeo.fileAllProj))
            {
                MessageBox.Show("Проект не выбран", "Удалить все проекты",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Контрольный запрос на удаление
            result = MessageBox.Show("Вы действительно хотите удалить все проекты ?", "Удалить все проекты",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

            // Восстановление переменных
            myGeo.FilePath();

            // Цикл на наличие не более 500 проектов
            for (int i = 1; i < 500; i++)
            {
                int k = 0;
                if (File.Exists(myGeo.fileAllProj))
                {
                    FileStream fb = new FileStream(myGeo.fileAllProj,
                        FileMode.Open, FileAccess.Read);
                    BinaryReader fbb = new BinaryReader(fb);
                    try
                    {
                        while ((sTmp = fbb.ReadString()) != null)
                        {
                            sTmp1 = fbb.ReadString();
                            sTmp2 = fbb.ReadString();

                            // Выход из цикла сразу после считывания первого проекта
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(
                            "DelAllProjToolStripMenuItem_Click[DEBUG] Не удалось выполнить операцию чтения.");
                    }
                    finally
                    {
                        fb.Close();
                        fbb.Close();
                    }

                    // Удаление очередного проекта и восстановление файла fileAllProj
                    k++;
                    myGeo.ProjectDelete(sTmp2);
                }

                //Выход из цикла сразу после удаления последнего проекта
                if (k == 0)
                    break;
            }
            // Попытка восстановить переменные после удаления последнего проекта

            myGeo.FilePath();
            // Проверка наличия текущего проекта
            //DllClass1.CheckOpenProj();
            DllClass1.CheckOpenProj(fileProj, out string curProject, out string curDirectory);
            //DllClass1.CheckOpenProj();
            if (myGeo.curProject == "")
                label1.Text = myGeo.comPath + "***Проект не открыт";
            else
                label1.Text = myGeo.curProject;
        }

        // Добавление функции - рисовка (p.54)
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (myGeo.kPoints > 0)
            {
                int iParam = 0;

                // Отображение точек
                // MyGeoPointDraw
                myGeo.PointDraw(e, iParam, myGeo.kPoints, myGeo.namePnt,
                    myGeo.xPntGeo, myGeo.yPntGeo, myGeo.zPntGeo,
                    scaleToWin, xBegGeo, yBegGeo, xBegWin, yBegWin);
            }
        }

        //private void PointsInput_Click(object sender, EventArgs e)
        //{
        //    myGeo.FilePath();
        //    //Проверка открытия проекта
        //    DllClass1.CheckOpenProj(myGeo.fileProj, out myGeo.curProject,
        //        out myGeo.curDirectory);
        //    myGeo.curProject = "CadastrDemo.txt"; // Временная затычка
        //    try
        //    {
        //        if (myGeo.curProject == "")
        //        {
        //            Console.WriteLine($"PointsInput_Click[DEBUG] myGeo.fileProj = {myGeo.fileProj}\n" +
        //                              $"PointsInput_Click[DEBUG] myGeo.curProject = {myGeo.curProject}");

        //            MessageBox.Show("Проект не определен", "Выберите существующий проект",
        //                MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //        }// return;
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine($"{0}Ошибка операции (PointsInput_Click){exception}");
        //    }
        //    finally
        //    {
        //    }
        //    //int iCond = 0;
        //    // Программа (функция) ввода файла, формирования массивов и бинарного файла
        //    //myGeo.PointsInput(out iCond);
        //    DllClass1.PointsInput(out int iCond, out int kAdd);
        //    //Индикатор наличия ошибок при вводе файла точек
        //    if (iCond < 0)
        //        return;
        //    if (myGeo.kPoints < 2)
        //        return;
        //    // Сохранение текущих координат границы области данных
        //    xminCur = myGeo.xmin;
        //    yminCur = myGeo.ymin;
        //    xmaxCur = myGeo.xmax;
        //    ymaxCur = myGeo.ymax;
        //    // Вычисление параметров преобразования координат
        //    myGeo.CoorWin(myGeo.xmin, myGeo.ymin, myGeo.xmax, myGeo.ymax,
        //        pixWidth, pixHeight, out scaleToWin, out scaleToGeo,
        //        out xBegGeo, out yBegGeo, out xEndGeo, out yEndGeo,
        //        out xBegWin, out yBegWin);
        //    //Перерисовка графической панели
        //    panel1.Invalidate();
        //}


        // Загрузка данных
        private void LoadData()
        {
            myGeo.FilePath();
            // Проверка открытия проекта
            DllClass1.CheckOpenProj(myGeo.fileProj, out myGeo.curProject,
                out myGeo.curDirectory);
            if (myGeo.curProject == "") // Временно
            {
                Console.WriteLine($"PointsInput_Click[DEBUG] myGeo.fileProj = {myGeo.fileProj}\n" +
                                  $"PointsInput_Click[DEBUG] myGeo.curProject = {myGeo.curProject}");

                MessageBox.Show("Проект не открыт", "Загрузка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Загрузка массива точек
            myGeo.PointsLoad();
            // Проверка кол-ва точек
            if (myGeo.kPoints < 2)
            {
                MessageBox.Show("Данные отсутствуют", "Загрузить данные",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Console.WriteLine($"PointsInput_Click[DEBUG] myGeo.fileProj = {myGeo.fileProj}\n" +
                                  $"PointsInput_Click[DEBUG] myGeo.curProject = {myGeo.curProject}");
                return;
            }

            // Сохранение текущих координат границы области данных
            xminCur = myGeo.xmin;
            yminCur = myGeo.ymin;
            xmaxCur = myGeo.xmax;
            ymaxCur = myGeo.ymax;
            //Выполнение параметров преобразования Koopдинат
            myGeo.CoorWin(myGeo.xmin, myGeo.ymin, myGeo.xmax, myGeo.ymax,
                pixWidth, pixHeight, out scaleToWin, out scaleToGeo,
                out xBegGeo, out yBegGeo, out xEndGeo, out yEndGeo,
                out xBegWin, out yBegWin);
        }
    }
}

