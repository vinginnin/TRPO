using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindowsFormsApp1;
using static WindowsFormsApp1.Bank;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MoneyIn1()
        {
            Bank.ATM atm = new Bank.ATM(new WaitingState());
            int expected = 2000;
            int result = atm.MoneyIn(1000);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void MoneyIn2()
        {
            Bank.ATM atm = new Bank.ATM(new WaitingState());
            int expected = 3000;
            int result = atm.MoneyIn(2000);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void MoneyOut1()
        {
            Bank.ATM atm = new Bank.ATM(new WaitingState());
            int expected = 0;
            int result = atm.MoneyOut(1000);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void MoneyOut2()
        {
            Bank.ATM atm = new Bank.ATM(new WaitingState());
            int expected = -1000;
            int result = atm.MoneyOut(2000);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void State()
        {
            Bank.ATM atm = new Bank.ATM(new WaitingState());
            string expected = new WaitingState().ToString();
            string result = atm.State.ToString();
            Assert.AreEqual(expected, result);
        }
    }
}
