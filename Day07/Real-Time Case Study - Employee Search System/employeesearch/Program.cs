using System;
using System.Collections.Generic;
using System.Linq;

// Employee class to store employee information
class Employee
{
    // Employee properties
    public int Id;
    public string Name;
    public string Department;
    public string Designation;
    public int Experience;
    public double Salary;
    public string City;

    // Constructor to initialize employee details
    public Employee(int id, string name, string department,
        string designation, int experience, double salary, string city)
    {
        Id = id;
        Name = name;
        Department = department;
        Designation = designation;
        Experience = experience;
        Salary = salary;
        City = city;
    }

    // Method to display one employee record
    public void Display()
    {
        Console.WriteLine($"{Id,-6} {Name,-18} {Department,-10} {Designation,-20} {Experience,-5} {Salary,-10} {City}");
    }
}

class Program
{
    static void Main()
    {
        // Creating list of employees
        List<Employee> employees = new List<Employee>
        {
            new Employee(1001,"Rahul Sharma","IT","Software Engineer",2,45000,"Chennai"),
            new Employee(1002,"Priya Singh","HR","HR Executive",3,40000,"Bangalore"),
            new Employee(1003,"Amit Kumar","Finance","Accountant",5,55000,"Hyderabad"),
            new Employee(1004,"Neha Patel","IT","Senior Developer",6,85000,"Pune"),
            new Employee(1005,"Arjun Reddy","Sales","Sales Executive",2,38000,"Chennai"),
            new Employee(1006,"Sneha Iyer","Marketing","Marketing Executive",4,52000,"Coimbatore"),
            new Employee(1007,"Karan Mehta","IT","Team Lead",8,95000,"Mumbai"),
            new Employee(1008,"Divya Nair","Support","Support Engineer",1,32000,"Kochi"),
            new Employee(1009,"Rohit Verma","IT","Software Engineer",3,50000,"Delhi"),
            new Employee(1010,"Anjali Gupta","Finance","Financial Analyst",4,65000,"Noida"),
            new Employee(1011,"Suresh Kumar","Admin","Administrator",7,58000,"Madurai"),
            new Employee(1012,"Pooja Sharma","HR","Recruiter",2,42000,"Bangalore"),
            new Employee(1013,"Vikram Das","IT","System Engineer",5,62000,"Chennai"),
            new Employee(1014,"Meena Joshi","Support","Technical Support",3,41000,"Trichy"),
            new Employee(1015,"Naveen Raj","Sales","Sales Manager",9,98000,"Salem"),
            new Employee(1016,"Kavya R","Marketing","SEO Analyst",2,45000,"Chennai"),
            new Employee(1017,"Ajay Kumar","IT","DevOps Engineer",4,72000,"Hyderabad"),
            new Employee(1018,"Lakshmi Devi","Finance","Senior Accountant",6,76000,"Coimbatore"),
            new Employee(1019,"Manoj Singh","IT","QA Engineer",3,53000,"Pune"),
            new Employee(1020,"Deepika Rao","HR","HR Manager",8,90000,"Bangalore")
        };

        // Menu runs until user selects Exit
        while (true)
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine("      ABC Technologies");
            Console.WriteLine(" Employee Search Management System");
            Console.WriteLine("====================================");

            Console.WriteLine("1. Display All Employees");
            Console.WriteLine("2. Search by Employee ID (Linear Search)");
            Console.WriteLine("3. Search by Employee ID (Binary Search)");
            Console.WriteLine("4. Search by Employee Name");
            Console.WriteLine("5. Search by Department");
            Console.WriteLine("6. Search by City");
            Console.WriteLine("7. Search by Experience");
            Console.WriteLine("8. Search by Salary Range");
            Console.WriteLine("9. Exit");

            // Read user choice
            Console.Write("\nEnter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            // Execute selected operation
            switch (choice)
            {
                case 1:
                    DisplayAll(employees);
                    break;

                case 2:
                    Console.Write("Enter Employee ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    // Call Linear Search
                    LinearSearch(employees, id);
                    break;

                case 3:
                    Console.Write("Enter Employee ID: ");
                    int bid = Convert.ToInt32(Console.ReadLine());

                    // Call Binary Search
                    BinarySearch(employees, bid);
                    break;

                case 4:
                    Console.Write("Enter Employee Name: ");
                    string name = Console.ReadLine();

                    // Search employee by name
                    SearchByName(employees, name);
                    break;

                case 5:
                    Console.Write("Enter Department: ");
                    string dept = Console.ReadLine();

                    // Search employees by department
                    SearchByDepartment(employees, dept);
                    break;

                case 6:
                    Console.Write("Enter City: ");
                    string city = Console.ReadLine();

                    // Search employees by city
                    SearchByCity(employees, city);
                    break;

                case 7:
                    Console.Write("Enter Minimum Experience: ");
                    int exp = Convert.ToInt32(Console.ReadLine());

                    // Search employees by experience
                    SearchByExperience(employees, exp);
                    break;

                case 8:
                    Console.Write("Enter Minimum Salary: ");
                    double min = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter Maximum Salary: ");
                    double max = Convert.ToDouble(Console.ReadLine());

                    // Search employees within salary range
                    SearchBySalary(employees, min, max);
                    break;

                case 9:
                    // Exit the application
                    Console.WriteLine("Thank You!");
                    return;

                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }
        }
    }

    // Displays table heading
    static void DisplayHeader()
    {
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------------------------------------------------");
        Console.WriteLine("ID     Name               Department Designation          Exp   Salary     City");
        Console.WriteLine("----------------------------------------------------------------------------------------------");
    }

    // Displays all employees
    static void DisplayAll(List<Employee> employees)
    {
        DisplayHeader();

        foreach (Employee emp in employees)
        {
            emp.Display();
        }
    }

    // Linear Search by Employee ID
    static void LinearSearch(List<Employee> employees, int id)
    {
        // Check every employee one by one
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

    // Binary Search by Employee ID
    static void BinarySearch(List<Employee> employees, int id)
    {
        // Binary Search requires sorted data
        List<Employee> sorted = employees.OrderBy(e => e.Id).ToList();

        int low = 0;
        int high = sorted.Count - 1;

        while (low <= high)
        {
            // Find middle element
            int mid = (low + high) / 2;

            if (sorted[mid].Id == id)
            {
                DisplayHeader();
                sorted[mid].Display();
                return;
            }
            else if (id < sorted[mid].Id)
            {
                // Search left half
                high = mid - 1;
            }
            else
            {
                // Search right half
                low = mid + 1;
            }
        }

        Console.WriteLine("Employee Not Found.");
    }

    // Search employee by name
    static void SearchByName(List<Employee> employees, string name)
    {
        bool found = false;

        DisplayHeader();

        foreach (Employee emp in employees)
        {
            // Partial name search
            if (emp.Name.ToLower().Contains(name.ToLower()))
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Employee Not Found.");
    }

    // Search employees by department
    static void SearchByDepartment(List<Employee> employees, string department)
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

    // Search employees by city
    static void SearchByCity(List<Employee> employees, string city)
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

    // Search employees with minimum experience
    static void SearchByExperience(List<Employee> employees, int experience)
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

    // Search employees within salary range
    static void SearchBySalary(List<Employee> employees, double min, double max)
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