namespace BuildEmUp
{
    public class LotteryTicket
    {
        public LotteryTicket(int ticketNumber, IPerson person)
        {
            TicketNumber = ticketNumber;
            Person = person;
        }

        public IPerson Person { get; private set; }
        public int TicketNumber { get; private set; }
    }
}
