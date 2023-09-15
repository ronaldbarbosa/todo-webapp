using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Models.ViewModels;
using TodoList.Services;

namespace TodoList.Controllers
{
    public class TodoTaskController : Controller
    {
        private readonly TodoTaskService _todoTaskService;
        private readonly TodoTaskListService _todoTaskListService;
        private readonly UserService _userService;

        public TodoTaskController(TodoTaskService todoTaskService, TodoTaskListService todoTaskListService, UserService userService)
        {
            _todoTaskService = todoTaskService;
            _todoTaskListService = todoTaskListService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _todoTaskService.GetTodoTasksAsync(User.Identity.Name);
            return View("_TodoTaskList", tasks);
        }

        public async Task<IActionResult> Create()
        {
            var username = User.Identity.Name;
            var lists = await _todoTaskListService.GetTodoTaskListAsync(username);
            var viewModel = new CreateTodoTaskViewModel() { TodoTaskLists = lists, DueDate = DateTime.Today};
            return View("_Create", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTodoTaskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = await _userService.GetUserIdAsync(User.Identity.Name);
                var todoTask = new TodoTask() 
                { 
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    DueDate = viewModel.DueDate,
                    UserId = userId,
                    TodoTaskListId = viewModel.TodoTaskListId
                };

                await _todoTaskService.CreateTodoTaskAsync(todoTask);
                return RedirectToAction("Index", "User");
            }
            return View("_Create", viewModel);
        }
    }
}
