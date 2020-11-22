using System;
using Library.Domain;

namespace Library
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Employee employee = new Employee(1, "Baran", "Kazan", 9.23F, true, false, null);
            Console.WriteLine(employee.Id + ", ")
        }
    }
}
