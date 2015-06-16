using System;

public class Account
{
	private decimal balance = 0;
	
	public void Deposit(decimal amount)
	{
		if (amount <= 0)
		{
			throw new ArgumentException("Can not deposit negative or zero amount");
		}
		balance += amount;
	}

    public void Withdraw(decimal amount)
	{
		if (amount <= 0)
		{
			throw new ArgumentException("Can not withdraw negative or zero amount");
		}
		balance -= amount;
	}

    public void TransferFunds(Account destinationAcc, decimal amount)
	{
		if (destinationAcc == this)
		{
			throw new ArgumentException(
				"Source and destination accounts can not be the same");
		}
		balance -= amount;
		destinationAcc.balance += amount;
	}

    public void NotCoveredMethod()
    {
        Console.WriteLine("This method is never invoked");
    }

    public decimal Balance
	{
		get
		{
			return balance;
		}
	}
}
