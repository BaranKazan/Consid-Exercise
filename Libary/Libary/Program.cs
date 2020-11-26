using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Domain;
using Library.Service;
using Library.Service.Add;
using Library.Service.Delete;
using Library.Service.Get;
using Library.Service.Update;

namespace Library
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ServiceRunner<List<LibraryItem>> servericeRunner = new ServiceRunner<List<LibraryItem>>(new SortLibraryItemByType());

            List <LibraryItem> list = servericeRunner.Run();

            foreach(LibraryItem item in list)
            {
                item.Print();
            }

        }
    }
}
