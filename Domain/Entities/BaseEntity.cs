namespace Domain.Entities;

public abstract class BaseEntity : IBaseEntity
{
	public BaseEntity()
	{
		IsDeleted = false;
		Id = Guid.NewGuid();
		CreatedAt = DateTime.Now;
	}

	public Guid Id { get; set; }

	public System.DateTime CreatedAt { get; set; }

	public bool IsDeleted { get; set; }
}
