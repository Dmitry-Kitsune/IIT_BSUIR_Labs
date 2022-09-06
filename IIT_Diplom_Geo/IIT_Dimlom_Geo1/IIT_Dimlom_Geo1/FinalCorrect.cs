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
    public partial class FinalCorrect : Form
    {
        private string sTmp = "";
        private int kSymbPoly;
        private int kPolyFinal;
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
        private int hSymbPoly = 30;

        private MyGeodesy fin = new MyGeodesy();
        public FinalCorrect()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.FormLoad();
        }

        private void FormLoad()
        {
            this.fin.FilePath();
            this.fin.PolySymbolLoad(this.fin.fsymbPoly, out this.kSymbPoly, out this.hSymbPoly);
            this.fin.PolyLoadFin();
            this.iToler = 0;
            if (File.Exists(this.fin.fileToler))
            {
                FileStream input = new FileStream(this.fin.fileToler, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    this.sTmp = binaryReader.ReadString();
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
                this.iToler = 1;
                for (int index = 0; index < this.sTmp.Length; ++index)
                    this.sFormula[index] = this.sTmp[index];
            }
            this.CalcToler();
            this.kPolyFinal = this.fin.kPolyFinal;
            this.kInter = this.fin.kInter;
            this.kTen = this.kPolyFinal / 10;
            this.kDop = this.kPolyFinal - this.kTen * 10;
            this.kt1[1] = 1;
            this.kt2[1] = 10;
            int kTen = this.kTen;
            if (this.kTen == 0)
            {
                this.kTen = 1;
                this.kt2[1] = this.kDop;
            }
            if (this.kTen > 1)
            {
                for (int index = 2; index <= this.kTen; ++index)
                {
                    this.kt1[index] = this.kt2[index - 1] + 1;
                    this.kt2[index] = this.kt2[index - 1] + 10;
                }
            }
            if (kTen > 0 && this.kDop > 0)
            {
                ++this.kTen;
                this.kt1[this.kTen] = this.kt2[this.kTen - 1] + 1;
                this.kt2[this.kTen] = this.kt2[this.kTen - 1] + this.kDop;
            }
            if (this.kTen > 1)
                this.button2.Visible = true;
            this.i1 = this.kt1[1];
            this.i2 = this.kt2[1];
            this.BackNext(this.i1, this.i2);
            this.k = 1;
        }

        private void CalcToler()
        {
            if (this.iToler == 0)
            {
                for (int index = 1; index <= this.fin.kPolyFinal; ++index)
                {
                    this.fin.nameAdd[index] = "";
                    this.fin.nameDop[index] = "";
                    this.fin.nameWork[index] = "";
                }
            }
            if (this.iToler <= 0)
                return;
            for (int index = 1; index <= this.fin.kPolyFinal; ++index)
            {
                double num = Math.Abs(this.fin.arLegFin[index] - this.fin.arCalcFin[index]);
                DllClass1.TolerFormula(ref this.sFormula, this.fin.arCalcFin[index], out this.toler);
                this.fin.nameAdd[index] = string.Format("{0:F4}", (object)num);
                this.fin.nameDop[index] = string.Format("{0:F4}", (object)this.toler);
                if (num > this.toler)
                    this.fin.nameWork[index] = "Over";
            }
        }

        private void BackNext(int i1, int i2)
        {
            this.textBox1.Text = this.fin.namePolyFin[i1];
            this.textBox11.Text = string.Format("{0}", (object)this.fin.nSymbFin[i1]);
            this.textBox21.Text = string.Format("{0:F4}", (object)this.fin.arCalcFin[i1]);
            this.textBox31.Text = string.Format("{0:F4}", (object)this.fin.arLegFin[i1]);
            this.textBox41.Text = this.fin.nameAdd[i1];
            this.textBox51.Text = this.fin.nameDop[i1];
            this.textBox61.Text = this.fin.nameWork[i1];
            if (i2 >= i1 + 1)
            {
                int index = i1 + 1;
                this.textBox2.Text = this.fin.namePolyFin[index];
                this.textBox12.Text = string.Format("{0}", (object)this.fin.nSymbFin[index]);
                this.textBox22.Text = string.Format("{0:F4}", (object)this.fin.arCalcFin[index]);
                this.textBox32.Text = string.Format("{0:F4}", (object)this.fin.arLegFin[index]);
                this.textBox42.Text = this.fin.nameAdd[index];
                this.textBox52.Text = this.fin.nameDop[index];
                this.textBox62.Text = this.fin.nameWork[index];
            }
            if (i2 >= i1 + 2)
            {
                int index = i1 + 2;
                this.textBox3.Text = this.fin.namePolyFin[index];
                this.textBox13.Text = string.Format("{0}", (object)this.fin.nSymbFin[index]);
                this.textBox23.Text = string.Format("{0:F4}", (object)this.fin.arCalcFin[index]);
                this.textBox33.Text = string.Format("{0:F4}", (object)this.fin.arLegFin[index]);
                this.textBox43.Text = this.fin.nameAdd[index];
                this.textBox53.Text = this.fin.nameDop[index];
                this.textBox63.Text = this.fin.nameWork[index];
            }
            if (i2 >= i1 + 3)
            {
                int index = i1 + 3;
                this.textBox4.Text = this.fin.namePolyFin[index];
                this.textBox14.Text = string.Format("{0}", (object)this.fin.nSymbFin[index]);
                this.textBox24.Text = string.Format("{0:F4}", (object)this.fin.arCalcFin[index]);
                this.textBox34.Text = string.Format("{0:F4}", (object)this.fin.arLegFin[index]);
                this.textBox44.Text = this.fin.nameAdd[index];
                this.textBox54.Text = this.fin.nameDop[index];
                this.textBox64.Text = this.fin.nameWork[index];
            }
            if (i2 >= i1 + 4)
            {
                int index = i1 + 4;
                this.textBox5.Text = this.fin.namePolyFin[index];
                this.textBox15.Text = string.Format("{0}", (object)this.fin.nSymbFin[index]);
                this.textBox25.Text = string.Format("{0:F4}", (object)this.fin.arCalcFin[index]);
                this.textBox35.Text = string.Format("{0:F4}", (object)this.fin.arLegFin[index]);
                this.textBox45.Text = this.fin.nameAdd[index];
                this.textBox55.Text = this.fin.nameDop[index];
                this.textBox65.Text = this.fin.nameWork[index];
            }
            if (i2 >= i1 + 5)
            {
                int index = i1 + 5;
                this.textBox6.Text = this.fin.namePolyFin[index];
                this.textBox16.Text = string.Format("{0}", (object)this.fin.nSymbFin[index]);
                this.textBox26.Text = string.Format("{0:F4}", (object)this.fin.arCalcFin[index]);
                this.textBox36.Text = string.Format("{0:F4}", (object)this.fin.arLegFin[index]);
                this.textBox46.Text = this.fin.nameAdd[index];
                this.textBox56.Text = this.fin.nameDop[index];
                this.textBox66.Text = this.fin.nameWork[index];
            }
            if (i2 >= i1 + 6)
            {
                int index = i1 + 6;
                this.textBox7.Text = this.fin.namePolyFin[index];
                this.textBox17.Text = string.Format("{0}", (object)this.fin.nSymbFin[index]);
                this.textBox27.Text = string.Format("{0:F4}", (object)this.fin.arCalcFin[index]);
                this.textBox37.Text = string.Format("{0:F4}", (object)this.fin.arLegFin[index]);
                this.textBox47.Text = this.fin.nameAdd[index];
                this.textBox57.Text = this.fin.nameDop[index];
                this.textBox67.Text = this.fin.nameWork[index];
            }
            if (i2 >= i1 + 7)
            {
                int index = i1 + 7;
                this.textBox8.Text = this.fin.namePolyFin[index];
                this.textBox18.Text = string.Format("{0}", (object)this.fin.nSymbFin[index]);
                this.textBox28.Text = string.Format("{0:F4}", (object)this.fin.arCalcFin[index]);
                this.textBox38.Text = string.Format("{0:F4}", (object)this.fin.arLegFin[index]);
                this.textBox48.Text = this.fin.nameAdd[index];
                this.textBox58.Text = this.fin.nameDop[index];
                this.textBox68.Text = this.fin.nameWork[index];
            }
            if (i2 >= i1 + 8)
            {
                int index = i1 + 8;
                this.textBox9.Text = this.fin.namePolyFin[index];
                this.textBox19.Text = string.Format("{0}", (object)this.fin.nSymbFin[index]);
                this.textBox29.Text = string.Format("{0:F4}", (object)this.fin.arCalcFin[index]);
                this.textBox39.Text = string.Format("{0:F4}", (object)this.fin.arLegFin[index]);
                this.textBox49.Text = this.fin.nameAdd[index];
                this.textBox59.Text = this.fin.nameDop[index];
                this.textBox69.Text = this.fin.nameWork[index];
            }
            if (i2 < i1 + 9)
                return;
            int index1 = i1 + 9;
            this.textBox10.Text = this.fin.namePolyFin[index1];
            this.textBox20.Text = string.Format("{0}", (object)this.fin.nSymbFin[index1]);
            this.textBox30.Text = string.Format("{0:F4}", (object)this.fin.arCalcFin[index1]);
            this.textBox40.Text = string.Format("{0:F4}", (object)this.fin.arLegFin[index1]);
            this.textBox50.Text = this.fin.nameAdd[index1];
            this.textBox60.Text = this.fin.nameDop[index1];
            this.textBox70.Text = this.fin.nameWork[index1];
        }

        private void InitData()
        {
            this.textBox1.Text = this.textBox2.Text = this.textBox3.Text = this.textBox4.Text = this.textBox5.Text = "";
            this.textBox6.Text = this.textBox7.Text = this.textBox8.Text = this.textBox9.Text = this.textBox10.Text = "";
            this.textBox11.Text = this.textBox12.Text = this.textBox13.Text = this.textBox14.Text = this.textBox15.Text = "";
            this.textBox16.Text = this.textBox17.Text = this.textBox18.Text = this.textBox19.Text = this.textBox20.Text = "";
            this.textBox21.Text = this.textBox22.Text = this.textBox23.Text = this.textBox24.Text = this.textBox25.Text = "";
            this.textBox26.Text = this.textBox27.Text = this.textBox28.Text = this.textBox29.Text = this.textBox30.Text = "";
            this.textBox31.Text = this.textBox32.Text = this.textBox33.Text = this.textBox34.Text = this.textBox35.Text = "";
            this.textBox36.Text = this.textBox37.Text = this.textBox38.Text = this.textBox39.Text = this.textBox40.Text = "";
            this.textBox41.Text = this.textBox42.Text = this.textBox43.Text = this.textBox44.Text = this.textBox45.Text = "";
            this.textBox46.Text = this.textBox47.Text = this.textBox48.Text = this.textBox49.Text = this.textBox50.Text = "";
            this.textBox51.Text = this.textBox52.Text = this.textBox53.Text = this.textBox54.Text = this.textBox55.Text = "";
            this.textBox56.Text = this.textBox57.Text = this.textBox58.Text = this.textBox59.Text = this.textBox60.Text = "";
            this.textBox61.Text = this.textBox62.Text = this.textBox63.Text = this.textBox64.Text = this.textBox65.Text = "";
            this.textBox66.Text = this.textBox67.Text = this.textBox68.Text = this.textBox69.Text = this.textBox70.Text = "";
        }

        private void KeepData(int i1, int i2)
        {
            if (this.textBox1.Text != "")
                this.fin.namePolyFin[i1] = this.textBox1.Text;
            if (this.textBox2.Text != "")
                this.fin.namePolyFin[i1 + 1] = this.textBox2.Text;
            if (this.textBox3.Text != "")
                this.fin.namePolyFin[i1 + 2] = this.textBox3.Text;
            if (this.textBox4.Text != "")
                this.fin.namePolyFin[i1 + 3] = this.textBox4.Text;
            if (this.textBox5.Text != "")
                this.fin.namePolyFin[i1 + 4] = this.textBox5.Text;
            if (this.textBox6.Text != "")
                this.fin.namePolyFin[i1 + 5] = this.textBox6.Text;
            if (this.textBox7.Text != "")
                this.fin.namePolyFin[i1 + 6] = this.textBox7.Text;
            if (this.textBox8.Text != "")
                this.fin.namePolyFin[i1 + 7] = this.textBox8.Text;
            if (this.textBox9.Text != "")
                this.fin.namePolyFin[i1 + 8] = this.textBox9.Text;
            if (this.textBox10.Text != "")
                this.fin.namePolyFin[i1 + 9] = this.textBox10.Text;
            double tText = 0.0;
            if (this.textBox11.Text != "")
            {
                DllClass1.CheckText(this.textBox11.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.fin.nSymbFin[i1] = Convert.ToInt32(this.textBox11.Text);
            }
            if (this.textBox12.Text != "")
            {
                DllClass1.CheckText(this.textBox12.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.fin.nSymbFin[i1 + 1] = Convert.ToInt32(this.textBox12.Text);
            }
            if (this.textBox13.Text != "")
            {
                DllClass1.CheckText(this.textBox13.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.fin.nSymbFin[i1 + 2] = Convert.ToInt32(this.textBox13.Text);
            }
            if (this.textBox14.Text != "")
            {
                DllClass1.CheckText(this.textBox14.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.fin.nSymbFin[i1 + 3] = Convert.ToInt32(this.textBox14.Text);
            }
            if (this.textBox15.Text != "")
            {
                DllClass1.CheckText(this.textBox15.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.fin.nSymbFin[i1 + 4] = Convert.ToInt32(this.textBox15.Text);
            }
            if (this.textBox16.Text != "")
            {
                DllClass1.CheckText(this.textBox16.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.fin.nSymbFin[i1 + 5] = Convert.ToInt32(this.textBox16.Text);
            }
            if (this.textBox17.Text != "")
            {
                DllClass1.CheckText(this.textBox17.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.fin.nSymbFin[i1 + 6] = Convert.ToInt32(this.textBox17.Text);
            }
            if (this.textBox18.Text != "")
            {
                DllClass1.CheckText(this.textBox18.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.fin.nSymbFin[i1 + 7] = Convert.ToInt32(this.textBox18.Text);
            }
            if (this.textBox19.Text != "")
            {
                DllClass1.CheckText(this.textBox19.Text, out tText, out this.iCond);
                if (this.iCond < 0)
                {
                    int num = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.fin.nSymbFin[i1 + 8] = Convert.ToInt32(this.textBox19.Text);
            }
            if (!(this.textBox20.Text != ""))
                return;
            DllClass1.CheckText(this.textBox20.Text, out tText, out this.iCond);
            if (this.iCond < 0)
            {
                int num1 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                this.fin.nSymbFin[i1 + 9] = Convert.ToInt32(this.textBox20.Text);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (this.k > 1)
            {
                this.i1 = this.kt1[this.k];
                this.i2 = this.kt2[this.k];
                this.KeepData(this.i1, this.i2);
                --this.k;
                this.i1 = this.kt1[this.k];
                this.i2 = this.kt2[this.k];
                this.InitData();
                this.BackNext(this.i1, this.i2);
                this.button2.Visible = true;
            }
            if (this.k != 1)
                return;
            this.i1 = this.kt1[this.k];
            this.i2 = this.kt2[this.k];
            this.KeepData(this.i1, this.i2);
            this.button1.Visible = false;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            this.i1 = this.kt1[this.k];
            this.i2 = this.kt2[this.k];
            this.KeepData(this.i1, this.i2);
            this.button1.Visible = true;
            if (this.k < this.kTen)
            {
                this.InitData();
                ++this.k;
                this.i1 = this.kt1[this.k];
                this.i2 = this.kt2[this.k];
                this.BackNext(this.i1, this.i2);
            }
            if (this.k != this.kTen)
                return;
            this.button2.Visible = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            this.i1 = this.kt1[this.k];
            this.i2 = this.kt2[this.k];
            this.KeepData(this.i1, this.i2);
            for (int index1 = 1; index1 <= this.kPolyFinal; ++index1)
            {
                this.i1 = 0;
                for (int index2 = 0; index2 <= this.kSymbPoly; ++index2)
                {
                    if (this.fin.np2Sign[index2] > 0 && this.fin.np2Sign[index2] == this.fin.nSymbFin[index1])
                    {
                        ++this.i1;
                        break;
                    }
                }
                this.i2 = 0;
                if (this.i1 == 0)
                {
                    for (int index3 = 0; index3 <= this.kSymbPoly; ++index3)
                    {
                        if (this.fin.np1Sign[index3] == this.fin.nSymbFin[index1])
                        {
                            ++this.i2;
                            break;
                        }
                    }
                    this.i1 = this.i2;
                }
                if (this.i1 == 0)
                {
                    this.sTmp = string.Format("{0}", (object)this.fin.nSymbFin[index1]);
                    int num = (int)MessageBox.Show(this.sTmp, "Неправильный номер символ участка");
                }
            }
            this.fin.kPolyFinal = this.kPolyFinal;
            this.fin.KeepPolyFin();
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
                    this.textBox1.Text = this.fin.namePolyFin[index1];
                    break;
            }
            int index2 = i1 + 1;
            if (i2 >= index2 && (index2 == 2 || index2 == 12 || index2 == 22 || index2 == 32 || index2 == 42 || index2 == 52 || index2 == 62 || index2 == 72 || index2 == 82 || index2 == 92))
                this.textBox2.Text = this.fin.namePolyFin[index2];
            int index3 = i1 + 2;
            if (i2 >= index3 && (index3 == 3 || index3 == 13 || index3 == 23 || index3 == 33 || index3 == 43 || index3 == 53 || index3 == 63 || index3 == 73 || index3 == 83 || index3 == 93))
                this.textBox3.Text = this.fin.namePolyFin[index3];
            int index4 = i1 + 3;
            if (i2 >= index4 && (index4 == 4 || index4 == 14 || index4 == 24 || index4 == 34 || index4 == 44 || index4 == 54 || index4 == 64 || index4 == 74 || index4 == 84 || index4 == 94))
                this.textBox4.Text = this.fin.namePolyFin[index4];
            int index5 = i1 + 4;
            if (i2 >= index5 && (index5 == 5 || index5 == 15 || index5 == 25 || index5 == 35 || index5 == 45 || index5 == 55 || index5 == 65 || index5 == 75 || index5 == 85 || index5 == 95))
                this.textBox5.Text = this.fin.namePolyFin[index5];
            int index6 = i1 + 5;
            if (i2 >= index6 && (index6 == 6 || index6 == 16 || index6 == 26 || index6 == 36 || index6 == 46 || index6 == 56 || index6 == 66 || index6 == 76 || index6 == 86 || index6 == 96))
                this.textBox6.Text = this.fin.namePolyFin[index6];
            int index7 = i1 + 6;
            if (i2 >= index7 && (index7 == 7 || index7 == 17 || index7 == 27 || index7 == 37 || index7 == 47 || index7 == 57 || index7 == 67 || index7 == 77 || index7 == 87 || index7 == 97))
                this.textBox7.Text = this.fin.namePolyFin[index7];
            int index8 = i1 + 7;
            if (i2 >= index8 && (index8 == 8 || index8 == 18 || index8 == 28 || index8 == 38 || index8 == 48 || index8 == 58 || index8 == 68 || index8 == 78 || index8 == 88 || index8 == 98))
                this.textBox8.Text = this.fin.namePolyFin[index8];
            int index9 = i1 + 8;
            if (i2 >= index9 && (index9 == 9 || index9 == 19 || index9 == 29 || index9 == 39 || index9 == 49 || index9 == 59 || index9 == 69 || index9 == 79 || index9 == 89 || index9 == 99))
                this.textBox9.Text = this.fin.namePolyFin[index9];
            int index10 = i1 + 9;
            if (i2 < index10 || index10 != 10 && index10 != 20 && index10 != 30 && index10 != 40 && index10 != 50 && index10 != 60 && index10 != 70 && index10 != 80 && index10 != 90 && index10 != 100)
                return;
            this.textBox10.Text = this.fin.namePolyFin[index10];
        }

        private void SymbolChange(int i1, int i2)
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
                    this.textBox11.Text = string.Format("{0}", (object)this.fin.nSymbFin[index1]);
                    break;
            }
            int index2 = i1 + 1;
            if (i2 >= index2 && (index2 == 2 || index2 == 12 || index2 == 22 || index2 == 32 || index2 == 42 || index2 == 52 || index2 == 62 || index2 == 72 || index2 == 82 || index2 == 92))
                this.textBox12.Text = string.Format("{0}", (object)this.fin.nSymbFin[index2]);
            int index3 = i1 + 2;
            if (i2 >= index3 && (index3 == 3 || index3 == 13 || index3 == 23 || index3 == 33 || index3 == 43 || index3 == 53 || index3 == 63 || index3 == 73 || index3 == 83 || index3 == 93))
                this.textBox13.Text = string.Format("{0}", (object)this.fin.nSymbFin[index3]);
            int index4 = i1 + 3;
            if (i2 >= index4 && (index4 == 4 || index4 == 14 || index4 == 24 || index4 == 34 || index4 == 44 || index4 == 54 || index4 == 64 || index4 == 74 || index4 == 84 || index4 == 94))
                this.textBox14.Text = string.Format("{0}", (object)this.fin.nSymbFin[index4]);
            int index5 = i1 + 4;
            if (i2 >= index5 && (index5 == 5 || index5 == 15 || index5 == 25 || index5 == 35 || index5 == 45 || index5 == 55 || index5 == 65 || index5 == 75 || index5 == 85 || index5 == 95))
                this.textBox15.Text = string.Format("{0}", (object)this.fin.nSymbFin[index5]);
            int index6 = i1 + 5;
            if (i2 >= index6 && (index6 == 6 || index6 == 16 || index6 == 26 || index6 == 36 || index6 == 46 || index6 == 56 || index6 == 66 || index6 == 76 || index6 == 86 || index6 == 96))
                this.textBox16.Text = string.Format("{0}", (object)this.fin.nSymbFin[index6]);
            int index7 = i1 + 6;
            if (i2 >= index7 && (index7 == 7 || index7 == 17 || index7 == 27 || index7 == 37 || index7 == 47 || index7 == 57 || index7 == 67 || index7 == 77 || index7 == 87 || index7 == 97))
                this.textBox17.Text = string.Format("{0}", (object)this.fin.nSymbFin[index7]);
            int index8 = i1 + 7;
            if (i2 >= index8 && (index8 == 8 || index8 == 18 || index8 == 28 || index8 == 38 || index8 == 48 || index8 == 58 || index8 == 68 || index8 == 78 || index8 == 88 || index8 == 98))
                this.textBox18.Text = string.Format("{0}", (object)this.fin.nSymbFin[index8]);
            int index9 = i1 + 8;
            if (i2 >= index9 && (index9 == 9 || index9 == 19 || index9 == 29 || index9 == 39 || index9 == 49 || index9 == 59 || index9 == 69 || index9 == 79 || index9 == 89 || index9 == 99))
                this.textBox19.Text = string.Format("{0}", (object)this.fin.nSymbFin[index9]);
            int index10 = i1 + 9;
            if (i2 < index10 || index10 != 10 && index10 != 20 && index10 != 30 && index10 != 40 && index10 != 50 && index10 != 60 && index10 != 70 && index10 != 80 && index10 != 90 && index10 != 100)
                return;
            this.textBox20.Text = string.Format("{0}", (object)this.fin.nSymbFin[index10]);
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (this.textBox71.Text != "F" && this.textBox71.Text != "T")
            {
                int num = (int)MessageBox.Show("Введите символ'F' или 'T' ", "Имена участков", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                for (int index = 1; index <= this.kPolyFinal; ++index)
                {
                    this.sTmp = "";
                    this.sTmp = this.fin.namePolyFin[index];
                    if (this.sTmp[0] != 'F' && this.sTmp[0] != 'T')
                        this.fin.namePolyFin[index] = this.textBox71.Text + this.sTmp + "\0";
                }
                this.i1 = this.kt1[1];
                this.i2 = this.kt2[1];
                this.NameChange(this.i1, this.i2);
            }
        }

        private void Establish_Click(object sender, EventArgs e)
        {
            double tText = 0.0;
            if (!(this.textBox72.Text != ""))
                return;
            DllClass1.CheckText(this.textBox72.Text, out tText, out this.iCond);
            if (this.iCond < 0)
            {
                int num1 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.i1 = Convert.ToInt32(this.textBox72.Text);
                this.i2 = 0;
                for (int index = 0; index <= this.kSymbPoly; ++index)
                {
                    if (this.fin.np2Sign[index] == this.i1)
                    {
                        ++this.i2;
                        break;
                    }
                }
                if (this.i2 == 0)
                {
                    for (int index = 0; index <= this.kSymbPoly; ++index)
                    {
                        if (this.fin.np1Sign[index] == this.i1)
                        {
                            ++this.i2;
                            break;
                        }
                    }
                }
                if (this.i2 == 0)
                {
                    int num2 = (int)MessageBox.Show("Неправильный номер. Проверьте свои коды", "Символы участка");
                }
                else
                {
                    for (int index = 1; index <= this.kPolyFinal; ++index)
                    {
                        DllClass1.CheckText(this.textBox72.Text, out tText, out this.iCond);
                        if (this.iCond < 0)
                        {
                            int num3 = (int)MessageBox.Show("Проверьте данные", "Финальный", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        this.fin.nSymbFin[index] = Convert.ToInt32(this.textBox72.Text);
                    }
                    this.i1 = this.kt1[1];
                    this.i2 = this.kt2[1];
                    this.SymbolChange(this.i1, this.i2);
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e) => Form.ActiveForm.Close();
    }
}

