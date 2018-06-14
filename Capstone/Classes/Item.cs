using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public abstract class Item
	{
		/// <summary>
		/// Sets Name of Item
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Sets Cost of Item
		/// </summary>
		decimal Cost { get; set; }

		//Constructor
		public Item(string name, decimal cost)
		{
			this.Name = name;
			this.Cost = cost;
		}

		/// <summary>
		/// Gives Item the ability to make sound by type
		/// </summary>
		/// <returns></returns>
		public abstract string MakeSound();
		



	}
}
