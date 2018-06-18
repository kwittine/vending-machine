using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace Capstone.Tests
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        public void Can_Feed_Money()
        {
			Transaction transaction = new Transaction();

			transaction.FeedMoney(5);

			Assert.AreEqual<decimal>(5, transaction.Balance);
        }

		//[TestMethod]
		//public void Cant_Feed_Negative_Money()
		//{
		//	Transaction transaction = new Transaction();

		//	transaction.FeedMoney(-5);

		//	Assert.AreEqual(0, transaction.Balance);
		//}

		[TestMethod]
		public void Can_Make_Purchase()
		{
			Transaction transaction = new Transaction();
			transaction.Balance = 5.0M;
			bool result = transaction.MakePurchase(2.5M);

			Assert.AreEqual<decimal>(2.5M, transaction.Balance);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Can_Make_Change_And_Reset_Balance()
		{
			Transaction transaction = new Transaction();
			transaction.Balance = 1.65M;
			Change result = transaction.GiveChange();
            Change answer = new Change(6, 1, 1);
			//int[] answer = new int[3] { 6, 1, 1 };

			//Assert.IsTrue(result.Length == answer.Length);
			Assert.AreEqual(answer.NumberOfQuarters, result.NumberOfQuarters);
			Assert.AreEqual(answer.NumberOfDimes, result.NumberOfDimes);
			Assert.AreEqual(answer.NumberOfNickels, result.NumberOfNickels);
			Assert.AreEqual(0.0M, transaction.Balance);
		}

		[TestMethod]
		public void Cant_Purchase_Item_Pricer_ThanBalance()
		{
			Transaction transaction = new Transaction();
			bool result = transaction.MakePurchase(2.5M);

			Assert.IsFalse(result);
		}
    }
}
