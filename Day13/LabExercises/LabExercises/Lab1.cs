using System;

public struct RgbColor
{
    public byte R;
    public byte G;
    public byte B;

    // Constructor
    public RgbColor(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    // Convert RGB values to #RRGGBB format
    public override string ToString()
    {
        return $"#{R:X2}{G:X2}{B:X2}";
    }
}

// Enum containing named colors
public enum NamedColor
{
    Red,
    Green,
    Blue,
    White,
    Black
}

// Class containing an RgbColor
public class Pixel
{
    public RgbColor Color;
}

public class Lab1
{
    // Convert NamedColor into RgbColor
    public static RgbColor FromNamed(NamedColor name)
    {
        switch (name)
        {
            case NamedColor.Red:
                return new RgbColor(255, 0, 0);

            case NamedColor.Green:
                return new RgbColor(0, 255, 0);

            case NamedColor.Blue:
                return new RgbColor(0, 0, 255);

            case NamedColor.White:
                return new RgbColor(255, 255, 255);

            case NamedColor.Black:
                return new RgbColor(0, 0, 0);

            default:
                return new RgbColor(0, 0, 0);
        }
    }


    // Driver method
    public static void Run()
    {
        // --------------------------------
        // STRUCT COPY
        // --------------------------------

        Console.WriteLine("-- struct copy --");

        RgbColor a = FromNamed(NamedColor.Red);

        // Struct value is copied
        RgbColor b = a;

        // Modify only b
        b.R = 1;

        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");


        // --------------------------------
        // CLASS / REFERENCE COPY
        // --------------------------------

        Console.WriteLine();
        Console.WriteLine("-- class/reference copy --");

        Pixel p1 = new Pixel();

        p1.Color = FromNamed(NamedColor.Green);

        // Reference is copied
        Pixel p2 = p1;

        // Modify p2's Color
        p2.Color = new RgbColor(0, 255, 0);

        Console.WriteLine($"p1.Color = {p1.Color}");
        Console.WriteLine($"p2.Color = {p2.Color}");
    }
}
