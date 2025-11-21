using Microsoft.EntityFrameworkCore;

namespace TodoList.API.DATA.Context
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> Tareas { get; set; }
    }
}
