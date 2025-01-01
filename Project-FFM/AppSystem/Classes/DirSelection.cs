using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_FFM.AppSystem.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Project_FFM.AppSystem.Classes
{
    internal class DirSelection
    {
        //Function to get folders at the Source Address
        static public string[] DirGet(string pathS)
        {
            string[] dirs = new string[] { pathS };
            for (long i = 0; i < dirs.Length; i++)
            {
                string[] dirdirs = Directory.GetDirectories(dirs[i]);
                dirs = dirs.Concat(dirdirs).ToArray();
            }
            return dirs;
        }

        //Function to make sure that the appropriate folder exists
        //or not in the event that it does not exist
        //that it creates and returns the address of the folder
        static public string CheckDirEx(string pathD,string category)
        {
            string filePathD;
            if (category!=null)
            {
                filePathD = Path.Combine(pathD, category);
            }
            else
            {
                filePathD = Path.Combine(pathD, "Others");
            }
            if (!Directory.Exists(filePathD))
                Directory.CreateDirectory(filePathD);
            return filePathD;
        }

        static public bool IsEnoughSpace(string drivePath, long requiredSpace)
        {
            DriveInfo drive = new DriveInfo(drivePath);

            return drive.AvailableFreeSpace >= requiredSpace;
        }

        static public void DeleteFolder(string sourceFolderPath)
        {
            try
            {
                if (Directory.GetFiles(sourceFolderPath).Length == 0 && Directory.GetDirectories(sourceFolderPath).Length == 0)
                {
                    Directory.Delete(sourceFolderPath);
                    AppForm.AddLog($"Deleted empty folder: {sourceFolderPath}");
                }
            }
            catch (Exception ex)
            {
                AppForm.AddLog($"Error deleting {sourceFolderPath} : {ex.Message}");
            }
        }
    }
}
