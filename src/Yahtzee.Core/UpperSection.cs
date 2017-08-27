using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Core
{
    public class UpperSection : ScoreCardSection
    {
        private const int UpperBonusLimit = 63;
        private const int UpperBonusValue = 35;

        public UpperSection(Func<IEnumerable<int>, int> onesScorer, Func<IEnumerable<int>, int> twosScorer, Func<IEnumerable<int>, int> threesScorer, Func<IEnumerable<int>, int> foursScorer, Func<IEnumerable<int>, int> fivesScorer, Func<IEnumerable<int>, int> sixesScorer)
        {
            Items.Add(ScoreCard.Items.Ones, new Score(onesScorer));
            Items.Add(ScoreCard.Items.Twos, new Score(twosScorer));
            Items.Add(ScoreCard.Items.Threes, new Score(threesScorer));
            Items.Add(ScoreCard.Items.Fours, new Score(foursScorer));
            Items.Add(ScoreCard.Items.Fives, new Score(fivesScorer));
            Items.Add(ScoreCard.Items.Sixes, new Score(sixesScorer));
        }

        private int SumOfLockedScore => Items.Values.Where(x => x.IsLocked()).Select(x => x.Value).Sum();

        public int Ones => Items[ScoreCard.Items.Ones].Value;
        public int Twos => Items[ScoreCard.Items.Twos].Value;
        public int Threes => Items[ScoreCard.Items.Threes].Value;
        public int Fours => Items[ScoreCard.Items.Fours].Value;
        public int Fives => Items[ScoreCard.Items.Fives].Value;
        public int Sixes => Items[ScoreCard.Items.Sixes].Value;
        public int Score => SumOfLockedScore + Bonus;
        public int Bonus => SumOfLockedScore >= UpperBonusLimit ? UpperBonusValue : 0;
    }
}