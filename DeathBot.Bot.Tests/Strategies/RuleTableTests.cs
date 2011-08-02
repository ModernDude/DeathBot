using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeathBot.Bot.Strategies;
using RockPaperScissorsPro;
using Xunit;

namespace DeathBot.Bot.Tests.Strategies
{
    public class RuleTableTest
    {
        [Fact]
        public void CanNotInitWithCountLessThanOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new RuleTable(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new RuleTable(-1));
        }

        [Fact]
        public void RuleTableInitOfSizeOneProducesProperRules()
        {
            var table = new RuleTable(1);

            Assert.Equal(25, table.Rules.Count);

            int[] index = { 0 };


            Func<Rule> nextRule = () => table.Rules[index[0]++];

            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Rock), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Paper), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Scissors), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Dynamite), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.WaterBalloon), nextRule());

            AssertRulesEqual(RuleFrom(Moves.Paper, Moves.Rock), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Paper, Moves.Paper), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Paper, Moves.Scissors), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Paper, Moves.Dynamite), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Paper, Moves.WaterBalloon), nextRule());

            AssertRulesEqual(RuleFrom(Moves.Scissors, Moves.Rock), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Scissors, Moves.Paper), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Scissors, Moves.Scissors), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Scissors, Moves.Dynamite), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Scissors, Moves.WaterBalloon), nextRule());

            AssertRulesEqual(RuleFrom(Moves.Dynamite, Moves.Rock), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Dynamite, Moves.Paper), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Dynamite, Moves.Scissors), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Dynamite, Moves.Dynamite), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Dynamite, Moves.WaterBalloon), nextRule());

            AssertRulesEqual(RuleFrom(Moves.WaterBalloon, Moves.Rock), nextRule());
            AssertRulesEqual(RuleFrom(Moves.WaterBalloon, Moves.Paper), nextRule());
            AssertRulesEqual(RuleFrom(Moves.WaterBalloon, Moves.Scissors), nextRule());
            AssertRulesEqual(RuleFrom(Moves.WaterBalloon, Moves.Dynamite), nextRule());
            AssertRulesEqual(RuleFrom(Moves.WaterBalloon, Moves.WaterBalloon), nextRule());

        }

        [Fact]
        public void RuleTableInitOfSizeTwoProducesProperRules()
        {
            var table = new RuleTable(2);

            var rules = table.Rules;

            Assert.Equal(125, rules.Count());

            int[] index = { 0 };

            Func<Rule> nextRule = () => rules[index[0]++];

            //spot check
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Rock, Moves.Rock), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Rock, Moves.Paper), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Rock, Moves.Scissors), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Rock, Moves.Dynamite), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Rock, Moves.WaterBalloon), nextRule());

            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Paper, Moves.Rock), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Paper, Moves.Paper), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Paper, Moves.Scissors), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Paper, Moves.Dynamite), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Paper, Moves.WaterBalloon), nextRule());

            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Scissors, Moves.Rock), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Scissors, Moves.Paper), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Scissors, Moves.Scissors), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Scissors, Moves.Dynamite), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Scissors, Moves.WaterBalloon), nextRule());

            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Dynamite, Moves.Rock), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Dynamite, Moves.Paper), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Dynamite, Moves.Scissors), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Dynamite, Moves.Dynamite), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.Dynamite, Moves.WaterBalloon), nextRule());

            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.WaterBalloon, Moves.Rock), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.WaterBalloon, Moves.Paper), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.WaterBalloon, Moves.Scissors), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.WaterBalloon, Moves.Dynamite), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Rock, Moves.WaterBalloon, Moves.WaterBalloon), nextRule());

            AssertRulesEqual(RuleFrom(Moves.Paper, Moves.Rock, Moves.Rock), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Paper, Moves.Rock, Moves.Paper), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Paper, Moves.Rock, Moves.Scissors), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Paper, Moves.Rock, Moves.Dynamite), nextRule());
            AssertRulesEqual(RuleFrom(Moves.Paper, Moves.Rock, Moves.WaterBalloon), nextRule());
        }



        [Fact]
        public void CanSetMatched()
        {
            var table = new RuleTable(2);
            
            var firstMatch = new List<Move> { Moves.Paper, Moves.Rock };

            table.SetMatched(firstMatch);

            var rules = table.Rules;

            rules.Where(r => r.Antecedents.SequenceEqual(firstMatch)).ToList().ForEach(r => Assert.True(r.IsMatched));
            rules.Where(r => !r.Antecedents.SequenceEqual(firstMatch)).ToList().ForEach(r => Assert.False(r.IsMatched));

            var secondMatch = new List<Move> { Moves.Rock, Moves.Paper };

            table.SetMatched(secondMatch);
            rules.Where(r => r.Antecedents.SequenceEqual(secondMatch)).ToList().ForEach(r => Assert.True(r.IsMatched));
            rules.Where(r => !r.Antecedents.SequenceEqual(secondMatch)).ToList().ForEach(r => Assert.False(r.IsMatched));
        }

        [Fact]
        public void CanGetMatched()
        {
            var table = new RuleTable(2);

            var firstMatch = new List<Move> { Moves.Paper, Moves.Rock };

            table.SetMatched(firstMatch);

            var rules = table.FindRulesByAntecedents(firstMatch);

            var matched = table.GetMatched().ToList();

            Assert.Equal(5, matched.Count);
            Assert.Equal(rules[0], matched[0]);
            Assert.Equal(rules[1], matched[1]);
            Assert.Equal(rules[2], matched[2]);
            Assert.Equal(rules[3], matched[3]);
            Assert.Equal(rules[4], matched[4]);
        }


        [Fact]
        public void MatchedHighestWeightIsNullWhenNoMatches()
        {
            var table = new RuleTable(2);
            
            var res = table.GetMatchedHighestWeight();

            Assert.Null(res);
        }

        [Fact]
        public void MatchedHighestWeightReturnsOneOfTopIfMoreThanOneWeightSame()
        {
            var table = new RuleTable(1);
            
            var firstMatch = new List<Move> { Moves.Paper };

            table.SetMatched(firstMatch);

            var rules = table.FindRulesByAntecedents(firstMatch);

            var rule1 = rules[0];
            var rule2 = rules[1];
            var rule3 = rules[2];

            rule1.IsMatched = true;
            Do(rule1.IncrementWeight, 10);

            rule2.IsMatched = true;
            Do(rule2.IncrementWeight, 10);

            rule3.IsMatched = true;
            Do(rule3.IncrementWeight, 9);

            var res = table.GetMatchedHighestWeight();

            Assert.Equal(10, res.Weight);
        }


        [Fact]
        public void MatchedHighestWeightReturnsProperWhenNonMatchesIsGreater()
        {
            var table = new RuleTable(1);
           
            var firstMatch = new List<Move> { Moves.Paper };
            table.SetMatched(firstMatch);
            var firstRules = table.FindRulesByAntecedents(firstMatch);
            Do(firstRules[0].IncrementWeight, 20);
            Do(firstRules[1].IncrementWeight, 10);

            var secondMatch = new List<Move> { Moves.Rock };
            table.SetMatched(secondMatch);
            var secondRules = table.FindRulesByAntecedents(secondMatch);
            Do(secondRules[0].IncrementWeight, 6);
            Do(secondRules[1].IncrementWeight, 5);

            var res = table.GetMatchedHighestWeight();
            Assert.Equal(6, res.Weight);

        }


        [Fact]
        public void CanGetMatchedConsequentReturnsNullWhenNoMatches()
        {
            var table = new RuleTable(2);
            
            Assert.Null(table.GetMatchedConsequent(Moves.Scissors));
        }

        [Fact]
        public void CanGetMatchedConsequent()
        {
            var table = new RuleTable(2);
            
            var rules = table.Rules;

            table.SetMatched(new List<Move>() { Moves.Paper, Moves.Rock });

            var rule = table.GetMatchedConsequent(Moves.Scissors);

            Assert.NotNull(rule);
            Assert.True(rule.IsMatched);
            Assert.Equal(Moves.Paper, rule.Antecedents[0]);
            Assert.Equal(Moves.Rock, rule.Antecedents[1]);
            Assert.Equal(rule.Consequent, Moves.Scissors);
        }



        private static void Do(Action action, int times)
        {
            Enumerable.Range(0, times).ToList().ForEach(i => action());
        }

        private static Rule RuleFrom(Move antecedent, Move consequent)
        {
            return new Rule(new List<Move> { antecedent }, consequent);
        }

        private static Rule RuleFrom(Move antecedent1, Move antecedent2, Move consequent)
        {
            return new Rule(new List<Move> { antecedent1, antecedent2 }, consequent);
        }

        private static void AssertRulesEqual(Rule expected, Rule actual)
        {
            Assert.Equal(expected.IsMatched, actual.IsMatched);
            Assert.Equal(expected.Weight, actual.Weight);
            Assert.Equal(expected.Antecedents, actual.Antecedents);
            Assert.Equal(expected.Consequent, actual.Consequent);
        }
    }
}
