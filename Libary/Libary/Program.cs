using System;
using Library.Domain;
using Library.DAO;
using System.Collections.Generic;
using Libary.DAO;

namespace Library
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            LibraryItemDao libraryItemDao = new LibraryItemDao();


            List<LibraryItem> libraryItems = libraryItemDao.GetAll();

            foreach(LibraryItem libraryItem in libraryItems)
            {
                libraryItem.Print();
            }

            //Save
            //Console.WriteLine(categoryDAO.Save(new Category("Video games")));

            //Update
            //Console.WriteLine(categoryDAO.Update(new Category(1009, "Video Gaaaaames")));

            //Delete
            //Console.WriteLine(categoryDAO.Delete(1009));

            //Get
            /*Category category = categoryDAO.Get(2);
            Console.WriteLine(category.Id + ", " + category.CategoryName);*/

            //GetAll
            /*List<Category> categories = categoryDAO.GetAll();
            foreach(Category category in categories)
            {
                Console.WriteLine(category.Id + ", " + category.CategoryName);
            }*/
        }
    }
}
