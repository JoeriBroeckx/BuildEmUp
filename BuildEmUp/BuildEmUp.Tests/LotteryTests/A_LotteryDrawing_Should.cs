using System;
using BuildEmUp.Enum;
using Moq;
using NUnit.Framework;

namespace BuildEmUp.Tests
{
    [TestFixture]
    public class A_LotteryDrawing_Should
    {
        private LotteryDrawing _lotteryDrawing;
        
        private Mock<Random> _randomNumberGenerator;
        
        private decimal _jackpot;
        private IPerson _unluckyBuyer;
        private IPerson _luckyBuyer;

        [SetUp]
        public void Setup()
        {
            _jackpot = 50000;
            _luckyBuyer = new Person();
            _unluckyBuyer = new Person();
            
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
        public void Be_able_to_pick_out_the_winning_person()
        {
            _lotteryDrawing.SoldTickets.Add(new LotteryTicket(12345, _luckyBuyer));
            _lotteryDrawing.SoldTickets.Add(new LotteryTicket(54321, _unluckyBuyer));

            _lotteryDrawing.DrawAWinner();

            var result = _lotteryDrawing.Winner;

            Assert.AreEqual(_luckyBuyer, result);
        }

        [Test]
        public void Be_able_to_hold_the_sold_tickets()
        {
            _lotteryDrawing.SoldTickets.Add(new LotteryTicket(12345, _luckyBuyer));

            Assert.AreEqual(1, _lotteryDrawing.SoldTickets.Count);
        }
    }
}
