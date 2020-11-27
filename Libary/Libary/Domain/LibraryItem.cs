using System;
using Library.Helper;

namespace Library.Domain
{
    /*
     * This class is a domain of LibraryItem.
     */
    public class LibraryItem : DomainInterface
    {

        public LibraryItem(int CategoryId, String Title, String Author,
            int? Pages, int? RunTimeMinutes, bool IsBorrowable, String Borrower,
            DateTime? BorrowDate, String Type)
        {
            this.CategoryId = CategoryId;
            this.Title = Title;
            this.Author = Author;
            this.Pages = Pages;
            this.RunTimeMinutes = RunTimeMinutes;
            this.IsBorrowable = IsBorrowable;
            this.Borrower = Borrower;
            this.BorrowDate = BorrowDate;
            this.Type = Type;
        }

        public LibraryItem(int Id, int CategoryId, String Title, String Author,
            int? Pages, int? RunTimeMinutes, bool IsBorrowable, String Borrower,
            DateTime? BorrowDate, String Type)
        {
            this.Id = Id;
            this.CategoryId = CategoryId;
            this.Title = Title;
            this.Author = Author;
            this.Pages = Pages;
            this.RunTimeMinutes = RunTimeMinutes;
            this.IsBorrowable = IsBorrowable;
            this.Borrower = Borrower;
            this.BorrowDate = BorrowDate;
            this.Type = Type;
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public int? Pages { get; set; }
        public int? RunTimeMinutes { get; set; }
        public bool IsBorrowable { get; set; }
        public String Borrower { get; set; }
        public DateTime? BorrowDate { get; set; }
        public String Type { get; set; }

        public void Print()
        {
            Console.WriteLine($"ID: {Id}, CategoryID: {CategoryId}, Tittle: {TextConverter.AcronymTheTittle(Title)}, " +
                $"Author: {Author}, Pages: {Pages}, Run Time Minutes: {RunTimeMinutes}, Borrowable: {IsBorrowable}, " +
                $"Borrower: {Borrower}, Borrowed Date: {TextConverter.DateWithoutTime(BorrowDate)}, Type: {Type}");
        }
    }
}
