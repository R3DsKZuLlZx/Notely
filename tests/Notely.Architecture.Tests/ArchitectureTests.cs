using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Notely.Architecture.Tests;

public class ArchitectureTests
{
    private const string InfrastructureNamespace = "Notely.Infrastructure";
    private const string WebNamespace = "Notely.Web";
    
    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Application.NotelyApplicationExtensions).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            WebNamespace,
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
