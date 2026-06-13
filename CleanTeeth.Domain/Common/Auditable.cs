namespace CleanTeeth.Domain.Common
{
    public class Auditable
    {
        public string? CreatedBy { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
