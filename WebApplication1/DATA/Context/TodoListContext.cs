using Microsoft.EntityFrameworkCore;
using TodoList.API.DATA.Domain;

namespace TodoList.API.DATA.Context
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
