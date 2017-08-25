using System.Collections.Generic;
using Xunit;
using Yahtzee.Core;

namespace Yahtzee.Test
{
    public class StraightTest
    {
        public static IEnumerable<object[]> SmallStraights => new object[][] {
            new object[] { new []{ 1, 2, 3, 4, 6 } },
            new object[] { new []{ 2, 3, 4, 5, 5 } },
            new object[] { new []{ 1, 3, 4, 5, 6 } }
        };

        [Fact]
        public void ReturnsZeroWhenDiceDontFormAStraight()
        {
            Assert.Equal(0, Score.SmallStraight(new List<int> { 1, 1, 1, 1, 1 }));
            Assert.Equal(0, Score.LongStraight(new List<int> { 1, 1, 1, 1, 1 }));
        }

        [Theory]
        [MemberData(nameof(SmallStraights))]
        public void ReturnsThirtyWhenDiceFormASmallStraight(int[] dice)
        {
            Assert.Equal(30, Score.SmallStraight(dice));
        }

        [Fact]
        public void ReturnsThirtyWhenDiceFormALongStraight()
        {
            Assert.Equal(40, Score.LongStraight(new List<int> { 1, 2, 3, 4, 5 }));
        }
    }
}