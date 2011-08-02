using RockPaperScissorsPro;

namespace DeathBot.Bot.Strategies
{
    /// <summary>
    /// Anything that is going to predict a move needs to behave this way.
    /// </summary>
    public interface IPredictionStrategy : IStrategyFitness
    {
        Move PredictOpponentsNextMove(MoveHistory moveHistory);
    }
}