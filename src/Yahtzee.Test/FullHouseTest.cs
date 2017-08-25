using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yahtzee.Core;

namespace Yahtzee.Test
{
    public class FullHouseTest
    {
        [Fact]
        public void ReturnsZeroWhenDiceDontFormAFullHouse()
        {
            Assert.Equal(0, Score.FullHouse(new List<int> { 1, 2, 3, 4, 5 }));
        }

        [Fact]
        public void ReturnsTwentyFizeWhenDiceFormAFullHouse()
        {
            Assert.Equal(25, Score.FullHouse(new List<int> { 1, 1, 1, 4, 4 }));
        }
    }
}
