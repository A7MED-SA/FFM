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
        public static int MoveInfoFlag { get; set; } = 0;

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

                loglist.HorizontalExtent = maxWidth+15;
            }
        }


        private void selectbn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                //folderBrowser.Description = "";
                folderBrowser.ShowNewFolderButton = true;

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
                folderBrowser.ShowNewFolderButton = true;

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
                        SourceFolderSize = size;
                        sizelbl.Text = $"{SourceFolderSize} bytes";
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private async void moveFilesbn_Click_1(object sender, EventArgs e)
        {
            
            if (MoveInfoFlag == 1)
            {
                MessageBox.Show("Alre");
                return;
            }

            if (Files == null || Files.Length == 0|| ShowInfoFlag == 0)
            {
                MessageBox.Show("Please click 'Show Files' first.");
                return;
            }

            if (!DirSelection.IsEnoughSpace(DestinationFolder.Substring(0, 3), SourceFolderSize))
            {
                MessageBox.Show("Not enough space in the destination folder.");
                return;
            }

            try
            {
                for (long fileIndex = 0; fileIndex < Files.Length; fileIndex++)
                {

                    string extension = Path.GetExtension(Files[fileIndex]); 
                    string category = FileSelection.GetFileCategory(extension);   
                    string filePath = Files[fileIndex];                     
                    string fileName = Path.GetFileName(filePath);   
                    string destinationFilePath = FileSelection.GetUniqueFilePath(Path.Combine(DirSelection.CheckDirEx(DestinationFolder, category), fileName));

                    await FileSelection.CopyFileInChunksAsync(fileName, filePath, destinationFilePath);
                    if (deletechk.Checked)
                        FileSelection.DeleteFile(filePath,fileName);
                }

                for(long dirIndex = Directories.Length-1; dirIndex >=0 ;dirIndex--)
                {
                    if (deletechk.Checked)
                        DirSelection.DeleteFolder(Directories[dirIndex]);
                }

                MessageBox.Show("All files moved successfully!");
                MoveInfoFlag = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
