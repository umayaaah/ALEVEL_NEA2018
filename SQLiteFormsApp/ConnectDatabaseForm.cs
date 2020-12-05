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
using System.IO;

namespace SQLiteFormsApp
{
    public partial class ConnectDatabaseForm : Form
    {
        private const string FILE_EXTENSION = ".sqlite";
        private string fileName;
        private bool existingdb;

        public ConnectDatabaseForm()
        {
            InitializeComponent();
            txtFileName.Text = "TestDatabase";
        }

        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            fileName = txtFileName.Text;
            existingdb = true;
            
            if (fileName == "")
            {
                MessageBox.Show("Enter file name");
            }
            else if (!File.Exists(fileName + FILE_EXTENSION)) // If the file does not exist
            {
                MessageBox.Show("Database does not exist");
            }
            else // Connect to the specified file
            {
                try
                {
                    Database existDatabase = new Database(fileName, existingdb);
                    existDatabase.InitialiseConnection();
                    GoToMainMenu();
                }
                catch
                {
                    MessageBox.Show("Error loading file");
                }
            }
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            fileName = txtFileName.Text;
            existingdb = false;

            if (fileName == "")
            {
                MessageBox.Show("Enter file name");
            }
            else
            {
                Database newDatabase = new Database(fileName, existingdb);
                newDatabase.InitialiseConnection();
                try
                {
                    newDatabase.CreateDBTables();
                }
                catch
                {
                    MessageBox.Show("Database already exists");
                }
                GoToMainMenu();
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

        private void GoToMainMenu()
        {
            this.Hide();
            MainMenuForm frmMainMenu = new MainMenuForm();
            frmMainMenu.Show();
        }
    }
}
