using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TodoList.Models.ViewModels;
using TodoList.Services;

namespace TodoList.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserFormViewModel userForm)
        {
            await _userService.CreateUserAsync(userForm);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userEdit = new UserFormViewModel() { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName };
            return View(userEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserFormViewModel userForm)
        {
            await _userService.UpdateUserAsync(userForm);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) 
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var deleted = await _userService.DeleteUserAsync(id);
            if (!deleted)
            {
                return RedirectToAction(nameof(CantDelete));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CantDelete() 
        {
            return View();
        }
    }
}
