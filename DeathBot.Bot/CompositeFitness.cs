using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeathBot.Bot.Strategies;

namespace DeathBot.Bot
{
    public class CompositeFitness : IStrategyFitness
    {
        private readonly List<IPredictionStrategy> _strategies;

        public CompositeFitness(List<IPredictionStrategy> strategies )
        {
            _strategies = strategies;
        }

        private IPredictionStrategy GetStrategyWithHighestFitness()
        {
            return _strategies.OrderByDescending(mp => mp.GetFitness()).FirstOrDefault();
        }

        public float GetFitness()
        {
            var strategy = GetStrategyWithHighestFitness();

            return strategy != null ? strategy.GetFitness() : 0;
        }
    }
}
