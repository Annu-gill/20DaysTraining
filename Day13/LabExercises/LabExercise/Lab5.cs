using System;
using System.Collections.Generic;
using System.Linq;

public class Address
{
    // --------------------------------
    // Auto-properties
    // --------------------------------

    public string Street { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;
}

public class Order
{
    // --------------------------------
    // Get-only property
    // Set through constructor
    // --------------------------------

    public string OrderId { get; }

    // --------------------------------
    // Address property
    // Nullable because it may be unset
    // --------------------------------

    public Address? ShipTo { get; set; }

    // --------------------------------
    // Collection property
    // --------------------------------

    public List<string> Items { get; set; } = new();

    // --------------------------------
    // Total property
    // --------------------------------

    public decimal Total { get; set; }

    // --------------------------------
    // Constructor
    // --------------------------------

    public Order(string orderId)
    {
        OrderId = orderId;
    }
}

public class Lab5
{
    public static void Run()
    {
        // --------------------------------
        // Order 1
        // Object initializer
        // Nested object initializer
        // Collection initializer
        // --------------------------------

        Order order1 = new Order("ORD-1")
        {
            ShipTo = new Address
            {
                Street = "123 Main Street",
                City = "Springfield",
                ZipCode = "12345"
            },

            Items =
            {
                "Keyboard",
                "Mouse"
            },

            Total = 59.98m
        };

        // --------------------------------
        // Print Order 1
        // --------------------------------

        Console.WriteLine(
            $"Order {order1.OrderId} " +
            $"ships to {order1.ShipTo?.City} " +
            $"with {order1.Items.Count} items, " +
            $"Total=${order1.Total:F2}"
        );

        // --------------------------------
        // Order 2
        // ShipTo intentionally left null
        // --------------------------------

        Order order2 = new Order("ORD-2")
        {
            Items =
            {
                "Monitor"
            },

            Total = 199.99m
        };

        // --------------------------------
        // Handle null ShipTo
        // --------------------------------

        if (order2.ShipTo == null)
        {
            Console.WriteLine(
                $"Order {order2.OrderId} has no " +
                $"shipping address set " +
                $"(ShipTo is null)"
            );
        }

        // --------------------------------
        // Bonus: List of Orders
        // --------------------------------

        List<Order> orders = new List<Order>
        {
            new Order("ORD-3")
            {
                ShipTo = new Address
                {
                    Street = "456 Oak Avenue",
                    City = "Chicago",
                    ZipCode = "60601"
                },

                Items =
                {
                    "Laptop",
                    "Bag"
                },

                Total = 1000.00m
            },

            new Order("ORD-4")
            {
                Items =
                {
                    "Headphones"
                },

                Total = 150.00m
            }
        };

        // --------------------------------
        // LINQ Sum
        // --------------------------------

        decimal totalOrders =
            orders.Sum(order => order.Total);

        Console.WriteLine(
            $"Bonus - Total of ORD-3 and ORD-4: " +
            $"${totalOrders:F2}"
        );
    }
}