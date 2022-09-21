using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace SchoolLearn.Resources.Scripts
{
    internal class PSQLConnection : IConnection
    {
        public string ConnectionPath { get; set; }

        private NpgsqlConnection connection;

        public PSQLConnection(string connectionPath)
        {
            ConnectionPath = connectionPath;
        }

        public void TryOpenConnection()
        {
            connection = new NpgsqlConnection(ConnectionPath);

            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                throw new ConnectionException("Не удалось установить соединение");
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public NpgsqlConnection GetNpgsqlConnection() => connection;

        public bool IsOpen()
        {
            return connection.State == ConnectionState.Open ? true : false;
        }
    }
}
