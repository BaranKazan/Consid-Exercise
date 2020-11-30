using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Domain;
using Library.Helper;

namespace Library.Service.Update
{
    /*
     * Updates a row in the Category table.
     */
    public class UpdateCategory : Runnable<bool>
    {

        private CategoryDao categoryDao = new CategoryDao();
        private int Id;
        private String categoryName;

        public UpdateCategory(int Id, String categoryName)
        {
            this.Id = Id;
            this.categoryName = categoryName;
        }

        public bool Run()
        {
            if (!CheckInput.checkCategoryName(this.categoryName))
                throw new Exception("The input of the category name is not correct");


            List<Category> categories = categoryDao.GetAll();
            foreach(Category category in categories)
            {
                if(category.Id == this.Id)
                {
                    return categoryDao.Update(new Category(this.Id, this.categoryName));
                }
            }
            throw new Exception("The ID does not exist.");
        }
    }
}
