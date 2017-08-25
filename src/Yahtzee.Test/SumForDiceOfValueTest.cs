using System.Collections.Generic;
using Xunit;
using Yahtzee.Core;

namespace Yahtzee.Tests
{
    public class SumForDiceOfValueTest
    {
        public static IEnumerable<object[]> SumOfOnes => new object[][] {
            new object[] { new []{ 0, 0, 0, 0, 0 }, 0 },
            new object[] { new []{ 1, 0, 0, 0, 0 }, 1 },
            new object[] { new []{ 1, 1, 0, 0, 0 }, 2 },
            new object[] { new []{ 1, 1, 1, 0, 0 }, 3 },
            new object[] { new []{ 1, 1, 1, 1, 0 }, 4 },
            new object[] { new []{ 1, 1, 1, 1, 1 }, 5 }
        };

        public static IEnumerable<object[]> SumOfTwos => new object[][] {
            new object[] { new []{ 0, 0, 0, 0, 0 }, 0 },
            new object[] { new []{ 2, 0, 0, 0, 0 }, 2 },
            new object[] { new []{ 2, 2, 0, 0, 0 }, 4 },
            new object[] { new []{ 2, 2, 2, 0, 0 }, 6 },
            new object[] { new []{ 2, 2, 2, 2, 0 }, 8 },
            new object[] { new []{ 2, 2, 2, 2, 2 }, 10 }
        };

        public static IEnumerable<object[]> SumOfThrees => new object[][] {
            new object[] { new []{ 0, 0, 0, 0, 0 }, 0 },
            new object[] { new []{ 3, 0, 0, 0, 0 }, 3 },
            new object[] { new []{ 3, 3, 0, 0, 0 }, 6 },
            new object[] { new []{ 3, 3, 3, 0, 0 }, 9 },
            new object[] { new []{ 3, 3, 3, 3, 0 }, 12 },
            new object[] { new []{ 3, 3, 3, 3, 3 }, 15 }
        };

        public static IEnumerable<object[]> SumOfFours => new object[][] {
            new object[] { new []{ 0, 0, 0, 0, 0 }, 0 },
            new object[] { new []{ 4, 0, 0, 0, 0 }, 4 },
            new object[] { new []{ 4, 4, 0, 0, 0 }, 8 },
            new object[] { new []{ 4, 4, 4, 0, 0 }, 12 },
            new object[] { new []{ 4, 4, 4, 4, 0 }, 16 },
            new object[] { new []{ 4, 4, 4, 4, 4 }, 20 }
        };

        public static IEnumerable<object[]> SumOfFives => new object[][] {
            new object[] { new []{ 0, 0, 0, 0, 0 }, 0 },
            new object[] { new []{ 5, 0, 0, 0, 0 }, 5 },
            new object[] { new []{ 5, 5, 0, 0, 0 }, 10 },
            new object[] { new []{ 5, 5, 5, 0, 0 }, 15 },
            new object[] { new []{ 5, 5, 5, 5, 0 }, 20 },
            new object[] { new []{ 5, 5, 5, 5, 5 }, 25 }
        };

        public static IEnumerable<object[]> SumOfSixes => new object[][] {
            new object[] { new []{ 0, 0, 0, 0, 0 }, 0 },
            new object[] { new []{ 6, 0, 0, 0, 0 }, 6 },
            new object[] { new []{ 6, 6, 0, 0, 0 }, 12 },
            new object[] { new []{ 6, 6, 6, 0, 0 }, 18 },
            new object[] { new []{ 6, 6, 6, 6, 0 }, 24 },
            new object[] { new []{ 6, 6, 6, 6, 6 }, 30 }
        };

        [Theory]
        [MemberData(nameof(SumOfOnes))]
        public void ReturnsTheSumOfOnes(int[] dice, int expected)
        {
            var result = Score.DiceOfValue(1, dice);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(SumOfTwos))]
        public void ReturnsTheSumOfTwos(int[] dice, int expected)
        {
            var result = Score.DiceOfValue(2, dice);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(SumOfThrees))]
        public void ReturnsTheSumOfThrees(int[] dice, int expected)
        {
            var result = Score.DiceOfValue(3, dice);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(SumOfFours))]
        public void ReturnsTheSumOfFours(int[] dice, int expected)
        {
            var result = Score.DiceOfValue(4, dice);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(SumOfFives))]
        public void ReturnsTheSumOfFives(int[] dice, int expected)
        {
            var result = Score.DiceOfValue(5, dice);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(SumOfSixes))]
        public void ReturnsTheSumOfSixes(int[] dice, int expected)
        {
            var result = Score.DiceOfValue(6, dice);

            Assert.Equal(expected, result);
        }
    }
}