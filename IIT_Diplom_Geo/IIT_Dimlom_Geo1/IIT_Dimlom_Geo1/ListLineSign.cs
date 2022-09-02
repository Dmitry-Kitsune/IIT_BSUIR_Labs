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
    public partial class ListLineSign : Form
    {
        private int kSymbLine;
        private int hSymbLine = 20;
        private int iLong;
        private int iHei;
        private int iWid;
        private int kPixel;
        private int iWidth;
        private int iHeight;
        private int pixWid;
        private int pixHei;
        private int yTolMin;
        private int yTolMax;
        private int nBase;
        private int iCod1;
        private int iCod2;
        private double sPixel = 0.254;
        private int nProcess;
        private MyGeodesy myLin = new MyGeodesy();
        public ListLineSign()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            pixWid = panel1.Bounds.Width;
            pixHei = panel1.Bounds.Height;
            if (pixWid <= pixHei)
                iWidth = iHeight = pixWid;
            if (pixWid > pixHei)
                iWidth = iHeight = pixHei;
            myLin.FilePath();
            FormLoad();
        }
        private void FormLoad()
        {
            DllClass1.SetColour(myLin.brColor, myLin.pnColor);
            DllClass1.LineSymbolLoad(myLin.fsymbLine, out kSymbLine, out hSymbLine, myLin.sSymbLine, myLin.x1Line, myLin.y1Line, myLin.x2Line, myLin.y2Line, myLin.xDescr, myLin.yDescr, myLin.x1Dens, myLin.y1Dens, myLin.x1Sign, myLin.y1Sign, myLin.x2Sign, myLin.y2Sign, myLin.n1Sign, myLin.n2Sign, myLin.iStyle1, myLin.iStyle2, myLin.iWidth1, myLin.iWidth2, myLin.nColLine, myLin.nItem, myLin.itemLoc, myLin.nBaseSymb, myLin.sInscr, myLin.hInscr, myLin.iColInscr, myLin.iDensity);
            myLin.nWork[1] = hSymbLine;
            if (kSymbLine > 1)
            {
                for (int index = 2; index <= kSymbLine; ++index)
                    myLin.nWork[index] = myLin.nWork[index - 1] + hSymbLine;
            }
            yTolMin = myLin.nWork[1] - hSymbLine;
            yTolMax = myLin.nWork[kSymbLine];
            if (File.Exists(myLin.fileAdd))
            {
                FileStream input = new FileStream(myLin.fileAdd, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                nProcess = binaryReader.ReadInt32();
                binaryReader.Close();
                input.Close();
            }
            if (nProcess == 40)
                label5.Text = "DoubleClick one of the basic symbols(1-8)";
            if (nProcess == 200)
                label5.Text = "";
            if (nProcess == 300)
                label5.Text = "DoubleClick appropriate symbols";
            if (nProcess != 1000)
                return;
            label5.Text = "";
            for (int index1 = 1; index1 <= kSymbLine; ++index1)
            {
                yTolMax = myLin.nWork[kSymbLine] + hSymbLine;
                if (yTolMax < pixHei)
                    break;
                for (int index2 = 1; index2 <= kSymbLine; ++index2)
                    myLin.nWork[index2] = myLin.nWork[index2] - hSymbLine;
                panel1.Invalidate();
            }
        }
        public void LineListDraw(
          PaintEventArgs e,
          int kSymbLine,
          int hSymbLine,
          string[] sSymbLine,
          int[] x1Line,
          int[] y1Line,
          int[] x2Line,
          int[] y2Line,
          int[] xDescr,
          int[] yDescr,
          int[] x1Dens,
          int[] y1Dens,
          int[] x1Sign,
          int[] y1Sign,
          int[] x2Sign,
          int[] y2Sign,
          int[] n1Sign,
          int[] n2Sign,
          int[] iStyle1,
          int[] iStyle2,
          int[] iWidth1,
          int[] iWidth2,
          int[] nColLine,
          int[] nItem,
          int[] itemLoc,
          int[] nBaseSymb,
          string[] sInscr,
          double[] hInscr,
          int[] iColInscr,
          int[] iDensity,
          SolidBrush[] brCol,
          Pen[] pnCol)
        {
            Graphics graphics = e.Graphics;
            string sTxt = "";
            int mClr = 0;
            int emSize = hSymbLine / 2;
            int num1 = 1;
            double[] x = new double[5];
            double[] y1 = new double[5];
            double[] xAng = new double[5];
            double[] yAng = new double[5];
            int kit = 0;
            double[] xit = new double[10];
            double[] yit = new double[10];
            int num2 = myLin.nWork[1] - hSymbLine;
            int num3 = x1Line[1];
            int num4 = x2Line[1];
            int num5 = 0;
            int num6 = 35;
            int num7 = 130;
            for (int index1 = 1; index1 <= kSymbLine; ++index1)
            {
                num2 += hSymbLine;
                int num8 = num2;
                x[0] = (double)num6;
                x[1] = (double)num7;
                y1[0] = 1.0 * (double)num2;
                y1[1] = 1.0 * (double)num8;
                int index2 = n1Sign[index1];
                int iWid1 = iWidth1[index1];
                int iWid2 = iWidth2[index1];
                int nBase = nBaseSymb[index1];
                int iStyle3 = iStyle1[index1];
                int iStyle4 = iStyle2[index1];
                int index3 = nColLine[index1];
                int nSelect = nItem[index1];
                int num9 = itemLoc[index1];
                int nDensity = iDensity[index1];
                SolidBrush solidBrush1 = brCol[index3];
                Pen jColor = pnCol[index3];
                string s1 = string.Format("{0}", (object)n1Sign[index2]);
                graphics.DrawString(s1, new Font("Bold", (float)emSize), (Brush)solidBrush1, 10f, (float)(num2 - emSize));
                string s2 = string.Format("{0}", (object)n2Sign[index2]);
                graphics.DrawString(s2, new Font("Bold", (float)emSize), (Brush)solidBrush1, 140f, (float)(num2 - emSize));
                string s3 = string.Format("{0}", (object)iDensity[index2]);
                graphics.DrawString(s3, new Font("Bold", (float)emSize), (Brush)solidBrush1, 170f, (float)(num2 - emSize));
                string s4 = sSymbLine[index2];
                graphics.DrawString(s4, new Font("Bold", (float)emSize), (Brush)solidBrush1, 200f, (float)(num2 - emSize));
                if (nSelect > 0)
                {
                    DllClass1.SelItemLine(myLin.fitemLine, nSelect, out iLong, out iWid, out iHei, out kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColorItm, out sTxt, out mClr);
                    if (nDensity == 1)
                    {
                        for (int index4 = 0; index4 <= num1; ++index4)
                        {
                            xAng[index4] = x[index4];
                            yAng[index4] = y1[index4];
                        }
                        DllClass1.CoordLineItem(nDensity, num1, xAng, yAng, nBase, out kit, xit, yit);
                        if (iLong == 0)
                        {
                            for (int index5 = 1; index5 <= kit; ++index5)
                            {
                                int int32_1 = Convert.ToInt32(xit[index5]);
                                int int32_2 = Convert.ToInt32(yit[index5]);
                                if (nBase < 8)
                                {
                                    int32_1 -= iWid / 2;
                                    int32_2 -= iHei / 2;
                                    if (num9 == 1)
                                        int32_2 -= iHei / 2;
                                    if (num9 == 3)
                                        int32_2 += iHei / 2;
                                }
                                if (nBase == 8)
                                {
                                    int32_1 -= iWid / 2;
                                    int32_2 -= iHei / 2;
                                    if (num9 == 1)
                                        int32_2 -= iHei;
                                    if (num9 == 3)
                                        int32_2 += iHei;
                                }
                                DllClass1.SignDraw(e, int32_1, int32_2, kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColorItm, brCol);
                            }
                        }
                    }
                    if (nDensity > 1 && iLong == 0)
                    {
                        if (nDensity == 1)
                            num5 = 5 * iWid;
                        if (nDensity == 2)
                            num5 = 4 * iWid;
                        if (nDensity == 3)
                            num5 = 3 * iWid;
                        if (nDensity == 4)
                            num5 = 2 * iWid;
                        if (nDensity == 5)
                            num5 = iWid;
                        kit = (num7 - num6) / num5 + 1;
                        int ixh = num6 - num5;
                        for (int index6 = 1; index6 <= kit; ++index6)
                        {
                            ixh += num5;
                            int iyh = num2;
                            if (nBase < 8)
                            {
                                iyh -= iHei / 2;
                                if (num9 == 1)
                                    iyh -= iHei / 2;
                                if (num9 == 3)
                                    iyh += iHei / 2;
                            }
                            if (nBase == 8)
                            {
                                iyh -= iHei / 2;
                                if (num9 == 1)
                                    iyh -= iHei;
                                if (num9 == 3)
                                    iyh += iHei;
                            }
                            DllClass1.SignDraw(e, ixh, iyh, kPixel, myLin.ixSqu, myLin.iySqu, myLin.nColorItm, brCol);
                        }
                    }
                }
                if (nBase == 1 || nBase == 2)
                {
                    jColor.Width = (float)iWid1;
                    DllClass1.LineSymbolStyle(e, jColor, iStyle3, num1, x, y1, iWid1);
                }
                if (nBase > 2 && nBase < 8)
                {
                    jColor.Width = (float)iWid1;
                    DllClass1.LineSymbolStyle(e, jColor, iStyle3, num1, x, y1, iWid1);
                }
                if (nBase == 8)
                {
                    int num10 = num2 - 3;
                    jColor.Width = (float)iWid1;
                    if (iStyle3 == 1 || iStyle3 == 2)
                    {
                        y1[0] = (double)num10;
                        y1[1] = (double)num10;
                        DllClass1.LineSymbolStyle(e, jColor, iStyle3, num1, x, y1, iWid1);
                    }
                    if (iStyle3 > 2 && iStyle3 < 8)
                    {
                        y1[0] = (double)num10;
                        y1[1] = (double)num10;
                        DllClass1.LineSymbolStyle(e, jColor, iStyle3, num1, x, y1, iWid1);
                    }
                    jColor.Width = (float)iWid2;
                    int num11 = num2 + 3;
                    if (iStyle4 == 1 || iStyle4 == 2)
                    {
                        y1[0] = (double)num11;
                        y1[1] = (double)num11;
                        DllClass1.LineSymbolStyle(e, jColor, iStyle4, num1, x, y1, iWid2);
                    }
                    if (iStyle4 > 2 && iStyle4 < 8)
                    {
                        y1[0] = (double)num11;
                        y1[1] = (double)num11;
                        DllClass1.LineSymbolStyle(e, jColor, iStyle4, num1, x, y1, iWid2);
                    }
                }
                if (nSelect > 0 && iLong > 0)
                {
                    sTxt = sInscr[index1];
                    double num12 = hInscr[index1];
                    mClr = iColInscr[index1];
                    int length = sTxt.Length;
                    SolidBrush solidBrush2 = brCol[mClr];
                    int int32_3 = Convert.ToInt32(num12 / sPixel);
                    int int32_4 = Convert.ToInt32(0.5 * (x[0] + x[1]));
                    int y2 = Convert.ToInt32(0.5 * (y1[0] + y1[1]));
                    int x1 = int32_4 - int32_3 * length / 2;
                    int y1_1 = y2;
                    int x2 = int32_4 + int32_3 * length / 2;
                    int y2_1 = y2;
                    if (nBase < 8)
                    {
                        int32_4 -= int32_3 * length / 2;
                        y2 -= int32_3;
                        if (num9 == 1)
                            y2 -= int32_3 / 2;
                        if (num9 == 3)
                            y2 += int32_3 / 2;
                        if (num9 == 2)
                        {
                            Pen pen = new Pen(Color.White, 3f);
                            graphics.DrawLine(pen, x1, y1_1, x2, y2_1);
                        }
                    }
                    if (nBase == 8)
                    {
                        int32_4 -= int32_3 * length / 2;
                        y2 = y2 - int32_3 - 2;
                        if (num9 == 1)
                            y2 -= int32_3;
                        if (num9 == 3)
                            y2 += int32_3;
                    }
                    graphics.DrawString(sTxt, new Font("Bold", (float)int32_3), (Brush)solidBrush2, (float)(int32_4 + 2), (float)y2);
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e) => LineListDraw(e, kSymbLine, hSymbLine, myLin.sSymbLine, myLin.x1Line, myLin.y1Line, myLin.x2Line, myLin.y2Line, myLin.xDescr, myLin.yDescr, myLin.x1Dens, myLin.y1Dens, myLin.x1Sign, myLin.y1Sign, myLin.x2Sign, myLin.y2Sign, myLin.n1Sign, myLin.n2Sign, myLin.iStyle1, myLin.iStyle2, myLin.iWidth1, myLin.iWidth2, myLin.nColLine, myLin.nItem, myLin.itemLoc, myLin.nBaseSymb, myLin.sInscr, myLin.hInscr, myLin.iColInscr, myLin.iDensity, myLin.brColor, myLin.pnColor);

        private void UpLine_Click(object sender, EventArgs e)
        {
            yTolMax = myLin.nWork[kSymbLine] + hSymbLine;
            if (yTolMax < pixHei)
                return;
            for (int index = 1; index <= kSymbLine; ++index)
                myLin.nWork[index] = myLin.nWork[index] - hSymbLine;
            panel1.Invalidate();
        }
        private void DownLine_Click(object sender, EventArgs e)
        {
            if (myLin.nWork[1] > yTolMin)
                return;
            for (int index = 1; index <= kSymbLine; ++index)
                myLin.nWork[index] = myLin.nWork[index] + hSymbLine;
            panel1.Invalidate();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            iCod2 = 0;
            nBase = 0;
            if (File.Exists(myLin.fileAdd))
                File.Delete(myLin.fileAdd);
            FileStream output = new FileStream(myLin.fileAdd, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(iCod2);
            binaryWriter.Write(nBase);
            binaryWriter.Close();
            output.Close();
            Form.ActiveForm.Close();
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int num1 = e.Y + hSymbLine / 2;
            int index1 = 0;
            int index2 = kSymbLine + 1;
            myLin.nWork[index2] = myLin.nWork[kSymbLine] + hSymbLine;
            for (int index3 = 2; index3 <= index2; ++index3)
            {
                if (myLin.nWork[index3 - 1] <= num1 && myLin.nWork[index3] > num1)
                {
                    index1 = index3 - 1;
                    break;
                }
            }
            if (index1 > 0)
            {
                iCod1 = myLin.n1Sign[index1];
                iCod2 = myLin.n2Sign[index1];
                nBase = myLin.nBaseSymb[index1];
            }
            if (iCod1 == 0 || iCod2 == 0 || nBase == 0)
            {
                int num2 = (int)MessageBox.Show("Repeat symbol selection", "help", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(myLin.fileAdd))
                    File.Delete(myLin.fileAdd);
                FileStream output = new FileStream(myLin.fileAdd, FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                binaryWriter.Write(index1);
                binaryWriter.Close();
                output.Close();
                Form.ActiveForm.Close();
            }
        }
    }
}
