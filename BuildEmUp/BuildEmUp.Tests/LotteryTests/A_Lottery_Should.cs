using System.Collections.Generic;
using BuildEmUp.Enum;
using Moq;
using NUnit.Framework;

namespace BuildEmUp.Tests
{
    [TestFixture]
    public class A_Lottery_Should
    {
        private Lottery _lottery;

        private Mock<ILotteryDrawing> _mockedDrawing;
        private Mock<IPerson> _luckyBuyer;

        private const decimal Funding = 500;

        [SetUp]
        public void Setup()
        {
            _luckyBuyer = new Mock<IPerson>();
            _mockedDrawing = new Mock<ILotteryDrawing>();

            _lottery = new Lottery();
            _lottery.AppendFunds(Funding);

            _mockedDrawing
                .Setup(x => x.SoldTickets)
                .Returns(() => new List<LotteryTicket>());
            _mockedDrawing
                .Setup(x => x.Winner)
                .Returns(() => _luckyBuyer.Object);
            _mockedDrawing
                .Setup(x => x.Jackpot)
                .Returns(() => 500m);
            _mockedDrawing
                .Setup(x => x.LotteryType)
                .Returns(() => LotteryType.Normal);
        }


        [Test]
        public void Be_able_to_create_a_new_drawing()
        {
            _lottery.CreateNewLotteryDrawing();

            var result = _lottery.ActiveDrawings;
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void Be_able_to_sell_lottery_tickets_for_a_drawing()
        {
            _lottery.SellTicketTo(_mockedDrawing.Object, _luckyBuyer.Object);

            var result = _lottery.Funds;
            _mockedDrawing.Verify(x => x.CreateTicketNumber());
            _luckyBuyer.Verify(x => x.Pays((decimal)LotteryType.Normal));
            _mockedDrawing.Verify(x => x.SoldTickets);
            Assert.AreEqual(Funding + (decimal)LotteryType.Normal, result);
        }

        [Test]
        public void Charge_the_correct_amount_for_a_normal_ticket()
        {
            _mockedDrawing.Setup(x => x.LotteryType).Returns(() => LotteryType.Normal);

            _lottery.SellTicketTo(_mockedDrawing.Object, _luckyBuyer.Object);

            _luckyBuyer.Verify(x => x.Pays((decimal)LotteryType.Normal));
        }

        [Test]
        public void Charge_the_correct_amount_for_a_special_ticket()
        {
            _mockedDrawing.Setup(x => x.LotteryType).Returns(() => LotteryType.Special);

            _lottery.SellTicketTo(_mockedDrawing.Object, _luckyBuyer.Object);

            _luckyBuyer.Verify(x => x.Pays((decimal)LotteryType.Special));
        }

        [Test]
        public void Be_able_to_end_a_drawing()
        {
            _lottery.DrawWinnerFor(_mockedDrawing.Object);

            _mockedDrawing.Verify(x => x.DrawAWinner());
            Assert.True(_lottery.ActiveDrawings.Count == 0);
            Assert.True(_lottery.PastDrawings.Count == 1);
        }

        [Test]
        public void Be_able_to_pay_out_a_winner()
        {
            _lottery.DrawWinnerFor(_mockedDrawing.Object);

            _luckyBuyer.Verify(x => x.Receives(Funding));
        }

        [Test]
        public void Not_pay_out_if_there_was_no_winner()
        {
            _mockedDrawing.Setup(x => x.Winner).Returns(() => null);

            _lottery.DrawWinnerFor(_mockedDrawing.Object);

            var amountOfFunds = _lottery.Funds;
            Assert.AreEqual(Funding, amountOfFunds);
        }
    }
}