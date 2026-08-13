using System;

public class InventoryItem
{
    // Private backing field for Quantity
    private int _quantity;

    // Name can only be assigned during object initialization.
    public string Name { get; init; }

    // Quantity property with validation
    public int Quantity
    {
        get
        {
            return _quantity;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Quantity cannot be negative"
                );
            }

            _quantity = value;
        }
    }

    // UnitPrice property with validation
    public decimal UnitPrice
    {
        get;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "UnitPrice must be greater than zero"
                );
            }

            field = value;
        }
    }

    // Computed read-only property
    public decimal TotalValue
    {
        get
        {
            return Quantity * UnitPrice;
        }
    }

    // Constructor
    public InventoryItem(
        string name,
        int quantity,
        decimal unitPrice)
    {
        // Validate name
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Name cannot be null or whitespace"
            );
        }

        // Assign through properties
        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    // Bonus method
    public void Restock(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException(
                "Restock amount must be greater than zero"
            );
        }

        Quantity += amount;
    }
}

public class Lab1
{
    public static void Run()
    {
        // Create a valid InventoryItem
        InventoryItem item = new InventoryItem(
            "Keyboard",
            3,
            45.00m
        );

        Console.WriteLine(
            $"Created: {item.Name}, " +
            $"Qty={item.Quantity}, " +
            $"Price=${item.UnitPrice:F2}, " +
            $"Total=${item.TotalValue:F2}"
        );

        // --------------------------------
        // Test Quantity validation
        // --------------------------------

        try
        {
            item.Quantity = -5;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(
                $"Caught expected error setting Quantity=-5: " +
                $"{ex.Message}"
            );
        }

        // --------------------------------
        // Test UnitPrice validation
        // --------------------------------

        try
        {
            item.UnitPrice = 0;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(
                $"Caught expected error setting UnitPrice=0: " +
                $"{ex.Message}"
            );
        }

        // --------------------------------
        // Bonus: Restock
        // --------------------------------

        item.Restock(2);

        Console.WriteLine(
            $"After restocking 2: Qty={item.Quantity}, " +
            $"Total=${item.TotalValue:F2}"
        );
    }
}