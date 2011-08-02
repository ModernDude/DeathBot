namespace DeathBot.Bot
{
    /// <summary>
    /// Behavior for generating a random number. Necessary mainly for testing.
    /// </summary>
    public interface IRandomNumber
    {
        int Next(int min, int max);
    }
}