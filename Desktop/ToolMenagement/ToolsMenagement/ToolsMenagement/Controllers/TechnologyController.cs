using Microsoft.AspNetCore.Mvc;
using ToolsMenagement.Interfaces;
using ToolsMenagement.Models;

namespace ToolsMenagement.Controllers
{
    public class TechnologyController : Controller
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IToolRepository _toolRepository;

        public TechnologyController(ITechnologyRepository technologyRepository, IToolRepository toolRepository)
        {
            _technologyRepository = technologyRepository;
            _toolRepository = toolRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var tools = await _toolRepository.GetNarzedziaAsync();
            var view = new TechnologyViewController
            {
                Narzedzia = tools.ToList(),
                SelectedNarzedziaIds = new List<int>()
            };
            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TechnologyViewController view)
        {
            if (ModelState.IsValid)
            {
                var technologia = new Technologium
                {
                    Opis = view.Opis,
                    DataUtworzenia = view.DataUtworzenia,
                    NarzedziaTechnologia = view.SelectedNarzedziaIds.Select(id => new NarzedziaTechnologium
                    {
                        IdNarzedzia = id
                    }).ToList()
                };

                await _technologyRepository.AddTechnologyAsync(technologia);
                return RedirectToAction("Index");
            }
            view.Narzedzia = (await _toolRepository.GetNarzedziaAsync()).ToList();
            return View(view);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var technologie = await _technologyRepository.GetTechnologiesAsync();
            return View(technologie);
        }
    }
}
