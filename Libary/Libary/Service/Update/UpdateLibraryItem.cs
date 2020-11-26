using System;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Update
{
    /*
     * Updates a row in the LibraryItem table.
     */
    public class UpdateLibraryItem : Runnable<bool>
    {
        private int id;
        private int categoryId;
        private String title;
        private String author;
        private int? pages;
        private int? runTimeMinutes;
        private bool isBorrowable;
        private String borrower;
        private DateTime? borrowDate;
        private String type;
        private LibraryItemDao libraryItemDao = new LibraryItemDao();

        public UpdateLibraryItem(int id, int categoryId, String title, String author, int? pages, int? runTimeMinutes,
            bool isBorrowable, String borrower, DateTime? borrowDate, String type)
        {
            this.id = id;
            this.categoryId = categoryId;
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.runTimeMinutes = runTimeMinutes;
            this.isBorrowable = isBorrowable;
            this.borrower = borrower;
            this.borrowDate = borrowDate;
            this.type = type;
        }

        public bool Run()
        {
            return libraryItemDao.Update(new LibraryItem(id, categoryId, title, author, pages, runTimeMinutes, isBorrowable, borrower, borrowDate, type));
        }
    }
}
