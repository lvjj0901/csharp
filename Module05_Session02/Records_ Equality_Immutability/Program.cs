var account = new Account("10001","Jason",500m);
//var account1 = new Account("10002", "Mike");
account.Deposit(100m);
Console.WriteLine($"account Balance: {account.Balance}");
account.Withdraw(50m);
Console.WriteLine($"account Balance: {account.Balance}");

public class Account
{
    public string AccountNumber { get; init; }

    public string Owner { get; init; }

    public decimal Balance { get; private set; }

    public Account(string accountNumber, string owner) : this(accountNumber, owner, 0m)
    {
        this.AccountNumber = accountNumber;
        this.Owner = owner;
        this.Balance = 0m;
    }

    public Account(string accountNumber, string owner,decimal openingBalance)
    {
        this.AccountNumber = accountNumber;
        this.Owner = owner;
        if (openingBalance < 0)
        { 
            throw new ArgumentException("Opening balance cannot be negative.");
        }
        this.Balance = openingBalance;
    }  

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException(
                "Deposit amount must be positive.");
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException(
                "Withdrawal amount must be positive.");
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException(
                "Insufficient funds.");
        }

        Balance -= amount;
    }
}
