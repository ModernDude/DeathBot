using System;
using System.Collections.Generic;
using RockPaperScissorsPro;

namespace DeathBot.Bot.Strategies
{
    /// <summary>
    /// Strategy is to predict completely randmon moves. 
    /// </summary>
    public class RandomStrategy : SimpleStrategyBase
    {
        private readonly List<Move> _moves = new List<Move>
                                                 {
                                                     Moves.Paper,
                                                     Moves.Scissors,
                                                     Moves.Rock,
                                                     Moves.Dynamite,
                                                     Moves.WaterBalloon
                                                 };

        private readonly IRandomNumber _randomNumber;


        public RandomStrategy(IRandomNumber randomNumber, SimpleFitness fitness) : base(fitness)
        {
            if (randomNumber == null) throw new ArgumentNullException("randomNumber");
            if (fitness == null) throw new ArgumentNullException("fitness");

            _randomNumber = randomNumber;
        }

        public override Move PredictOpponentsNextMove(MoveHistory moveHistory)
        {
            this.LogOpponentsPreviousMove(moveHistory.GetOpponentsPreviousMove());

            var random = _randomNumber.Next(0, _moves.Count - 1);
            CurrentPrediction = _moves[random];
            return CurrentPrediction;
        }
    }
}