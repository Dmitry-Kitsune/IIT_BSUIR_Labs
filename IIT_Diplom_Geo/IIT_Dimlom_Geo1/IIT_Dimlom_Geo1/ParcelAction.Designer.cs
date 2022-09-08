using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class ParcelAction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;
        private IContainer components;
        private Panel panel7;
        private GroupBox groupBox1;
        private Button button1;
        private GroupBox groupBox2;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private GroupBox groupBox3;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button11;
        private Button button10;
        private Button button9;
        private GroupBox groupBox6;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private TextBox textBox4;
        private GroupBox groupBox7;
        private Button button12;
        private Button button13;
        private GroupBox groupBox8;
        private Button button15;
        private Button button14;
        private Button button18;
        private Button button19;
        private TextBox textBox6;
        private TextBox textBox5;
        private Label label5;
        private Button button20;
        private Button button21;
        private Button button23;
        private Button button22;
        private GroupBox groupBox9;
        private Button button24;
        private Button button25;
        private Button button26;
        private Button button30;
        private Button button29;
        private Button button31;
        private Button button17;
        private GroupBox groupBox10;
        private Label label6;
        private StatusBar statusBar1 = new StatusBar();
        private StatusBarPanel panel1 = new StatusBarPanel();
        private StatusBarPanel panel2 = new StatusBarPanel();
        private StatusBarPanel panel3 = new StatusBarPanel();
        private StatusBarPanel panel4 = new StatusBarPanel();
        private StatusBarPanel panel5 = new StatusBarPanel();
        private StatusBarPanel panel6 = new StatusBarPanel();
        private Rectangle RcDraw;
        private Rectangle RcBox;
        private Rectangle[] RcPnt = new Rectangle[1000];
        private Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        private Point startPoint;
        private Point endPoint;
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button17 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button22 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button30 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button29 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button19 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button25 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Location = new System.Drawing.Point(12, 71);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(644, 685);
            this.panel7.TabIndex = 0;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown);
            this.panel7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseMove);
            this.panel7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(662, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 756);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия с участками";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox5.Controls.Add(this.button11);
            this.groupBox5.Controls.Add(this.button10);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(9, 152);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(360, 126);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Разделение участка с выбранной перпендикулярной линией";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(7, 82);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(347, 37);
            this.button11.TabIndex = 2;
            this.button11.Text = "Процент от выбранного участка слева от перпендикуляра";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.PerpendicularPercent_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(186, 36);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(168, 40);
            this.button10.TabIndex = 1;
            this.button10.Text = "Разделение пополам выбранной линии по перпендикуляру";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.PerpendicularLine_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(7, 36);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(173, 40);
            this.button9.TabIndex = 0;
            this.button9.Text = "Площадь (кв.м) слева от перпендикуляра";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.PerpendicularMetre_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox9.Controls.Add(this.button17);
            this.groupBox9.Controls.Add(this.button31);
            this.groupBox9.Controls.Add(this.button26);
            this.groupBox9.Controls.Add(this.button24);
            this.groupBox9.ForeColor = System.Drawing.Color.Black;
            this.groupBox9.Location = new System.Drawing.Point(9, 429);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(360, 100);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Объединение участков";
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.White;
            this.button17.ForeColor = System.Drawing.Color.Black;
            this.button17.Location = new System.Drawing.Point(225, 55);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(129, 39);
            this.button17.TabIndex = 5;
            this.button17.Text = "Список узлов";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.NodeList_Click);
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.Color.White;
            this.button31.ForeColor = System.Drawing.Color.Black;
            this.button31.Location = new System.Drawing.Point(6, 55);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(204, 39);
            this.button31.TabIndex = 4;
            this.button31.Text = "Удаление внутреннего участка";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.ParcelDelete_Click);
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.White;
            this.button26.ForeColor = System.Drawing.Color.Black;
            this.button26.Location = new System.Drawing.Point(216, 13);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(141, 36);
            this.button26.TabIndex = 1;
            this.button26.Text = "Объединить все участки";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.UnifyAllParcels_Click);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.White;
            this.button24.ForeColor = System.Drawing.Color.Black;
            this.button24.Location = new System.Drawing.Point(2, 13);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(208, 36);
            this.button24.TabIndex = 0;
            this.button24.Text = "Выделить соседние учестки с помощью мыши";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.UnificationParcels_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox8.Controls.Add(this.button22);
            this.groupBox8.Controls.Add(this.button15);
            this.groupBox8.Controls.Add(this.button14);
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(9, 529);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(360, 64);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Дополнительные опции";
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.OrangeRed;
            this.button22.ForeColor = System.Drawing.Color.White;
            this.button22.Location = new System.Drawing.Point(251, 19);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(103, 39);
            this.button22.TabIndex = 5;
            this.button22.Text = "Удалить все действия";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.AllActionsRemove_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(98, 19);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(147, 39);
            this.button15.TabIndex = 1;
            this.button15.Text = "Удалить последнее действие";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.LastRemove_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(3, 19);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(91, 39);
            this.button14.TabIndex = 0;
            this.button14.Text = "Информация об участке";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.GetInfo_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox7.Controls.Add(this.button30);
            this.groupBox7.Controls.Add(this.button21);
            this.groupBox7.Controls.Add(this.button20);
            this.groupBox7.Controls.Add(this.button13);
            this.groupBox7.Controls.Add(this.button12);
            this.groupBox7.ForeColor = System.Drawing.Color.Black;
            this.groupBox7.Location = new System.Drawing.Point(9, 284);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(360, 139);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Действия с участками с использованием графики";
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.White;
            this.button30.Location = new System.Drawing.Point(186, 110);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(115, 22);
            this.button30.TabIndex = 4;
            this.button30.Text = "Отменить выбор";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.Unselect_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.White;
            this.button21.Location = new System.Drawing.Point(40, 110);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(101, 23);
            this.button21.TabIndex = 3;
            this.button21.Text = "Продолжить";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.Continue_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.White;
            this.button20.Location = new System.Drawing.Point(6, 69);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(351, 35);
            this.button20.TabIndex = 2;
            this.button20.Text = "Разделение или слияние с замкнутой линией проектирования";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.DevideUnify_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(6, 14);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(163, 49);
            this.button13.TabIndex = 1;
            this.button13.Text = "Разделение со всеми линиями проектирования";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.DesignAllLines_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(175, 14);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(182, 49);
            this.button12.TabIndex = 0;
            this.button12.Text = "Разделение любой (открытой или закрытой) линией проектирования";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.DesignLine_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox6.Controls.Add(this.button29);
            this.groupBox6.Controls.Add(this.textBox6);
            this.groupBox6.Controls.Add(this.textBox5);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.button19);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.textBox4);
            this.groupBox6.Controls.Add(this.textBox3);
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(9, 593);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(360, 157);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Информация об участках";
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.White;
            this.button29.Location = new System.Drawing.Point(194, 128);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(107, 23);
            this.button29.TabIndex = 12;
            this.button29.Text = "Отменить";
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.Abolish_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(251, 55);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(96, 20);
            this.textBox6.TabIndex = 11;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(139, 56);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(106, 20);
            this.textBox5.TabIndex = 10;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(8, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Сумма площ.\r\n внутренних участк.";
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.White;
            this.button19.Location = new System.Drawing.Point(26, 128);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(107, 23);
            this.button19.TabIndex = 8;
            this.button19.Text = "Подтвердить";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(25, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Площадь, \r\nкв.м";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(137, 97);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(112, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(251, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(96, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(139, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(106, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(58, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(248, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Допуст. площ.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(134, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Расчетная площ.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(6, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 216);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дествия с участками без использования моделирования (дизайна)";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(3, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(360, 96);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Разделение участка с выбранной параллельной линией";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(232, 36);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(122, 51);
            this.button8.TabIndex = 2;
            this.button8.Text = "Процент от выбранного участка";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.ParallelPercent_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(118, 36);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(108, 51);
            this.button7.TabIndex = 1;
            this.button7.Text = "Расстояние (м) между линиями";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.ParallelDistance_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(7, 36);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(105, 51);
            this.button6.TabIndex = 0;
            this.button6.Text = "Площадь (кв.м) между линиями";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.ParallelMetre_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox10.Controls.Add(this.button25);
            this.groupBox10.Controls.Add(this.button23);
            this.groupBox10.Controls.Add(this.button18);
            this.groupBox10.Controls.Add(this.button1);
            this.groupBox10.ForeColor = System.Drawing.Color.Black;
            this.groupBox10.Location = new System.Drawing.Point(206, 0);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(450, 65);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Модель";
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.White;
            this.button25.Location = new System.Drawing.Point(84, 19);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(100, 37);
            this.button25.TabIndex = 7;
            this.button25.Text = "Проектные линии вкл/выкл";
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.DesignLineOnOff_Click);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.White;
            this.button23.Location = new System.Drawing.Point(6, 19);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(72, 37);
            this.button23.TabIndex = 6;
            this.button23.Text = "Точки вкл/выкл";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.PointOnOff_Click);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.White;
            this.button18.Location = new System.Drawing.Point(190, 19);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(134, 37);
            this.button18.TabIndex = 4;
            this.button18.Text = "Отмененные линии и участки вкл./выкл.";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.CancelParcelOnOff_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(1, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Панель навигации";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.MoveIcon1;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.Location = new System.Drawing.Point(144, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 39);
            this.button5.TabIndex = 3;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Move_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.ZoomOutIcon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(101, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 37);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.zoomIn;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(57, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 37);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.SelectBoX1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(5, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 37);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.SelectBox_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OrangeRed;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(340, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Закрыть окно";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(12, 763);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "-";
            // 
            // ParcelAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1040, 789);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParcelAction";
            this.Text = "Действия с площадями";
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}