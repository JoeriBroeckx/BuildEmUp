using System;
using System.Collections.Generic;
using System.Linq;
using BuildEmUp.Enum;

namespace BuildEmUp
{
    public class LotteryDrawing : ILotteryDrawing
    {
        private Random _chanceMachine;

        public LotteryDrawing(LotteryType type, decimal jackpot)
        {
            LotteryType = type;
            Jackpot = jackpot;

            SoldTickets = new List<LotteryTicket>();
        }

        public void DrawAWinner()
        {
            var winningTicket = DrawAWinningTicket();

            if (winningTicket != null)
            {
                Winner = winningTicket.Person;
            }
        }

        private LotteryTicket DrawAWinningTicket()
        {
            var winningTicketNumber = CreateTicketNumber();
            return SoldTickets.FirstOrDefault(ticket => ticket.TicketNumber == winningTicketNumber);
        }

        public int CreateTicketNumber()
        {
            return ChanceMachine.Next(1, 25000001);
        }


        #region Getters & setters

        public LotteryType LotteryType
        {
            get;
            private set;
        }

        public decimal Jackpot
        {
            get;
            private set;
        }

        public List<LotteryTicket> SoldTickets
        {
            get;
            private set;
        }

        public IPerson Winner
        {
            get;
            private set;
        }

        public Random ChanceMachine
        {
            get
            {
                if (_chanceMachine == null)
                    _chanceMachine = new Random();
                return _chanceMachine;
            }
            set
            {
                _chanceMachine = value;
            }
        }
        #endregion
    }
}
