using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class CadInterval
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;
        private IContainer components;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private RadioButton radioButton9;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private RadioButton radioButton6;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private RadioButton radioButton5;
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
            this.label1 = new Label();
            this.label2 = new Label();
            this.groupBox1 = new GroupBox();
            this.radioButton9 = new RadioButton();
            this.radioButton8 = new RadioButton();
            this.radioButton7 = new RadioButton();
            this.radioButton6 = new RadioButton();
            this.radioButton5 = new RadioButton();
            this.radioButton4 = new RadioButton();
            this.radioButton3 = new RadioButton();
            this.radioButton2 = new RadioButton();
            this.radioButton1 = new RadioButton();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.button1 = new Button();
            this.button2 = new Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.FromArgb(224, 224, 224);
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum Height  = ";
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.FromArgb(224, 224, 224);
            this.label2.Location = new Point(213, 10);
            this.label2.Name = "label2";
            this.label2.Size = new Size(118, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Maximum Height  = ";
            this.groupBox1.BackColor = Color.Silver;
            this.groupBox1.Controls.Add((Control)this.radioButton9);
            this.groupBox1.Controls.Add((Control)this.radioButton8);
            this.groupBox1.Controls.Add((Control)this.radioButton7);
            this.groupBox1.Controls.Add((Control)this.radioButton6);
            this.groupBox1.Controls.Add((Control)this.radioButton5);
            this.groupBox1.Controls.Add((Control)this.radioButton4);
            this.groupBox1.Controls.Add((Control)this.radioButton3);
            this.groupBox1.Controls.Add((Control)this.radioButton2);
            this.groupBox1.Controls.Add((Control)this.radioButton1);
            this.groupBox1.Location = new Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(400, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.radioButton9.AutoSize = true;
            this.radioButton9.BackColor = Color.FromArgb(224, 224, 224);
            this.radioButton9.Location = new Point(316, 67);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new Size(63, 17);
            this.radioButton9.TabIndex = 8;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "25.0 m";
            this.radioButton9.UseVisualStyleBackColor = false;
            this.radioButton8.AutoSize = true;
            this.radioButton8.BackColor = Color.FromArgb(224, 224, 224);
            this.radioButton8.Location = new Point(316, 44);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new Size(63, 17);
            this.radioButton8.TabIndex = 7;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "20.0 m";
            this.radioButton8.UseVisualStyleBackColor = false;
            this.radioButton7.AutoSize = true;
            this.radioButton7.BackColor = Color.FromArgb(224, 224, 224);
            this.radioButton7.Location = new Point(316, 20);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new Size(63, 17);
            this.radioButton7.TabIndex = 6;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "10.0 m";
            this.radioButton7.UseVisualStyleBackColor = false;
            this.radioButton6.AutoSize = true;
            this.radioButton6.BackColor = Color.FromArgb(224, 224, 224);
            this.radioButton6.Location = new Point(170, 68);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new Size(56, 17);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "5.0 m";
            this.radioButton6.UseVisualStyleBackColor = false;
            this.radioButton5.AutoSize = true;
            this.radioButton5.BackColor = Color.FromArgb(224, 224, 224);
            this.radioButton5.Location = new Point(170, 44);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new Size(56, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "2.0 m";
            this.radioButton5.UseVisualStyleBackColor = false;
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = Color.FromArgb(224, 224, 224);
            this.radioButton4.Location = new Point(170, 20);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new Size(56, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "1.0 m";
            this.radioButton4.UseVisualStyleBackColor = false;
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = Color.FromArgb(224, 224, 224);
            this.radioButton3.Location = new Point(16, 68);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new Size(56, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "0.1 m";
            this.radioButton3.UseVisualStyleBackColor = false;
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = Color.FromArgb(224, 224, 224);
            this.radioButton2.Location = new Point(16, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(56, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "0.2 m";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = Color.FromArgb(224, 224, 224);
            this.radioButton1.Location = new Point(16, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(56, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "0.5 m";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.textBox1.Location = new Point(133, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(74, 20);
            this.textBox1.TabIndex = 3;
            this.textBox2.Location = new Point(337, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new Size(75, 20);
            this.textBox2.TabIndex = 4;
            this.button1.BackColor = Color.White;
            this.button1.Location = new Point(103, 134);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.Confirm_Click);
            this.button2.BackColor = Color.White;
            this.button2.Location = new Point(221, 134);
            this.button2.Name = "button2";
            this.button2.Size = new Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Quit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new EventHandler(this.Quit_Click);
            this.AutoScaleDimensions = new SizeF(7f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Gray;
            this.ClientSize = new Size(426, 166);
            this.Controls.Add((Control)this.button2);
            this.Controls.Add((Control)this.button1);
            this.Controls.Add((Control)this.textBox2);
            this.Controls.Add((Control)this.textBox1);
            this.Controls.Add((Control)this.groupBox1);
            this.Controls.Add((Control)this.label2);
            this.Controls.Add((Control)this.label1);
            this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadInterval";
            this.Text = "Select Interval";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}