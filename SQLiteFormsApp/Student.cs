using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SQLiteFormsApp
{
    class Student
    {
        public int StudentID { get; private set; }
        public List<int> Subjects { get; private set; }

        public Student(int StudentID)
        {
            this.StudentID = StudentID;
            this.Subjects = new List<int>();
        }

        public void CreateListOfSubjects()
        {
            string sql = "SELECT SubjectID FROM StudentSubject WHERE StudentID = " + StudentID;
            Database.ExecuteCommand(sql);
            SQLiteDataReader dr = Database.ReadCommand(sql);
            while (dr.Read())
            {
                int SubjectID = dr.GetInt32(0);
                Subjects.Add(SubjectID);
            }
        }

        public static int ParseStudentID(string cbStudent)
        {
            int StudentID;
            
            try
            {
                int IndexOfColon = cbStudent.IndexOf(":");
                string ID = cbStudent.Substring(0, IndexOfColon);

                StudentID = Convert.ToInt32(ID);
            }
            catch
            {
                StudentID = -1;
            }

            return StudentID;
        }

        public static void ComboBoxFill(ComboBox cbStudent)
        {
            try
            {
                string sql = "SELECT * FROM Student";
                Database.ExecuteCommand(sql);
                SQLiteDataReader dr = Database.ReadCommand(sql);

                while (dr.Read())
                {
                    int StudentID = dr.GetInt32(0);
                    string Forename = dr.GetString(1);
                    string Lastname = dr.GetString(2);
                    string Output = Convert.ToString(StudentID) + ": " + Forename + " " + Lastname;
                    cbStudent.Items.Add(Output);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
