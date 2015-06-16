using System;
using System.Collections.Generic;

public class Bank
{
	private List<Account> accounts;

	public Bank()
	{
		accounts = new List<Account>();
	}

	public int AccountsCount
	{
		get
		{
			return accounts.Count;
		}
	}

	public Account this [int index]
	{
		get
		{
			if ((index < 0) || (index >= accounts.Count))
			{
				throw new ArgumentException("Invalid account index.");
			}
			Account account = (Account) accounts[index];
			return account;
		}
	}

	public void AddAccount(Account acc)
	{
		if (acc == null)
		{
			throw new ArgumentException("NULL accounts are not allowed!");
		}
		accounts.Add(acc);
	}

	public void RemoveAccount(Account acc)
	{
		int index = accounts.IndexOf(acc);
		if (index == -1)
		{
			throw new ArgumentException("Account not found. Can not be removed.");
		}
		accounts.RemoveAt(index);
	}
}
