using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestApplication.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        public void TestExceptionCase()
        {
            // Assert.Fail();
            BankAccount bank = new BankAccount("Lucy", 0);
            try
            {
                bank.Debit(2);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "amount <=0 or amount > balance");
                return;
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "balance = 0");
                return;
            }
            Assert.Fail("No exception was thrown");
        }
        [TestMethod()]    
        public void TestCreditCase()
        {
            BankAccount bank = new BankAccount("Lucy", 2);
            bank.credit(2);
            Assert.AreEqual(4, bank.Balance);
        }
        [TestMethod()]
        public void TestDebitCase()
        {
            BankAccount bank = new BankAccount("Lucy", 2);
            bank.Debit(2);
            Assert.AreEqual(0, bank.Balance);
        }
        [TestMethod()]
        public void TestCreditDebitCase()
        {
            BankAccount bank = new BankAccount("Lucy", 2);
            bank.Debit(2);
            bank.credit(2);
            Assert.AreEqual(2, bank.Balance);
        }
    }
}