using System;
using System.Diagnostics;

/// <summary>
/// Provides methods for sorting integer arrays using the Insertion Sort algorithm.
/// </summary>
public class InsertionSort
{
    /// <summary>
    /// Sorts the array in ascending order using Insertion Sort.
    /// </summary>
    public static void Sort(int[] array)
    {
        // Start from the second element.
        for (int i = 1; i < array.Length; i++)
        {
            // Store the current element to be inserted.
            int key = array[i];

            // Initialize the previous index.
            int j = i - 1;

            // Shift elements greater than the key one position to the right.
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }

            // Insert the key into its correct position.
            array[j + 1] = key;
        }
    }

    /// <summary>
    /// Displays the elements of the array.
    /// </summary>
    public static void PrintArray(int[] array)
    {
        // Print each element separated by spaces.
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}

/// <summary>
/// Entry point of the application.
/// Demonstrates the Insertion Sort algorithm.
/// </summary>
public class Program
{
    /// <summary>
    /// Main method of the application.
    /// </summary>
    public static void Main(string[] args)
    {
        // Create an unsorted integer array.
        int[] numbers = { 12, 11, 13, 5, 6 };

        Console.WriteLine("========== Insertion Sort ==========\n");

        Console.WriteLine("Original Array:");
        InsertionSort.PrintArray(numbers);

        // Create a Stopwatch object.
        Stopwatch stopwatch = new Stopwatch();

        // Start measuring execution time.
        stopwatch.Start();

        // Sort the array using Insertion Sort.
        InsertionSort.Sort(numbers);

        // Stop measuring execution time.
        stopwatch.Stop();

        Console.WriteLine("\nSorted Array:");
        InsertionSort.PrintArray(numbers);

        // Display the execution time in milliseconds.
        Console.WriteLine($"\nExecution Time: {stopwatch.Elapsed.TotalMilliseconds:F6} ms");
    }
}