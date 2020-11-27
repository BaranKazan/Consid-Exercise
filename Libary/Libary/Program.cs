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
            ServiceRunner<bool> servericeRunner = new ServiceRunner<bool>(new UpdateEmployee(13, "Manager", "Manager", 1.8F, false, false, 14));

            Console.WriteLine(servericeRunner.Run());
        }
    }
}
