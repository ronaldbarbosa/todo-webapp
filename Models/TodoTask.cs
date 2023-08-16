using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Created")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Display(Name = "Updated")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool Finished { get; set; } = false;
        public User User { get; set; }
        public Guid UserId { get; set; }
        public TodoTask()
        {
        }

        public TodoTask(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public TodoTask(string title, string description, User user, Guid userId) : this(title, description)
        {
            User = user;
            UserId = userId;
        }
    }
}
