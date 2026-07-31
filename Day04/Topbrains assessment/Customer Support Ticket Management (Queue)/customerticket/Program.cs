using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[] tickets =
        {
            "T001|John|Login Issue",
            "T002|Alice|Payment Failed",
            "T003|David|Account Locked",
            "T004|Emma|Refund Request",
            "T005|James|Password Reset"
        };

        Queue<string> ticketQueue = new Queue<string>();

        // Enqueue Tickets
        Console.WriteLine("Enqueued Ticket IDs:");
        foreach (string ticket in tickets)
        {
            ticketQueue.Enqueue(ticket);
            string[] data = ticket.Split('|');
            Console.WriteLine(data[0]);
        }

        // Display All Tickets
        Console.WriteLine("\nQueue:");
        foreach (string ticket in ticketQueue)
        {
            string[] data = ticket.Split('|');
            Console.WriteLine($"{data[0]} {data[1]} {data[2]}");
        }

        // Process First Ticket (Dequeue)
        Console.WriteLine("\nProcessing Ticket\n");
        string processedTicket = ticketQueue.Dequeue();
        string[] processedData = processedTicket.Split('|');
        Console.WriteLine($"{processedData[0]} {processedData[1]} {processedData[2]}");
        Console.WriteLine("\nNext Ticket\n");

        // view next ticket
        string nextTicket = ticketQueue.Peek();
        string[] nextData = nextTicket.Split('|');
        Console.WriteLine($"{nextData[0]} {nextData[1]} {nextData[2]}");

        // Check Queue Count
        Console.WriteLine("\nPending Tickets = " + ticketQueue.Count);

        // search by id
        Console.WriteLine("\nEnter Ticket ID to search:");
        string searchId = Console.ReadLine();
        bool found = false;
        foreach (string ticket in ticketQueue)
        {
            string[] data = ticket.Split('|');
            if (data[0] == searchId)
            {
                Console.WriteLine("\nTicket Found");
                Console.WriteLine($"Customer : {data[1]}");
                Console.WriteLine($"Issue : {data[2]}");
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("Ticket Not Found");
        }

        // Count Tickets by Issue Type
        Console.WriteLine("\nTicket Count by Issue Type\n");
        int loginCount = 0;
        int paymentCount = 0;
        int refundCount = 0;
        foreach (string ticket in ticketQueue)
        {
            string[] data = ticket.Split('|');
            if (data[2] == "Login Issue")
                loginCount++;
            else if (data[2] == "Payment Failed")
                paymentCount++;
            else if (data[2] == "Refund Request")
                refundCount++;
        }
        Console.WriteLine($"Login Issue = {loginCount}");
        Console.WriteLine($"Payment Failed = {paymentCount}");
        Console.WriteLine($"Refund Request = {refundCount}");


        // Remove All Processed Tickets
        Console.WriteLine("\nRemoving All Processed Tickets\n");
        while (ticketQueue.Count > 0)
        {
            ticketQueue.Dequeue();
        }
        Console.WriteLine("Remaining Queue:");
        if (ticketQueue.Count == 0)
        {
            Console.WriteLine("Queue is Empty");
        }
        else
        {
            foreach (string ticket in ticketQueue)
            {
                string[] data = ticket.Split('|');
                Console.WriteLine($"{data[0]} {data[1]} {data[2]}");
            }
        }
    }
}