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
			.BePublic();

		ArchRule.Check(Architecture);
	}

	/// <summary>
	/// This is a sample of ArchUnitNet Errors
	/// </summary>
	/// <Note>
	/// It's better to use typeof reserved word anywhere possible in ArchUnitNet rather than nameof
	/// </Note>
	[Fact]
	public void All_Entities_Should_Be_Public_And_Should_Not_Be_Abstract()
	{
		IArchRule ArchRule =
			Classes()
			.That()
			.ResideInNamespace(typeof(Domain.Entities.User).Namespace)
			.Should()
			.BePublic()
			.AndShould()
			.NotBeAbstract();

		ArchRule.Check(Architecture);
	}
}
