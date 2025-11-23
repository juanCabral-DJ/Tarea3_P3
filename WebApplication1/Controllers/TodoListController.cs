using Microsoft.AspNetCore.Mvc;
using TodoList.API.DATA.Domain;
using TodoList.API.DATA.persistence.interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        public readonly ITodoList _todoList;

        public TodoListController(ITodoList todoList)
        {
            _todoList = todoList;
        }

        // GET: api/<TodoListController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _todoList.GetAllAsync();
            return Ok(items);
        }

        // GET api/<TodoListController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _todoList.GetByIdAsync(id);
            return Ok(item);
        }

        // POST api/<TodoListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TodoListController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TodoItem item)
        {
            
            if (id != item.Id)
            {
                return BadRequest("El ID no coincide con una tarea existente");
            }

            var existingTask = await _todoList.GetByIdAsync(id);

            if (existingTask == null)
            {
                return NotFound();
            }

            // Actualizar
            await _todoList.UpdateAsync(item);

            return NoContent();
        }

        // DELETE api/<TodoListController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var existingTask = await _todoList.GetByIdAsync(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            // Borrar
            await _todoList.DeleteAsync(id);

            return NoContent();
        }
    }
}
