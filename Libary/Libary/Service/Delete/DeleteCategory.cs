using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Delete
{
    public class DeleteCategory : Runnable<bool>
    {

        private int id;
        private CategoryDao categoryDao;
        private LibraryItemDao libraryItemDao;

        public DeleteCategory(int id)
        {
            this.id = id;
            categoryDao = new CategoryDao();
            libraryItemDao = new LibraryItemDao();

        }

        public bool Run()
        {
            List<LibraryItem> libraryItemList = libraryItemDao.GetAll();

            foreach(LibraryItem item in libraryItemList)
            {
                if (item.CategoryId == this.id)
                    throw new Exception("The ID of the Category exits in LibraryItem, please delete all the referenece and then try again.");
            }

            return categoryDao.Delete(this.id);
        }
    }
}
