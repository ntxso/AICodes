using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonRepository _repository;
        private readonly LoggerService _logger;

        public PersonController(PersonRepository repository, LoggerService logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var persons = await _repository.GetAllPersonsAsync();
            return View(persons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddPersonAsync(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // Diğer metotlar...
    }
}
