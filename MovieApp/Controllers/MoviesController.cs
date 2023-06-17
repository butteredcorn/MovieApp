using Microsoft.AspNetCore.Mvc;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var movieDTOs = await _service.GetAll(cancellationToken);

            return View(movieDTOs);
        }
    }
}
