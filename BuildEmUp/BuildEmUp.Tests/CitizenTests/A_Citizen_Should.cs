using NUnit.Framework;

namespace BuildEmUp.Tests
{
    [TestFixture]
    public class A_Citizen_Should
    {
        private Person _person;

        [SetUp]
        public void Setup()
        {
            _person = new Person();
        }


        [Test]
        public void Be_able_to_create_a_random_citizen()
        {
            Assert.IsNotNull(_person.GetFinancialProfile());
        }
    }
}
