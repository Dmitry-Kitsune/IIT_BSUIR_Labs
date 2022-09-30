using IIT_Diplom_Geo1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IIT_Dimlom_Geo1
{
    public partial class ListPoints : Form
    {

        private string sTmp = "";
        private string sTmp1 = "";
        private string sTmp2 = "";
        private string sTmp3 = "";
        private string sDif = "";
        private string pName = "";
        private int kBlock;
        private int kDif;
        private string[] nameDif = new string[1000];
        private double[] xDif = new double[1000];
        private double[] yDif = new double[1000];
        private double[] zDif = new double[1000];
        private MyGeodesy myList = new MyGeodesy();
        public ListPoints()
        {
            InitializeComponent();
            Form_Load();
        }

        private void Form_Load()
        {
            myList.FilePath();
            if (!File.Exists(myList.tmpStr))
            {
                int num = (int)MessageBox.Show("Диск не определен", "Заполнить хранилище контрольных точек", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (File.Exists(myList.difTarget))
            {
                FileStream input2 = new FileStream(myList.difTarget, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader2 = new BinaryReader((Stream)input2);
                try
                {
                    kDif = binaryReader2.ReadInt32();
                    if (kDif > 0)
                    {
                        for (int index = 1; index <= kDif; ++index)
                        {
                            nameDif[index] = binaryReader2.ReadString();
                            xDif[index] = binaryReader2.ReadDouble();
                            yDif[index] = binaryReader2.ReadDouble();
                            zDif[index] = binaryReader2.ReadDouble();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                }
                finally
                {
                    input2.Close();
                    binaryReader2.Close();
                }
            }
            if (!File.Exists(myList.aeroBlock))
                return;
            FileStream input3 = new FileStream(myList.aeroBlock, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader3 = new BinaryReader((Stream)input3);
            try
            {
                binaryReader3.ReadDouble();
                binaryReader3.ReadDouble();
                binaryReader3.ReadDouble();
                binaryReader3.ReadDouble();
                binaryReader3.ReadDouble();
                binaryReader3.ReadDouble();
                kBlock = binaryReader3.ReadInt32();
                for (int index1 = 1; index1 <= kBlock; ++index1)
                {
                    myList.blockName[index1] = binaryReader3.ReadString();
                    myList.xBlock[index1] = binaryReader3.ReadDouble();
                    myList.yBlock[index1] = binaryReader3.ReadDouble();
                    myList.zBlock[index1] = binaryReader3.ReadDouble();
                    sTmp1 = string.Format("{0:F3}", (object)myList.xBlock[index1]);
                    sTmp2 = string.Format("{0:F3}", (object)myList.yBlock[index1]);
                    sTmp3 = string.Format("{0:F3}", (object)myList.zBlock[index1]);
                    pName = myList.blockName[index1].PadRight(12);
                    int num1 = 0;
                    if (myList.blockName[index1].IndexOf('-') > -1)
                    {
                        pName = myList.blockName[index1].Trim('-');
                        pName = pName.PadRight(12);
                        ++num1;
                    }
                    sTmp1 = sTmp1.PadRight(18);
                    sTmp2 = sTmp2.PadRight(18);
                    sTmp3 = sTmp3.PadRight(12);
                    sTmp = pName + sTmp1 + sTmp2 + sTmp3;
                    if (num1 > 0)
                    {
                        sTmp += "Центр аэрофотосъемки";
                        listBox1.Items.Add((object)sTmp);
                    }
                    else
                    {
                        int num2 = 0;
                        if (kDif > 0)
                        {
                            for (int index2 = 1; index2 <= kDif; ++index2)
                            {
                                if (myList.blockName[index1] == nameDif[index2])
                                {
                                    ++num2;
                                    if (xDif[index2] != 0.0 && yDif[index2] != 0.0 && zDif[index2] != 0.0)
                                    {
                                        sTmp1 = string.Format("{0:F3}", (object)xDif[index2]);
                                        sTmp2 = string.Format("{0:F3}", (object)yDif[index2]);
                                        sTmp3 = string.Format("{0:F3}", (object)zDif[index2]);
                                        sTmp1 = sTmp1.PadRight(10);
                                        sTmp2 = sTmp2.PadRight(10);
                                        sDif = sTmp1 + sTmp2 + sTmp3;
                                    }
                                    if (xDif[index2] != 0.0 && yDif[index2] != 0.0 && zDif[index2] == 0.0)
                                    {
                                        sTmp1 = string.Format("{0:F3}", (object)xDif[index2]);
                                        sTmp2 = string.Format("{0:F3}", (object)yDif[index2]);
                                        sTmp1 = sTmp1.PadRight(10);
                                        sDif = sTmp1 + sTmp2;
                                    }
                                    if (xDif[index2] == 0.0 && yDif[index2] == 0.0 && zDif[index2] != 0.0)
                                    {
                                        sTmp3 = string.Format("{0:F3}", (object)zDif[index2]);
                                        sDif = sTmp3;
                                        break;
                                    }
                                    break;
                                }
                            }
                        }
                        if (num2 > 0)
                            sTmp = sTmp + "     " + sDif;
                        listBox1.Items.Add((object)sTmp);
                    }
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

        private void Cancel_Click(object sender, EventArgs e) => Form.ActiveForm.Close();
    }
}

