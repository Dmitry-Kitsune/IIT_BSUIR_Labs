namespace IIT_Diplom_Geo1
{
    partial class CreateNewProj
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            textBox1 = new System.Windows.Forms.TextBox();
            listBox1 = new System.Windows.Forms.ListBox();
            textBox2 = new System.Windows.Forms.TextBox();
            Confirm = new System.Windows.Forms.Button();
            Quit = new System.Windows.Forms.Button();
            textBoxNewProjName = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(219, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(148, 20);
            textBox1.TabIndex = 0;
            textBox1.Text = "Существующие проекты:";
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new System.Drawing.Point(39, 38);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(511, 368);
            listBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(161, 410);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(294, 20);
            textBox2.TabIndex = 2;
            textBox2.Text = "Введите имя нового проекта";
            textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Confirm
            // 
            Confirm.Location = new System.Drawing.Point(82, 480);
            Confirm.Name = "Confirm";
            Confirm.Size = new System.Drawing.Size(105, 23);
            Confirm.TabIndex = 3;
            Confirm.Text = "Подтвердить";
            Confirm.UseVisualStyleBackColor = true;
            Confirm.Click += new System.EventHandler(Confirm_Click);
            // 
            // Quit
            // 
            Quit.Location = new System.Drawing.Point(454, 480);
            Quit.Name = "Quit";
            Quit.Size = new System.Drawing.Size(75, 23);
            Quit.TabIndex = 4;
            Quit.Text = "Выход";
            Quit.UseVisualStyleBackColor = true;
            Quit.Click += new System.EventHandler(Quit_Click);
            // 
            // textBoxNewProjName
            // 
            textBoxNewProjName.Location = new System.Drawing.Point(82, 436);
            textBoxNewProjName.Name = "textBoxNewProjName";
            textBoxNewProjName.Size = new System.Drawing.Size(447, 20);
            textBoxNewProjName.TabIndex = 5;
            // 
            // CreateNewProj
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(593, 541);
            Controls.Add(textBoxNewProjName);
            Controls.Add(Quit);
            Controls.Add(Confirm);
            Controls.Add(textBox2);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateNewProj";
            Text = "Создание нового проекта";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.TextBox textBoxNewProjName;
    }
}