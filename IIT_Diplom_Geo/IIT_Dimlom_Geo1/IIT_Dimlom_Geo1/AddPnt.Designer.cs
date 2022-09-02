using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class AddPnt
    {


        private IContainer components;
        private Panel panel7;
        private Button button1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private GroupBox groupBox3;
        private Button button12;
        private Button button11;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private GroupBox groupBox4;
        private Label label1;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox textBox11;
        private TextBox textBox10;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
        private Button button15;
        private Button button14;
        private Button button13;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label6;
        private Label label11;
        private Button button10;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel7 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            label6 = new System.Windows.Forms.Label();
            groupBox6 = new System.Windows.Forms.GroupBox();
            radioButton2 = new System.Windows.Forms.RadioButton();
            radioButton1 = new System.Windows.Forms.RadioButton();
            groupBox5 = new System.Windows.Forms.GroupBox();
            button10 = new System.Windows.Forms.Button();
            label11 = new System.Windows.Forms.Label();
            textBox7 = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            button15 = new System.Windows.Forms.Button();
            textBox9 = new System.Windows.Forms.TextBox();
            button14 = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            textBox10 = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            textBox11 = new System.Windows.Forms.TextBox();
            textBox8 = new System.Windows.Forms.TextBox();
            button13 = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            textBox6 = new System.Windows.Forms.TextBox();
            textBox5 = new System.Windows.Forms.TextBox();
            textBox4 = new System.Windows.Forms.TextBox();
            textBox3 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            button7 = new System.Windows.Forms.Button();
            button9 = new System.Windows.Forms.Button();
            button12 = new System.Windows.Forms.Button();
            button8 = new System.Windows.Forms.Button();
            button11 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            button5 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panel7
            // 
            panel7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel7.Location = new System.Drawing.Point(12, 64);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(657, 643);
            panel7.TabIndex = 0;
            panel7.Paint += new System.Windows.Forms.PaintEventHandler(panel7_Paint);
            panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(panel7_MouseDown);
            panel7.MouseMove += new System.Windows.Forms.MouseEventHandler(panel7_MouseMove);
            panel7.MouseUp += new System.Windows.Forms.MouseEventHandler(panel7_MouseUp);
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.Red;
            button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button1.ForeColor = System.Drawing.Color.White;
            button1.Location = new System.Drawing.Point(786, 681);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(130, 26);
            button1.TabIndex = 1;
            button1.Text = "Закрыть окно";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(Cancel_Click);
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            groupBox1.ForeColor = System.Drawing.Color.Black;
            groupBox1.Location = new System.Drawing.Point(675, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(350, 663);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(groupBox6);
            groupBox4.Controls.Add(groupBox5);
            groupBox4.Controls.Add(button13);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(textBox6);
            groupBox4.Controls.Add(textBox5);
            groupBox4.Controls.Add(textBox4);
            groupBox4.Controls.Add(textBox3);
            groupBox4.Controls.Add(textBox2);
            groupBox4.Controls.Add(textBox1);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label1);
            groupBox4.ForeColor = System.Drawing.Color.Black;
            groupBox4.Location = new System.Drawing.Point(6, 228);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(338, 429);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Дополнительная точка";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label6.Location = new System.Drawing.Point(201, 91);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(110, 13);
            label6.TabIndex = 29;
            label6.Text = "Perpend. length,m";
            // 
            // groupBox6
            // 
            groupBox6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox6.Controls.Add(radioButton2);
            groupBox6.Controls.Add(radioButton1);
            groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            groupBox6.ForeColor = System.Drawing.Color.Black;
            groupBox6.Location = new System.Drawing.Point(6, 175);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(326, 74);
            groupBox6.TabIndex = 28;
            groupBox6.TabStop = false;
            groupBox6.Text = "Положение новой точки относительно направления 1-2";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            radioButton2.Location = new System.Drawing.Point(195, 41);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(98, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Круг право";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            radioButton1.Location = new System.Drawing.Point(44, 41);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(90, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Круг лево";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox5.Controls.Add(button10);
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(textBox7);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(button15);
            groupBox5.Controls.Add(textBox9);
            groupBox5.Controls.Add(button14);
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(textBox10);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(textBox11);
            groupBox5.Controls.Add(textBox8);
            groupBox5.ForeColor = System.Drawing.Color.Black;
            groupBox5.Location = new System.Drawing.Point(6, 295);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(326, 128);
            groupBox5.TabIndex = 27;
            groupBox5.TabStop = false;
            groupBox5.Text = "Данные точки";
            // 
            // button10
            // 
            button10.BackColor = System.Drawing.Color.White;
            button10.Location = new System.Drawing.Point(234, 99);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(75, 23);
            button10.TabIndex = 26;
            button10.Text = "Помощь";
            button10.UseVisualStyleBackColor = false;
            button10.Click += new System.EventHandler(HelpSymb_Click);
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label11.Location = new System.Drawing.Point(168, 61);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(44, 13);
            label11.TabIndex = 25;
            label11.Text = "Код = ";
            // 
            // textBox7
            // 
            textBox7.Location = new System.Drawing.Point(47, 19);
            textBox7.Name = "textBox7";
            textBox7.Size = new System.Drawing.Size(77, 20);
            textBox7.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label9.Location = new System.Drawing.Point(15, 66);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(26, 13);
            label9.TabIndex = 23;
            label9.Text = "Y =";
            // 
            // button15
            // 
            button15.BackColor = System.Drawing.Color.White;
            button15.Location = new System.Drawing.Point(123, 99);
            button15.Name = "button15";
            button15.Size = new System.Drawing.Size(91, 23);
            button15.TabIndex = 13;
            button15.Text = "Очистить";
            button15.UseVisualStyleBackColor = false;
            button15.Click += new System.EventHandler(CancelSave_Click);
            // 
            // textBox9
            // 
            textBox9.Location = new System.Drawing.Point(47, 63);
            textBox9.Name = "textBox9";
            textBox9.ReadOnly = true;
            textBox9.Size = new System.Drawing.Size(77, 20);
            textBox9.TabIndex = 16;
            // 
            // button14
            // 
            button14.BackColor = System.Drawing.Color.White;
            button14.Location = new System.Drawing.Point(8, 99);
            button14.Name = "button14";
            button14.Size = new System.Drawing.Size(86, 23);
            button14.TabIndex = 12;
            button14.Text = "Сохранить";
            button14.UseVisualStyleBackColor = false;
            button14.Click += new System.EventHandler(Save_Click);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label7.Location = new System.Drawing.Point(7, 23);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(32, 13);
            label7.TabIndex = 21;
            label7.Text = "Имя";
            // 
            // textBox10
            // 
            textBox10.Location = new System.Drawing.Point(226, 36);
            textBox10.Name = "textBox10";
            textBox10.Size = new System.Drawing.Size(71, 20);
            textBox10.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label10.Location = new System.Drawing.Point(186, 40);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(26, 13);
            label10.TabIndex = 24;
            label10.Text = "Z =";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label8.Location = new System.Drawing.Point(14, 44);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(26, 13);
            label8.TabIndex = 22;
            label8.Text = "X =";
            // 
            // textBox11
            // 
            textBox11.Location = new System.Drawing.Point(226, 58);
            textBox11.Name = "textBox11";
            textBox11.Size = new System.Drawing.Size(72, 20);
            textBox11.TabIndex = 18;
            // 
            // textBox8
            // 
            textBox8.Location = new System.Drawing.Point(47, 41);
            textBox8.Name = "textBox8";
            textBox8.ReadOnly = true;
            textBox8.Size = new System.Drawing.Size(77, 20);
            textBox8.TabIndex = 15;
            // 
            // button13
            // 
            button13.BackColor = System.Drawing.Color.MediumSpringGreen;
            button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            button13.Location = new System.Drawing.Point(129, 255);
            button13.Name = "button13";
            button13.Size = new System.Drawing.Size(91, 34);
            button13.TabIndex = 11;
            button13.Text = "Расчитать";
            button13.UseVisualStyleBackColor = false;
            button13.Click += new System.EventHandler(Calculate_Click);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            label5.Location = new System.Drawing.Point(13, 133);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(14, 13);
            label5.TabIndex = 10;
            label5.Text = "3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            label4.Location = new System.Drawing.Point(11, 94);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(14, 13);
            label4.TabIndex = 9;
            label4.Text = "2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            label3.Location = new System.Drawing.Point(12, 53);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(14, 13);
            label3.TabIndex = 8;
            label3.Text = "1";
            // 
            // textBox6
            // 
            textBox6.Location = new System.Drawing.Point(204, 149);
            textBox6.Name = "textBox6";
            textBox6.Size = new System.Drawing.Size(100, 20);
            textBox6.TabIndex = 7;
            textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            textBox5.Location = new System.Drawing.Point(204, 110);
            textBox5.Name = "textBox5";
            textBox5.Size = new System.Drawing.Size(100, 20);
            textBox5.TabIndex = 6;
            textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(203, 52);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(100, 20);
            textBox4.TabIndex = 5;
            textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(32, 130);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new System.Drawing.Size(98, 20);
            textBox3.TabIndex = 4;
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(32, 91);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(98, 20);
            textBox2.TabIndex = 3;
            textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(32, 51);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(98, 20);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label2.Location = new System.Drawing.Point(194, 25);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(116, 13);
            label2.TabIndex = 1;
            label2.Text = "Угол, гр°мин′сек″";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label1.Location = new System.Drawing.Point(10, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(112, 13);
            label1.TabIndex = 0;
            label1.Text = "Выбранные точки";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox3.Controls.Add(button7);
            groupBox3.Controls.Add(button9);
            groupBox3.Controls.Add(button12);
            groupBox3.Controls.Add(button8);
            groupBox3.Controls.Add(button11);
            groupBox3.Controls.Add(button6);
            groupBox3.ForeColor = System.Drawing.Color.Black;
            groupBox3.Location = new System.Drawing.Point(7, 15);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(337, 207);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Добавление точки следующими методами";
            // 
            // button7
            // 
            button7.BackColor = System.Drawing.Color.White;
            button7.Location = new System.Drawing.Point(6, 76);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(153, 55);
            button7.TabIndex = 1;
            button7.Text = "Метод полярной засечки";
            button7.UseVisualStyleBackColor = false;
            button7.Click += new System.EventHandler(AngleResect_Click);
            // 
            // button9
            // 
            button9.BackColor = System.Drawing.Color.White;
            button9.Location = new System.Drawing.Point(184, 76);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(149, 55);
            button9.TabIndex = 3;
            button9.Text = "Метод обратной полярной (угловой) засечки";
            button9.UseVisualStyleBackColor = false;
            button9.Click += new System.EventHandler(InverseResection_Click);
            // 
            // button12
            // 
            button12.BackColor = System.Drawing.Color.Salmon;
            button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button12.Location = new System.Drawing.Point(184, 152);
            button12.Name = "button12";
            button12.Size = new System.Drawing.Size(149, 48);
            button12.TabIndex = 6;
            button12.Text = "Удалить Точку";
            button12.UseVisualStyleBackColor = false;
            button12.Click += new System.EventHandler(PointDelete_Click);
            // 
            // button8
            // 
            button8.BackColor = System.Drawing.Color.White;
            button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button8.Location = new System.Drawing.Point(184, 19);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(147, 49);
            button8.TabIndex = 2;
            button8.Text = "Метод линейной засечки";
            button8.UseVisualStyleBackColor = false;
            button8.Click += new System.EventHandler(LinearResect_Click);
            // 
            // button11
            // 
            button11.BackColor = System.Drawing.Color.White;
            button11.Location = new System.Drawing.Point(6, 152);
            button11.Name = "button11";
            button11.Size = new System.Drawing.Size(153, 49);
            button11.TabIndex = 5;
            button11.Text = "Информация о точке и исправление";
            button11.UseVisualStyleBackColor = false;
            button11.Click += new System.EventHandler(PointInfo_Click);
            // 
            // button6
            // 
            button6.BackColor = System.Drawing.Color.White;
            button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button6.Location = new System.Drawing.Point(6, 20);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(153, 48);
            button6.TabIndex = 0;
            button6.Text = "Метод перпендикуляров";
            button6.UseVisualStyleBackColor = false;
            button6.Click += new System.EventHandler(Perpendicular_Click);
            // 
            // groupBox2
            // 
            groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button2);
            groupBox2.ForeColor = System.Drawing.Color.Black;
            groupBox2.Location = new System.Drawing.Point(12, 8);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(657, 50);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Панель навигации";
            // 
            // button5
            // 
            button5.BackColor = System.Drawing.Color.White;
            button5.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.MoveIcon1;
            button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            button5.Location = new System.Drawing.Point(171, 19);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(58, 31);
            button5.TabIndex = 3;
            button5.UseVisualStyleBackColor = false;
            button5.Click += new System.EventHandler(Move_Click);
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.White;
            button2.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.SelectBoX1;
            button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            button2.Location = new System.Drawing.Point(6, 19);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(71, 31);
            button2.TabIndex = 0;
            button2.UseVisualStyleBackColor = false;
            button2.Click += new System.EventHandler(SelectBox_Click);
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.White;
            button4.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.ZoomOutIcon;
            button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button4.Location = new System.Drawing.Point(125, 19);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(40, 31);
            button4.TabIndex = 2;
            button4.UseVisualStyleBackColor = false;
            button4.Click += new System.EventHandler(ZoomOut_Click);
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.White;
            button3.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.zoomIn;
            button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button3.Location = new System.Drawing.Point(81, 19);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(38, 31);
            button3.TabIndex = 1;
            button3.UseVisualStyleBackColor = false;
            button3.Click += new System.EventHandler(ZoomIn_Click);
            // 
            // AddPnt
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1037, 719);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(panel7);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddPnt";
            Text = "Добавление точек";
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);

        }
        #endregion
    }
}