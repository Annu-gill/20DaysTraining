// using System;

// public struct Point
// {
//     public int X;
//     public int Y;
//     public Point(int x, int y)
//     {
//         X = x;
//         Y = y;
//     }
//     public override string ToString()
//     {
//         return $" {X} {Y}";
//     }
// }
// class Program
// {
//     static void Main(string[] args)
//     {
//         Point a = new Point(22, 55);
//         Point b = a;
//         b.X = 99;
//         Console.WriteLine(a);
//         Console.WriteLine(b);
//         Console.ReadLine();
//     }
// }



using System;

public class Employee
{
    private decimal _salary;

    public string Name = string.Empty;

    protected string Department = "General";

    internal string EmployeeId = "E-1001";

    protected internal void SetDepartment(string department)
    {
        Department = department;
    }

    public void ShowSalary()
    {
        Console.WriteLine($"Salary: {_salary}");
    }

    private protected void AdjustSalary(decimal salary)
    {
        _salary = salary;
    }
}

public class Manager : Employee
{
    public void PrintDetails()
    {
        Name = "Annu";

        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Department: {Department}");

        SetDepartment("Engineering");

        Console.WriteLine($"Updated Department: {Department}");

        AdjustSalary(500000);

        ShowSalary();
        Console.WriteLine($"Employee ID: {EmployeeId}");
    }
}

class Program
{
    static void Main()
    {
        Manager manager = new Manager();
        manager.PrintDetails();
    }
}