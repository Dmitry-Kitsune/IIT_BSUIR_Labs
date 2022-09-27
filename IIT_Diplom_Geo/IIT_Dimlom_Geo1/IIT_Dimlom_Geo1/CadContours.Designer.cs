using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class CadContours
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
       // private System.ComponentModel.IContainer components = null;
        private StatusBar statusBar1 = new StatusBar();
        private StatusBarPanel panel1 = new StatusBarPanel();
        private StatusBarPanel panel2 = new StatusBarPanel();
        private StatusBarPanel panel3 = new StatusBarPanel();
        private StatusBarPanel panel4 = new StatusBarPanel();
        private StatusBarPanel panel5 = new StatusBarPanel();
        private StatusBarPanel panel6 = new StatusBarPanel();
        private Rectangle RcDraw;
        private Rectangle RcBox;
        private Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        private Point startPoint;
        private Point endPoint;
        private IContainer components;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private GroupBox groupBox3;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private GroupBox groupBox4;
        private Button button13;
        private Button button12;
        private Button button11;
        private Button button10;
        private Button button9;
        private GroupBox groupBox5;
        private Button button18;
        private Button button17;
        private Button button16;
        private Button button15;
        private Button button14;
        private GroupBox groupBox6;
        private Button button21;
        private Button button20;
        private Button button19;
        private Button button22;
        private Panel panel7;
        private Button button23;
        private Button button24;
        private Button button25;
        private Button button26;
        private Button button27;
        private Button button30;
        private Button button29;
        private Button button31;
        private GroupBox groupBox7;
        private Button button28;
        private GroupBox groupBox8;
        private Button button32;
        private Label label1;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button24 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button29 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button28 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button31 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(708, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 828);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.button13);
            this.groupBox4.Controls.Add(this.button12);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(6, 675);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(289, 145);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Горизонтали и полигоны";
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(180, 105);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(104, 36);
            this.button13.TabIndex = 4;
            this.button13.Text = "Отменить блокировку";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.Abolish_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(4, 103);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(172, 38);
            this.button12.TabIndex = 3;
            this.button12.Text = "Выделите блокируемые полигоны мышью";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.BlockSelect_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(4, 64);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(277, 35);
            this.button11.TabIndex = 2;
            this.button11.Text = "Блокировка всех внутренних исключений полигонов";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.ExeptIntrinsic_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(134, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(150, 39);
            this.button10.TabIndex = 1;
            this.button10.Text = "Блокировка всех внутренних полигонов";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.BlockInrinsic_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(6, 19);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(122, 39);
            this.button9.TabIndex = 0;
            this.button9.Text = "Блокировка всех полигонов";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.BlockAll_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox5.Controls.Add(this.button24);
            this.groupBox5.Controls.Add(this.button23);
            this.groupBox5.Controls.Add(this.button18);
            this.groupBox5.Controls.Add(this.button17);
            this.groupBox5.Controls.Add(this.button16);
            this.groupBox5.Controls.Add(this.button15);
            this.groupBox5.Controls.Add(this.button14);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(7, 426);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(289, 356);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Коррекция горизонталей";
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.White;
            this.button24.Location = new System.Drawing.Point(10, 119);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(272, 41);
            this.button24.TabIndex = 6;
            this.button24.Text = "Увеличить плавность выбранной горизонтали";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.RaiseOne_Click);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.White;
            this.button23.Location = new System.Drawing.Point(10, 73);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(273, 40);
            this.button23.TabIndex = 5;
            this.button23.Text = "Уменьшить плавность выбранной горизонтали";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.LessenOne_Click);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.White;
            this.button18.Location = new System.Drawing.Point(7, 210);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(276, 34);
            this.button18.TabIndex = 4;
            this.button18.Text = "Восстановление последней удаленной строки";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.ContRestore_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.White;
            this.button17.Location = new System.Drawing.Point(144, 166);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(139, 39);
            this.button17.TabIndex = 3;
            this.button17.Text = "Удалить горизонталь";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.ContRemove_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.White;
            this.button16.Location = new System.Drawing.Point(8, 166);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(131, 38);
            this.button16.TabIndex = 2;
            this.button16.Text = "Разделение горизонтали";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.ContSplit_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(7, 20);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(139, 47);
            this.button15.TabIndex = 1;
            this.button15.Text = "Повышение плавности всех горизонталей";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.SmoothUp_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(152, 19);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(133, 48);
            this.button14.TabIndex = 0;
            this.button14.Text = "Уменьшить плавность всех горизонталей";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.SmoothDown_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.button26);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(5, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 411);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Построение модели рельефа";
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox8.Controls.Add(this.button29);
            this.groupBox8.Controls.Add(this.button32);
            this.groupBox8.Controls.Add(this.button30);
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(5, 19);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(282, 123);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Вспомогательные операции - добавление вершин";
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button29.ForeColor = System.Drawing.Color.Black;
            this.button29.Location = new System.Drawing.Point(5, 35);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(138, 50);
            this.button29.TabIndex = 6;
            this.button29.Text = "Добавить вершины для всех линий";
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.VertexAdd_Click);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button32.ForeColor = System.Drawing.Color.Black;
            this.button32.Location = new System.Drawing.Point(149, 35);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(127, 50);
            this.button32.TabIndex = 8;
            this.button32.Text = "Выбрать линию для добавления вершин";
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.SelectLines_Click);
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button30.ForeColor = System.Drawing.Color.Black;
            this.button30.Location = new System.Drawing.Point(82, 91);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(131, 26);
            this.button30.TabIndex = 7;
            this.button30.Text = "Удаление вершин";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.VertexRemove_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox7.Controls.Add(this.button28);
            this.groupBox7.Controls.Add(this.button27);
            this.groupBox7.ForeColor = System.Drawing.Color.Black;
            this.groupBox7.Location = new System.Drawing.Point(9, 193);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(275, 75);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Вспомогательные операции";
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button28.ForeColor = System.Drawing.Color.Black;
            this.button28.Location = new System.Drawing.Point(150, 19);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(120, 50);
            this.button28.TabIndex = 9;
            this.button28.Text = "Вернуть модель перед обновлением";
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.ModelReturn_Click);
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button27.ForeColor = System.Drawing.Color.Black;
            this.button27.Location = new System.Drawing.Point(5, 19);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(139, 50);
            this.button27.TabIndex = 5;
            this.button27.Text = "Модель автоматической коррекции рельефа";
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.AutomatCorrect_Click);
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.White;
            this.button26.Location = new System.Drawing.Point(12, 366);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(128, 37);
            this.button26.TabIndex = 4;
            this.button26.Text = "Установить новый треугольник";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.NewTriangle_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(145, 366);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(137, 37);
            this.button8.TabIndex = 3;
            this.button8.Text = "Изменение интервала";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.ChangeInterval_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(10, 321);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(272, 39);
            this.button7.TabIndex = 2;
            this.button7.Text = "Коррекция модели удалением треугольника";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.TreRemove_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(12, 274);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(270, 41);
            this.button6.TabIndex = 1;
            this.button6.Text = "Коррекция модели путем выбора общей стороны двух треугольников";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Diagonal_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(7, 148);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(277, 39);
            this.button5.TabIndex = 0;
            this.button5.Text = "Модель построения рельефа и горизонталей";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.ModelContour_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox6.Controls.Add(this.button31);
            this.groupBox6.Controls.Add(this.button25);
            this.groupBox6.Controls.Add(this.button21);
            this.groupBox6.Controls.Add(this.button20);
            this.groupBox6.Controls.Add(this.button19);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(213, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(489, 69);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "View";
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.Color.White;
            this.button31.Location = new System.Drawing.Point(314, 17);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(80, 38);
            this.button31.TabIndex = 5;
            this.button31.Text = "Линии вкл/выкл";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.LineOnOff_Click);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.White;
            this.button25.Location = new System.Drawing.Point(400, 16);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(83, 39);
            this.button25.TabIndex = 3;
            this.button25.Text = "Полигоны вкл/выкл";
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.PolygonOnOff_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.White;
            this.button21.Location = new System.Drawing.Point(189, 16);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(119, 39);
            this.button21.TabIndex = 2;
            this.button21.Text = "Горизонтали вкл/выкл";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.ContoursOnOff_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.White;
            this.button20.Location = new System.Drawing.Point(85, 17);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(98, 38);
            this.button20.TabIndex = 1;
            this.button20.Text = "Треугольники вкл./выкл.";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.TrianglesOnOff_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.White;
            this.button19.Location = new System.Drawing.Point(6, 16);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(75, 38);
            this.button19.TabIndex = 0;
            this.button19.Text = "Точка вкл./выкл.\r\n";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.PointsOnOff_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 69);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Панель навигации";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.MoveIcon1;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(144, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 39);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Move_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.ZoomOutIcon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(100, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 39);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.zoomIn;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(56, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 38);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.SelectBoX1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(6, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 39);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SelectBox_Click);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.Red;
            this.button22.ForeColor = System.Drawing.Color.White;
            this.button22.Location = new System.Drawing.Point(600, 791);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(96, 40);
            this.button22.TabIndex = 5;
            this.button22.Text = "Закрыть окно";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.Quit_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(12, 78);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(690, 707);
            this.panel7.TabIndex = 1;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown);
            this.panel7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseMove);
            this.panel7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 793);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "-";
            // 
            // CadContours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1013, 871);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadContours";
            this.Text = "Добавление горизонталей";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}