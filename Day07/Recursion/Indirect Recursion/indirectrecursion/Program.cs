using System;

/// <summary>
/// Demonstrates Indirect Recursion using Even and Odd.
/// </summary>
class IndirectRecursion
{
    static void Even(int n)
    {
        // Base Case
        if (n == 0)
        {
            Console.WriteLine("The number is Even.");
            return;
        }

        // Call Odd function
        Odd(n - 1);
    }

    static void Odd(int n)
    {
        // Base Case
        if (n == 0)
        {
            Console.WriteLine("The number is Odd.");
            return;
        }

        // Call Even function
        Even(n - 1);
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        // Always start with Even()
        Even(number);

        Console.ReadKey();
    }
}