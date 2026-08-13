using System;
using System.Collections.Generic;
using System.IO;

class Node
{
    public int data;
    public Node left;
    public Node right;

    public Node(int value)
    {
        data = value;
        left = null;
        right = null;
    }
}

class Solution
{
    // Insert a node into the Binary Search Tree
    static Node Insert(Node root, int data)
    {
        if (root == null)
        {
            return new Node(data);
        }

        if (data <= root.data)
        {
            root.left = Insert(root.left, data);
        }
        else
        {
            root.right = Insert(root.right, data);
        }

        return root;
    }

    // Postorder Traversal (Left -> Right -> Root)
    static void PostOrder(Node root)
    {
        if (root == null)
            return;

        PostOrder(root.left);
        PostOrder(root.right);
        Console.Write(root.data + " ");
    }

    static void Main(String[] args)
    {
        Console.Write("Enter number of nodes: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Node root = null;

        Console.WriteLine("Enter node values:");

        string[] values = Console.ReadLine().Split(' ');

        for (int i = 0; i < n; i++)
        {
            root = Insert(root, Convert.ToInt32(values[i]));
        }

        Console.WriteLine("\nPostorder Traversal:");
        PostOrder(root);

        Console.WriteLine();
    }
}