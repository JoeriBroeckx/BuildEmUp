using System.Collections.Generic;

namespace BuildEmUp
{
    public interface ILottery
    {
        void SellTicketTo(ILotteryDrawing drawing, IPerson buyer);
        void DrawWinnerFor(ILotteryDrawing drawing);
        void PayOut(IPerson winner, decimal jackpot);
        void AppendFunds(decimal amount);

        decimal Funds { get; }
        List<ILotteryDrawing> ActiveDrawings { get; }
        List<ILotteryDrawing> PastDrawings { get; }
    }
}