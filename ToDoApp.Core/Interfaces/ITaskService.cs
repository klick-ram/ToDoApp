using ToDoApp.Core.Models;

namespace ToDoApp.Core.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskItem> GetTasks();
        TaskItem GetTaskById(int id);
        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(int id);
    }
}
