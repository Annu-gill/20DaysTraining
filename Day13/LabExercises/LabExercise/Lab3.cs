using System;

public class Subscription
{
    // --------------------------------
    // Id: Get-only auto-property
    // Can only be assigned in constructor
    // --------------------------------

    public string Id { get; }

    // --------------------------------
    // PlanName: Fully read/write
    // --------------------------------

    public string PlanName { get; set; } = string.Empty;

    // --------------------------------
    // StartedAt: Init-only property
    // Can be assigned during initialization
    // but not after construction
    // --------------------------------

    public DateTime StartedAt { get; init; }

    // --------------------------------
    // IsActive: Public getter
    // Private setter
    // --------------------------------

    public bool IsActive { get; private set; } = true;

    // --------------------------------
    // Computed read-only property
    // --------------------------------

    public int MonthsActive
    {
        get
        {
            return (
                (DateTime.Now.Year - StartedAt.Year) * 12
                + DateTime.Now.Month - StartedAt.Month
            );
        }
    }

    // --------------------------------
    // Constructor
    // --------------------------------

    public Subscription(string id)
    {
        Id = id;
    }

    // --------------------------------
    // Cancel subscription
    // --------------------------------

    public void Cancel()
    {
        IsActive = false;
    }

    // --------------------------------
    // Bonus: Renew subscription
    // --------------------------------

    public void Renew(string newPlanName)
    {
        PlanName = newPlanName;
        IsActive = true;
    }
}

public class Lab3
{
    public static void Run()
    {
        // --------------------------------
        // Create Subscription
        // --------------------------------

        Subscription subscription =
            new Subscription("SUB-1")
            {
                PlanName = "Pro",
                StartedAt = new DateTime(2026, 1, 1)
            };

        // --------------------------------
        // Print subscription details
        // --------------------------------

        Console.WriteLine(
            $"Id={subscription.Id}, " +
            $"Plan={subscription.PlanName}, " +
            $"Started={subscription.StartedAt:yyyy-MM-dd}, " +
            $"Active={subscription.IsActive}, " +
            $"MonthsActive={subscription.MonthsActive}"
        );

        // --------------------------------
        // Cancel subscription
        // --------------------------------

        subscription.Cancel();

        Console.WriteLine(
            $"After Cancel(): Active={subscription.IsActive}"
        );

        // --------------------------------
        // The following code DOES NOT COMPILE
        // because IsActive has a private setter.
        // --------------------------------

        // subscription.IsActive = true;

        Console.WriteLine(
            "(subscription.IsActive = true; " +
            "would NOT compile from outside the class)"
        );

        // --------------------------------
        // The following code DOES NOT COMPILE
        // because StartedAt uses init.
        // --------------------------------

        // subscription.StartedAt = DateTime.Now;

        Console.WriteLine(
            "(subscription.StartedAt = DateTime.Now; " +
            "would NOT compile after construction)"
        );

        // --------------------------------
        // Bonus: Renew subscription
        // --------------------------------

        subscription.Renew("Premium");

        Console.WriteLine(
            $"After Renew(): " +
            $"Plan={subscription.PlanName}, " +
            $"Active={subscription.IsActive}"
        );
    }
}