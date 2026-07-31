using System;

class Transaction
{
    public string AccountId;
    public double Amount;
    public string Timestamp;
    public string Merchant;

    public Transaction(string accountId, double amount, string timestamp, string merchant)
    {
        AccountId = accountId;
        Amount = amount;
        Timestamp = timestamp;
        Merchant = merchant;
    }
}