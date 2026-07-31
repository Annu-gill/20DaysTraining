using System;
using System.Collections.Generic;

/// <summary>
/// Represents a Directed Graph for the Course Prerequisite System.
/// Edge: Prerequisite Course -> Dependent Course
/// </summary>
class DirectedGraph
{
    // Total number of courses
    private int vertices;

    // Adjacency List to store the graph
    private List<int>[] adj;

    /// <summary>
    /// Constructor to initialize graph with given number of vertices.
    /// </summary>
    public DirectedGraph(int v)
    {
        vertices = v;
        adj = new List<int>[v];

        // Create an empty list for every course
        for (int i = 0; i < v; i++)
        {
            adj[i] = new List<int>();
        }
    }

    /// <summary>
    /// Adds a directed edge from prerequisite course to dependent course.
    /// </summary>
    public void AddEdge(int from, int to)
    {
        adj[from].Add(to);
    }

    /// <summary>
    /// Displays the adjacency list representation of the graph.
    /// </summary>
    public void DisplayGraph()
    {
        Console.WriteLine("Course Dependency Graph:");

        for (int i = 0; i < vertices; i++)
        {
            Console.Write(i + " -> ");

            foreach (int neighbor in adj[i])
            {
                Console.Write(neighbor + " ");
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Creates the reverse graph.
    /// Original Edge : A -> B
    /// Reverse Edge  : B -> A
    /// Used to find prerequisites.
    /// </summary>
    public List<int>[] GetReverseGraph()
    {
        List<int>[] reverse = new List<int>[vertices];

        for (int i = 0; i < vertices; i++)
            reverse[i] = new List<int>();

        for (int i = 0; i < vertices; i++)
        {
            foreach (int neighbor in adj[i])
            {
                reverse[neighbor].Add(i);
            }
        }

        return reverse;
    }

    /// <summary>
    /// Prints all direct and indirect prerequisites of a course.
    /// </summary>
    public void PrintAllPrerequisites(int course)
    {
        List<int>[] reverse = GetReverseGraph();

        bool[] visited = new bool[vertices];

        Console.Write("All prerequisites of Course " + course + ": ");

        DFSPrerequisite(course, reverse, visited);

        Console.WriteLine();
    }

    /// <summary>
    /// DFS on reverse graph to visit all prerequisite courses.
    /// </summary>
    private void DFSPrerequisite(int course, List<int>[] reverse, bool[] visited)
    {
        foreach (int pre in reverse[course])
        {
            if (!visited[pre])
            {
                visited[pre] = true;
                Console.Write(pre + " ");

                DFSPrerequisite(pre, reverse, visited);
            }
        }
    }

    /// <summary>
    /// Prints only the direct prerequisites of a course.
    /// </summary>
    public void PrintDirectPrerequisites(int course)
    {
        List<int>[] reverse = GetReverseGraph();

        Console.Write("Direct prerequisites of Course " + course + ": ");

        foreach (int pre in reverse[course])
        {
            Console.Write(pre + " ");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Checks whether the graph contains a cycle.
    /// </summary>
    public bool HasCycle()
    {
        bool[] visited = new bool[vertices];
        bool[] recStack = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            if (HasCycleDFS(i, visited, recStack))
                return true;
        }

        return false;
    }

    /// <summary>
    /// DFS function used for cycle detection.
    /// Recursion stack keeps track of current DFS path.
    /// </summary>
    private bool HasCycleDFS(int vertex, bool[] visited, bool[] recStack)
    {
        if (!visited[vertex])
        {
            visited[vertex] = true;
            recStack[vertex] = true;

            foreach (int neighbor in adj[vertex])
            {
                // Visit unvisited neighbor
                if (!visited[neighbor] && HasCycleDFS(neighbor, visited, recStack))
                    return true;

                // Neighbor already in recursion stack => Cycle
                else if (recStack[neighbor])
                    return true;
            }
        }

        // Remove vertex from recursion stack
        recStack[vertex] = false;

        return false;
    }

    /// <summary>
    /// Performs Topological Sorting using Kahn's Algorithm.
    /// </summary>
    public void TopologicalSort()
    {
        int[] indegree = new int[vertices];

        // Calculate indegree of every vertex
        for (int i = 0; i < vertices; i++)
        {
            foreach (int neighbor in adj[i])
            {
                indegree[neighbor]++;
            }
        }

        Queue<int> queue = new Queue<int>();

        // Insert all vertices having indegree 0
        for (int i = 0; i < vertices; i++)
        {
            if (indegree[i] == 0)
                queue.Enqueue(i);
        }

        Console.Write("Topological Order: ");

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            Console.Write(current + " ");

            foreach (int neighbor in adj[current])
            {
                indegree[neighbor]--;

                if (indegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Prints all courses that have no prerequisites.
    /// </summary>
    public void CoursesWithNoPrerequisites()
    {
        int[] indegree = new int[vertices];

        // Calculate indegree
        for (int i = 0; i < vertices; i++)
        {
            foreach (int neighbor in adj[i])
            {
                indegree[neighbor]++;
            }
        }

        Console.Write("Courses with no prerequisites: ");

        for (int i = 0; i < vertices; i++)
        {
            if (indegree[i] == 0)
                Console.Write(i + " ");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Counts how many courses directly depend on a given course.
    /// </summary>
    public void CountDependents(int course)
    {
        Console.WriteLine("Courses directly depending on Course " + course + ": " + adj[course].Count);
    }
}

class Program
{
    static void Main()
    {
        // Create graph with 6 courses (0 to 5)
        DirectedGraph graph = new DirectedGraph(6);

        // Add prerequisite relationships
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
        graph.PrintAllPrerequisites(5);

        Console.WriteLine("----------------------------------------");
        graph.PrintDirectPrerequisites(3);

        Console.WriteLine("----------------------------------------");
        if (graph.HasCycle())
            Console.WriteLine("Graph contains a cycle.");
        else
            Console.WriteLine("Graph has no cycle.");

        Console.WriteLine("----------------------------------------");
        if (!graph.HasCycle())
            graph.TopologicalSort();

        Console.WriteLine("----------------------------------------");
        graph.CoursesWithNoPrerequisites();

        Console.WriteLine("----------------------------------------");
        graph.CountDependents(2);
    }
}