using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Models.ViewModels;
using TodoList.Services;

namespace TodoList.Controllers
{
    public class TodoTaskController : Controller
    {
        private readonly TodoTaskService _todoTaskService;
        private readonly UserService _userService;

        public TodoTaskController(TodoTaskService todoTaskService, UserService userService)
        {
            _todoTaskService = todoTaskService;
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
            var allTasks = await _todoTaskService.GetAllTasks();
            return View(allTasks);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var todoTask = await _todoTaskService.GetTodoTaskById(id);
            if (todoTask == null)
            {
                return NotFound();
            }
            return View(todoTask);
        }

        public async Task<ActionResult> Create()
        {
            var users = await _userService.GetAllUsersAsync();
            var viewModel = new TodoTaskFormViewModel() { Users = users };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TodoTaskFormViewModel todoTaskForm)
        {
            var user = await _userService.GetUserByIdAsync(todoTaskForm.Id);
            await _todoTaskService.CreateTodoTask(new TodoTask() { Title = todoTaskForm.Title, Description = todoTaskForm.Description, User = user });
            return RedirectToAction(nameof(Index));
        }

        // GET: TodoTaskController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var todoTask = await _todoTaskService.GetTodoTaskById(id);
            if(todoTask == null) 
            {
                return NotFound(id);
            }
            var todoTasktoEdit = new TodoTaskFormViewModel() { Id = todoTask.Id, Title = todoTask.Title, Description = todoTask.Description };
            return View(todoTasktoEdit);
        }

        // POST: TodoTaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditConfirmed(TodoTaskFormViewModel formViewModel)
        {
            await _todoTaskService.UpdateTodoTask(formViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var todoTask = await _todoTaskService.GetTodoTaskById(id);

            if (todoTask == null) 
            {
                return NotFound(id);
            }
            return View(todoTask);
        }

        // POST: TodoTaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid Id)
        {
            await _todoTaskService.DeleteTodoTask(Id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTodoTaskStatus(Guid taskId, bool isChecked)
        {
            await _todoTaskService.UpdateTodoTaskStatus(taskId, isChecked);
            var todoTask = await _todoTaskService.GetTodoTaskById(taskId);
            if (todoTask.Finished == true)
            {
                return Json(new { success = true, message = "Task marked as completed." });
            }
            else
            {
                return Json(new { success = true, message = "Task marked as to do." });
            }
        }
    }
}
