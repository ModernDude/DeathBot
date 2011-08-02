using System;
using System.Linq;
using System.Linq.Expressions;
using RockPaperScissorsPro;
using Xunit;

namespace DeathBot.Bot.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    public class MoveHistoryTest
    {
        public void Default_History_Is_Empty()
        {
            var history = new MoveHistory();

            var myHistoryCount = history.GetMyHistory().ToList().Count;
            var opponentHistoryCount = history.GetMyOppenentsHistory().ToList().Count;
            var bothCount = history.GetMyAndOpponentsHistory().ToList().Count();

            Assert.Equal(0, myHistoryCount);
            Assert.Equal(0, opponentHistoryCount);
            Assert.Equal(0, bothCount);
        }

        [Fact]
        public void Counts_Correct_When_History_Exists()
        {
            var history = new MoveHistory();

            history.AddHistory(Moves.Rock, Moves.WaterBalloon);
            history.AddHistory(Moves.Scissors, Moves.Rock);

            var myHistoryCount = history.GetMyHistory().ToList().Count;
            var opponentHistoryCount = history.GetMyOppenentsHistory().ToList().Count;
            var bothCount = history.GetMyAndOpponentsHistory().ToList().Count();

            Assert.Equal(2, myHistoryCount);
            Assert.Equal(2, opponentHistoryCount);
            Assert.Equal(2, bothCount);
        }

        [Fact]
        public void Retreived_Values_Correct_Order()
        {
            var history = new MoveHistory();

            history.AddHistory(Moves.Rock, Moves.WaterBalloon);
            history.AddHistory(Moves.Scissors, Moves.Rock);

            var myHistory = history.GetMyHistory().ToList();
            var opponentHistory = history.GetMyOppenentsHistory().ToList();
            var both = history.GetMyAndOpponentsHistory().ToList();

            Assert.Equal(myHistory[0], Moves.Scissors);
            Assert.Equal(myHistory[1], Moves.Rock);

            Assert.Equal(opponentHistory[0], Moves.Rock);
            Assert.Equal(opponentHistory[1], Moves.WaterBalloon);

            Assert.True(both[0].Equals(Tuple.Create(Moves.Scissors, Moves.Rock)));
            Assert.True(both[1].Equals(Tuple.Create(Moves.Rock, Moves.WaterBalloon)));
        }
    }
}
