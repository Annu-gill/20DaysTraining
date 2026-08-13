using System;
using System.Collections.Generic;

/// <summary>
/// Represents an Undirected Graph for the Social Network.
/// Each vertex represents a user.
/// Each edge represents a mutual friendship.
/// </summary>
class UndirectedGraph
{
    // Total number of users
    private int vertices;

    // Adjacency List to store friendships
    private List<int>[] adj;

    /// <summary>
    /// Constructor to initialize the graph.
    /// </summary>
    public UndirectedGraph(int v)
    {
        vertices = v;
        adj = new List<int>[v];

        // Create an empty list for every user
        for (int i = 0; i < v; i++)
            adj[i] = new List<int>();
    }

    /// <summary>
    /// Adds a friendship between two users.
    /// Since the graph is undirected,
    /// both users become friends with each other.
    /// </summary>
    public void AddEdge(int u, int v)
    {
        adj[u].Add(v);
        adj[v].Add(u);
    }

    /// <summary>
    /// Displays all users and their friends.
    /// </summary>
    public void DisplayGraph()
    {
        Console.WriteLine("Social Network:");

        for (int i = 0; i < vertices; i++)
        {
            Console.Write(i + " -> ");

            foreach (int friend in adj[i])
                Console.Write(friend + " ");

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Prints all direct friends of a user.
    /// </summary>
    public void FriendsOfUser(int user)
    {
        Console.Write("Friends of User " + user + ": ");

        foreach (int friend in adj[user])
            Console.Write(friend + " ");

        Console.WriteLine();
    }

    /// <summary>
    /// Checks whether two users are connected
    /// directly or indirectly using Breadth First Search (BFS).
    /// </summary>
    public bool AreConnected(int start, int end)
    {
        bool[] visited = new bool[vertices];

        Queue<int> queue = new Queue<int>();

        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            // Destination found
            if (current == end)
                return true;

            foreach (int neighbor in adj[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Finds the shortest friendship path
    /// between two users using BFS.
    /// </summary>
    public void ShortestPath(int start, int end)
    {
        bool[] visited = new bool[vertices];

        // Stores parent of every node
        int[] parent = new int[vertices];

        for (int i = 0; i < vertices; i++)
            parent[i] = -1;

        Queue<int> queue = new Queue<int>();

        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            foreach (int neighbor in adj[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    parent[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }

        if (!visited[end])
        {
            Console.WriteLine("No Path Exists.");
            return;
        }

        // Reconstruct shortest path
        Stack<int> path = new Stack<int>();

        int temp = end;

        while (temp != -1)
        {
            path.Push(temp);
            temp = parent[temp];
        }

        Console.Write("Shortest Path: ");

        while (path.Count > 0)
            Console.Write(path.Pop() + " ");

        Console.WriteLine();
    }

    /// <summary>
    /// Finds all users exactly two friendships away
    /// from the given user.
    /// Uses BFS to calculate distance.
    /// </summary>
    public void UsersAtDistanceTwo(int source)
    {
        bool[] visited = new bool[vertices];
        int[] distance = new int[vertices];

        Queue<int> queue = new Queue<int>();

        queue.Enqueue(source);
        visited[source] = true;
        distance[source] = 0;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            foreach (int neighbor in adj[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    distance[neighbor] = distance[current] + 1;
                    queue.Enqueue(neighbor);
                }
            }
        }

        Console.Write("Users at Distance 2 from User " + source + ": ");

        for (int i = 0; i < vertices; i++)
        {
            if (distance[i] == 2)
                Console.Write(i + " ");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Checks whether the graph contains a cycle.
    /// Uses DFS with parent tracking.
    /// </summary>
    public bool HasCycle()
    {
        bool[] visited = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            if (!visited[i])
            {
                if (DFS(i, visited, -1))
                    return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Recursive DFS helper function for cycle detection.
    /// Parent is used so that the edge back to the previous
    /// node is not considered a cycle.
    /// </summary>
    private bool DFS(int current, bool[] visited, int parent)
    {
        visited[current] = true;

        foreach (int neighbor in adj[current])
        {
            if (!visited[neighbor])
            {
                if (DFS(neighbor, visited, current))
                    return true;
            }
            else if (neighbor != parent)
            {
                // Visited neighbor that is not parent => Cycle
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Finds all connected components (friend groups)
    /// using DFS.
    /// </summary>
    public void ConnectedComponents()
    {
        bool[] visited = new bool[vertices];

        int group = 1;

        for (int i = 0; i < vertices; i++)
        {
            if (!visited[i])
            {
                Console.Write("Friend Group " + group + ": ");

                DFSComponent(i, visited);

                Console.WriteLine();

                group++;
            }
        }
    }

    /// <summary>
    /// DFS helper method used to print
    /// every member of a connected component.
    /// </summary>
    private void DFSComponent(int current, bool[] visited)
    {
        visited[current] = true;

        Console.Write(current + " ");

        foreach (int neighbor in adj[current])
        {
            if (!visited[neighbor])
                DFSComponent(neighbor, visited);
        }
    }
}

class Program
{
    static void Main()
    {
        // Create social network with 6 users (0-5)
        UndirectedGraph graph = new UndirectedGraph(6);

        // Add friendships
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(3, 5);
        graph.AddEdge(4, 5);

        Console.WriteLine("----------------------------------------");
        graph.DisplayGraph();

        Console.WriteLine("----------------------------------------");
        graph.FriendsOfUser(2);

        Console.WriteLine("----------------------------------------");
        if (graph.AreConnected(0, 5))
            Console.WriteLine("User 0 and User 5 are Connected.");
        else
            Console.WriteLine("User 0 and User 5 are NOT Connected.");

        Console.WriteLine("----------------------------------------");
        graph.ShortestPath(0, 5);

        Console.WriteLine("----------------------------------------");
        graph.UsersAtDistanceTwo(1);

        Console.WriteLine("----------------------------------------");
        if (graph.HasCycle())
            Console.WriteLine("Cycle Detected.");
        else
            Console.WriteLine("No Cycle Found.");

        Console.WriteLine("----------------------------------------");
        graph.ConnectedComponents();
    }
}