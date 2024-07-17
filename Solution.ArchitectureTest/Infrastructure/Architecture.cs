using Microsoft.AspNetCore.Components.Web;

namespace Infrastructure;

public static class Architecture
{
    public static ArchUnitNET.Domain.Architecture EntireSolutionArchitecture = new ArchLoader()
            .LoadAssemblies(
                System.Reflection.Assembly.Load(nameof(Web)),
                System.Reflection.Assembly.Load(nameof(Domain)),
                System.Reflection.Assembly.Load(nameof(Application)),
                System.Reflection.Assembly.Load(nameof(Infrastructure))
            ).Build();

	public static ArchUnitNET.Domain.Architecture WebAssemblyArchitecture = new ArchLoader()
            .LoadAssemblies(
                System.Reflection.Assembly.Load(nameof(Web))
            ).Build();

	public static ArchUnitNET.Domain.Architecture DomainAssemblyArchitecture = new ArchLoader()
            .LoadAssemblies(
                System.Reflection.Assembly.Load(nameof(Domain))
            ).Build();

	public static ArchUnitNET.Domain.Architecture ApplicationAssemblyArchitecture = new ArchLoader()
            .LoadAssemblies(
                System.Reflection.Assembly.Load(nameof(Application))
            ).Build();

	public static ArchUnitNET.Domain.Architecture InfrastructureAssemblyArchitecture = new ArchLoader()
            .LoadAssemblies(
                System.Reflection.Assembly.Load(nameof(Infrastructure))
            ).Build();

	public static IObjectProvider<IType> WebLayer = Types()
			.That()
			.ResideInAssembly(typeof(Web.Controllers.WeatherForecastController).Assembly)
			.As("Web Layer");

	public static IObjectProvider<IType> DomainLayer = Types()
			.That()
			.ResideInAssembly(typeof(Domain.Entities.Base.BaseEntity).Assembly)
			.As("Domain Layer");

	public static IObjectProvider<IType> ApplicationLayer = Types()
			.That()
			.ResideInAssembly(typeof(Application.Common.Interfaces.IUser).Assembly)
			.As("Application Layer");

	public static IObjectProvider<IType> InfrastructureLayer = Types()
			.That()
			.ResideInAssembly(typeof(Infrastructure.Data.Configurations.UserConfiguration).Assembly)
			.As("Infrastructure Layer");
}
