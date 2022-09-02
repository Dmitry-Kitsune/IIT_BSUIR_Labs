using System.Drawing;
using System.Windows.Forms;
using System;

namespace IIT_Dimlom_Geo1
{
    partial class ListLineSign
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
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
            panel1 = new Panel();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            SuspendLayout();
            panel1.AutoScroll = true;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Location = new Point(12, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(356, 584);
            panel1.TabIndex = 0;
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.MouseDoubleClick += new MouseEventHandler(panel1_MouseDoubleClick);
            button1.BackColor = Color.White;
            button1.Location = new Point(12, 645);
            button1.Name = "button1";
            button1.Size = new Size(59, 23);
            button1.TabIndex = 1;
            button1.Text = "Up one";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new EventHandler(UpLine_Click);
            button2.BackColor = Color.White;
            button2.Location = new Point(154, 645);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Down one";
            button2.UseVisualStyleBackColor = false;
            button2.Click += new EventHandler(DownLine_Click);
            button4.BackColor = Color.White;
            button4.Location = new Point(325, 645);
            button4.Name = "button4";
            button4.Size = new Size(43, 23);
            button4.TabIndex = 4;
            button4.Text = "Quit";
            button4.UseVisualStyleBackColor = false;
            button4.Click += new EventHandler(Quit_Click);
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(224, 224, 224);
            label5.Location = new Point(87, 629);
            label5.Name = "label5";
            label5.Size = new Size(185, 13);
            label5.TabIndex = 5;
            label5.Text = "DoubleClick appropriate symbol";
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(14, 2);
            label7.Name = "label7";
            label7.Size = new Size(48, 26);
            label7.TabIndex = 6;
            label7.Text = " Serial\r\nnumber";
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(79, 6);
            label8.Name = "label8";
            label8.Size = new Size(47, 13);
            label8.TabIndex = 7;
            label8.Text = "Symbol";
            label9.AutoSize = true;
            label9.ForeColor = Color.White;
            label9.Location = new Point(142, 2);
            label9.Name = "label9";
            label9.Size = new Size(39, 26);
            label9.TabIndex = 8;
            label9.Text = "Users\r\ncode";
            label10.AutoSize = true;
            label10.ForeColor = Color.White;
            label10.Location = new Point(180, 2);
            label10.Name = "label10";
            label10.Size = new Size(47, 26);
            label10.TabIndex = 9;
            label10.Text = "Items\r\ndensity";
            label11.AutoSize = true;
            label11.ForeColor = Color.White;
            label11.Location = new Point(252, 9);
            label11.Name = "label11";
            label11.Size = new Size(71, 13);
            label11.TabIndex = 10;
            label11.Text = "Description";
            AutoScaleDimensions = new SizeF(7f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(380, 675);
            Controls.Add((Control)label11);
            Controls.Add((Control)label10);
            Controls.Add((Control)label9);
            Controls.Add((Control)label8);
            Controls.Add((Control)label7);
            Controls.Add((Control)label5);
            Controls.Add((Control)button4);
            Controls.Add((Control)button2);
            Controls.Add((Control)button1);
            Controls.Add((Control)panel1);
            Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ListLineSign";
            Text = "Listing Lines' Signs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}