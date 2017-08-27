using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yahtzee.Core;

namespace Yahtzee.Test
{
    public class ScoreTest
    {
        [Fact]
        public void KeepsLockedInScoreOnPreview()
        {
            var score = new Score(x => x.Where(y => y == 1).Sum());

            score.Preview(new List<int> { 1 });
            score.LockIn();
            score.Preview(new List<int> { 2 });

            Assert.Equal(1, score.Value);
        }

        [Fact]
        public void KeepsLockedInScoreOnReset()
        {
            var score = new Score(x => 1);

            score.Preview(new List<int>());
            score.LockIn();
            score.Reset();

            Assert.Equal(1, score.Value);
        }

        [Fact]
        public void CannotLockInTwice()
        {
            var score = new Score(x => 1);

            score.Preview(new List<int>());
            score.LockIn();

            Assert.Throws<Exception>(() => score.LockIn());
        }

        [Fact]
        public void CannotLockInUnassignedScore()
        {
            var score = new Score(x => 1);

            Assert.Throws<Exception>(() => score.LockIn());
        }

        [Fact]
        public void CannotLockInAfterAReset()
        {
            var score = new Score(x => 1);

            score.Preview(new List<int>());
            score.Reset();

            Assert.Throws<Exception>(() => score.LockIn());
        }
    }
}