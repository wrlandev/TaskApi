using Microsoft.AspNetCore.Mvc;
using TaskApi.Data;

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
    }
}
