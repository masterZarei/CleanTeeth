using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void Constructor_NullEmail_Throws()
        {
            Assert.Throws<BusinessRuleException>(() =>
            {
                new EmailValueObject(null);
            });
        }

        [TestMethod]
        public void Constructor_InvalidEmail_Throws()
        {
            Assert.Throws<BusinessRuleException>(() =>
            {
                new EmailValueObject("felipe.com");
            });
        }

        [TestMethod]
        public void Constructor_ValidEmail_Throws()
        {
            _ = new EmailValueObject("felipe@gmail.com");
        }
    }
}
