﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SchoolLearn.Resources.Scripts
{
    internal class PSQLDatabaseSaver : IDbSaver
    {
        PSQLConnection connection;

        public PSQLDatabaseSaver(PSQLConnection connection)
        {
            this.connection = connection;
        }

       

        public void TrySave(string table, ISaveable saveableObject)
        {
            string cmdText = $"INSERT INTO {table} VALUES (DEFAULT, {saveableObject.GetInfoForSave()})";

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
                throw new SaveException();
            }
        }

    }
}
