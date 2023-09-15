using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models.ViewModels;
using TodoList.Services;

namespace TodoList.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly TodoTaskService _todoTaskService;
        private readonly TodoTaskListService _todoTaskListService;
        private readonly TagService _tagService;

        public UserController(UserService userService, TodoTaskService todoTaskService, TodoTaskListService todoTaskListService, TagService tagService)
        {
            _userService = userService;
            _todoTaskService = todoTaskService;
            _todoTaskListService = todoTaskListService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new TodoTasksAndListViewModel
            {
                User = await _userService.GetUserAsync(User.Identity.Name),
                TodoTasks = await _todoTaskService.GetTodoTasksAsync(User.Identity.Name),
                TodoTaskLists = await _todoTaskListService.GetTodoTaskListAsync(User.Identity.Name),
                Tags = await _tagService.GetTagsAsync()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit()
        {
            var user = await _userService.GetUserAsync(User.Identity.Name);
            var viewModel = new EditUserViewModel { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                await _userService.EditUserAsync(model, User.Identity.Name);
                return RedirectToAction("Index", "User");
            }
            return View(model);
        }
    }
}
