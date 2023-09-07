namespace TodoList.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<TodoTask>? TodoTasks { get; set; }
    }
}
