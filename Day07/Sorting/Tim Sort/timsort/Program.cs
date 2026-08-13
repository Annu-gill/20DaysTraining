using System;

class TimSort
{
    // Minimum run size
    const int RUN = 32;

    // Insertion Sort
    static void InsertionSort(int[] arr, int left, int right)
    {
        for (int i = left + 1; i <= right; i++)
        {
            int temp = arr[i];
            int j = i - 1;

            while (j >= left && arr[j] > temp)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = temp;
        }
    }

    // Merge two sorted subarrays
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int len1 = mid - left + 1;
        int len2 = right - mid;

        int[] leftArr = new int[len1];
        int[] rightArr = new int[len2];

        for (int i = 0; i < len1; i++)
            leftArr[i] = arr[left + i];

        for (int i = 0; i < len2; i++)
            rightArr[i] = arr[mid + 1 + i];

        int x = 0, y = 0, k = left;

        while (x < len1 && y < len2)
        {
            if (leftArr[x] <= rightArr[y])
                arr[k++] = leftArr[x++];
            else
                arr[k++] = rightArr[y++];
        }

        while (x < len1)
            arr[k++] = leftArr[x++];

        while (y < len2)
            arr[k++] = rightArr[y++];
    }

    // Tim Sort
    static void TimSortAlgorithm(int[] arr)
    {
        int n = arr.Length;

        // Step 1: Sort individual runs using Insertion Sort
        for (int i = 0; i < n; i += RUN)
        {
            InsertionSort(arr, i, Math.Min(i + RUN - 1, n - 1));
        }

        // Step 2: Merge runs
        for (int size = RUN; size < n; size = 2 * size)
        {
            for (int left = 0; left < n; left += 2 * size)
            {
                int mid = left + size - 1;

                if (mid >= n - 1)
                    continue;

                int right = Math.Min(left + 2 * size - 1, n - 1);

                Merge(arr, left, mid, right);
            }
        }
    }

    static void Main()
    {
        int[] arr = { 29, 4, 71, 15, 92, 8, 46, 33, 60, 1 };

        Console.WriteLine("Tim Sort");
        Console.WriteLine("Before: " + string.Join(", ", arr));

        TimSortAlgorithm(arr);

        Console.WriteLine("After : " + string.Join(", ", arr));
    }
}