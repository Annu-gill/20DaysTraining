using System;

// =====================================================
// 1. METHOD OVERLOADING
// =====================================================

public class Formatter
{
    // Format(int)
    public string Format(int value)
    {
        return value.ToString();
    }

    // Format(double)
    public string Format(double value)
    {
        return value.ToString("F2");
    }


    // Format(int, int)
    // Treat the two integers as a fraction.
    public string Format(int numerator, int denominator)
    {
        return $"{numerator}/{denominator}";
    }

}

// =====================================================
// 2. BASE CLASS
// =====================================================

public class Notifier
{
    // Virtual method
    public virtual void Send()
    {
        Console.WriteLine("Notifier: generic send");
    }

    // Non-virtual method
    public void Log()
    {
        Console.WriteLine("Notifier: generic log");
    }

}

// =====================================================
// 3. OVERRIDE AND METHOD HIDING
// =====================================================

public class EmailNotifier : Notifier
{
    // Override the virtual Send() method.
    public override void Send()
    {
        Console.WriteLine("EmailNotifier: sending email");
    }

    // Hide the inherited Log() method.
    public new void Log()
    {
        Console.WriteLine("EmailNotifier: logging to email log");
    }


}

// =====================================================
// 4. OPERATOR OVERLOADING
// =====================================================

public struct Vector2
{
    public double X;
    public double Y;


    public Vector2(double x, double y)
    {
        X = x;
        Y = y;
    }


    // Operator +
    // Adds two Vector2 objects.
    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(
            a.X + b.X,
            a.Y + b.Y);
    }


    // Operator *
    // Multiplies a vector by a scalar.
    public static Vector2 operator *(Vector2 vector, double scalar)
    {
        return new Vector2(
            vector.X * scalar,
            vector.Y * scalar);
    }


    // Bonus: == operator
    public static bool operator ==(Vector2 a, Vector2 b)
    {
        return a.X == b.X && a.Y == b.Y;
    }


    // Bonus: != operator
    public static bool operator !=(Vector2 a, Vector2 b)
    {
        return !(a == b);
    }


    // Bonus: Equals
    public override bool Equals(object? obj)
    {
        if (obj is Vector2 other)
        {
            return this == other;
        }

        return false;
    }


    // Bonus: GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }


    public override string ToString()
    {
        return $"({X}, {Y})";
    }


}

// =====================================================
// LAB 5 DRIVER
// =====================================================

public class Lab5
{
    public static void Run()
    {
        // =================================================
        // METHOD OVERLOADING
        // =================================================

        Formatter formatter = new Formatter();

        Console.WriteLine(
            $"Format(7) -> \"{formatter.Format(7)}\"");

        Console.WriteLine(
            $"Format(3.5) -> \"{formatter.Format(3.5)}\"");

        Console.WriteLine(
            $"Format(3, 4) -> \"{formatter.Format(3, 4)}\"");


        Console.WriteLine();


        // =================================================
        // OVERRIDE VS HIDE
        // =================================================

        EmailNotifier email = new EmailNotifier();

        // Same object, EmailNotifier reference
        Console.WriteLine("-- through EmailNotifier variable --");

        email.Send();
        email.Log();


        Console.WriteLine();


        // Same object, but Notifier reference
        Notifier notifier = email;

        Console.WriteLine(
            "-- through Notifier variable, same object --");

        notifier.Send();
        notifier.Log();


        Console.WriteLine();


        // =================================================
        // OPERATOR OVERLOADING
        // =================================================

        Vector2 vector1 = new Vector2(1, 2);
        Vector2 vector2 = new Vector2(3, 4);

        Vector2 sum = vector1 + vector2;

        Console.WriteLine(
            $"{vector1} + {vector2} = {sum}");


        Vector2 vector3 = new Vector2(2, 2);

        Vector2 scaled = vector3 * 3;

        Console.WriteLine(
            $"{vector3} * 3 = {scaled}");


        // =================================================
        // BONUS: == AND !=
        // =================================================

        Vector2 vector4 = new Vector2(5, 5);
        Vector2 vector5 = new Vector2(5, 5);

        Console.WriteLine();

        Console.WriteLine(
            $"vector4 == vector5: {vector4 == vector5}");

        Console.WriteLine(
            $"vector4 != vector5: {vector4 != vector5}");
    }
}
