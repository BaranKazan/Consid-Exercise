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
            ServiceRunner<bool> servericeRunner = new ServiceRunner<bool>(new UpdateLibraryItem(1, 1, "Title", "Author", 2, null, true, "Type"));

            Console.WriteLine(servericeRunner.Run());
        }
    }
}
