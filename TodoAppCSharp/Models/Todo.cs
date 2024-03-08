using System.Diagnostics.CodeAnalysis;

namespace TodoAppCSharp.Models;

[ExcludeFromCodeCoverage]

public class Todo
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime DateOfPublication { get; set; }
}