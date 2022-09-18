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

        public void TrySave(string table, ISaveable saveableObject)
        {
            string cmdText = $"INSERT INTO {table} VALUES ({saveableObject.GetInfoForSave()})";

            SqlCommand command = new SqlCommand(cmdText, connection.GetSqlConnection());

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
