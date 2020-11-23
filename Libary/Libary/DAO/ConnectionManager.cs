using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library.DAO
{
    public class ConnectionManager
    {
        private SqlConnection connection = null;
        private SqlCommand command = null;
        private static ConnectionManager instance = null;

        private ConnectionManager() {
            connection = new SqlConnection(@"Data Source=localhost, 1433;Initial Catalog=Library;User ID=sa;Password=Pa$$w0rd2020");
        }

        public static ConnectionManager getInstance()
        {
            if (instance == null)
                instance = new ConnectionManager();

            return instance;
        }

        public void WriteData(String query)
        {
            this.connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            this.command = new SqlCommand(query, this.connection);
            adapter.InsertCommand = new SqlCommand(query, this.connection);
            adapter.InsertCommand.ExecuteNonQuery();
            this.CloseConnection();
         }

        public SqlDataReader ReadData(String query)
        {
            this.connection.Open();
            this.command = new SqlCommand(query, this.connection);
            return this.command.ExecuteReader();
        }

        public void CloseConnection()
        {
            this.command.Dispose();
            this.connection.Close();
        }

    }
}
