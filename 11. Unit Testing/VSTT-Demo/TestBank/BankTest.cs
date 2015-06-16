using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestBank
{
    [TestClass]
    public class BankTest
    {
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize]
        public void TestInitialize()
        {
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void TestBankAddAccount()
        {
            Bank bank = new Bank();
            Account acc = new Account();
            bank.AddAccount(acc);
            Assert.AreEqual(bank.AccountsCount, 1);
            Assert.AreSame(bank[0], acc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBankAddNullAccount()
        {
            Bank bank = new Bank();
            bank.AddAccount(null);
        }

        [TestMethod]
        public void TestBankAddRemoveAccount()
        {
            Bank bank = new Bank();
            Account acc = new Account();
            bank.AddAccount(acc);
            Assert.AreEqual(bank.AccountsCount, 1);
            bank.RemoveAccount(acc);
            Assert.AreEqual(bank.AccountsCount, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBankRemoveInvalidAccount()
        {
            Bank bank = new Bank();
            Account acc = new Account();
            bank.AddAccount(acc);
            Account anotherAcc = new Account();
            bank.RemoveAccount(anotherAcc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBankRemoveNullAccount()
        {
            Bank bank = new Bank();
            bank.RemoveAccount(null);
        }

        [TestMethod]
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBankAccountIndexerInvalidRange()
        {
            Bank bank = new Bank();
            Account acc = new Account();
            bank.AddAccount(acc);
            Account accFromBank = bank[1];
        }

        [TestMethod]
        [Ignore]
        public void TestBankIgnoreTest()
        {
            // This test is not executed
        }
    }
}
