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

        

    public partial class CreateDatabase : Form
    {
        const string userpath = "H:\\NEA Project Folder\\";
        const string dbName = "AppointmentDatabase";

        static SQLiteConnection m_dbConnection;

        // Creates an empty database file
        static void createNewDatabase()
        {
            SQLiteConnection.CreateFile(userpath + dbName+".sqlite");
        }

        // Creates a connection with our database file.
        static void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + userpath + dbName+".sqlite;Version=3;");
            m_dbConnection.Open();
        }

        // Creates a table named 'highscores' with two columns: name (a string of max 20 characters) and score (an int)
        static void createTable()
        {
            string sql = "create table Doctor (name varchar(20), score int, form varchar(5))";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        // Inserts some values in the highscores table.
        // As you can see, there is quite some duplicate code here, we'll solve this in part two.
        static void fillTable()
        {
        }
    
        public CreateDatabase()
        {
            InitializeComponent();
            createNewDatabase();
            connectToDatabase();
        }

        private void bDoIT_Click(object sender, EventArgs e)
        {
//            connectToDatabase();
  //          createNewDatabase();
    //        createTable();
            fillTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

    }
}
