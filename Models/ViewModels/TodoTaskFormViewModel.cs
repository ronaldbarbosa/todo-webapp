using System.ComponentModel.DataAnnotations;

namespace TodoList.Models.ViewModels
{
    public class TodoTaskFormViewModel
    {
        [Display(Name = "User")]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
