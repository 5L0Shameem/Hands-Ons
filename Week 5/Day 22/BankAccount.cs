using System;

class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}

class BankAccount
{
    private double balance;

    public BankAccount(double balance)
    {
        this.balance = balance;
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            throw new InsufficientBalanceException("Error: Withdrawal amount exceeds available balance");
        }
        else
        {
            balance -= amount;
            Console.WriteLine("Withdrawal successful. Remaining Balance = " + balance);
        }
    }
}

class BankApp
{
    static void Main()
    {
        Console.Write("Enter Balance: ");
        double bal = double.Parse(Console.ReadLine());

        Console.Write("Enter Withdraw Amount: ");
        double amt = double.Parse(Console.ReadLine());

        BankAccount account = new BankAccount(bal);

        try
        {
            account.Withdraw(amt);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Transaction completed");
        }
    }
}
