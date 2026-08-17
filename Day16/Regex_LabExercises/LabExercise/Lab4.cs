using System;
using System.Text.RegularExpressions;

public static class PatternLibrary
{
    // --------------------------------
    // Compiled regex patterns
    // --------------------------------

    public static readonly Regex Email =
        new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled
        );

    public static readonly Regex UsPhone =
        new Regex(
            @"^\d{3}-\d{3}-\d{4}$",
            RegexOptions.Compiled
        );

    public static readonly Regex HexColor =
        new Regex(
            @"^#[0-9A-Fa-f]{6}$",
            RegexOptions.Compiled
        );

    // --------------------------------
    // Wrapper methods
    // --------------------------------

    public static bool IsValidEmail(string input)
    {
        return Email.IsMatch(input);
    }

    public static bool IsValidPhone(string input)
    {
        return UsPhone.IsMatch(input);
    }

    public static bool IsValidHexColor(string input)
    {
        return HexColor.IsMatch(input);
    }
}

public class Lab4
{
    public static void Run()
    {
        // --------------------------------
        // IgnoreCase demonstration
        // --------------------------------

        bool ignoreCaseOff =
            Regex.IsMatch(
                "HELLO",
                @"hello"
            );

        bool ignoreCaseOn =
            Regex.IsMatch(
                "HELLO",
                @"hello",
                RegexOptions.IgnoreCase
            );

        Console.WriteLine(
            $"IgnoreCase off: {ignoreCaseOff}, IgnoreCase on: {ignoreCaseOn}"
        );

        Console.WriteLine();

        // --------------------------------
        // Multiline demonstration
        // --------------------------------

        string multiLineText =
            "First line\nSecond line\nThird line";

        int withoutMultiline =
            Regex.Matches(
                multiLineText,
                @"^"
            ).Count;

        int withMultiline =
            Regex.Matches(
                multiLineText,
                @"^",
                RegexOptions.Multiline
            ).Count;

        Console.WriteLine(
            $"Line-start matches WITHOUT Multiline: {withoutMultiline}"
        );

        Console.WriteLine(
            $"Line-start matches WITH Multiline: {withMultiline}"
        );

        Console.WriteLine();

        // --------------------------------
        // PatternLibrary tests
        // --------------------------------

        Console.WriteLine(
            $"IsValidEmail(\"a@b.com\"): {PatternLibrary.IsValidEmail("a@b.com")}, " +
            $"IsValidEmail(\"not-an-email\"): {PatternLibrary.IsValidEmail("not-an-email")}"
        );

        Console.WriteLine(
            $"IsValidPhone(\"555-123-4567\"): {PatternLibrary.IsValidPhone("555-123-4567")}, " +
            $"IsValidPhone(\"5551234567\"): {PatternLibrary.IsValidPhone("5551234567")}"
        );

        Console.WriteLine(
            $"IsValidHexColor(\"#1A2B3C\"): {PatternLibrary.IsValidHexColor("#1A2B3C")}, " +
            $"IsValidHexColor(\"1A2B3C\"): {PatternLibrary.IsValidHexColor("1A2B3C")}"
        );
    }
}
