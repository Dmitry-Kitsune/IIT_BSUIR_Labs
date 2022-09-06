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
    public partial class LegalArea : Form
    {
        private string sTmp = "";
        private int kPolySource;
        private int kPoly;
        private int kInter;
        private int kTen;
        private int kDop;
        private int k;
        private int i1;
        private int i2;
        private int iToler;
        private int[] kt1 = new int[1000];
        private int[] kt2 = new int[1000];
        private char[] sFormula = new char[50];
        private double toler;
        private int iCond;
        private MyGeodesy ar = new MyGeodesy();
        public LegalArea()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            button1.Visible = false;
            button2.Visible = false;
        }

        private void LegalArea_Load(object sender, EventArgs e)
        {
            ar.FilePath();
            ar.PolygonLoad(ref ar.kPolyInside);
            iToler = 0;
            if (File.Exists(ar.fileToler))
            {
                FileStream input = new FileStream(ar.fileToler, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    sTmp = binaryReader.ReadString();
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
                iToler = 1;
                for (int index = 0; index < sTmp.Length; ++index)
                    sFormula[index] = sTmp[index];
            }
            CalcToler();
            kPoly = ar.kPoly;
            kInter = ar.kInter;
            this.kTen = kPoly / 10;
            kDop = kPoly - this.kTen * 10;
            kt1[1] = 1;
            kt2[1] = 10;
            int kTen = this.kTen;
            if (kTen == 0)
            {
                kTen = 1;
                kt2[1] = kDop;
            }
            if (kTen > 1)
            {
                for (int index = 2; index <= kTen; ++index)
                {
                    kt1[index] = kt2[index - 1] + 1;
                    kt2[index] = kt2[index - 1] + 10;
                }
            }
            if (kTen > 0 && kDop > 0)
            {
                ++kTen;
                kt1[kTen] = kt2[kTen - 1] + 1;
                kt2[kTen] = kt2[kTen - 1] + kDop;
            }
            if (kTen > 1)
                button2.Visible = true;
            i1 = kt1[1];
            i2 = kt2[1];
            BackNext(i1, i2);
            k = 1;
        }

        private void CalcToler()
        {
            if (iToler == 0)
            {
                for (int index = 1; index <= ar.kPoly; ++index)
                {
                    ar.nameAdd[index] = "";
                    ar.nameDop[index] = "";
                    ar.nameWork[index] = "";
                }
            }
            if (iToler <= 0)
                return;
            for (int index = 1; index <= ar.kPoly; ++index)
            {
                double num1 = Math.Abs(ar.areaLeg[index] - ar.areaPol[index]);
                double num2 = ar.areaLeg[index] - ar.areaPol[index];
                DllClass1.TolerFormula(ref sFormula, ar.areaPol[index], out toler);
                ar.nameAdd[index] = string.Format("{0:F2}", (object)num2);
                ar.nameDop[index] = string.Format("{0:F2}", (object)toler);
                if (num1 > toler)
                    ar.nameWork[index] = "Over";
            }
        }

        private void BackNext(int i1, int i2)
        {
            textBox1.Text = ar.namePoly[i1];
            textBox2.Text = string.Format("{0:F4}", (object)ar.areaPol[i1]);
            textBox3.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1]);
            textBox31.Text = ar.nameAdd[i1];
            textBox32.Text = ar.nameDop[i1];
            textBox51.Text = ar.nameWork[i1];
            int num1 = i1 + 1;
            if (i2 >= num1)
            {
                textBox4.Text = ar.namePoly[i1 + 1];
                textBox5.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 1]);
                textBox6.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 1]);
                textBox33.Text = ar.nameAdd[i1 + 1];
                textBox34.Text = ar.nameDop[i1 + 1];
                textBox52.Text = ar.nameWork[i1 + 1];
            }
            int num2 = i1 + 2;
            if (i2 >= num2)
            {
                textBox4.Text = ar.namePoly[i1 + 1];
                textBox5.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 1]);
                textBox6.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 1]);
                textBox7.Text = ar.namePoly[i1 + 2];
                textBox8.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 2]);
                textBox9.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 2]);
                textBox33.Text = ar.nameAdd[i1 + 1];
                textBox34.Text = ar.nameDop[i1 + 1];
                textBox52.Text = ar.nameWork[i1 + 1];
                textBox35.Text = ar.nameAdd[i1 + 2];
                textBox36.Text = ar.nameDop[i1 + 2];
                textBox53.Text = ar.nameWork[i1 + 2];
            }
            int num3 = i1 + 3;
            if (i2 >= num3)
            {
                textBox4.Text = ar.namePoly[i1 + 1];
                textBox5.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 1]);
                textBox6.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 1]);
                textBox7.Text = ar.namePoly[i1 + 2];
                textBox8.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 2]);
                textBox9.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 2]);
                textBox10.Text = ar.namePoly[i1 + 3];
                textBox11.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 3]);
                textBox12.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 3]);
                textBox33.Text = ar.nameAdd[i1 + 1];
                textBox34.Text = ar.nameDop[i1 + 1];
                textBox52.Text = ar.nameWork[i1 + 1];
                textBox35.Text = ar.nameAdd[i1 + 2];
                textBox36.Text = ar.nameDop[i1 + 2];
                textBox53.Text = ar.nameWork[i1 + 2];
                textBox37.Text = ar.nameAdd[i1 + 3];
                textBox38.Text = ar.nameDop[i1 + 3];
                textBox54.Text = ar.nameWork[i1 + 3];
            }
            int num4 = i1 + 4;
            if (i2 >= num4)
            {
                textBox4.Text = ar.namePoly[i1 + 1];
                textBox5.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 1]);
                textBox6.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 1]);
                textBox7.Text = ar.namePoly[i1 + 2];
                textBox8.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 2]);
                textBox9.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 2]);
                textBox10.Text = ar.namePoly[i1 + 3];
                textBox11.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 3]);
                textBox12.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 3]);
                textBox13.Text = ar.namePoly[i1 + 4];
                textBox14.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 4]);
                textBox15.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 4]);
                textBox33.Text = ar.nameAdd[i1 + 1];
                textBox34.Text = ar.nameDop[i1 + 1];
                textBox52.Text = ar.nameWork[i1 + 1];
                textBox35.Text = ar.nameAdd[i1 + 2];
                textBox36.Text = ar.nameDop[i1 + 2];
                textBox53.Text = ar.nameWork[i1 + 2];
                textBox37.Text = ar.nameAdd[i1 + 3];
                textBox38.Text = ar.nameDop[i1 + 3];
                textBox54.Text = ar.nameWork[i1 + 3];
                textBox39.Text = ar.nameAdd[i1 + 4];
                textBox40.Text = ar.nameDop[i1 + 4];
                textBox55.Text = ar.nameWork[i1 + 4];
            }
            int num5 = i1 + 5;
            if (i2 >= num5)
            {
                textBox4.Text = ar.namePoly[i1 + 1];
                textBox5.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 1]);
                textBox6.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 1]);
                textBox7.Text = ar.namePoly[i1 + 2];
                textBox8.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 2]);
                textBox9.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 2]);
                textBox10.Text = ar.namePoly[i1 + 3];
                textBox11.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 3]);
                textBox12.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 3]);
                textBox13.Text = ar.namePoly[i1 + 4];
                textBox14.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 4]);
                textBox15.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 4]);
                textBox16.Text = ar.namePoly[i1 + 5];
                textBox17.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 5]);
                textBox18.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 5]);
                textBox33.Text = ar.nameAdd[i1 + 1];
                textBox34.Text = ar.nameDop[i1 + 1];
                textBox52.Text = ar.nameWork[i1 + 1];
                textBox35.Text = ar.nameAdd[i1 + 2];
                textBox36.Text = ar.nameDop[i1 + 2];
                textBox53.Text = ar.nameWork[i1 + 2];
                textBox37.Text = ar.nameAdd[i1 + 3];
                textBox38.Text = ar.nameDop[i1 + 3];
                textBox54.Text = ar.nameWork[i1 + 3];
                textBox39.Text = ar.nameAdd[i1 + 4];
                textBox40.Text = ar.nameDop[i1 + 4];
                textBox55.Text = ar.nameWork[i1 + 4];
                textBox41.Text = ar.nameAdd[i1 + 5];
                textBox42.Text = ar.nameDop[i1 + 5];
                textBox56.Text = ar.nameWork[i1 + 5];
            }
            int num6 = i1 + 6;
            if (i2 >= num6)
            {
                textBox4.Text = ar.namePoly[i1 + 1];
                textBox5.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 1]);
                textBox6.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 1]);
                textBox7.Text = ar.namePoly[i1 + 2];
                textBox8.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 2]);
                textBox9.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 2]);
                textBox10.Text = ar.namePoly[i1 + 3];
                textBox11.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 3]);
                textBox12.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 3]);
                textBox13.Text = ar.namePoly[i1 + 4];
                textBox14.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 4]);
                textBox15.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 4]);
                textBox16.Text = ar.namePoly[i1 + 5];
                textBox17.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 5]);
                textBox18.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 5]);
                textBox19.Text = ar.namePoly[i1 + 6];
                textBox20.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 6]);
                textBox21.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 6]);
                textBox33.Text = ar.nameAdd[i1 + 1];
                textBox34.Text = ar.nameDop[i1 + 1];
                textBox52.Text = ar.nameWork[i1 + 1];
                textBox35.Text = ar.nameAdd[i1 + 2];
                textBox36.Text = ar.nameDop[i1 + 2];
                textBox53.Text = ar.nameWork[i1 + 2];
                textBox37.Text = ar.nameAdd[i1 + 3];
                textBox38.Text = ar.nameDop[i1 + 3];
                textBox54.Text = ar.nameWork[i1 + 3];
                textBox39.Text = ar.nameAdd[i1 + 4];
                textBox40.Text = ar.nameDop[i1 + 4];
                textBox55.Text = ar.nameWork[i1 + 4];
                textBox41.Text = ar.nameAdd[i1 + 5];
                textBox42.Text = ar.nameDop[i1 + 5];
                textBox56.Text = ar.nameWork[i1 + 5];
                textBox43.Text = ar.nameAdd[i1 + 6];
                textBox44.Text = ar.nameDop[i1 + 6];
                textBox57.Text = ar.nameWork[i1 + 6];
            }
            int num7 = i1 + 7;
            if (i2 >= num7)
            {
                textBox4.Text = ar.namePoly[i1 + 1];
                textBox5.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 1]);
                textBox6.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 1]);
                textBox7.Text = ar.namePoly[i1 + 2];
                textBox8.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 2]);
                textBox9.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 2]);
                textBox10.Text = ar.namePoly[i1 + 3];
                textBox11.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 3]);
                textBox12.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 3]);
                textBox13.Text = ar.namePoly[i1 + 4];
                textBox14.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 4]);
                textBox15.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 4]);
                textBox16.Text = ar.namePoly[i1 + 5];
                textBox17.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 5]);
                textBox18.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 5]);
                textBox19.Text = ar.namePoly[i1 + 6];
                textBox20.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 6]);
                textBox21.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 6]);
                textBox22.Text = ar.namePoly[i1 + 7];
                textBox23.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 7]);
                textBox24.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 7]);
                textBox33.Text = ar.nameAdd[i1 + 1];
                textBox34.Text = ar.nameDop[i1 + 1];
                textBox52.Text = ar.nameWork[i1 + 1];
                textBox35.Text = ar.nameAdd[i1 + 2];
                textBox36.Text = ar.nameDop[i1 + 2];
                textBox53.Text = ar.nameWork[i1 + 2];
                textBox37.Text = ar.nameAdd[i1 + 3];
                textBox38.Text = ar.nameDop[i1 + 3];
                textBox54.Text = ar.nameWork[i1 + 3];
                textBox39.Text = ar.nameAdd[i1 + 4];
                textBox40.Text = ar.nameDop[i1 + 4];
                textBox55.Text = ar.nameWork[i1 + 4];
                textBox41.Text = ar.nameAdd[i1 + 5];
                textBox42.Text = ar.nameDop[i1 + 5];
                textBox56.Text = ar.nameWork[i1 + 5];
                textBox43.Text = ar.nameAdd[i1 + 6];
                textBox44.Text = ar.nameDop[i1 + 6];
                textBox57.Text = ar.nameWork[i1 + 6];
                textBox45.Text = ar.nameAdd[i1 + 7];
                textBox46.Text = ar.nameDop[i1 + 7];
                textBox58.Text = ar.nameWork[i1 + 7];
            }
            int num8 = i1 + 8;
            if (i2 >= num8)
            {
                textBox4.Text = ar.namePoly[i1 + 1];
                textBox5.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 1]);
                textBox6.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 1]);
                textBox7.Text = ar.namePoly[i1 + 2];
                textBox8.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 2]);
                textBox9.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 2]);
                textBox10.Text = ar.namePoly[i1 + 3];
                textBox11.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 3]);
                textBox12.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 3]);
                textBox13.Text = ar.namePoly[i1 + 4];
                textBox14.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 4]);
                textBox15.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 4]);
                textBox16.Text = ar.namePoly[i1 + 5];
                textBox17.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 5]);
                textBox18.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 5]);
                textBox19.Text = ar.namePoly[i1 + 6];
                textBox20.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 6]);
                textBox21.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 6]);
                textBox22.Text = ar.namePoly[i1 + 7];
                textBox23.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 7]);
                textBox24.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 7]);
                textBox25.Text = ar.namePoly[i1 + 8];
                textBox26.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 8]);
                textBox27.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 8]);
                textBox33.Text = ar.nameAdd[i1 + 1];
                textBox34.Text = ar.nameDop[i1 + 1];
                textBox52.Text = ar.nameWork[i1 + 1];
                textBox35.Text = ar.nameAdd[i1 + 2];
                textBox36.Text = ar.nameDop[i1 + 2];
                textBox53.Text = ar.nameWork[i1 + 2];
                textBox37.Text = ar.nameAdd[i1 + 3];
                textBox38.Text = ar.nameDop[i1 + 3];
                textBox54.Text = ar.nameWork[i1 + 3];
                textBox39.Text = ar.nameAdd[i1 + 4];
                textBox40.Text = ar.nameDop[i1 + 4];
                textBox55.Text = ar.nameWork[i1 + 4];
                textBox41.Text = ar.nameAdd[i1 + 5];
                textBox42.Text = ar.nameDop[i1 + 5];
                textBox56.Text = ar.nameWork[i1 + 5];
                textBox43.Text = ar.nameAdd[i1 + 6];
                textBox44.Text = ar.nameDop[i1 + 6];
                textBox57.Text = ar.nameWork[i1 + 6];
                textBox45.Text = ar.nameAdd[i1 + 7];
                textBox46.Text = ar.nameDop[i1 + 7];
                textBox58.Text = ar.nameWork[i1 + 7];
                textBox47.Text = ar.nameAdd[i1 + 8];
                textBox48.Text = ar.nameDop[i1 + 8];
                textBox59.Text = ar.nameWork[i1 + 8];
            }
            int num9 = i1 + 9;
            if (i2 < num9)
                return;
            textBox4.Text = ar.namePoly[i1 + 1];
            textBox5.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 1]);
            textBox6.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 1]);
            textBox7.Text = ar.namePoly[i1 + 2];
            textBox8.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 2]);
            textBox9.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 2]);
            textBox10.Text = ar.namePoly[i1 + 3];
            textBox11.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 3]);
            textBox12.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 3]);
            textBox13.Text = ar.namePoly[i1 + 4];
            textBox14.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 4]);
            textBox15.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 4]);
            textBox16.Text = ar.namePoly[i1 + 5];
            textBox17.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 5]);
            textBox18.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 5]);
            textBox19.Text = ar.namePoly[i1 + 6];
            textBox20.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 6]);
            textBox21.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 6]);
            textBox22.Text = ar.namePoly[i1 + 7];
            textBox23.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 7]);
            textBox24.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 7]);
            textBox25.Text = ar.namePoly[i1 + 8];
            textBox26.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 8]);
            textBox27.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 8]);
            textBox28.Text = ar.namePoly[i1 + 9];
            textBox29.Text = string.Format("{0:F4}", (object)ar.areaPol[i1 + 9]);
            textBox30.Text = string.Format("{0:F4}", (object)ar.areaLeg[i1 + 9]);
            textBox33.Text = ar.nameAdd[i1 + 1];
            textBox34.Text = ar.nameDop[i1 + 1];
            textBox52.Text = ar.nameWork[i1 + 1];
            textBox35.Text = ar.nameAdd[i1 + 2];
            textBox36.Text = ar.nameDop[i1 + 2];
            textBox53.Text = ar.nameWork[i1 + 2];
            textBox37.Text = ar.nameAdd[i1 + 3];
            textBox38.Text = ar.nameDop[i1 + 3];
            textBox54.Text = ar.nameWork[i1 + 3];
            textBox39.Text = ar.nameAdd[i1 + 4];
            textBox40.Text = ar.nameDop[i1 + 4];
            textBox55.Text = ar.nameWork[i1 + 4];
            textBox41.Text = ar.nameAdd[i1 + 5];
            textBox42.Text = ar.nameDop[i1 + 5];
            textBox56.Text = ar.nameWork[i1 + 5];
            textBox43.Text = ar.nameAdd[i1 + 6];
            textBox44.Text = ar.nameDop[i1 + 6];
            textBox57.Text = ar.nameWork[i1 + 6];
            textBox45.Text = ar.nameAdd[i1 + 7];
            textBox46.Text = ar.nameDop[i1 + 7];
            textBox58.Text = ar.nameWork[i1 + 7];
            textBox47.Text = ar.nameAdd[i1 + 8];
            textBox48.Text = ar.nameDop[i1 + 8];
            textBox59.Text = ar.nameWork[i1 + 8];
            textBox49.Text = ar.nameAdd[i1 + 9];
            textBox50.Text = ar.nameDop[i1 + 9];
            textBox60.Text = ar.nameWork[i1 + 9];
        }

        private void KeepData(int i1, int i2)
        {
            if (textBox3.Text != "")
            {
                DllClass1.CheckText(textBox3.Text, out ar.areaLeg[i1], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ar.namePoly[i1] = textBox1.Text;
            }
            if (textBox6.Text != "")
            {
                DllClass1.CheckText(textBox6.Text, out ar.areaLeg[i1 + 1], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ar.namePoly[i1 + 1] = textBox4.Text;
            }
            if (textBox9.Text != "")
            {
                DllClass1.CheckText(textBox9.Text, out ar.areaLeg[i1 + 2], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ar.namePoly[i1 + 2] = textBox7.Text;
            }
            if (textBox12.Text != "")
            {
                DllClass1.CheckText(textBox12.Text, out ar.areaLeg[i1 + 3], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ar.namePoly[i1 + 3] = textBox10.Text;
            }
            if (textBox15.Text != "")
            {
                DllClass1.CheckText(textBox15.Text, out ar.areaLeg[i1 + 4], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ar.namePoly[i1 + 4] = textBox13.Text;
            }
            if (textBox18.Text != "")
            {
                DllClass1.CheckText(textBox18.Text, out ar.areaLeg[i1 + 5], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ar.namePoly[i1 + 5] = textBox16.Text;
            }
            if (textBox21.Text != "")
            {
                DllClass1.CheckText(textBox21.Text, out ar.areaLeg[i1 + 6], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ar.namePoly[i1 + 6] = textBox19.Text;
            }
            if (textBox24.Text != "")
            {
                DllClass1.CheckText(textBox24.Text, out ar.areaLeg[i1 + 7], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ar.namePoly[i1 + 7] = textBox22.Text;
            }
            if (textBox27.Text != "")
            {
                DllClass1.CheckText(textBox27.Text, out ar.areaLeg[i1 + 8], out iCond);
                if (iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ar.namePoly[i1 + 8] = textBox25.Text;
            }
            if (!(textBox30.Text != ""))
                return;
            DllClass1.CheckText(textBox30.Text, out ar.areaLeg[i1 + 9], out iCond);
            if (iCond < 0)
            {
                int num1 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                ar.namePoly[i1 + 9] = textBox28.Text;
        }

        private void InitData()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = "";
            textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = "";
            textBox16.Text = textBox17.Text = textBox18.Text = textBox19.Text = textBox20.Text = "";
            textBox21.Text = textBox22.Text = textBox23.Text = textBox24.Text = textBox25.Text = "";
            textBox26.Text = textBox27.Text = textBox28.Text = textBox29.Text = textBox30.Text = "";
            textBox31.Text = textBox32.Text = textBox33.Text = textBox34.Text = textBox35.Text = "";
            textBox36.Text = textBox37.Text = textBox38.Text = textBox39.Text = textBox40.Text = "";
            textBox41.Text = textBox42.Text = textBox43.Text = textBox44.Text = textBox45.Text = "";
            textBox46.Text = textBox47.Text = textBox48.Text = textBox49.Text = textBox50.Text = "";
            textBox51.Text = textBox52.Text = textBox53.Text = textBox54.Text = textBox55.Text = "";
            textBox56.Text = textBox57.Text = textBox58.Text = textBox59.Text = textBox60.Text = "";
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (k > 1)
            {
                i1 = kt1[k];
                i2 = kt2[k];
                KeepData(i1, i2);
                --k;
                i1 = kt1[k];
                i2 = kt2[k];
                InitData();
                BackNext(i1, i2);
                button2.Visible = true;
            }
            if (k != 1)
                return;
            i1 = kt1[k];
            i2 = kt2[k];
            KeepData(i1, i2);
            button1.Visible = false;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            i1 = kt1[k];
            i2 = kt2[k];
            KeepData(i1, i2);
            button1.Visible = true;
            if (k < kTen)
            {
                InitData();
                ++k;
                i1 = kt1[k];
                i2 = kt2[k];
                BackNext(i1, i2);
            }
            if (k != kTen)
                return;
            button2.Visible = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            this.i1 = this.kt1[this.k];
            this.i2 = this.kt2[this.k];
            this.KeepData(this.i1, this.i2);
            this.ar.kPoly = this.kPoly;
            this.ar.KeepPoly();
            this.kPolySource = this.ar.kPoly;
            for (int index = 1; index <= this.ar.kPoly; ++index)
            {
                this.ar.nameSource[index] = this.ar.namePoly[index];
                this.ar.xLabSource[index] = this.ar.xLab[index];
                this.ar.yLabSource[index] = this.ar.yLab[index];
                this.ar.arCalcSource[index] = this.ar.areaPol[index];
                this.ar.arLegSource[index] = this.ar.areaLeg[index];
                this.ar.k1Source[index] = this.ar.kt1[index];
                this.ar.k2Source[index] = this.ar.kt2[index];
                this.i1 = this.ar.k1Source[index];
                this.i2 = this.ar.k2Source[index];
                for (int i1 = this.i1; i1 <= this.i2; ++i1)
                {
                    this.ar.xSource[i1] = this.ar.xPol[i1];
                    this.ar.ySource[i1] = this.ar.yPol[i1];
                }
            }
            this.ar.kPolySource = this.kPolySource;
            this.ar.LoadKeepSource(2);
            Form.ActiveForm.Close();
        }

        private void NameChange(int i1, int i2)
        {
            int index1 = i1;
            switch (index1)
            {
                case 1:
                case 11:
                case 21:
                case 31:
                case 41:
                case 51:
                case 61:
                case 71:
                case 81:
                case 91:
                    this.textBox1.Text = this.ar.namePoly[index1];
                    break;
            }
            int index2 = i1 + 1;
            if (i2 >= index2 && (index2 == 2 || index2 == 12 || index2 == 22 || index2 == 32 || index2 == 42 || index2 == 52 || index2 == 62 || index2 == 72 || index2 == 82 || index2 == 92))
                this.textBox4.Text = this.ar.namePoly[index2];
            int index3 = i1 + 2;
            if (i2 >= index3 && (index3 == 3 || index3 == 13 || index3 == 23 || index3 == 33 || index3 == 43 || index3 == 53 || index3 == 63 || index3 == 73 || index3 == 83 || index3 == 93))
                this.textBox7.Text = this.ar.namePoly[index3];
            int index4 = i1 + 3;
            if (i2 >= index4 && (index4 == 4 || index4 == 14 || index4 == 24 || index4 == 34 || index4 == 44 || index4 == 54 || index4 == 64 || index4 == 74 || index4 == 84 || index4 == 94))
                this.textBox10.Text = this.ar.namePoly[index4];
            int index5 = i1 + 4;
            if (i2 >= index5 && (index5 == 5 || index5 == 15 || index5 == 25 || index5 == 35 || index5 == 45 || index5 == 55 || index5 == 65 || index5 == 75 || index5 == 85 || index5 == 95))
                this.textBox13.Text = this.ar.namePoly[index5];
            int index6 = i1 + 5;
            if (i2 >= index6 && (index6 == 6 || index6 == 16 || index6 == 26 || index6 == 36 || index6 == 46 || index6 == 56 || index6 == 66 || index6 == 76 || index6 == 86 || index6 == 96))
                this.textBox16.Text = this.ar.namePoly[index6];
            int index7 = i1 + 6;
            if (i2 >= index7 && (index7 == 7 || index7 == 17 || index7 == 27 || index7 == 37 || index7 == 47 || index7 == 57 || index7 == 67 || index7 == 77 || index7 == 87 || index7 == 97))
                this.textBox19.Text = this.ar.namePoly[index7];
            int index8 = i1 + 7;
            if (i2 >= index8 && (index8 == 8 || index8 == 18 || index8 == 28 || index8 == 38 || index8 == 48 || index8 == 58 || index8 == 68 || index8 == 78 || index8 == 88 || index8 == 98))
                this.textBox22.Text = this.ar.namePoly[index8];
            int index9 = i1 + 8;
            if (i2 >= index9 && (index9 == 9 || index9 == 19 || index9 == 29 || index9 == 39 || index9 == 49 || index9 == 59 || index9 == 69 || index9 == 79 || index9 == 89 || index9 == 99))
                this.textBox25.Text = this.ar.namePoly[index9];
            int index10 = i1 + 9;
            if (i2 < index10 || index10 != 10 && index10 != 20 && index10 != 30 && index10 != 40 && index10 != 50 && index10 != 60 && index10 != 70 && index10 != 80 && index10 != 90 && index10 != 100)
                return;
            this.textBox28.Text = this.ar.namePoly[index10];
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (this.textBox61.Text != "F" && this.textBox61.Text != "T")
            {
                int num = (int)MessageBox.Show("Введите символ'F' или 'T' ", "Имена участков", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                for (int index = 1; index <= this.kPoly; ++index)
                {
                    this.sTmp = this.ar.namePoly[index];
                    if (this.sTmp[0] != 'F' && this.sTmp[0] != 'T')
                        this.ar.namePoly[index] = this.textBox61.Text + this.sTmp;
                }
                this.i1 = this.kt1[1];
                this.i2 = this.kt2[1];
                this.NameChange(this.i1, this.i2);
            }
        }

        private void Cancel_Click(object sender, EventArgs e) => Form.ActiveForm.Close();
    }
}
