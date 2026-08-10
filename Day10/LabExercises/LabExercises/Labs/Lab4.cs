using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}

class Lab4
{
    public static void Run()
    {
        // ----------------------------------------
        // Raw employee data
        // ----------------------------------------

        const string rawData = @"
john smith|engineering|72000
MARY jones|sales|65000

ravi KUMAR|engineering|81000
";

        // ----------------------------------------
        // Variables for employee data
        // ----------------------------------------

        List<Employee> employees = new List<Employee>();

        // ----------------------------------------
        // Counters for StringBuilder Append calls
        // and string concatenations
        // ----------------------------------------

        int appendCount = 0;
        int concatenationCount = 0;

        // ----------------------------------------
        // Split raw data into rows
        // ----------------------------------------

        string[] rows = rawData.Split(
            '\n',
            StringSplitOptions.None
        );

        foreach (string row in rows)
        {
            // Remove unnecessary spaces/newline characters
            string cleanRow = row.Trim();

            // Skip blank rows
            if (string.IsNullOrWhiteSpace(cleanRow))
            {
                continue;
            }

            // ----------------------------------------
            // Split each row using '|'
            // ----------------------------------------

            string[] fields = cleanRow.Split('|');

            if (fields.Length != 3)
            {
                continue;
            }

            string name = fields[0].Trim();
            string department = fields[1].Trim();
            string salaryText = fields[2].Trim();

            // ----------------------------------------
            // Convert salary string to decimal
            // ----------------------------------------

            if (!decimal.TryParse(
                    salaryText,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal salary))
            {
                continue;
            }

            // ----------------------------------------
            // Create Employee object
            // ----------------------------------------

            Employee employee = new Employee
            {
                Name = StringToolkit.ToTitleCase(name),
                Department = StringToolkit.ToTitleCase(department),
                Salary = salary
            };

            employees.Add(employee);
        }

        // ----------------------------------------
        // Calculate total salary
        // ----------------------------------------

        decimal totalSalary = 0;

        foreach (Employee employee in employees)
        {
            totalSalary += employee.Salary;
        }

        // ----------------------------------------
        // Build report using StringBuilder
        // ----------------------------------------

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("==============================================");
        appendCount++;

        sb.AppendLine("          EMPLOYEE COMPENSATION REPORT");
        appendCount++;

        sb.AppendLine("==============================================");
        appendCount++;

        sb.AppendLine();
        appendCount++;

        // Header
        string header =
            "Name".PadRight(20) +
            "Department".PadRight(18) +
            "Salary".PadLeft(12);

        sb.AppendLine(header);
        appendCount++;

        sb.AppendLine("----------------------------------------------");
        appendCount++;

        // ----------------------------------------
        // Add employee rows
        // ----------------------------------------

        foreach (Employee employee in employees)
        {
            string employeeLine =
                employee.Name.PadRight(20) +
                employee.Department.PadRight(18) +
                employee.Salary.ToString(
                    "N2",
                    CultureInfo.InvariantCulture
                ).PadLeft(12);

            sb.AppendLine(employeeLine);
            appendCount++;
        }

        // ----------------------------------------
        // Footer
        // ----------------------------------------

        sb.AppendLine("----------------------------------------------");
        appendCount++;

        string footer =
            $"Employees: {employees.Count}    " +
            $"Total Salary: {totalSalary:N0}";

        sb.AppendLine(footer);
        appendCount++;

        sb.AppendLine("==============================================");
        appendCount++;

        // ----------------------------------------
        // Print final report
        // ----------------------------------------

        Console.WriteLine(sb.ToString());

        // ----------------------------------------
        // Print performance information
        // ----------------------------------------

        Console.WriteLine(
            $"StringBuilder Append calls: {appendCount}"
        );

        Console.WriteLine(
            $"String concatenations in loops: {concatenationCount}"
        );
    }
}