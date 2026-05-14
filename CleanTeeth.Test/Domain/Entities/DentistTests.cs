using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.Entities
{
    [TestClass]
    public class DentistTests
    {
        [TestMethod]
        public void Constructor_NullName_Throws()
        {
            Assert.Throws<BusinessRuleException>(() =>
            {
                var email = new EmailValueObject("test@test.com");
                new Dentist(null!, email);
            });
        }
        [TestMethod]
        public void Constructor_NullEmail_Throws()
        {
            Assert.Throws<BusinessRuleException>(() =>
            {
                new Dentist("Felipe", email: null!);
            });
        }

        [TestMethod]
        public void Constructor_ValidDentist_NoExceptions()
        {
            var email = new EmailValueObject("felipe@example.com");
            new Dentist("Felipe", email);
        }
    }
}
