using Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Solution.ArchitectureTest;

public class ProjectDependencyTests
{
	private readonly Architecture Architecture = null;
	public readonly IObjectProvider<Class> DomainEntities =null;

    public ProjectDependencyTests()
	{
		Architecture = new ArchLoader()
			.LoadAssemblies(
				System.Reflection.Assembly.Load(nameof(Web)),
				System.Reflection.Assembly.Load(nameof(Domain)),
				System.Reflection.Assembly.Load(nameof(Application)),
				System.Reflection.Assembly.Load(nameof(Infrastructure))
			).Build();
	}

	[Fact]
	public void All_Entities_Should_Drive_From_BaseEntity()
	{
		IArchRule ArchRule =
			Classes()
			.That()
			.ResideInNamespace(nameof(Domain.Entities))
			.Should()
			.ImplementInterface(typeof(IBaseEntity));

		ArchRule.Check(Architecture);
	}

	[Fact]
	public void All_Entities_Should_Be_Public()
	{
		IArchRule ArchRule =
			Classes()
			.That()
			.ResideInNamespace(nameof(Domain.Entities))
			.Should()
			.BePublic()
			.AndShould()
			.NotBeAbstract();

		ArchRule.Check(Architecture);
	}
}
