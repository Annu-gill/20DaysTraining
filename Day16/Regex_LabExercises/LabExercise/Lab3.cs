using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Lab3
{
    public static void Run()
    {
        // --------------------------------
        // Named groups for log line
        // --------------------------------

        string logLine =
            "2026-08-14 09:15:32 ERROR Connection timed out";

        Match logMatch =
            Regex.Match(
                logLine,
                @"^(?<date>\d{4}-\d{2}-\d{2})\s+(?<time>\d{2}:\d{2}:\d{2})\s+(?<level>[A-Z]+)\s+(?<message>.+)$"
            );

        if (logMatch.Success)
        {
            Console.WriteLine(
                $"date={logMatch.Groups["date"].Value}, " +
                $"time={logMatch.Groups["time"].Value}, " +
                $"level={logMatch.Groups["level"].Value}, " +
                $"message={logMatch.Groups["message"].Value}"
            );
        }

        Console.WriteLine();

        // --------------------------------
        // Named groups for key=value pairs
        // --------------------------------

        string kvText =
            "name=Alice;age=30;city=NYC";

        MatchCollection kvMatches =
            Regex.Matches(
                kvText,
                @"(?<key>[^=;]+)=(?<value>[^;]+)"
            );

        foreach (Match match in kvMatches)
        {
            Console.WriteLine(
                $"{match.Groups["key"].Value}={match.Groups["value"].Value}"
            );
        }

        Console.WriteLine();

        // --------------------------------
        // MatchEvaluator for number formatting
        // --------------------------------

        string numbers =
            "Revenue: 1234567, Costs: 89000";

        string formattedNumbers =
            Regex.Replace(
                numbers,
                @"\b\d+\b",
                match =>
                {
                    long value =
                        long.Parse(match.Value);

                    return value.ToString("N0", CultureInfo.InvariantCulture);
                }
            );

        Console.WriteLine(formattedNumbers);

        Console.WriteLine();

        // --------------------------------
        // MatchEvaluator for ALL CAPS words
        // --------------------------------

        string shouting =
            "THIS IS URGENT please respond";

        string titleCase =
            Regex.Replace(
                shouting,
                @"\b[A-Z]{2,}\b",
                match =>
                {
                    string word =
                        match.Value.ToLower();

                    return char.ToUpper(word[0]) +
                           word.Substring(1);
                }
            );

        Console.WriteLine(titleCase);
    }
}
