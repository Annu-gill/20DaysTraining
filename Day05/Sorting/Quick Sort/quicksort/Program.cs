using System;
using System.Diagnostics;

/// <summary>
/// Provides methods for sorting integer arrays using the Quick Sort algorithm.
/// </summary>
public class QuickSort
{
    /// <summary>
    /// Sorts the array using Quick Sort.
    /// </summary>
    public static void Sort(int[] array)
    {
        QuickSortRecursive(array, 0, array.Length - 1);
    }

    /// <summary>
    /// Recursively sorts the array.
    /// </summary>
    private static void QuickSortRecursive(int[] array, int low, int high)
    {
        if (low < high)
        {
            // Find the pivot index
            int pivotIndex = Partition(array, low, high);

            // Sort left subarray
            QuickSortRecursive(array, low, pivotIndex - 1);

            // Sort right subarray
            QuickSortRecursive(array, pivotIndex + 1, high);
        }
    }

    /// <summary>
    /// Partitions the array around a pivot element.
    /// </summary>
    private static int Partition(int[] array, int low, int high)
    {
        // Choose the last element as pivot
        int pivot = array[high];

        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;

                // Swap array[i] and array[j]
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        // Place the pivot in its correct position
        int swap = array[i + 1];
        array[i + 1] = array[high];
        array[high] = swap;

        return i + 1;
    }

    /// <summary>
    /// Prints the array.
    /// </summary>
    public static void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}

/// <summary>
/// Entry point of the application.
/// Demonstrates the Quick Sort algorithm.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("========== Quick Sort ==========\n");

        Console.WriteLine("Original Array:");
        QuickSort.PrintArray(numbers);

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        QuickSort.Sort(numbers);

        stopwatch.Stop();

        Console.WriteLine("\nSorted Array:");
        QuickSort.PrintArray(numbers);

        Console.WriteLine("\nPerformance");
        Console.WriteLine($"Execution Time : {stopwatch.Elapsed.TotalMilliseconds:F6} ms");
    }
}
