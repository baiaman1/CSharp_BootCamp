// namespace Tasks
// {

//     public enum Breed {Dog, Cat, Rat}

//     class Animal
//     {
//         public Breed breed;
//          public Animal(Breed breed)
//          {
//             this.breed = breed;
//          }
//          public void PrinRR()
//          {
//             System.Console.WriteLine(breed);
//          }
//     }
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Animal dog = new(Breed.Rat);
//             dog.PrinRR();
            
//             // Task task = new(State.New);
//             // task.PrintType(); // Пример вызова метода из Task.cs

            
//         }
//     }
// }




using System;
using System.Collections.Generic;

namespace Tasks
{
    class Program
    {
        static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Task Tracker!");

            while (true)
            {
                Console.WriteLine("\nEnter method:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "add":
                        AddTask();
                        break;
                    case "list":
                        ListTasks();
                        break;
                    case "done":
                        MarkTaskAsCompleted();
                        break;
                    case "wontdo":
                        MarkTaskAsIrrelevant();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.WriteLine("Enter task details:");
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Due Date (MM/dd/yyyy): ");
            DateTime? dueDate = ParseDateTime(Console.ReadLine());
            Console.Write("Type (Work/Study/Personal): ");
            TaskType type = ParseEnum<TaskType>(Console.ReadLine());
            Console.Write("Priority (Low/Normal/High): ");
            TaskPriority priority = ParseEnum<TaskPriority>(Console.ReadLine());
            // if (dueDate != null)
            Task task = new Task(title, description, dueDate, type, priority);
            tasks.Add(task);
            Console.WriteLine("Task added successfully.");
        }

        static void ListTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("The task list is empty.");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine(task);
                Console.WriteLine();
            }
        }

        static void MarkTaskAsCompleted()
        {
            Console.Write("Enter the title of the task to mark as completed: ");
            string title = Console.ReadLine();
            Task task = FindTaskByTitle(title);
            if (task != null)
            {
                task.MarkAsCompleted();
                Console.WriteLine($"The task [{title}] is completed!");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        static void MarkTaskAsIrrelevant()
        {
            Console.Write("Enter the title of the task to mark as irrelevant: ");
            string title = Console.ReadLine();
            Task task = FindTaskByTitle(title);
            if (task != null)
            {
                task.MarkAsIrrelevant();
                Console.WriteLine($"The task [{title}] is no longer relevant.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        static DateTime? ParseDateTime(string input)
        {
            if (DateTime.TryParseExact(input, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                return result;
            return null;
        }

        static T ParseEnum<T>(string input)
        {
            return (T)Enum.Parse(typeof(T), input, true);
        }

        static Task FindTaskByTitle(string title)
        {
            return tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}