using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    internal class GivenBook : Book
    {
        public DateTime GivenDate { get; private set; }

        public GivenBook(string title, double price, int pagesCount, DateTime dateOfReturn, ReadingInterval readingInterval = null, int? id = null) 
            : base(title, price, pagesCount, readingInterval, id)
        {
            this.GivenDate = dateOfReturn;
        }

        public override string GetInfoForAdd()
        {
            return $"{base.GetInfoForAdd()}, '{GivenDate}'";
        }
    }
}
