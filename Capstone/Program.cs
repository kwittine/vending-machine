using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
			FileIO fileIO = new FileIO();
			var inventory = fileIO.GetVendingMachineStock();
			VendingMachine vendingMachine = new VendingMachine(inventory);

			UI ui = new UI(vendingMachine);

			ui.MainScreen();
        }
    }
}
