using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteFormsApp
{
    public partial class EditTablesForm : Form
    {
        public EditTablesForm()
        {
            InitializeComponent();
        }

        private void btnEditSubjects_Click(object sender, EventArgs e)
        {
            this.Hide();
            SubjectsForm frmSubject = new SubjectsForm();
            frmSubject.Show();
        }

        private void btnEditTeachers_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            TeachersForm frmTeacher = new TeachersForm();
            frmTeacher.Show();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentForm frmStudent = new StudentForm();
            frmStudent.Show();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomForm frmRoom = new RoomForm();
            frmRoom.Show();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenuForm frmMainMenu = new MainMenuForm();
            frmMainMenu.Show();
        }
    }
}
