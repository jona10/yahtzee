using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Core
{
    public class UpperSection
    {
        private const int UpperBonusLimit = 63;
        private const int UpperBonusValue = 35;

        private readonly Dictionary<ScoreCard.Items, Score> _items;

        public UpperSection(Func<IEnumerable<int>, int> onesScorer, Func<IEnumerable<int>, int> twosScorer, Func<IEnumerable<int>, int> threesScorer, Func<IEnumerable<int>, int> foursScorer, Func<IEnumerable<int>, int> fivesScorer, Func<IEnumerable<int>, int> sixesScorer)
        {
            _items = new Dictionary<ScoreCard.Items, Score>();
            _items.Add(ScoreCard.Items.Ones, new Score(onesScorer));
            _items.Add(ScoreCard.Items.Twos, new Score(twosScorer));
            _items.Add(ScoreCard.Items.Threes, new Score(threesScorer));
            _items.Add(ScoreCard.Items.Fours, new Score(foursScorer));
            _items.Add(ScoreCard.Items.Fives, new Score(fivesScorer));
            _items.Add(ScoreCard.Items.Sixes, new Score(sixesScorer));
        }

        private int SumOfLockedScore => _items.Values.Where(x => x.IsLocked()).Select(x => x.Value).Sum();

        public int Ones => _items[ScoreCard.Items.Ones].Value;
        public int Twos => _items[ScoreCard.Items.Twos].Value;
        public int Threes => _items[ScoreCard.Items.Threes].Value;
        public int Fours => _items[ScoreCard.Items.Fours].Value;
        public int Fives => _items[ScoreCard.Items.Fives].Value;
        public int Sixes => _items[ScoreCard.Items.Sixes].Value;
        public int Score => SumOfLockedScore + Bonus;
        public int Bonus => SumOfLockedScore >= UpperBonusLimit ? UpperBonusValue : 0;

        public void Lock(ScoreCard.Items item)
        {
            switch (item)
            {
                case ScoreCard.Items.Ones:
                case ScoreCard.Items.Twos:
                case ScoreCard.Items.Threes:
                case ScoreCard.Items.Fours:
                case ScoreCard.Items.Fives:
                case ScoreCard.Items.Sixes:
                    _items[item].LockIn();
                    _items.Values.ToList().ForEach(x => x.Reset());
                    break;

                default:
                    throw new Exception(item + " is not part of the upper section.");
            }
        }

        public void Preview(IEnumerable<int> dice)
        {
            foreach (var current in _items.Values)
                current.Preview(dice);
        }
    }
}