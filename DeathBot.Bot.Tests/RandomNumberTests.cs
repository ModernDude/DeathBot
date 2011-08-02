using System;
using Xunit;

namespace DeathBot.Bot.Tests
{
    public class RandomNumberTests
    {
        [Fact]
        public void Can_Generate_Single_Number_Within_One_Number_Range()
        {
            var random = new RandomNumber();

            var res = random.Next(3, 3);

            Assert.Equal(3, res);
        }

        [Fact]
        public void Can_Generate_Single_Numbers_Within_Range()
        {
            var random = new RandomNumber();

            var res = random.Next(3, 6);

            Assert.InRange(res, 3, 6);
        }

        [Fact]
        public void Invalid_Range_Rejected()
        {
            var randmon = new Random();

            Assert.Throws<ArgumentOutOfRangeException>(() => randmon.Next(3, 2));
        }
    }
}