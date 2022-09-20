using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolLearn.Resources.Scripts
{
    internal class Book : IAddeable, IDeleteable
    {
        public int? Id { get; private set; } //при создании книги из приложения у неё не может быть id

        public string Title { get; private set; }

        public double Price { get; private set; }

        public int PagesCount { get; private set; }

        public ReadingInterval ReadingInterval { get; set; }

        private const string TABLE_NAME = "book";

        private Book()
        {
            ReadingInterval = new ReadingInterval();
        }

        public Book(string title)
        {
            this.Title = title;
        }

        public Book(string title, double price, int pagesCount, int? id = null) : this()
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
            this.PagesCount = pagesCount;
        }

        public Book(string title, double price, int pagesCount, DateTime beginReading, int? id = null)
            : this(title,price,pagesCount, id)
        {
            this.ReadingInterval.ReadBeginning = beginReading;
        }

        public Book(string title, double price, int pagesCount, ReadingInterval readingInterval, int? id = null)
            : this(title,price,pagesCount, id)
        {
            this.ReadingInterval = readingInterval;
        }

        virtual public string GetInfoForAdd()
        {
            return $"'{Title}', {Price.ToString().Replace(',','.')}, {PagesCount}," +
                $" {ReadingInterval.ReadBeginning.CheckAtNullForDB()}, {ReadingInterval.ReadEnd.CheckAtNullForDB()}";
        }

        public int? GetId()
        {
            return Id;
        }

        public string GetTableName()
        {
            return TABLE_NAME;
        }
    }
}
