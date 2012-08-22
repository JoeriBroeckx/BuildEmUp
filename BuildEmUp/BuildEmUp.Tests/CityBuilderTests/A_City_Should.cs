using NUnit.Framework;

namespace BuildEmUp.Tests.CityBuilderTests
{
    [TestFixture]
    public class A_CityBuilder_Should
    {
        /// <summary>
        /// Money flow:
        ///     Industrial needs employees
        ///         --> Employees get payed by the industries
        ///     Residential need shops
        ///         --> People spent money on items
        ///     Commercial needs goods to sell
        ///         --> Shops buy stock from companies
        /// 
        /// ==> Commercial driven 
        ///         We want to sell more, so we need more goods, which needs more workers, who need more shops, ..
        /// </summary>

        [Test]
        public void Assign_residential_lots_to_increase_civilian_growth()
        {

        }

        [Test]
        public void Assign_industrial_lots_to_increase_labor_growth()
        {

        }

        [Test]
        public void Assign_commercial_lots_to_increase_commercial_growth()
        {

        }

        [Test]
        public void Connect_lots_with_roads()
        {

        }

        [Test]
        public void Keep_all_lots_connected()
        {

        }

        [Test]
        public void Interconnect_zones_with_bigger_roads()
        {

        }

        [Test]
        public void Keep_industrial_zones_away_from_residential_areas()
        {

        }

        [Test]
        public void Only_build_if_there_is_a_need()
        {

        }

        [Test]
        public void Favor_putting_the_same_type_of_lot_near_eachother()
        {

        }

    }
}
