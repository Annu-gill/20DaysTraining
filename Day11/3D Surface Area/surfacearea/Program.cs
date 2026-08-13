using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    public static int surfaceArea(List<List<int>> A)
    {
        int H = A.Count;
        int W = A[0].Count;

        int area = 0;

        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                int current = A[i][j];

                // Top and Bottom
                area += 2;

                // Up
                int up = (i > 0) ? A[i - 1][j] : 0;
                area += Math.Max(0, current - up);

                // Down
                int down = (i < H - 1) ? A[i + 1][j] : 0;
                area += Math.Max(0, current - down);

                // Left
                int left = (j > 0) ? A[i][j - 1] : 0;
                area += Math.Max(0, current - left);

                // Right
                int right = (j < W - 1) ? A[i][j + 1] : 0;
                area += Math.Max(0, current - right);
            }
        }

        return area;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        // Read rows and columns
        string[] firstInput = Console.ReadLine()
            .Trim()
            .Split(' ');

        int H = Convert.ToInt32(firstInput[0]);
        int W = Convert.ToInt32(firstInput[1]);

        // Read the 2D array
        List<List<int>> A = new List<List<int>>();

        for (int i = 0; i < H; i++)
        {
            List<int> row = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(x => Convert.ToInt32(x))
                .ToList();

            A.Add(row);
        }

        // Calculate surface area
        int result = Result.surfaceArea(A);

        // Print result
        Console.WriteLine(result);
    }
}

