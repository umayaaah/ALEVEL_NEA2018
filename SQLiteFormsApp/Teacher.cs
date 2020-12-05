using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFormsApp
{
    class Teacher
    {
        public static int ParseTeacherID(string cbTeacher)
        {
            int TeacherID;
            try
            {
                int IndexOfColon = cbTeacher.IndexOf(":");
                string Subject = cbTeacher.Substring(0, IndexOfColon);

                TeacherID = Convert.ToInt32(Subject);
            }
            catch
            {
                TeacherID = -1;
            }

            return TeacherID;
        }
    }
}
