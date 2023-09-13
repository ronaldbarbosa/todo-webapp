using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers
{
    public class TagController : Controller
    {
        private readonly TagService _tagService;

        public TagController(TagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title)
        {
            if (title == null || title == "") 
            {
                return Json(new { result = "O título da tag é obrigtório!" });
            }
            await _tagService.CreateTagAsync(new Tag(title));
            return Json(new { result = "Tag adicionada com sucesso!" } );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
