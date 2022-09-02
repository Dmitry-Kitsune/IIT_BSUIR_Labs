using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class ControlPoints
    {
        private Panel panel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private GroupBox groupBox3;
        private ListBox listBox1;
        private Button button5;
        private TextBox textBox2;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Button button8;
        private Button button7;
        private Button button6;
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            panel1 = new System.Windows.Forms.Panel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            button8 = new System.Windows.Forms.Button();
            button7 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            textBox6 = new System.Windows.Forms.TextBox();
            textBox5 = new System.Windows.Forms.TextBox();
            textBox4 = new System.Windows.Forms.TextBox();
            textBox3 = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            listBox1 = new System.Windows.Forms.ListBox();
            button5 = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.White;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel1.Location = new System.Drawing.Point(12, 64);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(547, 469);
            panel1.TabIndex = 0;
            panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
            panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
            panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(panel1_MouseMove);
            panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(panel1_MouseUp);
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Location = new System.Drawing.Point(565, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(344, 531);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label5.Location = new System.Drawing.Point(7, 434);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(0, 13);
            label5.TabIndex = 3;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            groupBox3.Controls.Add(button8);
            groupBox3.Controls.Add(button7);
            groupBox3.Controls.Add(button6);
            groupBox3.Controls.Add(textBox6);
            groupBox3.Controls.Add(textBox5);
            groupBox3.Controls.Add(textBox4);
            groupBox3.Controls.Add(textBox3);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(listBox1);
            groupBox3.ForeColor = System.Drawing.Color.Black;
            groupBox3.Location = new System.Drawing.Point(6, 9);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(332, 516);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Исправление координат";
            // 
            // button8
            // 
            button8.BackColor = System.Drawing.Color.White;
            button8.Location = new System.Drawing.Point(250, 477);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(75, 23);
            button8.TabIndex = 11;
            button8.Text = "Удалить";
            button8.UseVisualStyleBackColor = false;
            button8.Click += new System.EventHandler(Delete_Click);
            // 
            // button7
            // 
            button7.BackColor = System.Drawing.Color.White;
            button7.Location = new System.Drawing.Point(139, 477);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(75, 23);
            button7.TabIndex = 10;
            button7.Text = "Ввод";
            button7.UseVisualStyleBackColor = false;
            button7.Click += new System.EventHandler(Input_Click);
            // 
            // button6
            // 
            button6.BackColor = System.Drawing.Color.White;
            button6.Location = new System.Drawing.Point(26, 477);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(90, 23);
            button6.TabIndex = 9;
            button6.Text = "Исправить";
            button6.UseVisualStyleBackColor = false;
            button6.Click += new System.EventHandler(Correct_Click);
            // 
            // textBox6
            // 
            textBox6.Location = new System.Drawing.Point(45, 448);
            textBox6.Name = "textBox6";
            textBox6.Size = new System.Drawing.Size(59, 20);
            textBox6.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Location = new System.Drawing.Point(235, 418);
            textBox5.Name = "textBox5";
            textBox5.Size = new System.Drawing.Size(90, 20);
            textBox5.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(128, 418);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(86, 20);
            textBox4.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(45, 418);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(64, 20);
            textBox3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            label4.Location = new System.Drawing.Point(23, 451);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(15, 13);
            label4.TabIndex = 4;
            label4.Text = "Z";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            label3.Location = new System.Drawing.Point(271, 401);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(15, 13);
            label3.TabIndex = 3;
            label3.Text = "Y";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            label2.Location = new System.Drawing.Point(158, 401);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(15, 13);
            label2.TabIndex = 2;
            label2.Text = "X";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            label1.Location = new System.Drawing.Point(7, 418);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 13);
            label1.TabIndex = 1;
            label1.Text = "Имя";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new System.Drawing.Point(6, 19);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(320, 368);
            listBox1.TabIndex = 0;
            // 
            // button5
            // 
            button5.BackColor = System.Drawing.Color.Salmon;
            button5.ForeColor = System.Drawing.Color.White;
            button5.Location = new System.Drawing.Point(821, 539);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(75, 23);
            button5.TabIndex = 1;
            button5.Text = "Выход";
            button5.UseVisualStyleBackColor = false;
            button5.Click += new System.EventHandler(Quit_Click);
            // 
            // groupBox2
            // 
            groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.ForeColor = System.Drawing.Color.Black;
            groupBox2.Location = new System.Drawing.Point(12, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(547, 56);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Навигация";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(565, 543);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(104, 20);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(692, 543);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(108, 20);
            textBox2.TabIndex = 2;
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.White;
            button4.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.MoveIcon1;
            button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button4.Location = new System.Drawing.Point(166, 18);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(45, 32);
            button4.TabIndex = 3;
            button4.UseVisualStyleBackColor = false;
            button4.Click += new System.EventHandler(Move_Click);
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.White;
            button3.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.ZoomOutIcon;
            button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button3.Location = new System.Drawing.Point(116, 18);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(44, 32);
            button3.TabIndex = 2;
            button3.UseVisualStyleBackColor = false;
            button3.Click += new System.EventHandler(ZoomOut_Click);
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.White;
            button2.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.zoomIn;
            button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button2.Location = new System.Drawing.Point(66, 19);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(44, 31);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = false;
            button2.Click += new System.EventHandler(ZoomIn_Click);
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.White;
            button1.BackgroundImage = global::IIT_Dimlom_Geo1.Properties.Resources.SelectBoX1;
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button1.Location = new System.Drawing.Point(15, 19);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(45, 31);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(SelectBox_Click);
            // 
            // ControlPoints
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(921, 566);
            Controls.Add(textBox2);
            Controls.Add(groupBox1);
            Controls.Add(button5);
            Controls.Add(textBox1);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ControlPoints";
            Text = "Архив контрольных точек";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}