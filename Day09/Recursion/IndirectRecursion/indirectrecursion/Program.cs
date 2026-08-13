using System;

class IndirectRecursion
{
    static bool IsPositiveChain(int n)
    {
        // Base case
        if (n == 0)
        {
            return true;
        }

        // Positive number: move -1 toward zero
        if (n > 0)
        {
            return IsNegativeChain(n - 1);
        }

        // Negative number: move +1 toward zero
        return IsNegativeChain(n + 1);
    }

    static bool IsNegativeChain(int n)
    {
        // Base case
        if (n == 0)
        {
            return true;
        }

        // Move one step toward zero
        if (n > 0)
        {
            return IsPositiveChain(n - 1);
        }

        return IsPositiveChain(n + 1);
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        bool result;

        if (n >= 0)
        {
            result = IsPositiveChain(n);
        }
        else
        {
            result = IsNegativeChain(n);
        }

        Console.WriteLine("Reaches zero: " + result);
    }
}