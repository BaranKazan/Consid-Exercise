using System;

namespace Library.Domain
{

    /*
     * This class is a domain of Category.
     */
    public class Category
    {

        public Category(String CategoryName)
        {
            this.CategoryName = CategoryName;
        }

        public Category(int Id,String CategoryName)
        {
            this.Id = Id;
            this.CategoryName = CategoryName;
        }

        public int Id { get; set; }
        public String CategoryName { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Id}, {CategoryName}");
        }
    }
}
