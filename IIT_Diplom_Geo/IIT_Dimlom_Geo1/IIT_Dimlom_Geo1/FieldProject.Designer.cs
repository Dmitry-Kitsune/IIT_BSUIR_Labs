using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class FieldProject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;
        private IContainer components;
        private Label label1;
        private Button button1;
        private Button button2;
        private ListBox listBox1;
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
            this.button1 = new Button();
            this.button2 = new Button();
            this.listBox1 = new ListBox();
            this.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Yellow;
            this.label1.Location = new Point(189, 8);
            this.label1.Name = "label1";
            this.label1.Size = new Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Transfer Project";
            this.button1.BackColor = Color.White;
            this.button1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            this.button1.Location = new Point(153, 327);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.Confirm_Click);
            this.button2.BackColor = Color.White;
            this.button2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            this.button2.Location = new Point(269, 327);
            this.button2.Name = "button2";
            this.button2.Size = new Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new EventHandler(this.Cancel_Click);
            this.listBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new Point(12, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(483, 290);
            this.listBox1.TabIndex = 4;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Gray;
            this.ClientSize = new Size(507, 383);
            this.Controls.Add((Control)this.listBox1);
            this.Controls.Add((Control)this.button2);
            this.Controls.Add((Control)this.button1);
            this.Controls.Add((Control)this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FieldProject";
            this.Text = "Field  Projects";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}