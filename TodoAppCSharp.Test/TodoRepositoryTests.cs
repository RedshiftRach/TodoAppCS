using AutoFixture;
using FluentAssertions;
using TodoAppCSharp.Models;
using TodoAppCSharp.Repository;

namespace TodoAppCSharp.Test;

public class TodoRepositoryTests
{
    private readonly Fixture _fixture = new();

        [Fact]
        public void Add_ShouldCallAdd()
        {
            // Arrange
            var todoFixture = _fixture.Create<Todo>();
            var dict = new Dictionary<Guid, Todo>();
            var sut = new TodoRepository(dict);

            // Act
            sut.Add(todoFixture);

            // Assert
            var todo = dict[todoFixture.Id];
            todo.Should().BeEquivalentTo(todoFixture);

        }

        [Fact]
        public void Get_ShouldReturnBook()
        {
            // Arrange
            var todoFixture = _fixture.Create<Todo>();
            var dict = new Dictionary<Guid, Todo>();
            var sut = new TodoRepository(dict);
            dict.Add(todoFixture.Id, todoFixture);

            // Act
            var todo = sut.Get(todoFixture.Id);

            // Assert
            todo.Should().BeEquivalentTo(todoFixture);
        }

        [Fact]
        public void GetAll_ShouldReturnBooks()
        {
            // Arrange
            var todoFixture = _fixture.Create<Todo[]>();
            var dict = new Dictionary<Guid, Todo>();
            var sut = new TodoRepository(dict);
            foreach (var todo in todoFixture)
            {

                dict.Add(todo.Id, todo);
            }

            // Act
           var todos = sut.GetAll();

            // Assert
            todos.Should().BeEquivalentTo(todoFixture);
        }

        [Fact]
        public void Update_ShouldUpdateBook()
        {
            // Arrange
            var todoFixture = _fixture.Create<Todo>();
            var dict = new Dictionary<Guid, Todo>
            {
                { todoFixture.Id, todoFixture }
            };
            var sut = new TodoRepository(dict);

            // Act 
            var newTodo = _fixture.Create<Todo>();
            sut.Update(todoFixture.Id, newTodo);

            // Assert 
            dict[todoFixture.Id].Should().BeEquivalentTo(newTodo);
        }
    

    [Fact]
        public void Delete_ShouldCallDelete()
        {
            // Arrange
            var todoFixture = _fixture.Create<Todo>();
            var dict = new Dictionary<Guid, Todo>
            {
                { todoFixture.Id, todoFixture }
            };
            var sut = new TodoRepository(dict);

            // Act
            sut.Delete(todoFixture.Id);

            // Assert
            var containsKey = dict.ContainsKey(todoFixture.Id);
            containsKey.Should().BeFalse();
        }
}