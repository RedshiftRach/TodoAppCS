using AutoFixture;
using FluentAssertions;
using TodoAppCSharp.Contracts;
using TodoAppCSharp.Mappers;

namespace TodoAppCSharp.Test;

public class TodoMapperTests
{
    private readonly Fixture _fixture = new();
    [Fact]
    public void Map_MapsPropertiesFromTodoRequest()
    {
        // Arrange
        var todoRequest = _fixture.Create<TodoRequest>(); 
        var sut = new TodoMapper();

        // Act
        var todo = sut.Map(todoRequest);

        // Assert
        todo.Title.Should().Be(todoRequest.Title);
        todo.Author.Should().Be(todoRequest.Author);
        todo.DateOfPublication.Should().Be(todoRequest.DateOfPublication);
    }
}