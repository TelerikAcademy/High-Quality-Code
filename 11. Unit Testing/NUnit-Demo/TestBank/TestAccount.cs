using System;
using NUnit.Framework;

[TestFixture]
public class TestAccount
{
	[Test]
	public void TestDeposit()
	{
		Account acc = new Account();
		acc.Deposit(200.00F);
		float balance = acc.Balance;
		Assert.AreEqual(balance, 200F);
	}

	[Test]
	[ExpectedException(typeof(ArgumentException))]
	public void TestDepositZero()
	{
		Account acc = new Account();
		acc.Deposit(0);
	}

	[Test]
	public void TestDepositNegative()
	{
		Account acc = new Account();
		acc.Deposit(-150.30F);
		float balance = acc.Balance;
		Assert.AreEqual(balance, -150.30F);
	}

	[Test]
	public void TestWithdraw()
	{
		Account acc = new Account();
		acc.Withdraw(138.56F);
		float balance = acc.Balance;
		Assert.AreEqual(balance, -138.56F);
	}

	[Test]
	[ExpectedException(typeof(ArgumentException))]
	public void TestWithdrawZero()
	{
		Account acc = new Account();
		acc.Withdraw(0);
	}

	[Test]
	public void TestWithdrawNegative()
	{
		Account acc = new Account();
		acc.Withdraw(-3.14F);
		float balance = acc.Balance;
		Assert.AreEqual(balance, 1000F);
	}

	[Test]
	public void TestTransferFunds()
	{
		Account source = new Account();
		source.Deposit(200.00F);
		Account dest = new Account();
		dest.Deposit(150.00F);
		source.TransferFunds(dest, 100.00F);
		Assert.AreEqual(250.00F, dest.Balance);
		Assert.AreEqual(100.00F, source.Balance);
	}

	[Test]
	[ExpectedException(typeof(NullReferenceException))]
	public void TestTransferFundsFromNullAccount()
	{
		Account source = null;
		Account dest = new Account();
		dest.Deposit(200.00F);
		source.TransferFunds(dest, 100.00F);
	}

	[Test]
	[ExpectedException(typeof(NullReferenceException))]
	public void TestTransferFundsToNullAccount()
	{
		Account source = new Account();
		source.Deposit(200.00F);
		Account dest = null;
		source.TransferFunds(dest, 100.00F);
	}

	[Test]
	[ExpectedException(typeof(ArgumentException))]
	public void TestTransferFundsSameAccount()
	{
		Account source = new Account();
		source.Deposit(200.00F);
		Account dest = source;
		source.TransferFunds(dest, 100.00F);
	}

	[Test]
	public void TestDepositWithdrawTransferFunds()
	{
		Account source = new Account();
		source.Deposit(200.00F);
		source.Withdraw(100.00F);

		Account dest = new Account();
		dest.Deposit(150.00F);
		dest.Withdraw(50.00F);

		source.TransferFunds(dest, 100.00F);
		Assert.AreEqual(0.00F, source.Balance);
		Assert.AreEqual(200.00F, dest.Balance);
	}
}
