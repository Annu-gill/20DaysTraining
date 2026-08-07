using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSearchManagementSystem
{
    class EmployeeService
    {
        public static void DisplayHeader()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine("ID     Name               Department   Designation          Exp   Salary      City");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
        }

        public static void DisplayAll(List<Employee> employees)
        {
            DisplayHeader();

            foreach (Employee emp in employees)
            {
                emp.Display();
            }
        }

        public static void LinearSearch(List<Employee> employees, int id)
        {
            foreach (Employee emp in employees)
            {
                if (emp.Id == id)
                {
                    DisplayHeader();
                    emp.Display();
                    return;
                }
            }

            Console.WriteLine("Employee Not Found.");
        }

        public static void BinarySearch(List<Employee> employees, int id)
        {
            List<Employee> sorted = employees.OrderBy(e => e.Id).ToList();

            int low = 0;
            int high = sorted.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (sorted[mid].Id == id)
                {
                    DisplayHeader();
                    sorted[mid].Display();
                    return;
                }
                else if (id < sorted[mid].Id)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            Console.WriteLine("Employee Not Found.");
        }

        public static void SearchByName(List<Employee> employees, string name)
        {
            bool found = false;

            DisplayHeader();

            foreach (Employee emp in employees)
            {
                if (emp.Name.ToLower().Contains(name.ToLower()))
                {
                    emp.Display();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("Employee Not Found.");
        }

        public static void SearchByDepartment(List<Employee> employees, string department)
        {
            bool found = false;

            DisplayHeader();

            foreach (Employee emp in employees)
            {
                if (emp.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
                {
                    emp.Display();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No Employees Found.");
        }

        public static void SearchByCity(List<Employee> employees, string city)
        {
            bool found = false;

            DisplayHeader();

            foreach (Employee emp in employees)
            {
                if (emp.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                {
                    emp.Display();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No Employees Found.");
        }

        public static void SearchByExperience(List<Employee> employees, int experience)
        {
            bool found = false;

            DisplayHeader();

            foreach (Employee emp in employees)
            {
                if (emp.Experience >= experience)
                {
                    emp.Display();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No Employees Found.");
        }

        public static void SearchBySalary(List<Employee> employees, double min, double max)
        {
            bool found = false;

            DisplayHeader();

            foreach (Employee emp in employees)
            {
                if (emp.Salary >= min && emp.Salary <= max)
                {
                    emp.Display();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No Employees Found.");
        }
    }
}