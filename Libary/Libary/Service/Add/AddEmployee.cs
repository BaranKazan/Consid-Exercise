using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Domain;
using Library.Helper;

namespace Library.Service.Add
{

    /*
     * This class adds a new Employee into the table.
     * 
     * It checks the parameter first before storing the data.
     */

    public class AddEmployee : Runnable<bool>
    {

        private String firstName;
        private String lastName;
        private float salary;
        private bool isCeo;
        private bool isManager;
        private int? managerId;
        private EmployeeDao employeeDao = new EmployeeDao();

        public AddEmployee(String firstName, String lastName, float salary, bool isCeo, bool isManager, int? managerId)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
            this.isCeo = isCeo;
            this.isManager = isManager;
            this.managerId = managerId;
        }

        public bool Run()
        {
            if (!CheckInput.checkFirstName(this.firstName))
                throw new Exception("The input of the first name is not right");
            if (!CheckInput.checkLastName(this.lastName))
                throw new Exception("The input of the last name is not right");


            if (this.isCeo && !this.isManager)
            {
                if (this.managerId != null)
                    throw new Exception("The CEO cant have manager ID.");

                List<Employee> employees = employeeDao.GetAll();

                foreach(Employee employee in employees)
                {
                    if (employee.IsCEO)
                        throw new Exception($"There is already a CEO that exists, it's {employee.FirstName} {employee.LastName}");
                }
                return employeeDao.Save(new Employee(this.firstName, this.lastName, this.salary, this.isCeo, this.isManager, null));
            }
            else if(!this.isCeo && this.isManager)
            {
                if(this.managerId != null)
                {
                    List<Employee> employees = employeeDao.GetAll();
                    foreach (Employee employee in employees)
                    {
                        if (employee.Id == this.managerId)
                        {
                            if (!employee.IsManager && !employee.IsCEO)
                                throw new Exception("The given employee ID is not a manager or CEO");
                            else
                                return employeeDao.Save(new Employee(this.firstName, this.lastName, this.salary, this.isCeo, this.isManager, this.managerId));

                        }
                    }
                    throw new Exception("The is no employee with the ID of manager ID.");
                }
                else
                {
                    return employeeDao.Save(new Employee(this.firstName, this.lastName, this.salary, this.isCeo, this.isManager, null));
                }
            }
            else if (!this.isCeo && !this.isManager) {
                if (this.managerId == null)
                    throw new Exception("The regular employee must have manager ID.");

                List<Employee> employees = employeeDao.GetAll();
                foreach(Employee employee in employees)
                {
                    if(employee.Id == this.managerId)
                    {
                        if (employee.IsManager && !employee.IsCEO)
                            return employeeDao.Save(new Employee(this.firstName, this.lastName, this.salary, this.isCeo, this.isManager, this.managerId));
                        else
                            throw new Exception("Regular employee cant have CEO as manager ID.");
                    }
                }
                throw new Exception("The is no manager with the given manager ID.");
            }
            else
            {
                throw new Exception("The employee cant be both CEO or manager.");
            }
        }
    }
}
