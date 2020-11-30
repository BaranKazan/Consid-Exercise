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
            ServiceRunner<bool> servericeRunner = new ServiceRunner<bool>(new AddEmployee("Baran Kazan", "Kazan", 1.53F, true, false, null));

            Console.WriteLine(servericeRunner.Run());
        }
    }
}
