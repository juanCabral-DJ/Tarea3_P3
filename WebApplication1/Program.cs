using Microsoft.EntityFrameworkCore;
using TodoList.API.DATA.Context;
using TodoList.API.DATA.persistence.interfaces;
using TodoList.API.DATA.persistence.repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("TodoList");

builder.Services.AddDbContext<TodoListContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ITodoList, TodoListRepositorie>();

var app = builder.Build();
 
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
