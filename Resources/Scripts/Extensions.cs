using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    static internal class Extensions
    {
        static public string CheckAtNullForDB(this DateTime dateTime)
        {
            if (dateTime == new DateTime(0001,01,01))
                return "NULL";
            else return $"'{dateTime}'";
        }
    }
}
