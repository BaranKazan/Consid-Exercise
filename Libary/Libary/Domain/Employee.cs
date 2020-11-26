using System;
namespace Library.Domain
{

    /*
     * This class is a domain of Employee
     */
    public class Employee
    {

        public Employee(String FirstName, String LastName, float Salary,
            bool IsCEO, bool IsManager, int? ManagerId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Salary = Salary;
            this.IsCEO = IsCEO;
            this.IsManager = IsManager;
            this.ManagerId = ManagerId;
        }

        public Employee(int Id, String FirstName, String LastName, float Salary,
            bool IsCEO, bool IsManager, int? ManagerId)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Salary = Salary;
            this.IsCEO = IsCEO;
            this.IsManager = IsManager;
            this.ManagerId = ManagerId;
        }

        public int Id { set; get; }
        public String FirstName { set; get; }
        public String LastName { set; get; }
        public float Salary { set; get; }
        public bool IsCEO { set; get; }
        public bool IsManager { set; get; }
        public int? ManagerId { set; get; }

        public void Print()
        {
            Console.WriteLine($"{Id}, {FirstName}, {LastName}, {Salary}, {IsCEO}, {IsManager}, {ManagerId}");
        }
    }
}
