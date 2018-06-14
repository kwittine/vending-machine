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
		//Build a method to return a dictionary
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, List<Item>> GetVendingMachineStock()
		{
			//Create a dictionary
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

						string newKey = protoItem[0];

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

						//Set values of list by using for loop				
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

	}
}
