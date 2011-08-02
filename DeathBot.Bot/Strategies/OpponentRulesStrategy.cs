using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissorsPro;

namespace DeathBot.Bot.Strategies
{
    public class OpponentRulesStrategy : RuleStrategyBase
    {
        public OpponentRulesStrategy(int opponentMovesToTrack, SimpleFitness fitness) : base(opponentMovesToTrack, fitness)
        {
            
        }

        public override Move PredictOpponentsNextMove(MoveHistory moveHistory)
        {
            if (!EnoughHistoryToPredictMove(moveHistory.GetMyOppenentsHistory()))
                return null;
           
            LogOpponentsPreviousMove(moveHistory.GetOpponentsPreviousMove());

            SetMatched(moveHistory.GetMyOppenentsHistory());
            CurrentPrediction = GetMatchedWithHightesWeight().Consequent;
            return CurrentPrediction;
        }
    }
}
