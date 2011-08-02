using System;
using System.Collections.Generic;
using RockPaperScissorsPro;

namespace DeathBot.Bot
{
    public class MoveHistory
    {
        private readonly List<Move> _myHistory;
        private readonly List<Move> _opponentHistory;

        public MoveHistory()
        {
            _myHistory = new List<Move>();
            _opponentHistory = new List<Move>();
        }

        public void AddHistory(Move myMove, Move opponentsMove)
        {
            if (myMove == null) throw new ArgumentNullException("myMove");
            if (myMove == null) throw new ArgumentNullException("opponentsMove");

            _myHistory.Insert(0, myMove);
            _opponentHistory.Insert(0, opponentsMove);
        }

        /// <summary>
        /// Ordered such that move recent move is first
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Move> GetMyHistory()
        {
            return _myHistory;
        }

        /// <summary>
        /// Ordered such that most recent move is first. 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Move> GetMyOppenentsHistory()
        {
            return _opponentHistory;
        }


        public IEnumerable<Tuple<Move, Move>> GetMyAndOpponentsHistory()
        {
            for (var i = 0; i < Math.Min(_myHistory.Count, _opponentHistory.Count); i++)
            {
                yield return Tuple.Create(_myHistory[i], _opponentHistory[i]);
            }
        }

        public Move GetOpponentsPreviousMove()
        {
            return _opponentHistory.Count > 0 ? _opponentHistory[0] : null;
        }
    }
}