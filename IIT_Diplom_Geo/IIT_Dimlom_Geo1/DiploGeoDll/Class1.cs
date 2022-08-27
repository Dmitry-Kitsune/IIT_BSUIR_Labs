
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace DiploGeoDll;

public class Class1
{
    public static void CheckDrive(string dirName, out string strPath)
    {
        string sTmp = "";
        strPath = "";
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        foreach (DriveInfo d in allDrives)
        {
            if ((d.Name[0] == 'A') || (d.Name[0] == 'a'))
                continue;
            if ((d.Name[0] == 'B') || (d.Name[0] == 'b'))
                continue;
            if (d.IsReady == false)
                continue;
            if (d.DriveFormat == "CDUDF")
                continue;
            sTmp = d.Name + dirName;
            if (Directory.Exists(sTmp))
            {
                strPath = d.Name;
                break;
            }
        }
    }
}
