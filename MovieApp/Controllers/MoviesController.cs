using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _context.Movies
                .Select(
                    m =>
                        new
                        {
                            m.Title,
                            m.Genre,
                            m.Description,
                            m.StartDate,
                            m.EndDate,
                            m.Price,
                            Images = m.Images.Select(i => i.Url).ToList(),
                            Movies = m.Actors.Select(a => a.Id).ToList(),
                            Cinemas = m.Cinemas.Select(c => c.Id).ToList(),
                        }
                )
                .ToListAsync(cancellationToken);

            return View();
        }
    }
}
