using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Models.ViewModels;
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

        public async Task<IActionResult> Index()
        {
            var tags = await _tagService.GetTagsAsync();
            return View(tags);
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

        public async Task<IActionResult> Edit(int id)
        {
            var tag = await _tagService.GetTagAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            var viewModel = new TagEditViewModel { Id = tag.Id, Title = tag.Title };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TagEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var tag = await _tagService.GetTagAsync(id);
                tag.Title = viewModel.Title;
                await _tagService.EditTagAsync(tag);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            await _tagService.DeleteTagAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
