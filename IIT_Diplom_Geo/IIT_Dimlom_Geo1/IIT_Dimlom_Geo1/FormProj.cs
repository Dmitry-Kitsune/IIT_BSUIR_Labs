using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
   
    public partial class ProjectMenu : Form
    {
        MyGeodesy myGeo = new MyGeodesy();
        public ProjectMenu()
        {
            InitializeComponent();

            this.FileOptions.MouseHover += new
                EventHandler(this.FileOptions_MouseLeave);
            this.FileOptions.MouseLeave += new
                EventHandler(this.FileOptions_MouseLeave);
            FormLoad();
        }
        private void FormLoad()
        {
            myGeo.CheckDrive(myGeo.dirKey, out myGeo.dirKey);
        }

    }
}
