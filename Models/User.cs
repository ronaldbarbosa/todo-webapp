using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public ICollection<TodoTask> TodoTasks { get; set; }

        public User() { }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            TodoTasks = new List<TodoTask>();
        }
    }
}
