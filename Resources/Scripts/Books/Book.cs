using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolLearn.Resources.Scripts
{
    internal class Book : ISaveable
    {
        public string Title { get; private set; }

        public double Price { get; private set; }

        public int PagesCount { get; private set; }

        public ReadingInterval ReadingInterval { get; set; }

        private Book()
        {
            ReadingInterval = new ReadingInterval();
        }

        public Book(string title, double price, int pagesCount) : this()
        {
            this.Title = title;
            this.Price = price;
            this.PagesCount = pagesCount;
        }

        public Book(string title, double price, int pagesCount, DateTime beginReading)
            : this(title,price,pagesCount)
        {
            this.ReadingInterval.ReadBeginning = beginReading;
        }

        public Book(string title, double price, int pagesCount, ReadingInterval readingInterval)
            : this(title,price,pagesCount)
        {
            this.ReadingInterval = readingInterval;
        }

        virtual public string GetInfoForSave()
        {
            return $"'{Title}', {Price.ToString().Replace(',','.')}, {PagesCount}," +
                $" {ReadingInterval.ReadBeginning.CheckAtNullForDB()}, {ReadingInterval.ReadEnd.CheckAtNullForDB()}";
        }
    }
}
