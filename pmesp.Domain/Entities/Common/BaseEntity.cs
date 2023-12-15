using System.ComponentModel.DataAnnotations;

namespace pmesp.Domain.Entities.Common;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; protected set; }
}
