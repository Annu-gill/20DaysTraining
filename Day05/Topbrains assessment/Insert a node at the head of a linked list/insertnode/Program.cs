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
    // Insert a node at the head of the linked list
    static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode head, int data)
    {
        SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

        newNode.next = head;

        return newNode;
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

            head = insertNodeAtHead(head, value);
        }

        Console.WriteLine("\nLinked List:");

        PrintList(head);
    }
}