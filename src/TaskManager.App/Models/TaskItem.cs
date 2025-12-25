using System;

namespace TaskManager.App.Models
{
    //<summary>
    // Represents a task item in the task manager application.

    public class TaskItem
    {
       // <summary>
        // Gets or sets the unique identifier for the task.
        public int Id { get; set; }
        // <summary>
        // Gets or sets the description of the task.
        public string Description { get; set; }
        // <summary>   
        // Gets or sets the due date of the task.
        public DateTime DueDate { get; set; }
        // <summary>   
        // Gets or sets a value indicating whether the task is completed.
        public bool IsCompleted { get; set; }

        // <summary>
        // when the task was created
        public DateTime CreatedAt { get; set; }

        // <summary>
        // when the task was last updated  
        public DateTime UpdatedAt { get; set; }

        // <summary>
        //constructor to initialize a new task item
        // <param name="description">The description of the task.</param>
        // <param name="dueDate">The due date of the task.</param>
        //<parm name="Id">The unique identifier for the task.</parm>
        public TaskItem(int id, string description, DateTime dueDate)
        {
            Id = id;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Marks the task as completed and updates the UpdatedAt timestamp.
        public void MarkAsCompleted()
        {
            IsCompleted = true;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        // Updates the task description and updates the UpdatedAt timestamp.
        public override string ToString()
        {
            var status = IsCompleted ? "Completed" : "Pending";
            return $"[ID: {Id}] {Description} - Due: {DueDate.ToShortDateString()} - Status: {status}";
        }
    }
}

