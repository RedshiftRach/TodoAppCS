using TodoAppCSharp.Mappers;
using TodoAppCSharp.Models;
using TodoAppCSharp.Repository;
using TodoAppCSharp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dictionary = new Dictionary<Guid, Todo>();
var tr = new TodoRepository(dictionary);
var todo = new Todo
{
    Author = "Satoshi Nakamoto", Content = "How does Bitcoin compare to other cryptocurrencies?",
    DateOfPublication = new DateTime(2009, 07, 23), Title = "Bitcoin and other cryptocurrencies"
};
dictionary.Add(todo.Id, todo);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<ITodoRepository>(tr);
builder.Services.AddSingleton<ITodoService, TodoService>();
builder.Services.AddSingleton<ITodoMapper, TodoMapper>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();