using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Core
{
    public class LowerSection : ScoreCardSection
    {
        public LowerSection(Func<IEnumerable<int>, int> threeOfAKindScorer, Func<IEnumerable<int>, int> fourOfAKindScorer, Func<IEnumerable<int>, int> fullHouseScorer, Func<IEnumerable<int>, int> smallStraightScorer, Func<IEnumerable<int>, int> longStraightScorer, Func<IEnumerable<int>, int> chanceScorer, Func<IEnumerable<int>, int> yahtzeeScorer)
        {
            Items.Add(ScoreCard.Items.ThreeOfAKind, new Score(threeOfAKindScorer));
            Items.Add(ScoreCard.Items.FourOfAKind, new Score(fourOfAKindScorer));
            Items.Add(ScoreCard.Items.FullHouse, new Score(fullHouseScorer));
            Items.Add(ScoreCard.Items.SmallStraight, new Score(smallStraightScorer));
            Items.Add(ScoreCard.Items.LongStraight, new Score(longStraightScorer));
            Items.Add(ScoreCard.Items.Chance, new Score(chanceScorer));
            Items.Add(ScoreCard.Items.Yahtzee, new Score(yahtzeeScorer));
        }

        public int ThreeOfAKind => Items[ScoreCard.Items.ThreeOfAKind].Value;
        public int FourOfAKind => Items[ScoreCard.Items.FourOfAKind].Value;
        public int FullHouse => Items[ScoreCard.Items.FullHouse].Value;
        public int SmallStraight => Items[ScoreCard.Items.SmallStraight].Value;
        public int LongStraight => Items[ScoreCard.Items.LongStraight].Value;
        public int Chance => Items[ScoreCard.Items.Chance].Value;
        public int Yahtzee => Items[ScoreCard.Items.Yahtzee].Value;
        public int Score => Items.Values.Where(x => x.IsLocked()).Select(x => x.Value).Sum();
    }
}