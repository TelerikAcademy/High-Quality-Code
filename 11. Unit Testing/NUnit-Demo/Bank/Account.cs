using System;

public class Account
{
	private float balance = 0;
	
	public void Deposit(float amount)
	{
		if (amount == 0)
		{
			throw new ArgumentException("Can not deposit ammount of 0.00");
		}
		balance += amount;
	}

	public void Withdraw(float amount)
	{
		if (amount == 0)
		{
			throw new ArgumentException("Can not withdrwa ammount of 0.00");
		}
		balance -= amount;
	}

	public void TransferFunds(Account destinationAcc, float amount)
	{
		if (destinationAcc == this)
		{
			throw new ArgumentException(
				"Source and destination accounts can not be the same");
		}
		balance -= amount;
		destinationAcc.balance += amount;
	}

	public float Balance
	{
		get
		{
			return balance;
		}
	}
}