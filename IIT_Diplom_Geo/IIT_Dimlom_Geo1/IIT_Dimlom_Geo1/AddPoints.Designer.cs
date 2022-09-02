


using System.Drawing;
using System.Windows.Forms;
using System;

namespace IIT_Dimlom_Geo1
{
    partial class AddPoints
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
       
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

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && components != null)
        //        components.Dispose();
        //    base.Dispose(disposing);
        //}

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
            groupBox5 = new System.Windows.Forms.GroupBox();
            button21 = new System.Windows.Forms.Button();
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
            label6 = new System.Windows.Forms.Label();
            groupBox6 = new System.Windows.Forms.GroupBox();
            radioButton2 = new System.Windows.Forms.RadioButton();
            radioButton1 = new System.Windows.Forms.RadioButton();
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
            button20 = new System.Windows.Forms.Button();
            button12 = new System.Windows.Forms.Button();
            button11 = new System.Windows.Forms.Button();
            button10 = new System.Windows.Forms.Button();
            button9 = new System.Windows.Forms.Button();
            button8 = new System.Windows.Forms.Button();
            button7 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            groupBox7 = new System.Windows.Forms.GroupBox();
            button19 = new System.Windows.Forms.Button();
            button18 = new System.Windows.Forms.Button();
            button17 = new System.Windows.Forms.Button();
            button16 = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            button5 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            label12 = new System.Windows.Forms.Label();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panel7
            // 
            panel7.BackColor = System.Drawing.SystemColors.InactiveBorder;
            panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel7.Location = new System.Drawing.Point(2, 77);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(684, 628);
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
            button1.Location = new System.Drawing.Point(798, 682);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(136, 23);
            button1.TabIndex = 1;
            button1.Text = "Закрыть окно";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(Cancel_Click);
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            groupBox1.ForeColor = System.Drawing.Color.Black;
            groupBox1.Location = new System.Drawing.Point(692, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(336, 673);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добавление точек и Уравнивание";
            // 
            // groupBox4
            // 
            groupBox4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            groupBox4.Controls.Add(groupBox5);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(groupBox6);
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
            groupBox4.Location = new System.Drawing.Point(6, 260);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(324, 403);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Добавление точки";
            // 
            // groupBox5
            // 
            groupBox5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox5.Controls.Add(button21);
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
            groupBox5.Location = new System.Drawing.Point(4, 269);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(314, 124);
            groupBox5.TabIndex = 27;
            groupBox5.TabStop = false;
            groupBox5.Text = "Данные точки";
            // 
            // button21
            // 
            button21.BackColor = System.Drawing.Color.White;
            button21.Location = new System.Drawing.Point(235, 95);
            button21.Name = "button21";
            button21.Size = new System.Drawing.Size(71, 23);
            button21.TabIndex = 26;
            button21.Text = "Помощь";
            button21.UseVisualStyleBackColor = false;
            button21.Click += new System.EventHandler(Help_Click);
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label11.Location = new System.Drawing.Point(182, 65);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(29, 13);
            label11.TabIndex = 25;
            label11.Text = "Код";
            // 
            // textBox7
            // 
            textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox7.Location = new System.Drawing.Point(42, 19);
            textBox7.Name = "textBox7";
            textBox7.Size = new System.Drawing.Size(60, 20);
            textBox7.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label9.Location = new System.Drawing.Point(10, 66);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(26, 13);
            label9.TabIndex = 23;
            label9.Text = "Y =";
            // 
            // button15
            // 
            button15.BackColor = System.Drawing.Color.White;
            button15.Location = new System.Drawing.Point(125, 95);
            button15.Name = "button15";
            button15.Size = new System.Drawing.Size(88, 23);
            button15.TabIndex = 13;
            button15.Text = "Очистить";
            button15.UseVisualStyleBackColor = false;
            button15.Click += new System.EventHandler(CancelSave_Click);
            // 
            // textBox9
            // 
            textBox9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            textBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox9.Location = new System.Drawing.Point(42, 63);
            textBox9.Name = "textBox9";
            textBox9.ReadOnly = true;
            textBox9.Size = new System.Drawing.Size(77, 20);
            textBox9.TabIndex = 16;
            // 
            // button14
            // 
            button14.BackColor = System.Drawing.Color.White;
            button14.Location = new System.Drawing.Point(14, 95);
            button14.Name = "button14";
            button14.Size = new System.Drawing.Size(84, 23);
            button14.TabIndex = 12;
            button14.Text = "Сохранить";
            button14.UseVisualStyleBackColor = false;
            button14.Click += new System.EventHandler(Save_Click);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label7.Location = new System.Drawing.Point(2, 23);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(32, 13);
            label7.TabIndex = 21;
            label7.Text = "Имя";
            // 
            // textBox10
            // 
            textBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox10.Location = new System.Drawing.Point(221, 33);
            textBox10.Name = "textBox10";
            textBox10.Size = new System.Drawing.Size(53, 20);
            textBox10.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label10.Location = new System.Drawing.Point(185, 35);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(26, 13);
            label10.TabIndex = 24;
            label10.Text = "Z =";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label8.Location = new System.Drawing.Point(9, 44);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(26, 13);
            label8.TabIndex = 22;
            label8.Text = "X =";
            // 
            // textBox11
            // 
            textBox11.Location = new System.Drawing.Point(222, 59);
            textBox11.Name = "textBox11";
            textBox11.Size = new System.Drawing.Size(53, 20);
            textBox11.TabIndex = 18;
            // 
            // textBox8
            // 
            textBox8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox8.Location = new System.Drawing.Point(42, 41);
            textBox8.Name = "textBox8";
            textBox8.ReadOnly = true;
            textBox8.Size = new System.Drawing.Size(77, 20);
            textBox8.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(178, 71);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(131, 15);
            label6.TabIndex = 29;
            label6.Text = "Перпенд. длина, м";
            // 
            // groupBox6
            // 
            groupBox6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox6.Controls.Add(radioButton2);
            groupBox6.Controls.Add(radioButton1);
            groupBox6.ForeColor = System.Drawing.Color.Black;
            groupBox6.Location = new System.Drawing.Point(8, 161);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(310, 65);
            groupBox6.TabIndex = 28;
            groupBox6.TabStop = false;
            groupBox6.Text = "Положение новой точки относительно направления 1-2";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            radioButton2.Location = new System.Drawing.Point(187, 36);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(91, 17);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Круг право";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            radioButton1.Location = new System.Drawing.Point(14, 36);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(84, 17);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Круг лево";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            button13.BackColor = System.Drawing.Color.LightGreen;
            button13.Location = new System.Drawing.Point(116, 232);
            button13.Name = "button13";
            button13.Size = new System.Drawing.Size(101, 31);
            button13.TabIndex = 11;
            button13.Text = "Расчитать";
            button13.UseVisualStyleBackColor = false;
            button13.Click += new System.EventHandler(Calculate_Click);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            label5.Location = new System.Drawing.Point(23, 120);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(14, 13);
            label5.TabIndex = 10;
            label5.Text = "3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            label4.Location = new System.Drawing.Point(23, 90);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(14, 13);
            label4.TabIndex = 9;
            label4.Text = "2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            label3.Location = new System.Drawing.Point(18, 55);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(14, 13);
            label3.TabIndex = 8;
            label3.Text = "1";
            // 
            // textBox6
            // 
            textBox6.Location = new System.Drawing.Point(180, 120);
            textBox6.Name = "textBox6";
            textBox6.Size = new System.Drawing.Size(127, 20);
            textBox6.TabIndex = 7;
            textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            textBox5.Location = new System.Drawing.Point(180, 90);
            textBox5.Name = "textBox5";
            textBox5.Size = new System.Drawing.Size(127, 20);
            textBox5.TabIndex = 6;
            textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(179, 48);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(130, 20);
            textBox4.TabIndex = 5;
            textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(44, 120);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new System.Drawing.Size(93, 20);
            textBox3.TabIndex = 4;
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(44, 87);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(93, 20);
            textBox2.TabIndex = 3;
            textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(42, 52);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(94, 20);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(178, 30);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(125, 15);
            label2.TabIndex = 1;
            label2.Text = "Угол, гр°мин′сек″";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(11, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(126, 15);
            label1.TabIndex = 0;
            label1.Text = "Выбранные точки";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox3.Controls.Add(button20);
            groupBox3.Controls.Add(button12);
            groupBox3.Controls.Add(button11);
            groupBox3.Controls.Add(button10);
            groupBox3.Controls.Add(button9);
            groupBox3.Controls.Add(button8);
            groupBox3.Controls.Add(button7);
            groupBox3.Controls.Add(button6);
            groupBox3.Location = new System.Drawing.Point(6, 19);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(324, 235);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            // 
            // button20
            // 
            button20.BackColor = System.Drawing.Color.White;
            button20.Location = new System.Drawing.Point(6, 106);
            button20.Name = "button20";
            button20.Size = new System.Drawing.Size(132, 50);
            button20.TabIndex = 7;
            button20.Text = "Графический способ";
            button20.UseVisualStyleBackColor = false;
            button20.Click += new System.EventHandler(PointGraphicly_Click);
            // 
            // button12
            // 
            button12.BackColor = System.Drawing.Color.White;
            button12.Location = new System.Drawing.Point(210, 185);
            button12.Name = "button12";
            button12.Size = new System.Drawing.Size(100, 37);
            button12.TabIndex = 6;
            button12.Text = "Удаление точки";
            button12.UseVisualStyleBackColor = false;
            button12.Click += new System.EventHandler(PointDelete_Click);
            // 
            // button11
            // 
            button11.BackColor = System.Drawing.Color.White;
            button11.Location = new System.Drawing.Point(6, 185);
            button11.Name = "button11";
            button11.Size = new System.Drawing.Size(142, 37);
            button11.TabIndex = 5;
            button11.Text = "Информация о точке и исправление";
            button11.UseVisualStyleBackColor = false;
            button11.Click += new System.EventHandler(PointInfo_Click);
            // 
            // button10
            // 
            button10.BackColor = System.Drawing.Color.White;
            button10.Location = new System.Drawing.Point(152, 111);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(168, 45);
            button10.TabIndex = 4;
            button10.Text = "Добавить точку в ручную";
            button10.UseVisualStyleBackColor = false;
            button10.Click += new System.EventHandler(InputData_Click);
            // 
            // button9
            // 
            button9.BackColor = System.Drawing.Color.White;
            button9.Location = new System.Drawing.Point(150, 55);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(170, 50);
            button9.TabIndex = 3;
            button9.Text = "Метод обратной полярной засечки";
            button9.UseVisualStyleBackColor = false;
            button9.Click += new System.EventHandler(InverseResection_Click);
            // 
            // button8
            // 
            button8.BackColor = System.Drawing.Color.White;
            button8.Location = new System.Drawing.Point(6, 55);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(131, 45);
            button8.TabIndex = 2;
            button8.Text = "Метод линейных засечек";
            button8.UseVisualStyleBackColor = false;
            button8.Click += new System.EventHandler(LinearResect_Click);
            // 
            // button7
            // 
            button7.BackColor = System.Drawing.Color.White;
            button7.Location = new System.Drawing.Point(150, 10);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(170, 39);
            button7.TabIndex = 1;
            button7.Text = "Метод полярных засечек (угловой метод)";
            button7.UseVisualStyleBackColor = false;
            button7.Click += new System.EventHandler(AngleResect_Click);
            // 
            // button6
            // 
            button6.BackColor = System.Drawing.Color.White;
            button6.Location = new System.Drawing.Point(6, 10);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(131, 39);
            button6.TabIndex = 0;
            button6.Text = "Метод перпендикуляров";
            button6.UseVisualStyleBackColor = false;
            button6.Click += new System.EventHandler(Perpendicular_Click);
            // 
            // groupBox7
            // 
            groupBox7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox7.Controls.Add(button19);
            groupBox7.Controls.Add(button18);
            groupBox7.Controls.Add(button17);
            groupBox7.Controls.Add(button16);
            groupBox7.ForeColor = System.Drawing.Color.Black;
            groupBox7.Location = new System.Drawing.Point(298, 3);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(388, 68);
            groupBox7.TabIndex = 6;
            groupBox7.TabStop = false;
            groupBox7.Text = "Добавление точек в модель";
            // 
            // button19
            // 
            button19.BackColor = System.Drawing.Color.LightCoral;
            button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            button19.Location = new System.Drawing.Point(299, 11);
            button19.Name = "button19";
            button19.Size = new System.Drawing.Size(83, 45);
            button19.TabIndex = 0;
            button19.Text = "Удалить все точки";
            button19.UseVisualStyleBackColor = false;
            button19.Click += new System.EventHandler(AllPointsDelete_Click);
            // 
            // button18
            // 
            button18.BackColor = System.Drawing.Color.DarkSalmon;
            button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            button18.Location = new System.Drawing.Point(219, 11);
            button18.Name = "button18";
            button18.Size = new System.Drawing.Size(74, 45);
            button18.TabIndex = 1;
            button18.Text = "Удалить точку";
            button18.UseVisualStyleBackColor = false;
            button18.Click += new System.EventHandler(DesignPointDelete_Click);
            // 
            // button17
            // 
            button17.BackColor = System.Drawing.Color.White;
            button17.Location = new System.Drawing.Point(110, 11);
            button17.Name = "button17";
            button17.Size = new System.Drawing.Size(103, 49);
            button17.TabIndex = 2;
            button17.Text = "Добавить точку с помощью ввода";
            button17.UseVisualStyleBackColor = false;
            button17.Click += new System.EventHandler(DesignTyping_Click);
            // 
            // button16
            // 
            button16.BackColor = System.Drawing.Color.White;
            button16.Location = new System.Drawing.Point(4, 15);
            button16.Name = "button16";
            button16.Size = new System.Drawing.Size(100, 45);
            button16.TabIndex = 3;
            button16.Text = "Добавить точку графически";
            button16.UseVisualStyleBackColor = false;
            button16.Click += new System.EventHandler(DesitgnGraphicly_Click);
            // 
            // groupBox2
            // 
            groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button4);
            groupBox2.ForeColor = System.Drawing.Color.Black;
            groupBox2.Location = new System.Drawing.Point(2, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(292, 68);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Масштабирование изображения";
            // 
            // button5
            // 
            button5.BackColor = System.Drawing.Color.White;
            button5.Location = new System.Drawing.Point(199, 29);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(91, 23);
            button5.TabIndex = 3;
            button5.Text = "Сместить";
            button5.UseVisualStyleBackColor = false;
            button5.Click += new System.EventHandler(Move_Click);
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.White;
            button2.Location = new System.Drawing.Point(6, 29);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(108, 23);
            button2.TabIndex = 0;
            button2.Text = "Выбрать область";
            button2.UseVisualStyleBackColor = false;
            button2.Click += new System.EventHandler(SelectBox_Click);
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            label12.Location = new System.Drawing.Point(12, 658);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(14, 17);
            label12.TabIndex = 3;
            label12.Text = "-";
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.White;
            button3.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.zoomIn;
            button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button3.Location = new System.Drawing.Point(120, 29);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(34, 23);
            button3.TabIndex = 1;
            button3.UseVisualStyleBackColor = false;
            button3.Click += new System.EventHandler(ZoomIn_Click);
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.White;
            button4.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.ZoomOutIcon;
            button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            button4.Location = new System.Drawing.Point(160, 29);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(33, 23);
            button4.TabIndex = 2;
            button4.UseVisualStyleBackColor = false;
            button4.Click += new System.EventHandler(ZoomOut_Click);
            // 
            // AddPoints
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1040, 717);
            Controls.Add(groupBox7);
            Controls.Add(groupBox2);
            Controls.Add(label12);
            Controls.Add(panel7);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddPoints";
            Text = "Добавление точек";
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17; 
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Button button21;
        private Label label11;
        private TextBox textBox7;
        private Label label9;
        private Button button15;
        private TextBox textBox9;
        private Button button14;
        private Label label7;
        private TextBox textBox10;
        private Label label10;
        private Label label8;
        private TextBox textBox11;
        private TextBox textBox8;
        private Label label6;
        private GroupBox groupBox6;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button13;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;

        //private System.Windows.Forms.ListBox listBox1;
        //private System.Windows.Forms.Button Confirm;
        //private System.Windows.Forms.Button Cancel;
        //private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.Button ChangeDrive;
        //private System.Windows.Forms.Label label3;
        //private System.Windows.Forms.StatusStrip statusStrip1;
        //private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        //private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        //private System.Windows.Forms.RichTextBox richTextBox1;
    }
}