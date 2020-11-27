using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Delete
{
    public class DeleteEmployee : Runnable<bool>
    {

        private int id;
        private EmployeeDao employeeDao = new EmployeeDao();

        public DeleteEmployee(int id)
        {
            this.id = id;
        }

        public bool Run()
        {

            List<Employee> employees = employeeDao.GetAll();
            foreach(Employee employee in employees)
            {
                if(employee.Id == this.id)
                {
                    foreach(Employee employee1 in employees)
                    {
                        if (employee.Id == employee1.ManagerId)
                            throw new Exception($"The ID is refered by the user ID {employee1.Id}");
                    }
                    return employeeDao.Delete(this.id);
                }

            }
            throw new Exception("The ID does not exist.");
        }
    }
}
