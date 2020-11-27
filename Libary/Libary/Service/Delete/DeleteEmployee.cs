using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Domain;

namespace Library.Service.Delete
{

    /*
     * This class deletes a employee.
     * 
     * First it checks the other employee if they refered the one that
     * is about to get removed from the table. 
     */

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
            Employee match = null;
            Employee referedEmployee = null;
            foreach(Employee employee in employees)
            {
                if(employee.Id == this.id)
                {
                    match = employee;
                }
                if(this.id == employee.ManagerId)
                {
                    referedEmployee = employee;
                }

            }
            if (referedEmployee != null)
            {
                throw new Exception($"The ID is refered by the user ID {referedEmployee.Id}");
            }
            else if(match != null)
            {
                return employeeDao.Delete(this.id);
            }
            else
            {
                throw new Exception("The ID does not exist.");
            }
        }
    }
}
