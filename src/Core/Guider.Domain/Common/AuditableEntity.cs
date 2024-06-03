namespace Guider.Domain.Common
{
    internal class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
