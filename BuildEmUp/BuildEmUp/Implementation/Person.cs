using System;
using BuildEmUp.Enum;

namespace BuildEmUp
{
    public class Person : IPerson
    {
        private Account _account;
        
        // link to the partner (and their willingness to invest)
        // risk factors, such as children, ..
        // share an account with the partner?
        // happiness rating
        // health
        // disease
        // should be following up on his own stock and sell if he deems it necessary
        // age
        // should be able to die
        // een bedrijf moet citizens met benodigde skills van andere steden kunnen aantrekken (met bv een aantrekbonus?) moesten die niet aanwezig zijn in de stad

        public Person()
        {
            CreateNewCitizen(new Random());
        }

        private void CreateNewCitizen(Random random)
        {
            _account = new Account(random.Next(2000,50000));
            
            // person should buy a housing
            // person will probably need a loan to buy this housing
            // person should find a job (to pay the loan?)
            // person should "be good at certain things"

            // a person should have a believe (which has a slight effect on everything)
            // "looks"-rating
            // willingness to invest
            // skills (diploma?)
            // effectiveness with those skills
        }

        public void Pays(decimal amount)
        {
            _account.Subtract(amount);
        }

        public void Receives(decimal amount)
        {
            _account.Add(amount);
        }

        public Account GetFinancialProfile()
        {
            return _account;
        }
    }
}