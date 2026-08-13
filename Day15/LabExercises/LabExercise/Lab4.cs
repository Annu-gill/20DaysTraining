using System;
using System.Collections.Generic;

public static class StringUtils
{
    // --------------------------------
    // Check whether a string is a palindrome
    // --------------------------------

    public static bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    // --------------------------------
    // Reverse a string
    // --------------------------------

    public static string Reverse(string s)
    {
        char[] characters = s.ToCharArray();

        Array.Reverse(characters);

        return new string(characters);
    }

    // --------------------------------
    // Count words in a string
    // --------------------------------

    public static int WordCount(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return 0;
        }

        string[] words = s.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        return words.Length;
    }
}

public class TrackedWidget
{
    // --------------------------------
    // Instance property
    // --------------------------------

    public Guid InstanceId { get; }

    // --------------------------------
    // Static property
    // Shared by all TrackedWidget objects
    // --------------------------------

    public static int LiveCount { get; private set; }

    // --------------------------------
    // Constructor
    // --------------------------------

    public TrackedWidget()
    {
        InstanceId = Guid.NewGuid();

        LiveCount++;
    }

    // --------------------------------
    // Dispose method
    // --------------------------------

    public void Dispose()
    {
        if (LiveCount > 0)
        {
            LiveCount--;
        }
    }

    // --------------------------------
    // Instance method
    // --------------------------------

    public void PrintInfo()
    {
        Console.WriteLine(
            $"Widget {InstanceId}: " +
            $"LiveCount={LiveCount}"
        );
    }
}

public class Lab4
{
    public static void Run()
    {
        // --------------------------------
        // Test StringUtils.IsPalindrome()
        // --------------------------------

        bool palindrome =
            StringUtils.IsPalindrome("racecar");

        Console.WriteLine(
            $"IsPalindrome(\"racecar\") -> {palindrome}"
        );

        // --------------------------------
        // Test StringUtils.Reverse()
        // --------------------------------

        string reversed =
            StringUtils.Reverse("Hello");

        Console.WriteLine(
            $"Reverse(\"Hello\") -> {reversed}"
        );

        // --------------------------------
        // Test StringUtils.WordCount()
        // --------------------------------

        int count =
            StringUtils.WordCount(
                "the quick brown fox"
            );

        Console.WriteLine(
            $"WordCount(\"the quick brown fox\") -> {count}"
        );

        // --------------------------------
        // Static classes cannot be instantiated
        // --------------------------------

        // StringUtils utils = new StringUtils();

        Console.WriteLine(
            "(new StringUtils() would not compile)"
        );

        // --------------------------------
        // Create three TrackedWidget objects
        // --------------------------------

        TrackedWidget widget1 =
            new TrackedWidget();

        TrackedWidget widget2 =
            new TrackedWidget();

        TrackedWidget widget3 =
            new TrackedWidget();

        Console.WriteLine(
            $"LiveCount after creating 3 widgets: " +
            $"{TrackedWidget.LiveCount}"
        );

        // --------------------------------
        // Print information for each widget
        // --------------------------------

        widget1.PrintInfo();
        widget2.PrintInfo();
        widget3.PrintInfo();

        // --------------------------------
        // Dispose two widgets
        // --------------------------------

        widget1.Dispose();
        widget2.Dispose();

        Console.WriteLine(
            $"LiveCount after disposing 2: " +
            $"{TrackedWidget.LiveCount}"
        );
    }
}