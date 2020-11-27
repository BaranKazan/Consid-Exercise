using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Delete
{
    /*
     * Deletes a row in the Category table. 
     */
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

        /*
         * There is no need to check if the key is refered in the LibraryItem
         * table becuase the database does that for us.
         */
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
