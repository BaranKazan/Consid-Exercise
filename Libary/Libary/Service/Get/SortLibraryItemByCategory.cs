using System.Collections.Generic;
using System.Linq;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Get
{
    /*
     * Sorts the LibraryItem by the category
     */
    public class SortLibraryItemByCategory : Runnable<List<LibraryItem>>
    {

        private LibraryItemDao libraryItemDao = new LibraryItemDao();

        public List<LibraryItem> Run()
        {
            return libraryItemDao.GetAll().OrderBy(item => item.CategoryId).ToList();
        }
    }
}
