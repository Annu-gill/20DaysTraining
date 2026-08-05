using System;
using System.Diagnostics;

/// <summary>
/// Provides methods for sorting integer arrays using the Merge Sort algorithm.
/// </summary>
public class MergeSort
{
    /// <summary>
    /// Sorts the array using Merge Sort.
    /// </summary>
    public static void Sort(int[] array)
    {
        int[] temp = new int[array.Length];
        MergeSortRecursive(array, temp, 0, array.Length - 1);
    }

    /// <summary>
    /// Recursively divides the array into smaller subarrays.
    /// </summary>
    private static void MergeSortRecursive(int[] array, int[] temp, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            // Sort left half
            MergeSortRecursive(array, temp, left, mid);

            // Sort right half
            MergeSortRecursive(array, temp, mid + 1, right);

            // Merge the sorted halves
            Merge(array, temp, left, mid, right);
        }
    }

    /// <summary>
    /// Merges two sorted subarrays.
    /// </summary>
    private static void Merge(int[] array, int[] temp, int left, int mid, int right)
    {
        int i = left;
        int j = mid + 1;
        int k = left;

        // Compare elements from both halves
        while (i <= mid && j <= right)
        {
            if (array[i] <= array[j])
            {
                temp[k] = array[i];
                i++;
            }
            else
            {
                temp[k] = array[j];
                j++;
            }
            k++;
        }

        // Copy remaining elements of left half
        while (i <= mid)
        {
            temp[k] = array[i];
            i++;
            k++;
        }

        // Copy remaining elements of right half
        while (j <= right)
        {
            temp[k] = array[j];
            j++;
            k++;
        }

        // Copy merged elements back into original array
        for (int index = left; index <= right; index++)
        {
            array[index] = temp[index];
        }
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
/// Demonstrates the Merge Sort algorithm.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("========== Merge Sort ==========\n");

        Console.WriteLine("Original Array:");
        MergeSort.PrintArray(numbers);

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        MergeSort.Sort(numbers);

        stopwatch.Stop();

        Console.WriteLine("\nSorted Array:");
        MergeSort.PrintArray(numbers);

        Console.WriteLine("\nPerformance");
        Console.WriteLine($"Execution Time : {stopwatch.Elapsed.TotalMilliseconds:F6} ms");
    }
}