using System;
using System.Collections.Generic;

public class Box<T>
{
    private T _value;

    public Box(T value)
    {
        _value = value;
    }

    public T GetValue()
    {
        return _value;
    }

    public void Replace(T newValue)
    {
        _value = newValue;
    }
}

// Generic factory for creating a Box with a default value
public static class BoxFactory
{
    public static Box<T> CreateEmpty<T>() where T : new()
    {
        return new Box<T>(new T());
    }
}

public class Pair<TFirst, TSecond>
{
    public TFirst First { get; set; }

    public TSecond Second { get; set; }

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }

    public override string ToString()
    {
        return $"({First}, {Second})";
    }
}

public class SortedBox<T> where T : IComparable<T>
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
        _items.Sort();
    }

    public List<T> Items
    {
        get
        {
            return _items;
        }
    }
}

public class Lab1
{
    public static void Run()
    {
        // --------------------------------
        // Test Box<int>
        // --------------------------------

        Box<int> intBox = new Box<int>(42);

        Console.WriteLine(
            $"Box<int>: {intBox.GetValue()}"
        );

        // --------------------------------
        // Test Box<string>
        // --------------------------------

        Box<string> stringBox =
            new Box<string>("Hello");

        Console.WriteLine(
            $"Box<string>: {stringBox.GetValue()}"
        );

        // --------------------------------
        // Test Box<DateTime>
        // --------------------------------

        Box<DateTime> dateBox =
            new Box<DateTime>(
                new DateTime(2026, 8, 12)
            );

        Console.WriteLine(
            $"Box<DateTime>: " +
            $"{dateBox.GetValue():yyyy-MM-dd}"
        );

        // --------------------------------
        // Test Replace()
        // --------------------------------

        intBox.Replace(100);

        Console.WriteLine(
            $"After Replace: {intBox.GetValue()}"
        );

        // --------------------------------
        // Test CreateEmpty<T>()
        // --------------------------------

        Box<int> emptyIntBox =
            BoxFactory.CreateEmpty<int>();

        Console.WriteLine(
            $"Empty Box<int>: " +
            $"{emptyIntBox.GetValue()}"
        );

        // --------------------------------
        // Test Pair<TFirst, TSecond>
        // --------------------------------

        Pair<string, int> pair =
            new Pair<string, int>("Age", 30);

        Console.WriteLine(
            $"Pair: {pair}"
        );

        // --------------------------------
        // Test SortedBox<T>
        // --------------------------------

        SortedBox<int> sortedBox =
            new SortedBox<int>();

        sortedBox.Add(5);
        sortedBox.Add(1);
        sortedBox.Add(3);

        Console.WriteLine(
            $"SortedBox after adding 5, 1, 3: " +
            $"{string.Join(", ", sortedBox.Items)}"
        );
    }
}