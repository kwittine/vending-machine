using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class Transaction
	{
		decimal Balance { get; set; }

		public decimal FeedMoney(decimal userInputMoney)
		{
			return Balance;
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
				//Call Dispense Item from vending machine class - 
				return Balance;

			}
		}

		public decimal GiveChange()
		{
			if (Balance >= 0.25M)
			{

				int quarters = (int)(Balance / 0.25M);
				Balance = Balance - (0.25M * quarters);
			}

			if (Balance >= 0.10M)
			{

				int dimes = (int)(Balance / 0.10M);
				Balance = Balance - (0.10M * dimes);
			}

			if (Balance >= 0.05M)
			{
				int nickles = (int)(Balance / 0.05M);
				Balance = Balance - (0.05M * nickles);
			}

			return Balance;//Pass change into another method that specifies quarters dimes and nickles
		}
	}


}
}
