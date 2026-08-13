using System;
using System.Diagnostics;
using System.Text;

class Lab2
{
    // ----------------------------------------
    // Build string using +=
    // ----------------------------------------
    static string BuildWithString(int count)
    {
        string result = "";

        for (int i = 0; i < count; i++)
        {
            result += i.ToString();
        }

        return result;
    }

    // ----------------------------------------
    // Build string using StringBuilder
    // ----------------------------------------
    static string BuildWithStringBuilder(int count)
    {
        StringBuilder result = new StringBuilder(count * 5);

        for (int i = 0; i < count; i++)
        {
            result.Append(i.ToString());
        }

        return result.ToString();
    }

    // ----------------------------------------
    // Run Lab 2
    // ----------------------------------------
    public static void Run()
    {
        int count = 50000;

        Console.WriteLine("StringBuilder Performance Benchmark");
        Console.WriteLine("-----------------------------------");

        // ----------------------------------------
        // String concatenation timing
        // ----------------------------------------

        Stopwatch stopwatch = Stopwatch.StartNew();

        BuildWithString(count);

        stopwatch.Stop();

        long stringTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine(
            $"String concatenation ({count:N0} items): {stringTime} ms"
        );

        // ----------------------------------------
        // StringBuilder timing
        // ----------------------------------------

        stopwatch.Restart();

        BuildWithStringBuilder(count);

        stopwatch.Stop();

        long stringBuilderTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine(
            $"StringBuilder ({count:N0} items): {stringBuilderTime} ms"
        );

        // ----------------------------------------
        // Calculate ratio
        // ----------------------------------------

        if (stringBuilderTime > 0)
        {
            double ratio =
                (double)stringTime / stringBuilderTime;

            Console.WriteLine(
                $"StringBuilder is roughly {ratio:F1}x faster on this run"
            );
        }
        else
        {
            Console.WriteLine(
                "StringBuilder completed too quickly to calculate an accurate ratio."
            );
        }

        // ----------------------------------------
        // Test with 200,000 items
        // ----------------------------------------

        Console.WriteLine();
        Console.WriteLine("Testing with 200,000 items...");
        Console.WriteLine("-----------------------------------");

        count = 200000;

        // String timing
        stopwatch.Restart();

        BuildWithString(count);

        stopwatch.Stop();

        stringTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine(
            $"String concatenation ({count:N0} items): {stringTime} ms"
        );

        // StringBuilder timing
        stopwatch.Restart();

        BuildWithStringBuilder(count);

        stopwatch.Stop();

        stringBuilderTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine(
            $"StringBuilder ({count:N0} items): {stringBuilderTime} ms"
        );

        // Ratio
        if (stringBuilderTime > 0)
        {
            double ratio =
                (double)stringTime / stringBuilderTime;

            Console.WriteLine(
                $"StringBuilder is roughly {ratio:F1}x faster on this run"
            );
        }
        else
        {
            Console.WriteLine(
                "StringBuilder completed too quickly to calculate an accurate ratio."
            );
        }
    }
}