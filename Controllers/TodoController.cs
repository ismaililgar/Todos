using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Data.Abstract;
using ShoppingApi.DataAccess;
using ShoppingApi.Models;
using System.Linq;
using Todos.Repository.Abstract;

namespace ShoppingApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<TodoController> _logger;
        public TodoController(IUnitOfWork uow, ILogger<TodoController> logger)
        {
            _logger = logger;
            _uow = uow;
        }

        [HttpGet]
        [Route("todos")]
        public IEnumerable<TodoItem> GetTodos()
        {
            var result = _uow.todorep.GetAll();
            _logger.LogInformation($"Controller executed on: {DateTime.Now.TimeOfDay}");
            _logger.LogInformation($"Executed items: {result.Count()}");
            
            return result;




        }

        [HttpGet]
        [Route("todo/{id}")]
        public IActionResult GetTodoItemById(long id)
        {
            var item = _uow.todorep.GetById(id);
            if (item == null)
            {
                return BadRequest("Aradığınız id'de bir item yok.");
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpPost]
        [Route("todos")]
        public void AddTodo(TodoItem item)
        {
            _uow.todorep.Add(item);
            _uow.SaveAsync();

        }

    }
}
