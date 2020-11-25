using System;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Update
{
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
            return categoryDao.Update(new Category(this.Id, this.categoryName));
        }
    }
}
