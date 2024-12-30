using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        static string destinationFolder = "";
        static string sourceFolder = "";
        public AppForm()
        {
            InitializeComponent();
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
                    sourceFolder = folderBrowser.SelectedPath;
                    sourcePathtxt.Text = sourceFolder;
                }
                else
                {
                    sourceFolder = "";
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
                    destinationFolder = folderBrowser.SelectedPath;
                    destinationPathtxt.Text = destinationFolder;
                }
                else
                {
                    destinationFolder = "";
                    destinationPathtxt.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sourceFolder == "")
                MessageBox.Show("Plz select folder");
            else
            {
                listBox1.Items.Clear();
                string[] dirs = DirSelection.DirGet(sourceFolder);
                string[] files = FileSelection.GetFiles(dirs);
                for(long i=0;i<files.Length;i++)
                {
                    listBox1.Items.Add(Path.GetFileName(files[i]));
                }
            }
        }
    }
}
