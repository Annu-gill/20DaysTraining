using System;

class Lab1
{
    public static void Run()
    {
        // ------------------------------------
        // 1. String Basics
        // ------------------------------------

        string original = "  Hello, Training Team!  ";

        // Trim the string
        string trimmed = original.Trim();

        // ------------------------------------
        // 2. Check String Immutability
        // ------------------------------------

        Console.WriteLine(
            $"ReferenceEquals(original, trimmed): {object.ReferenceEquals(original, trimmed)}"
        );

        // ------------------------------------
        // 3. String Search Operations
        // ------------------------------------

        Console.WriteLine(
            $"Contains \"Training\": {trimmed.Contains("Training")}"
        );

        Console.WriteLine(
            $"StartsWith trimmed \"Hello\": {trimmed.StartsWith("Hello")}"
        );

        Console.WriteLine(
            $"Index of first comma: {trimmed.IndexOf(',')}"
        );

        // ------------------------------------
        // 4. Replace
        // ------------------------------------

        string replaced = trimmed.Replace(
            "Training Team",
            "Engineering Team"
        );

        Console.WriteLine(
            $"\"Training Team\" replaced -> {replaced}"
        );

        // ------------------------------------
        // 5. Split String
        // ------------------------------------

        string[] words = trimmed.Split(
            new char[] { ' ', ',' },
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }

        // ------------------------------------
        // 6. IsNullOrWhiteSpace
        // ------------------------------------

        string nullString = null;
        string emptyString = "";
        string spacesString = "   ";
        string normalString = "ok";

        Console.WriteLine(
            $"IsNullOrWhiteSpace(null): {string.IsNullOrWhiteSpace(nullString)}"
        );

        Console.WriteLine(
            $"IsNullOrWhiteSpace(\"\"): {string.IsNullOrWhiteSpace(emptyString)}"
        );

        Console.WriteLine(
            $"IsNullOrWhiteSpace(\"   \"): {string.IsNullOrWhiteSpace(spacesString)}"
        );

        Console.WriteLine(
            $"IsNullOrWhiteSpace(\"ok\"): {string.IsNullOrWhiteSpace(normalString)}"
        );

        // ------------------------------------
        // 7. Bonus
        // ------------------------------------

        string first = "HELLO";
        string second = "hello";

        int comparison = string.Compare(
            first,
            second,
            StringComparison.OrdinalIgnoreCase
        );

        Console.WriteLine(
            $"Case-insensitive comparison result: {comparison}"
        );
    }
}