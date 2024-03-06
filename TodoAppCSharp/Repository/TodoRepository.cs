using TodoAppCSharp.Models;
namespace TodoAppCSharp.Repository;

    public interface ITodoRepository
    {
        public void Add(Todo todo);
        public Todo? Get(Guid Id);
        public Todo[] GetAll();
        public void Update(Guid Id, Todo todo);
        public void Delete(Guid Id);
    }
    public class TodoRepository : ITodoRepository

    {
        public TodoRepository(Dictionary<Guid, Todo> repository)
        {
            _repository = repository;
        }

        private readonly Dictionary<Guid, Todo> _repository;

        public void Add(Todo todo)
        {

            _repository.Add(todo.Id, todo);

        }

        public void Delete(Guid Id)
        {
            if (_repository.ContainsKey(Id))
            {
                _repository.Remove(Id);
            }
        }

        public Todo? Get(Guid Id)
        {
            return _repository.TryGetValue(Id, out var todo) ? todo : null;
        }

        public Todo[] GetAll()
        {
            return _repository.Values.ToArray();
        }

        public void Update(Guid Id, Todo todo)

        {
            if (_repository.ContainsKey(Id))
            {
                _repository[Id] = todo;
            }
            
        }
    }