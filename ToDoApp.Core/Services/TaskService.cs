using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IEnumerable<TaskItem> GetTasks()
        {
            return _taskRepository.GetAll();
        }

        public TaskItem GetTaskById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public void AddTask(TaskItem task)
        {
            _taskRepository.Add(task);
        }

        public void UpdateTask(TaskItem task)
        {
            _taskRepository.Update(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.Delete(id);
        }
    }
}
