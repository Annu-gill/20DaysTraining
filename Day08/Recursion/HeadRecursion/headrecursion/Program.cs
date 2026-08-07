using System;

class HeadRecursion
{
    static void SumDigitsReversed(int n)
    {
        // Base case
        if (n == 0)
        {
            return;
        }

        // Head recursion: recursive call first
        SumDigitsReversed(n / 10);

        // Print digit while returning from recursion
        Console.Write(n % 10);
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digits in reverse order: ");

        SumDigitsReversed(n);

        Console.WriteLine();
    }
}