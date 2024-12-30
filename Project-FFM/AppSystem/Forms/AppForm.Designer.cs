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
            listBox1 = new ListBox();
            button1 = new Button();
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
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(36, 122);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(176, 199);
            listBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(257, 186);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 342);
            Controls.Add(button1);
            Controls.Add(listBox1);
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
        private ListBox listBox1;
        private Button button1;
    }
}