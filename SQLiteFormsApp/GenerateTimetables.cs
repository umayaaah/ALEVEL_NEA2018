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
    public static class GenerateTimetables
    {
        private static SQLiteDataAdapter DataAdapter;
        private static List<Student> ListOfStudents = new List<Student>();

        public const int MAX_DAYS_PER_WEEK = 5;
        public const int MAX_PERIODS_PER_DAY = 7;
        public const int MAX_PERIODS_PER_DAY_PER_BLOCK = 2;
        public const int MAX_PERIODS_PER_WEEK_PER_BLOCK = 7;

        public static void Execute()
        {
            MessageBox.Show("Generating timetables... Please wait");

            string msql = "DELETE FROM Booking";
            Database.ExecuteCommand(msql);
            msql = "DELETE FROM Class";
            Database.ExecuteCommand(msql);
            msql = "DELETE FROM Timetable";
            Database.ExecuteCommand(msql);
            msql = "DELETE FROM BlockAssignment";
            Database.ExecuteCommand(msql);

            SortStudentSubject();
            UpdateStudentSubjectTable();

            PopulateAssignmentTable();
            PopulateClassTable();
            PopulateBookings();

            List<int> Blocks = new List<int>();
            string sql = "SELECT ID FROM Block";
            Database.ExecuteCommand(sql);
            SQLiteDataReader dr = Database.ReadCommand(sql);
            while (dr.Read())
            {
                int BlockID = dr.GetInt32(0);
                Blocks.Add(BlockID);
            }

            int NumberOfLessonsBooked_Total = 0;
            int NumberOfLessonsBooked_PerDay = 0;
            int Day = 0;
            int Period = 0;
            bool BlockAlreadyBooked;

            foreach (int BlockID in Blocks)
                {
                    while (NumberOfLessonsBooked_Total < MAX_PERIODS_PER_WEEK_PER_BLOCK)
                    {
                        // Loop through Days until there are still Periods to book
                        while (Day < MAX_DAYS_PER_WEEK && NumberOfLessonsBooked_Total < MAX_PERIODS_PER_WEEK_PER_BLOCK)
                        {
                            // Loop through Periods until there are still Periods to book
                            while (Period < MAX_PERIODS_PER_DAY && NumberOfLessonsBooked_Total < MAX_PERIODS_PER_WEEK_PER_BLOCK
                           && NumberOfLessonsBooked_PerDay < MAX_PERIODS_PER_DAY_PER_BLOCK)
                            {
                                BlockAlreadyBooked = IsFilledByBlock(Day, Period);
                                // Cell free, book it
                                if (!BlockAlreadyBooked)
                                {
                                    TimetableTheBlock(Day, Period, BlockID);
                                    NumberOfLessonsBooked_Total++;
                                    NumberOfLessonsBooked_PerDay++;
                                }
                                // Next Period
                                Period++;
                            }
                            // Next Day
                            Period = 0;
                            NumberOfLessonsBooked_PerDay = 0;
                            Day++;
                        }
                        Day = 0;
                    }
                    NumberOfLessonsBooked_Total = 0;
                }
            
            // All the bookings are managed, show a final message
            MessageBox.Show("Timetables Created!");
        }

        public static bool TimetableTheBlock(int Day, int Period, int BlockID)
        {
            string sql = "INSERT INTO Timetable (Period, Day, BlockID) VALUES (" + Period + ", " + Day + ", " + BlockID + ")";
            Database.ExecuteCommand(sql);
            return true;
        }

        public static bool IsFilledByBlock(int Day, int Period)
        {
            string sql = "SELECT COUNT(*) FROM Timetable WHERE Day = " + Day + " AND Period = " + Period;
            Database.ExecuteCommand(sql);
            SQLiteDataReader dr = Database.ReadCommand(sql);

            int Exists = dr.Read() ? dr.GetInt32(0) : -1;

            return Exists >= 1 ? true : false;
        }

        public static List<int> GetListOfStudents()
        {
            List<int> StudentsIDs = new List<int>();
            string sql = "SELECT StudentID FROM Student";
            Database.ExecuteCommand(sql);
            SQLiteDataReader dr = Database.ReadCommand(sql);
            while (dr.Read())
            {
                int StudentID = dr.GetInt32(0);
                StudentsIDs.Add(StudentID);
            }
            return StudentsIDs;
        }

        public static void SortStudentSubject()
        {
            List<int> Students = GetListOfStudents();
            List<int> StudentSubject = new List<int>();
            Student student;
            foreach (int StudentID in Students)
            {
                student = new Student(StudentID);
                student.CreateListOfSubjects();
                student.Subjects.Sort();
                ListOfStudents.Add(student);
            }
        }

        public static int GetFirstIDForStudent(int StudentID)
        {
            string sql = "SELECT ID FROM StudentSubject WHERE StudentID = " + StudentID + " LIMIT 1";
            Database.ExecuteCommand(sql);
            SQLiteDataReader dr = Database.ReadCommand(sql);

            return dr.Read() ? dr.GetInt32(0) : -1;
        }

        public static void UpdateStudentSubjectTable()
        {
            foreach (Student student in ListOfStudents)
            {
                int counter = GetFirstIDForStudent(student.StudentID);
                foreach (int SubjectID in student.Subjects)
                {
                    string sql = "UPDATE StudentSubject SET SubjectID = " + SubjectID + " WHERE ID = " + counter;
                    Database.ExecuteCommand(sql);
                    counter++;
                }
            }
        }

        private static void PopulateAssignmentTable()
        {
            int StudentSubjectID = 1;
            foreach (Student student in ListOfStudents)
            {
                int BlockID = 1;
                foreach (int SubjectID in student.Subjects)
                {
                    string sql = "INSERT INTO BlockAssignment(StudentSubjectID, BlockID) VALUES (" + StudentSubjectID +
                                                                                                    ", " + BlockID + ")";
                    Database.ExecuteCommand(sql);
                    StudentSubjectID++;
                    BlockID++;
                }
            }
        }

        private static void PopulateClassTable()
        {
            // Fill the class table for Year 13 lessons.
            string sqlClass13 = @"
                    INSERT INTO Class(Name, Year, SubjectID, BlockID)

                    SELECT 
	                    13 || Block.Name || (UPPER(substr(Subject.Name,1,2))) as ClassNameYear13, 13 as Year,
                                                          Subject.SubjectID as SubjectID, Block.ID as BlockID
                    FROM 
	                    BlockAssignment INNER JOIN 
	                    Block ON Block.ID = BlockAssignment.BlockID INNER JOIN 
	                    StudentSubject ON StudentSubject.ID = BlockAssignment.StudentSubjectID INNER JOIN
	                    Student ON Student.StudentID = StudentSubject.StudentID INNER JOIN 
	                    Subject ON Subject.SubjectID = StudentSubject.SubjectID 
                    GROUP BY 
	                    Block.ID, 
	                    Subject.SubjectID";

            // Fill the class table for Year 12 lessons.
            string sqlClass12 = @"
                    INSERT INTO Class(Name, Year, SubjectID, BlockID)

                    SELECT 
	                    12 || Block.Name || (UPPER(substr(Subject.Name,1,2))) as ClassNameYear12, 12 as Year, Subject.SubjectID as SubjectID, Block.ID as BlockID
                    FROM 
	                    BlockAssignment INNER JOIN 
	                    Block ON Block.ID = BlockAssignment.BlockID INNER JOIN 
	                    StudentSubject ON StudentSubject.ID = BlockAssignment.StudentSubjectID INNER join
	                    Student ON Student.StudentID = StudentSubject.StudentID INNER JOIN 
	                    Subject ON Subject.SubjectID = StudentSubject.SubjectID 
                    GROUP BY 
	                    Block.ID, 
	                    Subject.SubjectID";

            Database.ExecuteCommand(sqlClass12);
            Database.ExecuteCommand(sqlClass13);
        }

        private static List<int> GetListOfTeacherIDsForSubject(int SubjectID)
        {
            List<int> TeacherIDs = new List<int>();
            string sql = "SELECT TeacherID FROM Teacher WHERE SubjectID = " + SubjectID;
            Database.ExecuteCommand(sql);

            SQLiteDataReader dr = Database.ReadCommand(sql);
            while (dr.Read())
            {
                int TeacherID = dr.GetInt32(0);
                TeacherIDs.Add(TeacherID);
            }
            return TeacherIDs;
        }

        public static bool InsertBooking(int ClassID, int TeacherID, int BlockID, int RoomID)
        {
            string sql = "INSERT INTO Booking (ClassID, TeacherID, BlockID, RoomID) VALUES ("
                            + ClassID + ", " + TeacherID + ", " + BlockID + ", " + RoomID + ")";
            Database.ExecuteCommand(sql);
            return true;
        }
        
        private static void PopulateBookings()
        {
            // Class
            DataTable Classes = new DataTable();
            DataAdapter = Database.DataAdapt("SELECT * FROM Class ORDER BY BlockID, SubjectID, Year");
            
            DataAdapter.Fill(Classes);

            // Room
            List<int> Rooms = new List<int>();
            string room_sql = "SELECT RoomID FROM Room";
            Database.ExecuteCommand(room_sql);
            SQLiteDataReader room_dr = Database.ReadCommand(room_sql);
            while (room_dr.Read())
            {
                int RoomID = room_dr.GetInt32(0);
                Rooms.Add(RoomID);
            }

            int ClassID;
            int BlockID;
            int SubjectID;

            int PreviousSubjectID = 0;
            int PreviousBlockID = 0;

            int numberOfTeachers = 0;
            int TeacherIDIndex = 0;

            int numberOfRooms = Rooms.Count;
            int roomIndex = 0;
            bool roomAvailable = true;

            bool FirstTime = true; // The first time making a booking

            for (int ClassRow = 0; ClassRow < Classes.Rows.Count; ClassRow++)
            {
                ClassID = Convert.ToInt32(Classes.Rows[ClassRow][0]);
                SubjectID = Convert.ToInt32(Classes.Rows[ClassRow][3]);
                BlockID = Convert.ToInt32(Classes.Rows[ClassRow][4]);

                List<int> ListOfTeacherIDs = GetListOfTeacherIDsForSubject(SubjectID);
                numberOfTeachers = ListOfTeacherIDs.Count;

                // When in a new block, all the rooms are made available again
                if (PreviousBlockID != BlockID && !FirstTime)
                {
                    roomAvailable = true;
                    roomIndex = 0;
                }

                // When the class has a different subject to before then restart the list of teachers
                // When the index is at the end of the list then restart the list of teachers
                if ((PreviousSubjectID != SubjectID || TeacherIDIndex == numberOfTeachers) && !FirstTime)
                {
                    TeacherIDIndex = 0;
                }
  
                if (PreviousBlockID == BlockID && roomIndex == numberOfRooms && !FirstTime)
                {
                    if (roomAvailable)
                    {
                        roomAvailable = false;
                    }                    
                }

                int RoomID_ToAssign;
                if (roomAvailable)
                {
                   RoomID_ToAssign = Rooms[roomIndex];
                }
                else
                {
                    RoomID_ToAssign = -1;
                }
                
                // All values are found, booking can be made 
                InsertBooking(ClassID, ListOfTeacherIDs[TeacherIDIndex], BlockID, RoomID_ToAssign);

                // Update variables
                TeacherIDIndex++;
                PreviousSubjectID = SubjectID;
                PreviousBlockID = BlockID;
                FirstTime = false;
                roomIndex++;
            }
        }
    }

}
