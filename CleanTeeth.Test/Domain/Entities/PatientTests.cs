using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.Entities
{
    [TestClass]
    public class PatientTests
    {
        [TestMethod]
        public void Constructor_NullName_Throws()
        {
            Assert.Throws<BusinessRuleException>(() =>
            {
                var email = new EmailValueObject("felipe@example.com");
                new Patient(null!, email);
            });
        }

        [TestMethod]
        public void Constructor_NullEmail_Throws()
        {
            Assert.Throws<BusinessRuleException>(() =>
            {
                new Patient("Felipe", email: null!);
            });
        }

        [TestMethod]
        public void Constructor_ValidPatient_NoExceptions()
        {
            var email = new EmailValueObject("felipe@example.com");
            new Patient("Felipe", email);
        }
    }
}
