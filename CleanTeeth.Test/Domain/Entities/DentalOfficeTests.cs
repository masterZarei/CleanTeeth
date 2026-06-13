using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Test.Domain.Entities
{
    [TestClass]
    public class DentalOfficeTests
    {
        [TestMethod]
        public void Constructor_NullName_Throws()
        {
            Assert.Throws<BusinessRuleException>(() =>
            {
                new DentalOffice(null!);
            });
        }
    }
}
