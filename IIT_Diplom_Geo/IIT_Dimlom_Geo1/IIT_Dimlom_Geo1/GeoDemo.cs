using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Windows.Media.Media3D;

namespace IIT_Dimlom_Geo1
{
   
    public partial class GeoDemo : Form 
    {

       MyGeodesy myGeo = new MyGeodesy();
        public GeoDemo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.btExit1.MouseHover += new
                EventHandler(this.btExit_MouseHover);
            this.btExit1.MouseLeave += new
                EventHandler(this.btExit_MouseLeave);
            //this.FileOptions.MouseHover += new 
            //    EventHandler(this.FileOptions_MouseLeave);
            //this.FileOptions.MouseLeave += new 
            //    EventHandler(this.FileOptions_MouseLeave);
            FormLoad();
        }
        private void FormLoad()
        {
            myGeo.CheckDrive(myGeo.dirKey, out myGeo.dirKey);
        }
        private void btExit_MouseHover(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = "Close all processes";
        }

        private void btExit_MouseLeave(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready...";
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel3.Text = String.Format("{0}", e.X);
            toolStripStatusLabel5.Text = String.Format("{0}", e.Y);
        }

        private void ProjectMenuItem_Click(object sender, EventArgs e)
        {
            ProjectMenu frm = new ProjectMenu();
            frm.Show();
        }

    }


}

