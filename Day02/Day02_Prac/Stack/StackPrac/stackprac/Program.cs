
// using System;

// class StackArray
// {
//     int[] stack = new int[5];
//     int top = -1;

//     public void Push(int value)
//     {
//         if (top == stack.Length - 1)
//         {
//             Console.WriteLine("Stack Overflow");
//             return;
//         }

//         stack[++top] = value;
//     }

//     public void Pop()
//     {
//         if (top == -1)
//         {
//             Console.WriteLine("Stack Underflow");
//             return;
//         }

//         Console.WriteLine("Deleted: " + stack[top--]);
//     }

//     public void Display()
//     {
//         for (int i = top; i >= 0; i--)
//             Console.WriteLine(stack[i]);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         StackArray s = new StackArray();

//         s.Push(10);
//         s.Push(20);
//         s.Push(30);

//         s.Display();

//         s.Pop();

//         s.Display();
//     }
// }



using System;

class BrowserHistory
{
    string[] history = new string[10];
    int top = -1;

    public void VisitPage(string page)
    {
        if (top == history.Length - 1)
        {
            Console.WriteLine("History Full");
            return;
        }

        history[++top] = page;
        Console.WriteLine("Visited: " + page);
    }

    public void Back()
    {
        if (top == -1)
        {
            Console.WriteLine("No History");
            return;
        }

        Console.WriteLine("Removed: " + history[top--]);
    }

    public void CurrentPage()
    {
        if (top == -1)
        {
            Console.WriteLine("No Current Page");
            return;
        }

        Console.WriteLine("Current Page: " + history[top]);
    }

    public void DisplayHistory()
    {
        if (top == -1)
        {
            Console.WriteLine("History Empty");
            return;
        }

        Console.WriteLine("Browser History:");

        for (int i = top; i >= 0; i--)
            Console.WriteLine(history[i]);
    }

    public void ClearHistory()
    {
        top = -1;
        Console.WriteLine("History Cleared");
    }

    public void TotalPages()
    {
        Console.WriteLine("Total Pages: " + (top + 1));
    }
}

class Program
{
    static void Main()
    {
        BrowserHistory browser = new BrowserHistory();

        while (true)
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("Browser History System");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Visit Page");
            Console.WriteLine("2. Back");
            Console.WriteLine("3. Current Page");
            Console.WriteLine("4. Display History");
            Console.WriteLine("5. Clear History");
            Console.WriteLine("6. Total Pages");
            Console.WriteLine("7. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Website: ");
                    string page = Console.ReadLine();
                    browser.VisitPage(page);
                    break;

                case 2:
                    browser.Back();
                    break;

                case 3:
                    browser.CurrentPage();
                    break;

                case 4:
                    browser.DisplayHistory();
                    break;

                case 5:
                    browser.ClearHistory();
                    break;

                case 6:
                    browser.TotalPages();
                    break;

                case 7:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}




