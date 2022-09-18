using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolLearn.Resources.Scripts
{
    internal class PSQLConnection : IConnection
    {
        public string ConnectionPath { get; set; }

        private SqlConnection connection;

        public PSQLConnection(string connectionPath)
        {
            ConnectionPath = connectionPath;
        }

        public void TryOpenConnection()
        {
            connection = new SqlConnection(ConnectionPath);

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }
}
