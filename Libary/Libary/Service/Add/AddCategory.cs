using System;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Add
{
    /*
     * Adds a new row to the Category table in the database
     */
    public class AddCategory : Runnable<bool>
    {

        private CategoryDao categoryDao = new CategoryDao();
        private String categoryName;

        public AddCategory(String categoryName)
        {
            this.categoryName = categoryName;
        }

        public bool Run()
        {
            return categoryDao.Save(new Category(this.categoryName));
        }
    }
}
