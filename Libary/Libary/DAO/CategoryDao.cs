using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Library.Domain;

namespace Library.DAO
{

    /*
     * This class follows the DAO desgin pattern which handles the communications between the Category table in the database.
     */
    public class CategoryDao : DaoInterface<Category>
    {

        private ConnectionManager connectionManager = null;

        public CategoryDao()
        {
            this.connectionManager = ConnectionManager.getInstance();
        }

        public CategoryDao(ConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public bool Delete(int id)
        {
            bool dataDeleted = false;
            try
            {
                connectionManager.WriteData($"DELETE FROM Category WHERE Id={id}");
                dataDeleted = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return dataDeleted;
        }

        public Category Get(int id)
        {
            Category category = null;
            try
            {
                SqlDataReader dataReader = connectionManager.ReadData("SELECT * FROM Category WHERE Id = " + id);

                if (!dataReader.Read())
                    throw new Exception("The ID does not exist.");

                category = new Category(dataReader.GetInt32(0), dataReader.GetString(1));
                dataReader.Close();
                connectionManager.CloseConnection();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return category;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = null;
            try
            {
                SqlDataReader dataReader = connectionManager.ReadData("SELECT * FROM Category");
                categories = new List<Category>();
                if (!dataReader.Read())
                    throw new Exception("The table is empty.");

                do
                {
                    categories.Add(new Category(dataReader.GetInt32(0), dataReader.GetString(1)));
                }
                while (dataReader.Read());

                dataReader.Close();
                connectionManager.CloseConnection();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return categories;
        }

        public bool Save(Category category)
        {
            bool dataStored = false;
            try
            {
                connectionManager.WriteData($"INSERT INTO Category(CategoryName) VALUES ('{category.CategoryName}')");
                dataStored = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return dataStored;
        }

        public bool Update(Category category)
        {
            bool dataChanged = false;
            try
            {
                connectionManager.WriteData($"UPDATE Category SET CategoryName='{category.CategoryName}' WHERE Id = {category.Id}");
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
