namespace Domain.Entities.Base;

public interface IBaseEntity
{
    DateTime CreatedAt { get; set; }
    Guid Id { get; set; }
    bool IsDeleted { get; set; }
}