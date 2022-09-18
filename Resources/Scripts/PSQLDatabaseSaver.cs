using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolLearn.Resources.Scripts
{
    internal class PSQLDatabaseSaver
    {
        IConnection connection;

        public PSQLDatabaseSaver(IConnection connection)
        {
            this.connection = connection;
        }

        public void Save(string table)
        {
            string cmdText = $"INSERT INTO {table} VALUES ()";

            SqlCommand command = new SqlCommand(cmdText, connection.GetSqlConnection());
        }

    }
}
