using System;
using System.Collections.Generic;

namespace EmployeeSearchManagementSystem
{
    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1001,
                    Name = "Rahul Sharma",
                    Department = "IT",
                    Designation = "Software Engineer",
                    Experience = 2,
                    Salary = 45000,
                    City = "Chennai"
                },

                new Employee
                {
                    Id = 1002,
                    Name = "Priya Singh",
                    Department = "HR",
                    Designation = "HR Executive",
                    Experience = 3,
                    Salary = 40000,
                    City = "Bangalore"
                },

                new Employee
                {
                    Id = 1003,
                    Name = "Amit Kumar",
                    Department = "Finance",
                    Designation = "Accountant",
                    Experience = 5,
                    Salary = 55000,
                    City = "Hyderabad"
                },

                new Employee
                {
                    Id = 1004,
                    Name = "Neha Patel",
                    Department = "IT",
                    Designation = "Senior Developer",
                    Experience = 6,
                    Salary = 85000,
                    City = "Pune"
                },

                new Employee
                {
                    Id = 1005,
                    Name = "Arjun Reddy",
                    Department = "Sales",
                    Designation = "Sales Executive",
                    Experience = 2,
                    Salary = 38000,
                    City = "Chennai"
                },

                new Employee
                {
                    Id = 1006,
                    Name = "Sneha Iyer",
                    Department = "Marketing",
                    Designation = "Marketing Executive",
                    Experience = 4,
                    Salary = 52000,
                    City = "Coimbatore"
                },

                new Employee
                {
                    Id = 1007,
                    Name = "Karan Mehta",
                    Department = "IT",
                    Designation = "Team Lead",
                    Experience = 8,
                    Salary = 95000,
                    City = "Mumbai"
                },

                new Employee
                {
                    Id = 1008,
                    Name = "Divya Nair",
                    Department = "Support",
                    Designation = "Support Engineer",
                    Experience = 1,
                    Salary = 32000,
                    City = "Kochi"
                },

                new Employee
                {
                    Id = 1009,
                    Name = "Rohit Verma",
                    Department = "IT",
                    Designation = "Software Engineer",
                    Experience = 3,
                    Salary = 50000,
                    City = "Delhi"
                },

                new Employee
                {
                    Id = 1010,
                    Name = "Anjali Gupta",
                    Department = "Finance",
                    Designation = "Financial Analyst",
                    Experience = 4,
                    Salary = 65000,
                    City = "Noida"
                },

                new Employee
                {
                    Id = 1011,
                    Name = "Suresh Kumar",
                    Department = "Admin",
                    Designation = "Administrator",
                    Experience = 7,
                    Salary = 58000,
                    City = "Madurai"
                },

                new Employee
                {
                    Id = 1012,
                    Name = "Pooja Sharma",
                    Department = "HR",
                    Designation = "Recruiter",
                    Experience = 2,
                    Salary = 42000,
                    City = "Bangalore"
                },

                new Employee
                {
                    Id = 1013,
                    Name = "Vikram Das",
                    Department = "IT",
                    Designation = "System Engineer",
                    Experience = 5,
                    Salary = 62000,
                    City = "Chennai"
                },

                new Employee
                {
                    Id = 1014,
                    Name = "Meena Joshi",
                    Department = "Support",
                    Designation = "Technical Support",
                    Experience = 3,
                    Salary = 41000,
                    City = "Trichy"
                },

                new Employee
                {
                    Id = 1015,
                    Name = "Naveen Raj",
                    Department = "Sales",
                    Designation = "Sales Manager",
                    Experience = 9,
                    Salary = 98000,
                    City = "Salem"
                },

                new Employee
                {
                    Id = 1016,
                    Name = "Kavya R",
                    Department = "Marketing",
                    Designation = "SEO Analyst",
                    Experience = 2,
                    Salary = 45000,
                    City = "Chennai"
                },

                new Employee
                {
                    Id = 1017,
                    Name = "Ajay Kumar",
                    Department = "IT",
                    Designation = "DevOps Engineer",
                    Experience = 4,
                    Salary = 72000,
                    City = "Hyderabad"
                },

                new Employee
                {
                    Id = 1018,
                    Name = "Lakshmi Devi",
                    Department = "Finance",
                    Designation = "Senior Accountant",
                    Experience = 6,
                    Salary = 76000,
                    City = "Coimbatore"
                },

                new Employee
                {
                    Id = 1019,
                    Name = "Manoj Singh",
                    Department = "IT",
                    Designation = "QA Engineer",
                    Experience = 3,
                    Salary = 53000,
                    City = "Pune"
                },

                new Employee
                {
                    Id = 1020,
                    Name = "Deepika Rao",
                    Department = "HR",
                    Designation = "HR Manager",
                    Experience = 8,
                    Salary = 90000,
                    City = "Bangalore"
                }
            };

            while (true)
            {
                Console.WriteLine("\n===== Employee Search Management System =====");
                Console.WriteLine("1. Display All Employees");
                Console.WriteLine("2. Linear Search by ID");
                Console.WriteLine("3. Binary Search by ID");
                Console.WriteLine("4. Search by Name");
                Console.WriteLine("5. Search by Department");
                Console.WriteLine("6. Search by City");
                Console.WriteLine("7. Search by Experience");
                Console.WriteLine("8. Search by Salary Range");
                Console.WriteLine("9. Exit");

                Console.Write("\nEnter Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        EmployeeService.DisplayAll(employees);
                        break;

                    case 2:
                        Console.Write("Enter Employee ID: ");
                        EmployeeService.LinearSearch(employees, Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 3:
                        Console.Write("Enter Employee ID: ");
                        EmployeeService.BinarySearch(employees, Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 4:
                        Console.Write("Enter Employee Name: ");
                        EmployeeService.SearchByName(employees, Console.ReadLine());
                        break;

                    case 5:
                        Console.Write("Enter Department: ");
                        EmployeeService.SearchByDepartment(employees, Console.ReadLine());
                        break;

                    case 6:
                        Console.Write("Enter City: ");
                        EmployeeService.SearchByCity(employees, Console.ReadLine());
                        break;

                    case 7:
                        Console.Write("Enter Minimum Experience: ");
                        EmployeeService.SearchByExperience(employees, Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 8:
                        Console.Write("Enter Minimum Salary: ");
                        double min = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Maximum Salary: ");
                        double max = Convert.ToDouble(Console.ReadLine());

                        EmployeeService.SearchBySalary(employees, min, max);
                        break;

                    case 9:
                        Console.WriteLine("Thank You!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }
    }
}