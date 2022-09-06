using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class Aero
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;
        private IContainer components;
        private Panel panel7;
        private Button button1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private Label label1;
        private Label label3;
        private GroupBox groupBox3;
        private Button button8;
        private Button button7;
        private GroupBox groupBox4;
        private Button button12;
        private Button button11;
        private Button button10;
        private Button button9;
        private GroupBox groupBox5;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button13;
        private GroupBox groupBox6;
        private Button button21;
        private Button button20;
        private Button button19;
        private Button button18;
        private Button button17;
        private Button button16;
        private Button button15;
        private Button button14;
        private GroupBox groupBox7;
        private Button button25;
        private Button button24;
        private Button button23;
        private Button button22;
        private GroupBox groupBox8;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private Button button26;
        private Button button30;
        private Button button29;
        private Button button28;
        private Button button27;
        private GroupBox groupBox9;
        private Button button34;
        private Button button33;
        private Button button32;
        private Button button31;
        private StatusBar statusBar1 = new StatusBar();
        private StatusBarPanel panel1 = new StatusBarPanel();
        private StatusBarPanel panel2 = new StatusBarPanel();
        private StatusBarPanel panel3 = new StatusBarPanel();
        private StatusBarPanel panel4 = new StatusBarPanel();
        private StatusBarPanel panel5 = new StatusBarPanel();
        private StatusBarPanel panel6 = new StatusBarPanel();
        private Rectangle RcDraw;
        private Rectangle RcBox;
        private Rectangle RcBox1;
        private Rectangle RcBox2;
        private Rectangle RcBox3;
        private Rectangle RcBox4;
        private Rectangle[] RcPnt = new Rectangle[100];
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
            this.panel7 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button30 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button25 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button21 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button34 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Location = new System.Drawing.Point(15, 71);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(619, 644);
            this.panel7.TabIndex = 0;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown);
            this.panel7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseMove);
            this.panel7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(763, 685);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Закрыть окно";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(639, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 677);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox8.Controls.Add(this.button30);
            this.groupBox8.Controls.Add(this.button29);
            this.groupBox8.Controls.Add(this.button28);
            this.groupBox8.Controls.Add(this.button27);
            this.groupBox8.Controls.Add(this.button26);
            this.groupBox8.Controls.Add(this.radioButton6);
            this.groupBox8.Controls.Add(this.radioButton5);
            this.groupBox8.Controls.Add(this.radioButton4);
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(6, 514);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(364, 157);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Архив ЦММ";
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.Coral;
            this.button30.Location = new System.Drawing.Point(118, 116);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(142, 35);
            this.button30.TabIndex = 7;
            this.button30.Text = "Удалить архив";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.ArchiveDtmDelete_Click);
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.White;
            this.button29.Location = new System.Drawing.Point(272, 75);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(89, 35);
            this.button29.TabIndex = 6;
            this.button29.Text = "Показать архив";
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.ArchiveDtmShow_Click);
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.Color.White;
            this.button28.Location = new System.Drawing.Point(118, 75);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(142, 35);
            this.button28.TabIndex = 5;
            this.button28.Text = "Добавить текущую модель в архив";
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.AddCurrModel_Click);
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.Color.White;
            this.button27.Location = new System.Drawing.Point(6, 75);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(106, 35);
            this.button27.TabIndex = 4;
            this.button27.Text = "Показать модель";
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.ModelShow_Click);
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.LightGreen;
            this.button26.Location = new System.Drawing.Point(272, 16);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(87, 53);
            this.button26.TabIndex = 3;
            this.button26.Text = "Загрузить точки ЦММ из файла";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.StereoDtm_Click);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(8, 52);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(256, 17);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.Text = "x_left     y_right    x_parallax   y_parallax";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(8, 34);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(253, 17);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.Text = "x_left     y_left     x_parallax   y_parallax";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(8, 16);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(223, 17);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "x_left     y_left     x_right     y_right";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox7.Controls.Add(this.button25);
            this.groupBox7.Controls.Add(this.button24);
            this.groupBox7.Controls.Add(this.button23);
            this.groupBox7.Controls.Add(this.button22);
            this.groupBox7.ForeColor = System.Drawing.Color.Black;
            this.groupBox7.Location = new System.Drawing.Point(6, 408);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(364, 100);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Корректировка плана контрольных и проверочных точек";
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.White;
            this.button25.Location = new System.Drawing.Point(195, 60);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(163, 34);
            this.button25.TabIndex = 3;
            this.button25.Text = "Список точек";
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.PointsList_Click);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.White;
            this.button24.Location = new System.Drawing.Point(7, 60);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(182, 34);
            this.button24.TabIndex = 2;
            this.button24.Text = "Все точки как контрольные";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.AllAsControl_Click);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.White;
            this.button23.Location = new System.Drawing.Point(194, 19);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(164, 39);
            this.button23.TabIndex = 1;
            this.button23.Text = "Выбор провеолчгых точек";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.CheckSelect_Click);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.White;
            this.button22.Location = new System.Drawing.Point(6, 19);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(182, 39);
            this.button22.TabIndex = 0;
            this.button22.Text = "Выбор контрольных точек";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.ControlSelect_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox6.Controls.Add(this.button21);
            this.groupBox6.Controls.Add(this.button20);
            this.groupBox6.Controls.Add(this.button19);
            this.groupBox6.Controls.Add(this.button18);
            this.groupBox6.Controls.Add(this.button17);
            this.groupBox6.Controls.Add(this.button16);
            this.groupBox6.Controls.Add(this.button15);
            this.groupBox6.Controls.Add(this.button14);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(7, 259);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(363, 143);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Управление графикой";
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.White;
            this.button21.Location = new System.Drawing.Point(279, 19);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(79, 34);
            this.button21.TabIndex = 7;
            this.button21.Text = "Все точки";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.AllPoints_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.White;
            this.button20.Location = new System.Drawing.Point(265, 99);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(92, 34);
            this.button20.TabIndex = 6;
            this.button20.Text = "Оригинал";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.Original_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.White;
            this.button19.Location = new System.Drawing.Point(143, 19);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(134, 34);
            this.button19.TabIndex = 5;
            this.button19.Text = "Проверочные точки";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.CheckPoints_Click);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.White;
            this.button18.Location = new System.Drawing.Point(5, 19);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(132, 34);
            this.button18.TabIndex = 4;
            this.button18.Text = "Контрольные точки";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.ControlPoints_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.White;
            this.button17.Location = new System.Drawing.Point(143, 59);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(214, 34);
            this.button17.TabIndex = 3;
            this.button17.Text = "Объекдинение полос(направлений)";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.StripsJoin_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.White;
            this.button16.Location = new System.Drawing.Point(5, 59);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(132, 34);
            this.button16.TabIndex = 2;
            this.button16.Text = "Объединение моделей";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.ModelsJoin_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(143, 99);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(116, 34);
            this.button15.TabIndex = 1;
            this.button15.Text = "Относительная ориентация";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.RelativeOrient_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(5, 99);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(132, 34);
            this.button14.TabIndex = 0;
            this.button14.Text = "Внутренняя ориентация";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.InteriorOrient_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox5.Controls.Add(this.button13);
            this.groupBox5.Controls.Add(this.radioButton3);
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(6, 175);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(364, 78);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Данные стереоскопических измерений";
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.LightGreen;
            this.button13.Location = new System.Drawing.Point(275, 14);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(84, 58);
            this.button13.TabIndex = 3;
            this.button13.Text = "Загрузить данные из файла";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.StereoInput_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(8, 50);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(264, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "x_left     y_right    x_parallax     y_parallax";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(261, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "x_left     y_left     x_parallax     y_parallax";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(223, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "x_left     y_left     x_right     y_right";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.button12);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(6, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(364, 105);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Архив контрольных точек";
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(151, 19);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(198, 34);
            this.button12.TabIndex = 3;
            this.button12.Text = "Контрольные точкитекущего проекта";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.ControlCurrent_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(197, 59);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(152, 34);
            this.button11.TabIndex = 2;
            this.button11.Text = "Удалить архив";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.ControlDelete_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(17, 59);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(174, 34);
            this.button10.TabIndex = 1;
            this.button10.Text = "Информация об архиве";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.ControlInfo_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(17, 19);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(125, 34);
            this.button9.TabIndex = 0;
            this.button9.Text = "Заполнить Архив";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.FillControl_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(6, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 48);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Архив аеро-фото камер";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(234, 17);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(127, 23);
            this.button8.TabIndex = 1;
            this.button8.Text = "Удалить архив";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.CameraDelete_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(9, 17);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(219, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "Заполнить и исправить Архив";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.FillCamera_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox9.Controls.Add(this.button34);
            this.groupBox9.Controls.Add(this.button33);
            this.groupBox9.Controls.Add(this.button32);
            this.groupBox9.Controls.Add(this.button31);
            this.groupBox9.ForeColor = System.Drawing.Color.Black;
            this.groupBox9.Location = new System.Drawing.Point(12, 2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(199, 63);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Панель навигации";
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.White;
            this.button34.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.MoveIcon1;
            this.button34.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button34.Location = new System.Drawing.Point(145, 19);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(36, 34);
            this.button34.TabIndex = 3;
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.Move_Click);
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.Color.White;
            this.button33.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.ZoomOutIcon;
            this.button33.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button33.Location = new System.Drawing.Point(102, 19);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(37, 34);
            this.button33.TabIndex = 2;
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.White;
            this.button32.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.zoomIn;
            this.button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button32.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button32.Location = new System.Drawing.Point(57, 19);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(39, 34);
            this.button32.TabIndex = 1;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.Color.White;
            this.button31.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.SelectBoX1;
            this.button31.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button31.Location = new System.Drawing.Point(6, 19);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(45, 34);
            this.button31.TabIndex = 0;
            this.button31.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.SelectBox_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(217, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 63);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "                                                                                 " +
    "    ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Текущий проект";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(12, 656);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 18);
            this.label3.TabIndex = 3;
            // 
            // Aero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1016, 739);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Aero";
            this.Text = "Аэротриангуляция";
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox textBox1;
    }
}