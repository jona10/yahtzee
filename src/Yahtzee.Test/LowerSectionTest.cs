using System;
using System.Collections.Generic;
using Xunit;
using Yahtzee.Core;

namespace Yahtzee.Test
{
    public class LowerSectionTest
    {
        [Fact]
        public void PreviewsTheScoreForSetOfDice()
        {
            var section = new LowerSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6, x => 7);
            section.Preview(new List<int>());
            Assert.Equal(1, section.ThreeOfAKind);
            Assert.Equal(2, section.FourOfAKind);
            Assert.Equal(3, section.FullHouse);
            Assert.Equal(4, section.SmallStraight);
            Assert.Equal(5, section.LongStraight);
            Assert.Equal(6, section.Chance);
            Assert.Equal(7, section.Yahtzee);
        }

        [Fact]
        public void LocksInThreeOfAKindScore()
        {
            var section = new LowerSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6, x => 7);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.ThreeOfAKind);

            Assert.Equal(1, section.ThreeOfAKind);
            Assert.Equal(0, section.FourOfAKind);
            Assert.Equal(0, section.FullHouse);
            Assert.Equal(0, section.SmallStraight);
            Assert.Equal(0, section.LongStraight);
            Assert.Equal(0, section.Chance);
            Assert.Equal(0, section.Yahtzee);
        }

        [Fact]
        public void LockInFourOfAKindScore()
        {
            var section = new LowerSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6, x => 7);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.FourOfAKind);

            Assert.Equal(0, section.ThreeOfAKind);
            Assert.Equal(2, section.FourOfAKind);
            Assert.Equal(0, section.FullHouse);
            Assert.Equal(0, section.SmallStraight);
            Assert.Equal(0, section.LongStraight);
            Assert.Equal(0, section.Chance);
            Assert.Equal(0, section.Yahtzee);
        }

        [Fact]
        public void LockInFullHouseScore()
        {
            var section = new LowerSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6, x => 7);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.FullHouse);

            Assert.Equal(0, section.ThreeOfAKind);
            Assert.Equal(0, section.FourOfAKind);
            Assert.Equal(3, section.FullHouse);
            Assert.Equal(0, section.SmallStraight);
            Assert.Equal(0, section.LongStraight);
            Assert.Equal(0, section.Chance);
            Assert.Equal(0, section.Yahtzee);
        }

        [Fact]
        public void LockInSmallStraightScore()
        {
            var section = new LowerSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6, x => 7);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.SmallStraight);

            Assert.Equal(0, section.ThreeOfAKind);
            Assert.Equal(0, section.FourOfAKind);
            Assert.Equal(0, section.FullHouse);
            Assert.Equal(4, section.SmallStraight);
            Assert.Equal(0, section.LongStraight);
            Assert.Equal(0, section.Chance);
            Assert.Equal(0, section.Yahtzee);
        }

        [Fact]
        public void LockInLongStraightScore()
        {
            var section = new LowerSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6, x => 7);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.LongStraight);

            Assert.Equal(0, section.ThreeOfAKind);
            Assert.Equal(0, section.FourOfAKind);
            Assert.Equal(0, section.FullHouse);
            Assert.Equal(0, section.SmallStraight);
            Assert.Equal(5, section.LongStraight);
            Assert.Equal(0, section.Chance);
            Assert.Equal(0, section.Yahtzee);
        }

        [Fact]
        public void LockInChanceScore()
        {
            var section = new LowerSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6, x => 7);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Chance);

            Assert.Equal(0, section.ThreeOfAKind);
            Assert.Equal(0, section.FourOfAKind);
            Assert.Equal(0, section.FullHouse);
            Assert.Equal(0, section.SmallStraight);
            Assert.Equal(0, section.LongStraight);
            Assert.Equal(6, section.Chance);
            Assert.Equal(0, section.Yahtzee);
        }

        [Fact]
        public void LockInYahtzeeScore()
        {
            var section = new LowerSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6, x => 7);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Yahtzee);

            Assert.Equal(0, section.ThreeOfAKind);
            Assert.Equal(0, section.FourOfAKind);
            Assert.Equal(0, section.FullHouse);
            Assert.Equal(0, section.SmallStraight);
            Assert.Equal(0, section.LongStraight);
            Assert.Equal(0, section.Chance);
            Assert.Equal(7, section.Yahtzee);
        }

        [Fact]
        public void CannotLockInScoreThatIsNotPartOfTheUpperSection()
        {
            var section = new LowerSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6, x => 7);
            section.Preview(new List<int>());

            Assert.Throws<Exception>(() => section.Lock(ScoreCard.Items.Ones));
        }

        [Fact]
        public void ReturnsScore()
        {
            var section = new LowerSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6, x => 7);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.ThreeOfAKind);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.FourOfAKind);
            section.Preview(new List<int>());

            Assert.Equal(3, section.Score);
        }
    }
}