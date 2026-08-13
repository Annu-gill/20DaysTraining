using System;

class NestedRecursion
{
    static int Calculate(int n)
    {
        // Base case
        if (n > 100)
        {
            return n - 10;
        }

        // Nested recursive call
        return Calculate(Calculate(n + 11));
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int result = Calculate(n);

        Console.WriteLine("Result: " + result);
    }
}