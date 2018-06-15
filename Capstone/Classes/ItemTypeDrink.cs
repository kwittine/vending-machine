using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class ItemTypeDrink : Item
	{


		/// <summary>
		/// To set input value in list
		/// </summary>
		/// <param name="itemType"></param>
		/// <param name="name"></param>
		/// <param name="cost"></param>
		public ItemTypeDrink(string name, decimal cost)
			: base(name, cost)
		{


		}

		/// <summary>
		/// Sets Item type sound
		/// </summary>
		/// <returns>Item type sound</returns>
		public override string MakeSound()
		{
			return ($"You drank {Name}. Glug Glug, Yum!");
		}
	}
}
