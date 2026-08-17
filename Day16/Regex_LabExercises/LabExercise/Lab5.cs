using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class LogEntry
{
    public string Date { get; init; } = string.Empty;

    public string Time { get; init; } = string.Empty;

    public string Level { get; init; } = string.Empty;

    public string Message { get; init; } = string.Empty;
}

public class Lab5
{
    public static List<LogEntry> ParseLog(string rawLog)
    {
        List<LogEntry> entries =
            new List<LogEntry>();

        string pattern =
            @"^(?<date>\d{4}-\d{2}-\d{2})\s+" +
            @"(?<time>\d{2}:\d{2}:\d{2})\s+" +
            @"(?<level>INFO|WARN|ERROR)\s+" +
            @"(?<message>.+)$";

        MatchCollection matches =
            Regex.Matches(
                rawLog,
                pattern,
                RegexOptions.Multiline
            );

        foreach (Match match in matches)
        {
            entries.Add(
                new LogEntry
                {
                    Date =
                        match.Groups["date"].Value,

                    Time =
                        match.Groups["time"].Value,

                    Level =
                        match.Groups["level"].Value,

                    Message =
                        match.Groups["message"].Value
                }
            );
        }

        return entries;
    }

    public static string RedactErrorCodes(
        string rawLog
    )
    {
        string pattern =
            @"^(?<prefix>\d{4}-\d{2}-\d{2}\s+" +
            @"\d{2}:\d{2}:\d{2}\s+ERROR\s+.*?" +
            @"code=)(?<code>\d+)(?<suffix>.*)$";

        return Regex.Replace(
            rawLog,
            pattern,
            match =>
            {
                return
                    match.Groups["prefix"].Value +
                    "###" +
                    match.Groups["suffix"].Value;
            },
            RegexOptions.Multiline
        );
    }

    public static void Run()
    {
        string rawLog = @"2026-08-14 09:15:00 INFO Service started
        2026-08-14 09:16:12 WARN Disk usage high
        2026-08-14 09:17:45 ERROR Request failed code=404
        2026-08-14 09:18:03 INFO Request completed
        2026-08-14 09:19:22 ERROR Upstream error code=500
        2026-08-14 09:20:00 INFO Shutdown complete";

        // --------------------------------
        // Parse Log Entries
        // --------------------------------

        List<LogEntry> entries =
            ParseLog(rawLog);

        Console.WriteLine(
            $"Parsed {entries.Count} entries."
        );

        // --------------------------------
        // Summary by Level
        // --------------------------------

        int infoCount =
            entries.Count(
                e => e.Level == "INFO"
            );

        int warnCount =
            entries.Count(
                e => e.Level == "WARN"
            );

        int errorCount =
            entries.Count(
                e => e.Level == "ERROR"
            );

        Console.WriteLine(
            $"Summary: INFO: {infoCount}, " +
            $"WARN: {warnCount}, " +
            $"ERROR: {errorCount}"
        );

        Console.WriteLine();

        // --------------------------------
        // Redacted Log
        // --------------------------------

        Console.WriteLine(
            "--- Redacted log ---"
        );

        Console.WriteLine(
            RedactErrorCodes(rawLog)
        );
    }
}