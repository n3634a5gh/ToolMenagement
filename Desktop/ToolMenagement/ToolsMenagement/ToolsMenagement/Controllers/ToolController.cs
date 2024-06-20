using Microsoft.AspNetCore.Mvc;
using ToolsMenagement.Interfaces;
using ToolsMenagement.Models;

namespace ToolsMenagement.Controllers
{
    public class ToolController : Controller
    {
        private readonly IToolRepository _toolRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ToolController(IToolRepository toolRepository, ICategoryRepository categoryRepository)
        {
            _toolRepository = toolRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var kategorie = await _toolRepository.GetKategorieAsync();
            var viewController = new ToolViewController
            {
                Kategorie = kategorie.ToList()
            };
            return View(viewController);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToolViewController viewController)
        {
                var narzedzie = new Narzedzie
                {
                    IdKategorii = viewController.SelectedKategoriaId,
                    Nazwa = viewController.Nazwa,
                    Srednica = viewController.Srednica,
                    Magazyns = new List<Magazyn>
                    {
                        new Magazyn
                        {
                            Trwalosc = viewController.Trwalosc,
                            Uzycie = 0,
                            CyklRegeneracji = 0,
                            Wycofany = false,
                            Regeneracja = false
                        }
                    }
                };

                await _toolRepository.AddNarzedzieAsync(narzedzie);
                return RedirectToAction("Index");

            viewController.Kategorie = (await _toolRepository.GetKategorieAsync()).ToList();
            return View(viewController);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var narzedzia = await _toolRepository.GetNarzedziaWithMagazynAsync();
            return View(narzedzia);
        }
    }
}
