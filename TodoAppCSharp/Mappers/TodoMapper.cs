using TodoAppCSharp.Contracts;
using TodoAppCSharp.Models;

namespace TodoAppCSharp.Mappers;

    public interface ITodoMapper
    {

        public Todo Map (TodoRequest request);

    }
    public class TodoMapper : ITodoMapper
    {
        public Todo Map(TodoRequest request)
        {
            var todo = new Todo
            {
                Title = request.Title,
                Content = request.Content,
                Author = request.Author,
                DateOfPublication = request.DateOfPublication
            };
            return todo;
        }
    }