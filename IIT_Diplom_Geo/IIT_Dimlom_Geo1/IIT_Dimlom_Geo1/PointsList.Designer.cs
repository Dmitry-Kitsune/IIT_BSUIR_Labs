using System.Drawing;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class PointsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
       
        private ListBox listBox1;
        private Button button1;
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
            listBox1 = new System.Windows.Forms.ListBox();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.BackColor = System.Drawing.SystemColors.Info;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new System.Drawing.Point(12, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(325, 381);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button1.Location = new System.Drawing.Point(129, 398);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(Cancel_Click);
            // 
            // PointsList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonShadow;
            ClientSize = new System.Drawing.Size(349, 433);
            Controls.Add(button1);
            Controls.Add(listBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PointsList";
            Text = "Points\' List";
            ResumeLayout(false);

        }


        #endregion
    }
}