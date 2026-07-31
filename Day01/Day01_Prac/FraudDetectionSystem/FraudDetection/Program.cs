using System;

class Program
{
    static void Main(string[] args)
    {
        Transaction[] transactions =
        {
            new Transaction("ACC101",25000,"09:00","Amazon"),
            new Transaction("ACC102",70000,"09:30","Flipkart"),
            new Transaction("ACC101",15000,"10:00","Amazon"),
            new Transaction("ACC103",90000,"10:30","Apple"),
            new Transaction("ACC101",55000,"11:00","Amazon"),
            new Transaction("ACC104",12000,"11:30","Nike")
        };

        DisplayTransactions(transactions);

        Console.WriteLine();

        SearchAccount(transactions, "ACC101");

        Console.WriteLine();

        LargeTransactions(transactions);

        Console.WriteLine();

        RepeatedAccounts(transactions);

        Console.WriteLine();

        RepeatedMerchants(transactions);
    }

    // Display all transactions
    static void DisplayTransactions(Transaction[] transactions)
    {
        Console.WriteLine("------ All Transactions ------");

        foreach (Transaction t in transactions)
        {
            Console.WriteLine("Account: " + t.AccountId + "  Amount: " + t.Amount + "  Time: " + t.Timestamp + "  Merchant: " + t.Merchant);
        }
    }

    // Search by Account ID
    static void SearchAccount(Transaction[] transactions, string accountId)
    {
        Console.WriteLine("------ Search Result ------");

        foreach (Transaction t in transactions)
        {
            if (t.AccountId == accountId)
            {
                Console.WriteLine(t.AccountId + " " + t.Amount + " " + t.Timestamp + " " + t.Merchant);
            }
        }
    }

    // Large transactions
    static void LargeTransactions(Transaction[] transactions)
    {
        Console.WriteLine("------ Suspicious Transactions (Amount > 50000) ------");

        foreach (Transaction t in transactions)
        {
            if (t.Amount > 50000)
            {
                Console.WriteLine(
                    t.AccountId + " Amount: " + t.Amount + " --> Suspicious");
            }
        }
    }

    // Repeated Account IDs
    static void RepeatedAccounts(Transaction[] transactions)
    {
        Console.WriteLine("------ Repeated Accounts ------");

        for (int i = 0; i < transactions.Length; i++)
        {
            bool alreadyPrinted = false;

            for (int j = 0; j < i; j++)
            {
                if (transactions[i].AccountId == transactions[j].AccountId)
                {
                    alreadyPrinted = true;
                    break;
                }
            }

            if (!alreadyPrinted)
            {
                int count = 1;

                for (int j = i + 1; j < transactions.Length; j++)
                {
                    if (transactions[i].AccountId == transactions[j].AccountId)
                    {
                        count++;
                    }
                }

                if (count > 1)
                {
                    Console.WriteLine(transactions[i].AccountId +
                                      " appears " + count + " times");
                }
            }
        }
    }

    // Repeated Merchant Names
    static void RepeatedMerchants(Transaction[] transactions)
    {
        Console.WriteLine("------ Repeated Merchants ------");

        for (int i = 0; i < transactions.Length; i++)
        {
            bool alreadyPrinted = false;

            for (int j = 0; j < i; j++)
            {
                if (transactions[i].Merchant == transactions[j].Merchant)
                {
                    alreadyPrinted = true;
                    break;
                }
            }

            if (!alreadyPrinted)
            {
                int count = 1;

                for (int j = i + 1; j < transactions.Length; j++)
                {
                    if (transactions[i].Merchant == transactions[j].Merchant)
                    {
                        count++;
                    }
                }

                if (count > 1)
                {
                    Console.WriteLine(transactions[i].Merchant + " appears " + count + " times");
                }
            }
        }
    }
}