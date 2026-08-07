using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    /*
     * Complete the 'icecreamParlor' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER m
     *  2. INTEGER_ARRAY arr
     */

    public static List<int> icecreamParlor(int m, List<int> arr)
    {
        // Store price -> index
        Dictionary<int, int> priceIndex =
            new Dictionary<int, int>();

        for (int i = 0; i < arr.Count; i++)
        {
            int price = arr[i];

            // Price needed to complete the total
            int complement = m - price;

            // Check if complement was already seen
            if (priceIndex.ContainsKey(complement))
            {
                int firstIndex = priceIndex[complement] + 1;
                int secondIndex = i + 1;

                return new List<int>
                {
                    firstIndex,
                    secondIndex
                };
            }

            // Store current price and its 0-based index
            if (!priceIndex.ContainsKey(price))
            {
                priceIndex[price] = i;
            }
        }

        return new List<int>();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine()!.Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int m = Convert.ToInt32(Console.ReadLine()!.Trim());

            int n = Convert.ToInt32(Console.ReadLine()!.Trim());

            List<int> arr = Console.ReadLine()!
                .Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> result = Result.icecreamParlor(m, arr);

            Console.WriteLine(String.Join(" ", result));
        }
    }
}