using System;
using System.Diagnostics;

/// <summary>
/// Provides methods for sorting integer arrays using the Bubble Sort algorithm.
/// </summary>
public class BubbleSort
{
    /// <summary>
    /// Sorts the given array in ascending order using Bubble Sort.
    /// </summary>
    public static void Sort(int[] array)
    {
        // Traverse through the array.
        for (int i = 0; i < array.Length - 1; i++)
        {
            // Flag to determine whether a swap occurred.
            bool swapped = false;

            // Compare adjacent elements.
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                // Swap if elements are in the wrong order.
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;

                    swapped = true;
                }
            }

            // If no swapping occurred, the array is already sorted.
            if (!swapped)
            {
                break;
            }
        }
    }

    /// <summary>
    /// Prints all elements of the array.
    /// </summary>
    public static void PrintArray(int[] array)
    {
        // Display each element.
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}

/// <summary>
/// Entry point of the application.
/// Demonstrates the Bubble Sort algorithm.
/// </summary>
public class Program
{
    /// <summary>
    /// Main method of the application.
    /// </summary>
    public static void Main(string[] args)
    {
        // Create an unsorted integer array.
        int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

        // Display the title.
        Console.WriteLine("Bubble Sort");

        // Display the original array.
        Console.WriteLine("Original Array:");
        BubbleSort.PrintArray(numbers);

        // Create a Stopwatch object to measure execution time.
        Stopwatch stopwatch = new Stopwatch();

        // Start measuring time.
        stopwatch.Start();

        // Perform Bubble Sort.
        BubbleSort.Sort(numbers);

        // Stop measuring time.
        stopwatch.Stop();

        // Display the sorted array.
        Console.WriteLine("\nSorted Array:");
        BubbleSort.PrintArray(numbers);

        // Display the actual execution time measured by the compiler/runtime.
        Console.WriteLine("\nPerformance");
        
        Console.WriteLine($"Execution Time : {stopwatch.Elapsed.TotalMilliseconds:F6} ms");
    }
}