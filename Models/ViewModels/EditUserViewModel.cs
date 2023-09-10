using System.ComponentModel.DataAnnotations;

namespace TodoList.Models.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
