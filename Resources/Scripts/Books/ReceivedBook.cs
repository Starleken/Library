using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    internal class ReceivedBook : Book
    {
        public DateTime DateOfReceived { get; set; }


        public ReceivedBook(string title, double price, int pagesCount, DateTime dateOfReceived, ReadingInterval readingInterval = null) 
            : base(title, price, pagesCount, readingInterval)
        {
            this.DateOfReceived = dateOfReceived;
        }

        public override string GetInfoForAdd()
        {
            return $"{base.GetInfoForAdd()}, ''";
        }
    }
}
