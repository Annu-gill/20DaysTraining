using System;
using System.Collections.Generic;

public class BTreeNode
{
    public List<int> Keys { get; set; }
    public List<BTreeNode> Children { get; set; }
    public bool IsLeaf { get; set; }

    public BTreeNode(bool isLeaf)
    {
        Keys = new List<int>();
        Children = new List<BTreeNode>();
        IsLeaf = isLeaf;
    }
}

public class BTree
{
    private BTreeNode root;
    private int degree;
    private int maxKeys => 2 * degree - 1;
    private int minKeys => degree - 1;

    public BTree(int degree)
    {
        this.degree = degree;
        root = new BTreeNode(true);
    }

    // Insert key
    public void Insert(int key)
    {
        if (root.Keys.Count == maxKeys)
        {
            // Root is full, split it
            BTreeNode newRoot = new BTreeNode(false);
            newRoot.Children.Add(root);

            SplitChild(newRoot, 0);

            root = newRoot;
            InsertNonFull(root, key);
        }
        else
        {
            InsertNonFull(root, key);
        }
    }

    private void InsertNonFull(BTreeNode node, int key)
    {
        int i = node.Keys.Count - 1;

        if (node.IsLeaf)
        {
            node.Keys.Add(0); // Placeholder

            while (i >= 0 && key < node.Keys[i])
            {
                node.Keys[i + 1] = node.Keys[i];
                i--;
            }

            node.Keys[i + 1] = key;
        }
        else
        {
            while (i >= 0 && key < node.Keys[i])
                i--;

            i++;

            if (node.Children[i].Keys.Count == maxKeys)
            {
                SplitChild(node, i);

                if (key > node.Keys[i])
                    i++;
            }

            InsertNonFull(node.Children[i], key);
        }
    }

    private void SplitChild(BTreeNode parent, int index)
    {
        BTreeNode child = parent.Children[index];
        BTreeNode newChild = new BTreeNode(child.IsLeaf);

        int middleKey = child.Keys[degree - 1];

        // Copy last (degree-1) keys
        for (int j = 0; j < minKeys; j++)
        {
            newChild.Keys.Add(child.Keys[j + degree]);
        }

        // Copy children if not leaf
        if (!child.IsLeaf)
        {
            for (int j = 0; j < degree; j++)
            {
                newChild.Children.Add(child.Children[j + degree]);
            }

            child.Children.RemoveRange(degree, child.Children.Count - degree);
        }

        // Remove keys from original child
        child.Keys.RemoveRange(degree - 1, child.Keys.Count - (degree - 1));

        // Insert into parent
        parent.Children.Insert(index + 1, newChild);
        parent.Keys.Insert(index, middleKey);
    }

    public void Display()
    {
        DisplayRecursive(root, 0);
    }

