namespace Project_FFM.AppSystem.Forms
{
    partial class AppForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sourcePathtxt = new TextBox();
            destinationPathtxt = new TextBox();
            sourcePathbn = new Button();
            destinationPathbn = new Button();
            fileslist = new ListBox();
            showFilesbn = new Button();
            moveFilesbn = new Button();
            deletechk = new CheckBox();
            loglist = new ListBox();
            SuspendLayout();
            // 
            // sourcePathtxt
            // 
            sourcePathtxt.Location = new Point(36, 32);
            sourcePathtxt.Name = "sourcePathtxt";
            sourcePathtxt.ReadOnly = true;
            sourcePathtxt.Size = new Size(240, 23);
            sourcePathtxt.TabIndex = 0;
            // 
            // destinationPathtxt
            // 
            destinationPathtxt.Location = new Point(36, 82);
            destinationPathtxt.Name = "destinationPathtxt";
            destinationPathtxt.ReadOnly = true;
            destinationPathtxt.Size = new Size(240, 23);
            destinationPathtxt.TabIndex = 1;
            // 
            // sourcePathbn
            // 
            sourcePathbn.Location = new Point(295, 32);
            sourcePathbn.Name = "sourcePathbn";
            sourcePathbn.Size = new Size(33, 23);
            sourcePathbn.TabIndex = 2;
            sourcePathbn.Text = "...";
            sourcePathbn.UseVisualStyleBackColor = true;
            sourcePathbn.Click += selectbn_Click;
            // 
            // destinationPathbn
            // 
            destinationPathbn.Location = new Point(295, 82);
            destinationPathbn.Name = "destinationPathbn";
            destinationPathbn.Size = new Size(33, 23);
            destinationPathbn.TabIndex = 3;
            destinationPathbn.Text = "...";
            destinationPathbn.UseVisualStyleBackColor = true;
            destinationPathbn.Click += destinationPathbn_Click;
            // 
            // fileslist
            // 
            fileslist.FormattingEnabled = true;
            fileslist.ItemHeight = 15;
            fileslist.Location = new Point(36, 159);
            fileslist.Name = "fileslist";
            fileslist.Size = new Size(176, 199);
            fileslist.TabIndex = 4;
            // 
            // showFilesbn
            // 
            showFilesbn.Location = new Point(224, 298);
            showFilesbn.Name = "showFilesbn";
            showFilesbn.Size = new Size(75, 23);
            showFilesbn.TabIndex = 5;
            showFilesbn.Text = "Show Files";
            showFilesbn.UseVisualStyleBackColor = true;
            showFilesbn.Click += showFilesbn_Click;
            // 
            // moveFilesbn
            // 
            moveFilesbn.Location = new Point(224, 248);
            moveFilesbn.Name = "moveFilesbn";
            moveFilesbn.Size = new Size(75, 23);
            moveFilesbn.TabIndex = 6;
            moveFilesbn.Text = "Move Files";
            moveFilesbn.UseVisualStyleBackColor = true;
            moveFilesbn.Click += moveFilesbn_Click_1;
            // 
            // deletechk
            // 
            deletechk.AutoSize = true;
            deletechk.Location = new Point(382, 26);
            deletechk.Name = "deletechk";
            deletechk.Size = new Size(126, 34);
            deletechk.TabIndex = 8;
            deletechk.Text = "Delete original files\r\n      (warning)";
            deletechk.UseVisualStyleBackColor = true;
            // 
            // loglist
            // 
            loglist.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loglist.FormattingEnabled = true;
            loglist.HorizontalScrollbar = true;
            loglist.ItemHeight = 13;
            loglist.Location = new Point(308, 159);
            loglist.Name = "loglist";
            loglist.Size = new Size(297, 199);
            loglist.TabIndex = 9;
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 370);
            Controls.Add(loglist);
            Controls.Add(deletechk);
            Controls.Add(moveFilesbn);
            Controls.Add(showFilesbn);
            Controls.Add(fileslist);
            Controls.Add(destinationPathbn);
            Controls.Add(sourcePathbn);
            Controls.Add(destinationPathtxt);
            Controls.Add(sourcePathtxt);
            Name = "AppForm";
            Text = "AppForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox sourcePathtxt;
        private TextBox destinationPathtxt;
        private Button sourcePathbn;
        private Button destinationPathbn;
        private Button showFilesbn;
        private Button moveFilesbn;
        private ListBox fileslist;
        private CheckBox deletechk;
        static public ListBox loglist;
    }
}