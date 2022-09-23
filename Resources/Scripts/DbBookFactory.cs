using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace SchoolLearn.Resources.Scripts
{
    internal class DbBookFactory
    {
        public Book Get(BookType bookType, DbDataReader reader)
        {
            Book book;

            switch (bookType)
            {
                case BookType.book:
                    book = CreateBook(reader);
                    break;
                case BookType.givenBook:
                    book = CreateGivenBook(reader);
                    break;
                case BookType.receivedBook:
                    book = CreateReceivedBook(reader);
                    break;
                default:
                    throw new Exception();
            }

            return book;
        }

        private Book CreateBook(DbDataReader reader)
        {
            ReadingInterval readingInterval = CreateReadingInterval(reader);

            return new Book
                (
                reader["title"].ToString(),
                Convert.ToDouble(reader["price"]),
                Convert.ToInt32(reader["listcount"]),
                readingInterval,
                Convert.ToInt32(reader["idbook"])
                );
        }

        private GivenBook CreateGivenBook(DbDataReader reader)
        {
            ReadingInterval readingInterval = CreateReadingInterval(reader);

            return new GivenBook
                (
                reader["title"].ToString(),
                Convert.ToDouble(reader["price"]),
                Convert.ToInt32(reader["listcount"]),
                Convert.ToDateTime(reader["givedate"]),
                Convert.ToInt32(reader["idbook"]),
                Convert.ToInt32(reader["idgivenbook"]),
                readingInterval
                );
        }

        private ReceivedBook CreateReceivedBook(DbDataReader reader)
        {
            ReadingInterval readingInterval = CreateReadingInterval(reader);

            return new ReceivedBook
                (
                reader["title"].ToString(),
                Convert.ToDouble(reader["price"]),
                Convert.ToInt32(reader["listcount"]),
                Convert.ToDateTime(reader["receivedate"]),
                Convert.ToInt32(reader["idbook"]),
                Convert.ToInt32(reader["idreceivedbook"]),
                readingInterval
                );
        }

        private ReadingInterval CreateReadingInterval(DbDataReader reader)
        {
            ReadingInterval readingInterval;

            if (reader["beginreading"] != DBNull.Value)
            {
                readingInterval = new ReadingInterval(
                Convert.ToDateTime(reader["beginreading"]),
                Convert.ToDateTime(reader["endreading"]));
            }
            else readingInterval = new ReadingInterval();

            return readingInterval;
        }
    }
}
