using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Website.ArchitectureTests;

public class CommandArchitectureTests
{
    [Fact]
    public void Command_ShouldHaveNameEndingWithCommand()
    {
        // Arrange
        var assembly = typeof(Application.AssemblyReference).Assembly;
        
        // Act
        var commandTestResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(Application.Common.Commands.ICommand<>))
            .Should()
            .HaveNameEndingWith("Command")
            .GetResult();

        // Assert
        commandTestResult.IsSuccessful.Should().BeTrue();
    }
}