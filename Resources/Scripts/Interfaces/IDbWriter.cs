using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    internal interface IDbWriter
    {
        void AddNewBook(Book book);

        void RemoveBook(Book book);
    }
}
