using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteFormsApp
{
    static class Subject
    {
        // Retrieves subjectID from the combo box
        // If the user tries to submit an empty combobox, the catch is carried out
        public static int ParseSubjectID(string cbSubject)
        {
            int SubjectID;
            try
            {
                int IndexOfColon = cbSubject.IndexOf(":");
                string Subject = cbSubject.Substring(0, IndexOfColon);

                SubjectID = Convert.ToInt32(Subject);
            }
            catch
            {
                SubjectID = -1;
            }

            return SubjectID;
        }

        // Adds ID and Name of every subject in subject table into a combobox
        public static void ComboBoxFill(ComboBox cbSubject)
        {
            try
            {
                string sql = "SELECT * FROM Subject";
                Database.ExecuteCommand(sql);
                SQLiteDataReader dr = Database.ReadCommand(sql);

                while (dr.Read())
                {
                    int SubjectID = dr.GetInt32(0);
                    string SubjectName = dr.GetString(1);
                    string Output = Convert.ToString(SubjectID) + ": " + SubjectName;
                    cbSubject.Items.Add(Output);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
