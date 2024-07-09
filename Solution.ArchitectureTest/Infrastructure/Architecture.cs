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
}
