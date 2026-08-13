using System;

class JumpSearch
{
    static int JumpSearchMethod(int[] arr, int key)
    {
        int n = arr.Length;
        int step = (int)Math.Sqrt(n);
        int prev = 0;

        while (prev < n && arr[Math.Min(step, n) - 1] < key)
        {
            prev = step;
            step += (int)Math.Sqrt(n);

            if (prev >= n)
                return -1;
        }

        while (prev < Math.Min(step, n))
        {
            if (arr[prev] == key)
                return prev;

            prev++;
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

        int index = JumpSearchMethod(arr, key);

        if (index != -1)
            Console.WriteLine("Element found at index " + index);
        else
            Console.WriteLine("Element not found.");
    }
}