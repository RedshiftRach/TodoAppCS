using Microsoft.AspNetCore.Mvc;

namespace TodoAppCSharp.Controllers;

public class TodoController : ControllerBase
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
}