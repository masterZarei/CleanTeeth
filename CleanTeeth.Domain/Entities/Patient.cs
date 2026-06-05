using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public EmailValueObject Email { get; private set; } = null!;

        private Patient() { }
        public Patient(string name, EmailValueObject email)
        {
            EnforceNameBusinessRules(name);
            EnforceEmailBusinessRules(email);

            Name = name;
            Email = email;
            Id = Guid.CreateVersion7();
        }
        public void UpdateName(string name)
        {
            EnforceNameBusinessRules(name);
            Name = name;
        }
        public void UpdateEmail(EmailValueObject email)
        {
            EnforceEmailBusinessRules(email);
            Email = email;
        }
        private static void EnforceNameBusinessRules(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} is required.");
            }
        }
        private static void EnforceEmailBusinessRules(EmailValueObject email)
        {
            if (email is null)
            {
                throw new BusinessRuleException($"The {nameof(email)} is required.");
            }
        }
    }
}
