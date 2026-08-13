using System;

class FibonacciSearch
{
    static int FibonacciSearchMethod(int[] arr, int key)
    {
        int n = arr.Length;

        int fibMMm2 = 0;
        int fibMMm1 = 1;
        int fibM = fibMMm2 + fibMMm1;

        while (fibM < n)
        {
            fibMMm2 = fibMMm1;
            fibMMm1 = fibM;
            fibM = fibMMm2 + fibMMm1;
        }

        int offset = -1;

        while (fibM > 1)
        {
            int i = Math.Min(offset + fibMMm2, n - 1);

            if (arr[i] < key)
            {
                fibM = fibMMm1;
                fibMMm1 = fibMMm2;
                fibMMm2 = fibM - fibMMm1;
                offset = i;
            }
            else if (arr[i] > key)
            {
                fibM = fibMMm2;
                fibMMm1 = fibMMm1 - fibMMm2;
                fibMMm2 = fibM - fibMMm1;
            }
            else
            {
                return i;
            }
        }

        if (fibMMm1 == 1 && offset + 1 < n && arr[offset + 1] == key)
            return offset + 1;

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

        int index = FibonacciSearchMethod(arr, key);

        if (index != -1)
            Console.WriteLine("Element found at index " + index);
        else
            Console.WriteLine("Element not found.");
    }
}