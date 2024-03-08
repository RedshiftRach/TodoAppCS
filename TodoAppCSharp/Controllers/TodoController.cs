using Microsoft.AspNetCore.Mvc;
using TodoAppCSharp.Contracts;
using TodoAppCSharp.Mappers;
using TodoAppCSharp.Services;

namespace TodoAppCSharp.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class TodoController(ILogger<TodoController> logger, ITodoService todoService, ITodoMapper todoMapper)
    : ControllerBase
{
    // GET
    private readonly ILogger<TodoController> _logger = logger;

    [HttpGet]
        public IActionResult GetAll()
        {
            // Do something

            var todos = todoService.GetAll();

            return Ok(todos);

        }
        [HttpGet("{Id}")]
        public IActionResult GetById(Guid Id)
        {
            // Do something
       
            var todo= todoService.Get(Id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoRequest todoRequest)
        {
            // Do something

            //if (DateTime.GreaterThan(todo.DateOfPublication, DateTime.Now))
            var todo = todoMapper.Map(todoRequest);

            if (todo.Author != string.Empty )
            {
                todoService.Add(todo);
            } 
            return Ok(todo);
        }
        [HttpPut("{Id}")]
        public IActionResult Put(Guid Id, [FromBody] TodoRequest todoRequest)
        {

            // Do something
      
            //if (DateTime.GreaterThan(todo.DateOfPublication, DateTime.Now))

            var todo = todoMapper.Map(todoRequest);

            if (todo.Author != string.Empty) 
            {
                todoService.Update(Id, todo);
            } 
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            // Do something
            todoService.Delete(Id);
            return Ok();
        }
}