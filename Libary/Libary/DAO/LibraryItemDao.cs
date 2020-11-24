using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Library.DAO;
using Library.Domain;

namespace Libary.DAO
{
    public class LibraryItemDao : DaoInterface<LibraryItem>
    {

        private ConnectionManager connectionManager = null;

        public LibraryItemDao()
        {
            this.connectionManager = ConnectionManager.getInstance();
        }

        public LibraryItemDao(ConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public bool Delete(int id)
        {
            bool dataDeleted = false;
            try
            {
                connectionManager.WriteData($"DELETE FROM LibraryItem WHERE Id={id}");
                dataDeleted = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return dataDeleted;
        }

        public LibraryItem Get(int id)
        {
            LibraryItem libraryItem = null;
            try
            {
                SqlDataReader dataReader = connectionManager.ReadData("SELECT * FROM LibraryItem WHERE Id = " + id);

                if (!dataReader.Read())
                    throw new Exception("The ID does not exist.");

                libraryItem = new LibraryItem(dataReader.GetInt32(0), dataReader.GetInt32(1),
                        dataReader.GetString(2), dataReader.GetString(3),
                        !Convert.IsDBNull(dataReader.GetValue(4)) ? (int?)dataReader.GetValue(4) : null,
                        !Convert.IsDBNull(dataReader.GetValue(5)) ? (int?)dataReader.GetValue(5) : null,
                        (bool)dataReader.GetValue(6), (String)dataReader.GetValue(7),
                        !dataReader.IsDBNull(8) ? (DateTime?)dataReader.GetDateTime(8) : null,
                        dataReader.GetString(9));
                dataReader.Close();
                connectionManager.CloseConnection();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return libraryItem;
        }

        public List<LibraryItem> GetAll()
        {
            List<LibraryItem> libarieItems = null;
            try
            {
                SqlDataReader dataReader = connectionManager.ReadData("SELECT * FROM LibraryItem");
                libarieItems = new List<LibraryItem>();
                if (!dataReader.Read())
                    throw new Exception("The table is empty.");
                do
                {
                    libarieItems.Add(new LibraryItem(dataReader.GetInt32(0), dataReader.GetInt32(1),
                        dataReader.GetString(2), dataReader.GetString(3),
                        !Convert.IsDBNull(dataReader.GetValue(4)) ? (int?)dataReader.GetValue(4) : null,
                        !Convert.IsDBNull(dataReader.GetValue(5)) ? (int?)dataReader.GetValue(5) : null,
                        (bool)dataReader.GetValue(6), (String)dataReader.GetValue(7),
                        !dataReader.IsDBNull(8) ? (DateTime?)dataReader.GetDateTime(8) : null,
                        dataReader.GetString(9)));

                }
                while (dataReader.Read());
                dataReader.Close();
                connectionManager.CloseConnection();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return libarieItems;
        }

        public bool Save(LibraryItem libraryItem)
        {
            bool dataStored = false;
            try
            {
                connectionManager.WriteData($"INSERT INTO LibraryItem(CategoryID, Title, Author, Pages, RunTimeMinutes, " +
                    $"IsBorrowable, Borrower, BorrowDate, Type) " +
                    $"VALUES ({libraryItem.CategoryId}, '{libraryItem.Title}', '{libraryItem.Author}', " +
                    $"{(libraryItem.Pages != null ? libraryItem.Pages.ToString() : "null")}, " +
                    $"{(libraryItem.RunTimeMinutes != null ? libraryItem.RunTimeMinutes.ToString() : "null")}, " +
                    $"{(libraryItem.IsBorrowable ? 1 : 0)}, '{libraryItem.Borrower}', " +
                    $"{(libraryItem.BorrowDate != null ? "'"+Convert.ToDateTime(libraryItem.BorrowDate).ToString("yyyy-MM-dd")+"'" : "null")}, " +
                    $"'{libraryItem.Type}')");
                dataStored = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return dataStored;
        }

        public bool Update(LibraryItem libraryItem)
        {
            bool dataChanged = false;
            try
            {
                connectionManager.WriteData($"UPDATE LibraryItem SET " +
                    $"CategoryID={libraryItem.CategoryId}, Title='{libraryItem.Title}', Author='{libraryItem.Author}', " +
                    $"Pages={(libraryItem.Pages != null ? libraryItem.Pages.ToString() : "null")}, " +
                    $"RunTimeMinutes={(libraryItem.RunTimeMinutes != null ? libraryItem.RunTimeMinutes.ToString() : "null")}, " +
                    $"IsBorrowable={(libraryItem.IsBorrowable ? 1 : 0)}, Borrower='{libraryItem.Borrower}', " +
                    $"BorrowDate={(libraryItem.BorrowDate != null ? "'" + Convert.ToDateTime(libraryItem.BorrowDate).ToString("yyyy-MM-dd") + "'" : "null")}, Type='{libraryItem.Type}' " +
                    $"WHERE Id = {libraryItem.Id}");
                dataChanged = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return dataChanged;
        }
    }
}
