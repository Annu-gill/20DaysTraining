using System;

public class LibraryBook
{
    // private: accessible only inside LibraryBook
    private string _isbn;


    // public: accessible from anywhere
    public string Title;

    // protected: accessible inside LibraryBook and derived classes
    protected string ShelfLocation = "Unassigned";

    // internal: accessible anywhere within the same project/assembly
    internal int CopiesAvailable;

    // static: one shared value for the entire class
    public static int TotalBooksCreated;


    // Constructor
    public LibraryBook(string title, string isbn)
    {
        Title = title;
        _isbn = isbn;

        // Every new LibraryBook starts with one copy
        CopiesAvailable = 1;

        // Shared by all LibraryBook objects
        TotalBooksCreated++;
    }


    // protected internal:
    // accessible from the same assembly OR from a derived class
    protected internal void Relocate(string newLocation)
    {
        ShelfLocation = newLocation;
    }


    // private protected:
    // accessible inside LibraryBook and derived classes
    // within the same assembly
    private protected void AdjustCopies(int delta)
    {
        CopiesAvailable += delta;
    }

}

// Derived class
public class ReferenceBook : LibraryBook
{
    public ReferenceBook(string title, string isbn)
    : base(title, isbn)
    {
    }

    public void PrintLocation()
    {
        // ShelfLocation is protected,
        // so the derived class can access it.
        Relocate("Reference Section");

        // AdjustCopies is private protected,
        // so the derived class can access it.
        AdjustCopies(2);

        Console.WriteLine(
            $"ReferenceBook shelf location after Relocate: \"{ShelfLocation}\"");

        Console.WriteLine(
            $"Copies available after AdjustCopies(+2): {CopiesAvailable}");
    }


}

public class Lab2
{
    public static void Run()
    {
        // Create three LibraryBook objects
        LibraryBook book1 = new LibraryBook(
        "C# Programming",
        "ISBN001");

        Console.WriteLine(
            $"Book 1 created. Total books so far: {LibraryBook.TotalBooksCreated}");


        LibraryBook book2 = new LibraryBook(
            "Object Oriented Programming",
            "ISBN002");

        Console.WriteLine(
            $"Book 2 created. Total books so far: {LibraryBook.TotalBooksCreated}");


        LibraryBook book3 = new LibraryBook(
            "Data Structures",
            "ISBN003");

        Console.WriteLine(
            $"Book 3 created. Total books so far: {LibraryBook.TotalBooksCreated}");


        Console.WriteLine();


        // Create a derived ReferenceBook
        ReferenceBook referenceBook = new ReferenceBook(
            "C# Reference Guide",
            "ISBN004");

        referenceBook.PrintLocation();
    }
}
