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

namespace SQLiteFormsApp
{
    public partial class StudentSubjectForm : Form
    {
        public StudentSubjectForm()
        {
            InitializeComponent();
        }

        private void StudentSubjectForm_Load(object sender, EventArgs e)
        {
            PopulateCheckList();
            Student.ComboBoxFill(cbStudent);
        }

        private void PopulateCheckList()
        {
            string sql = "SELECT * FROM Subject";
            Database.ExecuteCommand(sql);
            SQLiteDataReader dr = Database.ReadCommand(sql);
            while (dr.Read())
            {
                int SubjectID = dr.GetInt32(0);
                string Name = dr.GetString(1);
                chkSubjects.Items.Add(Name);
            }
        }

        // When the user changes the student on the combo box
        private void cbStudent_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Uncheck all items in checkbox
            foreach (int i in chkSubjects.CheckedIndices)
            {
                chkSubjects.SetItemCheckState(i, CheckState.Unchecked);
            }

            // Parse the StudentID from the combo box
            int StudentID = Student.ParseStudentID(cbStudent.Text);

            // Get all subjects for a particular student from table StudentSubject
            string sql = @"SELECT Subject.Name
                           FROM StudentSubject
                           INNER JOIN Subject ON StudentSubject.SubjectID = Subject.SubjectID
                           WHERE StudentID = " + StudentID;
            Database.ExecuteCommand(sql);
            
            // Store the subjects returned from query in a list
            List<string> ListOfSubjectNames = new List<string>();
            SQLiteDataReader dr = Database.ReadCommand(sql);
            while (dr.Read())
            {
                string SubjectName = dr.GetString(0);
                ListOfSubjectNames.Add(SubjectName);
            }

            // For all the items in the checkbox, if the subject in the checkbox is the same
            // as one of the students subject choices, then check that element in the checkbox
            for (int i = 0; i < chkSubjects.Items.Count; i++) 
            {
                if (ListOfSubjectNames.Contains(chkSubjects.Items[i].ToString()))
                {
                    chkSubjects.SetItemChecked(i, true);
                }
            }
        }

        private bool StudentRecordExists(int StudentID)
        {
            int Count = 0;
            string sql = "SELECT COUNT(SubjectID) from StudentSubject WHERE StudentID = " + StudentID;
            Database.ExecuteCommand(sql);
            SQLiteDataReader dr = Database.ReadCommand(sql);
            while (dr.Read())
            {
                Count = dr.GetInt32(0);
            }

            if(Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void InsertStudentSubjectTable(List <string> SubjectNames)
        {
            int StudentID = Student.ParseStudentID(cbStudent.Text);
            int SubjectID = 0;

            // For each subject in the list, get the subjectID from the subject table
            // Insert the subjectID and studentID to the StudentSubject table
            foreach(string SubjectName in SubjectNames)
            {
                string sql = "SELECT SubjectID FROM Subject WHERE Name = '" + SubjectName + "'";
                Database.ExecuteCommand(sql);
                SQLiteDataReader dr = Database.ReadCommand(sql);
                while (dr.Read())
                {
                    SubjectID = dr.GetInt32(0);
                }
                sql = "INSERT INTO StudentSubject (StudentID, SubjectID) VALUES ('" +
                                                    StudentID + "' ," + SubjectID + ")";
                Database.ExecuteCommand(sql);
            }
        }

        private void UpdateStudentSubjectTable(List<string> SubjectNames)
        {
            int StudentID = Student.ParseStudentID(cbStudent.Text);
            int SubjectID = 0;

            Student studentToUpdate = new Student(StudentID);
            studentToUpdate.CreateListOfSubjects();
            List<int> oldIDs = studentToUpdate.Subjects;
            oldIDs.Sort();

            List<int> newIDs = new List<int>();
            foreach (string SubjectName in SubjectNames)
            {
                string sql = "SELECT SubjectID FROM Subject WHERE Name = '" + SubjectName + "'";
                Database.ExecuteCommand(sql);
                SQLiteDataReader dr = Database.ReadCommand(sql);
                while (dr.Read())
                {
                    SubjectID = dr.GetInt32(0);
                    newIDs.Add(SubjectID);
                }
            }
            newIDs.Sort();

            int OldID;
            int NewID;
            for(int i = 0; i < oldIDs.Count(); i++)
            {
                OldID = oldIDs[i];
                NewID = newIDs[i];
                // If the SubjectID in the same index of both lists is different, update the record
                if(OldID != NewID)
                {
                    string sql = @"UPDATE StudentSubject
                                SET SubjectID = " + NewID +
                                " WHERE StudentID = " + StudentID + " AND " +
                                "SubjectID = " + OldID;
                    Database.ExecuteCommand(sql);
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int StudentID = Student.ParseStudentID(cbStudent.Text);
            int NoCheckedSubjects = chkSubjects.CheckedItems.Count;
            bool IsStudentRecorded = StudentRecordExists(StudentID);

            List<string> CheckedSubjects = new List<string>();
            foreach (string Subject in chkSubjects.CheckedItems)
            {
                CheckedSubjects.Add(Subject);
            }

            if (NoCheckedSubjects != 4)
            {
                MessageBox.Show("Error: Check 4 subjects for student");
            }
            else
            {
                if(IsStudentRecorded)
                {
                    UpdateStudentSubjectTable(CheckedSubjects);
                    MessageBox.Show("Student choice updated");
                }
                else
                {
                    InsertStudentSubjectTable(CheckedSubjects);
                    MessageBox.Show("Student choice added");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenuForm frmMainMenu = new MainMenuForm();
            frmMainMenu.Show();
        }

    }
}
