using System;

public class TaxCalculator
{
    // Virtual method
    public virtual decimal CalculateTax(decimal amount)
    {
        return amount * 0.10m;
    }
}


// Derived class
public class RegionalTaxCalculator : TaxCalculator
{
    // Override is sealed.
    // No further derived class can override this method.
    public sealed override decimal CalculateTax(decimal amount)
    {
        return amount * 0.12m;
    }
}


/*
    This code intentionally does NOT compile.

    RegionalTaxCalculator has sealed CalculateTax().
    Therefore, another class cannot override it.

    Uncommenting this class produces a compiler error:

    'InvalidTaxCalculator.CalculateTax(decimal)':
    cannot override inherited member
    'RegionalTaxCalculator.CalculateTax(decimal)'
    because it is sealed.

public class InvalidTaxCalculator : RegionalTaxCalculator
{
    public override decimal CalculateTax(decimal amount)
    {
        return amount * 0.15m;
    }
}
*/


// Completely sealed class
public sealed class FixedDiscountCalculator
{
    public decimal ApplyDiscount(decimal price)
    {
        return price * 0.90m;
    }
}


/*
    This code intentionally does NOT compile.

    FixedDiscountCalculator is sealed.
    Therefore, no class can inherit from it.

    Uncommenting this class produces a compiler error:

    'InvalidDiscountCalculator':
    cannot derive from sealed type 'FixedDiscountCalculator'

public class InvalidDiscountCalculator : FixedDiscountCalculator
{
}
*/


public class Lab3
{
    public static void Run()
    {
        // --------------------------------
        // Regional Tax Calculator
        // --------------------------------

        RegionalTaxCalculator regionalTax =
            new RegionalTaxCalculator();

        decimal tax =
            regionalTax.CalculateTax(200);

        Console.WriteLine(
            $"RegionalTaxCalculator.CalculateTax(200) -> {tax:F2}"
        );


        // --------------------------------
        // Fixed Discount Calculator
        // --------------------------------

        FixedDiscountCalculator discountCalculator =
            new FixedDiscountCalculator();

        decimal discountedPrice =
            discountCalculator.ApplyDiscount(50);

        Console.WriteLine(
            $"FixedDiscountCalculator.ApplyDiscount(50) -> {discountedPrice:F2}"
        );
    }
}