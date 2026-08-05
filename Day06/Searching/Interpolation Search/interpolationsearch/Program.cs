using System;

class InterpolationSearch
{
    static int InterpolationSearchMethod(int[] arr, int key)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high &&
               key >= arr[low] &&
               key <= arr[high])
        {
            if (low == high)
            {
                if (arr[low] == key)
                    return low;
                return -1;
            }

            int pos = low + ((key - arr[low]) * (high - low)) /
                             (arr[high] - arr[low]);

            if (arr[pos] == key)
                return pos;

            if (arr[pos] < key)
                low = pos + 1;
            else
                high = pos - 1;
        }

        return -1;
    }

    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

        Console.WriteLine("Sorted Array:");
        foreach (int num in arr)
            Console.Write(num + " ");

        Console.Write("\n\nEnter element to search: ");
        int key = Convert.ToInt32(Console.ReadLine());

        int index = InterpolationSearchMethod(arr, key);

        if (index != -1)
            Console.WriteLine("Element found at index " + index);
        else
            Console.WriteLine("Element not found.");
    }
}