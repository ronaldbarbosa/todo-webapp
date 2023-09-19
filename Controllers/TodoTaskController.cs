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
        
        public async Task<IActionResult> TodoTaskInfo(int Id)
        {
            var todoTask = await _todoTaskService.GetTodoTaskAsync(Id);
            var viewModel = new EditTodoTaskViewModel {
                Id = todoTask.Id,
                Title = todoTask.Title,
                Description = todoTask.Description,
                DueDate = todoTask.DueDate,
                TodoTaskLists = await _todoTaskListService.GetTodoTaskListsAsync(User.Identity.Name),
                TodoTaskListId = todoTask.TodoTaskListId,
            };
            return View("_TodoTaskInfo", viewModel);
        }

        public async Task<IActionResult> TodoTaskListToday()
        {
            var tasks = await _todoTaskService.GetTodoTasksAsync(User.Identity.Name);
            return View("_TodoTaskListToday", tasks);
        }

        public async Task<IActionResult> TodoTaskListUpcoming()
        {
            var tasks = await _todoTaskService.GetTodoTasksAsync(User.Identity.Name);
            return View("_TodoTaskListUpcoming", tasks);
        }

        public async Task<IActionResult> Create()
        {
            var username = User.Identity.Name;
            var lists = await _todoTaskListService.GetTodoTaskListsAsync(username);
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
                var todoTask = new TodoTask();
                if (viewModel.TodoTaskListId != null)
                {
                    var todoTaskList = await _todoTaskListService.GetTodoTaskListAsync(User.Identity.Name, viewModel.TodoTaskListId);

                    todoTask.Title = viewModel.Title;
                    todoTask.Description = viewModel.Description;
                    todoTask.DueDate = viewModel.DueDate;
                    todoTask.UserId = userId;
                    todoTask.TodoTaskList = todoTaskList;
                    todoTask.TodoTaskListId = viewModel.TodoTaskListId;
                }
                else
                {
                    todoTask.Title = viewModel.Title;
                    todoTask.Description = viewModel.Description;
                    todoTask.DueDate = viewModel.DueDate;
                    todoTask.UserId = userId;
                }

                await _todoTaskService.CreateTodoTaskAsync(todoTask);
                return RedirectToAction("Index", "User");
            }
            return View("_Create", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EditTodoTaskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var todoTask = await _todoTaskService.GetTodoTaskAsync(viewModel.Id);
                if (todoTask != null)
                {
                    todoTask.Title = viewModel.Title;
                    todoTask.Description = viewModel.Description;
                    todoTask.DueDate= viewModel.DueDate;
                    todoTask.TodoTaskListId = viewModel.TodoTaskListId;

                    if (viewModel.TodoTaskListId != null)
                    {
                        todoTask.TodoTaskList = await _todoTaskListService.GetTodoTaskListAsync(User.Identity.Name, todoTask.TodoTaskListId);
                    }

                    await _todoTaskService.UpdateTodoTaskAsync(todoTask);
                    viewModel.TodoTaskLists = await _todoTaskListService.GetTodoTaskListsAsync(User.Identity.Name);

                    return RedirectToAction("Index", "User");
                }
            }
            return View("_TodoTaskInfo");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodoTaskStatus(int id, bool finished)
        {
            var todoTask = await _todoTaskService.GetTodoTaskAsync(id);
            if (todoTask == null) 
            {
                return Json(new { Erro = "Erro:", Mensagem = "Usuário não encontrado" });
            }
            todoTask.Finished = finished;
            await _todoTaskService.UpdateTodoTaskAsync(todoTask);
            return Json(new { Sucesso = "Sucesso:", Mensagem = "Tarefa atualizada com sucesso" });
        }
    }
}
