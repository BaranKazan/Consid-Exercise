using System;

namespace Library.Domain
{

    public class Category
    {
        public Category(int Id,String CategoryName)
        {
            this.Id = Id;
            this.CategoryName = CategoryName;
        }

        public int Id { get; set; }
        public String CategoryName { get; set; }

    }
}
