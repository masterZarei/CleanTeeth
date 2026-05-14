using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.ValueObjects
{
    [TestClass]
    public class TimeIntervalTests
    {
        [TestMethod]
        public void Constructor_StartIsAfterEnd_Throws() 
        {
            Assert.Throws<BusinessRuleException>(() =>
            {
                new TimeIntervalValueObject(DateTime.UtcNow, DateTime.UtcNow.AddDays(-1));
            });
        }
        [TestMethod]
        public void Constructor_ValidTimeInterval_NoException()
        {
            new TimeIntervalValueObject(DateTime.UtcNow, DateTime.UtcNow.AddHours(1));
        }
    }
}
