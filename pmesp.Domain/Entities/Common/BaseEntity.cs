using System.ComponentModel.DataAnnotations;

namespace pmesp.Domain.Entities.Common;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }

    public BaseEntity(Guid id)
    {
        Id = id;
    }
}
