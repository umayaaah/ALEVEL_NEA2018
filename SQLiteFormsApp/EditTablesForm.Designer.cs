namespace SQLiteFormsApp
{
    partial class EditTablesForm
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
            this.btnEditTeachers = new System.Windows.Forms.Button();
            this.btnEditSubjects = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditTeachers
            // 
            this.btnEditTeachers.BackColor = System.Drawing.Color.AliceBlue;
            this.btnEditTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTeachers.Location = new System.Drawing.Point(75, 290);
            this.btnEditTeachers.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditTeachers.Name = "btnEditTeachers";
            this.btnEditTeachers.Size = new System.Drawing.Size(524, 53);
            this.btnEditTeachers.TabIndex = 11;
            this.btnEditTeachers.Text = "Teachers";
            this.btnEditTeachers.UseVisualStyleBackColor = false;
            this.btnEditTeachers.Click += new System.EventHandler(this.btnEditTeachers_Click_1);
            // 
            // btnEditSubjects
            // 
            this.btnEditSubjects.BackColor = System.Drawing.Color.AliceBlue;
            this.btnEditSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSubjects.Location = new System.Drawing.Point(75, 206);
            this.btnEditSubjects.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditSubjects.Name = "btnEditSubjects";
            this.btnEditSubjects.Size = new System.Drawing.Size(524, 53);
            this.btnEditSubjects.TabIndex = 10;
            this.btnEditSubjects.Text = "Subjects";
            this.btnEditSubjects.UseVisualStyleBackColor = false;
            this.btnEditSubjects.Click += new System.EventHandler(this.btnEditSubjects_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(75, 579);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(524, 74);
            this.btnMainMenu.TabIndex = 71;
            this.btnMainMenu.Text = "Back to Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(65, 61);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 55);
            this.lblTitle.TabIndex = 72;
            this.lblTitle.Text = "Basic data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(510, 29);
            this.label1.TabIndex = 73;
            this.label1.Text = "Start by entering the basic data for your school:";
            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.Color.AliceBlue;
            this.btnStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudents.Location = new System.Drawing.Point(75, 371);
            this.btnStudents.Margin = new System.Windows.Forms.Padding(4);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(524, 53);
            this.btnStudents.TabIndex = 74;
            this.btnStudents.Text = "Students";
            this.btnStudents.UseVisualStyleBackColor = false;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRooms.Location = new System.Drawing.Point(75, 458);
            this.btnRooms.Margin = new System.Windows.Forms.Padding(4);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(524, 53);
            this.btnRooms.TabIndex = 75;
            this.btnRooms.Text = "Rooms";
            this.btnRooms.UseVisualStyleBackColor = false;
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            // 
            // EditTablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(671, 710);
            this.Controls.Add(this.btnRooms);
            this.Controls.Add(this.btnStudents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnEditTeachers);
            this.Controls.Add(this.btnEditSubjects);
            this.Name = "EditTablesForm";
            this.Text = "EditDbForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEditTeachers;
        private System.Windows.Forms.Button btnEditSubjects;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnRooms;
    }
}