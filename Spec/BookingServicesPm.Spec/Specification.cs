using NUnit.Framework;

namespace BookingServicesPm.Spec
{
    [TestFixture]
    public class Specification
    {

        [TestFixtureSetUp]
        public void SetUp()
        {
            Given();
            When();
        }
        
        protected virtual void Given()
        {
        }

        protected virtual void When()
        {
        }
    }
}
