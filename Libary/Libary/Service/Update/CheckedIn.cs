using System;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Update
{
    /*
     * Checks in a item that was returned by the user.
     */
    public class CheckedIn : Runnable<bool>
    {

        private int itemId;
        private LibraryItemDao libraryItemDao = new LibraryItemDao();

        public CheckedIn(int itemId)
        {
            this.itemId = itemId;
        }

        public bool Run()
        {
            LibraryItem libraryItem = libraryItemDao.Get(this.itemId);
            libraryItem.BorrowDate = null;
            libraryItem.Borrower = "None";
            return libraryItemDao.Update(libraryItem);
        }
    }
}
