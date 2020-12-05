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
    public partial class SubjectsForm : Form
    {
        private string ID;
        private new string Name;

        public SubjectsForm()
        {
            InitializeComponent();
            Database.GridFill("Subject", dataGridView1);
        }

        // Inserts user inputs to subject table
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Name = txtSubject.Text.Trim();
            bool isNameValid = Validation.ValidateString(Name);

            if (Name == "")
            {
                MessageBox.Show("Fill all fields");
            }
            else if (!isNameValid)
            {
                MessageBox.Show("Error: Only enter characters for names");
            }
            else if (Name.Length > 20)
            {
                MessageBox.Show("Error: Maximum length for subject name is 20");
            }
            else
            {
                string sql = "INSERT INTO Subject (Name) VALUES ('" + Name + "')";
                Database.ExecuteCommand(sql);


                ClearAllTexts();
                Database.GridFill("Subject", dataGridView1);
            }
        }

        // Updates records given ID and name with user inputs
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ID = txtID.Text.Trim();
            Name = txtSubject.Text.Trim();
            bool isIDValid = Validation.ValidateInteger(ID);

            if (ID == "" || Name == "")
            {
                MessageBox.Show("Fill all fields");
            }
            else if (Name.Length > 20)
            {
                MessageBox.Show("Error: Maximum length for subject name is 20");
            }
            else if (!isIDValid)
            {
                MessageBox.Show("Error: Enter a number for ID");
            }
            else
            {
                try // Attempt to update a record given the current ID and new subject name
                {
                    string sql = "UPDATE Subject SET Name = '" + Name + "' WHERE SubjectID = '" + ID + "'";
                    Database.ExecuteCommand(sql);

                    ClearAllTexts();
                    Database.GridFill("Subject", dataGridView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Deletes records given ID by user input
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ID = txtID.Text.Trim();
            bool isIDValid = Validation.ValidateInteger(ID);

            if (ID == "")
            {
                MessageBox.Show("Fill all fields");
            }
            else if (!isIDValid)
            {
                MessageBox.Show("Error: Enter a number for ID");
            }
            else
            {
                try // Attempt to delete record given the ID
                {
                    string sql = "DELETE FROM Subject WHERE SubjectID = " + ID;
                    Database.ExecuteCommand(sql);
                    ClearAllTexts();
                    Database.GridFill("Subject", dataGridView1);
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
        }

        // Clears the fields on text boxes
        private void ClearAllTexts()
        {
            txtSubject.Text = "";
            txtID.Text = "";
        }

        // Updates text boxes with a record that is clicked on the datatable 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow rowUpdate in dataGridView1.SelectedRows)
            {
                txtID.Text = rowUpdate.Cells[0].Value.ToString();
                txtSubject.Text = rowUpdate.Cells[1].Value.ToString();
            }
        }

        // Goes back to edit database menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditTablesForm frmEdit = new EditTablesForm();
            frmEdit.Show();
        }
    }
}
