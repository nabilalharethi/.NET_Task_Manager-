using System;
using TaskManager.App.Services;
using TaskManager.App.Models;

namespace TaskManager.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskService = new TaskService();
            bool running = true;

            Console.WriteLine("Welcome to the Task Manager!");
            Console.WriteLine("----------------------------");

            while (running)
            {
                DisplayMenu();
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewTask(taskService);
                        break;
                    case "2":
                        ViewAllTasks(taskService);
                        break;
                    case "3":
                        MarkTaskAsCompleted(taskService);
                        break;
                    case "4":
                        DeleteTask(taskService);
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Exiting Task Manager. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add New Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }

        static void AddNewTask(TaskService taskService)
        {
            Console.Write("Enter task description: ");
            var description = Console.ReadLine();

            Console.Write("Enter due date (yyyy-mm-dd): ");
            var dueDateInput = Console.ReadLine();

            if (DateTime.TryParse(dueDateInput, out DateTime dueDate))
            {
                var task = taskService.AddTask(description, dueDate);
                Console.WriteLine($"Task added: {task}");
            }
            else
            {
                Console.WriteLine("Invalid date format. Task not added.");
            }
        }

        static void ViewAllTasks(TaskService taskService)
        {
            var tasks = taskService.GetAllTasks();

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
            }
            else
            {
                Console.WriteLine("Tasks:");
                foreach (var task in tasks)
                {
                    Console.WriteLine(task);
                }
            }
        }

        static void MarkTaskAsCompleted(TaskService taskService)
        {
            Console.Write("Enter task ID to mark as completed: ");
            var idInput = Console.ReadLine();

            if (int.TryParse(idInput, out int id))
            {
                if (taskService.MarkTaskAsCompleted(id))
                {
                    Console.WriteLine("Task marked as completed.");
                }
                else
                {
                    Console.WriteLine("Task not found or already completed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        static void DeleteTask(TaskService taskService)
        {
            Console.Write("Enter task ID to delete: ");
            var idInput = Console.ReadLine();

            if (int.TryParse(idInput, out int id))
            {
                if (taskService.DeleteTask(id))
                {
                    Console.WriteLine("Task deleted.");
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }
    }
}
