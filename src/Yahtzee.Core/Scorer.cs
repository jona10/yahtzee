using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Core
{
    public static class Scorer
    {
        private static int DiceOfValue(int value, IEnumerable<int> dice)
        {
            return dice.Where(die => die == value).Sum();
        }

        public static int Ones(IEnumerable<int> dice) => DiceOfValue(1, dice);

        public static int Twos(IEnumerable<int> dice) => DiceOfValue(2, dice);

        public static int Threes(IEnumerable<int> dice) => DiceOfValue(3, dice);

        public static int Fours(IEnumerable<int> dice) => DiceOfValue(4, dice);

        public static int Fives(IEnumerable<int> dice) => DiceOfValue(5, dice);

        public static int Sixes(IEnumerable<int> dice) => DiceOfValue(6, dice);

        private static bool IsRepeated(int numberOfTimes, IEnumerable<int> dice)
        {
            return dice.GroupBy(x => x).Any(x => x.Count() >= numberOfTimes);
        }

        private static int DiceOfAKind(int numberOfTimesRepeated, IEnumerable<int> dice)
        {
            return IsRepeated(numberOfTimesRepeated, dice) ? dice.Sum() : 0;
        }

        public static int ThreeOfAKind(IEnumerable<int> dice) => DiceOfAKind(3, dice);

        public static int FourOfAKind(IEnumerable<int> dice) => DiceOfAKind(4, dice);

        public static int FullHouse(IEnumerable<int> dice)
        {
            return dice.GroupBy(x => x).Count() == 2 ? 25 : 0;
        }

        private static bool IsFollowing(int current, int next)
        {
            return next == current + 1;
        }

        private static bool IsStraight(int lengthOfStraight, IEnumerable<int> dice)
        {
            var ordered = dice.Distinct().OrderBy(x => x).ToArray();

            var inOrderCount = 1;
            for (int i = 0; i < ordered.Length - 1; i++)
            {
                inOrderCount = IsFollowing(ordered[i], ordered[i + 1]) ? inOrderCount + 1 : 1;
                if (inOrderCount >= lengthOfStraight)
                    return true;
            }

            return false;
        }

        public static int SmallStraight(IEnumerable<int> dice)
        {
            return IsStraight(4, dice) ? 30 : 0;
        }

        public static int LongStraight(IEnumerable<int> dice)
        {
            return IsStraight(5, dice) ? 40 : 0;
        }

        public static int Yahtzee(IEnumerable<int> dice)
        {
            return IsRepeated(5, dice) ? 50 : 0;
        }
    }
}