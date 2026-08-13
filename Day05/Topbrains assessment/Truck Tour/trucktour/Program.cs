using System;
using System.Collections.Generic;

class Program
{
    // Function to find the starting petrol pump
    static int TruckTour(List<List<int>> petrolPumps)
    {
        int start = 0;
        int currentFuel = 0;
        int totalFuel = 0;

        for (int i = 0; i < petrolPumps.Count; i++)
        {
            int petrol = petrolPumps[i][0];
            int distance = petrolPumps[i][1];

            int balance = petrol - distance;

            currentFuel += balance;
            totalFuel += balance;

            // If truck cannot reach next pump,
            // choose the next pump as the new start.
            if (currentFuel < 0)
            {
                start = i + 1;
                currentFuel = 0;
            }
        }

        if (totalFuel >= 0)
            return start;
        else
            return -1;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of petrol pumps: ");
        int n = Convert.ToInt32(Console.ReadLine());

        List<List<int>> petrolPumps = new List<List<int>>();

        Console.WriteLine("Enter petrol and distance for each pump:");

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            int petrol = Convert.ToInt32(input[0]);
            int distance = Convert.ToInt32(input[1]);

            petrolPumps.Add(new List<int> { petrol, distance });
        }

        int result = TruckTour(petrolPumps);

        Console.WriteLine("\nStarting Petrol Pump Index: " + result);
    }
}