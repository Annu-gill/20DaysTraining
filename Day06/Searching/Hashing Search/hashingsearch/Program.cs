using System;
using System.Collections.Generic;

class HashingSearch
{
    static void Main()
    {
        int[] arr = { 15, 25, 35, 45, 55, 65, 75 };

        Dictionary<int, int> hashTable = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            hashTable[arr[i]] = i;
        }

        Console.WriteLine("Array Elements:");
        foreach (int num in arr)
            Console.Write(num + " ");

        Console.Write("\n\nEnter element to search: ");
        int key = Convert.ToInt32(Console.ReadLine());

        if (hashTable.ContainsKey(key))
        {
            Console.WriteLine("Element found at index " + hashTable[key]);
        }
        else
        {
            Console.WriteLine("Element not found.");
        }
    }
}