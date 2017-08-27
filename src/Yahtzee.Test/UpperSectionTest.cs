using System;
using System.Collections.Generic;
using Xunit;
using Yahtzee.Core;

namespace Yahtzee.Test
{
    public class UpperSectionTest
    {
        [Fact]
        public void PreviewsTheScoreForSetOfDice()
        {
            var section = new UpperSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6);
            section.Preview(new List<int>());
            Assert.Equal(1, section.Ones);
            Assert.Equal(2, section.Twos);
            Assert.Equal(3, section.Threes);
            Assert.Equal(4, section.Fours);
            Assert.Equal(5, section.Fives);
            Assert.Equal(6, section.Sixes);
        }

        [Fact]
        public void LocksInOnesScore()
        {
            var section = new UpperSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Ones);

            Assert.Equal(1, section.Ones);
            Assert.Equal(0, section.Twos);
            Assert.Equal(0, section.Threes);
            Assert.Equal(0, section.Fours);
            Assert.Equal(0, section.Fives);
            Assert.Equal(0, section.Sixes);
        }

        [Fact]
        public void LockInTwosScore()
        {
            var section = new UpperSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Twos);

            Assert.Equal(0, section.Ones);
            Assert.Equal(2, section.Twos);
            Assert.Equal(0, section.Threes);
            Assert.Equal(0, section.Fours);
            Assert.Equal(0, section.Fives);
            Assert.Equal(0, section.Sixes);
        }

        [Fact]
        public void LockInThreesScore()
        {
            var section = new UpperSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Threes);

            Assert.Equal(0, section.Ones);
            Assert.Equal(0, section.Twos);
            Assert.Equal(3, section.Threes);
            Assert.Equal(0, section.Fours);
            Assert.Equal(0, section.Fives);
            Assert.Equal(0, section.Sixes);
        }

        [Fact]
        public void LockInFoursScore()
        {
            var section = new UpperSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Fours);

            Assert.Equal(0, section.Ones);
            Assert.Equal(0, section.Twos);
            Assert.Equal(0, section.Threes);
            Assert.Equal(4, section.Fours);
            Assert.Equal(0, section.Fives);
            Assert.Equal(0, section.Sixes);
        }

        [Fact]
        public void LockInFivesScore()
        {
            var section = new UpperSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Fives);

            Assert.Equal(0, section.Ones);
            Assert.Equal(0, section.Twos);
            Assert.Equal(0, section.Threes);
            Assert.Equal(0, section.Fours);
            Assert.Equal(5, section.Fives);
            Assert.Equal(0, section.Sixes);
        }

        [Fact]
        public void LockInSixesScore()
        {
            var section = new UpperSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Sixes);

            Assert.Equal(0, section.Ones);
            Assert.Equal(0, section.Twos);
            Assert.Equal(0, section.Threes);
            Assert.Equal(0, section.Fours);
            Assert.Equal(0, section.Fives);
            Assert.Equal(6, section.Sixes);
        }

        [Fact]
        public void CannotLockInScoreThatIsNotPartOfTheUpperSection()
        {
            var section = new UpperSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6);
            section.Preview(new List<int>());

            Assert.Throws<Exception>(() => section.Lock(ScoreCard.Items.ThreeOfAKind));
        }

        [Fact]
        public void ReturnsScore()
        {
            var section = new UpperSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Sixes);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Fours);
            section.Preview(new List<int>());

            Assert.Equal(10, section.Score);
        }

        [Fact]
        public void ReturnsScoreIncludingBonus()
        {
            var section = new UpperSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 63);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Sixes);
            section.Preview(new List<int>());

            Assert.Equal(63+35, section.Score);
        }

        [Fact]
        public void ReturnsBonusOfZeroWhenUpperSectionSumIsUnderSixtyThree()
        {
            var section = new UpperSection(x => 1, x => 2, x => 3, x => 4, x => 5, x => 6);

            Assert.Equal(0, section.Bonus);
        }

        [Fact]
        public void ReturnsBonusWhenUpperSectionSumIsGreaterThanSixtyThree()
        {
            var section = new UpperSection(x => 65, x => 2, x => 3, x => 4, x => 5, x => 6);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Ones);

            Assert.Equal(35, section.Bonus);
        }

        [Fact]
        public void ReturnsBonusWhenUpperSectionSumIsEqualToSixtyThree()
        {
            var section = new UpperSection(x => 63, x => 2, x => 3, x => 4, x => 5, x => 6);
            section.Preview(new List<int>());
            section.Lock(ScoreCard.Items.Ones);

            Assert.Equal(35, section.Bonus);
        }
    }
}