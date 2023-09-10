namespace TodoList.Models.ViewModels
{
    public class TodoTasksAndListViewModel
    {
        public User User { get; set; }
        public IList<TodoTask> TodoTasks { get; set; }
        public IList<TodoTaskList> TodoTaskLists { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}
