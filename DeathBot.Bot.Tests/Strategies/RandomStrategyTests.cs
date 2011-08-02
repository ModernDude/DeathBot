using DeathBot.Bot.Strategies;
using Moq;
using RockPaperScissorsPro;
using Xunit;

namespace DeathBot.Bot.Tests.Strategies
{
    public class RandomStrategyTests
    {
        [Fact]
        public void Can_Make_Random_Predictions()
        {
            var mock = new Mock<IRandomNumber>();

            int calls = 0;

            mock.Setup(r => r.Next(0, 4))
                .Returns(() => calls)
                .Callback(() => calls++);

            var randomMovePredictor = new RandomStrategy(mock.Object, new SimpleFitness());

            var moveHistory = new MoveHistory();
            moveHistory.AddHistory(Moves.Rock, Moves.Rock);

            Assert.Equal(randomMovePredictor.PredictOpponentsNextMove(moveHistory), Moves.Paper);
            Assert.Equal(randomMovePredictor.PredictOpponentsNextMove(moveHistory), Moves.Scissors);
            Assert.Equal(randomMovePredictor.PredictOpponentsNextMove(moveHistory), Moves.Rock);
            Assert.Equal(randomMovePredictor.PredictOpponentsNextMove(moveHistory), Moves.Dynamite);
            Assert.Equal(randomMovePredictor.PredictOpponentsNextMove(moveHistory), Moves.WaterBalloon);
        }
                    
    }
}