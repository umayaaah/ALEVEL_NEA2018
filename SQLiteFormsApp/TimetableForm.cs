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
using System.Collections;

namespace SQLiteFormsApp
{
    public partial class TimetableForm : Form
    {

        public TimetableForm()
        {
            InitializeComponent();
        }

        private void btnTeacherTT_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherTimetableForm frmTeacherTT = new TeacherTimetableForm();
            frmTeacherTT.Show();
        }

        private void btnStudentTT_Click(object sender, EventArgs e)
        {

            this.Hide();
            StudentTimetableForm frmStudentTT = new StudentTimetableForm();
            frmStudentTT.Show();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenuForm frmMainMenu = new MainMenuForm();
            frmMainMenu.Show();
        }
    }

}
