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

        private int idbook; 

        public GivenBook(string title, double price, int pagesCount, DateTime dateOfReturn, int idbook, ReadingInterval readingInterval = null, int? id = null) 
            : base(title, price, pagesCount, readingInterval, id)
        {
            this.GivenDate = dateOfReturn;
            this.idbook = idbook;
        }

        public override string GetInfoForAdd()
        {
            return $"{idbook}, {GivenDate.CheckAtNullForDB()}";
        }

        public override string GetTableName()
        {
            return TableNames.GIVEN_BOOK_TABLE;
        }

        public override string GetQueueForDelete()
        {
            return $"DELETE FROM {TableNames.GIVEN_BOOK_TABLE} WHERE idgivenbook = {Id}";
        }
    }
}
