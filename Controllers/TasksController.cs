using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.ModelViews;

namespace TaskApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(200, _context.Tasks.ToList());
        }

        [HttpPost]
        public IActionResult Create([FromBody] TaskModel task)
        {
            if (string.IsNullOrEmpty(task.Title))
            {
                return StatusCode(400, new ErrorView { Message = "Title Is Required" });
            }

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return StatusCode(201, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TaskModel task)
        {
            if (string.IsNullOrEmpty(task.Title))
            {
                return StatusCode(400, new ErrorView { Message = "Title Is Required" });
            }

            var taskDb = _context.Tasks.Find(id);

            if (taskDb == null)
            {
                return StatusCode(404, new ErrorView { Message = $"Id ({id}) not found" });
            }

            taskDb.Title = task.Title;
            taskDb.Description = task.Description;
            taskDb.Completed = task.Completed;

            _context.Tasks.Update(taskDb);
            _context.SaveChanges();

            return StatusCode(200, task);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var taskDb = _context.Tasks.Find(id);

            if (taskDb == null)
            {
                return StatusCode(404, new ErrorView { Message = $"Id ({id}) not found" });
            }

            return StatusCode(200, taskDb);
        }
    }
}
