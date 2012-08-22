using System.Collections.Generic;
using BuildEmUp.Interface;

namespace BuildEmUp.Implementation
{
    public class City : ICity
    {
        private List<Person> _people;

        public City()
        {
            _people = new List<Person>();
        }


        public List<Person> GetInhabitans()
        {
            return _people;
        }

        public decimal GetCurrentCityAttractiveness()
        {
            //todo: available jobs & environment & public services & quality of life
            return 70m;
        }
    }
}
