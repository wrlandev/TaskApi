using TaskApi.DTOs;
using TaskApi.Models;

namespace TaskApi.Services.Interfaces
{
    public interface ITaskService
    {
        List<TaskModel> GetAll();
        TaskModel GetById(int id);
        TaskModel Create(TaskDto taskDto);
        TaskModel Update(int id, TaskDto taskDto);
        void Delete(int id);
    }
}
