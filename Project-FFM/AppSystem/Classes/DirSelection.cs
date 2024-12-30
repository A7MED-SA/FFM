using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Project_FFM.AppSystem.Classes
{
    internal class DirSelection
    {
        //Function to get folders at the Source Address
        static public string[] DirGet(string pathS)
        {
            string[] dirs = new string[] { pathS };
            Console.WriteLine("-------------------------------------");
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

        static long GetFolderSize(string folderPath)
        {
            long totalSize = 0;

            // الحصول على أحجام الملفات داخل المجلد
            FileInfo[] files = new DirectoryInfo(folderPath).GetFiles();
            foreach (FileInfo file in files)
            {
                totalSize += file.Length;
            }

            // الحصول على أحجام المجلدات الفرعية
            DirectoryInfo[] subDirectories = new DirectoryInfo(folderPath).GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                totalSize += GetFolderSize(subDirectory.FullName);
            }

            return totalSize;
        }
    }
}
