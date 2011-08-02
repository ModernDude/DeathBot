using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissorsPro;

namespace DeathBot.Bot.Strategies
{
    public class CompositeStrategy : IPredictionStrategy
    {
        protected IStrategyFitness Fitness { get; set; }
        protected List<IPredictionStrategy> Strategies { get; set; }

        public CompositeStrategy(IStrategyFitness fitness, List<IPredictionStrategy> strategies )
        {
            Fitness = fitness;
            Strategies = strategies;
        }


        public float GetFitness()
        {
            return Fitness.GetFitness();
        }

        public Move PredictOpponentsNextMove(MoveHistory moveHistory)
        {
            var best = GetStrategyWithHighestFitness();
            
            Move returnMove = null;

            foreach(var strategy in Strategies)
            {
                 if (best == strategy)
                 {
                     returnMove = strategy.PredictOpponentsNextMove(moveHistory);
                 }
                 else
                 {
                     strategy.PredictOpponentsNextMove(moveHistory);
                 }
                    
            }

            return returnMove;
        }

        private IPredictionStrategy GetStrategyWithHighestFitness()
        {
            return Strategies.OrderByDescending(mp => mp.GetFitness()).FirstOrDefault();
        }
    }
}
