using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Delete
{
    /*
     * Delete a row from LibraryItem table in the database.
     */
    public class DeleteLibraryItem : Runnable<bool>
    {

        private int id;
        private LibraryItemDao libraryItemDao = new LibraryItemDao();

        public DeleteLibraryItem(int id)
        {
            this.id = id;
        }

        public bool Run()
        {
            List<LibraryItem> items = libraryItemDao.GetAll();
            foreach(LibraryItem item in items)
            {
                if(this.id == item.Id)
                {
                    return libraryItemDao.Delete(id);
                }
            }
            throw new Exception("The ID does not exits in the LibraryItem");
        }
    }
}
