using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace Capstone.Tests
{
	[TestClass]
	public class VendingMachineTests
	{
		[TestMethod]
		public void Can_Instantiate_WithStockedInventory()
		{
			FileIO fileIO = new FileIO();
			var inventory = fileIO.GetVendingMachineStock();
			VendingMachine vendingMachine = new VendingMachine(inventory);

			Assert.IsNotNull(vendingMachine);
			Assert.IsNotNull(vendingMachine.Stock);
		}

		[TestMethod]
		public void Can_Remove_Item_FromInventory_And_Add_To_PurchasedItems()
		{
			FileIO fileIO = new FileIO();
			var inventory = fileIO.GetVendingMachineStock();
			VendingMachine vendingMachine = new VendingMachine(inventory);
			Transaction transaction = new Transaction();
			vendingMachine.FeedMoney(5);

			vendingMachine.DispenseItem("C2");

			Assert.AreEqual(4, vendingMachine.Stock["C2"].Count);
			Assert.AreEqual(1, vendingMachine.PurchasedItems.Count);
			Assert.AreEqual(1, vendingMachine.TotalPurchasedItems.Count);
		}

		[TestMethod]
		public void Does_Position_Exist_In_Vending_Machine()
		{
			FileIO fileIO = new FileIO();
			var inventory = fileIO.GetVendingMachineStock();
			VendingMachine vendingMachine = new VendingMachine(inventory);
			Transaction transaction = new Transaction();
			vendingMachine.FeedMoney(5);

			vendingMachine.DispenseItem("");

			Assert.AreEqual(5, vendingMachine.Balance);
			Assert.AreEqual(0, vendingMachine.PurchasedItems.Count);
			Assert.AreEqual(0, vendingMachine.TotalPurchasedItems.Count);
		}

		[TestMethod]
		public void Out_Of_Stock_Test_And_Cant_Dispense_More()
		{
			FileIO fileIO = new FileIO();
			var inventory = fileIO.GetVendingMachineStock();
			VendingMachine vendingMachine = new VendingMachine(inventory);
			Transaction transaction = new Transaction();
			vendingMachine.FeedMoney(500);

			vendingMachine.DispenseItem("C2");
			vendingMachine.DispenseItem("C2");
			vendingMachine.DispenseItem("C2");
			vendingMachine.DispenseItem("C2");
			vendingMachine.DispenseItem("C2");
			vendingMachine.DispenseItem("C2");

			Assert.AreEqual(0, vendingMachine.Stock["C2"].Count);
			Assert.AreEqual(5, vendingMachine.PurchasedItems.Count);
		}
	}
}
