using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    public static long gridlandMetro(
        int n,
        int m,
        int k,
        List<List<int>> track)
    {
        // Group tracks by row
        Dictionary<int, List<(int start, int end)>> rows =
            new Dictionary<int, List<(int start, int end)>>();

        foreach (List<int> t in track)
        {
            int row = t[0];
            int start = t[1];
            int end = t[2];

            if (!rows.ContainsKey(row))
            {
                rows[row] = new List<(int start, int end)>();
            }

            rows[row].Add((start, end));
        }

        long occupiedCells = 0;

        // Process every row
        foreach (var row in rows)
        {
            List<(int start, int end)> tracks = row.Value;

            // Sort by starting column
            tracks.Sort((a, b) => a.start.CompareTo(b.start));

            int currentStart = tracks[0].start;
            int currentEnd = tracks[0].end;

            for (int i = 1; i < tracks.Count; i++)
            {
                int nextStart = tracks[i].start;
                int nextEnd = tracks[i].end;

                // Overlapping tracks
                if (nextStart <= currentEnd)
                {
                    currentEnd = Math.Max(currentEnd, nextEnd);
                }
                else
                {
                    // Count current merged track
                    occupiedCells +=
                        (long)currentEnd - currentStart + 1;

                    // Start new track
                    currentStart = nextStart;
                    currentEnd = nextEnd;
                }
            }

            // Count last merged track
            occupiedCells +=
                (long)currentEnd - currentStart + 1;
        }

        // Use long to prevent integer overflow
        long totalCells = (long)n * m;

        return totalCells - occupiedCells;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        // Read n, m, k
        string[] firstInput = Console.ReadLine()!
            .Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int n = int.Parse(firstInput[0]);
        int m = int.Parse(firstInput[1]);
        int k = int.Parse(firstInput[2]);

        List<List<int>> track = new List<List<int>>();

        // Read tracks
        for (int i = 0; i < k; i++)
        {
            string[] input = Console.ReadLine()!
                .Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            track.Add(new List<int>
            {
                int.Parse(input[0]),
                int.Parse(input[1]),
                int.Parse(input[2])
            });
        }

        long result = Result.gridlandMetro(n, m, k, track);

        // For local dotnet run
        Console.WriteLine(result);
    }
}