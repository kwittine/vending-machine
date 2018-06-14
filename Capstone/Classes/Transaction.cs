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
		public decimal Balance { get; set; }

		public void FeedMoney(int userInputMoney)
		{
			Balance += (decimal)userInputMoney;
		}

		public decimal MakePurchase(decimal costOfItem)
		{
			if (costOfItem > Balance)
			{
				//Make message in UI : "Insufficient Funds to Purchase Item"
				return Balance; // 
			}
			else
			{
				Balance -= costOfItem;
				
				return Balance;

			}
		}

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
	}


}

