using System.Collections.Generic;
using DeathBot.Bot.Strategies;
using RockPaperScissorsPro;
using Xunit;

namespace DeathBot.Bot.Tests.Strategies
{
    public class RuleTest
    {
        [Fact]
        public void Rule_Defaults_To_Unmatched()
        {
            var rule = CreateRule();

            Assert.Equal(false, rule.IsMatched);
        }

        [Fact]
        public void Rule_Weight_Default_To_Zero()
        {
            var rule = CreateRule();

            Assert.Equal(0, rule.Weight);
        }

        [Fact]
        public void Rule_Created_With_Arbitrary_Number_Of_Antecedents()
        {
            var rule = CreateRule();

            Assert.Equal(3, rule.Antecedents.Count);
            Assert.Equal(Moves.Scissors, rule.Consequent);
        }


        [Fact]
        public void Can_Increment_Weight()
        {
            var rule = CreateRule();

            rule.IncrementWeight();

            Assert.Equal(1, rule.Weight);
        }


        [Fact]
        public void Can_Decrement_Weight()
        {
            var rule = CreateRule();

            rule.DecrementWeight();

            Assert.Equal(-1, rule.Weight);
        }

        private Rule CreateRule()
        {
            return new Rule(new List<Move>
                                {
                                    Moves.Dynamite,
                                    Moves.Rock,
                                    Moves.Scissors
                                }, Moves.Scissors);
        }
    }
}