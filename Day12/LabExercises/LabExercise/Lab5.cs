using System;
using System.Collections.Generic;
using System.Linq;


// ==========================================
// 1. IIdentifiable Interface
// ==========================================

public interface IIdentifiable
{
    string Id { get; }
}


// ==========================================
// 2. IPaymentMethod Interface
// ==========================================

public interface IPaymentMethod : IIdentifiable
{
    string DisplayName { get; }

    PaymentResult Charge(decimal amount);
}


// ==========================================
// 3. PaymentResult Class
// ==========================================

public class PaymentResult
{
    public bool Success { get; }

    public string Message { get; }

    public PaymentResult(bool success, string message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        Success = success;
        Message = message;
    }
}


// ==========================================
// 4. Abstract PaymentMethodBase
// ==========================================

public abstract class PaymentMethodBase : IPaymentMethod
{
    public string Id { get; }

    public string DisplayName { get; }

    protected PaymentMethodBase(
        string id,
        string displayName)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException(
                "Id cannot be empty.",
                nameof(id));
        }

        if (string.IsNullOrWhiteSpace(displayName))
        {
            throw new ArgumentException(
                "DisplayName cannot be empty.",
                nameof(displayName));
        }

        Id = id;
        DisplayName = displayName;
    }

    public abstract PaymentResult Charge(decimal amount);
}


// ==========================================
// 5. CreditCardPayment
// ==========================================

public class CreditCardPayment : PaymentMethodBase
{
    public CreditCardPayment(
        string id,
        string displayName)
        : base(id, displayName)
    {
    }

    public override PaymentResult Charge(decimal amount)
    {
        if (amount <= 0)
        {
            return new PaymentResult(
                false,
                "Amount must be greater than zero.");
        }

        if (amount > 5000)
        {
            return new PaymentResult(
                false,
                "Credit card limit exceeded.");
        }

        return new PaymentResult(
            true,
            "Credit card payment successful.");
    }
}


// ==========================================
// 6. Sealed CashPayment
// ==========================================

public sealed class CashPayment : PaymentMethodBase
{
    public CashPayment(
        string id,
        string displayName)
        : base(id, displayName)
    {
    }

    public override PaymentResult Charge(decimal amount)
    {
        if (amount <= 0)
        {
            return new PaymentResult(
                false,
                "Amount must be greater than zero.");
        }

        return new PaymentResult(
            true,
            "Cash payment successful.");
    }
}


// ==========================================
// 7. Lab Driver
// ==========================================

public class Lab5
{
    public static void Run()
    {
        // ------------------------------------------
        // Create payment methods
        // ------------------------------------------

        List<IPaymentMethod> paymentMethods =
            new List<IPaymentMethod>
            {
                new CreditCardPayment(
                    "CC-1",
                    "Visa ...1234"),

                new CashPayment(
                    "CASH-1",
                    "Cash Drawer")
            };


        // ------------------------------------------
        // Amounts to process
        // ------------------------------------------

        decimal[] amounts =
        {
            1500m,
            6000m
        };


        // ------------------------------------------
        // Anonymous settlement report
        // ------------------------------------------

        var settlementReport =
            from payment in paymentMethods
            from amount in amounts
            let result = payment.Charge(amount)
            select new
            {
                Id = payment.Id,
                DisplayName = payment.DisplayName,
                AmountAttempted = amount,
                Success = result.Success
            };


        // ------------------------------------------
        // Print settlement report
        // ------------------------------------------

        foreach (var entry in settlementReport)
        {
            Console.WriteLine(
                $"{entry.Id,-8} " +
                $"{entry.DisplayName,-15} " +
                $"Attempted={entry.AmountAttempted,8:F2} " +
                $"Success={entry.Success}"
            );
        }


        // ------------------------------------------
        // Calculate successfully settled amount
        // ------------------------------------------

        decimal totalSuccessfullySettled =
            settlementReport
                .Where(x => x.Success)
                .Sum(x => x.AmountAttempted);


        Console.WriteLine();

        Console.WriteLine(
            $"Total successfully settled: " +
            $"{totalSuccessfullySettled:F2}"
        );
    }
}