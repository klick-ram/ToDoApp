using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using ToDoApp.Core.Services;
using ToDoApp.Infrastructure.Repositories;

namespace ToDoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Setup Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddScoped<ITaskService, TaskService>()
                .AddScoped<ITaskRepository, MockTaskRepository>()
                .BuildServiceProvider();

            // Get the TaskService from DI
            var taskService = serviceProvider.GetService<ITaskService>();

            // Example usage
            var task1 = new TaskItem { Id = 1, Name = "To do Task 1", IsCompleted = false };
            taskService.AddTask(task1);
            var task2 = new TaskItem { Id = 2, Name = "To do Task 2", IsCompleted = true };
            taskService.AddTask(task2);

            var tasks = taskService.GetTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task: {task.Name}, Completed: {task.IsCompleted}");
            }
        }
    }
}
