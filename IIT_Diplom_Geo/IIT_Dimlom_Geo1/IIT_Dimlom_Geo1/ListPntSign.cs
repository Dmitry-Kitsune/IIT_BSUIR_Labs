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
using DiplomGeoDLL;

namespace IIT_Dimlom_Geo1
{
    public partial class ListPntSign : Form
    {

        private string sTmp = "";
        private string sText = "";
        private int pixWid;
        private int pixHei;
        private int iWidth;
        private int iHeight;
        private int kSymbPnt;
        private int yTolMin;
        private int yTolMax;
        private int iLong;
        private int iWid;
        private int iHei;
        private int kPix;
        private int mColor;
        private string sDscr = "";
        private double sPixel = 0.254;
        private double sWid;
        private double sHei;
        private int hLine;
        private int nProcess;
        //private IContainer components;

        MyGeodesy myPoint = new MyGeodesy();


        public ListPntSign()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            pixWid = panel1.Bounds.Width;
            pixHei = panel1.Bounds.Height;
            if (pixWid <= pixHei)
                iWidth = iHeight = pixWid;
            if (pixWid > pixHei)
                iWidth = iHeight = pixHei;
            myPoint.FilePath();
            FormLoad();
        }

        private void FormLoad()
        {
            if (File.Exists(myPoint.fileAdd))
            {
                FileStream input = new FileStream(myPoint.fileAdd, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                nProcess = binaryReader.ReadInt32();
                input.Close();
                binaryReader.Close();
            }
            DllClass1.SetColour(myPoint.brColor, myPoint.pnColor);
            DllClass1.PointSymbLoad(myPoint.fsymbPnt, out kSymbPnt, 
                myPoint.numRec, myPoint.numbUser, myPoint.heiSymb);
            hLine = 0;
            for (int index = 1; index <= kSymbPnt; ++index)
            {
                if (myPoint.heiSymb[index] > hLine)
                    hLine = myPoint.heiSymb[index];
            }
            hLine += hLine / 2;
            myPoint.ihSymb[1] = 60;
            for (int index = 2; index <= kSymbPnt; ++index)
                myPoint.ihSymb[index] = myPoint.ihSymb[index - 1] + hLine;
            yTolMin = myPoint.ihSymb[1] - hLine;
            if (nProcess == 10 || nProcess == 200)
                label6.Text = "";
            if (nProcess != 1000)
                return;
            label6.Text = "";
            for (int index1 = 1; index1 <= kSymbPnt; ++index1)
            {
                yTolMax = myPoint.ihSymb[kSymbPnt] + hLine;
                if (yTolMax < pixHei)
                    break;
                for (int index2 = 1; index2 <= kSymbPnt; ++index2)
                    myPoint.ihSymb[index2] = myPoint.ihSymb[index2] - hLine;
                panel1.Invalidate();
            }
        }

        private void Up_Click(object sender, EventArgs e)
        {
            yTolMax = myPoint.ihSymb[kSymbPnt] + hLine;
            if (yTolMax < pixHei)
                return;
            for (int index = 1; index <= kSymbPnt; ++index)
                myPoint.ihSymb[index] = myPoint.ihSymb[index] - hLine;
            panel1.Invalidate();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            if (myPoint.ihSymb[1] > yTolMin)
                return;
            for (int index = 1; index <= kSymbPnt; ++index)
                myPoint.ihSymb[index] = myPoint.ihSymb[index] + hLine;
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black, 1f);
            Font font1 = new Font("Arial", 8f);
            Font font2 = new Font("Arial", 8f, FontStyle.Bold);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            int x1 = 20;
            if (kSymbPnt <= 0)
                return;
            for (int index = 1; index <= kSymbPnt; ++index)
            {
                int y = myPoint.ihSymb[index] - 40;
                sTmp = string.Format("{0}", (object)myPoint.numRec[index]);
                graphics.DrawString(sTmp, font1, (Brush)solidBrush, (float)x1, (float)y);
                if (myPoint.numbUser[index] > 0)
                {
                    DllClass1.SelSymbPnt(myPoint.fsymbPnt, myPoint.numbUser[index], 
                        kSymbPnt, myPoint.numRec, myPoint.numbUser, out iLong,
                        out iWid, out iHei, out sDscr, out kPix, myPoint.ixSqu,
                        myPoint.iySqu, myPoint.nColor, out sText, out mColor);
                    int ixh = x1 + 60;
                    int num = y;
                    if (iLong == 0)
                        DllClass1.SignDraw(e, ixh, num, kPix, myPoint.ixSqu, myPoint.iySqu, myPoint.nColor, myPoint.brColor);
                    if (iLong > 0)
                        DllClass1.DrawText(e, sText, iHei, ixh, num, mColor, myPoint.brColor);
                    sTmp = string.Format("{0}", (object)myPoint.numbUser[index]);
                    int x2 = x1 + 115;
                    graphics.DrawString(sTmp, font1, (Brush)solidBrush, (float)x2, (float)num);
                    sWid = Convert.ToDouble(sPixel * (double)iWid);
                    sHei = Convert.ToDouble(sPixel * (double)iHei);
                    sTmp = string.Format("{0:F1}", (object)sWid) + "/" + string.Format("{0:F1}", (object)sHei);
                    int x3 = x1 + 160;
                    graphics.DrawString(sTmp, font1, (Brush)solidBrush, (float)x3, (float)num);
                    int x4 = x1 + 230;
                    graphics.DrawString(sDscr, font1, (Brush)solidBrush, (float)x4, (float)num);
                }
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (File.Exists(myPoint.fileAdd))
                File.Delete(myPoint.fileAdd);
            FileStream output = new FileStream(myPoint.fileAdd, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(num);
            binaryWriter.Close();
            output.Close();
            Form.ActiveForm.Close();
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int num1 = e.Y + 50;
            int num2 = 0;
            int index1 = kSymbPnt + 1;
            myPoint.ihSymb[index1] = myPoint.ihSymb[kSymbPnt] + hLine;
            for (int index2 = 2; index2 <= index1; ++index2)
            {
                if (myPoint.ihSymb[index2 - 1] <= num1 && myPoint.ihSymb[index2] > num1)
                {
                    num2 = index2 - 1;
                    break;
                }
            }
            if (File.Exists(myPoint.fileAdd))
                File.Delete(myPoint.fileAdd);
            FileStream output = new FileStream(myPoint.fileAdd, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
            binaryWriter.Write(num2);
            binaryWriter.Close();
            output.Close();
            Form.ActiveForm.Close();
        }



    }
}
