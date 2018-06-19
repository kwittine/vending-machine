using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class FileIO

	{
		/// <summary>
		/// Method that returns vending machine stock
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, List<Item>> GetVendingMachineStock()
		{
			Dictionary<string, List<Item>> vendingStock = new Dictionary<string, List<Item>>();
			//Select Path to read
			string path = Path.Combine(Environment.CurrentDirectory, "VendingMachine.txt");

			try
			{
				using (StreamReader sr = new StreamReader(path))
				{
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();

						//Build String Array
						string[] protoItem = line.Split('|');

						string itemType = protoItem[3];

						decimal cost = decimal.Parse(protoItem[2]);

						//create a list of five items

						List<Item> stockPerLocation = new List<Item>();

						for (int i = 0; i < 5; i++)
						{
							if (itemType == "Chip")
							{
								stockPerLocation.Add(new ItemTypeChip(protoItem[1], cost));
							}
							else if (itemType == "Candy")
							{
								stockPerLocation.Add(new ItemTypeCandy(protoItem[1], cost));
							}
							else if (itemType == "Gum")
							{
								stockPerLocation.Add(new ItemTypeGum(protoItem[1], cost));
							}
							else if (itemType == "Drink")
							{
								stockPerLocation.Add(new ItemTypeDrink(protoItem[1], cost));
							}
						}		
						
						vendingStock[protoItem[0]] = stockPerLocation;
					}
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine("Error Reading File " + ex.Message);
			}

			return vendingStock;
		}

		//AUDIT
		public void LogTransaction(string itemName, string itemPosition, decimal itemCost, decimal totalBalance)
		{
			string path = Path.Combine(Environment.CurrentDirectory, "log.txt");

			try
			{
				using (StreamWriter sw = new StreamWriter(path, true))
				{
					sw.WriteLine($"{DateTime.Now.ToString()} {itemName} {itemPosition} {itemCost:C} {totalBalance:C} ");
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine("An error has occured" + ex.Message);
			}
		}

		public void LogTransaction(string nameOfTransaction, decimal transactionAmount, decimal totalBalance)
		{
			string path = Path.Combine(Environment.CurrentDirectory, "log.txt");

			try
			{
				using (StreamWriter sw = new StreamWriter(path, true))
				{
					sw.WriteLine($"{DateTime.Now.ToString()} {nameOfTransaction} {transactionAmount:C} {totalBalance:C}");
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine("An error has occured" + ex.Message);
			}
		}

		//SALES REPORT
		public void SalesReport(List<Item> totalPurchasedItems)
		{
			decimal totalSalesBalance = 0.0M;
			Dictionary<string, int> salesReport = new Dictionary<string, int>();

			string path = Path.Combine(Environment.CurrentDirectory, "SalesReport.txt");

			try
			{
				using (StreamWriter sw = new StreamWriter(path, true))
				{
					foreach (Item item in totalPurchasedItems)
					{
						if (salesReport.ContainsKey(item.Name))
						{
							salesReport[item.Name]++;
						}
						else
						{
							salesReport[item.Name] = 1;
						}

						totalSalesBalance += item.Cost;
					}

					foreach (var kvp in salesReport)
					{
						sw.WriteLine($"{kvp.Key}|{kvp.Value}");
					}

					sw.WriteLine();
					sw.WriteLine($"**TOTAL SALES** {totalSalesBalance:C}");
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine("An error has occured" + ex.Message);
			}
		}
	}
}
