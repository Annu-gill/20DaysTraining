using System;
using System.Diagnostics;

public class SelectionSort
{
    /// <summary>
    /// Sorts the given array in ascending order using the Selection Sort algorithm.
    /// </summary>
    public static void Sort(int[] array)
    {
        // Traverse the array one element at a time.
        for (int i = 0; i < array.Length - 1; i++)
        {
            // Assume the current index contains the smallest element.
            int minIndex = i;

            // Search the remaining unsorted portion of the array.
            for (int j = i + 1; j < array.Length; j++)
            {
                // Update the minimum index if a smaller element is found.
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap only if a smaller element was found.
            if (minIndex != i)
            {
                Swap(array, i, minIndex);
            }
        }
    }

    /// <summary>
    /// Swaps two elements in the array.
    /// </summary>
    private static void Swap(int[] array, int firstIndex, int secondIndex)
    {
        // Store the first element temporarily.
        int temp = array[firstIndex];

        // Move the second element to the first position.
        array[firstIndex] = array[secondIndex];

        // Place the original first element into the second position.
        array[secondIndex] = temp;
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
/// Demonstrates the Selection Sort algorithm.
/// </summary>
public class Program
{
    /// <summary>
    /// Main method of the application.
    /// </summary>
    public static void Main(string[] args)
    {
        // Create an unsorted integer array.
        int[] numbers = { 64, 25, 12, 22, 11 };

        Console.WriteLine("========== Selection Sort ==========\n");

        Console.WriteLine("Original Array:");
        SelectionSort.PrintArray(numbers);

        // Create a Stopwatch object.
        Stopwatch stopwatch = new Stopwatch();

        // Start measuring execution time.
        stopwatch.Start();

        // Sort the array using Selection Sort.
        SelectionSort.Sort(numbers);

        // Stop measuring execution time.
        stopwatch.Stop();

        Console.WriteLine("\nSorted Array:");
        SelectionSort.PrintArray(numbers);

        // Display the execution time in milliseconds.
        Console.WriteLine($"\nExecution Time: {stopwatch.Elapsed.TotalMilliseconds:F6} ms");
    }
}