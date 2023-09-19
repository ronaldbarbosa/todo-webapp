using Microsoft.AspNetCore.Mvc;
using TodoList.Services;

namespace TodoList.Controllers
{
    public class TodoTaskListController : Controller
    {
        private readonly TodoTaskListService _todoTaskListService;

        public TodoTaskListController(TodoTaskListService todoTaskListService)
        {
            _todoTaskListService = todoTaskListService;
        }

        public async Task<IActionResult> GetTodoTaskListsAsync(string username)
        {
            var todoTaskLists = await _todoTaskListService.GetTodoTaskListsAsync(username);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title)
        {
            if (string.IsNullOrEmpty(title)) 
            {
                return Json(new { result = "O título da lista é obrigtório!" });
            }

            await _todoTaskListService.CreateTodoTaskListAsync(title, User.Identity.Name);
            return Json(new { result = "Lista de tarefas criada com sucesso!" });
        }
    }
}
