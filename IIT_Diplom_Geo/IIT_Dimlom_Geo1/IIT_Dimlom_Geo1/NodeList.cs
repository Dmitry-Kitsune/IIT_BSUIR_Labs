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
    public partial class NodeList : Form
    {
        private int kNode;
        private int kTopo;
        private int kPnt;
        private int i1;
        private int i2;
        private int ip;
        private string sDist = "";
        private double dist;
        private double dx;
        private double dy;
        private double ss;
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private string sTmp1 = "";
        private string sTmp2 = "";
        private int nProcess;
        private int nAction;
        private int kLineAct;
        private int kNodeAct;
        private MyGeodesy myNod = new MyGeodesy();

        public string fCurPnt { get; private set; }
        public string fCurHeig { get; private set; }

        public NodeList()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            FormLoad();
        }
        private void FormLoad()
        {
            myNod.FilePath();
            if (File.Exists(myNod.fileProcess))
            {
                FileStream input = new FileStream(myNod.fileProcess, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                try
                {
                    nProcess = binaryReader.ReadInt32();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The Read operation failed as expected.");
                }
                finally
                {
                    input.Close();
                    binaryReader.Close();
                }
            }
            myNod.PointLoad(fCurPnt,fCurHeig);
            kPnt = myNod.kPntPlus;
            if (nProcess == 1001)
            {
                myNod.LoadNode();
                kNode = myNod.kNodeTopo;
                myNod.LineTopoLoad();
                kTopo = myNod.kLineTopo;
                FillList();
            }
            if (nProcess != 1002)
                return;
            myNod.KeepLoadAction(1);
            nAction = myNod.nAction;
            myNod.NodeActLoad(nAction);
            kNodeAct = myNod.kNodeAct;
            myNod.TopoActLoad(nAction);
            kLineAct = myNod.kLineAct;
            FillAct();
        }

        private void Cancel_Click(object sender, EventArgs e) => Form.ActiveForm.Close();

        public void FillList()
        {
            for (int i1 = 1; i1 <= kTopo; ++i1)
            {
                x1 = y1 = x2 = y2 = 0.0;
                i1 = myNod.kl1[i1];
                i2 = myNod.kl2[i1];
                dist = 0.0;
                for (int i2 = i1 + 1; i2 <= i2; ++i2)
                {
                    dx = myNod.zLin[i2] - myNod.zLin[i2 - 1];
                    dy = myNod.zPik[i2] - myNod.zPik[i2 - 1];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    dist += ss;
                }
                ip = 0;
                for (int i3 = 0; i3 <= kPnt; ++i3)
                {
                    dx = myNod.zLin[i1] - myNod.xPnt[i3];
                    dy = myNod.zPik[i1] - myNod.yPnt[i3];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < 0.003)
                    {
                        ++ip;
                        sTmp1 = myNod.namePnt[i3];
                        x1 = myNod.xPnt[i3];
                        y1 = myNod.yPnt[i3];
                        break;
                    }
                }
                if (ip == 0)
                {
                    for (int i4 = 1; i4 <= kNode; ++i4)
                    {
                        dx = myNod.zLin[i1] - myNod.xNode[i4];
                        dy = myNod.zPik[i1] - myNod.yNode[i4];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < 0.003)
                        {
                            ++ip;
                            sTmp1 = myNod.nameNode[i4];
                            x1 = myNod.xNode[i4];
                            y1 = myNod.yNode[i4];
                            break;
                        }
                    }
                }
                ip = 0;
                for (int i5 = 0; i5 <= kPnt; ++i5)
                {
                    dx = myNod.zLin[i2] - myNod.xPnt[i5];
                    dy = myNod.zPik[i2] - myNod.yPnt[i5];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < 0.003)
                    {
                        ++ip;
                        sTmp2 = myNod.namePnt[i5];
                        x2 = myNod.xPnt[i5];
                        y2 = myNod.yPnt[i5];
                        break;
                    }
                }
                if (ip == 0)
                {
                    for (int i6 = 1; i6 <= kNode; ++i6)
                    {
                        dx = myNod.zLin[i2] - myNod.xNode[i6];
                        dy = myNod.zPik[i2] - myNod.yNode[i6];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < 0.003)
                        {
                            ++ip;
                            sTmp2 = myNod.nameNode[i6];
                            x2 = myNod.xNode[i6];
                            y2 = myNod.yNode[i6];
                            break;
                        }
                    }
                }
                sDist = sTmp1 + "     " + string.Format("{0:F3}", (object)x1) + "     " + string.Format("{0:F3}", (object)y1);
                listBox1.Items.Add((object)sDist);
                if (myNod.radLine[i1] > 0.0)
                    sDist = "                                                " + string.Format("{0:F3}", (object)dist) + "   " + string.Format("{0:F3}", (object)myNod.radLine[i1]);
                if (myNod.radLine[i1] == 0.0)
                    sDist = "                                                " + string.Format("{0:F3}", (object)dist);
                listBox1.Items.Add((object)sDist);
                sDist = sTmp2 + "     " + string.Format("{0:F3}", (object)x2) + "     " + string.Format("{0:F3}", (object)y2);
                listBox1.Items.Add((object)sDist);
                listBox1.Items.Add((object)"----------------------------------------------------------------------------------");
            }
        }

        public void FillAct()
        {
            for (int i1 = 1; i1 <= kLineAct; ++i1)
            {
                x1 = y1 = x2 = y2 = 0.0;
                i1 = myNod.kActLine1[i1];
                i2 = myNod.kActLine2[i1];
                dist = 0.0;
                for (int i2 = i1 + 1; i2 <= i2; ++i2)
                {
                    dx = myNod.xLineAct[i2] - myNod.xLineAct[i2 - 1];
                    dy = myNod.yLineAct[i2] - myNod.yLineAct[i2 - 1];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    dist += ss;
                }
                ip = 0;
                for (int i3 = 0; i3 <= kPnt; ++i3)
                {
                    dx = myNod.xLineAct[i1] - myNod.xPnt[i3];
                    dy = myNod.yLineAct[i1] - myNod.yPnt[i3];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < 0.003)
                    {
                        ++ip;
                        sTmp1 = myNod.namePnt[i3];
                        x1 = myNod.xPnt[i3];
                        y1 = myNod.yPnt[i3];
                        break;
                    }
                }
                if (ip == 0)
                {
                    for (int i4 = 1; i4 <= kNodeAct; ++i4)
                    {
                        dx = myNod.xLineAct[i1] - myNod.xNodeAct[i4];
                        dy = myNod.yLineAct[i1] - myNod.yNodeAct[i4];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < 0.003)
                        {
                            ++ip;
                            sTmp1 = myNod.nameNodeAct[i4];
                            x1 = myNod.xNodeAct[i4];
                            y1 = myNod.yNodeAct[i4];
                            break;
                        }
                    }
                }
                ip = 0;
                for (int i5 = 0; i5 <= kPnt; ++i5)
                {
                    dx = myNod.xLineAct[i2] - myNod.xPnt[i5];
                    dy = myNod.yLineAct[i2] - myNod.yPnt[i5];
                    ss = Math.Sqrt(dx * dx + dy * dy);
                    if (ss < 0.003)
                    {
                        ++ip;
                        sTmp2 = myNod.namePnt[i5];
                        x2 = myNod.xPnt[i5];
                        y2 = myNod.yPnt[i5];
                        break;
                    }
                }
                if (ip == 0)
                {
                    for (int i6 = 1; i6 <= kNodeAct; ++i6)
                    {
                        dx = myNod.xLineAct[i2] - myNod.xNodeAct[i6];
                        dy = myNod.yLineAct[i2] - myNod.yNodeAct[i6];
                        ss = Math.Sqrt(dx * dx + dy * dy);
                        if (ss < 0.003)
                        {
                            ++ip;
                            sTmp2 = myNod.nameNodeAct[i6];
                            x2 = myNod.xNodeAct[i6];
                            y2 = myNod.yNodeAct[i6];
                            break;
                        }
                    }
                }
                sDist = sTmp1 + "     " + string.Format("{0:F3}", (object)x1) + "     " + string.Format("{0:F3}", (object)y1);
                listBox1.Items.Add((object)sDist);
                if (myNod.radAct[i1] > 0.0)
                    sDist = "                                                " + string.Format("{0:F3}", (object)dist) + "   " + string.Format("{0:F3}", (object)myNod.radAct[i1]);
                if (myNod.radAct[i1] == 0.0)
                    sDist = "                                                " + string.Format("{0:F3}", (object)dist);
                listBox1.Items.Add((object)sDist);
                sDist = sTmp2 + "     " + string.Format("{0:F3}", (object)x2) + "     " + string.Format("{0:F3}", (object)y2);
                listBox1.Items.Add((object)sDist);
                listBox1.Items.Add((object)"----------------------------------------------------------------------------------");
            }
        }

    }
}
