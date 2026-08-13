using System;

class LinearSearch
{
    static int LinearSearchMethod(int[] arr, int key)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == key)
                return i;
        }

        return -1;
    }

    static void Main()
    {
        int[] arr = { 12, 25, 18, 45, 30, 60, 50 };

        Console.WriteLine("Array Elements:");
        foreach (int num in arr)
            Console.Write(num + " ");

        Console.Write("\n\nEnter element to search: ");
        int key = Convert.ToInt32(Console.ReadLine());

        int index = LinearSearchMethod(arr, key);

        if (index != -1)
            Console.WriteLine("Element found at index " + index);
        else
            Console.WriteLine("Element not found.");
    }
}