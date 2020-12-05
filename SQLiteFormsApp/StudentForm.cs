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
    public partial class StudentForm : Form
    {
        private string ID;
        private string FName;
        private string LName;
        private string Year;

        public StudentForm()
        {
            InitializeComponent();
            Database.GridFill("Student", dataGridView1);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FName = txtFName.Text.Trim();
            LName = txtLName.Text.Trim();
            Year = txtYear.Text.Trim();

            bool IsYearValid = Validation.ValidateInteger(Year);
            bool AreNamesValid = Validation.ValidateString(FName) && Validation.ValidateString(LName);

            if (FName == "" || LName == "" || Year == "")
            {
                MessageBox.Show("Enter all fields");
            }
            else if (!IsYearValid && (Year != "12" || Year != "13"))
            {
                MessageBox.Show("Error: Enter either 12 or 13 for year");
            }
            else if (FName.Length > 20 || LName.Length > 20)
            {
                MessageBox.Show("Error: Maximum length for forename and surname is 20");
            }
            else if (!AreNamesValid)
            {
                MessageBox.Show("Error: Only enter letters for names");
            }
            else
            {
                string sql = "INSERT INTO Student (Forename, Surname, Year) VALUES ('" + FName + "', '" + LName + "' , " + Year + ")";
                Database.ExecuteCommand(sql);

                ClearAllTexts();
                Database.GridFill("Student", dataGridView1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ID = txtID.Text.Trim();
            FName = txtFName.Text.Trim();
            LName = txtLName.Text.Trim();
            Year = txtYear.Text.Trim();

            bool IsIDValid = Validation.ValidateInteger(ID);
            bool IsYearValid = Validation.ValidateInteger(Year);
            bool AreNamesValid = Validation.ValidateString(FName) && Validation.ValidateString(LName);

            if (FName == "" || LName == "" || Year == "")
            {
                MessageBox.Show("Enter all fields");
            }
            else if (!IsIDValid)
            {
                MessageBox.Show("Error: Enter a number for ID");
            }
            else if (!IsYearValid && Year != "12" && Year != "13")
            {
                MessageBox.Show("Error: Enter either 12 or 13 for year");
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
                try // Attempt to update a record given the current ID and new subject name
                {
                    string sql = "UPDATE Student SET Forename = '" + FName + "', Surname = '"
                                + LName + "', Year = " + Year + " WHERE StudentID = '" + ID + "'";
                    Database.ExecuteCommand(sql);

                    ClearAllTexts();
                    Database.GridFill("Student", dataGridView1);
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

            if(!IsIDValid)
            {
                MessageBox.Show("Error: Enter a number for ID");
            }
            else
            {
                string sql = "DELETE FROM Student WHERE StudentID = " + ID;
                Database.ExecuteCommand(sql);
                sql = "DELETE FROM StudentSubject WHERE StudentID = " + ID;
                Database.ExecuteCommand(sql);
            }
            ClearAllTexts();
            Database.GridFill("Student", dataGridView1);
    

        }

        // Updates text boxes with a record that is clicked on the datatable 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow rowUpdate in dataGridView1.SelectedRows)
            {
                try
                {
                    txtID.Text = rowUpdate.Cells[0].Value.ToString();
                    txtFName.Text = rowUpdate.Cells[1].Value.ToString();
                    txtLName.Text = rowUpdate.Cells[2].Value.ToString();
                }
                catch
                {
                    ClearAllTexts();
                }

            }
        }

        private void ClearAllTexts()
        {
            txtID.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditTablesForm frmEdit = new EditTablesForm();
            frmEdit.Show();
        }
    }
}
