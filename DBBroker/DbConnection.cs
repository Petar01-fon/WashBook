using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBBroker
{
    internal class DbConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public DbConnection()
        {
            connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=WashBook;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public void OpenConnection()
        {
            connection?.Open();
        }
        public void CloseConnection()
        {
            connection?.Close();
        }

        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            transaction?.Commit();
        }
        public void RollBack()
        {
            transaction.Rollback();
        }

        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", connection, transaction);
        }

    }
}
