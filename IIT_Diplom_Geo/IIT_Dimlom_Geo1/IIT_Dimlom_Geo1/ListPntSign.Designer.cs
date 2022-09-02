using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    partial class ListPntSign
    {
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
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.White;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel1.Location = new System.Drawing.Point(12, 33);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(394, 571);
            panel1.TabIndex = 0;
            panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
            panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(panel1_MouseDoubleClick);
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.White;
            button1.Location = new System.Drawing.Point(12, 637);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(63, 23);
            button1.TabIndex = 1;
            button1.Text = "Вверх один";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(Up_Click);
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.White;
            button2.Location = new System.Drawing.Point(170, 637);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Вниз один";
            button2.UseVisualStyleBackColor = false;
            button2.Click += new System.EventHandler(Down_Click);
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.White;
            button4.Location = new System.Drawing.Point(346, 637);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(60, 23);
            button4.TabIndex = 4;
            button4.Text = "Выход";
            button4.UseVisualStyleBackColor = false;
            button4.Click += new System.EventHandler(Quit_Click);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.Color.Black;
            label6.ForeColor = System.Drawing.Color.White;
            label6.Location = new System.Drawing.Point(115, 618);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(185, 13);
            label6.TabIndex = 5;
            label6.Text = "DoubleClick appropriate symbol";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(18, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(27, 26);
            label1.TabIndex = 6;
            label1.Text = "№\r\nп/п";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Location = new System.Drawing.Point(68, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 13);
            label2.TabIndex = 7;
            label2.Text = "Символ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.Black;
            label3.Location = new System.Drawing.Point(145, 9);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(29, 13);
            label3.TabIndex = 8;
            label3.Text = "Код";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.Black;
            label4.Location = new System.Drawing.Point(197, 4);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(77, 26);
            label4.TabIndex = 9;
            label4.Text = "Ширина/\r\nВысота, мм";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.Black;
            label5.Location = new System.Drawing.Point(302, 9);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(65, 13);
            label5.TabIndex = 10;
            label5.Text = "Описание";
            // 
            // ListPntSign
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(423, 672);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ListPntSign";
            Text = "Список знаков точек";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
                private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button4;
        private Label label6;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}