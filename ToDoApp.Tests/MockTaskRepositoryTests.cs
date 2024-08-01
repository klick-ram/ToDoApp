using ToDoApp.Core.Models;
using ToDoApp.Infrastructure.Repositories;

namespace ToDoApp.Tests
{
    public class MockTaskRepositoryTests
    {
        private readonly MockTaskRepository _mockTaskRepository;

        public MockTaskRepositoryTests()
        {
            _mockTaskRepository = new MockTaskRepository();
        }

        [Fact]
        public void Add_ShouldAddTask()
        {
            // Arrange
            var task = new TaskItem { Id = 1, Name = "Test Task", IsCompleted = false };

            // Act
            _mockTaskRepository.Add(task);

            // Assert
            var result = _mockTaskRepository.GetAll();
            Assert.Single(result);
        }

        [Fact]
        public void GetAll_ShouldReturnAllTasks()
        {
            // Arrange
            var task1 = new TaskItem { Id = 1, Name = "Task 1", IsCompleted = false };
            var task2 = new TaskItem { Id = 2, Name = "Task 2", IsCompleted = true };
            _mockTaskRepository.Add(task1);
            _mockTaskRepository.Add(task2);

            // Act
            var result = _mockTaskRepository.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Delete_ShouldRemoveTask()
        {
            // Arrange
            var task = new TaskItem { Id = 1, Name = "Test Task", IsCompleted = false };
            _mockTaskRepository.Add(task);

            // Act
            _mockTaskRepository.Delete(task.Id);

            // Assert
            var result = _mockTaskRepository.GetAll();
            Assert.Empty(result);
        }

        // Add more tests for GetById, Update, etc.
    }

}
