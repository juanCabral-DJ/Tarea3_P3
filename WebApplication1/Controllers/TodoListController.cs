using Microsoft.AspNetCore.Mvc;
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
