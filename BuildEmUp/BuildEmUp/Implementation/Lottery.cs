using System;
using System.Collections.Generic;
using BuildEmUp.Enum;

namespace BuildEmUp
{
    public class Lottery : ILottery
    {
        public Lottery()
        {
            Funds = 0;
            ActiveDrawings = new List<ILotteryDrawing>();
            PastDrawings = new List<ILotteryDrawing>();
        }

        public void CreateNewLotteryDrawing()
        {
            //TODO: check the amount of funds + "Publishing"
            // If "normal" --> publish a normal lotto
            // If "big surplus" --> publish a super special lotto!

            var drawing = new LotteryDrawing(LotteryType.Normal, Funds);
            ActiveDrawings.Add(drawing);
        }

        public void SellTicketTo(ILotteryDrawing drawing, IPerson buyer)
        {
            var ticketNumber = drawing.CreateTicketNumber();
            var ticket = new LotteryTicket(ticketNumber, buyer);

            ChargeForTicket(buyer, (decimal)drawing.LotteryType);

            drawing.SoldTickets.Add(ticket);
        }

        private void ChargeForTicket(IPerson buyer, decimal price)
        {
            buyer.Pays(price);
            Funds += price;
        }

        public void DrawWinnerFor(ILotteryDrawing drawing)
        {
            drawing.DrawAWinner();

            if (drawing.Winner != null)
            {
                PayOut(drawing.Winner, drawing.Jackpot);
                AnnounceWinner();
            }
            else
            {
                AnnounceNoWinner();
            }

            ActiveDrawings.Remove(drawing);
            PastDrawings.Add(drawing);
        }

        public void PayOut(IPerson winner, decimal jackpot)
        {
            winner.Receives(jackpot);
            Funds -= jackpot;
        }

        public void AppendFunds(decimal amount)
        {
            Funds += amount;
        }

        #region Todos

        private void AnnounceWinner()
        {
            //TODO: announce winner --> raises peoples spirits
        }
        
        private void AnnounceNoWinner()
        {
            //TODO: announce nowinner --> raises their willingness to invest
        }
        #endregion

        #region Getters & setters

        public decimal Funds
        {
            get; 
            private set;
        }

        public List<ILotteryDrawing> ActiveDrawings
        {
            get;
            private set;
        }

        public List<ILotteryDrawing> PastDrawings
        {
            get;
            private set;
        }
        #endregion
    }
}