    private void DisplayRecursive(BTreeNode node, int level)
    {
        Console.WriteLine($"Level {level}: {string.Join(", ", node.Keys)}");

        if (!node.IsLeaf)
        {
            foreach (var child in node.Children)
            {
                DisplayRecursive(child, level + 1);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BTree bTree = new BTree(3);

        int[] keys = { 10, 20, 5, 6, 12, 30, 7, 17 };

        foreach (int key in keys)
        {
            bTree.Insert(key);
        }

        Console.WriteLine("B-Tree Structure:");
        bTree.Display();
    }
}



// using System;
// using System.Collections.Generic;
// using System.Linq;

// // Edge class for weighted graphs
// public class Edge
// {
//     public int Destination { get; set; }
//     public int Weight { get; set; }

//     public Edge(int destination, int weight = 1)
//     {
//         Destination = destination;
//         Weight = weight;
//     }

//     public override string ToString()
//     {
//         return $"Destination: {Destination}, Weight: {Weight}";
//     }
// }

// // Vertex class
// public class Vertex
// {
//     public int Id { get; set; }
//     public string Label { get; set; }

//     public Vertex(int id, string label = null)
//     {
//         Id = id;
//         Label = label ?? id.ToString();
//     }

//     public override string ToString()
//     {
//         return Label;
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         // Creating vertices
//         Vertex v1 = new Vertex(1, "A");
//         Vertex v2 = new Vertex(2, "B");
//         Vertex v3 = new Vertex(3);   // Label will be "3"

//         Console.WriteLine("Vertices:");
//         Console.WriteLine(v1);
//         Console.WriteLine(v2);
//         Console.WriteLine(v3);

//         Console.WriteLine();

//         // Creating edges
//         Edge e1 = new Edge(2, 10);
//         Edge e2 = new Edge(3, 5);
//         Edge e3 = new Edge(1);   // Default weight = 1

//         Console.WriteLine("Edges:");
//         Console.WriteLine(e1);
//         Console.WriteLine(e2);
//         Console.WriteLine(e3);
//     }
// }


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class UndirectedUnweightedGraph
// {
//     private Dictionary<int, List<int>> adjacencyList;

//     public UndirectedUnweightedGraph()
//     {
//         adjacencyList = new Dictionary<int, List<int>>();
//     }

//     // Add Vertex
//     public void AddVertex(int vertex)
//     {
//         if (!adjacencyList.ContainsKey(vertex))
//         {
//             adjacencyList[vertex] = new List<int>();
//         }
//     }

//     // Add Edge (Bidirectional)
//     public void AddEdge(int source, int destination)
//     {
//         if (!adjacencyList.ContainsKey(source))
//             AddVertex(source);

//         if (!adjacencyList.ContainsKey(destination))
//             AddVertex(destination);

//         adjacencyList[source].Add(destination);
//         adjacencyList[destination].Add(source);
//     }

//     // Remove Edge
//     public void RemoveEdge(int source, int destination)
//     {
//         if (adjacencyList.ContainsKey(source))
//             adjacencyList[source].Remove(destination);

//         if (adjacencyList.ContainsKey(destination))
//             adjacencyList[destination].Remove(source);
//     }

//     // Remove Vertex
//     public void RemoveVertex(int vertex)
//     {
//         if (!adjacencyList.ContainsKey(vertex))
//             return;

//         foreach (var v in adjacencyList.Keys.ToList())
//         {
//             adjacencyList[v].Remove(vertex);
//         }

//         adjacencyList.Remove(vertex);
//     }

//     // Check Edge
//     public bool HasEdge(int source, int destination)
//     {
//         return adjacencyList.ContainsKey(source) &&
//                adjacencyList[source].Contains(destination);
//     }

//     // Get Neighbors
//     public List<int> GetNeighbors(int vertex)
//     {
//         if (adjacencyList.ContainsKey(vertex))
//             return adjacencyList[vertex];

//         return new List<int>();
//     }

//     // Get All Vertices
//     public List<int> GetAllVertices()
//     {
//         return adjacencyList.Keys.ToList();
//     }

//     // BFS Traversal
//     public void BFS(int start)
//     {
//         if (!adjacencyList.ContainsKey(start))
//             return;

//         HashSet<int> visited = new HashSet<int>();
//         Queue<int> queue = new Queue<int>();

//         visited.Add(start);
//         queue.Enqueue(start);

//         Console.Write("BFS Traversal: ");

//         while (queue.Count > 0)
//         {
//             int current = queue.Dequeue();
//             Console.Write(current + " ");

//             foreach (int neighbor in adjacencyList[current])
//             {
//                 if (!visited.Contains(neighbor))
//                 {
//                     visited.Add(neighbor);
//                     queue.Enqueue(neighbor);
//                 }
//             }
//         }

//         Console.WriteLine();
//     }

//     // DFS Traversal
//     public void DFS(int start)
//     {
//         if (!adjacencyList.ContainsKey(start))
//             return;

//         HashSet<int> visited = new HashSet<int>();

//         Console.Write("DFS Traversal: ");
//         DFSRecursive(start, visited);
//         Console.WriteLine();
//     }

//     private void DFSRecursive(int vertex, HashSet<int> visited)
//     {
//         visited.Add(vertex);
//         Console.Write(vertex + " ");

//         foreach (int neighbor in adjacencyList[vertex])
//         {
//             if (!visited.Contains(neighbor))
//             {
//                 DFSRecursive(neighbor, visited);
//             }
//         }
//     }

//     // Display Graph
//     public void Display()
//     {
//         Console.WriteLine("Graph:");

//         foreach (var item in adjacencyList)
//         {
//             Console.Write(item.Key + " -> ");

//             foreach (int neighbor in item.Value)
//             {
//                 Console.Write(neighbor + " ");
//             }

//             Console.WriteLine();
//         }
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         UndirectedUnweightedGraph graph = new UndirectedUnweightedGraph();

//         // Add vertices
//         graph.AddVertex(1);
//         graph.AddVertex(2);
//         graph.AddVertex(3);
//         graph.AddVertex(4);
//         graph.AddVertex(5);

//         // Add edges
//         graph.AddEdge(1, 2);
//         graph.AddEdge(1, 3);
//         graph.AddEdge(2, 4);
//         graph.AddEdge(3, 5);
//         graph.AddEdge(4, 5);

//         Console.WriteLine("Initial Graph:");
//         graph.Display();

//         Console.WriteLine();

//         // BFS
//         graph.BFS(1);

//         // DFS
//         graph.DFS(1);

//         Console.WriteLine();

//         // Check Edge
//         Console.WriteLine("Edge between 1 and 2: " + graph.HasEdge(1, 2));
//         Console.WriteLine("Edge between 2 and 5: " + graph.HasEdge(2, 5));

//         Console.WriteLine();

//         // Neighbors
//         Console.WriteLine("Neighbors of Vertex 1:");
//         foreach (int n in graph.GetNeighbors(1))
//         {
//             Console.Write(n + " ");
//         }

//         Console.WriteLine("\n");

//         // Remove Edge
//         graph.RemoveEdge(1, 2);

//         Console.WriteLine("Graph after removing edge (1,2):");
//         graph.Display();

//         Console.WriteLine();

//         // Remove Vertex
//         graph.RemoveVertex(5);

//         Console.WriteLine("Graph after removing vertex 5:");
//         graph.Display();
//     }
// }


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class DirectedUnweightedGraph
// {
//     private Dictionary<int, List<int>> adjacencyList;

//     public DirectedUnweightedGraph()
//     {
//         adjacencyList = new Dictionary<int, List<int>>();
//     }

//     // Add Vertex
//     public void AddVertex(int vertex)
//     {
//         if (!adjacencyList.ContainsKey(vertex))
//         {
//             adjacencyList[vertex] = new List<int>();
//         }
//     }

//     // Add Directed Edge
//     public void AddEdge(int source, int destination)
//     {
//         if (!adjacencyList.ContainsKey(source))
//             AddVertex(source);

//         if (!adjacencyList.ContainsKey(destination))
//             AddVertex(destination);

//         adjacencyList[source].Add(destination);
//     }

//     // Remove Edge
//     public void RemoveEdge(int source, int destination)
//     {
//         if (adjacencyList.ContainsKey(source))
//         {
//             adjacencyList[source].Remove(destination);
//         }
//     }

//     // Remove Vertex
//     public void RemoveVertex(int vertex)
//     {
//         if (!adjacencyList.ContainsKey(vertex))
//             return;

//         foreach (var v in adjacencyList.Keys.ToList())
//         {
//             adjacencyList[v].Remove(vertex);
//         }

//         adjacencyList.Remove(vertex);
//     }

//     // Check Edge
//     public bool HasEdge(int source, int destination)
//     {
//         return adjacencyList.ContainsKey(source) &&
//                adjacencyList[source].Contains(destination);
//     }

//     // Get Neighbors
//     public List<int> GetNeighbors(int vertex)
//     {
//         if (adjacencyList.ContainsKey(vertex))
//             return adjacencyList[vertex];

//         return new List<int>();
//     }

//     // Get All Vertices
//     public List<int> GetAllVertices()
//     {
//         return adjacencyList.Keys.ToList();
//     }

//     // Check Cycle using DFS
//     public bool HasCycle()
//     {
//         HashSet<int> visited = new HashSet<int>();
//         HashSet<int> recursionStack = new HashSet<int>();

//         foreach (int vertex in adjacencyList.Keys)
//         {
//             if (HasCycleDFS(vertex, visited, recursionStack))
//                 return true;
//         }

//         return false;
//     }

//     private bool HasCycleDFS(int vertex, HashSet<int> visited, HashSet<int> recursionStack)
//     {
//         if (recursionStack.Contains(vertex))
//             return true;

//         if (visited.Contains(vertex))
//             return false;

//         visited.Add(vertex);
//         recursionStack.Add(vertex);

//         foreach (int neighbor in adjacencyList[vertex])
//         {
//             if (HasCycleDFS(neighbor, visited, recursionStack))
//                 return true;
//         }

//         recursionStack.Remove(vertex);
//         return false;
//     }

//     // Topological Sort
//     public List<int> TopologicalSort()
//     {
//         if (HasCycle())
//         {
//             Console.WriteLine("Topological Sort not possible. Graph contains a cycle.");
//             return new List<int>();
//         }

//         HashSet<int> visited = new HashSet<int>();
//         Stack<int> stack = new Stack<int>();

//         foreach (int vertex in adjacencyList.Keys)
//         {
//             if (!visited.Contains(vertex))
//             {
//                 TopologicalSortDFS(vertex, visited, stack);
//             }
//         }

//         return stack.ToList();
//     }

//     private void TopologicalSortDFS(int vertex, HashSet<int> visited, Stack<int> stack)
//     {
//         visited.Add(vertex);

//         foreach (int neighbor in adjacencyList[vertex])
//         {
//             if (!visited.Contains(neighbor))
//             {
//                 TopologicalSortDFS(neighbor, visited, stack);
//             }
//         }

//         stack.Push(vertex);
//     }

//     // Display Graph
//     public void Display()
//     {
//         Console.WriteLine("Directed Graph:");

//         foreach (var item in adjacencyList)
//         {
//             Console.Write(item.Key + " -> ");

//             foreach (int neighbor in item.Value)
//             {
//                 Console.Write(neighbor + " ");
//             }

//             Console.WriteLine();
//         }
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         DirectedUnweightedGraph graph = new DirectedUnweightedGraph();

//         // Add Vertices
//         graph.AddVertex(1);
//         graph.AddVertex(2);
//         graph.AddVertex(3);
//         graph.AddVertex(4);
//         graph.AddVertex(5);

//         // Add Directed Edges
//         graph.AddEdge(1, 2);
//         graph.AddEdge(1, 3);
//         graph.AddEdge(2, 4);
//         graph.AddEdge(3, 4);
//         graph.AddEdge(4, 5);

//         Console.WriteLine("Initial Graph:");
//         graph.Display();

//         Console.WriteLine();

//         Console.WriteLine("Edge 1 -> 2 : " + graph.HasEdge(1, 2));
//         Console.WriteLine("Edge 2 -> 1 : " + graph.HasEdge(2, 1));

//         Console.WriteLine();

//         Console.Write("Neighbors of Vertex 1: ");
//         foreach (int n in graph.GetNeighbors(1))
//         {
//             Console.Write(n + " ");
//         }

//         Console.WriteLine("\n");

//         Console.WriteLine("Does Graph Have Cycle? " + graph.HasCycle());

//         Console.WriteLine();

//         Console.Write("Topological Sort: ");
//         List<int> topo = graph.TopologicalSort();

//         foreach (int v in topo)
//         {
//             Console.Write(v + " ");
//         }

//         Console.WriteLine("\n");

//         graph.RemoveEdge(1, 3);

//         Console.WriteLine("Graph after removing edge (1 -> 3):");
//         graph.Display();

//         Console.WriteLine();

//         graph.RemoveVertex(5);

//         Console.WriteLine("Graph after removing vertex 5:");
//         graph.Display();
//     }
// }



// using System;
// using System.Collections.Generic;

// class UndirectedGraph
// {
//     private int vertices;
//     private List<int>[] adj;

//     public UndirectedGraph(int v)
//     {
//         vertices = v;
//         adj = new List<int>[v];

//         for (int i = 0; i < v; i++)
//             adj[i] = new List<int>();
//     }

//     // Add Friendship
//     public void AddEdge(int u, int v)
//     {
//         adj[u].Add(v);
//         adj[v].Add(u);
//     }

//     // Display Graph
//     public void DisplayGraph()
//     {
//         Console.WriteLine("Social Network:");

//         for (int i = 0; i < vertices; i++)
//         {
//             Console.Write(i + " -> ");

//             foreach (int friend in adj[i])
//                 Console.Write(friend + " ");

//             Console.WriteLine();
//         }
//     }

//     // Task 1 - Friends of User
//     public void FriendsOfUser(int user)
//     {
//         Console.Write("Friends of User " + user + ": ");

//         foreach (int friend in adj[user])
//             Console.Write(friend + " ");

//         Console.WriteLine();
//     }

//     // Task 2 - Check Connectivity
//     public bool AreConnected(int start, int end)
//     {
//         bool[] visited = new bool[vertices];
//         Queue<int> queue = new Queue<int>();

//         queue.Enqueue(start);
//         visited[start] = true;

//         while (queue.Count > 0)
//         {
//             int current = queue.Dequeue();

//             if (current == end)
//                 return true;

//             foreach (int neighbor in adj[current])
//             {
//                 if (!visited[neighbor])
//                 {
//                     visited[neighbor] = true;
//                     queue.Enqueue(neighbor);
//                 }
//             }
//         }

//         return false;
//     }

//     // Task 3 - Shortest Path
//     public void ShortestPath(int start, int end)
//     {
//         bool[] visited = new bool[vertices];
//         int[] parent = new int[vertices];

//         for (int i = 0; i < vertices; i++)
//             parent[i] = -1;

//         Queue<int> queue = new Queue<int>();

//         queue.Enqueue(start);
//         visited[start] = true;

//         while (queue.Count > 0)
//         {
//             int current = queue.Dequeue();

//             foreach (int neighbor in adj[current])
//             {
//                 if (!visited[neighbor])
//                 {
//                     visited[neighbor] = true;
//                     parent[neighbor] = current;
//                     queue.Enqueue(neighbor);
//                 }
//             }
//         }

//         if (!visited[end])
//         {
//             Console.WriteLine("No Path Exists.");
//             return;
//         }

//         Stack<int> path = new Stack<int>();

//         int temp = end;

//         while (temp != -1)
//         {
//             path.Push(temp);
//             temp = parent[temp];
//         }

//         Console.Write("Shortest Path: ");

//         while (path.Count > 0)
//             Console.Write(path.Pop() + " ");

//         Console.WriteLine();
//     }

//     // Task 4 - Users at Distance 2
//     public void UsersAtDistanceTwo(int source)
//     {
//         bool[] visited = new bool[vertices];
//         int[] distance = new int[vertices];

//         Queue<int> queue = new Queue<int>();

//         queue.Enqueue(source);
//         visited[source] = true;
//         distance[source] = 0;

//         while (queue.Count > 0)
//         {
//             int current = queue.Dequeue();

//             foreach (int neighbor in adj[current])
//             {
//                 if (!visited[neighbor])
//                 {
//                     visited[neighbor] = true;
//                     distance[neighbor] = distance[current] + 1;
//                     queue.Enqueue(neighbor);
//                 }
//             }
//         }

//         Console.Write("Users at Distance 2 from User " + source + ": ");

//         for (int i = 0; i < vertices; i++)
//         {
//             if (distance[i] == 2)
//                 Console.Write(i + " ");
//         }

//         Console.WriteLine();
//     }

//     // Task 5 - Cycle Detection
//     public bool HasCycle()
//     {
//         bool[] visited = new bool[vertices];

//         for (int i = 0; i < vertices; i++)
//         {
//             if (!visited[i])
//             {
//                 if (DFS(i, visited, -1))
//                     return true;
//             }
//         }

//         return false;
//     }

//     private bool DFS(int current, bool[] visited, int parent)
//     {
//         visited[current] = true;

//         foreach (int neighbor in adj[current])
//         {
//             if (!visited[neighbor])
//             {
//                 if (DFS(neighbor, visited, current))
//                     return true;
//             }
//             else if (neighbor != parent)
//             {
//                 return true;
//             }
//         }

//         return false;
//     }

//     // Task 6 - Connected Components
//     public void ConnectedComponents()
//     {
//         bool[] visited = new bool[vertices];
//         int group = 1;

//         for (int i = 0; i < vertices; i++)
//         {
//             if (!visited[i])
//             {
//                 Console.Write("Friend Group " + group + ": ");
//                 DFSComponent(i, visited);
//                 Console.WriteLine();
//                 group++;
//             }
//         }
//     }

//     private void DFSComponent(int current, bool[] visited)
//     {
//         visited[current] = true;
//         Console.Write(current + " ");

//         foreach (int neighbor in adj[current])
//         {
//             if (!visited[neighbor])
//                 DFSComponent(neighbor, visited);
//         }
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         UndirectedGraph graph = new UndirectedGraph(6);

//         // Add Friendships
//         graph.AddEdge(0, 1);
//         graph.AddEdge(0, 2);
//         graph.AddEdge(1, 3);
//         graph.AddEdge(2, 3);
//         graph.AddEdge(2, 4);
//         graph.AddEdge(3, 5);
//         graph.AddEdge(4, 5);

//         Console.WriteLine("==================================");
//         graph.DisplayGraph();

//         Console.WriteLine("\n==================================");
//         graph.FriendsOfUser(2);

//         Console.WriteLine("\n==================================");
//         if (graph.AreConnected(0, 5))
//             Console.WriteLine("User 0 and User 5 are Connected.");
//         else
//             Console.WriteLine("User 0 and User 5 are NOT Connected.");

//         Console.WriteLine("\n==================================");
//         graph.ShortestPath(0, 5);

//         Console.WriteLine("\n==================================");
//         graph.UsersAtDistanceTwo(1);

//         Console.WriteLine("\n==================================");
//         if (graph.HasCycle())
//             Console.WriteLine("Cycle Detected.");
//         else
//             Console.WriteLine("No Cycle Found.");

//         Console.WriteLine("\n==================================");
//         graph.ConnectedComponents();
//     }
// }

