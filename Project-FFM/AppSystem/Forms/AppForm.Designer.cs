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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            sizelbl = new Label();
            SuspendLayout();
            // 
            // sourcePathtxt
            // 
            sourcePathtxt.Location = new Point(132, 36);
            sourcePathtxt.Name = "sourcePathtxt";
            sourcePathtxt.ReadOnly = true;
            sourcePathtxt.Size = new Size(240, 23);
            sourcePathtxt.TabIndex = 0;
            // 
            // destinationPathtxt
            // 
            destinationPathtxt.Location = new Point(132, 86);
            destinationPathtxt.Name = "destinationPathtxt";
            destinationPathtxt.ReadOnly = true;
            destinationPathtxt.Size = new Size(240, 23);
            destinationPathtxt.TabIndex = 1;
            // 
            // sourcePathbn
            // 
            sourcePathbn.Location = new Point(391, 36);
            sourcePathbn.Name = "sourcePathbn";
            sourcePathbn.Size = new Size(33, 23);
            sourcePathbn.TabIndex = 2;
            sourcePathbn.Text = "...";
            sourcePathbn.UseVisualStyleBackColor = true;
            sourcePathbn.Click += selectbn_Click;
            // 
            // destinationPathbn
            // 
            destinationPathbn.Location = new Point(391, 86);
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
            fileslist.Location = new Point(12, 177);
            fileslist.Name = "fileslist";
            fileslist.Size = new Size(176, 199);
            fileslist.TabIndex = 4;
            // 
            // showFilesbn
            // 
            showFilesbn.Location = new Point(194, 308);
            showFilesbn.Name = "showFilesbn";
            showFilesbn.Size = new Size(75, 23);
            showFilesbn.TabIndex = 5;
            showFilesbn.Text = "Show Files";
            showFilesbn.UseVisualStyleBackColor = true;
            showFilesbn.Click += showFilesbn_Click;
            // 
            // moveFilesbn
            // 
            moveFilesbn.Location = new Point(194, 258);
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
            deletechk.Location = new Point(468, 81);
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
            loglist.Location = new Point(275, 177);
            loglist.Name = "loglist";
            loglist.Size = new Size(381, 199);
            loglist.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(81, 17);
            label1.TabIndex = 10;
            label1.Text = "Source Path";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(109, 17);
            label2.TabIndex = 11;
            label2.Text = "Destination Path";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 134);
            label3.Name = "label3";
            label3.Size = new Size(61, 17);
            label3.TabIndex = 12;
            label3.Text = "Size Files";
            // 
            // sizelbl
            // 
            sizelbl.BorderStyle = BorderStyle.FixedSingle;
            sizelbl.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sizelbl.Location = new Point(132, 128);
            sizelbl.Name = "sizelbl";
            sizelbl.Size = new Size(240, 23);
            sizelbl.TabIndex = 13;
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 388);
            Controls.Add(sizelbl);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FFM - Files and Folders Management";
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
        private Label label1;
        private Label label2;
        static public ListBox loglist;
        private Label label3;
        private Label sizelbl;
    }
}