using RockPaperScissorsPro;
using Xunit;

namespace DeathBot.Bot.Tests
{
    public class SimpleFitnessTests
    {
        [Fact]
        public void Fitness_Default_To_One()
        {
            var fitness = new SimpleFitness();

            var res = fitness.GetFitness();

            Assert.Equal(1, res);
        }

        [Fact]
        public void Fitness_Zero_After_One_Wrong_Prediction()
        {
            var fitness = new SimpleFitness();

            fitness.LogOpponentMove(Moves.Rock, Moves.Paper);

            var res = fitness.GetFitness();

            Assert.Equal(0, res);
        }

        [Fact]
        public void Fitness_Fifty_After_One_Wrong_And_One_Right_Prediction()
        {
            var fitness = new SimpleFitness();

            fitness.LogOpponentMove(Moves.Rock, Moves.Paper);
            fitness.LogOpponentMove(Moves.Scissors, Moves.Scissors);

            var res = fitness.GetFitness();

            Assert.Equal(.50, res);
        }
    }
}