using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SchoolLearn.Resources.Scripts
{
    internal class PSQLDatabaseReader : IDbReader
    {
        private PSQLConnection connection;

        public PSQLDatabaseReader(PSQLConnection connection)
        {
            this.connection = connection;
        }

        public List<Book> ReadAllBooks()
        {
            string cmdText = "SELECT * FROM book";

            NpgsqlCommand command = new NpgsqlCommand(cmdText, connection.GetNpgsqlConnection());

            NpgsqlDataReader reader = command.ExecuteReader();

            List<Book> books = new List<Book>();
            while (reader.Read())
            {
                ReadingInterval readingInterval;

                if (reader["beginreading"] != DBNull.Value)
                {
                    readingInterval = new ReadingInterval(
                    Convert.ToDateTime(reader["beginreading"]),
                    Convert.ToDateTime(reader["endreading"]));
                }
                else readingInterval = new ReadingInterval();

                books.Add(new Book
                    (
                    reader["title"].ToString(),
                    Convert.ToDouble(reader["price"]),
                    Convert.ToInt32(reader["listcount"]),
                    readingInterval,
                    Convert.ToInt32(reader["idbook"])
                    ));
            }

            return books;
        }

        public GivenBook[] ReadGivenBooks()
        {
            throw new NotImplementedException();
        }

        public ReceivedBook[] ReadReceivedBooks()
        {
            throw new NotImplementedException();
        }
    }
}
