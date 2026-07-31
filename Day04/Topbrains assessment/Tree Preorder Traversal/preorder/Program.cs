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
    // Insert node into Binary Search Tree
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

    // Preorder Traversal (Root -> Left -> Right)
    public static void preOrder(Node root)
    {
        if (root == null)
            return;

        Console.Write(root.data + " ");
        preOrder(root.left);
        preOrder(root.right);
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

        Console.WriteLine("\nPreorder Traversal:");
        preOrder(root);

        Console.WriteLine();
    }
}