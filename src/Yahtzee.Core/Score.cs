using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Core
{
    public static class Score
    {
        public static int SumForDiceOfValue(int value, IEnumerable<int> dice)
        {
            return dice.Where(die => die == value).Sum();
        }
    }
}