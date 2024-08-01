using Moq;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using ToDoApp.Core.Services;

namespace ToDoApp.Tests
{
    public class TaskServiceTests
    {
        private readonly TaskService _taskService;
        private readonly Mock<ITaskRepository> _mockTaskRepository;

        public TaskServiceTests()
        {
            _mockTaskRepository = new Mock<ITaskRepository>();
            _taskService = new TaskService(_mockTaskRepository.Object);
        }

        [Fact]
        public void GetTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var tasks = new List<TaskItem>
            {
                new TaskItem { Id = 1, Name = "Task 1", IsCompleted = false },
                new TaskItem { Id = 2, Name = "Task 2", IsCompleted = true }
            };
            _mockTaskRepository.Setup(repo => repo.GetAll()).Returns(tasks);

            // Act
            var result = _taskService.GetTasks();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void AddTask_ShouldCallRepositoryAdd()
        {
            // Arrange
            var newTask = new TaskItem { Id = 1, Name = "New Task", IsCompleted = false };

            // Act
            _taskService.AddTask(newTask);

            // Assert
            _mockTaskRepository.Verify(repo => repo.Add(newTask), Times.Once);
        }
        
        [Fact]
        public void UpdateTask_ShouldCallRepositoryUpdate()
        {
            // Arrange
            var updatedTask = new TaskItem { Id = 1, Name = "Updated Task", IsCompleted = true };

            // Act
            _taskService.UpdateTask(updatedTask);

            // Assert
            _mockTaskRepository.Verify(repo => repo.Update(updatedTask), Times.Once);
        }

        [Fact]
        public void DeleteTask_ShouldCallRepositoryDelete()
        {
            // Arrange
            var taskId = 1;

            // Act
            _taskService.DeleteTask(taskId);

            // Assert
            _mockTaskRepository.Verify(repo => repo.Delete(taskId), Times.Once);
        }

    }
}
