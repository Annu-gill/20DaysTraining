using System;

class BinarySearch
{
    static int BinarySearchMethod(int[] arr, int key)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == key)
                return mid;

            if (key < arr[mid])
                high = mid - 1;
            else
                low = mid + 1;
        }

        return -1;
    }

    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80 };

        Console.WriteLine("Sorted Array:");
        foreach (int num in arr)
            Console.Write(num + " ");

        Console.Write("\n\nEnter element to search: ");
        int key = Convert.ToInt32(Console.ReadLine());

        int index = BinarySearchMethod(arr, key);

        if (index != -1)
            Console.WriteLine("Element found at index " + index);
        else
            Console.WriteLine("Element not found.");
    }
}