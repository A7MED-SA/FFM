
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Project_FFM; 

namespace Project_FFM.AppSystem.Classes
{
    internal class FileSelection
    {
        //Registered dictionary with the names of the folders and
        //each extension is suitable for the type of folder
        static Dictionary<string, List<string>> extensions = new Dictionary<string, List<string>>
        {
            { "Images", new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".svg", ".webp" } },
            { "Videos", new List<string> { ".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv", ".webm" } },
            { "Documents", new List<string> { ".doc", ".docx", ".pdf", ".txt", ".rtf", ".odt", ".xls", ".xlsx", ".ppt", ".pptx", ".csv" } },
            { "Audio", new List<string> { ".mp3", ".wav", ".flac", ".aac", ".ogg", ".m4a", ".wma" } },
            { "Compressed", new List<string> { ".zip", ".rar", ".tar", ".7z", ".gz", ".iso" } },
            { "Code Files", new List<string> { ".cs", ".java", ".cpp", ".js", ".html", ".css", ".py", ".php", ".rb" } },
            { "Executables", new List<string> { ".exe", ".bat", ".msi", ".apk", ".app", ".dmg", ".bin" } },
            { "Databases", new List<string> { ".sql", ".db", ".sqlite", ".mdb", ".accdb" } },
            { "Fonts", new List<string> { ".ttf", ".otf", ".woff", ".woff2" } },
            { "Archives", new List<string> { ".tar.gz", ".tar.bz2", ".xz", ".rar", ".7z" } },
            { "Web Files", new List<string> { ".html", ".css", ".js", ".json", ".xml", ".svg", ".woff", ".woff2" } }
        };

        //Function to see the appropriate folder type using the folder extension
        static public string GetFileCategory(string fileExtension)
        {
            foreach (var category in extensions)
            {
                if (category.Value.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
                {
                    return category.Key;
                }
            }
            return null;
        }

        static public string[] GetFiles(string[] dirs)
        {
            string[] files = new string[] { };
            for (long i = dirs.Length - 1; i >= 0; i--)
            {
                string[] filesfiles = Directory.GetFiles(dirs[i]);
                files = files.Concat(filesfiles).ToArray();
                
            }
            return files;
        }

        /*
        for (long j = 0; j < files.Length; j++)
                {
                    try
                    {
                        string extension = Path.GetExtension(files[j]); //value
                        string category = GetFileCategory(extension);   //key
                        string filePath = files[j];                     //fileSpath
                        string fileName = Path.GetFileName(filePath);   //filename
                        string destinationFilePath = GetUniqueFilePath(Path.Combine(DirSelection.CheckDirEx(Program.destinationFolder, category), fileName));
                       
                        Console.WriteLine($"{filePath} => {fileName} {extension} {category} => {destinationFilePath}");
                        CopyFileInChunks(filePath, destinationFilePath);
                        // حذف الملف المصدر (اختياري)
                        File.Delete(filePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

        */
        //Function aims to generate a unique path of a file inside the destination folder.
        //If there is a file with the same name,
        //the function adds a serial number to the file name until it becomes unique
        static public string GetUniqueFilePath(string filePathinDestination)
        {
            //
            string directory = Path.GetDirectoryName(filePathinDestination);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePathinDestination);
            string extension = Path.GetExtension(filePathinDestination);

            int counter = 1;
            string uniqueFilePath = filePathinDestination;

            while (File.Exists(uniqueFilePath))
            {
                uniqueFilePath = Path.Combine(directory, $"{fileNameWithoutExtension} ({counter}){extension}");
                counter++;
            }

            return uniqueFilePath;
        }


        //CopyfileInchnks function carries out a file copying from another to another using
        //reading and writing on parts to ensure high performance and managing memory use effectively,
        //especially with large files.
        static public void CopyFileInChunks(string sourceFilePath, string destinationFilePath)
        {
            const int bufferSize = 1024 * 1024; // 1 Mb
            byte[] buffer = new byte[bufferSize];

            using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
            {
                long totalBytes = sourceStream.Length;
                long totalBytesCopied = 0;

                int bytesRead;
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                    totalBytesCopied += bytesRead;

                    Console.WriteLine($"تم نقل {totalBytesCopied} من {totalBytes} بايت...");
                }
            }
        }
    }




}
