using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        public Change(int numberOfQuarters, int numberOfDimes, int numberofNickels)
        {
            NumberOfQuarters = numberOfQuarters;
            NumberOfDimes = numberOfDimes;
            NumberOfNickels = numberofNickels;
        }

        public int NumberOfQuarters { get; }
        public int NumberOfDimes { get; }
        public int NumberOfNickels { get; }
    }
}
