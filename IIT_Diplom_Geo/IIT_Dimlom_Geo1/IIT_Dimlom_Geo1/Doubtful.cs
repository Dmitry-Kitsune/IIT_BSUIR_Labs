using IIT_Diplom_Geo1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiplomGeoDLL;
using System.IO;

namespace IIT_Dimlom_Geo1
{
    public partial class Doubtful : Form
    {
        private string sTmp = "";
        private string sTmp1 = "";
        private string sTmp2 = "";
        private int ks;
        private int kp;
        private double av;
        private double am;
        private MyGeodesy myError = new MyGeodesy();
        public Doubtful()
        {
            InitializeComponent();
            Form_Load();
        }
        private void Form_Load()
        {
            myError.FilePath();
            if (!File.Exists(myError.tmpStr))
            {
                int num = (int)MessageBox.Show("Диск не определен", "Список точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form.ActiveForm.Close();
            }
            if (!File.Exists(myError.fileProj))
                return;
            FileStream input1 = new FileStream(myError.fileProj, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader1 = new BinaryReader((Stream)input1);
            sTmp = binaryReader1.ReadString();
            myError.curProject = binaryReader1.ReadString();
            input1.Close();
            binaryReader1.Close();
            myError.curDirect = "Proj" + sTmp;
            FileStream input2 = new FileStream(myError.fDoubtful, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader2 = new BinaryReader((Stream)input2);
            ks = binaryReader2.ReadInt32();
            for (int index1 = 1; index1 <= ks; ++index1)
            {
                kp = binaryReader2.ReadInt32();
                av = binaryReader2.ReadDouble();
                am = binaryReader2.ReadDouble();
                for (int index2 = 1; index2 <= kp; ++index2)
                {
                    myError.nameAdd[index2] = binaryReader2.ReadString();
                    myError.xAdd[index2] = binaryReader2.ReadDouble();
                    myError.yAdd[index2] = binaryReader2.ReadDouble();
                }
                sTmp = "Line " + string.Format("{0}", (object)index1) + ".  ";
                sTmp += myError.nameAdd[1];
                for (int index3 = 2; index3 <= kp; ++index3)
                    sTmp = sTmp + "+" + myError.nameAdd[index3];
                int int32_1 = Convert.ToInt32(100000.0 * av);
                int num1 = 10000;
                if (int32_1 > 5)
                    num1 = Convert.ToInt32(100000 / int32_1);
                sTmp1 = string.Format("{0}", (object)num1);
                int int32_2 = Convert.ToInt32(100000.0 * am);
                int num2 = 10000;
                if (int32_2 > 5)
                    num2 = Convert.ToInt32(100000 / int32_2);
                sTmp2 = string.Format("{0}", (object)num2);
                sTmp = sTmp + "   Avarege=1:" + sTmp2 + "   Max=1:" + sTmp1;
                listBox1.Items.Add((object)sTmp);
            }
            binaryReader2.Close();
            input2.Close();
        }

        private void Cancel_Click(object sender, EventArgs e) => Form.ActiveForm.Close();


    }
}
