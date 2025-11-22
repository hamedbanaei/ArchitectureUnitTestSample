using ArchUnitNET.Fluent.Syntax.Elements;

namespace Solution.ArchitectureTest;

public class SolutionGlobalRuleTests
{
    [Fact]
    public void All_Async_Methods_Names_Should_End_With_Async_Word()
    {
        IArchRule ArchRule =
            MethodMembers()
            .That()
            .HaveReturnType(typeof(Task<>))
            .Should()
            .HaveNameContaining("Async(")
            ;
        
        Infrastructure
            .Architecture
            .EntireSolutionArchitecture
            .CheckRule(ArchRule)
            ;
    }
}
