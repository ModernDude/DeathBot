using System;
using RockPaperScissorsPro;

namespace DeathBot.Bot.Strategies
{
    public abstract class SimpleStrategyBase : IPredictionStrategy
    {
        protected SimpleStrategyBase(SimpleFitness fitness)
        {
            if (fitness == null) throw new ArgumentNullException("fitness");

            CurrentPrediction = null;
            Fitness = fitness;
        }

        protected Move CurrentPrediction { get; set; }
        protected SimpleFitness Fitness { get; set; }

        protected bool HasPredictionBeenMade
        {
            get { return null != CurrentPrediction; }
        }

        #region IPredictionStrategy Members

        public float GetFitness()
        {
            return Fitness.GetFitness();
        }

        public abstract Move PredictOpponentsNextMove(MoveHistory moveHistory);

        #endregion

        protected virtual void LogOpponentsPreviousMove(Move opponentsPreviousMove)
        {
            if (HasPredictionBeenMade)
            {
                Fitness.LogOpponentMove(CurrentPrediction, opponentsPreviousMove);
            }
        }
    }
}