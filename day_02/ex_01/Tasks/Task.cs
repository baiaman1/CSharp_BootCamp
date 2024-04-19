// using Tasks;
using System;
namespace Tasks
{

    public class Task
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? DueDate { get; private set; }
        public TaskType Type { get; private set; }
        public TaskPriority Priority { get; private set; }
        public TaskState State { get; private set; }

        // Constructor
        public Task(string title, string description, DateTime? dueDate, TaskType type, TaskPriority priority)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Type = type;
            Priority = priority;
            State = TaskState.New;
        }

        public Task(string title, string description, TaskType type, TaskPriority priority)
        {
            Title = title;
            Description = description;
            Type = type;
            Priority = priority;
            State = TaskState.New;
        }

        // Override ToString() to provide custom string representation
        public override string ToString()
        {
            return $"{Title}\n[{Type}] [{State}]\nPriority: {Priority}{(DueDate.HasValue ? ", Due till " + DueDate.Value.ToString("MM/dd/yyyy") : "")}\n{Description}";
        }

        // Method to mark the task as completed
        public void MarkAsCompleted()
        {
            if (State != TaskState.Completed)
                State = TaskState.Completed;
        }

        // Method to mark the task as irrelevant
        public void MarkAsIrrelevant()
        {
            if (State != TaskState.Completed && State != TaskState.Irrelevant)
                State = TaskState.Irrelevant;
        }
    }

}