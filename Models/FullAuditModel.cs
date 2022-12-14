public abstract class FullAuditModel : IIdentityModel, IAuditColumns
{
    public int Id { get; set; }
    public string? CreatedByUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
