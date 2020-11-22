using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Library.Domain;

namespace Library.DAO
{
    public class CategoryDAO : DatabaseConnection<Category>
    {

        private SqlConnection connection = null;

        public CategoryDAO()
        {
            this.connection = GetConnection();
        }

        public CategoryDAO(SqlConnection connection)
        {
            this.connection = connection;
        }

        public override bool Delete(int id)
        {
            SqlCommand command = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = null;
            bool dataDeleted = false;

            try
            {
                this.connection.Open();
                query = $"DELETE FROM Category WHERE Id={id}";
                command = new SqlCommand(query, this.connection);
                adapter.InsertCommand = new SqlCommand(query, this.connection);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                this.connection.Close();
                dataDeleted = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return dataDeleted;
        }

        public override Category Get(int id)
        {
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            Category category = null;

            try
            {
                this.connection.Open();

                String query = "SELECT * FROM Category WHERE Id = " + id;

                command = new SqlCommand(query, this.connection);
                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                    throw new Exception("The ID does not exist.");

                category = new Category((int)dataReader.GetValue(0), (String)dataReader.GetValue(1));

                dataReader.Close();
                command.Dispose();
                this.connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            
            return category;
        }

        public override List<Category> GetAll()
        {
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            List<Category> categories = new List<Category>();

            try
            {
                this.connection.Open();
                String query = "SELECT * FROM Category";
                command = new SqlCommand(query, this.connection);
                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                    throw new Exception("The ID does not exist.");

                while (dataReader.Read())
                {
                    categories.Add(new Category((int)dataReader.GetValue(0), (String)dataReader.GetValue(1)));
                }
                dataReader.Close();
                command.Dispose();
                this.connection.Close();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
            return categories;
        }

        public override bool Save(Category category)
        {
            SqlCommand command = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = null;
            bool dataStored = false;

            try
            {
                this.connection.Open();
                query = $"INSERT INTO Category(CategoryName) VALUES ('{category.CategoryName}')";
                command = new SqlCommand(query, this.connection);
                adapter.InsertCommand = new SqlCommand(query, this.connection);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                this.connection.Close();
                dataStored = true;
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
            return dataStored;
        }

        public override bool Update(Category category)
        {
            SqlCommand command = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = null;
            bool dataChanged = false;

            try
            {
                this.connection.Open();
                query = $"UPDATE Category SET CategoryName='{category.CategoryName}' WHERE Id = {category.Id}";
                Console.WriteLine(query);
                command = new SqlCommand(query, this.connection);
                adapter.InsertCommand = new SqlCommand(query, this.connection);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                this.connection.Close();
                dataChanged = true;

            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
            return dataChanged;
        }
    }
}
