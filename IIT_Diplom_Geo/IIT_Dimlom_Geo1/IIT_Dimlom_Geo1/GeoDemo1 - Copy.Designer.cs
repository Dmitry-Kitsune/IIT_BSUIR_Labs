using System.Windows.Forms;

namespace IIT_Diplom_Geo1
{
    partial class GeoDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        public new bool MaximizeBox { get; set; }
        public new bool MinimizeBox { get; set; }
        
        Form form1 = new Form();

     
        
       
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeoDemo));
            panel1 = new System.Windows.Forms.Panel();
            groupBoxOptions1 = new System.Windows.Forms.GroupBox();
            ZoomIn = new System.Windows.Forms.Button();
            Move = new System.Windows.Forms.Button();
            ZoomOut = new System.Windows.Forms.Button();
            SelectBox = new System.Windows.Forms.Button();
            PointsInput = new System.Windows.Forms.Button();
            btExit1 = new System.Windows.Forms.Button();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            ProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SelectProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newProjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            DeleteProjManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DeleteProjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DelAllProjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            btExit = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            contentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            indexToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            searchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            groupBoxOptions1.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel1.Location = new System.Drawing.Point(12, 74);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(625, 472);
            panel1.TabIndex = 0;
            panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
            panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
            panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(panel1_MouseMove);
            panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(panel1_MouseUp);
            // 
            // groupBoxOptions1
            // 
            groupBoxOptions1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            groupBoxOptions1.Controls.Add(Move);
            groupBoxOptions1.Controls.Add(SelectBox);
            groupBoxOptions1.Controls.Add(PointsInput);
            groupBoxOptions1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            groupBoxOptions1.Location = new System.Drawing.Point(643, 74);
            groupBoxOptions1.Name = "groupBoxOptions1";
            groupBoxOptions1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            groupBoxOptions1.Size = new System.Drawing.Size(206, 443);
            groupBoxOptions1.TabIndex = 1;
            groupBoxOptions1.TabStop = false;
            groupBoxOptions1.Text = "Опции";
            // 
            // ZoomIn
            // 
            ZoomIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ZoomIn.BackgroundImage")));
            ZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            ZoomIn.Location = new System.Drawing.Point(69, 39);
            ZoomIn.Name = "ZoomIn";
            ZoomIn.Size = new System.Drawing.Size(28, 29);
            ZoomIn.TabIndex = 3;
            ZoomIn.UseVisualStyleBackColor = true;
            // 
            // Move
            // 
            Move.Location = new System.Drawing.Point(36, 205);
            Move.Name = "Move";
            Move.Size = new System.Drawing.Size(110, 31);
            Move.TabIndex = 5;
            Move.Text = "Переместить";
            Move.UseVisualStyleBackColor = true;
            // 
            // ZoomOut
            // 
            ZoomOut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ZoomOut.BackgroundImage")));
            ZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            ZoomOut.Location = new System.Drawing.Point(112, 39);
            ZoomOut.Name = "ZoomOut";
            ZoomOut.Size = new System.Drawing.Size(28, 30);
            ZoomOut.TabIndex = 4;
            ZoomOut.UseVisualStyleBackColor = true;
            // 
            // SelectBox
            // 
            SelectBox.Location = new System.Drawing.Point(36, 144);
            SelectBox.Name = "SelectBox";
            SelectBox.Size = new System.Drawing.Size(110, 42);
            SelectBox.TabIndex = 2;
            SelectBox.Text = "Выбрать область";
            SelectBox.UseVisualStyleBackColor = true;
            SelectBox.Click += new System.EventHandler(SelectBox_Click);
            SelectBox.MouseClick += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
            SelectBox.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
            SelectBox.MouseUp += new System.Windows.Forms.MouseEventHandler(panel1_MouseUp);
            // 
            // PointsInput
            // 
            PointsInput.Location = new System.Drawing.Point(81, 392);
            PointsInput.Name = "PointsInput";
            PointsInput.Size = new System.Drawing.Size(97, 43);
            PointsInput.TabIndex = 1;
            PointsInput.Text = "Загрузить точки";
            PointsInput.UseVisualStyleBackColor = true;
            PointsInput.Click += new System.EventHandler(PointsInput_Click);
            // 
            // btExit1
            // 
            btExit1.BackColor = System.Drawing.SystemColors.Control;
            btExit1.Location = new System.Drawing.Point(643, 523);
            btExit1.Name = "btExit1";
            btExit1.Size = new System.Drawing.Size(75, 23);
            btExit1.TabIndex = 0;
            btExit1.Text = "Выход";
            btExit1.UseVisualStyleBackColor = false;
            btExit1.Click += new System.EventHandler(btExit_Click);
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripStatusLabel1,
            toolStripStatusLabel2,
            toolStripStatusLabel3,
            toolStripStatusLabel4,
            toolStripStatusLabel5});
            statusStrip1.Location = new System.Drawing.Point(0, 575);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(861, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            toolStripStatusLabel1.Text = "Готов...";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(28, 17);
            toolStripStatusLabel2.Text = "X = ";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel3.Text = "*********";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(28, 17);
            toolStripStatusLabel4.Text = "Y = ";
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new System.Drawing.Size(67, 17);
            toolStripStatusLabel5.Text = "************";
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileToolStripMenuItem,
            optionsToolStripMenuItem1,
            editToolStripMenuItem,
            toolsToolStripMenuItem,
            helpToolStripMenuItem1});
            menuStrip1.Location = new System.Drawing.Point(9, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(383, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuFileOpen,
            newProjToolStripMenuItem,
            toolStripSeparator,
            saveToolStripMenuItem1,
            saveAsToolStripMenuItem,
            toolStripSeparator1,
            DeleteProjManagerToolStripMenuItem,
            toolStripSeparator5,
            printToolStripMenuItem,
            printPreviewToolStripMenuItem,
            toolStripSeparator2,
            btExit});
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // menuFileOpen
            // 
            menuFileOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ProjectMenuItem,
            SelectProjectToolStripMenuItem});
            menuFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("menuFileOpen.Image")));
            menuFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            menuFileOpen.Name = "menuFileOpen";
            menuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            menuFileOpen.Size = new System.Drawing.Size(205, 22);
            menuFileOpen.Text = "Открыть проект";
            // 
            // ProjectMenuItem
            // 
            ProjectMenuItem.Name = "ProjectMenuItem";
            ProjectMenuItem.Size = new System.Drawing.Size(253, 22);
            ProjectMenuItem.Text = "Изменить директорию проектов";
            ProjectMenuItem.Click += new System.EventHandler(ProjectMenuItem_Click);
            // 
            // SelectProjectToolStripMenuItem
            // 
            SelectProjectToolStripMenuItem.Name = "SelectProjectToolStripMenuItem";
            SelectProjectToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            SelectProjectToolStripMenuItem.Text = "Выбрать проект";
            SelectProjectToolStripMenuItem.Click += new System.EventHandler(SelectProjectToolStripMenuItem_Click);
            // 
            // newProjToolStripMenuItem
            // 
            newProjToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newProjToolStripMenuItem.Image")));
            newProjToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            newProjToolStripMenuItem.Name = "newProjToolStripMenuItem";
            newProjToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            newProjToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            newProjToolStripMenuItem.Text = "Новый проект";
            newProjToolStripMenuItem.Click += new System.EventHandler(newProjToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(202, 6);
            // 
            // saveToolStripMenuItem1
            // 
            saveToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem1.Image")));
            saveToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            saveToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            saveToolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
            saveToolStripMenuItem1.Text = "Сохранить";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            saveAsToolStripMenuItem.Text = "Сохранить как";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // DeleteProjManagerToolStripMenuItem
            // 
            DeleteProjManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            DeleteProjToolStripMenuItem,
            DelAllProjToolStripMenuItem});
            DeleteProjManagerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteProjManagerToolStripMenuItem.Image")));
            DeleteProjManagerToolStripMenuItem.Name = "DeleteProjManagerToolStripMenuItem";
            DeleteProjManagerToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            DeleteProjManagerToolStripMenuItem.Text = "Удаление проектов";
            // 
            // DeleteProjToolStripMenuItem
            // 
            DeleteProjToolStripMenuItem.Name = "DeleteProjToolStripMenuItem";
            DeleteProjToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            DeleteProjToolStripMenuItem.Text = "Удалить проект";
            DeleteProjToolStripMenuItem.Click += new System.EventHandler(DeleteProjToolStripMenuItem_Click);
            // 
            // DelAllProjToolStripMenuItem
            // 
            DelAllProjToolStripMenuItem.Name = "DelAllProjToolStripMenuItem";
            DelAllProjToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            DelAllProjToolStripMenuItem.Text = "Удалить все проекты";
            DelAllProjToolStripMenuItem.Click += new System.EventHandler(DelAllProjToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(202, 6);
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            printToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            printToolStripMenuItem.Text = "Печать";
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            printPreviewToolStripMenuItem.Text = "Предпросмотр печати";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // btExit
            // 
            btExit.Name = "btExit";
            btExit.Size = new System.Drawing.Size(205, 22);
            btExit.Text = "Выход";
            btExit.Click += new System.EventHandler(btExit_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            optionsToolStripMenuItem1.Size = new System.Drawing.Size(56, 20);
            optionsToolStripMenuItem1.Text = "Опции";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            undoToolStripMenuItem,
            redoToolStripMenuItem,
            toolStripSeparator3,
            cutToolStripMenuItem,
            copyToolStripMenuItem,
            pasteToolStripMenuItem,
            toolStripSeparator4,
            selectAllToolStripMenuItem});
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            editToolStripMenuItem.Text = "Редактирование";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            undoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            undoToolStripMenuItem.Text = "Отменить";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            redoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            cutToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            cutToolStripMenuItem.Text = "Вырезать";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            copyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            copyToolStripMenuItem.Text = "Копировать";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            pasteToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            pasteToolStripMenuItem.Text = "Вставить";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(178, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            selectAllToolStripMenuItem.Text = "Выбрать все";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            customizeToolStripMenuItem,
            optionsToolStripMenuItem});
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            toolsToolStripMenuItem.Text = "Инструменты";
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            contentsToolStripMenuItem1,
            indexToolStripMenuItem1,
            searchToolStripMenuItem1,
            toolStripSeparator6,
            aboutToolStripMenuItem1});
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new System.Drawing.Size(68, 20);
            helpToolStripMenuItem1.Text = "Помощь";
            // 
            // contentsToolStripMenuItem1
            // 
            contentsToolStripMenuItem1.Name = "contentsToolStripMenuItem1";
            contentsToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            contentsToolStripMenuItem1.Text = "&Contents";
            // 
            // indexToolStripMenuItem1
            // 
            indexToolStripMenuItem1.Name = "indexToolStripMenuItem1";
            indexToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            indexToolStripMenuItem1.Text = "&Index";
            // 
            // searchToolStripMenuItem1
            // 
            searchToolStripMenuItem1.Name = "searchToolStripMenuItem1";
            searchToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            searchToolStripMenuItem1.Text = "&Search";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(119, 6);
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            aboutToolStripMenuItem1.Text = "&About...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label1.Location = new System.Drawing.Point(103, 552);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(0, 552);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(97, 20);
            textBox1.TabIndex = 4;
            textBox1.Text = "Текущий проект:";
            // 
            // GeoDemo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(861, 597);
            Controls.Add(ZoomIn);
            Controls.Add(ZoomOut);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(groupBoxOptions1);
            Controls.Add(btExit1);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GeoDemo";
            RightToLeft = System.Windows.Forms.RightToLeft.No;
            Text = "Главное окно";
            groupBoxOptions1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Panel panel1;
        private GroupBox groupBoxOptions1;
        private Button btExit1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionsToolStripMenuItem1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newProjToolStripMenuItem;
        private ToolStripMenuItem menuFileOpen;
        private ToolStripMenuItem ProjectMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem btExit;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem contentsToolStripMenuItem1;
        private ToolStripMenuItem indexToolStripMenuItem1;
        private ToolStripMenuItem searchToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private Label label1;
        private TextBox textBox1;
        private ToolStripMenuItem SelectProjectToolStripMenuItem;
        private ToolStripMenuItem DeleteProjManagerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem DeleteProjToolStripMenuItem;
        private ToolStripMenuItem DelAllProjToolStripMenuItem;
        private Button PointsInput;
        private Button Move;
        private Button ZoomOut;
        private Button ZoomIn;
        private Button SelectBox;
    }
}

