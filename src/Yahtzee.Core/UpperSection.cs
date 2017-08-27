using System;
using System.Collections.Generic;

namespace Yahtzee.Core
{
    public class UpperSection
    {
        private readonly Score _ones;
        private readonly Score _twos;
        private readonly Score _threes;
        private readonly Score _fours;
        private readonly Score _fives;
        private readonly Score _sixes;

        public UpperSection(Func<IEnumerable<int>, int> onesScorer, Func<IEnumerable<int>, int> twosScorer, Func<IEnumerable<int>, int> threesScorer, Func<IEnumerable<int>, int> foursScorer, Func<IEnumerable<int>, int> fivesScorer, Func<IEnumerable<int>, int> sixesScorer)
        {
            _ones = new Score(onesScorer);
            _twos = new Score(twosScorer);
            _threes = new Score(threesScorer);
            _fours = new Score(foursScorer);
            _fives = new Score(fivesScorer);
            _sixes = new Score(sixesScorer);
        }

        public int Ones { get { return _ones.Value; } }
        public int Twos { get { return _twos.Value; } }
        public int Threes { get { return _threes.Value; } }
        public int Fours { get { return _fours.Value; } }
        public int Fives { get { return _fives.Value; } }
        public int Sixes { get { return _sixes.Value; } }

        private int SumOfLockedScore
        {
            get
            {
                var score = 0;
                if (_ones.IsLocked())
                    score += _ones.Value;

                if (_twos.IsLocked())
                    score += _twos.Value;

                if (_threes.IsLocked())
                    score += _threes.Value;

                if (_fours.IsLocked())
                    score += _fours.Value;

                if (_fives.IsLocked())
                    score += _fives.Value;

                if (_sixes.IsLocked())
                    score += _sixes.Value;

                return score;
            }
        }

        public int Score
        {
            get
            {
                return SumOfLockedScore + Bonus;
            }
        }

        public int Bonus
        {
            get
            {
                if (SumOfLockedScore >= 63)
                {
                    return 35;
                }

                return 0;
            }
        }

        public void Lock(ScoreCard.Items item)
        {
            switch (item)
            {
                case ScoreCard.Items.Ones:
                    _ones.LockIn();
                    _twos.Reset();
                    _threes.Reset();
                    _fours.Reset();
                    _fives.Reset();
                    _sixes.Reset();
                    break;

                case ScoreCard.Items.Twos:
                    _ones.Reset();
                    _twos.LockIn();
                    _threes.Reset();
                    _fours.Reset();
                    _fives.Reset();
                    _sixes.Reset();
                    break;

                case ScoreCard.Items.Threes:
                    _ones.Reset();
                    _twos.Reset();
                    _threes.LockIn();
                    _fours.Reset();
                    _fives.Reset();
                    _sixes.Reset();
                    break;

                case ScoreCard.Items.Fours:
                    _ones.Reset();
                    _twos.Reset();
                    _threes.Reset();
                    _fours.LockIn();
                    _fives.Reset();
                    _sixes.Reset();
                    break;

                case ScoreCard.Items.Fives:
                    _ones.Reset();
                    _twos.Reset();
                    _threes.Reset();
                    _fours.Reset();
                    _fives.LockIn();
                    _sixes.Reset();
                    break;

                case ScoreCard.Items.Sixes:
                    _ones.Reset();
                    _twos.Reset();
                    _threes.Reset();
                    _fours.Reset();
                    _fives.Reset();
                    _sixes.LockIn();
                    break;

                default:
                    throw new Exception(item + " is not part of the upper section.");
            }
        }

        public void Preview(IEnumerable<int> dice)
        {
            _ones.Preview(dice);
            _twos.Preview(dice);
            _threes.Preview(dice);
            _fours.Preview(dice);
            _fives.Preview(dice);
            _sixes.Preview(dice);
        }
    }
}