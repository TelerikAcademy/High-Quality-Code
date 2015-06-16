using System;
using NUnit.Framework;

[TestFixture, Explicit]
public class TestBank
{
    [TestFixtureSetUp]
    [Ignore]
    public void Init()
    {
        // TODO: to be implemented
    }

    [TestFixtureTearDown]
    [Ignore]
    public void Dispose()
    {
        // TODO: to be implemented
    }

	[Test]
	public void TestBankAddAccount()
	{
        Bank bank = new Bank(); 
        Account acc = new Account();
		bank.AddAccount(acc);
		Assert.AreEqual(bank.AccountsCount, 1);
		Assert.AreSame(bank[0], acc);
	}

	[Test]
	[ExpectedException(typeof(ArgumentException))]
	public void TestBankAddNullAccount()
	{
        Bank bank = new Bank();
        bank.AddAccount(null);
	}

	[Test]
	public void TestBankAddRemoveAccount()
	{
        Bank bank = new Bank();
        Account acc = new Account();
		bank.AddAccount(acc);
		Assert.AreEqual(bank.AccountsCount, 1);
		bank.RemoveAccount(acc);
		Assert.AreEqual(bank.AccountsCount, 0);
	}

	[Test]
	[ExpectedException(typeof(ArgumentException))]
	public void TestBankRemoveInvalidAccount()
	{
        Bank bank = new Bank();
        Account acc = new Account();
		bank.AddAccount(acc);
		Account anotherAcc = new Account();
		bank.RemoveAccount(anotherAcc);
	}

	[Test]
	[ExpectedException(typeof(ArgumentException))]
	public void TestBankRemoveNullAccount()
	{
        Bank bank = new Bank();
        bank.RemoveAccount(null);
	}

	[Test]
	public void TestBankAccountIndexer()
	{
        Bank bank = new Bank();
        Account acc = new Account();
		bank.AddAccount(acc);
		Account sameAcc = bank[0];
		Assert.AreSame(acc, sameAcc);

		Account secondAcc = new Account();
		bank.AddAccount(secondAcc);
		Account sameSecondAcc = bank[1];
		Assert.AreSame(secondAcc, sameSecondAcc);

		Assert.AreNotSame(sameAcc, sameSecondAcc);
	}

	[Test]
	[ExpectedException(typeof(ArgumentException))]
	public void TestBankAccountIndexerInvalidRange()
	{
        Bank bank = new Bank();
        Account acc = new Account();
		bank.AddAccount(acc);
		Account accFromBank = bank[1];
	}

	[Test]
	[Ignore]
	public void TestBankIgnoreTest()
	{
		// TODO: to be implemented
	}
}
