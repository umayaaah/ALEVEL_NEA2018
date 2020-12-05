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
    public partial class TeacherTimetableForm : Form
    {
        public TeacherTimetableForm()
        {
            InitializeComponent();
            TeacherCBFill();
            TimeTable_dataGridView.RowCount = GenerateTimetables.MAX_PERIODS_PER_DAY;
        }

        public void TeacherCBFill()
        {
            try
            {
                string sql = "SELECT * FROM Teacher";
                Database.ExecuteCommand(sql);
                SQLiteDataReader dr = Database.ReadCommand(sql);

                while (dr.Read())
                {
                    int TeacherID = dr.GetInt32(0);
                    string FirstName = dr.GetString(1);
                    string LastName = dr.GetString(2);
                    string Output = Convert.ToString(TeacherID) + ": " + FirstName + " " + LastName;
                    cbTeacher.Items.Add(Output);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void GridFill()
        {
            int TeacherID = Teacher.ParseTeacherID(cbTeacher.Text);

            //Sql to get periods and days teacher teaches and what class/room
            DataTable Timetable_ForTeacher = new DataTable("Timetable");
            string GetTeacherInfo = @"SELECT Day, Period, Class.Name, IFNULL(Room.Name, 'No Room')
                                    FROM Timetable
                                    INNER JOIN Booking ON Timetable.BlockID = Booking.BlockID
                                    LEFT JOIN Room ON Booking.RoomID = Room.RoomID
                                    INNER JOIN Class ON Booking.ClassID = Class.ClassID
                                    WHERE Booking.TeacherID = " + TeacherID + " ORDER BY Day";

            SQLiteDataAdapter da = Database.DataAdapt(GetTeacherInfo);
            int Day;
            int Period;
            string ClassName;
            string RoomName;

            da.Fill(Timetable_ForTeacher);

            // Loops for the number of records in the datatable created above
            for (int i = 0; i < Timetable_ForTeacher.Rows.Count; i++)
            {
                Day = Convert.ToInt32(Timetable_ForTeacher.Rows[i][0]);
                Period = Convert.ToInt32(Timetable_ForTeacher.Rows[i][1]);
                ClassName = Timetable_ForTeacher.Rows[i][2].ToString();
                RoomName = Timetable_ForTeacher.Rows[i][3].ToString();
                TimeTable_dataGridView.Rows[Period].Cells[Day].Value = FormatCell(ClassName, RoomName);
            }
        }

        private string FormatCell(string Class, string Room)
        {
            return ("Class: " + Class + "\nRoom: " + Room);
        }

        private void btnOutputTimetable_Click(object sender, EventArgs e)
        {
            GridFill();
        }
    
        private void cbTeacher_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            TimeTable_dataGridView.Rows.Clear();
            TimeTable_dataGridView.RowCount = GenerateTimetables.MAX_PERIODS_PER_DAY;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimetableForm frmTT = new TimetableForm();
            frmTT.Show();
        }
    }
}
