using System;

public class Appointment
{
    // Read-only properties
    public string Title { get; }
    public DateTime Start { get; }
    public TimeSpan Duration { get; }
    public string Location { get; }

    // Static field shared by the entire class
    public static int DefaultDurationMinutes;


    // Static constructor
    // Runs automatically the first time the Appointment
    // type is used.
    static Appointment()
    {
        Console.WriteLine(
            "Appointment type initialized. Default duration set to 30 minutes.");

        DefaultDurationMinutes = 30;
    }


    // Full constructor
    public Appointment(
        string title,
        DateTime start,
        TimeSpan duration,
        string location)
    {
        Title = title;
        Start = start;
        Duration = duration;
        Location = location;
    }


    // Two-argument constructor
    // Calls the full constructor using this(...)
    public Appointment(string title, DateTime start)
        : this(
            title,
            start,
            TimeSpan.FromMinutes(DefaultDurationMinutes),
            "TBD")
    {
    }


    // One-argument constructor
    // Calls the two-argument constructor using this(...)
    public Appointment(string title)
        : this(title, DateTime.Now.AddDays(1))
    {
    }

}

public class Lab3
{
    public static void Run()
    {
        // -----------------------------------------
        // 1. Full constructor
        // -----------------------------------------

        Appointment full = new Appointment(
            "Standup",
            new DateTime(2026, 8, 12, 9, 0, 0),
            TimeSpan.FromMinutes(30),
            "Room 4");


        // -----------------------------------------
        // 2. Two-argument constructor
        // -----------------------------------------

        Appointment twoArg = new Appointment(
            "Client Call",
            new DateTime(2026, 8, 12, 14, 0, 0));


        // -----------------------------------------
        // 3. One-argument constructor
        // -----------------------------------------

        Appointment oneArg = new Appointment("Follow Up");


        // -----------------------------------------
        // Print appointment details
        // -----------------------------------------

        Console.WriteLine(
            $"Full: {full.Title} @ {full.Start:yyyy-MM-dd HH:mm}, " +
            $"{full.Duration.TotalMinutes:0} min, {full.Location}");

        Console.WriteLine(
            $"Two-arg: {twoArg.Title} @ {twoArg.Start:yyyy-MM-dd HH:mm}, " +
            $"{twoArg.Duration.TotalMinutes:0} min, {twoArg.Location}");

        Console.WriteLine(
            $"One-arg: {oneArg.Title} @ {oneArg.Start:yyyy-MM-dd}, " +
            $"{oneArg.Duration.TotalMinutes:0} min, {oneArg.Location}");

        Console.WriteLine(
            $"DefaultDurationMinutes: {Appointment.DefaultDurationMinutes}");
    }
}
