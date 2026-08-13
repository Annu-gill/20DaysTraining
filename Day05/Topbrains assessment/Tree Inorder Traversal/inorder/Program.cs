using System;

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

    // Inorder Traversal (Left -> Root -> Right)
    static void InOrder(Node root)
    {
        if (root == null)
            return;

        InOrder(root.left);
        Console.Write(root.data + " ");
        InOrder(root.right);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of nodes: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Node root = null;

        Console.WriteLine("Enter node values:");

        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            root = Insert(root, value);
        }

        Console.WriteLine("\nInorder Traversal:");
        InOrder(root);

        Console.WriteLine();
    }
}