using System;
using System.Collections.Generic;
using System.Linq;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Get
{

    /*
     * Sorts the employee by the rank.
     */

    public class SortEmployeeByRank : Runnable<List<Employee>>
    {
        private EmployeeDao employeeDao = new EmployeeDao();

        public List<Employee> Run()
        {
            List<Employee> employees = employeeDao.GetAll();
            List<Employee> ceo = new List<Employee>();
            List<Employee> manager = new List<Employee>();
            List<Employee> regular = new List<Employee>();

            foreach(Employee employee in employees)
            {
                if (employee.IsCEO && !employee.IsManager)
                    ceo.Add(employee);

                if (employee.IsManager && !employee.IsCEO)
                    manager.Add(employee);

                if (!employee.IsCEO && !employee.IsManager)
                    regular.Add(employee);
            }

            List<Employee> sorted = ceo.Concat(manager).Concat(regular).ToList();

            return sorted;
        }
    }
}
