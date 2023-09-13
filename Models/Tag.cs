namespace TodoList.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<TodoTask>? TodoTasks { get; set; } = new List<TodoTask>();

        public Tag(string title)
        {
            Title = title;
        }

        public Tag(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
