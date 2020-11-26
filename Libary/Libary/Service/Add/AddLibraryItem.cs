using System;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Add
{
    /*
     * Saves a new row to the LibraryItem table in the database.
     */
    public class AddLibraryItem : Runnable<bool>
    {
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


        public AddLibraryItem(int categoryId, String title, String author, int? pages, int? runTimeMinutes,
            bool isBorrowable, String borrower, DateTime? borrowDate, String type)
        {
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
            return libraryItemDao.Save(new LibraryItem(categoryId, title, author, pages, runTimeMinutes, isBorrowable, borrower, borrowDate, type));
        }
    }
}
