namespace JournalIO
{
    partial class Form2
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.DateEntry = new System.Windows.Forms.RichTextBox();
            this.ContentsEntry = new System.Windows.Forms.RichTextBox();
            this.Results = new System.Windows.Forms.RichTextBox();
            this.Next = new System.Windows.Forms.Button();
            this.NumResults = new System.Windows.Forms.TextBox();
            this.StartSearch = new System.Windows.Forms.Button();
            this.DateDisplayer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(36, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Search by date below:";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(475, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(233, 26);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "";
            this.textBox2.Text = "Search by contents below:";
            // 
            // DateEntry
            // 
            this.DateEntry.Location = new System.Drawing.Point(36, 111);
            this.DateEntry.Name = "DateEntry";
            this.DateEntry.Size = new System.Drawing.Size(367, 60);
            this.DateEntry.TabIndex = 2;
            this.DateEntry.Text = "";
            // 
            // ContentsEntry
            // 
            this.ContentsEntry.Location = new System.Drawing.Point(470, 111);
            this.ContentsEntry.Name = "ContentsEntry";
            this.ContentsEntry.Size = new System.Drawing.Size(291, 59);
            this.ContentsEntry.TabIndex = 3;
            this.ContentsEntry.Text = "";
            // 
            // Results
            // 
            this.Results.Location = new System.Drawing.Point(45, 287);
            this.Results.Name = "Results";
            this.Results.ReadOnly = true;
            this.Results.Size = new System.Drawing.Size(897, 339);
            this.Results.TabIndex = 4;
            this.Results.Text = "";
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(782, 222);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(141, 46);
            this.Next.TabIndex = 5;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // NumResults
            // 
            this.NumResults.Location = new System.Drawing.Point(579, 232);
            this.NumResults.Name = "NumResults";
            this.NumResults.Size = new System.Drawing.Size(148, 26);
            this.NumResults.TabIndex = 6;
            this.NumResults.Text = "Result";
            // 
            // StartSearch
            // 
            this.StartSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartSearch.Location = new System.Drawing.Point(842, 89);
            this.StartSearch.Name = "StartSearch";
            this.StartSearch.Size = new System.Drawing.Size(193, 100);
            this.StartSearch.TabIndex = 7;
            this.StartSearch.Text = "Search";
            this.StartSearch.UseVisualStyleBackColor = true;
            this.StartSearch.Click += new System.EventHandler(this.StartSearch_Click);
            // 
            // DateDisplayer
            // 
            this.DateDisplayer.Location = new System.Drawing.Point(57, 232);
            this.DateDisplayer.Name = "DateDisplayer";
            this.DateDisplayer.Size = new System.Drawing.Size(141, 26);
            this.DateDisplayer.TabIndex = 8;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 704);
            this.Controls.Add(this.DateDisplayer);
            this.Controls.Add(this.StartSearch);
            this.Controls.Add(this.NumResults);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.ContentsEntry);
            this.Controls.Add(this.DateEntry);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox DateEntry;
        private System.Windows.Forms.RichTextBox ContentsEntry;
        private System.Windows.Forms.RichTextBox Results;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.TextBox NumResults;
        private System.Windows.Forms.Button StartSearch;
        private System.Windows.Forms.TextBox DateDisplayer;
    }
}