using System.Collections.Generic;
using System.Linq;
using RockPaperScissorsPro;

namespace DeathBot.Bot.Strategies
{
    public class Rule
    {
        public Rule(List<Move> antecedents, Move consequent)
        {
            Antecedents = antecedents;
            Consequent = consequent;
            IsMatched = false;
            Weight = 0;
        }

        public List<Move> Antecedents { get; private set; }
        public Move Consequent { get; private set; }
        public bool IsMatched { get; set; }
        public int Weight { get; private set; }

        public void IncrementWeight()
        {
            Weight++;
        }

        public void DecrementWeight()
        {
            Weight--;
        }

        
    }
}