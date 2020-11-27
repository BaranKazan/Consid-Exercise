using System;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Add
{
    /*
     * Saves a new row to the LibraryItem table in the database.
     * 
     * The run function checks the required parameters depending on the category. 
     * Some values will pass such as having pages in DVD because it was not Excluded
     * in the exercise. 
     * 
     * There is no need checking for CategoryID becuase the databse does that for us.
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
            bool isBorrowable, String type)
        {
            this.categoryId = categoryId;
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.runTimeMinutes = runTimeMinutes;
            this.isBorrowable = isBorrowable;
            this.borrower = "None";
            this.borrowDate = null;
            this.type = type;
        }

        public bool Run()
        {

            switch (this.categoryId)
            {
                case 1:
                    if (this.title == "")
                        throw new Exception("The title of the book is empty");
                    else if (this.author == "")
                        throw new Exception("The author of the book is empty");
                    else if (this.pages == 0 || this.pages == null)
                        throw new Exception("The number of pages is required for the book");
                    else if (this.type == "")
                        throw new Exception("The type of the book is required.");
                    else
                        return libraryItemDao.Save(new LibraryItem(categoryId, title, author,
                            pages, runTimeMinutes, isBorrowable, borrower, borrowDate, type));

                case 2:
                    if (this.title == "")
                        throw new Exception("The title of the reference book is empty");
                    else if (this.author == "")
                        throw new Exception("The author of the book is empty");
                    else if (this.pages == 0 || this.pages == null)
                        throw new Exception("The number of pages is required for the reference book");
                    else if (this.type == "")
                        throw new Exception("The type of the reference book is required.");
                    else if (this.isBorrowable)
                        throw new Exception("Any reference book cant be borrowed");
                    else
                        return libraryItemDao.Save(new LibraryItem(categoryId, title, author,
                            pages, runTimeMinutes, isBorrowable, borrower, borrowDate, type));

                case 3:
                    if (this.title == "")
                        throw new Exception("The title of the DVD is empty");
                    else if (this.runTimeMinutes == 0 || this.runTimeMinutes == null)
                        throw new Exception("The number of run time minutes is required for the DVD");
                    else if (this.type == "")
                        throw new Exception("The type of the DVD is required.");
                    else
                        return libraryItemDao.Save(new LibraryItem(categoryId, title, author,
                                pages, runTimeMinutes, isBorrowable, borrower, borrowDate, type));

                case 4:
                    if (this.title == "")
                        throw new Exception("The title of the audio book is empty");
                    else if (this.runTimeMinutes == 0 || this.runTimeMinutes == null)
                        throw new Exception("The number of run time minutes is required for the audio book");
                    else if (this.type == "")
                        throw new Exception("The type of the audio book is required.");
                    else
                        return libraryItemDao.Save(new LibraryItem(categoryId, title, author,
                                pages, runTimeMinutes, isBorrowable, borrower, borrowDate, type));

                default:
                    if (this.title == "")
                        throw new Exception("The title of the category is empty");
                    else if (this.type == "")
                        throw new Exception("The type of the category is required.");
                    else
                        return libraryItemDao.Save(new LibraryItem(categoryId, title, author,
                                pages, runTimeMinutes, isBorrowable, borrower, borrowDate, type));
            }
        }
    }
}
