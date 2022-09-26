using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    internal class BookFactory
    {
        public Book Get(BookType bookType, string title, double price, int listcount,
            DateTime? beginreading, DateTime? endReading, DateTime? date = null)
        {
            Book book;

            switch (bookType)
            {
                case BookType.book:
                    book = CreateBook(title, price, listcount, beginreading, endReading);
                    break;
                case BookType.givenBook:
                    book = CreateBook(title, price, listcount, beginreading, endReading);
                    //book = CreateGivenBook();
                    break;
                case BookType.receivedBook:
                    book = CreateBook(title, price, listcount, beginreading, endReading);
                    //book = CreateReceivedBook();
                    break;
                default:
                    throw new Exception();
            }

            return book;
        }

        private Book CreateBook(string title, double price, int listcount, DateTime? beginreading,
            DateTime? endReading)
        {
            Book book = new Book(title, price, listcount, CreateReadingInterval(beginreading,endReading));

            return book;
        }

        private ReadingInterval CreateReadingInterval(DateTime? beginreading, DateTime? endreading)
        {
            ReadingInterval readingInterval;

            readingInterval = new ReadingInterval(beginreading, endreading);

            return readingInterval;
        }
    }
}
