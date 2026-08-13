using System;

class TreeRecursion
{
    static int CountPaths(int rows, int cols)
    {
        // Base case: reached the destination
        if (rows == 1 || cols == 1)
        {
            return 1;
        }

        // Move down + Move right
        return CountPaths(rows - 1, cols) +
               CountPaths(rows, cols - 1);
    }

    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        int result = CountPaths(rows, cols);

        Console.WriteLine("Number of paths: " + result);
    }
}