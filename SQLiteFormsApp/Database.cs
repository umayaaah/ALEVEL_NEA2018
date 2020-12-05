using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace SQLiteFormsApp
{
    public class Database
    {
        private static SQLiteConnection dbConnection;
        private bool existingdb;
        private string filePath;
        private const string FILE_EXTENSION = ".sqlite; Version=3;";

        // Constructor for database object
        public Database(string filePath, bool existingdb)
        {
            this.filePath = filePath;
            this.existingdb = existingdb;
            dbConnection = new SQLiteConnection("Data Source= " + filePath + FILE_EXTENSION);
        }

        // Create new database with the required tables
        public void CreateDatabase()
        {
            SQLiteConnection.CreateFile(filePath + ".sqlite");
        }

        // Initialise both databases
        public void InitialiseConnection()
        {
            if (!existingdb) // If the database does not exist, create a new database
            {
                dbConnection.Open();
            }
            else // Connect to the specified database
            {
                dbConnection.OpenAndReturn();
            }
        }

        public void CreateDBTables()
        {
            CreateSubjectTable();
            CreateTeacherTable();
            CreateClassTable();
            CreateRoomTable();
            CreateStudentTable();
            CreateStudentSubjectTable();
            CreateBlockTable();
            fillBlockTable();
            CreateBlockAssignmentTable();
            CreateBookingTable();
            CreateTimetable();
        }
       
        public static void CloseConnection()
        {
            dbConnection.Close();
        }

        // Function for database commands: execute and read command
        public static void ExecuteCommand(string sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        
        public static SQLiteDataReader ReadCommand(string sql)
        {
            SQLiteCommand readCommand = new SQLiteCommand(sql, dbConnection);
            return readCommand.ExecuteReader();
        }

        // Method to output database on a datatable
        public static SQLiteDataAdapter DataAdapt(string sql)
        {
            SQLiteDataAdapter DataAdp = new SQLiteDataAdapter(sql, dbConnection);
            return DataAdp;
        }

        // Fill the datatables with a given table
        public static void GridFill(string Table, DataGridView DataGrid)
        {
            DataTable dt = new DataTable("" + Table + "");
            SQLiteDataAdapter da = DataAdapt("SELECT * FROM " + Table);

            da.Fill(dt);
            da.Update(dt);
            DataGrid.DataSource = dt;
        }

        public void CreateSubjectTable()
        {
            string sql = "CREATE table Subject (SubjectID INTEGER PRIMARY KEY ASC, Name VARCHAR(20))";
            ExecuteCommand(sql);
        }

        public void CreateTeacherTable()
        {
            string sql ="CREATE table Teacher( " +
                        "TeacherID INTEGER PRIMARY KEY ASC," +
                        "Forename VARCHAR (20)," +
                        "Surname VARCHAR (20)," +
                        "SubjectID INTEGER," +
                        "FOREIGN KEY(SubjectID) REFERENCES Subject(SubjectID))";
            ExecuteCommand(sql);
        }

        public void CreateStudentTable()
        {
            string sql = "CREATE table Student (" +
                         "StudentID INTEGER PRIMARY KEY ASC, " +
                         "Forename VARCHAR (20), " +
                         "Surname VARCHAR (20), " +
                         "Year INTEGER (2))";
            ExecuteCommand(sql);
        }

        public void CreateStudentSubjectTable()
        {
            string sql = "CREATE table StudentSubject (" +
                         "ID INTEGER PRIMARY KEY ASC, " +
                         "StudentID INTEGER, " +
                         "SubjectID INTEGER, " +
                         "FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectID), " +
                         "FOREIGN KEY (StudentID) REFERENCES Student(StudentID))";
            ExecuteCommand(sql);
        }

        public void CreateBlockTable()
        {
            string sql = "CREATE table Block (ID INTEGER PRIMARY KEY ASC, Name VARCHAR(1))";
            ExecuteCommand(sql);
        }

        public void fillBlockTable()
        {
            string sql = "INSERT INTO Block (Name) VALUES ('A')";
            ExecuteCommand(sql);
            sql = "INSERT INTO Block (Name) VALUES ('B')";
            ExecuteCommand(sql);
            sql = "INSERT INTO Block (Name) VALUES ('C')";
            ExecuteCommand(sql);
            sql = "INSERT INTO Block (Name) VALUES ('D')";
            ExecuteCommand(sql);
        }

        public void CreateBlockAssignmentTable()
        {
            string sql = "CREATE table BlockAssignment (ID INTEGER PRIMARY KEY ASC, " +
                         "StudentSubjectID INTEGER, BlockID INTEGER, " +
                         "FOREIGN KEY(StudentSubjectID) REFERENCES StudentSubject(ID), " +
                         "FOREIGN KEY(BlockID) REFERENCES Block(BlockID))";
            ExecuteCommand(sql);
        }

        public void CreateClassTable()
        {
            string sql = "CREATE table Class (" +
                         "ClassID INTEGER PRIMARY KEY ASC," +
                         "Name VARCHAR (6)," +
                         "Year INTEGER (2)," +
                         "SubjectID INTEGER," +
                         "BlockID INTEGER," +
                         "FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectID)," +
                         "FOREIGN KEY (BlockID) REFERENCES Block(ID))";
            ExecuteCommand(sql);
        }

        public void CreateRoomTable()
        {
            string sql = "CREATE table Room (RoomID INTEGER PRIMARY KEY ASC, Name VARCHAR (6))";
            ExecuteCommand(sql);
        }

        public void CreateBookingTable()
        {
            string sql = "CREATE table Booking (" +
                         "BookingID INTEGER PRIMARY KEY ASC, " +
                         "ClassID INTEGER," +
                         "TeacherID INTEGER," +
                         "BlockID INTEGER, " +
                         "RoomID INTEGER," +
                         "FOREIGN KEY (ClassID) REFERENCES Class(ClassID)," +
                         "FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID)," +
                         "FOREIGN KEY (RoomID) REFERENCES Room(RoomID)," +
                         "FOREIGN KEY (BlockID) REFERENCES Block(ID))";
            ExecuteCommand(sql);
        }

        public void CreateTimetable()
        {
            string sql = "CREATE table Timetable (ID INTEGER PRIMARY KEY ASC, " +
                         "Period INT, Day INT, BlockID INTEGER, FOREIGN KEY (BlockID) REFERENCES Block(ID))";
            ExecuteCommand(sql);
        }

    }
}
