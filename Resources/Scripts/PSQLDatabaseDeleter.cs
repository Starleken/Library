using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SchoolLearn.Resources.Scripts
{
    internal class PSQLDatabaseDeleter : IDbDeleter
    {
        PSQLConnection connection;

        public PSQLDatabaseDeleter(PSQLConnection connection)
        {
            this.connection = connection;
        }

        public void DeleteObject(string table, IDeleteable removeableObject)
        {
            string cmdText = $"DELETE FROM {table} WHERE id={removeableObject.GetId()}";

            if (connection.IsOpen() == false)
            {
                throw new ConnectionException();
            }

            try
            {
                NpgsqlCommand command = new NpgsqlCommand(cmdText, connection.GetNpgsqlConnection());
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DeleteException();
            }
        }
    }
}
