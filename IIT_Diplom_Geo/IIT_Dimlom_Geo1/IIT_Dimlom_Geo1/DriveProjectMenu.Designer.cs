using DiplomGeoDLL;


namespace IIT_Diplom_Geo1

{
    partial class ProjectMenu
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectMenu));
            listBox1 = new System.Windows.Forms.ListBox();
            Confirm = new System.Windows.Forms.Button();
            Cancel = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            ChangeDrive = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            resources.ApplyResources(listBox1, "listBox1");
            listBox1.Name = "listBox1";
            // 
            // Confirm
            // 
            resources.ApplyResources(Confirm, "Confirm");
            Confirm.Name = "Confirm";
            Confirm.UseVisualStyleBackColor = true;
            Confirm.Click += new System.EventHandler(Confirm_Click);
            // 
            // Cancel
            // 
            resources.ApplyResources(Cancel, "Cancel");
            Cancel.Name = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += new System.EventHandler(Cancel_Click);
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            label2.Name = "label2";
            // 
            // ChangeDrive
            // 
            resources.ApplyResources(ChangeDrive, "ChangeDrive");
            ChangeDrive.Name = "ChangeDrive";
            ChangeDrive.UseVisualStyleBackColor = true;
            ChangeDrive.Click += new System.EventHandler(ChangeDrive_Click);
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label3.Name = "label3";
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripStatusLabel1});
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            // 
            // richTextBox1
            // 
            resources.ApplyResources(richTextBox1, "richTextBox1");
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            // 
            // ProjectMenu
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            Controls.Add(richTextBox1);
            Controls.Add(statusStrip1);
            Controls.Add(label3);
            Controls.Add(ChangeDrive);
            Controls.Add(label2);
            Controls.Add(Cancel);
            Controls.Add(Confirm);
            Controls.Add(listBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProjectMenu";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChangeDrive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}