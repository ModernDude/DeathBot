using System;
using System.Security.Cryptography;

namespace DeathBot.Bot
{
    /// <summary>
    /// A random number generator that does a bit better than System.Random. 
    /// </summary>
    public class RandomNumber : IRandomNumber
    {
        #region IRandomNumberMembers

        public int Next(int min, int max)
        {       
            if (max < min) throw new ArgumentOutOfRangeException("max");

            using (var rng = new RNGCryptoServiceProvider())
            {
                var buffer = new byte[4];

                FillWithCryptoStrongSequenceOfRandomValues(buffer);

                var result = BitConverter.ToInt32(buffer, 0);

                return new Random(result).Next(min, max);
            }
        }

        private static void FillWithCryptoStrongSequenceOfRandomValues(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buffer);
            }
        }

        #endregion
    }
}