using System;
using System.Text.RegularExpressions;
using System.Linq;

public class Lab2
{
    public static void Run()
    {
        // --------------------------------
        // Extract order numbers
        // --------------------------------

        string text =
            "Order #4521 was shipped. order #99 is pending. ORDER #12345 was cancelled.";

        MatchCollection matches =
            Regex.Matches(
                text,
                @"order\s*#(\d+)",
                RegexOptions.IgnoreCase
            );

        string[] orderNumbers =
            matches
                .Cast<Match>()
                .Select(m => m.Groups[1].Value)
                .ToArray();

        Console.WriteLine(
            $"Order numbers found: {string.Join(", ", orderNumbers)}"
        );

        Console.WriteLine();

        // --------------------------------
        // Mask credit card number
        // --------------------------------

        string cardText =
            "Card on file: 4111-1111-1111-1234";

        string maskedCard =
            Regex.Replace(
                cardText,
                @"\b(\d{4})[- ]?(\d{4})[- ]?(\d{4})[- ]?(\d{4})\b",
                "XXXX-XXXX-XXXX-$4"
            );

        Console.WriteLine(
            $"Masked card: {maskedCard.Replace("Card on file: ", "")}"
        );

        Console.WriteLine();

        // --------------------------------
        // Reformat name
        // --------------------------------

        string names = "Smith, John";

        string reformatted =
            Regex.Replace(
                names,
                @"^\s*([^,]+),\s*(.+?)\s*$",
                "$2 $1"
            );

        Console.WriteLine(
            $"Reformatted name: {reformatted}"
        );

        Console.WriteLine();

        // --------------------------------
        // Split tags into clean array
        // --------------------------------

        string tags =
            "red, blue;green , yellow";

        string[] tagArray =
            Regex.Split(tags, @"[;,]")
                .Select(t => t.Trim())
                .Where(t => t.Length > 0)
                .ToArray();

        Console.WriteLine(
            $"Tags: [{string.Join(", ", tagArray)}]"
        );
    }
}
