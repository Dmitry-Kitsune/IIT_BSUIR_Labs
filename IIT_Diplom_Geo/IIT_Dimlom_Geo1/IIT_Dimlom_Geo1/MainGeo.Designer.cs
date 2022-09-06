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
        private Panel panel7;
        private Label label2;
        private Label label1;
        private Label label3;
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button6 = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.ToolStripMenuItem();
            this.button5 = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.топографическиеСимволыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button7 = new System.Windows.Forms.ToolStripMenuItem();
            this.button8 = new System.Windows.Forms.ToolStripMenuItem();
            this.button9 = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкаИОбработкаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.геодезическиеВычисленияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.аеротриангуляцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button91 = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 702);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(849, 36);
            this.label4.TabIndex = 4;
            this.label4.Text = "                ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(123, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "                                                                          ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Текущий проект";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(12, 66);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(849, 633);
            this.panel7.TabIndex = 3;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            this.panel7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(13, 738);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(523, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "                                                                                 " +
    "                      ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.топографическиеСимволыToolStripMenuItem,
            this.загрузкаИОбработкаДанныхToolStripMenuItem,
            this.помощьToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(878, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.button6,
            this.button2,
            this.button3,
            this.удалениеToolStripMenuItem,
            this.exit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.файлToolStripMenuItem.Text = "Меню проекта";
            // 
            // button6
            // 
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(180, 22);
            this.button6.Text = "Изменить диск";
            this.button6.Click += new System.EventHandler(this.DiskChange_Click);
            // 
            // button2
            // 
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 22);
            this.button2.Text = "Открыть проект";
            this.button2.Click += new System.EventHandler(this.ProjectOpen_Click);
            // 
            // button3
            // 
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 22);
            this.button3.Text = "Выбрать проект";
            this.button3.Click += new System.EventHandler(this.ProjectSelect_Click);
            // 
            // удалениеToolStripMenuItem
            // 
            this.удалениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.button4,
            this.button5});
            this.удалениеToolStripMenuItem.Name = "удалениеToolStripMenuItem";
            this.удалениеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.удалениеToolStripMenuItem.Text = "Удаление проектов";
            // 
            // button4
            // 
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(207, 22);
            this.button4.Text = "Удалить проект";
            this.button4.Click += new System.EventHandler(this.ProjectDelete_Click);
            // 
            // button5
            // 
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(207, 22);
            this.button5.Text = "УДАЛИТЬ ВСЕ ПРОЕКТЫ";
            this.button5.Click += new System.EventHandler(this.ProjectsDelete_Click);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(180, 22);
            this.exit.Text = "Выход";
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // топографическиеСимволыToolStripMenuItem
            // 
            this.топографическиеСимволыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.button7,
            this.button8,
            this.button9});
            this.топографическиеСимволыToolStripMenuItem.Name = "топографическиеСимволыToolStripMenuItem";
            this.топографическиеСимволыToolStripMenuItem.Size = new System.Drawing.Size(172, 20);
            this.топографическиеСимволыToolStripMenuItem.Text = "Топографические символы";
            // 
            // button7
            // 
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(132, 22);
            this.button7.Text = "Точки";
            this.button7.Click += new System.EventHandler(this.PointsSymb_Click);
            // 
            // button8
            // 
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(132, 22);
            this.button8.Text = "Линии";
            this.button8.Click += new System.EventHandler(this.LinesSymb_Click);
            // 
            // button9
            // 
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(132, 22);
            this.button9.Text = "Полигоны";
            this.button9.Click += new System.EventHandler(this.PolygonsSymb_Click);
            // 
            // загрузкаИОбработкаДанныхToolStripMenuItem
            // 
            this.загрузкаИОбработкаДанныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.геодезическиеВычисленияToolStripMenuItem,
            this.аеротриангуляцияToolStripMenuItem,
            this.button91});
            this.загрузкаИОбработкаДанныхToolStripMenuItem.Name = "загрузкаИОбработкаДанныхToolStripMenuItem";
            this.загрузкаИОбработкаДанныхToolStripMenuItem.Size = new System.Drawing.Size(182, 20);
            this.загрузкаИОбработкаДанныхToolStripMenuItem.Text = "Загрузка и обработка данных";
            // 
            // геодезическиеВычисленияToolStripMenuItem
            // 
            this.геодезическиеВычисленияToolStripMenuItem.Name = "геодезическиеВычисленияToolStripMenuItem";
            this.геодезическиеВычисленияToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.геодезическиеВычисленияToolStripMenuItem.Text = "Геодезические вычисления";
            this.геодезическиеВычисленияToolStripMenuItem.Click += new System.EventHandler(this.Geodesy_Click);
            // 
            // аеротриангуляцияToolStripMenuItem
            // 
            this.аеротриангуляцияToolStripMenuItem.Name = "аеротриангуляцияToolStripMenuItem";
            this.аеротриангуляцияToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.аеротриангуляцияToolStripMenuItem.Text = "Аеротриангуляция";
            this.аеротриангуляцияToolStripMenuItem.Click += new System.EventHandler(this.Aero_Click);
            // 
            // button91
            // 
            this.button91.Name = "button91";
            this.button91.Size = new System.Drawing.Size(226, 22);
            this.button91.Text = "Топография и кадастр";
            this.button91.Click += new System.EventHandler(this.Cadastre_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // MainGeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(878, 784);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainGeo";
            this.Text = "Главное меню";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem button6;
        private ToolStripMenuItem button2;
        private ToolStripMenuItem button3;
        private ToolStripMenuItem удалениеToolStripMenuItem;
        private ToolStripMenuItem button4;
        private ToolStripMenuItem button5;
        private ToolStripMenuItem топографическиеСимволыToolStripMenuItem;
        private ToolStripMenuItem button7;
        private ToolStripMenuItem button8;
        private ToolStripMenuItem button9;
        private ToolStripMenuItem загрузкаИОбработкаДанныхToolStripMenuItem;
        private ToolStripMenuItem геодезическиеВычисленияToolStripMenuItem;
        private ToolStripMenuItem аеротриангуляцияToolStripMenuItem;
        private ToolStripMenuItem button91;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem exit;
        private ToolStripMenuItem помощьToolStripMenuItem;
    }
}