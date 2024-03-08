using TaskApi.Data;
using TaskApi.DTOs;
using TaskApi.Models;
using TaskApi.Models.Errors;
using TaskApi.ModelViews;

namespace TaskApi.Services
{
    public class TaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public List<TaskModel> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public TaskModel Create(TaskDto taskDto)
        {
            if (string.IsNullOrEmpty(taskDto.Title))
            {
                throw new TaskError("Title is required");
            }

            var task = new TaskModel
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                Completed = taskDto.Completed

            };

            _context.Tasks.Add(task);

            _context.SaveChanges();

            return task;
        }

        public TaskModel Update(int id, TaskDto taskDto)
        {
            var taskDb = _context.Tasks.Find(id);

            if(taskDb == null)
            {
                throw new TaskError("Task not found");
            }

            if (string.IsNullOrEmpty(taskDto.Title))
            {
                throw new TaskError("Title is required");
            }

            taskDb.Title = taskDto.Title;
            taskDb.Description = taskDto.Description;
            taskDb.Completed = taskDto.Completed;

            _context.Tasks.Update(taskDb);

            _context.SaveChanges();

            return taskDb;
        }

        public TaskModel GetById(int id)
        {
            var taskDb = _context.Tasks.Find(id);

            if (taskDb == null)
            {
                throw new TaskError("Task not found");
            }

            return taskDb;
        }

        public void Delete(int id)
        {
            var taskDb = _context.Tasks.Find(id);

            if (taskDb == null)
            {
                throw new TaskError("Task not found");
            }

            _context.Tasks.Remove(taskDb);
            _context.SaveChanges();
        }
    }
}
