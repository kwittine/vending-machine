using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
	public class Transaction
	{
		/// <summary>
		/// Property for Balance
		/// </summary>
		public decimal Balance { get; set; }

		/// <summary>
		/// Feed Money
		/// </summary>
		/// <param name="userInputMoney"></param>
		public void FeedMoney(int userInputMoney)
		{
			Balance += (decimal)userInputMoney;
		}

		/// <summary>
		/// Make purchase method
		/// </summary>
		/// <param name="costOfItem"></param>
		/// <returns></returns>
		public bool  MakePurchase(decimal costOfItem)
		{
			if (costOfItem > Balance)
			{
				//Make message in UI : "Insufficient Funds to Purchase Item"
				Console.WriteLine($"Your Balance is: {Balance:C}. The cost of the item is: {costOfItem:C}.");
				Console.WriteLine($"Please insert more money to make a purchase");
				return false;
			}
			else
			{
				Balance -= costOfItem;
				return true;

			}

		}


		/// <summary>
		/// Give Change Method
		/// </summary>
		/// <returns></returns>
		public int[] GiveChange()
		{
			int[] change = new int[3];

			if (Balance >= 0.25M)
			{
				int quarters = (int)(Balance / 0.25M);
				change[0] = quarters;
				Balance = Balance - (0.25M * quarters);
			}

			if (Balance >= 0.10M)
			{

				int dimes = (int)(Balance / 0.10M);
				change[1] = dimes;
				Balance = Balance - (0.10M * dimes);
			}

			if (Balance >= 0.05M)
			{
				int nickles = (int)(Balance / 0.05M);
				change[2] = nickles;
				Balance = Balance - (0.05M * nickles);
			}

			return change;
		}

		//SALES REPORT

		


	}


}

