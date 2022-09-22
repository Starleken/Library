using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    static internal class Extensions
    {
        static public string CheckAtNullForDB(this DateTime? dateTime)
        {
            if (dateTime == null)
                return "NULL";
            else return $"'{dateTime}'";
        }

        static public string CheckAtNullForDB(this DateTime dateTime)
        {
            if (dateTime == null)
                return "NULL";
            else return $"'{dateTime}'";
        }
    }
}
