using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Created")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Display(Name = "Updated")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
        public bool Finished { get; set; } = false;
        public User User { get; set; }
        public string UserId { get; set; }
        public IList<Tag>? Tags { get; set; }
        public TodoTaskList? TodoTaskList { get; set; }
        public int? TodoTaskListId { get; set; }

        public TodoTask()
        {
        }

        public TodoTask(int id, string title, string description, string userId)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Description = description;
        }

        public TodoTask(int id, string title, string description, string userId, IList<Tag>? tags, TodoTaskList? todoTaskList, int? todoTaskListId) : this(id, title, description, userId)
        {
            Tags = tags;
            TodoTaskList = todoTaskList;
            TodoTaskListId = todoTaskListId;
        }
    }
}
