namespace BuildEmUp
{
    public class Account
    {
        // account is een data klasse

        private decimal _savings;

        public Account(decimal initialDeposit)
        {
            
        }

        public void Add(decimal amount)
        {
            _savings += amount;
        }

        public void Subtract(decimal amount)
        {
            _savings -= amount;
        }
    }
}