using System;
using BuildEmUp.Enum;
using Moq;
using NUnit.Framework;

namespace BuildEmUp.Tests
{
    [TestFixture]
    public class A_New_LotteryDrawing_Should
    {
        private LotteryDrawing _lotteryDrawing;
        
        private Mock<Random> _randomNumberGenerator;
        
        private decimal _jackpot;


        [SetUp]
        public void Setup()
        {           
            _randomNumberGenerator = new Mock<Random>();

            _lotteryDrawing = new LotteryDrawing(LotteryType.Normal, _jackpot);
            _lotteryDrawing.ChanceMachine = _randomNumberGenerator.Object;

            _randomNumberGenerator
                .Setup(x => x.Next(1, 25000001))
                .Returns(() => 12345);
        }

        
        [Test]
        public void Be_able_to_make_a_random_number()
        {
            var result = _lotteryDrawing.CreateTicketNumber();

            Assert.IsInstanceOf<int>(result);
            Assert.True(result > 1);
            Assert.True(result < 25000001);
        }

        [Test]
        public void Be_able_to_hold_the_sold_tickets()
        {
            _lotteryDrawing.SoldTickets.Add(new LotteryTicket(12345, new Person()));

            Assert.AreEqual(1, _lotteryDrawing.SoldTickets.Count);
        }
    }
}
