using System;
using System.Collections.Generic;

public class CacheEntryOptions
{
    // --------------------------------
    // Auto-implemented properties
    // --------------------------------

    public string Label { get; set; } = string.Empty;

    public bool Pinned { get; set; }
}

public class TypedCache<TKey, TValue>
    where TKey : notnull
{
    // --------------------------------
    // Dictionary storing key/value pairs
    // --------------------------------

    private readonly Dictionary<TKey, TValue> _store = new();

    // --------------------------------
    // Dictionary storing entry metadata
    // --------------------------------

    private readonly Dictionary<TKey, CacheEntryOptions> _options = new();

    // --------------------------------
    // Static state
    // Shared by all instances of the
    // same closed generic type
    // --------------------------------

    private static int _totalInstances;

    // --------------------------------
    // Constructor
    // --------------------------------

    public TypedCache()
    {
        _totalInstances++;
    }

    // --------------------------------
    // Indexer
    // --------------------------------

    public TValue this[TKey key]
    {
        get
        {
            if (!_store.ContainsKey(key))
            {
                throw new KeyNotFoundException(
                    $"The given key '{key}' was not present in the cache."
                );
            }

            return _store[key];
        }

        set
        {
            _store[key] = value;
        }
    }

    // --------------------------------
    // Read-only expression-bodied property
    // --------------------------------

    public int Count => _store.Count;

    // --------------------------------
    // Static property
    // --------------------------------

    public static int TotalCacheInstances =>
        _totalInstances;

    // --------------------------------
    // Static method
    // --------------------------------

    public static void PrintGlobalStats()
    {
        Console.WriteLine(
            $"Global TypedCache<{typeof(TKey).Name}," +
            $"{typeof(TValue).Name}> instances created: " +
            $"{TotalCacheInstances}"
        );
    }

    // --------------------------------
    // Add method
    // --------------------------------

    public void Add(
        TKey key,
        TValue value,
        CacheEntryOptions? options = null)
    {
        _store[key] = value;

        // If no options are supplied,
        // create default options.
        _options[key] =
            options ?? new CacheEntryOptions();
    }

    // --------------------------------
    // Bonus: Evict
    // --------------------------------

    public bool Evict(TKey key)
    {
        if (!_store.ContainsKey(key))
        {
            return false;
        }

        if (_options.TryGetValue(key, out CacheEntryOptions? options))
        {
            if (options.Pinned)
            {
                return false;
            }
        }

        _store.Remove(key);
        _options.Remove(key);

        return true;
    }
}

public class Lab6
{
    public static void Run()
    {
        // --------------------------------
        // Create first cache
        // --------------------------------

        TypedCache<string, int> cache1 =
            new TypedCache<string, int>();

        // Add entries
        cache1.Add("a", 1);

        cache1.Add(
            "b",
            2,
            new CacheEntryOptions
            {
                Label = "Important",
                Pinned = true
            }
        );

        // --------------------------------
        // Create second cache
        // --------------------------------

        TypedCache<string, int> cache2 =
            new TypedCache<string, int>();

        cache2.Add("x", 100);

        cache2.Add(
            "y",
            200,
            new CacheEntryOptions
            {
                Label = "Temporary",
                Pinned = false
            }
        );

        // --------------------------------
        // Read values using indexer
        // --------------------------------

        Console.WriteLine(
            $"cache1[\"a\"] = {cache1["a"]}"
        );

        // --------------------------------
        // Print Count
        // --------------------------------

        Console.WriteLine(
            $"cache1 Count: {cache1.Count}"
        );

        // --------------------------------
        // Missing key test
        // --------------------------------

        try
        {
            Console.WriteLine(
                cache1["z"]
            );
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(
                $"Missing key caught: {ex.Message}"
            );
        }

        // --------------------------------
        // Test indexer setter
        // --------------------------------

        cache1["a"] = 10;

        Console.WriteLine(
            $"cache1[\"a\"] after overwrite: " +
            $"{cache1["a"]}"
        );

        // --------------------------------
        // Static global statistics
        // --------------------------------

        TypedCache<string, int>.PrintGlobalStats();

        // --------------------------------
        // Bonus: Evict
        // --------------------------------

        bool evictedY = cache2.Evict("y");

        Console.WriteLine(
            $"Evict cache2[\"y\"]: {evictedY}"
        );

        // Pinned entry cannot be evicted
        bool evictedB = cache1.Evict("b");

        Console.WriteLine(
            $"Evict pinned cache1[\"b\"]: {evictedB}"
        );
    }
}