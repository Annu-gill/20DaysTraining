using System;
using System.Collections.Generic;

// Abstract base class
public abstract class Employee
{
    public string Name { get; }

    public decimal BaseSalary { get; }

    // Constructor
    protected Employee(string name, decimal baseSalary)
    {
        Name = name;
        BaseSalary = baseSalary;
    }


    // Abstract method
    // Every derived class must provide its own implementation.
    public abstract decimal CalculatePay();


    // Concrete method
    // This method works for every subclass.
    public void PrintPaySlip()
    {
        Console.WriteLine($"{Name}: {CalculatePay():C}");
    }

}

// Salaried employee
public class SalariedEmployee : Employee
{
    public SalariedEmployee(string name, decimal baseSalary)
    : base(name, baseSalary)
    {
    }

    // Salaried employees receive their base salary.
    public override decimal CalculatePay()
    {
        return BaseSalary;
    }


}

// Commission employee
public class CommissionEmployee : Employee
{
    public decimal CommissionEarned;


    public CommissionEmployee(
        string name,
        decimal baseSalary,
        decimal commission)
        : base(name, baseSalary)
    {
        CommissionEarned = commission;
    }


    // Commission employees receive salary + commission.
    public override decimal CalculatePay()
    {
        return BaseSalary + CommissionEarned;
    }

}

// Bonus Challenge:
// Manager inherits from SalariedEmployee.
public class ManagerEmployee : SalariedEmployee
{
    public decimal Bonus;

    public ManagerEmployee(
        string name,
        decimal baseSalary,
        decimal bonus)
        : base(name, baseSalary)
    {
        Bonus = bonus;
    }


    // Override CalculatePay again.
    public override decimal CalculatePay()
    {
        return base.CalculatePay() + Bonus;
    }

}

// Lab driver
public class Lab4
{
    public static void Run()
    {
        // Create a list containing different
        // types of employees.
        List<Employee> employees = new List<Employee>
{
new SalariedEmployee(
"Alice",
4500m),

        new CommissionEmployee(
            "Bob",
            3000m,
            200m),

        new CommissionEmployee(
            "Carla",
            3500m,
            650m)
    };


        // Polymorphism:
        // Each object is accessed through
        // an Employee reference.
        foreach (Employee employee in employees)
        {
            employee.PrintPaySlip();
        }


        // Bonus Challenge
        Console.WriteLine();
        Console.WriteLine("-- Bonus Manager --");

        Employee manager = new ManagerEmployee(
            "David",
            5000m,
            1000m);

        manager.PrintPaySlip();
    }
}
