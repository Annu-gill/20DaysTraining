using System;
class Program
{
    static void Main(string[] args)
    {
        // // int[] numbers = { 1, 2, 3, 4, 5 };

        // // find sum of numbers in an array
        // int sum = 0;
        // for (int i = 0; i < numbers.Length; i++)
        // {
        //     sum += numbers[i];
        // }
        // Console.WriteLine("Sum is: " + sum);

        // // reverse an array
        // Array.Reverse(numbers);

        // Console.WriteLine("Reversed Array:");
        // foreach (int num in numbers)
        // {
        //     Console.Write(num + " ");
        // }

        // //find max number in an array
        // int max = numbers[0];

        // for (int i = 1; i < numbers.Length; i++)
        // {
        //     if (numbers[i] > max)
        //     {
        //         max = numbers[i];
        //     }
        // }

        // Console.WriteLine("\nMaximum number is: " + max);

        // //count of even and odd numbers by printing the even and odd numbers
        // int evenCount = 0;
        // int oddCount = 0;
        // Console.WriteLine("Even numbers:");
        // foreach (int num in numbers)
        // {
        //     if (num % 2 == 0)
        //     {
        //         Console.Write(num + " ");
        //         evenCount++;
        //     }
        // }
        // Console.WriteLine("Odd numbers: ");
        // foreach (int num in numbers)
        // {
        //     if (num % 2 != 0)
        //     {
        //         Console.Write(num + " ");
        //         oddCount++;
        //     }
        // }
        // Console.WriteLine("Even count is: " + evenCount);
        // Console.WriteLine("Odd count is: " + oddCount);

        // // print alternative numbers
        // Console.WriteLine("Alternative elements: ");
        // for (int i = 0; i < numbers.Length; i += 2)
        // {
        //     Console.WriteLine(numbers[i] + " ");
        // }

        // // second largest element in array
        // int largest = int.MinValue;
        // int second_largest = int.MinValue;

        // foreach (int num in numbers)
        // {
        //     if (num > largest)
        //     {
        //         second_largest = largest;
        //         largest = num;
        //     }
        //     else if (num > second_largest && num != largest)
        //     {
        //         second_largest = num;
        //     }
        // }
        // Console.WriteLine("Second Largest Number: " + second_largest);


        // // Merge 2 arrays
        // int[] array1 = { 1, 2, 3, 4 };
        // int[] array2 = { 5, 6, 7, 8 };
        // int[] mergedArray = new int[array1.Length + array2.Length];
        // int k = 0;
        // foreach (int num in array1)
        // {
        //     mergedArray[k] = num;
        //     k++;
        // }
        // foreach (int num in array2)
        // {
        //     mergedArray[k] = num;
        //     k++;
        // }
        // Console.WriteLine("Merged Array:");
        // foreach (int num in mergedArray)
        // {
        //     Console.Write(num + " ");
        // }


        // find count of duplicate numbers and mention the duplicate numbers

        // int[] numbers = { 1, 2, 3, 2, 4, 5, 3, 6, 2 };

        // Console.WriteLine("Duplicate Numbers:");

        // for (int i = 0; i < numbers.Length; i++)
        // {
        //     int count = 1;
        //     bool isDuplicate = false;

        //     for (int j = 0; j < i; j++)
        //     {
        //         if (numbers[i] == numbers[j])
        //         {
        //             isDuplicate = true;
        //             break;
        //         }
        //     }

        //     if (!isDuplicate)
        //     {
        //         for (int j = i + 1; j < numbers.Length; j++)
        //         {
        //             if (numbers[i] == numbers[j])
        //             {
        //                 count++;
        //             }
        //         }

        //         if (count > 1)
        //         {
        //             Console.WriteLine(numbers[i] + " is duplicated " + count + " times");
        //         }
        //     }
        // }

        // // remove duplicate elements
        // int[] numbers = { 1, 2, 3, 2, 4, 5, 3, 6, 2 };

        // Console.WriteLine("Array after removing duplicates:");

        // for (int i = 0; i < numbers.Length; i++)
        // {
        //     bool isDuplicate = false;

        //     for (int j = 0; j < i; j++)
        //     {
        //         if (numbers[i] == numbers[j])
        //         {
        //             isDuplicate = true;
        //             break;
        //         }
        //     }

        //     if (!isDuplicate)
        //     {
        //         Console.Write(numbers[i] + " ");
        //     }
        // }

        // reverse an array
        int[] numbers = { 1, 2, 3, 4, 5 };
        Array.Reverse(numbers);

        Console.WriteLine("Reversed Array:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }

        string text = "Hello, Welcome to Capgemini!";
        char[] chars = text.ToCharArray();
        Console.Write("\nReversed String: ");
        Array.Reverse(chars);

       Console.WriteLine(new string(chars));
    }
}