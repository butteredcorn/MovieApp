using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;

namespace MovieApp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _context.Cinemas
                .Select(
                    c =>
                        new
                        {
                            c.Name,
                            c.Description,
                            MovieIds = c.Movies.Select(m => m.Id)
                        }
                )
                .ToListAsync(cancellationToken);

            return View();
        }
    }
}
