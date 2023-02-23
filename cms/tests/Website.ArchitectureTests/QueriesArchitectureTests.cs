using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Website.ArchitectureTests;

public class QueriesArchitectureTests
{
    [Fact]
    public void Query_ShouldHaveNameEndingWithQuery()
    {
        // Arrange
        var assembly = typeof(Application.AssemblyReference).Assembly;
        
        // Act
        var commandTestResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(Application.Common.Queries.IQuery<>))
            .Should()
            .HaveNameEndingWith("Query")
            .GetResult();

        // Assert
        commandTestResult.IsSuccessful.Should().BeTrue();
    }
}