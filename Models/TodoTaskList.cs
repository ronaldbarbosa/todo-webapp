namespace TodoList.Models
{
    public class TodoTaskList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }

        public IList<TodoTask> TodoTasks { get; set; } = new List<TodoTask>();
        public string UserId { get; set; }
        public User User { get; set; }

        public TodoTaskList()
        {
        }

        public TodoTaskList(string title, string color)
        {
            Title = title;
            Color = color;
        }
    }
}
