using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    internal class ReceivedBook : Book
    {
        public DateTime ReceivedDate { get; set; }

        private int idbook;

        public ReceivedBook(string title, double price, int pagesCount, DateTime receiveDate, int idbook, int? id = null, ReadingInterval readingInterval = null) 
            : base(title, price, pagesCount, readingInterval, id)
        {
            this.ReceivedDate = receiveDate;
            this.idbook = idbook;
        }

        public override string GetInfoForAdd()
        {
            return $"{idbook}, {ReceivedDate.CheckAtNullForDB()}";
        }

        public override string GetTableName()
        {
            return TableNames.RECEIVED_BOOK_TABLE;
        }

        public override string GetQueueForDelete()
        {
            return $"DELETE FROM {TableNames.BOOK_TABLE} WHERE idbook = {idbook}";
        }
    }
}
