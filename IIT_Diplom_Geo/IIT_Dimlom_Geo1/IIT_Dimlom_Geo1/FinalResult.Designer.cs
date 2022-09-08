using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class FinalResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;
        private IContainer components;
        private StatusBar statusBar1 = new StatusBar();
        private StatusBarPanel panel1 = new StatusBarPanel();
        private StatusBarPanel panel2 = new StatusBarPanel();
        private StatusBarPanel panel3 = new StatusBarPanel();
        private StatusBarPanel panel4 = new StatusBarPanel();
        private StatusBarPanel panel5 = new StatusBarPanel();
        private StatusBarPanel panel6 = new StatusBarPanel();
        private Rectangle RcDraw;
        private Rectangle RcBox;
        private Rectangle[] RcPnt = new Rectangle[200];
        private Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        private Point startPoint;
        private Point endPoint;
        private GroupBox groupBox1;
        private Button button1;
        private Panel panel7;
        private GroupBox groupBox2;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private GroupBox groupBox3;
        private Button button7;
        private Button button6;
        private Button button9;
        private Button button8;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private GroupBox groupBox4;
        private Button button11;
        private Button button10;
        private TextBox textBox6;
        private TextBox textBox5;
        private Label label6;
        private Label label5;
        private Button button13;
        private Button button12;
        private GroupBox groupBox5;
        private Button button16;
        private Button button14;
        private GroupBox groupBox6;
        private Button button20;
        private Button button19;
        private Button button21;
        private TextBox textBox7;
        private Label label7;
        private Button button23;
        private Button button22;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ComboBox comboBox1;
        private Label label8;
        private GroupBox groupBox7;
        private Button button28;
        private GroupBox groupBox9;
        private Button button30;
        private Button button29;
        private Button button31;
        private Button button17;
        private GroupBox groupBox10;
        private TextBox textBox8;
        private Label label10;
        private Button button26;
        private Button button25;
        private Button button24;
        private Button button33;
        private Button button34;
        private GroupBox groupBox11;
        private Button button32;
        private Button button18;
        private Button button15;
        private Label label3;
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
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.button32 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button24 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button26 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button17 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button23 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button34 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button33 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button31 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.groupBox11);
            this.groupBox1.Controls.Add(this.groupBox10);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(678, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 680);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox11.Controls.Add(this.button32);
            this.groupBox11.Controls.Add(this.button18);
            this.groupBox11.Controls.Add(this.button15);
            this.groupBox11.ForeColor = System.Drawing.Color.Black;
            this.groupBox11.Location = new System.Drawing.Point(6, 584);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(319, 90);
            this.groupBox11.TabIndex = 10;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Установить дополнительный символ";
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.White;
            this.button32.Location = new System.Drawing.Point(8, 62);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(304, 23);
            this.button32.TabIndex = 2;
            this.button32.Text = "Удалить все добавленные символы";
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.AllItemDel_Click);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.White;
            this.button18.Location = new System.Drawing.Point(136, 19);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(176, 37);
            this.button18.TabIndex = 1;
            this.button18.Text = "Удалить последный добавленный символ";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.LastItem_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(6, 19);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(124, 37);
            this.button15.TabIndex = 0;
            this.button15.Text = "Выбрать символ из списка";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.ListItems_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox10.Controls.Add(this.button24);
            this.groupBox10.Controls.Add(this.textBox8);
            this.groupBox10.Controls.Add(this.label10);
            this.groupBox10.Controls.Add(this.button26);
            this.groupBox10.Controls.Add(this.button25);
            this.groupBox10.ForeColor = System.Drawing.Color.Black;
            this.groupBox10.Location = new System.Drawing.Point(8, 12);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(319, 65);
            this.groupBox10.TabIndex = 9;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Исправление символов точек";
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.White;
            this.button24.Location = new System.Drawing.Point(239, 22);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(75, 36);
            this.button24.TabIndex = 4;
            this.button24.Text = "Помощь (Help)";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.HelpPoints_Click);
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.White;
            this.textBox8.Location = new System.Drawing.Point(75, 38);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(65, 20);
            this.textBox8.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(72, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Код символа";
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.White;
            this.button26.Location = new System.Drawing.Point(146, 22);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(92, 36);
            this.button26.TabIndex = 1;
            this.button26.Text = "Подтвердить изменения";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.PointConfirm_Click);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.White;
            this.button25.Location = new System.Drawing.Point(5, 22);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(66, 36);
            this.button25.TabIndex = 0;
            this.button25.Text = "Выбрать точку";
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.PointSelect_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox9.Controls.Add(this.button17);
            this.groupBox9.Controls.Add(this.button30);
            this.groupBox9.Controls.Add(this.button29);
            this.groupBox9.ForeColor = System.Drawing.Color.Black;
            this.groupBox9.Location = new System.Drawing.Point(7, 428);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(320, 40);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Надписи точек";
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.White;
            this.button17.Location = new System.Drawing.Point(229, 14);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(85, 23);
            this.button17.TabIndex = 2;
            this.button17.Text = "Удалить точку";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.PointDelete_Click);
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.White;
            this.button30.Location = new System.Drawing.Point(76, 14);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(150, 23);
            this.button30.TabIndex = 1;
            this.button30.Text = "Горизонтальное/Вертикальное смещение";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.HorVerPnt_Click);
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.White;
            this.button29.Location = new System.Drawing.Point(7, 14);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(65, 23);
            this.button29.TabIndex = 0;
            this.button29.Text = "Переместить";
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.MoveNamePnt_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox7.Controls.Add(this.button19);
            this.groupBox7.Controls.Add(this.button20);
            this.groupBox7.ForeColor = System.Drawing.Color.Black;
            this.groupBox7.Location = new System.Drawing.Point(6, 368);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(323, 54);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Надписи полигонов";
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.White;
            this.button19.Location = new System.Drawing.Point(9, 14);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(99, 34);
            this.button19.TabIndex = 0;
            this.button19.Text = "Переместить";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.InscriptionMove_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.White;
            this.button20.Location = new System.Drawing.Point(114, 14);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(202, 34);
            this.button20.TabIndex = 1;
            this.button20.Text = "Горизонтальное/Вертикальное смещение надписей";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.HorizontalVertical_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.comboBox1);
            this.groupBox6.Controls.Add(this.radioButton2);
            this.groupBox6.Controls.Add(this.radioButton1);
            this.groupBox6.Controls.Add(this.button23);
            this.groupBox6.Controls.Add(this.button22);
            this.groupBox6.Controls.Add(this.button21);
            this.groupBox6.Controls.Add(this.textBox7);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(7, 474);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(320, 104);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Дополнительные надписи";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label8.Location = new System.Drawing.Point(257, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Цвет";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(228, 77);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(90, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.radioButton2.Location = new System.Drawing.Point(124, 81);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(102, 17);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Вертикально";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.radioButton1.Location = new System.Drawing.Point(6, 81);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(115, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Горизонтально";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.White;
            this.button23.Location = new System.Drawing.Point(228, 14);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(86, 38);
            this.button23.TabIndex = 6;
            this.button23.Text = "Удалить";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.AddRemove_Click);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.White;
            this.button22.Location = new System.Drawing.Point(124, 14);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(98, 38);
            this.button22.TabIndex = 5;
            this.button22.Text = "Переместить";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.AddMoving_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.White;
            this.button21.Location = new System.Drawing.Point(6, 14);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(115, 38);
            this.button21.TabIndex = 4;
            this.button21.Text = "Добавить надпись";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.AddInscript_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(115, 58);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(107, 20);
            this.textBox7.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label7.Location = new System.Drawing.Point(6, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Введите надпись";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.button34);
            this.groupBox4.Controls.Add(this.button13);
            this.groupBox4.Controls.Add(this.button12);
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(6, 196);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(323, 166);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Исправление названий и символов участков";
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.White;
            this.button34.Location = new System.Drawing.Point(240, 135);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(72, 22);
            this.button34.TabIndex = 9;
            this.button34.Text = "Помощь";
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.HelpPolygons_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(114, 135);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(95, 22);
            this.button13.TabIndex = 8;
            this.button13.Text = "Отменить";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(6, 135);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(82, 22);
            this.button12.TabIndex = 7;
            this.button12.Text = "Сохранить";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.Save_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(233, 103);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(76, 20);
            this.textBox6.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(77, 103);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(81, 20);
            this.textBox5.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.Location = new System.Drawing.Point(170, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 26);
            this.label6.TabIndex = 4;
            this.label6.Text = "Символ\r\n участка";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Location = new System.Drawing.Point(3, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "Название \r\nучастка";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(7, 63);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(305, 34);
            this.button11.TabIndex = 1;
            this.button11.Text = "Изменение названий и символов участков с помощью выделения";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.NameSymbGraph_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(6, 17);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(307, 40);
            this.button10.TabIndex = 0;
            this.button10.Text = "Изменение названий и символов участков с помощью списка";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.NameSymbol_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Controls.Add(this.button33);
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(6, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(321, 114);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Исправление линий";
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.Color.White;
            this.button33.Location = new System.Drawing.Point(199, 82);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(117, 27);
            this.button33.TabIndex = 12;
            this.button33.Text = "Помощь";
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.HelpLines_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(118, 82);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 26);
            this.button9.TabIndex = 11;
            this.button9.Text = "Отменить";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.Delay_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(6, 83);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(106, 26);
            this.button8.TabIndex = 10;
            this.button8.Text = "Подтвердить";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(249, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(64, 20);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(64, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Location = new System.Drawing.Point(161, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ширина, м\r\nмасштаб \r\nизображения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Location = new System.Drawing.Point(8, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ваш код";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(161, 15);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(155, 22);
            this.button7.TabIndex = 1;
            this.button7.Text = "Изменить направление линии";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.LineDirection_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(6, 15);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(141, 22);
            this.button6.TabIndex = 0;
            this.button6.Text = "Изменить символ линии";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.LineSymbol_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(339, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Закрыть окно";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Exit_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox5.Controls.Add(this.button31);
            this.groupBox5.Controls.Add(this.button28);
            this.groupBox5.Controls.Add(this.button16);
            this.groupBox5.Controls.Add(this.button14);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(213, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(459, 57);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Отображение";
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.Color.White;
            this.button31.Location = new System.Drawing.Point(97, 18);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(69, 35);
            this.button31.TabIndex = 6;
            this.button31.Text = "Высоты Вкл/Выкл";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.HeightsOnOff_Click);
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.Color.White;
            this.button28.Location = new System.Drawing.Point(172, 18);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(76, 35);
            this.button28.TabIndex = 5;
            this.button28.Text = "Контуры Вкл/Выкл";
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.ContoursOnOff_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.White;
            this.button16.Location = new System.Drawing.Point(254, 18);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(79, 35);
            this.button16.TabIndex = 2;
            this.button16.Text = "Символы Вкл/Выкл";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.PolySymbol_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(16, 18);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 35);
            this.button14.TabIndex = 0;
            this.button14.Text = "Точки Вкл/Выкл";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.PointsOnOff_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Панель навигации";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.MoveIcon1;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.Location = new System.Drawing.Point(148, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 31);
            this.button5.TabIndex = 3;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Move_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.ZoomOutIcon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(103, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(39, 29);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.zoomIn;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(53, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 29);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.SelectBoX1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(6, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 29);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.SelectBox_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Location = new System.Drawing.Point(12, 63);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(660, 617);
            this.panel7.TabIndex = 1;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown);
            this.panel7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseMove);
            this.panel7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(12, 683);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "-";
            // 
            // FinalResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1010, 718);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinalResult";
            this.Text = "Подготовка окончательных результатов";
            this.groupBox1.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}