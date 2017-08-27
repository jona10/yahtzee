using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Core
{
    public class LowerSection
    {
        private readonly Dictionary<ScoreCard.Items, Score> _items;

        public LowerSection(Func<IEnumerable<int>, int> threeOfAKindScorer, Func<IEnumerable<int>, int> fourOfAKindScorer, Func<IEnumerable<int>, int> fullHouseScorer, Func<IEnumerable<int>, int> smallStraightScorer, Func<IEnumerable<int>, int> longStraightScorer, Func<IEnumerable<int>, int> chanceScorer, Func<IEnumerable<int>, int> yahtzeeScorer)
        {
            _items = new Dictionary<ScoreCard.Items, Score>();
            _items.Add(ScoreCard.Items.ThreeOfAKind, new Score(threeOfAKindScorer));
            _items.Add(ScoreCard.Items.FourOfAKind, new Score(fourOfAKindScorer));
            _items.Add(ScoreCard.Items.FullHouse, new Score(fullHouseScorer));
            _items.Add(ScoreCard.Items.SmallStraight, new Score(smallStraightScorer));
            _items.Add(ScoreCard.Items.LongStraight, new Score(longStraightScorer));
            _items.Add(ScoreCard.Items.Chance, new Score(chanceScorer));
            _items.Add(ScoreCard.Items.Yahtzee, new Score(yahtzeeScorer));
        }

        public int ThreeOfAKind => _items[ScoreCard.Items.ThreeOfAKind].Value;
        public int FourOfAKind => _items[ScoreCard.Items.FourOfAKind].Value;
        public int FullHouse => _items[ScoreCard.Items.FullHouse].Value;
        public int SmallStraight => _items[ScoreCard.Items.SmallStraight].Value;
        public int LongStraight => _items[ScoreCard.Items.LongStraight].Value;
        public int Chance => _items[ScoreCard.Items.Chance].Value;
        public int Yahtzee => _items[ScoreCard.Items.Yahtzee].Value;
        public int Score => _items.Values.Where(x => x.IsLocked()).Select(x => x.Value).Sum();

        public void Lock(ScoreCard.Items item)
        {
            switch (item)
            {
                case ScoreCard.Items.ThreeOfAKind:
                case ScoreCard.Items.FourOfAKind:
                case ScoreCard.Items.FullHouse:
                case ScoreCard.Items.SmallStraight:
                case ScoreCard.Items.LongStraight:
                case ScoreCard.Items.Chance:
                case ScoreCard.Items.Yahtzee:
                    _items[item].LockIn();
                    _items.Values.ToList().ForEach(x => x.Reset());
                    break;

                default:
                    throw new Exception(item + " is not part of the lower section.");
            }
        }

        public void Preview(IEnumerable<int> dice)
        {
            foreach (var current in _items.Values)
                current.Preview(dice);
        }
    }
}