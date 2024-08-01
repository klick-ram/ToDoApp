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
        public void GetById_ShouldReturnCorrectTask()
        {
            // Arrange
            var task1 = new TaskItem { Id = 1, Name = "Task 1", IsCompleted = false };
            var task2 = new TaskItem { Id = 2, Name = "Task 2", IsCompleted = true };
            _mockTaskRepository.Add(task1);
            _mockTaskRepository.Add(task2);

            // Act
            var result = _mockTaskRepository.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Task 1", result.Name);
            Assert.False(result.IsCompleted);
        }

        [Fact]
        public void GetById_ShouldReturnNullIfTaskNotFound()
        {
            // Act
            var result = _mockTaskRepository.GetById(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Update_ShouldModifyTask()
        {
            // Arrange
            var task = new TaskItem { Id = 1, Name = "Initial Task", IsCompleted = false };
            _mockTaskRepository.Add(task);

            var updatedTask = new TaskItem { Id = 1, Name = "Updated Task", IsCompleted = true };

            // Act
            _mockTaskRepository.Update(updatedTask);

            // Assert
            var result = _mockTaskRepository.GetById(1);
            Assert.NotNull(result);
            Assert.Equal("Updated Task", result.Name);
            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void Update_ShouldNotModifyTaskIfNotFound()
        {
            // Arrange
            var updatedTask = new TaskItem { Id = 1, Name = "Updated Task", IsCompleted = true };

            // Act
            _mockTaskRepository.Update(updatedTask);

            // Assert
            var result = _mockTaskRepository.GetById(1);
            Assert.Null(result);
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

        [Fact]
        public void Delete_ShouldNotThrowIfTaskNotFound()
        {
            // Act
            var exception = Record.Exception(() => _mockTaskRepository.Delete(1));

            // Assert
            Assert.Null(exception);
        }
    }

}
