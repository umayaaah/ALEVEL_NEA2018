namespace SQLiteFormsApp
{
    partial class MainMenuForm
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
            this.lblMainMenu = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnGenerateTimetable = new System.Windows.Forms.Button();
            this.btnViewTables = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddStudentSubjects = new System.Windows.Forms.Button();
            this.btnViewTT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMainMenu
            // 
            this.lblMainMenu.AutoSize = true;
            this.lblMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainMenu.Location = new System.Drawing.Point(215, 116);
            this.lblMainMenu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainMenu.Name = "lblMainMenu";
            this.lblMainMenu.Size = new System.Drawing.Size(417, 85);
            this.lblMainMenu.TabIndex = 3;
            this.lblMainMenu.Text = "Main Menu";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(143, 49);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(571, 67);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Timetable Generator";
            // 
            // btnGenerateTimetable
            // 
            this.btnGenerateTimetable.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGenerateTimetable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateTimetable.Location = new System.Drawing.Point(112, 567);
            this.btnGenerateTimetable.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateTimetable.Name = "btnGenerateTimetable";
            this.btnGenerateTimetable.Size = new System.Drawing.Size(624, 79);
            this.btnGenerateTimetable.TabIndex = 11;
            this.btnGenerateTimetable.Text = "Generate new timetables";
            this.btnGenerateTimetable.UseVisualStyleBackColor = false;
            this.btnGenerateTimetable.Click += new System.EventHandler(this.btnTimetable_Click);
            // 
            // btnViewTables
            // 
            this.btnViewTables.BackColor = System.Drawing.Color.AliceBlue;
            this.btnViewTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewTables.Location = new System.Drawing.Point(112, 266);
            this.btnViewTables.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewTables.Name = "btnViewTables";
            this.btnViewTables.Size = new System.Drawing.Size(624, 79);
            this.btnViewTables.TabIndex = 12;
            this.btnViewTables.Text = "Update/view school information";
            this.btnViewTables.UseVisualStyleBackColor = false;
            this.btnViewTables.Click += new System.EventHandler(this.btnViewTables_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(112, 704);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(624, 79);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddStudentSubjects
            // 
            this.btnAddStudentSubjects.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAddStudentSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudentSubjects.Location = new System.Drawing.Point(112, 368);
            this.btnAddStudentSubjects.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddStudentSubjects.Name = "btnAddStudentSubjects";
            this.btnAddStudentSubjects.Size = new System.Drawing.Size(624, 74);
            this.btnAddStudentSubjects.TabIndex = 14;
            this.btnAddStudentSubjects.Text = "Add student subject options";
            this.btnAddStudentSubjects.UseVisualStyleBackColor = false;
            this.btnAddStudentSubjects.Click += new System.EventHandler(this.btnAddStudentSubjects_Click);
            // 
            // btnViewTT
            // 
            this.btnViewTT.BackColor = System.Drawing.Color.AliceBlue;
            this.btnViewTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewTT.Location = new System.Drawing.Point(112, 466);
            this.btnViewTT.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewTT.Name = "btnViewTT";
            this.btnViewTT.Size = new System.Drawing.Size(624, 74);
            this.btnViewTT.TabIndex = 15;
            this.btnViewTT.Text = "View timetables";
            this.btnViewTT.UseVisualStyleBackColor = false;
            this.btnViewTT.Click += new System.EventHandler(this.btnViewTT_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(829, 834);
            this.Controls.Add(this.btnViewTT);
            this.Controls.Add(this.btnAddStudentSubjects);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnViewTables);
            this.Controls.Add(this.btnGenerateTimetable);
            this.Controls.Add(this.lblMainMenu);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMainMenu;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnGenerateTimetable;
        private System.Windows.Forms.Button btnViewTables;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddStudentSubjects;
        private System.Windows.Forms.Button btnViewTT;
    }
}