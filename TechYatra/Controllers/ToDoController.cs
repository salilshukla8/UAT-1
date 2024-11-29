using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechYatra.Interface;
using TechYatra.Model;
using TechYatra.Service;

namespace TechYatra.Controllers
{
    [Route("api/todo")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<ToDo>> GetAllTasks()
        {
            var tasks = _service.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<ToDo> GetTask(int id) 
        { 
            var task = _service.GetTask(id);
            if(task is null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost("AddTask")]
        public ActionResult<ToDo> AddWork(ToDo task) 
        {
            var work = _service.AddTask(task);
            return CreatedAtAction(nameof(GetTask), new {id=work.Id},work);
        }

        [HttpPut("{id}")]
        public ActionResult PutTask(ToDo task)
        {
            try
            {
                _service.UpdateTask(task);
            }

            catch (DbUpdateConcurrencyException ex)
            {
                if (!_service.IsExists(task.Id))
                {
                    return NotFound();
                }

                else
                {
                    throw;
                }

            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        { 
            bool result=_service.DeleteTask(id);
            if(result is true)
            {
                return NoContent() ;
            }
            return BadRequest("Requeted Id cannot be found");
        }
    }
}
