using FluentAssertions;
using NetArchTest.Rules;

namespace Website.ArchitectureTests;

[TestClass]
public class ArchitectureTests
{
    private const string RootNamespace = "Website";
    private const string CommonNamespace = $"{RootNamespace}.Common";
    private const string DomainNamespace = $"{RootNamespace}.Domain";
    private const string ApplicationNamespace = $"{RootNamespace}.Application";
    private const string InfrastructureNamespace = $"{RootNamespace}.Infrastructure";
    private const string ServicesNamespace = $"{RootNamespace}.Services";
    private const string PresentationNamespace = $"{RootNamespace}.Presentation";
    private const string ApiNamespace = $"{RootNamespace}.Api";

    [TestMethod]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Website.Domain.AssemblyReference).Assembly;
        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            ServicesNamespace,
            PresentationNamespace,
            ApiNamespace
        };
        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    
    [TestMethod]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Website.Application.AssemblyReference).Assembly;
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PresentationNamespace,
            ServicesNamespace,
            ApiNamespace
        };
        
        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        
        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    
    [TestMethod]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Website.Infrastructure.AssemblyReference).Assembly;
        var otherProjects = new[]
        {
            ApplicationNamespace,
            ServicesNamespace,
            PresentationNamespace,
            ApiNamespace
        };
        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    
    [TestMethod]
    public void Services_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Website.Services.AssemblyReference).Assembly;
        var otherProjects = new[]
        {
            DomainNamespace,
            ApplicationNamespace,
            PresentationNamespace,
            ApiNamespace,
            InfrastructureNamespace,
            PresentationNamespace
        };
        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    
    [TestMethod]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Presentation.AssemblyReference).Assembly;
        var otherProjects = new[]
        {
            DomainNamespace,
            InfrastructureNamespace,
            ApiNamespace
        };
        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
}