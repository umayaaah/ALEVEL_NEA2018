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
    public partial class StudentTimetableForm : Form
    {
        public StudentTimetableForm()
        {
            InitializeComponent();
            Student.ComboBoxFill(cbStudent);
            TimeTable_dataGridView.RowCount = GenerateTimetables.MAX_PERIODS_PER_DAY;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimetableForm frmTT = new TimetableForm();
            frmTT.Show();
        }

        private void GridFill()
        {
            int StudentID = Student.ParseStudentID(cbStudent.Text);
            //Sql for periods and days
            DataTable Timetable_ForStudent = new DataTable("Timetable");
            string GetStudentInfo = @"SELECT Day, Period, Class.Name as Class, 
                                          SUBSTR(Teacher.Forename, 0, 2) || SUBSTR(Teacher.Surname, 0, 2) as Teacher,
                                          IFNULL(Room.Name, 'No Room') as Room
                                    FROM
                                        Student INNER JOIN
                                        StudentSubject ON StudentSubject.StudentID = Student.StudentID
                                        INNER JOIN Subject ON Subject.SubjectID = StudentSubject.SubjectID
                                        INNER JOIN BlockAssignment ON BlockAssignment.StudentSubjectID = StudentSubject.ID
                                        INNER JOIN Class ON Class.SubjectID = Subject.SubjectID
                                        INNER JOIN Booking ON Booking.ClassID = Class.ClassID
                                        INNER JOIN Timetable ON Timetable.BlockID = Booking.BlockID
                                        INNER JOIN Teacher ON Teacher.TeacherID = Booking.TeacherID
                                        LEFT JOIN Room ON Room.RoomID = Booking.RoomID 
                                    WHERE
                                         Student.StudentID = " + StudentID + @" AND
                                         Class.Year = Student.Year AND
                                         Class.BlockID = BlockAssignment.BlockID
                                    ORDER BY Class.Name";

            SQLiteDataAdapter da = Database.DataAdapt(GetStudentInfo);
            int Day;
            int Period;
            string ClassName;
            string TeacherInitials;
            string RoomName;

            da.Fill(Timetable_ForStudent);

            for (int i = 0; i < Timetable_ForStudent.Rows.Count; i++)
            {
                Day = Convert.ToInt32(Timetable_ForStudent.Rows[i][0]);
                Period = Convert.ToInt32(Timetable_ForStudent.Rows[i][1]);
                ClassName = Timetable_ForStudent.Rows[i][2].ToString();
                TeacherInitials = Timetable_ForStudent.Rows[i][3].ToString();
                RoomName = Timetable_ForStudent.Rows[i][4].ToString();
                TimeTable_dataGridView.Rows[Period].Cells[Day].Value = FormatCell(ClassName, TeacherInitials, RoomName);
            }
        }

        private string FormatCell(string Class, string TeacherInitials, string Room)
        {
            return ("Class: " + Class + "\nTeacher: " + TeacherInitials + "\nRoom: " + Room);
        }

        private void btnOutputTimetable_Click(object sender, EventArgs e)
        {
            GridFill();
        }
    }
}
