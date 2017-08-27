using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Core
{
    public abstract class ScoreCardSection
    {
        protected ScoreCardSection()
        {
            Items = new Dictionary<ScoreCard.Items, Score>();
        }

        protected Dictionary<ScoreCard.Items, Score> Items { get; }

        public void Preview(IEnumerable<int> dice)
        {
            foreach (var current in Items.Values)
                current.Preview(dice);
        }

        public void Lock(ScoreCard.Items item)
        {
            if (!Items.ContainsKey(item))
                throw new Exception(item + " is not part of this section.");

            Items[item].LockIn();
            Items.Values.ToList().ForEach(x => x.Reset());
        }
    }
}