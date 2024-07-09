using ArchUnitNET.Domain.Extensions;
using Domain.Entities.Base;

namespace Solution.ArchitectureTestBase;

public class DomainAssemblyTests
{
	[Fact]
	public void All_Domain_Entities_Should_Drive_From_BaseEntity()
	{
		IArchRule ArchRule =
			Classes()
			.That()
			.ResideInNamespace(nameof(Domain.Entities))
			.Should()
			.ImplementInterface(typeof(BaseEntity));

		Infrastructure
			.Architecture
			.DomainAssemblyArchitecture
			.CheckRule(ArchRule);
	}

	[Fact]
	public void All_Domain_Entities_Should_Be_Public()
	{
		IArchRule ArchRule =
			Classes()
			.That()
			.ResideInNamespace(nameof(Domain.Entities))
			.Should()
			.BePublic();

		Infrastructure
			.Architecture
			.DomainAssemblyArchitecture
			.CheckRule(ArchRule);
	}

	/// <summary>
	/// This is a sample of ArchUnitNet Errors
	/// </summary>
	/// <Note>
	/// It's better to use typeof reserved word anywhere possible in ArchUnitNet rather than nameof
	/// </Note>
	[Fact]
	public void All_Entities_Should_Be_Abstract()
	{
		IArchRule ArchRule =
			Classes()
			.That()
			.ResideInNamespace(typeof(Domain.Entities.User).Namespace)
			.Should()
			.BeAbstract();

		Infrastructure
			.Architecture
			.DomainAssemblyArchitecture
			.CheckRule(ArchRule);
	}

	[Fact]
	public void All_Classes_Inside_Domain_Entities_Base_Should_Be_Public_And_Abstract()
	{
		IArchRule ArchRule =
			Classes()
			.That()
			.ResideInNamespace(typeof(Domain.Entities.Base.BaseEntity).Namespace)
			.Should()
			.BePublic()
			.AndShould()
			.BeAbstract();

		Infrastructure
			.Architecture
			.DomainAssemblyArchitecture
			.CheckRule(ArchRule);
	}

	[Fact]
	public void All_Interfaces_Inside_Domain_Entities_Base_Should_Be_Public()
	{
		IArchRule ArchRule =
			Interfaces()
			.That()
			.ResideInNamespace(typeof(Domain.Entities.Base.BaseEntity).Namespace)
			.Should()
			.BePublic();

		Infrastructure
			.Architecture
			.DomainAssemblyArchitecture
			.CheckRule(ArchRule);
	}
}
