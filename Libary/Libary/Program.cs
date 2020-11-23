using System;
using Library.Domain;
using Library.DAO;
using System.Collections.Generic;

namespace Library
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CategoryDao categoryDAO = new CategoryDao();


            //Save
            //Console.WriteLine(categoryDAO.Save(new Category("Video games")));

            //Update
            //Console.WriteLine(categoryDAO.Update(new Category(1009, "Video Gaaaaames")));

            //Delete
            //Console.WriteLine(categoryDAO.Delete(1009));

            Category category = categoryDAO.Get(2);
            Console.WriteLine(category.Id + ", " + category.CategoryName);
            
            //GetAll
            /*List<Category> categories = categoryDAO.GetAll();
            foreach(Category category in categories)
            {
                Console.WriteLine(category.Id + ", " + category.CategoryName);
            }*/
        }
    }
}
