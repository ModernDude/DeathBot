using RockPaperScissorsPro;

namespace DeathBot.Bot.Strategies
{
    public class MyRulesStrategy : RuleStrategyBase
    {
        public MyRulesStrategy(int myMovesToTrack, SimpleFitness fitness)
            : base(myMovesToTrack, fitness)
        {
        }

        public override Move PredictOpponentsNextMove(MoveHistory moveHistory)
        {
            if (!EnoughHistoryToPredictMove(moveHistory.GetMyHistory()))
                return null;

            LogOpponentsPreviousMove(moveHistory.GetOpponentsPreviousMove());

            SetMatched(moveHistory.GetMyHistory());
            CurrentPrediction = GetMatchedWithHightesWeight().Consequent;
            return CurrentPrediction;
        }
    }
}