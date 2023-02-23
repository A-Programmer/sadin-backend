using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NetArchTest.Rules;
using Xunit;

namespace Website.ArchitectureTests;

public class PresentationArchitectureTests
{
    [Fact]
    public void Controllers_ShouldNotHaveDependencyOnInfrastructure()
    {
        // Arrange
        var assembly = typeof(Presentation.AssemblyReference).Assembly;

        // Act
        var controllersTestResult = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Controller")
            .ShouldNot()
            .HaveDependencyOn("Website.Infrastructure")
            .GetResult();

        // Asser
        controllersTestResult.IsSuccessful.Should().BeTrue();
    }
}