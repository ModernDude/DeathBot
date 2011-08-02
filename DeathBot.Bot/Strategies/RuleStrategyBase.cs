using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissorsPro;

namespace DeathBot.Bot.Strategies
{
    public abstract class RuleStrategyBase : SimpleStrategyBase
    {
        protected int AntecedentCount { get; set; }
        private RuleTable Table { get; set; }

        protected RuleStrategyBase(int antecedentCount, SimpleFitness fitness) : base(fitness)
        {
            AntecedentCount = antecedentCount;
            Table = new RuleTable(antecedentCount);
        }


        protected bool EnoughHistoryToPredictMove(IEnumerable<Move> history)
        {
            return history.Count() >= AntecedentCount;
        }

        protected void SetMatched(IEnumerable<Move> history)
        {
            Table.SetMatched(history.Take(AntecedentCount).ToList());
        }

        protected Rule GetMatchedWithHightesWeight()
        {
            return Table.GetMatchedHighestWeight();
        }

        protected override void LogOpponentsPreviousMove(Move opponentsPreviousMove)
        {
            base.LogOpponentsPreviousMove(opponentsPreviousMove);

            AdjustRuleWeight(opponentsPreviousMove);

        }

        private void AdjustRuleWeight(Move opponentsPreviousMove)
        {
            if (opponentsPreviousMove == null)
                return;

            var prediction = this.GetMatchedWithHightesWeight();

            if (opponentsPreviousMove == prediction.Consequent)
            {
                prediction.IncrementWeight();
            }
            else
            {
                prediction.DecrementWeight();

                var shouldHaveFired = Table.GetMatchedConsequent(opponentsPreviousMove);

                shouldHaveFired.IncrementWeight();
            }
        }
    }
}
