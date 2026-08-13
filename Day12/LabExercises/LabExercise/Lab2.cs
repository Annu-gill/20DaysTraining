using System;
using System.Collections.Generic;
using System.Linq;

public abstract class NotificationChannel
{
    // Concrete method
    public bool TrySend(string message)
    {
        try
        {
            return Send(message);
        }
        catch
        {
            return false;
        }
    }

    // Abstract method
    protected abstract bool Send(string message);
}


// Email implementation
public class EmailChannel : NotificationChannel
{
    protected override bool Send(string message)
    {
        // Email always succeeds
        return true;
    }
}


// SMS implementation
public class SmsChannel : NotificationChannel
{
    protected override bool Send(string message)
    {
        // SMS messages cannot exceed 160 characters
        if (message.Length > 160)
        {
            throw new ArgumentException(
                "SMS message cannot exceed 160 characters."
            );
        }

        return true;
    }
}


public class Lab2
{
    public static void Run()
    {
        Console.WriteLine(
            "===== Lab 2: Notification Channels ====="
        );

        // -----------------------------------------
        // Create notification channels
        // -----------------------------------------

        List<NotificationChannel> channels =
            new List<NotificationChannel>
            {
                new EmailChannel(),
                new SmsChannel(),
                new EmailChannel(),
                new SmsChannel()
            };

        // -----------------------------------------
        // Short message
        // -----------------------------------------

        string shortMessage =
            "Hello, this is a short notification.";

        Console.WriteLine();
        Console.WriteLine("Short Message:");

        var shortResults = channels
            .Select(channel => new
            {
                ChannelType = channel.GetType().Name,
                Success = channel.TrySend(shortMessage)
            })
            .ToList();

        foreach (var result in shortResults)
        {
            Console.WriteLine(
                $"{result.ChannelType}: " +
                $"{(result.Success ? "Success" : "Failed")}"
            );
        }

        // -----------------------------------------
        // Long message
        // -----------------------------------------

        string longMessage = new string('A', 200);

        Console.WriteLine();
        Console.WriteLine("Long Message:");

        var longResults = channels
            .Select(channel => new
            {
                ChannelType = channel.GetType().Name,
                Success = channel.TrySend(longMessage)
            })
            .ToList();

        foreach (var result in longResults)
        {
            Console.WriteLine(
                $"{result.ChannelType}: " +
                $"{(result.Success ? "Success" : "Failed")}"
            );
        }

        // -----------------------------------------
        // Combine results
        // -----------------------------------------

        var report = shortResults
            .Concat(longResults)
            .ToList();

        // -----------------------------------------
        // Count success and failures
        // -----------------------------------------

        int succeeded =
            report.Count(result => result.Success);

        int failed =
            report.Count(result => !result.Success);

        Console.WriteLine();
        Console.WriteLine(
            $"Succeeded: {succeeded}, Failed: {failed}"
        );
    }
}