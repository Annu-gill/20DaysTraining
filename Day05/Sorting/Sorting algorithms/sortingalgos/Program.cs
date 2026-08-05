using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== Sorting Menu =====");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Selection Sort");
            Console.WriteLine("3. Insertion Sort");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 4)
            {
                Console.WriteLine("Thank you, exiting program.");
                break;
            }

            int[] arr = { 29, 4, 71, 15, 92, 8, 46, 33, 60, 1 };

            Console.WriteLine("\nBefore Sorting:");
            PrintArray(arr);

            switch (choice)
            {
                case 1:
                    BubbleSort(arr);
                    Console.WriteLine("\nAfter Bubble Sort:");
                    PrintArray(arr);
                    break;

                case 2:
                    SelectionSort(arr);
                    Console.WriteLine("\nAfter Selection Sort:");
                    PrintArray(arr);
                    break;

                case 3:
                    InsertionSort(arr);
                    Console.WriteLine("\nAfter Insertion Sort:");
                    PrintArray(arr);
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    // Bubble Sort
    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Selection Sort
    static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int min = i;

            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }

            int temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
        }
    }

    // Insertion Sort
    static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    // Print Array
    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}