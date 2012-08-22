using System;
using System.Collections.Generic;
using BuildEmUp.Enum;

namespace BuildEmUp
{
    public interface ILotteryDrawing
    {
        void DrawAWinner();
        int CreateTicketNumber();

        LotteryType LotteryType { get; }
        decimal Jackpot { get; }
        List<LotteryTicket> SoldTickets { get; }
        IPerson Winner { get; }
        Random ChanceMachine { get; set; }
    }
}