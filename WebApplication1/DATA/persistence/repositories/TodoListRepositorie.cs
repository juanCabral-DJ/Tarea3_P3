using Microsoft.EntityFrameworkCore;
using TodoList.API.DATA.Context;
using TodoList.API.DATA.Domain;
using TodoList.API.DATA.persistence.interfaces;

namespace TodoList.API.DATA.persistence.repositories
{
    public class TodoListRepositorie : ITodoList
    {
        private readonly TodoListContext _context;

        public TodoListRepositorie(TodoListContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TodoItem item)
        {
              _context.TodoItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);

            if (item != null)
            {
                _context.TodoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
        {
             return await _context.TodoItems.FindAsync(id);
        }

        public async Task UpdateAsync(TodoItem item)
        {
            _context.TodoItems.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
