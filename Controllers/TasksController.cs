using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskApi.Data;
using TaskApi.DTOs;
using TaskApi.Models;
using TaskApi.Models.Errors;
using TaskApi.ModelViews;
using TaskApi.Services;

namespace TaskApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;
        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(200, _service.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] TaskDto taskDto)
        {
            return StatusCode(201, _service.Create(taskDto));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TaskDto taskDto)
        {
            return StatusCode(200, _service.Update(id, taskDto));
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return StatusCode(200, _service.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);

            return StatusCode(204);
        }
    }
}
