using System;

class SinglyLinkedListNode
{
    public int data;
    public SinglyLinkedListNode? next;

    public SinglyLinkedListNode(int nodeData)
    {
        data = nodeData;
        next = null;
    }
}

class SinglyLinkedList
{
    public SinglyLinkedListNode? head;
    public SinglyLinkedListNode? tail;

    public SinglyLinkedList()
    {
        head = null;
        tail = null;
    }

    // Insert node at the end of the linked list
    public void InsertNode(int nodeData)
    {
        SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail!.next = node;
            tail = node;
        }
    }

    // Display the linked list
    public void Display()
    {
        SinglyLinkedListNode? temp = head;

        while (temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.next;
        }

        Console.WriteLine();
    }
}

class Program
{
    // Insert a node at a specific position
    static SinglyLinkedListNode? InsertNodeAtPosition(SinglyLinkedListNode? head, int data, int position)
    {
        SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

        // Insert at the beginning
        if (position == 0)
        {
            newNode.next = head;
            return newNode;
        }

        SinglyLinkedListNode? current = head;

        // Move to the node before the desired position
        for (int i = 0; i < position - 1; i++)
        {
            current = current!.next;
        }

        // Insert the new node
        newNode.next = current!.next;
        current.next = newNode;

        return head;
    }

    static void Main(string[] args)
    {
        SinglyLinkedList list = new SinglyLinkedList();

        Console.Write("Enter number of nodes: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter node values:");

        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            list.InsertNode(value);
        }

        Console.Write("Enter data to insert: ");
        int data = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter position: ");
        int position = Convert.ToInt32(Console.ReadLine());

        list.head = InsertNodeAtPosition(list.head, data, position);

        Console.WriteLine("\nUpdated Linked List:");
        list.Display();
    }
}