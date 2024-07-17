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
			.ImplementInterface(typeof(BaseEntity))
			;

		Infrastructure
			.Architecture
			.DomainAssemblyArchitecture
			.CheckRule(ArchRule)
			;
	}

	[Fact]
	public void All_Domain_Entities_Should_Be_Public()
	{
		IArchRule ArchRule =
			Classes()
			.That()
			.ResideInNamespace(nameof(Domain.Entities))
			.Should()
			.BePublic()
			;

		Infrastructure
			.Architecture
			.DomainAssemblyArchitecture
			.CheckRule(ArchRule)
			;
	}

	/// <summary>
	/// This is a sample of ArchUnitNet Errors
	/// </summary>
	/// <Note>
	/// It's better to use typeof reserved word anywhere possible in ArchUnitNet rather than nameof
	/// </Note>
	//[Fact]
	//public void All_Entities_Should_Be_Abstract()
	//{
	//	IArchRule ArchRule =
	//		Classes()
	//		.That()
	//		.ResideInNamespace(typeof(Domain.Entities.User).Namespace)
	//		.Should()
	//		.BeAbstract()
	//		;

	//	Infrastructure
	//		.Architecture
	//		.DomainAssemblyArchitecture
	//		.CheckRule(ArchRule)
	//		;
	//}

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
			.BeAbstract()
			;

		Infrastructure
			.Architecture
			.DomainAssemblyArchitecture
			.CheckRule(ArchRule)
			;
	}

	[Fact]
	public void All_Interfaces_Inside_Domain_Entities_Base_Should_Be_Public()
	{
		IArchRule ArchRule =
			Interfaces()
			.That()
			.ResideInNamespace(typeof(Domain.Entities.Base.BaseEntity).Namespace)
			.Should()
			.BePublic()
			;

		Infrastructure
			.Architecture
			.DomainAssemblyArchitecture
			.CheckRule(ArchRule)
			;
	}

	[Fact]
	public void Domain_Layer_Should_Not_Be_Depended_On_Infrastructure_Layer()
	{
		IArchRule ArchRule =
			Types()
			.That()
			.Are(Infrastructure.Architecture.DomainLayer)
			.Should()
			.NotDependOnAnyTypesThat()
			.Are(Infrastructure.Architecture.InfrastructureLayer)
			;

		Infrastructure
			.Architecture
			.EntireSolutionArchitecture
			.CheckRule(ArchRule)
			;
	}

	[Fact]
	public void Domain_Layer_Should_Not_Be_Depended_On_Application_Layer()
	{
		IArchRule ArchRule =
			Types()
			.That()
			.Are(Infrastructure.Architecture.DomainLayer)
			.Should()
			.NotDependOnAnyTypesThat()
			.Are(Infrastructure.Architecture.ApplicationLayer)
			;

		Infrastructure
			.Architecture
			.EntireSolutionArchitecture
			.CheckRule(ArchRule)
			;
	}

	[Fact]
	public void Domain_Layer_Should_Not_Be_Depended_On_Web_Layer()
	{
		IArchRule ArchRule =
			Types()
			.That()
			.Are(Infrastructure.Architecture.DomainLayer)
			.Should()
			.NotDependOnAnyTypesThat()
			.Are(Infrastructure.Architecture.WebLayer)
			;

		Infrastructure
			.Architecture
			.EntireSolutionArchitecture
			.CheckRule(ArchRule)
			;
	}

	/// <summary>
	/// Sample of complext rule. But it's not recommended. It's better to have clear and simple tests.
	/// </summary>
	[Fact]
	public void Domain_Layer_Should_Not_Be_Depended_On_Any_Layer()
	{
		IArchRule ArchRule =
			Types()
			.That()
			.Are(Infrastructure.Architecture.DomainLayer)
			.Should()
			.NotDependOnAnyTypesThat()
			.Are(Infrastructure.Architecture.WebLayer)
			.AndShould()
			.NotDependOnAnyTypesThat()
			.Are(Infrastructure.Architecture.ApplicationLayer)
			.AndShould()
			.NotDependOnAnyTypesThat()
			.Are(Infrastructure.Architecture.InfrastructureLayer)
			;

		Infrastructure
			.Architecture
			.EntireSolutionArchitecture
			.CheckRule(ArchRule)
			;
	}

	/// <summary>
	/// Another sample of complext rule. But it's not recommended. It's better to have clear and simple tests.
	/// </summary>
	[Fact]
	public void Domain_Layer_Should_Not_Be_Depended_On_Any_Layer_2()
	{
		IArchRule ArchRule1 =
			Types()
			.That()
			.Are(Infrastructure.Architecture.DomainLayer)
			.Should()
			.NotDependOnAnyTypesThat()
			.Are(Infrastructure.Architecture.WebLayer)
			;

		IArchRule ArchRule2 =
			Types()
			.That()
			.Are(Infrastructure.Architecture.DomainLayer)
			.Should()
			.NotDependOnAnyTypesThat()
			.Are(Infrastructure.Architecture.ApplicationLayer)
			;

		IArchRule ArchRule3 =
			Types()
			.That()
			.Are(Infrastructure.Architecture.DomainLayer)
			.Should()
			.NotDependOnAnyTypesThat()
			.Are(Infrastructure.Architecture.InfrastructureLayer)
			;

		IArchRule combinedArchRule =
			ArchRule1
			.And(ArchRule2)
			.And(ArchRule3)
			;

		Infrastructure
			.Architecture
			.EntireSolutionArchitecture
			.CheckRule(combinedArchRule)
			;
	}
}
