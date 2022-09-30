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
    public partial class PointsList : Form
    {
        private int kLinePoly;
        private int kAdd;
        private int ip;
        private string sTmp = "";
        private string sTmp1 = "";
        private string sTmp2 = "";
        private string sTmp3 = "";
        private string pName = "";
        private MyGeodesy myList = new MyGeodesy();
        public PointsList()
        {
            InitializeComponent();
            Form_Load();
        }

        private void Form_Load()
        {
            myList.FilePath();
            if (!File.Exists(myList.tmpStr))
            {
                int num = (int)MessageBox.Show("Диск не определен", "Список точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form.ActiveForm.Close();
            }
            if (!File.Exists(myList.fileProj))
                return;
            FileStream input1 = new FileStream(myList.fileProj, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader1 = new BinaryReader((Stream)input1);
            sTmp = binaryReader1.ReadString();
            myList.curProject = binaryReader1.ReadString();
            input1.Close();
            binaryReader1.Close();
            myList.curDirect = "Proj" + sTmp;
            kAdd = 0;
            if (File.Exists(myList.flinePoly))
            {
                FileStream input2 = new FileStream(myList.flinePoly, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader2 = new BinaryReader((Stream)input2);
                try
                {
                    kLinePoly = binaryReader2.ReadInt32();
                    for (int index1 = 1; index1 <= kLinePoly; ++index1)
                    {
                        int num = binaryReader2.ReadInt32();
                        for (int index2 = 1; index2 <= num; ++index2)
                        {
                            myList.nameDop[index2] = binaryReader2.ReadString();
                            myList.xDop[index2] = binaryReader2.ReadDouble();
                            myList.yDop[index2] = binaryReader2.ReadDouble();
                            myList.zDop[index2] = binaryReader2.ReadDouble();
                            ip = 0;
                            if (kAdd > 0)
                            {
                                for (int index3 = 1; index3 <= kAdd; ++index3)
                                {
                                    if (myList.nameDop[index2] == myList.nameAdd[index3])
                                    {
                                        ++ip;
                                        break;
                                    }
                                }
                            }
                            if (ip <= 0)
                            {
                                ++kAdd;
                                myList.nameAdd[kAdd] = myList.nameDop[index2];
                                myList.xAdd[kAdd] = myList.xDop[index2];
                                myList.yAdd[kAdd] = myList.yDop[index2];
                                myList.zAdd[kAdd] = myList.zDop[index2];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                }
                finally
                {
                    binaryReader2.Close();
                    input2.Close();
                }
            }
            if (File.Exists(myList.filePoints))
            {
                FileStream input3 = new FileStream(myList.filePoints, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader3 = new BinaryReader((Stream)input3);
                try
                {
                    kAdd = binaryReader3.ReadInt32();
                    for (int index = 1; index <= kAdd; ++index)
                    {
                        myList.nameAdd[index] = binaryReader3.ReadString();
                        myList.xAdd[index] = binaryReader3.ReadDouble();
                        myList.yAdd[index] = binaryReader3.ReadDouble();
                        myList.zAdd[index] = binaryReader3.ReadDouble();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                }
                finally
                {
                    binaryReader3.Close();
                    input3.Close();
                }
            }
            if (kAdd <= 0)
                return;
            for (int index = 1; index <= kAdd; ++index)
            {
                sTmp1 = string.Format("{0:F3}", (object)myList.xAdd[index]);
                sTmp2 = string.Format("{0:F3}", (object)myList.yAdd[index]);
                sTmp3 = string.Format("{0:F3}", (object)myList.zAdd[index]);
                this.pName = myList.nameAdd[index].PadRight(12);
                sTmp1 = sTmp1.PadRight(18);
                sTmp2 = sTmp2.PadRight(18);
                sTmp3 = sTmp3.PadRight(18);
                sTmp = this.pName + sTmp1 + sTmp2 + sTmp3;
                listBox1.Items.Add((object)sTmp);
            }
        }
        private void Cancel_Click(object sender, EventArgs e) => Form.ActiveForm.Close();
    }
}
