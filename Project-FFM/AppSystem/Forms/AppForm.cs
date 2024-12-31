using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_FFM.AppSystem.Classes;

namespace Project_FFM.AppSystem.Forms
{

    public partial class AppForm : Form
    {
        public static string DestinationFolder { get; set; } = "";
        public static string SourceFolder { get; set; } = "";
        public static long SourceFolderSize { get; private set; } = 0;
        public static string[] Files { get; private set; }
        public static string[] Directories { get; private set; }
        public static int ShowInfoFlag { get; set; } = 0;

        public AppForm()
        {
            InitializeComponent();
        }

        static private void UpdateHorizontalScrollbar()
        {
            using (Graphics g = loglist.CreateGraphics())
            {
                int maxWidth = 0;

                foreach (var item in loglist.Items)
                {
                    int itemWidth = (int)g.MeasureString(item.ToString(), loglist.Font).Width;
                    if (itemWidth > maxWidth)
                        maxWidth = itemWidth;
                }

                loglist.HorizontalExtent = maxWidth;
            }
        }


        private void selectbn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                //folderBrowser.Description = "";
                folderBrowser.ShowNewFolderButton = true; // إظهار خيار إنشاء مجلد جديد

                DialogResult result = folderBrowser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    SourceFolder = folderBrowser.SelectedPath;
                    sourcePathtxt.Text = SourceFolder;
                }
                else
                {
                    SourceFolder = "";
                    sourcePathtxt.Text = "";
                }
            }
        }

        private void destinationPathbn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                //folderBrowser.Description = "";
                folderBrowser.ShowNewFolderButton = true; // إظهار خيار إنشاء مجلد جديد

                DialogResult result = folderBrowser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    DestinationFolder = folderBrowser.SelectedPath;
                    destinationPathtxt.Text = DestinationFolder;
                }
                else
                {
                    DestinationFolder = "";
                    destinationPathtxt.Text = "";
                }
            }
        }



        public static void AddLog(string log)
        {
            if (loglist.InvokeRequired)
            {
                loglist.Invoke(new Action(() =>
                {
                    loglist.Items.Add(log);
                    UpdateHorizontalScrollbar();
                }));
            }
            else
            {
                loglist.Items.Add(log);
                UpdateHorizontalScrollbar();
            }
        }

        private void showFilesbn_Click(object sender, EventArgs e)
        {
            if (SourceFolder == "")
                MessageBox.Show("Plz select folder");
            else
            {
                if (DestinationFolder == "")
                    MessageBox.Show("Plz select folder");
                else
                {
                    try
                    {
                        long size = 0;
                        ShowInfoFlag = 1;
                        fileslist.Items.Clear();
                        Directories = DirSelection.DirGet(SourceFolder);
                        Files = FileSelection.GetFiles(Directories);
                        for (long i = 0; i < Files.Length; i++)
                        {
                            FileInfo info = new FileInfo(Files[i]);
                            size += info.Length;
                            fileslist.Items.Add(Path.GetFileName(Files[i]));
                        }
                        fileslist.Items.Add(size.ToString());
                        SourceFolderSize = size;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private async void moveFilesbn_Click_1(object sender, EventArgs e)
        {
            //if (Files == null || Files.Length == 0)
            //{
            //    MessageBox.Show("Please click 'Show Files' first.");
            //    return;
            //}

            //if (!DirSelection.IsEnoughSpace(DestinationFolder.Substring(0, 3), SourceFolderSize))
            //{
            //    MessageBox.Show("Not enough space in the destination folder.");
            //    return;
            //}

            try
            {
                for (long j = 0; j < Files.Length; j++)
                {

                    string extension = Path.GetExtension(Files[j]); //value
                    string category = FileSelection.GetFileCategory(extension);   //key
                    string filePath = Files[j];                     //fileSpath
                    string fileName = Path.GetFileName(filePath);   //filename
                    string destinationFilePath = FileSelection.GetUniqueFilePath(Path.Combine(DirSelection.CheckDirEx(DestinationFolder, category), fileName));

                    //Console.WriteLine($"{filePath} => {fileName} {extension} {category} => {destinationFilePath}");
                    //await CopyFileInChunksAsync(sourceFile, destinationFile);
                    await FileSelection.CopyFileInChunksAsync(fileName,filePath, destinationFilePath);
                    //FileSelection.CopyFileInChunks(filePath, destinationFilePath);
                    if (deletechk.Checked)
                        File.Delete(filePath);
                }
                MessageBox.Show("All files moved successfully!");

                //FileSelection.test();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
