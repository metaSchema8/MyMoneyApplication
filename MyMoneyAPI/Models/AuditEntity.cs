namespace MyMoneyAPI.Models
{
    public abstract class AuditEntity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTimeOffset CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        // Nullable to handle records that haven't been modified yet
        public DateTimeOffset? ModifiedDate { get; set; }  
        public bool IsActive { get; set; }
    }
}
