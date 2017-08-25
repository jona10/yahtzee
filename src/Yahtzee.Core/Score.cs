using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Core
{
    public static class Score
    {
        private static int DiceOfValue(int value, IReadOnlyCollection<int> dice)
        {
            return dice.Where(die => die == value).Sum();
        }

        public static int Ones(IReadOnlyCollection<int> dice) => DiceOfValue(1, dice);

        public static int Twos(IReadOnlyCollection<int> dice) => DiceOfValue(2, dice);

        public static int Threes(IReadOnlyCollection<int> dice) => DiceOfValue(3, dice);

        public static int Fours(IReadOnlyCollection<int> dice) => DiceOfValue(4, dice);

        public static int Fives(IReadOnlyCollection<int> dice) => DiceOfValue(5, dice);

        public static int Sixes(IReadOnlyCollection<int> dice) => DiceOfValue(6, dice);

        private static bool IsRepeated(int numberOfTimes, IReadOnlyCollection<int> dice)
        {
            return dice.GroupBy(x => x).Any(x => x.Count() >= numberOfTimes);
        }

        private static int DiceOfAKind(int numberOfTimesRepeated, IReadOnlyCollection<int> dice)
        {
            return IsRepeated(numberOfTimesRepeated, dice) ? dice.Sum() : 0;
        }

        public static int ThreeOfAKind(IReadOnlyCollection<int> dice) => DiceOfAKind(3, dice);

        public static int FourOfAKind(IReadOnlyCollection<int> dice) => DiceOfAKind(4, dice);

        public static int FullHouse(IReadOnlyCollection<int> dice)
        {
            return dice.GroupBy(x => x).Count() == 2 ? 25 : 0;
        }

        public static int Yahtzee(IReadOnlyCollection<int> dice)
        {
            return IsRepeated(5, dice) ? 50 : 0;
        }
    }
}