using System;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Update
{
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
            libraryItem.BorrowDate = DateTime.Now;
            libraryItem.Borrower = this.borrower;
            return libraryItemDao.Update(libraryItem);
        }
    }
}
