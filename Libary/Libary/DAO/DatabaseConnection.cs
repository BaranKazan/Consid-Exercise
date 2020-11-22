using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library.DAO
{
    public abstract class DatabaseConnection<T>
    {
        private readonly String connectionString = @"Data Source=localhost, 1433;Initial Catalog=Library;User ID=sa;Password=Pa$$w0rd2020";

        public SqlConnection GetConnection()
        {
            
            return new SqlConnection(this.connectionString);

        }

        public abstract T Get(int id);
        public abstract List<T> GetAll();
        public abstract bool Save(T t);
        public abstract bool Update(T t);
        public abstract bool Delete(int id);
    }
}
