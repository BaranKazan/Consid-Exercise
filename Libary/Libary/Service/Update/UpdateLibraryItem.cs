using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Domain;
using Library.Helper;

namespace Library.Service.Update
{
    /*
     * Updates a row in the LibraryItem table. The implementation is familiar
     * with the save function.
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
        private String type;
        private LibraryItemDao libraryItemDao = new LibraryItemDao();

        public UpdateLibraryItem(int id, int categoryId, String title, String author, int? pages, int? runTimeMinutes,
            bool isBorrowable, String type)
        {
            this.id = id;
            this.categoryId = categoryId;
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.runTimeMinutes = runTimeMinutes;
            this.isBorrowable = isBorrowable;
            this.type = type;
        }

        public bool Run()
        {
            List<LibraryItem> items = libraryItemDao.GetAll();

            foreach(LibraryItem item in items)
            {
                if(item.Id == this.id)
                {
                    switch (this.categoryId)
                    {
                        case 1:
                            if (!CheckInput.checkTitle(this.title))
                                throw new Exception("The title of the book is empty");
                            else if (!CheckInput.checkAuthor(this.author))
                                throw new Exception("Check the input of the authors name");
                            else if (!CheckInput.checkPages(this.pages))
                                throw new Exception("The number of pages is required to be grater than 0 for the book");
                            else if (!CheckInput.checkType(this.type))
                                throw new Exception("Check the input type of the book");
                            else
                                return libraryItemDao.Update(new LibraryItem(id, categoryId, title, author, pages,
                                    runTimeMinutes, isBorrowable, item.Borrower, item.BorrowDate, type));

                        case 2:
                            if (!CheckInput.checkTitle(this.title))
                                throw new Exception("The title of the reference book is empty");
                            else if (!CheckInput.checkAuthor(this.author))
                                throw new Exception("Check the input of the authors name");
                            else if (!CheckInput.checkPages(this.pages))
                                throw new Exception("The number of pages is required to be grater than 0 for the reference book");
                            else if (!CheckInput.checkType(this.type))
                                throw new Exception("Check the input type of the reference book");
                            else if (this.isBorrowable)
                                throw new Exception("Any reference book cant be borrowed");
                            else
                                return libraryItemDao.Update(new LibraryItem(id, categoryId, title, author, pages,
                                    runTimeMinutes, isBorrowable, item.Borrower, item.BorrowDate, type));

                        case 3:
                            if (!CheckInput.checkTitle(this.title))
                                throw new Exception("The title of the DVD is empty");
                            else if (!CheckInput.checkRunTimeMinutes(this.runTimeMinutes))
                                throw new Exception("The number of run time minutes is required to be greater than 0 for the DVD");
                            else if (!CheckInput.checkType(this.type))
                                throw new Exception("Check the input type of the DVD");
                            else
                                return libraryItemDao.Update(new LibraryItem(id, categoryId, title, author, pages,
                                    runTimeMinutes, isBorrowable, item.Borrower, item.BorrowDate, type));

                        case 4:
                            if (!CheckInput.checkTitle(this.title))
                                throw new Exception("The title of the audio book is empty");
                            else if (!CheckInput.checkRunTimeMinutes(this.runTimeMinutes))
                                throw new Exception("The number of run time minutes is required to be hreater than 0 for the audio book");
                            else if (!CheckInput.checkType(this.type))
                                throw new Exception("Check the input type of the audio book");
                            else
                                return libraryItemDao.Update(new LibraryItem(id, categoryId, title, author, pages,
                                    runTimeMinutes, isBorrowable, item.Borrower, item.BorrowDate, type));
                        default:
                            if (!CheckInput.checkTitle(this.title))
                                throw new Exception("The title of the category is empty");
                            else if (!CheckInput.checkType(this.type))
                                throw new Exception("Check the input type of the category");
                            else
                                return libraryItemDao.Update(new LibraryItem(id, categoryId, title, author, pages,
                                    runTimeMinutes, isBorrowable, item.Borrower, item.BorrowDate, type));
                    }

                }
            }
            throw new Exception("The ID does not exist.");
        }
    }
}
