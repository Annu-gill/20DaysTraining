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

    // Function to find the height of the binary tree
    static int GetHeight(Node root)
    {
        // If tree is empty, height is -1
        if (root == null)
        {
            return -1;
        }

        // Find height of left subtree
        int leftHeight = GetHeight(root.left);

        // Find height of right subtree
        int rightHeight = GetHeight(root.right);

        // Return maximum height + 1
        return Math.Max(leftHeight, rightHeight) + 1;
    }

    static void Main(string[] args)
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

        int height = GetHeight(root);

        Console.WriteLine("\nHeight of Binary Tree: " + height);
    }
}