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
        private PSQLConnection connection;

        public PSQLDatabaseDeleter(PSQLConnection connection)
        {
            this.connection = connection;
        }

        public void DeleteObject(string table, IDeleteable removeableObject)
        {
            if (connection.IsOpen() == false)
            {
                throw new ConnectionException("Соединение не установлено");
            }

            int? id = removeableObject.GetId();

            try
            {
                CheckIdAtNull(id);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }

            string cmdText = $"DELETE FROM {table} WHERE id={id}";

            try
            {
                NpgsqlCommand command = new NpgsqlCommand(cmdText, connection.GetNpgsqlConnection());
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DeleteException("Ошибка удаления обьекта") ;
            }
        }

        private void CheckIdAtNull(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("id не может быть NULL");
            }
        }
    }
}
