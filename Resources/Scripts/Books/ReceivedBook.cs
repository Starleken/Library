using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    internal class ReceivedBook : Book
    {
        public DateTime ReceiveDate { get; set; }

        public ReceivedBook(string title, double price, int pagesCount, DateTime receiveDate, ReadingInterval readingInterval = null, int? id = null) 
            : base(title, price, pagesCount, readingInterval, id)
        {
            this.ReceiveDate = receiveDate;
        }

        public override string GetInfoForAdd()
        {
            return $"{base.GetInfoForAdd()}, '{ReceiveDate}'";
        }

        public override string GetTableName()
        {
            return TableNames.RECEIVED_BOOK_TABLE;
        }
    }
}
