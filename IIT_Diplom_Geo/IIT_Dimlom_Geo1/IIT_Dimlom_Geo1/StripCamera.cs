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
    public partial class StripCamera : Form
    {
        private string sTmp = "";
        private string curAero = "";
        private string curStrip = "";
        private int kStrip;
        private int kStereo;
        private long nMod;
        private int nLeft;
        private int nRight;
        private int kMark;
        private int kPnt;
        private int kCamera;
        private int nProcess;
        private long numSel;
        private int kSel;
        private string sName = "";
        private double xl;
        private double yl;
        private double xr;
        private double yr;
        private string[] numCam = new string[10];
        private string[] nameCam = new string[10];
        private string[] focCam = new string[10];
        private string[] xoCam = new string[10];
        private string[] yoCam = new string[10];
        private string[] markCam = new string[10];
        private string[] dstrCam = new string[10];
        private string[] n = new string[50];
        private string[] x = new string[50];
        private string[] y = new string[50];
        private string[] xd = new string[150];
        private string[] yd = new string[150];
        private string[] sSel = new string[1000];
        private int indx;
        private MyGeodesy myCam = new MyGeodesy();
        public StripCamera()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Form_Load();
        }

        private void Form_Load()
        {
            myCam.FilePath();
            if (File.Exists(myCam.fileProj))
            {
                FileStream input = new FileStream(myCam.fileProj, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                sTmp = binaryReader.ReadString();
                myCam.curProject = binaryReader.ReadString();
                input.Close();
                binaryReader.Close();
            }
            myCam.curDirect = "Proj" + sTmp;
            if (File.Exists(myCam.fileProcess))
            {
                FileStream input = new FileStream(myCam.fileProcess, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    nProcess = binaryReader.ReadInt32();
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
            if (nProcess == 140 || nProcess == 150)
            {
                curAero = myCam.fileAero;
                curStrip = myCam.aeroStrip;
            }
            if (nProcess == 300)
            {
                curAero = myCam.stereoModel;
                curStrip = myCam.modelStrip;
            }
            if (File.Exists(curStrip))
            {
                FileStream input = new FileStream(curStrip, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    kStrip = binaryReader.ReadInt32();
                    for (int index = 1; index <= kStrip; ++index)
                    {
                        myCam.kModelStrip[index] = binaryReader.ReadInt32();
                        myCam.numCamera[index] = binaryReader.ReadInt64();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Операция чтения завершилась неудачно, как и ожидалось.");
                }
                finally
                {
                    binaryReader.Close();
                    input.Close();
                }
            }
            InitStore();
            if (File.Exists(curAero))
            {
                FileStream input = new FileStream(curAero, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    string str1 = "";
                    string str2 = "";
                    for (int index1 = 1; index1 <= kStrip; ++index1)
                    {
                        kStereo = myCam.kModelStrip[index1];
                        myCam.numCamera[index1] = 0L;
                        for (int index2 = 1; index2 <= kStereo; ++index2)
                        {
                            nMod = binaryReader.ReadInt64();
                            nLeft = binaryReader.ReadInt32();
                            nRight = binaryReader.ReadInt32();
                            kMark = binaryReader.ReadInt32();
                            kPnt = binaryReader.ReadInt32();
                            for (int index3 = 1; index3 <= kPnt; ++index3)
                            {
                                sName = binaryReader.ReadString();
                                xl = binaryReader.ReadDouble();
                                yl = binaryReader.ReadDouble();
                                xr = binaryReader.ReadDouble();
                                yr = binaryReader.ReadDouble();
                            }
                            if (index2 == 1)
                                str1 = Convert.ToString(nLeft);
                            if (index2 == kStereo)
                                str2 = Convert.ToString(nRight);
                        }
                        sTmp = " " + str1 + "-" + str2;
                        listBox1.Items.Add((object)sTmp);
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
            if (!File.Exists(myCam.fstoreCam))
                return;
            FileStream input1 = new FileStream(myCam.fstoreCam, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader1 = new BinaryReader((Stream)input1);
            try
            {
                kCamera = Convert.ToInt32(binaryReader1.ReadString());
                for (int j = 1; j <= kCamera; ++j)
                {
                    numCam[j] = binaryReader1.ReadString();
                    nameCam[j] = binaryReader1.ReadString();
                    focCam[j] = binaryReader1.ReadString();
                    xoCam[j] = binaryReader1.ReadString();
                    yoCam[j] = binaryReader1.ReadString();
                    markCam[j] = binaryReader1.ReadString();
                    dstrCam[j] = binaryReader1.ReadString();
                    BoxData(j);
                    int int32_1 = Convert.ToInt32(markCam[j]);
                    int int32_2 = Convert.ToInt32(dstrCam[j]);
                    if (int32_1 > 0)
                    {
                        for (int index = 1; index <= int32_1; ++index)
                        {
                            n[index] = binaryReader1.ReadString();
                            x[index] = binaryReader1.ReadString();
                            y[index] = binaryReader1.ReadString();
                        }
                    }
                    if (int32_2 > 0)
                    {
                        for (int index = 1; index <= int32_2; ++index)
                        {
                            xd[index] = binaryReader1.ReadString();
                            yd[index] = binaryReader1.ReadString();
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
                input1.Close();
                binaryReader1.Close();
            }
        }

        private void InitStore()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = "";
            textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = "";
            textBox16.Text = textBox17.Text = textBox18.Text = textBox19.Text = textBox20.Text = "";
            textBox21.Text = textBox22.Text = textBox23.Text = textBox24.Text = textBox25.Text = "";
            textBox26.Text = textBox27.Text = textBox28.Text = textBox29.Text = textBox30.Text = "";
            textBox31.Text = textBox32.Text = textBox33.Text = textBox34.Text = textBox35.Text = "";
        }

        private void BoxData(int j)
        {
            if (j == 1)
            {
                textBox1.Text = numCam[j];
                textBox2.Text = nameCam[j];
                textBox3.Text = focCam[j];
                textBox4.Text = xoCam[j];
                textBox5.Text = yoCam[j];
                textBox6.Text = markCam[j];
                textBox7.Text = dstrCam[j];
            }
            if (j == 2)
            {
                textBox8.Text = numCam[j];
                textBox9.Text = nameCam[j];
                textBox10.Text = focCam[j];
                textBox11.Text = xoCam[j];
                textBox12.Text = yoCam[j];
                textBox13.Text = markCam[j];
                textBox14.Text = dstrCam[j];
            }
            if (j == 3)
            {
                textBox15.Text = numCam[j];
                textBox16.Text = nameCam[j];
                textBox17.Text = focCam[j];
                textBox18.Text = xoCam[j];
                textBox19.Text = yoCam[j];
                textBox20.Text = markCam[j];
                textBox21.Text = dstrCam[j];
            }
            if (j == 4)
            {
                textBox22.Text = numCam[j];
                textBox23.Text = nameCam[j];
                textBox24.Text = focCam[j];
                textBox25.Text = xoCam[j];
                textBox26.Text = yoCam[j];
                textBox27.Text = markCam[j];
                textBox28.Text = dstrCam[j];
            }
            if (j != 5)
                return;
            textBox29.Text = numCam[j];
            textBox30.Text = nameCam[j];
            textBox31.Text = focCam[j];
            textBox32.Text = xoCam[j];
            textBox33.Text = yoCam[j];
            textBox34.Text = markCam[j];
            textBox35.Text = dstrCam[j];
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                int num1 = (int)MessageBox.Show("Полоса(направление) не выбрано", "Полоса(направление)и камера", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string str1 = listBox1.SelectedItem.ToString();
                indx = listBox1.SelectedIndex + 1;
                string str2 = "";
                if (radioButton1.Checked)
                    str2 = textBox1.Text;
                if (radioButton2.Checked)
                    str2 = textBox8.Text;
                if (radioButton3.Checked)
                    str2 = textBox15.Text;
                if (radioButton4.Checked)
                    str2 = textBox22.Text;
                if (radioButton5.Checked)
                    str2 = textBox29.Text;
                if (str2 != "")
                    numSel = Convert.ToInt64(str2);
                if (str2 == "" || numSel == 0L)
                {
                    int num2 = (int)MessageBox.Show("Данные выбранной камеры отсутствуют", "Полоса(направление)и камера", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    sTmp = str1 + "                   " + str2;
                    listBox2.Items.Add((object)sTmp);
                    ++kSel;
                    sSel[kSel] = sTmp;
                    myCam.numCamera[indx] = numSel;
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex < 0)
            {
                int num = (int)MessageBox.Show("Полоса(направление) не выбрано", "Полоса(направление)и камера", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (kSel == 0)
                    return;
                indx = listBox2.SelectedIndex + 1;
                myCam.numCamera[indx] = 0L;
                for (int index = 1; index <= kSel; ++index)
                {
                    if (indx == index)
                    {
                        sSel[index] = "";
                        break;
                    }
                }
                int index1 = 0;
                for (int index2 = 1; index2 <= kSel; ++index2)
                {
                    if (!(sSel[index2] == ""))
                    {
                        ++index1;
                        sSel[index1] = sSel[index2];
                    }
                }
                kSel = index1;
                listBox2.Items.Clear();
                if (kSel <= 0)
                    return;
                for (int index3 = 1; index3 <= kSel; ++index3)
                    listBox2.Items.Add((object)sSel[index3]);
            }
        }

        private void ExitKeep_Click(object sender, EventArgs e)
        {
            myCam.numCamera[listBox1.SelectedIndex + 1] = numSel;
            if (myCam.numCamera[1] == 0L)
            {
                int num = (int)MessageBox.Show("Номер для первой камеры направления не может быть = 0", "Полоса(направление)и камера", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(curStrip))
                    File.Delete(curStrip);
                FileStream output = new FileStream(curStrip, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(kStrip);
                for (int index = 1; index <= kStrip; ++index)
                {
                    if (myCam.numCamera[index] == 0L)
                        myCam.numCamera[index] = myCam.numCamera[index - 1];
                    binaryWriter.Write(myCam.kModelStrip[index]);
                    binaryWriter.Write(myCam.numCamera[index]);
                }
                output.Close();
                binaryWriter.Close();
                Form.ActiveForm.Close();
            }
        }

        private void ExitNoKeep_Click(object sender, EventArgs e) => Form.ActiveForm.Close();
    }
}
