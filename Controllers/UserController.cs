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

        public UserController(UserService userService)
        {
            _userService = userService;
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
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
