using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

static class StringToolkit
{
    // 1. Reverse a string
    public static string Reverse(string input)
    {
        char[] characters = input.ToCharArray();

        Array.Reverse(characters);

        return new string(characters);
    }

    // 2. Count a particular character
    public static int CountChar(string text, char searchChar)
    {
        int count = 0;

        foreach (char character in text)
        {
            if (character == searchChar)
            {
                count++;
            }
        }

        return count;
    }

    // 3. Remove duplicate characters
    public static string RemoveDuplicates(string input)
    {
        HashSet<char> seen = new HashSet<char>();
        string result = "";

        foreach (char character in input)
        {
            if (seen.Add(character))
            {
                result += character;
            }
        }

        return result;
    }

    // 4. Check whether a string is a palindrome
    //    Ignore case and spaces
    public static bool IsPalindrome(string input)
    {
        string cleaned = "";

        foreach (char character in input)
        {
            if (character != ' ')
            {
                cleaned += char.ToLower(character);
            }
        }

        string reversed = Reverse(cleaned);

        return cleaned == reversed;
    }

    // 5. Convert string to title case
    public static string ToTitleCase(string input)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        return textInfo.ToTitleCase(input.ToLower());
    }

    // 6. Extract only numbers
    public static string ExtractNumbers(string input)
    {
        string result = "";

        foreach (char character in input)
        {
            if (char.IsDigit(character))
            {
                result += character;
            }
        }

        return result;
    }
}


// Driver class for Lab 3
class Lab3
{
    public static void Run()
    {
        Console.WriteLine("===== Lab 3: String Manipulation Toolkit =====");
        Console.WriteLine();

        // 1. Reverse
        string reverseResult = StringToolkit.Reverse("Hello");

        Console.WriteLine(
            $"Reverse(\"Hello\") -> \"{reverseResult}\""
        );

        // 2. CountChar
        int countResult = StringToolkit.CountChar("banana", 'a');

        Console.WriteLine(
            $"CountChar(\"banana\", 'a') -> {countResult}"
        );

        // 3. RemoveDuplicates
        string duplicateResult =
            StringToolkit.RemoveDuplicates("mississippi");

        Console.WriteLine(
            $"RemoveDuplicates(\"mississippi\") -> \"{duplicateResult}\""
        );

        // 4. IsPalindrome
        bool palindromeResult =
            StringToolkit.IsPalindrome("race car");

        Console.WriteLine(
            $"IsPalindrome(\"race car\") -> {palindromeResult}"
        );

        // 5. ToTitleCase
        string titleResult =
            StringToolkit.ToTitleCase("hello training team");

        Console.WriteLine(
            $"ToTitleCase(\"hello training team\") -> \"{titleResult}\""
        );

        // 6. ExtractNumbers
        string numberResult =
            StringToolkit.ExtractNumbers("Order #4521, qty 3");

        Console.WriteLine(
            $"ExtractNumbers(\"Order #4521, qty 3\") -> \"{numberResult}\""
        );
    }
}