using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationHierarchy
{
    // Employee Class
    class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public int ManagerId { get; set; }

        // Parameterized Constructor
        public Employee(int id, string name, string designation, string department, int managerId)
        {
            EmployeeId = id;
            Name = name;
            Designation = designation;
            Department = department;
            ManagerId = managerId;
        }
    }

    class Program
    {
        // List to store all employees
        static List<Employee> employees = new List<Employee>()
        {
            new Employee(1001,"John Smith","CEO","Management",0),
            new Employee(1002,"Michael Johnson","IT Manager","IT",1001),
            new Employee(1003,"Sarah Williams","HR Manager","HR",1001),
            new Employee(1004,"David Brown","Finance Manager","Finance",1001),
            new Employee(1005,"Robert Davis","Team Lead","IT",1002),
            new Employee(1006,"Jennifer Miller","QA Lead","IT",1002),
            new Employee(1007,"William Wilson","Senior Developer","IT",1005),
            new Employee(1008,"Emma Moore","Senior Developer","IT",1005),
            new Employee(1009,"Daniel Taylor","QA Engineer","IT",1006),
            new Employee(1010,"Sophia Anderson","QA Engineer","IT",1006),
            new Employee(1011,"James Thomas","Recruiter","HR",1003),
            new Employee(1012,"Olivia Jackson","Recruiter","HR",1003),
            new Employee(1013,"Benjamin White","Accountant","Finance",1004),
            new Employee(1014,"Charlotte Harris","Accountant","Finance",1004),
            new Employee(1015,"Lucas Martin","Developer","IT",1007),
            new Employee(1016,"Ethan Walker","Developer","IT",1007),
            new Employee(1017,"Mia Hall","UI Developer","IT",1008),
            new Employee(1018,"Alexander Young","Business Analyst","IT",1005),
            new Employee(1019,"Harper King","HR Executive","HR",1011),
            new Employee(1020,"Jack Scott","Finance Executive","Finance",1013)
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("==========================================");
                Console.WriteLine("        ABC TECHNOLOGIES");
                Console.WriteLine("Organization Hierarchy Management System");
                Console.WriteLine("==========================================");

                Console.WriteLine("1. Display Complete Organization Chart");
                Console.WriteLine("2. Find Employee by ID");
                Console.WriteLine("3. Find Employee by Name");
                Console.WriteLine("4. Display Employees under a Manager");
                Console.WriteLine("5. Count Total Employees under a Manager");
                Console.WriteLine("6. Display Hierarchy Level");
                Console.WriteLine("7. Exit");

                Console.Write("\nEnter Your Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        DisplayOrganizationChart();
                        break;

                    case 2:
                        FindEmployeeById();
                        break;

                    case 3:
                        FindEmployeeByName();
                        break;

                    case 4:
                        DisplayEmployeesUnderManager();
                        break;

                    case 5:
                        CountEmployeesUnderManager();
                        break;

                    case 6:
                        DisplayHierarchyLevel();
                        break;

                    case 7:
                        Console.WriteLine("Thank You!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        //============================================================
        // Display Complete Organization Chart using Recursion
        //============================================================
        static void DisplayOrganizationChart()
        {
            Employee ceo = employees.FirstOrDefault(e => e.ManagerId == 0);

            Console.WriteLine("Organization Hierarchy\n");

            PrintHierarchy(ceo, "", true);
        }

        // Recursive Function
        static void PrintHierarchy(Employee manager, string indent, bool last)
        {
            if (manager == null)
                return;

            Console.Write(indent);

            if (manager.ManagerId != 0)
            {
                Console.Write(last ? "└── " : "├── ");
            }

            Console.WriteLine($"{manager.Name} ({manager.Designation})");

            indent += (manager.ManagerId == 0) ? "" : (last ? "    " : "│   ");

            List<Employee> subordinates =
                employees.Where(e => e.ManagerId == manager.EmployeeId).ToList();

            for (int i = 0; i < subordinates.Count; i++)
            {
                PrintHierarchy(subordinates[i], indent, i == subordinates.Count - 1);
            }
        }

        //============================================================
        // Find Employee by ID
        //============================================================
        static void FindEmployeeById()
        {
            Console.Write("Enter Employee ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employees.FirstOrDefault(e => e.EmployeeId == id);

            if (emp != null)
            {
                Console.WriteLine("\nEmployee Details");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"ID          : {emp.EmployeeId}");
                Console.WriteLine($"Name        : {emp.Name}");
                Console.WriteLine($"Designation : {emp.Designation}");
                Console.WriteLine($"Department  : {emp.Department}");
            }
            else
            {
                Console.WriteLine("Employee Not Found.");
            }
        }

        //============================================================
        // Find Employee by Name
        //============================================================
        static void FindEmployeeByName()
        {
            Console.Write("Enter Employee Name : ");

            string name = Console.ReadLine().ToLower();

            Employee emp = employees.FirstOrDefault
            (
                e => e.Name.ToLower().Contains(name)
            );

            if (emp != null)
            {
                Console.WriteLine("\nEmployee Details");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"ID          : {emp.EmployeeId}");
                Console.WriteLine($"Name        : {emp.Name}");
                Console.WriteLine($"Designation : {emp.Designation}");
                Console.WriteLine($"Department  : {emp.Department}");
            }
            else
            {
                Console.WriteLine("Employee Not Found.");
            }
        }

        //============================================================
        // Display Employees under a Manager
        //============================================================
        static void DisplayEmployeesUnderManager()
        {
            Console.Write("Enter Manager ID : ");
            int managerId = Convert.ToInt32(Console.ReadLine());

            Employee manager = employees.FirstOrDefault(e => e.EmployeeId == managerId);

            if (manager == null)
            {
                Console.WriteLine("Manager Not Found.");
                return;
            }

            Console.WriteLine($"\nEmployees under {manager.Name}\n");

            ShowSubordinates(manager.EmployeeId);
        }

        // Recursive Function
        static void ShowSubordinates(int managerId)
        {
            List<Employee> list =
                employees.Where(e => e.ManagerId == managerId).ToList();

            foreach (Employee emp in list)
            {
                Console.WriteLine($"{emp.Name} ({emp.Designation})");

                ShowSubordinates(emp.EmployeeId);
            }
        }

        //============================================================
        // Count Employees under a Manager
        //============================================================
        static void CountEmployeesUnderManager()
        {
            Console.Write("Enter Manager ID : ");
            int managerId = Convert.ToInt32(Console.ReadLine());

            Employee manager =
                employees.FirstOrDefault(e => e.EmployeeId == managerId);

            if (manager == null)
            {
                Console.WriteLine("Manager Not Found.");
                return;
            }

            int total = CountSubordinates(managerId);

            Console.WriteLine($"\nTotal Employees under {manager.Name} = {total}");
        }

        // Recursive Function
        static int CountSubordinates(int managerId)
        {
            int count = 0;

            List<Employee> list =
                employees.Where(e => e.ManagerId == managerId).ToList();

            foreach (Employee emp in list)
            {
                count++;

                count += CountSubordinates(emp.EmployeeId);
            }

            return count;
        }

        //============================================================
        // Display Hierarchy Level
        //============================================================
        static void DisplayHierarchyLevel()
        {
            Console.Write("Enter Employee ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp =
                employees.FirstOrDefault(e => e.EmployeeId == id);

            if (emp == null)
            {
                Console.WriteLine("Employee Not Found.");
                return;
            }

            int level = GetHierarchyLevel(emp);

            Console.WriteLine($"\nHierarchy Level of {emp.Name} = {level}");
        }

        // Recursive Function
        static int GetHierarchyLevel(Employee emp)
        {
            if (emp.ManagerId == 0)
                return 1;

            Employee manager =
                employees.FirstOrDefault(e => e.EmployeeId == emp.ManagerId);

            return 1 + GetHierarchyLevel(manager);
        }
    }
}