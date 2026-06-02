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
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} is required.");
            }
            if (email is null)
            {
                throw new BusinessRuleException($"The {nameof(email)} is required.");
            }
            Name = name;
            Email = email;
            Id = Guid.CreateVersion7();
        }
    }
}
