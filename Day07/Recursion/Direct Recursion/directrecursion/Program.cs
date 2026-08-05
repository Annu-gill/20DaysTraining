using System;

/// <summary>
/// Demonstrates Direct Recursion using Factorial.
/// </summary>
class FactorialRecursion
{
    /// <summary>
    /// Calculates factorial of a number.
    /// </summary>
    /// <param name="n">Input number.</param>
    /// <returns>Factorial value.</returns>
    static int Factorial(int n)
    {
        // Base Case
        if (n == 0 || n == 1)
            return 1;

        // Recursive Call
        return n * Factorial(n - 1);
    }

    /// <summary>
    /// Entry point of the program.
    /// </summary>
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int result = Factorial(number);

        Console.WriteLine("\nFactorial = " + result);

        Console.ReadKey();
    }
}