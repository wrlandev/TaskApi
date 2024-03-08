using Microsoft.AspNetCore.Mvc;
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
            if(string.IsNullOrEmpty(task.Title))
            {
                return StatusCode(400, new ErrorView { Message = "Title Is Required" });
            }

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return StatusCode(201, task);
        }
    }
}
