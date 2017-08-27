using System.Collections.Generic;
using Xunit;
using Yahtzee.Core;

namespace Yahtzee.Test
{
    public class ChanceTest
    {
        [Fact]
        public void ReturnsTheSumOfTheDice()
        {
            Assert.Equal(15, Scorer.Chance(new List<int> { 1, 2, 3, 4, 5 }));
        }
    }
}