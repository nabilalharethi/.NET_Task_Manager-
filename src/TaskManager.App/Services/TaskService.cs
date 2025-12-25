using System.Collections.Generic;
using System.Linq;
using TaskManager.App.Models;

namespace TaskManager.App.Services
{
    /// <summary>
    /// Service for managing task items.
    /// </summary>
    public class TaskService
    {
        private readonly List<TaskItem> _tasks;
        private int _nextId;

        public TaskService()
        {
            _tasks = new List<TaskItem>();
            _nextId = 1;
        }

        /// <summary>
        /// Adds a new task to the task list.
        /// </summary>
        public TaskItem AddTask(string description, DateTime dueDate)
        {
            var task = new TaskItem(_nextId++, description, dueDate);
            _tasks.Add(task);
            return task;
        }

        /// <summary>
        /// Retrieves all tasks.
        /// </summary>
        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        /// <summary>
        /// Finds a task by its unique identifier.
        /// </summary>
        public TaskItem GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }
        /// <summary>
        /// Mark a task as completed by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the task to mark as completed.</param>
        public bool MarkTaskAsCompleted(int id)
        {
            var task = GetTaskById(id);
            if (task != null && !task.IsCompleted)
            {
                task.MarkAsCompleted();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes a task by its unique identifier.
        /// </summary>
        public bool DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                _tasks.Remove(task);
                return true;
            }
            return false;
        }

        // <summary>
        //gets count of pending tasks
        public int GetPendingTaskCount()
        {
            return _tasks.Count(t => !t.IsCompleted);
        }
    }
        
}