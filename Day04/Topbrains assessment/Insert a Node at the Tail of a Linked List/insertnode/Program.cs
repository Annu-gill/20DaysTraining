using System;

class SinglyLinkedListNode
{
    public int data;
    public SinglyLinkedListNode next;

    public SinglyLinkedListNode(int nodeData)
    {
        data = nodeData;
        next = null;
    }
}

class Program
{
    // Insert a node at the tail of the linked list
    static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
    {
        // Create a new node
        SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

        // If the list is empty
        if (head == null)
        {
            return newNode;
        }

        // Traverse to the last node
        SinglyLinkedListNode current = head;

        while (current.next != null)
        {
            current = current.next;
        }

        // Add the new node at the end
        current.next = newNode;

        return head;
    }

    // Display the linked list
    static void PrintList(SinglyLinkedListNode head)
    {
        while (head != null)
        {
            Console.WriteLine(head.data);
            head = head.next;
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of nodes: ");
        int n = Convert.ToInt32(Console.ReadLine());

        SinglyLinkedListNode head = null;

        Console.WriteLine("Enter node values:");

        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            head = insertNodeAtTail(head, value);
        }

        Console.WriteLine("\nLinked List:");

        PrintList(head);
    }
}