using System;
using BuildEmUp.Enum;
using Moq;
using NUnit.Framework;

namespace BuildEmUp.Tests
{
    [TestFixture]
    public class A_LotteryDrawing_With_Sold_Tickets
    {
        private IPerson _unluckyBuyer;
        private IPerson _luckyBuyer;
        private int _jackpot;
        private Mock<Random> _randomNumberGenerator;
        private LotteryDrawing _lotteryDrawing;

        [SetUp]
        public void Setup()
        {
            _luckyBuyer = new Person();
            _unluckyBuyer = new Person();

            _randomNumberGenerator = new Mock<Random>();

            _lotteryDrawing = new LotteryDrawing(LotteryType.Normal, _jackpot);
            _lotteryDrawing.ChanceMachine = _randomNumberGenerator.Object;

            _lotteryDrawing.SoldTickets.Add(new LotteryTicket(12345, _luckyBuyer));
            _lotteryDrawing.SoldTickets.Add(new LotteryTicket(54321, _unluckyBuyer));
        }

        [Test]
        public void Given_a_buyer_that_has_the_same_ticketnumber_as_the_drawn_ticket_he_should_be_the_winner()
        {
            _randomNumberGenerator
                .Setup(x => x.Next(1, 25000001))
                .Returns(() => 12345);

            _lotteryDrawing.DrawAWinner();

            var result = _lotteryDrawing.Winner;

            Assert.AreEqual(_luckyBuyer, result);
        }

    }
}