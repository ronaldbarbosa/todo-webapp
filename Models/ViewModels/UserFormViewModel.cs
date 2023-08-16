using System.ComponentModel.DataAnnotations;

namespace TodoList.Models.ViewModels
{
    public class UserFormViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
