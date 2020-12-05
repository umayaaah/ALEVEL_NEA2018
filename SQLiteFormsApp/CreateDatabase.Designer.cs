namespace SQLiteFormsApp
{
    partial class CreateDatabase
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
            this.bDoIT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bDoIT
            // 
            this.bDoIT.Location = new System.Drawing.Point(196, 183);
            this.bDoIT.Name = "bDoIT";
            this.bDoIT.Size = new System.Drawing.Size(76, 55);
            this.bDoIT.TabIndex = 0;
            this.bDoIT.Text = "Do It";
            this.bDoIT.UseVisualStyleBackColor = true;
            this.bDoIT.Click += new System.EventHandler(this.bDoIT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bDoIT);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bDoIT;
    }
}

