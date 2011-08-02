using System;
using System.Collections.Generic;
using System.Linq;
using RockPaperScissorsPro;

namespace DeathBot.Bot.Strategies
{
    public class RuleTable
    {
        private readonly Dictionary<int, List<Rule>> _rulesHashedByAntecedent;
        private List<Rule> _matchedRules;

        public RuleTable(int antecedentCount)
        {
            if (antecedentCount <= 0)
                throw new ArgumentOutOfRangeException("antecedentCount", "must be greater than zero");

            _rulesHashedByAntecedent = new Dictionary<int, List<Rule>>();
            _matchedRules = new List<Rule>();
            Rules = new List<Rule>();
            AntecedentCount = antecedentCount;

            BuildTable(antecedentCount);
        }

        private void BuildTable(int antecedentCount)
        {
            var query = Enumerable
                .Range(0, antecedentCount + 1)
                .Select(x => GetMoves());

            foreach (var ruleDef in query.CartesianProduct())
            {
                var moves = ruleDef.ToList();
                var antecedents = new List<Move>(antecedentCount);
                moves.Take(antecedentCount).ToList().ForEach(antecedents.Add);

                var rule = new Rule(antecedents, moves.Last());
                Rules.Add(rule);
                AddRuleToAntecedentHash(rule);
            }
        }

        public List<Rule> Rules { get; set; }
        private int AntecedentCount { get; set; }


        private void AddRuleToAntecedentHash(Rule rule)
        {
            var hashCode = GetAntecedentsHashCode(rule.Antecedents);

            if (!_rulesHashedByAntecedent.ContainsKey(hashCode))
                _rulesHashedByAntecedent.Add(hashCode, new List<Rule>());

            _rulesHashedByAntecedent[hashCode].Add(rule);
        }


        public Rule GetMatchedHighestWeight()
        {
            return GetMatched().OrderByDescending(r => r.Weight).FirstOrDefault();
        }

        public Rule GetMatchedConsequent(Move consequent)
        {
            return GetMatched().Where(r => r.Consequent == consequent).FirstOrDefault();
        }


        public void SetMatched(List<Move> antecedents)
        {
            if (antecedents == null) throw new ArgumentNullException("antecedents");

            //unmatch previos rules
            if (_matchedRules != null)
                _matchedRules.ForEach(rule => rule.IsMatched = false);

            _matchedRules = FindRulesByAntecedents(antecedents);
            _matchedRules.ForEach(rule => rule.IsMatched = true);
        }


        public IEnumerable<Rule> GetMatched()
        {
            return _matchedRules;
        }


        public List<Rule> FindRulesByAntecedents(List<Move> antecedents)
        {
            return _rulesHashedByAntecedent[GetAntecedentsHashCode(antecedents)];
        }


        private int GetAntecedentsHashCode(IEnumerable<Move> antecedents)
        {
            unchecked
            {
                return antecedents.Aggregate(17, (current, a) => current*23 + a.GetHashCode());
            }
        }

        private static IEnumerable<Move> GetMoves()
        {
            yield return Moves.Rock;
            yield return Moves.Paper;
            yield return Moves.Scissors;
            yield return Moves.Dynamite;
            yield return Moves.WaterBalloon;
        }
    }
}