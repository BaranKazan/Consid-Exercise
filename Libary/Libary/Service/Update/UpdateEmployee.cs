using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Domain;
using Library.Helper;

namespace Library.Service.Update
{

    /*
     * Updates the employee, the implementation is familiar with the save function.
     */

    public class UpdateEmployee : Runnable<bool>
    {
        private int id;
        private String firstName;
        private String lastName;
        private float salary;
        private bool isCeo;
        private bool isManager;
        private int? managerId;
        private EmployeeDao employeeDao = new EmployeeDao();

        public UpdateEmployee(int id, String firstName, String lastName, float salary, bool isCeo, bool isManager, int? managerId)
        {
            this.id = id;
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

            List<Employee> employees = employeeDao.GetAll();
            foreach(Employee employee in employees)
            {
                if(employee.Id == this.id)
                {
                    if (this.isCeo && !this.isManager)
                    {
                        if (this.managerId != null)
                            throw new Exception("The CEO cant have manager ID.");

                        foreach (Employee employee1 in employees)
                        {
                            if (employee1.IsCEO && !(employee1.Id == this.id))
                                throw new Exception($"There is already a CEO that exists, it's {employee1.FirstName} {employee1.LastName} with ID {employee1.Id}");
                        }
                        return employeeDao.Update(new Employee(this.id, this.firstName, this.lastName, this.salary, this.isCeo, this.isManager, null));
                    }
                    else if (!this.isCeo && this.isManager)
                    {
                        if (this.managerId != null)
                        {
                            foreach (Employee employee2 in employees)
                            {
                                if (employee2.Id == this.managerId)
                                {
                                    if (!employee2.IsManager && !employee2.IsCEO)
                                        throw new Exception("The given employee ID is not a manager or CEO");
                                    else
                                        return employeeDao.Update(new Employee(this.id, this.firstName, this.lastName, this.salary, this.isCeo, this.isManager, this.managerId));

                                }
                            }
                            throw new Exception("The is no employee with the ID of manager ID.");
                        }
                        else
                        {
                            return employeeDao.Update(new Employee(this.id, this.firstName, this.lastName, this.salary, this.isCeo, this.isManager, null));
                        }
                    }
                    else if (!this.isCeo && !this.isManager)
                    {
                        if (this.managerId == null)
                            throw new Exception("The regular employee must have manager ID.");

                        foreach (Employee employee3 in employees)
                        {
                            if (employee3.Id == this.managerId && !(employee3.Id == employee3.ManagerId))
                            {
                                if (employee3.IsManager && !employee3.IsCEO)
                                    return employeeDao.Update(new Employee(this.id, this.firstName, this.lastName, this.salary, this.isCeo, this.isManager, this.managerId));
                                else
                                    throw new Exception("Regular employee cant have CEO or regular employee as a manager.");
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
            throw new Exception("The given ID does not exists in the Employee table");
        }
    }
}
