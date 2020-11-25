using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Library.Domain;

namespace Library.DAO
{
    public class EmployeeDao : DaoInterface<Employee>
    {

        private ConnectionManager connectionManager = null;

        public EmployeeDao()
        {
            this.connectionManager = ConnectionManager.getInstance();
        }

        public EmployeeDao(ConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public bool Delete(int id)
        {
            bool dataDeleted = false;
            try
            {
                connectionManager.WriteData($"DELETE FROM Employees WHERE Id={id}");
                dataDeleted = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return dataDeleted;
        }

        public Employee Get(int id)
        {
            Employee employee = null;
            try
            {
                SqlDataReader dataReader = connectionManager.ReadData("SELECT * FROM Employees WHERE Id = " + id);

                if (!dataReader.Read())
                    throw new Exception("The ID does not exist.");

                employee = new Employee(dataReader.GetInt32(0), dataReader.GetString(1),
                    dataReader.GetString(2), (float)dataReader.GetDecimal(3),
                    dataReader.GetBoolean(4), dataReader.GetBoolean(5),
                    !dataReader.IsDBNull(6) ? (int?)dataReader.GetInt32(6) : null);
                dataReader.Close();
                connectionManager.CloseConnection();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return employee;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = null;
            try
            {
                SqlDataReader dataReader = connectionManager.ReadData("SELECT * FROM Employees");
                employees = new List<Employee>();
                if (!dataReader.Read())
                    throw new Exception("The table is empty.");
                do
                {
                    employees.Add(new Employee(dataReader.GetInt32(0), dataReader.GetString(1),
                    dataReader.GetString(2), (float)dataReader.GetDecimal(3),
                    dataReader.GetBoolean(4), dataReader.GetBoolean(5),
                    !dataReader.IsDBNull(6) ? (int?)dataReader.GetInt32(6) : null));

                }
                while (dataReader.Read());
                dataReader.Close();
                connectionManager.CloseConnection();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return employees;
        }

        public bool Save(Employee employee)
        {
            bool dataStored = false;
            try
            {
                connectionManager.WriteData($"INSERT INTO Employees(FirstName, LastName, Salary, IsCEO, IsManager, ManagerId) " +
                    $"VALUES ('{employee.FirstName}', '{employee.LastName}', {employee.Salary}, {(employee.IsCEO ? 1 : 0)}, " +
                    $"{(employee.IsManager ? 1 : 0)}, {(employee.ManagerId != null ? employee.ManagerId.ToString() : "null")})");
                dataStored = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return dataStored;
        }

        public bool Update(Employee employee)
        {
            bool dataChanged = false;
            try
            {
                connectionManager.WriteData($"UPDATE Employees SET FirstName='{employee.FirstName}', LastName='{employee.LastName}', " +
                    $"Salary={employee.Salary}, IsCEO={(employee.IsCEO ? 1 : 0)}, IsManager={(employee.IsManager ? 1 : 0)}, " +
                    $"ManagerId={(employee.ManagerId != null ? employee.ManagerId.ToString() : "null")}  WHERE Id = {employee.Id}");
                dataChanged = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return dataChanged;
        }
    }
}
