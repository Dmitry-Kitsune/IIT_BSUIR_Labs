using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class GeoCalc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 
        private StatusBar statusBar1 = new StatusBar();
        private StatusBarPanel panel1 = new StatusBarPanel();
        private StatusBarPanel panel2 = new StatusBarPanel();
        private StatusBarPanel panel3 = new StatusBarPanel();
        private StatusBarPanel panel4 = new StatusBarPanel();
        private StatusBarPanel panel5 = new StatusBarPanel();
        private StatusBarPanel panel6 = new StatusBarPanel();
        private Rectangle RcDraw;
        private Rectangle RcBox;
        private Rectangle[] RcPnt = new Rectangle[100];
        private bool isDrag;
        private Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        private Point startPoint;
        private Point endPoint;
        internal PrintPreviewControl PrintPreviewControl1;
        private Panel panel7;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private Label label3;
        private Button button1;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private Button button4;
        private Button button3;
        private Button button2;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button10;
        private GroupBox groupBox5;
        private Button button12;
        private Button button11;
        private Button button16;
        private Button button15;
        private Button button14;
        private Button button13;
        private Button button19;
        private Button button18;
        private GroupBox groupBox8;
        private GroupBox groupBox9;
        private GroupBox groupBox10;
        private RadioButton radioButton9;
        private RadioButton radioButton12;
        private RadioButton radioButton11;
        private RadioButton radioButton10;
        private RadioButton radioButton13;
        private ListBox listBox1;
        private Button button22;
        private Label label8;
        private Button button25;
        private Button button24;
        private Button button23;
        private Button button27;
        private Button button26;
        private Button button28;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private RadioButton radioButton1;
        private RadioButton radioButton15;
        private RadioButton radioButton14;
        private Button button21;
        private Button button30;
        private Button button29;
        private TextBox textBox3;
        private Button button32;
        private Button button31;
        private TextBox textBox4;
        private Button button34;
        private Button button33;
        private Button button20;
        private Label label9;
        private Label label7;
        private GroupBox groupBox6;
        private Button button35;
        private Button button17;


        private System.ComponentModel.IContainer components = null;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button35 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button27 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button28 = new System.Windows.Forms.Button();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button22 = new System.Windows.Forms.Button();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button34 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button30 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button18 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Location = new System.Drawing.Point(14, 71);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(680, 691);
            this.panel7.TabIndex = 0;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown);
            this.panel7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseMove);
            this.panel7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(700, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 766);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox6.Controls.Add(this.button35);
            this.groupBox6.Controls.Add(this.button17);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(6, 448);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(399, 54);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Просмотр(показать)";
            // 
            // button35
            // 
            this.button35.BackColor = System.Drawing.Color.White;
            this.button35.Location = new System.Drawing.Point(184, 19);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(202, 29);
            this.button35.TabIndex = 1;
            this.button35.Text = "ЦММ точки (в разработке)";
            this.button35.UseVisualStyleBackColor = false;
            this.button35.Click += new System.EventHandler(this.DTMPoints_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.White;
            this.button17.Location = new System.Drawing.Point(5, 19);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(154, 29);
            this.button17.TabIndex = 0;
            this.button17.Text = "Базовые точки";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.BasicPoints_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox9.Controls.Add(this.button27);
            this.groupBox9.Controls.Add(this.button26);
            this.groupBox9.Controls.Add(this.button25);
            this.groupBox9.Controls.Add(this.button24);
            this.groupBox9.Controls.Add(this.button23);
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.listBox1);
            this.groupBox9.Controls.Add(this.groupBox10);
            this.groupBox9.ForeColor = System.Drawing.Color.Black;
            this.groupBox9.Location = new System.Drawing.Point(6, 508);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(399, 252);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Опции печати";
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.Color.White;
            this.button27.Location = new System.Drawing.Point(6, 211);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(194, 39);
            this.button27.TabIndex = 7;
            this.button27.Text = "Вернуться на главную панель";
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.MainPanel_Click);
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.White;
            this.button26.Location = new System.Drawing.Point(206, 211);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(184, 39);
            this.button26.TabIndex = 6;
            this.button26.Text = "Распечатать выбранную страницу";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.PrintSelection_Click);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.White;
            this.button25.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.ZoomOutIcon;
            this.button25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button25.Location = new System.Drawing.Point(341, 172);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(49, 35);
            this.button25.TabIndex = 5;
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.PreviewOut_Click);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.White;
            this.button24.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.zoomIn;
            this.button24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button24.Location = new System.Drawing.Point(286, 172);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(49, 35);
            this.button24.TabIndex = 4;
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.PreviewIn_Click);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.White;
            this.button23.Location = new System.Drawing.Point(286, 120);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(104, 47);
            this.button23.TabIndex = 3;
            this.button23.Text = "Подтвердить выбор страницы";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.PreviewSelection_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(6, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(263, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Стр.   xmin     ymin     xmax      ymax    точки";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 136);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(267, 69);
            this.listBox1.TabIndex = 1;
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.button28);
            this.groupBox10.Controls.Add(this.radioButton15);
            this.groupBox10.Controls.Add(this.radioButton14);
            this.groupBox10.Controls.Add(this.radioButton8);
            this.groupBox10.Controls.Add(this.radioButton7);
            this.groupBox10.Controls.Add(this.radioButton1);
            this.groupBox10.Controls.Add(this.button22);
            this.groupBox10.Controls.Add(this.radioButton13);
            this.groupBox10.Controls.Add(this.radioButton12);
            this.groupBox10.Controls.Add(this.radioButton11);
            this.groupBox10.Controls.Add(this.radioButton10);
            this.groupBox10.Controls.Add(this.radioButton9);
            this.groupBox10.Location = new System.Drawing.Point(7, 19);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(389, 98);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(86, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Выберите масштаб и нажмите";
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.Color.White;
            this.button28.ForeColor = System.Drawing.Color.Black;
            this.button28.Location = new System.Drawing.Point(217, 56);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(166, 38);
            this.button28.TabIndex = 3;
            this.button28.Text = "Распечатать данные ЦММ";
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.PrintDTM_Click);
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.BackColor = System.Drawing.Color.White;
            this.radioButton15.Location = new System.Drawing.Point(304, 20);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(64, 17);
            this.radioButton15.TabIndex = 12;
            this.radioButton15.Text = "1:6250";
            this.radioButton15.UseVisualStyleBackColor = false;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.BackColor = System.Drawing.Color.White;
            this.radioButton14.Location = new System.Drawing.Point(229, 20);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(64, 17);
            this.radioButton14.TabIndex = 11;
            this.radioButton14.Text = "1:2500";
            this.radioButton14.UseVisualStyleBackColor = false;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.BackColor = System.Drawing.Color.White;
            this.radioButton8.Location = new System.Drawing.Point(154, 20);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(64, 17);
            this.radioButton8.TabIndex = 10;
            this.radioButton8.Text = "1:1250";
            this.radioButton8.UseVisualStyleBackColor = false;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.BackColor = System.Drawing.Color.White;
            this.radioButton7.Location = new System.Drawing.Point(86, 20);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(57, 17);
            this.radioButton7.TabIndex = 9;
            this.radioButton7.Text = "1:625";
            this.radioButton7.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(18, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 17);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.Text = "1:250";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.White;
            this.button22.Location = new System.Drawing.Point(2, 56);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(207, 38);
            this.button22.TabIndex = 7;
            this.button22.Text = "Распечатать данные геодезии";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.GeoFoundationPrint_Click);
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.BackColor = System.Drawing.Color.White;
            this.radioButton13.Location = new System.Drawing.Point(303, 0);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(64, 17);
            this.radioButton13.TabIndex = 4;
            this.radioButton13.TabStop = true;
            this.radioButton13.Text = "1:5000";
            this.radioButton13.UseVisualStyleBackColor = false;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.BackColor = System.Drawing.Color.White;
            this.radioButton12.Location = new System.Drawing.Point(228, 0);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(64, 17);
            this.radioButton12.TabIndex = 3;
            this.radioButton12.Text = "1:2000";
            this.radioButton12.UseVisualStyleBackColor = false;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.BackColor = System.Drawing.Color.White;
            this.radioButton11.Checked = true;
            this.radioButton11.Location = new System.Drawing.Point(154, 0);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(64, 17);
            this.radioButton11.TabIndex = 2;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "1:1000";
            this.radioButton11.UseVisualStyleBackColor = false;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.BackColor = System.Drawing.Color.White;
            this.radioButton10.Location = new System.Drawing.Point(86, 0);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(57, 17);
            this.radioButton10.TabIndex = 1;
            this.radioButton10.Text = "1:500";
            this.radioButton10.UseVisualStyleBackColor = false;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.BackColor = System.Drawing.Color.White;
            this.radioButton9.Location = new System.Drawing.Point(18, 0);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(57, 17);
            this.radioButton9.TabIndex = 0;
            this.radioButton9.Text = "1:200";
            this.radioButton9.UseVisualStyleBackColor = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Controls.Add(this.button34);
            this.groupBox5.Controls.Add(this.button33);
            this.groupBox5.Controls.Add(this.button20);
            this.groupBox5.Controls.Add(this.button32);
            this.groupBox5.Controls.Add(this.button31);
            this.groupBox5.Controls.Add(this.button12);
            this.groupBox5.Controls.Add(this.button11);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(6, 297);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(399, 145);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Точки Цифровой модели местности ( в разработке)";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(110, 76);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(49, 20);
            this.textBox4.TabIndex = 7;
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.White;
            this.button34.Location = new System.Drawing.Point(268, 61);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(123, 35);
            this.button34.TabIndex = 6;
            this.button34.Text = "Помощь в выборе";
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.DTMhelp_Click);
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.Color.White;
            this.button33.Location = new System.Drawing.Point(165, 61);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(97, 35);
            this.button33.TabIndex = 5;
            this.button33.Text = "Сохранить символ";
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.DTMsymbolSave_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.White;
            this.button20.Location = new System.Drawing.Point(2, 59);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(102, 37);
            this.button20.TabIndex = 4;
            this.button20.Text = "Изменить символ";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.DTMsymbol_Click);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.White;
            this.button32.Location = new System.Drawing.Point(190, 102);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(203, 37);
            this.button32.TabIndex = 3;
            this.button32.Text = "Надпись Вертикально/Горизонтально";
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.DTMinscription_Click);
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.Color.White;
            this.button31.Location = new System.Drawing.Point(0, 102);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(179, 37);
            this.button31.TabIndex = 2;
            this.button31.Text = "Переместить надпись";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.DTMmove_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(268, 19);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(118, 34);
            this.button12.TabIndex = 1;
            this.button12.Text = "Другие измерения";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.AddPoints_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(2, 19);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(260, 34);
            this.button11.TabIndex = 0;
            this.button11.Text = "ЗАГРУЗКА измерений ЦММ из файла";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.InputAllPoints_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox4.Controls.Add(this.button30);
            this.groupBox4.Controls.Add(this.button19);
            this.groupBox4.Controls.Add(this.button29);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.button18);
            this.groupBox4.Controls.Add(this.button21);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(6, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(399, 281);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Загрузка и обработка данных Геодезических изысканий";
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.White;
            this.button30.Location = new System.Drawing.Point(291, 195);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(102, 37);
            this.button30.TabIndex = 22;
            this.button30.Text = "Помощь";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.HelpSelection_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.White;
            this.button19.Location = new System.Drawing.Point(183, 238);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(207, 37);
            this.button19.TabIndex = 1;
            this.button19.Text = "Надписи Вертикально/Горизонтально";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.InscrHorVert_Click);
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.White;
            this.button29.Location = new System.Drawing.Point(183, 195);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(102, 38);
            this.button29.TabIndex = 21;
            this.button29.Text = "Сохранить символ";
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.SymbolSave_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(110, 213);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(67, 20);
            this.textBox3.TabIndex = 20;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.White;
            this.button18.Location = new System.Drawing.Point(5, 238);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(172, 37);
            this.button18.TabIndex = 0;
            this.button18.Text = "Перемещение надписей";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.InscriptionMove_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.White;
            this.button21.Location = new System.Drawing.Point(6, 196);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(98, 37);
            this.button21.TabIndex = 19;
            this.button21.Text = "Изменить символ";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.ChangeSymbol_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox8.Controls.Add(this.radioButton5);
            this.groupBox8.Controls.Add(this.radioButton6);
            this.groupBox8.Controls.Add(this.radioButton2);
            this.groupBox8.Controls.Add(this.radioButton3);
            this.groupBox8.Controls.Add(this.radioButton4);
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(6, 75);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(384, 32);
            this.groupBox8.TabIndex = 18;
            this.groupBox8.TabStop = false;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioButton5.Location = new System.Drawing.Point(215, 10);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(64, 17);
            this.radioButton5.TabIndex = 6;
            this.radioButton5.Text = "1:3000";
            this.radioButton5.UseVisualStyleBackColor = false;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioButton6.Location = new System.Drawing.Point(285, 10);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(64, 17);
            this.radioButton6.TabIndex = 7;
            this.radioButton6.Text = "1:5000";
            this.radioButton6.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "1:500";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioButton3.Location = new System.Drawing.Point(73, 10);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(64, 17);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.Text = "1:1000";
            this.radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioButton4.Location = new System.Drawing.Point(144, 10);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(64, 17);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.Text = "1:2000";
            this.radioButton4.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(310, 170);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(80, 20);
            this.textBox2.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 174);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(191, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Максимальные =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(36, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Средние =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Относительная погрешность:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(324, 108);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 49);
            this.button4.TabIndex = 12;
            this.button4.Text = "Список точек";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.PointsList_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(149, 108);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(169, 49);
            this.button3.TabIndex = 11;
            this.button3.Text = "Список измеренных линий с погрешностями";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.ListLines_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(6, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 49);
            this.button2.TabIndex = 10;
            this.button2.Text = "ПОГРЕШНОСТЬ измерений";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Doubtful_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(380, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Выберите допуск и нажмите кнопку \'Погрешность измерений\'";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(384, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "ЗАГРУЗКА ДАННЫХ ИЗМЕРЕНИЙ из файла(Исходные точки)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.GeoInput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(211, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "                                                                                 " +
    "       ";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button10);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button16);
            this.groupBox3.Controls.Add(this.button15);
            this.groupBox3.Controls.Add(this.button14);
            this.groupBox3.Controls.Add(this.button13);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(682, 69);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Панель навигации";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Red;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(582, 13);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(94, 44);
            this.button10.TabIndex = 2;
            this.button10.Text = "Закрыть окно";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текущий проект";
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.White;
            this.button16.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.MoveIcon1;
            this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button16.Location = new System.Drawing.Point(142, 19);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(47, 32);
            this.button16.TabIndex = 3;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.Move_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.White;
            this.button15.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.ZoomOutIcon;
            this.button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button15.Location = new System.Drawing.Point(91, 19);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(45, 32);
            this.button15.TabIndex = 2;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.White;
            this.button14.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.zoomIn;
            this.button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button14.Location = new System.Drawing.Point(49, 19);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(36, 32);
            this.button14.TabIndex = 1;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.White;
            this.button13.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.SelectBoX1;
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button13.Location = new System.Drawing.Point(7, 19);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(36, 32);
            this.button13.TabIndex = 0;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.SelectBox_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(12, 771);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "  ";
            // 
            // GeoCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1114, 815);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeoCalc";
            this.Text = "Геодезические измерения";
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }            
        #endregion
    }
}