using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeathBot.Bot.Strategies;
using RockPaperScissorsPro;
using Xunit;

namespace DeathBot.Bot.Tests.Strategies
{
    public class OpponentRulesStrategyTests
    {
        [Fact]
        public void Predictions_Are_Null_When_Not_Enough_History()
        {
            var os = new OpponentRulesStrategy(3, new SimpleFitness());

            var history = new MoveHistory();

            var res = os.PredictOpponentsNextMove(history);

            Assert.Null(res);

            history.AddHistory(Moves.Rock, Moves.Rock);
            history.AddHistory(Moves.Rock, Moves.Rock);

            res = os.PredictOpponentsNextMove(history);

            Assert.Null(res);
        }
    }
}
