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
            string cmdText = $"SELECT * FROM {TableNames.BOOK_TABLE}";

            NpgsqlDataReader reader = MakeQuery(cmdText);

            List<Book> books = new List<Book>();
            while (reader.Read())
            {
                ReadingInterval readingInterval = CreateReadingInterval(reader);

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

        private NpgsqlDataReader MakeQuery(string cmdText)
        {
            NpgsqlCommand command = new NpgsqlCommand(cmdText, connection.GetNpgsqlConnection());

            NpgsqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        private ReadingInterval CreateReadingInterval(NpgsqlDataReader reader)
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
