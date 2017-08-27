using System;
using System.Collections.Generic;

namespace Yahtzee.Core
{
    public class Score
    {
        private enum ScoreState { Unassigned, Preview, Locked }

        private ScoreState _state;
        private int _value;
        private readonly Func<IEnumerable<int>, int> _scorer;

        public Score(Func<IEnumerable<int>, int> scorer)
        {
            _scorer = scorer;
            _state = ScoreState.Unassigned;
            _value = 0;
        }

        public int Value { get { return _value; } }

        public void Preview(IEnumerable<int> dices)
        {
            if (_state == ScoreState.Locked)
                return;

            _value = _scorer(dices);
            _state = ScoreState.Preview;
        }

        public void LockIn()
        {
            if (_state == ScoreState.Unassigned)
                throw new Exception("Cannot lock in score that hasn't been previewed.");

            if (_state == ScoreState.Locked)
                throw new Exception("State has already been locked.");

            _state = ScoreState.Locked;
        }

        public void Reset()
        {
            if (_state == ScoreState.Locked)
                return;

            _state = ScoreState.Unassigned;
            _value = 0;
        }

        public bool IsLocked()
        {
            return _state == ScoreState.Locked;
        }
    }
}