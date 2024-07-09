using Domain.Entities.Base;

namespace Domain.Entities;

public class User : BaseEntity
{
	public string Name { get; set; }

	public string Email { get; set; }

	public string Username { get; set; }
}
