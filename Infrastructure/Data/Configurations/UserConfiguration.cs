using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.Property(t => t.Name)
			.IsRequired()
			.IsUnicode(true)
			.HasMaxLength(200);

		builder.Property(t => t.Username)
			.IsRequired()
			.IsUnicode(false)
			.HasMaxLength(200);
	}
}

