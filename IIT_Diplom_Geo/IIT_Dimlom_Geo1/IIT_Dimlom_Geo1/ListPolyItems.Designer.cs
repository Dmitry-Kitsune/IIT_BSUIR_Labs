using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class ListPolyItems
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;
        private IContainer components;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel1;
        private Label label1;
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
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.panel1 = new Panel();
            this.label1 = new Label();
            this.SuspendLayout();
            this.button1.BackColor = Color.White;
            this.button1.Location = new Point(12, 369);
            this.button1.Name = "button1";
            this.button1.Size = new Size(43, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Up";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.Up_Click);
            this.button2.BackColor = Color.White;
            this.button2.Location = new Point(65, 369);
            this.button2.Name = "button2";
            this.button2.Size = new Size(52, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Down";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new EventHandler(this.Down_Click);
            this.button3.BackColor = Color.White;
            this.button3.Location = new Point((int)sbyte.MaxValue, 369);
            this.button3.Name = "button3";
            this.button3.Size = new Size(41, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Quit";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new EventHandler(this.Quit_Click);
            this.panel1.BackColor = Color.White;
            this.panel1.Location = new Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(156, 328);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDoubleClick += new MouseEventHandler(this.panel1_MouseDoubleClick);
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Silver;
            this.label1.Location = new Point(6, 348);
            this.label1.Name = "label1";
            this.label1.Size = new Size(170, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "DoubleClick appropriate item";
            this.AutoScaleDimensions = new SizeF(7f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(64, 64, 64);
            this.ClientSize = new Size(180, 400);
            this.Controls.Add((Control)this.label1);
            this.Controls.Add((Control)this.panel1);
            this.Controls.Add((Control)this.button3);
            this.Controls.Add((Control)this.button2);
            this.Controls.Add((Control)this.button1);
            this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListPolyItems";
            this.Text = "Items Polygon Listing";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion
    }
}