using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Domain;
using Library.Service;
using Library.Service.Delete;
using Library.Service.Update;

namespace Library
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ServiceRunner<bool> servericeRunner = new ServiceRunner<bool>(new DeleteCategory(1));

            Console.WriteLine(servericeRunner.Run());

        }
    }
}
