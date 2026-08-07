using System;

class RecursionPatterns
{
    // ==========================================
    // 1. HEAD RECURSION
    // ==========================================
    static void HeadRecursion(int n)
    {
        // Base case
        if (n == 0)
        {
            return;
        }

        // Recursive call happens first
        HeadRecursion(n - 1);

        // Work happens after recursive call
        Console.WriteLine(n);
    }


    // ==========================================
    // 2. TAIL RECURSION
    // ==========================================
    static void TailRecursion(int n)
    {
        // Base case
        if (n == 0)
        {
            return;
        }

        // Work happens before recursive call
        Console.WriteLine(n);

        // Recursive call is the last operation
        TailRecursion(n - 1);
    }


    // ==========================================
    // 3. TREE RECURSION
    // ==========================================
    static void TreeRecursion(int n)
    {
        // Base case
        if (n == 0)
        {
            return;
        }

        Console.WriteLine(n);

        // First recursive call
        TreeRecursion(n - 1);

        // Second recursive call
        TreeRecursion(n - 1);
    }


    // ==========================================
    // 4. INDIRECT RECURSION
    // ==========================================
    static void IndirectA(int n)
    {
        // Base case
        if (n == 0)
        {
            return;
        }

        Console.WriteLine("A: " + n);

        // Calls another method
        IndirectB(n - 1);
    }

    static void IndirectB(int n)
    {
        // Base case
        if (n == 0)
        {
            return;
        }

        Console.WriteLine("B: " + n);

        // Calls the first method
        IndirectA(n - 1);
    }


    // ==========================================
    // MAIN METHOD
    // ==========================================
    static void Main()
    {
        Console.WriteLine("===== HEAD RECURSION =====");
        HeadRecursion(5);

        Console.WriteLine();

        Console.WriteLine("===== TAIL RECURSION =====");
        TailRecursion(5);

        Console.WriteLine();

        Console.WriteLine("===== TREE RECURSION =====");
        TreeRecursion(3);

        Console.WriteLine();

        Console.WriteLine("===== INDIRECT RECURSION =====");
        IndirectA(5);
    }
}