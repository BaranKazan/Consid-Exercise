using System;
using Library.DAO;

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
            return libraryItemDao.Delete(id);
        }
    }
}
