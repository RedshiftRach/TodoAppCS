using System.Diagnostics.CodeAnalysis;

namespace TodoAppCSharp.Models;

[ExcludeFromCodeCoverage]

public class Todo
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateOnly DateOfTodo { get; set; }
}