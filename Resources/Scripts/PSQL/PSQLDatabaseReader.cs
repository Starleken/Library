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
        private DbBookFactory bookFactory = new DbBookFactory();

        public PSQLDatabaseReader(PSQLConnection connection)
        {
            this.connection = connection;
        }

        public List<Book> ReadAllBooks()
        {
            string cmdText = $"SELECT * FROM {TableNames.BOOK_TABLE}";

            using (NpgsqlDataReader reader = MakeQuery(cmdText))
            {
                List<Book> books = new List<Book>();
                while (reader.Read())
                {
                    books.Add(new DbBookFactory().Get(BookType.book, reader));
                }

                return books;
            }
        }

        public List<GivenBook> ReadGivenBooks()
        {
            string cmdText = $"SELECT * FROM {TableNames.BOOK_TABLE}, {TableNames.GIVEN_BOOK_TABLE}" +
                $" WHERE {TableNames.GIVEN_BOOK_TABLE}.idbook = {TableNames.BOOK_TABLE}.idbook";

            using (NpgsqlDataReader reader = MakeQuery(cmdText))
            {
                List<GivenBook> books = new List<GivenBook>();
                while (reader.Read())
                {
                    Book book = bookFactory.Get(BookType.givenBook, reader);
                    books.Add((GivenBook)book);
                }

                return books;
            }
        }

        public List<ReceivedBook> ReadReceivedBooks()
        {
            string cmdText = $"SELECT * FROM {TableNames.BOOK_TABLE}, {TableNames.RECEIVED_BOOK_TABLE}" +
                $" WHERE {TableNames.RECEIVED_BOOK_TABLE}.idbook = {TableNames.BOOK_TABLE}.idbook";

            using (NpgsqlDataReader reader = MakeQuery(cmdText))
            {
                List<ReceivedBook> books = new List<ReceivedBook>();
                while (reader.Read())
                {
                    Book book = bookFactory.Get(BookType.receivedBook, reader);
                    books.Add((ReceivedBook)book);
                }

                return books;
            }
        }

        private NpgsqlDataReader MakeQuery(string cmdText)
        {
            NpgsqlCommand command = new NpgsqlCommand(cmdText, connection.GetNpgsqlConnection());

            NpgsqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}
