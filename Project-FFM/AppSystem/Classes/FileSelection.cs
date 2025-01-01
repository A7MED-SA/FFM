
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Project_FFM;
using Project_FFM.AppSystem.Forms;

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


        static public void DeleteFile(string sourceFilePath, string fileName)
        {
            try
            {
                AppForm.AddLog($"Deleting file: {fileName}");
                File.Delete(sourceFilePath);
            }
            catch (Exception ex)
            {
                AppForm.AddLog($"Error deleting {fileName} : {ex.Message}");
            }
        }

        //CopyfileInchnks function carries out a file copying from another to another using
        //reading and writing on parts to ensure high performance and managing memory use effectively,
        //especially with large files.
        static public async Task CopyFileInChunksAsync(string nameFile, string sourceFilePath, string destinationFilePath)
        {
            const int bufferSize = 1024 * 1024; // 1 MB
            byte[] buffer = new byte[bufferSize];

            using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
            {
                long totalBytes = sourceStream.Length;
                long totalBytesCopied = 0;

                int bytesRead;
                while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await destinationStream.WriteAsync(buffer, 0, bytesRead);
                    totalBytesCopied += bytesRead;

                    string progressLog = $"Copying {nameFile}: {totalBytesCopied} / {totalBytes} bytes...";
                    AppForm.AddLog(progressLog); 
                    await Task.Delay(50); 
                }
            }
            AppForm.AddLog($"Finished moving {nameFile}");
        }
       
        //static public void CopyFileInChunks(string sourceFilePath, string destinationFilePath)
        //{
        //    const int bufferSize = 1024 * 1024; // 1 Mb
        //    byte[] buffer = new byte[bufferSize];

        //    using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
        //    using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
        //    {
        //        long totalBytes = sourceStream.Length;
        //        long totalBytesCopied = 0;

        //        int bytesRead;
        //        while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
        //        {
        //            destinationStream.Write(buffer, 0, bytesRead);
        //            totalBytesCopied += bytesRead;

        //            string log = $"from {totalBytesCopied} to {totalBytes}\n";
        //            //Console.WriteLine($"تم نقل {totalBytesCopied} من {totalBytes} بايت...");
        //            AppForm.AddLog(log);
        //        }
        //    }
        //}

      
        /*
         * static void ResumeableFileCopy(string sourceFilePath, string destinationFilePath)
    {
        const int bufferSize = 1024 * 1024; // حجم القطعة (1 ميجابايت)
        byte[] buffer = new byte[bufferSize];

        long sourceFileSize = new FileInfo(sourceFilePath).Length;
        long destinationFileSize = File.Exists(destinationFilePath) ? new FileInfo(destinationFilePath).Length : 0;

        // تحقق من أن الوجهة ليست أكبر من المصدر
        if (destinationFileSize > sourceFileSize)
        {
            throw new InvalidOperationException("الملف الوجهة أكبر من الملف المصدر. النقل غير ممكن.");
        }

        using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
        using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Append, FileAccess.Write))
        {
            sourceStream.Position = destinationFileSize; // ابدأ من حيث توقفت
            long totalBytesCopied = destinationFileSize;

            Console.WriteLine($"استئناف النقل من {destinationFileSize} بايت من أصل {sourceFileSize} بايت...");

            int bytesRead;
            while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                destinationStream.Write(buffer, 0, bytesRead);
                totalBytesCopied += bytesRead;

                // عرض نسبة التقدم
                Console.WriteLine($"تم نقل {totalBytesCopied} من {sourceFileSize} بايت...");

                // تحقق من الإيقاف المؤقت (يمكن محاكاته هنا)
                if (CheckForPause())
                {
                    Console.WriteLine("تم إيقاف العملية من قبل المستخدم.");
                    break;
                }
            }
        }
    }

    static bool CheckForPause()
    {
        // في تطبيق واقعي، يمكن استبدال هذا بفحص فعلي لإشارة إيقاف أو مؤقت.
        return false; // قم بتغيير القيمة إلى true لمحاكاة الإيقاف.
    }
         * */
    }




}
