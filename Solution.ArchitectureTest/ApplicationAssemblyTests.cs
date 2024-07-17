namespace Solution.ArchitectureTest;

public class ApplicationAssemblyTests
{
	[Fact]
	public void Application_Layer_Should_Not_Be_Depended_On_Infrastructure_Layer()
	{
		IArchRule ArchRule =
			Types()
			.That()
			.Are(Infrastructure.Architecture.ApplicationLayer)
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
	public void Application_Layer_Should_Not_Be_Depended_On_Web_Layer()
	{
		IArchRule ArchRule =
			Types()
			.That()
			.Are(Infrastructure.Architecture.ApplicationLayer)
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

	[Fact]
	public void All_Interfaces_In_Namespace_Application_Common_Interfaces_Should_Be_Public()
	{
		IArchRule ArchRule =
			Interfaces()
			.That()
			.ResideInNamespace(typeof(Application.Common.Interfaces.IUser).Namespace)
			.Should()
			.BePublic()
			;

		Infrastructure
			.Architecture
			.EntireSolutionArchitecture
			.CheckRule(ArchRule)
			;
	}

	[Fact]
	public void Namespace_Application_Common_Interfaces_Should_Not_Include_Classes()
	{
		int classCount =
			Classes()
			.That()
			.ResideInNamespace(typeof(Application.Common.Interfaces.IUser).Namespace)
			.GetObjects(Infrastructure.Architecture.ApplicationAssemblyArchitecture)
			.ToList()
			.Count
			;

		Assert.Equal(0, classCount);
	}
}
