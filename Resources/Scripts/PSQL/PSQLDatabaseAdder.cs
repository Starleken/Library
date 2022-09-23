using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SchoolLearn.Resources.Scripts
{
    internal class PSQLDatabaseAdder : IDbAdder
    {
        private PSQLConnection connection;

        public PSQLDatabaseAdder(PSQLConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Возвращает id добавленного экземпляра
        /// </summary>
        public void TryAdd(IAddeable addeableObject)
        {
            if (connection.IsOpen() == false)
            {
                throw new ConnectionException("Соединение не установлено");
            }

            string cmdText = $"INSERT INTO {addeableObject.GetTableName()} VALUES (DEFAULT, {addeableObject.GetInfoForAdd()}) RETURNING idbook";

            try
            {
                NpgsqlCommand command = new NpgsqlCommand(cmdText, connection.GetNpgsqlConnection());
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new AddException("Ошибка добавления обьекта");
            }
        }

    }
}
