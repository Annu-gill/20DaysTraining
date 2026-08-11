using System;
using System.Collections.Generic;
using System.Linq;

// =====================================================
// 1. ENUM
// =====================================================

public enum ShapeKind
{
    Circle,
    Rectangle,
    Triangle
}

// =====================================================
// 2. ABSTRACT BASE CLASS
// =====================================================

public abstract class Shape
{
    public ShapeKind Kind { get; protected set; }

    // Abstract methods
    public abstract double Area();

    public abstract double Perimeter();


    // Concrete override of ToString()
    public override string ToString()
    {
        return $"{Kind}: Area={Area():F2}, Perimeter={Perimeter():F2}";
    }

}

// =====================================================
// 3. CIRCLE
// =====================================================

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Kind = ShapeKind.Circle;
        Radius = radius;
    }


    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }


    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }

}

// =====================================================
// 4. RECTANGLE
// =====================================================

public class Rectangle : Shape
{
    public double Width { get; }

    public double Height { get; }


    public Rectangle(double width, double height)
    {
        Kind = ShapeKind.Rectangle;

        Width = width;
        Height = height;
    }


    public override double Area()
    {
        return Width * Height;
    }


    public override double Perimeter()
    {
        return 2 * (Width + Height);
    }

}

// =====================================================
// 5. TRIANGLE
// =====================================================

public class Triangle : Shape
{
    public double SideA { get; }

    public double SideB { get; }

    public double SideC { get; }


    public Triangle(
        double sideA,
        double sideB,
        double sideC)
    {
        Kind = ShapeKind.Triangle;

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }


    public override double Area()
    {
        // Heron's formula

        double semiPerimeter =
            (SideA + SideB + SideC) / 2;

        return Math.Sqrt(
            semiPerimeter *
            (semiPerimeter - SideA) *
            (semiPerimeter - SideB) *
            (semiPerimeter - SideC));
    }


    public override double Perimeter()
    {
        return SideA + SideB + SideC;
    }

}

// =====================================================
// 6. BOUNDING BOX STRUCT
// =====================================================

public struct BoundingBox
{
    public double Width;

    public double Height;


    public BoundingBox(double width, double height)
    {
        Width = width;
        Height = height;
    }


    // Operator * overload
    // Scales both width and height.
    public static BoundingBox operator *(
        BoundingBox box,
        double factor)
    {
        return new BoundingBox(
            box.Width * factor,
            box.Height * factor);
    }


    // Bonus: Deconstruct
    public void Deconstruct(
        out double width,
        out double height)
    {
        width = Width;
        height = Height;
    }

}

// =====================================================
// 7. SHAPE MATH
// =====================================================

public static class ShapeMath
{
    // Total area of ALL shapes
    public static double TotalArea(
    IEnumerable<Shape> shapes)
    {
        return shapes.Sum(shape => shape.Area());
    }

    // Total area of only a particular ShapeKind
    public static double TotalArea(
        IEnumerable<Shape> shapes,
        ShapeKind onlyKind)
    {
        return shapes
            .Where(shape => shape.Kind == onlyKind)
            .Sum(shape => shape.Area());
    }

}

// =====================================================
// 8. LAB 6 DRIVER
// =====================================================

public class Lab6
{
    public static void Run()
    {
        // ---------------------------------------------
        // Create a list of different shapes
        // ---------------------------------------------

        List<Shape> shapes = new List<Shape>
    {
        new Circle(3),

        new Rectangle(6, 4),

        new Triangle(3, 4, 5)
    };


        // ---------------------------------------------
        // Print shapes using polymorphism
        // ---------------------------------------------

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape);
        }


        Console.WriteLine();


        // ---------------------------------------------
        // Total area of all shapes
        // ---------------------------------------------

        double totalArea =
            ShapeMath.TotalArea(shapes);

        Console.WriteLine(
            $"Total area (all shapes): {totalArea:F2}");


        // ---------------------------------------------
        // Total area of circles only
        // ---------------------------------------------

        double circleArea =
            ShapeMath.TotalArea(
                shapes,
                ShapeKind.Circle);

        Console.WriteLine(
            $"Total area (circles only): {circleArea:F2}");


        Console.WriteLine();


        // ---------------------------------------------
        // BoundingBox operator *
        // ---------------------------------------------

        BoundingBox box =
            new BoundingBox(4, 3);

        BoundingBox scaledBox =
            box * 2;

        Console.WriteLine(
            $"Scaled bounding box (4 x 3) * 2 -> " +
            $"({scaledBox.Width:0}, {scaledBox.Height:0})");


        // ---------------------------------------------
        // Bonus: Deconstruct
        // ---------------------------------------------

        var (width, height) = scaledBox;

        Console.WriteLine(
            $"Deconstructed box: Width={width}, Height={height}");
    }

}
