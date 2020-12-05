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
    public partial class TeachersForm : Form
    {
        private string ID;
        private string FName;
        private string LName;
        private int SubjectID;

        public TeachersForm()
        {
            InitializeComponent();
        }

        private void Teachers_Load(object sender, EventArgs e)
        {
            Subject.ComboBoxFill(cbSubject);
            Database.GridFill("Teacher", dataGridView1);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FName = txtFName.Text.Trim();
            LName = txtLName.Text.Trim();
            SubjectID = Subject.ParseSubjectID(cbSubject.Text);

            bool AreNamesValid = Validation.ValidateString(FName) && Validation.ValidateString(LName);

            if (FName == "" || LName == "" || SubjectID < 0)
            {
                MessageBox.Show("Enter all fields");
            }
            else if (FName.Length > 20 || LName.Length > 20)
            {
                MessageBox.Show("Error: Maximum length for forename and surname is 20");
            }
            else if (!AreNamesValid)
            {
                MessageBox.Show("Error: Only enter characters for names");
            }
            else
            {
                try
                {
                    string sql = "INSERT INTO Teacher (Forename, Surname, SubjectID) " +
                    "VALUES ('" + FName + "' , '" + LName + "' , '" + SubjectID + "')";
                    Database.ExecuteCommand(sql);

                    ClearAllTexts();
                    Database.GridFill("Teacher", dataGridView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ID = txtID.Text.Trim();
            FName = txtFName.Text.Trim();
            LName = txtLName.Text.Trim();
            SubjectID = Subject.ParseSubjectID(cbSubject.Text);

            bool IsIDValid = Validation.ValidateInteger(ID);
            bool AreNamesValid = Validation.ValidateString(FName) && Validation.ValidateString(LName);

            if (FName == "" || LName == "" || SubjectID < 0)
            {
                MessageBox.Show("Enter all fields");
            }
            else if (!IsIDValid)
            {
                MessageBox.Show("Error: Enter a number for ID");
            }
            else if (FName.Length > 20 || LName.Length > 20)
            {
                MessageBox.Show("Error: Maximum length for forename and surname is 20");
            }
            else if (!AreNamesValid)
            {
                MessageBox.Show("Error: Only enter characters for names");
            }
            else
            {
                try // Update teacher table given all values
                {
                    string sql = "UPDATE Teacher SET Forename = '" + FName + "', Surname = '" + LName +
                                 "' , SubjectID = '" + SubjectID + "' WHERE TeacherID = " + ID;
                    Database.ExecuteCommand(sql);

                    ClearAllTexts();
                    Database.GridFill("Teacher", dataGridView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ID = txtID.Text.Trim();

            bool IsIDValid = Validation.ValidateInteger(ID);

            if (!IsIDValid)
            {
                MessageBox.Show("Error: Enter a number for ID");
            }
            else
            {
                string sql = "DELETE FROM Teacher WHERE TeacherID = " + ID;
                Database.ExecuteCommand(sql);
            }

            ClearAllTexts();
            Database.GridFill("Teacher", dataGridView1);
        }

        // Updates text boxes with a record that is clicked on the datatable 
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow rowUpdate in dataGridView1.SelectedRows)
            {
                txtID.Text = rowUpdate.Cells[0].Value.ToString();
                txtFName.Text = rowUpdate.Cells[1].Value.ToString();
                txtLName.Text = rowUpdate.Cells[2].Value.ToString();
            }
        }

        // Clears all text boxes
        private void ClearAllTexts()
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtID.Text = "";
            cbSubject.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditTablesForm frmEdit = new EditTablesForm();
            frmEdit.Show();
        }
    }
}
