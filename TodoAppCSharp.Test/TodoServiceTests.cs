using AutoFixture;
using FluentAssertions;
using NSubstitute;
using TodoAppCSharp.Models;
using TodoAppCSharp.Repository;
using TodoAppCSharp.Services;

namespace TodoAppCSharp.Test;
public class TodoServiceTests
{
        private readonly Fixture _fixture = new();
        [Fact]
        public void Get_ShouldReturnTodo()
        {
            // Arrange
            var todoFixture = _fixture.Create<Todo>();
            var todoRepositoryMock = Substitute.For<ITodoRepository>();
            var id = Guid.NewGuid();
            todoRepositoryMock.Get(id).Returns(todoFixture);
            
            var sut = new TodoService(todoRepositoryMock);
            
            // Act
            var todo = sut.Get(id);

            // Assert
            todo.Should().BeEquivalentTo(todoFixture);
        }

        [Fact]
        public void GetAll_ShouldReturnTodos()
        {
            // Arrange
            var todoFixture = _fixture.Create<Todo[]>();
            var todoRepositoryMock = Substitute.For<ITodoRepository>();
            todoRepositoryMock.GetAll().Returns(todoFixture);
            
            var sut = new TodoService(todoRepositoryMock);

            // Act
            var todos = sut.GetAll();
            
            // Assert
            todos.Should().BeEquivalentTo(todoFixture);
        }

        [Fact]
        public void Add_ShouldAddTodo()
        {
            // Arrange
            var todoFixture = _fixture.Create<Todo>();
            var todoRepositoryMock = Substitute.For<ITodoRepository>();
            var sut = new TodoService(todoRepositoryMock);

            // Act
            sut.Add(todoFixture);
            
            // Assert
            todoRepositoryMock.Received(1).Add(todoFixture);
        }
        [Fact]
        public void Update_ShouldUpdateTodo()
        {

            // Arrange
            var todoFixture = _fixture.Create<Todo>();
            var todoRepositoryMock = Substitute.For<ITodoRepository>();
            var sut = new TodoService(todoRepositoryMock);
            var id = todoFixture.Id;
            
            // Act
            sut.Update(id, todoFixture);

            // Assert
            todoRepositoryMock.Received(1).Update(id, todoFixture);
        }
        [Fact]
        public void Delete_ShouldCallDelete()
        {
            // Arrange
            var todoRepositoryMock = Substitute.For<ITodoRepository>();
            var id = Guid.NewGuid();

            var sut = new TodoService(todoRepositoryMock);

            // Act
            sut.Delete(id);

            // Assert
            todoRepositoryMock.Received(1).Delete(id);
            
        }
}