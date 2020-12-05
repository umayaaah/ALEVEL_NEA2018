using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;

namespace SQLiteFormsApp
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        // Shows the edit tables form
        private void GoToTableMenu()
        {
            this.Hide();
            EditTablesForm frmEdit = new EditTablesForm();
            frmEdit.Show();
        }

        private void btnViewTables_Click(object sender, EventArgs e)
        {
            GoToTableMenu();
        }

        // Shows the student subject form
        private void btnAddStudentSubjects_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSubjectForm frmStudentSubject = new StudentSubjectForm();
            frmStudentSubject.Show();
        }

        private void btnViewTT_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimetableForm frmTT = new TimetableForm();
            frmTT.Show();
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            int TeacherCount = TableCount("Teacher");
            int RoomCount = TableCount("Room");
            if (RoomCount <= 0)
            {
                MessageBox.Show("Error: No rooms assigned");
                GoToTableMenu();
            }
            else if (TeacherCount <= 0)
            {
                MessageBox.Show("Error: No teachers assigned");
                GoToTableMenu();
            }
            else
            {
                bool EnoughRooms = IsNumberOfRoomsEnough();
                if (IsNumberOfTeacherEnough() && EnoughRooms)
                {
                    // The algorithm to generate timetables is called
                    GenerateTimetables.Execute();

                    this.Hide();
                    TimetableForm frmTimetable = new TimetableForm();
                    frmTimetable.Show();
                }

                if (!EnoughRooms)
                {
                    this.Hide();
                    RoomForm frmRoom = new RoomForm();
                    frmRoom.Show();
                }
            }
        }

        // Counts the number of records in a table
        private int TableCount(string tableName)
        {
            string sql_CountRecords = "SELECT COUNT(*) FROM " + tableName;
            Database.ExecuteCommand(sql_CountRecords);
            SQLiteDataReader dr = Database.ReadCommand(sql_CountRecords);

            int Count =  dr.Read() ? dr.GetInt32(0) : -1;
            return Count;
        }

        private bool IsNumberOfTeacherEnough()
        {
            string sql_NumberOfTeachersPerSubject =
                @"SELECT  SubjectName 
                FROM (

                        SELECT COUNT(Teacher.TeacherID) as NumberOfTeachers, Subject.Name as SubjectName
                        FROM Teacher INNER JOIN Subject ON Subject.SubjectID = Teacher.SubjectID
                        GROUP BY Teacher.SubjectID
     
                        )
                WHERE
                        NumberOfTeachers < 2";
            // Execute query
            Database.ExecuteCommand(sql_NumberOfTeachersPerSubject);

            // Parse result into a list
            List<string> ProblemSubjects = new List<string>();
            SQLiteDataReader dr = Database.ReadCommand(sql_NumberOfTeachersPerSubject);
            while (dr.Read())
            {
                string SubjectName = dr.GetString(0);
                ProblemSubjects.Add(SubjectName);
            }
            
            if (ProblemSubjects.Count > 0)
            {
                // Format a string with all the subject names
                string FormattedListOfSubjects = FormatList(ProblemSubjects);
                MessageBox.Show("Error: Not enough teachers for the following subjects:\n" + FormattedListOfSubjects);
                return false; // Not enough teachers for the 'problem' subjects
            }
            else
            {
                return true; // Number of teachers per subject is enough
            }
        }

        // Format the problem subjects into a list string
        private string FormatList(List<string>ListToFormat)
        {
            string FormattedList = "";
            foreach(string Item in ListToFormat)
            {
                FormattedList = "\n" + Item + FormattedList;
            }
            return FormattedList;
        }

        private bool IsNumberOfRoomsEnough()
        {
            string sql_numberOfRooms = "SELECT COUNT(*) FROM Room";
            Database.ExecuteCommand(sql_numberOfRooms);
            SQLiteDataReader noOfRooms_dr = Database.ReadCommand(sql_numberOfRooms);

            int NumberOfRooms = 0;
            while (noOfRooms_dr.Read())
            {
                // Parse result into integer variable
                NumberOfRooms = noOfRooms_dr.GetInt32(0);
            }

            string sql_numberOfClassesPerBlock = "SELECT COUNT(BlockID) FROM Class GROUP BY BlockID";
            // Parse numbers returned into a list
            List<int> ClassesPerBlock = new List<int>();
            SQLiteDataReader classesPerBlock_dr = Database.ReadCommand(sql_numberOfClassesPerBlock);
            while (classesPerBlock_dr.Read())
            {
                // Parse result into integer variable
                int NumberPerBlock = classesPerBlock_dr.GetInt32(0);
                ClassesPerBlock.Add(NumberPerBlock);
            }

            // Compare block with the greatest number of classes with the number of rooms
            if (ClassesPerBlock.Max() > NumberOfRooms)
            {
                int RoomsRequired = ClassesPerBlock.Max() - NumberOfRooms;
                DialogResult dialog = MessageBox.Show(RoomsRequired +
                       " more rooms required. Ignore? ", "Error", MessageBoxButtons.YesNo);
                if(dialog == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public static void Exit()
        {
            try
            {
                Database.CloseConnection();
                System.Windows.Forms.Application.Exit();
            }
            catch
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                Database.CloseConnection();
                System.Windows.Forms.Application.Exit();
            }
            catch
            {
                System.Windows.Forms.Application.Exit();
            }
        }

    }
}
