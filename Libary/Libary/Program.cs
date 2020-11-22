using System;
using Library.Domain;
using Library.DAO;
using System.Collections.Generic;

namespace Library
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            bool update = categoryDAO.Delete(1007);
            Console.WriteLine(update);
        }
    }
}
