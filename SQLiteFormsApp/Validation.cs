using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SQLiteFormsApp
{
    static class Validation
    {
        public static bool ValidateInteger(string Number)
        {
            int myInt;
            bool isNumeric = int.TryParse(Number, out myInt);
            if (isNumeric)
            {
                return true;
            }
            return false;
        }

        public static bool ValidateString(string AnyString)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            Match match = regex.Match(AnyString);
            if (match.Success)
            {
                return true;
            }
            return false;
        }
    }
}
