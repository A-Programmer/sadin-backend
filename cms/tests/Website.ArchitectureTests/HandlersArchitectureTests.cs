using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Website.ArchitectureTests;

public class HandlersArchitectureTests
{
    [Fact]
    public void CommandHandlers_ShouldHaveNameEndingWithCommandHandler()
    {
        // Arrange
        var assembly = typeof(Application.AssemblyReference).Assembly;
        
        // Act
        var commandHandlersTestResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(Application.Common.Commands.ICommandHandler<,>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();

        // Assert
        commandHandlersTestResult.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void QueryHandlers_ShouldHaveNameEndingWithQueryHandler()
    {
        // Arrange
        var assembly = typeof(Application.AssemblyReference).Assembly;
        
        // Act
        var queryHandlersTestResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(Application.Common.Queries.IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        // Assert
        queryHandlersTestResult.IsSuccessful.Should().BeTrue();
    }
}