using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    public static long aVeryBigSum(List<long> ar)
    {
        long sum = 0;

        foreach (long number in ar)
        {
            sum += number;
        }

        return sum;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        // Read number of elements
        int n = Convert.ToInt32(Console.ReadLine());

        // Read array
        List<long> ar = Console.ReadLine()
            .Split(' ')
            .Select(x => Convert.ToInt64(x))
            .ToList();

        // Calculate sum
        long result = Result.aVeryBigSum(ar);

        // Print result
        Console.WriteLine(result);
    }
}

