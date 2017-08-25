using System.Collections.Generic;
using Xunit;
using Yahtzee.Core;

namespace Yahtzee.Test
{
    public class SumForDiceOfAKind
    {
        public static IEnumerable<object[]> ThreeOfAKind => new object[][] {
            new object[] { new []{ 1, 2, 3, 4, 5 }, 0 },
            new object[] { new []{ 1, 1, 1, 6, 6 }, 15 },
            new object[] { new []{ 2, 2, 2, 6, 6 }, 18 },
            new object[] { new []{ 3, 3, 3, 6, 6 }, 21 },
            new object[] { new []{ 4, 4, 4, 6, 6 }, 24 },
            new object[] { new []{ 5, 5, 5, 6, 6 }, 27 },
            new object[] { new []{ 6, 6, 6, 5, 5 }, 28 }
        };

        public static IEnumerable<object[]> FourOfAKind => new object[][] {
            new object[] { new []{ 1, 2, 3, 4, 5 }, 0 },
            new object[] { new []{ 1, 1, 1, 1, 6 }, 10 },
            new object[] { new []{ 2, 2, 2, 2, 6 }, 14 },
            new object[] { new []{ 3, 3, 3, 3, 6 }, 18 },
            new object[] { new []{ 4, 4, 4, 4, 6 }, 22 },
            new object[] { new []{ 5, 5, 5, 5, 6 }, 26 },
            new object[] { new []{ 6, 6, 6, 6, 5 }, 29 }
        };

        [Theory]
        [MemberData(nameof(ThreeOfAKind))]
        public void ReturnsTheSumOfAllDiceWhenThreeDiceAreOfTheSameKind(int[] dice, int expected)
        {
            Assert.Equal(expected, Score.ThreeOfAKind(dice));
        }

        [Theory]
        [MemberData(nameof(FourOfAKind))]
        public void ReturnsTheSumOfAllDiceWhenFourDiceAreOfTheSameKind(int[] dice, int expected)
        {
            Assert.Equal(expected, Score.FourOfAKind(dice));
        }
    }
}