using TodoAppCSharp.Models;
using TodoAppCSharp.Repository;

namespace TodoAppCSharp.Services;

    public interface ITodoService
    {
        public void Add(Todo todo);
        public void Delete(Guid Id);
        public Todo? Get(Guid Id);
        public Todo[] GetAll();
        public void Update(Guid Id, Todo todo);
    }
    public class TodoService(ITodoRepository todoRepository) : ITodoService
    {
        public void Add(Todo todo)
        {
            todo.Id = Guid.NewGuid();
            todoRepository.Add(todo);
        }
        public void Delete(Guid Id)
        {
            todoRepository.Delete(Id);
        }
        public Todo? Get(Guid Id)
        {
            var todo = todoRepository.Get(Id);
            return todo;
        }
        public Todo[] GetAll()
        {
            return todoRepository.GetAll();
        }

        public void Update(Guid Id, Todo todo)
        {
            todo.Id = Id;
            todoRepository.Update(Id, todo);
        }
    }
    