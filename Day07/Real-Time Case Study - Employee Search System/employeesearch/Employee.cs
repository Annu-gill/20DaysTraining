using System;

namespace EmployeeSearchManagementSystem
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public int Experience { get; set; }
        public double Salary { get; set; }
        public string City { get; set; }

        public void Display()
        {
            Console.WriteLine($"{Id,-6} {Name,-18} {Department,-12} {Designation,-20} {Experience,-5} {Salary,-10} {City}");
        }
    }
}