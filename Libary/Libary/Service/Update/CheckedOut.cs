using System;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Update
{
    /*
     * Checks out a item that the user wants to borrow.
     */
    public class CheckedOut : Runnable<bool>
    {

        private int itemId;
        private String borrower;
        private LibraryItemDao libraryItemDao = new LibraryItemDao();

        public CheckedOut(int itemId, String borrower)
        {
            this.itemId = itemId;
            this.borrower = borrower;
        }

        public bool Run()
        {
            LibraryItem libraryItem = libraryItemDao.Get(this.itemId);
            if (libraryItem.IsBorrowable)
                throw new Exception("The item is not allowed to be borrowed.");
            libraryItem.BorrowDate = DateTime.Today;
            libraryItem.Borrower = this.borrower;
            return libraryItemDao.Update(libraryItem);
        }
    }
}
