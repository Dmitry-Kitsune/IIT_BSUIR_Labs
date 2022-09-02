using System.Drawing;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class Doubtful
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        ///     private ListBox listBox1;
        private ListBox listBox1;
        private Button button1;
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
            listBox1 = new ListBox();
            button1 = new Button();
            SuspendLayout();
            listBox1.BackColor = Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, 192);
            listBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(10, 8);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(719, 173);
            listBox1.TabIndex = 0;
            button1.BackColor = Color.FromArgb(192, (int)byte.MaxValue, (int)byte.MaxValue);
            button1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            button1.Location = new Point(329, 189);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new EventHandler(Cancel_Click);
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 220);
            Controls.Add((Control)button1);
            Controls.Add((Control)listBox1);
            Name = "Doubtful";
            Text = "Doubtful Measurements Lines";
            ResumeLayout(false);
        }

        #endregion
    }
}