using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Core
{
    public static class Score
    {
        public static int DiceOfValue(int value, IReadOnlyCollection<int> dice)
        {
            return dice.Where(die => die == value).Sum();
        }

        public static int DiceOfAKind(int numberOfTimesRepeated, IReadOnlyCollection<int> dice)
        {
            if (dice.GroupBy(x => x).Any(x => x.Count() >= numberOfTimesRepeated))
                return dice.Sum();
            return 0;
        }
    }
}