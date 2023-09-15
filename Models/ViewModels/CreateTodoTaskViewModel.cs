using System.ComponentModel.DataAnnotations;

namespace TodoList.Models.ViewModels
{
    public class CreateTodoTaskViewModel
    {
        [Display(Name = "Título")]
        public string Title { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Display(Name = "Prazo")]
        public DateTime DueDate { get; set; }
        [Display(Name = "Lista")]
        public IList<TodoTaskList>? TodoTaskLists { get; set; }
        public int? TodoTaskListId { get; set; }
    }
}
