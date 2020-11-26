using System;
using Library.DAO;

namespace Library.Service.Delete
{
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
