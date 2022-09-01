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
    public partial class ListPolySign : Form
    {
        private int iWidth;
        private int iHeight;
        private int pixWid;
        private int pixHei;
        private int yTolMin;
        private int yTolMax;
        private int kPolySymb;
        private int hSymbPoly;
        private MyGeodesy myPol = new MyGeodesy();
        private IContainer components;
        private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label6;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        public ListPolySign()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.pixWid = this.panel1.Bounds.Width;
            this.pixHei = this.panel1.Bounds.Height;
            if (this.pixWid <= this.pixHei)
                this.iWidth = this.iHeight = this.pixWid;
            if (this.pixWid > this.pixHei)
                this.iWidth = this.iHeight = this.pixHei;
            this.myPol.FilePath();
            this.FormLoad();
        }

        public void PolyListDraw(
   PaintEventArgs e,
   string fitemPoly,
   int hSymbPoly,
   int kSymbPoly,
   string[] symbPoly,
   int[] nSign1,
   int[] xSign1,
   int[] ySign1,
   int[] xSign,
   int[] ySign,
   int[] nItem,
   int[] xItem,
   int[] yItem,
   int[] xDescr,
   int[] yDescr,
   int[] nSign2,
   int[] xSign2,
   int[] ySign2,
   int[] nBackCol,
   int[] npTxtCol,
   double[] hpFont,
   string[] sInscr,
   int[] kOneSymb,
   int[] ixSqu,
   int[] iySqu,
   int[] nColItem,
   SolidBrush[] brColor,
   Pen[] pnColor)
        {
            Graphics graphics = e.Graphics;
            string sTxt = "";
            int num1 = 10;
            int num2 = 50;
            int num3 = 110;
            int num4 = 135;
            int num5 = 180;
            int num6;
            int num7 = num6 = 0;
            int num8;
            int mClr = num8 = 0;
            int kPix = num8;
            int iHei = num8;
            int iWid = num8;
            int iLong = num8;
            int num9;
            int num10 = num9 = 0;
            int width = 25;
            int height = hSymbPoly;
            Font font = new Font("Arial", 8f);
            SolidBrush solidBrush1 = new SolidBrush(Color.Black);
            for (int index1 = 1; index1 <= kSymbPoly; ++index1)
            {
                int x1 = num1;
                int y = ySign1[index1];
                string s1 = string.Format("{0}", (object)nSign1[index1]);
                graphics.DrawString(s1, font, (Brush)solidBrush1, (float)x1, (float)y);
                int x2 = num2;
                int index2 = nBackCol[index1];
                if (index2 == 10)
                {
                    SolidBrush solidBrush2 = new SolidBrush(Color.White);
                    graphics.FillRectangle((Brush)solidBrush2, x2, y, width, height);
                }
                if (index2 < 10)
                {
                    SolidBrush solidBrush3 = brColor[index2];
                    graphics.FillRectangle((Brush)solidBrush3, x2, y, width, height);
                }
                Pen pen = new Pen(Color.YellowGreen, 1f);
                graphics.DrawRectangle(pen, x2, y, width, height);
                int num11 = num4;
                string s2 = string.Format("{0}", (object)kOneSymb[index1]);
                graphics.DrawString(s2, font, (Brush)solidBrush1, (float)(num11 + 10), (float)y);
                int x3 = num5;
                graphics.DrawString(symbPoly[index1], font, (Brush)solidBrush1, (float)x3, (float)y);
                int x4 = num3;
                string s3 = string.Format("{0}", (object)nSign2[index1]);
                graphics.DrawString(s3, font, (Brush)solidBrush1, (float)x4, (float)y);
                int nSelect = nItem[index1];
                if (nSelect != 0 && kOneSymb[index1] != 0)
                {
                    DllClass1.SelItemPoly(fitemPoly, nSelect, out iLong, out iWid, out iHei, out kPix, ixSqu, iySqu, nColItem, out sTxt, out mClr);
                    int num12 = num2;
                    if (iLong == 0)
                    {
                        int num13 = 1;
                        int num14 = (width - num13 * iWid) / (num13 + 1);
                        int num15 = num12;
                        for (int index3 = 1; index3 <= num13; ++index3)
                        {
                            int num16 = num15 + num14;
                            for (int index4 = 1; index4 <= kPix; ++index4)
                            {
                                int num17 = num16 + ixSqu[index4];
                                int num18 = y + iySqu[index4];
                                mClr = nColItem[index4];
                                SolidBrush solidBrush4 = brColor[mClr];
                                num7 = (width - iWid) / 2;
                                int num19 = (height - iHei) / 2;
                                int num20 = 0;
                                graphics.FillRectangle((Brush)solidBrush4, num17 + num20, num18 + num19, 1, 1);
                            }
                            num15 = num16 + iWid;
                        }
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            this.PolyListDraw(e, this.myPol.fitemPoly, this.hSymbPoly, this.kPolySymb, this.myPol.sPolySymb, this.myPol.npSign1, this.myPol.xpSign1, this.myPol.ypSign1, this.myPol.xpSymb, this.myPol.ypSymb, this.myPol.npItem, this.myPol.xpItem, this.myPol.ypItem, this.myPol.xpDescr, this.myPol.ypDescr, this.myPol.npSign2, this.myPol.xpSign2, this.myPol.ypSign2, this.myPol.nBackCol, this.myPol.npTxtCol, this.myPol.hpFont, this.myPol.spInscr, this.myPol.nOneSymb, this.myPol.iWidth1, this.myPol.iWidth2, this.myPol.nColorItm, this.myPol.brColor, this.myPol.pnColor);
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index1 = 0;
            for (int index2 = 2; index2 <= this.kPolySymb; ++index2)
            {
                if (this.myPol.ypSign1[index2 - 1] < e.Y && this.myPol.ypSign1[index2] > e.Y)
                {
                    index1 = this.myPol.npSign1[index2] - 1;
                    break;
                }
            }
            if (index1 == 0)
                index1 = this.kPolySymb;
            if (File.Exists(this.myPol.fileAdd))
                File.Delete(this.myPol.fileAdd);
            FileStream output = new FileStream(this.myPol.fileAdd, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(this.myPol.npSign1[index1]);
            binaryWriter.Close();
            output.Close();
            Form.ActiveForm.Close();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (File.Exists(this.myPol.fileAdd))
                File.Delete(this.myPol.fileAdd);
            FileStream output = new FileStream(this.myPol.fileAdd, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(num);
            binaryWriter.Close();
            output.Close();
            Form.ActiveForm.Close();
        }
        private void Up_Click(object sender, EventArgs e)
        {
            this.yTolMax = this.myPol.ypSign1[this.kPolySymb] + this.hSymbPoly;
            if (this.yTolMax < this.pixHei)
                return;
            for (int index = 1; index <= this.kPolySymb; ++index)
                this.myPol.ypSign1[index] = this.myPol.ypSign1[index] - this.hSymbPoly;
            this.panel1.Invalidate();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            if (this.myPol.ypSign1[1] > this.yTolMin)
                return;
            for (int index = 1; index <= this.kPolySymb; ++index)
                this.myPol.ypSign1[index] = this.myPol.ypSign1[index] + this.hSymbPoly;
            this.panel1.Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }
    }
}
