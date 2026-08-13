using System;
using System.Collections.Generic;
using System.Text;

public class LogEntry
{
    public DateTime Timestamp { get; set; }
    public string LogLevel { get; set; }
    public string Message { get; set; }
    public Exception Exception { get; set; }

    public LogEntry(
        DateTime timestamp,
        string logLevel,
        string message,
        Exception exception = null)
    {
        Timestamp = timestamp;
        LogLevel = logLevel;
        Message = message;
        Exception = exception;
    }
}

public class LogProcessor
{
    private readonly int bufferCapacity;

    // Stores formatted log messages
    private readonly List<string> logBuffer;

    // Stores only Error logs
    private readonly List<LogEntry> errorLogs;

    public LogProcessor(int bufferCapacity)
    {
        this.bufferCapacity = bufferCapacity;
        logBuffer = new List<string>();
        errorLogs = new List<LogEntry>();
    }

    public void ProcessLog(LogEntry log)
    {
        // StringBuilder is used to efficiently construct the log message
        StringBuilder builder = new StringBuilder();

        builder.Append("[");
        builder.Append(log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
        builder.Append("] ");

        builder.Append(log.LogLevel);
        builder.Append(": ");

        builder.Append(log.Message);

        // Add exception information if available
        if (log.Exception != null)
        {
            builder.Append(" | Exception: ");
            builder.Append(log.Exception.Message);
        }

        // Convert StringBuilder content to string
        logBuffer.Add(builder.ToString());

        // Store Error logs separately
        if (log.LogLevel.Equals("ERROR", StringComparison.OrdinalIgnoreCase))
        {
            errorLogs.Add(log);
        }

        Console.WriteLine(
            $"Log received. Buffer size: {logBuffer.Count}/{bufferCapacity}");

        // Flush when buffer reaches capacity
        if (logBuffer.Count >= bufferCapacity)
        {
            FlushBuffer();
        }
    }

    public void FlushBuffer()
    {
        if (logBuffer.Count == 0)
        {
            Console.WriteLine("Buffer is empty.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("========== FLUSHING BUFFER ==========");

        foreach (string log in logBuffer)
        {
            Console.WriteLine(log);
        }

        Console.WriteLine("========== BUFFER FLUSHED ===========");
        Console.WriteLine();

        // Clear buffer after processing
        logBuffer.Clear();
    }

    public void DisplayErrorSummary()
    {
        Console.WriteLine();
        Console.WriteLine("========== ERROR SUMMARY ==========");

        if (errorLogs.Count == 0)
        {
            Console.WriteLine("No errors found.");
        }
        else
        {
            Console.WriteLine($"Total Error Logs: {errorLogs.Count}");
            Console.WriteLine();

            foreach (LogEntry error in errorLogs)
            {
                Console.WriteLine(
                    $"Time: {error.Timestamp:yyyy-MM-dd HH:mm:ss}");

                Console.WriteLine(
                    $"Message: {error.Message}");

                if (error.Exception != null)
                {
                    Console.WriteLine(
                        $"Exception: {error.Exception.Message}");
                }

                Console.WriteLine("----------------------------------");
            }
        }

        Console.WriteLine("==================================");
    }
}

public class Program
{
    public static void Main()
    {
        // Buffer can hold 3 logs before flushing
        LogProcessor processor = new LogProcessor(3);

        LogEntry log1 = new LogEntry(
            DateTime.Now,
            "INFO",
            "Application started successfully."
        );

        LogEntry log2 = new LogEntry(
            DateTime.Now,
            "INFO",
            "User logged in successfully."
        );

        LogEntry log3 = new LogEntry(
            DateTime.Now,
            "ERROR",
            "Database connection failed.",
            new Exception("Unable to connect to SQL Server.")
        );

        LogEntry log4 = new LogEntry(
            DateTime.Now,
            "WARNING",
            "Memory usage is above 80%."
        );

        LogEntry log5 = new LogEntry(
            DateTime.Now,
            "ERROR",
            "File could not be processed.",
            new Exception("File not found.")
        );

        // Process logs
        processor.ProcessLog(log1);
        processor.ProcessLog(log2);
        processor.ProcessLog(log3);

        processor.ProcessLog(log4);
        processor.ProcessLog(log5);

        // Flush remaining logs
        processor.FlushBuffer();

        // Display all errors
        processor.DisplayErrorSummary();
    }
}