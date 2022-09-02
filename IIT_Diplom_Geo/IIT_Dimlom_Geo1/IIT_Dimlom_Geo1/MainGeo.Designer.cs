using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace IIT_Dimlom_Geo1
{
    partial class MainGeo
    {
        private StatusBar statusBar1 = new StatusBar();
        private StatusBarPanel panel1 = new StatusBarPanel();
        private StatusBarPanel panel2 = new StatusBarPanel();
        private StatusBarPanel panel3 = new StatusBarPanel();
        private StatusBarPanel panel4 = new StatusBarPanel();
        private StatusBarPanel panel5 = new StatusBarPanel();
        private StatusBarPanel panel6 = new StatusBarPanel();
           
        private GroupBox groupBox1;
        private Button button1;
        private GroupBox groupBox2;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Panel panel7;
        private Label label2;
        private Label label1;
        private Label label3;
        private GroupBox groupBox3;
        private Button button9;
        private Button button8;
        private Button button7;
        private GroupBox groupBox4;
        private Button button10;
        private Button button11;
        private GroupBox groupBox5;
        private Button button12;
        private Label label4;

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
                groupBox1 = new GroupBox();
                label4 = new Label();
                groupBox5 = new GroupBox();
                button12 = new Button();
                groupBox4 = new GroupBox();
                button11 = new Button();
                button10 = new Button();
                groupBox3 = new GroupBox();
                button9 = new Button();
                button8 = new Button();
                button7 = new Button();
                groupBox2 = new GroupBox();
                label2 = new Label();
                label1 = new Label();
                button6 = new Button();
                button5 = new Button();
                button4 = new Button();
                button3 = new Button();
                button2 = new Button();
                button1 = new Button();
                panel7 = new Panel();
                label3 = new Label();
                groupBox1.SuspendLayout();
                groupBox5.SuspendLayout();
                groupBox4.SuspendLayout();
                groupBox3.SuspendLayout();
                groupBox2.SuspendLayout();
                SuspendLayout();
                groupBox1.BackColor = Color.FromArgb(64, 64, 64);
                groupBox1.Controls.Add((Control)label4);
                groupBox1.Controls.Add((Control)groupBox5);
                groupBox1.Controls.Add((Control)groupBox4);
                groupBox1.Controls.Add((Control)groupBox3);
                groupBox1.Controls.Add((Control)groupBox2);
                groupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
                groupBox1.ForeColor = Color.White;
                groupBox1.Location = new Point(691, 12);
                groupBox1.Name = "groupBox1";
                groupBox1.Size = new Size(328, 426);
                groupBox1.TabIndex = 0;
                groupBox1.TabStop = false;
                groupBox1.Text = "Main options";
                label4.BackColor = Color.FromArgb(64, 64, 64);
                label4.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
                label4.Location = new Point(13, 320);
                label4.Name = "label4";
                label4.Size = new Size(303, 90);
                label4.TabIndex = 4;
                label4.Text = "                ";
                groupBox5.BackColor = Color.White;
                groupBox5.Controls.Add((Control)button12);
                groupBox5.ForeColor = Color.Black;
                groupBox5.Location = new Point(7, 237);
                groupBox5.Name = "groupBox5";
                groupBox5.Size = new Size(315, 63);
                groupBox5.TabIndex = 3;
                groupBox5.TabStop = false;
                groupBox5.Text = "Cadastral";
                button12.BackColor = Color.Black;
                button12.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
                button12.ForeColor = Color.White;
                button12.Location = new Point(9, 15);
                button12.Name = "button12";
                button12.Size = new Size(300, 42);
                button12.TabIndex = 0;
                button12.Text = "Cadastral processes";
                button12.UseVisualStyleBackColor = false;
                button12.Click += new EventHandler(Cadastre_Click);
                groupBox4.BackColor = Color.DarkGray;
                groupBox4.Controls.Add((Control)button11);
                groupBox4.Controls.Add((Control)button10);
                groupBox4.ForeColor = Color.Black;
                groupBox4.Location = new Point(7, 163);
                groupBox4.Name = "groupBox4";
                groupBox4.Size = new Size(315, 68);
                groupBox4.TabIndex = 2;
                groupBox4.TabStop = false;
                groupBox4.Text = "Information support";
                button11.BackColor = Color.White;
                button11.Location = new Point(9, 40);
                button11.Name = "button11";
                button11.Size = new Size(300, 23);
                button11.TabIndex = 1;
                button11.Text = "Aerotriangulation";
                button11.UseVisualStyleBackColor = false;
                button11.Click += new EventHandler(Aero_Click);
                button10.BackColor = Color.White;
                button10.Location = new Point(9, 15);
                button10.Name = "button10";
                button10.Size = new Size(300, 23);
                button10.TabIndex = 0;
                button10.Text = "Geodetic calculation";
                button10.UseVisualStyleBackColor = false;
                button10.Click += new EventHandler(Geodesy_Click);
                groupBox3.BackColor = Color.Silver;
                groupBox3.Controls.Add((Control)button9);
                groupBox3.Controls.Add((Control)button8);
                groupBox3.Controls.Add((Control)button7);
                groupBox3.ForeColor = Color.Black;
                groupBox3.Location = new Point(7, 109);
                groupBox3.Name = "groupBox3";
                groupBox3.Size = new Size(314, 44);
                groupBox3.TabIndex = 1;
                groupBox3.TabStop = false;
                groupBox3.Text = "Topographic symbology";
                button9.BackColor = Color.White;
                button9.Location = new Point(233, 17);
                button9.Name = "button9";
                button9.Size = new Size(75, 23);
                button9.TabIndex = 2;
                button9.Text = "Polygons";
                button9.UseVisualStyleBackColor = false;
                button9.Click += new EventHandler(PolygonsSymb_Click);
                button8.BackColor = Color.White;
                button8.Location = new Point(124, 17);
                button8.Name = "button8";
                button8.Size = new Size(75, 23);
                button8.TabIndex = 1;
                button8.Text = "Lines";
                button8.UseVisualStyleBackColor = false;
                button8.Click += new EventHandler(LinesSymb_Click);
                button7.BackColor = Color.White;
                button7.Location = new Point(9, 17);
                button7.Name = "button7";
                button7.Size = new Size(75, 23);
                button7.TabIndex = 0;
                button7.Text = "Points";
                button7.UseVisualStyleBackColor = false;
                button7.Click += new EventHandler(PointsSymb_Click);
                groupBox2.BackColor = Color.Gray;
                groupBox2.Controls.Add((Control)label2);
                groupBox2.Controls.Add((Control)label1);
                groupBox2.Controls.Add((Control)button6);
                groupBox2.Controls.Add((Control)button5);
                groupBox2.Controls.Add((Control)button4);
                groupBox2.Controls.Add((Control)button3);
                groupBox2.Controls.Add((Control)button2);
                groupBox2.ForeColor = Color.Black;
                groupBox2.Location = new Point(7, 14);
                groupBox2.Name = "groupBox2";
                groupBox2.Size = new Size(314, 89);
                groupBox2.TabIndex = 0;
                groupBox2.TabStop = false;
                groupBox2.Text = "Projects support";
                label2.AutoSize = true;
                label2.BackColor = Color.White;
                label2.Location = new Point(6, 69);
                label2.Name = "label2";
                label2.Size = new Size(303, 13);
                label2.TabIndex = 6;
                label2.Text = "                                                                          ";
                label1.AutoSize = true;
                label1.BackColor = Color.Silver;
                label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte)0);
                label1.Location = new Point(108, 55);
                label1.Name = "label1";
                label1.Size = new Size(91, 13);
                label1.TabIndex = 5;
                label1.Text = "Current project";
                button6.BackColor = Color.White;
                button6.Location = new Point(248, 13);
                button6.Name = "button6";
                button6.Size = new Size(60, 35);
                button6.TabIndex = 4;
                button6.Text = "Drive change";
                button6.UseVisualStyleBackColor = false;
                button6.Click += new EventHandler(DiskChange_Click);
                button5.BackColor = Color.White;
                button5.Location = new Point(184, 13);
                button5.Name = "button5";
                button5.Size = new Size(64, 35);
                button5.TabIndex = 3;
                button5.Text = "Projects delete";
                button5.UseVisualStyleBackColor = false;
                button5.Click += new EventHandler(ProjectsDelete_Click);
                button4.BackColor = Color.White;
                button4.Location = new Point(124, 13);
                button4.Name = "button4";
                button4.Size = new Size(60, 35);
                button4.TabIndex = 2;
                button4.Text = "Project delete";
                button4.UseVisualStyleBackColor = false;
                button4.Click += new EventHandler(ProjectDelete_Click);
                button3.BackColor = Color.White;
                button3.Location = new Point(65, 13);
                button3.Name = "button3";
                button3.Size = new Size(59, 35);
                button3.TabIndex = 1;
                button3.Text = "Project select";
                button3.UseVisualStyleBackColor = false;
                button3.Click += new EventHandler(ProjectSelect_Click);
                button2.BackColor = Color.White;
                button2.Location = new Point(7, 13);
                button2.Name = "button2";
                button2.Size = new Size(58, 34);
                button2.TabIndex = 0;
                button2.Text = "Project open";
                button2.UseVisualStyleBackColor = false;
                button2.Click += new EventHandler(ProjectOpen_Click);
                button1.BackColor = Color.Black;
                button1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
                button1.ForeColor = Color.White;
                button1.Location = new Point(810, 652);
                button1.Name = "button1";
                button1.Size = new Size(87, 23);
                button1.TabIndex = 2;
                button1.Text = "Exit";
                button1.UseVisualStyleBackColor = false;
                button1.Click += new EventHandler(Exit_Click);
                panel7.BackColor = Color.White;
                panel7.BorderStyle = BorderStyle.FixedSingle;
                panel7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
                panel7.Location = new Point(14, 12);
                panel7.Name = "panel7";
                panel7.Size = new Size(665, 643);
                panel7.TabIndex = 3;
                panel7.Paint += new PaintEventHandler(panel7_Paint);
                panel7.MouseMove += new MouseEventHandler(panel7_MouseMove);
                label3.AutoSize = true;
                label3.BackColor = Color.Silver;
                label3.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte)0);
                label3.ForeColor = Color.Blue;
                label3.Location = new Point(27, 658);
                label3.Name = "label3";
                label3.Size = new Size(523, 17);
                label3.TabIndex = 4;
                label3.Text = "                                                                                                       ";
                AutoScaleDimensions = new SizeF(7f, 13f);
                AutoScaleMode = AutoScaleMode.Font;
                BackColor = Color.Silver;
                ClientSize = new Size(1018, 702);
                Controls.Add((Control)label3);
                Controls.Add((Control)panel7);
                Controls.Add((Control)button1);
                Controls.Add((Control)groupBox1);
                Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
                MaximizeBox = false;
                MinimizeBox = false;
                Name = "MainGeo";
                Text = "Cadastral problems";
                groupBox1.ResumeLayout(false);
                groupBox5.ResumeLayout(false);
                groupBox4.ResumeLayout(false);
                groupBox3.ResumeLayout(false);
                groupBox2.ResumeLayout(false);
                groupBox2.PerformLayout();
                ResumeLayout(false);
                PerformLayout();
            
        }

        #endregion
    }
}