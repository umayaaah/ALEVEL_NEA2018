namespace SQLiteFormsApp
{
    partial class TimetableForm
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
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnStudentTT = new System.Windows.Forms.Button();
            this.btnTeacherTT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(52, 418);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(519, 74);
            this.btnMainMenu.TabIndex = 70;
            this.btnMainMenu.Text = "Back to Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnStudentTT
            // 
            this.btnStudentTT.BackColor = System.Drawing.Color.AliceBlue;
            this.btnStudentTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentTT.Location = new System.Drawing.Point(52, 279);
            this.btnStudentTT.Name = "btnStudentTT";
            this.btnStudentTT.Size = new System.Drawing.Size(519, 74);
            this.btnStudentTT.TabIndex = 71;
            this.btnStudentTT.Text = "View student timetables";
            this.btnStudentTT.UseVisualStyleBackColor = false;
            this.btnStudentTT.Click += new System.EventHandler(this.btnStudentTT_Click);
            // 
            // btnTeacherTT
            // 
            this.btnTeacherTT.BackColor = System.Drawing.Color.AliceBlue;
            this.btnTeacherTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherTT.Location = new System.Drawing.Point(52, 166);
            this.btnTeacherTT.Name = "btnTeacherTT";
            this.btnTeacherTT.Size = new System.Drawing.Size(519, 74);
            this.btnTeacherTT.TabIndex = 72;
            this.btnTeacherTT.Text = "View teacher timetables";
            this.btnTeacherTT.UseVisualStyleBackColor = false;
            this.btnTeacherTT.Click += new System.EventHandler(this.btnTeacherTT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 75;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(42, 58);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(375, 55);
            this.lblTitle.TabIndex = 74;
            this.lblTitle.Text = "View Timetables";
            // 
            // TimetableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(618, 566);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnTeacherTT);
            this.Controls.Add(this.btnStudentTT);
            this.Controls.Add(this.btnMainMenu);
            this.Name = "TimetableForm";
            this.Text = "Timetable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnStudentTT;
        private System.Windows.Forms.Button btnTeacherTT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
    }
}