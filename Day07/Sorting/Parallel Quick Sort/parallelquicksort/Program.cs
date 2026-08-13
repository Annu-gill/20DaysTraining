using System;
using System.Threading.Tasks;

class ParallelQuickSort
{
    // Partition Method
    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];   // Last element as pivot
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    // Swap Method
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    // Parallel Quick Sort
    static void ParallelQuickSortAlgorithm(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            // For small arrays, use normal recursion
            if (high - low < 1000)
            {
                ParallelQuickSortAlgorithm(arr, low, pivotIndex - 1);
                ParallelQuickSortAlgorithm(arr, pivotIndex + 1, high);
            }
            else
            {
                // Sort both partitions in parallel
                Parallel.Invoke(
                    () => ParallelQuickSortAlgorithm(arr, low, pivotIndex - 1),
                    () => ParallelQuickSortAlgorithm(arr, pivotIndex + 1, high)
                );
            }
        }
    }

    static void Main()
    {
        int[] arr = { 29, 4, 71, 15, 92, 8, 46, 33, 60, 1 };

        Console.WriteLine("Parallel Quick Sort");
        Console.WriteLine("Stable: False");
        Console.WriteLine("Before: " + string.Join(", ", arr));

        ParallelQuickSortAlgorithm(arr, 0, arr.Length - 1);

        Console.WriteLine("After : " + string.Join(", ", arr));
    }
}