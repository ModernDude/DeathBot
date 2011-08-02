using RockPaperScissorsPro;

namespace DeathBot.Bot
{
    public class SimpleFitness : IStrategyFitness
    {
        private int _successfullPredictions;
        private int _totalPredictions;

        public SimpleFitness()
        {
            _totalPredictions = 0;
            _successfullPredictions = 0;
        }

        #region IStrategyFitness Members

        public float GetFitness()
        {
            return _totalPredictions > 0 ? _successfullPredictions/(float) _totalPredictions : 1;
        }

        #endregion

        public void LogOpponentMove(Move prediction, Move actual)
        {
            _totalPredictions++;

            if (prediction == actual)
                _successfullPredictions++;
        }
    }
}