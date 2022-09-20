using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    internal class GivenBook : Book
    {
        public DateTime DateOfReturn { get; private set; }

        public GivenBook(string title, double price, int pagesCount, DateTime dateOfReturn, ReadingInterval readingInterval = null) 
            : base(title, price, pagesCount, readingInterval)
        {
            this.DateOfReturn = dateOfReturn;
        }

        public override string GetInfoForAdd()
        {
            return $"{base.GetInfoForAdd()}, '{DateOfReturn}'";
        }
    }
}
