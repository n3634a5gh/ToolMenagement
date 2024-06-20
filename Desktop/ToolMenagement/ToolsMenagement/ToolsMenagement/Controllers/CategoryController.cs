using Microsoft.AspNetCore.Mvc;
using ToolsMenagement.Interfaces;
using ToolsMenagement.Models;

namespace ToolsMenagement.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _kategoriaRepository;

        public CategoryController(ICategoryRepository kategoriaRepository)
        {
            _kategoriaRepository = kategoriaRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kategorium kategoria)
        {
            if (ModelState.IsValid)
            {
                await _kategoriaRepository.AddCategoryAsync(kategoria);
                return RedirectToAction("Index");
            }
            return View(kategoria);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var kategorie = await _kategoriaRepository.GetCategoryAsync();
            return View(kategorie);
        }
    }
}
