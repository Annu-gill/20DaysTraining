using System;

class ExponentialSearch
{
    static int BinarySearch(int[] arr, int left, int right, int key)
    {
        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (arr[mid] == key)
                return mid;

            if (arr[mid] < key)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    static int ExponentialSearchMethod(int[] arr, int key)
    {
        int n = arr.Length;

        if (arr[0] == key)
            return 0;

        int i = 1;

        while (i < n && arr[i] <= key)
            i = i * 2;

        return BinarySearch(arr, i / 2, Math.Min(i, n - 1), key);
    }

    static void Main()
    {
        int[] arr = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

        Console.WriteLine("Sorted Array:");
        foreach (int num in arr)
            Console.Write(num + " ");

        Console.Write("\n\nEnter element to search: ");
        int key = Convert.ToInt32(Console.ReadLine());

        int index = ExponentialSearchMethod(arr, key);

        if (index != -1)
            Console.WriteLine("Element found at index " + index);
        else
            Console.WriteLine("Element not found.");
    }
}