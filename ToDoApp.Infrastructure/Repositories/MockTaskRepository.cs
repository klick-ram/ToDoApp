﻿using ToDoApp.Core.Models;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.Repositories
{
    public class MockTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();

        public IEnumerable<TaskItem> GetAll()
        {
            return _tasks;
        }

        public TaskItem GetById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TaskItem task)
        {
            _tasks.Add(task);
        }

        public void Update(TaskItem task)
        {
            var existingTask = GetById(task.Id);
            if (existingTask != null)
            {
                existingTask.Name = task.Name;
                existingTask.IsCompleted = task.IsCompleted;
            }
        }

        public void Delete(int id)
        {
            var task = GetById(id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }

}
