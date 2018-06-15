using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class VendingMachine
	{
		private FileIO fileIO = new FileIO();
		public Dictionary<string, List<Item>> Stock { get; set; }
		public List<Item> PurchasedItems { get; set; }
		public List<Item> TotalPurchasedItems { get; set; }
		private Transaction transaction = new Transaction();

		public decimal Balance
		{
			get
			{
				return transaction.Balance;
			}
		}


		public VendingMachine(Dictionary<string, List<Item>> stock)
		{
			this.Stock = stock;
			PurchasedItems = new List<Item>();
			TotalPurchasedItems = new List<Item>();
		}

		public void DispenseItem(string position)
		{
			// User selects valid position
			if (Stock.ContainsKey(position))
			{
			
				// There is at least one item within the position
				if (Stock[position].Count != 0) 
				{
					// Call Transaction Class --> Make purchase Method
					//transaction.MakePurchase(Stock[position][0].Cost);

					// Add item to List of purchased items in the transaction
					if (transaction.MakePurchase(Stock[position][0].Cost))
					{
						PurchasedItems.Add(Stock[position][0]);
						TotalPurchasedItems.Add(Stock[position][0]);

						fileIO.LogTransaction(Stock[position][0].Name, position, Stock[position][0].Cost, Balance);
						Console.WriteLine($"{Stock[position][0].Name} purchased!");

						// Remove an item from the Dictionary's stock
						Stock[position].RemoveAt(0);

					}
				}
				// There is no inventory left
				else
				{
					// Tell user out of stock
					Console.WriteLine($"{position} is out of stock.");

				}
			}
			// User entered invalid position
			else
			{
				// Tell user invalid position
				Console.WriteLine($"Please enter a valid position.");

			}

		}

		public void FeedMoney(int moneyEntered)
		{
			transaction.FeedMoney(moneyEntered);
			fileIO.LogTransaction("FEED MONEY:", (decimal)moneyEntered, Balance);
		}

		public int[] GiveChange()
		{
			decimal balanceBeforeChange = Balance;
			int[] change = transaction.GiveChange();
			fileIO.LogTransaction("GIVE CHANGE:", balanceBeforeChange, Balance);
			return change;
		}


		
	}
}
