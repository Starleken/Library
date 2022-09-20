using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SchoolLearn.Resources.Scripts
{
    internal class PSQLDatabaseSaver : IDbAdder
    {
        private PSQLConnection connection;

        public PSQLDatabaseSaver(PSQLConnection connection)
        {
            this.connection = connection;
        }

        public int TryAdd(string table, IAddeable saveableObject)
        {
            if (connection.IsOpen() == false)
            {
                throw new ConnectionException("Соединение не установлено");
            }

            string cmdText = $"INSERT INTO {table} VALUES (DEFAULT, {saveableObject.GetInfoForAdd()}) RETURNING idbook";

            try
            {
                NpgsqlCommand command = new NpgsqlCommand(cmdText, connection.GetNpgsqlConnection());
                object id = command.ExecuteScalar();

                return (int)id;
            }
            catch (Exception ex)
            {
                throw new SaveException("Ошибка сохранения обьекта");
            }
        }

    }
}
