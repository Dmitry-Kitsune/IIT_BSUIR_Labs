using DiplomGeoDLL;
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
    public partial class CameraStore : Form
    {

        private int[] kmt = new int[10];
        private int[] k1 = new int[10];
        private int[] k2 = new int[10];
        private string[] n = new string[50];
        private string[] x = new string[50];
        private string[] y = new string[50];
        private string[] na = new string[50];
        private string[] xa = new string[50];
        private string[] ya = new string[50];
        private int[] kdt = new int[10];
        private int[] kd1 = new int[10];
        private int[] kd2 = new int[10];
        private string[] xd = new string[150];
        private string[] yd = new string[150];
        private string[] xb = new string[150];
        private string[] yb = new string[150];
        private string[] numCam = new string[10];
        private string[] nameCam = new string[10];
        private string[] focCam = new string[10];
        private string[] xoCam = new string[10];
        private string[] yoCam = new string[10];
        private string[] markCam = new string[10];
        private string[] dstrCam = new string[10];
        private string[] oldNumber = new string[10];
        private string[] nameBox = new string[70];
        private int[] nIndex = new int[70];
        private string sCamera = "";
        private string sNumber = "";
        private string sName = "";
        private string sFoc = "";
        private string sXo = "";
        private string sYo = "";
        private string sMark = "";
        private string sDstr = "";
        private int kCamera;
        private int kNumber;
        private int iCond;
        private int kName;
        private int ki;


        private MyGeodesy myCls = new MyGeodesy();
        public CameraStore()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            myCls.FilePath();
            InitStore();
            if (!File.Exists(myCls.tmpStr))
            {
                int num = (int)MessageBox.Show("Диск не определен", "Заполнить хранилище камер(снимков)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form.ActiveForm.Close();
            }
            else
            {
                try
                {
                    if (File.Exists(myCls.fileAdd))
                        File.Delete(myCls.fileAdd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция удаления завершилась неудачно, как и ожидалось.");
                }
                FileStream output = new FileStream(myCls.fileAdd, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                if (File.Exists(myCls.fstoreCam))
                {
                    FileStream input = new FileStream(myCls.fstoreCam, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    try
                    {
                        kCamera = Convert.ToInt32(binaryReader.ReadString());
                        for (int j = 1; j <= kCamera; ++j)
                        {
                            numCam[j] = binaryReader.ReadString();
                            nameCam[j] = binaryReader.ReadString();
                            focCam[j] = binaryReader.ReadString();
                            xoCam[j] = binaryReader.ReadString();
                            yoCam[j] = binaryReader.ReadString();
                            markCam[j] = binaryReader.ReadString();
                            dstrCam[j] = binaryReader.ReadString();
                            ++kNumber;
                            oldNumber[kNumber] = numCam[j];
                            Console.WriteLine(oldNumber[kNumber]);
                            binaryWriter.Write(numCam[j]);
                            binaryWriter.Write(nameCam[j]);
                            binaryWriter.Write(focCam[j]);
                            binaryWriter.Write(xoCam[j]);
                            binaryWriter.Write(yoCam[j]);
                            binaryWriter.Write(markCam[j]);
                            binaryWriter.Write(dstrCam[j]);
                            BoxData(j);
                            int int32_1 = Convert.ToInt32(markCam[j]);
                            int int32_2 = Convert.ToInt32(dstrCam[j]);
                            if (int32_1 > 0)
                            {
                                for (int index = 1; index <= int32_1; ++index)
                                {
                                    sNumber = binaryReader.ReadString();
                                    sXo = binaryReader.ReadString();
                                    sYo = binaryReader.ReadString();
                                    binaryWriter.Write(sNumber);
                                    binaryWriter.Write(sXo);
                                    binaryWriter.Write(sYo);
                                }
                            }
                            if (int32_2 > 0)
                            {
                                for (int index = 1; index <= int32_2; ++index)
                                {
                                    sXo = binaryReader.ReadString();
                                    sYo = binaryReader.ReadString();
                                    binaryWriter.Write(sXo);
                                    binaryWriter.Write(sYo);
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
                        input.Close();
                        binaryReader.Close();
                    }
                }
                output.Close();
                binaryWriter.Close();
            }
        }

        private void InitStore()
        {
            this.textBox1.Text = this.textBox2.Text = this.textBox3.Text = this.textBox4.Text = this.textBox5.Text = "";
            this.textBox6.Text = this.textBox7.Text = this.textBox8.Text = this.textBox9.Text = this.textBox10.Text = "";
            this.textBox11.Text = this.textBox12.Text = this.textBox13.Text = this.textBox14.Text = this.textBox15.Text = "";
            this.textBox16.Text = this.textBox17.Text = this.textBox18.Text = this.textBox19.Text = this.textBox20.Text = "";
            this.textBox21.Text = this.textBox22.Text = this.textBox23.Text = this.textBox24.Text = this.textBox25.Text = "";
            this.textBox26.Text = this.textBox27.Text = this.textBox28.Text = this.textBox29.Text = this.textBox30.Text = "";
            this.textBox31.Text = this.textBox32.Text = this.textBox33.Text = this.textBox34.Text = this.textBox35.Text = "";
        }

        private void AcountMark(ref int km, ref string[] n, ref string[] x, ref string[] y)
        {
            int index = 0;
            km = 0;
            if (this.textBox49.Text != "" && this.textBox50.Text != "")
            {
                ++index;
                n[index] = this.textBox41.Text;
                x[index] = this.textBox49.Text;
                y[index] = this.textBox50.Text;
            }
            if (this.textBox51.Text != "" && this.textBox58.Text != "")
            {
                ++index;
                n[index] = this.textBox42.Text;
                x[index] = this.textBox51.Text;
                y[index] = this.textBox58.Text;
            }
            if (this.textBox52.Text != "" && this.textBox59.Text != "")
            {
                ++index;
                n[index] = this.textBox43.Text;
                x[index] = this.textBox52.Text;
                y[index] = this.textBox59.Text;
            }
            if (this.textBox53.Text != "" && this.textBox60.Text != "")
            {
                ++index;
                n[index] = this.textBox44.Text;
                x[index] = this.textBox53.Text;
                y[index] = this.textBox60.Text;
            }
            if (this.textBox54.Text != "" && this.textBox61.Text != "")
            {
                ++index;
                n[index] = this.textBox45.Text;
                x[index] = this.textBox54.Text;
                y[index] = this.textBox61.Text;
            }
            if (this.textBox55.Text != "" && this.textBox62.Text != "")
            {
                ++index;
                n[index] = this.textBox46.Text;
                x[index] = this.textBox55.Text;
                y[index] = this.textBox62.Text;
            }
            if (this.textBox56.Text != "" && this.textBox63.Text != "")
            {
                ++index;
                n[index] = this.textBox47.Text;
                x[index] = this.textBox56.Text;
                y[index] = this.textBox63.Text;
            }
            if (this.textBox57.Text != "" && this.textBox64.Text != "")
            {
                ++index;
                n[index] = this.textBox48.Text;
                x[index] = this.textBox57.Text;
                y[index] = this.textBox64.Text;
            }
            km = index;
        }

        private void AcountDstr(ref int kd, ref string[] xd, ref string[] yd)
        {
            int num1 = 0;
            kd = 0;
            int index1 = num1 + 1;
            xd[index1] = this.textBox65.Text;
            yd[index1] = this.textBox66.Text;
            int index2 = index1 + 1;
            xd[index2] = this.textBox67.Text;
            yd[index2] = this.textBox68.Text;
            int index3 = index2 + 1;
            xd[index3] = this.textBox69.Text;
            yd[index3] = this.textBox70.Text;
            int index4 = index3 + 1;
            xd[index4] = this.textBox71.Text;
            yd[index4] = this.textBox72.Text;
            int index5 = index4 + 1;
            xd[index5] = this.textBox73.Text;
            yd[index5] = this.textBox74.Text;
            int index6 = index5 + 1;
            xd[index6] = this.textBox75.Text;
            yd[index6] = this.textBox76.Text;
            int index7 = index6 + 1;
            xd[index7] = this.textBox77.Text;
            yd[index7] = this.textBox78.Text;
            int index8 = index7 + 1;
            xd[index8] = this.textBox79.Text;
            yd[index8] = this.textBox80.Text;
            int index9 = index8 + 1;
            xd[index9] = this.textBox81.Text;
            yd[index9] = this.textBox82.Text;
            int index10 = index9 + 1;
            xd[index10] = this.textBox83.Text;
            yd[index10] = this.textBox84.Text;
            int index11 = index10 + 1;
            xd[index11] = this.textBox85.Text;
            yd[index11] = this.textBox86.Text;
            int index12 = index11 + 1;
            xd[index12] = this.textBox87.Text;
            yd[index12] = this.textBox88.Text;
            int index13 = index12 + 1;
            xd[index13] = this.textBox89.Text;
            yd[index13] = this.textBox90.Text;
            int index14 = index13 + 1;
            xd[index14] = this.textBox91.Text;
            yd[index14] = this.textBox92.Text;
            int index15 = index14 + 1;
            xd[index15] = this.textBox93.Text;
            yd[index15] = this.textBox94.Text;
            int index16 = index15 + 1;
            xd[index16] = this.textBox95.Text;
            yd[index16] = this.textBox96.Text;
            int index17 = index16 + 1;
            xd[index17] = this.textBox97.Text;
            yd[index17] = this.textBox98.Text;
            int index18 = index17 + 1;
            xd[index18] = this.textBox99.Text;
            yd[index18] = this.textBox100.Text;
            int index19 = index18 + 1;
            xd[index19] = this.textBox101.Text;
            yd[index19] = this.textBox102.Text;
            int index20 = index19 + 1;
            xd[index20] = this.textBox103.Text;
            yd[index20] = this.textBox104.Text;
            int index21 = index20 + 1;
            xd[index21] = this.textBox105.Text;
            yd[index21] = this.textBox106.Text;
            kd = 21;
            int num2 = 0;
            for (int index22 = 1; index22 <= kd; ++index22)
            {
                if (yd[index22] != "" && yd[index22] != "0")
                {
                    ++num2;
                    break;
                }
            }
            if (num2 == 0)
            {
                kd = 0;
            }
            else
            {
                if (num2 > 0)
                    kd = 21;
                double num3 = 0.0;
                for (int index23 = 1; index23 <= kd; ++index23)
                {
                    if (xd[index23] == "")
                    {
                        if (index23 == 1)
                            xd[index23] = "10";
                        if (index23 > 1)
                            xd[index23] = xd[index23 - 1] + "10";
                    }
                    if (yd[index23] == "")
                        yd[index23] = Convert.ToString(num3);
                }
            }
        }

        private void InitNew()
        {
            this.textBox36.Text = this.textBox37.Text = this.textBox38.Text = this.textBox39.Text = this.textBox40.Text = "";
            this.textBox49.Text = this.textBox50.Text = this.textBox51.Text = this.textBox58.Text = this.textBox52.Text = "";
            this.textBox59.Text = this.textBox53.Text = this.textBox60.Text = this.textBox54.Text = this.textBox61.Text = "";
            this.textBox55.Text = this.textBox62.Text = this.textBox56.Text = this.textBox63.Text = this.textBox57.Text = "";
            this.textBox64.Text = "";
            this.textBox66.Text = this.textBox68.Text = this.textBox70.Text = this.textBox72.Text = this.textBox74.Text = "";
            this.textBox76.Text = this.textBox78.Text = this.textBox80.Text = this.textBox82.Text = this.textBox84.Text = "";
            this.textBox86.Text = this.textBox88.Text = this.textBox90.Text = this.textBox92.Text = this.textBox94.Text = "";
            this.textBox96.Text = this.textBox98.Text = this.textBox100.Text = this.textBox102.Text = this.textBox104.Text = "";
            this.textBox106.Text = "";
        }

        private void BoxData(int j)
        {
            if (j == 1)
            {
                this.textBox1.Text = this.numCam[j];
                this.textBox6.Text = this.nameCam[j];
                this.textBox11.Text = this.focCam[j];
                this.textBox16.Text = this.xoCam[j];
                this.textBox21.Text = this.yoCam[j];
                this.textBox26.Text = this.markCam[j];
                this.textBox31.Text = this.dstrCam[j];
            }
            if (j == 2)
            {
                this.textBox2.Text = this.numCam[j];
                this.textBox7.Text = this.nameCam[j];
                this.textBox12.Text = this.focCam[j];
                this.textBox17.Text = this.xoCam[j];
                this.textBox22.Text = this.yoCam[j];
                this.textBox27.Text = this.markCam[j];
                this.textBox32.Text = this.dstrCam[j];
            }
            if (j == 3)
            {
                this.textBox3.Text = this.numCam[j];
                this.textBox8.Text = this.nameCam[j];
                this.textBox13.Text = this.focCam[j];
                this.textBox18.Text = this.xoCam[j];
                this.textBox23.Text = this.yoCam[j];
                this.textBox28.Text = this.markCam[j];
                this.textBox33.Text = this.dstrCam[j];
            }
            if (j == 4)
            {
                this.textBox4.Text = this.numCam[j];
                this.textBox9.Text = this.nameCam[j];
                this.textBox14.Text = this.focCam[j];
                this.textBox19.Text = this.xoCam[j];
                this.textBox24.Text = this.yoCam[j];
                this.textBox29.Text = this.markCam[j];
                this.textBox34.Text = this.dstrCam[j];
            }
            if (j != 5)
                return;
            this.textBox5.Text = this.numCam[j];
            this.textBox10.Text = this.nameCam[j];
            this.textBox15.Text = this.focCam[j];
            this.textBox20.Text = this.xoCam[j];
            this.textBox25.Text = this.yoCam[j];
            this.textBox30.Text = this.markCam[j];
            this.textBox35.Text = this.dstrCam[j];
        }

        private void ChangeBase(string sNum, string sName, string sFoc, string sXo, string sYo)
        {
            this.textBox36.Text = sNum;
            this.textBox37.Text = sName;
            this.textBox38.Text = sFoc;
            this.textBox39.Text = sXo;
            this.textBox40.Text = sYo;
            this.InitNameBox(out this.kName, this.nameBox);
        }

        private void ChangeMark(int km, string[] n, string[] x, string[] y)
        {
            for (int index = 1; index <= km; ++index)
            {
                if (index == 1)
                {
                    this.textBox41.Text = n[index];
                    this.textBox49.Text = x[index];
                    this.textBox50.Text = y[index];
                }
                if (index == 2)
                {
                    this.textBox42.Text = n[index];
                    this.textBox51.Text = x[index];
                    this.textBox58.Text = y[index];
                }
                if (index == 3)
                {
                    this.textBox43.Text = n[index];
                    this.textBox52.Text = x[index];
                    this.textBox59.Text = y[index];
                }
                if (index == 4)
                {
                    this.textBox44.Text = n[index];
                    this.textBox53.Text = x[index];
                    this.textBox60.Text = y[index];
                }
                if (index == 5)
                {
                    this.textBox45.Text = n[index];
                    this.textBox54.Text = x[index];
                    this.textBox61.Text = y[index];
                }
                if (index == 6)
                {
                    this.textBox46.Text = n[index];
                    this.textBox55.Text = x[index];
                    this.textBox62.Text = y[index];
                }
                if (index == 7)
                {
                    this.textBox47.Text = n[index];
                    this.textBox56.Text = x[index];
                    this.textBox63.Text = y[index];
                }
                if (index == 8)
                {
                    this.textBox48.Text = n[index];
                    this.textBox57.Text = x[index];
                    this.textBox64.Text = y[index];
                }
            }
            this.InitNameBox(out this.kName, this.nameBox);
        }

        private void ChangeDist(int kd, string[] xd, string[] yd)
        {
            for (int index = 1; index <= kd; ++index)
            {
                if (index == 1)
                {
                    this.textBox65.Text = xd[index];
                    this.textBox66.Text = yd[index];
                }
                if (index == 2)
                {
                    this.textBox67.Text = xd[index];
                    this.textBox68.Text = yd[index];
                }
                if (index == 3)
                {
                    this.textBox69.Text = xd[index];
                    this.textBox70.Text = yd[index];
                }
                if (index == 4)
                {
                    this.textBox71.Text = xd[index];
                    this.textBox72.Text = yd[index];
                }
                if (index == 5)
                {
                    this.textBox73.Text = xd[index];
                    this.textBox74.Text = yd[index];
                }
                if (index == 6)
                {
                    this.textBox75.Text = xd[index];
                    this.textBox76.Text = yd[index];
                }
                if (index == 7)
                {
                    this.textBox77.Text = xd[index];
                    this.textBox78.Text = yd[index];
                }
                if (index == 8)
                {
                    this.textBox79.Text = xd[index];
                    this.textBox80.Text = yd[index];
                }
                if (index == 9)
                {
                    this.textBox81.Text = xd[index];
                    this.textBox82.Text = yd[index];
                }
                if (index == 10)
                {
                    this.textBox83.Text = xd[index];
                    this.textBox84.Text = yd[index];
                }
                if (index == 11)
                {
                    this.textBox85.Text = xd[index];
                    this.textBox86.Text = yd[index];
                }
                if (index == 12)
                {
                    this.textBox87.Text = xd[index];
                    this.textBox88.Text = yd[index];
                }
                if (index == 13)
                {
                    this.textBox89.Text = xd[index];
                    this.textBox90.Text = yd[index];
                }
                if (index == 14)
                {
                    this.textBox91.Text = xd[index];
                    this.textBox92.Text = yd[index];
                }
                if (index == 15)
                {
                    this.textBox93.Text = xd[index];
                    this.textBox94.Text = yd[index];
                }
                if (index == 16)
                {
                    this.textBox95.Text = xd[index];
                    this.textBox96.Text = yd[index];
                }
                if (index == 17)
                {
                    this.textBox97.Text = xd[index];
                    this.textBox98.Text = yd[index];
                }
                if (index == 18)
                {
                    this.textBox99.Text = xd[index];
                    this.textBox100.Text = yd[index];
                }
                if (index == 19)
                {
                    this.textBox101.Text = xd[index];
                    this.textBox102.Text = yd[index];
                }
                if (index == 20)
                {
                    this.textBox103.Text = xd[index];
                    this.textBox104.Text = yd[index];
                }
                if (index == 21)
                {
                    this.textBox105.Text = xd[index];
                    this.textBox106.Text = yd[index];
                }
            }
            this.InitNameBox(out this.kName, this.nameBox);
        }

      
        private void ChangeFile()
        {
            if (File.Exists(myCls.fileAdd))
                File.Delete(myCls.fileAdd);
            FileStream output = new FileStream(myCls.fileAdd, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            if (File.Exists(myCls.fstoreCam))
            {
                FileStream input = new FileStream(myCls.fstoreCam, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    sCamera = binaryReader.ReadString();
                    kCamera = Convert.ToInt32(sCamera);
                    for (int index1 = 1; index1 <= kCamera; ++index1)
                    {
                        sNumber = binaryReader.ReadString();
                        sName = binaryReader.ReadString();
                        sFoc = binaryReader.ReadString();
                        sXo = binaryReader.ReadString();
                        sYo = binaryReader.ReadString();
                        sMark = binaryReader.ReadString();
                        sDstr = binaryReader.ReadString();
                        binaryWriter.Write(sNumber);
                        binaryWriter.Write(sName);
                        binaryWriter.Write(sFoc);
                        binaryWriter.Write(sXo);
                        binaryWriter.Write(sYo);
                        binaryWriter.Write(sMark);
                        binaryWriter.Write(sDstr);
                        int int32_1 = Convert.ToInt32(sMark);
                        int int32_2 = Convert.ToInt32(sDstr);
                        if (int32_1 > 0)
                        {
                            for (int index2 = 1; index2 <= int32_1; ++index2)
                            {
                                n[index2] = binaryReader.ReadString();
                                x[index2] = binaryReader.ReadString();
                                y[index2] = binaryReader.ReadString();
                                binaryWriter.Write(n[index2]);
                                binaryWriter.Write(x[index2]);
                                binaryWriter.Write(y[index2]);
                            }
                        }
                        if (int32_2 > 0)
                        {
                            for (int index3 = 1; index3 <= int32_2; ++index3)
                            {
                                xd[index3] = binaryReader.ReadString();
                                yd[index3] = binaryReader.ReadString();
                                binaryWriter.Write(xd[index3]);
                                binaryWriter.Write(yd[index3]);
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
                    input.Close();
                    binaryReader.Close();
                }
            }
            output.Close();
            binaryWriter.Close();
        }
        private void ConfirmSelect_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (radioButton1.Checked)
                num = 1;
            if (radioButton2.Checked)
                num = 2;
            if (radioButton3.Checked)
                num = 3;
            if (radioButton4.Checked)
                num = 4;
            if (radioButton5.Checked)
                num = 5;
            try
            {
                if (File.Exists(myCls.fileAdd))
                    File.Delete(myCls.fileAdd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Операция удаления завершилась неудачно, как и ожидалось.");
            }
            InitNew();
            FileStream output = new FileStream(myCls.fileAdd, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            if (File.Exists(myCls.fstoreCam))
            {
                FileStream input = new FileStream(myCls.fstoreCam, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    sCamera = binaryReader.ReadString();
                    binaryWriter.Write(sCamera);
                    kCamera = Convert.ToInt32(sCamera);
                    for (int index1 = 1; index1 <= kCamera; ++index1)
                    {
                        sNumber = binaryReader.ReadString();
                        sName = binaryReader.ReadString();
                        sFoc = binaryReader.ReadString();
                        sXo = binaryReader.ReadString();
                        sYo = binaryReader.ReadString();
                        sMark = binaryReader.ReadString();
                        sDstr = binaryReader.ReadString();
                        binaryWriter.Write(sNumber);
                        binaryWriter.Write(sName);
                        binaryWriter.Write(sFoc);
                        binaryWriter.Write(sXo);
                        binaryWriter.Write(sYo);
                        binaryWriter.Write(sMark);
                        binaryWriter.Write(sDstr);
                        if (num == index1)
                        {
                            ChangeBase(sNumber, sName, sFoc, sXo, sYo);
                            textBox107.Text = sNumber;
                        }
                        int int32_1 = Convert.ToInt32(sMark);
                        int int32_2 = Convert.ToInt32(sDstr);
                        if (int32_1 > 0)
                        {
                            for (int index2 = 1; index2 <= int32_1; ++index2)
                            {
                                n[index2] = binaryReader.ReadString();
                                x[index2] = binaryReader.ReadString();
                                y[index2] = binaryReader.ReadString();
                                binaryWriter.Write(n[index2]);
                                binaryWriter.Write(x[index2]);
                                binaryWriter.Write(y[index2]);
                            }
                            if (num == index1)
                                ChangeMark(int32_1, n, x, y);
                        }
                        if (int32_2 > 0)
                        {
                            for (int index3 = 1; index3 <= int32_2; ++index3)
                            {
                                xd[index3] = binaryReader.ReadString();
                                yd[index3] = binaryReader.ReadString();
                                binaryWriter.Write(xd[index3]);
                                binaryWriter.Write(yd[index3]);
                            }
                            if (num == index1)
                                ChangeDist(int32_2, xd, yd);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                }
                finally
                {
                    input.Close();
                    binaryReader.Close();
                }
            }
            output.Close();
            binaryWriter.Close();
            InitNameBox(out kName, nameBox);
            ChangeFile();
        }

        private void AddArchive_Click(object sender, EventArgs e)
        {
            double tText = 0.0;
            if (kCamera == 5)
            {
                int num1 = (int)MessageBox.Show("Если хранилище камер заполнено. Используйте кнопку 'Заменить номер'", "Заполнить хранилище камер(снимков)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (textBox36.Text == "")
                    textBox36.Text = Convert.ToString(999999L);
                if (textBox37.Text == "")
                    textBox37.Text = "Default";
                if (textBox38.Text == "")
                    textBox38.Text = Convert.ToString(0.0);
                DllClass1.CheckText(textBox38.Text, out tText, out iCond);
                if (iCond < 0)
                {
                    int num2 = (int)MessageBox.Show("Проверьте данные", "Аэротриангуляция", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (tText <= 0.0)
                {
                    int num3 = (int)MessageBox.Show("Ошибка фокусного расстояния", "Заполнить хранилище камер(снимков)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (textBox39.Text == "")
                        textBox39.Text = Convert.ToString(0.0);
                    if (textBox40.Text == "")
                        textBox40.Text = Convert.ToString(0.0);
                    if (kNumber > 0)
                    {
                        for (int index = 1; index <= kNumber; ++index)
                        {
                            Console.WriteLine(oldNumber[index]);
                            Console.WriteLine(textBox36.Text);
                            if (oldNumber[index] == textBox36.Text)
                            {
                                int num4 = (int)MessageBox.Show("Изменить номер камеры", "Пополнить хранилище камер(снимков)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                    }
                    ++kNumber;
                    oldNumber[kNumber] = textBox36.Text;
                    for (int index = 1; index <= kName; ++index)
                    {
                        InitNameBox(out kName, nameBox);
                        CorrectStoreCam(kName, nameBox, out ki, nIndex);
                        if (ki != 0)
                        {
                            if (ki > 0)
                                return;
                        }
                        else
                            break;
                    }
                    FileStream output1 = new FileStream(myCls.fileAdd, FileMode.Append, FileAccess.Write);
                    BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                    ++kCamera;
                    numCam[kCamera] = textBox36.Text;
                    nameCam[kCamera] = textBox37.Text;
                    focCam[kCamera] = textBox38.Text;
                    xoCam[kCamera] = textBox39.Text;
                    yoCam[kCamera] = textBox40.Text;
                    int km = 0;
                    AcountMark(ref km, ref na, ref xa, ref ya);
                    int kd = 0;
                    AcountDstr(ref kd, ref xb, ref yb);
                    markCam[kCamera] = Convert.ToString(km);
                    dstrCam[kCamera] = Convert.ToString(kd);
                    binaryWriter1.Write(numCam[kCamera]);
                    binaryWriter1.Write(nameCam[kCamera]);
                    binaryWriter1.Write(focCam[kCamera]);
                    binaryWriter1.Write(xoCam[kCamera]);
                    binaryWriter1.Write(yoCam[kCamera]);
                    binaryWriter1.Write(markCam[kCamera]);
                    binaryWriter1.Write(dstrCam[kCamera]);
                    if (km > 0)
                    {
                        for (int index = 1; index <= km; ++index)
                        {
                            binaryWriter1.Write(na[index]);
                            binaryWriter1.Write(xa[index]);
                            binaryWriter1.Write(ya[index]);
                        }
                    }
                    if (kd > 0)
                    {
                        for (int index = 1; index <= kd; ++index)
                        {
                            binaryWriter1.Write(xb[index]);
                            binaryWriter1.Write(yb[index]);
                        }
                    }
                    binaryWriter1.Close();
                    output1.Close();
                    BoxData(kCamera);
                    try
                    {
                        if (File.Exists(myCls.fstoreCam))
                            File.Delete(myCls.fstoreCam);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Операция удаления завершилась неудачно, как и ожидалось.");
                    }
                    FileStream input = new FileStream(myCls.fileAdd, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    FileStream output2 = new FileStream(myCls.fstoreCam, FileMode.CreateNew);
                    BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                    binaryWriter2.Write(Convert.ToString(kCamera));
                    for (int index1 = 1; index1 <= kCamera; ++index1)
                    {
                        sNumber = binaryReader.ReadString();
                        sName = binaryReader.ReadString();
                        sFoc = binaryReader.ReadString();
                        sXo = binaryReader.ReadString();
                        sYo = binaryReader.ReadString();
                        sMark = binaryReader.ReadString();
                        sDstr = binaryReader.ReadString();
                        binaryWriter2.Write(sNumber);
                        binaryWriter2.Write(sName);
                        binaryWriter2.Write(sFoc);
                        binaryWriter2.Write(sXo);
                        binaryWriter2.Write(sYo);
                        binaryWriter2.Write(sMark);
                        binaryWriter2.Write(sDstr);
                        int int32_1 = Convert.ToInt32(sMark);
                        int int32_2 = Convert.ToInt32(sDstr);
                        if (int32_1 > 0)
                        {
                            for (int index2 = 1; index2 <= int32_1; ++index2)
                            {
                                sNumber = binaryReader.ReadString();
                                sXo = binaryReader.ReadString();
                                sYo = binaryReader.ReadString();
                                binaryWriter2.Write(sNumber);
                                binaryWriter2.Write(sXo);
                                binaryWriter2.Write(sYo);
                            }
                        }
                        if (int32_2 > 0)
                        {
                            for (int index3 = 1; index3 <= int32_2; ++index3)
                            {
                                sXo = binaryReader.ReadString();
                                sYo = binaryReader.ReadString();
                                binaryWriter2.Write(sXo);
                                binaryWriter2.Write(sYo);
                            }
                        }
                    }
                    binaryWriter2.Close();
                    output2.Close();
                    input.Close();
                    binaryReader.Close();
                    textBox107.Text = "";
                    InitNew();
                    CorrectWhite(kName);
                    ChangeFile();
                }
            }
        }

        private void ReplaceNumber_Click(object sender, EventArgs e)
        {
            double tText = 0.0;
            if (!File.Exists(myCls.fstoreCam))
            {
                int num1 = (int)MessageBox.Show("Аеро-фото камеры'' Store isn't created", "Заполнить хранилище камер(снимков)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string text = textBox107.Text;
                if (text == "")
                {
                    int num2 = (int)MessageBox.Show("Replace Number isn't defined", "Заполнить хранилище камер(снимков)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int int32_1 = Convert.ToInt32(text);
                    if (textBox36.Text == "")
                        textBox36.Text = Convert.ToString(999999L);
                    if (textBox37.Text == "")
                        textBox37.Text = "Default";
                    if (textBox38.Text == "")
                        textBox38.Text = Convert.ToString(0.0);
                    DllClass1.CheckText(textBox38.Text, out tText, out iCond);
                    if (iCond < 0)
                    {
                        int num3 = (int)MessageBox.Show("Проверьте данные", "Аэротриангуляция", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (tText <= 0.0)
                    {
                        int num4 = (int)MessageBox.Show("Ошибка фокусного расстояния", "Заполнить хранилище камер(снимков)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (textBox39.Text == "")
                            textBox39.Text = Convert.ToString(0.0);
                        if (textBox40.Text == "")
                            textBox40.Text = Convert.ToString(0.0);
                        for (int index = 1; index <= kName; ++index)
                        {
                            InitNameBox(out kName, nameBox);
                            CorrectStoreCam(kName, nameBox, out ki, nIndex);
                            if (ki != 0)
                            {
                                if (ki > 0)
                                    return;
                            }
                            else
                                break;
                        }
                        if (kNumber > 0)
                        {
                            int num5 = 0;
                            for (int index = 1; index <= kNumber; ++index)
                            {
                                if (oldNumber[index] == textBox36.Text)
                                    ++num5;
                            }
                            if (num5 == 0)
                            {
                                for (int index = 1; index <= kNumber; ++index)
                                {
                                    if (oldNumber[index] == text)
                                    {
                                        oldNumber[index] = textBox36.Text;
                                        break;
                                    }
                                }
                            }
                        }
                        try
                        {
                            if (File.Exists(myCls.fstoreCam))
                                File.Delete(myCls.fstoreCam);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Операция удаления завершилась неудачно, как и ожидалось.");
                        }
                        FileStream output = new FileStream(myCls.fstoreCam, FileMode.CreateNew);
                        BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                        if (File.Exists(myCls.fileAdd))
                        {
                            FileStream input = new FileStream(myCls.fileAdd, FileMode.Open, FileAccess.Read);
                            BinaryReader binaryReader = new BinaryReader((Stream)input);
                            int km = 0;
                            int kd = 0;
                            try
                            {
                                sCamera = Convert.ToString(kCamera);
                                binaryWriter.Write(sCamera);
                                for (int j = 1; j <= kCamera; ++j)
                                {
                                    sNumber = binaryReader.ReadString();
                                    sName = binaryReader.ReadString();
                                    sFoc = binaryReader.ReadString();
                                    sXo = binaryReader.ReadString();
                                    sYo = binaryReader.ReadString();
                                    sMark = binaryReader.ReadString();
                                    sDstr = binaryReader.ReadString();
                                    int int32_2 = Convert.ToInt32(sMark);
                                    int int32_3 = Convert.ToInt32(sDstr);
                                    int int32_4 = Convert.ToInt32(sNumber);
                                    if (int32_1 == int32_4)
                                    {
                                        sNumber = textBox36.Text;
                                        sName = textBox37.Text;
                                        sFoc = textBox38.Text;
                                        sXo = textBox39.Text;
                                        sYo = textBox40.Text;
                                        AcountMark(ref km, ref na, ref xa, ref ya);
                                        AcountDstr(ref kd, ref xb, ref yb);
                                        sMark = Convert.ToString(km);
                                        sDstr = Convert.ToString(kd);
                                        numCam[j] = sNumber;
                                        nameCam[j] = sName;
                                        focCam[j] = sFoc;
                                        xoCam[j] = sXo;
                                        yoCam[j] = sYo;
                                        markCam[j] = sMark;
                                        dstrCam[j] = sDstr;
                                        BoxData(j);
                                    }
                                    binaryWriter.Write(sNumber);
                                    binaryWriter.Write(sName);
                                    binaryWriter.Write(sFoc);
                                    binaryWriter.Write(sXo);
                                    binaryWriter.Write(sYo);
                                    binaryWriter.Write(sMark);
                                    binaryWriter.Write(sDstr);
                                    if (int32_2 > 0)
                                    {
                                        for (int index = 1; index <= int32_2; ++index)
                                        {
                                            n[index] = binaryReader.ReadString();
                                            x[index] = binaryReader.ReadString();
                                            y[index] = binaryReader.ReadString();
                                            if (int32_1 != int32_4)
                                            {
                                                binaryWriter.Write(n[index]);
                                                binaryWriter.Write(x[index]);
                                                binaryWriter.Write(y[index]);
                                            }
                                        }
                                    }
                                    if (int32_3 > 0)
                                    {
                                        for (int index = 1; index <= int32_3; ++index)
                                        {
                                            xd[index] = binaryReader.ReadString();
                                            yd[index] = binaryReader.ReadString();
                                            if (int32_1 != int32_4)
                                            {
                                                binaryWriter.Write(xd[index]);
                                                binaryWriter.Write(yd[index]);
                                            }
                                        }
                                    }
                                    if (int32_1 == int32_4)
                                    {
                                        if (km > 0)
                                        {
                                            for (int index = 1; index <= km; ++index)
                                            {
                                                binaryWriter.Write(na[index]);
                                                binaryWriter.Write(xa[index]);
                                                binaryWriter.Write(ya[index]);
                                            }
                                        }
                                        if (kd > 0)
                                        {
                                            for (int index = 1; index <= kd; ++index)
                                            {
                                                binaryWriter.Write(xb[index]);
                                                binaryWriter.Write(yb[index]);
                                            }
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
                                input.Close();
                                binaryReader.Close();
                            }
                        }
                        output.Close();
                        binaryWriter.Close();
                        textBox107.Text = "";
                        InitNew();
                        CorrectWhite(kName);
                        ChangeFile();
                    }
                }
            }
        }

        private void InitNameBox(out int kName, string[] nameBox)
        {
            kName = 0;
            nameBox[1] = textBox38.Text;
            nameBox[2] = textBox39.Text;
            nameBox[3] = textBox40.Text;
            nameBox[4] = textBox41.Text;
            nameBox[5] = textBox42.Text;
            nameBox[6] = textBox43.Text;
            nameBox[7] = textBox44.Text;
            nameBox[8] = textBox45.Text;
            nameBox[9] = textBox46.Text;
            nameBox[10] = textBox47.Text;
            nameBox[11] = textBox48.Text;
            nameBox[12] = textBox49.Text;
            nameBox[13] = textBox50.Text;
            nameBox[14] = textBox51.Text;
            nameBox[15] = textBox52.Text;
            nameBox[16] = textBox53.Text;
            nameBox[17] = textBox54.Text;
            nameBox[18] = textBox55.Text;
            nameBox[19] = textBox56.Text;
            nameBox[20] = textBox57.Text;
            nameBox[21] = textBox58.Text;
            nameBox[22] = textBox59.Text;
            nameBox[23] = textBox60.Text;
            nameBox[24] = textBox61.Text;
            nameBox[25] = textBox62.Text;
            nameBox[26] = textBox63.Text;
            nameBox[27] = textBox64.Text;
            nameBox[28] = textBox65.Text;
            nameBox[29] = textBox66.Text;
            nameBox[30] = textBox67.Text;
            nameBox[31] = textBox68.Text;
            nameBox[32] = textBox69.Text;
            nameBox[33] = textBox70.Text;
            nameBox[34] = textBox71.Text;
            nameBox[35] = textBox72.Text;
            nameBox[36] = textBox73.Text;
            nameBox[37] = textBox74.Text;
            nameBox[38] = textBox75.Text;
            nameBox[39] = textBox76.Text;
            nameBox[40] = textBox77.Text;
            nameBox[41] = textBox78.Text;
            nameBox[42] = textBox79.Text;
            nameBox[43] = textBox80.Text;
            nameBox[44] = textBox81.Text;
            nameBox[45] = textBox82.Text;
            nameBox[46] = textBox83.Text;
            nameBox[47] = textBox84.Text;
            nameBox[48] = textBox85.Text;
            nameBox[49] = textBox86.Text;
            nameBox[50] = textBox87.Text;
            nameBox[51] = textBox88.Text;
            nameBox[52] = textBox89.Text;
            nameBox[53] = textBox90.Text;
            nameBox[54] = textBox91.Text;
            nameBox[55] = textBox92.Text;
            nameBox[56] = textBox93.Text;
            nameBox[57] = textBox94.Text;
            nameBox[58] = textBox95.Text;
            nameBox[59] = textBox96.Text;
            nameBox[60] = textBox97.Text;
            nameBox[61] = textBox98.Text;
            nameBox[62] = textBox99.Text;
            nameBox[63] = textBox100.Text;
            nameBox[64] = textBox101.Text;
            nameBox[65] = textBox102.Text;
            nameBox[66] = textBox103.Text;
            nameBox[67] = textBox104.Text;
            nameBox[68] = textBox105.Text;
            nameBox[69] = textBox106.Text;
            kName = 69;
        }

        private void CheckStoreCam(string[] nameBox, out int ki, int[] nIndex)
        {
            char ch1 = '.';
            char ch2 = '-';
            int num1 = 0;
            ki = 0;
            for (int index1 = 1; index1 <= 3; ++index1)
            {
                string str = nameBox[index1];
                if (!(str == ""))
                {
                    int num2 = 0;
                    int num3 = 0;
                    int num4 = 0;
                    for (int index2 = 0; index2 < str.Length; ++index2)
                    {
                        if (!char.IsDigit(str[index2]))
                        {
                            if ((int)str[index2] == (int)ch1)
                                ++num2;
                            else if ((int)str[index2] == (int)ch2)
                            {
                                ++num3;
                                if (index1 == 1)
                                {
                                    ++num4;
                                    break;
                                }
                                if (index2 != 0)
                                {
                                    ++num4;
                                    break;
                                }
                            }
                            else
                                ++num4;
                        }
                    }
                    if (num2 > 1 || num3 > 1)
                    {
                        ++ki;
                        nIndex[ki] = index1;
                    }
                    else if (num4 > 0)
                    {
                        ++ki;
                        nIndex[ki] = index1;
                    }
                }
            }
            for (int index3 = 4; index3 <= 11; ++index3)
            {
                string str = nameBox[index3];
                if (!(str == ""))
                {
                    int num5 = 0;
                    for (int index4 = 0; index4 < str.Length; ++index4)
                    {
                        if (!char.IsDigit(str[index4]))
                            ++num5;
                    }
                    if (num5 > 0)
                    {
                        ++ki;
                        nIndex[ki] = index3;
                    }
                }
            }
            for (int index5 = 12; index5 <= 27; ++index5)
            {
                string str = nameBox[index5];
                if (!(str == ""))
                {
                    int num6 = 0;
                    int num7 = 0;
                    int num8 = 0;
                    for (int index6 = 0; index6 < str.Length; ++index6)
                    {
                        if (!char.IsDigit(str[index6]))
                        {
                            if ((int)str[index6] == (int)ch1)
                                ++num6;
                            else if ((int)str[index6] == (int)ch2)
                            {
                                ++num7;
                                if (index6 != 0)
                                {
                                    ++num8;
                                    break;
                                }
                            }
                            else
                                ++num8;
                        }
                    }
                    if (num6 > 1 || num7 > 1)
                    {
                        ++ki;
                        nIndex[ki] = index5;
                    }
                    else if (num8 > 0)
                    {
                        ++ki;
                        nIndex[ki] = index5;
                    }
                }
            }
            for (int index7 = 28; index7 < kName; index7 += 2)
            {
                string str = nameBox[index7];
                if (!(str == ""))
                {
                    int num9 = 0;
                    num1 = 0;
                    int num10 = 0;
                    for (int index8 = 0; index8 < str.Length; ++index8)
                    {
                        if (!char.IsDigit(str[index8]))
                        {
                            if ((int)str[index8] == (int)ch1)
                                ++num9;
                            else
                                ++num10;
                        }
                    }
                    if (num9 > 1)
                    {
                        ++ki;
                        nIndex[ki] = index7;
                    }
                    else if (num10 > 0)
                    {
                        ++ki;
                        nIndex[ki] = index7;
                    }
                }
            }
            for (int index9 = 29; index9 <= kName; index9 += 2)
            {
                string str = nameBox[index9];
                if (!(str == ""))
                {
                    int num11 = 0;
                    int num12 = 0;
                    int num13 = 0;
                    for (int index10 = 0; index10 < str.Length; ++index10)
                    {
                        if (!char.IsDigit(str[index10]))
                        {
                            if ((int)str[index10] == (int)ch1)
                                ++num11;
                            else if ((int)str[index10] == (int)ch2)
                            {
                                ++num12;
                                if (index10 != 0)
                                {
                                    ++num13;
                                    break;
                                }
                            }
                            else
                                ++num13;
                        }
                    }
                    if (num11 > 1 || num12 > 1)
                    {
                        ++ki;
                        nIndex[ki] = index9;
                    }
                    else if (num13 > 0)
                    {
                        ++ki;
                        nIndex[ki] = index9;
                    }
                }
            }
        }

        private void CorrectStoreCam(int kName, string[] nameBox, out int ki, int[] nIndex)
        {
            ki = 0;
            for (int index1 = 1; index1 <= kName; ++index1)
            {
                CheckStoreCam(nameBox, out ki, nIndex);
                if (ki == 0)
                    break;
                for (int index2 = 1; index2 <= ki; ++index2)
                {
                    if (nIndex[index2] == 1)
                        textBox38.BackColor = Color.Red;
                    if (nIndex[index2] == 2)
                        textBox39.BackColor = Color.Red;
                    if (nIndex[index2] == 3)
                        textBox40.BackColor = Color.Red;
                    if (nIndex[index2] == 4)
                        textBox41.BackColor = Color.Red;
                    if (nIndex[index2] == 5)
                        textBox42.BackColor = Color.Red;
                    if (nIndex[index2] == 6)
                        textBox43.BackColor = Color.Red;
                    if (nIndex[index2] == 7)
                        textBox44.BackColor = Color.Red;
                    if (nIndex[index2] == 8)
                        textBox45.BackColor = Color.Red;
                    if (nIndex[index2] == 9)
                        textBox46.BackColor = Color.Red;
                    if (nIndex[index2] == 10)
                        textBox47.BackColor = Color.Red;
                    if (nIndex[index2] == 11)
                        textBox48.BackColor = Color.Red;
                    if (nIndex[index2] == 12)
                        textBox49.BackColor = Color.Red;
                    if (nIndex[index2] == 13)
                        textBox50.BackColor = Color.Red;
                    if (nIndex[index2] == 14)
                        textBox51.BackColor = Color.Red;
                    if (nIndex[index2] == 15)
                        textBox52.BackColor = Color.Red;
                    if (nIndex[index2] == 16)
                        textBox53.BackColor = Color.Red;
                    if (nIndex[index2] == 17)
                        textBox54.BackColor = Color.Red;
                    if (nIndex[index2] == 18)
                        textBox55.BackColor = Color.Red;
                    if (nIndex[index2] == 19)
                        textBox56.BackColor = Color.Red;
                    if (nIndex[index2] == 20)
                        textBox57.BackColor = Color.Red;
                    if (nIndex[index2] == 21)
                        textBox58.BackColor = Color.Red;
                    if (nIndex[index2] == 22)
                        textBox59.BackColor = Color.Red;
                    if (nIndex[index2] == 23)
                        textBox60.BackColor = Color.Red;
                    if (nIndex[index2] == 24)
                        textBox61.BackColor = Color.Red;
                    if (nIndex[index2] == 25)
                        textBox62.BackColor = Color.Red;
                    if (nIndex[index2] == 26)
                        textBox63.BackColor = Color.Red;
                    if (nIndex[index2] == 27)
                        textBox64.BackColor = Color.Red;
                    if (nIndex[index2] == 28)
                        textBox65.BackColor = Color.Red;
                    if (nIndex[index2] == 29)
                        textBox66.BackColor = Color.Red;
                    if (nIndex[index2] == 30)
                        textBox67.BackColor = Color.Red;
                    if (nIndex[index2] == 31)
                        textBox68.BackColor = Color.Red;
                    if (nIndex[index2] == 32)
                        textBox69.BackColor = Color.Red;
                    if (nIndex[index2] == 33)
                        textBox70.BackColor = Color.Red;
                    if (nIndex[index2] == 34)
                        textBox71.BackColor = Color.Red;
                    if (nIndex[index2] == 35)
                        textBox72.BackColor = Color.Red;
                    if (nIndex[index2] == 36)
                        textBox73.BackColor = Color.Red;
                    if (nIndex[index2] == 37)
                        textBox74.BackColor = Color.Red;
                    if (nIndex[index2] == 38)
                        textBox75.BackColor = Color.Red;
                    if (nIndex[index2] == 39)
                        textBox76.BackColor = Color.Red;
                    if (nIndex[index2] == 40)
                        textBox77.BackColor = Color.Red;
                    if (nIndex[index2] == 41)
                        textBox78.BackColor = Color.Red;
                    if (nIndex[index2] == 42)
                        textBox79.BackColor = Color.Red;
                    if (nIndex[index2] == 43)
                        textBox80.BackColor = Color.Red;
                    if (nIndex[index2] == 44)
                        textBox81.BackColor = Color.Red;
                    if (nIndex[index2] == 45)
                        textBox82.BackColor = Color.Red;
                    if (nIndex[index2] == 46)
                        textBox83.BackColor = Color.Red;
                    if (nIndex[index2] == 47)
                        textBox84.BackColor = Color.Red;
                    if (nIndex[index2] == 48)
                        textBox85.BackColor = Color.Red;
                    if (nIndex[index2] == 49)
                        textBox86.BackColor = Color.Red;
                    if (nIndex[index2] == 50)
                        textBox87.BackColor = Color.Red;
                    if (nIndex[index2] == 51)
                        textBox88.BackColor = Color.Red;
                    if (nIndex[index2] == 52)
                        textBox89.BackColor = Color.Red;
                    if (nIndex[index2] == 53)
                        textBox90.BackColor = Color.Red;
                    if (nIndex[index2] == 54)
                        textBox91.BackColor = Color.Red;
                    if (nIndex[index2] == 55)
                        textBox92.BackColor = Color.Red;
                    if (nIndex[index2] == 56)
                        textBox93.BackColor = Color.Red;
                    if (nIndex[index2] == 57)
                        textBox94.BackColor = Color.Red;
                    if (nIndex[index2] == 58)
                        textBox95.BackColor = Color.Red;
                    if (nIndex[index2] == 59)
                        textBox96.BackColor = Color.Red;
                    if (nIndex[index2] == 60)
                        textBox97.BackColor = Color.Red;
                    if (nIndex[index2] == 61)
                        textBox98.BackColor = Color.Red;
                    if (nIndex[index2] == 62)
                        textBox99.BackColor = Color.Red;
                    if (nIndex[index2] == 63)
                        textBox100.BackColor = Color.Red;
                    if (nIndex[index2] == 64)
                        textBox101.BackColor = Color.Red;
                    if (nIndex[index2] == 65)
                        textBox102.BackColor = Color.Red;
                    if (nIndex[index2] == 66)
                        textBox103.BackColor = Color.Red;
                    if (nIndex[index2] == 67)
                        textBox104.BackColor = Color.Red;
                    if (nIndex[index2] == 68)
                        textBox105.BackColor = Color.Red;
                    if (nIndex[index2] == 69)
                        textBox106.BackColor = Color.Red;
                }
            }
        }

        private void CorrectWhite(int kName)
        {
            for (int index = 1; index <= kName; ++index)
            {
                textBox38.BackColor = Color.White;
                textBox39.BackColor = Color.White;
                textBox40.BackColor = Color.White;
                textBox41.BackColor = Color.White;
                textBox42.BackColor = Color.White;
                textBox43.BackColor = Color.White;
                textBox44.BackColor = Color.White;
                textBox45.BackColor = Color.White;
                textBox46.BackColor = Color.White;
                textBox47.BackColor = Color.White;
                textBox48.BackColor = Color.White;
                textBox49.BackColor = Color.White;
                textBox50.BackColor = Color.White;
                textBox51.BackColor = Color.White;
                textBox52.BackColor = Color.White;
                textBox53.BackColor = Color.White;
                textBox54.BackColor = Color.White;
                textBox55.BackColor = Color.White;
                textBox56.BackColor = Color.White;
                textBox57.BackColor = Color.White;
                textBox58.BackColor = Color.White;
                textBox59.BackColor = Color.White;
                textBox60.BackColor = Color.White;
                textBox61.BackColor = Color.White;
                textBox62.BackColor = Color.White;
                textBox63.BackColor = Color.White;
                textBox64.BackColor = Color.White;
                textBox65.BackColor = Color.White;
                textBox66.BackColor = Color.White;
                textBox67.BackColor = Color.White;
                textBox68.BackColor = Color.White;
                textBox69.BackColor = Color.White;
                textBox70.BackColor = Color.White;
                textBox71.BackColor = Color.White;
                textBox72.BackColor = Color.White;
                textBox73.BackColor = Color.White;
                textBox74.BackColor = Color.White;
                textBox75.BackColor = Color.White;
                textBox76.BackColor = Color.White;
                textBox77.BackColor = Color.White;
                textBox78.BackColor = Color.White;
                textBox79.BackColor = Color.White;
                textBox80.BackColor = Color.White;
                textBox81.BackColor = Color.White;
                textBox82.BackColor = Color.White;
                textBox83.BackColor = Color.White;
                textBox84.BackColor = Color.White;
                textBox85.BackColor = Color.White;
                textBox86.BackColor = Color.White;
                textBox87.BackColor = Color.White;
                textBox88.BackColor = Color.White;
                textBox89.BackColor = Color.White;
                textBox90.BackColor = Color.White;
                textBox91.BackColor = Color.White;
                textBox92.BackColor = Color.White;
                textBox93.BackColor = Color.White;
                textBox94.BackColor = Color.White;
                textBox95.BackColor = Color.White;
                textBox96.BackColor = Color.White;
                textBox97.BackColor = Color.White;
                textBox98.BackColor = Color.White;
                textBox99.BackColor = Color.White;
                textBox100.BackColor = Color.White;
                textBox101.BackColor = Color.White;
                textBox102.BackColor = Color.White;
                textBox103.BackColor = Color.White;
                textBox104.BackColor = Color.White;
                textBox105.BackColor = Color.White;
                textBox106.BackColor = Color.White;
            }
        }

        private void LastBoxData(int j)
        {
            if (j == 1)
                textBox1.Text = textBox6.Text = textBox11.Text = textBox16.Text = textBox21.Text = textBox26.Text = textBox31.Text = "";
            if (j == 2)
                textBox2.Text = textBox7.Text = textBox12.Text = textBox17.Text = textBox22.Text = textBox27.Text = textBox32.Text = "";
            if (j == 3)
                textBox3.Text = textBox8.Text = textBox13.Text = textBox18.Text = textBox23.Text = textBox28.Text = textBox33.Text = "";
            if (j == 4)
                textBox4.Text = textBox9.Text = textBox14.Text = textBox19.Text = textBox24.Text = textBox29.Text = textBox34.Text = "";
            if (j != 5)
                return;
            textBox5.Text = textBox10.Text = textBox15.Text = textBox20.Text = textBox25.Text = textBox30.Text = textBox35.Text = "";
        }

        private void LastDelete_Click(object sender, EventArgs e)
        {
            int num1 = 0;
            int num2 = 0;
            if (!File.Exists(myCls.fstoreCam))
            {
                int num3 = (int)MessageBox.Show("Аеро-фото камеры'' Хранилище не было создано", "Заполнить хранилище камер(снимков)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(myCls.fileAdd))
                    File.Delete(myCls.fileAdd);
                FileStream output1 = new FileStream(myCls.fileAdd, FileMode.CreateNew);
                BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                if (File.Exists(myCls.fstoreCam))
                {
                    FileStream input = new FileStream(myCls.fstoreCam, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader((Stream)input);
                    num1 = 0;
                    num2 = 0;
                    try
                    {
                        sCamera = binaryReader.ReadString();
                        kCamera = Convert.ToInt32(sCamera);
                        for (int index1 = 1; index1 <= kCamera; ++index1)
                        {
                            sNumber = binaryReader.ReadString();
                            sName = binaryReader.ReadString();
                            sFoc = binaryReader.ReadString();
                            sXo = binaryReader.ReadString();
                            sYo = binaryReader.ReadString();
                            sMark = binaryReader.ReadString();
                            sDstr = binaryReader.ReadString();
                            binaryWriter1.Write(sNumber);
                            binaryWriter1.Write(sName);
                            binaryWriter1.Write(sFoc);
                            binaryWriter1.Write(sXo);
                            binaryWriter1.Write(sYo);
                            binaryWriter1.Write(sMark);
                            binaryWriter1.Write(sDstr);
                            int int32_1 = Convert.ToInt32(sMark);
                            int int32_2 = Convert.ToInt32(sDstr);
                            if (int32_1 > 0)
                            {
                                for (int index2 = 1; index2 <= int32_1; ++index2)
                                {
                                    n[index2] = binaryReader.ReadString();
                                    x[index2] = binaryReader.ReadString();
                                    y[index2] = binaryReader.ReadString();
                                    binaryWriter1.Write(n[index2]);
                                    binaryWriter1.Write(x[index2]);
                                    binaryWriter1.Write(y[index2]);
                                }
                            }
                            if (int32_2 > 0)
                            {
                                for (int index3 = 1; index3 <= int32_2; ++index3)
                                {
                                    xd[index3] = binaryReader.ReadString();
                                    yd[index3] = binaryReader.ReadString();
                                    binaryWriter1.Write(xd[index3]);
                                    binaryWriter1.Write(yd[index3]);
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
                        input.Close();
                        binaryReader.Close();
                    }
                }
                output1.Close();
                binaryWriter1.Close();
                LastBoxData(kCamera);
                if (kCamera == 1)
                {
                    int num4 = (int)MessageBox.Show("Аеро-фото камеры'Хранилище", "Используйте 'Удалить Архив'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    --kCamera;
                    if (File.Exists(myCls.fstoreCam))
                        File.Delete(myCls.fstoreCam);
                    FileStream output2 = new FileStream(myCls.fstoreCam, FileMode.CreateNew);
                    BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                    if (File.Exists(myCls.fileAdd))
                    {
                        FileStream input = new FileStream(myCls.fileAdd, FileMode.Open, FileAccess.Read);
                        BinaryReader binaryReader = new BinaryReader((Stream)input);
                        num1 = 0;
                        num2 = 0;
                        try
                        {
                            sCamera = Convert.ToString(kCamera);
                            binaryWriter2.Write(sCamera);
                            for (int index4 = 1; index4 <= kCamera; ++index4)
                            {
                                sNumber = binaryReader.ReadString();
                                sName = binaryReader.ReadString();
                                sFoc = binaryReader.ReadString();
                                sXo = binaryReader.ReadString();
                                sYo = binaryReader.ReadString();
                                sMark = binaryReader.ReadString();
                                sDstr = binaryReader.ReadString();
                                binaryWriter2.Write(sNumber);
                                binaryWriter2.Write(sName);
                                binaryWriter2.Write(sFoc);
                                binaryWriter2.Write(sXo);
                                binaryWriter2.Write(sYo);
                                binaryWriter2.Write(sMark);
                                binaryWriter2.Write(sDstr);
                                int int32_3 = Convert.ToInt32(sMark);
                                int int32_4 = Convert.ToInt32(sDstr);
                                if (int32_3 > 0)
                                {
                                    for (int index5 = 1; index5 <= int32_3; ++index5)
                                    {
                                        n[index5] = binaryReader.ReadString();
                                        x[index5] = binaryReader.ReadString();
                                        y[index5] = binaryReader.ReadString();
                                        binaryWriter2.Write(n[index5]);
                                        binaryWriter2.Write(x[index5]);
                                        binaryWriter2.Write(y[index5]);
                                    }
                                }
                                if (int32_4 > 0)
                                {
                                    for (int index6 = 1; index6 <= int32_4; ++index6)
                                    {
                                        xd[index6] = binaryReader.ReadString();
                                        yd[index6] = binaryReader.ReadString();
                                        binaryWriter2.Write(xd[index6]);
                                        binaryWriter2.Write(yd[index6]);
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
                            input.Close();
                            binaryReader.Close();
                        }
                    }
                    output2.Close();
                    binaryWriter2.Close();
                    textBox107.Text = "";
                    InitNew();
                    CorrectWhite(kName);
                    ChangeFile();
                    radioButton1.Checked = true;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

    }
}
