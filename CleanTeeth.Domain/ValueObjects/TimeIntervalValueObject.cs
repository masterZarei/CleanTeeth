using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.ValueObjects
{
    public record TimeIntervalValueObject
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        public TimeIntervalValueObject(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new BusinessRuleException("The start time must be before the end time.");
            }
            if (start < DateTime.UtcNow.AddSeconds(-10))
            {
                throw new BusinessRuleException("The start time cannot be in the past");
            }
            Start = start;
            End = end;
        }
    }
}
