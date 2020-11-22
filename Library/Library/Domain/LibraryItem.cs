using System;
namespace Library.Domain
{
    public class LibraryItem
    {
        public LibraryItem(int Id, int CategoryId, String Title, String Author,
            int Pages, int RunTimeMinutes, bool IsBorrowable, String Borrower,
            String BorrowDate, String Type)
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
        public int Pages { get; set; }
        public int RunTimeMinutes { get; set; }
        public bool IsBorrowable { get; set; }
        public String Borrower { get; set; }
        public String BorrowDate { get; set; }
        public String Type { get; set; }
    }
}
