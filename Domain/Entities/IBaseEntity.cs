
namespace Domain.Entities
{
	public interface IBaseEntity
	{
		DateTime CreatedAt { get; set; }
		Guid Id { get; set; }
		bool IsDeleted { get; set; }
	}
}