namespace IIT_Diplom_Geo1
{
    partial class SelectProj
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
            listBox1 = new System.Windows.Forms.ListBox();
            textBox1 = new System.Windows.Forms.TextBox();
            Confirm = new System.Windows.Forms.Button();
            Cancel = new System.Windows.Forms.Button();
            btDelete = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new System.Drawing.Point(49, 38);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(405, 329);
            listBox1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(173, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(148, 20);
            textBox1.TabIndex = 3;
            textBox1.Text = "Существующие проекты:";
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Confirm
            // 
            Confirm.Location = new System.Drawing.Point(49, 388);
            Confirm.Name = "Confirm";
            Confirm.Size = new System.Drawing.Size(105, 23);
            Confirm.TabIndex = 4;
            Confirm.Text = "Подтвердить";
            Confirm.UseVisualStyleBackColor = true;
            Confirm.Click += new System.EventHandler(Confirm_Click);
            // 
            // Cancel
            // 
            Cancel.Location = new System.Drawing.Point(379, 388);
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size(75, 23);
            Cancel.TabIndex = 5;
            Cancel.Text = "Отмена";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += new System.EventHandler(Cancel_Click);
            // 
            // btDelete
            // 
            btDelete.Location = new System.Drawing.Point(216, 388);
            btDelete.Name = "btDelete";
            btDelete.Size = new System.Drawing.Size(105, 23);
            btDelete.TabIndex = 7;
            btDelete.Text = "Удалить";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += new System.EventHandler(btDelete_Click);
            // 
            // SelectProj
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(508, 463);
            Controls.Add(btDelete);
            Controls.Add(Cancel);
            Controls.Add(Confirm);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectProj";
            Text = "Выбор проекта";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button btDelete;
    }
}