using TodoList.API.DATA.Domain;

namespace TodoList.API.DATA.persistence.interfaces
{
    public interface ITodoList
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem?> GetByIdAsync(int id);
        Task AddAsync(TodoItem item);
        Task UpdateAsync(TodoItem item);
        Task DeleteAsync(int id);
    }
}
