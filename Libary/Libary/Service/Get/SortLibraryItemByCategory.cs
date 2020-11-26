using System.Collections.Generic;
using System.Linq;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Get
{
    public class SortLibraryItemByCategory : Runnable<List<LibraryItem>>
    {

        private LibraryItemDao libraryItemDao = new LibraryItemDao();

        public List<LibraryItem> Run()
        {
            return libraryItemDao.GetAll().OrderBy(item => item.CategoryId).ToList();
        }
    }
}
