namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = "water";
            string inputDate = "01/01/2024";
            DateTime.TryParse(inputDate, out DateTime dateTime);
            TaskType taskType = TaskType.Work;
            TaskPriority taskPriority = TaskPriority.Normal;
            TaskState taskState = TaskState.New;


            Task task = new Task("water", "this is description", dateTime, taskType, taskPriority, taskState) {Title = title};
            

            System.Console.WriteLine(task.ToString());










        }
    }
}