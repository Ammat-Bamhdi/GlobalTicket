namespace GloboTicket.Domain.Common;

/// <summary>
/// Represents an entity that tracks its creation and modification history.
/// </summary>
public class AuditableEntity
{
    /// <summary>
    /// The user or system that created the entity.
    /// </summary>
    public string? CreatedBy { get; set; } 

    /// <summary>
    /// The date and time the entity was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// The user or system that last modified the entity.
    /// </summary>
    public string? LastModifiedBy { get; set; }

    /// <summary>
    /// The date and time the entity was last modified.
    /// </summary>
    public DateTime? LastModifiedDate { get; set; }
}