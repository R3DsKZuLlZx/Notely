using Notely.Application.Common.Cqrs;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Notely.Architecture.Tests;

public class QueryTests
{
    [Fact]
    public void Queries_Should_BeNamedQuery()
    {
        // Arrange
        var assembly = typeof(Application.NotelyApplicationExtensions).Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .Inherit(typeof(Query))
            .Or()
            .Inherit(typeof(Query<>))
            .Should()
            .HaveNameEndingWith("Query")
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Queries_Should_InheritQuery()
    {
        // Arrange
        var assembly = typeof(Application.NotelyApplicationExtensions).Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Query")
            .And()
            .DoNotHaveName("Query")
            .Should()
            .Inherit(typeof(Query))
            .Or()
            .Inherit(typeof(Query<>))
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
}
