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
    public partial class FieldProject : Form
    {
        private string[] nameFiles = new string[50];
        private string sTmp = "";
        private string pathGeo = "";
        private string allGeo = "";
        private string curName = "";
        private string curDir = "";
        private string curGeo = "";
        private string fileCalc = "";
        private string fileGeo = "";
        private string fileTah = "";
        private string curFile = "";
        private int nPro;
        private int kHeight = -1;
        private int kTaheo;
        private int kPnt;
        private int kGeo;
        private int ip;
        private string[] sCurDir = new string[100];
        private int kRec;
        private string[] sDrive;
        private int kDrive;
        private MyGeodesy myGeo = new MyGeodesy();
        public FieldProject()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            DllClass1.DriveList(out this.kDrive, out this.sDrive);
            this.sTmp = "";
            for (int index = 1; index <= this.kDrive; ++index)
            {
                this.sTmp = this.sDrive[index] + "Diplom_Geo\\brdrive.dat";
                if (File.Exists(this.sTmp))
                    break;
            }
            if (!File.Exists(this.sTmp))
                return;
            FileStream input1 = new FileStream(this.sTmp, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader1 = new BinaryReader((Stream)input1);
            this.pathGeo = binaryReader1.ReadString();
            binaryReader1.Close();
            input1.Close();
            this.allGeo = this.pathGeo + "brall.dat";
            this.kRec = -1;
            FileStream input2 = new FileStream(this.allGeo, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader2 = new BinaryReader((Stream)input2);
            try
            {
                while ((this.sTmp = binaryReader2.ReadString()) != null)
                {
                    this.nPro = Convert.ToInt32(this.sTmp);
                    this.curName = binaryReader2.ReadString();
                    this.curDir = binaryReader2.ReadString();
                    this.curGeo = this.pathGeo + this.curDir;
                    if (Directory.Exists(this.curGeo))
                    {
                        this.curFile = this.curGeo + "\\ftah.pnt";
                        if (File.Exists(this.curFile))
                        {
                            this.nameFiles = File.ReadAllLines(this.curFile);
                            this.ip = 0;
                            foreach (string nameFile in this.nameFiles)
                                ++this.ip;
                            if (this.ip > 0)
                            {
                                ++this.kRec;
                                this.sCurDir[this.kRec] = this.curDir;
                                this.listBox1.Items.Add((object)this.curName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The Read operation failed as expected.");
            }
            finally
            {
                input2.Close();
                binaryReader2.Close();
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            this.myGeo.FilePath();
            if (this.listBox1.SelectedIndex < 0 && MessageBox.Show("Project wasn't selected. Do You want to leave Dialog ?", "Project selection", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Form.ActiveForm.Close();
            }
            else
            {
                if (File.Exists(this.allGeo))
                {
                    if (File.Exists(this.myGeo.filePoint))
                        File.Delete(this.myGeo.filePoint);
                    if (File.Exists(this.myGeo.fileLine))
                        File.Delete(this.myGeo.fileLine);
                    if (File.Exists(this.myGeo.flineTopo))
                        File.Delete(this.myGeo.flineTopo);
                    if (File.Exists(this.myGeo.filePoly))
                        File.Delete(this.myGeo.filePoly);
                    if (File.Exists(this.myGeo.fileDangle))
                        File.Delete(this.myGeo.fileDangle);
                    if (File.Exists(this.myGeo.fileNode))
                        File.Delete(this.myGeo.fileNode);
                    if (File.Exists(this.myGeo.fileExter))
                        File.Delete(this.myGeo.fileExter);
                    if (File.Exists(this.myGeo.fpointProj))
                        File.Delete(this.myGeo.fpointProj);
                    if (File.Exists(this.myGeo.flineProj))
                        File.Delete(this.myGeo.flineProj);
                    if (File.Exists(this.myGeo.ftopoProj))
                        File.Delete(this.myGeo.ftopoProj);
                    if (File.Exists(this.myGeo.fnodeProj))
                        File.Delete(this.myGeo.fnodeProj);
                    if (File.Exists(this.myGeo.fpolyProj))
                        File.Delete(this.myGeo.fpolyProj);
                    if (File.Exists(this.myGeo.ftopoParc))
                        File.Delete(this.myGeo.ftopoParc);
                    if (File.Exists(this.myGeo.fnodeParc))
                        File.Delete(this.myGeo.fnodeParc);
                    if (File.Exists(this.myGeo.fpolyParc))
                        File.Delete(this.myGeo.fpolyParc);
                    if (File.Exists(this.myGeo.fileAction))
                        File.Delete(this.myGeo.fileAction);
                    if (File.Exists(this.myGeo.factLine))
                        File.Delete(this.myGeo.factLine);
                    if (File.Exists(this.myGeo.factPoly))
                        File.Delete(this.myGeo.factPoly);
                    if (File.Exists(this.myGeo.factNode))
                        File.Delete(this.myGeo.factNode);
                    if (File.Exists(this.myGeo.flineCancel))
                        File.Delete(this.myGeo.flineCancel);
                    if (File.Exists(this.myGeo.fpolyCancel))
                        File.Delete(this.myGeo.fpolyCancel);
                    if (File.Exists(this.myGeo.flineNew))
                        File.Delete(this.myGeo.flineNew);
                    if (File.Exists(this.myGeo.fpolyNew))
                        File.Delete(this.myGeo.fpolyNew);
                    if (File.Exists(this.myGeo.flineFinal))
                        File.Delete(this.myGeo.flineFinal);
                    if (File.Exists(this.myGeo.fpolyFinal))
                        File.Delete(this.myGeo.fpolyFinal);
                    if (File.Exists(this.myGeo.fpointFinal))
                        File.Delete(this.myGeo.fpointFinal);
                    if (File.Exists(this.myGeo.fileItems))
                        File.Delete(this.myGeo.fileItems);
                    if (File.Exists(this.myGeo.fAddInscr))
                        File.Delete(this.myGeo.fAddInscr);
                    if (File.Exists(this.myGeo.fileHeight))
                        File.Delete(this.myGeo.fileHeight);
                    if (File.Exists(this.myGeo.fileContour))
                        File.Delete(this.myGeo.fileContour);
                    if (File.Exists(this.myGeo.fileZminzmax))
                        File.Delete(this.myGeo.fileZminzmax);
                    if (File.Exists(this.myGeo.fileTrian))
                        File.Delete(this.myGeo.fileTrian);
                    if (File.Exists(this.myGeo.fileInterval))
                        File.Delete(this.myGeo.fileInterval);
                    if (File.Exists(this.myGeo.fileSplit))
                        File.Delete(this.myGeo.fileSplit);
                    if (File.Exists(this.myGeo.fpointInscr))
                        File.Delete(this.myGeo.fpointInscr);
                    if (File.Exists(this.myGeo.ftmpPoly))
                        File.Delete(this.myGeo.ftmpPoly);
                    if (File.Exists(this.myGeo.faddPoly))
                        File.Delete(this.myGeo.faddPoly);
                    if (File.Exists(this.myGeo.fpolyInter))
                        File.Delete(this.myGeo.fpolyInter);
                    if (File.Exists(this.myGeo.fblockPoly))
                        File.Delete(this.myGeo.fblockPoly);
                    if (File.Exists(this.myGeo.fInscrFin))
                        File.Delete(this.myGeo.fInscrFin);
                    if (File.Exists(this.myGeo.flistAction))
                        File.Delete(this.myGeo.flistAction);
                    if (File.Exists(this.myGeo.fsourcePoly))
                        File.Delete(this.myGeo.fsourcePoly);
                    if (File.Exists(this.myGeo.fCancPoly))
                        File.Delete(this.myGeo.fCancPoly);
                    if (File.Exists(this.myGeo.fCancLine))
                        File.Delete(this.myGeo.fCancLine);
                    if (File.Exists(this.myGeo.fileProcess))
                        File.Delete(this.myGeo.fileProcess);
                    if (File.Exists(this.myGeo.fileToler))
                        File.Delete(this.myGeo.fileToler);
                    this.myGeo.AllActionRemove();
                }
                BinaryReader binaryReader1 = new BinaryReader((Stream)new FileStream(this.allGeo, FileMode.Open, FileAccess.Read));
                if (this.listBox1.SelectedIndex <= -1)
                    return;
                this.curDir = this.sCurDir[this.listBox1.SelectedIndex];
                this.fileTah = this.pathGeo + this.curDir + "\\ftah.pnt";
                this.fileCalc = this.pathGeo + this.curDir + "\\fcalc.pnt";
                this.fileGeo = this.pathGeo + this.curDir + "\\fgeo.xyz";
                double num1 = 9999999.9;
                double num2 = 9999999.9;
                double num3 = 9999999.9;
                double num4 = -9999999.9;
                double num5 = -9999999.9;
                double num6 = -9999999.9;
                this.kTaheo = 0;
                this.kPnt = 0;
                if (File.Exists(this.fileTah))
                {
                    FileStream input = new FileStream(this.fileTah, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader2 = new BinaryReader((Stream)input);
                    try
                    {
                        this.kTaheo = binaryReader2.ReadInt32();
                        for (int index = 0; index <= this.kTaheo; ++index)
                        {
                            this.myGeo.nameWork[index] = binaryReader2.ReadString();
                            this.myGeo.xWork[index] = binaryReader2.ReadDouble();
                            this.myGeo.yWork[index] = binaryReader2.ReadDouble();
                            this.myGeo.zWork[index] = binaryReader2.ReadDouble();
                            this.myGeo.nWork1[index] = binaryReader2.ReadInt32();
                            this.myGeo.xGeoInscr[index] = binaryReader2.ReadDouble();
                            this.myGeo.yGeoInscr[index] = binaryReader2.ReadDouble();
                            this.myGeo.iHorVerGeo[index] = binaryReader2.ReadInt32();
                            if (this.myGeo.xWork[index] < num1)
                                num1 = this.myGeo.xWork[index];
                            if (this.myGeo.xWork[index] > num4)
                                num4 = this.myGeo.xWork[index];
                            if (this.myGeo.yWork[index] < num2)
                                num2 = this.myGeo.yWork[index];
                            if (this.myGeo.yWork[index] > num5)
                                num5 = this.myGeo.yWork[index];
                            if (this.myGeo.zWork[index] < num3)
                                num3 = this.myGeo.zWork[index];
                            if (this.myGeo.zWork[index] > num6)
                                num6 = this.myGeo.zWork[index];
                        }
                        this.kPnt = this.kTaheo;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The Read operation failed as expected.");
                    }
                    finally
                    {
                        input.Close();
                        binaryReader2.Close();
                    }
                }
                if (this.kTaheo == 0)
                {
                    if (File.Exists(this.fileGeo))
                    {
                        FileStream input = new FileStream(this.fileGeo, FileMode.Open, FileAccess.Read);
                        BinaryReader binaryReader3 = new BinaryReader((Stream)input);
                        try
                        {
                            this.kGeo = binaryReader3.ReadInt32();
                            for (int index = 1; index <= this.kGeo; ++index)
                            {
                                this.myGeo.nameAdd[index] = binaryReader3.ReadString();
                                this.myGeo.xAdd[index] = binaryReader3.ReadDouble();
                                this.myGeo.yAdd[index] = binaryReader3.ReadDouble();
                                this.myGeo.zAdd[index] = binaryReader3.ReadDouble();
                                this.myGeo.nGeoCode[index] = binaryReader3.ReadInt32();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("The Read operation failed as expected.");
                        }
                        finally
                        {
                            input.Close();
                            binaryReader3.Close();
                        }
                    }
                    if (File.Exists(this.fileCalc))
                    {
                        FileStream input = new FileStream(this.fileCalc, FileMode.Open, FileAccess.Read);
                        BinaryReader binaryReader4 = new BinaryReader((Stream)input);
                        try
                        {
                            this.kPnt = binaryReader4.ReadInt32();
                            for (int index1 = 0; index1 <= this.kPnt; ++index1)
                            {
                                this.myGeo.nameWork[index1] = binaryReader4.ReadString();
                                this.myGeo.xWork[index1] = binaryReader4.ReadDouble();
                                this.myGeo.yWork[index1] = binaryReader4.ReadDouble();
                                this.myGeo.zWork[index1] = binaryReader4.ReadDouble();
                                this.myGeo.nWork1[index1] = binaryReader4.ReadInt32();
                                if (this.kGeo > 0)
                                {
                                    for (int index2 = 1; index2 <= this.kGeo; ++index2)
                                    {
                                        if (this.myGeo.nameWork[index1] == this.myGeo.nameAdd[index2])
                                        {
                                            this.myGeo.nWork1[index1] = 5;
                                            break;
                                        }
                                    }
                                }
                                if (this.myGeo.xWork[index1] < num1)
                                    num1 = this.myGeo.xWork[index1];
                                if (this.myGeo.xWork[index1] > num4)
                                    num4 = this.myGeo.xWork[index1];
                                if (this.myGeo.yWork[index1] < num2)
                                    num2 = this.myGeo.yWork[index1];
                                if (this.myGeo.yWork[index1] > num5)
                                    num5 = this.myGeo.yWork[index1];
                                if (this.myGeo.zWork[index1] < num3)
                                    num3 = this.myGeo.zWork[index1];
                                if (this.myGeo.zWork[index1] > num6)
                                    num6 = this.myGeo.zWork[index1];
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("The Read operation failed as expected.");
                        }
                        finally
                        {
                            input.Close();
                            binaryReader4.Close();
                        }
                    }
                }
                if (this.kPnt < 3)
                {
                    int num7 = (int)MessageBox.Show("No Data");
                }
                else
                {
                    if (File.Exists(this.myGeo.filePoint))
                        File.Delete(this.myGeo.filePoint);
                    FileStream output1 = new FileStream(this.myGeo.filePoint, FileMode.CreateNew);
                    BinaryWriter binaryWriter1 = new BinaryWriter((Stream)output1);
                    binaryWriter1.Write(this.kPnt);
                    binaryWriter1.Write(num1);
                    binaryWriter1.Write(num2);
                    binaryWriter1.Write(num3);
                    binaryWriter1.Write(num4);
                    binaryWriter1.Write(num5);
                    binaryWriter1.Write(num6);
                    for (int index = 0; index <= this.kPnt; ++index)
                    {
                        binaryWriter1.Write(this.myGeo.nameWork[index]);
                        binaryWriter1.Write(this.myGeo.xWork[index]);
                        binaryWriter1.Write(this.myGeo.yWork[index]);
                        binaryWriter1.Write(this.myGeo.zWork[index]);
                        binaryWriter1.Write(this.myGeo.nWork1[index]);
                        this.myGeo.nWork2[index] = 0;
                        binaryWriter1.Write(this.myGeo.nWork2[index]);
                        if (this.myGeo.zWork[index] != 0.0)
                        {
                            ++this.kHeight;
                            this.myGeo.nameAdd[this.kHeight] = this.myGeo.nameWork[index];
                            this.myGeo.xAdd[this.kHeight] = this.myGeo.xWork[index];
                            this.myGeo.yAdd[this.kHeight] = this.myGeo.yWork[index];
                            this.myGeo.zAdd[this.kHeight] = this.myGeo.zWork[index];
                        }
                    }
                    binaryWriter1.Write(this.kPnt);
                    output1.Close();
                    binaryWriter1.Close();
                    if (this.kHeight > 4)
                    {
                        if (File.Exists(this.myGeo.fileHeight))
                            File.Delete(this.myGeo.fileHeight);
                        FileStream output2 = new FileStream(this.myGeo.fileHeight, FileMode.CreateNew);
                        BinaryWriter binaryWriter2 = new BinaryWriter((Stream)output2);
                        binaryWriter2.Write(this.kHeight);
                        for (int index = 0; index <= this.kHeight; ++index)
                        {
                            binaryWriter2.Write(this.myGeo.nameAdd[index]);
                            binaryWriter2.Write(this.myGeo.xAdd[index]);
                            binaryWriter2.Write(this.myGeo.yAdd[index]);
                            binaryWriter2.Write(this.myGeo.zAdd[index]);
                        }
                        binaryWriter2.Close();
                        output2.Close();
                    }
                    Form.ActiveForm.Close();
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e) => Form.ActiveForm.Close();
    }
}

