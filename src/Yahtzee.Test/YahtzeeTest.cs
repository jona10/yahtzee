using System.Collections.Generic;
using Xunit;
using Yahtzee.Core;

namespace Yahtzee.Test
{
    public class YahtzeeTest
    {
        [Fact]
        public void ReturnsZeroWhenDiceDontFormAYahtzee()
        {
            Assert.Equal(0, Score.Yahtzee(new List<int> { 1, 2, 3, 4, 5 }));
        }

        [Fact]
        public void ReturnsFiftyWhenDiceFormAYahtzee()
        {
            Assert.Equal(50, Score.Yahtzee(new List<int> { 1, 1, 1, 1, 1 }));
        }
    }
}