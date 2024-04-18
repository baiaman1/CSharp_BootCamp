namespace ToDo
{
    // class Task(string title, string summary, DateTime dueDate, TaskType type, TaskPriority priority, TaskState state)
    // {
    //     public required string Title { get; init; } = title;
    //     private string? Summary {get;} = summary;
    //     private DateTime DueDate {get;} = dueDate;
    //     private TaskType Type = type; 
    //     private TaskPriority Priority = priority;
    //     private TaskState State = state; 
    // }


    class Task
    {
 

        public Task(string title, string summary, DateTime dueDate, TaskType type, TaskPriority priority, TaskState state)
        {


            this.Title = title;
            this.Summary = summary;
            this.DueDate = dueDate;
            this.Type = type;
            this.Priority = priority;
            this.State = state;
        }

        public required string Title { get; init; } 
        private string? Summary {get;}
        private DateTime DueDate {get;}
        private TaskType Type; 
        private TaskPriority Priority;
        private TaskState State;
        public override string ToString()
        {
            return $"1.Title-{Title}\n2.Summary-{Summary}\n3.DueDate-{DueDate}\n4.Type-{Type}\n5.Priority-{Priority}\n6.State-{State}\n";
        }
    }



}