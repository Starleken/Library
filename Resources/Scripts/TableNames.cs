using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    static internal class TableNames
    {
        static public string BOOK_TABLE { get; private set; } = "book";

        static public string GIVEN_BOOK_TABLE { get; private set; } = "givenbook";

        static public string RECEIVED_BOOK_TABLE { get; private set; } = "receivedbook";
    }
}
