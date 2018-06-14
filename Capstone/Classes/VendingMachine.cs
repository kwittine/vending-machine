using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class VendingMachine
	{
		public Dictionary<string, List<Item>> Stock { get; set; }
		public List<Item> PurchasedItems { get; set; }
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
		}

		public void DispenseItem(string position)
		{
			// User selects valid position
			if (Stock.ContainsKey(position))
			{
				// There is at least one item within the position
				if (Stock[position].Count != 0)
				{
					// Add item to List of purchased items in the transaction
					PurchasedItems.Add(Stock[position][0]);

					// Remove an item from the Dictionary's stock
					Stock[position].RemoveAt(0);
				}
				// There is no inventory left
				else
				{
					// Call UI method out of stock
				}
			}
			// User entered invalid position
			else
			{
				// Call UI method invalid position
			}
		}

		public void FeedMoney(int moneyEntered)
		{
			transaction.FeedMoney(moneyEntered);
		}

		public int[] GiveChange()
		{
			return transaction.GiveChange();
		}
	}
}
